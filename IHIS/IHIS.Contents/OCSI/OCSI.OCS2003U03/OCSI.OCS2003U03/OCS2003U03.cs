using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSI
{
    public partial class OCS2003U03 : XScreen
    {
        public OCS2003U03()
        {
            InitializeComponent();
        }

        private string mParamBunho = "";
        private string mParamFkinp1001 = "";
        private string mParamInputGwa = "";
        private string mParamInputDoctor = "%";
        private string mParamQueryDate = "";
        private int mAfterQuerySetFocusRow = -1;
        private string mAfterQuerySetFocusColName = "";

        private ArrayList sourceList = new ArrayList(); // 返却対象PKOCS2003

        private bool isProcessingYN = false;

        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리

        // 라디오 버튼 back 컬러
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        //// 라디오 버튼 관련 동적생성 변수
        //private int mInputTabDefaultWidth = 111;
        //private int mInputTabDefaultHeight = 31;
        //private int mInputTabDefaultYLoc = 5;
        //private int mInputTabDefaultXLoc = 9;

        //private class mCancelItem
        //{
        //    string drg_bunho="";
        //    string jubsu_date = "";
        //    string input_tab = "";
        //}

        // 프린트 해야 할 처방전 리스트
        private ArrayList mCancel_drg_bunho_list = new ArrayList();
        private ArrayList mCancel_jubsu_list = new ArrayList();
        private ArrayList mCancel_input_list = new ArrayList();

        //private List<mCancelItem> mCancel_info = new List<mCancelItem>();

        private ArrayList drg_bunho = new ArrayList();
       

        #region [ Screen 이벤트 ]

        private void OCS2003U03_Load(object sender, EventArgs e)
        {
            this.mOrderBiz = new IHIS.OCS.OrderBiz(this.Name);             // OCS 그룹 Business 라이브러리

            if (this.OpenParam != null) 
            {
                if (this.OpenParam.Contains("bunho"))
                {
                    this.mParamBunho = this.OpenParam["bunho"].ToString();
                }

                if (this.OpenParam.Contains("fkinp1001"))
                {
                    this.mParamFkinp1001 = this.OpenParam["fkinp1001"].ToString();
                }

                if (this.OpenParam.Contains("gwa"))
                {
                    this.mParamInputGwa = this.OpenParam["gwa"].ToString();
                }

                if (this.OpenParam.Contains("doctor"))
                {
                    this.mParamInputDoctor = this.OpenParam["doctor"].ToString();
                }
                if (this.OpenParam.Contains("query_date"))
                {
                    this.mParamQueryDate = this.OpenParam["query_date"].ToString();
                    this.dtpQueryDate.SetDataValue(this.mParamQueryDate);
                }
                //this.ParentForm.WindowState = FormWindowState.Minimized;
                // 중지
                //this.LoadAllData();
                this.paBox.SetPatientID(this.mParamBunho);
                this.paBox.Enabled = false;
            }

            this.dpkStop_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            //this.dpkStopEnd_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            this.initScreen();
        }
        private void initScreen()
        {
            this.grdOrder_date.AutoSizeColumn(12, 0);   //返却対象あり
            this.grdOrder.AutoSizeColumn(14, 0);        // 検体
            this.grdDrugOrder.AutoSizeColumn(11, 0);    // 検体
            this.mOrderBiz.SetNumCombo(this.grdOrder, "dv", false);
            this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_return", false);
            this.mOrderBiz.SetNumCombo(this.grdOrder, "dv_toiwon", false);

            this.SetPartReturnColumn(false, "all");
        }

        private void SetPartReturnColumn(bool aONOFF, string aGubun)
        {
            if (aONOFF)
            {
                

                if (aGubun == "dv_return")
                {
                    this.grdOrder[0, 17].Value = "部分返却する回数、服用コード";
                    this.grdOrder.AutoSizeColumn(18, 60); // 返却服用コード
                    this.grdOrder.AutoSizeColumn(19, 120); // 返却服用方法
                }
                else if (aGubun == "dv_toiwon")
                {
                    this.grdOrder[0, 20].Value = "退院処方へ変更する回数、服用コード";
                    this.grdOrder.AutoSizeColumn(21, 60); // 退院服用コード
                    this.grdOrder.AutoSizeColumn(22, 120); // 退院服用方法
                }
                else
                {
                    this.grdOrder.AutoSizeColumn(18, 60); // 返却服用コード
                    this.grdOrder.AutoSizeColumn(19, 120); // 返却服用方法
                    this.grdOrder.AutoSizeColumn(21, 60); // 退院服用コード
                    this.grdOrder.AutoSizeColumn(22, 120); // 退院服用方法
                }
            }
            else
            {
                this.grdOrder.AutoSizeColumn(14, 0);        // 検体

                if (aGubun == "dv_return")
                {
                    this.grdOrder[0, 17].Value = "部分\r\n返却";
                    this.grdOrder.AutoSizeColumn(18, 0); // 返却服用コード
                    this.grdOrder.AutoSizeColumn(19, 0); // 返却服用方法
                }
                else if (aGubun == "dv_toiwon")
                {
                    this.grdOrder[0, 20].Value = "退院\r\n処方";
                    this.grdOrder.AutoSizeColumn(21, 0); // 退院服用コード
                    this.grdOrder.AutoSizeColumn(22, 0); // 退院服用方法
                }
                else
                {
                    this.grdOrder.AutoSizeColumn(18, 0); // 返却服用コード
                    this.grdOrder.AutoSizeColumn(19, 0); // 返却服用方法
                    this.grdOrder.AutoSizeColumn(21, 0); // 退院服用コード
                    this.grdOrder.AutoSizeColumn(22, 0); // 退院服用方法
                }
            }
        }
        private void OCS2003U03_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            int width = this.Width;
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            if (rc.Width - 30 < this.Width)
            {
                width = rc.Width - 30;
            }
            this.ParentForm.Size = new System.Drawing.Size(width, this.Height);
        }
        #endregion
        #region [환자정보 처리]
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            this.paBox.SetPatientID(info.BunHo);
            base.OnReceiveBunHo(info);
        }
         #endregion
        #region [ 데이터 로드 ]

        private void LoadAllData()
        {
            this.grdOrder_date.QueryLayout(true);
        }


        #endregion

        #region [ Process Call ]

        private bool BannabProcess(bool aIsBannab, string aGubun)
        {
            string procName = "PR_OCSI_PROCESS_BANNAB_NEW";
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();

            sourceList.Clear();

            string sysdate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            string aWorkGubun = "";
            string MagamSer = "";
            //mCancel_info.Clear();
            mCancel_drg_bunho_list.Clear();
            mCancel_jubsu_list.Clear();
            mCancel_input_list.Clear();

            switch (aGubun)
            {
                case "1":
                    aWorkGubun = (aIsBannab == true ? "I" : "C");
                    break;
                case "2":
                    aWorkGubun = "T";
                    break;
                //case "3":
                //    aWorkGubun = "J";
                //    break;

            }
            Service.BeginTransaction();
            try
            {
                foreach (DataRow row in this.grdOrder.LayoutTable.Rows)
                {
                    if (row["select_yn"].ToString() == "Y")
                    {
                        this.sourceList.Add(row["pkocs2003"].ToString());

                        inList.Clear();
                        inList.Add(aWorkGubun); //aIsBannab(rbtDC.Checked)
                        inList.Add(row["bunho"].ToString());
                        inList.Add(row["fkinp1001"].ToString());
                        inList.Add(row["pkocs2003"].ToString());
                        inList.Add((aIsBannab == true ? row["stop_date"].ToString() : sysdate));
                        inList.Add((aIsBannab == true ? TypeCheck.NVL(row["stop_end_date"].ToString(), row["stop_date"].ToString()) : sysdate));

                        if(UserInfo.UserGubun == UserType.Doctor)
                            inList.Add(UserInfo.DoctorID); 
                        else
                            inList.Add(row["input_doctor"].ToString());

                        inList.Add(UserInfo.UserID);

                        inList.Add(aGubun); // 1:返却、2:退院処方に変更、3:注射返却

                        inList.Add(TypeCheck.NVL(row["dv_return"].ToString(), row["dv"].ToString())); // 返却回数
                        inList.Add(row["bogyong_code_return"].ToString()); // 返却後服用方法

                        inList.Add(TypeCheck.NVL(row["dv_toiwon"].ToString(), row["dv"].ToString())); // 退院処方回数
                        inList.Add(row["bogyong_code_toiwon"].ToString()); // 退院処方服用方法
                        
                        
                        if((row["input_tab"].ToString()=="01")||
                           (row["input_tab"].ToString()=="03"))
                        {

                            if(!mCancel_drg_bunho_list.Contains(row["drg_bunho"].ToString()))
                            {
                                //if (row["drg_bunho"].ToString() == "")
                                //{
                                //    throw new Exception(XMsg.GetMsg("M004"));
                                //}
                                //mCancel_drg_bunho_list.Add(row["drg_bunho"].ToString());
                                //mCancel_jubsu_list.Add(row["jubsu_date"].ToString());
                                //mCancel_input_list.Add(row["input_tab"].ToString());

                                if (row["drg_bunho"].ToString() != "")
                                {
                                    mCancel_drg_bunho_list.Add(row["drg_bunho"].ToString());
                                    mCancel_jubsu_list.Add(row["jubsu_date"].ToString());
                                    mCancel_input_list.Add(row["input_tab"].ToString());
                                }
                            }
                        }

                        outList.Clear();

                        if (Service.ExecuteProcedure(procName, inList, outList) == false)
                        {
                            //MessageBox.Show(XMsg.GetMsg("M004") + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Service.RollbackTransaction();
                            //return false;

                            throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                        }

                        if (outList[0].ToString() != "0")
                        {
                            //MessageBox.Show(XMsg.GetMsg("M004") + "-" + outList[0].ToString(), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Service.RollbackTransaction();
                            //return false;

                            throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                        }
                    }
                }

                #region 薬局自動受付
                this.drg_bunho = new ArrayList();
                if (true)
                {
                    if (aWorkGubun != "C")
                    {
                        /*
                            I_JUBSU_DATE       IN        DATE
                          , I_ORDER_DATE       IN        DATE
                          , I_HOPE_DATE        IN        DATE
                          , I_MAGAM_GUBUN      IN        VARCHAR2  -- 11, 12, 21, 22, 31, 32
                          , I_BUNHO            IN        VARCHAR2
                          , I_DOCTOR           IN        VARCHAR2
                          , I_MAGAM_USER       IN        VARCHAR2
                          , O_DRG_BUNHO        IN  OUT   NUMBER
                          , IO_ERR             IN  OUT   VARCHAR2

                         */

                        /*
                         
                          SELECT I_STOP_DATE - NVL(A1.HOPE_DATE, A1.ORDER_DATE)
                            INTO P_NEW_NALSU
                            FROM DUAL;
                          
                          P_NEW_NALSU_TO :=  A1.NALSU - ( ( (I_STOP_DATE2 -I_STOP_DATE) + 1 ) + P_NEW_NALSU);

                           -- A1.NALSUが1であれば　NEWDATAをスキップする。
                          IF NVL(P_NEW_NALSU_TO, 0) = 0 OR A1.NALSU <= 1  THEN
                            GOTO SKIP_NEW_INSERT ;
                          END IF;
                         */

                        procName = "PR_DRG_INP_MAGAM_PROC";
                        
                        string magam_gubun = "";
                        foreach (DataRow row in this.grdOrder.LayoutTable.Rows)
                        {
                            if (row["select_yn"].ToString() != "Y") continue;

                            int new_nalsu    = (DateTime.Parse(row["stop_date"].ToString()) - DateTime.Parse(row["start_date"].ToString())).Days;
                            int new_nalsu_to = int.Parse(row["nalsu"].ToString()) - (((DateTime.Parse(TypeCheck.NVL(row["stop_end_date"].ToString(), row["stop_date"].ToString()).ToString()) - DateTime.Parse(row["stop_date"].ToString())).Days + 1) + new_nalsu);

                            

                            if (new_nalsu > 0)
                            {
                                inList = new ArrayList();
                                outList = new ArrayList();

                                if (   row["order_gubun"].ToString().Substring(1, 1) == "B"
                                    || row["order_gubun"].ToString().Substring(1, 1) == "C"
                                    || row["order_gubun"].ToString().Substring(1, 1) == "D")
                                {
                                    if (row["select_yn"].ToString() == "Y")
                                    {
                                        // SET
                                        inList.Add(EnvironInfo.CurrSystemID);
                                        inList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // JUBSU_DATE
                                        // WHERE
                                        inList.Add(row["order_date"].ToString()); // ORDER_DATE
                                        inList.Add(row["start_date"].ToString()); // HOPE_DATE


                                        switch (row["input_gubun"].ToString())
                                        {
                                            case "D0":
                                                magam_gubun = "1";
                                                break;
                                            case "D4":
                                                magam_gubun = "2";
                                                break;
                                            case "D7":
                                                magam_gubun = "3";
                                                break;
                                        }

                                        if (row["order_gubun"].ToString().Substring(1, 1) == "B")
                                            magam_gubun = magam_gubun + "2";
                                        else
                                            magam_gubun = magam_gubun + "1";

                                        inList.Add(magam_gubun);

                                        MagamSer = this.getMagamSer(inList[1].ToString(), inList[4].ToString(), row["input_doctor"].ToString());
                                        if(MagamSer != "0")
                                            inList.Add(MagamSer);
                                        else
                                            throw new Exception(XMsg.GetMsg("M004")+"締切番号が正常に取得されていません。");

                                        inList.Add(row["bunho"].ToString());

                                        if (UserInfo.UserGubun == UserType.Doctor)
                                        {
                                            inList.Add(UserInfo.DoctorID);
                                            inList.Add(UserInfo.DoctorID);
                                        }
                                        else
                                        {
                                            inList.Add(row["input_doctor"].ToString());
                                            inList.Add(row["input_doctor"].ToString());
                                        }

                                        if (Service.ExecuteProcedure(procName, inList, outList) == false)
                                        {
                                            throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                                        }
                                        else
                                        {
                                            if (!drg_bunho.Contains(outList[0].ToString()) && outList[0].ToString() != "0" && outList[0].ToString() != "")
                                                drg_bunho.Add(row["order_gubun"].ToString().Substring(1, 1) + inList[1].ToString() + outList[0].ToString());
                                        }
                                    }
                                }
                            }

                            if (row["dv"].ToString() != TypeCheck.NVL(row["dv_return"].ToString(), row["dv"].ToString()).ToString())
                            {
                                inList = new ArrayList();
                                outList = new ArrayList();

                                if (row["order_gubun"].ToString().Substring(1, 1) == "B"
                                    || row["order_gubun"].ToString().Substring(1, 1) == "C"
                                    || row["order_gubun"].ToString().Substring(1, 1) == "D")
                                {
                                    if (row["select_yn"].ToString() == "Y")
                                    {
                                        inList.Add(EnvironInfo.CurrSystemID);
                                        // SET
                                        inList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // JUBSU_DATE
                                        // WHERE
                                        inList.Add(row["order_date"].ToString()); // ORDER_DATE
                                        inList.Add(row["stop_date"].ToString()); // HOPE_DATE


                                        switch (row["input_gubun"].ToString())
                                        {
                                            case "D0":
                                                magam_gubun = "1";
                                                break;
                                            case "D4":
                                                magam_gubun = "2";
                                                break;
                                            case "D7":
                                                magam_gubun = "3";
                                                break;
                                        }

                                        if (row["order_gubun"].ToString().Substring(1, 1) == "B")
                                            magam_gubun = magam_gubun + "2";
                                        else
                                            magam_gubun = magam_gubun + "1";

                                        inList.Add(magam_gubun);
                                        
                                        MagamSer = this.getMagamSer(inList[1].ToString(), inList[4].ToString(), row["input_doctor"].ToString());
                                        if (MagamSer != "0")
                                            inList.Add(MagamSer);
                                        else
                                            throw new Exception(XMsg.GetMsg("M004") + "締切番号が正常に取得されていません。");

                                        inList.Add(row["bunho"].ToString());

                                        if (UserInfo.UserGubun == UserType.Doctor)
                                        {
                                            inList.Add(UserInfo.DoctorID);
                                            inList.Add(UserInfo.DoctorID);
                                        }
                                        else
                                        {
                                            inList.Add(row["input_doctor"].ToString());
                                            inList.Add(row["input_doctor"].ToString());
                                        }

                                        if (Service.ExecuteProcedure(procName, inList, outList) == false)
                                        {
                                            throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                                        }
                                        else
                                        {
                                            if (!drg_bunho.Contains(outList[0].ToString()) && outList[0].ToString() != "0" && outList[0].ToString() != "")
                                                drg_bunho.Add(row["order_gubun"].ToString().Substring(1, 1) + inList[1].ToString() + outList[0].ToString());
                                        }

                                    }
                                }
                            }

                            if (new_nalsu_to > 0)
                            {
                                inList = new ArrayList();
                                outList = new ArrayList();

                                if (   row["order_gubun"].ToString().Substring(1, 1) == "B"
                                    || row["order_gubun"].ToString().Substring(1, 1) == "C"
                                    || row["order_gubun"].ToString().Substring(1, 1) == "D")
                                {
                                    if (row["select_yn"].ToString() == "Y")
                                    {
                                        inList.Add(EnvironInfo.CurrSystemID);
                                        // SET
                                        inList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // JUBSU_DATE
                                        // WHERE
                                        inList.Add(row["order_date"].ToString()); // ORDER_DATE
                                        inList.Add(DateTime.Parse(TypeCheck.NVL(row["stop_end_date"].ToString(), row["stop_date"].ToString()).ToString()).AddDays(1).ToString("yyyy/MM/dd")); // HOPE_DATE


                                        switch (row["input_gubun"].ToString())
                                        {
                                            case "D0":
                                                magam_gubun = "1";
                                                break;
                                            case "D4":
                                                magam_gubun = "2";
                                                break;
                                            case "D7":
                                                magam_gubun = "3";
                                                break;
                                        }

                                        if (row["order_gubun"].ToString().Substring(1, 1) == "B")
                                            magam_gubun = magam_gubun + "2";
                                        else
                                            magam_gubun = magam_gubun + "1";

                                        inList.Add(magam_gubun);

                                        MagamSer = this.getMagamSer(inList[1].ToString(), inList[4].ToString(), row["input_doctor"].ToString());
                                        if (MagamSer != "0")
                                            inList.Add(MagamSer);
                                        else
                                            throw new Exception(XMsg.GetMsg("M004") + "締切番号が正常に取得されていません。");

                                        inList.Add(row["bunho"].ToString());

                                        if (UserInfo.UserGubun == UserType.Doctor)
                                        {
                                            inList.Add(UserInfo.DoctorID);
                                            inList.Add(UserInfo.DoctorID);
                                        }
                                        else
                                        {
                                            inList.Add(row["input_doctor"].ToString());
                                            inList.Add(row["input_doctor"].ToString());
                                        }

                                        if (Service.ExecuteProcedure(procName, inList, outList) == false)
                                        {
                                            throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                                        }
                                        else
                                        {
                                            if (!drg_bunho.Contains(outList[0].ToString()) && outList[0].ToString() != "0" && outList[0].ToString() != "")
                                                drg_bunho.Add(row["order_gubun"].ToString().Substring(1, 1) + inList[1].ToString() + outList[0].ToString());
                                        }

                                    }
                                }
                            }

                            #region 退院処方に変更の場合にやること

                            if (aWorkGubun == "T")
                            {
                                int toiwon_drg_nalsu = int.Parse(row["nalsu"].ToString()) - new_nalsu;

                                if (row["dv"].ToString() != TypeCheck.NVL(row["dv_return"].ToString(), row["dv"].ToString()).ToString())
                                {
                                    inList = new ArrayList();
                                    outList = new ArrayList();

                                    if (   row["order_gubun"].ToString().Substring(1, 1) == "B"
                                        || row["order_gubun"].ToString().Substring(1, 1) == "C"
                                        || row["order_gubun"].ToString().Substring(1, 1) == "D")
                                    {
                                        if (row["select_yn"].ToString() == "Y")
                                        {
                                            inList.Add(EnvironInfo.CurrSystemID);
                                            // SET
                                            inList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // JUBSU_DATE
                                            // WHERE
                                            inList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // ORDER_DATE
                                            inList.Add(row["stop_date"].ToString()); // HOPE_DATE
                                            
                                            magam_gubun = "3"; // 退院

                                            if (row["order_gubun"].ToString().Substring(1, 1) == "B")
                                                magam_gubun = magam_gubun + "2";
                                            else
                                                magam_gubun = magam_gubun + "1";

                                            inList.Add(magam_gubun);

                                            MagamSer = this.getMagamSer(inList[1].ToString(), inList[4].ToString(), row["input_doctor"].ToString());
                                            if (MagamSer != "0")
                                                inList.Add(MagamSer);
                                            else
                                                throw new Exception(XMsg.GetMsg("M004") + "締切番号が正常に取得されていません。");

                                            inList.Add(row["bunho"].ToString());

                                            if (UserInfo.UserGubun == UserType.Doctor)
                                            {
                                                inList.Add(UserInfo.DoctorID);
                                                inList.Add(UserInfo.DoctorID);
                                            }
                                            else
                                            {
                                                inList.Add(row["input_doctor"].ToString());
                                                inList.Add(row["input_doctor"].ToString());
                                            }

                                            if (Service.ExecuteProcedure(procName, inList, outList) == false)
                                            {
                                                throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                                            }
                                            else
                                            {
                                                if (!drg_bunho.Contains(outList[0].ToString()) && outList[0].ToString() != "0" && outList[0].ToString() != "")
                                                    drg_bunho.Add(row["order_gubun"].ToString().Substring(1, 1) + inList[1].ToString() + outList[0].ToString());
                                            }

                                        }
                                    }
                                }

                                
                                if (toiwon_drg_nalsu > 0)
                                {
                                    inList = new ArrayList();
                                    outList = new ArrayList();

                                    if (   row["order_gubun"].ToString().Substring(1, 1) == "B"
                                        || row["order_gubun"].ToString().Substring(1, 1) == "C"
                                        || row["order_gubun"].ToString().Substring(1, 1) == "D")
                                    {
                                        if (row["select_yn"].ToString() == "Y")
                                        {
                                            inList.Add(EnvironInfo.CurrSystemID);
                                            // SET
                                            inList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // JUBSU_DATE
                                            // WHERE
                                            inList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // ORDER_DATE
                                            if (row["dv"].ToString() != TypeCheck.NVL(row["dv_return"].ToString(), row["dv"].ToString()).ToString())
                                                inList.Add(DateTime.Parse(row["stop_date"].ToString()).AddDays(1)); // HOPE_DATE
                                            else
                                                inList.Add(row["stop_date"].ToString()); // HOPE_DATE

                                            //inList.Add(DateTime.Parse(TypeCheck.NVL(row["stop_end_date"].ToString(), row["stop_date"].ToString()).ToString()).AddDays(1).ToString("yyyy/MM/dd")); // HOPE_DATE

                                            magam_gubun = "3";

                                            if (row["order_gubun"].ToString().Substring(1, 1) == "B")
                                                magam_gubun = magam_gubun + "2";
                                            else
                                                magam_gubun = magam_gubun + "1";

                                            inList.Add(magam_gubun);

                                            MagamSer = this.getMagamSer(inList[1].ToString(), inList[4].ToString(), row["input_doctor"].ToString());
                                            if (MagamSer != "0")
                                                inList.Add(MagamSer);
                                            else
                                                throw new Exception(XMsg.GetMsg("M004") + "締切番号が正常に取得されていません。");

                                            inList.Add(row["bunho"].ToString());

                                            if (UserInfo.UserGubun == UserType.Doctor)
                                            {
                                                inList.Add(UserInfo.DoctorID);
                                                inList.Add(UserInfo.DoctorID);
                                            }
                                            else
                                            {
                                                inList.Add(row["input_doctor"].ToString());
                                                inList.Add(row["input_doctor"].ToString());
                                            }

                                            if (Service.ExecuteProcedure(procName, inList, outList) == false)
                                            {
                                                throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                                            }
                                            else
                                            {
                                                if (!drg_bunho.Contains(outList[0].ToString()) && outList[0].ToString() != "0" && outList[0].ToString() != "")
                                                    drg_bunho.Add(row["order_gubun"].ToString().Substring(1, 1) + inList[1].ToString() + outList[0].ToString());
                                            }

                                        }
                                    }
                                }
                            }

                            #endregion 退院処方に変更の場合にやること
                        }
                    }
                    
                }
                #endregion

                #region input sunab_date
                // PR_OCS_UPDATE_DRG_SUNAB_DATE(A1.HOSP_CODE, P_NEW_PKOCS2003_TO, A1.UPD_ID);

                string procedure_name = "PR_OCS_UPDATE_DRG_SUNAB_DATE";
                ArrayList inList_sunab_date = new ArrayList();
                ArrayList outList_sunab_date = new ArrayList();

                string cmd_sunab_date = @"SELECT DISTINCT A.PKOCS2003 PKOCS2003
                                            FROM OCS2003 A
                                           WHERE A.HOSP_CODE        = :f_hosp_code
                                             AND A.SOURCE_FKOCS2003 = :f_pkocs2003
                                        ";

                string cmd_sunab_date_c = @"SELECT DISTINCT A.PKOCS2003 PKOCS2003
                                              FROM OCS2003 A
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.PKOCS2003 = :f_pkocs2003
                                          ";

                BindVarCollection bind_sunab_date = new BindVarCollection();

                

                if (this.sourceList.Count > 0)
                {
                    for(int i = 0; i < this.sourceList.Count; i++)
                    {
                        bind_sunab_date.Add("f_hosp_code", EnvironInfo.HospCode);
                        bind_sunab_date.Add("f_pkocs2003", this.sourceList[i].ToString());

                        DataTable dt = null;

                        if(aWorkGubun != "C")
                            dt = Service.ExecuteDataTable(cmd_sunab_date, bind_sunab_date);
                        else
                            dt = Service.ExecuteDataTable(cmd_sunab_date_c, bind_sunab_date);

                        if (dt.Rows.Count > 0)
                        {
                            for (int b = 0; b < dt.Rows.Count; b++)
                            {
                                inList_sunab_date.Clear();

                                inList_sunab_date.Add(EnvironInfo.HospCode);
                                inList_sunab_date.Add(dt.Rows[b]["pkocs2003"].ToString());
                                inList_sunab_date.Add(UserInfo.UserID);

                                if (!Service.ExecuteProcedure(procedure_name, inList_sunab_date, outList_sunab_date))
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                }

                            }
                        }
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Service.RollbackTransaction();
                return false;
            }

            Service.CommitTransaction();

            DrgPrintProcess(aIsBannab);

            return true;
        }

        #endregion

        private string getMagamSer(string aJubsu_date, string aMagam_gubun, string aActer)
        {
            string magam_ser = "";
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(aJubsu_date);
            inputList.Add(aMagam_gubun);
            inputList.Add("%");
            inputList.Add("PA");
            inputList.Add(aActer);

            if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
                magam_ser = outputList[0].ToString();
            
            return magam_ser;
        }

        #region [ 각종 메소드 ]
        //isBannab(rbtDC.Checked)
        private bool BannabProcessCheck(bool isBannab, string aBtnGubun)
        {
            string msg = "";
            bool isExistData = false;

            string cmd = @"SELECT COUNT(*) CNT
                             FROM OCS2003 A
                                , OCS2017 B
                            WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.PKOCS2003 = :f_pkocs2003
                              AND B.HOSP_CODE = A.HOSP_CODE
                              AND B.FKOCS2003 = A.PKOCS2003
                              AND B.PASS_DATE IS NOT NULL
                              AND NVL(B.BANNAB_YN, 'N') != 'Y'
                              AND B.ACT_RES_DATE = TO_DATE(:f_act_res_date, 'YYYY/MM/DD')
                            ";
            BindVarCollection bind = new BindVarCollection();

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.rbtDC.Checked)
                {
                    if (this.grdOrder.GetItemString(i, "dv_return") == "" && this.grdOrder.GetItemString(i, "select_yn") == "Y")
                    {
                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
                        bind.Add("f_pkocs2003", this.grdOrder.GetItemString(i, "pkocs2003"));
                        bind.Add("f_act_res_date", this.grdOrder.GetItemString(i, "stop_date"));
                        object acted_dv = Service.ExecuteScalar(cmd, bind);

                        if (int.Parse(acted_dv.ToString()) > 0)
                        {
                            XMessageBox.Show(this.grdOrder.GetItemString(i, "hangmog_name") + "オーダは [" + acted_dv.ToString() + "回 / " + this.grdOrder.GetItemString(i, "dv")
                                + "回] 投与されています。部分返却又は日付を調節してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }


                    }
                }

                if (this.grdOrder.GetItemString(i, "select_yn") == "Y")
                {
                    isExistData = true;
                    if (isBannab && this.grdOrder.GetItemString(i, "stop_date") == "")
                    {
                        msg = "[" + this.grdOrder.GetItemString(i, "hangmog_code") + "] " + this.grdOrder.GetItemString(i, "hangmog_name") + "\n"
                            + "=====================================================================" + "\n"
                            + XMsg.GetMsg("M002");

                        XMessageBox.Show(msg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                // tag 1 取消、tag 2 退院処方に変更
                if (aBtnGubun == "2" && this.grdOrder.GetItemString(i, "input_gubun") == "D7" && this.grdOrder.GetItemString(i, "select_yn") == "Y")
                {
                    msg = "[" + this.grdOrder.GetItemString(i, "hangmog_code") + "] " + this.grdOrder.GetItemString(i, "hangmog_name") + "\n"
                            + "=====================================================================" + "\n"
                            + XMsg.GetMsg("M009");

                    XMessageBox.Show(msg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // tag 1 取消、tag 2 退院処方に変更
                if (   aBtnGubun == "2"
                    && this.grdOrder.GetItemString(i, "select_yn") == "Y" 
                    && (   this.grdOrder.GetItemString(i, "order_gubun").Substring(1, 1) != "C"
                        && this.grdOrder.GetItemString(i, "order_gubun").Substring(1, 1) != "D")
                   )
                {
                    msg = "[" + this.grdOrder.GetItemString(i, "hangmog_code") + "] " + this.grdOrder.GetItemString(i, "hangmog_name") + "\n"
                            + "=====================================================================" + "\n"
                            + XMsg.GetMsg("M011");

                    XMessageBox.Show(msg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // 部分返却処理時必要なデータチェック
                if (   aBtnGubun == "1"
                    && this.grdOrder.GetItemString(i, "select_yn") == "Y"
                    && this.grdOrder.GetItemString(i, "dv_return") != "")
                {
                    if (this.grdOrder.GetItemString(i, "order_gubun").Substring(1, 1) != "B")
                    {
                        if (this.grdOrder.GetItemString(i, "bogyong_code_return") == "")
                        {
                            msg = "部分返却処理に必要なデータが不足しています。" + "\n"
                                    + "=====================================================================" + "\n"
                                    + XMsg.GetMsg("M009");

                            XMessageBox.Show(msg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }

                // 部分退院処方切り換え時必要なデータチェック
                if (   aBtnGubun == "2" 
                    && this.grdOrder.GetItemString(i, "select_yn") == "Y"
                    && this.grdOrder.GetItemString(i, "dv_return") != "")
                {
                    if (this.grdOrder.GetItemString(i, "order_gubun").Substring(1, 1) != "B")
                    {
                        if (   this.grdOrder.GetItemString(i, "bogyong_code_return") == ""
                            || this.grdOrder.GetItemString(i, "dv_toiwon") == ""
                            || this.grdOrder.GetItemString(i, "bogyong_code_toiwon") == "")
                        {
                            msg = "部分退院処方切り換えるに必要なデータが不足しています。"+ "\n"
                                    + "=====================================================================" + "\n"
                                    + XMsg.GetMsg("M009");

                            XMessageBox.Show(msg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }

            }
            if (isExistData == false)
            {
                XMessageBox.Show(XMsg.GetMsg("M003"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        #endregion

        #region [ XEditGrid ]

        private void grdOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 1) 
            {
                if (grid.CurrentColName == "select_yn")
                {
                    

                    if (rowNumber < 0) return;

                    if (grid.GetItemString(rowNumber, "select_yn") == "Y")
                    {
                        grid[rowNumber, "select_yn"].Image = this.ImageList.Images[1];
                        grid.SetItemValue(rowNumber, "select_yn", "N");

                        grid.SetItemValue(rowNumber, "dv_return", "");
                        grid.SetItemValue(rowNumber, "bogyong_code_return", "");
                        grid.SetItemValue(rowNumber, "bogyong_code_return_name", "");

                        grid.SetItemValue(rowNumber, "dv_toiwon", "");
                        grid.SetItemValue(rowNumber, "bogyong_code_toiwon", "");
                        grid.SetItemValue(rowNumber, "bogyong_code_toiwon_name", "");

                        if (this.rbtDC.Checked)
                        {
                            //grid.SetItemValue(rowNumber, "stop_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                            //for (int i = 0; i < grid.RowCount; i++)
                            //{
                            //    if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                            //        && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                            //        && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                            //        && grid.GetItemString(rowNumber, "mix_group") != "")
                            //    {
                                    grid[rowNumber, "select_yn"].Image = this.ImageList.Images[1];
                                    grid.SetItemValue(rowNumber, "select_yn", "N");
                                    grid.SetItemValue(rowNumber, "stop_date", "");
                                    grid.SetItemValue(rowNumber, "stop_end_date", "");
                            //    }
                            //}
                            
                            grid.SetItemValue(rowNumber, "stop_date", "");
                            grid.SetItemValue(rowNumber, "stop_end_date", "");
                        }
                        else
                        {
                            for (int i = 0; i < grid.RowCount; i++)
                            {
                                if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                                    && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                                    && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                                    && grid.GetItemString(rowNumber, "mix_group") != "")
                                {
                                    grid[i, "select_yn"].Image = this.ImageList.Images[1];
                                    grid.SetItemValue(i, "select_yn", "N");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (grid.GetItemString(rowNumber, "ocs_flag") == "4")
                        {
                            XMessageBox.Show("既に会計処理されたオーダです。医事課にお問い合わせください。", "確認");
                            return;
                        }
                        if (grid.GetItemString(rowNumber, "input_gubun") == "D7")
                        {
                            XMessageBox.Show("退院処方は返却できません。直接オーダを修正してください。", "確認");
                            return;
                        }

                        grid[rowNumber, "select_yn"].Image = this.ImageList.Images[0];
                        grid.SetItemValue(rowNumber, "select_yn", "Y");
                        if (this.rbtDC.Checked)
                        {
                            for (int i = 0; i < grid.RowCount; i++)
                            {
                                string stop_date = "";
                                string stop_end_date = "";

                                if (grid.GetItemString(rowNumber, "acting_date") != "")
                                {  
                                    DateTime time = DateTime.Parse(grid.GetItemString(rowNumber, "acting_date"));

                                    string ableToStopDate = getStopStartDateActYetOfOCS2017(grid.GetItemString(rowNumber, "pkocs2003"));

                                    if (grid.GetItemString(rowNumber, "order_gubun").Substring(1, 1) == "C"
                                        && grid.GetItemString(rowNumber, "acting_date") != grid.GetItemString(rowNumber, "end_date"))
                                    {
                                        stop_date = time.AddDays(1).ToString();
                                        stop_end_date = (grid.GetItemString(rowNumber, "end_date"));
                                    }
                                    else
                                    {
                                        //stop_date = time.ToString();     
                                        stop_date = ableToStopDate;
                                        //stop_end_date = ableToStopDate;
                                        stop_end_date = this.getStopEndDateActYetOfOCS2017(grid.GetItemString(rowNumber, "pkocs2003"), DateTime.Parse(stop_date).ToString("yyyy/MM/dd"));
                                        //stop_date = (grid.GetItemString(rowNumber, "acting_date"));
                                    }
                                }
                                else
                                {
                                    //stop_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                                    stop_date = (grid.GetItemString(rowNumber, "start_date"));
                                    stop_end_date = (grid.GetItemString(rowNumber, "end_date"));
                                }//end_date

                                

                                grid.SetItemValue(rowNumber, "stop_date", stop_date);
                                grid.SetItemValue(rowNumber, "stop_end_date", stop_end_date);
                                //grid.SetItemValue(rowNumber, "stop_date", int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd").ToString()) > int.Parse(grid.GetItemString(rowNumber, "group_ser").Replace('/', ' ')) ? grid.GetItemString(rowNumber, "end_date") : EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                                if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                                    && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                                    && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                                    && grid.GetItemString(rowNumber, "mix_group") != "")
                                {
                                    grid[i, "select_yn"].Image = this.ImageList.Images[0];
                                    grid.SetItemValue(i, "select_yn", "Y");
                                    
                                    grid.SetItemValue(i, "stop_date", stop_date);
                                    grid.SetItemValue(i, "stop_end_date", stop_end_date);
                                    //grid.SetItemValue(i, "stop_date", int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd").ToString()) > int.Parse(grid.GetItemString(i, "group_ser").Replace('/', ' ')) ? grid.GetItemString(i, "end_date") : EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                }
                            }

                        }
                        else
                        {
                            for (int i = 0; i < grid.RowCount; i++)
                            {
                                if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                                    && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                                    && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                                    && grid.GetItemString(rowNumber, "mix_group") != "")
                                {
                                    grid[i, "select_yn"].Image = this.ImageList.Images[0];
                                    grid.SetItemValue(i, "select_yn", "Y");
                                }
                            }
                        }
                    }
                }
                else if (grid.CurrentColName == "dv_return")
                {
                    this.SetPartReturnColumn(true, grid.CurrentColName);
                    this.grdOrder.SetFocusToItem(rowNumber, "bogyong_code_return_name");
                    this.grdOrder.SetFocusToItem(rowNumber, "dv_return");
                }
                else if (grid.CurrentColName == "dv_toiwon")
                {
                    this.SetPartReturnColumn(true, grid.CurrentColName);
                    this.grdOrder.SetFocusToItem(rowNumber, "bogyong_code_toiwon_name");
                    this.grdOrder.SetFocusToItem(rowNumber, "dv_toiwon");
                }
            }
            else if (e.Clicks == 2 && e.Button == MouseButtons.Left && this.grdOrder.DisplayRowCount > 0)
            {
                OCS2017 frmOCS2017 = new OCS2017();
                
                XEditGrid grd = this.grdOrder;
                int CurrRow = grd.CurrentRowNumber;

                frmOCS2017.BUNHO       = grd.GetItemString(CurrRow, "bunho");
                frmOCS2017.PKOCS2003   = grd.GetItemString(CurrRow, "pkocs2003");

                frmOCS2017.FKINP1001   = grd.GetItemString(CurrRow, "fkinp1001");
                frmOCS2017.ORDERDATE   = grd.GetItemString(CurrRow, "order_date");
                frmOCS2017.INPUTDOCTOR = grd.GetItemString(CurrRow, "input_doctor");

                frmOCS2017.ORDERINFO = grd.GetItemString(CurrRow, "hangmog_name") + " " + grd.GetItemString(CurrRow, "start_date") + " ～ " + grd.GetItemString(CurrRow, "end_date");
                frmOCS2017.SOURCEGRD = grd;
                frmOCS2017.GUBUN     = "PART";
                frmOCS2017.StartPosition = FormStartPosition.CenterScreen;
                frmOCS2017.ShowDialog();
            }

        }

        private string getStopStartDateActYetOfOCS2017(string aPkocs2003)
        {
            string cmd = @" SELECT MIN(A.ACT_RES_DATE)
                              FROM OCS2017 A
                             WHERE A.HOSP_CODE = :f_hosp_code
                               AND A.FKOCS2003 = :f_pkocs2003
                               AND A.PASS_DATE IS NULL
                               ";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_pkocs2003", aPkocs2003);

            object obj = Service.ExecuteScalar(cmd, bind);

            if (obj.ToString() != "")
                return obj.ToString();
            else
                return "";
        }

        private string getStopEndDateActYetOfOCS2017(string aPkocs2003, string aStopStartDate)
        {
            string cmd = @" SELECT MIN(AA.ACT_RES_DATE)-1 ACT_RES_DATE
                              FROM (
                                    SELECT A.DV, B.ACT_RES_DATE, COUNT(*) ACT_CNT
                                      FROM OCS2003 A
                                         , OCS2017 B
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.PKOCS2003 = :f_pkocs2003
                                       --
                                       AND B.HOSP_CODE = A.HOSP_CODE
                                       AND B.FKOCS2003 = A.PKOCS2003
                                       AND B.PASS_DATE IS NOT NULL
                                       AND B.ACT_RES_DATE > :f_stop_start_date
                                     GROUP BY A.DV, B.ACT_RES_DATE
                                     ) AA
                             ORDER BY AA.ACT_RES_DATE
                               ";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_stop_start_date", aStopStartDate);
            bind.Add("f_pkocs2003", aPkocs2003);

            object obj = Service.ExecuteScalar(cmd, bind);

            if (obj.ToString() != "")
                return obj.ToString();
            else
                return "";
        }
        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, string aGroupSer, bool select)
        //private bool grdSelectAll(XGrid grdObject)
        //{
        //    int rowIndex = -1;

        //    for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
        //        grdObject.SetItemValue(rowIndex, "select", "Y");

        //    return true;

        //}

        //private bool grdDeleteAll(XGrid grdObject)
        //{
        //    int rowIndex = -1;

        //    for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
        //        grdObject.SetItemValue(rowIndex, "select", "N");

        //    return true;
        //}

        //private void btnSelect_Click(object sender, EventArgs e)
        //{
        //    Control ctl = sender as Control;

        //    if (ctl.Tag.ToString() == "1")
        //        this.grdSelectAll(this.grdOrder);
        //    else
        //        this.grdDeleteAll(this.grdOrder);
        //}

        private void grdOrder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            Hashtable param = new Hashtable();
            object previousValue = grid.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer);
            switch (e.ColName)
            {
                case "stop_date" :

                    if (this.rbtDC.Checked == false)
                        return;

                    if (e.ChangeValue.ToString() == "")
                        return;

                    //if (DateTime.Parse(e.ChangeValue.ToString()) < DateTime.Parse(this.grdOrder.GetItemString(e.RowNumber, "start_date"))
                    //    || DateTime.Parse(e.ChangeValue.ToString()) > DateTime.Parse(TypeCheck.NVL(this.grdOrder.GetItemString(e.RowNumber, "end_date"), this.grdOrder.GetItemString(e.RowNumber, "start_date")).ToString()))
                    //{
                    //    grid.SetItemValue(e.RowNumber, e.ColName, previousValue.ToString());
                    //    XMessageBox.Show("「中止日（から）」の日付が正しくありません", "確認");
                    //    return;
                    //}

                    //if (e.ChangeValue.ToString() != "" && grid.GetItemString(e.RowNumber, "stop_end_date") != "")
                    //{
                        if (!IsValidStopDate(e.ChangeValue.ToString()
                                       , grid.GetItemString(e.RowNumber, "stop_end_date")
                                       , grid.GetItemString(e.RowNumber, "start_date")
                                       , grid.GetItemString(e.RowNumber, "end_date")
                                       , grid.GetItemString(e.RowNumber, "perfect_act_date")))
                        {
                            //grid.SetItemValue(e.RowNumber, e.ColName, (DateTime.Parse(grid.GetItemString(e.RowNumber, "acting_date")).AddDays(1)).ToString());
                            grid.SetItemValue(e.RowNumber, e.ColName, previousValue.ToString());
                            grid.SetFocusToItem(e.RowNumber, e.ColName);
                            return;
                        }
                    //}

                    if (this.grdOrder.GetItemString(e.RowNumber, "dv_return") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "dv_toiwon") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "bogyong_code_return") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "bogyong_code_toiwon") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "bogyong_code_return_name") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "bogyong_code_toiwon_name") != ""
                        
                        )
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "dv_return", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "dv_toiwon", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return_name", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon_name", "");
                    }
                    
                    // Set stop_end_date 
                    string cmd_s2 = @"SELECT DISTINCT B.ACT_RES_DATE
                                        FROM OCS2003 A
                                           , OCS2017 B
                                        WHERE A.HOSP_CODE = :f_hosp_code
                                        AND A.BUNHO = :f_bunho
                                        AND A.PKOCS2003 = :f_pkocs2003
                                        --
                                        AND B.HOSP_CODE = A.HOSP_CODE
                                        AND B.FKOCS2003 = A.PKOCS2003
                                        AND B.ACT_RES_DATE >= :f_kijun_date
                                        AND B.ACT_RES_DATE = (SELECT MIN(C.ACT_RES_DATE) -1 
                                                                FROM OCS2017 C
                                                               WHERE C.HOSP_CODE = B.HOSP_CODE
                                                                 AND C.FKOCS2003 = B.FKOCS2003
                                                                 AND C.ACT_RES_DATE > :f_kijun_date
                                                                 AND C.PASS_DATE IS NOT NULL
                                                                 )";
                    BindVarCollection bind_s2 = new BindVarCollection();
                    bind_s2.Add("f_hosp_code", EnvironInfo.HospCode);
                    bind_s2.Add("f_bunho", this.grdOrder.GetItemString(e.RowNumber, "bunho"));
                    bind_s2.Add("f_pkocs2003", this.grdOrder.GetItemString(e.RowNumber, "pkocs2003"));
                    bind_s2.Add("f_kijun_date", e.ChangeValue.ToString());

                    object obj = Service.ExecuteScalar(cmd_s2, bind_s2);
                    int a = 0;

                    if (obj == null)
                        this.grdOrder.SetItemValue(e.RowNumber, "stop_end_date", this.grdOrder.GetItemString(e.RowNumber, "end_date"));
                    if (obj != null)
                        this.grdOrder.SetItemValue(e.RowNumber, "stop_end_date", obj.ToString());
                    else if (this.grdOrder.GetItemString(e.RowNumber, "acting_date") == "")
                        a = 0;    
                    else if (DateTime.Parse(e.ChangeValue.ToString()) >= DateTime.Parse(this.grdOrder.GetItemString(e.RowNumber, "acting_date")))
                        a = 0;
                    else if (DateTime.Parse(e.ChangeValue.ToString()) < DateTime.Parse(this.grdOrder.GetItemString(e.RowNumber, "acting_date")))
                        this.grdOrder.SetItemValue(e.RowNumber, "stop_end_date", e.ChangeValue.ToString());


                    //if (IsValidStopDate(e.ChangeValue.ToString(), grid.GetItemString(e.RowNumber, "start_date"), grid.GetItemString(e.RowNumber, "end_date"),
                    //    grid.GetItemString(e.RowNumber, "acting_date")) == false)
                    //{
                    //    param.Add("grid", grid);
                    //    param.Add("row_number", e.RowNumber);
                    //    param.Add("column_name", e.ColName);
                    //    param.Add("value", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        //param.Add("value", "");
                        //PostCallHelper.PostCall(new PostMethodObject(GridOrderValidationFail), param);
                    //}

                    //int rowNumber = -1;

                    //rowNumber = e.RowNumber;

                    //if (rowNumber < 0) return;


                    //if (this.rbtDC.Checked)
                    //{
                    //    for (int i = 0; i < grid.RowCount; i++)
                    //    {
                    //        if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                    //            && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                    //            && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                    //            && grid.GetItemString(rowNumber, "mix_group") != "")
                    //        {
                    //            grid.SetItemValue(i, "stop_date", grid.GetItemString(rowNumber, "stop_date"));
                    //            if (grid.GetItemString(rowNumber, "stop_date") == "")
                    //            {
                    //                grid[i, "select_yn"].Image = this.ImageList.Images[1];
                    //                grid.SetItemValue(i, "select_yn", "N");
                    //            }
                    //        }
                    //    }
                    //}
                       
                    break;
                case "stop_end_date":

                    if (this.rbtDC.Checked == false)
                        return;

                    if (e.ChangeValue.ToString() == "")
                        return;

                    //if (DateTime.Parse(e.ChangeValue.ToString()) > DateTime.Parse(TypeCheck.NVL(this.grdOrder.GetItemString(e.RowNumber, "end_date"), this.grdOrder.GetItemString(e.RowNumber, "start_date")).ToString())
                    //    || DateTime.Parse(e.ChangeValue.ToString()) < DateTime.Parse(this.grdOrder.GetItemString(e.RowNumber, "start_date")))
                    //{
                    //    grid.SetItemValue(e.RowNumber, e.ColName, previousValue.ToString());
                    //    XMessageBox.Show("「中止日（まで）」の日付が正しくありません", "確認");
                    //    return;
                    //}

                    //if (e.ChangeValue.ToString() != "" && grid.GetItemString(e.RowNumber, "stop_date") != "")
                    //{
                        if (!IsValidStopEndDate(grid.GetItemString(e.RowNumber, "stop_date")
                                               , e.ChangeValue.ToString()
                                               , grid.GetItemString(e.RowNumber, "start_date")
                                               , grid.GetItemString(e.RowNumber, "end_date")
                                               , grid.GetItemString(e.RowNumber, "perfect_act_date")))
                        {
                            grid.SetItemValue(e.RowNumber, e.ColName, previousValue.ToString());
                            grid.SetFocusToItem(e.RowNumber, e.ColName);
                            return;
                        }
                    //}

                    if (this.grdOrder.GetItemString(e.RowNumber, "dv_return") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "dv_toiwon") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "bogyong_code_return") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "bogyong_code_toiwon") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "bogyong_code_return_name") != ""
                        || this.grdOrder.GetItemString(e.RowNumber, "bogyong_code_toiwon_name") != ""

                        )
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "dv_return", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "dv_toiwon", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return_name", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon_name", "");
                    }


                    

                    break;

                case "dv": //注射の場合投薬記録されている分は返却できない様にチェック
//                    string cmd = @"SELECT COUNT(*) CNT
//                                     FROM OCS2003 A
//                                        , OCS2017 B
//                                    WHERE A.HOSP_CODE = :f_hosp_code
//                                      AND A.PKOCS2003 = :f_pkocs2003
//                                      AND B.HOSP_CODE = A.HOSP_CODE
//                                      AND B.FKOCS2003 = A.PKOCS2003
//                                      AND B.ACTING_DATE IS NOT NULL
//                                      AND NVL(B.BANNAB_YN, 'N') != 'Y'
//                                      AND B.ACT_RES_DATE = :f_act_res_date
//                                    ";
//                    BindVarCollection bind = new BindVarCollection();
//                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bind.Add("f_pkocs2003", e.DataRow["pkocs2003"].ToString());
//                    bind.Add("f_act_res_date", e.DataRow["stop_end_date"].ToString());
//                    object acted_dv = Service.ExecuteScalar(cmd, bind);
                    
//                    if (acted_dv == null) break;

//                    int acted_dv_int = int.Parse(acted_dv.ToString());
//                    int previousValue_int = int.Parse(previousValue.ToString());

//                    cmd = @"SELECT A.DV
//                              FROM OCS2003 A
//                             WHERE A.HOSP_CODE = :f_hosp_code
//                               AND A.PKOCS2003 = :f_pkocs2003
//                               AND NVL(A.BANNAB_YN, 'N')  != 'Y'
//                             ";
//                    bind = new BindVarCollection();
//                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bind.Add("f_pkocs2003", e.DataRow["pkocs2003"].ToString());
//                    object dv = Service.ExecuteScalar(cmd, bind);

//                    int dv_int = int.Parse(dv.ToString());



//                    if ((dv_int - acted_dv_int) < int.Parse(e.ChangeValue.ToString()))
//                    {
//                        XMessageBox.Show("返却可能な数量が不足しています。返却可能な数量は" + (dv_int - acted_dv_int) + "です。", "確認");
//                        grid.SetItemValue(e.RowNumber, e.ColName, previousValue);
//                    }
                    break;
                case "bogyong_code_return":
                    if (e.ChangeValue.ToString() == "")
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return_name", "");
                    }
                    else
                    {
                        // 同一もの一括変更
                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (this.grdOrder.GetItemString(i, "select_yn") == "Y"
                                && this.grdOrder.GetItemString(i, "group_ser") == e.DataRow["group_ser"].ToString()
                                && this.grdOrder.GetItemString(i, "bogyong_name") == e.DataRow["bogyong_name"].ToString()
                                )
                            {
                                if (this.grdOrder.GetItemString(i, e.ColName) == "")
                                {
                                    this.grdOrder.SetItemValue(i, e.ColName, e.ChangeValue);
                                    this.grdOrder.SetItemValue(i, "bogyong_code_return_name", e.DataRow["bogyong_code_return_name"].ToString());
                                }
                            }
                        }
                    }

                    break;
                case "bogyong_code_toiwon":
                    if (e.ChangeValue.ToString() == "")
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon_name", "");
                    }
                    else
                    {
                        // 同一もの一括変更
                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (this.grdOrder.GetItemString(i, "select_yn") == "Y"
                                && this.grdOrder.GetItemString(i, "group_ser") == e.DataRow["group_ser"].ToString()
                                && this.grdOrder.GetItemString(i, "bogyong_name") == e.DataRow["bogyong_name"].ToString()
                                )
                            {
                                if (this.grdOrder.GetItemString(i, e.ColName) == "")
                                {
                                    this.grdOrder.SetItemValue(i, e.ColName, e.ChangeValue);
                                    this.grdOrder.SetItemValue(i, "bogyong_code_toiwon_name", e.DataRow["bogyong_code_toiwon_name"].ToString());
                                }
                            }
                        }
                    }

                    break;
                case "dv_return":

                    if (e.ChangeValue.ToString() == "")
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return_name", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon_name", "");
                        return;
                    }

                    BindVarCollection bind = new BindVarCollection();
                    string cmd = @" SELECT A.DV
                                      FROM OCS2003 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.PKOCS2003 = :f_pkocs2003
                                       AND NVL(A.BANNAB_YN, 'N')  != 'Y'
                                     ";
                    
                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
                    bind.Add("f_pkocs2003", e.DataRow["pkocs2003"].ToString());
                    object dv = Service.ExecuteScalar(cmd, bind);

                    int dv_int = int.Parse(dv.ToString());

                    cmd = @" SELECT COUNT(*) CNT
                               FROM OCS2003 A
                                  , OCS2017 B
                              WHERE A.HOSP_CODE = :f_hosp_code
                                AND A.PKOCS2003 = :f_pkocs2003
                                AND B.HOSP_CODE = A.HOSP_CODE
                                AND B.FKOCS2003 = A.PKOCS2003
                                AND B.PASS_DATE IS NOT NULL
                                AND NVL(B.BANNAB_YN, 'N') != 'Y'
                                AND B.ACT_RES_DATE = TO_DATE(:f_act_res_date, 'YYYY/MM/DD')
                                ";
                    bind = new BindVarCollection();
                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
                    bind.Add("f_pkocs2003", e.DataRow["pkocs2003"].ToString());
                    bind.Add("f_act_res_date", this.grdOrder.GetItemString(e.RowNumber, "stop_date"));
                    object acted_dv = Service.ExecuteScalar(cmd, bind);

                    if (acted_dv == null)
                        acted_dv = 0;

                    int acted_dv_int = int.Parse(acted_dv.ToString());

                    //else if ((dv_int - acted_dv_int) == int.Parse(e.ChangeValue.ToString()))
                    if (dv_int == int.Parse(e.ChangeValue.ToString()))
                    {
                        XMessageBox.Show("部分返却のみご使用可能です。部分返却ではない場合はここに数値を入れないで進めてください。", "確認");
                        grid.SetItemValue(e.RowNumber, e.ColName, previousValue);
                    }
                    else if ((dv_int - acted_dv_int) < int.Parse(e.ChangeValue.ToString()))
                    {
                        int result_dv = -1;

                        if ((dv_int - acted_dv_int) == dv_int)
                            result_dv = dv_int - 1;
                        else
                            result_dv = (dv_int - acted_dv_int);

                        
                        XMessageBox.Show("返却可能な数量が不足しています。返却可能な数量は" + result_dv + "です。", "確認");
                        grid.SetItemValue(e.RowNumber, e.ColName, previousValue);
                    }
                    else
                    {
                        // 同一もの一括変更
                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (this.grdOrder.GetItemString(i, "select_yn") == "Y"
                                && this.grdOrder.GetItemString(i, "group_ser") == e.DataRow["group_ser"].ToString()
                                && this.grdOrder.GetItemString(i, "bogyong_name") == e.DataRow["bogyong_name"].ToString()
                                )
                            {
                                if (this.grdOrder.GetItemString(i, e.ColName) == "")
                                {
                                    if (GetCanBannab(int.Parse(e.ChangeValue.ToString()), i, e.ColName))
                                        this.grdOrder.SetItemValue(i, e.ColName, e.ChangeValue);
                                }
                            }
                        }

                        string cmd_b = @"SELECT FN_OCS_BANNAB_BOGYONG_CODE( :f_hosp_code, :f_bogyong_code, :f_dv_original, :f_dv_changed, :f_gubun) 
                                         FROM SYS.DUAL";

                        BindVarCollection bind_b = new BindVarCollection();
                        bind_b.Add("f_hosp_code", EnvironInfo.HospCode);
                        bind_b.Add("f_bogyong_code", this.grdOrder.GetItemString(e.RowNumber, "bogyong_code"));
                        bind_b.Add("f_dv_original", this.grdOrder.GetItemString(e.RowNumber, "dv"));
                        bind_b.Add("f_dv_changed", e.ChangeValue.ToString());
                        bind_b.Add("f_gubun", "R");

                        //6XXXXXXXXXXTTTTTTTTTTTTT
                        //6 : 服用コード桁数
                        //X : LPAD
                        //T : 服用方法
                        object obj_b = Service.ExecuteScalar(cmd_b, bind_b);

                        if (obj_b.ToString() != "")
                        {
                            // 同一もの一括変更
                            for (int i = 0; i < this.grdOrder.RowCount; i++)
                            {
                                if (this.grdOrder.GetItemString(i, "select_yn") == "Y"
                                    && this.grdOrder.GetItemString(i, "group_ser") == e.DataRow["group_ser"].ToString()
                                    && this.grdOrder.GetItemString(i, "bogyong_name") == e.DataRow["bogyong_name"].ToString()
                                    )
                                {
                                    if (e.RowNumber == i)
                                    {
                                        this.grdOrder.SetItemValue(i, "bogyong_code_return", obj_b.ToString().Substring(1, int.Parse(obj_b.ToString().Substring(0, 1))));
                                        this.grdOrder.SetItemValue(i, "bogyong_code_return_name", obj_b.ToString().Substring(11));
                                    }
                                    else if (this.grdOrder.GetItemString(i, "bogyong_code_return") == "")
                                    {
                                        this.grdOrder.SetItemValue(i, "bogyong_code_return", obj_b.ToString().Substring(1, int.Parse(obj_b.ToString().Substring(0, 1))));
                                        this.grdOrder.SetItemValue(i, "bogyong_code_return_name", obj_b.ToString().Substring(11));
                                    }
                                }
                            }
                        }
                    }

                    if (e.DataRow["dv_time"].ToString() == "*")
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return", e.DataRow["bogyong_code"].ToString());
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return_name", e.DataRow["bogyong_name"].ToString());
                    }
                    break;
                case "dv_toiwon":

                    if (e.ChangeValue.ToString() == "")
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon_name", "");
                        return;
                    }

                    if (e.ChangeValue.ToString() != this.grdOrder.GetItemString(e.RowNumber, "dv_return"))
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, e.ColName, previousValue);
                        return;
                    }
                    else
                    {
                        // 同一もの一括変更
                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (   this.grdOrder.GetItemString(i, "select_yn") == "Y"
                                && this.grdOrder.GetItemString(i, "group_ser") == e.DataRow["group_ser"].ToString()
                                && this.grdOrder.GetItemString(i, "bogyong_name") == e.DataRow["bogyong_name"].ToString()
                                )
                            {
                                if (this.grdOrder.GetItemString(i, e.ColName) == "")
                                {
                                    if(this.GetCanBannab(int.Parse(e.ChangeValue.ToString()), e.RowNumber, e.ColName))
                                        this.grdOrder.SetItemValue(i, e.ColName, e.ChangeValue);
                                }
                            }
                        }

                        string cmd_t = @"SELECT FN_OCS_BANNAB_BOGYONG_CODE( :f_hosp_code, :f_bogyong_code, :f_dv_original, :f_dv_changed, :f_gubun) 
                                         FROM SYS.DUAL";

                        BindVarCollection bind_t = new BindVarCollection();
                        bind_t.Add("f_hosp_code", EnvironInfo.HospCode);
                        bind_t.Add("f_bogyong_code", this.grdOrder.GetItemString(e.RowNumber, "bogyong_code"));
                        bind_t.Add("f_dv_original", this.grdOrder.GetItemString(e.RowNumber, "dv"));
                        bind_t.Add("f_dv_changed", e.ChangeValue.ToString());
                        bind_t.Add("f_gubun", "T");

                        //6XXXXXXXXXXTTTTTTTTTTTTT
                        //6 : 服用コード桁数
                        //X : LPAD
                        //T : 服用方法
                        object obj_t = Service.ExecuteScalar(cmd_t, bind_t);

                        if (obj_t.ToString() != "")
                        {
                            // 同一もの一括変更
                            for (int i = 0; i < this.grdOrder.RowCount; i++)
                            {
                                if (this.grdOrder.GetItemString(i, "select_yn") == "Y"
                                    && this.grdOrder.GetItemString(i, "group_ser") == e.DataRow["group_ser"].ToString()
                                    && this.grdOrder.GetItemString(i, "bogyong_name") == e.DataRow["bogyong_name"].ToString()
                                    )
                                {
                                    if (e.RowNumber == i)
                                    {
                                        this.grdOrder.SetItemValue(i, "bogyong_code_toiwon", obj_t.ToString().Substring(1, int.Parse(obj_t.ToString().Substring(0, 1))));
                                        this.grdOrder.SetItemValue(i, "bogyong_code_toiwon_name", obj_t.ToString().Substring(11));
                                    }
                                    else if (this.grdOrder.GetItemString(i, "bogyong_code_toiwon") == "")
                                    {
                                        this.grdOrder.SetItemValue(i, "bogyong_code_toiwon", obj_t.ToString().Substring(1, int.Parse(obj_t.ToString().Substring(0, 1))));
                                        this.grdOrder.SetItemValue(i, "bogyong_code_toiwon_name", obj_t.ToString().Substring(11));
                                    }
                                }
                            }

                        }
                    }

                    break;
            }
        }

        // dv, RowNumber, ColName
        //private bool GetCanBannab(int aSourceDv, int aRowNum, string aColName)
        //{
        //    return GetCanBannab(aSourceDv, aRowNum, aColName, "", "");
        //}
        private bool GetCanBannab(int aSourceDv, int aRowNum, string aColName)
        {
            bool Result = false;

            string cmd = @"SELECT A.DV
                              FROM OCS2003 A
                             WHERE A.HOSP_CODE = :f_hosp_code
                               AND A.PKOCS2003 = :f_pkocs2003
                               AND NVL(A.BANNAB_YN, 'N')  != 'Y'
                             ";
            BindVarCollection bind = new BindVarCollection();

            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_pkocs2003", this.grdOrder.GetItemString(aRowNum, "pkocs2003"));
            object dv = Service.ExecuteScalar(cmd, bind);

            int dv_int = int.Parse(dv.ToString());

            cmd = @"SELECT COUNT(*) CNT
                                     FROM OCS2003 A
                                        , OCS2017 B
                                    WHERE A.HOSP_CODE = :f_hosp_code
                                      AND A.PKOCS2003 = :f_pkocs2003
                                      AND B.HOSP_CODE = A.HOSP_CODE
                                      AND B.FKOCS2003 = A.PKOCS2003
                                      AND B.PASS_DATE IS NOT NULL
                                      AND NVL(B.BANNAB_YN, 'N') != 'Y'
                                      AND B.ACT_RES_DATE = TO_DATE(:f_act_res_date, 'YYYY/MM/DD')
                                    ";
            bind = new BindVarCollection();

            bind.Add("f_hosp_code",    EnvironInfo.HospCode);
            bind.Add("f_pkocs2003",    this.grdOrder.GetItemString(aRowNum, "pkocs2003"));
            bind.Add("f_act_res_date", this.grdOrder.GetItemString(aRowNum, "stop_date"));

            object acted_dv = Service.ExecuteScalar(cmd, bind);

            if (acted_dv == null)
                acted_dv = 0;

            int acted_dv_int = int.Parse(acted_dv.ToString());






            switch (aColName)
            {
                case "dv_return":

                    if (dv_int == aSourceDv)
                        Result = false;
                    else if ((dv_int - acted_dv_int) < aSourceDv)
                        Result = false;
                    else
                        Result = true;
                    break;

                case "dv_toiwon":

                    if (aSourceDv.ToString() != this.grdOrder.GetItemString(aRowNum, "dv_return"))
                        Result = false;
                    else
                        Result = true;
                    break;

                case "stop_date":

                    if ((dv_int - acted_dv_int) > 0)
                        Result = true;
                    else
                        Result = false;

                    break;
            }
            return Result;
        }

        private void GridOrderValidationFail(object aParam)
        {
            Hashtable param = aParam as Hashtable;

            XEditGrid grid = param["grid"] as XEditGrid;
            string colName = param["column_name"].ToString();
            string value = param["value"].ToString();
            int rowNumber = int.Parse(param["row_number"].ToString());

            grid.SetItemValue(rowNumber, colName, value);

            if (this.rbtDC.Checked)
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                        && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                        && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                        && grid.GetItemString(rowNumber, "mix_group") != "")
                    {
                        grid.SetItemValue(i, "stop_date", grid.GetItemString(rowNumber, "stop_date"));
                        if (grid.GetItemString(rowNumber, "stop_date") == "")
                        {
                            grid[i, "select_yn"].Image = this.ImageList.Images[1];
                            grid.SetItemValue(i, "select_yn", "N");
                        }
                    }
                }
            }
        }

        private bool IsValidStopDate(string aStopStartDate, string aStopEndDate, string aStart_date, string aEndDate, string aActingDate)
        {
            DateTime stopStartDate;
            DateTime stopEndDate;
            DateTime endDate;
            DateTime startDate;
            DateTime actingDate;


            string curTime = TypeCheck.NVL(aEndDate, EnvironInfo.GetSysDate()).ToString();  

            if ((TypeCheck.IsDateTime(aStopStartDate) == false)||
                (TypeCheck.IsDateTime(DateTime.Parse(TypeCheck.NVL(aStopEndDate, "9998/12/31").ToString())) == false) ||
                (TypeCheck.IsDateTime(aStart_date) == false)||
                (TypeCheck.IsDateTime(curTime) == false))
            {
                return false;
            }

            stopStartDate    = DateTime.Parse(aStopStartDate);

            if(aStopEndDate != "")
                stopEndDate = DateTime.Parse(aStopEndDate);
            else
                stopEndDate = DateTime.Parse("9998/12/31");

            startDate   = DateTime.Parse(aStart_date);
            endDate     = DateTime.Parse(curTime);
            
           
            if (stopStartDate > endDate)
            {//中止日が終了日より未来です。中止日を確認して下さい。
                XMessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (stopStartDate < startDate)
            {//中止日がオーダ日付より過去です。中止日を確認して下さい。
                XMessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (stopStartDate > stopEndDate)
            {//中止日がオーダ日付より過去です。中止日を確認して下さい。
                XMessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!this.GetCanBannab(1, this.grdOrder.CurrentRowNumber, "stop_date"))
            {
                XMessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (aActingDate != "")
            //{
            //    actingDate = DateTime.Parse(aActingDate);
            //    if (stopStartDate <= actingDate)
            //    {//中止日がオーダ実施日付より過去です。中止日を確認して下さい。
            //        XMessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}
            return true;
        }

        private bool IsValidStopEndDate(string aStopStartDate, string aStopEndDate, string aStart_date, string aEndDate, string aActingDate)
        {
            DateTime stopStartDate;
            DateTime stopEndDate;
            
            DateTime endDate;
            DateTime startDate;
            DateTime actingDate;


            string curTime = TypeCheck.NVL(aEndDate, EnvironInfo.GetSysDate()).ToString();

            if ((TypeCheck.IsDateTime(aStopStartDate) == false) ||
                (TypeCheck.IsDateTime(aStopEndDate)   == false) ||
                (TypeCheck.IsDateTime(aStart_date)    == false) ||
                (TypeCheck.IsDateTime(curTime)        == false))
            {
                return false;
            }

            stopStartDate = DateTime.Parse(aStopStartDate);
            stopEndDate   = DateTime.Parse(aStopEndDate);

            startDate = DateTime.Parse(aStart_date);            
            endDate   = DateTime.Parse(curTime);


            if (startDate > stopStartDate)
                return false;

            if (endDate < stopEndDate)
                return false;
            

            if (stopEndDate > endDate)
            {//中止日が終了日より未来です。中止日を確認して下さい。
                XMessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (stopEndDate < stopStartDate)
            {//中止日がオーダ日付より過去です。中止日を確認して下さい。
                XMessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (aActingDate != "")
            //{
            //    actingDate = DateTime.Parse(aActingDate);
            //    if (stopEndDate < actingDate)
            //    {//中止日がオーダ実施日付より過去です。中止日を確認して下さい。
            //        XMessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}

            // Set stop_end_date 
            string cmd_s3 = @"SELECT DISTINCT B.ACT_RES_DATE
                                        FROM OCS2003 A
                                           , OCS2017 B
                                      WHERE A.HOSP_CODE = :f_hosp_code
                                        AND A.BUNHO     = :f_bunho
                                        AND A.PKOCS2003 = :f_pkocs2003
                                        --
                                        AND B.HOSP_CODE = A.HOSP_CODE
                                        AND B.FKOCS2003 = A.PKOCS2003
                                        --
                                        AND B.ACT_RES_DATE BETWEEN :f_stop_date AND :f_stop_end_date
                                        AND B.PASS_DATE IS NOT NULL";

            BindVarCollection bind_s3 = new BindVarCollection();
            bind_s3.Add("f_hosp_code",      EnvironInfo.HospCode);
            bind_s3.Add("f_bunho",          this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"));
            bind_s3.Add("f_pkocs2003",      this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocs2003"));
            bind_s3.Add("f_stop_date",      DateTime.Parse(aStopStartDate).AddDays(1).ToString("yyyy/MM/dd"));
            bind_s3.Add("f_stop_end_date",  aStopEndDate);

            object obj = Service.ExecuteScalar(cmd_s3, bind_s3);

            if (obj != null)
            {
                XMessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            

            return true;
        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            if (this.rbtDC.Checked == false)
            {
                e.Protect = true;
                return;
            }

            if (e.DataRow["select_yn"].ToString() != "Y")
            {
                e.Protect = true;
                return;
            }
            else
                e.Protect = false;

            //if (e.ColName == "stop_date")
            //{
            //    if (e.DataRow["select_yn"].ToString() != "Y")
            //    {
            //        e.Protect = true;
            //    }
            //    else
            //    {
            //        e.Protect = false;
            //    }
            //}
            //if (e.ColName == "dv")
            //{
            //    if (e.DataRow["order_gubun"].ToString().Substring(1, 1) != "B"
            //        && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C"
            //        && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "D")
            //        e.Protect = true;
            //}

            //if (e.ColName == "bogyong_code")
            //{
            //    if (e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C")
            //    {
            //        e.Protect = true;
            //    }
            //}
            //switch (e.ColName)
            //{
            //    case "stop_date":

            //        if (grid.GetItemString(e.RowNumber, "select_yn") != "Y")
            //        {
            //            e.Protect = true;
            //        }
            //        else
            //        {
            //            e.Protect = false;
            //        }
            //        break;
            //}

            if (e.ColName == "dv_return")
            {
                if (   e.DataRow["order_gubun"].ToString().Substring(1, 1) == "B"
                    || e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C"
                    || e.DataRow["order_gubun"].ToString().Substring(1, 1) == "D")
                    e.Protect = false;
                else
                    e.Protect = true;
            }
            if (   e.ColName == "bogyong_code_return"
                || e.ColName == "bogyong_code_return_name")
            {
                if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C")
                    e.Protect = false;
                else
                    e.Protect = true;
            }

            if (   e.ColName == "dv_toiwon"
                || e.ColName == "bogyong_code_toiwon"
                || e.ColName == "bogyong_code_toiwon_name")
            {
                if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C")
                    e.Protect = false;
                else
                    e.Protect = true;
            }
        }

        #endregion

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DiaplayMixGroup(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                //aGrd.Redraw = false; // Grid Display 멈춤

                int imageCnt = 0;

                // 기존 image 클리어
                for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    //if (aGrd.GetItemString(i, "dc_check") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() //&&
                                //aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
                                //aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                //aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1)
                                )
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    //aGrd[j + aGrd.HeaderHeights.Count, 1].Image = this.imageListMixGroup.Images[imageCnt];
                                    //aGrd[i + aGrd.HeaderHeights.Count, 1].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                }
                            }
                        }
                        // 현재는 image 갯수만큼 처리
                        if (count > 1) imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }
        #endregion

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.LoadAllData();
                    break;
                case FunctionType.Process:

                    e.IsBaseCall = false;

                    //this.mAfterQuerySetFocusRow = this.grdOrder_date.CurrentRowNumber;
                    //this.mAfterQuerySetFocusColName = this.grdOrder_date.CurrentColName;

                    ////[中止しようとした場合、中止するデータがあるのかまた中止日が設定されているのかをチェック]
                    //if (this.BannabProcessCheck(this.rbtDC.Checked) == false)
                    //    return;

                    //if (this.BannabProcess(this.rbtDC.Checked))
                    //{
                    //    //this.ClearGridData(false, this.rbtDC.Checked);
                    //    //this.LoadAllData();
                    //    this.grdDrugOrder.QueryLayout(true);
                    //    //this.LoadInputTab();
                    //}

                    //this.grdOrder_date.QueryLayout(false);
                    
                    break;
                case FunctionType.Print:
                    DrgPrintProcess(this.rbtDC.Checked);
                    break;

                case FunctionType.Close :

                    break;
            }
        }
        
        private void dtpQueryDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.LoadAllData();
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            //this.grdOrder_date.QueryLayout(true);
            this.LoadAllData();
        }


        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            this.grdDrugOrder.Reset();
            this.grdOrder_date.Reset();
            this.grdOrder.Reset();
        }

        private void grdOrder_date_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrder_date.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdOrder_date.SetBindVarValue("f_bunho", paBox.BunHo);
            grdOrder_date.SetBindVarValue("f_fkinp1001", this.mParamFkinp1001);
            grdOrder_date.SetBindVarValue("f_order_date", this.dtpQueryDate.GetDataValue());
            grdOrder_date.SetBindVarValue("f_input_gubun", "D0");
            grdOrder_date.SetBindVarValue("f_gaiyou_yn", (this.cbxGaiyouDrgViewYN.Checked == true ? "Y" : "N"));
            //grdOrder_date.SetBindVarValue("f_doctor", this.mParamInputDoctor);
            
        }

        private void grdOrder_date_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            

            if (grdOrder_date.RowCount > 0)
            {
                this.grdDrugOrder.QueryLayout(true);
                this.SetPartReturnColumn(false, "all");
            }

            if(this.grdOrder.DisplayRowCount > 0)
            {
                if (this.grdOrder.GetItemString(0, "start_date") != "")
                    this.dtpKijunDate.SetDataValue(this.grdOrder.GetItemString(0, "start_date"));
            }
        }

        private void tabOrder_gubun_SelectionChanged(object sender, EventArgs e)
        {
            foreach (IHIS.X.Magic.Controls.TabPage page in tabOrder_gubun.TabPages)
            {
                if (tabOrder_gubun.SelectedTab == page)
                    page.ImageIndex = 0;
                else
                    page.ImageIndex = 1;
            }
            this.ClearFilter(tabOrder_gubun.SelectedTab.Tag.ToString().Trim());
        }

        private void ClearFilter(string input_tab)
        {

            string filter = tabOrder_gubun.SelectedTab.Tag.ToString() == "%" ? "" : " input_tab = '" + input_tab + "' and  ";

            if (rbtDC.Checked)
                filter = filter + " bannab_can_yn <> 'Y' ";
            else
                filter = filter + " bannab_can_yn = 'Y' ";

            if ((input_tab != "01") &&
                (input_tab != "03") &&
                (input_tab != "%"))
            {
                this.grdOrder.CellInfos["end_date"].HeaderText = "実施\r\n予定日";
            }
            else
            {
                this.grdOrder.CellInfos["end_date"].HeaderText = "終了日";
            }
            this.grdOrder.InitializeColumns();

            //if ((input_tab != "01") &&
            //    (input_tab != "03") &&
            //    (input_tab != "%"))
            //{
            //    this.grdOrder.AutoSizeColumn(12, 0);
            //    this.grdOrder.AutoSizeColumn(13, 40);
            //    this.grdOrder.AutoSizeColumn(14, 0);
            //}
            //else
            //{
            //    this.grdOrder.AutoSizeColumn(12, 40);
            //    this.grdOrder.AutoSizeColumn(13, 40);
            //    if (this.rbtDC.Checked)
            //    {
            //        this.grdOrder.AutoSizeColumn(14, 40);
            //    }
            //    else
            //    {
            //        this.grdOrder.AutoSizeColumn(14, 0);
            //    }
            //}
            this.grdOrder.Reset();
            this.grdDrugOrder.ClearFilter();
            if (grdDrugOrder.RowCount > 0) this.grdDrugOrder.SetFilter(filter);

            foreach (DataRow drRow in this.grdDrugOrder.LayoutTable.Rows)
            {
                this.grdOrder.LayoutTable.ImportRow(drRow);
            }
            this.grdOrder.DisplayData();

            this.SetImage(this.grdOrder);

            this.SetPartReturnColumn(false, "all");
        }
        private void LoadInputTab()
        {
            int selectedIndex = this.tabOrder_gubun.SelectedIndex;

            this.rbtReturn.ForeColor = new XColor(Color.Black);

            this.tabOrder_gubun.SelectionChanged -= new System.EventHandler(this.tabOrder_gubun_SelectionChanged);
            try
            {
                tabOrder_gubun.TabPages.Clear();
            }
            catch { }

            //grdDrugOrder.ClearFilter();

            IHIS.X.Magic.Controls.TabPage page = new IHIS.X.Magic.Controls.TabPage();
            page.Title = "全体";
            page.Tag = "%";
            page.ImageIndex = 0;
            page.TabIndex = 0;
            tabOrder_gubun.TabPages.Add(page);

            if (tabOrder_gubun.TabPages.Count > 1) return;
            if (grdDrugOrder.RowCount < 1) return;

            if (grdDrugOrder.LayoutTable.Select("bannab_can_yn = 'Y'", "").Length > 0)
            {
                this.rbtReturn.ForeColor = new XColor(Color.Red);
            }
            else
            {
                this.rbtReturn.ForeColor = new XColor(Color.Black);
            }
            //Tab page생성	
            //string filter = "";
            //if (rbtDC.Checked)
            //    filter = " bannab_can_yn <> 'Y' ";
            //else
            //    filter = " bannab_can_yn = 'Y' ";

            string input_tab = "", input_tab_name = "";

            int cnt = 1;

            //foreach (DataRow row in grdDrugOrder.LayoutTable.Select(filter, " input_tab "))
            foreach (DataRow row in grdDrugOrder.LayoutTable.Rows)
            {
                if (row["input_tab"].ToString() != input_tab)
                {
                    input_tab = row["input_tab"].ToString().Trim();

                    input_tab_name = row["input_tab_name"].ToString();

                    if (input_tab_name == "") continue;

                    page = new IHIS.X.Magic.Controls.TabPage();
                    page.Title = input_tab_name;
                    page.Tag = input_tab;
                    page.ImageIndex = 1;
                    page.TabIndex = cnt;
                    tabOrder_gubun.TabPages.Add(page);
                    cnt++;
                }
            }
            tabOrder_gubun.SelectedIndex = 0;
            this.tabOrder_gubun.SelectionChanged += new System.EventHandler(this.tabOrder_gubun_SelectionChanged);
            this.ClearFilter("%");

            if (selectedIndex > -1)
                this.tabOrder_gubun.SelectedIndex = selectedIndex;
        }
        private void SetImage(XEditGrid grd )
        {
            // 조회후 이미지 셋팅this.grdOrder.DisplayRowCount
            for (int i = 0; i < grd.DisplayRowCount; i++)
            {
                if (grd.GetItemString(i, "select_yn") != "Y")
                {
                    grd[i, "select_yn"].Image = this.ImageList.Images[1];
                }
                else
                {
                    grd[i, "select_yn"].Image = this.ImageList.Images[0];
                }
            }
        }
        private void rbtDC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDC.Checked)
            {
                btnProcess.Visible = true;
                btnChangeToToiwonDrg.Visible = true;

                this.btnProcess.Text = "返却処理";
                this.btnProcess.ImageIndex = 14;
                rbtDC.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                //if (rbtDC.Tag.ToString() != "Y") rbtDC.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtDC.Font = new Font(rbtDC.Font.FontFamily, rbtDC.Font.Size, FontStyle.Bold);
                rbtDC.ImageIndex = 0;

                rbtReturn.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                //if (rbtReturn.Tag.ToString() != "Y") rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtReturn.Font = new Font(rbtDC.Font.FontFamily, rbtDC.Font.Size);
                rbtReturn.ImageIndex = 1;
            }
            else
            {
                //this.btnProcess.Text = "返却処理取消";
                //this.btnProcess.ImageIndex = 15;
                btnProcess.Visible = false;
                btnChangeToToiwonDrg.Visible = false;

                rbtReturn.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                //if (rbtReturn.Tag.ToString() != "Y") rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtReturn.Font = new Font(rbtDC.Font.FontFamily, rbtDC.Font.Size, FontStyle.Bold);
                rbtReturn.ImageIndex = 0;

                rbtDC.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                //if (rbtDC.Tag.ToString() != "Y") rbtDC.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtDC.Font = new Font(rbtDC.Font.FontFamily, rbtDC.Font.Size);
                rbtDC.ImageIndex = 1;

            }
            if(tabOrder_gubun.TabPages.Count > 0)
                this.ClearFilter(tabOrder_gubun.SelectedTab.Tag.ToString());

            if (this.grdOrder.DisplayRowCount > 0)
            {
                if (this.grdOrder.GetItemString(0, "start_date") != "")
                    this.dtpKijunDate.SetDataValue(this.grdOrder.GetItemString(0, "start_date"));
            }
        }

        private void grdDrugOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDrugOrder.SetBindVarValue("f_bunho", this.mParamBunho);
            this.grdDrugOrder.SetBindVarValue("f_fkinp1001", this.mParamFkinp1001);
            this.grdDrugOrder.SetBindVarValue("f_gwa", this.mParamInputGwa);
            this.grdDrugOrder.SetBindVarValue("f_doctor", this.grdOrder_date.GetItemString(this.grdOrder_date.CurrentRowNumber, "doctor"));
            this.grdDrugOrder.SetBindVarValue("f_input_tab", "2");
            this.grdDrugOrder.SetBindVarValue("f_query_date", this.grdOrder_date.GetItemString(this.grdOrder_date.CurrentRowNumber, "order_date"));
            this.grdDrugOrder.SetBindVarValue("f_query_gubun", (this.rbtDC.Checked == true ? "1" : "2"));
            this.grdDrugOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDrugOrder.SetBindVarValue("f_gaiyou_yn", (this.cbxGaiyouDrgViewYN.Checked == true ? "Y" : "N"));
            this.grdDrugOrder.SetBindVarValue("f_kijun_date", TypeCheck.NVL(this.dtpKijunDate.GetDataValue(), this.grdOrder_date.GetItemString(this.grdOrder_date.CurrentRowNumber, "order_date")).ToString());
        }

        private void grdDrugOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.LoadInputTab();
        }

        private void btnDatePlusMinus_Click(object sender, EventArgs e)
        {
            setDatePlusMinus(this.dtpKijunDate, ((Control)sender).Tag.ToString());
        }

        public void setDatePlusMinus(XDatePicker aKijunDate, string aGubun)
        {
            if (aKijunDate.GetDataValue() == "")
                aKijunDate.SetDataValue(EnvironInfo.GetSysDate());

            if (aGubun == "-" && aKijunDate.GetDataValue() != "")
                aKijunDate.SetDataValue(DateTime.Parse(aKijunDate.GetDataValue()).AddDays(-1));
            else if (aGubun == "+" && aKijunDate.GetDataValue() != "")
                aKijunDate.SetDataValue(DateTime.Parse(aKijunDate.GetDataValue()).AddDays(+1));

            aKijunDate.AcceptData();
        }
        private void dtpKijunDate_TextChanged(object sender, EventArgs e)
        {
            if (!TypeCheck.IsDateTime(this.dtpKijunDate.GetDataValue()))
                return;

            DateTime dt = DateTime.Parse(this.dtpKijunDate.GetDataValue());

            this.grdOrder.CellInfos[42].HeaderText = dt.ToString("MM")             + "\r\n/\r\n" + dt.ToString("dd");
            this.grdOrder.CellInfos[43].HeaderText = dt.AddDays(1).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(1).ToString("dd");
            this.grdOrder.CellInfos[44].HeaderText = dt.AddDays(2).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(2).ToString("dd");
            this.grdOrder.CellInfos[45].HeaderText = dt.AddDays(3).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(3).ToString("dd");
            this.grdOrder.CellInfos[46].HeaderText = dt.AddDays(4).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(4).ToString("dd");
            this.grdOrder.CellInfos[47].HeaderText = dt.AddDays(5).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(5).ToString("dd");
            this.grdOrder.CellInfos[48].HeaderText = dt.AddDays(6).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(6).ToString("dd");
            this.grdOrder.CellInfos[49].HeaderText = dt.AddDays(7).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(7).ToString("dd");
            this.grdOrder.CellInfos[50].HeaderText = dt.AddDays(8).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(8).ToString("dd");
            this.grdOrder.CellInfos[51].HeaderText = dt.AddDays(9).ToString("MM")  + "\r\n/\r\n" + dt.AddDays(9).ToString("dd");
            this.grdOrder.CellInfos[52].HeaderText = dt.AddDays(10).ToString("MM") + "\r\n/\r\n" + dt.AddDays(10).ToString("dd");
            this.grdOrder.CellInfos[53].HeaderText = dt.AddDays(11).ToString("MM") + "\r\n/\r\n" + dt.AddDays(11).ToString("dd");
            this.grdOrder.CellInfos[54].HeaderText = dt.AddDays(12).ToString("MM") + "\r\n/\r\n" + dt.AddDays(12).ToString("dd");
            this.grdOrder.CellInfos[55].HeaderText = dt.AddDays(13).ToString("MM") + "\r\n/\r\n" + dt.AddDays(13).ToString("dd");
            //this.grdOrder.CellInfos[24].HeaderText = dt.AddDays(14).ToString("dd");

            this.grdOrder.InitializeColumns();

            this.grdDrugOrder.QueryLayout(false);

            this.SetPartReturnColumn(false, "all");
        }

        private void grdOrder_date_GridCellFocusChanged(object sender, XGridCellFocusChangedEventArgs e)
        {
            string tab_gubun = "%";

            if (   (e.ColName == "input_tap_01_c") 
                || (e.ColName == "input_tap_01_d")
                || (e.ColName == "input_tap_03")
                || (e.ColName == "input_tap_04")
                || (e.ColName == "input_tap_05")
                || (e.ColName == "input_tap_07")
                || (e.ColName == "input_tap_08")
                || (e.ColName == "input_tap_09")
                || (e.ColName == "input_tap_11")
                || (e.ColName == "order_date_md")
                || (e.ColName == "doctor_name"))
            {
                if (   grdOrder_date.GetItemString(e.RowNumber, e.ColName) != ""
                    && e.ColName != "order_date_md"
                    && e.ColName != "doctor_name"
                    )
                {
                    tab_gubun = e.ColName.Substring(10, 2);
                }

                foreach (IHIS.X.Magic.Controls.TabPage page in tabOrder_gubun.TabPages)
                {
                    if (page.Tag.ToString() == tab_gubun)
                    {
                        page.ImageIndex = 0;
                        this.tabOrder_gubun.SelectionChanged -= new System.EventHandler(this.tabOrder_gubun_SelectionChanged);
                        tabOrder_gubun.SelectedIndex = page.TabIndex;
                        this.tabOrder_gubun.SelectionChanged += new System.EventHandler(this.tabOrder_gubun_SelectionChanged);
                    }
                    else
                    {
                        page.ImageIndex = 1;
                    }
                }

                //if ((tab_gubun != "01") &&
                //    (input_tab != "03") &&
                //    (input_tab != "%"))
                //{
                //    //this.grdDrugOrder.HeaderInfos[12].HeaderText = "希望日";
                //    this.grdDrugOrder.AutoSizeColumn(11, 0);
                //    this.grdDrugOrder.AutoSizeColumn(12, 45);
                //    this.grdDrugOrder.CellInfos["end_date"].HeaderText = "希望日";
                //}
                //else
                //{
                //    this.grdDrugOrder.AutoSizeColumn(11, 45);
                //    this.grdDrugOrder.AutoSizeColumn(12, 45);
                //    this.grdDrugOrder.CellInfos["end_date"].HeaderText = "投薬\r\n終了日";
                //}
                //this.grdDrugOrder.InitializeColumns();

                this.ClearFilter(tab_gubun);
            }
            //else if (   (e.ColName == "order_date_md") 
            //         || (e.ColName == "doctor_name"))
            //{

            //}
        }

        private void grdOrder_date_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdOrder_date.RowCount == 0)
                this.grdOrder.Reset();
            else
            {
                for (int i = 0; i < this.grdOrder_date.RowCount; i++)
                {
                    if (this.grdOrder_date.GetItemString(i, "input_tap_01_c") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_01_c") == "●")
                            this.grdOrder_date[i, "input_tap_01_c"].Image = this.ImageList.Images[3];
                        else
                            this.grdOrder_date[i, "input_tap_01_c"].Image = this.ImageList.Images[12];
                    }
                    if (this.grdOrder_date.GetItemString(i, "input_tap_01_d") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_01_d") == "●")
                            this.grdOrder_date[i, "input_tap_01_d"].Image = this.ImageList.Images[3];
                        else
                            this.grdOrder_date[i, "input_tap_01_d"].Image = this.ImageList.Images[12];
                    }
                    if (this.grdOrder_date.GetItemString(i, "input_tap_03") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_03") == "●")
                            this.grdOrder_date[i, "input_tap_03"].Image = this.ImageList.Images[4];
                        else
                            this.grdOrder_date[i, "input_tap_03"].Image = this.ImageList.Images[12];
                    }
                    if (this.grdOrder_date.GetItemString(i, "input_tap_04") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_04") == "●")
                            this.grdOrder_date[i, "input_tap_04"].Image = this.ImageList.Images[2];
                        else
                            this.grdOrder_date[i, "input_tap_04"].Image = this.ImageList.Images[12];
                    }
                    if (this.grdOrder_date.GetItemString(i, "input_tap_05") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_05") == "●")
                            this.grdOrder_date[i, "input_tap_05"].Image = this.ImageList.Images[9];
                        else
                            this.grdOrder_date[i, "input_tap_05"].Image = this.ImageList.Images[12];
                    }
                    if (this.grdOrder_date.GetItemString(i, "input_tap_07") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_07") == "●")
                            this.grdOrder_date[i, "input_tap_07"].Image = this.ImageList.Images[5];
                        else
                            this.grdOrder_date[i, "input_tap_07"].Image = this.ImageList.Images[12];
                    }
                    if (this.grdOrder_date.GetItemString(i, "input_tap_08") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_08") == "●")
                            this.grdOrder_date[i, "input_tap_08"].Image = this.ImageList.Images[7];
                        else
                            this.grdOrder_date[i, "input_tap_08"].Image = this.ImageList.Images[12];
                    }
                    if (this.grdOrder_date.GetItemString(i, "input_tap_09") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_09") == "●")
                            this.grdOrder_date[i, "input_tap_09"].Image = this.ImageList.Images[6];
                        else
                            this.grdOrder_date[i, "input_tap_09"].Image = this.ImageList.Images[12];
                    }
                    if (this.grdOrder_date.GetItemString(i, "input_tap_11") != "")
                    {
                        if (this.grdOrder_date.GetItemString(i, "input_tap_11") == "●")
                            this.grdOrder_date[i, "input_tap_11"].Image = this.ImageList.Images[8];
                        else
                            this.grdOrder_date[i, "input_tap_11"].Image = this.ImageList.Images[12];
                    }
                }
            }
            this.grdOrder_date.SetFocusToItem(this.mAfterQuerySetFocusRow, this.mAfterQuerySetFocusColName);
        }

        #region 변경 처방전 출력

        #region [--DrgPrintProcess--]
        private void DrgPrintProcess(bool aIsBannab)
        {
            if (aIsBannab)
            {
                for (int i = 0; i < mCancel_drg_bunho_list.Count; i++)
                {
                    if (mCancel_input_list[i].ToString() == "01")
                    {
                        DrgPrint(mCancel_jubsu_list[i].ToString(), mCancel_drg_bunho_list[i].ToString(), false, "R");
                    }
                    else
                    {
                        DrgPrint(mCancel_jubsu_list[i].ToString(), mCancel_drg_bunho_list[i].ToString(), true, "R");
                    }
                }
                mCancel_drg_bunho_list.Clear();

                // DRG_BUNHO別に処方箋出力するロジック封印
                if (false)
                {
                    for (int i = 0; i < this.drg_bunho.Count; i++)
                    {
                        if (drg_bunho[i].ToString().Substring(0, 1) != "B")
                        {
                            //string ar_JubsuDate, string ar_DrgBunho, bool ar_isJusa, string ar_Print_Gubun
                            DrgPrint(drg_bunho[i].ToString().Substring(1, 10), drg_bunho[i].ToString().Substring(11), false, "R");
                        }
                        else
                        {
                            DrgPrint(drg_bunho[i].ToString().Substring(1, 10), drg_bunho[i].ToString().Substring(11), true, "R");
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < mCancel_drg_bunho_list.Count; i++)
                {
                    if (mCancel_input_list[i].ToString() == "01")
                    {
                        DrgPrint(mCancel_jubsu_list[i].ToString(), mCancel_drg_bunho_list[i].ToString(), false, "R");
                    }
                    else
                    {
                        DrgPrint(mCancel_jubsu_list[i].ToString(), mCancel_drg_bunho_list[i].ToString(), true, "R");
                    }
                }
                mCancel_drg_bunho_list.Clear();
            }
        }
        #endregion

        #region [--DrgPrint--]
        /// <param name="ar_JubsuDate"></param>
        /// <param name="ar_DrgBunho"></param>
        /// <param name="ar_isJusa"></param>
        /// <param name="ar_Print_Gubun"></param>

        private void DrgPrint(string ar_JubsuDate, string ar_DrgBunho, bool ar_isJusa, string ar_Print_Gubun)
        {
            int row;

            //내복, 외용

            string origin_printer = IHIS.Framework.PrintHelper.GetDefaultPrinterName();
            

            if (!ar_isJusa)
            {
                #region 약국용 처방전
                dw_print.DataWindowObject = "d_drg3010_1";

                dw_print.Reset();

                // 오다 내역 조회
                if (DsvOrderPrint(ar_JubsuDate, ar_DrgBunho, ar_Print_Gubun))
                {
                    dw_print.FillChildData("dw_1", layOrderPrint.LayoutTable);
                }

                // comment 조회
                if (DsvOrderJungbo(ar_JubsuDate, ar_DrgBunho))
                {
                    dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                }

                if (layOrderJungbo.RowCount < 1)
                {
                    row = layOrderJungbo.InsertRow(0);
                    layOrderJungbo.SetItemValue(row, "bar_drg_bunho", ar_JubsuDate.Replace("/", "") + ar_DrgBunho);
                    dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                }

                dw_print.AcceptText();

                if (dw_print.RowCount > 0)
                {
                    dw_print.Print();
                }
                else
                    return;

                #endregion

                #region 병동용 처방전
                dw_print.DataWindowObject = "d_drg3010_1_ho_dong";

                dw_print.Reset();

                dw_print.FillChildData("dw_1", layOrderPrint.LayoutTable);

                // comment 조회
                //if (DsvOrderBarcode(ar_JubsuDate, ar_DrgBunho))
                //{
                //    dw_print.FillChildData("dw_2", layOrderBarcode.LayoutTable);
                //}
                dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);

                dw_print.AcceptText();
                if (dw_print.RowCount > 0)
                    dw_print.Print();
                #endregion

                #region 향균의뢰서 출력
                //if (DsvDrg1000Load(ar_JubsuDate, ar_DrgBunho) != "")
                //{
                //    dw_Anti.Reset();
                //    layAntiData.SetBindVarValue("f_fkocs", DsvDrg1000Load(ar_JubsuDate, ar_DrgBunho));
                //    if (layAntiData.QueryLayout(false))
                //    {
                //        dw_Anti.FillData(layAntiData.LayoutTable);
                //        dw_Anti.Print();
                //    }
                //    else
                //        XMessageBox.Show(Service.ErrFullMsg);
                //}
                #endregion
                return;
            }
           
            else//주사
            {
                #region 약국용 처방전
                dw_jusa.DataWindowObject = "d_drg3010_4";

                dw_jusa.Reset();

                // 오다 내역 조회
                if (DsvJusaOrderPrint(ar_JubsuDate, ar_DrgBunho, ar_Print_Gubun))
                {
                    dw_jusa.FillChildData("dw_1", layJusaOrderPrint.LayoutTable);
                }
                // comment 조회
                if (DsvOrderJungbo(ar_JubsuDate, ar_DrgBunho))
                {
                    dw_jusa.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                }

                if (layOrderJungbo.RowCount < 1)
                {
                    row = layOrderJungbo.InsertRow(0);
                    layOrderJungbo.SetItemValue(row, "bar_drg_bunho", ar_JubsuDate.Replace("/", "") + ar_DrgBunho);
                    dw_jusa.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                }

                dw_jusa.AcceptText();
                if (dw_jusa.RowCount > 0)
                {
                    dw_jusa.Print();
                }
                else
                    return;
                #endregion

                #region 병동용 처방전
                dw_jusa.DataWindowObject = "d_drg3010_jusa_ho_dong_all";

                dw_jusa.Reset();

                // 오다 내역 조회
                dw_jusa.FillData(layJusaOrderPrint.LayoutTable);

                dw_jusa.AcceptText();
                if (dw_jusa.RowCount > 0)
                    dw_jusa.Print();
                else
                    return;
                #endregion

                #region 향균의뢰서 출력
                //if (DsvDrg1000Load(ar_JubsuDate, ar_DrgBunho) != "")
                //{
                //    dw_Anti.Reset();
                //    layAntiData.SetBindVarValue("f_fkocs", DsvDrg1000Load(ar_JubsuDate, ar_DrgBunho));
                //    if (layAntiData.QueryLayout(false))
                //    {
                //        dw_Anti.FillData(layAntiData.LayoutTable);
                //        dw_Anti.Print();
                //    }
                //    else
                //        XMessageBox.Show(Service.ErrFullMsg);
                //}
                #endregion
                return;
            }
        }
        #endregion

        #region [-- DsvOrderPrint --]
        /// <summary>
        /// dsvOrderPrint Service Conversion PC: DRGPRINT, WT: E
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <param name="printGubun"></param>
        /// <returns></returns>
        private bool DsvOrderPrint(string jubsuDate, string drgBunho, string printGubun)
        {
            layOrderPrint.Reset();
            layOrderPrintTemp.Reset();

            string o_bunho = string.Empty;
            string o_drg_bunho = string.Empty;
            string o_naewon_date = string.Empty;
            string o_group_ser = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_order_date = string.Empty;
            string o_jaeryo_code = string.Empty;
            string o_divide = string.Empty;
            string o_ord_suryang = string.Empty;
            string o_order_suryang = string.Empty;
            string o_order_danui = string.Empty;
            string o_subul_danui = string.Empty;
            string o_group_yn = string.Empty;
            string o_jaeryo_gubun = string.Empty;
            string o_bogyong_code = string.Empty;
            string o_bogyong_name = string.Empty;
            string o_caution_name = string.Empty;
            string o_caution_code = string.Empty;
            string o_mix_yn = string.Empty;
            string o_atc_yn = string.Empty;
            string o_dv = string.Empty;
            string o_dv_time = string.Empty;
            string o_dc_yn = string.Empty;
            string o_bannab_yn = string.Empty;
            string o_source_fkocs2003 = string.Empty;
            string o_fkocs2003 = string.Empty;
            string o_sunab_date = string.Empty;
            string o_pattern = string.Empty;
            string o_jaeryo_name = string.Empty;
            string o_sunab_nalsu = string.Empty;
            string o_wonyoi_yn = string.Empty;
            string o_order_remark = string.Empty;
            string o_act_date = string.Empty;
            string o_mayak = string.Empty;
            string o_tpn_joje_gubun = string.Empty;
            string o_ui_jusa_yn = string.Empty;
            string o_subul_suryang = string.Empty;
            string o_serial_v = string.Empty;
            string o_gwa_name = string.Empty;
            string o_doctor_name = string.Empty;
            string o_suname = string.Empty;
            string o_suname2 = string.Empty;
            string o_birth = string.Empty;
            string o_age_sex = string.Empty;
            string o_other_gwa = string.Empty;
            string o_do_order = string.Empty;
            string o_gubun_name = string.Empty;
            string o_hope_date = string.Empty;
            string o_powder_yn = string.Empty;
            string o_line = string.Empty;
            string o_kyukyeok = string.Empty;
            string o_ho_dong = string.Empty;
            string o_ho_code = string.Empty;
            string o_title = string.Empty;
            string o_licenes = string.Empty;
            string o_bunryu1 = string.Empty;
            string o_donbok = string.Empty;
            string o_tusuk = string.Empty;
            string o_jusa = string.Empty;
            string o_magam_gubun = string.Empty;
            string o_text_color = string.Empty;
            string o_changgo = string.Empty;
            string o_from_order_date = string.Empty;
            string o_to_order_date = string.Empty;
            string o_order_date_text = string.Empty;
            string o_serial_text = string.Empty;
            string o_sex_age = string.Empty;
            string o_rp_barcode = string.Empty;
            string o_ord_danui2 = string.Empty;
            string o_data_gubun = string.Empty;
            string o_print_gubun = string.Empty;
            string o_hodong_ord_name = string.Empty;
            string o_nalsu = string.Empty;
            string o_max_bannab_yn = string.Empty;

            int rowNum;

            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            DataTable resTable = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();
            DataTable dtBannab = new DataTable();

            /* 재출력, 보류 체크 */
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(jubsuDate);
            inputList.Add(drgBunho);
            inputList.Add(printGubun);
            if (Service.ExecuteProcedure("PR_DRG_LOAD_PRINT_GUBUN", inputList, outputList))
            {
                o_print_gubun = outputList[0].ToString();
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return false;
            }

            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

            /* DRGPRINT_I_ORD_PRN_CUR */
            cmdText = @"SELECT DISTINCT
                               A.BUNHO                                             BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))                         DRG_BUNHO
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )    ORDER_DATE_TEXT
                              ,A.JUBSU_DATE                                        JUBSU_DATE
                              ,A.ORDER_DATE                                        ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M') SERIAL_V
                              ,E.SERIAL_V                                          SERIAL_TEXT
                              ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)           GWA_NAME
                              ,FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE)   DOCTOR_NAME
                              ,D.SUNAME                                            SUNAME
                              ,D.SUNAME2                                           SUNAME2
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH)          BIRTH
                              ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE)          SEX_AGE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)      HO_CODE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)      HO_DONG                    
                              ,DECODE(A.TOIWON_DRG_YN, '1', 'OT', A.MAGAM_GUBUN)                   MAGAM_GUBUN
                              ,TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO) || TO_CHAR(E.SERIAL_V)   RP_BARCODE
                          FROM INP1001 F
                              ,DRG2035 E
                              ,OUT0101 D
                              ,DRG0120 C
                              ,INV0110 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE         = :f_jubsu_date
                           AND A.HOSP_CODE          = :f_hosp_code
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.BUNRYU1            <> '4'
                           --AND NVL(A.DC_YN,'N')     = 'N'
                           --AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.HOSP_CODE          = A.HOSP_CODE
                           AND B.JAERYO_CODE        = A.JAERYO_CODE
                           AND C.HOSP_CODE       (+)= A.HOSP_CODE
                           AND C.BOGYONG_CODE    (+)= A.BOGYONG_CODE
                           AND D.HOSP_CODE          = A.HOSP_CODE
                           AND D.BUNHO              = A.BUNHO
                           AND E.HOSP_CODE          = A.HOSP_CODE
                           AND E.JUBSU_DATE         = A.JUBSU_DATE
                           AND E.DRG_BUNHO          = A.DRG_BUNHO
                           AND E.FKOCS2003          = A.FKOCS2003
                           AND F.HOSP_CODE          = A.HOSP_CODE
                           AND F.PKINP1001          = A.FKINP1001
                         ORDER BY TO_NUMBER(E.SERIAL_V)";
            try
            {
                resTable = Service.ExecuteDataTable(cmdText, bindVars);
                /* DRGPRINT_I_ORD_PRN_CUR */
                for (int i = 0; i < resTable.Rows.Count; i++)
                {
                    o_bunho = resTable.Rows[i]["bunho"].ToString();
                    o_drg_bunho = resTable.Rows[i]["drg_bunho"].ToString();
                    o_order_date_text = resTable.Rows[i]["order_date_text"].ToString();
                    o_jubsu_date = resTable.Rows[i]["jubsu_date"].ToString();
                    o_order_date = resTable.Rows[i]["order_date"].ToString();
                    o_serial_v = resTable.Rows[i]["serial_v"].ToString();
                    o_serial_text = resTable.Rows[i]["serial_text"].ToString();
                    o_gwa_name = resTable.Rows[i]["gwa_name"].ToString();
                    o_doctor_name = resTable.Rows[i]["doctor_name"].ToString();
                    o_suname = resTable.Rows[i]["suname"].ToString();
                    o_suname2 = resTable.Rows[i]["suname2"].ToString();
                    o_birth = resTable.Rows[i]["birth"].ToString();
                    o_sex_age = resTable.Rows[i]["sex_age"].ToString();
                    o_ho_code = resTable.Rows[i]["ho_code"].ToString();
                    o_ho_dong = resTable.Rows[i]["ho_dong"].ToString();
                    o_magam_gubun = resTable.Rows[i]["magam_gubun"].ToString();
                    o_rp_barcode = resTable.Rows[i]["rp_barcode"].ToString();

                    //
                    bindVars.Remove("f_serial_text");
                    bindVars.Add("f_serial_text", o_serial_text);
                    bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                    /* DRGPRINT_I_ORD_PRN_SERIAL */
                    cmdText = @"SELECT DISTINCT
                                       A.BUNHO                                                                                 BUNHO
                                      ,A.DRG_BUNHO                                                                             DRG_BUNHO
                                      ,A.GROUP_SER                                                                             GROUP_SER
                                      ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                                                                            JUBSU_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                                                                            ORDER_DATE
                                      ,A.JAERYO_CODE                                                                           JAERYO_CODE
                                      ,A.NALSU * DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DIVIDE, 1)              NALSU
                                      ,A.DIVIDE                                                                                DIVIDE
                                      ,A.ORD_SURYANG                                                                           ORD_SURYANG
                                      ,DECODE(A.BUNRYU1, '4', A.ORD_SURYANG, A.ORDER_SURYANG )                                 ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                         ORDER_DANUI
                                      ,A.SUBUL_DANUI                                                                           SUBUL_DANUI
                                      ,A.BOGYONG_CODE                                                                          BOGYONG_CODE
                                      ,TRIM(B.BOGYONG_NAME) || FN_DRG_LOAD_RP_TEXT('I', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V)||
                                        DECODE(NVL(G.DV_1,0) + NVL(G.DV_2,0) + NVL(G.DV_3,0) + NVL(G.DV_4,0) + NVL(G.DV_5,0) 
                                      , 0,  NULL, '('||LTRIM(TO_CHAR(NVL(G.DV_1,0))) || '-' ||LTRIM(TO_CHAR(NVL(G.DV_2,0))) ||  '-' ||
                                  LTRIM(TO_CHAR(NVL(G.DV_3,0))) || '-' ||LTRIM(TO_CHAR(NVL(G.DV_4,0))) ||  '-' ||
                                  LTRIM(TO_CHAR(NVL(G.DV_5,0)))|| ')' )   BOGYONG_NAME
                                      ,SUBSTRB(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ) ,1,80)      CAUTION_NAME
                                      ,A.MIX_YN                                                                                MIX_YN
                                      ,A.ATC_YN                                                                                ATC_YN
                                      ,D.DV                                                                                    DV
                                      ,A.DV_TIME                                                                               DV_TIME
                                      ,D.DC_YN                                                                                 DC_YN
                                      ,D.BANNAB_YN                                                                             BANNAB_YN
                                      ,D.SOURCE_FKOCS2003                                                                      SOURCE_FKOCS2003
                                      ,A.FKOCS2003                                                                             FKOCS2003
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                                          SUNAB_DATE
                                      ,B.PATTERN                                                                               PATTERN
                                      ,F.HANGMOG_NAME                                                                          JAERYO_NAME
                                      ,0                                                                                       SUNAB_NALSU
                                      ,NVL(D.WONYOI_ORDER_YN,'N')                                                              WONYOI_YN
                                      ,F.HANGMOG_NAME || ' : ' ||  TRIM(D.ORDER_REMARK)                                        ORDER_REMARK
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                    ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                   UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                         SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M')     SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                               GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                              DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                             OTHER_GWA
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                         HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                        POWDER_YN
                                      ,NVL(E.SERIAL_V, 1)                                                                      LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                       ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                            BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                          HO_DONG
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                          HO_CODE              
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                   DONBOK
                                      ,''                                                                                      TUSUK
                                      ,DECODE(G.TOIWON_DRG_YN, '1', 'OT', G.MAGAM_GUBUN)                                       MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                            TEXT_COLOR
                                      ,C.CHANGGO1                                                                              CHANGGO
                                      ,'( ' || TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE),'MM/DD')                                 FROM_ORDER_DATE
                                      ,TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE)+ A.NALSU - 1, 'MM/DD') || ' )'                   TO_ORDER_DATE
                                      ,'A'                                                                                     DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                   HODONG_ORD_NAME
                                      ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND Y.FKOCS2003  = X.FKOCS2003
                                           AND X.FKOCS2003  = E.FKOCS2003
                                           AND X.HOSP_CODE  = Y.HOSP_CODE
                                           )                                                     MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,DRG2035 E
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3011 A
                                      ,DRG3010 G
                                 WHERE A.JUBSU_DATE       = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.HOSP_CODE        = :f_hosp_code
                                   AND A.DRG_BUNHO        = :f_drg_bunho
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE        = A.HOSP_CODE
                                   AND C.JAERYO_CODE      = A.JAERYO_CODE
                                   AND D.HOSP_CODE        = A.HOSP_CODE
                                   AND D.PKOCS2003        = A.FKOCS2003
                                   AND G.HOSP_CODE        = A.HOSP_CODE
                                   AND G.FKOCS2003        = A.FKOCS2003
                                   AND E.HOSP_CODE        = A.HOSP_CODE
                                   AND E.JUBSU_DATE       = A.JUBSU_DATE
                                   AND E.DRG_BUNHO        = A.DRG_BUNHO
                                   AND E.FKOCS2003        = A.FKOCS2003
                                   AND E.SERIAL_V         = :f_serial_text
                                   AND F.HOSP_CODE        = D.HOSP_CODE
                                   AND F.HANGMOG_CODE     = D.HANGMOG_CODE
                                 ORDER BY A.DRG_BUNHO, 'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M'), A.FKOCS2003";

                    dtSerial = Service.ExecuteDataTable(cmdText, bindVars);
                    for (int j = 0; j < dtSerial.Rows.Count; j++)
                    {
                        o_bunho = dtSerial.Rows[j]["bunho"].ToString();
                        o_drg_bunho = dtSerial.Rows[j]["drg_bunho"].ToString();
                        o_group_ser = dtSerial.Rows[j]["group_ser"].ToString();
                        o_jubsu_date = dtSerial.Rows[j]["jubsu_date"].ToString();
                        o_order_date = dtSerial.Rows[j]["order_date"].ToString();
                        o_jaeryo_code = dtSerial.Rows[j]["jaeryo_code"].ToString();
                        o_nalsu = dtSerial.Rows[j]["nalsu"].ToString();
                        o_divide = dtSerial.Rows[j]["divide"].ToString();
                        o_ord_suryang = dtSerial.Rows[j]["ord_suryang"].ToString();
                        o_order_suryang = dtSerial.Rows[j]["order_suryang"].ToString();
                        o_order_danui = dtSerial.Rows[j]["order_danui"].ToString();
                        o_subul_danui = dtSerial.Rows[j]["subul_danui"].ToString();
                        o_bogyong_code = dtSerial.Rows[j]["bogyong_code"].ToString();
                        o_bogyong_name = dtSerial.Rows[j]["bogyong_name"].ToString();
                        o_caution_name = dtSerial.Rows[j]["caution_name"].ToString();
                        o_mix_yn = dtSerial.Rows[j]["mix_yn"].ToString();
                        o_atc_yn = dtSerial.Rows[j]["atc_yn"].ToString();
                        o_dv = dtSerial.Rows[j]["dv"].ToString();
                        o_dv_time = dtSerial.Rows[j]["dv_time"].ToString();
                        o_dc_yn = dtSerial.Rows[j]["dc_yn"].ToString();
                        o_bannab_yn = dtSerial.Rows[j]["bannab_yn"].ToString();
                        o_source_fkocs2003 = dtSerial.Rows[j]["source_fkocs2003"].ToString();
                        o_fkocs2003 = dtSerial.Rows[j]["fkocs2003"].ToString();
                        o_sunab_date = dtSerial.Rows[j]["sunab_date"].ToString();
                        o_pattern = dtSerial.Rows[j]["pattern"].ToString();
                        o_jaeryo_name = dtSerial.Rows[j]["jaeryo_name"].ToString();
                        o_sunab_nalsu = dtSerial.Rows[j]["sunab_nalsu"].ToString();
                        o_wonyoi_yn = dtSerial.Rows[j]["wonyoi_yn"].ToString();
                        o_order_remark = dtSerial.Rows[j]["order_remark"].ToString();
                        o_act_date = dtSerial.Rows[j]["act_date"].ToString();
                        o_ui_jusa_yn = dtSerial.Rows[j]["ui_jusa_yn"].ToString();
                        o_subul_suryang = dtSerial.Rows[j]["subul_suryang"].ToString();
                        o_serial_v = dtSerial.Rows[j]["serial_v"].ToString();
                        o_gwa_name = dtSerial.Rows[j]["gwa_name"].ToString();
                        o_doctor_name = dtSerial.Rows[j]["doctor_name"].ToString();
                        o_other_gwa = dtSerial.Rows[j]["other_gwa"].ToString();
                        o_hope_date = dtSerial.Rows[j]["hope_date"].ToString();
                        o_powder_yn = dtSerial.Rows[j]["powder_yn"].ToString();
                        o_line = dtSerial.Rows[j]["line"].ToString();
                        o_ord_danui2 = dtSerial.Rows[j]["ord_danui2"].ToString();
                        o_bunryu1 = dtSerial.Rows[j]["bunryu1"].ToString();
                        o_ho_dong = dtSerial.Rows[j]["ho_dong"].ToString();
                        o_ho_code = dtSerial.Rows[j]["ho_code"].ToString();
                        o_donbok = dtSerial.Rows[j]["donbok"].ToString();
                        o_tusuk = dtSerial.Rows[j]["tusuk"].ToString();
                        o_magam_gubun = dtSerial.Rows[j]["magam_gubun"].ToString();
                        o_text_color = dtSerial.Rows[j]["text_color"].ToString();
                        o_changgo = dtSerial.Rows[j]["changgo"].ToString();
                        o_from_order_date = dtSerial.Rows[j]["from_order_date"].ToString();
                        o_to_order_date = dtSerial.Rows[j]["to_order_date"].ToString();
                        o_data_gubun = dtSerial.Rows[j]["data_gubun"].ToString();
                        o_hodong_ord_name = dtSerial.Rows[j]["hodong_ord_name"].ToString();
                        o_max_bannab_yn = dtSerial.Rows[j]["max_bannab_yn"].ToString();

                        rowNum = layOrderPrintTemp.InsertRow(-1);

                        layOrderPrintTemp.SetItemValue(rowNum, "bunho", o_bunho);
                        layOrderPrintTemp.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layOrderPrintTemp.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "group_ser", o_group_ser);
                        layOrderPrintTemp.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "order_date", o_order_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                        layOrderPrintTemp.SetItemValue(rowNum, "nalsu", o_nalsu);
                        layOrderPrintTemp.SetItemValue(rowNum, "divide", o_divide);
                        layOrderPrintTemp.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layOrderPrintTemp.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layOrderPrintTemp.SetItemValue(rowNum, "order_danui", o_order_danui);
                        layOrderPrintTemp.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                        layOrderPrintTemp.SetItemValue(rowNum, "group_yn", o_group_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                        layOrderPrintTemp.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "caution_name", o_caution_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "caution_code", o_caution_code);
                        layOrderPrintTemp.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "dv", o_dv);
                        layOrderPrintTemp.SetItemValue(rowNum, "dv_time", o_dv_time);
                        layOrderPrintTemp.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs2003);
                        layOrderPrintTemp.SetItemValue(rowNum, "fkocs1003", o_fkocs2003);
                        layOrderPrintTemp.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "pattern", o_pattern);
                        layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                        layOrderPrintTemp.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "order_remark", o_order_remark);
                        layOrderPrintTemp.SetItemValue(rowNum, "act_date", o_act_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "mayak", o_mayak);
                        layOrderPrintTemp.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                        layOrderPrintTemp.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layOrderPrintTemp.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "suname", o_suname);
                        layOrderPrintTemp.SetItemValue(rowNum, "suname2", o_suname2);
                        layOrderPrintTemp.SetItemValue(rowNum, "birth", o_birth);
                        layOrderPrintTemp.SetItemValue(rowNum, "age", o_sex_age);
                        layOrderPrintTemp.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrintTemp.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrintTemp.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "hope_date", o_hope_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "line", o_line);
                        layOrderPrintTemp.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrintTemp.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrintTemp.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrintTemp.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                        layOrderPrintTemp.SetItemValue(rowNum, "ho_code", o_ho_code);
                        layOrderPrintTemp.SetItemValue(rowNum, "title", o_title);
                        layOrderPrintTemp.SetItemValue(rowNum, "donbok", o_donbok);
                        layOrderPrintTemp.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrintTemp.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrintTemp.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrintTemp.SetItemValue(rowNum, "from_order_date", o_from_order_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "to_order_date", o_to_order_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);

                        //반납건 추가 조회
                        bindVars.Remove("f_serial_v");
                        bindVars.Add("f_serial_v", o_serial_text);
                        bindVars.Add("f_fkocs2003", o_fkocs2003);
                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                        cmdText = @"SELECT DISTINCT
                                       A.BUNHO                                                                                 BUNHO
                                      ,A.DRG_BUNHO                                                                             DRG_BUNHO
                                      ,A.GROUP_SER                                                                             GROUP_SER
                                      ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                                                                            JUBSU_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                                                                            ORDER_DATE
                                      ,A.JAERYO_CODE                                                                           JAERYO_CODE
                                      ,A.NALSU * DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DIVIDE, 1)              NALSU
                                      ,A.DIVIDE                                                                                DIVIDE
                                      ,CASE WHEN A.NALSU < 0 THEN '-'||CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN '0'||ROUND(A.ORD_SURYANG,2) ELSE ''||ROUND(A.ORD_SURYANG,2) END
                                                           ELSE ''||CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN '0'||ROUND(A.ORD_SURYANG,2) ELSE ''||ROUND(A.ORD_SURYANG,2) END
                                                           END                                                                 ORD_SURYANG
                                      ,DECODE(A.BUNRYU1, '4', A.ORD_SURYANG, A.ORDER_SURYANG )                                 ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                         ORDER_DANUI
                                      ,A.SUBUL_DANUI                                                                           SUBUL_DANUI
                                      ,A.BOGYONG_CODE                                                                          BOGYONG_CODE
                                      ,TRIM(B.BOGYONG_NAME) || FN_DRG_LOAD_RP_TEXT('I', A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v)||
                                        DECODE(NVL(A.DV_1,0) + NVL(A.DV_2,0) + NVL(A.DV_3,0) + NVL(A.DV_4,0) + NVL(A.DV_5,0)
                                      , 0,  NULL, '('||LTRIM(TO_CHAR(NVL(A.DV_1,0))) || '-' ||LTRIM(TO_CHAR(NVL(A.DV_2,0))) ||  '-' ||
                                  LTRIM(TO_CHAR(NVL(A.DV_3,0))) || '-' ||LTRIM(TO_CHAR(NVL(A.DV_4,0))) ||  '-' ||
                                  LTRIM(TO_CHAR(NVL(A.DV_5,0)))|| ')' )   BOGYONG_NAME
                                      ,SUBSTRB(FN_DRG_LOAD_CAUTION_NM(A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v, 'O' ) ,1,80)      CAUTION_NAME
                                      ,A.MIX_YN                                                                                MIX_YN
                                      ,A.ATC_YN                                                                                ATC_YN
                                      ,D.DV                                                                                    DV
                                      ,A.DV_TIME                                                                               DV_TIME
                                      ,D.DC_YN                                                                                 DC_YN
                                      ,D.BANNAB_YN                                                                             BANNAB_YN
                                      ,D.SOURCE_FKOCS2003                                                                      SOURCE_FKOCS2003
                                      ,A.FKOCS2003                                                                             FKOCS2003
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                                          SUNAB_DATE
                                      ,B.PATTERN                                                                               PATTERN
                                      ,F.HANGMOG_NAME                                                                          JAERYO_NAME
                                      ,0                                                                                       SUNAB_NALSU
                                      ,NVL(D.WONYOI_ORDER_YN,'N')                                                              WONYOI_YN
                                      ,F.HANGMOG_NAME || ' : ' ||  TRIM(D.ORDER_REMARK)                                        ORDER_REMARK
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                    ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                   UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                         SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(:f_serial_v),'00'))||DECODE(A.MIX_GROUP,NULL,'',' M')    SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                               GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                              DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                             OTHER_GWA
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                         HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                        POWDER_YN
                                      ,NVL(:f_serial_v,'1')                                                                   LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                       ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                            BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                          HO_DONG
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                          HO_CODE
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                   DONBOK
                                      ,''                                                                                      TUSUK
                                      ,DECODE(A.TOIWON_DRG_YN, '1', 'OT', A.MAGAM_GUBUN)                                       MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                            TEXT_COLOR
                                      ,C.CHANGGO1                                                                              CHANGGO
                                      ,'( ' || TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE),'MM/DD')                                 FROM_ORDER_DATE
                                      ,TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE)+ A.NALSU - 1, 'MM/DD') || ' )'||' [ 処番:'||A.DRG_BUNHO||'  '||DECODE(D.INPUT_GUBUN, 'D0', '定期', 'D4', '臨時', 'D7', '退院', '定期')||' ]'      TO_ORDER_DATE
                                      ,'A'                                                                                     DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                   HODONG_ORD_NAME
                                      --,'Y'                                                                                     MAX_BANNAB_YN
                                      ,NVL(A.BANNAB_YN,'N')                                                                    MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3010 A
                                 WHERE A.SOURCE_FKOCS2003 = :f_fkocs2003
                                   AND A.HOSP_CODE        = :f_hosp_code
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE        = A.HOSP_CODE
                                   AND C.JAERYO_CODE      = A.JAERYO_CODE
                                   AND D.HOSP_CODE        = A.HOSP_CODE
                                   AND D.PKOCS2003        = A.FKOCS2003
                                   AND F.HOSP_CODE        = D.HOSP_CODE
                                   AND F.HANGMOG_CODE     = D.HANGMOG_CODE
                                 ORDER BY A.FKOCS2003";

                        dtBannab = Service.ExecuteDataTable(cmdText, bindVars);

                        for (int t = 0; t < dtBannab.Rows.Count; t++)
                        {
                            o_bunho = dtBannab.Rows[t]["bunho"].ToString();
                            o_drg_bunho = dtBannab.Rows[t]["drg_bunho"].ToString();
                            o_group_ser = dtBannab.Rows[t]["group_ser"].ToString();
                            o_jubsu_date = dtBannab.Rows[t]["jubsu_date"].ToString();
                            o_order_date = dtBannab.Rows[t]["order_date"].ToString();
                            o_jaeryo_code = dtBannab.Rows[t]["jaeryo_code"].ToString();
                            o_nalsu = dtBannab.Rows[t]["nalsu"].ToString();
                            o_divide = dtBannab.Rows[t]["divide"].ToString();
                            o_ord_suryang = dtBannab.Rows[t]["ord_suryang"].ToString();
                            o_order_suryang = dtBannab.Rows[t]["order_suryang"].ToString();
                            o_order_danui = dtBannab.Rows[t]["order_danui"].ToString();
                            o_subul_danui = dtBannab.Rows[t]["subul_danui"].ToString();
                            o_bogyong_code = dtBannab.Rows[t]["bogyong_code"].ToString();
                            o_bogyong_name = dtBannab.Rows[t]["bogyong_name"].ToString();
                            o_caution_name = dtBannab.Rows[t]["caution_name"].ToString();
                            o_mix_yn = dtBannab.Rows[t]["mix_yn"].ToString();
                            o_atc_yn = dtBannab.Rows[t]["atc_yn"].ToString();
                            o_dv = dtBannab.Rows[t]["dv"].ToString();
                            o_dv_time = dtBannab.Rows[t]["dv_time"].ToString();
                            o_dc_yn = dtBannab.Rows[t]["dc_yn"].ToString();
                            o_bannab_yn = dtBannab.Rows[t]["bannab_yn"].ToString();
                            o_source_fkocs2003 = dtBannab.Rows[t]["source_fkocs2003"].ToString();
                            o_fkocs2003 = dtBannab.Rows[t]["fkocs2003"].ToString();
                            o_sunab_date = dtBannab.Rows[t]["sunab_date"].ToString();
                            o_pattern = dtBannab.Rows[t]["pattern"].ToString();
                            o_jaeryo_name = dtBannab.Rows[t]["jaeryo_name"].ToString();
                            o_sunab_nalsu = dtBannab.Rows[t]["sunab_nalsu"].ToString();
                            o_wonyoi_yn = dtBannab.Rows[t]["wonyoi_yn"].ToString();
                            o_order_remark = dtBannab.Rows[t]["order_remark"].ToString();
                            o_act_date = dtBannab.Rows[t]["act_date"].ToString();
                            o_ui_jusa_yn = dtBannab.Rows[t]["ui_jusa_yn"].ToString();
                            o_subul_suryang = dtBannab.Rows[t]["subul_suryang"].ToString();
                            o_serial_v = dtBannab.Rows[t]["serial_v"].ToString();
                            o_gwa_name = dtBannab.Rows[t]["gwa_name"].ToString();
                            o_doctor_name = dtBannab.Rows[t]["doctor_name"].ToString();
                            o_other_gwa = dtBannab.Rows[t]["other_gwa"].ToString();
                            o_hope_date = dtBannab.Rows[t]["hope_date"].ToString();
                            o_powder_yn = dtBannab.Rows[t]["powder_yn"].ToString();
                            o_line = dtBannab.Rows[t]["line"].ToString();
                            o_ord_danui2 = dtBannab.Rows[t]["ord_danui2"].ToString();
                            o_bunryu1 = dtBannab.Rows[t]["bunryu1"].ToString();
                            o_ho_dong = dtBannab.Rows[t]["ho_dong"].ToString();
                            o_ho_code = dtBannab.Rows[t]["ho_code"].ToString();
                            o_donbok = dtBannab.Rows[t]["donbok"].ToString();
                            o_tusuk = dtBannab.Rows[t]["tusuk"].ToString();
                            o_magam_gubun = dtBannab.Rows[t]["magam_gubun"].ToString();
                            o_text_color = dtBannab.Rows[t]["text_color"].ToString();
                            o_changgo = dtBannab.Rows[t]["changgo"].ToString();
                            o_from_order_date = dtBannab.Rows[t]["from_order_date"].ToString();
                            o_to_order_date = dtBannab.Rows[t]["to_order_date"].ToString();
                            o_data_gubun = dtBannab.Rows[t]["data_gubun"].ToString();
                            o_hodong_ord_name = dtBannab.Rows[t]["hodong_ord_name"].ToString();
                            o_max_bannab_yn = dtBannab.Rows[t]["max_bannab_yn"].ToString();

                            rowNum = layOrderPrintTemp.InsertRow(-1);

                            layOrderPrintTemp.SetItemValue(rowNum, "bunho", o_bunho);
                            layOrderPrintTemp.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                            layOrderPrintTemp.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                            layOrderPrintTemp.SetItemValue(rowNum, "group_ser", o_group_ser);
                            layOrderPrintTemp.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                            layOrderPrintTemp.SetItemValue(rowNum, "order_date", o_order_date);
                            layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                            layOrderPrintTemp.SetItemValue(rowNum, "nalsu", o_nalsu);
                            layOrderPrintTemp.SetItemValue(rowNum, "divide", o_divide);
                            layOrderPrintTemp.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                            layOrderPrintTemp.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                            layOrderPrintTemp.SetItemValue(rowNum, "order_danui", o_order_danui);
                            layOrderPrintTemp.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                            layOrderPrintTemp.SetItemValue(rowNum, "group_yn", o_group_yn);
                            layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                            layOrderPrintTemp.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                            layOrderPrintTemp.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                            layOrderPrintTemp.SetItemValue(rowNum, "caution_name", o_caution_name);
                            layOrderPrintTemp.SetItemValue(rowNum, "caution_code", o_caution_code);
                            layOrderPrintTemp.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                            layOrderPrintTemp.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                            layOrderPrintTemp.SetItemValue(rowNum, "dv", o_dv);
                            layOrderPrintTemp.SetItemValue(rowNum, "dv_time", o_dv_time);
                            layOrderPrintTemp.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                            layOrderPrintTemp.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                            layOrderPrintTemp.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs2003);
                            layOrderPrintTemp.SetItemValue(rowNum, "fkocs1003", o_fkocs2003);
                            layOrderPrintTemp.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                            layOrderPrintTemp.SetItemValue(rowNum, "pattern", o_pattern);
                            layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                            layOrderPrintTemp.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                            layOrderPrintTemp.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                            layOrderPrintTemp.SetItemValue(rowNum, "order_remark", o_order_remark);
                            layOrderPrintTemp.SetItemValue(rowNum, "act_date", o_act_date);
                            layOrderPrintTemp.SetItemValue(rowNum, "mayak", o_mayak);
                            layOrderPrintTemp.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                            layOrderPrintTemp.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                            layOrderPrintTemp.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                            layOrderPrintTemp.SetItemValue(rowNum, "serial_v", o_serial_v);
                            layOrderPrintTemp.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                            layOrderPrintTemp.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                            layOrderPrintTemp.SetItemValue(rowNum, "suname", o_suname);
                            layOrderPrintTemp.SetItemValue(rowNum, "suname2", o_suname2);
                            layOrderPrintTemp.SetItemValue(rowNum, "birth", o_birth);
                            layOrderPrintTemp.SetItemValue(rowNum, "age", o_sex_age);
                            layOrderPrintTemp.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                            layOrderPrintTemp.SetItemValue(rowNum, "do_order", o_do_order);
                            layOrderPrintTemp.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                            layOrderPrintTemp.SetItemValue(rowNum, "hope_date", o_hope_date);
                            layOrderPrintTemp.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                            layOrderPrintTemp.SetItemValue(rowNum, "line", o_line);
                            layOrderPrintTemp.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                            layOrderPrintTemp.SetItemValue(rowNum, "licenes", o_licenes);
                            layOrderPrintTemp.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                            layOrderPrintTemp.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                            layOrderPrintTemp.SetItemValue(rowNum, "ho_code", o_ho_code);
                            layOrderPrintTemp.SetItemValue(rowNum, "title", o_title);
                            layOrderPrintTemp.SetItemValue(rowNum, "donbok", o_donbok);
                            layOrderPrintTemp.SetItemValue(rowNum, "tusuk", o_tusuk);
                            layOrderPrintTemp.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                            layOrderPrintTemp.SetItemValue(rowNum, "text_color", o_text_color);
                            layOrderPrintTemp.SetItemValue(rowNum, "changgo", o_changgo);
                            layOrderPrintTemp.SetItemValue(rowNum, "from_order_date", o_from_order_date);
                            layOrderPrintTemp.SetItemValue(rowNum, "to_order_date", o_to_order_date);
                            layOrderPrintTemp.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                            layOrderPrintTemp.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                            layOrderPrintTemp.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                            layOrderPrintTemp.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);
                        }

                    }

                    /* DRGPRINT_I_ORD_PRN_REMARK */
                    cmdText = @"SELECT DISTINCT
                                       A.BUNHO                                                                                BUNHO
                                      ,A.DRG_BUNHO                                                                            DRG_BUNHO
                                      ,A.GROUP_SER                                                                            GROUP_SER
                                      ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                                                                           JUBSU_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                                                                           ORDER_DATE
                                      ,A.JAERYO_CODE                                                                          JAERYO_CODE
                                      ,A.NALSU * DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DIVIDE, 1)             NALSU
                                      ,A.DIVIDE                                                                               DIVIDE
                                      ,A.ORD_SURYANG                                                                          ORD_SURYANG
                                      ,DECODE(A.BUNRYU1, '4', A.ORD_SURYANG, A.ORDER_SURYANG )                                ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                        ORDER_DANUI
                                      ,A.SUBUL_DANUI                                                                          SUBUL_DANUI
                                      ,A.BOGYONG_CODE                                                                         BOGYONG_CODE
                                      ,TRIM(B.BOGYONG_NAME)|| DECODE(NVL(G.DV_1,0) + NVL(G.DV_2,0) + NVL(G.DV_3,0) + 
                                       NVL(G.DV_4,0) + NVL(G.DV_5,0) , 0,  NULL, '('||LTRIM(TO_CHAR(NVL(G.DV_1,0))) 
                                       || '-' ||LTRIM(TO_CHAR(NVL(G.DV_2,0))) ||  '-' ||
                                   LTRIM(TO_CHAR(NVL(G.DV_3,0))) || '-' ||LTRIM(TO_CHAR(NVL(G.DV_4,0))) ||  '-' ||
                                   LTRIM(TO_CHAR(NVL(G.DV_5,0)))|| ')' )                                                  BOGYONG_NAME
                                      ,SUBSTRB(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ) ,1,80)     CAUTION_NAME
                                      ,A.MIX_YN                                                                               MIX_YN
                                      ,A.ATC_YN                                                                               ATC_YN
                                      ,D.DV                                                                                   DV
                                      ,A.DV_TIME                                                                              DV_TIME
                                      ,D.DC_YN                                                                                DC_YN
                                      ,D.BANNAB_YN                                                                            BANNAB_YN
                                      ,D.SOURCE_FKOCS2003                                                                     SOURCE_FKOCS2003
                                      ,A.FKOCS2003                                                                            FKOCS2003
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                                         SUNAB_DATE
                                      ,B.PATTERN                                                                              PATTERN
                                      ,F.HANGMOG_NAME                                                                         JAERYO_NAME
                                      ,0                                                                                      SUNAB_NALSU
                                      ,NVL(D.WONYOI_ORDER_YN,'N')                                                             WONYOI_YN
                                      ,F.HANGMOG_NAME || ' : ' || TRIM(D.ORDER_REMARK)                                        ORDER_REMARK
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                   ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                  UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                        SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M')    SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                              GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                             DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                            OTHER_GWA
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                        HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                       POWDER_YN
                                      ,NVL(E.SERIAL_V, 1)                                                                     LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                      ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                           BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                         HO_CODE
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                         HO_DONG
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                  DONBOK
                                      ,''                                                                                     TUSUK
                                      ,DECODE(G.TOIWON_DRG_YN, '1', 'OT', G.MAGAM_GUBUN)                                      MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                           TEXT_COLOR
                                      ,C.CHANGGO1                                                                             CHANGGO
                                      ,'( ' || TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE),'MM/DD')                                 FROM_ORDER_DATE
                                      ,TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE)+ A.NALSU - 1, 'MM/DD') || ' )'                   TO_ORDER_DATE
                                      ,'B'                                                                                    DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                  HODONG_ORD_NAME
                                      ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND Y.FKOCS2003  = X.FKOCS2003
                                           AND X.FKOCS2003  = E.FKOCS2003 
                                           AND X.HOSP_CODE  = Y.HOSP_CODE
                                          )                                                     MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,DRG2035 E
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3011 A
                                      ,DRG3010 G
                                 WHERE A.JUBSU_DATE       = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.HOSP_CODE        = :f_hosp_code
                                   AND A.DRG_BUNHO        = :f_drg_bunho
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE        = A.HOSP_CODE
                                   AND C.JAERYO_CODE      = A.JAERYO_CODE
                                   AND D.HOSP_CODE        = A.HOSP_CODE
                                   AND D.PKOCS2003        = A.FKOCS2003
                                   AND TRIM(D.ORDER_REMARK) IS NOT NULL
                                   AND G.HOSP_CODE        = A.HOSP_CODE
                                   AND G.FKOCS2003        = A.FKOCS2003
                                   AND E.HOSP_CODE        = A.HOSP_CODE
                                   AND E.JUBSU_DATE       = A.JUBSU_DATE
                                   AND E.DRG_BUNHO        = A.DRG_BUNHO
                                   AND E.FKOCS2003        = A.FKOCS2003
                                   AND E.SERIAL_V         = :f_serial_text
                                   AND F.HOSP_CODE        = D.HOSP_CODE
                                   AND F.HANGMOG_CODE     = D.HANGMOG_CODE
                                 ORDER BY A.DRG_BUNHO, 'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M'), A.FKOCS2003";

                    dtRemark = Service.ExecuteDataTable(cmdText, bindVars);

                    for (int k = 0; k < dtRemark.Rows.Count; k++)
                    {
                        o_bunho = dtRemark.Rows[k]["bunho"].ToString();
                        o_drg_bunho = dtRemark.Rows[k]["drg_bunho"].ToString();
                        o_group_ser = dtRemark.Rows[k]["group_ser"].ToString();
                        o_jubsu_date = dtRemark.Rows[k]["jubsu_date"].ToString();
                        o_order_date = dtRemark.Rows[k]["order_date"].ToString();
                        o_jaeryo_code = dtRemark.Rows[k]["jaeryo_code"].ToString();
                        o_nalsu = dtRemark.Rows[k]["nalsu"].ToString();
                        o_divide = dtRemark.Rows[k]["divide"].ToString();
                        o_ord_suryang = dtRemark.Rows[k]["ord_suryang"].ToString();
                        o_order_suryang = dtRemark.Rows[k]["order_suryang"].ToString();
                        o_order_danui = dtRemark.Rows[k]["order_danui"].ToString();
                        o_subul_danui = dtRemark.Rows[k]["subul_danui"].ToString();
                        o_bogyong_code = dtRemark.Rows[k]["bogyong_code"].ToString();
                        o_bogyong_name = dtRemark.Rows[k]["bogyong_name"].ToString();
                        o_caution_name = dtRemark.Rows[k]["caution_name"].ToString();
                        o_mix_yn = dtRemark.Rows[k]["mix_yn"].ToString();
                        o_atc_yn = dtRemark.Rows[k]["atc_yn"].ToString();
                        o_dv = dtRemark.Rows[k]["dv"].ToString();
                        o_dv_time = dtRemark.Rows[k]["dv_time"].ToString();
                        o_dc_yn = dtRemark.Rows[k]["dc_yn"].ToString();
                        o_bannab_yn = dtRemark.Rows[k]["bannab_yn"].ToString();
                        o_source_fkocs2003 = dtRemark.Rows[k]["source_fkocs2003"].ToString();
                        o_fkocs2003 = dtRemark.Rows[k]["fkocs2003"].ToString();
                        o_sunab_date = dtRemark.Rows[k]["sunab_date"].ToString();
                        o_pattern = dtRemark.Rows[k]["pattern"].ToString();
                        o_jaeryo_name = dtRemark.Rows[k]["jaeryo_name"].ToString();
                        o_sunab_nalsu = dtRemark.Rows[k]["sunab_nalsu"].ToString();
                        o_wonyoi_yn = dtRemark.Rows[k]["wonyoi_yn"].ToString();
                        o_order_remark = dtRemark.Rows[k]["order_remark"].ToString();
                        o_act_date = dtRemark.Rows[k]["act_date"].ToString();
                        o_ui_jusa_yn = dtRemark.Rows[k]["ui_jusa_yn"].ToString();
                        o_subul_suryang = dtRemark.Rows[k]["subul_suryang"].ToString();
                        o_serial_v = dtRemark.Rows[k]["serial_v"].ToString();
                        o_gwa_name = dtRemark.Rows[k]["gwa_name"].ToString();
                        o_doctor_name = dtRemark.Rows[k]["doctor_name"].ToString();
                        o_other_gwa = dtRemark.Rows[k]["other_gwa"].ToString();
                        o_hope_date = dtRemark.Rows[k]["hope_date"].ToString();
                        o_powder_yn = dtRemark.Rows[k]["powder_yn"].ToString();
                        o_line = dtRemark.Rows[k]["line"].ToString();
                        o_ord_danui2 = dtRemark.Rows[k]["ord_danui2"].ToString();
                        o_bunryu1 = dtRemark.Rows[k]["bunryu1"].ToString();
                        o_ho_code = dtRemark.Rows[k]["ho_code"].ToString();
                        o_ho_dong = dtRemark.Rows[k]["ho_dong"].ToString();
                        o_donbok = dtRemark.Rows[k]["donbok"].ToString();
                        o_tusuk = dtRemark.Rows[k]["tusuk"].ToString();
                        o_magam_gubun = dtRemark.Rows[k]["magam_gubun"].ToString();
                        o_text_color = dtRemark.Rows[k]["text_color"].ToString();
                        o_changgo = dtRemark.Rows[k]["changgo"].ToString();
                        o_from_order_date = dtRemark.Rows[k]["from_order_date"].ToString();
                        o_to_order_date = dtRemark.Rows[k]["to_order_date"].ToString();
                        o_data_gubun = dtRemark.Rows[k]["data_gubun"].ToString();
                        o_hodong_ord_name = dtRemark.Rows[k]["hodong_ord_name"].ToString();
                        o_max_bannab_yn = dtRemark.Rows[k]["max_bannab_yn"].ToString();

                        rowNum = layOrderPrintTemp.InsertRow(-1);

                        layOrderPrintTemp.SetItemValue(rowNum, "bunho", o_bunho);
                        layOrderPrintTemp.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layOrderPrintTemp.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "group_ser", o_group_ser);
                        layOrderPrintTemp.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "order_date", o_order_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                        layOrderPrintTemp.SetItemValue(rowNum, "nalsu", o_nalsu);
                        layOrderPrintTemp.SetItemValue(rowNum, "divide", o_divide);
                        layOrderPrintTemp.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layOrderPrintTemp.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layOrderPrintTemp.SetItemValue(rowNum, "order_danui", o_order_danui);
                        layOrderPrintTemp.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                        layOrderPrintTemp.SetItemValue(rowNum, "group_yn", o_group_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                        layOrderPrintTemp.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "caution_name", o_caution_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "caution_code", o_caution_code);
                        layOrderPrintTemp.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "dv", o_dv);
                        layOrderPrintTemp.SetItemValue(rowNum, "dv_time", o_dv_time);
                        layOrderPrintTemp.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs2003);
                        layOrderPrintTemp.SetItemValue(rowNum, "fkocs1003", o_fkocs2003);
                        layOrderPrintTemp.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "pattern", o_pattern);
                        layOrderPrintTemp.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                        layOrderPrintTemp.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "order_remark", o_order_remark);
                        layOrderPrintTemp.SetItemValue(rowNum, "act_date", o_act_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "mayak", o_mayak);
                        layOrderPrintTemp.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                        layOrderPrintTemp.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layOrderPrintTemp.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "suname", o_suname);
                        layOrderPrintTemp.SetItemValue(rowNum, "suname2", o_suname2);
                        layOrderPrintTemp.SetItemValue(rowNum, "birth", o_birth);
                        layOrderPrintTemp.SetItemValue(rowNum, "age", o_sex_age);
                        layOrderPrintTemp.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrintTemp.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrintTemp.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "hope_date", o_hope_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrintTemp.SetItemValue(rowNum, "line", o_line);
                        layOrderPrintTemp.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrintTemp.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrintTemp.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrintTemp.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                        layOrderPrintTemp.SetItemValue(rowNum, "ho_code", o_ho_code);
                        layOrderPrintTemp.SetItemValue(rowNum, "title", o_title);
                        layOrderPrintTemp.SetItemValue(rowNum, "donbok", o_donbok);
                        layOrderPrintTemp.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrintTemp.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrintTemp.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrintTemp.SetItemValue(rowNum, "from_order_date", o_from_order_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "to_order_date", o_to_order_date);
                        layOrderPrintTemp.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                        layOrderPrintTemp.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                        layOrderPrintTemp.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);
                    }
                }

                int ttt_cnt = 0;

                foreach (DataRow dtrow in layOrderPrintTemp.LayoutTable.Rows)
                {
                    Service.debugFileWrite("mins test row = " + ++ttt_cnt);
                    for (int col_ind = 0; col_ind < layOrderPrint.LayoutTable.Columns.Count; col_ind++)
                    {
                        Service.debugFileWrite("mins test " + ttt_cnt + " [" + layOrderPrint.LayoutTable.Columns[col_ind].ColumnName + "] = [" + dtrow[col_ind].ToString() + "]");
                    }
                }

                //foreach (DataRow dtrow in layOrderPrint.LayoutTable.Rows)
                //{
                //    Service.debugFileWrite("mins test row = " + ++ttt_cnt);
                //    for (int col_ind = 0; col_ind < layOrderPrint.LayoutTable.Columns.Count; col_ind++)
                //    {
                //        Service.debugFileWrite("mins test " + ttt_cnt + " [" + layOrderPrint.LayoutTable.Columns[col_ind].ColumnName + "] = [" + dtrow[col_ind].ToString() + "]");
                //    }
                //}
            }
            catch (Exception xe)
            {
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }

            DataRow[] dr = layOrderPrintTemp.LayoutTable.Select("1=1", "drg_bunho, from_order_date, dc_yn desc");
            foreach (DataRow dt in dr)
            {
                // layOrderPrint SORT が必要だ
                layOrderPrint.LayoutTable.ImportRow(dt);
                layOrderPrint.AcceptData();
            }
            return true;
        }
        #endregion

        #region [-- DsvJusaOrderPrint --]
        /// <summary>
        /// dsvJusaOrderPrint Service Conversion PC: DRGPRINT, WT: D
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <param name="printGubun"></param>
        /// <returns></returns>
        private bool DsvJusaOrderPrint(string jubsuDate, string drgBunho, string printGubun)
        {
            layJusaOrderPrint.Reset();

            string o_print_gubun = string.Empty;
            int rowNum;

            // DRGPRINT_I_JUSA_CUR 변수
            string o_bunho = string.Empty;
            string o_drg_bunho = string.Empty;
            string o_order_date_text = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_order_date = string.Empty;
            string o_hope_date = string.Empty;
            string o_serial_v = string.Empty;
            string o_serial_text = string.Empty;
            string o_gwa_name = string.Empty;
            string o_resident_name = string.Empty;
            string o_suname = string.Empty;
            string o_suname2 = string.Empty;
            string o_birth = string.Empty;
            string o_sex_age = string.Empty;
            string o_ho_code = string.Empty;
            string o_ho_dong = string.Empty;
            string o_magam_gubun = string.Empty;
            string o_rp_barcode = string.Empty;
            string o_barcode = string.Empty;
            string o_key = string.Empty;

            //DRGPRINT_I_JUSA_SERIAL 변수
            string o_jaeryo_code = string.Empty;
            string o_nalsu = string.Empty;
            string o_divide = string.Empty;
            string o_order_suryang = string.Empty;
            string o_subul_suryang = string.Empty;
            string o_ord_suryang = string.Empty;
            string o_order_danui = string.Empty;
            string o_subul_danui = string.Empty;
            string o_bunryu1 = string.Empty;
            string o_bunryu2 = string.Empty;
            string o_bunryu3 = string.Empty;
            string o_bunryu4 = string.Empty;
            string o_remark = string.Empty;
            string o_dv_time = string.Empty;
            string o_dv = string.Empty;
            string o_bunryu6 = string.Empty;
            string o_mix_group = string.Empty;
            string o_dv_1 = string.Empty;
            string o_dv_2 = string.Empty;
            string o_dv_3 = string.Empty;
            string o_dv_4 = string.Empty;
            string o_dv_5 = string.Empty;
            string o_hubal_change_yn = string.Empty;
            string o_pharmacy = string.Empty;
            string o_jusa_spd_gubun = string.Empty;
            string o_drg_pack_yn = string.Empty;
            string o_jusa = string.Empty;
            string o_jaeryo_name = string.Empty;
            string o_order_danui_name = string.Empty;
            string o_subul_danui_name = string.Empty;
            string o_jusa_name = string.Empty;
            string o_bogyong_name = string.Empty;
            string o_jusa_nalsu = string.Empty;
            string o_data_gubun = string.Empty;
            string o_hodong_ord_name = string.Empty;
            string o_doctor_name = string.Empty;
            string o_bannab_yn = string.Empty;
            string o_max_bannab_yn = string.Empty;
            string o_fkocs2003 = string.Empty;

            string cmdText = string.Empty;
            DataTable dtJusa = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();
            DataTable dtBannab = new DataTable();

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(jubsuDate);
            inputList.Add(drgBunho);
            inputList.Add(printGubun);
            if (Service.ExecuteProcedure("PR_DRG_LOAD_PRINT_GUBUN", inputList, outputList))
            {
                o_print_gubun = outputList[0].ToString();
            }
            /*DRGPRINT_I_JUSA_CUR*/
            cmdText = @"SELECT DISTINCT
                               A.BUNHO                                             BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))                         DRG_BUNHO
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )    ORDER_DATE_TEXT
                              ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                  JUBSU_DATE
                              ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                  ORDER_DATE
                              ,TO_CHAR(NVL(A.HOPE_DATE, A.ORDER_DATE),'YYYY/MM/DD')HOPE_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M') SERIAL_V
                              ,E.SERIAL_V                                          SERIAL_TEXT
                              ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)           GWA_NAME
                              ,FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE)   DOCTOR_NAME
                              ,D.SUNAME                                            SUNAME
                              ,D.SUNAME2                                           SUNAME2
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH)          BIRTH
                              ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE)          SEX_AGE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)      HO_CODE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)      HO_DONG
                              ,A.MAGAM_GUBUN                                       MAGAM_GUBUN
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO) || TO_CHAR(E.SERIAL_V)||'*'      RP_BARCODE
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO)||'*'                             BARCODE
                              ,LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ') key
                          FROM DRG2035 E
                              ,OUT0101 D
                              ,DRG0120 C
                              ,INV0110 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE         = :f_jubsu_date
                           AND A.HOSP_CODE          = :f_hosp_code
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.BUNRYU1            IN ('4')
                           --AND NVL(A.DC_YN,'N')     = 'N'
                           --AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.HOSP_CODE          = A.HOSP_CODE
                           AND B.JAERYO_CODE        = A.JAERYO_CODE
                           AND C.HOSP_CODE          (+)= A.HOSP_CODE
                           AND C.BOGYONG_CODE       (+)= A.BOGYONG_CODE
                           AND D.HOSP_CODE          = A.HOSP_CODE
                           AND D.BUNHO              = A.BUNHO
                           AND E.HOSP_CODE          = A.HOSP_CODE
                           AND E.JUBSU_DATE         = A.JUBSU_DATE
                           AND E.DRG_BUNHO          = A.DRG_BUNHO
                           AND E.FKOCS2003          = A.FKOCS2003
                         ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            try
            {
                dtJusa = Service.ExecuteDataTable(cmdText, bindVars);
                /*DRGPRINT_I_JUSA_CUR*/
                for (int i = 0; i < dtJusa.Rows.Count; i++)
                {
                    o_bunho = dtJusa.Rows[i]["bunho"].ToString();
                    o_drg_bunho = dtJusa.Rows[i]["drg_bunho"].ToString();
                    o_order_date_text = dtJusa.Rows[i]["order_date_text"].ToString();
                    o_jubsu_date = dtJusa.Rows[i]["jubsu_date"].ToString();
                    o_order_date = dtJusa.Rows[i]["order_date"].ToString();
                    o_hope_date  = dtJusa.Rows[i]["hope_date"].ToString();
                    o_serial_v = dtJusa.Rows[i]["serial_v"].ToString();
                    o_serial_text = dtJusa.Rows[i]["serial_text"].ToString();
                    o_gwa_name = dtJusa.Rows[i]["gwa_name"].ToString();
                    o_resident_name = dtJusa.Rows[i]["doctor_name"].ToString();
                    o_suname = dtJusa.Rows[i]["suname"].ToString();
                    o_suname2 = dtJusa.Rows[i]["suname2"].ToString();
                    o_birth = dtJusa.Rows[i]["birth"].ToString();
                    o_sex_age = dtJusa.Rows[i]["sex_age"].ToString();
                    o_ho_code = dtJusa.Rows[i]["ho_code"].ToString();
                    o_ho_dong = dtJusa.Rows[i]["ho_dong"].ToString();
                    o_magam_gubun = dtJusa.Rows[i]["magam_gubun"].ToString();
                    o_rp_barcode = dtJusa.Rows[i]["rp_barcode"].ToString();
                    o_barcode = dtJusa.Rows[i]["barcode"].ToString();
                    o_key = dtJusa.Rows[i]["key"].ToString();

                    bindVars.Remove("f_serial_text");
                    bindVars.Add("f_serial_text", o_serial_text);
                    bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                    /*DRGPRINT_I_JUSA_SERIAL*/
                    cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                  ,A.NALSU                                              NALSU
                                  ,A.DIVIDE                                             DIVIDE
                                  ,A.ORDER_SURYANG                                      ORDER_SURYANG
                                  ,A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                  ,A.ORD_SURYANG                                        ORD_SURYANG
                                  ,A.ORDER_DANUI                                        ORDER_DANUI
                                  ,A.SUBUL_DANUI                                        SUBUL_DANUI
                                  ,A.BUNRYU1                                            BUNRYU1
                                  ,A.BUNRYU2                                            BUNRYU2
                                  ,A.BUNRYU3                                            BUNRYU3
                                  ,A.BUNRYU4                                            BUNRYU4
                                  ,TRIM(C.ORDER_REMARK)                                 REMARK
                                  ,A.DV_TIME                                            DV_TIME
                                  ,A.DV                                                 DV
                                  ,A.BUNRYU6                                            BUNRYU6
                                  ,A.MIX_GROUP                                          MIX_GROUP
                                  ,A.DV_1                                               DV_1
                                  ,A.DV_2                                               DV_2
                                  ,A.DV_3                                               DV_3
                                  ,A.DV_4                                               DV_4
                                  ,A.DV_5                                               DV_5
                                  ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                  ,A.PHARMACY                                           PHARMACY
                                  ,A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                  ,A.DRG_PACK_YN                                        DRG_PACK_YN
                                  ,A.JUSA                                               JUSA
                                  ,B.HANGMOG_NAME                                       JAERYO_NAME
                                  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)    DANUI_NAME
                                  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI)    SUBUL_DANUI_NAME
                                  ,FN_OCS_LOAD_CODE_NAME('JUSA',NVL(A.JUSA,'0'))        JUSA_NAME
                                  ,A.BOGYONG_CODE || ' ' || FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',NVL(A.JUSA_SPD_GUBUN,'0'))     BOGYONG_NAME
                                  ,FN_DRG_LOAD_NALSU_CNT(A.BUNHO, A.ORDER_DATE, 'I', A.JAERYO_CODE)                               JUSA_NALSU
                                  ,'A'                                                                                            DATA_GUBUN
                                  ,NVL(D.ACT_JAERYO_NAME,B.HANGMOG_NAME)                HODONG_ORD_NAME
                                  ,LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                   LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                   LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))            key
                                  ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND Y.FKOCS2003  = X.FKOCS2003
                                           AND X.HOSP_CODE  = Y.HOSP_CODE)              MAX_BANNAB_YN
                                  ,A.BANNAB_YN                                          BANNAB_YN
                                  ,A.FKOCS2003                                          FKOCS2003
                              FROM DRG2035 E
                                  ,INV0110 D
                                  ,OCS2003 C
                                  ,OCS0103 B
                                  ,DRG3010 A
                             WHERE A.JUBSU_DATE         = :f_jubsu_date
                               AND A.HOSP_CODE          = :f_hosp_code
                               AND A.DRG_BUNHO          = :f_drg_bunho
                               AND A.BUNRYU1            IN ('4')
                               --AND NVL(A.DC_YN,'N')     = 'N'
                               --AND NVL(A.BANNAB_YN,'N') = 'N'
                               AND B.HOSP_CODE          = C.HOSP_CODE
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND C.HOSP_CODE          = A.HOSP_CODE
                               AND C.PKOCS2003          = A.FKOCS2003
                               AND D.HOSP_CODE       (+)= A.HOSP_CODE
                               AND D.JAERYO_CODE     (+)= A.JAERYO_CODE
                               AND E.HOSP_CODE          = A.HOSP_CODE
                               AND E.JUBSU_DATE         = A.JUBSU_DATE
                               AND E.DRG_BUNHO          = A.DRG_BUNHO
                               AND E.FKOCS2003          = A.FKOCS2003
                               AND E.SERIAL_V           = :f_serial_text
                             ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                   LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                   LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))";

                    dtSerial = Service.ExecuteDataTable(cmdText, bindVars);

                    /*DRGPRINT_I_JUSA_SERIAL*/
                    for (int j = 0; j < dtSerial.Rows.Count; j++)
                    {
                        o_jaeryo_code = dtSerial.Rows[j]["jaeryo_code"].ToString();
                        o_nalsu = dtSerial.Rows[j]["nalsu"].ToString();
                        o_divide = dtSerial.Rows[j]["divide"].ToString();
                        o_order_suryang = dtSerial.Rows[j]["order_suryang"].ToString();
                        o_subul_suryang = dtSerial.Rows[j]["subul_suryang"].ToString();
                        o_ord_suryang = dtSerial.Rows[j]["ord_suryang"].ToString();
                        o_order_danui = dtSerial.Rows[j]["order_danui"].ToString();
                        o_subul_danui = dtSerial.Rows[j]["subul_danui"].ToString();
                        o_bunryu1 = dtSerial.Rows[j]["bunryu1"].ToString();
                        o_bunryu2 = dtSerial.Rows[j]["bunryu2"].ToString();
                        o_bunryu3 = dtSerial.Rows[j]["bunryu3"].ToString();
                        o_bunryu4 = dtSerial.Rows[j]["bunryu4"].ToString();
                        o_remark = dtSerial.Rows[j]["remark"].ToString();
                        o_dv_time = dtSerial.Rows[j]["dv_time"].ToString();
                        o_dv = dtSerial.Rows[j]["dv"].ToString();
                        o_bunryu6 = dtSerial.Rows[j]["bunryu6"].ToString();
                        o_mix_group = dtSerial.Rows[j]["mix_group"].ToString();
                        o_dv_1 = dtSerial.Rows[j]["dv_1"].ToString();
                        o_dv_2 = dtSerial.Rows[j]["dv_2"].ToString();
                        o_dv_3 = dtSerial.Rows[j]["dv_3"].ToString();
                        o_dv_4 = dtSerial.Rows[j]["dv_4"].ToString();
                        o_dv_5 = dtSerial.Rows[j]["dv_5"].ToString();
                        o_hubal_change_yn = dtSerial.Rows[j]["hubal_change_yn"].ToString();
                        o_pharmacy = dtSerial.Rows[j]["pharmacy"].ToString();
                        o_jusa_spd_gubun = dtSerial.Rows[j]["jusa_spd_gubun"].ToString();
                        o_drg_pack_yn = dtSerial.Rows[j]["drg_pack_yn"].ToString();
                        o_jusa = dtSerial.Rows[j]["jusa"].ToString();
                        o_jaeryo_name = dtSerial.Rows[j]["jaeryo_name"].ToString();
                        o_order_danui_name = dtSerial.Rows[j]["danui_name"].ToString();
                        o_subul_danui_name = dtSerial.Rows[j]["subul_danui_name"].ToString();
                        o_jusa_name = dtSerial.Rows[j]["jusa_name"].ToString();
                        o_bogyong_name = dtSerial.Rows[j]["bogyong_name"].ToString();
                        o_jusa_nalsu = dtSerial.Rows[j]["jusa_nalsu"].ToString();
                        o_data_gubun = dtSerial.Rows[j]["data_gubun"].ToString();
                        o_hodong_ord_name = dtSerial.Rows[j]["hodong_ord_name"].ToString();
                        o_key = dtSerial.Rows[j]["key"].ToString();
                        o_max_bannab_yn = dtSerial.Rows[j]["max_bannab_yn"].ToString();
                        o_bannab_yn = dtSerial.Rows[j]["bannab_yn"].ToString();
                        o_fkocs2003 = dtSerial.Rows[j]["fkocs2003"].ToString();

                        /* layJusaOrderPrint 에 쿼리결과를 셋팅 */
                        rowNum = layJusaOrderPrint.InsertRow(-1);
                        layJusaOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                        layJusaOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layJusaOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layJusaOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layJusaOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                        layJusaOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layJusaOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                        layJusaOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                        layJusaOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layJusaOrderPrint.SetItemValue(rowNum, "resident_name", o_resident_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jusa", o_jusa_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layJusaOrderPrint.SetItemValue(rowNum, "subul_surang", o_subul_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_remark", o_remark);
                        layJusaOrderPrint.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "jusa_nalsu", o_jusa_nalsu);
                        layJusaOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "barcode", o_barcode);
                        layJusaOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "sort_key", o_key);
                        layJusaOrderPrint.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);
                        layJusaOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layJusaOrderPrint.SetItemValue(rowNum, "fkocs2003", o_fkocs2003);

                        //반납건 추가 조회
                        bindVars.Remove("f_serial_v");
                        bindVars.Add("f_serial_v", o_serial_text);
                        bindVars.Add("f_fkocs2003", o_fkocs2003);
                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                        cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                  ,A.NALSU                                              NALSU
                                  ,A.DIVIDE                                             DIVIDE
                                  ,A.ORDER_SURYANG                                      ORDER_SURYANG
                                  ,A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                  ,CASE WHEN A.NALSU < 0 THEN '-'||CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN '0'||ROUND(A.ORD_SURYANG,2) ELSE ''||ROUND(A.ORD_SURYANG,2) END
                                                           ELSE ''||CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN '0'||ROUND(A.ORD_SURYANG,2) ELSE ''||ROUND(A.ORD_SURYANG,2) END
                                                           END                                                                 ORD_SURYANG
                                  ,A.ORDER_DANUI                                        ORDER_DANUI
                                  ,A.SUBUL_DANUI                                        SUBUL_DANUI
                                  ,A.BUNRYU1                                            BUNRYU1
                                  ,A.BUNRYU2                                            BUNRYU2
                                  ,A.BUNRYU3                                            BUNRYU3
                                  ,A.BUNRYU4                                            BUNRYU4
                                  ,TRIM(C.ORDER_REMARK)                                 REMARK
                                  ,A.DV_TIME                                            DV_TIME
                                  ,A.DV                                                 DV
                                  ,A.BUNRYU6                                            BUNRYU6
                                  ,A.MIX_GROUP                                          MIX_GROUP
                                  ,A.DV_1                                               DV_1
                                  ,A.DV_2                                               DV_2
                                  ,A.DV_3                                               DV_3
                                  ,A.DV_4                                               DV_4
                                  ,A.DV_5                                               DV_5
                                  ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                  ,A.PHARMACY                                           PHARMACY
                                  ,A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                  ,A.DRG_PACK_YN                                        DRG_PACK_YN
                                  ,A.JUSA                                               JUSA
                                  ,B.HANGMOG_NAME                                       JAERYO_NAME
                                  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)    DANUI_NAME
                                  ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI)    SUBUL_DANUI_NAME
                                  ,FN_OCS_LOAD_CODE_NAME('JUSA',NVL(A.JUSA,'0'))        JUSA_NAME
                                  ,A.BOGYONG_CODE || ' ' || FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',NVL(A.JUSA_SPD_GUBUN,'0'))     BOGYONG_NAME
                                  ,FN_DRG_LOAD_NALSU_CNT(A.BUNHO, A.ORDER_DATE, 'I', A.JAERYO_CODE)                               JUSA_NALSU
                                  ,'A'                                                                                            DATA_GUBUN
                                  ,NVL(D.ACT_JAERYO_NAME,B.HANGMOG_NAME)                HODONG_ORD_NAME
                                  ,LTRIM(TO_CHAR(:f_serial_v, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                   LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                   LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))            key
                                  --,'Y'                                                  MAX_BANNAB_YN
                                  ,NVL(A.BANNAB_YN,'N')                                 MAX_BANNAB_YN
                                  ,A.BANNAB_YN                                          BANNAB_YN
                                  ,A.FKOCS2003                                          FKOCS2003
                              FROM INV0110 D
                                  ,OCS2003 C
                                  ,OCS0103 B
                                  ,DRG3010 A
                             WHERE A.SOURCE_FKOCS2003   = :f_fkocs2003
                               AND A.HOSP_CODE          = :f_hosp_code
                               AND B.HOSP_CODE          = C.HOSP_CODE
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND C.HOSP_CODE          = A.HOSP_CODE
                               AND C.PKOCS2003          = A.FKOCS2003
                               AND D.HOSP_CODE       (+)= A.HOSP_CODE
                               AND D.JAERYO_CODE     (+)= A.JAERYO_CODE
                               
                             ORDER BY A.FKOCS2003";

                        //dtBannab = Service.ExecuteDataTable(cmdText, bindVars);
                        for (int t = 0; t < dtBannab.Rows.Count; t++)
                        {
                            o_jaeryo_code = dtBannab.Rows[t]["jaeryo_code"].ToString();
                            o_nalsu = dtBannab.Rows[t]["nalsu"].ToString();
                            o_divide = dtBannab.Rows[t]["divide"].ToString();
                            o_order_suryang = dtBannab.Rows[t]["order_suryang"].ToString();
                            o_subul_suryang = dtBannab.Rows[t]["subul_suryang"].ToString();
                            o_ord_suryang = dtBannab.Rows[t]["ord_suryang"].ToString();
                            o_order_danui = dtBannab.Rows[t]["order_danui"].ToString();
                            o_subul_danui = dtBannab.Rows[t]["subul_danui"].ToString();
                            o_bunryu1 = dtBannab.Rows[t]["bunryu1"].ToString();
                            o_bunryu2 = dtBannab.Rows[t]["bunryu2"].ToString();
                            o_bunryu3 = dtBannab.Rows[t]["bunryu3"].ToString();
                            o_bunryu4 = dtBannab.Rows[t]["bunryu4"].ToString();
                            o_remark = dtBannab.Rows[t]["remark"].ToString();
                            o_dv_time = dtBannab.Rows[t]["dv_time"].ToString();
                            o_dv = dtBannab.Rows[t]["dv"].ToString();
                            o_bunryu6 = dtBannab.Rows[t]["bunryu6"].ToString();
                            o_mix_group = dtBannab.Rows[t]["mix_group"].ToString();
                            o_dv_1 = dtBannab.Rows[t]["dv_1"].ToString();
                            o_dv_2 = dtBannab.Rows[t]["dv_2"].ToString();
                            o_dv_3 = dtBannab.Rows[t]["dv_3"].ToString();
                            o_dv_4 = dtBannab.Rows[t]["dv_4"].ToString();
                            o_dv_5 = dtBannab.Rows[t]["dv_5"].ToString();
                            o_hubal_change_yn = dtBannab.Rows[t]["hubal_change_yn"].ToString();
                            o_pharmacy = dtBannab.Rows[t]["pharmacy"].ToString();
                            o_jusa_spd_gubun = dtBannab.Rows[t]["jusa_spd_gubun"].ToString();
                            o_drg_pack_yn = dtBannab.Rows[t]["drg_pack_yn"].ToString();
                            o_jusa = dtBannab.Rows[t]["jusa"].ToString();
                            o_jaeryo_name = dtBannab.Rows[t]["jaeryo_name"].ToString();
                            o_order_danui_name = dtBannab.Rows[t]["danui_name"].ToString();
                            o_subul_danui_name = dtBannab.Rows[t]["subul_danui_name"].ToString();
                            o_jusa_name = dtBannab.Rows[t]["jusa_name"].ToString();
                            o_bogyong_name = dtBannab.Rows[t]["bogyong_name"].ToString();
                            o_jusa_nalsu = dtBannab.Rows[t]["jusa_nalsu"].ToString();
                            o_data_gubun = dtBannab.Rows[t]["data_gubun"].ToString();
                            o_hodong_ord_name = dtBannab.Rows[t]["hodong_ord_name"].ToString();
                            o_key = dtBannab.Rows[t]["key"].ToString();
                            o_max_bannab_yn = dtBannab.Rows[t]["max_bannab_yn"].ToString();
                            o_bannab_yn = dtBannab.Rows[t]["bannab_yn"].ToString();
                            o_fkocs2003 = dtBannab.Rows[t]["fkocs2003"].ToString();

                            rowNum = layJusaOrderPrint.InsertRow(-1);

                            layJusaOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                            layJusaOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                            layJusaOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                            layJusaOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                            layJusaOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                            layJusaOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                            layJusaOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                            layJusaOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                            layJusaOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                            layJusaOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                            layJusaOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                            layJusaOrderPrint.SetItemValue(rowNum, "resident_name", o_resident_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "jusa", o_jusa_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                            layJusaOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                            layJusaOrderPrint.SetItemValue(rowNum, "subul_surang", o_subul_suryang);
                            layJusaOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "order_remark", o_remark);
                            layJusaOrderPrint.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                            layJusaOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                            layJusaOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                            layJusaOrderPrint.SetItemValue(rowNum, "jusa_nalsu", o_jusa_nalsu);
                            layJusaOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                            layJusaOrderPrint.SetItemValue(rowNum, "barcode", o_barcode);
                            layJusaOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                            layJusaOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "sort_key", o_key);
                            layJusaOrderPrint.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);
                            layJusaOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                            layJusaOrderPrint.SetItemValue(rowNum, "fkocs2003", o_fkocs2003);
                        }
                    }

                    /*DRGPRINT_I_SER_REMARK_CUR*/
                    cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                  ,A.NALSU                                              NALSU
                                  ,A.DIVIDE                                             DIVIDE
                                  ,A.ORDER_SURYANG                                      ORDER_SURYANG
                                  ,A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                  ,A.ORD_SURYANG                                        ORD_SURYANG
                                  ,A.ORDER_DANUI                                        ORDER_DANUI
                                  ,A.SUBUL_DANUI                                        SUBUL_DANUI
                                  ,A.BUNRYU1                                            BUNRYU1
                                  ,A.BUNRYU2                                            BUNRYU2
                                  ,A.BUNRYU3                                            BUNRYU3
                                  ,A.BUNRYU4                                            BUNRYU4
                                  ,TRIM(C.ORDER_REMARK)                                 REMARK
                                  ,A.DV_TIME                                            DV_TIME
                                  ,A.DV                                                 DV
                                  ,A.BUNRYU6                                            BUNRYU6
                                  ,A.MIX_GROUP                                          MIX_GROUP
                                  ,A.DV_1                                               DV_1
                                  ,A.DV_2                                               DV_2
                                  ,A.DV_3                                               DV_3
                                  ,A.DV_4                                               DV_4
                                  ,A.DV_5                                               DV_5
                                  ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                  ,A.PHARMACY                                           PHARMACY
                                  ,A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                  ,A.DRG_PACK_YN                                        DRG_PACK_YN
                                  ,A.JUSA                                               JUSA
                                  ,B.HANGMOG_NAME                                       JAERYO_NAME
                                  ,'B'                                                  DATA_GUBUN
                                  ,NVL(D.ACT_JAERYO_NAME,B.HANGMOG_NAME)                HODONG_ORD_NAME
                                  ,LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                   LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                   LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))            key
                                  ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND Y.FKOCS2003  = X.FKOCS2003
                                           AND X.HOSP_CODE  = Y.HOSP_CODE )             MAX_BANNAB_YN
                                  ,A.BANNAB_YN                                          BANNAB_YN
                                  ,A.FKOCS2003                                          FKOCS2003
                              FROM DRG2035 E
                                  ,INV0110 D
                                  ,OCS2003 C
                                  ,OCS0103 B
                                  ,DRG3010 A
                             WHERE A.JUBSU_DATE         = :f_jubsu_date
                               AND A.HOSP_CODE          = :f_hosp_code
                               AND A.DRG_BUNHO          = :f_drg_bunho
                               AND A.BUNRYU1            IN ('4')
                               --AND NVL(A.DC_YN,'N')     = 'N'
                               --AND NVL(A.BANNAB_YN,'N') = 'N'
                               AND TRIM(C.ORDER_REMARK) IS NOT NULL   -- COMMENT 조회
                               AND B.HOSP_CODE          = C.HOSP_CODE
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND C.HOSP_CODE          = A.HOSP_CODE
                               AND C.PKOCS2003          = A.FKOCS2003
                               AND D.HOSP_CODE       (+)= A.HOSP_CODE
                               AND D.JAERYO_CODE     (+)= A.JAERYO_CODE
                               AND E.HOSP_CODE          = A.HOSP_CODE
                               AND E.JUBSU_DATE         = A.JUBSU_DATE
                               AND E.DRG_BUNHO          = A.DRG_BUNHO
                               AND E.FKOCS2003          = A.FKOCS2003
                               AND E.SERIAL_V           = :f_serial_text
                             ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                      LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                      LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))";

                    dtRemark = Service.ExecuteDataTable(cmdText, bindVars);

                    for (int k = 0; k < dtRemark.Rows.Count; k++)
                    {
                        o_jaeryo_code = dtRemark.Rows[k]["jaeryo_code"].ToString();
                        o_nalsu = dtRemark.Rows[k]["nalsu"].ToString();
                        o_divide = dtRemark.Rows[k]["divide"].ToString();
                        o_order_suryang = dtRemark.Rows[k]["order_suryang"].ToString();
                        o_subul_suryang = dtRemark.Rows[k]["subul_suryang"].ToString();
                        o_ord_suryang = dtRemark.Rows[k]["ord_suryang"].ToString();
                        o_order_danui = dtRemark.Rows[k]["order_danui"].ToString();
                        o_subul_danui = dtRemark.Rows[k]["subul_danui"].ToString();
                        o_bunryu1 = dtRemark.Rows[k]["bunryu1"].ToString();
                        o_bunryu2 = dtRemark.Rows[k]["bunryu2"].ToString();
                        o_bunryu3 = dtRemark.Rows[k]["bunryu3"].ToString();
                        o_bunryu4 = dtRemark.Rows[k]["bunryu4"].ToString();
                        o_remark = dtRemark.Rows[k]["remark"].ToString();
                        o_dv_time = dtRemark.Rows[k]["dv_time"].ToString();
                        o_dv = dtRemark.Rows[k]["dv"].ToString();
                        o_bunryu6 = dtRemark.Rows[k]["bunryu6"].ToString();
                        o_mix_group = dtRemark.Rows[k]["mix_group"].ToString();
                        o_dv_1 = dtRemark.Rows[k]["dv_1"].ToString();
                        o_dv_2 = dtRemark.Rows[k]["dv_2"].ToString();
                        o_dv_3 = dtRemark.Rows[k]["dv_3"].ToString();
                        o_dv_4 = dtRemark.Rows[k]["dv_4"].ToString();
                        o_dv_5 = dtRemark.Rows[k]["dv_5"].ToString();
                        o_hubal_change_yn = dtRemark.Rows[k]["hubal_change_yn"].ToString();
                        o_pharmacy = dtRemark.Rows[k]["pharmacy"].ToString();
                        o_jusa_spd_gubun = dtRemark.Rows[k]["jusa_spd_gubun"].ToString();
                        o_drg_pack_yn = dtRemark.Rows[k]["drg_pack_yn"].ToString();
                        o_jusa = dtRemark.Rows[k]["jusa"].ToString();
                        o_jaeryo_name = dtRemark.Rows[k]["jaeryo_name"].ToString();
                        o_data_gubun = dtRemark.Rows[k]["data_gubun"].ToString();
                        o_hodong_ord_name = dtRemark.Rows[k]["hodong_ord_name"].ToString();
                        o_key = dtRemark.Rows[k]["key"].ToString();

                        rowNum = layJusaOrderPrint.InsertRow(-1);

                        layJusaOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                        layJusaOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layJusaOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layJusaOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layJusaOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                        layJusaOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layJusaOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                        layJusaOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                        layJusaOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layJusaOrderPrint.SetItemValue(rowNum, "resident_name", o_resident_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jusa", o_jusa_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layJusaOrderPrint.SetItemValue(rowNum, "subul_surang", o_subul_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_remark", o_remark);
                        layJusaOrderPrint.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "jusa_nalsu", o_jusa_nalsu);
                        layJusaOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "barcode", o_barcode);
                        layJusaOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "sort_key", o_key);
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region [-- DsvOrderJungbo --]
        /// <summary>
        /// dsvOrderJungbo Service Conversion PC: DRGPRINT, WT: 8
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns>bool</returns>
        private bool DsvOrderJungbo(string jubsuDate, string drgBunho)
        {
            layOrderJungbo.Reset();
            string o_seq_1 = string.Empty;
            string o_seq_2 = string.Empty;

            string o_text_1 = string.Empty;
            string o_text_2 = string.Empty;
            string o_text_3 = string.Empty;
            string o_comments = string.Empty;
            string o_bunho_comments = string.Empty;
            string o_bar_drg_bunho = string.Empty;
            string o_bar_rp_bunho = string.Empty;

            string o_bunho = string.Empty;
            string o_cpl_1 = string.Empty;
            string o_cpl_2 = string.Empty;
            string o_cpl_3 = string.Empty;
            string o_danui_1 = string.Empty;
            string o_danui_2 = string.Empty;
            string o_danui_3 = string.Empty;
            string o_hl_1 = string.Empty;
            string o_hl_2 = string.Empty;
            string o_hl_3 = string.Empty;

            string t_comments = string.Empty;

            string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            DataTable resTable = new DataTable();
            object retVal = null;

            cmdText = @"SELECT '1'                SEQ_1
                              ,D.SERIAL_V         SEQ_2
                              ,C.JAERYO_NAME      TEXT_1
                              ,''                 TEXT_2
                              ,''                 TEXT_3
                              ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ')     REMARK
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'  bar_drg_bunho
                              ,A.BUNHO            BUNHO
                          FROM DRG2035 D
                              ,INV0110 C
                              ,DRG9042 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.HOSP_CODE   = :f_hosp_code
                           AND A.DRG_BUNHO   = :f_drg_bunho
                           AND B.FKOCS       = A.FKOCS2003
                           AND B.ORDER_REMARK IS NOT NULL
                           AND B.HOSP_CODE   = A.HOSP_CODE
                           AND C.JAERYO_CODE = A.JAERYO_CODE
                           AND C.HOSP_CODE   = A.HOSP_CODE
                           AND D.FKOCS2003(+)= A.FKOCS2003
                           AND D.HOSP_CODE(+)= A.HOSP_CODE
                           
                        UNION ALL
                        SELECT DISTINCT '1'       SEQ_1
                              ,''                 SEQ_2
                              ,C.JAERYO_NAME      TEXT_1
                              ,''                 TEXT_2
                              ,''                 TEXT_3
                              ,'[' || FN_ADM_MSG(4111) || ']' || REPLACE(REPLACE(C.DRG_COMMENT,CHR(13)||CHR(10),' '),CHR(10),' ')      REMARK
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'  bar_drg_bunho
                              ,A.BUNHO            BUNHO
                          FROM DRG2035 D
                              ,INV0110 C
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.HOSP_CODE   = :f_hosp_code
                           AND A.DRG_BUNHO   = :f_drg_bunho
                           AND C.JAERYO_CODE = A.JAERYO_CODE
                           AND C.HOSP_CODE   = A.HOSP_CODE
                           AND NVL(C.CHKD,'N') = 'Y'
                           AND D.FKOCS2003(+)= A.FKOCS2003
                           AND D.HOSP_CODE(+)= A.HOSP_CODE
                        UNION ALL
                        SELECT DISTINCT
                               '2'                SEQ_1
                              ,''                 SEQ_2
                              ,'##'               TEXT_1
                              ,''                 TEXT_2
                              ,''                 TEXT_3
                              ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ')    REMARK
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'  bar_drg_bunho
                              ,A.BUNHO            BUNHO
                          FROM DRG9040 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE    = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.HOSP_CODE     = :f_hosp_code
                           AND A.DRG_BUNHO     = :f_drg_bunho
                           AND B.HOSP_CODE     = A.HOSP_CODE
                           AND B.JUBSU_DATE    = A.JUBSU_DATE
                           AND B.DRG_BUNHO     = A.DRG_BUNHO
                           AND B.ORDER_REMARK IS NOT NULL
                        UNION ALL
                        SELECT DISTINCT
                               '3'                SEQ_1
                              ,''                 SEQ_2
                              ,'$$'               TEXT_1
                              ,''                 TEXT_2
                              ,''                 TEXT_3
                              ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ')     REMARK
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'  bar_drg_bunho
                              ,A.BUNHO            BUNHO
                          FROM DRG9041 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE    = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.HOSP_CODE     = :f_hosp_code
                           AND A.DRG_BUNHO     = :f_drg_bunho
                           AND B.HOSP_CODE  (+)= A.HOSP_CODE
                           AND B.BUNHO      (+)= A.BUNHO
                           AND B.ORDER_REMARK IS NOT NULL
                         ORDER BY 1, 2";

            try
            {
                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (TypeCheck.IsNull(resTable) || resTable.Rows.Count == 0)
                {
                    /* fetch된 data가 없을 경우는 바코드를 위해서 */
                    retVal = Service.ExecuteScalar(@"SELECT DISTINCT '*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'
                                                   FROM DRG3010 A
                                                  WHERE A.JUBSU_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                                    AND A.HOSP_CODE   = :f_hosp_code
                                                    AND A.DRG_BUNHO   = :f_drg_bunho", bindVars);
                    if (retVal == null)
                    {
                        XMessageBox.Show(Service.ErrFullMsg + "\n\r" + "データがありません。");
                        return false;
                    }

                    layOrderJungbo.InsertRow(-1);
                    layOrderJungbo.SetItemValue(0, "bar_drg_bunho", retVal.ToString());
                    return true;
                }

                if (Service.ErrCode != 0) return false;

                for (int i = 0; i < resTable.Rows.Count; i++)
                {
                    o_seq_1 = resTable.Rows[i]["seq_1"].ToString();
                    o_seq_2 = resTable.Rows[i]["seq_2"].ToString();
                    o_text_1 = resTable.Rows[i]["text_1"].ToString();
                    o_text_2 = resTable.Rows[i]["text_2"].ToString();
                    o_text_3 = resTable.Rows[i]["text_3"].ToString();
                    o_comments = resTable.Rows[i]["remark"].ToString();
                    o_bar_drg_bunho = resTable.Rows[i]["bar_drg_bunho"].ToString();
                    o_bunho = resTable.Rows[i]["bunho"].ToString();

                    cmdText = @"SELECT NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :o_bunho), 0) HEIGHT
                                  ,'Cm'                                             CM
                                  ,NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :o_bunho), 0) WEIGHT
                                  ,'Kg'                                             KG
                                  ,FN_CPL_HANGMOG_RESULT(:o_bunho, '00077')         CPL_RESULT
                                  ,FN_ADM_CONVERT_KATAKANA_FULL(:o_comments)        COMMENTS
                                  ,TRUNC(LENGTH(NVL(:o_comments,' ')) / 80)         CNT
                              FROM DUAL";
                    DataTable dtResult = new DataTable();
                    BindVarCollection bcResult = new BindVarCollection();
                    bcResult.Add("o_bunho", resTable.Rows[i]["bunho"].ToString());
                    bcResult.Add("o_comments", resTable.Rows[i]["remark"].ToString());
                    dtResult = Service.ExecuteDataTable(cmdText, bcResult);
                    int by_row;

                    o_cpl_2 = dtResult.Rows[0]["height"].ToString();
                    o_danui_2 = dtResult.Rows[0]["cm"].ToString();
                    o_cpl_1 = dtResult.Rows[0]["weight"].ToString();
                    o_danui_1 = dtResult.Rows[0]["kg"].ToString();
                    o_cpl_3 = dtResult.Rows[0]["cpl_result"].ToString();
                    o_comments = dtResult.Rows[0]["comments"].ToString();
                    by_row = int.Parse(dtResult.Rows[0]["cnt"].ToString());

                    cmdText = "";
                    int rowNum = 0;
                    for (int b = 0; b <= by_row; b++)
                    {
                        cmdText = @"SELECT '    ' || SUBSTR('" + o_comments + "', " + b + "* 80 + 1, 80)  T_COMMENTS FROM DUAL";
                        t_comments = Service.ExecuteScalar(cmdText).ToString();
                        if (b == 0)
                        {
                            rowNum = layOrderJungbo.InsertRow(-1);
                            layOrderJungbo.SetItemValue(rowNum, "text_1", o_text_1);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", o_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);

                            rowNum = layOrderJungbo.InsertRow(-1);
                            layOrderJungbo.SetItemValue(rowNum, "text_1", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);
                        }
                        else
                        {
                            rowNum = layOrderJungbo.InsertRow(-1);
                            layOrderJungbo.SetItemValue(rowNum, "text_1", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        private void btnOrder_Click(object sender, EventArgs e)
        {
            XButton btnOrder = sender as XButton;
            string CellName = "";
            string cutdate = "";

            if (btnOrder.Name == "btnOrder_stop")
            {
                CellName = "stop_date";
                cutdate = this.dpkStop_date.GetDataValue();
            }
            else
            {
                CellName = "stop_end_date";
                cutdate = this.dpkStopEnd_date.GetDataValue();
            }

            DataRow[] dtRow = this.grdOrder.LayoutTable.Select("select_yn =" + "'Y'");

            if (dtRow.Length > 0)
            {
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.GetItemString(i, "select_yn") == "Y")
                    {
                        this.grdOrder.SetFocusToItem(i, "stop_date");
                        grdOrder.SetItemValue(i, "stop_end_date", "");
                        grdOrder.SetItemValue(i, "stop_date", cutdate);

                        if (IsValidStopDate(cutdate, grdOrder.GetItemString(i, "stop_end_date"), grdOrder.GetItemString(i, "start_date"), grdOrder.GetItemString(i, "end_date"),
                            grdOrder.GetItemString(i, "perfect_act_date")) != false)
                        {
                            this.grdOrder.SetItemValue(i, CellName, cutdate);

                            if (CellName == "stop_date")
                            {
                                string cmd_s2 = @"SELECT DISTINCT B.ACT_RES_DATE
                                        FROM OCS2003 A
                                           , OCS2017 B
                                        WHERE A.HOSP_CODE = :f_hosp_code
                                        AND A.BUNHO = :f_bunho
                                        AND A.PKOCS2003 = :f_pkocs2003
                                        --
                                        AND B.HOSP_CODE = A.HOSP_CODE
                                        AND B.FKOCS2003 = A.PKOCS2003
                                        AND B.ACT_RES_DATE >= :f_kijun_date
                                        AND B.ACT_RES_DATE = (SELECT MIN(C.ACT_RES_DATE) -1 
                                                                FROM OCS2017 C
                                                               WHERE C.HOSP_CODE = B.HOSP_CODE
                                                                 AND C.FKOCS2003 = B.FKOCS2003
                                                                 AND C.ACT_RES_DATE > :f_kijun_date
                                                                 AND C.PASS_DATE IS NOT NULL
                                                                 )";
                                BindVarCollection bind_s2 = new BindVarCollection();
                                bind_s2.Add("f_hosp_code", EnvironInfo.HospCode);
                                bind_s2.Add("f_bunho", this.grdOrder.GetItemString(i, "bunho"));
                                bind_s2.Add("f_pkocs2003", this.grdOrder.GetItemString(i, "pkocs2003"));
                                bind_s2.Add("f_kijun_date", this.grdOrder.GetItemString(i, "stop_date"));

                                object obj = Service.ExecuteScalar(cmd_s2, bind_s2);
                                int a = 0;

                                if (obj == null)
                                    this.grdOrder.SetItemValue(i, "stop_end_date", this.grdOrder.GetItemString(i, "end_date"));
                                if (obj != null)
                                    this.grdOrder.SetItemValue(i, "stop_end_date", obj.ToString());
                                else if (this.grdOrder.GetItemString(i, "acting_date") == "")
                                    a = 0;
                                else if (DateTime.Parse(this.grdOrder.GetItemString(i, "stop_date")) >= DateTime.Parse(this.grdOrder.GetItemString(i, "acting_date")))
                                    a = 0;
                                else if (DateTime.Parse(this.grdOrder.GetItemString(i, "stop_date")) < DateTime.Parse(this.grdOrder.GetItemString(i, "acting_date")))
                                    this.grdOrder.SetItemValue(i, "stop_end_date", this.grdOrder.GetItemString(i, "stop_date"));
                            }
                        }
                        else
                        {
                            this.grdOrder.SetItemValue(i, CellName, "");
                        }
                    }
                }
            }

            
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;

            if (ctl.Tag.ToString() == "1")
                this.grdSelectAll(this.grdOrder);
            else
                this.grdDeleteAll(this.grdOrder);
        }

        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, string aGroupSer, bool select)
        private bool grdSelectAll(XGrid grid)
        {
            int rowNumber = -1;

            for (rowNumber = 0; rowNumber < grid.RowCount; rowNumber++)
            {
                if (grid.GetItemString(rowNumber, "ocs_flag") == "4")
                    continue;

                if (grid.GetItemString(rowNumber, "input_gubun") == "D7")
                    continue;

                grid[rowNumber, "select_yn"].Image = this.ImageList.Images[0];
                grid.SetItemValue(rowNumber, "select_yn", "Y");

                if (this.rbtDC.Checked)
                {
                    for (int i = 0; i < grid.RowCount; i++)
                    {
                        string stop_date = "";
                        string stop_end_date = "";
                        string ableToStopDate = getStopStartDateActYetOfOCS2017(grid.GetItemString(rowNumber, "pkocs2003"));

                        if (grid.GetItemString(rowNumber, "acting_date") != "")
                        {
                            DateTime time = DateTime.Parse(grid.GetItemString(rowNumber, "acting_date"));

                            if (grid.GetItemString(rowNumber, "order_gubun").Substring(1, 1) == "C"
                                && grid.GetItemString(rowNumber, "acting_date") != grid.GetItemString(rowNumber, "end_date"))
                            {
                                stop_date = time.AddDays(1).ToString();
                                stop_end_date = (grid.GetItemString(rowNumber, "end_date"));
                            }
                            else
                            {
                                //stop_date = time.ToString();
                                stop_date = ableToStopDate;
                                stop_end_date = this.getStopEndDateActYetOfOCS2017(grid.GetItemString(rowNumber, "pkocs2003"), DateTime.Parse(stop_date).ToString("yyyy/MM/dd"));
                            }

                            //if(grid.GetItemString(rowNumber, "order_gubun").Substring(1, 1) == "C")
                            //    stop_date = time.AddDays(1).ToString();
                            //else
                            //    stop_date = time.ToString();

                            //stop_date = (grid.GetItemString(rowNumber, "acting_date"));
                        }
                        else
                        {
                            //stop_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                            stop_date = (grid.GetItemString(rowNumber, "start_date"));
                            stop_end_date = (grid.GetItemString(rowNumber, "end_date"));
                        }//end_date

                        //stop_end_date = (grid.GetItemString(rowNumber, "end_date"));

                        grid.SetItemValue(rowNumber, "stop_date", stop_date);
                        grid.SetItemValue(rowNumber, "stop_end_date", stop_end_date);
                        //grid.SetItemValue(rowNumber, "stop_date", int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd").ToString()) > int.Parse(grid.GetItemString(rowNumber, "group_ser").Replace('/', ' ')) ? grid.GetItemString(rowNumber, "end_date") : EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                        if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                            && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                            && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                            && grid.GetItemString(rowNumber, "mix_group") != "")
                        {
                            grid[i, "select_yn"].Image = this.ImageList.Images[0];
                            grid.SetItemValue(i, "select_yn", "Y");

                            grid.SetItemValue(i, "stop_date", stop_date);
                            grid.SetItemValue(i, "stop_end_date", stop_end_date);
                            //grid.SetItemValue(i, "stop_date", int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd").ToString()) > int.Parse(grid.GetItemString(i, "group_ser").Replace('/', ' ')) ? grid.GetItemString(i, "end_date") : EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < grid.RowCount; i++)
                    {
                        if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                            && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                            && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                            && grid.GetItemString(rowNumber, "mix_group") != "")
                        {
                            grid[i, "select_yn"].Image = this.ImageList.Images[0];
                            grid.SetItemValue(i, "select_yn", "Y");
                        }
                    }
                }
                    
            }
            return true;
        }

        private bool grdDeleteAll(XGrid grid)
        {
            int rowNumber = -1;

            for (rowNumber = 0; rowNumber < grid.RowCount; rowNumber++)
            {
                grid[rowNumber, "select_yn"].Image = this.ImageList.Images[1];
                grid.SetItemValue(rowNumber, "select_yn", "N");

                if (this.rbtDC.Checked)
                {
                    grid.SetItemValue(rowNumber, "dv_return", "");
                    grid.SetItemValue(rowNumber, "bogyong_code_return", "");
                    grid.SetItemValue(rowNumber, "bogyong_code_return_name", "");

                    grid.SetItemValue(rowNumber, "dv_toiwon", "");
                    grid.SetItemValue(rowNumber, "bogyong_code_toiwon", "");
                    grid.SetItemValue(rowNumber, "bogyong_code_toiwon_name", "");

                    //grid.SetItemValue(rowNumber, "stop_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                    for (int i = 0; i < grid.RowCount; i++)
                    {
                        if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                            && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                            && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                            && grid.GetItemString(rowNumber, "mix_group") != "")
                        {
                            grid[i, "select_yn"].Image = this.ImageList.Images[1];
                            grid.SetItemValue(i, "select_yn", "N");
                            grid.SetItemValue(i, "stop_date", "");
                            grid.SetItemValue(i, "stop_end_date", "");
                        }
                    }
                    grid.SetItemValue(rowNumber, "stop_date", "");
                    grid.SetItemValue(rowNumber, "stop_end_date", "");
                }
                else
                {
                    for (int i = 0; i < grid.RowCount; i++)
                    {
                        if (grid.GetItemString(rowNumber, "mix_group") == grid.GetItemString(i, "mix_group")
                            && grid.GetItemString(rowNumber, "fkinp1001") == grid.GetItemString(i, "fkinp1001")
                            && grid.GetItemString(rowNumber, "group_ser") == grid.GetItemString(i, "group_ser")
                            && grid.GetItemString(rowNumber, "mix_group") != "")
                        {
                            grid[i, "select_yn"].Image = this.ImageList.Images[1];
                            grid.SetItemValue(i, "select_yn", "N");
                        }
                    }
                }
            }
            return true;
        }

        private void grdOrder_date_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["dc_able_gubun"].ToString() == "Y")
                e.BackColor = Color.Khaki;
            
            if (e.ColName == "input_tap_01_c" && e.DataRow["input_tap_01_c"].ToString() == "×")
                e.BackColor = Color.LightGreen;

            if (e.ColName == "input_tap_01_d" && e.DataRow["input_tap_01_d"].ToString() == "×")
                e.BackColor = Color.LightGreen;

            if (e.ColName == "input_tap_03" && e.DataRow["input_tap_03"].ToString() == "×")
                e.BackColor = Color.LightGreen;

            if (e.ColName == "input_tap_04" && e.DataRow["input_tap_04"].ToString() == "×")
                e.BackColor = Color.LightGreen;

            if (e.ColName == "input_tap_05" && e.DataRow["input_tap_05"].ToString() == "×")
                e.BackColor = Color.LightGreen;

            if (e.ColName == "input_tap_07" && e.DataRow["input_tap_07"].ToString() == "×")
                e.BackColor = Color.LightGreen;

            if (e.ColName == "input_tap_08" && e.DataRow["input_tap_08"].ToString() == "×")
                e.BackColor = Color.LightGreen;

            if (e.ColName == "input_tap_09" && e.DataRow["input_tap_09"].ToString() == "×")
                e.BackColor = Color.LightGreen;

            if (e.ColName == "input_tap_11" && e.DataRow["input_tap_11"].ToString() == "×")
                e.BackColor = Color.LightGreen;
        }

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            //if (e.DataRow["ocs_acting_date"].ToString() != "" && e.ColName == "hangmog_name")
            //    e.BackColor = Color.SkyBlue;

            //if ( e.DataRow["if_data_send_yn"].ToString() == "Y" && e.ColName == "hangmog_name")
            //    e.BackColor = Color.DarkGray;

            if (e.ColName == "hangmog_name" || e.ColName == "ocs_flag")
            {
                switch (e.DataRow["ocs_flag"].ToString())
                {
                    case "1":
                        
                        break;
                    case "2":
                        //e.BackColor = Color.Gold;   // Gold
                        //if (e.DataRow["jubsu_date"].ToString() != "")
                        e.BackColor = Color.YellowGreen;   // 녹색
                        break;
                    case "3":
                        e.BackColor = Color.SkyBlue;
                        break;
                    case "4":
                        e.BackColor = Color.DarkGray;
                        break;
                    case "5":
                        e.BackColor = Color.Gold;
                        break;
                }
            }

            if (e.ColName == "dv_return")
            {
                if (  e.DataRow["order_gubun"].ToString().Substring(1, 1) == "B"
                   || e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C")
                    e.BackColor = Color.LightGreen;
            }

            if (   e.ColName == "bogyong_code_return"
                || e.ColName == "bogyong_code_return_name")
            {
                if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C")
                    e.BackColor = Color.LightGreen;
            }

            if (   e.ColName == "dv_toiwon"
                || e.ColName == "bogyong_code_toiwon"
                || e.ColName == "bogyong_code_toiwon_name")
            {
                if ( e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C")
                    e.BackColor = Color.LightGreen;
            }

            if (e.ColName == "input_gubun_name")
            {
                switch (e.DataRow["input_gubun"].ToString())
                {
                    case "D0":
                        e.BackColor = Color.PaleGoldenrod;
                        break;

                    case "D4":
                        e.BackColor = Color.Orange;
                        break;

                    case "D7":
                        e.BackColor = Color.Red;
                        break;
                }
            }

            switch (e.ColName)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                case "12":
                case "13":
                    //if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C"
                    //    || e.DataRow["order_gubun"].ToString().Substring(1, 1) == "D"
                    //    || e.DataRow["order_gubun"].ToString().Substring(1, 1) == "B")
                    if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C")
                    {
                        if (e.DataRow["start_date"].ToString() != ""
                        && e.DataRow["end_date"].ToString() != ""
                        && TypeCheck.IsDateTime(e.DataRow["start_date"].ToString())
                        && TypeCheck.IsDateTime(e.DataRow["end_date"].ToString()))
                        {

                            if (DateTime.Parse(e.DataRow["start_date"].ToString()) <= DateTime.Parse(this.dtpKijunDate.GetDataValue()).AddDays(int.Parse(e.ColName))
                               && DateTime.Parse(e.DataRow["end_date"].ToString()) >= DateTime.Parse(this.dtpKijunDate.GetDataValue()).AddDays(int.Parse(e.ColName)))
                            {
                                //e.BackColor = Color.LightSkyBlue;
                                e.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);
                            }
                            else
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, ".");
                        }
                        else
                            this.grdOrder.SetItemValue(e.RowNumber, e.ColName, ".");
                    }
                    else
                    {
                        if (TypeCheck.NVL(e.DataRow["end_date"].ToString(), e.DataRow["start_date"].ToString()).ToString() != ""
                            && TypeCheck.IsDateTime(TypeCheck.NVL(e.DataRow["end_date"].ToString(), e.DataRow["start_date"].ToString())))
                        {
                            if (DateTime.Parse(TypeCheck.NVL(e.DataRow["end_date"].ToString(), e.DataRow["start_date"].ToString()).ToString()) == DateTime.Parse(this.dtpKijunDate.GetDataValue()).AddDays(int.Parse(e.ColName)))
                            {
                                //e.BackColor = Color.LightSkyBlue;
                                e.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);

                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, "×");
                            }
                            else
                                this.grdOrder.SetItemValue(e.RowNumber, e.ColName, ".");
                        }
                        else
                            this.grdOrder.SetItemValue(e.RowNumber, e.ColName, ".");
                    }
                    break;
            }
            
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = !pnlHelp.Visible;

            if (pnlHelp.Visible)
                pnlHelp.Size = new Size(138, 284);
        }

        private void btnHelp2_Click(object sender, EventArgs e)
        {
            pnlHelp2.Visible = !pnlHelp2.Visible;

            if (pnlHelp2.Visible)
                pnlHelp2.Size = new Size(243, 232);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            XButton btn = sender as XButton;
          
            if (XMessageBox.Show("[ "+ btn.Text + " ] でよろしいですか？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!isProcessingYN)
                {
                    isProcessingYN = true;
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                   
                    this.mAfterQuerySetFocusRow = this.grdOrder_date.CurrentRowNumber;
                    this.mAfterQuerySetFocusColName = this.grdOrder_date.CurrentColName;

                    //[中止しようとした場合、中止するデータがあるのかまた中止日が設定されているのかをチェック]
                    if (this.BannabProcessCheck(this.rbtDC.Checked, btn.Tag.ToString()) == false)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                        isProcessingYN = false;
                        return;
                    }

                    if (this.BannabProcess(this.rbtDC.Checked, btn.Tag.ToString()))
                    {
                        this.grdDrugOrder.QueryLayout(true);
                    }

                    this.grdOrder_date.QueryLayout(false);

                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    isProcessingYN = false;
                }
            }
            
        }

        private void cbxGaiyouDrgViewYN_CheckedChanged(object sender, EventArgs e)
        {
            this.grdOrder_date.QueryLayout(false);
        }

        private void btnHelp2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if(!this.btnProcess.Visible)
                    this.btnProcess.Visible = true;
                else
                    this.btnProcess.Visible = false;
            }
        }

        private void grdOrder_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "bogyong_code_return":
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("bogyong_code_return", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    break;
                case "bogyong_code_toiwon":
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("bogyong_code_return", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    break;
            }
        }

        private void grdOrder_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            string dv_original = this.grdOrder.GetItemString(e.RowNumber, "dv"); // 登録されているDV
            string dv_return = this.grdOrder.GetItemString(e.RowNumber, "dv_return"); // DV

            string dv_toiwon = this.grdOrder.GetItemString(e.RowNumber, "dv_toiwon"); // DV

            object[] obj = e.ReturnValues;
            string bogyong_code = "";
            string bogyong_name = "";
            string dv_cnt = "";

            int dv_result = int.Parse(dv_original) - int.Parse(dv_return);

            if (e.ReturnValues.Length > 0)
            {
                bogyong_code = obj[0].ToString();
                bogyong_name = obj[1].ToString();
                dv_cnt = obj[2].ToString();

                switch (e.ColName)
                {
                    case "bogyong_code_return":

                        if (dv_result.ToString() != dv_cnt)
                        {
                            XMessageBox.Show(@"返却後、残りの薬の服用方法が正しくありません。
                                              例）3回中1回返却したとしたら「2回」分の服用方法を入れてください","確認");

                            this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return", "");
                            this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return_name", "");
                            this.grdOrder.AcceptData();
                        }
                        else
                        {
                            this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_return_name", bogyong_name);
                        }
                        break;
                    case "bogyong_code_toiwon":

                        if (dv_toiwon != dv_cnt)
                        {
                            XMessageBox.Show(@"返却した回数分退院処方に変更できます。
                                              例）3回中1回返却して1回分を退院処方にしたい場合は「1回」分の服用方法を入れてください", "確認");

                            this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon", "");
                            this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon_name", "");
                            this.grdOrder.AcceptData();
                        }
                        else
                        {
                            this.grdOrder.SetItemValue(e.RowNumber, "bogyong_code_toiwon_name", bogyong_name);
                        }
                        break;
                }
            }
        }

        private void grdOrder_date_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                OCS2017 frmOCS2017 = new OCS2017();

                XEditGrid grd = this.grdOrder_date;
                int CurrRow = grd.CurrentRowNumber;

                frmOCS2017.BUNHO       = grd.GetItemString(CurrRow, "bunho");
                //frmOCS2017.PKOCS2003   = grd.GetItemString(CurrRow, "pkocs2003");
                frmOCS2017.FKINP1001   = grd.GetItemString(CurrRow, "fkinp1001");
                frmOCS2017.ORDERDATE   = grd.GetItemString(CurrRow, "order_date");
                frmOCS2017.INPUTDOCTOR = grd.GetItemString(CurrRow, "doctor");
                //frmOCS2017.ORDERINFO = grd.GetItemString(CurrRow, "hangmog_name") + " " + grd.GetItemString(CurrRow, "start_date") + " ～ " + grd.GetItemString(CurrRow, "end_date");
                frmOCS2017.SOURCEGRD = grd;
                frmOCS2017.GUBUN     = "ALL";
                frmOCS2017.StartPosition = FormStartPosition.CenterScreen;
                frmOCS2017.ShowDialog();
            }
        }

        private void dtpKijunDate_DataValidating(object sender, DataValidatingEventArgs e)
        {

        }

        private void rbtReturn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}