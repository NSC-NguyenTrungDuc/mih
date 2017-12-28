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
    public partial class OCS6010U00 : IHIS.Framework.XScreen
    {
        public OCS6010U00()
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
        private OCS.PatientInfo mSelectedPatientInfo;
        private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("OCS1003P01");
        private OCS.OrderFunc mOrderFunc = new IHIS.OCS.OrderFunc("OCS1003P01");
        private OCS.HangmogInfo mHangmogInfo = new HangmogInfo("OCS1003P01");
        private OCS.CommonForms mCommonForms = new CommonForms();

        ///////////////////////////////////////////////////////////////////////////////////
        // 동적 구성 관련
        /////////////////////////////////////////////////////////////////////////////////// 
        private int mInputTabDefaultWidth = 90;
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
        private string mParamBunho = "";
        private string mParamNaewonKey = "";
        private string mOrderDate = "";
        private bool mIsCalledByScreen = false;

        private string mInputGubun = "";
        private string mInputGwa = "";

        private ArrayList mBunhoInfoControls = new ArrayList();

        // 메세지 관련 변수들
        string mMsg = "";
        string mCap = "";

        // 팝업메뉴
        private IHIS.X.Magic.Menus.PopupMenu mMenuPFEResult = new IHIS.X.Magic.Menus.PopupMenu();

        private string mCurrentInputTab = "";


        #endregion

        #region Screen 이벤트

        private void OCS6010U00_Load(object sender, EventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            //if (this.Opener is IHIS.Framework.MdiForm &&
            //    (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            //{
            //    Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //    this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 110);
            //}

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 110);

            // Save Performer 셋팅
            this.laySaveLayout.SavePerformer = new XSavePeformer(this);
            this.layDeletedData.SavePerformer = this.laySaveLayout.SavePerformer;
            this.grdOCS6012.SavePerformer = this.laySaveLayout.SavePerformer;
            this.grdOCS6010.SavePerformer = this.laySaveLayout.SavePerformer;

            // 환자번호 자릿수 셋팅
            this.fbxBunho.MaxLength = EnvironInfo.BunhoLength;

            // 환자번호 컨트롤 셋팅
            this.mBunhoInfoControls.Add(this.fbxBunho);
            this.mBunhoInfoControls.Add(this.lbSuname);
            this.mBunhoInfoControls.Add(this.lbSuname2);
            this.mBunhoInfoControls.Add(this.lbSexAge);
            this.mBunhoInfoControls.Add(this.lbWeight);
            this.mBunhoInfoControls.Add(this.lbHeight);
            this.mBunhoInfoControls.Add(this.lbGubunName);
            this.mBunhoInfoControls.Add(this.lbChojaeName);

            this.mSelectedPatientInfo = new PatientInfo(this.Name);

            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            mMenuPFEResult.MenuCommands.Clear();
            IHIS.X.Magic.Menus.MenuCommand popUpMenu;
            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "内視鏡画像結果" : "화상결과", (Image)this.ImageList.Images[17], new EventHandler(PopUpMenuPfeResult_Click));
            popUpMenu.Tag = "1";
            mMenuPFEResult.MenuCommands.Add(popUpMenu);
            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "内視鏡レポート照会" : "레포트결과", (Image)this.ImageList.Images[15], new EventHandler(PopUpMenuPfeResult_Click));
            popUpMenu.Tag = "2";
            mMenuPFEResult.MenuCommands.Add(popUpMenu);
            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "心電図結果" : "심전도결과", (Image)this.ImageList.Images[11], new EventHandler(PopUpMenuPfeResult_Click));
            popUpMenu.Tag = "3";
            mMenuPFEResult.MenuCommands.Add(popUpMenu);

            // 유저변경 로직을 태움.
            this.OCS6010U00_UserChanged(this, new EventArgs());

            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("naewon_key"))
                {
                    this.mParamNaewonKey = this.OpenParam["naewon_key"].ToString();
                }

                if (this.OpenParam.Contains("bunho"))
                {
                    this.mParamBunho = this.OpenParam["bunho"].ToString();
                }

                if (this.OpenParam.Contains("order_date"))
                {
                    this.mOrderDate = this.OpenParam["order_date"].ToString();
                }
                else
                {
                    this.mOrderDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                }

                this.mIsCalledByScreen = true;
            }
            else
            {
                this.mOrderDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
            }

            PostCallHelper.PostCall(new PostMethod(PostLoadEvent));
        }

        private void OCS6010U00_UserChanged(object sender, EventArgs e)
        {
            InitializeScreenByUser();
        }

        // 로드에서 파라미터와 유저변경 로직 적용후
        // 여기서 초기에 조회등의 로직을 타게된다.
        /// <summary>
        /// 
        /// </summary>
        private void PostLoadEvent()
        {
            this.layDeletedOCS6015 = this.grdOCS6015.CloneToLayout();
            this.layDeletedOCS6016 = this.grdOCS6016.CloneToLayout();

            // 다른 화면에서 열린 경우는 환자파인드 박스에 번호 셋팅후
            // 변경 못하도록 설정한다.
            if (this.mIsCalledByScreen)
            {
                if (this.mParamBunho != "")
                {
                    // 환자번호 선택해 버리자.~~~~~
                    this.fbxBunho.SetEditValue(this.mParamBunho);
                    this.fbxBunho.AcceptData();
                    this.fbxBunho.Protect = true;
                }
                else
                {
                    this.mIsCalledByScreen = false;
                }
            }
        }

        #endregion

        #region 초기화 모듈

        #region 유저별 초기화 될것들

        private void InitializeScreenByUser()
        {
            // 모드 설정 ( 의사가 로긴한건지, 의사가 아닌 다른사람들이 로긴한건지 판단 )
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.mDoctorLogin = true;
                this.mInputGubun = "D%";
                this.mInputGwa = UserInfo.Gwa;

            }
            else
            {
                this.mDoctorLogin = false;

                if (TypeCheck.IsNull(UserInfo.InputGubun))
                {
                    this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。";
                    this.mCap = "使用権限確認";

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }

                this.mInputGubun = UserInfo.InputGubun;

                if (UserInfo.UserGubun == UserType.Nurse)
                    this.mInputGwa = TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa).ToString();
                else
                    this.mInputGwa = UserInfo.Gwa;
            }

            if (TypeCheck.IsNull(this.mInputGwa))
            {

                if (this.OpenParam != null && this.OpenParam.Contains("input_gwa"))
                {
                    this.mInputGwa = this.OpenParam["input_gwa"].ToString();
                }
                else
                {
                    this.mInputGwa = mCommonForms.SelectGwa("1", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                if (TypeCheck.IsNull(this.mInputGwa))
                {
                    this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。";
                    this.mCap = "使用権限確認";

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }

            // InputGubun 탭 구성
            this.MakeInputGubunTab();

            // InputTab 탭 구성
            this.MakeInputTab();

            // 오더 지시 중 오더가 기본값
            this.rbnOrder.Checked = true;
        }

        #endregion

        #region 환자번호 변경시 초기화 목록

        // 환자번호 초기화시 설정파일
        private void InitializeBunho(bool aIsCalledbyOpening)
        {
            ClearPatientInfoLabel();
            //this.mParamNaewonKey = "";
            this.mSelectedPatientInfo.ClearPatientInfo();

            //this.pbxEtcJubsu.Visible = false;
            this.pbxExistBunhoComment.Visible = false;
            //this.pbxInpReserYN.Visible = false;

            this.InitializeOrderInfo();

            if (aIsCalledbyOpening == false)
            {
                //this.mParamNaewonKey 
            }

            this.paInfoBox.Reset();
        }

        #endregion

        #region 오더관련 데이터 초기화

        // 오더 및 상병정보 초기화
        private void InitializeOrderInfo()
        {
            // OCS6010클리어
            this.grdOCS6010.Reset();

            // OCS6015, 6016클리어
            this.grdOCS6015.Reset();
            this.grdOCS6016.Reset();

            // 재원일수 트리뷰
            this.tvwJaewonIL.Nodes.Clear();

            // 오더정보 클리어
            try
            {
                this.grdOCS6015.Reset();
                this.ResetAllOrderTemp();

            }
            catch { }
        }

        // 오더 ㄱㅐ별테이블 데이터 리셋
        private void ResetAllOrderTemp()
        {
            this.layDrgOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layXrtOrder.Reset();
            this.layChuchiOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.laySusulOrder.Reset();
            this.layEtcOrder.Reset();

            this.layDisplayLayout.Reset();
            //this.layQueryLayout.Reset();
            this.layDeletedData.Reset();
            this.dwOrderInfo.Reset();
        }

        #endregion

        #region 환자정보 초기화

        private void SetPatientInfoLabel(DataRow aPatientInfo)
        {
            if (aPatientInfo == null) return;

            this.lbSuname.Text = aPatientInfo["suname"].ToString();
            this.lbSuname2.Text = aPatientInfo["suname2"].ToString();
            this.lbSexAge.Text = aPatientInfo["sex"].ToString() + "/" + aPatientInfo["age"].ToString();
            this.lbWeight.Text = aPatientInfo["weight"].ToString();
            this.lbHeight.Text = aPatientInfo["height"].ToString();
            this.lbGubunName.Text = aPatientInfo["gubun_name"].ToString();
            this.lbChojaeName.Text = aPatientInfo["chojae_name"].ToString();
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

        #region 데이터 셋팅 및 조회 관련

        private void ClearPatientInfoLabel()
        {
            // 환자정보 컨트롤 클리어
            for (int i = 0; i < this.mBunhoInfoControls.Count; i++)
            {
                if (((Control)mBunhoInfoControls[i]).Name == "fbxBunho") continue;

                if (((Control)mBunhoInfoControls[i]) is XLabel)
                {
                    ((XLabel)mBunhoInfoControls[i]).Text = "";
                }
                else if (((Control)mBunhoInfoControls[i]) is XTextBox)
                {
                    ((XTextBox)mBunhoInfoControls[i]).SetDataValue("");
                }
            }
        }

        private void LoadOCS6010(string aBunho, string aFkinp1001)
        {
            this.grdOCS6010.SetBindVarValue("f_bunho", aBunho);
            this.grdOCS6010.SetBindVarValue("f_fkinp1001", aFkinp1001);
            this.grdOCS6010.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.grdOCS6010.QueryLayout(true);
        }

        private void LoadOCS6012(string aFkocs6010)
        {
            //this.layOCS6012.SetBindVarValue("f_pkocs6010", aFkocs6010);
            this.grdOCS6012.SetBindVarValue("f_pkocs6010", aFkocs6010);
            this.grdOCS6012.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (this.cbxQryAllDate.Checked)
            {
                //this.layOCS6012.SetBindVarValue("f_all_plan_date", "Y");
                this.grdOCS6012.SetBindVarValue("f_all_plan_date", "Y");
            }
            else
            {
                //this.layOCS6012.SetBindVarValue("f_all_plan_date", "N");
                this.grdOCS6012.SetBindVarValue("f_all_plan_date", "N");
            }

            //this.layOCS6012.QueryLayout(true);
            this.grdOCS6012.QueryLayout(true);
        }

        private void LoadOCS6013(string aFkocs6010, string aJaewonIL)
        {
            this.layQueryLayout.SetBindVarValue("f_pkocs6010", aFkocs6010);
            this.layQueryLayout.SetBindVarValue("f_jaewonil", aJaewonIL);
            this.layQueryLayout.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.layQueryLayout.QueryLayout(true);

            this.ResetAllOrderTemp();

            this.SetInputGubunColor(this.layQueryLayout.LayoutTable);

            foreach (DataRow dr in this.layQueryLayout.LayoutTable.Rows)
            {
                //this.SetInputGubunColor(dr["input_gubun"].ToString());

                switch (dr["input_tab"].ToString())
                {
                    case "01":    // 약

                        this.layDrgOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "03":    // 주사

                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "04":    // 검체검ㅅㅏ

                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "05":    // 생리검사

                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "06":    // 병리검사

                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "07":    // 화상진단

                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "08":    // 처치

                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "09":    // 수술 마취

                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "11":    // 기타 오더

                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }
        }

        private void DislplayOrderDataWindow(string aInputGubun, string aInputTab)
        {
            this.SetDisplayLayout(aInputGubun, aInputTab);

            this.dwOrderInfo.Reset();

            this.dwOrderInfo.FillData(this.layDisplayLayout.LayoutTable);
        }

        private void LoadOCS6015(string aFkocs6010, string aCpCode, string aCpPathCode, string aJaewonIl, string aPlanOrderDate)
        {
            this.layDeletedOCS6015.Reset();

            this.grdOCS6015.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS6015.SetBindVarValue("f_fkocs6010", aFkocs6010);
            this.grdOCS6015.SetBindVarValue("f_cp_code", aCpCode);
            this.grdOCS6015.SetBindVarValue("f_cp_path_code", aCpPathCode);
            this.grdOCS6015.SetBindVarValue("f_jaewonil", aJaewonIl);
            this.grdOCS6015.SetBindVarValue("f_plan_order_date", aPlanOrderDate);

            this.grdOCS6015.QueryLayout(true);

            if (this.rbnJisi.Checked)
                this.SetInputGubunColor(this.grdOCS6015.LayoutTable);

            if (this.grdOCS6015.RowCount <= 0) this.grdOCS6015.Reset();

            this.layDeletedOCS6016.Reset();
            this.grdOCS6016.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS6016.SetBindVarValue("f_fkocs6010", aFkocs6010);
            this.grdOCS6016.SetBindVarValue("f_cp_code", aCpCode);
            this.grdOCS6016.SetBindVarValue("f_cp_path_code", aCpPathCode);
            this.grdOCS6016.SetBindVarValue("f_jaewonil", aJaewonIl);

            this.grdOCS6016.QueryLayout(true);
        }

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

        private bool UpdateOCS6012()
        {
            if (this.grdOCS6012.SaveLayout() == false)
            {
                //MessageBox.Show(XMsg.GetMsg("M005")  + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion

        #region 각종 메소드 들

        #region 각종 체크 메소드
        /// <summary>
        /// 환자번호 입력시 각종체크들 ( 알레르기, 타과진료, 진료의뢰, 환자특기사항 )
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        /// <param name="aBunho">환자번호</param>
        /// <param name="aGwa">진료과</param>
        /// <param name="aDoctor">진료의</param>
        private void CheckPatientEtcInfo(string aNaewonDate, string aBunho, string aGwa, string aDoctor)
        {
            // 코맨트
            string commemt = this.mOrderBiz.LoadPatientSpecificComment(aBunho);

            if (commemt != "")
            {
                this.mCap = "患者特記事項";

                MessageBox.Show(commemt, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.pbxExistBunhoComment.Visible = true;
            }
        }

        /// <summary>
        /// 환자 선택여부
        /// </summary>
        /// <returns></returns>
        private bool IsPatientSelected()
        {
            if (this.fbxBunho.GetDataValue() == "" ||
                this.mSelectedPatientInfo == null ||
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() == "") return false;

            return true;
        }

        private void MakeDayTree(int aCurrentRowNumber)
        {
            TreeNode node;
            Hashtable nodeInfo;
            string title = "";
            this.tvwJaewonIL.Nodes.Clear();

            //foreach (DataRow dr in this.layOCS6012.LayoutTable.Rows)
            //foreach(DataRow dr in this.grdOCS6012.LayoutTable.Rows)
            for(int i=0; i<this.grdOCS6012.RowCount; i++)
            {
                title = "【" + this.LoadWeekDay(DateTime.Parse(grdOCS6012.GetItemString(i, "plan_order_date")).DayOfWeek) + "】" + grdOCS6012.GetItemString(i, "plan_order_date") + " (" + grdOCS6012.GetItemString(i, "jaewonil") + "日)";
                node = new TreeNode(title, 16, 1);

                nodeInfo = new Hashtable();
                foreach (DataColumn cl in this.grdOCS6012.LayoutTable.Columns)
                {
                    nodeInfo.Add(cl.ColumnName, grdOCS6012.GetItemString(i, cl.ColumnName));
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
        }

        /// <summary>
        /// 요일명을 Return한다.
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        private string LoadWeekDay(System.DayOfWeek dayOfWeek)
        {
            string returnValue = "";

            if (dayOfWeek == System.DayOfWeek.Sunday)
                returnValue = "日";
            else if (dayOfWeek == System.DayOfWeek.Monday)
                returnValue = "月";
            else if (dayOfWeek == System.DayOfWeek.Tuesday)
                returnValue = "火";
            else if (dayOfWeek == System.DayOfWeek.Wednesday)
                returnValue = "水";
            else if (dayOfWeek == System.DayOfWeek.Thursday)
                returnValue = "木";
            else if (dayOfWeek == System.DayOfWeek.Friday)
                returnValue = "金";
            else if (dayOfWeek == System.DayOfWeek.Saturday)
                returnValue = "土";

            return returnValue;

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

        //        // 의사가 로그인한 경우
        //        if (this.mDoctorLogin)
        //        {
        //            // 내복약 셋팅
        //            foreach (DataRow drugFilter in this.layDrgOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(drugFilter);
        //            }
        //        }
        //        // 의사 이외의 사람이 로그인한 경우
        //        else
        //        {
        //            // 내복약 셋팅
        //            foreach (DataRow drugFilter in this.layDrgOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(drugFilter);
        //            }
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

        //        if (this.mDoctorLogin)
        //        {
        //            // 주사약 셋팅
        //            foreach (DataRow jusaFilter in this.layJusaOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(jusaFilter);
        //            }
        //        }
        //        else
        //        {
        //            // 주사약 셋팅
        //            foreach (DataRow jusaFilter in this.layJusaOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(jusaFilter);
        //            }
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

        //        if (this.mDoctorLogin)
        //        {
        //            // 검체검사 셋팅
        //            foreach (DataRow cplFilter in this.layCplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(cplFilter);
        //            }
        //        }
        //        else
        //        {
        //            // 검체검사 셋팅
        //            foreach (DataRow cplFilter in this.layCplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(cplFilter);
        //            }
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

        //        if (this.mDoctorLogin)
        //        {
        //            // 생리검사 셋팅
        //            foreach (DataRow pfeFilter in this.layPfeOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(pfeFilter);
        //            }
        //        }
        //        else
        //        {
        //            // 생리검사 셋팅
        //            foreach (DataRow pfeFilter in this.layPfeOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(pfeFilter);
        //            }
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

        //        if (this.mDoctorLogin)
        //        {
        //            // 병리검사 셋팅
        //            foreach (DataRow aplFilter in this.layAplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(aplFilter);
        //            }
        //        }
        //        else
        //        {
        //            // 병리검사 셋팅
        //            foreach (DataRow aplFilter in this.layAplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(aplFilter);
        //            }
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

        //        if (this.mDoctorLogin)
        //        {
        //            // 방사선 셋팅
        //            foreach (DataRow xrtFilter in this.layXrtOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(xrtFilter);
        //            }
        //        }
        //        else
        //        {
        //            // 병리검사 셋팅
        //            foreach (DataRow xrtFilter in this.layXrtOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(xrtFilter);
        //            }
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

        //        if (this.mDoctorLogin)
        //        {
        //            // 처치오더 셋팅
        //            foreach (DataRow chuchiFilter in this.layChuchiOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(chuchiFilter);
        //            }
        //        }
        //        else
        //        {
        //            // 처치오더 셋팅
        //            foreach (DataRow chuchiFilter in this.layChuchiOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(chuchiFilter);
        //            }
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

        //        if (this.mDoctorLogin)
        //        {
        //            // 수술오더 셋팅
        //            foreach (DataRow susulFilter in this.laySusulOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(susulFilter);
        //            }
        //        }
        //        else
        //        {
        //            // 수술오더 셋팅
        //            foreach (DataRow susulFilter in this.laySusulOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(susulFilter);
        //            }
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

        //        if (this.mDoctorLogin)
        //        {
        //            // 기타오더 셋팅
        //            foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(etcFilter);
        //            }
        //        }
        //        else
        //        {
        //            // 기타오더 셋팅
        //            foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
        //            {
        //                sourceLay.LayoutTable.ImportRow(etcFilter);
        //            }
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

                // 의사가 로그인한 경우
                if (this.mDoctorLogin)
                {
                    // 내복약 셋팅
                    //foreach (DataRow drugFilter in this.layDrugOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(drugFilter);
                    //}
                    for (int i = 0; i < this.layDrgOrder.RowCount; i++)
                    {
                        if (this.layDrgOrder.GetItemString(i, "input_gubun") == aInputGubun)
                        {
                            sourceLay.LayoutTable.ImportRow(this.layDrgOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                // 의사 이외의 사람이 로그인한 경우
                else
                {
                    // 내복약 셋팅
                    //foreach (DataRow drugFilter in this.layDrugOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(drugFilter);
                    //}
                    for (int i = 0; i < this.layDrgOrder.RowCount; i++)
                    {
                        if (this.layDrgOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layDrgOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layDrgOrder.LayoutTable.Rows[i]);
                        }
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

                if (this.mDoctorLogin)
                {
                    // 주사약 셋팅
                    //foreach (DataRow jusaFilter in this.layJusaOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(jusaFilter);
                    //}
                    for (int i = 0; i < this.layJusaOrder.RowCount; i++)
                    {
                        if (this.layJusaOrder.GetItemString(i, "input_gubun") == aInputGubun)
                        {
                            sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 주사약 셋팅
                    //foreach (DataRow jusaFilter in this.layJusaOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(jusaFilter);
                    //}
                    for (int i = 0; i < this.layJusaOrder.RowCount; i++)
                    {
                        if (this.layJusaOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layJusaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                        }
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

                if (this.mDoctorLogin)
                {
                    // 검체검사 셋팅
                    //foreach (DataRow cplFilter in this.layCplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(cplFilter);
                    //}
                    for (int i = 0; i < this.layCplOrder.RowCount; i++)
                    {
                        if (this.layCplOrder.GetItemString(i, "input_gubun") == aInputGubun )
                        {
                            sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 검체검사 셋팅
                    //foreach (DataRow cplFilter in this.layCplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(cplFilter);
                    //}
                    for (int i = 0; i < this.layCplOrder.RowCount; i++)
                    {
                        if (this.layCplOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layCplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                        }
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

                if (this.mDoctorLogin)
                {
                    // 생리검사 셋팅
                    //foreach (DataRow pfeFilter in this.layPfeOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(pfeFilter);
                    //}
                    for (int i = 0; i < this.layPfeOrder.RowCount; i++)
                    {
                        if (this.layPfeOrder.GetItemString(i, "input_gubun") == aInputGubun)
                        {
                            sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 생리검사 셋팅
                    //foreach (DataRow pfeFilter in this.layPfeOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(pfeFilter);
                    //}
                    for (int i = 0; i < this.layPfeOrder.RowCount; i++)
                    {
                        if (this.layPfeOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layPfeOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                        }
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

                if (this.mDoctorLogin)
                {
                    // 병리검사 셋팅
                    //foreach (DataRow aplFilter in this.layAplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(aplFilter);
                    //}
                    for (int i = 0; i < this.layAplOrder.RowCount; i++)
                    {
                        if (this.layAplOrder.GetItemString(i, "input_gubun") == aInputGubun)
                        {
                            sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 병리검사 셋팅
                    //foreach (DataRow aplFilter in this.layAplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(aplFilter);
                    //}
                    for (int i = 0; i < this.layAplOrder.RowCount; i++)
                    {
                        if (this.layAplOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layAplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                        }
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

                if (this.mDoctorLogin)
                {
                    // 방사선 셋팅
                    //foreach (DataRow xrtFilter in this.layXrtOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(xrtFilter);
                    //}
                    for (int i = 0; i < this.layXrtOrder.RowCount; i++)
                    {
                        if (this.layXrtOrder.GetItemString(i, "input_gubun") == aInputGubun)
                        {
                            sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 병리검사 셋팅
                    //foreach (DataRow xrtFilter in this.layXrtOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(xrtFilter);
                    //}
                    for (int i = 0; i < this.layXrtOrder.RowCount; i++)
                    {
                        if (this.layXrtOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layXrtOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                        }
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

                if (this.mDoctorLogin)
                {
                    // 처치오더 셋팅
                    //foreach (DataRow chuchiFilter in this.layChuchiOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(chuchiFilter);
                    //}
                    for (int i = 0; i < this.layChuchiOrder.RowCount; i++)
                    {
                        if (this.layChuchiOrder.GetItemString(i, "input_gubun") == aInputGubun)
                        {
                            sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 처치오더 셋팅
                    //foreach (DataRow chuchiFilter in this.layChuchiOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(chuchiFilter);
                    //}
                    for (int i = 0; i < this.layChuchiOrder.RowCount; i++)
                    {
                        if (this.layChuchiOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layChuchiOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                        }
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

                if (this.mDoctorLogin)
                {
                    // 수술오더 셋팅
                    //foreach (DataRow susulFilter in this.laySusulOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(susulFilter);
                    //}
                    for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                    {
                        if (this.laySusulOrder.GetItemString(i, "input_gubun") == aInputGubun)
                        {
                            sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 수술오더 셋팅
                    //foreach (DataRow susulFilter in this.laySusulOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(susulFilter);
                    //}
                    for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                    {
                        if (this.laySusulOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.laySusulOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                        }
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

                if (this.mDoctorLogin)
                {
                    // 기타오더 셋팅
                    //foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(etcFilter);
                    //}
                    for (int i = 0; i < this.layEtcOrder.RowCount; i++)
                    {
                        if (this.layEtcOrder.GetItemString(i, "input_gubun") == aInputGubun)
                        {
                            sourceLay.LayoutTable.ImportRow(this.layEtcOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 기타오더 셋팅
                    //foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(etcFilter);
                    //}
                    for (int i = 0; i < this.layEtcOrder.RowCount; i++)
                    {
                        if (this.layEtcOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layEtcOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layEtcOrder.LayoutTable.Rows[i]);
                        }
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

            // 지시사항 변경된 데이터 확인
            foreach (DataRow dr in this.grdOCS6015.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layDeletedOCS6015.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.grdOCS6016.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            foreach (DataRow dr in this.layDeletedOCS6016.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                    return true;
            }

            return false;
        }

        #endregion

        #region 지시사항 InputGubun 별 Row Visible 

        private void SetRowJisiDataVisible(string aInputGubun)
        {
            for (int i = 0; i < this.grdOCS6015.RowCount; i++)
            {
                if (grdOCS6015.GetItemString(i, "input_gubun") == aInputGubun)
                    this.grdOCS6015.SetRowVisible(i, true);
                else
                    this.grdOCS6015.SetRowVisible(i, false);
            }
        }

        #endregion

        #endregion

        #region 탭구성 모듈

        // 입력구분 탭 동적 구성 
        private void MakeInputGubunTab()
        {
            MultiLayout mInputGubun = new MultiLayout();

            mInputGubun.LayoutItems.Add("code", DataType.String);
            mInputGubun.LayoutItems.Add("code_name", DataType.String);
            mInputGubun.InitializeLayoutTable();

            // 의사가 로긴한경우
            if (this.mDoctorLogin == true)
            {

                mInputGubun.QuerySQL = "SELECT CODE, CODE_NAME "
                                     + "  FROM OCS0132 "
                                     + " WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                     + "   AND CODE LIKE 'D%' "
                                     + "   AND CODE_TYPE LIKE 'INPUT_GUBUN' "
                                     + "   AND VALUE_POINT = '1' " // 画面上表示
                                     + " ORDER BY SORT_KEY, CODE ";
            }
            // 기타유저인경우
            else
            {
                mInputGubun.QuerySQL = "SELECT CODE, CODE_NAME "
                                     + "  FROM OCS0132 "
                                     + " WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                     + "   AND CODE LIKE '" + this.mInputGubun + "' "
                                     + "   AND CODE_TYPE LIKE 'INPUT_GUBUN' "
                                     + "   AND VALUE_POINT = '1' " // 画面上表示
                                     + " ORDER BY SORT_KEY, CODE ";
            }

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
                if (this.mDoctorLogin)
                    tpgInputGubun = new IHIS.X.Magic.Controls.TabPage(dr["code_name"].ToString());
                else
                    tpgInputGubun = new IHIS.X.Magic.Controls.TabPage(dr["code_name"].ToString() + "及び医師オーダ照会");

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
        /// 환자번호 검색 
        /// </summary>
        private void OpenScreen_OUT0101Q01()
        {
            CommonItemCollection param = new CommonItemCollection();

            XScreen.OpenScreenWithParam(this, "OUTS", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS6000U01(string aBunho, string aFkinp1001, string aIpwonDate)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("fkinp1001", aFkinp1001);
            param.Add("ipwon_date", aIpwonDate);

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS6000U01", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 내복약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U10(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layDrgOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 주사약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U12(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);

            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 검체검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U13(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);

            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 생리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U14(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);

            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 병리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U15(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);

            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 화상진단 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U16(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);

            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 처치오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U17(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);

            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID); 
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 수술오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U18(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);

            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 기타오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U19(string aCpMasterKey, string aOrderDate, string aJaewonIl, string aCpCode, string aCpPathCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", aOrderDate);
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IOEGUBUN);
            param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            param.Add("input_part", this.mInputGwa);

            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.Name);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.CpOrder);
            param.Add("jaewonil", aJaewonIl);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("cp_master_key", aCpMasterKey);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS6010U10()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("fkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 의사 지시사항 조회
        /// </summary>
        private void OpenScreen_OCS2005U00(string aFkocs6010, string aCpCode, string aCpPathCode, string aPlanOrderDate, string aInputGubun, string aDirectMode, string aJaewonil)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("fkocs6010", aFkocs6010);
            param.Add("cp_code", aCpCode);
            param.Add("cp_path_code", aCpPathCode);
            param.Add("plan_order_date", aPlanOrderDate);
            param.Add("input_gubun", aInputGubun);
            param.Add("direct_mode", aDirectMode);
            param.Add("jaewonil", aJaewonil);
            param.Add("input_gwa",  mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());          // inp1001에 있는 과
            param.Add("input_doctor", mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());     // inp1001에 있는 닥터

            MultiLayout layOCS6015 = this.grdOCS6015.CloneToLayout();
            foreach (DataRow row6015 in this.grdOCS6015.LayoutTable.Rows)
            {
                layOCS6015.LayoutTable.ImportRow(row6015);
            }

            MultiLayout layOCS6016 = this.grdOCS6016.CloneToLayout();
            foreach (DataRow row6016 in this.grdOCS6016.LayoutTable.Rows)
            {
                layOCS6016.LayoutTable.ImportRow(row6016);
            }

            param.Add("DIRECT", layOCS6015);
            param.Add("DIRECT_DETAIL", layOCS6016);

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_ScanViewer(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "CPLS", "SCANVIEWER", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_XRT0000Q00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
        }

        private void OpenScreen_CPL0000Q00(string aBunho)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }

        private void OpenScreen_INJ0000Q00(string aBunho)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "INJS", "INJ0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }

        #endregion

        #region [ 그리드에 데이터 넣기 ]

        private bool InsertOCS6012NewRow(int aCurrentRow)
        {
            bool isMove = false;

            int newRow = this.grdOCS6012.InsertRow(aCurrentRow);

            //this.grdOCS6012.SetItemValue(newRow, "hosp_code", EnvironInfo.HospCode);
            this.grdOCS6012.SetItemValue(newRow, "fkocs6010", this.grdOCS6010.GetItemString(grdOCS6010.CurrentRowNumber, "pkocs6010"));
            this.grdOCS6012.SetItemValue(newRow, "cp_code", this.grdOCS6010.GetItemString(grdOCS6010.CurrentRowNumber, "cp_code"));
            //this.grdOCS6002.SetItemValue(newRow, "cp_path_code", (newRow + 1).ToString());
            //this.grdOCS6002.SetItemValue(newRow, "jaewonil", (newRow + 1).ToString());

            return true;
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

            if (this.grdOCS6010.RowCount > 0 && this.grdOCS6010.CurrentRowNumber >= 0)
            {
                this.LoadOCS6012(this.grdOCS6010.GetItemString(this.grdOCS6010.CurrentRowNumber, "pkocs6010"));

                this.MakeDayTree(-1);
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

                    this.SetInputGubunColor(layQueryLayout.LayoutTable);
                }
                else
                {
                    this.pnlOrder.Visible = false;
                    this.pnlJisi.Visible = true;

                    this.SetInputGubunColor(this.grdOCS6015.LayoutTable);
                }

                this.tabInputGubun_SelectionChanged(this.tabInputGubun, new EventArgs());
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

        #region XFindBox

        #region 환자번호 파인드박스

        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            this.OpenScreen_OUT0101Q01();
        }

        private void fbxBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string bunho = "";
            object postCallArguments;

            // 환자변경시 초기화 모듈
            this.InitializeBunho(false);

            if (e.DataValue == "")
            {
                this.SetMsg("");
                return;
            }

            bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);

            // 환자정보 로드해 봅시다....
            // 파라미터 셋팅
            this.mPatientInfoParam.NaewonDate = this.mOrderDate;
            this.mPatientInfoParam.NaewonKey = this.mParamNaewonKey;
            this.mPatientInfoParam.InputID = UserInfo.DoctorID;
            this.mPatientInfoParam.IOEGubun = IOEGUBUN; // 입원
            this.mPatientInfoParam.Bunho = bunho;
            this.mPatientInfoParam.IsEnableIpwonReser = true;

            this.mSelectedPatientInfo.Parameter = this.mPatientInfoParam;

            if (this.mSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NaewonBaseInfo) == false)
            {
                this.mMsg = "オーダ権限がありません｡";
                this.mCap = "患者番号確認";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.SetMsg(this.mMsg, MsgType.Error);

                postCallArguments = new Hashtable();

                ((Hashtable)postCallArguments).Add("success_yn", "N");
                ((Hashtable)postCallArguments).Add("bunho", bunho);

                PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

                return;
            }

            // 재원환자 체크 
            if (this.mOrderBiz.IsJaewonPatient(bunho, true) == false)
            {
                this.mMsg = "現在入院中の患者様ではありません。入院オーダは使用できません｡";
                this.mCap = "患者番号確認";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.SetMsg(this.mMsg, MsgType.Error);

                postCallArguments = new Hashtable();

                ((Hashtable)postCallArguments).Add("success_yn", "N");
                ((Hashtable)postCallArguments).Add("bunho", bunho);

                PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

                return;
            }

            // 기타 사항들 체크 및 visible 셋팅
            this.CheckPatientEtcInfo(this.mOrderDate, bunho
                                    , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

            // 환자정보 라벨들 셋팅
            this.SetPatientInfoLabel(this.mSelectedPatientInfo.GetPatientInfo);

            // Patient Info Box Setting 
            this.paInfoBox.SetPatientID(bunho);

            postCallArguments = new Hashtable();
            ((Hashtable)postCallArguments).Add("success_yn", "Y");
            ((Hashtable)postCallArguments).Add("bunho", bunho);

            PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);


        }

        #endregion

        #endregion

        #region [ 버튼 이벤트 ]

        // CP적용 버튼
        private void btnApplyCP_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            this.OpenScreen_OCS6000U01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());
        }

        #region 오더 입력 버튼 

        private void btnDrgOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U10(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        private void btnJusaOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U12(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        private void btnCplOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U13(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        private void btnPfeOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U14(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        private void btnAplOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U15(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        private void btnXrtOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U16(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        private void btnChuchiOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U17(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        private void btnSusulOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U18(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        private void btnEtcOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            Hashtable nodeInfo = this.tvwJaewonIL.SelectedNode.Tag as Hashtable;

            this.OpenScreen_OCS0103U19(nodeInfo["fkocs6010"].ToString(), nodeInfo["plan_order_date"].ToString(), nodeInfo["jaewonil"].ToString(), nodeInfo["cp_code"].ToString(), nodeInfo["cp_path_code"].ToString());
        }

        #endregion

        private void btnChiryoKeikaku_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            this.OpenScreen_OCS6010U10();
        }

        private void btnDoctorJisi_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.tvwJaewonIL.SelectedNode == null) return;

            this.OpenScreen_OCS2005U00(this.grdOCS6012.GetItemString(grdOCS6012.CurrentRowNumber, "fkocs6010")
                                      , this.grdOCS6012.GetItemString(grdOCS6012.CurrentRowNumber, "cp_code")
                                      , this.grdOCS6012.GetItemString(grdOCS6012.CurrentRowNumber, "cp_path_code")
                                      , this.grdOCS6012.GetItemString(grdOCS6012.CurrentRowNumber, "plan_order_date")
                                      , this.tabInputGubun.SelectedTab.Tag.ToString()
                                      , "1"
                                      , this.grdOCS6012.GetItemString(grdOCS6012.CurrentRowNumber, "jaewonil"));   //  6010
        }

        private void btnAddJaewonIl_Click(object sender, EventArgs e)
        {
            this.InsertOCS6012NewRow(-1);

            int currentRowNum = this.grdOCS6012.CurrentRowNumber;

            if (this.UpdateOCS6012() == true)
            {
                this.LoadOCS6012(this.grdOCS6010.GetItemString(grdOCS6010.CurrentRowNumber, "pkocs6010"));

                if (this.grdOCS6012.RowCount > 0)
                    this.MakeDayTree(currentRowNum);
                else
                    this.ResetAllOrderTemp();
            }
        }

        private void btnDelJaewonIl_Click(object sender, EventArgs e)
        {
            if (this.grdOCS6012.CurrentRowNumber < 0) return;

            int currentRowNumber = this.grdOCS6012.CurrentRowNumber;

            this.grdOCS6012.DeleteRow(this.grdOCS6012.CurrentRowNumber);

            if (this.UpdateOCS6012() == true)
            {
                if (currentRowNumber > this.grdOCS6012.RowCount - 1)
                    currentRowNumber = this.grdOCS6012.RowCount - 1;


            }

            this.LoadOCS6012(this.grdOCS6010.GetItemString(this.grdOCS6010.CurrentRowNumber, "pkocs6010"));

            if (this.grdOCS6012.RowCount > 0)
                this.MakeDayTree(currentRowNumber);
            else
                this.ResetAllOrderTemp();
        }

        #endregion

        #region [ 버튼 리스트 이벤트 ]

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            string msg = "";
            string cap = "";

            switch (e.Func)
            {
                case FunctionType.Query:    // 조회

                    e.IsBaseCall = false;

                    if (this.AcceptData() == false) return;

                    // 환자 선택 여부
                    if (this.IsPatientSelected() == false) return;

                    // 조회 전 클리어
                    InitializeOrderInfo();
                    // 조회 시작 
                    this.LoadOCS6010(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
                    

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    this.AcceptData();

                    if (this.MergeToSaveLayout() == false) return;

                    if (this.OrderValidationCheck() == false) return;

                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        Service.BeginTransaction();

                        // 삭제 먼저 실시
                        if (this.layDeletedData.RowCount > 0)
                        {
                            if (this.layDeletedData.SaveLayout() == false)
                            {
                                // 저장에 실패하였습니다. 
                                msg = XMsg.GetMsg("M005");
                                msg += "-" + Service.ErrFullMsg;
                                cap = XMsg.GetField("F001");

                                MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                Service.RollbackTransaction();
                                return;
                            }
                        }

                        // 업데이트 인서트 실시
                        if (this.laySaveLayout.RowCount > 0)
                        {
                            if (this.laySaveLayout.SaveLayout() == false)
                            {
                                // 저장에 실패하였습니다. 
                                msg = XMsg.GetMsg("M005");
                                msg += "-" + Service.ErrFullMsg;
                                cap = XMsg.GetField("F001");

                                MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                Service.RollbackTransaction();
                                return;
                            }
                        }

                        if (this.grdOCS6010.SaveLayout() == false)
                        {
                            // 저장에 실패하였습니다. 
                            msg = XMsg.GetMsg("M005");
                            msg += "-" + Service.ErrFullMsg;
                            cap = XMsg.GetField("F001");

                            MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            Service.RollbackTransaction();
                            return;
                        }

                        // OCS6015 & OCS6016 저장   // 20110214 KHJ
                        if (this.SaveOCS6015() == false)
                        {
                            // 저장에 실패하였습니다. 
                            msg = XMsg.GetMsg("M005");
                            msg += "-" + Service.ErrFullMsg;
                            cap = XMsg.GetField("F001");

                            MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            Service.RollbackTransaction();
                            return;
                        }

                        Service.CommitTransaction();

                        grdOCS6015.ResetUpdate();
                        grdOCS6016.ResetUpdate();
                        layDrgOrder.ResetUpdate();
                        layJusaOrder.ResetUpdate();
                        layEtcOrder.ResetUpdate();
                        layPfeOrder.ResetUpdate();
                        laySusulOrder.ResetUpdate();
                        layXrtOrder.ResetUpdate();
                        layAplOrder.ResetUpdate();
                        layChuchiOrder.ResetUpdate();
                        layCplOrder.ResetUpdate();

                        this.btnList.PerformClick(FunctionType.Query);
                        
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }

                    break;
            }
        }

        #endregion

        #region [ 트리뷰 이벤트 ]

        private void tvwJaewonIL_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            Hashtable nodeInfo = e.Node.Tag as Hashtable;

            this.grdOCS6012.SetFocusToItem(int.Parse(nodeInfo["row_num"].ToString()), 0);
        }

        #endregion

        #region 그리드 이벤트

        #region CP Master 그리드

        private void grdOCS6010_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            if (e.CurrentRow < 0) return;

            this.LoadOCS6012(grid.GetItemString(e.CurrentRow, "pkocs6010"));

            this.MakeDayTree(-1);
        }

        private void grdOCS6010_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (e.ColName == "cp_end_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    grid.SetItemValue(e.RowNumber, "cp_end_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                }
                else
                {
                    grid.SetItemValue(e.RowNumber, "cp_end_date", "");
                }
            }
        }

        #endregion

        #region 재원일 그리드

        private void grdOCS6012_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.LoadOCS6013(this.grdOCS6010.GetItemString(grdOCS6010.CurrentRowNumber, "pkocs6010"), grdOCS6012.GetItemString(e.CurrentRow, "jaewonil"));

            this.LoadOCS6015(this.grdOCS6010.GetItemString(grdOCS6010.CurrentRowNumber, "pkocs6010"), grdOCS6012.GetItemString(e.CurrentRow, "cp_code"), grdOCS6012.GetItemString(e.CurrentRow, "cp_path_code"), grdOCS6012.GetItemString(e.CurrentRow, "jaewonil"), grdOCS6012.GetItemString(e.CurrentRow, "plan_order_date"));

            // 오더 조회후 input tab별로 화면 Display
            this.SetRowJisiDataVisible(tabInputGubun.SelectedTab.Tag.ToString());                               // 지시사항
            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab); // 오더
        }

        #endregion

        #endregion

        #endregion

        #region [ Post 이벤트 메소드들... ]

        /// <summary>
        /// 환자번호 벨리데이팅 후 타게되는 메소드
        /// </summary>
        /// <param name="aArguments">Hashtable : [success_yn]  벨리데이션 성공여부, [bunho] 9자리 환자번호 </param>
        private void PostBunhoValidating(object aArguments)
        {
            Hashtable arguments = aArguments as Hashtable;

            if (arguments["success_yn"].ToString() != "Y")
            {

                this.fbxBunho.SetDataValue("");

                this.InitializeBunho(false);
            }
            else
            {
                this.fbxBunho.SetDataValue(arguments["bunho"].ToString());

                this.btnList.PerformClick(FunctionType.Query);
            }
        }

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
                                WHERE HOSP_CODE = '" + EnvironInfo.HospCode + @"'
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
                        targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "TYPE=1";

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
                        targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "TYPE=2";

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

                case "3":  // 심전도 결과 조회

                    if (this.IsPatientSelected() == true)
                    {
                        EkgCallHelper.CallViewer(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                    }

                    break;
            }
        }

        private void btnENDOResult_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected())
            {
                this.mMenuPFEResult.TrackPopup(this.xPanel3.PointToScreen(new Point(button.Location.X, button.Location.Y)));
            }
        }

        #endregion

        #region [ 이미지 결과 조회 ]

        private void btnImageResult_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_ScanViewer(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        #endregion

        #region [ 검체검사 결과 조회 ]

        private void btnCplResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false)
                return;

            this.OpenScreen_CPL0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        #endregion

        #region [ 방사선 결과 조회 ]

        private void btnXRTResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false)
                return;

            this.OpenScreen_XRT0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        #endregion

        #region [ 주사 경과 기록 ]

        private void btnJusaResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false)
                return;

            this.OpenScreen_INJ0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
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
                                this.layDeletedOCS6015.LayoutTable.ImportRow(dr);
                            }
                        }

                        // 입력 구분
                        if (commandParam.Contains("DIRECT"))
                        {
                            this.grdOCS6015.Reset();
                            foreach (DataRow dr in ((MultiLayout)commandParam["DIRECT"]).LayoutTable.Rows)
                            {
                                this.grdOCS6015.LayoutTable.ImportRow(dr);
                            }
                            this.grdOCS6015.DisplayData();
                        }

                        // 삭제 디테일
                        if (commandParam.Contains("DELETEDIRECTDETAIL"))
                        {
                            //this.layDeletedOCS6006.Reset();
                            foreach (DataRow dr in ((MultiLayout)commandParam["DELETEDIRECTDETAIL"]).LayoutTable.Rows)
                            {
                                this.layDeletedOCS6016.LayoutTable.ImportRow(dr);
                            }
                        }

                        // 입력 디테일
                        if (commandParam.Contains("DIRECTDETAIL"))
                        {
                            this.grdOCS6016.Reset();
                            foreach (DataRow dr in ((MultiLayout)commandParam["DIRECTDETAIL"]).LayoutTable.Rows)
                            {
                                this.grdOCS6016.LayoutTable.ImportRow(dr);
                            }
                            this.grdOCS6016.DisplayData();
                        }

                    }

                    #endregion

                    break;

                case "OCS6000U01": // CP적용

                    #region CP 적용

                    if (commandParam.Contains("cp_code"))
                    {
                        string applyCpCode = commandParam["cp_code"].ToString();
                        int applyRow = -1;

                        this.btnList.PerformClick(FunctionType.Query);

                        for (int i = 0; i < this.grdOCS6010.RowCount; i++)
                        {
                            if (this.grdOCS6010.GetItemString(i, "cp_code") == applyCpCode)
                            {
                                applyRow = i;
                                break;
                            }
                        }

                        this.grdOCS6010.SetFocusToItem(applyRow, "cp_code", false);
                    }

                    #endregion

                    break;
            }

            return base.Command(command, commandParam);
        }
            
        #endregion

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mOrderBiz.GridDisplayValue((XGrid)this  .CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void grdOCS6012_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            if (this.ExistModifiedOrder() == true)
            {
                DialogResult result = MessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    this.btnList.PerformClick(FunctionType.Update);
            }
        }

        private void OCS6010U00_Closing(object sender, CancelEventArgs e)
        {
            if (this.ExistModifiedOrder() == true)
            {
                DialogResult result = MessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    this.btnList.PerformClick(FunctionType.Update);
            }
        }





        #region [ SaveOCS6015 & 6006 ]
        /// <summary>
        /// CP 지시사항 저장 처리
        /// </summary>
        /// <returns>bool</returns>
        private bool SaveOCS6015()
        {
            try
            {
                Service.BeginTransaction();

                // -- OCS6015 ---------------------------------------------------------------------------------------------------

                foreach (DataRow row in grdOCS6015.LayoutTable.Rows)
                {
                    string cmdText = string.Empty;
                    BindVarCollection bindVars = new BindVarCollection();
                    bindVars.Add("q_user_id",        UserInfo.UserID);
                    bindVars.Add("f_hosp_code",      EnvironInfo.HospCode);

                    bindVars.Add("f_fkocs6010",      grdOCS6010.GetItemString(grdOCS6010.CurrentRowNumber, "pkocs6010"));
                    bindVars.Add("f_pkocs6015",      row["pkocs6015"].ToString());

                    bindVars.Add("f_cp_code",        row["cp_code"].ToString());
                    bindVars.Add("f_cp_path_code",   row["cp_path_code"].ToString());
                    bindVars.Add("f_jaewonil",       row["jaewonil"].ToString());
                    bindVars.Add("f_input_gubun",    row["input_gubun"].ToString());
                    bindVars.Add("f_pk_seq",         row["pk_seq"].ToString());
                    bindVars.Add("f_input_id",       UserInfo.UserID);
                    bindVars.Add("f_direct_gubun",   row["direct_gubun"].ToString());
                    bindVars.Add("f_direct_code",    row["direct_code"].ToString());
                    bindVars.Add("f_direct_detail",  row["direct_detail"].ToString());
                    bindVars.Add("f_direct_detail2", row["direct_detail2"].ToString());
                    bindVars.Add("f_direct_text",    row["direct_text"].ToString());
                    bindVars.Add("f_plan_from_date", row["drt_from_date"].ToString());
                    bindVars.Add("f_plan_to_date",   row["drt_to_date"].ToString());
                    bindVars.Add("f_continue_yn",    row["continue_yn"].ToString());
                    bindVars.Add("f_input_gwa",      row["input_gwa"].ToString());
                    bindVars.Add("f_input_doctor",   row["input_doctor"].ToString());

                    switch (row.RowState)
                    {
                        case DataRowState.Added:

                            cmdText = @"INSERT INTO OCS6015
                                             ( SYS_DATE       , SYS_ID          , UPD_DATE         , UPD_ID            ,
                                               HOSP_CODE      , PKOCS6015       , FKOCS6010        , CP_CODE           ,
                                               CP_PATH_CODE   , JAEWONIL        , INPUT_GUBUN      , PK_SEQ            ,
                                               INPUT_ID       , DIRECT_GUBUN    , DIRECT_CODE      , PLAN_FROM_DATE    ,
                                               PLAN_TO_DATE   , DIRECT_DETAIL   , DIRECT_DETAIL2   , DIRECT_TEXT       ,
                                               CONTINUE_YN    , INPUT_GWA       , INPUT_DOCTOR        )
                                        VALUES
                                             ( SYSDATE        , :q_user_id      , SYSDATE          , :q_user_id        ,
                                               :f_hosp_code   , :f_pkocs6015    , :f_fkocs6010     , :f_cp_code        ,
                                               :f_cp_path_code, :f_jaewonil     , :f_input_gubun   , :f_pk_seq         ,
                                               :f_input_id    , :f_direct_gubun , :f_direct_code   , :f_plan_from_date ,
                                               :f_plan_to_date, :f_direct_detail, :f_direct_detail2, :f_direct_text    ,
                                               :f_continue_yn , :f_input_gwa    , :f_input_doctor     )";

                            break;
                        case DataRowState.Modified:

                            cmdText = @"UPDATE OCS6015
                                           SET UPD_DATE       = SYSDATE
                                             , UPD_ID         = :q_user_id
                                             , INPUT_ID       = :f_input_id
                                             , DIRECT_GUBUN   = :f_direct_gubun
                                             , DIRECT_CODE    = :f_direct_code
                                             , PLAN_FROM_DATE = :f_plan_from_date
                                             , PLAN_TO_DATE   = :f_plan_to_date
                                             , DIRECT_DETAIL  = :f_direct_detail
                                             , DIRECT_DETAIL2 = :f_direct_detail2
                                             , DIRECT_TEXT    = :f_direct_text
                                             , CONTINUE_YN    = :f_continue_yn
                                             , INPUT_GWA      = :f_input_gwa
                                             , INPUT_DOCTOR   = :f_input_doctor
                                         WHERE HOSP_CODE      = :f_hosp_code
                                           AND PKOCS6015      = :f_pkocs6015";
                            break;
                    }

                    if (!TypeCheck.IsNull(cmdText))
                    {
                        if (!Service.ExecuteNonQuery(cmdText, bindVars)) throw new Exception(Service.ErrFullMsg);
                    }
                }

                #region delete

                if (layDeletedOCS6016.RowCount > 0)
                {
                    foreach (DataRow row in layDeletedOCS6016.LayoutTable.Rows)
                    {
                        string cmdText = string.Empty;
                        BindVarCollection bindVars = new BindVarCollection();
                        bindVars.Add("f_hosp_code",      EnvironInfo.HospCode);
                        bindVars.Add("f_cp_code",        row["cp_code"].ToString());
                        bindVars.Add("f_cp_path_code",   row["cp_path_code"].ToString());
                        bindVars.Add("f_jaewonil",       row["jaewonil"].ToString());
                        bindVars.Add("f_input_gubun",    row["input_gubun"].ToString());
                        bindVars.Add("f_pk_seq",         row["pk_seq"].ToString());
                        bindVars.Add("f_seq",            row["seq"].ToString());

                        bindVars.Add("f_pkocs6016",      row["pkocs6016"].ToString());

                        cmdText = @"DELETE OCS6016
                                     WHERE HOSP_CODE     = :f_hosp_code
                                       AND PKOCS6016     = :f_pkocs6016";

                        if (!Service.ExecuteNonQuery(cmdText, bindVars))
                        {
                            throw new Exception(Service.ErrFullMsg);
                        }
                    }
                    layDeletedOCS6016.Reset();
                }

                if (layDeletedOCS6015.RowCount > 0)
                {
                    foreach (DataRow row in layDeletedOCS6015.LayoutTable.Rows)
                    {
                        string cmdText = string.Empty;
                        string cmdTextD = string.Empty;
                        BindVarCollection bindVars = new BindVarCollection();
                        bindVars.Add("f_hosp_code",      EnvironInfo.HospCode);
                        bindVars.Add("f_cp_code",        row["cp_code"].ToString());
                        bindVars.Add("f_cp_path_code",   row["cp_path_code"].ToString());
                        bindVars.Add("f_jaewonil",       row["jaewonil"].ToString());
                        bindVars.Add("f_input_gubun",    row["input_gubun"].ToString());
                        bindVars.Add("f_pk_seq",         row["pk_seq"].ToString());

                        bindVars.Add("f_pkocs6015",      row["pkocs6015"].ToString());

                        cmdText = @"DELETE OCS6015
                                     WHERE HOSP_CODE     = :f_hosp_code
                                       AND PKOCS6015     = :f_pkocs6015";

                        cmdTextD = @"DELETE OCS6016
                                      WHERE HOSP_CODE    = :f_hosp_code
                                        AND FKOCS6015    = :f_pkocs6015";

                        if (!Service.ExecuteNonQuery(cmdText, bindVars)) throw new Exception(Service.ErrFullMsg);
                        if (!Service.ExecuteNonQuery(cmdTextD, bindVars)) throw new Exception(Service.ErrFullMsg);
                    }
                    layDeletedOCS6015.Reset();
                }
                #endregion

                // -- OCS6016 ---------------------------------------------------------------------------------------------------
                if (grdOCS6016.RowCount > 0)
                {
                    foreach (DataRow row in grdOCS6016.LayoutTable.Rows)
                    {
                        string cmdText = string.Empty;
                        BindVarCollection bindVars = new BindVarCollection();
                        bindVars.Add("q_user_id",        UserInfo.UserID);
                        bindVars.Add("f_hosp_code",      EnvironInfo.HospCode);
                        bindVars.Add("f_fkocs6010",      row["fkocs6010"].ToString());
                        bindVars.Add("f_fkocs6015",      row["fkocs6015"].ToString());
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
                        bindVars.Add("f_fk_ocs2006seq",  row["fk_ocs2006seq"].ToString());


                        switch (row.RowState)
                        {
                            case DataRowState.Added:

                                bindVars.Add("f_pkocs6016", Service.ExecuteScalar("SELECT OCS6016_SEQ.NEXTVAL FROM DUAL").ToString());

                                cmdText = @"INSERT INTO OCS6016
                                                 ( SYS_DATE         , SYS_ID          , UPD_DATE         , UPD_ID           ,
                                                   HOSP_CODE        , PKOCS6016       , FKOCS6010        , FKOCS6015        ,
                                                   CP_CODE          , CP_PATH_CODE    , JAEWONIL         , INPUT_GUBUN      ,
                                                   PK_SEQ           , SEQ             , DIRECT_GUBUN     , DIRECT_CODE      ,
                                                   DIRECT_DETAIL    , HANGMOG_CODE    , SURYANG          , NALSU            ,
                                                   ORD_DANUI        , BOGYONG_CODE    , JUSA_CODE        , JUSA_SPD_GUBUN   ,
                                                   DV               , DV_TIME         , INSULIN_FROM     , INSULIN_TO       ,
                                                   TIME_GUBUN       , BOM_YN          , BOM_SOURCE_KEY   , FK_OCS2006SEQ    )
                                            VALUES
                                                 ( SYSDATE          , :q_user_id      , SYSDATE          , :q_user_id       ,
                                                   :f_hosp_code     , :f_pkocs6016    , :f_fkocs6010     , :f_fkocs6015     ,
                                                   :f_cp_code       , :f_cp_path_code , :f_jaewonil      , :f_input_gubun   ,
                                                   :f_pk_seq        , :f_seq          , :f_direct_gubun  , :f_direct_code   ,
                                                   :f_direct_detail , :f_hangmog_code , :f_suryang       , :f_nalsu         ,
                                                   :f_ord_danui     , :f_bogyong_code , :f_jusa_code     , :f_jusa_spd_gubun,
                                                   :f_dv            , :f_dv_time      , :f_insulin_from  , :f_insulin_to    ,
                                                   :f_time_gubun    , :f_bom_yn       , :f_bom_source_key, :f_fk_ocs2006seq )";

                                break;
                            case DataRowState.Modified:

                                bindVars.Add("f_pkocs6016", row["pkocs6016"].ToString());

                                cmdText = @"UPDATE OCS6016
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
                                             WHERE HOSP_CODE      = :f_hosp_code
                                               AND PKOCS6016      = :f_pkocs6016";

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
                XMessageBox.Show(xe.Message, "SaveOCS6015 Error!");
                return false;
            }
            Service.CommitTransaction();

            return true;
        }
        #endregion

        private void grdOCS6015_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            switch (e.ColName)
            {
                case "continue_yn":
                    if (e.ChangeValue.ToString() == "Y")
                    {
                        grdOCS6015.SetItemValue(e.RowNumber, "drt_to_date", "");
                    }
                    break;

                case "drt_to_date":
                    if (e.ChangeValue.ToString().Trim() != "")
                    {
                        grdOCS6015.SetItemValue(e.RowNumber, "continue_yn", "N");
                    }
                    break;
            }
        }

        /// <summary>
        /// CP削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdOCS6010_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            object retVal = new object();
            bindVars.Add("f_bunho", grdOCS6010.GetItemString(e.RowNumber, "bunho"));
            bindVars.Add("f_order_date", grdOCS6010.GetItemString(e.RowNumber, "app_date"));
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

            cmdText = @"SELECT COUNT(ACTING_DATE)
                          FROM OCS2003
                         WHERE HOSP_CODE = :f_hosp_code
                           AND SYS_ID    = 'CP'
                           AND TRUNC(ORDER_DATE) = TRUNC(TO_DATE(:f_order_date))
                           AND BUNHO     = :f_bunho";

            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (retVal.ToString() != "0")
            {
                XMessageBox.Show("既に実施されたオーダがある為、削除はできません。", "削除不可", MessageBoxIcon.Hand);
                return;
            }
            
            DialogResult dgResult = new DialogResult();
            dgResult = XMessageBox.Show("選択したCPコードを削除します。よろしいですか？", "削除", MessageBoxButtons.YesNo);

            if (dgResult == DialogResult.Yes)
            {
                try
                {
                    Service.BeginTransaction();
                    cmdText = @"BEGIN
                                    DELETE OCS6016 WHERE FKOCS6010 IN (SELECT PKOCS6010 FROM OCS6010 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND TRUNC(TO_DATE(:f_order_date)) = TRUNC(APP_DATE));
                                    DELETE OCS6015 WHERE FKOCS6010 IN (SELECT PKOCS6010 FROM OCS6010 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND TRUNC(TO_DATE(:f_order_date)) = TRUNC(APP_DATE));
                                    DELETE OCS6013 WHERE FKOCS6010 IN (SELECT PKOCS6010 FROM OCS6010 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND TRUNC(TO_DATE(:f_order_date)) = TRUNC(APP_DATE));
                                    DELETE OCS6012 WHERE FKOCS6010 IN (SELECT PKOCS6010 FROM OCS6010 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND TRUNC(TO_DATE(:f_order_date)) = TRUNC(APP_DATE));
                                    DELETE OCS6010 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND TRUNC(TO_DATE(:f_order_date)) = TRUNC(APP_DATE);
                                    DELETE FROM OCS2003 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND TRUNC(TO_DATE(:f_order_date)) = TRUNC(ORDER_DATE) AND SYS_ID = 'CP';
                               END;";
                    Service.ExecuteNonQuery(cmdText, bindVars);
                }
                catch (Exception xe)
                {
                    XMessageBox.Show(xe.Message);
                    Service.RollbackTransaction();
                }

                Service.CommitTransaction();

                btnList.PerformClick(FunctionType.Query);
            }
        }
    }

    #region XSavePeformer
    public class XSavePeformer : ISavePerformer
    {
        private OCS6010U00 parent = null;
        private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS6010U00");

        public XSavePeformer(OCS6010U00 parent)
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
            if (item.BindVarList.Contains("f_hosp_code"))
                item.BindVarList.Remove("f_hosp_code");
            item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

            switch (callerId)
            {
                case '1':   // 재원일 추가 

                    #region 재원일

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            cmdText = " SELECT MAX(Z.JAEWONIL)+1 JAEWONIL "
                                    + "  FROM OCS6012 Z"
                                    + " WHERE Z.HOSP_CODE = " + EnvironInfo.HospCode + "' "
                                    + "   AND Z.FKOCS6010 = " + item.BindVarList["f_fkocs6010"].VarValue;

                            t_chk = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(t_chk) == true ||
                                t_chk.ToString() == "")
                            {
                                t_chk = "1";
                            }

                            if (item.BindVarList.Contains("f_jaewonil"))
                                item.BindVarList.Remove("f_jaewonil");
                            if (item.BindVarList.Contains("f_cp_path_code"))
                                item.BindVarList.Remove("f_cp_path_code");

                            item.BindVarList.Add("f_jaewonil", t_chk.ToString());
                            item.BindVarList.Add("f_cp_path_code", t_chk.ToString());

                            cmdText = " SELECT TO_CHAR(A.APP_DATE + TO_NUMBER('" + item.BindVarList["f_jaewonil"].VarValue + "') -1, 'YYYY/MM/DD') ORDER_DATE "
                                    + "   FROM OCS6010 A "
                                    + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                    + "    AND A.PKOCS6010 = " + item.BindVarList["f_fkocs6010"].VarValue;

                            t_chk = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(t_chk) == true ||
                                t_chk.ToString() == "")
                            {
                                return false;
                            }

                            if (item.BindVarList.Contains("f_plan_order_date"))
                                item.BindVarList.Remove("f_plan_order_date");
                            item.BindVarList.Add("f_plan_order_date", t_chk.ToString());

                            cmdText = @"INSERT INTO OCS6012
                                             ( SYS_DATE , SYS_ID         , UPD_DATE, UPD_ID
                                             , HOSP_CODE, FKOCS6010      , CP_CODE , CP_PATH_CODE
                                             , JAEWONIL , PLAN_ORDER_DATE, MENT    , ORD_OCCUR_GUBUN )
                                        VALUES 
                                             ( SYSDATE     , :q_user_id        , SYSDATE   , :q_user_id
                                             , :f_hosp_code, :f_fkocs6010      , :f_cp_code, :f_cp_path_code 
                                             , :f_jaewonil , :f_plan_order_date, :f_memt   , :f_ord_occur_gubun )";
                                             

                            break;

                        case DataRowState.Deleted:

                            cmdText = @" SELECT 'Y' 
                                           FROM SYS.DUAL
                                          WHERE EXISTS ( SELECT 'X'
                                                           FROM OCS6013
                                                          WHERE HOSP_CODE       = :f_hosp_code
                                                            AND FKOCS6010       = :f_fkocs6010
                                                            AND CP_CODE         = :f_cp_code 
                                                            AND CP_PATH_CODE    = :f_cp_path_code
                                                            AND JAEWONIL        = :f_jaewonil
                                                            AND PLAN_ORDER_DATE = :f_plan_order_date )
                                             OR EXISTS ( SELECT 'X'
                                                           FROM OCS6015 
                                                          WHERE HOSP_CODE       = :f_hosp_code
                                                            AND FKOCS6010       = :f_fkocs6010
                                                            AND CP_CODE         = :f_cp_code
                                                            AND CP_PATH_CODE    = :f_cp_path_code 
                                                            AND JAEWONIL        = :f_jaewonil        ) ";

                            t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if (TypeCheck.IsNull(t_chk) == false &&
                                t_chk.ToString().Trim() == "Y")
                            {
                                MessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }


                            cmdText = @" DELETE FROM OCS6012           
                                          WHERE HOSP_CODE       = :f_hosp_code
                                            AND FKOCS6010       = :f_fkocs6010
                                            AND CP_CODE         = :f_cp_code
                                            AND CP_PATH_CODE    = :f_cp_path_code
                                            AND JAEWONIL        = :f_jaewonil
                                            AND PLAN_ORDER_DATE = :f_plan_order_date ";
                                    

                            break;
                    }

                    #endregion

                    break;
                case '2':    // 삭제로직...

                    #region 오더 삭제

                    cmdText = " DELETE FROM OCS6013 "
                            + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                            + "    AND PKOCS6013 = :f_pkocskey ";



                    #endregion

                    break;

                case '3':    // 인서트 & 업데이트 

                    #region 오더 입력 및 변경

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            item.BindVarList.Add("f_input_gwa", UserInfo.Gwa);
                            item.BindVarList.Add("f_input_doctor", UserInfo.Gwa + UserInfo.UserID);
                            
                            // 키가 입력되지 않은경우 키를 따야함..
                            if (item.BindVarList["f_pkocskey"].VarValue == "")
                            {
                                cmdText = " SELECT OCS6013_SEQ.NEXTVAL "
                                        + "   FROM SYS.DUAL ";

                                t_chk = Service.ExecuteScalar(cmdText);

                                item.BindVarList.Remove("f_pkocskey");
                                item.BindVarList.Add("f_pkocskey", t_chk.ToString());
                            }

                            // 시퀀스 가져오기
                            if (item.BindVarList["f_seq"].VarValue == "")
                            {
                                cmdText = " SELECT MAX(SEQ)+1 SEQ "
                                        + "   FROM OCS6013 "
                                        + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                        + "    AND FKOCS6010 = " + item.BindVarList["f_in_out_key"].VarValue
                                        + "    AND PLAN_ORDER_DATE = TO_DATE('" + item.BindVarList["f_order_date"].VarValue + "', 'YYYY/MM/DD')";

                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", t_chk.ToString());
                            }

                            cmdText = @" INSERT INTO OCS6013                                                      
                                            ( SYS_DATE        , SYS_ID       , UPD_DATE       , PKOCS6013       
                                            , FKOCS6010       , JAEWONIL     , PLAN_ORDER_DATE, INPUT_GUBUN      
                                            , HANGMOG_CODE    , ORDER_GUBUN  , GROUP_SER      , SEQ              
                                            , SPECIMEN_CODE   , SURYANG      , ORD_DANUI      , DV_TIME          
                                            , DV              , NALSU        , JUSA           , BOGYONG_CODE     
                                            , EMERGENCY       , MUHYO        , PORTABLE_YN    , TOIWON_DRG_YN    
                                            , ANTI_CANCER_YN  , PAY          , PRN_YN         , POWDER_YN        
                                            , DV_1            , DV_2         , DV_3           , DV_4             
                                            , MIX_GROUP       , ORDER_REMARK , NURSE_REMARK   , REGULAR_YN       
                                            , JAERYO_JUNDAL_YN, JUNDAL_TABLE , JUNDAL_PART    , MOVE_PART        
                                            , INPUT_PART      , REF_FKOCS2003, INPUT_GWA      , INPUT_DOCTOR     
                                            , ORDER_END_YN    , INPUT_TAB    , HUBAL_CHANGE_YN, PHARMACY         
                                            , JUSA_SPD_GUBUN  , DRG_PACK_YN  
                                            , UPD_ID          , HOSP_CODE      
                                            , ACT_DOCTOR      , ACT_BUSEO    , ACT_GWA        
                                            , BOM_SOURCE_KEY  , FKOCS2003    , INPUT_ID       , CP_CODE          , CP_PATH_CODE )                  
                                       VALUES                                                                    
                                            ( SYSDATE             , :q_user_id     , SYSDATE           , :f_pkocskey      
                                            , :f_in_out_key       , :f_jaewonil    , :f_order_date     , :f_input_gubun   
                                            , :f_hangmog_code     , :f_order_gubun , :f_group_ser      , :f_seq           
                                            , :f_specimen_code    , :f_suryang     , :f_ord_danui      , :f_dv_time       
                                            , :f_dv               , :f_nalsu       , :f_jusa           , :f_bogyong_code  
                                            , :f_emergency        , :f_muhyo       , :f_portable_yn    , :f_toiwon_drg_yn 
                                            , 'N'                 , :f_pay         , 'N'               , :f_powder_yn     
                                            , :f_dv1              , :f_dv2         , :f_dv3            , :f_dv4           
                                            , :f_mix_group        , :f_order_remark, :f_nurse_remark   , :f_regular_yn    
                                            , :f_jaeryo_jundal_yn , :f_jundal_table, :f_jundal_part    , :f_move_part     
                                            , :f_input_part       , NULL           , :f_input_gwa      , :f_input_doctor  
                                            , 'N'                 , :f_input_tab   , :f_hubal_change_yn, :f_pharmacy      
                                            , :f_jusa_spd_gubun   , :f_drg_pack_yn 
                                            , :q_user_id          , :f_hosp_code   
                                            , :f_act_doctor       , :f_act_buseo   , :f_act_gwa        
                                            , :f_bom_source_key   , NULL           , :f_input_id       , :f_cp_code, :f_cp_path_code) ";



                            break;

                        case DataRowState.Modified:

                            cmdText = @"UPDATE OCS6013
                                           SET UPD_DATE         = SYSDATE
                                             , UPD_ID           = :q_user_id
                                             , NALSU            = :f_nalsu
                                             , JUSA             = :f_jusa
                                             , BOGYONG_CODE     = :f_bogyong_code
                                             , EMERGENCY        = :f_emergency
                                             , JAERYO_JUNDAL_YN = :f_jaeryo_jundal_yn
                                             , JUNDAL_TABLE     = :f_jundal_table
                                             , JUNDAL_PART      = :f_jundal_part
                                             , MOVE_PART        = :f_move_part
                                             , MUHYO            = :f_muhyo
                                             , PORTABLE_YN      = :f_portable_yn
                                             , POWDER_YN        = :f_powder_yn
                                             , DV_1             = :f_dv_1
                                             , DV_2             = :f_dv_2
                                             , DV_3             = :f_dv_3
                                             , DV_4             = :f_dv_4
                                             , MIX_GROUP        = :f_mix_group
                                             , ORDER_REMARK     = :f_order_remark
                                             , NURSE_REMARK     = :f_nurse_remark
                                             , BOM_SOURCE_KEY   = :f_bom_source_key
                                             , REGULAR_YN       = :f_regular_yn
                                             , HUBAL_CHANGE_YN  = :f_hubal_change_yn
                                             , PHARMACY         = :f_pharmacy
                                             , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun
                                             , DRG_PACK_YN      = :f_drg_pack_yn
                                         WHERE HOSP_CODE        = '" + EnvironInfo.HospCode + @"'
                                           AND PKOCS6013        = :f_pkocskey";



                            break;

                    }

                    #endregion

                    break;

                case '4':    // CP 마스터

                    cmdText = @" UPDATE OCS6010
                                    SET CP_END_YN   = :f_cp_end_yn
                                      , CP_END_DATE = DECODE(NVL(:f_cp_end_yn, 'N'), 'N', NULL, :f_cp_end_date )
                                      , REMARK      = :f_remark
                                  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                                    AND PKOCS6010 = :f_pkocs6010 ";

                    break;
            }

            bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

            // '4' CP 이면서 성공이면 종료프로세스를 태운다.
            if (callerId == '4' && isSuccess)
            {
                string proName = "PR_OCS_APPLY_CP_END";
                inList.Clear();
                outList.Clear();

                inList.Add(item.BindVarList["f_pkocs6010"].VarValue);
                inList.Add(item.BindVarList["q_user_id"].VarValue);

                if (Service.ExecuteProcedure(proName, inList, outList) == true)
                {
                    if (outList[0].ToString() != "0")
                    {
                        isSuccess = false;
                    }
                    else
                    {
                        isSuccess = true;
                    }
                }
                else
                {
                    isSuccess = false;
                }
            }

            return isSuccess;
        }
    }
    #endregion
}