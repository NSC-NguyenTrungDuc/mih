#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.Injs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.Framework;
using IHIS.OCSO.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.CloudConnector.Contracts.Results.System;
using ComboListItemInfo = IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Arguments.System;

#endregion

namespace IHIS.OCSO
{
    /// <summary>
    /// INJ1001U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCINJ1001U01 : IHIS.Framework.XScreen
    {
        #region [DynService Control]

        private IHIS.Framework.SingleLayout mLayCommon = new SingleLayout();
        private DateTime currentDate;
        private bool isFirstLoad = true;

        #endregion

        #region Fields & Properties

        private XPatientBox patInfo = new XPatientBox();
        private XRadioButton rbtWait;
        private XRadioButton rbtDone;
        private XDatePicker dtpQueryDate;
        private string bunho;
        private string jubsuDate;
        private string orderDate;
        private string gwa;
        private string doctor;
        private string actor;
        private string actorName;
        public string JujongjaName;
        public string JujongjaCode;
        public XRadioButton RbtWait
        {
            get { return rbtWait; }
            set { rbtWait = value; }
        }

        public XRadioButton RbtDone
        {
            get { return rbtDone; }
            set { rbtDone = value; }
        }

        public XDatePicker DtpQueryDate
        {
            get { return dtpQueryDate; }
            set { dtpQueryDate = value; }
        }

        public XEditGrid GrdOCS1003
        {
            get { return grdOCS1003; }
        }

        public XMstGrid GrdDetail
        {
            get { return grdDetail; }
        }

        public string Bunho
        {
            get { return bunho; }
            set { bunho = value; }
        }

        public string JubsuDate
        {
            get { return jubsuDate; }
            set { jubsuDate = value; }
        }

        public string OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public string Gwa
        {
            get { return gwa; }
            set { gwa = value; }
        }

        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public string Actor
        {
            get { return actor; }
            set { actor = value; }
        }

        public string ActorName
        {
            get { return actorName; }
            set { actorName = value; }
        }

        #endregion

        public UCINJ1001U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
        }

        #region Common Method, Variable

        // 1.예약일자가 당일보다 작은거
        [Browsable(false), DataBindable]
        public string OrderGunBun
        {
            get { return mOrderGunBun; }
        }

        // 전달파트가 점적실인 경우IR 이고 그외는 IRH 
        [Browsable(false), DataBindable]
        public string JundalPart
        {
            get { return mJundalPart; }
        }

        private string mOrderGunBun = "1";
        private string mJundalPart = string.Empty;
        private string mGwa, mDoctor;

        private DataTable itemTable;

        #endregion

        #region 사용자 전역변수

        private string mPreOrderYn = "N", mPostOrderYn = "N"; //미래오더와 과거오더 유무확인 플래그
        private bool mOnReceiveBunho = false;
        private string mReceivedBunho = "";
        private string mReceivedDate = "";

        private int QueryTime;
        private int TimeVal;

        // 注射実施箋出力可否 
        private string injScripPrnYN = "";

        // ラベル出力可否 
        private string labelPrnYN = "";

        // 自動照会使用可否フラグ
        private string useTimeChkYN = "";

        // 受付チェックボックス一括適用フラグ
        private string chkAllJubsuYN = "";

        #endregion

        #region [환자정보 Reques/Receive Event]

        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            //if (info != null && !TypeCheck.IsNull(info.BunHo))
            //{
            //    mOnReceiveBunho = true;
            //    mReceivedBunho = info.BunHo;
            //    mReceivedDate = info.SuName;
            //    this.dtpQueryDate.DataValidating -=
            //        new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
            //    this.dtpQueryDate.SetDataValue(mReceivedDate);
            //    this.dtpQueryDate.DataValidating +=
            //        new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
            //    if (this.rbtWait.Checked)
            //    {
            //        xButtonList1_ButtonClick(null, new ButtonClickEventArgs(FunctionType.Query, false, false));
            //    }
            //    else
            //    {
            //        this.rbtWait.Checked = true;
            //    }

            //}
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        //public override XPatientInfo OnRequestBunHo()
        //{
        //    if (!TypeCheck.IsNull(patInfo.BunHo))
        //    {
        //        return new XPatientInfo(patInfo.BunHo, "", "", "", this.ScreenName);
        //    }
        //    return null;
        //}

        #endregion

        #region OnLoad

        private string mHospCode = "";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #endregion

        #region [PostLoad]

        private string btn_autoQuery_yn = null;
        private string btn_injPrint_yn = null;
        private string btn_labelPrint_yn = null;
        private void PostLoad()
        {


            //TODO: INJ1001U01MlayConstantInfoRequest
            // 注射画面コントロールデータ照会
            //            this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME
            //                                            FROM INJ0102
            //                                           WHERE HOSP_CODE = :f_hosp_code
            //                                             AND CODE_TYPE = 'INJ_CONSTANT'
            //                                        ORDER BY CODE";

            this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code").Equals("btn_autoQuery_yn"))
                        btn_autoQuery_yn = mlayConstantInfo.GetItemString(i, "code_name");

                    if (this.mlayConstantInfo.GetItemString(i, "code").Equals("btn_injPrint_yn"))
                        btn_injPrint_yn = mlayConstantInfo.GetItemString(i, "code_name");

                    if (this.mlayConstantInfo.GetItemString(i, "code").Equals("btn_labelPrint_yn"))
                        btn_labelPrint_yn = mlayConstantInfo.GetItemString(i, "code_name");
                }
            }

            // ボタン設定

            // 自動照会
            if (btn_autoQuery_yn.Equals("Y"))
            {
                this.useTimeChkYN = "Y";
                //this.btnUseTimeChk.ImageIndex = 3;

                //this.timer1.Start();
                //this.cboTime.Enabled = true;
            }
            else
            {
                this.useTimeChkYN = "N";
                //this.btnUseTimeChk.ImageIndex = 2;

                //this.cboTime.Enabled = false;
                //this.timer1.Stop();
            }

            // 注射実施箋出力
            if (btn_injPrint_yn.Equals("Y"))
            {
                this.injScripPrnYN = "Y";
                //this.btnInjActScrip.ImageIndex = 3;
            }
            else
            {
                this.injScripPrnYN = "N";
                //this.btnInjActScrip.ImageIndex = 2;
            }

            // ラベル出力
            if (btn_labelPrint_yn.Equals("Y"))
            {
                this.labelPrnYN = "Y";
                //this.btnLabel.ImageIndex = 3;
            }
            else
            {
                this.labelPrnYN = "N";
                //this.btnLabel.ImageIndex = 2;
            }

            // 実施者に 現在ログインしている IDを セットする｡
            //this.fbxActor.SetDataValue(UserInfo.UserID);
            //this.dbxActor_name.SetDataValue(UserInfo.UserName);
        }

        #endregion

        #region xButtonList1_ButtonClick

        private string mMsg = "";
        private string mCap = "";
        private bool mIsSaveSuccess = true;

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //case FunctionType.Update:
                case FunctionType.Process:
                    e.IsBaseCall = false;
                    mIsSaveSuccess = false;

                    if (this.grdDetail.RowCount < 1) return;

                    // 未投与の場合
                    if (this.rbtWait.Checked)
                    {
                        for (int i = 0; i < this.grdDetail.RowCount; i++)
                        {
                            if (this.grdDetail.GetItemValue(i, "acting_flag").ToString() == "Y")
                            {
                                if (!this.checkActor(i))
                                {
                                    XMessageBox.Show(Resources.INJ_XMessageBox1, Resources.INJ_Caption1,
                                        MessageBoxIcon.Information);
                                    //this.fbxActor.Focus();
                                    return;
                                }

                                if (!this.checkDate(i))
                                {
                                    return;
                                }
                            }
                        }
                    }

                    if (this.rbtDone.Checked)
                    {
                        foreach (DataRow dtRow in grdOCS1003.LayoutTable.Rows)
                        {
                            // 会計未処理のみ
                            if (dtRow["if_data_send_yn"].ToString() == "Y")
                            {
                                XMessageBox.Show(Resources.INJ_XMessageBox2, "", MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    this.grdDetailPreSaveLayout();

                    // 2015.04.27 deleted by AnhNV
                    // Connect to cloud: save grdDetail
                    //UpdateResult updateResult = GridDeatil_SaveLayout();
                    //if (updateResult != null && updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result)
                    //{
                    //    this.grdDetailSaveEnd();
                    //    this.mMsg = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox2_Ko
                    //        : Resources.XMessageBox2_JP;
                    //    this.mCap = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox3_Ko
                    //        : Resources.XMessageBox3_JP;
                    //    //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    mIsSaveSuccess = true;
                    //}
                    //else
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox4_Ko
                    //        : Resources.XMessageBox4_JP;
                    //    this.mMsg += "\r\n" + Service.ErrFullMsg;
                    //    this.mCap = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox5_Ko
                    //        : Resources.XMessageBox5_Jp;
                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    // 2015.04.27 Added by AnhNV

                    //MED-11162
                    if (!IHIS.Framework.Utilities.CheckInventory(grdDetail.LayoutTable))
                    {
                        return;
                    }

                    List<INJ1001U01SaveLayoutInfo> lstData = GetListDataForSaveLayout();

                    if (lstData.Count > 0)
                    {
                        INJ1001U01SaveLayoutArgs args = new INJ1001U01SaveLayoutArgs();
                        //args.UpdId = fbxActor.GetDataValue().ToString();
                        args.UpdId = this.actor;
                        args.UserId = UserInfo.UserID;
                        args.SaveLayoutItem = lstData;
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, INJ1001U01SaveLayoutArgs>(args);

                        if (res.ExecutionStatus == ExecutionStatus.Success)
                        {
                            if (!TypeCheck.IsNull(res.Msg))
                            {
                                XMessageBox.Show(Resources.INJ_XMessageBox13 + res.Msg + Resources.INJ_XMessageBox12, Resources.INJ_Caption4, MessageBoxIcon.Warning);
                            }

                            if (res.Result)
                            {
                                this.grdDetailSaveEnd();
                                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox2_Ko : Resources.INJ_XMessageBox2_JP;
                                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox3_Ko : Resources.INJ_XMessageBox3_JP;
                                //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mIsSaveSuccess = true;
                            }
                            else
                            {
                                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox4_Ko : Resources.INJ_XMessageBox4_JP;
                                this.mMsg += "\r\n" + Service.ErrFullMsg;
                                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox5_Ko : Resources.INJ_XMessageBox5_Jp;
                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox4_Ko : Resources.INJ_XMessageBox4_JP;
                            this.mMsg += "\r\n" + Service.ErrFullMsg;
                            this.mCap = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox5_Ko : Resources.INJ_XMessageBox5_Jp;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.clearDetailScreen();

                    //this.grdMaster.QueryLayout(true);

                    if (this.mOnReceiveBunho)
                    {
                        //grdMaster.SetFocusToItem(mReceiveBunhoRowNum, "bunho");

                        /*modify by CloudVersion team on 07-12-2015
                         *Bug MED-5868
                         * mReceiveBunhoRowNum = current row number of grdMaster
                         * mReceivedBunho = current patient ID
                         * => change logic: mReceiveBunhoRowNum to mReceivedBunho
                         */
                        //this.patInfo.SetPatientID(mReceiveBunhoRowNum.ToString());
                        //this.patInfo.SetPatientID(mReceivedBunho.ToString());

                        mOnReceiveBunho = false;
                    }

                    // Simple version
                    if (!TypeCheck.IsNull(this.bunho))
                    {
                        this.grdOCS1003.QueryLayout(true);
                        this.grdDetail.QueryLayout(true);
                    }

                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 오더 코멘트 처리

        // order_comment
        private void Comment_MSG(bool dis_flag)
        {
            string remark = string.Empty;
            string reser_date = string.Empty;
            string curr_date = string.Empty;
            string msg = string.Empty;

            curr_date = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "reser_date").ToString().Trim();

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                remark = grdDetail.GetItemString(i, "remark_chk").Trim();
                reser_date = grdDetail.GetItemString(i, "reser_date").ToString().Trim();

                if ((remark.Length > 0) && (reser_date == curr_date))
                {
                    msg += "・ " + remark + "\r\n";
                }
            }

            if (msg.Length > 0)
            {
                //txtOrdRemark.Text = msg;
                if (dis_flag)
                {
                    XMessageBox.Show(msg, Resources.INJ_XMessageBox6);
                }
            }
            else
            {
                //txtOrdRemark.Text = string.Empty;
            }
        }

        #endregion

        #region grdDetail 선택환자의 오더 묶음

        private void grdDetail_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            //hsyhsy
            //처방은 당일 시행 오더와 과거, 미래 오더는 별도의 색으로 구분하여 표시한다.
            DateTime ot = DateTime.Parse(e.DataRow["reser_date"].ToString());
            DateTime queryDate = DateTime.Parse(this.dtpQueryDate.GetDataValue());
            if (ot.CompareTo(queryDate) == 0)
            {
                e.BackColor = Color.White;
            }
            else
            {
                e.BackColor = XColor.XLabelGradientEndColor.Color;
            }

            if (e.RowNumber < 1) return;
        }

        private void grdDetail_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {

            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                if (e.RowNumber == i)
                {
                    this.grdDetail.SetItemValue(i, "acting_flag", e.ChangeValue.ToString());
                    this.grdDetail.SetItemValue(i, "jubsu_date",
                        (e.ChangeValue.ToString() == "Y" ? this.dtpActingDate.GetDataValue() : ""));
                    //this.grdDetail.SetItemValue(i, "old_acting_flag", this.grdDetail.GetItemString(i, "jubsu_date"));
                    this.grdDetail.SetItemValue(i, "acting_date",
                        (e.ChangeValue.ToString() == "Y" ? this.dtpActingDate.GetDataValue() : ""));
                    this.grdDetail.SetItemValue(i, "jujongja",
                        (e.ChangeValue.ToString() == "Y" ? this.actor : ""));
                    this.grdDetail.SetItemValue(i, "jujongja_name",
                        (e.ChangeValue.ToString() == "Y" ? this.actorName : ""));

                    continue;
                }

                if (e.DataRow["mix_group"].ToString() == "")
                    continue;

                if (e.DataRow["group_ser"].ToString() == this.grdDetail.GetItemString(i, "group_ser") &&
                    e.DataRow["mix_group"].ToString() == this.grdDetail.GetItemString(i, "mix_group") &&
                    e.DataRow["hope_date"].ToString() == this.grdDetail.GetItemString(i, "hope_date") &&
                    e.DataRow["order_date"].ToString() == this.grdDetail.GetItemString(i, "order_date") &&
                    e.DataRow["order_gubun"].ToString().Trim().PadRight(2).Substring(1, 1) ==
                    this.grdDetail.GetItemString(i, "order_gubun").Trim().PadRight(2).Substring(1, 1))
                {
                    this.grdDetail.SetItemValue(i, "acting_flag", e.ChangeValue.ToString());
                    this.grdDetail.SetItemValue(i, "jubsu_date",
                        (e.ChangeValue.ToString() == "Y" ? this.dtpActingDate.GetDataValue() : ""));
                    //this.grdDetail.SetItemValue(i, "old_acting_flag", this.grdDetail.GetItemString(i, "jubsu_date"));
                    this.grdDetail.SetItemValue(i, "acting_date",
                        (e.ChangeValue.ToString() == "Y" ? this.dtpActingDate.GetDataValue() : ""));
                    this.grdDetail.SetItemValue(i, "jujongja",
                        (e.ChangeValue.ToString() == "Y" ? this.actor : ""));
                    this.grdDetail.SetItemValue(i, "jujongja_name",
                        (e.ChangeValue.ToString() == "Y" ? this.actorName : ""));
                }
            }

            itemTable.Rows.Clear();
        }

        private void grdDetail_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            //hsyhsy
            switch (e.ColName)
            {
                case "acting_flag":
                    //if (e.DataRow["acting_flag"].ToString() == "Y")
                    //{
                    //    if (e.DataRow["sunab_date"].ToString() != "")
                    //    {
                    //        e.Protect = true;
                    //        XMessageBox.Show(Resources.XMessageBox2, "", MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    //						DateTime ot = DateTime.Parse(e.DataRow["reser_date"].ToString());
                    //    //						if (mToDay.CompareTo(ot) != 0)
                    //    //						{
                    //    //							e.Protect = true;
                    //    //							string msg = (NetInfo.Language == LangMode.Ko ? "예약일자를 확인하시기 바랍니다." : 
                    //    //								"予約日付 ご確認くださいい");
                    //    //							XMessageBox.Show(msg);
                    //    //							return;;
                    //    //						}
                    //}
                    break;

                case "acting_date": // 投与済TABでは変更不可能
                    if (this.rbtDone.Checked) e.Protect = true;
                    return;

                default:
                    break;
            }

            e.Protect = false;
        }

        private void grdDetailQuery(string bunho, string reser_date, string gwa, string doctor, string acting_date)
        {
            //dsvDetail.ClearInLayout();


            if (!grdDetail.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }


        }

        private void grdDetail_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.layCPLOrderYN.QueryLayout();

            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);

            if (this.rbtWait.Checked) //선택한 버튼이 미투여버튼일 때. 2011.12.15
            {
                this.AutoCheck(); //자동 실시 체크 추가 2011.12.07 woo
                this.InputActingDate();
            }


            if (!_GroupedLoad)
            {
                _GroupedLoad = true;
                //if (!this.grdNUR1016.QueryLayout(false))
                //{
                //    //XMessageBox.Show(Service.ErrFullMsg);
                //}
                //if (!this.grdNUR1017.QueryLayout(false))
                //{
                //    //XMessageBox.Show(Service.ErrFullMsg);
                //}
                //if (!this.grdOUT0106.QueryLayout(false))
                //{
                //    //XMessageBox.Show(Service.ErrFullMsg);
                //}
            }
            _GroupedLoad = false;
        }

        private void AutoCheck()
        {
            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                //조회된 로우를 돌면서
                //if (this.dtpQueryDate.GetDataValue().Equals(this.grdDetail.GetItemValue(i, "reser_date").ToString()))
                //{//조회 날짜와 예약날짜가 같으면
                this.grdDetail.SetItemValue(i, "acting_flag", "Y"); //실시에 자동체크
                this.grdDetail.SetItemValue(i, "jujongja", this.actor); //실시자 이름을 넣는다.
                this.grdDetail.SetItemValue(i, "jujongja_name", this.actorName);
                this.grdDetail.SetItemValue(i, "acting_date", this.dtpActingDate.GetDataValue());
                // }
            }

            // GRIDのFONT色を元に戻す。
            //this.grdDetail.ResetUpdate();
        }

        //20120314 woo
        private void InputActingDate()
        {
            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                this.grdDetail.SetItemValue(i, "acting_date", this.dtpActingDate.GetDataValue().ToString());
            }
        }

        private void grdDetail_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //this.grdSang.QueryLayout(true);

            if (this.grdDetail.RowCount < 1) return;

            // 未投与の場合
            //if (this.rdoWait.Checked)
            //{
            //    this.AutoInputInfo(this.fbxActor.GetDataValue(), this.dbxActor_name.GetDataValue());
            //}
            JujongjaName = this.grdDetail.GetItemString(e.CurrentRow, "jujongja_name");
            JujongjaCode = this.grdDetail.GetItemString(e.CurrentRow, "jujongja");
            if (this.RowFocusHandler != null)
            {
                this.RowFocusHandler(this, e);
            }
            // 投与済の場合
            //if (this.rbtDone.Checked)
            //{
            //    this.fbxActor.SetDataValue(this.grdDetail.GetItemString(e.CurrentRow, "jujongja"));
            //    this.dbxActor_name.SetDataValue(this.grdDetail.GetItemString(e.CurrentRow, "jujongja_name"));
            //}
        }
        public event RowFocusChangedEventHandler RowFocusHandler;

        #region grdDetailPreSaveLayout

        private void grdDetailPreSaveLayout()
        {
            //hsyhsy
            string fkinj1001 = String.Empty;
            string groupSer = String.Empty;
            string mixGroup = String.Empty;
            string hopeDate = String.Empty;
            string orderDate = String.Empty;
            string orderGubun = String.Empty;
            string doctor = string.Empty;
            string gwa = string.Empty;

            bool isExist = false;
            DataRow dtRow = null;


            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                if (this.grdDetail.GetRowState(i) == DataRowState.Modified)
                {

                    //액팅된 건수를 데이타 테이블에 담아 dsvSave_ServiceEnd에서 건수 만큼 라벨출력한다.
                    if (grdDetail.GetItemValue(i, "acting_flag").ToString().Trim() == "Y")
                    {
                        doctor = this.grdDetail.GetItemString(i, "doctor").Trim();

                        //주석 20120302 woo
                        //grdDetail.SetItemValue(i, "acting_date", dtpActingDate.GetDataValue());
                        //grdDetail.SetItemValue(i, "jujongja", txtConfirmUser.GetDataValue());

                        fkinj1001 = this.grdDetail.GetItemString(i, "fkinj1001").Trim();
                        groupSer = this.grdDetail.GetItemString(i, "group_ser").Trim();
                        mixGroup = this.grdDetail.GetItemString(i, "mix_group").Trim();
                        hopeDate = this.grdDetail.GetItemString(i, "hope_date").Trim();
                        orderDate = this.grdDetail.GetItemString(i, "order_date").Trim();
                        orderGubun = this.grdDetail.GetItemString(i, "order_gubun").Trim();
                        gwa = this.grdDetail.GetItemString(i, "gwa").Trim();


                        isExist = false;
                        // 그룹mix가 ""이면 단일 그룹으로 본다
                        if (mixGroup != "")
                        {
                            if (itemTable.Rows.Count > 0)
                            {
                                // 중복rp,mix구분은 한건만 저장한다.
                                foreach (DataRow row in this.itemTable.Rows)
                                {
                                    if (row["mix_group"].ToString() == "")
                                        continue;

                                    if ((row["group_ser"].ToString() == groupSer) &&
                                        (row["mix_group"].ToString() == mixGroup) &&
                                        (row["hope_date"].ToString() == hopeDate) &&
                                        (row["order_date"].ToString() == orderDate) &&
                                        (row["order_gubun"].ToString().Trim().PadRight(2).Substring(1, 1) ==
                                         orderGubun.Trim().PadRight(2).Substring(1, 1)))
                                    {
                                        isExist = true;
                                        break;
                                    }
                                }
                            }
                        }

                        //데이타 설정
                        if (!isExist)
                        {
                            dtRow = itemTable.NewRow();
                            dtRow["fkinj1001"] = fkinj1001;
                            dtRow["group_ser"] = groupSer;
                            dtRow["mix_group"] = mixGroup;
                            dtRow["hope_date"] = hopeDate;
                            dtRow["order_date"] = orderDate;
                            dtRow["order_gubun"] = orderGubun;
                            dtRow["gwa"] = gwa;
                            dtRow["doctor"] = doctor;
                            itemTable.Rows.Add(dtRow);
                            itemTable.AcceptChanges();
                        }
                    }
                    else // 取消の場合実施記録を消す。
                    {
                        this.grdDetail.SetItemValue(i, "silsi_remark", "");
                    }
                }
            }
        }

        #endregion

        #region grdDetailSaveEnd

        private void grdDetailSaveEnd()
        {
            if (this.rbtWait.Checked)
            {
                string mGroupSer = String.Empty;
                string mMixGroup = String.Empty;
                foreach (DataRow row in this.itemTable.Rows)
                {
                    _LayLableNewBc.Clear();
                    _LayLableNewBc.Add("f_hosp_code", this.mHospCode);
                    //_LayLableNewBc.Add("f_bunho", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "bunho"));
                    //_LayLableNewBc.Add("f_jubsu_date", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "jubsu_date"));
                    //_LayLableNewBc.Add("f_gwa", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "gwa"));
                    //_LayLableNewBc.Add("f_doctor", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "doctor"));
                    _LayLableNewBc.Add("f_bunho", this.bunho);
                    _LayLableNewBc.Add("f_jubsu_date", this.jubsuDate);
                    _LayLableNewBc.Add("f_gwa", this.gwa);
                    _LayLableNewBc.Add("f_doctor", this.doctor);
                    _LayLableNewBc.Add("f_group_ser", row["group_ser"].ToString());
                    _LayLableNewBc.Add("f_mix_group", row["mix_group"].ToString());
                    _LayLableNewBc.Add("f_fkinj1001", row["fkinj1001"].ToString());
                    _LayLableNewBc.Add("f_hosp_code", this.mHospCode);

                    //layLableNew.SetBindVarValue("f_hosp_code", this.mHospCode);
                    //layLableNew.SetBindVarValue("f_bunho", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "bunho"));
                    //layLableNew.SetBindVarValue("f_jubsu_date", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "jubsu_date"));
                    //layLableNew.SetBindVarValue("f_gwa", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "gwa"));
                    //layLableNew.SetBindVarValue("f_doctor",grdMaster.GetItemString(grdMaster.CurrentRowNumber, "doctor"));
                    //layLableNew.SetBindVarValue("f_group_ser", row["group_ser"].ToString());
                    //layLableNew.SetBindVarValue("f_mix_group", row["mix_group"].ToString());
                    //layLableNew.SetBindVarValue("f_fkinj1001", row["fkinj1001"].ToString());
                    //layLableNew.SetBindVarValue("f_hosp_code", this.mHospCode);

                    // ラベル出力ボタンがチェックされている場合、自動出力する。
                    if (this.labelPrnYN.Equals("Y")) this.prtLabel();
                }

                // 注射実施箋出力ボタンがチェックされている場合、自動出力する。
                if (this.injScripPrnYN.Equals("Y")) this.prtInjActScrip();
            }
            clearDetailScreen(); //디테일 화면 클리어
            //this.grdMaster.QueryLayout(false); //마스터 조회
        }

        #endregion

        #endregion

        #region 조회일자

        private void dtpQueryDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region Patient Box

        private void patInfo_PatientSelected(object sender, System.EventArgs e)
        {
            //
            //if (patInfo.Tag == null) patInfo.Tag = "";
            ////if(patInfo.Tag.ToString() == patInfo.BunHo ) return;
            ///* 같은환자를 두번째 직접 입력으로 검색할 때
            // * 태그가 남아있어서 리턴이되어버린다. 어쩔 것인가?? 2011.12.10 woo*/

            ////this.fbxActor.ResetText();
            ////this.dbxActor_name.ResetText();

            //patInfo.Tag = patInfo.BunHo;

            //lbSuname.Text = patInfo.SuName;
            //lbSex.Text = patInfo.Sex;
            //lbAge.Text = patInfo.YearAge.ToString();
            //lbAddress.Text = patInfo.Address1 + patInfo.Address2;

            //this.grdOCS1003.QueryLayout(false); //해당환자의 예약날짜별 과별 의사별 묶음 woo
            ////this.grdSilsiRemark.QueryLayout(false);

            //if (!_GroupedLoad)
            //{
            //    _GroupedLoad = true;
            //    this.grdNUR1016.QueryLayout(false); //해당 환자 알레르기 내용 woo
            //    this.grdNUR1017.QueryLayout(false); //해당 환자 감염증 내용 
            //    this.grdOUT0106.QueryLayout(false); //해당 환자의 특기사항 내용 woo 
            //}
            //_GroupedLoad = false;

            ////해당환자의 미래예약이 있나 확인
            //this.layReserDate.SetBindVarValue("f_bunho", patInfo.BunHo);
            //this.layReserDate.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            //this.layReserDate.SetBindVarValue("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");
            //this.layReserDate.QueryLayout(false);

            //this.fbxActor.Focus();
        }

        //환자번호를 잘못입력했거나 널값인 경우 추가 2011.12.12 woo
        private void patInfo_PatientSelectionFailed(object sender, EventArgs e)
        {
            clearDetailScreen();
        }

        #endregion

        #region 화면 클리어 2011.12.12 woo

        private void clearDetailScreen()
        {
            //this.patInfo.Reset();
            this.grdDetail.Reset();
            //this.grdNUR1016.Reset();
            //this.grdNUR1017.Reset();
            //this.grdOUT0106.Reset();
            this.grdOCS1003.Reset();
            //this.grdSang.Reset();
            this.pbxReserDate.Visible = false;
            this.pbxCPL.Visible = false;
            this.btnCPL.Visible = false;
            this.dtpActingDate.SetDataValue(currentDate); //오늘 날짜로 변경

            //this.fbxActor.ResetData();
            //this.fbxActor.Focus();
        }

        #endregion

        #region grdMaster 관련

        #region grdMaster_GridCellPainting

        private void grdMaster_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            ////항암
            //if (e.DataRow["chkb"].ToString() == "Y")
            //{
            //    e.ForeColor = XColor.ErrMsgForeColor.Color;
            //    grdMaster[e.RowNumber + 2, 0].ToolTipText = "抗癌";
            //    grdMaster[e.RowNumber + 2, 0].Image = this.ImageList.Images[6];
            //}

            ////당일오더면
            //if (e.DataRow["reser_gubun"].ToString() == "1")
            //{
            //    if (e.ColName == "reser_gubun")
            //        e.ForeColor = Color.Blue;
            //}

            ////예약오더면
            //if (e.DataRow["reser_gubun"].ToString() == "2")
            //{
            //    e.BackColor = Color.LightGreen;
            //}
            ////trial patient
            //if (e.DataRow["trial_patient_yn"].ToString() == "Y")
            //{
            //    grdMaster[e.RowNumber + 1, 1].ToolTipText = Resources.SMS_TRIAL;
            //}
            ////Don't show tooltip values "N" in Xcell
            //if (e.DataRow["trial_patient_yn"].ToString() == "N")
            //{
            //    grdMaster[e.RowNumber + 1, 1].ToolTipText = " ";
            //}

        }

        #endregion

        #region grdMaster_QueryStarting

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            //grdMaster.ParamList = new List<string>(new String[] { "f_reser_date", "f_acting_flag", "f_gwa" });

            //this.grdMaster.SetBindVarValue("f_hosp_code", this.mHospCode);
            //this.grdMaster.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            //this.grdMaster.SetBindVarValue("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");
            //this.grdMaster.SetBindVarValue("f_gwa", xBuseoCombo1.GetDataValue());
        }

        #endregion

        #region grdMaster_QueryEnd

        private int mReceiveBunhoRowNum = -1;

        
        private void grdMaster_QueryEnd(object sender, QueryEndEventArgs e)
        {
//            if (e.IsSuccess)
//            {
//                //InjsINJ1001U01ChkbStateRequest
//                string cmdText = @"SELECT DISTINCT 
//                                      NVL(C.CHKB,'N')
//                                  FROM INV0110 C
//                                      ,INJ1001 B
//                                      ,INJ1002 A
//                                 WHERE A.HOSP_CODE             = :f_hosp_code
//                                   AND B.HOSP_CODE             = A.HOSP_CODE
//                                   AND B.HOSP_CODE             = A.HOSP_CODE
//                                   AND A.RESER_DATE            = TO_DATE(:f_reser_date,'YYYY/MM/DD')
//                                   AND NVL(A.ACTING_FLAG, 'N') = :f_acting_flag
//                                   AND B.BUNHO                 = :f_bunho
//                                   AND B.PKINJ1001             = A.FKINJ1001
//                                   AND B.DOCTOR                = :f_doctor
//                                   AND C.JAERYO_CODE           = A.HANGMOG_CODE
//                                   AND NVL(C.CHKB,'N')         = 'Y' ";

//                object chkb = null;
//                BindVarCollection bc = new BindVarCollection();
//                bc.Add("f_hosp_code", this.mHospCode);
//                bc.Add("f_reser_date", this.dtpQueryDate.GetDataValue());
//                bc.Add("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");

//                _InjsINJ1001U01ChkbStateArgs.ActingFlag = bc["f_acting_flag"].VarValue;
//                _InjsINJ1001U01ChkbStateArgs.ReserDate = bc["f_reser_date"].VarValue;

//                mReceiveBunhoRowNum = -1;

//                for (int i = 0; i < this.grdMaster.RowCount; i++)
//                {
//                    bc.Add("f_bunho", this.grdMaster.GetItemString(i, "bunho"));
//                    bc.Add("f_doctor", this.grdMaster.GetItemString(i, "doctor"));

//                    _InjsINJ1001U01ChkbStateArgs.Bunho = bc["f_bunho"].VarValue;
//                    _InjsINJ1001U01ChkbStateArgs.Doctor = bc["f_doctor"].VarValue;

//                    //chkb = Service.ExecuteScalar(cmdText, bc);
//                    _InjsINJ1001U01ChkbStateResult =
//                        CloudService.Instance.Submit<InjsINJ1001U01ChkbStateResult, InjsINJ1001U01ChkbStateArgs>(_InjsINJ1001U01ChkbStateArgs);
//                    if (_InjsINJ1001U01ChkbStateResult != null)
//                    {
//                        chkb = _InjsINJ1001U01ChkbStateResult.Result;
//                    }

//                    if (!TypeCheck.IsNull(chkb))
//                    {
//                        this.grdMaster.SetItemValue(i, "chkb", chkb.ToString());
//                    }

//                    if (this.mOnReceiveBunho)
//                    {
//                        if (this.mReceiveBunhoRowNum == -1)
//                        {
//                            if (this.mReceivedBunho == this.grdMaster.GetItemString(i, "bunho"))
//                            {
//                                mReceiveBunhoRowNum = i;
//                            }
//                        }
//                    }
//                }
//            }
        }

        #endregion

        #region grdMaster_MouseDown (2011.12.09 woo)

        /* 기존에는 rowFocusChanged 였는데 그렇게하면 처리도중에 자동조회로 환자 목록이 조회되고 
         * rowFocusChanged 를 타 상세내용이 조회될 수 있기때문에 클릭시로 조회타게 변경*/

        private void grdMaster_MouseDown(object sender, MouseEventArgs e)
        {

            //if (e.Button == MouseButtons.Left)
            //{
            //    int row = this.grdMaster.GetHitRowNumber(e.Y);  //좌표값을 그리드 로우값으로 변환

            //    if (row < 0) //클릭한 곳이 그리드의 공백이라면 리턴리턴~
            //        return;

            //    this.pbxReserDate.Visible = false;
            //    this.pbxCPL.Visible = false;
            //    this.btnCPL.Visible = false;
            //    this.patInfo.Reset();
            //    this.patInfo.Tag = null;

            //    //this.fbxActor.ResetText();
            //    //this.dbxActor_name.ResetText();
            //    // 왼쪽의 그리드의 환자를 클릭했을 경우에는 버튼 조작 가능하게 한다.
            //    //this.btnTodayOrder.Enabled = true;
            //    //this.btnPreOrder.Enabled = true;
            //    //this.btnPostOrder.Enabled = true;
            //    //this.pbxReserDate.Enabled = true;
            //    this.dtpActingDate.SetDataValue(EnvironInfo.GetSysDate());  //오늘 날짜로 변경

            //    readOCS1003(row);
            //    this.fbxActor.Focus();
            //}

        }

        #endregion


        #endregion

        #region SetPrint

        private string SetPrint(XDataWindow dw_print, bool lable_yn)
        {
            string print_name = "";

            if (lable_yn)
            {
                //foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                //{
                //    if (s == "OneNote 2007")
                //    {
                //        print_name = "OneNote 2007";
                //        break;
                //    }
                //    else
                //    {
                //        if (s.IndexOf("OneNote") >= 0)
                //            print_name = s;
                //    }
                //}

                //if (print_name.IndexOf("OneNote") < 0)
                //{
                //    MessageBox.Show("ラベルプリンタの設定がされていません。");
                //    //dw_print.PrintDialog(true);
                //}

                foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    //if (s == "EPSON TM-C100")
                    //{
                    //    print_name = "EPSON TM-C100";
                    //    break;
                    //}
                    //else
                    //{
                    //    if (s.IndexOf("TM") >= 0)
                    //        print_name = s;
                    //}
                    if (s == "SATO")
                    {
                        print_name = "SATO";
                        break;
                    }
                    else
                    {
                        if (s.IndexOf("SATO") >= 0)
                            print_name = s;
                    }
                }

                if (print_name.IndexOf("TM") < 0)
                {
                    //XMessageBox.Show("ラベルプリンタの設定がされていません。", "確認", MessageBoxIcon.Information);
                    dw_print.PrintDialog(true);
                }


                //}

                //if ( print_name.IndexOf("SATO") < 0 )
                //{
                //    MessageBox.Show("ラベルプリンタの設定がされていません。");
                //    //dw_print.PrintDialog(true);
                //}
            }
            else
            {
                print_name = dw_print.PrintProperties.PrinterName;
            }

            return print_name;
        }

        #endregion

        #region [btnReInjActScrip_Click 注射実施箋ボタンクリック]

        private void btnReInjActScrip_Click(object sender, EventArgs e)
        {
            if (this.grdDetail.RowCount > 0) this.prtInjActScrip();
            else return;
        }

        #endregion

        #region [prtInjActScrip 注射実施箋]

        private void prtInjActScrip()
        {
            // Updated by Cloud
            try
            {
                layTemp.ParamList = new List<string>(new string[]
                                                     {
                                                         "f_bunho",
                                                         "f_jubsu_date",
                                                         "f_doctor",
                                                         "f_hosp_code",
                                                         "f_reser_date",
                                                     });
                //layTemp.SetBindVarValue("f_bunho", this.patInfo.BunHo);
                layTemp.SetBindVarValue("f_bunho", this.bunho);
                layTemp.SetBindVarValue("f_jubsu_date", this.dtpActingDate.GetDataValue());
                layTemp.SetBindVarValue("f_doctor",
                    this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "doctor"));
                layTemp.SetBindVarValue("f_hosp_code", this.mHospCode);
                layTemp.SetBindVarValue("f_reser_date",
                    this.grdDetail.GetItemValue(this.grdDetail.CurrentRowNumber, "reser_date").ToString());

                layTemp.ExecuteQuery = GetLayTemp;

                layTemp.QueryLayout(true);
            }
            catch
            {

            }

        }

        #endregion

        #region btnLabel_Click

        private void btnReLabel_Click(object sender, System.EventArgs e)
        {
            this.prtLabel();
        }

        private void prtLabel()
        {
            //layLableNew.SetBindVarValue("f_bunho", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho"));
            //layLableNew.SetBindVarValue("f_jubsu_date", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "jubsu_date"));
            //layLableNew.SetBindVarValue("f_gwa", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "gwa"));
            //layLableNew.SetBindVarValue("f_doctor", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "doctor"));
            //layLableNew.SetBindVarValue("f_group_ser", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "group_ser"));
            //layLableNew.SetBindVarValue("f_mix_group", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "mix_group"));
            //layLableNew.SetBindVarValue("f_fkinj1001", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "fkinj1001"));
            //layLableNew.SetBindVarValue("f_hosp_code", this.mHospCode);

            _LayLableNewBc.Clear();
            _LayLableNewBc.Add("f_bunho", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho"));
            _LayLableNewBc.Add("f_jubsu_date", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "jubsu_date"));
            _LayLableNewBc.Add("f_gwa", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "gwa"));
            _LayLableNewBc.Add("f_doctor", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "doctor"));
            _LayLableNewBc.Add("f_group_ser", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "group_ser"));
            _LayLableNewBc.Add("f_mix_group", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "mix_group"));
            _LayLableNewBc.Add("f_fkinj1001", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "fkinj1001"));
            _LayLableNewBc.Add("f_hosp_code", this.mHospCode);


            layLableNew.QueryLayout(true);
        }

        #endregion

        #region 예약변경 버튼 클릭

        private void btnReser_Click(object sender, System.EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("INJS", "INJ1002U01");

            if (aScreen == null)
            {
                string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                openParams.Add("queryDate", this.dtpQueryDate.GetDataValue());
                openParams.Add("gwa", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "gwa"));
                openParams.Add("doctor", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "doctor"));
                //this.timer1.Stop();
                XScreen.OpenScreenWithParam(this, "INJS", "INJ1002U01", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);

                //if (this.useTimeChkYN.Equals("Y")) this.timer1.Start();
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }

            //this.grdMaster.QueryLayout(true);

            this.patInfo.SetPatientID("");
            //this.grdOCS1003.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회
            //this.layReserDate.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            //this.layReserDate.SetBindVarValue("f_acting_flag", this.rdoWait.Checked ? "N" : "Y");
            //this.layReserDate.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            //this.layReserDate.QueryLayout(false);
        }

        #endregion

        #region btnPreOrder

        private void btnPreOrder_Click(object sender, System.EventArgs e)
        {
            string bunho, reser_date; //, order_date;

            if (mPreOrderYn == "Y")
            {
                mPreOrderYn = "N";
                btnPreOrder.ImageIndex = 2;
            }
            else
            {
                mPreOrderYn = "Y";
                btnPreOrder.ImageIndex = 3;
            }

            //MED-9970
            if (this.dtpQueryDate == null) return;

            bunho = patInfo.BunHo;
            reser_date = this.dtpQueryDate.GetDataValue();

            this.grdOCS1003.QueryLayout(false); //2011.12.14 woo

        }

        #endregion

        #region btnPostOrder

        private void btnPostOrder_Click(object sender, System.EventArgs e)
        {
            string bunho, reser_date; //, order_date;
            int row;
            if (mPostOrderYn == "Y")
            {
                mPostOrderYn = "N";
                btnPostOrder.ImageIndex = 2;
            }
            else
            {
                mPostOrderYn = "Y";
                btnPostOrder.ImageIndex = 3;
            }

            //MED-9970
            if (this.dtpQueryDate == null) return;

            //row = grdMaster.CurrentRowNumber;
            //bunho = patInfo.BunHo;
            /* 직접 번호를 입력해서 환자의 오더 검색 시 옆의 그리드의 예약날짜를 받아오기때문에 
             * 그리드가 없으면 널값이 들어가 조회날짜를 받아오게 일단 변경. 2011.12.10 woo*/
            //reser_date = this.dtpQueryDate.GetDataValue();
            //reser_date = grdMaster.GetItemString(row, "reser_date");
            //order_date  = grdMaster.GetItemString(row, "order_date");
            //grdDetailQuery(bunho, reser_date, order_date, mGwa, mDoctor);
            this.grdOCS1003.QueryLayout(false); //2011.12.14 woo
            //grdDetailQuery(bunho, reser_date, mGwa, mDoctor);
            //grdOCS1003.ExecuteQuery = QueryGrdOCS1003;
        }

        #endregion

        #region btnTodayOrder_Click

        private void btnTodayOrder_Click(object sender, System.EventArgs e)
        {
            string bunho, reser_date; //, order_date;

            mPostOrderYn = "N";
            btnPostOrder.ImageIndex = 2;

            mPreOrderYn = "N";
            btnPreOrder.ImageIndex = 2;

            //MED-9970
            if (this.dtpQueryDate == null) return;

            bunho = patInfo.BunHo;
            reser_date = this.dtpQueryDate.GetDataValue();

            this.grdOCS1003.QueryLayout(false); //2011.12.14 woo

        }

        #endregion

        #region layLableNew_QueryEnd
        /// <summary>
        /// TODO: Print datawindow after saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layLableNew_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                if (layLableNew.RowCount > 0)
                {
                    int cnt = layLableNew.GetItemInt(0, "cnt");

                    #region 주사라벨

                    //tungtx added 2015/07/16
                    //this.pnlBottom.Controls.Remove(this.dw_jusa_lable);
                    //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ1001U01));
                    ////this.dw_jusa_lable = new IHIS.Framework.XDataWindow();
                    //resources.ApplyResources(this.dw_jusa_lable, "dw_jusa_lable");
                    //this.dw_jusa_lable.DataWindowObject = "d_inj_jusa_lable";
                    //this.dw_jusa_lable.LibraryList = "\\INJS\\injs.inj1001u01.pbd";
                    //this.dw_jusa_lable.Name = "dw_jusa_lable";
                    //this.pnlBottom.Controls.Add(this.dw_jusa_lable);

                    dw_jusa_lable.SetRedrawOff();
                    dw_jusa_lable.Reset();
                    dw_jusa_lable.FillData(layLableNew.LayoutTable);
                    dw_jusa_lable.SetRedrawOn();
                    dw_jusa_lable.Refresh();

                    try
                    {
                        //string origin_print = SetPrint(dw1, false);
                        //string print_name = SetPrint(dw1, true);

                        //바코드프린터명 가져오기
                        if (dw_jusa_lable.RowCount <= 0)
                            this.layPrintName.QueryLayout();
                        string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

                        // lable print set
                        try
                        {
                            //if (print_name != "")
                            //    IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);

                            //for (int i = 0; i < cnt; i++)
                            //{
                            //    dw_jusa_lable.Print();
                            //}
                            //// 기본프린터 set
                            ////if (origin_print != "")
                            //// 기본프린터 set　수정 2012.01.11 woo
                            //IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
                            //if (origin_print != "")
                            //{
                            //    if (origin_print != this.dw_jusa_lable.PrintProperties.PrinterName)
                            //        IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
                            //}


                            dw_jusa_lable.PrintProperties.PrinterName = printSetName;

                            for (int i = 0; i < cnt; i++)
                            {
                                dw_jusa_lable.Print();
                            }

                        }
                        catch
                        {
                        }
                    }
                    catch
                    {
                    }

                    #endregion
                }
            }
        }

        #endregion

        #region layTemp_QueryEnd

        private void layTemp_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                //string tRemark = "";
                //layOrderPrint.Reset();

                //int rowNum = -1;
                //for (int i = 0; i < layTemp.RowCount; i++)
                //{
                //    rowNum = layOrderPrint.InsertRow(-1);

                //    for (int k = 0; k < layTemp.LayoutTable.Columns.Count; k++)
                //    {
                //        if (layTemp.GetItemString(i, "order_remark_temp") != "")
                //        {
                //            if (tRemark == "")
                //                tRemark = "@ " + layTemp.GetItemString(i, "order_remark_temp");
                //            else
                //                tRemark += tRemark + ", " + layTemp.GetItemString(i, "order_remark_temp");
                //        }

                //        if (layTemp.LayoutTable.Columns[k].ColumnName == "order_remark_temp")
                //            continue;

                //        layOrderPrint.SetItemValue(rowNum, layTemp.LayoutTable.Columns[k].ColumnName, layTemp.GetItemString(i, layTemp.LayoutTable.Columns[k].ColumnName));
                //    }

                //    if (tRemark != "")
                //    {
                //        rowNum = layOrderPrint.InsertRow(-1);
                //        for (int k = 0; k < layTemp.LayoutTable.Columns.Count; k++)
                //        {
                //            if (layTemp.LayoutTable.Columns[k].ColumnName == "order_remark_temp")
                //                continue;

                //            layOrderPrint.SetItemValue(rowNum, layTemp.LayoutTable.Columns[k].ColumnName, layTemp.GetItemString(i, layTemp.LayoutTable.Columns[k].ColumnName));
                //        }

                //        layOrderPrint.SetItemValue(rowNum, "order_remark", tRemark);
                //        layOrderPrint.SetItemValue(rowNum, "data_gubun", "B");

                //    }
                //}

                //if (layOrderPrint.RowCount > 0)
                //{
                //    #region 주사 처방전
                //    dw_jusa.Reset();
                //    dw_jusa.FillData(layOrderPrint.LayoutTable);
                //    dw_jusa.Refresh();

                //    dw_jusa.Print();
                //    #endregion
                //}

                dw_jusa.Reset();
                //dw_jusa.FillData(layOrderPrint.LayoutTable);
                dw_jusa.FillData(layTemp.LayoutTable);
                dw_jusa.Refresh();

                dw_jusa.Print();
            }
        }

        #endregion

        //#region 注射実施箋出力
        //private void xButton1_Click(object sender, System.EventArgs e)
        //{
        //    layTemp.SetBindVarValue("f_bunho", this.patInfo.BunHo);
        //    layTemp.SetBindVarValue("f_jubsu_date", this.dtpQueryDate.GetDataValue());
        //    layTemp.SetBindVarValue("f_doctor", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "doctor"));
        //    layTemp.SetBindVarValue("f_hosp_code", this.mHospCode);
        //    layTemp.SetBindVarValue("f_reser_date", this.grdDetail.GetItemValue(this.grdDetail.CurrentRowNumber, "reser_date").ToString());

        //    layTemp.QueryLayout(true);
        //}
        //#endregion

        #region 진료과 콤보 선택

        private void xBuseoCombo1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            xButtonList1_ButtonClick(null, new ButtonClickEventArgs(FunctionType.Query, false, false));
        }

        #endregion

        #region QueryStarting End Evnet


        #region 미래오더 조회 부분

        private void layReserDate_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layReserDate.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void layReserDate_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layReserDate.RowCount > 0)
                this.pbxReserDate.Visible = true;
            else
                this.pbxReserDate.Visible = false;
        }

        #endregion

        #region 검체오더조회 부분

        private void layCPLOrderYN_QueryStarting(object sender, CancelEventArgs e)
        {
            layCPLOrderYN.ParamList = new List<string>(new string[] { "f_hosp_code", "f_bunho", "f_date" });

            this.layCPLOrderYN.SetBindVarValue("f_hosp_code", this.mHospCode);
            //this.layCPLOrderYN.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.layCPLOrderYN.SetBindVarValue("f_bunho", this.bunho);
            this.layCPLOrderYN.SetBindVarValue("f_date", this.dtpQueryDate.GetDataValue());
        }

        private void layCPLOrderYN_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layCPLOrderYN.GetItemValue("cpl_order_yn").ToString() == "Y")
            {
                this.pbxCPL.Visible = true;
                this.btnCPL.Visible = true;

            }
            else
            {
                this.pbxCPL.Visible = false;
                this.btnCPL.Visible = false;
            }
        }

        #endregion

        #region 환자알레르기 특기사항 상벼 QueryStarting (2011.12.08 woo)

        private void grdNUR1016_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdNUR1016.ParamList = new List<string>(new String[] { "f_bunho", "f_query_date", "f_hosp_code" });

            //this.grdNUR1016.SetBindVarValue("f_hosp_code", this.mHospCode);
            //this.grdNUR1016.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            //this.grdNUR1016.SetBindVarValue("f_query_date", this.dtpQueryDate.GetDataValue());
        }

        private void grdOUT0106_QueryStarting(object sender, CancelEventArgs e)
        {

            //this.grdOUT0106.SetBindVarValue("f_hosp_code", this.mHospCode);
            //this.grdOUT0106.SetBindVarValue("f_bunho", this.patInfo.BunHo);
        }

        private void grdNUR1017_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdNUR1017.ParamList = new List<string>(new String[] { "f_bunho", "f_query_date", "f_hosp_code" });

            //this.grdNUR1017.SetBindVarValue("f_hosp_code", this.mHospCode);
            //this.grdNUR1017.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            //this.grdNUR1017.SetBindVarValue("f_query_date", this.dtpQueryDate.GetDataValue());
        }

        private void grdSang_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdSang.ParamList = new List<string>(new String[] { "f_bunho", "f_gwa", "f_reser_date", "f_hosp_code" });

            //this.grdSang.SetBindVarValue("f_hosp_code", this.mHospCode);
            //this.grdSang.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            //this.grdSang.SetBindVarValue("f_gwa", this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa"));
            //this.grdSang.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
        }

        #endregion


        #endregion

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)

        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DisplayMixGroup(XEditGrid aGrd)
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
                    if (aGrd.GetItemString(i, "dc_yn") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) &&
                        aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() ==
                                aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() ==
                                aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() ==
                                aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_date").ToString().Trim() ==
                                aGrd.GetItemValue(j, "order_date").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1))
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image =
                                        this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image =
                                        this.imageListMixGroup.Images[imageCnt];
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

        #region 화면관련

        private void INJ1001U01_Closing(object sender, CancelEventArgs e)
        {
            if (!mIsSaveSuccess)
            {
                e.Cancel = true;
            }
            mIsSaveSuccess = true;
        }

        #endregion

        #region 채혈있음 버튼 처리

        private void btnCPL_Click(object sender, EventArgs e)
        {
            IXScreen aScreen = XScreen.FindScreen("CPLS", "CPL2010U00");

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                //openParams.Add("bunho", this.patInfo.BunHo);
                openParams.Add("bunho", this.bunho);
                openParams.Add("order_date", this.dtpQueryDate.GetDataValue());
                // openParams.Add("jubsuja_id", this.txtConfirmUser.GetDataValue());
                XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010U00", ScreenOpenStyle.PopUpFixed,
                    ScreenAlignment.ParentTopLeft, openParams);
            }
            else
            {
                aScreen.Activate();
                //XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, this.dtpQueryDate.GetDataValue(), "", "", "",
                //    PatientPKGubun.Out, this.ScreenName);
                XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, this.dtpQueryDate.GetDataValue(), "", "", "",
                    PatientPKGubun.Out, this.ScreenName);
                XScreen.SendPatientInfo(paInfo);

            }

        }

        #endregion

        #region [一括受付ボタン関連]

        private void btnChkAllJubsu_Click(object sender, EventArgs e)
        {
            //if (this.chkAllJubsuYN.Equals("Y"))
            //{
            //    this.btnChkAllJubsu.ImageIndex = 2;
            //    this.chkAllJubsuYN = "N";

            //    for (int i = 0; i < this.grdDetail.RowCount; i++)
            //    {
            //        //조회된 로우를 돌면서~
            //        if (this.grdDetail.GetItemString(i, "acting_flag").Equals("N"))
            //            continue; //원래 미실시로되어있는애들은 건너뛰고~
            //        this.grdDetail.SetItemValue(i, "acting_flag", "N"); //실시 체크해제
            //    }
            //}
            //else
            //{
            //    this.btnChkAllJubsu.ImageIndex = 3;
            //    this.chkAllJubsuYN = "Y";

            //    for (int i = 0; i < this.grdDetail.RowCount; i++)
            //    {
            //        //조회된 로우를 돌면서
            //        if (this.grdDetail.GetItemString(i, "acting_flag").Equals("Y"))
            //            continue; //실행되어있던 애들은 건너뛰고~
            //        this.grdDetail.SetItemValue(i, "acting_flag", "Y"); //실시에 체크
            //    }
            //}
        }

        private void reset_BtnChkAllJubsu()
        {
            //this.btnChkAllJubsu.ImageIndex = 3;
            this.chkAllJubsuYN = "Y";
        }

        #endregion

        #region 타이머 관련 (2011.12.08 woo)

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.lbTime.Text = (this.QueryTime / 1000).ToString();
            //this.QueryTime = this.QueryTime - 1000;

            //if (QueryTime == 0)
            //{
            //    this.grdMaster.QueryLayout(false);

            //    this.timer1.Stop();

            //    this.timer1.Start();

            //    this.QueryTime = TimeVal;
            //}
        }

        private void btnUseTimeChk_Click(object sender, EventArgs e)
        {
            //// 自動照会使用可否 useTimeChkYN 

            //if (this.useTimeChkYN.Equals("N"))
            //{
            //    this.btnUseTimeChk.ImageIndex = 3;
            //    this.useTimeChkYN = "Y";

            //    this.timer1.Start();
            //    this.cboTime.Enabled = true;
            //    this.tbxTimer.SetDataValue("Y");
            //    this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            //    this.txtTimeInterval.AcceptData();
            //}
            //else
            //{
            //    this.btnUseTimeChk.ImageIndex = 2;
            //    this.useTimeChkYN = "N";

            //    this.cboTime.Enabled = false;
            //    this.timer1.Stop();
            //}
        }

        private void setTimer()
        {
            //if (TypeCheck.IsInt(txtTimeInterval.Text))
            //{
            //    this.QueryTime = int.Parse(txtTimeInterval.GetDataValue());
            //    this.TimeVal = int.Parse(txtTimeInterval.GetDataValue());
            //}

            //this.QueryTime = this.TimeVal;

            //this.cboTime.SelectedIndex = 0;
            //this.timer1.Start();
            //this.cboTime.Enabled = true;
            //this.tbxTimer.SetDataValue("Y");
            //this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            //this.txtTimeInterval.AcceptData();
        }

        private void txtTimeInterval_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //if (TypeCheck.IsInt(e.DataValue))
            //{
            //    this.QueryTime = int.Parse(e.DataValue);
            //    this.TimeVal = int.Parse(e.DataValue);


            //    this.lbTime.Text = (this.QueryTime / 1000).ToString();

            //    if (this.tbxTimer.GetDataValue() == "Y")
            //    {
            //        this.timer1.Stop();
            //        this.timer1.Start();
            //    }
            //}
            //else
            //{
            //    PostCallHelper.PostCall(new PostMethod(PostTimerValidating));
            //}
        }

        private void PostTimerValidating()
        {
            //this.txtTimeInterval.SetDataValue(this.TimeVal.ToString());
        }

        private void cboTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.timer1.Stop();

            //this.tbxTimer.SetDataValue("Y");
            //this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            //this.txtTimeInterval.AcceptData();

            //this.timer1.Start();
        }

        #endregion

        #region grdOCS1003 (해당환자 오더 목록 관련) 2011.12.15 woo

        private void grdOCS1003_QueryStarting(object sender, CancelEventArgs e) //2011.12.14 woo
        {
            this.grdOCS1003.ParamList = new List<string>(new String[] { "f_post_order_yn", "f_pre_order_yn", "f_reser_date", "f_bunho", "f_acting_flag", "f_order_date", "f_reser_date" });

            this.grdOCS1003.SetBindVarValue("f_post_order_yn", mPostOrderYn);
            this.grdOCS1003.SetBindVarValue("f_pre_order_yn", mPreOrderYn);
            this.grdOCS1003.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            this.grdOCS1003.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.grdOCS1003.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdOCS1003.SetBindVarValue("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");

            //this.grdOCS1003.SetBindVarValue("f_order_date",
            //    this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "order_date"));
            this.grdOCS1003.SetBindVarValue("f_order_date", this.orderDate);
            //this.grdOCS1003.SetBindVarValue("f_reser_date",
            //    this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "reser_date"));
        }

        private void grdOCS1003_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //tuning performance by gathering request
            if (isFirstLoad)
            {
                GetDataScreenOpenSecond();
                //isFirstLoad = false;
            }

            this.grdDetail.QueryLayout(false);
        }

        private void grdOCS1003_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            DateTime ot = DateTime.Parse(e.DataRow["reser_date"].ToString());
            DateTime queryDate = DateTime.Parse(this.dtpQueryDate.GetDataValue());
            if (ot.CompareTo(queryDate) == 0)
            {
                //e.BackColor = XColor.XListViewHeaderBackColor.Color;
                e.BackColor = Color.White;
            }
            else
            {
                e.BackColor = XColor.XLabelGradientEndColor.Color;
            }

            if (e.RowNumber < 1) return;
        }


        #endregion

        #region rdoCheckedChanged(투여 미투여 버튼 관련) 2011.12.15 woo

        private void rdoCheckedChanged(object sender, EventArgs e)
        {
            //XRadioButton rButton = sender as XRadioButton;

            ////체크됐을 때만 로직타도록 수정
            //if (!rButton.Checked)
            //    return;

            //if (rButton.Name == this.rbtWait.Name)
            //{
            //    this.rbtWait.ImageIndex = 3;
            //    this.rbtDone.ImageIndex = 2;
            //    this.lblTitle.Text = Resources.lblTitleText;
            //    this.lblTitle.ForeColor = new XColor(Color.Teal);
            //    //this.btnReInjActScrip.Visible = false;
            //    this.btnReLabel.Visible = false;

            //    //this.btnInjActScrip.Visible = true;
            //    this.btnLabel.Visible = true;

            //    // 実施者選択
            //    this.fbxActor.Enabled = true;

            //    // 実施者に 現在ログインしている IDを セットする｡
            //    this.fbxActor.SetDataValue(UserInfo.UserID);
            //    this.dbxActor_name.SetDataValue(UserInfo.UserName);

            //    // 実施日選択カレンダー
            //    this.dtpActingDate.Enabled = true;

            //    this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.BrtWait, -1, ""));
            //    this.btnList.InitializeButtons();
            //    this.btnList.Refresh();
            //}
            //else
            //{
            //    this.rbtWait.ImageIndex = 2;
            //    this.rbtDone.ImageIndex = 3;
            //    this.lblTitle.Text = Resources.lblTitle;
            //    this.lblTitle.ForeColor = new XColor(Color.Crimson);
            //    //this.btnReInjActScrip.Visible = true;
            //    this.btnReLabel.Visible = true;

            //    //this.btnInjActScrip.Visible = false;
            //    this.btnLabel.Visible = false;

            //    // 実施日選択カレンダー
            //    this.fbxActor.Enabled = false;

            //    // 実施日選択カレンダー
            //    this.dtpActingDate.Enabled = false;

            //    this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.BrtDone, -1, ""));
            //    this.btnList.InitializeButtons();
            //    this.btnList.Refresh();
            //}

            //// 注射実施記録の初期化
            //this.btnCmtClear_Click(sender, e);

            //// 一括受付ボタン初期化
            //this.reset_BtnChkAllJubsu();

            //this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region [dtpActingDate_DataValidating 実施日付チェック]

        private void dtpActingDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (this.grdDetail.RowCount < 1) return;

            if (this.rbtWait.Checked)
            {
                string order =
                    this.grdDetail.GetItemDateTime(this.grdDetail.CurrentRowNumber, "order_date").ToString("yyyy/MM/dd");
                string acting = e.DataValue;
                DateTime order_date = DateTime.Parse(order);
                DateTime acting_date = DateTime.Parse(acting);
                //if (order_date > acting_date)
                //{
                //    XMessageBox.Show("オーダー日より先に日では実施できません。", "日付", MessageBoxIcon.Error);
                //    e.Cancel = true;
                //    this.dtpActingDate.SetDataValue(EnvironInfo.GetSysDate());
                //    return;
                //}

                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    this.grdDetail.SetItemValue(i, "acting_date", this.dtpActingDate.GetDataValue().ToString());
                }
            }
        }

        #endregion

        #region [btnPrintSetup_Click 注射ラベルプリンタ設定クリック]

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            this.SetPrint();
        }

        #endregion

        #region 바코드 프린터 설정

        private void SetPrint()
        {
            //Open the PrintDialog
            this.printDialog1.Document = this.printDocument1;
            DialogResult dr = this.printDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //Get the Copy times
                int nCopy = this.printDocument1.PrinterSettings.Copies;
                //Get the number of Start Page
                int sPage = this.printDocument1.PrinterSettings.FromPage;
                //Get the number of End Page
                int ePage = this.printDocument1.PrinterSettings.ToPage;
                //Get the printer name
                string PrinterName = this.printDocument1.PrinterSettings.PrinterName;


                //                string cmdText = @" DECLARE 
                //    
                //                                        T_TRM_ID VARCHAR2(8) := ''; 
                //
                //                                    BEGIN
                //                                        UPDATE ADM3300
                //                                           SET USER_ID         = :q_user_id
                //                                             , UP_TIME         = SYSDATE
                //                                             , B_PRINT_NAME    = :f_b_print_name
                //                                         WHERE HOSP_CODE       = :f_hosp_code 
                //                                           AND IP_ADDR         = :f_ip_addr;
                //                                           
                //                                              
                //                                           IF SQL%NOTFOUND THEN       
                //                                             
                //                                             SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                //                                               INTO T_TRM_ID
                //                                               FROM ADM3300
                //                                              WHERE HOSP_CODE = :f_hosp_code;
                //                                              
                //                                             INSERT INTO ADM3300
                //                                                  ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                //                                                    USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                //                                                VALUES 
                //                                                  ( T_TRM_ID, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                //                                                    NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name);       
                //                                                    
                //                                           END IF; 
                //
                //                                    END;";

                //BindVarCollection _BtnPrintSetupBc = new BindVarCollection();
                _BtnPrintSetupBc.Clear();
                _BtnPrintSetupBc.Add("q_user_id", UserInfo.UserID);
                _BtnPrintSetupBc.Add("f_b_print_name", PrinterName);
                _BtnPrintSetupBc.Add("f_hosp_code", this.mHospCode);
                _BtnPrintSetupBc.Add("f_ip_addr", NetInfo.ClientIP.ToString());
                _InjsINJ1001U01SettingPrintArgs.BPrintName = _BtnPrintSetupBc["f_b_print_name"].VarValue;
                _InjsINJ1001U01SettingPrintArgs.IpAddr = _BtnPrintSetupBc["f_ip_addr"].VarValue;
                _InjsINJ1001U01SettingPrintArgs.UserId = _BtnPrintSetupBc["q_user_id"].VarValue;
                _InjsINJ1001U01SettingPrintResult =
                    CloudService.Instance.Submit<InjsINJ1001U01SettingPrintResult, InjsINJ1001U01SettingPrintArgs>(
                        _InjsINJ1001U01SettingPrintArgs);

                if (_InjsINJ1001U01SettingPrintResult != null && _InjsINJ1001U01SettingPrintResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (!_InjsINJ1001U01SettingPrintResult.Result)
                    {
                        XMessageBox.Show(Resources.INJ_XMessageBox8 + Service.ErrFullMsg, Resources.INJ_Caption4,
                            MessageBoxIcon.Warning);
                    }
                }






                //if (!Service.ExecuteNonQuery(cmdText, bc))
                //{
                //    XMessageBox.Show(Resources.XMessageBox8 + Service.ErrFullMsg, Resources.Caption4,
                //        MessageBoxIcon.Warning);
                //}
            }
        }

        #endregion

        #region [btnAllergy_Click アレルギーボタンクリック]

        private void btnAllergy_Click(object sender, EventArgs e)
        {
            if (this.patInfo.BunHo == "")
                return;
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("NURI", "NUR1016U00");

            if (aScreen == null)
            {
                string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                //this.timer1.Stop();
                XScreen.OpenScreenWithParam(this, "NURI", "NUR1016U00", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);

                if (useTimeChkYN.Equals("Y"))
                {
                    //this.timer1.Start();
                }

            }
            else
            {
                ((XScreen)aScreen).Activate();
                XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, "", "", "", "", PatientPKGubun.Out,
                    this.ScreenName);
                XScreen.SendPatientInfo(paInfo);
            }


            //this.grdNUR1016.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회


        }

        #endregion

        private void layPrintName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPrintName.ParamList = new List<string>(new String[] { "f_hosp_code", "f_ip_addr" });

            this.layPrintName.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layPrintName.SetBindVarValue("f_ip_addr", NetInfo.ClientIP.ToString());
        }

        #region [btnGamyum_Click 感染症ボタンクリック]

        private void btnGamyum_Click(object sender, EventArgs e)
        {
            if (this.patInfo.BunHo == "")
                return;
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("NURI", "NUR1017U00");

            if (aScreen == null)
            {
                string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                //this.timer1.Stop();
                XScreen.OpenScreenWithParam(this, "NURI", "NUR1017U00", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);
                if (useTimeChkYN.Equals("Y"))
                {
                    //this.timer1.Start();
                }

            }
            else
            {
                ((XScreen)aScreen).Activate();
                XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, "", "", "", "", PatientPKGubun.Out,
                    this.ScreenName);
                XScreen.SendPatientInfo(paInfo);
            }


            _GroupedLoad = false;
            //this.grdNUR1017.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회

        }

        #endregion

        #region [btnOUt0106_Click 特記事項ボタンクリック]

        private void btnOUt0106_Click(object sender, EventArgs e)
        {
            //if (this.patInfo.BunHo == "")
            //    return;
            //IHIS.Framework.IXScreen aScreen;

            //aScreen = XScreen.FindScreen("NURO", "OUT0106U00");

            //if (aScreen == null)
            //{
            //    string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
            //    CommonItemCollection openParams = new CommonItemCollection();
            //    openParams.Add("bunho", bunho);
            //    this.timer1.Stop();
            //    XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", ScreenOpenStyle.ResponseFixed,
            //        ScreenAlignment.ScreenMiddleCenter, openParams);

            //    if (useTimeChkYN.Equals("Y"))
            //    {
            //        this.timer1.Start();
            //    }

            //}
            //else
            //{
            //    ((XScreen)aScreen).Activate();
            //    XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, "", "", "", "", PatientPKGubun.Out,
            //        this.ScreenName);
            //    XScreen.SendPatientInfo(paInfo);
            //}

            //_GroupedLoad = false;
            //this.grdOUT0106.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회
            //this._INJ1001U01Grouped2Result = null;
        }

        #endregion

        #region checkDate

        private bool checkDate(int row)
        {
            if (TypeCheck.IsNull(this.grdDetail.GetItemString(row, "reser_date")) ||
                TypeCheck.IsNull(this.grdDetail.GetItemString(row, "acting_date")))
                return false;

            string reser = this.grdDetail.GetItemString(row, "reser_date");
            string acting = this.grdDetail.GetItemString(row, "acting_date");
            DateTime reser_date = DateTime.Parse(reser);
            DateTime acting_date = DateTime.Parse(acting);
            reser = reser_date.ToString().Substring(0, 10);
            acting = acting_date.ToString().Substring(0, 10);
            if (reser_date > acting_date)
            {
                this.mCap = Resources.INJ_mCap;
                this.mMsg = Resources.INJ_XMessageBox9 + reser + Resources.INJ_XMessageBox10 + acting + Resources.INJ_XMessageBox11;
                if (XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                    DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            return true;
        }

        #endregion

        #region [btnInjActScrip_Click 注射実施せん出力ボタン]

        private void btnInjActScrip_Click(object sender, EventArgs e)
        {
            // 出力可否 injScripPrnYN

            if (this.injScripPrnYN.Equals("N"))
            {
                //this.btnInjActScrip.ImageIndex = 3;
                this.injScripPrnYN = "Y";
            }
            else
            {
                //this.btnInjActScrip.ImageIndex = 2;
                this.injScripPrnYN = "N";
            }
        }

        #endregion

        #region [btnLabel_Click 注射ラベル印刷ボタン]

        private void btnLabel_Click(object sender, EventArgs e)
        {
            // ラベル出力可否 labelPrnYN

            //if (this.labelPrnYN.Equals("N"))
            //{
            //    this.btnLabel.ImageIndex = 3;
            //    this.labelPrnYN = "Y";
            //}
            //else
            //{
            //    this.btnLabel.ImageIndex = 2;
            //    this.labelPrnYN = "N";
            //}
            this.prtLabel();
        }

        #endregion

        #region [fbxCmt 注射実施記録関連]

        private void fbxCmt_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkCmt.FormText = Resources.INJ_fwkCmtFormText;
            this.fwkCmt.ColInfos[0].HeaderText = Resources.INJ_fwkCmtHeader1;
            this.fwkCmt.ColInfos[0].ColWidth = 30;
            this.fwkCmt.ColInfos[1].HeaderText = Resources.INJ_fwkCmtHeader2;
            this.fwkCmt.ColInfos[1].ColWidth = 300;

            this.fwkCmt.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fbxCmt_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string code = this.fbxCmt.GetDataValue();

            if (code.Trim() == "")
            {
                this.dboxCmt.Text = "";
                this.fbxCmt.Focus();
                return;
            }

            this.layCommon.Reset();

            //            this.layCommon.QuerySQL = @"SELECT CODE_NAME
            //                                          FROM INJ0102
            //                                         WHERE HOSP_CODE = :f_hosp_code 
            //                                           AND CODE_TYPE = 'INJ_COMMENT'
            //                                           AND CODE      = :f_code
            //                                         ORDER BY CODE ";



            this.layCommon.LayoutItems.Clear();
            this.layCommon.LayoutItems.Add("code_name");

            this.layCommon.ParamList = new List<string>(new String[] { "f_code" });
            this.layCommon.ExecuteQuery = QueryLayCommon;

            this.layCommon.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layCommon.SetBindVarValue("f_code", code);

            this.layCommon.QueryLayout();

            if (!TypeCheck.IsNull(this.layCommon.GetItemValue("code_name")))
            {
                this.dboxCmt.SetDataValue(this.layCommon.GetItemValue("code_name").ToString());

                this.AutoInputCmt(code, this.layCommon.GetItemValue("code_name").ToString());
            }
            else this.btnCmtClear_Click(sender, e);
        }

        private void AutoInputCmt(string code, string codeName)
        {
            this.txtSilsiRemark.Text = this.txtSilsiRemark.Text
                                       + codeName + "\r\n";

            this.txtSilsiRemark.AcceptData();
        }

        private void btnCmtClear_Click(object sender, EventArgs e)
        {
            this.fbxCmt.Clear();
            this.dboxCmt.Text = "";

            this.txtSilsiRemark.Text = "";
        }

        #endregion

        #region [fbxActor 実施者関連]

        private void btnClear_Click(object sender, EventArgs e)
        {
            //this.fbxActor.Clear();
            //this.dbxActor_name.Text = "";

            this.AutoInputInfo("", "");
        }

        private void fbxActor_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkActor.FormText = Resources.INJ_FormText;
            this.fwkActor.ColInfos[0].HeaderText = Resources.INJ_HeaderText1;
            this.fwkActor.ColInfos[0].ColWidth = 80;
            this.fwkActor.ColInfos[1].HeaderText = Resources.INJ_HeaderText2;
            this.fwkActor.ColInfos[1].ColWidth = 150;

            this.fwkActor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fbxActor_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //string user_id = this.actor;

            //if (user_id.Trim() == "")
            //{
            //    this.dbxActor_name.Text = "";
            //    //this.fbxActor.Focus();
            //    return;
            //}

            //this.layCommon.Reset();

            ////            this.layCommon.QuerySQL = @"SELECT USER_NM
            ////                                          FROM ADM3200
            ////                                         WHERE HOSP_CODE   = :f_hosp_code
            ////                                           --AND USER_GROUP  = 'NUR'
            ////                                           AND USER_ID     = :f_user_id";

            //this.layCommon.LayoutItems.Clear();
            //this.layCommon.LayoutItems.Add("user_name");

            //layCommon.ParamList = new List<string>(new String[] { "f_user_id", "f_hosp_code" });
            //this.layCommon.SetBindVarValue("f_hosp_code", this.mHospCode);
            //this.layCommon.SetBindVarValue("f_user_id", user_id);

            //layCommon.ExecuteQuery = fbxActor_ExecuteValidating;
            //this.layCommon.QueryLayout();

            //if (!TypeCheck.IsNull(this.layCommon.GetItemValue("user_name")))
            //{
            //    this.dbxActor_name.SetDataValue(this.layCommon.GetItemValue("user_name").ToString());

            //    this.AutoInputInfo(user_id, this.layCommon.GetItemValue("user_name").ToString());
            //}
            //else this.btnClear_Click(sender, e);
        }

        public void AutoSetActor()
        {
            AutoInputInfo(actor, actorName);
        }

        private void AutoInputInfo(string actorCode, string actorName)
        {
            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                if (this.grdDetail.GetItemValue(i, "acting_flag").ToString() != "Y")
                    continue;
                this.grdDetail.SetItemValue(i, "jujongja", actorCode);
                this.grdDetail.SetItemValue(i, "jujongja_name", actorName);
            }
        }

        private bool checkActor(int row)
        {
            bool rtnVal = true;

            string actYn = this.grdDetail.GetItemString(row, "acting_flag");

            string actorCode = null;

            if (actYn.Equals("Y"))
            {
                actorCode = this.grdDetail.GetItemString(row, "jujongja");

                if (TypeCheck.IsNull(actorCode) || actorCode.Equals(""))
                    rtnVal = false;
            }

            return rtnVal;
        }

        #endregion

        // 2015.04.27 deleted by AnhNV
        #region XSavePerformer

        //        private class XSavePerformer : ISavePerformer
        //        {
        //            private INJ1001U01 parent;

        //            private InjsINJ1001U01OrderDateListArgs _InjsINJ1001U01OrderDateListArgs = new InjsINJ1001U01OrderDateListArgs();
        //            private InjsINJ1001U01OrderDateListResult _InjsINJ1001U01OrderDateListResult;

        //            public XSavePerformer(INJ1001U01 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
        //                item.BindVarList.Add("f_upd_id", parent.fbxActor.GetDataValue().ToString());

        ////                string cmdText = @"SELECT NVL(B.ORDER_DATE, TRUNC(SYSDATE))     ORDER_DATE
        ////                                     FROM INJ1002 A, INJ1001 B
        ////                                    WHERE A.HOSP_CODE  = :f_hosp_code
        ////                                      AND B.HOSP_CODE  = A.HOSP_CODE
        ////                                      AND A.PKINJ1002  = :f_pkinj1002
        ////                                      AND A.FKINJ1001  = B.PKINJ1001";
        //                _InjsINJ1001U01OrderDateListArgs.Pkinj1002 = item.BindVarList["f_pkinj1002"].VarValue;
        //                _InjsINJ1001U01OrderDateListResult =
        //                    CloudService.Instance.Submit<InjsINJ1001U01OrderDateListResult, InjsINJ1001U01OrderDateListArgs>(
        //                        _InjsINJ1001U01OrderDateListArgs);

        //                if (_InjsINJ1001U01UpdateResult == null)
        //                    return false;
        //                DataTable dt = new DataTable();
        //                dt.Columns.Add("order_date", typeof (string));
        //                foreach (string oItem in _InjsINJ1001U01OrderDateListResult.OrderDate)
        //                {
        //                    DataRow dr = dt.NewRow();
        //                    dr["order_date"] = oItem;
        //                    dt.Rows.Add(dr);
        //                }

        //                string temp1 = "";
        //                string temp2 = "";

        //                //DataTable dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

        //                if (dt.Rows.Count > 0)
        //                {
        //                    if (!TypeCheck.IsNull(dt.Rows[0]["order_date"]))
        //                    {
        //                        for (int i = 0; i < dt.Rows.Count; i++)
        //                        {
        //                            temp1 = dt.Rows[i]["order_date"].ToString()
        //                                .Substring(0, 10)
        //                                .Replace("/", "")
        //                                .Replace("-", "");
        //                            temp2 = item.BindVarList["f_acting_date"].VarValue.Replace("/", "").Replace("-", "");
        //                            if (temp2 == "")
        //                                temp2 = "30001231";

        //                            if (Convert.ToInt32(temp1) > Convert.ToInt32(temp2))
        //                            {
        //                                XMessageBox.Show(
        //                                    Resources.XMessageBox13 + item.BindVarList["hangmog_name"].VarValue +
        //                                    Resources.XMessageBox12, Resources.Caption4, MessageBoxIcon.Warning);
        //                                return false;
        //                            }
        //                        }
        //                    }
        //                }
        //                //TODO: InjsINJ1001U01UpdateRequest
        ////                cmdText = @"UPDATE INJ1002
        ////                               SET 
        ////                                   -- JUSA_YN       = :f_jusa_yn,
        ////                                   ACTING_FLAG   = :f_acting_flag
        ////                                 , ACTING_DATE   = DECODE(:f_acting_flag, 'Y', :f_acting_date, NULL)
        ////                                 , JUBSU_DATE    = DECODE(:f_acting_flag, 'Y', :f_acting_date, NULL)
        ////                                 , ACTING_TIME   = DECODE(:f_acting_flag, 'Y', TO_CHAR(SYSDATE, 'HH24MI'), NULL)
        ////                                 , ACTING_JANGSO = 'IR'
        ////                                 , TONGGYE_CODE  = :f_tonggye_code
        ////                                 , MIX_GROUP     = :f_mix_group
        ////                                 , UPD_ID        = NVL(:f_jujongja, :f_upd_id)
        ////                                 , UPD_DATE      = SYSDATE
        ////                                 , JUJONGJA      = DECODE(:f_acting_flag, 'Y', :f_jujongja, NULL)
        ////                                 , SILSI_REMARK  = :f_silsi_remark
        ////                             WHERE HOSP_CODE     = :f_hosp_code
        ////                               AND PKINJ1002     = :f_pkinj1002";

        ////                return Service.ExecuteNonQuery(cmdText, item.BindVarList);


        //                _InjsINJ1001U01UpdateArgs.ActingDate = item.BindVarList["f_acting_date"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.ActingFlag = item.BindVarList["f_acting_flag"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.Jujongja = item.BindVarList["f_jujongja"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.MixGroup = item.BindVarList["f_mix_group"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.Pkinj1002 = item.BindVarList["f_pkinj1002"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.SilsiRemark = item.BindVarList["f_silsi_remark"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.TonggyeCode = item.BindVarList["f_tonggye_code"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.UpdId = item.BindVarList["f_upd_id"].VarValue;
        //                _InjsINJ1001U01UpdateResult =
        //                    CloudService.Instance.Submit<UpdateResult, InjsINJ1001U01UpdateArgs>(
        //                        _InjsINJ1001U01UpdateArgs);

        //                if(_InjsINJ1001U01UpdateResult == null)
        //                    return false;
        //                else
        //                {
        //                    return _InjsINJ1001U01UpdateResult.Result;
        //                }
        //            }
        //        }

        #endregion

        private void grdMaster_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //int row = this.grdMaster.CurrentRowNumber;

            //if (row < 0) //클릭한 곳이 그리드의 공백이라면 리턴리턴~
            //    return;

            //this.pbxReserDate.Visible = false;
            //this.pbxCPL.Visible = false;
            //this.btnCPL.Visible = false;
            //this.patInfo.Reset();
            //this.patInfo.Tag = null;

            ////MED-9244
            ////this.dtpActingDate.SetDataValue(EnvironInfo.GetSysDate()); //오늘 날짜로 변경
            //this.dtpActingDate.SetDataValue(this.currentDate); //오늘 날짜로 변경

            //this.patInfo.SetPatientID(this.grdMaster.GetItemString(row, "bunho").ToString());

            //this.fbxActor.Focus();

            ////MED-9244 duplicate request, just query only when users focus row, not first time
            //if (!isFirstLoad)
            //{
            //    this.grdOCS1003.QueryLayout(false);
            //    this.grdNUR1016.QueryLayout(false);
            //    this.grdOUT0106.QueryLayout(false);
            //    this.grdNUR1017.QueryLayout(false); 
            //}
            //isFirstLoad = false;
        }

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = new XEditGrid();
            grd = this.grdOCS1003;
            int currRow = grd.CurrentRowNumber;

            this.grdDetail.ParamList = new List<string>(new String[] { "f_bunho", "f_reser_date", "f_acting_date", "f_gwa", "f_doctor", "f_acting_flag" });

            this.grdDetail.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.grdDetail.SetBindVarValue("f_reser_date", grd.GetItemString(currRow, "reser_date"));
            this.grdDetail.SetBindVarValue("f_acting_date", grd.GetItemString(currRow, "acting_date"));
            this.grdDetail.SetBindVarValue("f_gwa", grd.GetItemString(currRow, "gwa"));
            this.grdDetail.SetBindVarValue("f_doctor", grd.GetItemString(currRow, "doctor"));
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");
        }

        #region DzungTA modify
        private INJ1001U01Grouped2Args _INJ1001U01Grouped2Args = new INJ1001U01Grouped2Args();
        private INJ1001U01Grouped2Result _INJ1001U01Grouped2Result;
        private InjsINJ1001U01DetailListArgs _InjsINJ1001U01DetailListArgs = new InjsINJ1001U01DetailListArgs();
        private InjsINJ1001U01DetailListResult _InjsINJ1001U01DetailListResult;
        private InjsINJ1001U01ScheduleArgs _InjsINJ1001U01ScheduleArgs = new InjsINJ1001U01ScheduleArgs();
        private InjsINJ1001U01ScheduleResult _InjsINJ1001U01ScheduleResult;
        private INJ0102CodeNameListArgs _INJ0102CodeNameListArgs = new INJ0102CodeNameListArgs();
        private INJ0102CodeNameListResult _INJ0102CodeNameListResult;
        private INJ1001U01GrdSangArgs _INJ1001U01GrdSangArgs = new INJ1001U01GrdSangArgs();
        private INJ1001U01GrdSangResult _INJ1001U01GrdSangResult;
        private INJ1001U01XEditGridCell88Args _INJ1001U01XEditGridCell88Args = new INJ1001U01XEditGridCell88Args();
        private INJ1001U01XEditGridCell88Result _INJ1001U01XEditGridCell88Result;
        private INJ1001U01XEditGridCell89Args _INJ1001U01XEditGridCell89Args = new INJ1001U01XEditGridCell89Args();
        private INJ1001U01XEditGridCell89Result _inj1001U01XEditGridCell89Result;
        private InjsINJ1001U01AllergyListArgs _InjsINJ1001U01AllergyListArgs = new InjsINJ1001U01AllergyListArgs();
        private InjsINJ1001U01AllergyListResult _InjsINJ1001U01AllergyListResult;
        private InjsINJ1001U01CommentListArgs _InjsINJ1001U01CommentListArgs = new InjsINJ1001U01CommentListArgs();
        private InjsINJ1001U01CommentListResult _InjsINJ1001U01CommentListResult;
        private InjsINJ1001U01CplOrderStatusArgs _InjsINJ1001U01CplOrderStatusArgs =
            new InjsINJ1001U01CplOrderStatusArgs();
        private InjsINJ1001U01CplOrderStatusResult _InjsINJ1001U01CplOrderStatusResult;
        private InjsINJ1001U01InfectionListArgs _InjsINJ1001U01InfectionListArgs = new InjsINJ1001U01InfectionListArgs();
        private InjsINJ1001U01InfectionListResult _InjsINJ1001U01InfectionListResult;
        private InjsINJ1001U01LabelNewListArgs _InjsINJ1001U01LabelNewListArgs = new InjsINJ1001U01LabelNewListArgs();
        private InjsINJ1001U01LabelNewListResult _InjsINJ1001U01LabelNewListResult;
        private InjsINJ1001U01PrintNameListArgs _InjsINJ1001U01PrintNameListArgs = new InjsINJ1001U01PrintNameListArgs();
        private InjsINJ1001U01PrintNameListResult _InjsINJ1001U01PrintNameListResult;
        private InjsINJ1001U01ReserDateListArgs _InjsINJ1001U01ReserDateListArgs = new InjsINJ1001U01ReserDateListArgs();
        private InjsINJ1001U01ReserDateListResult _InjsINJ1001U01ReserDateListResult;
        private InjsINJ1001U01SettingPrintArgs _InjsINJ1001U01SettingPrintArgs = new InjsINJ1001U01SettingPrintArgs();
        private InjsINJ1001U01SettingPrintResult _InjsINJ1001U01SettingPrintResult;
        private static InjsINJ1001U01UpdateArgs _InjsINJ1001U01UpdateArgs = new InjsINJ1001U01UpdateArgs();
        private static UpdateResult _InjsINJ1001U01UpdateResult;
        private INJ1001U01CboTimeArgs _INJ1001U01CboTimeArgs = new INJ1001U01CboTimeArgs();
        private INJ1001U01CboTimeResult _INJ1001U01CboTimeResult;
        private INJ1001U01ComboListSortKeyArgs _INJ1001U01ComboListSortKeyArgs = new INJ1001U01ComboListSortKeyArgs();
        private ComboListByCodeTypeResult _INJ1001U01ComboListSortKeyResult;
        private INJ1001U01MlayConstantInfoArgs _INJ1001U01MlayConstantInfoArgs = new INJ1001U01MlayConstantInfoArgs();
        private INJ1001U01MlayConstantInfoResult _INJ1001U01MlayConstantInfoResult;


        private InjsINJ1001U01MasterListArgs _InjsINJ1001U01MasterListArgs = new InjsINJ1001U01MasterListArgs();
        private InjsINJ1001U01MasterListResult _InjsINJ1001U01MasterListResult;
        private InjsINJ1001U01ChkbStateArgs _InjsINJ1001U01ChkbStateArgs = new InjsINJ1001U01ChkbStateArgs();
        private InjsINJ1001U01ChkbStateResult _InjsINJ1001U01ChkbStateResult;

        BindVarCollection _GrdDetailBc = new BindVarCollection();
        BindVarCollection _LayLableNewBc = new BindVarCollection();
        BindVarCollection _BtnPrintSetupBc = new BindVarCollection();

        private bool _GroupedLoad = false; // grouped requests load flag for controls grdOUT0106, grdNUR1016, grd1017; default each control will load data separately


        /// <summary>
        /// Bind query method to control's ExecuteQuery delegates.
        /// </summary>
        private void BindExecuteQueryMethod()
        {
            grdOCS1003.ExecuteQuery = QueryGrdOCS1003;
            //grdSang.ExecuteQuery = QueryGrdSang;
            fwkCmt.ExecuteQuery = QueryFwkCmt;
            //grdNUR1016.ExecuteQuery = QueryGrdNUR1016;
            grdDetail.ExecuteQuery = QueryGrdDetail;
            //cboTime.ExecuteQuery = QueryCboTime;
            //cboTime.SetDictDDLB();
            //grdNUR1017.ExecuteQuery = QueryGrdNUR1017;
            //grdOUT0106.ExecuteQuery = QueryGrdOUT0106;
            layLableNew.ExecuteQuery = QueryLayLableNew;
            layReserDate.ExecuteQuery = QueryLayReserDate;
            layCPLOrderYN.ExecuteQuery = QuerylayCPLOrderYN;
            layPrintName.ExecuteQuery = QueryLayPrintName;
            mlayConstantInfo.ExecuteQuery = QueryMLayConstantInfo;
            //layCommon.ExecuteQuery = QueryLayCommon;
            //grdMaster.ExecuteQuery = QueryGrdMaster;
            fwkActor.ExecuteQuery = fbxActor_ExecuteQuery;
        }

        private IList<object[]> QueryGrdMaster(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01MasterListArgs.ActingFlag = varlist["f_acting_flag"].VarValue;
                _InjsINJ1001U01MasterListArgs.Gwa = varlist["f_gwa"].VarValue;
                _InjsINJ1001U01MasterListArgs.ReserDate = varlist["f_reser_date"].VarValue;
                _InjsINJ1001U01MasterListResult = CloudService.Instance.Submit<InjsINJ1001U01MasterListResult, InjsINJ1001U01MasterListArgs>(_InjsINJ1001U01MasterListArgs, true);

                if (_InjsINJ1001U01MasterListResult != null)
                {
                    foreach (IHIS.CloudConnector.Contracts.Models.Injs.InjsINJ1001U01MasterListItemInfo item in _InjsINJ1001U01MasterListResult.MasterListItem)
                    {
                        object[] objects =
                    {
                        item.TrialYn,
                        item.ReserGubun ,
                        item.Bunho ,
                        item.Suname,
                        item.OrderDate ,
                        item.ReserDate
                        
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryGrdMaster" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryLayCommon(BindVarCollection varlist)
        {
            IList<object[]> lObj = new List<object[]>();

            INJ0102CodeNameListArgs args = new INJ0102CodeNameListArgs();
            args.Code = varlist["f_code"].VarValue;
            args.CodeType = "INJ_COMMENT";
            INJ0102CodeNameListResult res = CloudService.Instance.Submit<INJ0102CodeNameListResult, INJ0102CodeNameListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.CodeNameList.ForEach(delegate(DataStringListItemInfo item)
                {
                    lObj.Add(new object[] { item.DataValue });
                });
            }

            return lObj;
        }

        private IList<object[]> QueryMLayConstantInfo(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                //_INJ1001U01MlayConstantInfoResult = CacheService.Instance.Get<INJ1001U01MlayConstantInfoArgs, INJ1001U01MlayConstantInfoResult>("INJ1001U01MlayConstantInfo", _INJ1001U01MlayConstantInfoArgs);
                //_INJ1001U01MlayConstantInfoResult =
                //    CloudService.Instance.Submit<INJ1001U01MlayConstantInfoResult, INJ1001U01MlayConstantInfoArgs>(
                //        _INJ1001U01MlayConstantInfoArgs);
                _INJ1001U01MlayConstantInfoResult = CacheService.Instance.Get<INJ1001U01MlayConstantInfoArgs, INJ1001U01MlayConstantInfoResult>(_INJ1001U01MlayConstantInfoArgs);

                if (_INJ1001U01MlayConstantInfoResult != null)
                {
                    foreach (ComboListItemInfo item in _INJ1001U01MlayConstantInfoResult.Item)
                    {
                        object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryMLayConstantInfo" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryLayPrintName(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01PrintNameListArgs.IpAddr = this.layPrintName.BindVarList["f_ip_addr"].VarValue;
                //_InjsINJ1001U01PrintNameListResult = CloudService.Instance.Submit<InjsINJ1001U01PrintNameListResult, InjsINJ1001U01PrintNameListArgs>(_InjsINJ1001U01PrintNameListArgs);

                //_InjsINJ1001U01PrintNameListResult = CacheService.Instance.Get<InjsINJ1001U01PrintNameListArgs, InjsINJ1001U01PrintNameListResult>("InjsINJ1001U01PrintNameList", _InjsINJ1001U01PrintNameListArgs);
                _InjsINJ1001U01PrintNameListResult = CacheService.Instance.Get<InjsINJ1001U01PrintNameListArgs, InjsINJ1001U01PrintNameListResult>(_InjsINJ1001U01PrintNameListArgs);
                if (_InjsINJ1001U01PrintNameListResult != null)
                {
                    foreach (string item in _InjsINJ1001U01PrintNameListResult.PrintNameList)
                    {
                        object[] objects =
                    {
                        item
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryLayPrintName" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QuerylayCPLOrderYN(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01CplOrderStatusArgs.Bunho = this.layCPLOrderYN.BindVarList["f_bunho"].VarValue;
                _InjsINJ1001U01CplOrderStatusArgs.Date = this.layCPLOrderYN.BindVarList["f_date"].VarValue;
                _InjsINJ1001U01CplOrderStatusArgs.Gubun = "O";
                _InjsINJ1001U01CplOrderStatusArgs.JundalPart = "CPL";
                _InjsINJ1001U01CplOrderStatusResult =
                    CloudService.Instance.Submit<InjsINJ1001U01CplOrderStatusResult, InjsINJ1001U01CplOrderStatusArgs>(
                        _InjsINJ1001U01CplOrderStatusArgs, true);
                if (_InjsINJ1001U01CplOrderStatusResult != null)
                {
                    object[] objects =
                {
                    _InjsINJ1001U01CplOrderStatusResult.Result
                };
                    res.Add(objects);
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QuerylayCPLOrderYN" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryLayReserDate(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01ReserDateListArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
                _InjsINJ1001U01ReserDateListArgs.Bunho = patInfo.BunHo;
                _InjsINJ1001U01ReserDateListArgs.Doctor = "";
                _InjsINJ1001U01ReserDateListArgs.ReserDate = this.dtpQueryDate.GetDataValue();
                _InjsINJ1001U01ReserDateListResult =
                    CloudService.Instance.Submit<InjsINJ1001U01ReserDateListResult, InjsINJ1001U01ReserDateListArgs>(
                        _InjsINJ1001U01ReserDateListArgs);
                if (_InjsINJ1001U01ReserDateListResult != null)
                {
                    //foreach (string item in _InjsINJ1001U01ReserDateListResult.ReserDate)
                    //{
                    //    object[] objects =
                    //{
                    //    item
                    //};
                    //    res.Add(objects);
                    //}

                    // AnhNV hot fixed
                    _InjsINJ1001U01ReserDateListResult.ReserDate.ForEach(delegate(DataStringListItemInfo item)
                    {
                        res.Add(new object[] { item.DataValue });
                    });
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryLayReserDate" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryXEditGridCell77(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            return res;
        }

        private IList<object[]> QueryLayLableNew(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01LabelNewListArgs.Doctor = _LayLableNewBc["f_doctor"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.Bunho = _LayLableNewBc["f_bunho"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.Fkinj1001 = _LayLableNewBc["f_fkinj1001"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.GroupSer = _LayLableNewBc["f_group_ser"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.Gwa = _LayLableNewBc["f_gwa"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.JubsuDate = _LayLableNewBc["f_jubsu_date"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.MixGroup = _LayLableNewBc["f_mix_group"].VarValue;
                _InjsINJ1001U01LabelNewListResult =
                    CloudService.Instance.Submit<InjsINJ1001U01LabelNewListResult, InjsINJ1001U01LabelNewListArgs>(
                        _InjsINJ1001U01LabelNewListArgs);
                if (_InjsINJ1001U01LabelNewListResult != null)
                {
                    foreach (InjsINJ1001U01LabelNewListItemInfo item in _InjsINJ1001U01LabelNewListResult.LabelNewListItem)
                    {
                        object[] objects =
                    {
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.Age,
                        item.Sex,
                        item.JubsuDate,
                        item.Cnt,
                        item.Suryang,
                        item.DanuiName,
                        item.BogyongName,
                        item.JusaName,
                        item.JaeryoName,
                        item.OrderRemark,
                        item.DataGubun,
                        item.MixYn
                        
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryLayLableNew" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryGrdOUT0106(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            //try
            //{
            //    if (_GroupedLoad)
            //    {
            //        _INJ1001U01Grouped2Args.ActingDate = "";
            //        _INJ1001U01Grouped2Args.ActingFlag = "";
            //        _INJ1001U01Grouped2Args.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue; //this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            //        _INJ1001U01Grouped2Args.CommtGubun = "B";
            //        _INJ1001U01Grouped2Args.Doctor = "";
            //        _INJ1001U01Grouped2Args.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
            //        _INJ1001U01Grouped2Args.OrderDate = "";
            //        _INJ1001U01Grouped2Args.PostOrderYn = "";
            //        _INJ1001U01Grouped2Args.PreOrderYn = "";
            //        _INJ1001U01Grouped2Args.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            //        _INJ1001U01Grouped2Args.ReserDate = "";

            //        if (_INJ1001U01Grouped2Result == null)
            //        {
            //            _INJ1001U01Grouped2Result =
            //                CloudService.Instance.Submit<INJ1001U01Grouped2Result, INJ1001U01Grouped2Args>(
            //                    _INJ1001U01Grouped2Args);
            //        }
            //        if (_INJ1001U01Grouped2Result != null)
            //        {
            //            foreach (DataStringListItemInfo item in _INJ1001U01Grouped2Result.GrdOut0106ListItem)
            //            {
            //                object[] objects =
            //                {
            //                    item.DataValue
            //                };
            //                res.Add(objects);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        _InjsINJ1001U01CommentListArgs.Bunho = this.patInfo.BunHo;
            //        _InjsINJ1001U01CommentListArgs.CommtGubun = "B";
            //        _InjsINJ1001U01CommentListResult =
            //            CloudService.Instance.Submit<InjsINJ1001U01CommentListResult, InjsINJ1001U01CommentListArgs>(
            //                _InjsINJ1001U01CommentListArgs);
            //        if (_InjsINJ1001U01CommentListResult != null)
            //        {
            //            foreach (DataStringListItemInfo item in _InjsINJ1001U01CommentListResult.CommentList)
            //            {
            //                object[] objects =
            //                {
            //                    item.DataValue
            //                };
            //                res.Add(objects);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("QueryGrdOUT0106" + ex.Message);
            //    throw;
            //}
            return res;
        }

        private IList<object[]> QueryXEditGridCell89(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _inj1001U01XEditGridCell89Result = CacheService.Instance.Get<INJ1001U01XEditGridCell89Args, INJ1001U01XEditGridCell89Result>(
                            _INJ1001U01XEditGridCell89Args);
                if (_inj1001U01XEditGridCell89Result != null)
                {
                    foreach (INJ1001U01XEditGridCell89ItemInfo item in _inj1001U01XEditGridCell89Result.XeditGridCell89Item)
                    {
                        object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                        item.SortKey
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryXEditGridCell89" + ex.Message);
                throw;
            }

            return res;
        }

        private IList<object[]> QueryXEditGridCell88(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _INJ1001U01XEditGridCell88Result = CacheService.Instance.Get<INJ1001U01XEditGridCell88Args, INJ1001U01XEditGridCell88Result>(
                           _INJ1001U01XEditGridCell88Args);
                if (_INJ1001U01XEditGridCell88Result != null)
                {
                    foreach (ComboListItemInfo item in _INJ1001U01XEditGridCell88Result.XeditGridCell88Item)
                    {
                        object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryXEditGridCell88" + ex.Message);
                throw;
            }

            return res;
        }

        private IList<object[]> QueryGrdNUR1017(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            //try
            //{
            //    if (_GroupedLoad)
            //    {
            //        _INJ1001U01Grouped2Args.ActingDate = "";
            //        _INJ1001U01Grouped2Args.ActingFlag = "";
            //        _INJ1001U01Grouped2Args.Bunho = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            //        _INJ1001U01Grouped2Args.CommtGubun = "B";
            //        _INJ1001U01Grouped2Args.Doctor = "";
            //        _INJ1001U01Grouped2Args.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
            //        _INJ1001U01Grouped2Args.OrderDate = "";
            //        _INJ1001U01Grouped2Args.PostOrderYn = "";
            //        _INJ1001U01Grouped2Args.PreOrderYn = "";
            //        _INJ1001U01Grouped2Args.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            //        _INJ1001U01Grouped2Args.ReserDate = "";

            //        if (_INJ1001U01Grouped2Result == null)
            //        {
            //            _INJ1001U01Grouped2Result =
            //                CloudService.Instance.Submit<INJ1001U01Grouped2Result, INJ1001U01Grouped2Args>(
            //                    _INJ1001U01Grouped2Args);
            //        }
            //        if (_INJ1001U01Grouped2Result != null)
            //        {
            //            foreach (InjsINJ1001U01InfectionListItemInfo item in _INJ1001U01Grouped2Result.GrdNur1017ListItem)
            //            {
            //                object[] objects =
            //                {
            //                    item.InfeJaeryo,
            //                    item.InfeCode,
            //                };
            //                res.Add(objects);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        _InjsINJ1001U01InfectionListArgs.Bunho = this.grdNUR1017.BindVarList["f_bunho"].VarValue;
            //        _InjsINJ1001U01InfectionListArgs.QueryDate = this.grdNUR1017.BindVarList["f_query_date"].VarValue;
            //        _InjsINJ1001U01InfectionListResult = CloudService.Instance
            //            .Submit<InjsINJ1001U01InfectionListResult, InjsINJ1001U01InfectionListArgs>(
            //                _InjsINJ1001U01InfectionListArgs);
            //        if (_InjsINJ1001U01InfectionListResult != null)
            //        {
            //            foreach (
            //                InjsINJ1001U01InfectionListItemInfo item in
            //                    _InjsINJ1001U01InfectionListResult.InfectionListItem)
            //            {
            //                object[] objects =
            //                {
            //                    item.InfeJaeryo,
            //                    item.InfeCode,
            //                };
            //                res.Add(objects);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("QueryGrdNUR1017" + ex.Message);
            //    throw;
            //}

            return res;
        }

        private IList<object[]> QueryCboTime(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                //_INJ1001U01CboTimeResult = CacheService.Instance.Get<INJ1001U01CboTimeArgs, INJ1001U01CboTimeResult>("INJ1001U01CboTimeResult", _INJ1001U01CboTimeArgs);
                //_INJ1001U01CboTimeResult = CacheService.Instance.Get<INJ1001U01CboTimeArgs, INJ1001U01CboTimeResult>(_INJ1001U01CboTimeArgs);
                _INJ1001U01CboTimeResult = CloudService.Instance.Submit<INJ1001U01CboTimeResult, INJ1001U01CboTimeArgs>(_INJ1001U01CboTimeArgs, true);
                if (_INJ1001U01CboTimeResult != null)
                {
                    foreach (ComboListItemInfo item in _INJ1001U01CboTimeResult.GrdOcs1003Item)
                    {
                        object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryCboTime" + ex.Message);
                throw;
            }
            return res;
        }


        private IList<object[]> QueryGrdDetail(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();

            if (TypeCheck.IsNull(this.grdDetail.BindVarList["f_bunho"].VarValue)) return res;

            _InjsINJ1001U01DetailListArgs.ActingDate = this.grdDetail.BindVarList["f_acting_date"].VarValue;
            _InjsINJ1001U01DetailListArgs.ActingFlag = this.grdDetail.BindVarList["f_acting_flag"].VarValue;
            _InjsINJ1001U01DetailListArgs.Bunho = this.grdDetail.BindVarList["f_bunho"].VarValue;
            _InjsINJ1001U01DetailListArgs.Doctor = this.grdDetail.BindVarList["f_doctor"].VarValue;
            _InjsINJ1001U01DetailListArgs.Gwa = this.grdDetail.BindVarList["f_gwa"].VarValue;
            _InjsINJ1001U01DetailListArgs.ReserDate = this.grdDetail.BindVarList["f_reser_date"].VarValue;
            _InjsINJ1001U01DetailListResult = null;

            if (_InjsINJ1001U01DetailListResult == null)
            {
                _InjsINJ1001U01DetailListResult = CloudService.Instance.Submit<InjsINJ1001U01DetailListResult, InjsINJ1001U01DetailListArgs>(
                            _InjsINJ1001U01DetailListArgs, true);
            }
            if (_InjsINJ1001U01DetailListResult != null)
            {
                foreach (InjsINJ1001U01DetailListItemInfo item in _InjsINJ1001U01DetailListResult.DetailListItem)
                {
                    object[] objects =
                    {
                        item.GroupSer,
                        item.Pkinj1002,
                        item.Fkinj1001,
                        item.Fkocs1003,
                        item.HangmogName,
                        item.Seq,
                        item.TonggyeCode,
                        item.MagamDate,
                        item.MagamJangso,
                        item.MagamSer,
                        item.ReserDateChar,
                        item.ReserTime,
                        item.JubsuDateChar,
                        item.HangmogCode,
                        item.JusaBuui,
                        item.ActingJangso,
                        item.ActingDateChar,
                        item.ActingTime,
                        item.CompanyCode,
                        item.LotNo,
                        item.ChasuCode,
                        item.PwResult,
                        item.CsResult,
                        item.Ast,
                        item.ActingFlag,
                        item.SunabDateChar,
                        item.SunabSuryang,
                        item.Fkout1001,
                        item.CancerYn,
                        item.Bunho,
                        item.RemarkChk,
                        item.DcYn,
                        item.JusaTongCnt,
                        item.OtherBuseoYn,
                        item.Jujongja,
                        item.JujongjaName,
                        item.YebangJujongChk,
                        item.ActdayChk,
                        item.Gwa,
                        item.BannabYn,
                        item.SkinYn,
                        item.ChungguDate,
                        item.OrderDate,
                        item.Doctor,
                        item.DanuiName,
                        item.HopeDateYn,
                        item.BogyongCode,
                        item.Suryang,
                        item.Dv,
                        item.DvTime,
                        item.SlipCode,
                        item.JusaYn,
                        item.MixGroup,
                        item.OldActingFlag,
                        item.SilsiRemark,
                        item.HopeDate,
                        item.OrderGubun,
                        item.TonggyeCodeName,
                        item.Key,
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        private IList<object[]> QueryGrdNUR1016(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            //try
            //{
            //    if (_GroupedLoad)
            //    {
            //        _INJ1001U01Grouped2Args.ActingDate = "";
            //        _INJ1001U01Grouped2Args.ActingFlag = "";
            //        _INJ1001U01Grouped2Args.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue;
            //        _INJ1001U01Grouped2Args.CommtGubun = "B";
            //        _INJ1001U01Grouped2Args.Doctor = "";
            //        _INJ1001U01Grouped2Args.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
            //        _INJ1001U01Grouped2Args.OrderDate = "";
            //        _INJ1001U01Grouped2Args.PostOrderYn = "";
            //        _INJ1001U01Grouped2Args.PreOrderYn = "";
            //        _INJ1001U01Grouped2Args.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            //        _INJ1001U01Grouped2Args.ReserDate = "";

            //        if (_INJ1001U01Grouped2Result == null)
            //        {
            //            _INJ1001U01Grouped2Result =
            //                CloudService.Instance.Submit<INJ1001U01Grouped2Result, INJ1001U01Grouped2Args>(
            //                    _INJ1001U01Grouped2Args);
            //        }
            //        if (_INJ1001U01Grouped2Result != null)
            //        {
            //            foreach (DataStringListItemInfo item in _INJ1001U01Grouped2Result.GrdNur1016ListItem)
            //            {
            //                object[] objects =
            //            {
            //                item.DataValue
            //            };
            //                //res.Add(objects);
            //            }
            //        }

            //        //_InjsINJ1001U01AllergyListArgs.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue;
            //        //_InjsINJ1001U01AllergyListArgs.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            //        //_InjsINJ1001U01AllergyListResult =
            //        //    CloudService.Instance.Submit<InjsINJ1001U01AllergyListResult, InjsINJ1001U01AllergyListArgs>(
            //        //        _InjsINJ1001U01AllergyListArgs);

            //        //if (_InjsINJ1001U01AllergyListResult != null)
            //        //{
            //        //    foreach (DataStringListItemInfo item in _InjsINJ1001U01AllergyListResult.AllergyInfo)
            //        //    {
            //        //        object[] objects =
            //        //    {
            //        //        item.DataValue
            //        //    };
            //        //        res.Add(objects);
            //        //    }
            //        //}

            //        res = (List<object[]>)querygrdNUR1016();
            //    }
            //    else
            //    {
            //        _InjsINJ1001U01AllergyListArgs.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue;
            //        _InjsINJ1001U01AllergyListArgs.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            //        _InjsINJ1001U01AllergyListResult =
            //            CloudService.Instance.Submit<InjsINJ1001U01AllergyListResult, InjsINJ1001U01AllergyListArgs>(
            //                _InjsINJ1001U01AllergyListArgs);

            //        if (_InjsINJ1001U01AllergyListResult != null)
            //        {
            //            foreach (DataStringListItemInfo item in _InjsINJ1001U01AllergyListResult.AllergyInfo)
            //            {
            //                object[] objects =
            //            {
            //                item.DataValue
            //            };
            //                res.Add(objects);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("QueryGrdNUR1016" + ex.Message);
            //    throw;
            //}

            return res;
        }

        private IList<object[]> QueryFwkCmt(BindVarCollection varlist)
        {
            List<object[]> lObj = new List<object[]>();

            INJ1001U01ComboListSortKeyArgs args = new INJ1001U01ComboListSortKeyArgs();
            args.CodeType = "INJ_COMMENT";
            // 2015.07.30 AnhNV fixed bug MED-2205
            //ComboResult res = CacheService.Instance.Get<INJ1001U01ComboListSortKeyArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_INJS_INJ1001U01_COMBO_LIST_SORT_KEY,
            //    args, delegate(ComboResult r) { return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0; });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, INJ1001U01ComboListSortKeyArgs>(args);
            ComboResult res = CacheService.Instance.Get<INJ1001U01ComboListSortKeyArgs, ComboResult>(args, delegate(ComboResult r)
            {
                return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }

        private IList<object[]> QueryGrdOCS1003(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();

            if (TypeCheck.IsNull(varlist["f_bunho"].VarValue)) return res;

            _InjsINJ1001U01ScheduleArgs.ActingFlag = varlist["f_acting_flag"].VarValue;
            _InjsINJ1001U01ScheduleArgs.Bunho = varlist["f_bunho"].VarValue;
            _InjsINJ1001U01ScheduleArgs.OrderDate = varlist["f_order_date"].VarValue;
            _InjsINJ1001U01ScheduleArgs.PostOrderYn = varlist["f_post_order_yn"].VarValue;
            _InjsINJ1001U01ScheduleArgs.PreOrderYn = varlist["f_pre_order_yn"].VarValue;
            _InjsINJ1001U01ScheduleArgs.ReserDate = varlist["f_reser_date"].VarValue;
            _InjsINJ1001U01ScheduleResult = null;


            if (_InjsINJ1001U01ScheduleResult == null)
            {
                _InjsINJ1001U01ScheduleResult = CloudService.Instance.Submit<InjsINJ1001U01ScheduleResult, InjsINJ1001U01ScheduleArgs>(_InjsINJ1001U01ScheduleArgs, true);
            }
            if (_InjsINJ1001U01ScheduleResult != null)
            {
                foreach (InjsINJ1001U01ScheduleItemInfo item in _InjsINJ1001U01ScheduleResult.ScheduleItem)
                {
                    object[] objects =
                    {
                        item.ReserDate,
                        item.OrderDate,
                        item.ActingDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.IfDataSendYn
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        private IList<object[]> QueryGrdSang(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();

            //_INJ1001U01GrdSangArgs.Bunho = this.grdSang.BindVarList["f_bunho"].VarValue;
            //_INJ1001U01GrdSangArgs.Gwa = this.grdSang.BindVarList["f_gwa"].VarValue;
            //_INJ1001U01GrdSangArgs.HospCode = this.grdSang.BindVarList["f_hosp_code"].VarValue;
            //_INJ1001U01GrdSangArgs.ReserDate = this.grdSang.BindVarList["f_reser_date"].VarValue;
            //_INJ1001U01GrdSangResult = null;

            //if (_INJ1001U01GrdSangResult == null)
            //{
            //    _INJ1001U01GrdSangResult = CloudService.Instance.Submit<INJ1001U01GrdSangResult, INJ1001U01GrdSangArgs>(_INJ1001U01GrdSangArgs);
            //}
            //if (_INJ1001U01GrdSangResult != null)
            //{
            //    foreach (INJ1001U01GrdSangItemInfo item in _INJ1001U01GrdSangResult.ScheduleItem)
            //    {
            //        object[] objects =
            //        {
            //            item.PkSeq,
            //            item.SangName,
            //            item.JuSangYn,
            //            item.SangStartDate
            //        };
            //        res.Add(objects);
            //    }
            //}

            return res;
        }

        #endregion

        #region save Grid Detail

        private UpdateResult GridDeatil_SaveLayout()
        {
            List<InjsINJ1001U01DetailListItemInfo> lstItemInfo = new List<InjsINJ1001U01DetailListItemInfo>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                InjsINJ1001U01DetailListItemInfo info = new InjsINJ1001U01DetailListItemInfo();
                info.ActingFlag = grdDetail.GetItemString(i, "acting_flag");
                info.ActingDateChar = grdDetail.GetItemString(i, "acting_date");
                info.ActingJangso = "IR";
                info.TonggyeCode = grdDetail.GetItemString(i, "tonggye_code");
                info.MixGroup = grdDetail.GetItemString(i, "mix_group");
                info.Jujongja = grdDetail.GetItemString(i, "jujongja");
                info.SilsiRemark = grdDetail.GetItemString(i, "silsi_remark");
                info.Pkinj1002 = grdDetail.GetItemString(i, "pkinj1002");

                lstItemInfo.Add(info);

            }
            INJ1001U01GridDetailSaveLayoutArgs args = new INJ1001U01GridDetailSaveLayoutArgs();
            args.UserId = UserInfo.UserID;
            args.UpdId = this.actor;
            args.ItemInfo = lstItemInfo;

            return CloudService.Instance.Submit<UpdateResult, INJ1001U01GridDetailSaveLayoutArgs>(args);

        }
        #endregion

        /// <summary>
        /// grdNUR1017_PreEndInitializing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void grdNUR1017_PreEndInitializing(object sender, EventArgs e)
        //{
        //    //xEditGridCell88.ExecuteQuery = QueryXEditGridCell88;
        //    //xEditGridCell89.ExecuteQuery = QueryXEditGridCell89;
        //}

        private IList<object[]> querygrdNUR1016()
        {
            List<object[]> res = new List<object[]>();

            //_InjsINJ1001U01AllergyListArgs.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue;
            //_InjsINJ1001U01AllergyListArgs.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            //_InjsINJ1001U01AllergyListResult =
            //    CloudService.Instance.Submit<InjsINJ1001U01AllergyListResult, InjsINJ1001U01AllergyListArgs>(
            //        _InjsINJ1001U01AllergyListArgs);

            //if (_InjsINJ1001U01AllergyListResult != null)
            //{
            //    foreach (DataStringListItemInfo item in _InjsINJ1001U01AllergyListResult.AllergyInfo)
            //    {
            //        object[] objects =
            //            {
            //                item.DataValue
            //            };
            //        res.Add(objects);
            //    }
            //}

            return res;
        }

        #region fbxActor

        /// <summary>
        /// fbxActor_ExecuteQuery
        /// </summary>
        /// <param name="bindVarCollection"></param>
        /// <returns></returns>
        private IList<object[]> fbxActor_ExecuteQuery(BindVarCollection bindVarCollection)
        {
            IList<object[]> listObject = new List<object[]>();
            InjsINJ1001U01ActorListArgs args = new InjsINJ1001U01ActorListArgs();
            InjsINJ1001U01ActorListResult result =
                CloudService.Instance.Submit<InjsINJ1001U01ActorListResult, InjsINJ1001U01ActorListArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<InjsINJ1001U01ActorListItemInfo> lstActorListItemInfo = result.ActorListItem;
                if (lstActorListItemInfo != null && lstActorListItemInfo.Count > 0)
                {
                    foreach (InjsINJ1001U01ActorListItemInfo info in lstActorListItemInfo)
                    {
                        listObject.Add(new object[]
                        {
                            info.UserId,
                            info.UserNm,
                            info.DeptCode
                        });
                    }
                }
            }
            return listObject;
        }

        /// <summary>
        /// fbxActor_ExecuteValidating
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> fbxActor_ExecuteValidating(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            INJ1001U01LayCommonArgs vINJ1001U01LayCommonArgs = new INJ1001U01LayCommonArgs();
            vINJ1001U01LayCommonArgs.UserId = bc["f_user_id"].VarValue;
            vINJ1001U01LayCommonArgs.HospCode = bc["f_hosp_code"].VarValue;
            INJ1001U01LayCommonResult result = CloudService.Instance.Submit<INJ1001U01LayCommonResult, INJ1001U01LayCommonArgs>(vINJ1001U01LayCommonArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.UserNm)
                {
                    object[] objects =
                    {
                        item.DataValue
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion

        #region Cloud updated

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<INJ1001U01SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<INJ1001U01SaveLayoutInfo> lstData = new List<INJ1001U01SaveLayoutInfo>();

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged) continue;

                INJ1001U01SaveLayoutInfo item = new INJ1001U01SaveLayoutInfo();

                item.ActingDate = grdDetail.GetItemString(i, "acting_date");
                item.ActingFlag = grdDetail.GetItemString(i, "acting_flag");
                item.HangmogName = grdDetail.GetItemString(i, "hangmog_name");
                item.Jujongja = grdDetail.GetItemString(i, "jujongja");
                item.MixGroup = grdDetail.GetItemString(i, "mix_group");
                item.Pkinj1002 = grdDetail.GetItemString(i, "pkinj1002");
                item.SilsiRemark = grdDetail.GetItemString(i, "silsi_remark");
                item.TonggyeCode = grdDetail.GetItemString(i, "tonggye_code");
                item.HangmogCode = grdDetail.GetItemString(i, "hangmog_code");
                item.Fkocs1003 = grdDetail.GetItemString(i, "fkocs1003");
                item.Suryang = grdDetail.GetItemString(i, "suryang");
                item.Dv = grdDetail.GetItemString(i, "dv");
                item.Nalsu = "1";
                item.RowState = grdDetail.GetRowState(i).ToString();

                lstData.Add(item);
            }

            return lstData;
        }
        #endregion

        #region GetLayTemp
        /// <summary>
        /// GetLayTemp
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayTemp(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            InjsINJ1001U01TempListArgs args = new InjsINJ1001U01TempListArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.Doctor = bvc["f_doctor"].VarValue;
            args.JubsuDate = bvc["f_jubsu_date"].VarValue;
            args.ReserDate = bvc["f_reser_date"].VarValue;
            InjsINJ1001U01TempListResult res = CloudService.Instance.Submit<InjsINJ1001U01TempListResult, InjsINJ1001U01TempListArgs>(args);

            if (res != null && res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.TempListItem.ForEach(delegate(InjsINJ1001U01TempListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.SerialV,
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.Age,
                        item.Sex,
                        item.OrderDate,
                        item.JubsuDate,
                        item.Cnt,
                        item.Suryang,
                        item.DanuiName,
                        item.BogyongName,
                        item.JusaName,
                        item.JaeryoName,
                        item.OrderRemark,
                        item.DataGubun,
                        item.Birth,
                        item.DoctorName,
                        item.GwaName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region Cache init data
        //Request for all initialize data and cache if needed
        private void GetDataScreenOpenFirst()
        {
            INJ1001U01CompositeFirstArgs compositeArgs = new INJ1001U01CompositeFirstArgs();

            //1
            compositeArgs.CboTimeParam = new INJ1001U01CboTimeArgs();

            //2
            compositeArgs.GrdMasterParam = new InjsINJ1001U01MasterListArgs();
            compositeArgs.GrdMasterParam.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
            compositeArgs.GrdMasterParam.Gwa = "IR";
            compositeArgs.GrdMasterParam.ReserDate = this.currentDate.ToString("yyyy/MM/dd");
            //3
            compositeArgs.PatientInfo = GenPatientInfo();
            //4
            compositeArgs.OrderStatus = new InjsINJ1001U01CplOrderStatusArgs();
            compositeArgs.OrderStatus.Bunho = this.patInfo.BunHo;
            compositeArgs.OrderStatus.Date = this.dtpQueryDate.GetDataValue();
            compositeArgs.OrderStatus.Gubun = "O";
            compositeArgs.OrderStatus.JundalPart = "CPL";
            //5
            compositeArgs.ConstantInfo = new INJ1001U01MlayConstantInfoArgs();
            //6
            compositeArgs.Schedule = new InjsINJ1001U01ScheduleArgs();
            compositeArgs.Schedule.ActingFlag = "N";
            compositeArgs.Schedule.Bunho = this.bunho;
            compositeArgs.Schedule.PostOrderYn = mPostOrderYn;
            compositeArgs.Schedule.PreOrderYn = mPreOrderYn;
            compositeArgs.Schedule.OrderDate = this.orderDate;
            compositeArgs.Schedule.ReserDate = this.dtpQueryDate.GetDataValue();
            //7
            compositeArgs.DetailtList = new InjsINJ1001U01DetailListArgs();
            compositeArgs.DetailtList.ActingDate = grdOCS1003.GetItemString(grdOCS1003.CurrentRowNumber, "acting_date");
            compositeArgs.DetailtList.ActingFlag = "N";
            compositeArgs.DetailtList.Bunho = this.bunho;
            compositeArgs.DetailtList.Doctor = grdOCS1003.GetItemString(grdOCS1003.CurrentRowNumber, "doctor");
            compositeArgs.DetailtList.Gwa = grdOCS1003.GetItemString(grdOCS1003.CurrentRowNumber, "gwa");
            compositeArgs.DetailtList.ReserDate = grdOCS1003.GetItemString(grdOCS1003.CurrentRowNumber, "reser_date"); 

            INJ1001U01CompositeFirstResult compositeResult = CloudService.Instance.Submit<INJ1001U01CompositeFirstResult, INJ1001U01CompositeFirstArgs>(compositeArgs, true, CallbackINJ1001U01CompositeFirst);
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackINJ1001U01CompositeFirst(INJ1001U01CompositeFirstArgs args, INJ1001U01CompositeFirstResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();

            cacheSession.Add(args.CboTimeParam, new KeyValuePair<int, object>(1, result.CboTimeList));
            cacheSession.Add(args.GrdMasterParam, new KeyValuePair<int, object>(1, result.GrdMasterList));
            cacheSession.Add(args.PatientInfo, new KeyValuePair<int, object>(1, result.PatientInfo));
            cacheSession.Add(args.OrderStatus, new KeyValuePair<int, object>(1, result.OrderStatusRes));
            cacheSession.Add(args.ConstantInfo, new KeyValuePair<int, object>(1, result.ConstantInfoRes));
            cacheSession.Add(args.Schedule, new KeyValuePair<int, object>(1, result.ScheduleRes));
            cacheSession.Add(args.DetailtList, new KeyValuePair<int, object>(1, result.DetailtListRes));

            if (result.GrdMasterList.MasterListItem.Count > 0)
            {
                GetPatientByCodeArgs patient = new GetPatientByCodeArgs();
                patient.PatientCode = result.GrdMasterList.MasterListItem[0].Bunho;
                cacheSession.Add(patient, new KeyValuePair<int, object>(1, result.PatientInfo));
            }
            cacheData.Add(CachePolicy.SESSION, cacheSession);

            return cacheData;
        }
        private GetPatientByCodeArgs GenPatientInfo()
        {
            //2
            GetPatientByCodeArgs patient = new GetPatientByCodeArgs();
            patient.PatientCode = "";
            return patient;
        }

        private void GetDataScreenOpenSecond()
        {
            INJ1001U01CompositeSecondArgs compositeArgs = new INJ1001U01CompositeSecondArgs();

            compositeArgs.GrdDetail = GenDetailArgs();
            compositeArgs.GrdSang = GenGrdSangArgs();
            compositeArgs.CplOrder = GenCplOrderArgs();
            compositeArgs.Grouped = GenGroupedArgs();
            compositeArgs.Allergy = GenAllergyArgs();
            compositeArgs.ReserDate = GenReserDateArgs();
            compositeArgs.ChkbState = GenChkbStateList();

            INJ1001U01CompositeSecondResult compositeResult = CloudService.Instance.Submit<INJ1001U01CompositeSecondResult, INJ1001U01CompositeSecondArgs>(compositeArgs, true, CallbackINJ1001U01CompositeSecond);
        }

        private List<InjsINJ1001U01ChkbStateArgs> GenChkbStateList()
        {
            //7
            List<InjsINJ1001U01ChkbStateArgs> chkbStateList = new List<InjsINJ1001U01ChkbStateArgs>();
            //for (int i = 0; i < this.grdMaster.RowCount; i++)
            //{
            //    InjsINJ1001U01ChkbStateArgs cbkbStateArgs = new InjsINJ1001U01ChkbStateArgs();
            //    cbkbStateArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
            //    cbkbStateArgs.ReserDate = dtpQueryDate.GetDataValue();
            //    cbkbStateArgs.Bunho = this.grdMaster.GetItemString(i, "bunho");
            //    cbkbStateArgs.Doctor = this.grdMaster.GetItemString(i, "doctor");
            //    chkbStateList.Add(cbkbStateArgs);
            //}

            InjsINJ1001U01ChkbStateArgs cbkbStateArgs = new InjsINJ1001U01ChkbStateArgs();
            cbkbStateArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
            cbkbStateArgs.ReserDate = dtpQueryDate.GetDataValue();
            cbkbStateArgs.Bunho = this.bunho;
            cbkbStateArgs.Doctor = this.doctor;
            chkbStateList.Add(cbkbStateArgs);

            return chkbStateList;
        }

        private InjsINJ1001U01ReserDateListArgs GenReserDateArgs()
        {
            //6
            InjsINJ1001U01ReserDateListArgs reserDateArgs = new InjsINJ1001U01ReserDateListArgs();
            reserDateArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
            reserDateArgs.Bunho = patInfo.BunHo;
            reserDateArgs.Doctor = "";
            reserDateArgs.ReserDate = this.dtpQueryDate.GetDataValue();

            return reserDateArgs;
        }

        private InjsINJ1001U01AllergyListArgs GenAllergyArgs()
        {
            //5
            InjsINJ1001U01AllergyListArgs allergyArgs = new InjsINJ1001U01AllergyListArgs();
            allergyArgs.Bunho = patInfo.BunHo;
            allergyArgs.QueryDate = dtpQueryDate.GetDataValue();

            return allergyArgs;
        }

        private INJ1001U01Grouped2Args GenGroupedArgs()
        {
            //4
            INJ1001U01Grouped2Args groupedArgs = new INJ1001U01Grouped2Args();
            groupedArgs.ActingDate = "";
            groupedArgs.ActingFlag = "";
            groupedArgs.Bunho = this.patInfo.BunHo;
            groupedArgs.CommtGubun = "B";
            groupedArgs.Doctor = "";
            groupedArgs.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
            groupedArgs.OrderDate = "";
            groupedArgs.PostOrderYn = "";
            groupedArgs.PreOrderYn = "";
            groupedArgs.QueryDate = this.dtpQueryDate.GetDataValue();
            groupedArgs.ReserDate = "";

            return groupedArgs;
        }

        private InjsINJ1001U01CplOrderStatusArgs GenCplOrderArgs()
        {
            //3
            InjsINJ1001U01CplOrderStatusArgs cplOrderArgs = new InjsINJ1001U01CplOrderStatusArgs();
            cplOrderArgs.Bunho = this.patInfo.BunHo;
            cplOrderArgs.Date = this.dtpQueryDate.GetDataValue();
            cplOrderArgs.Gubun = "O";
            cplOrderArgs.JundalPart = "CPL";

            return cplOrderArgs;
        }

        private INJ1001U01GrdSangArgs GenGrdSangArgs()
        {
            //2
            INJ1001U01GrdSangArgs grdSangArgs = new INJ1001U01GrdSangArgs();
            grdSangArgs.Bunho = this.patInfo.BunHo;
            grdSangArgs.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
            grdSangArgs.ReserDate = this.dtpQueryDate.GetDataValue();
            grdSangArgs.HospCode = UserInfo.HospCode;

            return grdSangArgs;
        }

        private InjsINJ1001U01DetailListArgs GenDetailArgs()
        {
            //1
            InjsINJ1001U01DetailListArgs detailArgs = new InjsINJ1001U01DetailListArgs();
            XEditGrid grd = new XEditGrid();
            grd = this.grdOCS1003;
            int currRow = grd.CurrentRowNumber;
            detailArgs.Bunho = this.patInfo.BunHo;
            detailArgs.ReserDate = grd.GetItemString(currRow, "reser_date");
            detailArgs.ActingDate = grd.GetItemString(currRow, "acting_date");
            detailArgs.Gwa = grd.GetItemString(currRow, "gwa");
            detailArgs.Doctor = grd.GetItemString(currRow, "doctor");
            detailArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";

            return detailArgs;
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackINJ1001U01CompositeSecond(INJ1001U01CompositeSecondArgs args, INJ1001U01CompositeSecondResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();

            cacheSession.Add(args.GrdDetail, new KeyValuePair<int, object>(1, result.GrdDetail));
            cacheSession.Add(args.GrdSang, new KeyValuePair<int, object>(1, result.GrdSang));
            cacheSession.Add(args.CplOrder, new KeyValuePair<int, object>(1, result.CplOrder));
            cacheSession.Add(args.Grouped, new KeyValuePair<int, object>(1, result.Grouped));
            cacheSession.Add(args.Allergy, new KeyValuePair<int, object>(2, result.Allergy)); //allergy call 2 times
            cacheSession.Add(args.ReserDate, new KeyValuePair<int, object>(1, result.ReserDate));
            for (int i = 0; i < result.ChkbState.Count; i++)
            {
                cacheSession.Add(args.ChkbState[i], new KeyValuePair<int, object>(1, result.ChkbState[i]));
            }

            cacheData.Add(CachePolicy.ONCE, cacheSession);

            return cacheData;
        } 
        #endregion

        #endregion

        private void Init()
        {
            this.dw_jusa.DataWindowObject = "";
            this.dw_jusa.DataWindowObject = Resources.INJ_dw_jusaDataWindowObject;
            this.dw_jusa.LibraryList = Resources.INJ_dw_jusaLibraryList;
            this.dw_jusa.Name = Resources.INJ_dw_jusaName;
            this.dw_jusa_lable.DataWindowObject = "";
            this.dw_jusa_lable.DataWindowObject = Resources.INJ_dw_jusa_lableDataWindowObject;
            this.dw_jusa_lable.LibraryList = Resources.INJ_dw_jusa_lableLibraryList;
            this.dw_jusa_lable.Name = Resources.INJ_dw_jusa_lableName;
            this.xDataWindow1.DataWindowObject = "";
            this.xDataWindow1.DataWindowObject = Resources.INJ_xDataWindow1DataWindowObject;
            this.xDataWindow1.LibraryList = Resources.INJ_xDataWindow1LibraryList;
            this.xDataWindow1.Name = Resources.INJ_xDataWindow1Name;
            this.dw1.DataWindowObject = "";
            this.dw1.DataWindowObject = Resources.INJ_dw1DataWindowObject;
            this.dw1.LibraryList = Resources.INJ_dw1LibraryList;
            this.dw1.Name = Resources.INJ_dw1Name;
            //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.BrtWait, -1, ""));
            //this.btnList.InitializeButtons();
            //this.btnList.Refresh();
            this.dw_jusa_lable.Visible = false;
        }

        #region Simple version

        public void OpenScreen()
        {
            try
            {
                patInfo.SetPatientID(this.bunho);

                itemTable = new DataTable("lable");

                currentDate = EnvironInfo.GetSysDate();
                GetDataScreenOpenFirst();
                Init();
                BindExecuteQueryMethod();

                mHospCode = EnvironInfo.HospCode;
                //this.grdDetail.SavePerformer = new XSavePerformer(this);

                // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
                if (this.Opener is IHIS.Framework.MdiForm &&
                    (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable ||
                     this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
                {
                    // Removed by Simple version
                    //Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                    //this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);
                }

                //this.xBuseoCombo1.SelectedIndexChanged -= new System.EventHandler(this.xBuseoCombo1_SelectedIndexChanged);
                //this.dtpQueryDate.DataValidating -=
                //    new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);

                //xBuseoCombo1.ComboItems.Add("IR", "IR");
                //xBuseoCombo1.AcceptData();
                //xBuseoCombo1.RefreshComboItems();
                //this.dtpQueryDate.SetDataValue(currentDate.ToString("yyyy/MM/dd"));
                dtpActingDate.SetDataValue(currentDate);
                //this.lblTitle.Text = Resources.lblTitleText;
                //this.lblTitle.ForeColor = new XColor(Color.Teal);
                //dtpQueryDate.Focus();
                itemTable.Columns.Add("fkinj1001", typeof(string));
                itemTable.Columns.Add("group_ser", typeof(string));
                itemTable.Columns.Add("mix_group", typeof(string));
                itemTable.Columns.Add("hope_date", typeof(string));
                itemTable.Columns.Add("order_date", typeof(string));
                itemTable.Columns.Add("order_gubun", typeof(string));
                itemTable.Columns.Add("bunho", typeof(string));
                itemTable.Columns.Add("gwa", typeof(string));
                itemTable.Columns.Add("doctor", typeof(string));

                if (EnvironInfo.CurrSystemID == "INJS")
                {
                    //xBuseoCombo1.SelectedValue = "IR";
                    mJundalPart = "IR";
                }
                else
                {
                    //xBuseoCombo1.SelectedValue = "IR";
                    mJundalPart = "IR";
                }
                //xBuseoCombo1.AcceptData();

                this.mReceivedBunho = "";

                if (this.OpenParam != null)
                {
                    if (this.OpenParam.Contains("bunho"))
                    {
                        this.mReceivedBunho = this.OpenParam["bunho"].ToString();
                    }
                    if (this.OpenParam.Contains("order_date"))
                    {
                        this.mReceivedDate = this.OpenParam["order_date"].ToString();
                        //this.dtpQueryDate.SetDataValue(mReceivedDate);
                    }
                    this.mOnReceiveBunho = true;
                }

                //this.xBuseoCombo1.SelectedIndexChanged += new System.EventHandler(this.xBuseoCombo1_SelectedIndexChanged);
                //this.dtpQueryDate.DataValidating +=
                //    new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);

                // タイマー設定
                this.setTimer();

                PostCallHelper.PostCall(new PostMethod(PostLoad));

                //this.btnList.PerformClick(FunctionType.Query);
                this.HandleButtonListClick(FunctionType.Query,out reload);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\nInner exception:\r\n" + ex.InnerException.Message);
                throw;
            }
        }
        private bool reload;
        public void HandleButtonListClick(FunctionType fType,out bool reload)
        {
            reload = true;
            switch (fType)
            {
                //case FunctionType.Update:
                case FunctionType.Process:
                    //e.IsBaseCall = false;
                    mIsSaveSuccess = false;
                    reload = false;
                    if (this.grdDetail.RowCount < 1) return;

                    // 未投与の場合
                    if (this.rbtWait.Checked)
                    {
                        for (int i = 0; i < this.grdDetail.RowCount; i++)
                        {
                            if (this.grdDetail.GetItemValue(i, "acting_flag").ToString() == "Y")
                            {
                                reload = true;
                                if (!this.checkActor(i))
                                {
                                    XMessageBox.Show(Resources.INJ_XMessageBox1, Resources.INJ_Caption1,
                                        MessageBoxIcon.Information);
                                    //this.fbxActor.Focus();
                                    return;
                                }

                                if (!this.checkDate(i))
                                {
                                    return;
                                }
                            }
                        }
                        if (!reload) { return; }
                    }                    
                    if (this.rbtDone.Checked)
                    {
                        reload = true;
                        foreach (DataRow dtRow in grdOCS1003.LayoutTable.Rows)
                        {
                            // 会計未処理のみ
                            if (dtRow["if_data_send_yn"].ToString() == "Y")
                            {                                
                                XMessageBox.Show(Resources.INJ_XMessageBox2, "", MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    this.grdDetailPreSaveLayout();

                    // 2015.04.27 deleted by AnhNV
                    // Connect to cloud: save grdDetail
                    //UpdateResult updateResult = GridDeatil_SaveLayout();
                    //if (updateResult != null && updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result)
                    //{
                    //    this.grdDetailSaveEnd();
                    //    this.mMsg = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox2_Ko
                    //        : Resources.XMessageBox2_JP;
                    //    this.mCap = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox3_Ko
                    //        : Resources.XMessageBox3_JP;
                    //    //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    mIsSaveSuccess = true;
                    //}
                    //else
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox4_Ko
                    //        : Resources.XMessageBox4_JP;
                    //    this.mMsg += "\r\n" + Service.ErrFullMsg;
                    //    this.mCap = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox5_Ko
                    //        : Resources.XMessageBox5_Jp;
                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    // 2015.04.27 Added by AnhNV

                    //MED-11162
                    if (!IHIS.Framework.Utilities.CheckInventory(grdDetail.LayoutTable))
                    {
                        return;
                    }

                    List<INJ1001U01SaveLayoutInfo> lstData = GetListDataForSaveLayout();

                    if (lstData.Count > 0)
                    {
                        INJ1001U01SaveLayoutArgs args = new INJ1001U01SaveLayoutArgs();
                        //args.UpdId = fbxActor.GetDataValue().ToString();
                        args.UpdId = this.actor;
                        args.UserId = UserInfo.UserID;
                        args.SaveLayoutItem = lstData;
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, INJ1001U01SaveLayoutArgs>(args);

                        if (res.ExecutionStatus == ExecutionStatus.Success)
                        {
                            if (!TypeCheck.IsNull(res.Msg))
                            {
                                XMessageBox.Show(Resources.INJ_XMessageBox13 + res.Msg + Resources.INJ_XMessageBox12, Resources.INJ_Caption4, MessageBoxIcon.Warning);
                            }

                            if (res.Result)
                            {
                                this.grdDetailSaveEnd();
                                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox2_Ko : Resources.INJ_XMessageBox2_JP;
                                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox3_Ko : Resources.INJ_XMessageBox3_JP;
                                //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mIsSaveSuccess = true;
                            }
                            else
                            {
                                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox4_Ko : Resources.INJ_XMessageBox4_JP;
                                this.mMsg += "\r\n" + Service.ErrFullMsg;
                                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox5_Ko : Resources.INJ_XMessageBox5_Jp;
                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox4_Ko : Resources.INJ_XMessageBox4_JP;
                            this.mMsg += "\r\n" + Service.ErrFullMsg;
                            this.mCap = NetInfo.Language == LangMode.Ko ? Resources.INJ_XMessageBox5_Ko : Resources.INJ_XMessageBox5_Jp;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    break;

                case FunctionType.Query:
                    //e.IsBaseCall = false;

                    this.clearDetailScreen();

                    //this.grdMaster.QueryLayout(true);

                    if (this.mOnReceiveBunho)
                    {
                        //grdMaster.SetFocusToItem(mReceiveBunhoRowNum, "bunho");

                        /*modify by CloudVersion team on 07-12-2015
                         *Bug MED-5868
                         * mReceiveBunhoRowNum = current row number of grdMaster
                         * mReceivedBunho = current patient ID
                         * => change logic: mReceiveBunhoRowNum to mReceivedBunho
                         */
                        //this.patInfo.SetPatientID(mReceiveBunhoRowNum.ToString());
                        //this.patInfo.SetPatientID(mReceivedBunho.ToString());

                        mOnReceiveBunho = false;
                    }

                    // Simple version
                    if (reload)
                    {
                        this.grdOCS1003.QueryLayout(true);
                        this.grdDetail.QueryLayout(true);
                    }

                    break;
                default:
                    break;
            }
        }

        public void HandleBtnReserClick()
        {

            //MED-9970
            if (this.dtpQueryDate == null) return;

            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("INJS", "INJ1002U01");

            if (aScreen == null)
            {
                string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                openParams.Add("queryDate", this.dtpQueryDate.GetDataValue());
                openParams.Add("gwa", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "gwa"));
                openParams.Add("doctor", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "doctor"));
                //this.timer1.Stop();
                XScreen.OpenScreenWithParam(this, "INJS", "INJ1002U01", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);

                //if (this.useTimeChkYN.Equals("Y")) this.timer1.Start();
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }

            //this.grdMaster.QueryLayout(true);

            this.patInfo.SetPatientID("");
            //this.grdOCS1003.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회
            //this.layReserDate.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            //this.layReserDate.SetBindVarValue("f_acting_flag", this.rdoWait.Checked ? "N" : "Y");
            //this.layReserDate.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            //this.layReserDate.QueryLayout(false);
        }

        public void HandleBtnPrintSetupClick()
        {
            this.SetPrint();
        }

        public void HandleBtnReInjActScripClick()
        {
            if (this.grdDetail.RowCount > 0) this.prtInjActScrip();
            else return;
        }

        public void HandleBtnLabelClick()
        {
            this.prtLabel();
        }

        public void HandleBtnReLabelClick()
        {
            this.prtLabel();
        }

        public void HandleBtnChkAllJubsuClick()
        {
            if (this.chkAllJubsuYN.Equals("Y"))
            {
                //this.btnChkAllJubsu.ImageIndex = 2;
                this.chkAllJubsuYN = "N";

                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    //조회된 로우를 돌면서~
                    if (this.grdDetail.GetItemString(i, "acting_flag").Equals("N"))
                        continue; //원래 미실시로되어있는애들은 건너뛰고~
                    this.grdDetail.SetItemValue(i, "acting_flag", "N"); //실시 체크해제
                }
            }
            else
            {
                //this.btnChkAllJubsu.ImageIndex = 3;
                this.chkAllJubsuYN = "Y";

                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    //조회된 로우를 돌면서
                    if (this.grdDetail.GetItemString(i, "acting_flag").Equals("Y"))
                        continue; //실행되어있던 애들은 건너뛰고~
                    this.grdDetail.SetItemValue(i, "acting_flag", "Y"); //실시에 체크
                }
            }
        }

        #endregion
    }
}