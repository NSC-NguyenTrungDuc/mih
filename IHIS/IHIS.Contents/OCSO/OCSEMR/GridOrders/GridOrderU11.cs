using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;

namespace GridOrders
{
    public partial class GridOrderU11 : UserControl
    {
        #region contructor
        public GridOrderU11()
        {
            InitializeComponent();
        }
        #endregion

        #region 2. Form변수를 정의한다

        private string mbxMsg = "", mbxCap = "";
        private string mHospCode = EnvironInfo.HospCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 라디오 버튼 관련 변수
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 오더 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int OrderExtendWidth = 1081;
        private int OrderExtendWidth = 1000;
        private int OrderNormalWidth = 846;
        private bool mIsExtended = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 조회부분 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int OrderMinWidth = 618;
        private bool mIsSearchExtended = false;

        private int SearchHangmogNameNormalWidth = 329;
        private int SearchHangmogNameMaxWidth = 468;

        private int SlipHangmogNameNormalWidth = 175;
        private int SlipHangmogNameMaxWidth = 314;

        private int SangYongHangmogNormalWidth = 330;
        private int SangYongHangmogMaxWidth = 466;

        ///////////// Order 기본값 /////////////////////////////////////////////////////////////////////////
        private const string INPUTTAB = "10"; // リハビリ (10) 
        private string IOEGUBUN = "O";     // 입외구분(외래)
        private string mInputGubun = "D0";    // 입력구분(의사처방)
        private string mInputGubunName = "";  // 입력구분명
        private string mInputPart = "";      // 입력파트
        private string mCallerSysID = "";
        private string mCallerScreenID = "";
        private int mInitialGroupSer = 1100;

        //공통
        private string mOrderDate = "";
        private MultiLayout mOrderLayout;
        private OrderVariables.OrderMode mOrderMode;
        private int mCurrentRow = -1;
        //입원외래 order
        private string mPkInOutKey = "";
        // 셋트오더 관련 _ 키
        private string mMemb = "";
        private string mYaksokCode = "";
        // CP관련 키
        private string mMembGubun = "";
        private string mCpCode = "";
        private string mJaewonil = "";
        private string mCpPathCode = "";
        private string mCpMasterkey = "";

        //insert by jc [OCS1003P01のデータウインドウから選択された際、自動ポイント移動に必要な変数]
        private int mCurrentRowNum = -1;
        private XDataWindow mCurrentDataWindow;
        private string mCurrentColName = "";
        private int mStartRowNum = -1;

        // 환자정보관련

        private bool mDoctorLogin = false;

        // 오더 정보 관련
        private DataTable mInDataRow;
        private DataTable mOutDataRow;

        private DataTable mLayDtOrderBuffer = null; // 처방 Copy & Paste용 Buffer DataTable

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////// OCS Library  /////////////////////////////////////////////////////////////////////////
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리
        private IHIS.OCS.PatientInfo mPatientInfo = null;     // OCS 환자정보 그룹 라이브러리 
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리 		
        private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
        private IHIS.OCS.CommonForms mCommonForms = null;     // OCS 공통Form's 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리
        private IHIS.OCS.OrderInterface mInterface = null;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////grd Drag //////////////////////////////////////////////////////////////////////////////
        private bool mIsDrag = false;
        private int mDragX = 0;
        private int mDragY = 0;
        private int mDragRowIndex = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////Popup Menu ////////////////////////////////////////////////////////////////////////////
        private IHIS.X.Magic.Menus.PopupMenu popupOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 처방Grid용
        private IHIS.X.Magic.Menus.PopupMenu popupOftenUsedMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 상용처방Grid용
        private IHIS.X.Magic.Menus.PopupMenu popupYaksokOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 약속처방Grid용
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Hashtable mHtControl = null;        // Control과 연결할 HashTable

        private bool mIsSuccessBtnList = true;      // 버튼리스트 로직 콜해서 성공여부를 가지고 있는다(PerformClick의 Return값이 없어서)

        private string mPk_Naewon = ""; // 내원/재원환자List에서 환자 선택한 내원/재원Key

        private DataTable mDtOrderGubun;

        // 저장을 하기 위한 Layout
        private Hashtable mSaveLayout;

        // Screen Open check
        private bool mScreenOpen = true;

        // 신규 탭 페이지 
        private IHIS.X.Magic.Controls.TabPage tpgNew = new IHIS.X.Magic.Controls.TabPage();

        // Load screen
        private OCS0103U11InitializeScreenResult loadScreenResult;

        // 임시 컬럼
        string mTemp = "";

        #endregion

        #region Field & properties

        #endregion

        #region 4. OnLoad 및 Main Screen Event를 정의한다

        /// <summary>
        /// 
        /// </summary>
        private void PostLoad()
        {
            //MessageBox.Show("PostLoad Start");

            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

            /*if (this.OpenParam != null) // 다른 화면에서 콜되는 경우
            {
                //this.btnList.PerformClick(FunctionType.Query);*/

            this.MakeGroupTabInfo(IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);
            /*}*/

            // MessageBox.Show(this.grdOrder.CurrentRowNumber.ToString());
            this.txtSearch.Focus();
            this.setFocusGotoColumn();
        }

        /// <summary>
        /// 해당 Screen의 각종 Control 관련 Setting
        /// </summary>
        private void InitializeScreen()
        {
            //저장에 필요한 Layout을 정의한다.
            mSaveLayout = new Hashtable();
            mSaveLayout.Add("OCS1003", this.grdOrder);

            //DatePicker 문제로 일단        Reset하고 현재일자를 넣어준다.
            //this.dpkOrder_Date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            /*if (this.dpkOrder_Date.GetDataValue() == "")
            {
                //this.dpkOrder_Date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                this.dpkOrder_Date.SetDataValue(DateTime.Parse(loadScreenResult.SysDate).ToString("yyyy/MM/dd"));
            }*/

            // 상용처방을 로드한다.
            //            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder) // = 1
            //            {
            //                // 유저별 공통 모드인데 이건 어쩔까...
            //                string name = "";
            //                this.mOrderBiz.LoadColumnCodeName("gwa_doctor", "%", this.mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref name);
            //
            //                if (name == "")
            //                {
            //                    // 주과의 상용오더를 가져오자.
            //                    string mainDoctorCode = this.mOrderBiz.GetMainGwaDoctorCode(this.mMemb);
            //                    if (mainDoctorCode != "")
            //                        this.MakeSangyongTab(mainDoctorCode, INPUTTAB);
            //                    else
            //                        this.MakeSangyongTab(mMemb, INPUTTAB);
            //                }
            //                else
            //                {
            //                    this.MakeSangyongTab(mMemb, INPUTTAB);
            //                }
            //            }
            //            else
            //            {
            //                // 상용처방을 로드한다.
            //                if (UserInfo.UserGubun == UserType.Doctor)
            //                {
            //                    this.MakeSangyongTab(UserInfo.DoctorID, INPUTTAB);
            //                }
            //                else
            //                    this.MakeSangyongTab(UserInfo.UserID, INPUTTAB);
            //            }
            this.MakeSangyongTab2(loadScreenResult.UsedTabInfo);
        }

        private void setFocusGotoColumn()
        {
            //insert by jc [OCS1003P01のデータウインドーウで選択されたROWがあった場合の処理]
            //位置検索はすべてhangmog_codeで検索する
            //コメントのROWにもOrderBizで該当するHangmog_codeを入れているので検索可能である。
            //カーソルのコントロールの際にはgrdOrderのグリドを同時に動かす。
            //pkocskeyは使えない。なぜかというとpkocskeyは保存される際、トリガーによって与えられるので保存されてない状態では使えないのだ

            int currentRow = -1;
            if (mCurrentRowNum > 0)
            {
                //[OCS1003P01のデータウインドウで選択されたcolumnのデータ取得]
                string currentData = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, this.mCurrentColName);
                //[OCS1003P01のデータウインドウで選択されたgroup_ser取得]
                string currentGroupSer = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "group_ser_num");

                //[該当するGROUPTABに移動]
                this.SelectGroupTab(currentGroupSer);

                if (this.mCurrentColName == "hangmog_name"
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_detail")
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_info"))
                {
                    //[OCS1003P01のデータウインドウで選択されたhangmog_name取得]
                    string currentHangmogCode = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "hangmog_code");

                    //[OCS1003P01のデータウインドウで選択されたデータの位置検索]
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.GetItemString(i, "hangmog_code") == currentHangmogCode && this.grdOrder.GetItemString(i, "group_ser") == currentGroupSer)
                        {
                            currentRow = i;
                            break;
                        }
                    }
                }

                switch (this.mCurrentColName)
                {
                    case "hangmog_name":
                        this.grdOrder.SetFocusToItem(currentRow, "hangmog_code", true);
                        break;
                    case "order_detail":
                        this.grdOrder.SetFocusToItem(currentRow, "suryang", true);
                        break;
                    case "order_info":
                        if (currentData.Substring(0, 1) == "└")
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "order_remark", true);
                        }
                        else if (currentData.Substring(1, 1) == "希")
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "hope_date", true);
                        }
                        break;
                }
            }
        }

        private void SelectGroupTab(string aGroupSer)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (((Hashtable)tpg.Tag)["group_ser"].ToString() == aGroupSer)
                {
                    this.tabGroup.SelectedTab = tpg;
                    return;
                }
            }
        }

        private void OCS0103U10_Closing(object sender, CancelEventArgs e)
        {
            string mbxMsg = "", mbxCap = "";

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

        #endregion

        #region [ 각종 비지니스 메소드 ]

        /// <summary>
        /// 그룹탭 선택시 그룹관련 정보들 셋팅
        /// </summary>
        /// <param name="aGroupInfo">그룹정보</param>
        private void SetGroupControl(Hashtable aGroupInfo)
        {
            // 긴급여부
            this.cbxEmergency.SetDataValue(aGroupInfo["emergency"].ToString());
        }

        /// <summary>
        /// 그룹정보 프로텍트 여부 
        /// </summary>
        /// <param name="aGroupSer">그룹시리얼</param>
        private void ProtectGroupControl(string aGroupSer)
        {
            DataRow[] dr = this.grdOrder.LayoutTable.Select("group_ser=" + aGroupSer);
            bool isProtect = false;

            for (int i = 0; i < dr.Length; i++)
            {
                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                    this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
                {
                    isProtect = false;
                    break;
                }

                //if (dr[i].RowState != DataRowState.Added && dr[i]["ocs_flag"].ToString() != "0" && dr[i]["ocs_flag"].ToString() != "1")
                if (dr[i].RowState != DataRowState.Added && (dr[i]["ocs_flag"].ToString() != "0" && dr[i]["ocs_flag"].ToString() != "1" || dr[i]["sunab_yn"].ToString() == "Y"))
                {
                    isProtect = true;
                    break;
                }
            }

            foreach (Control ctrl in this.pnlOrderDetail.Controls)
            {
                if (ctrl is IDataControl)
                {
                    ((IDataControl)ctrl).Protect = isProtect;
                }
            }
        }

        private void GridInitValueSetting(XEditGrid aGrid, int aRowNumber)
        {
            string temp = "";

            if (tabGroup.SelectedTab == null) return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그룹시리얼 셋팅
            if (groupInfo.Contains("group_ser"))
                aGrid.SetItemValue(aRowNumber, "group_ser", groupInfo["group_ser"].ToString());

            // 복용코드
            if (groupInfo.Contains("bogyong_code"))
                aGrid.SetItemValue(aRowNumber, "bogyong_code", groupInfo["bogyong_code"].ToString());

            // 긴급
            if (groupInfo.Contains("emergency"))
                aGrid.SetItemValue(aRowNumber, "emergency", groupInfo["emergency"].ToString());

            // 원외처방
            if (groupInfo.Contains("wonyoi_order_yn"))
                aGrid.SetItemValue(aRowNumber, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());

            // 환자정보
            if ((this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder) && this.mPatientInfo != null)
            {
                aGrid.SetItemValue(aRowNumber, "bunho", this.mPatientInfo.GetPatientInfo["bunho"].ToString());
            }

            // 입력탭 정보
            aGrid.SetItemValue(aRowNumber, "input_tab", INPUTTAB);
            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_TAB", INPUTTAB, ref temp);
            aGrid.SetItemValue(aRowNumber, "input_tab_name", temp);

            //aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);
            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);
            aGrid.SetItemValue(aRowNumber, "input_gubun", this.mInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", this.mInputGubunName);

            /*aGrid.SetItemValue(aRowNumber, "order_date", this.dpkOrder_Date.GetDataValue());*/

            // 진료정보 ( 오더일자, 진료과, 의사 )
            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                    aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                }
                else if (UserInfo.Gwa == "CK")
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                }
                else
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mPatientInfo.GetPatientInfo["doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mPatientInfo.GetPatientInfo["gwa"].ToString());

                    // 간호사인경우는 간호픽업 데이트를 자동입력한다.
                    if (UserInfo.UserGubun == UserType.Nurse)
                    {
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_user", UserInfo.UserID);
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }
                }


                aGrid.SetItemValue(aRowNumber, "input_id", UserInfo.UserID);

                aGrid.SetItemValue(aRowNumber, "gwa", this.mPatientInfo.GetPatientInfo["gwa"].ToString());
                aGrid.SetItemValue(aRowNumber, "doctor", this.mPatientInfo.GetPatientInfo["doctor"].ToString());
                aGrid.SetItemValue(aRowNumber, "resident", this.mPatientInfo.GetPatientInfo["doctor"].ToString());

                // 접수및 입원정보
                if (this.IOEGUBUN == "O")
                {
                    aGrid.SetItemValue(aRowNumber, "naewon_type", this.mPatientInfo.GetPatientInfo["naewon_type"].ToString());
                }

                if (this.mOrderMode == OrderVariables.OrderMode.CpOrder)
                {
                    aGrid.SetItemValue(aRowNumber, "cp_code", this.mCpCode);
                    aGrid.SetItemValue(aRowNumber, "cp_path_code", this.mCpPathCode);
                    aGrid.SetItemValue(aRowNumber, "jaewonil", this.mJaewonil);
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mCpMasterkey);
                }
                else
                {
                    // 접수 키
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);
                }
            }
            // 셋트오더인경우
            else
            {
                if (this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);

                aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                aGrid.SetItemValue(aRowNumber, "memb", this.mMemb);
                aGrid.SetItemValue(aRowNumber, "yaksok_code", this.mYaksokCode);

                if (this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
                {
                    aGrid.SetItemValue(aRowNumber, "memb_gubun", this.mMembGubun);
                    aGrid.SetItemValue(aRowNumber, "cp_code", this.mCpCode);
                    aGrid.SetItemValue(aRowNumber, "cp_path_code", this.mCpPathCode);
                    aGrid.SetItemValue(aRowNumber, "jaewonil", this.mJaewonil);
                }
            }


        }

        private void ApplyDefaultOrderInfo(MultiLayout aSourceLayout, int aSettingRow, bool aIsCallCodeInput)
        {
            int parentKey = -1;
            string ordergubunname = "";
            int settingRow = aSettingRow;
            Hashtable groupInfo = null;

            if (this.tabGroup.SelectedTab == null)
                /*this.btnList.PerformClick(FunctionType.Process);*/

                groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그리드 상에서 직접 입력할때와 뭔가를 통해 입력할때...
            // 어디다 집어 넣어야 할지에 대한 헷갈림...
            // 직접 넣을 때는 현재 로우에 무조건 넣어야 하는데...
            // 근데... 뭔가를 통해서 넣을때는 현재 로우에 데이터가 있으면 안되거덩...
            // 그래서 저 컬럼을 두고 aIsCallCodeInput 이 true이면 무조건 현재 로우에 넣는거야...
            // 그거는 그리드에서 컬럼 체인지 탈때만...
            if (aIsCallCodeInput == false)
            {
                XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(settingRow);
                    settingRow = this.grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }
            }

            for (int i = 0; i < aSourceLayout.RowCount; i++)
            {
                if (i != 0)
                {
                    this.OrderGridCreateNewRow(settingRow);
                    settingRow = this.grdOrder.CurrentRowNumber;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                {
                    return;
                }

                foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                {
                    if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        this.grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = aSourceLayout.LayoutTable.Rows[i][cl.ColumnName];
                    }
                }

                // 디폴트 일수 
                if (TypeCheck.IsNull(this.grdOrder.LayoutTable.Rows[settingRow]["nalsu"]))
                    this.grdOrder.LayoutTable.Rows[settingRow]["nalsu"] = 1;

                // 오더 구분 관련 
                //if (aSourceLayout.GetItemString(i, "order_gubun").Length < 2)
                //    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun");
                //else
                //    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun").Substring(1, 1);

                //if (this.mOrderBiz.LoadColumnCodeName("code", "ORDER_GUBUN_BAS", this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"].ToString().Substring(1, 1), ref ordergubunname))
                //{
                //    if (ordergubunname == "")
                //    {
                //        ordergubunname = "そのた";
                //    }
                //}
                //else
                //{
                //    ordergubunname = "そのた";
                //}

                //this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun_name"] = ordergubunname;
                //this.grdOrder.LayoutTable.Rows[currRow]["order_gubun_bas_name"] = ordergubunname;

                // 오더 구분 관련 
                if (aSourceLayout.GetItemString(i, "order_gubun").Length < 2)
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun");
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun").Substring(1, 1);

                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                {
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table_out"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table_inp"] = aSourceLayout.GetItemString(i, "jundal_table_inp");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part_out"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part_inp"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                    this.grdOrder.LayoutTable.Rows[settingRow]["move_part_out"] = aSourceLayout.GetItemString(i, "move_part");
                    this.grdOrder.LayoutTable.Rows[settingRow]["move_part_inp"] = aSourceLayout.GetItemString(i, "move_part");
                    // 일단 그냥도 넣어주자 외래 기준
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["move_part"] = aSourceLayout.GetItemString(i, "move_part");

                }
                else
                {
                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    else
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_inp");

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    else
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                }
                // 입력컨트롤이 시간 분인경우 시간분 입력창을 띄운다...


                // 부모자식 연관관계 셋팅
                if (aSourceLayout.GetItemString(i, "child_yn") == "Y")
                {
                    parentKey = this.mOrderFunc.GetParentOrderKey(this.mOrderMode, this.grdOrder.LayoutTable, settingRow - 1);

                    if (parentKey < 0)
                    {
                        this.grdOrder.LayoutTable.Rows[settingRow]["child_yn"] = "N";
                    }
                    else
                    {
                        this.mOrderFunc.SetParentInfoToChild(this.grdOrder, parentKey.ToString(), settingRow);
                    }
                }
                else
                {
                    this.grdOrder.LayoutTable.Rows[settingRow]["child_yn"] = "N";
                }

                // 나중에 순서 재정렬을 위하여 dummy 값을 채워주고 재정렬후 뺀다.
                this.grdOrder.SetItemValue(settingRow, "dummy", "mageshin");

                // 依頼書作成中保存せず閉じたとしたらPHY8002　テーブルに FK_OCS　キーがないため　キーがないと保存してないと見なし、オーダを生成しない。
                string pkocskey = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey");
                //                string str = @"SELECT A.FK_OCS
                //                                 FROM PHY8002 A 
                //                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"' 
                //                                  AND A.FK_OCS = " + pkocskey;
                //                object obj = Service.ExecuteScalar(str);

                if (String.IsNullOrEmpty(pkocskey))
                {
                    pkocskey = "";
                }

                OcsoOCS1003P01CheckFkOcsArgs args = new OcsoOCS1003P01CheckFkOcsArgs();
                args.FkOcs = pkocskey;
                OcsoOCS1003P01CheckFkOcsResult result =
                    CloudService.Instance.Submit<OcsoOCS1003P01CheckFkOcsResult, OcsoOCS1003P01CheckFkOcsArgs>(args);

                if (this.mOrderMode != OrderVariables.OrderMode.SetOrder
                    && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                {
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (result.FkOcs == "" &&
                            this.grdOrder.GetItemString(settingRow, "specific_comment") != "")
                            this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
                    }
                }
                this.grdOrder.DisplayData();

                //this.SetOrderImage(this.grdOrder);

            }

        }

        private void ApplySangOrderInfo(string aHangmogCode, int aRowNumber, HangmogInfo.ExecutiveMode mExecutiveMode, bool aIsApplyCurrentRow)
        {
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            #region 그룹정보 및 항목코드 셋팅

            MultiLayout loadExtraInfo = new MultiLayout();

            loadExtraInfo.LayoutItems.Add("hangmog_code", DataType.String);
            loadExtraInfo.LayoutItems.Add("group_ser", DataType.String);
            loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
            loadExtraInfo.InitializeLayoutTable();

            Hashtable groupInfo = null;

            if (this.tabGroup.SelectedTab == null)
                /*this.btnList.PerformClick(FunctionType.Process);*/

                groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            loadExtraInfo.InsertRow(-1);
            // 항목정보
            loadExtraInfo.SetItemValue(0, "hangmog_code", aHangmogCode);
            // 그룹정보 로드
            // 그룹시리얼
            if (groupInfo.Contains("group_ser"))
            {
                loadExtraInfo.SetItemValue(0, "group_ser", groupInfo["group_ser"].ToString());
            }
            // Emergency
            if (groupInfo.Contains("emergency"))
            {
                loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
            }

            #endregion

            if (this.mHangmogInfo.LoadHangmogInfo(mExecutiveMode, loadExtraInfo) == false)
            {
                return;

            }



            this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, aRowNumber, aIsApplyCurrentRow);

            //PostCallHelper.PostCall(new PostMethodObject(PostOrderInsert), currRow);

        }

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
                    if (aGrd.GetItemString(i, "dc_check") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1))
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
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

        #region 오더 그리드 신규 로우 생성

        private void OrderGridCreateNewRow(int aRowNumber)
        {
            this.grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(this.grdOrder, this.grdOrder.CurrentRowNumber);
        }

        #endregion

        #region 부모자식 관련 로우 재구성

        private int SetRowSort()
        {
            MultiLayout mTemp = this.grdOrder.CloneToLayout();
            DataRow[] dtRows = this.grdOrder.LayoutTable.Select("child_yn='N'");
            DataRow[] chRows = this.grdOrder.LayoutTable.Select("child_yn='Y'");
            ArrayList parentList = new ArrayList();
            ArrayList childList = new ArrayList();
            ArrayList addedList = new ArrayList();
            int lastRow = -1;

            // 부모 복사
            for (int i = 0; i < dtRows.Length; i++)
            {
                parentList.Add(dtRows[i]);
            }

            // 자식복사
            for (int j = 0; j < chRows.Length; j++)
            {
                childList.Add(chRows[j]);
            }

            foreach (DataRow tr in parentList)
            {
                mTemp.LayoutTable.ImportRow(tr);

                addedList.Clear();

                foreach (DataRow cr in childList)
                {
                    if (tr["pkocskey"].ToString() == cr["bom_source_key"].ToString())
                    {
                        mTemp.LayoutTable.ImportRow(cr);
                        addedList.Add(cr);
                    }
                }

                foreach (DataRow deldr in addedList)
                {
                    childList.Remove(deldr);
                }
            }


            this.grdOrder.SuspendLayout();


            //this.grdOrder.Reset();
            this.grdOrder.LayoutTable.Clear();

            foreach (DataRow imdr in mTemp.LayoutTable.Rows)
            {
                this.grdOrder.LayoutTable.ImportRow(imdr);
            }

            this.grdOrder.DisplayData();

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetItemString(i, "dummy") == "mageshin")
                {
                    //this.grdOrder.SetFocusToItem(i, "hangmog_code", false);
                    this.grdOrder.SetItemValue(i, "dummy", "");
                    //break;
                    lastRow = i;
                }
            }

            //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            this.grdOrder.ResumeLayout();

            return lastRow;
        }

        #endregion

        #region 오더링 로우 이동

        private void MoveOrderRow(XEditGrid grid, int aSourceRowNumber, int aDestRowNumber)
        {
            if (aSourceRowNumber == aDestRowNumber) return;

            MultiLayout mTempLayout = grid.CloneToLayout();
            int parentKey = -1;

            for (int i = 0; i < grid.RowCount; i++)
            {
                if (i == aSourceRowNumber)
                    continue;

                if (i == aDestRowNumber)
                {
                    parentKey = this.mOrderFunc.GetParentOrderKey(this.mOrderMode, this.grdOrder.LayoutTable, i, true);

                    if (parentKey > 0)
                    {
                        this.grdOrder.SetItemValue(aSourceRowNumber, "child_yn", "Y");
                        this.grdOrder.SetItemValue(aSourceRowNumber, "bom_source_key", parentKey);

                        this.MoveOrderRowSub(grid, aSourceRowNumber);
                    }
                    else
                    {
                        this.grdOrder.SetItemValue(aSourceRowNumber, "child_yn", "N");
                        this.grdOrder.SetItemValue(aSourceRowNumber, "bom_source_key", "");
                    }

                    this.grdOrder.SetItemValue(aSourceRowNumber, "dummy", "mageshin");

                    mTempLayout.LayoutTable.ImportRow(grid.LayoutTable.Rows[aSourceRowNumber]);

                }

                mTempLayout.LayoutTable.ImportRow(grid.LayoutTable.Rows[i]);
            }
        }

        private void MoveOrderRowSub(XEditGrid grid, int aSourceRow)
        {
            if (grid.GetItemString(aSourceRow, "pkocskey") != "")
            {
                foreach (DataRow dr in grid.LayoutTable.Select("bom_source_key=" + grid.GetItemString(aSourceRow, "pkocskey")))
                {
                    dr["bom_source_key"] = grid.GetItemString(aSourceRow, "bom_source_key");
                }
            }
        }

        #endregion

        #region 처방Row 이동시 Control Display 변경처리(OrderRowMovingChangedDisplay)
        /// <summary>
        /// 처방Row 이동시 Control Display 변경처리
        /// </summary>
        /// <param name="aGrd"> XEditGrid  Grid </param>
        /// <param name="aRow"> int  Row </param>
        /// <returns> void </returns>
        private void OrderRowMovingChangedDisplay(XEditGrid aGrd, int aRow)
        {
            if (aGrd == null || aRow < 0) return;

            // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
            this.mHangmogInfo.DisplaySpecialColHeader(IOEGUBUN, aGrd, aRow, aGrd.GetItemString(aRow, "hangmog_code").Trim());

            //			// 현재 버튼 크기가 작어서 처리못함
            //			if (!TypeCheck.IsNull(aGrd.GetItemString(aRow, "specific_comment_name")))
            //				this.btnSpecificComment.Text = aGrd.GetItemString(aRow, "specific_comment_name"); // 항목별 서식지관리 명칭
            //			else
            //				this.btnSpecificComment.Text = TypeCheck.NVL(this.btnSpecificComment.Tag, "").ToString(); // 항목별 서식지관리 최초 명칭으로 초기화
        }
        #endregion

        #region 반납 지시 관련 컬럼 보이기

        private void ShowDcGubun(XEditGrid aGrid, string aGroupSer)
        {
            DataRow[] dr = aGrid.LayoutTable.Select("group_ser=" + aGroupSer + " AND dc_gubun='Y'");

            if (dr != null && dr.Length > 0)
            {
                aGrid.AutoSizeColumn(2, 35);
            }
            else
            {
                aGrid.AutoSizeColumn(2, 0);
            }
        }

        #endregion

        #endregion

        #region Event
        private void tabGroup_SelectionChanged(object sender, EventArgs e)
        {
            //insert by jc [選択されているgroupがない内はInput_gubunによるVisible設定をやり直す。]
            if (tabGroup.SelectedTab == null)
                mOrderFunc.SetGridRowVisibleByNoGroupSer(this.grdOrder, this.mInputGubun);

            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (this.tabGroup.SelectedTab == tpg)
                {
                    tpg.ImageIndex = 0;

                    this.mOrderFunc.DeleteEmptyNewRow(this.grdOrder);

                    this.DisplayOrderGridGroupInfo((Hashtable)tpg.Tag);

                    // 해당 그룹의 젤 마지막 로우로 포커스 이동
                    if (this.mCurrentColName == "")
                    {
                        PostCallHelper.PostCall(new PostMethodInt(this.PostTabSelection), this.mOrderFunc.GetLastRow(this.grdOrder.LayoutTable, ((Hashtable)tpg.Tag)["group_ser"].ToString()));
                    }
                }
                else
                {
                    tpg.ImageIndex = 1;
                }
            }
        }

        private void tabSangyongOrder_SelectionChanged(object sender, EventArgs e)
        {
            XTabControl control = sender as XTabControl;
            Hashtable tabInfo;
            string memb = "";

            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);

            //foreach (IHIS.X.Magic.Controls.TabPage tpg in control.TabPages)
            //{
            //    if (tpg == control.SelectedTab)
            //    {
            //        tpg.ImageIndex = 0;

            //        tabInfo = tpg.Tag as Hashtable;
            //        memb = tabInfo["memb"].ToString();

            //        string wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            //        this.LoadOftenUseOrder("1", memb, tabInfo["order_gubun"].ToString(), wonnaeDrgYn, this.txtSearch.GetDataValue());
            //    }
            //    else
            //    {
            //        tpg.ImageIndex = 1;
            //    }
            //}
        }

        private void grdOrder_Click(object sender, EventArgs e)
        {
            int lRow = grdOrder.CurrentRowNumber;
            string lResult = "";
            // 포커스가 왔을때 아무것도 입력이 되어 있지 않다면 
            // 신규로우를 하나 자동으로 생성한다.
            if (this.tabGroup.SelectedTab != null)
            {
                DataRow[] dr = this.grdOrder.LayoutTable.Select("group_ser=" + ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString());
                if (dr.Length <= 0)
                {
                    //todo: dev this
                    /*this.btnList.PerformClick(FunctionType.Insert);*/
                }
            }
        }

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            string dv = "";

            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                    (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                    (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly) ||
                    (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName)) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName))
                {
                    e.BackColor = OrderVariables.DisplayFieldColor.Color;
                }
            }
            else
            {
                if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                    (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                    (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly) ||
                    (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName)) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName) ||
                    !this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay))
                {
                    e.BackColor = OrderVariables.DisplayFieldColor.Color;
                }
            }

            this.mHangmogInfo.ColumnColorForOrderState(IOEGUBUN, grd, e); // 처방상태에 따른 색상 처리

            dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    break;
                case "dv_2":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 2)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;
                case "dv_3":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 3)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;
                case "dv_4":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 4)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;

            }

        }

        private void grdOrder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            string hangmog_code = grid.GetItemString(e.RowNumber, "hangmog_code").Trim();  // 항목코드

            // 이전값을 버퍼로 셋팅
            object previousValue = grid.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer);

            //// 오더가 아닌경우 오더코드가 입력되지 않았다면 메세지 처리
            //if (e.ColName != "hangmog_code" && grid.GetItemString(e.RowNumber, "hangmog_code") == "")
            //{
            //    MessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue); // 이전값으로 되돌린다.
            //}

            ////////////////////// 필드 Validation 및 Value Setting 공통모듈 Call ///////////////////
            // 항목을 제외한 다른 컬럼들의 일반적 validation 은 이안에서 기술한다.                 //
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (!this.mHangmogInfo.ColumnChanged(IOEGUBUN, grid, e)) return;
            }
            else
            {
                if (!this.mHangmogInfo.ColumnChanged(IOEGUBUN, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), this.mPatientInfo.GetPatientInfo["naewon_date"].ToString(), grid, e)) return;
            }
            /////////////////////////////////////////////////////////////////////////////////////////

            switch (e.ColName)
            {
                case "hangmog_code":    // 오더코드 

                    #region 오더코드

                    hangmog_code = e.ChangeValue.ToString().TrimEnd();

                    if (TypeCheck.IsNull(hangmog_code))
                    {
                        //this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);   // 이전값으로 되돌린다.
                        return;
                    }

                    this.mHangmogInfo.Parameter.Clear();
                    this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
                    this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
                    this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
                    this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
                    this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
                    this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;
                    this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = "N";

                    if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                        this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    {
                        this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                        this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                        this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                        this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                        this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                        this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
                    }

                    #region 그룹정보 및 항목코드 셋팅

                    MultiLayout loadExtraInfo = new MultiLayout();

                    loadExtraInfo.LayoutItems.Add("hangmog_code", DataType.String);
                    loadExtraInfo.LayoutItems.Add("group_ser", DataType.String);
                    loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
                    loadExtraInfo.InitializeLayoutTable();

                    Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                    loadExtraInfo.InsertRow(-1);
                    // 항목정보
                    loadExtraInfo.SetItemValue(0, "hangmog_code", e.ChangeValue.ToString());
                    // 그룹정보 로드
                    // 그룹시리얼
                    if (groupInfo.Contains("group_ser"))
                    {
                        loadExtraInfo.SetItemValue(0, "group_ser", groupInfo["group_ser"].ToString());
                    }
                    // Emergency
                    if (groupInfo.Contains("emergency"))
                    {
                        loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
                    }


                    #endregion

                    if (this.mHangmogInfo.LoadHangmogInfo(HangmogInfo.ExecutiveMode.CodeInput, loadExtraInfo) == false)
                    {
                        this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                        this.OpenScreen_OCS0103Q00(e.ChangeValue.ToString(), true);
                        return;
                    }

                    int currentRow = this.grdOrder.CurrentRowNumber;

                    this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, this.grdOrder.CurrentRowNumber, true);



                    //this.SetImageToGrid(grdOrder);
                    //this.DiaplayMixGroup(grid);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    #endregion

                    break;

                case "ord_danui":

                    string code = "";
                    string codename = "";

                    if (e.ChangeValue.ToString() == "")
                    {
                        this.mOrderBiz.GetDefaultOrdDanui(hangmog_code, ref code, ref codename);

                    }
                    else
                    {
                    }

                    break;

                case "jundal_part":  // 전달 파트 
                case "jundal_part_out":
                case "jundal_part_inp":

                    // 전달 파트에 대한 벨리데이션은 라이브러리에서ㅓ 행하여 지고 여기서는
                    // 전달 파트 변경시 jundal_table과 무브파트를 변경해야 한다.
                    string jundalTable = "";
                    string movePart = "";

                    if (e.ColName == "jundal_part")
                    {
                        //insert by jc [HOMの場合は希望日を入れられない。] 
                        if (grid.GetItemString(e.RowNumber, "jundal_part") == "HOM")
                        {
                            grid.SetItemValue(e.RowNumber, "hope_date", "");
                            grid.SetItemValue(e.RowNumber, "hope_time", "");
                        }
                        //if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)

                        //todo: Dev this
                        /*if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), this.dpkOrder_Date.GetDataValue()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part", movePart);
                        }*/
                    }
                    else if (e.ColName == "jundal_part_out")
                    {
                        //if (this.mOrderBiz.GetJundaTable("O", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)

                        //todo: Dev this
                        /*if (this.mOrderBiz.GetJundaTable("O", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), this.dpkOrder_Date.GetDataValue()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_out", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_out", movePart);
                        }*/
                    }
                    else if (e.ColName == "jundal_part_inp")
                    {
                        //if (this.mOrderBiz.GetJundaTable("I", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)

                        //todo: dev this.
                        /*if (this.mOrderBiz.GetJundaTable("I", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), this.dpkOrder_Date.GetDataValue()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_inp", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_inp", movePart);
                        }*/
                    }

                    break;

                case "hope_date":

                    if (e.ChangeValue.ToString() != "")
                    {
                        if (this.grdOrder.GetItemString(e.RowNumber, "dangil_gumsa_order_yn") == "Y")
                        {
                        }
                    }
                    else
                    {
                    }

                    break;
            }
        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            // InputControl별 필드 입력불가 제어
            // 처방 Field DataChange 가능여부 체크 입력불가 제어
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName))
                    e.Protect = true;
            }
            else
            {
                if (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName) ||
                    !this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay) ||
                    //insert by jc [CellのWidthが０である場合はProtectを掛けてカーソルが行っても反応しないようにするため] 2012/02/20
                    this.grdOrder[e.RowNumber, e.ColName].AbsoluteRectangle.Width == 0)
                    e.Protect = true;
            }

            string dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.Protect = true;
                    break;
                case "dv_2":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 2)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                case "dv_3":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 3)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                case "dv_4":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 4)
                        {
                            e.Protect = true;
                        }
                    }
                    break;

            }
        }

        private void grdOrder_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "hangmog_code":     // 항목코드 

                    e.Cancel = true; // 별도의 화면 오픈 

                    /*if (this.dpkOrder_Date.GetDataValue() == "")
                    {
                        return;
                    }*/

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), true); // 화면오픈

                    break;

                case "bogyong_code":  // 부위코드

                    e.Cancel = false;

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "" && grid.GetItemString(e.RowNumber, "input_control") == "A")
                    {
                        this.OpenScreen_CHT0117Q00(grid.GetItemString(e.RowNumber, "order_gubun_bas"));
                    }

                    break;

                case "specimen_code":

                    e.Cancel = false;

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("specimen_code_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "ord_danui_name":  // 오더단위

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part": // 전달파트
                    // 외래 전달 파트 
                    if (this.IOEGUBUN == "O")
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    // 입원 전달파트 
                    else
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    break;

                case "jundal_part_out": // 전달파트 외래

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_inp": // 전달파트 입원

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

            }
        }

        private void grdOrder_GridReservedMemoButtonClick(object sender, GridReservedMemoButtonClickEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            CommonItemCollection loadParams;

            switch (e.ColName)
            {
                case "order_remark":

                    loadParams = new CommonItemCollection();
                    loadParams.Add("category_gubun", OrderVariables.CATEGORY_COMMENT); // 처방Comment

                    grd.SetReservedMemoControlLoadParam(e.ColName, loadParams);

                    break;
            }
        }

        private void grdOrder_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.OrderRowMovingChangedDisplay((XEditGrid)sender, e.CurrentRow);
        }

        private void grdOrder_DragDrop(object sender, DragEventArgs e)
        {
            string data = e.Data.GetData("System.String").ToString();
            string gubun = data.Split('|')[0];
            string sourceRow = data.Split('|')[1];
            string hangmogCode = "";

            Point clientPoint = grdOrder.PointToClient(new Point(e.X, e.Y));
            int rowNumber = grdOrder.GetHitRowNumber(clientPoint.Y);

            if (TypeCheck.IsInt(sourceRow) == false)
            {
                return;
            }

            if (this.tabGroup.SelectedTab == null)
            {
                //todo: Dev this
                /*this.btnList.PerformClick(FunctionType.Process);*/
            }

            switch (gubun)
            {
                case "SangYong":

                    hangmogCode = this.grdSangyongOrder.GetItemString(int.Parse(sourceRow), "hangmog_code");

                    this.ApplySangOrderInfo(hangmogCode, rowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;

                case "OrderGrid":

                    this.MoveOrderRow(grdOrder, int.Parse(sourceRow), rowNumber);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;
            }

            this.mIsDrag = false;
            this.mDragX = 0;
            this.mDragY = 0;
            this.mDragRowIndex = -1;
        }

        private void grdOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시	
        }

        private void grdOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdOrder_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex = -1;
            int parentRowIndex = -1;
            XEditGrid grd = sender as XEditGrid;

            curRowIndex = grd.GetHitRowNumber(e.Y);


            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (curRowIndex < 0) return;

                // 재료만 이동이 가능함.
                if (grd.GetItemString(curRowIndex, "if_input_control") != "P")
                {
                    this.mDragX = e.X;
                    this.mDragY = e.Y;
                    ////Drag시 show info정보
                    //string dragInfo = "[" + grd.GetItemString(curRowIndex, "hangmog_code") + "]" + grd.GetItemString(curRowIndex, "hangmog_name");
                    //DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
                    //grd.DoDragDrop("OrderGrid" + "|" + curRowIndex.ToString(), DragDropEffects.Move);

                    this.mDragRowIndex = curRowIndex;
                    this.mIsDrag = true;
                }
            }

            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                this.grdOrder.SetFocusToItem(curRowIndex, "hangmog_name");
                popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
            }

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                switch (grd.CurrentColName)
                {
                    case "hangmog_name":
                        //// 시간 , 분 처리
                        //DataRow dRow = this.mOrderFunc.CopyDataRow(grd.LayoutTable.Rows[grd.CurrentRowNumber]);

                        //if (!TypeCheck.IsNull(grd.GetItemString(curRowIndex, "hangmog_code")) && this.mHangmogInfo.GetInputTime(this, dRow))
                        //{
                        //    grd.SetItemValue(curRowIndex, "suryang", dRow["suryang"]);
                        //    grd.SetItemValue(curRowIndex, "nalsu", dRow["nalsu"]);
                        //}
                        this.btnSpecificComment.PerformClick();
                        break;
                }
            }
        }

        private void grdOrder_MouseMove(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            int offset = Math.Abs(this.mDragY - e.Y);

            if (this.mIsDrag && offset > 5)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grd.GetItemString(this.mDragRowIndex, "hangmog_code") + "]" + grd.GetItemString(this.mDragRowIndex, "hangmog_name");
                DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
                grd.DoDragDrop("OrderGrid" + "|" + this.mDragRowIndex.ToString(), DragDropEffects.Move);
            }
        }

        private void grdOrder_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.mIsDrag && e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                this.mDragX = 0;
                this.mDragY = 0;
                this.mDragRowIndex = -1;
                this.mIsDrag = false;
            }
        }

        private void grdSangyongOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);
        }

        private void grdSangyongOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;
            int applyRow = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowNumber < 0) return;

                this.btnSelect.PerformClick();

            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grid.GetItemString(rowNumber, "hangmog_code") + "]" + grid.GetItemString(rowNumber, "hangmog_name");
                DragHelper.CreateDragCursor(grid, dragInfo, this.Font);
                grid.DoDragDrop("SangYong" + "|" + rowNumber.ToString(), DragDropEffects.Move);
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (rowNumber < 0) return;

                if (this.grdSangyongOrder.CurrentRowNumber != rowNumber)
                {
                    this.grdSangyongOrder.SetFocusToItem(rowNumber, 0);
                }

                this.popupOftenUsedMenu.TrackPopup(grid.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void grdSangyongOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdSangyongOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void cboQueryCon_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search_text();
            }
        }

        private void cboSearchCondition_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
        }

        private void rbnOftenOrder_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;
            //insert by jc TABが変わる際に検索語が既にあった場合はその検索語で検索する。
            string searchVoc = this.txtSearch.GetDataValue();
            string wonnaeDrgYn = this.cboQueryCon.GetDataValue();
            if (control.Checked)
            {
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;
                control.ImageIndex = 0;

                // 선택된것에 따른 화면 조정
                switch (control.Name)
                {
                    case "rbnOftenOrder":    // 상용오더

                        PostCallHelper.PostCall(new PostMethod(PostSearchChecked));
                        this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());

                        break;
                }
            }
            else
            {
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
                control.ImageIndex = 1;
            }
        }

        private void btnNewSelect_Click(object sender, EventArgs e)
        {
            //Todo: Dev this
            /*this.btnList.PerformClick(FunctionType.Process);*/

            this.btnSelect.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            XGrid grid = new XGrid();
            int rownumber = -1;

            if (this.tabGroup.SelectedTab == null)
            {
                //todo: dev this
                /*this.btnList.PerformClick(FunctionType.Process);*/
            }

            // 현재 선택된 그리드의 항목코드 셋팅
            if (rbnOftenOrder.Checked == true)
            {
                grid = this.grdSangyongOrder as XGrid;
                rownumber = this.grdOrder.CurrentRowNumber;
            }

            if (grid.RowCount <= 0 ||
                grid.CurrentRowNumber < 0) return;

            this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), this.grdOrder.CurrentRowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

            PostCallHelper.PostCall(new PostMethod(PostOrderInsert));
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (this.mIsExtended)
            {
                /*this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);
                this.btnExtend.ImageIndex = 3;*/
                this.mIsExtended = false;
            }
            else
            {
                /*this.pnlOrderInfo.Size = new Size(this.OrderExtendWidth, this.pnlOrderInfo.Size.Height);
                this.btnExtend.ImageIndex = 4;*/
                this.mIsExtended = true;
            }
            this.grdOrder.Refresh();
        }

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            this.mCurrentRow = this.grdOrder.CurrentRowNumber;

            this.OpenScreen_OCS0301Q09();

            this.mCurrentRow = -1;
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS1003Q09(false);
        }

        private void btnSpecificComment_Click(object sender, EventArgs e)
        {
            int currRow = -1;
            currRow = this.grdOrder.CurrentRowNumber;
            if (currRow < 0) return;
            //RowStatus変更のために弄る。
            //this.grdOrder.SetItemValue(currRow, "nalsu", 1);
            this.OpenScreen_SpecificComment(this.grdOrder, currRow, this.grdOrder.GetItemString(currRow, "specific_comment"));
        }

        private void cbxEmergency_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null) return;

            if (this.mOrderBiz.IsAbleEmergencyCheck(this.cbxEmergency.GetDataValue(), ((Hashtable)this.tabGroup.SelectedTab.Tag), this.grdOrder.LayoutTable) == false)
            {
                PostCallHelper.PostCall(new PostMethodStr(this.PostEmergencyCheckedChangeFail), (this.cbxEmergency.GetDataValue() == "Y" ? "N" : "Y"));
            }
            else
            {
                this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "emergency", this.cbxEmergency.GetDataValue(), "", "", "");
            }
        }
       
        #endregion

        #region Method

        private void MakeGroupTabInfo(string aIOGubun, string aFkInOutKey, string aInputGubun, string aInputTab)
        {
            if (this.grdOrder.RowCount <= 0)
            {
                // 저장된 그룹탭 정보가 없는경우
                // 신규 그룹을 생성한다.
                /*this.btnList.PerformClick(FunctionType.Process);*/
            }
            else
            {
                this.tabGroup.SelectionChanged -= new EventHandler(tabGroup_SelectionChanged);

                try
                {
                    this.tabGroup.TabPages.Clear();
                }
                catch
                {
                    this.tabGroup.Refresh();
                }

                IHIS.X.Magic.Controls.TabPage ldTab;
                Hashtable groupInfo;
                string curGroupSer = "";
                bool isExist = false;

                foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
                {
                    // 의사인경우는 넘어온 input_gubun 과 일치하는 입력구분만 보여주고
                    // 의사 이외의 경우는 의사 오더 및 자신의 입력구분에 해당하는 오더를 전부 보여준다.
                    //if ((this.mInputGubun.Substring(0, 1) == "D" && dr["input_gubun"].ToString() == this.mInputGubun) ||
                    //     (this.mInputGubun.Substring(0, 1) != "D" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D")))
                    //{
                    if ((UserInfo.UserGubun == UserType.Doctor && dr["input_gubun"].ToString() == this.mInputGubun)
                       || (UserInfo.UserGubun != UserType.Doctor && UserInfo.Gwa != "CK" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D"))
                       || (UserInfo.Gwa == "CK" && (dr["input_gubun"].ToString().Substring(0, 1) == "D" || dr["input_gubun"].ToString() == UserInfo.Gwa))
                      )
                    {
                        if (curGroupSer != dr["group_ser"].ToString())
                        {
                            isExist = false;
                            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
                            {
                                if (dr["group_ser"].ToString() == ((Hashtable)tpg.Tag)["group_ser"].ToString())
                                {
                                    isExist = true;
                                    break;
                                }
                            }

                            if (isExist == false)
                            {
                                ldTab = new IHIS.X.Magic.Controls.TabPage();

                                ldTab.Title = dr["group_ser"].ToString() + " グループ";
                                /*ldTab.ImageList = this.ImageList;
                                ldTab.ImageIndex = 1;*/

                                groupInfo = new Hashtable();
                                groupInfo.Add("group_ser", dr["group_ser"]);
                                groupInfo.Add("group_name", dr["group_ser"].ToString() + " グループ");
                                //groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                                //groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());
                                groupInfo.Add("emergency", dr["emergency"].ToString());
                                //groupInfo.Add("nalsu", dr["nalsu"].ToString());
                                //groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());

                                ldTab.Tag = groupInfo;

                                this.tabGroup.TabPages.Add(ldTab);

                                curGroupSer = dr["group_ser"].ToString();
                            }
                        }
                    }
                }

                if (this.tabGroup.TabPages.Count > 0)
                {
                    this.tabGroup.SelectedTab = this.tabGroup.TabPages[0];

                    this.tabGroup.SelectionChanged += new EventHandler(tabGroup_SelectionChanged);

                    this.tabGroup_SelectionChanged(this, new EventArgs());
                    //this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);
                }
                else
                {
                    /*this.btnList.PerformClick(FunctionType.Process);*/
                }
            }
        }

        private void PostTabSelection(int aRowNumber)
        {
            this.grdOrder.SetFocusToItem(aRowNumber, "hangmog_code", false);
        }
        // MinhLS
        private void MakeSangyongTab2(IEnumerable<LoadOftenUsedTabResponseInfo> itemList)
        {
            Hashtable tabInfo;

            this.tabSangyongOrder.SelectionChanged -= new EventHandler(tabSangyongOrder_SelectionChanged);

            try
            {
                this.tabSangyongOrder.TabPages.Clear();
            }
            catch
            {
                this.tabSangyongOrder.Refresh();
            }

            IHIS.X.Magic.Controls.TabPage tpg;

            foreach (LoadOftenUsedTabResponseInfo item in itemList)
            {
                tpg = new IHIS.X.Magic.Controls.TabPage();
                tpg.Title = item.OrderGubunName;
                /*tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 1;*/

                tabInfo = new Hashtable();
                tabInfo.Add("order_gubun", item.OrderGubun);
                tabInfo.Add("memb", item.Memb);
                //tabInfo.Add("xrt_yn", sangyongTab.Rows[i]["xray_yn"].ToString());
                tpg.Tag = tabInfo;

                this.tabSangyongOrder.TabPages.Add(tpg);
            }

            this.tabSangyongOrder.SelectionChanged += new EventHandler(tabSangyongOrder_SelectionChanged);

            this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
        }

        private void DisplayOrderGridGroupInfo(Hashtable aGroupInfo)
        {
            // 오더그리드의 오더항목 visible setting 
            this.mOrderFunc.SetGridRowVisibleByGroupSer(this.grdOrder, aGroupInfo["group_ser"].ToString(), this.mInputGubun);

            // 그룹항목셋팅
            this.SetGroupControl(aGroupInfo);

            // 그룹항목에 대하여 프로텍트 여부 
            this.ProtectGroupControl(aGroupInfo["group_ser"].ToString());

            // dc 구분관련 보일것인가 말것인가..
            this.ShowDcGubun(this.grdOrder, (aGroupInfo["group_ser"].ToString()));

        }

        private void InitScreen()
        {
            //this.grdOrder.AutoSizeColumn(3, 0);
            //this.grdOrder.AutoSizeColumn(4, 0);

            this.grdOrder.AutoSizeColumn(15, 0);　//비치
            this.grdOrder.AutoSizeColumn(7, 0); //HOPE_DATE

            this.grdOrder.AutoSizeColumn(6, 0); //comment
            //this.grdOrder.AutoSizeColumn(8, 0); //suryang
            //this.grdOrder.AutoSizeColumn(9, 0); //danui
            //this.grdOrder.AutoSizeColumn(10, 0); //nalsu
            this.grdOrder.AutoSizeColumn(11, 0); //dangil_gumsa
            this.grdOrder.AutoSizeColumn(12, 0); //dangil_result

            // 셋트 오더인경우는 정시약, 반납지시 컬럼이 보이면 안됨. 그룹시리얼도
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                this.grdOrder.AutoSizeColumn(2, 0);
                this.grdOrder.AutoSizeColumn(7, 0);
                this.grdOrder.AutoSizeColumn(16, 0);
            }
            // 의사 오더인 경우는 반납지시 컬럼이 보이지 않ㄴㅡㄴ다.
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.grdOrder.AutoSizeColumn(2, 0);
            }

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder)
            {
                this.grdOrder.AutoSizeColumn(17, 0);
                this.grdOrder.AutoSizeColumn(18, 0);
            }
            else
            {
                this.grdOrder.AutoSizeColumn(16, 0);
            }

            // 입원 외래에 따른 조회 조건 기본셋팅값
            if (this.IOEGUBUN == "O")
            {
                this.cboQueryCon.SetDataValue("%"); // 전체 기본
            }
            else
            {
                this.cboQueryCon.SetDataValue("Y"); // 원내 채용약 기본
                //insert by jc 入院オーダでは当日カラムがないので画面から見えないように修正。START
                this.grdOrder.AutoSizeColumn(11, 0);//当日施行
                this.grdOrder.AutoSizeColumn(12, 0);//当日結果
                //insert by jc 入院オーダでは当日カラムがないので画面から見えないように修正。END
            }


            /*// 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            popupOrderMenu.MenuCommands.Clear();
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG001_MSG, (Image)this.imageListPopupMenu.Images[0],
                new EventHandler(PopUpMenuSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG002_MSG, (Image)this.imageListPopupMenu.Images[1],
                new EventHandler(PopUpMenuUnSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG003_MSG, (Image)this.imageListPopupMenu.Images[2],
                new EventHandler(PopUpMenuInsert_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG004_MSG, (Image)this.imageListPopupMenu.Images[3],
                new EventHandler(PopUpMenuPaste_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG005_MSG, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuDelete_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG006_MSG, (Image)this.imageListPopupMenu.Images[7],
                new EventHandler(PopUpMenuSelectOftenOrder_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG007_MSG, (Image)this.imageListPopupMenu.Images[8],
                new EventHandler(PopUpMenuRecoverToDandok_Click)));

            // 상용오더 팝업메뉴
            popupOftenUsedMenu.MenuCommands.Clear();
            popupOftenUsedMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG008_MSG, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuSelectOftenOrderDelete_Click)));*/
        }

        /// <summary>
        /// 항목코드 파인드 창 오픈
        /// </summary>
        /// <param name="aHangmogCode">검색어</param>
        /// <param name="aMultiSelect">복수선택여부</param>
        private void OpenScreen_OCS0103Q00(string aHangmogCode, bool aMultiSelect)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("hangmog_code", aHangmogCode);
            param.Add("multiSelect", true);
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void PostOrderInsert()
        {
            int lastRow = this.SetRowSort();

            this.SetImageToGrid(grdOrder);

            this.SetOrderImage(grdOrder);

            if (lastRow >= 0)
                this.grdOrder.SetFocusToItem(lastRow, "hangmog_code", false);

            this.grdOrder.AcceptData();

            //if (TypeCheck.IsNull(aValidInfo) == false)
            //{
            //    if (TypeCheck.IsInt(aValidInfo.ToString()))
            //    {
            //        this.grdOrder.SetFocusToItem(int.Parse(aValidInfo.ToString()), "hangmog_code", true);
            //    }
            //}
        }

        #region  SetImageToGrid

        private void SetImageToGrid(XEditGrid grd)
        {
            for (int i = 0; i < grd.RowCount; i++)
            {
                // 부모인경우
                if (grd.GetItemString(i, "child_yn") != "Y")
                {
                    //todo: Dev this
                    /*grd[i + grd.HeaderHeights.Count, 1].Image = this.ImageGrouping.Images[0];*/

                }
                // 자식인경우
                else
                {
                    //todo: dev this
                    /*grd[i + grd.HeaderHeights.Count, 1].Image = this.ImageGrouping.Images[1];*/
                }
            }
        }

        #endregion

        private void SetOrderImage(XEditGrid aGrid)
        {
            // 의사가 입력하는 경우는 스킵
            if (this.mInputGubun.Substring(0, 1) == "D") return;

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                // 의사 오더인경우
                if (aGrid.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                {
                    //todo: Dev this
                    /*aGrid[i + aGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[10];*/
                    //aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = Resources.MSG011_MSG + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;

                    aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = "YC BS" + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
                }
            }
        }

        private void OpenScreen_CHT0117Q00(string aOrderGubun)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("order_gubun", aOrderGubun);

            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0117Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void Search_text()
        {
            string searchText = this.txtSearch.GetDataValue();

            if (searchText == "" && this.rbnOftenOrder.Checked)
                searchText = "%";

            if (searchText == "")
                return;

            string wonnaeDrgYn = "";

            wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            if (this.rbnOftenOrder.Checked)
            {
                if (this.tabSangyongOrder.SelectedTab != null)
                {
                    Hashtable tabInfo = this.tabSangyongOrder.SelectedTab.Tag as Hashtable;

                    this.LoadOftenUseOrder("1", tabInfo["memb"].ToString(), tabInfo["order_gubun"].ToString(), wonnaeDrgYn, searchText);
                }
            }

            PostCallHelper.PostCall(new PostMethod(PostSearchValidating));
        }

        private void LoadOftenUseOrder(string aMembGubun, string aMemb, string aOrderGubun, string aWonnaeDrgYn, string aSearchWord)
        {
            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);
            //this.grdSangyongOrder.Reset();
            ////insert by jc [検索条件追加] 2012/10/15
            //DataTable dtSangyongData = this.mOrderBiz.LoadOftenUsedInfo(aMembGubun, aMemb, aOrderGubun, aWonnaeDrgYn, TypeCheck.NVL(aSearchWord, "%").ToString(), this.cboSearchCondition.SelectedValue.ToString());

            //if (dtSangyongData != null && dtSangyongData.Rows.Count > 0)
            //{
            //    this.grdSangyongOrder.ImportRowRange(dtSangyongData, 0);
            //    this.grdSangyongOrder.ResetUpdate();
            //    this.grdSangyongOrder.DisplayData();
            //}
        }

        private void PostSearchValidating()
        {
            // this.txtSearch.SetDataValue("");
            bool isFocusToTextBox = false;

            if (this.rbnOftenOrder.Checked)
            {
                if (this.grdSangyongOrder.RowCount <= 0)
                    isFocusToTextBox = true;
            }

            if (isFocusToTextBox)
            {
                this.txtSearch.Focus();
                this.txtSearch.SelectAll();
            }
            else
            {
                this.txtSearch.Focus();
                //this.txtSearch.SetDataValue("");
            }
        }

        private void PostSearchChecked()
        {
            this.txtSearch.Focus();
        }

        private void OpenScreen_OCS0301Q09()
        {
            /*string naewon_date = this.dpkOrder_Date.GetDataValue().PadRight(10).Substring(0, 10).Replace("-", "/");*/

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("input_tab", INPUTTAB);


            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("memb", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                openParams.Add("gwa", UserInfo.Gwa);
                openParams.Add("memb", UserInfo.DoctorID);
            }
            else if (UserInfo.UserGubun == UserType.Nurse)
            {
                openParams.Add("gwa", TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }
            else
            {
                openParams.Add("gwa", TypeCheck.NVL(this.mInputPart, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }

            openParams.Add("patient_info", this.mPatientInfo);

            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0301Q09", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003Q09(bool aIsAutoClose)
        {
            // 처방 입력 가능 여부

            //해당 내원의 처방정보를 가져온다.
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mPatientInfo.GetPatientInfo["bunho"].ToString());

            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("doctor", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else
            {
                openParams.Add("gwa", mPatientInfo.GetPatientInfo["gwa"].ToString());
                openParams.Add("doctor", mPatientInfo.GetPatientInfo["doctor"].ToString());
            }


            /*openParams.Add("naewon_date", this.dpkOrder_Date.GetDataValue());*/
            if (UserInfo.UserGubun == UserType.Doctor)
                openParams.Add("input_gubun", "D%");
            else
                openParams.Add("input_gubun", this.mInputGubun);
            //openParams.Add("tel_yn"     , "N"); // 간호 입력분은 뺀다 
            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", aIsAutoClose);
            openParams.Add("input_tab", INPUTTAB);
            openParams.Add("io_gubun", this.IOEGUBUN);

            openParams.Add("childYN", "N");
            openParams.Add("patient_info", this.mPatientInfo);

            //전처방조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q09", ScreenOpenStyle.ResponseSizable, openParams);
        }
        
        /// <summary>
        /// 의뢰서 화면 오픈
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="aRowNumber"></param>
        private void OpenScreen_SpecificComment(XEditGrid aGrid, int aRowNumber, string aSpecific_Comment)
        {
            //if (aGrid.GetItemString(aRowNumber, "specific_comment_pgm_id") == "")
            //{
            //    MessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aGrid.GetItemString(aRowNumber, "bunho"));
            openParams.Add("order_date", aGrid.GetItemString(aRowNumber, "order_date"));
            if (aGrid.GetItemString(aRowNumber, "pkocskey") == "")
            {
                aGrid.SetItemValue(aRowNumber, "pkocskey", this.mOrderFunc.GetOrderKey(this.mOrderMode));
            }

            openParams.Add("pkocskey", aGrid.GetItemString(aRowNumber, "pkocskey"));

            openParams.Add("in_out_gubun", this.IOEGUBUN);
            openParams.Add("hangmog_code", aGrid.GetItemString(aRowNumber, "hangmog_code"));
            openParams.Add("gwa", aGrid.GetItemString(aRowNumber, "gwa"));
            openParams.Add("doctor", aGrid.GetItemString(aRowNumber, "doctor"));
            openParams.Add("jundal_part", aGrid.GetItemString(aRowNumber, "jundal_part"));
            openParams.Add("naewon_key", aGrid.GetItemString(aRowNumber, "in_out_key"));

            //string sysid = aGrid.GetItemString(aRowNumber, "specific_comment_sys_id");
            //string pgmid = aGrid.GetItemString(aRowNumber, "specific_comment_pgm_id");
            if (aSpecific_Comment == "18")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U00", ScreenOpenStyle.ResponseSizable, openParams);
            else if (aSpecific_Comment == "19")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U01", ScreenOpenStyle.ResponseSizable, openParams);

        }

        private void PostEmergencyCheckedChangeFail(string aOrgCheckedValue)
        {
            this.cbxEmergency.CheckedChanged -= new EventHandler(cbxEmergency_CheckedChanged);

            this.cbxEmergency.SetDataValue(aOrgCheckedValue);

            this.cbxEmergency.CheckedChanged += new EventHandler(cbxEmergency_CheckedChanged);
        }

        private void ApplyGroupInfo(Hashtable aExistGroupInfo, string aType, string aValue1, string aValue2, string aValue3, string aValue4)
        {
            string bogyongCode = "";
            string bogyongName = "";
            string dv = "";
            string nalsu = "";
            string emergency = "";
            string wonyoi_order_yn = "";
            string donbogyn = "";
            string orderRemark = "";

            #region 기존 데이터 셋팅

            //if (aExistGroupInfo.Contains("bogyong_code"))
            //{
            //    bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            //}
            //if (aExistGroupInfo.Contains("bogyong_name"))
            //{
            //    bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            //}
            //if (aExistGroupInfo.Contains("dv"))
            //{
            //    dv = aExistGroupInfo["dv"].ToString();
            //}
            //if (aExistGroupInfo.Contains("nalsu"))
            //{
            //    nalsu = aExistGroupInfo["nalsu"].ToString();
            //}
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            //if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            //{
            //    wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            //}
            //if (aExistGroupInfo.Contains("donbog_yn"))
            //{
            //    donbogyn = aExistGroupInfo["donbog_yn"].ToString();
            //}
            //if (aExistGroupInfo.Contains("order_remark"))
            //{
            //    orderRemark = aExistGroupInfo["order_remark"].ToString();
            //}

            #endregion

            #region 변경에 따른 데이터 셋팅

            switch (aType)
            {
                case "bogyong_code":

                    bogyongCode = aValue1;
                    bogyongName = aValue2;
                    dv = aValue3;
                    donbogyn = aValue4;

                    break;

                case "nalsu":

                    nalsu = aValue1;

                    break;

                case "emergency":

                    emergency = aValue1;

                    break;

                case "wonyoi_order_yn":

                    wonyoi_order_yn = aValue1;

                    break;
            }

            #endregion

            this.ApplyGroupInfo(bogyongCode, bogyongName, dv, nalsu, emergency, wonyoi_order_yn, donbogyn, orderRemark);
        }

        /// <summary>
        /// 그룹정보 셋팅
        /// </summary>
        /// <param name="aBogyongCode">복용코드</param>
        /// <param name="aBogyongName">복용코드명칭</param>
        /// <param name="aDv">DV</param>
        /// <param name="aNalsu">날수</param>
        /// <param name="aEmergency">긴급</param>
        /// <param name="aWonyoiOrderYN">원외처방여부</param>
        /// <param name="aDonbogYN">돈복YN</param>
        /// <param name="aOrderRemark">오더코맨트</param>
        private void ApplyGroupInfo(string aBogyongCode, string aBogyongName, string aDv
                                   , string aNalsu, string aEmergency, string aWonyoiOrderYN, string aDonbogYN, string aOrderRemark)
        {
            // 탭인포에 적용
            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            this.tabGroup.SelectedTab.Title = tabInfo["group_ser"].ToString() + " グループ";

            if (aBogyongCode != "")
            {
                this.tabGroup.SelectedTab.Title += ":" + aBogyongName;
            }


            if (tabInfo.Contains("emergency"))
                tabInfo.Remove("emergency");
            tabInfo.Add("emergency", aEmergency);


            // 오더에 적용
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                // 같은 그룹의 오더들은 변경해준다.
                // 긴급
                if (this.grdOrder.GetItemString(i, "group_ser") == tabInfo["group_ser"].ToString())
                {
                    // 접수하기 전의 오더만 가능
                    if (this.grdOrder.GetRowState(i) == DataRowState.Added ||
                        (this.grdOrder.GetItemString(i, "ocs_flag") == "0" || this.grdOrder.GetItemString(i, "ocs_flag") == "1"))
                    {
                        // 긴급
                        if (this.grdOrder.GetItemString(i, "emergency") != aEmergency)
                        {
                            this.grdOrder.SetItemValue(i, "emergency", aEmergency);
                        }

                    }
                }
            }
        }

        #endregion

    }
}
