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

namespace IHIS.OCSI
{
    public partial class OCS6000U00 : IHIS.Framework.XScreen
    {
        public OCS6000U00()
        {
            InitializeComponent();
        }

        #region Screen 변수들

        ///////////////////////////////////////////////////////////////////////////////////
        // 라디오버튼 관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));

        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        ///////////////////////////////////////////////////////////////////////////////////
        // 화면 사용 변수들

        private bool mDoctorLogin = false;
        private string IOEGUBUN = "I";

        ///////////////////////////////////////////////////////////////////////////////////
        // 라이브러리
        ///////////////////////////////////////////////////////////////////////////////////
        private OCS.PatientInfo.clsParameter mPatientInfoParam = new IHIS.OCS.PatientInfo.clsParameter();
        private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("OCS6000U00");
        private OCS.OrderFunc mOrderFunc = new IHIS.OCS.OrderFunc("OCS6000U00");
        private OCS.HangmogInfo mHangmogInfo = new HangmogInfo("OCS6000U00");
        private OCS.CommonForms mCommonForms = new CommonForms();

        ///////////////////////////////////////////////////////////////////////////////////
        // 동적 구성 관련
        /////////////////////////////////////////////////////////////////////////////////// 
        private int mInputTabDefaultWidth = 100;
        private int mInputTabDefaultHeight = 26;
        private int mInputTabDefaultYLoc = 4;
        private int mInputTabDefaultXLoc = 7;

        ///////////////////////////////////////////////////////////////////////////////////
        // 입력구분 색관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mExistInputGubunColor = new XColor(Color.Red);
        private XColor mNormalInputGubunColor = new XColor(Color.Black);

        /////////////////////////////////////////////////////////////////////////////////////////////
        // 파라미터 사용변수
        /////////////////////////////////////////////////////////////////////////////////////////////
        private bool mAdminMode = false;
        private bool mUserMode = false;

        private string mInputGubun = "";
        private string mInputGwa = "";

        // 메세지 관련 변수들
        string mMsg = "";
        string mCap = "";

        // 팝업메뉴
        private IHIS.X.Magic.Menus.PopupMenu mMenuPFEResult = new IHIS.X.Magic.Menus.PopupMenu();

        private string mCurrentInputTab = "";


        #endregion

        #region Screen 이벤트

        private void OCS6000U00_Load(object sender, EventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            if (this.Opener is IHIS.Framework.MdiForm &&
                (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            {
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 110);
            }

            // Save Performer 셋팅
            this.grdOCS6000.SavePerformer = new XSavePeformer(this);
            this.grdOCS6002.SavePerformer = this.grdOCS6000.SavePerformer;
            this.laySaveLayout.SavePerformer = this.grdOCS6000.SavePerformer;
            this.layDeletedData.SavePerformer = this.laySaveLayout.SavePerformer;

            this.grdOCS6005.SavePerformer = this.grdOCS6000.SavePerformer;
            this.grdOCS6006.SavePerformer = this.grdOCS6000.SavePerformer;

            PostCallHelper.PostCall(new PostMethod(PostLoad));

            

        }

        private void PostLoad()
        {
            this.MakeInputGubunTab();

            this.MakeInputTab();

            this.layDeletedOCS6005 = this.grdOCS6005.CloneToLayout();
            this.layDeletedOCS6006 = this.grdOCS6006.CloneToLayout();

            // 유저변경
            this.OCS6000U00_UserChanged(this, new EventArgs());
        }

        // 유저 변경 이벤트 
        private void OCS6000U00_UserChanged(object sender, EventArgs e)
        {
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                if (UserInfo.UserGroup == "OCSA")
                {
                    this.mAdminMode = true;
                }
                else
                {
                    this.mAdminMode = false;
                }

                this.fbxMemb.SetEditValue(UserInfo.UserID);
                this.fbxMemb.AcceptData();

                this.cboGwa.SetDataValue(UserInfo.Gwa);
            }
            else
            {
                // 의사가 아닌경우는 어드민 유저만
                // OCSA 유저만
                if (UserInfo.UserGroup == "ADMIN" || UserInfo.UserGroup == "OCSA")
                {
                    this.mAdminMode = true;

                    this.fbxMemb.Protect = false;
                    this.cboGwa.Protect = false;

                    this.fbxMemb.SetEditValue("");
                    this.fbxMemb.AcceptData();
                }
                else
                {
                    // 사용권한이 없습니다.
                    MessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F002"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.btnList.PerformClick(FunctionType.Reset);

                    this.fbxMemb.Protect = true;
                    this.cboGwa.Protect = true;
                }
            }
        }

        #endregion

        #region 초기화 모듈

        #region 오더관련 데이터 초기화

        // 오더 및 상병정보 초기화
        private void InitializeOrderInfo()
        {
            // OCS6010클리어
            this.grdOCS6000.Reset();

            // 재원일수 트리뷰
            this.tvwJaewonIL.Nodes.Clear();

            // 오더정보 클리어
            try
            {
                //this.grdOCS6015.Reset();
                this.layDisplayLayout.Reset();
                this.layQueryLayout.Reset();
                this.dwOrderInfo.Reset();

            }
            catch { }
        }

        // 오더 ㄱㅐ별테이블 데이터 리셋
        private void ResetAllOrderTemp()
        {
            this.layDrgOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            this.layChuchiOrder.Reset();
            this.laySusulOrder.Reset();
            this.layEtcOrder.Reset();

            this.layDisplayLayout.Reset();
            this.laySaveLayout.Reset();

            this.dwOrderInfo.Reset();
        }

        #endregion

        #region 입력구분 탭 폰트색 초기화

        private void ClearInputGubunColor()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                tpg.TitleTextColor = this.mNormalInputGubunColor.Color;
            }
        }

        #endregion

        #endregion

        #region 업데이트 관련

        private bool MergeToSaveLayout()
        {
            // 약부터 시작해서 차례로 넣는다.

            this.laySaveLayout.Reset();

            // 내복약오더
            foreach (DataRow dr in this.layDrgOrder.LayoutTable.Rows)
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

            // 기타오더
            foreach (DataRow dr in this.layEtcOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            return true;
        }

        private bool OrderValidationCheck()
        {
            int dupRow = -1;
            string inputid = "";

            // 권한체크 
            if (this.mDoctorLogin)
            {
                inputid = UserInfo.DoctorID;
            }
            else
            {
                inputid = UserInfo.UserID;
            }

            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                //// 의뢰지 작성여부 체크 
                //if (this.laySaveLayout.GetItemString(i, "specific_comment_not_null") == "Y" &&
                //    this.laySaveLayout.GetItemString(i, "specific_comment") != "CM")
                //{
                //    if (this.mOrderBiz.IsSpeciFicCommentInputYn(this.laySaveLayout.GetItemString(i, "hangmog_code"), this.laySaveLayout.GetItemString(i, "pkocskey")))
                //    {
                //        this.mMsg = "▶ " + "[ " + this.laySaveLayout.GetItemString(i, "hangmog_code") + " ] " + this.laySaveLayout.GetItemString(i, "hangmog_name") + "\r\n"
                //                  + "\n=================================================================\n"
                //                  + XMsg.GetMsg("M003"); //반드시 의뢰지를 작성해야 하는 항목입니다. 의뢰지를 작성하십시오.
                //        MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                //        return false;
                //    }
                //}

                //// 원외처방인 경우는 비치일수 없음.
                //if (this.laySaveLayout.GetItemString(i, "wonyoi_order_yn") == "Y" &&
                //    this.laySaveLayout.GetItemString(i, "bichi_yn") == "Y")
                //{
                //    this.mMsg = "▶ " + "[ " + this.laySaveLayout.GetItemString(i, "hangmog_code") + " ] " + this.laySaveLayout.GetItemString(i, "hangmog_name") + "\r\n"
                //                  + "\n=================================================================\n"
                //                  + XMsg.GetMsg("M004"); //반드시 의뢰지를 작성해야 하는 항목입니다. 의뢰지를 작성하십시오.

                //    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    return false;
                //}

                //// 환자상태에 따른 금지
                //if (this.mOrderBiz.CheckPatientStatus(this.laySaveLayout.GetItemString(i, "bunho"), this.laySaveLayout.GetItemString(i, "hangmog_code"), this.laySaveLayout.GetItemString(i, "hangmog_name")) == true)
                //{
                //    return false;
                //}


            }

            // 중복처방체크 
            //if (this.mOrderBiz.IsProtecedDupInputOutOrder(this.laySaveLayout, this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
            //                                             , this.dtpOrderDate.GetDataValue()
            //                                             , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
            //                                             , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
            //                                             , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
            //                                             , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
            //                                             , ref dupRow) == true)
            //{
            //    return false;
            //}

            return true;
        }

        #endregion

        #region 각종 메소드 들

        #region 각종 체크 메소드
        
        private void MakeDayTree(int aCurrentRowNumber)
        {
            TreeNode node;
            string title = "";
            Hashtable nodeInfo;

            //int currentRowNumber = this.grdOCS6002.CurrentRowNumber;

            this.tvwJaewonIL.AfterSelect -= new TreeViewEventHandler(tvwJaewonIL_AfterSelect);
            this.tvwJaewonIL.Nodes.Clear();

            for (int i = 0; i < this.grdOCS6002.RowCount; i++)
            {
                title = "【 " + this.grdOCS6002.GetItemString(i, "jaewonil") + "日 】";
                node = new TreeNode(title, 16, 1);
                nodeInfo = new Hashtable();

                foreach (DataColumn cl in this.grdOCS6002.LayoutTable.Columns)
                {
                    nodeInfo.Add(cl.ColumnName, this.grdOCS6002.GetItemString(i, cl.ColumnName));
                }

                nodeInfo.Add("row_num", i.ToString());
                node.Tag = nodeInfo;

                this.tvwJaewonIL.Nodes.Add(node);
            }

            if (this.tvwJaewonIL.Nodes.Count > 0)
            {
                if (aCurrentRowNumber < 0)
                    this.tvwJaewonIL.SelectedNode = this.tvwJaewonIL.Nodes[0];
                else
                    this.tvwJaewonIL.SelectedNode = this.tvwJaewonIL.Nodes[aCurrentRowNumber];
            }
            else
            {
                this.ResetAllOrderTemp();
            }

            this.tvwJaewonIL.AfterSelect += new TreeViewEventHandler(tvwJaewonIL_AfterSelect);

            this.tvwJaewonIL_AfterSelect(this.tvwJaewonIL, new TreeViewEventArgs(this.tvwJaewonIL.SelectedNode));
        }

        #endregion

        #region 각종 쿼리들...

        private string GetMembQuery()
        {
            string querySql = "";

            if (this.mAdminMode == true)
            {
                querySql = " SELECT X.MEMB, X.MEMB_NAME "
                         + "   FROM ( "
                         + " SELECT '0' SORT_KEY, 'ADMIN' MEMB, '病院共通' MEMB_NAME "
                         + "   FROM SYS.DUAL "
                         + "  UNION ALL "
                         + " SELECT '1' SORT_KEY, A.GWA MEMB, A.GWA_NAME MEMB_NAME "
                         + "   FROM BAS0260 A "
                         + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                         + "    AND A.BUSEO_GUBUN IN ('1', '2' ) "
                         + "    AND A.START_DATE = ( SELECT MAX(Z.START_DATE) "
                         + "                           FROM BAS0260 Z "
                         + "                          WHERE Z.HOSP_CODE  = A.HOSP_CODE "
                         + "                            AND Z.BUSEO_CODE = A.BUSEO_CODE "
                         + "                            AND Z.START_DATE <= TRUNC(SYSDATE) ) "
                         + "  UNION ALL "
                         + " SELECT '2' SORT_KEY, A.USER_ID MEMB, A.USER_NM MEMB_NAME "
                         + "   FROM ADM3200 A "
                         + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                         + "    AND A.USER_GUBUN = '1' "
                         + "    AND A.USER_NM LIKE '%'||:f_find1|| '%' ) X "
                         + "  ORDER BY X.SORT_KEY, X.MEMB ";
            }
            else
            {
                querySql = " SELECT X.MEMB, X.MEMB_NAME "
                         + "   FROM ( "
                         + " SELECT '2' SORT_KEY, A.USER_ID MEMB, A.USER_NM MEMB_NAME "
                         + "   FROM ADM3200 A "
                         + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                         + "    AND A.USER_GUBUN = '1' ) X "
                         + "  ORDER BY X.SORT_KEY, X.MEMB ";
            }

            return querySql;
        }

        #endregion

        #region 유저구분에 따른 진료과 콤보 Visible 

        private void SetVisibleGwaCombo()
        {
            if (this.mUserMode == true)
            {
                this.lbGwa.Visible = true;
                this.cboGwa.Visible = true;

                this.cboGwa.SetDataValue("%");
            }
            else
            {
                this.lbGwa.Visible = false;
                this.cboGwa.Visible = false;
            }
        }

        #endregion

        #region 유저 ID 가져오는 함수

        private string GetMembID()
        {
            if (this.cboGwa.GetDataValue() == "" && UserInfo.UserGroup != "ADMIN")
            {
                return "";
            }
            else
            {
                if (this.cboGwa.GetDataValue() == "%")
                {
                    return this.fbxMemb.GetDataValue();
                }
                else
                {
                    return this.cboGwa.GetDataValue() + this.fbxMemb.GetDataValue();
                }
            }
        }

        #endregion

        #region 입력구분 탭 폰트색 셋팅

        private void SetInputGubunColor(string aInputGubun)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                if (this.mDoctorLogin)
                {
                    if (tpg.Tag.ToString() == aInputGubun)
                    {
                        tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    }
                }
                else
                {
                    if (tpg.Tag.ToString() == "D%")
                    {
                        if (tpg.Tag.ToString().Substring(0, 1) == aInputGubun.Substring(0, 1))
                            tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    }
                    else
                    {
                        if (tpg.Tag.ToString() == aInputGubun)
                            tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    }
                }
            }
        }

        private void SetInputGubunColor(DataTable aData)
        {
            this.ClearInputGubunColor();

            foreach (DataRow dr in aData.Rows)
            {
                this.SetInputGubunColor(dr["input_gubun"].ToString());
            }
        }

        #endregion

        #region 오더 디스플레이용 데이터 셋팅

        //private void SetDisplayLayout(string aInputGubun, string aInputTab)
        //{
        //    this.layDisplayLayout.Reset();

        //    MultiLayout layTemp = this.layDisplayLayout.Clone();
        //    MultiLayout sourceLay = this.layQueryLayout.Clone();

        //    #region [ 내복약 ]

        //    if (aInputTab == "01" || aInputTab == "%")    // 내복약
        //    {
        //        sourceLay.Reset();

        //        // 내복약 셋팅
        //        foreach (DataRow drugFilter in this.layDrgOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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
        //        foreach (DataRow jusaFilter in this.layJusaOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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
        //        foreach (DataRow cplFilter in this.layCplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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
        //        foreach (DataRow pfeFilter in this.layPfeOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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
        //        foreach (DataRow aplFilter in this.layAplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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

        //        // 방사선 셋팅
        //        foreach (DataRow xrtFilter in this.layXrtOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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
        //        foreach (DataRow chuchiFilter in this.layChuchiOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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
        //        foreach (DataRow susulFilter in this.laySusulOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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
        //        foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
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
        private void SetDisplayLayout(string aInputGubun, string aInputTab)
        {
            this.layDisplayLayout.Reset();

            MultiLayout layTemp = this.layDisplayLayout.Clone();
            MultiLayout sourceLay = this.layQueryLayout.Clone();

            #region [ 내복약 ]

            if (aInputTab == "01" || aInputTab == "%")    // 내복약
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layDrgOrder.RowCount; i++)
                {
                    if (this.layDrgOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.layDrgOrder.LayoutTable.Rows[i]);
                    }
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
                    if (this.layJusaOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                    }
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
                    if (this.layCplOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                    }
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
                    if (this.layPfeOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                    }
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
                    if (this.layAplOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                    }
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
                    if (this.layXrtOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                    }
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
                    if (this.layChuchiOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                    }
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
                    if (this.laySusulOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                    }
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

                for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                {
                    if (this.layEtcOrder.GetItemString(i, "input_gubun") == aInputGubun)
                    {
                        sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                    }
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
        #endregion

        #region 각각의 오더 레이아웃으로 데이터 넣기

        private void RecieveAndSetOrderInfo(string aCommand, XEditGrid aGrid)
        {
            switch (aCommand)
            {
                case "OCS0103U10": // 약오더인경우

                    #region 약오더 

                    this.layDrgOrder.Reset();

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
                        this.layDrgOrder.LayoutTable.ImportRow(dr);

                        //// 접수정보 
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
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

                        //// 접수정보 
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                    }

                    #endregion

                    break;

                case "OCS0103U13": // 검체검사 

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

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    #endregion

                    break;

                case "OCS0103U14": // 생리검사

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

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    #endregion

                    break;

                case "OCS0103U15": // 병리검사

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

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    #endregion

                    break;

                case "OCS0103U16": // 화상진단

                    #region 화상진단

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

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    #endregion

                    break;

                case "OCS0103U17": // 처치 

                    #region 처치오더

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

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    #endregion

                    break;

                case "OCS0103U18": // 수술오더

                    #region 수술오더

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

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    #endregion

                    break;

                case "OCS0103U19": // 기타오더

                    #region 기타오더

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

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    #endregion

                    break;
            }
        }

        #endregion

        #region 그리드 순서변경

        private void MoveRowFromTo(XEditGrid aGrid, int aSourceRowNumber, int aDestRowNumber)
        {
            MultiLayout tempLayout = aGrid.CloneToLayout();

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (i == aSourceRowNumber) continue;

                if (i == aDestRowNumber)
                {
                    tempLayout.LayoutTable.ImportRow(aGrid.LayoutTable.Rows[aSourceRowNumber]);

                }

                tempLayout.LayoutTable.ImportRow(aGrid.LayoutTable.Rows[i]);
            }

            aGrid.Reset();

            foreach (DataRow dr in tempLayout.LayoutTable.Rows)
            {
                aGrid.LayoutTable.ImportRow(dr);
            }

            aGrid.DisplayData();

            // 포커스는 Dest Row 로 
            aGrid.SetFocusToItem(aDestRowNumber, 0);
        }

        #endregion

        #region 그리드 Seq 재설정

        private void ReSettingGridSeq(XEditGrid aGrid)
        {
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (aGrid.GetItemString(i, "seq") == "" ||
                    aGrid.GetItemString(i, "seq") != (i + 1).ToString())
                {
                    aGrid.SetItemValue(i, "seq", i + 1);
                }
            }
        }

        #endregion

        #region 그리드 신규 로우 작성 및 로우 삭제

        private bool InsertOCS6000NewRow(int aCurrentRow)
        {
            int newRow = -1;

            newRow = this.grdOCS6000.InsertRow(aCurrentRow);

            this.grdOCS6000.SetItemValue(newRow, "hosp_code", EnvironInfo.HospCode);
            this.grdOCS6000.SetItemValue(newRow, "memb_gubun", "00");
            this.grdOCS6000.SetItemValue(newRow, "memb", this.GetMembID());

            return true;
        }
    
        private bool InsertOCS6002NewRow (int aCurrentRow)
        {
            bool isMove = false;


            if (aCurrentRow >= 0 && aCurrentRow < this.grdOCS6002.RowCount -1 )
            {
                DialogResult result = MessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return false;

                isMove = true;
            }

            if (isMove)
            {
                for (int i=aCurrentRow+1; i<this.grdOCS6002.RowCount; i++)
                {
                    string jaewonIl = grdOCS6002.GetItemString(i, "jaewonil");

                    this.grdOCS6002.SetItemValue(i, "jaewonil", int.Parse(jaewonIl) + 1);
                    this.grdOCS6002.SetItemValue(i, "cp_path_code", int.Parse(jaewonIl) + 1);
                }
            }

            int newRow = this.grdOCS6002.InsertRow(aCurrentRow);

            this.grdOCS6002.SetItemValue(newRow, "hosp_code", EnvironInfo.HospCode);
            this.grdOCS6002.SetItemValue(newRow, "memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            this.grdOCS6002.SetItemValue(newRow, "memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            this.grdOCS6002.SetItemValue(newRow, "cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            this.grdOCS6002.SetItemValue(newRow, "cp_path_code", (newRow + 1).ToString());
            this.grdOCS6002.SetItemValue(newRow, "jaewonil", (newRow + 1).ToString());

            return true;
        }

        private bool DeleteOCS6002Row(int aCurrentRow)
        {
            bool isMove = false;

            if ( aCurrentRow != this.grdOCS6002.RowCount - 1)
            {
                DialogResult result = MessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return false;

                isMove = true;
            }

            // 삭제전 체크 
            if (this.IsExistOCS6003(this.grdOCS6002.GetItemString(aCurrentRow, "memb_gubun")
                                   , this.grdOCS6002.GetItemString(aCurrentRow, "memb")
                                   , this.grdOCS6002.GetItemString(aCurrentRow, "cp_code")
                                   , this.grdOCS6002.GetItemString(aCurrentRow, "cp_path_code")
                                   , this.grdOCS6002.GetItemString(aCurrentRow, "jaewonil")))
            {
                MessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            this.grdOCS6002.DeleteRow(aCurrentRow);

            if (isMove)
            {
                for (int i = aCurrentRow; i < this.grdOCS6002.RowCount; i++)
                {
                    this.grdOCS6002.SetItemValue(i, "jaewonil", i + 1);
                    this.grdOCS6002.SetItemValue(i, "cp_path_code", i + 1);
                }
            }

            return true;
        }

        #endregion

        #region 변경된 데이터 있는지 확인

        private bool ExistModifiedOrder()
        {
            if (this.layDeletedData.RowCount > 0) return true;

            foreach (DataRow dr in this.layDrgOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layJusaOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layCplOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layPfeOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layAplOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layChuchiOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.laySusulOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layEtcOrder.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            if (this.layDeletedData.RowCount > 0)
                return true;

            // 지시사항 데이터 체크 
            foreach (DataRow dr in this.grdOCS6005.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.grdOCS6006.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            return false;
        }

        #endregion

        #region [ 삭제시 디테일 데이터가 있는지 체크 ]

        private bool IsExistOCS6003(string aMembGubun, string aMemb, string aCpCode, string aCpPathCode, string aJaewonIL)
        {
            // DB 데이터로 체크하자...
            string cmd = " SELECT 'Y' " + "\r\n"
                       + "   FROM SYS.DUAL " + "\r\n"
                       + "  WHERE EXISTS ( SELECT 'X' " + "\r\n"
                       + "                   FROM OCS6003 A " + "\r\n"
                       + "                  WHERE A.HOSP_CODE    = '" + EnvironInfo.HospCode + "' " + "\r\n"
                       + "                    AND A.MEMB_GUBUN   = '" + aMembGubun + "' " + "\r\n"
                       + "                    AND A.MEMB         = '" + aMemb + "' " + "\r\n"
                       + "                    AND A.CP_CODE      = '" + aCpCode + "' " + "\r\n"
                       + "                    AND A.CP_PATH_CODE = '" + aCpPathCode + "' " + "\r\n"
                       + "                    AND A.JAEWONIL     = " + aJaewonIL + ")";

            object existYn = Service.ExecuteScalar(cmd);

            if (existYn != null && existYn.ToString() == "Y")
            {
                return true;
            }

            cmd = " SELECT 'Y' " + "\r\n"
                       + "   FROM SYS.DUAL " + "\r\n"
                       + "  WHERE EXISTS ( SELECT 'X' " + "\r\n"
                       + "                   FROM OCS6005 A " + "\r\n"
                       + "                  WHERE A.HOSP_CODE    = '" + EnvironInfo.HospCode + "' " + "\r\n"
                       + "                    AND A.MEMB_GUBUN   = '" + aMembGubun + "' " + "\r\n"
                       + "                    AND A.MEMB         = '" + aMemb + "' " + "\r\n"
                       + "                    AND A.CP_CODE      = '" + aCpCode + "' " + "\r\n"
                       + "                    AND A.CP_PATH_CODE = '" + aCpPathCode + "' " + "\r\n"
                       + "                    AND A.JAEWONIL     = " + aJaewonIL + ")";

            existYn = Service.ExecuteScalar(cmd);

            if (existYn != null && existYn.ToString() == "Y")
            {
                return true;
            }

            return false;
        }

        private bool IsExistOCS6002(string aMembGubun, string aMemb, string aCpCode)
        {
            // DB 데이터로 체크하자...
            string cmd = " SELECT 'Y' " + "\r\n"
                       + "   FROM DUAL " + "\r\n"
                       + "  WHERE EXISTS ( SELECT 'X' " + "\r\n"
                       + "                   FROM OCS6002 A " + "\r\n"
                       + "                  WHERE A.HOSP_CODE    = '" + EnvironInfo.HospCode + "' " + "\r\n"
                       + "                    AND A.MEMB_GUBUN   = '" + aMembGubun + "' " + "\r\n"
                       + "                    AND A.MEMB         = '" + aMemb + "' " + "\r\n"
                       + "                    AND A.CP_CODE      = '" + aCpCode + "' ) ";

            object existYn = Service.ExecuteScalar(cmd);

            if (existYn != null && existYn.ToString() == "Y")
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 지시사항 InputGubun 별 Row Visible

        private void SetRowJisiDataVisible(string aInputGubun)
        {
            for (int i = 0; i < this.grdOCS6005.RowCount; i++)
            {
                if (grdOCS6005.GetItemString(i, "input_gubun") == aInputGubun)
                    this.grdOCS6005.SetRowVisible(i, true);
                else
                    this.grdOCS6005.SetRowVisible(i, false);
            }
        }

        #endregion

        #endregion

        #region 각종 데이터 로드

        private void LoadOCS6000(string aMemb)
        {
            this.grdOCS6000.SetBindVarValue("f_memb", aMemb);
            this.grdOCS6000.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.grdOCS6000.QueryLayout(true);

            if (this.grdOCS6000.RowCount <= 0)
                this.InitializeOrderInfo();
        }

        private void LoadOCS6002(string aMembGubun, string aMemb, string aCpCode, bool aIsResetCurrentRow)
        {
            int aCurrentRow = -1;
            if (aIsResetCurrentRow == false)
                aCurrentRow = this.grdOCS6002.CurrentRowNumber;
            this.grdOCS6002.SetBindVarValue("f_hosp_code" , EnvironInfo.HospCode);
            this.grdOCS6002.SetBindVarValue("f_memb_gubun", aMembGubun);
            this.grdOCS6002.SetBindVarValue("f_memb", aMemb);
            this.grdOCS6002.SetBindVarValue("f_cp_code", aCpCode);

            this.grdOCS6002.QueryLayout(true);

            MakeDayTree(aCurrentRow);

            if (this.grdOCS6002.RowCount <= 0)
                this.ResetAllOrderTemp();
        }

        private void LoadOCS6003(string aMembGubun, string aMemb, string aCpCode, string aCpPathCode, string aJaewonIl)
        {
            this.layQueryLayout.SetBindVarValue("f_hosp_code" , EnvironInfo.HospCode);
            this.layQueryLayout.SetBindVarValue("f_memb_gubun", aMembGubun);
            this.layQueryLayout.SetBindVarValue("f_memb", aMemb);
            this.layQueryLayout.SetBindVarValue("f_cp_code", aCpCode);
            this.layQueryLayout.SetBindVarValue("f_cp_path_code", aCpPathCode);
            this.layQueryLayout.SetBindVarValue("f_jaewonil", aJaewonIl);

            this.layQueryLayout.QueryLayout(true);

            // 중간 레이아웃 초기화
            this.layDrgOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            this.laySusulOrder.Reset();
            this.layChuchiOrder.Reset();
            this.layEtcOrder.Reset();

            if (this.rbnOrder.Checked)
                this.SetInputGubunColor(this.layQueryLayout.LayoutTable);

            foreach (DataRow dr in this.layQueryLayout.LayoutTable.Rows)
            {
                //this.SetInputGubunColor(dr["input_gubun"].ToString());
                switch (dr["input_tab"].ToString())
                {
                    case "01":  // 내복약오더

                        this.layDrgOrder.LayoutTable.ImportRow(dr);

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

                    case "11":  // 기타 오더

                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }

            if (this.layQueryLayout.RowCount <= 0)
                this.ResetAllOrderTemp();

            

            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
        }

        private void LoadOCS6005(string aMembGubun, string aMemb, string aCpCode, string aCpPathCode, string aJaewonIl)
        {
            this.grdOCS6005.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS6005.SetBindVarValue("f_memb_gubun", aMembGubun);
            this.grdOCS6005.SetBindVarValue("f_memb", aMemb);
            this.grdOCS6005.SetBindVarValue("f_cp_code", aCpCode);
            this.grdOCS6005.SetBindVarValue("f_cp_path_code", aCpPathCode);
            this.grdOCS6005.SetBindVarValue("f_jaewonil", aJaewonIl);

            this.grdOCS6005.QueryLayout(true);

            if (this.rbnJisi.Checked)
                this.SetInputGubunColor(this.grdOCS6005.LayoutTable);

            if (this.grdOCS6005.RowCount <= 0) this.grdOCS6006.Reset();

            this.grdOCS6006.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS6006.SetBindVarValue("f_memb_gubun", aMembGubun);
            this.grdOCS6006.SetBindVarValue("f_memb", aMemb);
            this.grdOCS6006.SetBindVarValue("f_cp_code", aCpCode);
            this.grdOCS6006.SetBindVarValue("f_cp_path_code", aCpPathCode);
            this.grdOCS6006.SetBindVarValue("f_jaewonil", aJaewonIl);

            this.grdOCS6006.QueryLayout(true);
        }

        #endregion

        #region 오더 표시 데이터 윈도우

        private void DislplayOrderDataWindow(string aInputGubun, string aInputTab)
        {
            this.SetDisplayLayout(aInputGubun, aInputTab);

            this.dwOrderInfo.Reset();

            this.dwOrderInfo.FillData(this.layDisplayLayout.LayoutTable);
        }

        #endregion

        #region 저장

        private bool UpdateOCS6000()
        {
            // OCS6000 SEQ 재설정

            this.ReSettingGridSeq(this.grdOCS6000);

            // Null 체크
            for (int i = 0; i < this.grdOCS6000.RowCount; i++)
            {
                if (this.grdOCS6000.GetItemString(i, "cp_code") == "" ||
                    this.grdOCS6000.GetItemString(i, "cp_name") == "" )
                {
                    MessageBox.Show(XMsg.GetMsg("M003"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (this.grdOCS6000.SaveLayout() != true)
            {
                MessageBox.Show(XMsg.GetMsg("M005"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool UpdateOCS6002()
        {
            if (this.grdOCS6002.SaveLayout() != true)
            {
                MessageBox.Show(XMsg.GetMsg("M005") + "-" + Service.ErrCode, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool UpdateOCS6005()
        {
            if (this.grdOCS6005.SaveLayout() != true)
            {
                MessageBox.Show(XMsg.GetMsg("M005") + "-" + Service.ErrCode, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (this.grdOCS6006.SaveLayout() != true)
                {
                    MessageBox.Show(XMsg.GetMsg("M005") + "-" + Service.ErrCode, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 탭구성 모듈

        // 입력구분 탭 동적 구성 
        private void MakeInputGubunTab()
        {
            MultiLayout mInputGubun = new MultiLayout();

            mInputGubun.LayoutItems.Add("code", DataType.String);
            mInputGubun.LayoutItems.Add("code_name", DataType.String);
            mInputGubun.InitializeLayoutTable();

            mInputGubun.QuerySQL = "SELECT CODE, CODE_NAME "
                                 + "  FROM OCS0132 "
                                 + " WHERE CODE_TYPE LIKE 'INPUT_GUBUN' "
                                 + "   AND CODE LIKE 'D%' "
                                 + "   AND HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                 + " ORDER BY SORT_KEY, CODE ";
            
            mInputGubun.QueryLayout(true);

            // 이벤트 삭제
            this.tabInputGubun.SelectionChanged -= new EventHandler(tabInputGubun_SelectionChanged);

            IHIS.X.Magic.Controls.TabPage tpgInputGubun;
            try
            {
                this.tabInputGubun.TabPages.Clear();
            }
            finally
            {
                this.tabInputGubun.Refresh();
            }

            foreach (DataRow dr in mInputGubun.LayoutTable.Rows)
            {
                tpgInputGubun = new IHIS.X.Magic.Controls.TabPage(dr["code_name"].ToString());

                tpgInputGubun.Tag = dr["code"].ToString();
                tpgInputGubun.ImageList = this.ImageList;
                tpgInputGubun.ImageIndex = 4;

                this.tabInputGubun.TabPages.Add(tpgInputGubun);
            }

            this.tabInputGubun.SelectionChanged += new EventHandler(tabInputGubun_SelectionChanged);

            this.tabInputGubun_SelectionChanged(this.tabInputGubun, new EventArgs());
        }

        // 입력탭 라디오 동적 구성
        private void MakeInputTab()
        {
            MultiLayout dtLayout = this.mOrderBiz.LoadComboDataSource("code", "INPUT_TAB");
            XRadioButton rbnButton;

            int rowCount = 0;

            // 기존 내역삭제
            foreach (Control control in this.pnlInputTab.Controls)
            {
                if (control is XRadioButton)
                {
                    this.pnlInputTab.Controls.Remove(control);
                }
            }

            int count = 0;

            if (dtLayout.RowCount > 0)
            {
                // 화면 끝 체크
                if ((this.pnlInputTab.Size.Width - this.mInputTabDefaultXLoc - (this.mInputTabDefaultWidth * count)) < this.mInputTabDefaultWidth)
                {
                    rowCount++;
                    this.pnlInputTab.Size = new Size(this.pnlInputTab.Size.Width, this.pnlInputTab.Height + this.mInputTabDefaultHeight);
                    count = 0;
                }

                rbnButton = new XRadioButton();

                rbnButton.Text = "全体";
                rbnButton.Size = new Size(this.mInputTabDefaultWidth, this.mInputTabDefaultHeight);
                rbnButton.Location = new Point((this.mInputTabDefaultXLoc + (this.mInputTabDefaultWidth * count)), this.mInputTabDefaultYLoc + (this.mInputTabDefaultHeight * rowCount));
                rbnButton.TextAlign = ContentAlignment.MiddleCenter;
                rbnButton.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);
                rbnButton.Appearance = Appearance.Button;
                rbnButton.ImageList = this.ImageList;
                rbnButton.ImageIndex = 0;
                rbnButton.ImageAlign = ContentAlignment.MiddleLeft;

                rbnButton.BackColor = this.mUnSelectedBackColor;
                rbnButton.ForeColor = this.mUnSelectedForeColor;
                rbnButton.CheckedChanged += new EventHandler(rbnOrder_CheckedChanged);

                rbnButton.Tag = "%";

                this.pnlInputTab.Controls.Add(rbnButton);

                count++;


            }

            foreach (DataRow dr in dtLayout.LayoutTable.Rows)
            {
                // code = 00 code_name = '複合' 는 제외
                if (dr["code"].ToString().Equals("00")) continue;

                // 화면 끝 체크
                if ((this.pnlInputTab.Size.Width - this.mInputTabDefaultXLoc - (this.mInputTabDefaultWidth * count)) < this.mInputTabDefaultWidth)
                {
                    rowCount++;
                    this.pnlInputTab.Size = new Size(this.pnlInputTab.Size.Width, this.pnlInputTab.Height + this.mInputTabDefaultHeight);
                    count = 0;
                }

                rbnButton = new XRadioButton();

                rbnButton.Text = dr["code_name"].ToString();
                rbnButton.Size = new Size(this.mInputTabDefaultWidth, this.mInputTabDefaultHeight);
                rbnButton.Location = new Point((this.mInputTabDefaultXLoc + (this.mInputTabDefaultWidth * count)), this.mInputTabDefaultYLoc + ( this.mInputTabDefaultHeight * rowCount));
                rbnButton.TextAlign = ContentAlignment.MiddleCenter;
                rbnButton.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);
                rbnButton.Appearance = Appearance.Button;
                rbnButton.ImageList = this.ImageList;
                rbnButton.ImageIndex = 0;
                rbnButton.ImageAlign = ContentAlignment.MiddleLeft;

                rbnButton.BackColor = this.mUnSelectedBackColor;
                rbnButton.ForeColor = this.mUnSelectedForeColor;
                rbnButton.CheckedChanged += new EventHandler(rbnOrder_CheckedChanged);

                rbnButton.Tag = dr["code"].ToString();

                this.pnlInputTab.Controls.Add(rbnButton);

                count++;

            }

            // 전체를 체크해 놓는다.
            foreach (Control control in this.pnlInputTab.Controls)
            {
                if (control is XRadioButton && control.Tag.ToString() == "%")
                {
                    ((XRadioButton)control).Checked = true;
                }
            }


        }

        #endregion

        #region [ 다른 화면 오픈 ]

        /// <summary>
        /// 내복약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U10()
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("order_date", aOrderDate);
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layDrgOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 주사약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U12()
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("order_date", aOrderDate);
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 검체검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U13()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layCplOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 생리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U14()
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("order_date", aOrderDate);
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 병리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U15()
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("order_date", aOrderDate);
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layAplOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 화상진단 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U16()
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("order_date", aOrderDate);
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 처치오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U17()
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("order_date", aOrderDate);
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID); 
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 수술오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U18()
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("order_date", aOrderDate);
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 기타오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U19()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layEtcOrder.LayoutTable);
            param.Add("cp_code", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code"));
            param.Add("memb_gubun", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun"));
            param.Add("memb", this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb"));
            param.Add("jaewonil", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));
            param.Add("cp_path_code", this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code"));
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpSetOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 의사 지시사항 조회
        /// </summary>
        private void OpenScreen_OCS2005U00( string aMembGubun, string aMemb      , string aCpCode    , string aCpPathCode
                                          , string aJaewonIl , string aInputGubun, string aDirectMode )
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("memb_gubun", aMembGubun);
            param.Add("memb", aMemb);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("jaewonil", aJaewonIl);
            param.Add("input_gubun", aInputGubun);
            param.Add("direct_mode", aDirectMode);

            MultiLayout layOCS6005 = this.grdOCS6005.CloneToLayout();
            foreach (DataRow row6005 in this.grdOCS6005.LayoutTable.Rows)
            {
                layOCS6005.LayoutTable.ImportRow(row6005);
            }

            MultiLayout layOCS6006 = this.grdOCS6006.CloneToLayout();
            foreach (DataRow row6006 in this.grdOCS6006.LayoutTable.Rows)
            {
                layOCS6006.LayoutTable.ImportRow(row6006);
            }

            param.Add("DIRECT", layOCS6005);
            param.Add("DIRECT_DETAIL", layOCS6006);

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005U00", ScreenOpenStyle.ResponseFixed, param);
        }

        #endregion

        #region Control Event

        #region [ 탭 페이지 ]

        private void tabInputGubun_SelectionChanged(object sender, EventArgs e)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                if (tpg == this.tabInputGubun.SelectedTab)
                {
                    tpg.ImageIndex = 1;

                    if (this.rbnOrder.Checked)
                        this.DislplayOrderDataWindow(tpg.Tag.ToString(), this.mCurrentInputTab);
                    else
                        this.SetRowJisiDataVisible(tpg.Tag.ToString());
                }
                else
                {
                    tpg.ImageIndex = 0;
                }
            }
        }

        #endregion

        #region Check Box 이벤트

        private void cbxQryAllDate_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox control = sender as CheckBox;

            if (control.Checked == true)
            {
                control.BackColor = this.mSelectedBackColor.Color;
                control.ForeColor = this.mSelectedForeColor.Color;
                control.ImageIndex = 1;
            }
            else
            {
                control.BackColor = this.mUnSelectedBackColor.Color;
                control.ForeColor = this.mUnSelectedForeColor.Color;
                control.ImageIndex = 0;
            }
        }

        #endregion

        #region XRadioButton 이벤트

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;

            if (control.Checked)
            {
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;
                //control.ImageIndex = 1;

                if (control.Name == "rbnOrder")
                {
                    this.pnlOrder.Visible = true;
                    this.pnlJisi.Visible = false;

                    this.SetInputGubunColor(this.layQueryLayout.LayoutTable);

                    
                }
                else
                {
                    this.pnlOrder.Visible = false;
                    this.pnlJisi.Visible = true;

                    this.SetInputGubunColor(this.grdOCS6005.LayoutTable);
                }

                this.tabInputGubun_SelectionChanged(this.tabInputGubun, new EventArgs());

                //this.btnList.PerformClick(FunctionType.Query);

            }
            else
            {
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
                //control.ImageIndex = 01;
            }
        }

        #region [ 오더구분 라디오 버튼 ]

        private void rbnOrder_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;

            if (control.Checked)
            {
                control.ImageIndex = 1;
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;

                this.mCurrentInputTab = control.Tag.ToString();
                
                this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
            }
            else
            {
                control.ImageIndex = 0;
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
            }
        }

        #endregion

        #endregion

        #region [ 버튼 이벤트 ]

        #region 오더 입력 버튼 

        private void btnDrgOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U10();
        }

        private void btnJusaOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U12();
        }

        private void btnCplOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U13();
        }

        private void btnPfeOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U14();
        }

        private void btnAplOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U15();
        }

        private void btnXrtOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U16();
        }

        private void btnChuchiOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U17();
        }

        private void btnSusulOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U18();
        }

        private void btnEtcOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS0103U19();
        }

        #endregion

        private void btnDoctorJisi_Click(object sender, EventArgs e)
        {
            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS2005U00(this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun")
                                      , this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb")
                                      , this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code")
                                      , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code")
                                      , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil")
                                      , this.tabInputGubun.SelectedTab.Tag.ToString()
                                      , "0");
        }

        #region Cp 순서 변경 버튼

        private void btnCpCodeUp_Click(object sender, EventArgs e)
        {
            if (this.grdOCS6000.CurrentRowNumber <= 0) return;

            this.MoveRowFromTo(this.grdOCS6000, this.grdOCS6000.CurrentRowNumber, this.grdOCS6000.CurrentRowNumber - 1);
        }

        private void btnCpCodeDn_Click(object sender, EventArgs e)
        {
            if (this.grdOCS6000.CurrentRowNumber < 0 || this.grdOCS6000.CurrentRowNumber == this.grdOCS6000.RowCount - 1) return;

            this.MoveRowFromTo(this.grdOCS6000, this.grdOCS6000.CurrentRowNumber, this.grdOCS6000.CurrentRowNumber + 1);
        }

        #endregion

        #endregion

        #region [ 버튼 리스트 이벤트 ]

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            string msg = "";
            string cap = "";

            switch (e.Func)
            {
                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    if (this.fbxMemb.GetDataValue() == "")
                        return;

                    if (this.mUserMode == true && this.cboGwa.GetDataValue() == "")
                        return;

                    this.AcceptData();

                    this.InsertOCS6000NewRow(this.grdOCS6000.CurrentRowNumber);

                    break;

                case FunctionType.Delete :
                    
                    e.IsBaseCall = false;

                    if (this.fbxMemb.GetDataValue() == "")
                        return;

                    if (this.mUserMode == true && this.cboGwa.GetDataValue() == "")
                        return;

                    this.AcceptData();

                    // 삭제전 체크 
                    if (this.IsExistOCS6002(this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun")
                                           , this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb")
                                           , this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code")) == true)
                    {
                        MessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 현재 로우 삭제
                    this.grdOCS6000.DeleteRow(grdOCS6000.CurrentRowNumber);

                    break;

                case FunctionType.Query:    // 조회

                    e.IsBaseCall = false;

                    if (this.AcceptData() == false) return;


                    this.LoadOCS6000(this.GetMembID());
                    
                        

                    // 조회 시작 
                    //this.LoadOCS6010(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
                    

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    this.AcceptData();

                    this.mOrderFunc.DeleteEmptyNewRow(this.grdOCS6000);

                    // OCS6000 Seq 재설정
                    this.ReSettingGridSeq(this.grdOCS6000);

                    if (this.MergeToSaveLayout() == false) return;

                    //if (this.OrderValidationCheck() == false) return;

                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        Service.BeginTransaction();

                        // OCS6000 저장 
                        if (this.UpdateOCS6000() == false)
                        {
                            Service.RollbackTransaction();
                            MessageBox.Show(XMsg.GetMsg("M005") + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (this.UpdateOCS6002() == false)
                        {
                            Service.RollbackTransaction();
                            MessageBox.Show(XMsg.GetMsg("M005") + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (SaveOCS6005() == false)  // 20110209 KHJ
                        {
                            Service.RollbackTransaction();
                            MessageBox.Show(XMsg.GetMsg("M005") + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 삭제 먼저 실시
                        if (this.layDeletedData.RowCount > 0)
                        {
                            //if (this.layDeletedData.SaveLayout() == false)
                            if (!LayDeleteDateSave())   // 일괄삭제
                            {
                                Service.RollbackTransaction();
                                MessageBox.Show(XMsg.GetMsg("M005") + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        if (this.laySaveLayout.SaveLayout() == false)
                        {
                            Service.RollbackTransaction();
                            MessageBox.Show(XMsg.GetMsg("M005") + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Service.CommitTransaction();

                        #region 그리드의 리셋업데이트
                        // 그리드 저장 성공 후 리셋업데이트를 해주어서 포커스 변화 시 반복적으로 보존할 것인가를 물어보는 경고창 해제.
                        layDeletedData.Reset();
                        layDeletedData.ResetUpdate();

                        layAplOrder.ResetUpdate();
                        layChuchiOrder.ResetUpdate();
                        layCplOrder.ResetUpdate();
                        layDrgOrder.ResetUpdate();
                        layEtcOrder.ResetUpdate();
                        layJusaOrder.ResetUpdate();
                        layPfeOrder.ResetUpdate();
                        laySusulOrder.ResetUpdate();
                        layXrtOrder.ResetUpdate();
                        grdOCS6005.ResetUpdate();
                        grdOCS6006.ResetUpdate();
                        #endregion

                        // 저장 완료후 재조회 
                        // 조회는 트리뷰의 After Select 이벤트를 태우는것으로 대체
                        //this.LoadOCS6000(GetMembID());
                        this.grdOCS6002_RowFocusChanged(this.grdOCS6002, new RowFocusChangedEventArgs(-1, this.grdOCS6002.CurrentRowNumber));
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }

                    break;
            }
        }

        private bool LayDeleteDateSave()
        {
            string cmdDelete = "DELETE FROM OCS6003 WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' AND PKOCS6003 = :f_pkocskey ";
            BindVarCollection bindDelete = new BindVarCollection();

            try
            {
                for (int i = 0; i < layDeletedData.RowCount; i++)
                {
                    bindDelete.Clear();
                    bindDelete.Add("f_pkocskey", layDeletedData.GetItemString(i, "pkocskey"));

                    Service.ExecuteNonQuery(cmdDelete, bindDelete);
                }
            }
            catch (Exception xe)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region [ 트리뷰 이벤트 ]

        private void tvwJaewonIL_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            Hashtable nodeInfo = e.Node.Tag as Hashtable;

            // 그리드의 로우에 포커스 위치
            int rowNumber = int.Parse(nodeInfo["row_num"].ToString());

            this.grdOCS6002.SetFocusToItem(rowNumber, 0);

            //this.LoadOCS6003(dr["memb_gubun"].ToString(), dr["memb"].ToString(), dr["cp_code"].ToString(), dr["cp_path_code"].ToString(), dr["jaewonil"].ToString());
        }

        #endregion

        #region [ 콤보 박스 ]

        private void cboGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.mUserMode == true)
            {
                this.LoadOCS6000(this.GetMembID());
            }
        }

        #endregion

        #region 그리드 이벤트

        #region CP Master 그리드

        private void grdOCS6000_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XGrid grid = sender as XGrid;
            if (e.CurrentRow < 0) return;

            this.LoadOCS6002(grid.GetItemString(e.CurrentRow, "memb_gubun"), grid.GetItemString(e.CurrentRow, "memb"), grid.GetItemString(e.CurrentRow, "cp_code"), true);
        }

        #endregion

        #endregion

        #region [ 파인드 박스 ]

        private void fbxMemb_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkUserFind.InputSQL = this.GetMembQuery();
        }

        private void fbxMemb_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                this.dbxMembName.SetDataValue("");
                this.mUserMode = false;
                this.SetVisibleGwaCombo();
                return;
            }

            if (e.DataValue == "ADMIN")
            {
                this.dbxMembName.SetDataValue("病院共通");
                this.mUserMode = false;
                this.SetVisibleGwaCombo();
                PostCallHelper.PostCall(new PostMethod(PostMembValidation));
                return;
            }

            string name = "";
            string userGubun = "";

            // 먼저 진료과로 검색..
            this.mOrderBiz.LoadColumnCodeName("gwa", e.DataValue, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref name);

            if (name != "")
            {
                this.dbxMembName.SetDataValue(name);
                this.mUserMode = false;
                this.SetVisibleGwaCombo();
                PostCallHelper.PostCall(new PostMethod(PostMembValidation));
                return;
            }
            
            // 다음은 유저명 검색
            string querySql = " SELECT A.USER_NM, A.USER_GUBUN "
                            + "   FROM ADM3200 A "
                            + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                            + "    AND A.USER_ID = '" + e.DataValue + "' ";

            DataTable temp = Service.ExecuteDataTable(querySql);

            if (temp == null || temp.Rows.Count <= 0)
            {
                MessageBox.Show(XMsg.GetMsg("M002"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            foreach (DataRow dr in temp.Rows)
            {
                name = dr["user_nm"].ToString();
                userGubun = dr["user_gubun"].ToString();
            }

            if (userGubun != "1")
            {
                MessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F002"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            this.dbxMembName.SetDataValue(name);
            this.mUserMode = true;
            this.SetVisibleGwaCombo();
            PostCallHelper.PostCall(new PostMethod(PostMembValidation));

        }

        private void PostMembValidation()
        {
            this.LoadOCS6000(this.GetMembID());
        }

        #endregion

        #endregion

        #region [ 내시경 결과 조회 ]

        // 처방행삭제
        private void PopUpMenuPfeResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand menu = sender as IHIS.X.Magic.Menus.MenuCommand;

            string targetUrl = "";
            string serverIP = "192.168.150.114";

            string cmdText = @"SELECT CODE_NAME
                                 FROM OCS0132
                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                                  AND CODE_TYPE = 'SERVER_IP'
                                  AND CODE = 'ENDO'";

            object retVal = Service.ExecuteScalar(cmdText);

            if (!TypeCheck.IsNull(retVal))
            {
                serverIP = retVal.ToString();
            }

            switch (menu.Tag.ToString())
            {
                case "1":     // 이미지 결과 조회

                    try
                    {
                        targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=0000229429&TYPE=1&KEY=12345";

                        System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        MessageBox.Show("other msg : " + other.Message);
                    }

                    break;

                case "2":

                    try
                    {
                        targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=0000229429&TYPE=2&KEY=12345";

                        System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        MessageBox.Show("other msg : " + other.Message);
                    }


                    break;   // 레포트 결과 조회
            }
        }

        private void btnENDOResult_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            //if (this.IsPatientSelected())
            //{
            //    this.mMenuPFEResult.TrackPopup(this.PointToScreen(new Point(button.Location.X, button.Location.Y)));
            //}
        }

        #endregion

        #region [ Command ]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "OCS0103U10": // 약오더 화면

                    #region 약오더 

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("drug_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["drug_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U12": // 주사오더 화면

                    #region 주사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("jusa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["jusa_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
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
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U14": // 생리검사

                    #region 생리검사

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("pfe_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["pfe_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U15": // 병리검사

                    #region 병리검사

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("apl_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["apl_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U16": // 화상진단

                    #region 화상진단

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("xrt_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["xrt_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
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
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
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
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U19": // 기타오더

                    #region 기타 오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("etc_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["etc_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS2005U00": // 지시사항

                    #region 지시사항

                    if (commandParam != null)
                    {
                        // 삭제 구분
                        if (commandParam.Contains("DELETEDIRECT"))
                        {
                            //this.layDeletedOCS6005.Reset();
                            foreach (DataRow dr in ((MultiLayout)commandParam["DELETEDIRECT"]).LayoutTable.Rows)
                            {
                                this.layDeletedOCS6005.LayoutTable.ImportRow(dr);
                            }
                        }

                        // 입력 구분
                        if (commandParam.Contains("DIRECT"))
                        {
                            this.grdOCS6005.Reset();
                            foreach (DataRow dr in ((MultiLayout)commandParam["DIRECT"]).LayoutTable.Rows)
                            {
                                this.grdOCS6005.LayoutTable.ImportRow(dr);
                            }
                            this.grdOCS6005.DisplayData();
                        }

                        // 삭제 디테일
                        if (commandParam.Contains("DELETEDIRECTDETAIL"))
                        {
                            //this.layDeletedOCS6006.Reset();
                            foreach (DataRow dr in ((MultiLayout)commandParam["DELETEDIRECTDETAIL"]).LayoutTable.Rows)
                            {
                                this.layDeletedOCS6006.LayoutTable.ImportRow(dr);
                            }
                        }

                        // 입력 디테일
                        if (commandParam.Contains("DIRECTDETAIL"))
                        {
                            this.grdOCS6006.Reset();
                            foreach (DataRow dr in ((MultiLayout)commandParam["DIRECTDETAIL"]).LayoutTable.Rows)
                            {
                                this.grdOCS6006.LayoutTable.ImportRow(dr);
                            }
                            this.grdOCS6006.DisplayData();
                        }

                    }

                    #endregion

                    break;
            }

            return base.Command(command, commandParam);
        }

        #endregion

        private void btnAddJaewonIl_Click(object sender, EventArgs e)
        {
            if (this.grdOCS6000.CurrentRowNumber < 0 ||
                this.grdOCS6000.RowCount <= 0)
                return;

            this.InsertOCS6002NewRow(-1);

            if (this.UpdateOCS6000() == true)
            {
                if (this.UpdateOCS6002() == true)
                {
                    this.LoadOCS6002(this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun")
                                    , this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb")
                                    , this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code")
                                    , false);
                         
                }
            }
        }

        private void btnDelJaewonIl_Click(object sender, EventArgs e)
        {
            if (this.grdOCS6002.CurrentRowNumber < 0) return;

            if (this.DeleteOCS6002Row(this.grdOCS6002.CurrentRowNumber) == false)
                return;

            if (this.UpdateOCS6000() == true)
            {
                if (this.UpdateOCS6002() == true)
                {
                    this.LoadOCS6002(this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb_gubun")
                                    , this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "memb")
                                    , this.grdOCS6000.GetItemString(grdOCS6000.CurrentRowNumber, "cp_code")
                                    , false);
                }
            }
        }

        private void grdOCS6002_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.LoadOCS6003(this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "memb_gubun")
                           , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "memb")
                           , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_code")
                           , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code")
                           , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));

            this.LoadOCS6005(this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "memb_gubun")
                           , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "memb")
                           , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_code")
                           , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "cp_path_code")
                           , this.grdOCS6002.GetItemString(grdOCS6002.CurrentRowNumber, "jaewonil"));

            this.SetRowJisiDataVisible(tabInputGubun.SelectedTab.Tag.ToString());       
        }

        private void grdOCS6002_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            if (this.ExistModifiedOrder() == true)
            {
                DialogResult result = MessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    this.btnList.PerformClick(FunctionType.Update);
            }
        }

        private void OCS6000U00_Closing(object sender, CancelEventArgs e)
        {
            if (this.ExistModifiedOrder() == true)
            {
                DialogResult result = MessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    this.btnList.PerformClick(FunctionType.Update);
            }
        }

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }


        #region [ SaveOCS6005 & 6006 ]
        /// <summary>
        /// CP 지시사항 저장 처리
        /// </summary>
        /// <returns>bool</returns>
        private bool SaveOCS6005()
        {
            try
            {
                Service.BeginTransaction();

                // -- OCS6005 ---------------------------------------------------------------------------------------------------

                foreach (DataRow row in grdOCS6005.LayoutTable.Rows)
                {
                    string cmdText = string.Empty;
                    BindVarCollection bindVars = new BindVarCollection();
                    bindVars.Add("q_user_id",       UserInfo.UserID);
                    bindVars.Add("f_hosp_code",     EnvironInfo.HospCode);
                    bindVars.Add("f_memb_gubun",    row["memb_gubun"].ToString());
                    bindVars.Add("f_memb",          row["memb"].ToString());
                    bindVars.Add("f_cp_code",       row["cp_code"].ToString());
                    bindVars.Add("f_cp_path_code",  row["cp_path_code"].ToString());
                    bindVars.Add("f_jaewonil",      row["jaewonil"].ToString());
                    bindVars.Add("f_input_gubun",   row["input_gubun"].ToString());
                    bindVars.Add("f_pk_seq",        row["pk_seq"].ToString());
                    bindVars.Add("f_direct_gubun",  row["direct_gubun"].ToString());
                    bindVars.Add("f_direct_code",   row["direct_code"].ToString());
                    bindVars.Add("f_direct_cont1",  row["direct_cont1"].ToString());
                    bindVars.Add("f_direct_cont2",  row["direct_cont2"].ToString());
                    bindVars.Add("f_direct_text",   row["direct_text"].ToString());
                    bindVars.Add("f_jaewonil_from", row["jaewonil_from"].ToString());
                    bindVars.Add("f_jaewonil_to",   row["jaewonil_to"].ToString());
                    bindVars.Add("f_continue_yn",   row["continue_yn"].ToString());
                    bindVars.Add("f_input_gwa",     row["input_gwa"].ToString());
                    bindVars.Add("f_input_doctor",  row["input_doctor"].ToString());

                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            cmdText = @"INSERT INTO OCS6005
                                             ( SYS_DATE         , SYS_ID          , UPD_DATE        , UPD_ID          ,
                                               HOSP_CODE        , MEMB_GUBUN      , MEMB            , CP_CODE         ,
                                               CP_PATH_CODE     , JAEWONIL        , INPUT_GUBUN     , PK_SEQ          ,
                                               DIRECT_GUBUN     , DIRECT_CODE     , DIRECT_CONT1    , DIRECT_CONT2    ,
                                               DIRECT_TEXT      , JAEWONIL_FROM   , JAEWONIL_TO     , CONTINUE_YN     ,
                                               INPUT_GWA        , INPUT_DOCTOR          )
                                        VALUES
                                             ( SYSDATE          , :q_user_id      , SYSDATE         , :q_user_id      ,
                                               :f_hosp_code     , :f_memb_gubun   , :f_memb         , :f_cp_code      ,
                                               :f_cp_path_code  , :f_jaewonil     , :f_input_gubun  , :f_pk_seq       ,
                                               :f_direct_gubun  , :f_direct_code  , :f_direct_cont1 , :f_direct_cont2 ,
                                               :f_direct_text   , :f_jaewonil_from, :f_jaewonil_to  , :f_continue_yn  ,
                                               :f_input_gwa     , :f_input_doctor       )";

                            break;
                        case DataRowState.Modified:
                            cmdText = @"UPDATE OCS6005
                                           SET UPD_DATE      = SYSDATE
                                             , UPD_ID        = :q_user_id
                                             , DIRECT_CONT1  = :f_direct_cont1
                                             , DIRECT_CONT2  = :f_direct_cont2
                                             , DIRECT_TEXT   = :f_direct_text
                                             , JAEWONIL_FROM = :f_jaewonil_from
                                             , JAEWONIL_TO   = :f_jaewonil_to
                                             , CONTINUE_YN   = :f_continue_yn
                                             , INPUT_GWA     = :f_input_gwa
                                             , INPUT_DOCTOR  = :f_input_doctor
                                         WHERE MEMB_GUBUN    = :f_memb_gubun
                                           AND MEMB          = :f_memb
                                           AND CP_CODE       = :f_cp_code
                                           AND CP_PATH_CODE  = :f_cp_path_code
                                           AND JAEWONIL      = :f_jaewonil
                                           AND INPUT_GUBUN   = :f_input_gubun
                                           AND PK_SEQ        = :f_pk_seq
                                           AND HOSP_CODE     = :f_hosp_code";
                            break;
                    }

                    if (!TypeCheck.IsNull(cmdText))
                    {
                        if(!Service.ExecuteNonQuery(cmdText, bindVars)) throw new Exception(Service.ErrFullMsg);
                    }
                }

                #region delete

                if (layDeletedOCS6006.RowCount > 0)
                {
                    foreach (DataRow row in layDeletedOCS6006.LayoutTable.Rows)
                    {
                        string cmdText = string.Empty;
                        BindVarCollection bindVars = new BindVarCollection();
                        bindVars.Add("f_hosp_code",     EnvironInfo.HospCode);
                        bindVars.Add("f_memb_gubun",    row["memb_gubun"].ToString());
                        bindVars.Add("f_memb",          row["memb"].ToString());
                        bindVars.Add("f_cp_code",       row["cp_code"].ToString());
                        bindVars.Add("f_cp_path_code",  row["cp_path_code"].ToString());
                        bindVars.Add("f_jaewonil",      row["jaewonil"].ToString());
                        bindVars.Add("f_input_gubun",   row["input_gubun"].ToString());
                        bindVars.Add("f_pk_seq",        row["pk_seq"].ToString());
                        bindVars.Add("f_seq",           row["seq"].ToString());

                        cmdText = @"DELETE OCS6006
                                     WHERE MEMB_GUBUN     = :f_memb_gubun
                                       AND MEMB           = :f_memb
                                       AND CP_CODE        = :f_cp_code
                                       AND CP_PATH_CODE   = :f_cp_path_code
                                       AND JAEWONIL       = :f_jaewonil
                                       AND INPUT_GUBUN    = :f_input_gubun
                                       AND PK_SEQ         = :f_pk_seq
                                       AND SEQ            = :f_seq
                                       AND HOSP_CODE      = :f_hosp_code";

                        if (!Service.ExecuteNonQuery(cmdText, bindVars))
                        {
                            throw new Exception(Service.ErrFullMsg);
                        }
                    }
                    layDeletedOCS6006.Reset();
                }

                if (layDeletedOCS6005.RowCount > 0)
                {
                    foreach (DataRow row in layDeletedOCS6005.LayoutTable.Rows)
                    {
                        string cmdText = string.Empty;
                        string cmdTextD = string.Empty;
                        BindVarCollection bindVars = new BindVarCollection();
                        bindVars.Add("f_hosp_code",     EnvironInfo.HospCode);
                        bindVars.Add("f_memb_gubun",    row["memb_gubun"].ToString());
                        bindVars.Add("f_memb",          row["memb"].ToString());
                        bindVars.Add("f_cp_code",       row["cp_code"].ToString());
                        bindVars.Add("f_cp_path_code",  row["cp_path_code"].ToString());
                        bindVars.Add("f_jaewonil",      row["jaewonil"].ToString());
                        bindVars.Add("f_input_gubun",   row["input_gubun"].ToString());
                        bindVars.Add("f_pk_seq",        row["pk_seq"].ToString());

                        cmdText = @"DELETE OCS6005
                                     WHERE MEMB_GUBUN    = :f_memb_gubun
                                       AND MEMB          = :f_memb
                                       AND CP_CODE       = :f_cp_code
                                       AND CP_PATH_CODE  = :f_cp_path_code
                                       AND JAEWONIL      = :f_jaewonil
                                       AND INPUT_GUBUN   = :f_input_gubun
                                       AND PK_SEQ        = :f_pk_seq
                                       AND HOSP_CODE     = :f_hosp_code";

                        cmdTextD = @"DELETE OCS6006
                                     WHERE MEMB_GUBUN     = :f_memb_gubun
                                       AND MEMB           = :f_memb
                                       AND CP_CODE        = :f_cp_code
                                       AND CP_PATH_CODE   = :f_cp_path_code
                                       AND JAEWONIL       = :f_jaewonil
                                       AND INPUT_GUBUN    = :f_input_gubun
                                       AND PK_SEQ         = :f_pk_seq
                                       AND HOSP_CODE      = :f_hosp_code";

                        if (!Service.ExecuteNonQuery(cmdText, bindVars)) throw new Exception(Service.ErrFullMsg);
                        if (!Service.ExecuteNonQuery(cmdTextD, bindVars)) throw new Exception(Service.ErrFullMsg);
                    }
                    layDeletedOCS6005.Reset();
                }
                #endregion

                // -- OCS6006 ---------------------------------------------------------------------------------------------------
                if (grdOCS6006.RowCount > 0)
                {
                    foreach(DataRow row in grdOCS6006.LayoutTable.Rows)
                    {
                        string cmdText = string.Empty;
                        BindVarCollection bindVars = new BindVarCollection();
                        bindVars.Add("q_user_id",        UserInfo.UserID);
                        bindVars.Add("f_hosp_code",      EnvironInfo.HospCode);
                        bindVars.Add("f_memb_gubun",     row["memb_gubun"].ToString());
                        bindVars.Add("f_memb",           row["memb"].ToString());
                        bindVars.Add("f_cp_code",        row["cp_code"].ToString());
                        bindVars.Add("f_cp_path_code",   row["cp_path_code"].ToString());
                        bindVars.Add("f_jaewonil",       row["jaewonil"].ToString());
                        bindVars.Add("f_input_gubun",    row["input_gubun"].ToString());
                        bindVars.Add("f_pk_seq",         row["pk_seq"].ToString());
                        bindVars.Add("f_seq",            row["seq"].ToString());
                        bindVars.Add("f_direct_gubun",   row["direct_gubun"].ToString());
                        bindVars.Add("f_direct_code",    row["direct_code"].ToString());
                        bindVars.Add("f_direct_detail",  row["direct_detail"].ToString());
                        bindVars.Add("f_hangmog_code",   row["hangmog_code"].ToString());
                        bindVars.Add("f_suryang",        row["suryang"].ToString());
                        bindVars.Add("f_nalsu",          row["nalsu"].ToString());
                        bindVars.Add("f_ord_danui",      row["ord_danui"].ToString());
                        bindVars.Add("f_bogyong_code",   row["bogyong_code"].ToString());
                        bindVars.Add("f_jusa_code",      row["jusa_code"].ToString());
                        bindVars.Add("f_jusa_spd_gubun", row["jusa_spd_gubun"].ToString());
                        bindVars.Add("f_dv",             row["dv"].ToString());
                        bindVars.Add("f_dv_time",        row["dv_time"].ToString());
                        bindVars.Add("f_insulin_from",   row["insulin_from"].ToString());
                        bindVars.Add("f_insulin_to",     row["insulin_to"].ToString());
                        bindVars.Add("f_time_gubun",     row["time_gubun"].ToString());
                        bindVars.Add("f_bom_yn",         row["bom_yn"].ToString());
                        bindVars.Add("f_bom_source_key", row["bom_source_key"].ToString());


                        switch (row.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"INSERT INTO OCS6006
                                                 ( SYS_DATE         , SYS_ID          , UPD_DATE        , UPD_ID          ,
                                                   HOSP_CODE        , MEMB_GUBUN      , MEMB            , CP_CODE         ,
                                                   CP_PATH_CODE     , JAEWONIL        , INPUT_GUBUN     , PK_SEQ          ,
                                                   SEQ              , DIRECT_GUBUN    , DIRECT_CODE     , DIRECT_DETAIL   ,
                                                   HANGMOG_CODE     , SURYANG         , NALSU           , ORD_DANUI       ,
                                                   BOGYONG_CODE     , JUSA_CODE       , JUSA_SPD_GUBUN  , DV              ,
                                                   DV_TIME          , INSULIN_FROM    , INSULIN_TO      , TIME_GUBUN      ,
                                                   BOM_YN           , BOM_SOURCE_KEY        )
                                            VALUES
                                                 ( SYSDATE          , :q_user_id      , SYSDATE           , :q_user_id      ,
                                                   :f_hosp_code     , :f_memb_gubun   , :f_memb           , :f_cp_code      ,
                                                   :f_cp_path_code  , :f_jaewonil     , :f_input_gubun    , :f_pk_seq       ,
                                                   :f_seq           , :f_direct_gubun , :f_direct_code    , :f_direct_detail,
                                                   :f_hangmog_code  , :f_suryang      , :f_nalsu          , :f_ord_danui    ,
                                                   :f_bogyong_code  , :f_jusa_code    , :f_jusa_spd_gubun , :f_dv           ,
                                                   :f_dv_time       , :f_insulin_from , :f_insulin_to     , :f_time_gubun   ,
                                                   :f_bom_yn        , :f_bom_source_key     )";

                                break;
                            case DataRowState.Modified:

                                cmdText = @"UPDATE OCS6006
                                               SET UPD_DATE       = SYSDATE
                                                 , UPD_ID         = :q_user_id
                                                 , HANGMOG_CODE   = :f_hangmog_code
                                                 , SURYANG        = :f_suryang
                                                 , NALSU          = :f_nalsu
                                                 , ORD_DANUI      = :f_ord_danui
                                                 , BOGYONG_CODE   = :f_bogyong_code
                                                 , JUSA_CODE      = :f_jusa_code
                                                 , JUSA_SPD_GUBUN = :f_jusa_spd_gubun
                                                 , DV             = :f_dv
                                                 , DV_TIME        = :f_dv_time
                                                 , INSULIN_FROM   = :f_insulin_from
                                                 , INSULIN_TO     = :f_insulin_to
                                                 , TIME_GUBUN     = :f_time_gubun
                                                 , BOM_YN         = :f_bom_yn
                                                 , BOM_SOURCE_KEY = :f_bom_source_key
                                             WHERE MEMB_GUBUN     = :f_memb_gubun
                                               AND MEMB           = :f_memb
                                               AND CP_CODE        = :f_cp_code
                                               AND CP_PATH_CODE   = :f_cp_path_code
                                               AND JAEWONIL       = :f_jaewonil
                                               AND INPUT_GUBUN    = :f_input_gubun
                                               AND PK_SEQ         = :f_pk_seq
                                               AND SEQ            = :f_seq
                                               AND HOSP_CODE      = :f_hosp_code";

                                break;
                        }

                        if (!TypeCheck.IsNull(cmdText))
                        {
                            if (!Service.ExecuteNonQuery(cmdText, bindVars)) throw new Exception(Service.ErrFullMsg);
                        }
                    }
                }
                // DELETE END-----------------------------------------------------------------------------------------------*/

            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message, "SaveOCS6005 Error!");
                return false;
            }
            Service.CommitTransaction();

            return true;
        }
        #endregion


    }

    #region XSavePeformer
    public class XSavePeformer : ISavePerformer
    {
        private OCS6000U00 parent = null;
        private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS6010U00");

        public XSavePeformer(OCS6000U00 parent)
        {
            this.parent = parent;
        }

        public bool Execute(char callerId, RowDataItem item)
        {
            string cmdText = "";
            object t_chk = "";
            string spName = "";
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();

            item.BindVarList.Add("q_user_id", UserInfo.UserID);
            item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
            switch (callerId)
            {
                case '1':   // OCS6000   

                    #region CP MASTER OCS6000

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            cmdText = @"INSERT INTO OCS6000 
                                             ( SYS_DATE        , SYS_ID    , UPD_DATE , UPD_ID
                                             , HOSP_CODE       , MEMB_GUBUN, MEMB     , CP_CODE
                                             , CP_NAME         , SEQ       , CP_REMARK, START_CONDITION_YN
                                             , ORD_OCCUR_GUBUN )
                                        VALUES 
                                             ( SYSDATE         , :q_user_id   , SYSDATE     , :q_user_id
                                             , :f_hosp_code    , :f_memb_gubun, :f_memb     , :f_cp_code
                                             , :f_cp_name      , :f_seq       , :f_cp_remark, :f_start_condition_yn
                                             , :f_ord_occur_gubun ) ";

                            break;

                        case DataRowState.Modified:

                            cmdText = @"UPDATE OCS6000
                                           SET UPD_ID      = :q_user_id
                                             , UPD_DATE    = SYSDATE
                                             , CP_NAME     = :f_cp_name
                                             , CP_REMARK   = :f_cp_remark 
                                         WHERE HOSP_CODE   = :f_hosp_code
                                           AND MEMB_GUBUN  = :f_memb_gubun 
                                           AND MEMB        = :f_memb
                                           AND CP_CODE     = :f_cp_code ";

                            break;

                        case DataRowState.Deleted:

                            cmdText = @" DELETE FROM OCS6000           
                                          WHERE HOSP_CODE   = :f_hosp_code
                                            AND MEMB_GUBUN  = :f_memb_gubun 
                                            AND MEMB        = :f_memb
                                            AND CP_CODE     = :f_cp_code ";


                            break;
                    }

                    #endregion

                    break;
                case '2':    // OCS6002  

                    #region 일수별

                    switch (item.RowState)
                    {
                        case DataRowState.Added:     // Insert 

                            cmdText = @" INSERT INTO OCS6002 
                                              ( SYS_DATE        , SYS_ID    , UPD_DATE   , UPD_ID
                                              , HOSP_CODE       , MEMB_GUBUN, MEMB       , CP_CODE
                                              , CP_PATH_CODE    , JAEWONIL  , PATH_REMARK, CONDITION_YN
                                              , ORD_OCCUR_GUBUN )
                                         VALUES
                                              ( SYSDATE         , :q_user_id   , SYSDATE       , :q_user_id
                                              , :f_hosp_code    , :f_memb_gubun, :f_memb       , :f_cp_code
                                              , :f_cp_path_code , :f_jaewonil  , :f_path_remark, :f_condition_yn
                                              , :f_ord_occur_gubun ) ";


                            break;

                        case DataRowState.Modified:  // Update

                            cmdText = @" UPDATE OCS6003
                                            SET CP_PATH_CODE = :f_cp_path_code
                                              , JAEWONIL     = :f_jaewonil
                                              , UPD_ID       = :q_user_id
                                              , UPD_DATE     = SYSDATE
                                          WHERE HOSP_CODE    = :f_hosp_code
                                            AND MEMB_GUBUN   = :f_memb_gubun
                                            AND MEMB         = :f_memb
                                            AND CP_CODE      = :f_cp_code
                                            AND CP_PATH_CODE = :f_org_cp_path_code
                                            AND JAEWONIL     = :f_org_jaewonil ";

                            if (Service.ExecuteNonQuery(cmdText, item.BindVarList) == false)
                                return false;

                            cmdText = @" UPDATE OCS6002
                                            SET JAEWONIL     = :f_jaewonil
                                              , CP_PATH_CODE = :f_cp_path_code
                                          WHERE HOSP_CODE    = :f_hosp_code
                                            AND MEMB_GUBUN   = :f_memb_gubun
                                            AND MEMB         = :f_memb
                                            AND CP_CODE      = :f_cp_code
                                            AND CP_PATH_CODE = :f_org_cp_path_code
                                            AND JAEWONIL     = :f_org_jaewonil      ";

                            break;

                        case DataRowState.Deleted:   // Delete

                            cmdText = @" DELETE FROM OCS6002 
                                          WHERE HOSP_CODE    = :f_hosp_code
                                            AND MEMB_GUBUN   = :f_memb_gubun
                                            AND MEMB         = :f_memb
                                            AND CP_CODE      = :f_cp_code
                                            AND CP_PATH_CODE = :f_org_cp_path_code
                                            AND JAEWONIL     = :f_org_jaewonil      ";
                            break;
                    }


                    #endregion

                    break;

                case '3':    // 인서트 & 업데이트 

                    #region 오더 입력 및 변경

                    switch (item.RowState)
                    {
                        case DataRowState.Added:



                            // 키가 입력되지 않은경우 키를 따야함..
                            if (item.BindVarList["f_pkocskey"].VarValue == "")
                            {
                                cmdText = " SELECT OCS6003_SEQ.NEXTVAL "
                                        + "   FROM SYS.DUAL ";

                                t_chk = Service.ExecuteScalar(cmdText);

                                item.BindVarList.Remove("f_pkocskey");
                                item.BindVarList.Add("f_pkocskey", t_chk.ToString());
                            }

                            // 시퀀스 가져오기
                            if (item.BindVarList["f_seq"].VarValue == "")
                            {
                                cmdText = @" SELECT MAX(SEQ)+1 SEQ 
                                               FROM OCS6003 
                                              WHERE HOSP_CODE    = :f_hosp_code
                                                AND MEMB_GUBUN   = :f_memb_gubun
                                                AND MEMB         = :f_memb
                                                AND CP_CODE      = :f_cp_code
                                                AND CP_PATH_CODE = :f_cp_path_code
                                                AND JAEWONIL     = :f_jaewon_il    ";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", t_chk.ToString());
                            }

                            cmdText = @" INSERT INTO OCS6003 
                                              ( SYS_DATE      , SYS_ID        , UPD_DATE    , PKOCS6003
                                              , MEMB          , CP_CODE       , JAEWONIL    , INPUT_GUBUN
                                              , HANGMOG_CODE  , ORDER_GUBUN   , GROUP_SER   , SEQ
                                              , SPECIMEN_CODE , SURYANG       , ORD_DANUI   , DV_TIME
                                              , DV            , NALSU         , JUSA        , BOGYONG_CODE
                                              , EMERGENCY     , MUHYO         , PORTABLE_YN , TOIWON_DRG_YN
                                              , ANTI_CANCER_YN, PAY           , PRN_YN      , POWDER_YN
                                              , DV_1          , DV_2          , DV_3        , DV_4
                                              , MIX_GROUP     , ORDER_REMARK  , NURSE_REMARK, JUNDAL_TABLE
                                              , JUNDAL_PART   , MOVE_PART     , INPUT_TAB   , HUBAL_CHANGE_YN
                                              , PHARMACY      , JUSA_SPD_GUBUN, DRG_PACK_YN , UPD_ID
                                              , HOSP_CODE     , MEMB_GUBUN    , CP_PATH_CODE, AMT
                                              , BOGYONG_CODE2 , HANGMOG_NAME  , BOM_SOURCE_KEY )
                                         VALUES 
                                              ( SYSDATE          , :q_user_id       , SYSDATE        , :f_pkocskey
                                              , :f_memb          , :f_cp_code       , :f_jaewonil    , :f_input_gubun
                                              , :f_hangmog_code  , :f_order_gubun   , :f_group_ser   , :f_seq
                                              , :f_specimen_code , :f_suryang       , :f_ord_danui   , :f_dv_time
                                              , :f_dv            , :f_nalsu         , :f_jusa        , :f_bogyong_code
                                              , :f_emergency     , :f_muhyo         , :f_portable_yn , :f_toiwon_drg_yn
                                              , :f_anti_cancer_yn, :f_pay           , :f_prn_yn      , :f_powder_yn
                                              , :f_dv_1          , :f_dv_2          , :f_dv_3        , :f_dv_4
                                              , :f_mix_group     , :f_order_remark  , :f_nurse_remark, :f_jundal_table
                                              , :f_jundal_part   , :f_move_part     , :f_input_tab   , :f_hubal_change_yn
                                              , :f_pharmacy      , :f_jusa_spd_gubun, :f_drg_pack_yn , :f_upd_id
                                              , :f_hosp_code     , :f_memb_gubun    , :f_cp_path_code, :f_amt
                                              , :f_bogyong_code2 , :f_hangmog_name  , :f_bom_source_key ) ";

                            break;

                        case DataRowState.Modified:

                            cmdText = " UPDATE OCS6003 "
                                    + "    SET UPD_DATE         = SYSDATE "
                                    + "      , UPD_ID           = :q_user_id "
                                    + "      , NALSU            = :f_nalsu "
                                    + "      , JUSA             = :f_jusa  "
                                    + "      , BOGYONG_CODE     = :f_bogyong_code "
                                    + "      , EMERGENCY        = :f_emergency "
                                    + "      , JUNDAL_TABLE     = :f_jundal_table "
                                    + "      , JUNDAL_PART      = :f_jundal_part "
                                    + "      , MOVE_PART        = :f_move_part "
                                    + "      , MUHYO            = :f_muhyo "
                                    + "      , PORTABLE_YN      = :f_portable_yn "
                                    + "      , POWDER_YN        = :f_powder_yn "
                                    + "      , DV_1             = :f_dv_1 "
                                    + "      , DV_2             = :f_dv_2 "
                                    + "      , DV_3             = :f_dv_3 "
                                    + "      , DV_4             = :f_dv_4 "
                                    + "      , MIX_GROUP        = :f_mix_group "
                                    + "      , ORDER_REMARK     = :f_order_remark "
                                    + "      , NURSE_REMARK     = :f_nurse_remark "
                                    + "      , BOM_SOURCE_KEY   = :f_bom_source_key "
                                    + "      , HUBAL_CHANGE_YN  = :f_hubal_change_yn "
                                    + "      , PHARMACY         = :f_pharmacy "
                                    + "      , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun "
                                    + "      , DRG_PACK_YN      = :f_drg_pack_yn "
                                    + "  WHERE PKOCS6003        = :f_pkocskey ";



                            break;

                    }

                    #endregion

                    break;

                case '4':    // 삭제

                    cmdText = @" DELETE FROM OCS6003
                                  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                                    AND PKOCS6003 = :f_pkocskey ";

                    break;
            }

            bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

            return isSuccess;
        }

    }
    #endregion
}