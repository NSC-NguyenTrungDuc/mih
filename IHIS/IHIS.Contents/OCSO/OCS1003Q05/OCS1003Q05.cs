#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSO.Properties;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using System.Collections.Generic;
using System.Reflection;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
#endregion

namespace IHIS.OCSO
{
    /// <summary>
    /// OCS1003Q00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class OCS1003Q05 : IHIS.Framework.XScreen
    {
        #region [OCS Library]
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리        
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
        private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리

        #endregion

        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";

        //등록번호
        private string mBunho = "";
        //진료과
        private string mGwa = "";
        //입력구분
        private string mInput_gubun = "";

        private ArrayList mCanDoArrList = new ArrayList();

        //private bool mIsDrugJusa = false;
        //내원일자
        private string mNaewon_date = "";
        //pk_order
        private string mPk_order = "";
        //tel처방여부
        private string mTel_yn = "%";
        //입력오더구분
        private string mInput_tab = "%";

        //Call한 시스템 외래,입원,응급 구분
        private string mIOgubun = "";

        //Data가 없는 경우 화면 닫을지 여부
        private bool mAuto_close = false;

        //신규그룹번호발생여부
        private bool mIsNewGroupSer = true;

        //자식여부
        private string mChildYN = "";

        private IHIS.X.Magic.Menus.PopupMenu popupMenu = new IHIS.X.Magic.Menus.PopupMenu();

        // 팝업메뉴
        private IHIS.X.Magic.Menus.PopupMenu mMenuPFEResult = new IHIS.X.Magic.Menus.PopupMenu();

        //hospital code
        private string mHospCode = EnvironInfo.HospCode;

        /// <summary>
        /// Cache key
        /// </summary>
        private const string CACHE_CBO = "OCSO.OCS1003Q05.Cbo";

        /// <summary>
        /// patientFormX
        /// </summary>
        int patientFormX;

        /// <summary>
        /// IOGubun
        /// </summary>
        private string IOGubun = "O";
        #endregion

        #region Constructor
        /// <summary>
        /// OCS1003Q05
        /// </summary>
        public OCS1003Q05()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.mOrderBiz = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리            
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
            this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리         
            this.mColumnControl = new IHIS.OCS.ColumnControl(this.ScreenID); // OCS 컬럼 컨트롤 그룹 라이브러리 

            // Cloud updated
            InitControlsToConnectCloud();

            //disable rbtIn due to MED-3803
            this.rbtIn.Enabled = false;

            //TODO disable IN Hospital Tab MED-5790
            InvisibleRbtIn();

        }

        private void InvisibleRbtIn()
        {
            this.rbtIn.Visible = false;
            this.rbtOut.Width += rbtOut.Width;
        }
        #endregion

        #region Events

        public override object Command(string command, CommonItemCollection commandParam)
        {
            return base.Command(command, commandParam);
        }

        protected override void OnLoad(EventArgs e)
        {
            cboKijunGubun.SelectedIndexChanged -= new EventHandler(cboKijunGubun_SelectedIndexChanged);
            rbtOut.CheckedChanged -= new EventHandler(rbtOut_CheckedChanged);
            chkAll.CheckedChanged -= new EventHandler(chkAll_CheckedChanged);

            patientFormX = ParentForm.Location.X;

            //ntt 처방일자
            grdOCS1003.AutoSizeColumn(3, 0);
            grdOUT1001.SetBindVarValue("f_io_gubun", "O");

            try
            {
                popupMenu.MenuCommands.Clear();
                popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? Resources.MessageText1_JP : Resources.MessageText1_Ko, (Image)this.ImageList.Images[2],
                    new EventHandler(this.PopUpMenuGumsaInfo_Click)));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.Message);
            }

            mMenuPFEResult.MenuCommands.Clear();
            CheckHideButtonArgs args = new CheckHideButtonArgs();
            args.CodeType = "RESULT_BUTTON_USE_YN";
            CheckHideButtonResult result = CloudService.Instance.Submit<CheckHideButtonResult, CheckHideButtonArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                bool check = false;
                foreach (CheckHideButtonInfo item in result.Dt)
                {
                    if (item.CodeName.Equals("Y"))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    CheckHideButtonInfo item;
                    IHIS.X.Magic.Menus.MenuCommand popUpMenu;
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_6, (Image)this.ImageList.Images[13], new EventHandler(btnAPLResult_Click));
                    popUpMenu.Tag = "1";
                    item = GetItemHideButton(result.Dt, "CPL");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_7, (Image)this.ImageList.Images[11], new EventHandler(btnXRTResult_Click));
                    popUpMenu.Tag = "2";
                    item = GetItemHideButton(result.Dt, "XRT");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.MessageText2_JP, (Image)this.ImageList.Images[10], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "3";
                    item = GetItemHideButton(result.Dt, "END");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.MessageText3_JP, (Image)this.ImageList.Images[17], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "4";
                    item = GetItemHideButton(result.Dt, "ENDR");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.MessageText4_JP, (Image)this.ImageList.Images[7], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "5";
                    item = GetItemHideButton(result.Dt, "EKG");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                }
                else
                {
                    btnPFEResult.Visible = false;
                }
            }

            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                    {
                        if (OpenParam["bunho"].ToString().Trim() == "")
                        {
                            //mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正しくありません。 ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
                            //mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            //XMessageBox.Show(mbxMsg, mbxCap);
                            //this.Close();
                            //return;
                        }
                        else
                            mBunho = OpenParam["bunho"].ToString().Trim();
                    }
                    else
                    {
                        //mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正しくありません。 ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
                        //mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        //XMessageBox.Show(mbxMsg, mbxCap);
                        //this.Close();
                        //return;
                    }

                    if (OpenParam.Contains("gwa"))
                    {
                        if (OpenParam["gwa"].ToString().Trim() == "")
                        {
                            //mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正しくありません。 ご確認ください。" : "진료과가 정확하지않습니다. 확인바랍니다.";
                            //mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            //XMessageBox.Show(mbxMsg, mbxCap);
                            //this.Close();
                            //return;
                        }
                        else
                            mGwa = OpenParam["gwa"].ToString().Trim();
                    }
                    else
                    {
                        //mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正しくありません。 ご確認ください。" : "진료과가 정확하지않습니다. 확인바랍니다.";
                        //mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        //XMessageBox.Show(mbxMsg, mbxCap);
                        //this.Close();
                        //return;
                    }


                    if (OpenParam.Contains("input_gubun"))
                    {
                        if (OpenParam["input_gubun"].ToString().Trim() == "")
                        {

                            //mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正しくありません。 ご確認ください。" : "입력구분이 정확하지않습니다. 확인바랍니다.";
                            //mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            //XMessageBox.Show(mbxMsg, mbxCap);
                            //this.Close();
                            //return;
                        }
                        else
                        {
                            string temp = "";
                            String[] mCanDoList;
                            if (mInput_gubun != "DA")
                            {
                                mInput_gubun = OpenParam["input_gubun"].ToString().Trim();
                                mOrderBiz.LoadColumnCodeName("code", "DO_INPUT_TAB_POSSIBLE", mInput_gubun, ref temp);

                                mCanDoList = temp.Split('/');

                                for (int i = 0; i < mCanDoList.Length; i++)
                                {
                                    mCanDoArrList.Add(mCanDoList[i].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        //mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正しくありません。 ご確認ください。" : "입력구분이 정확하지않습니다. 확인바랍니다.";
                        //mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        //XMessageBox.Show(mbxMsg, mbxCap);
                        //this.Close();
                        //return;
                    }


                    //pk_order
                    if (OpenParam.Contains("pk_order"))
                    {
                        mPk_order = OpenParam["pk_order"].ToString().Trim();
                    }

                    mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                    if (OpenParam.Contains("naewon_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                            mNaewon_date = OpenParam["naewon_date"].ToString();
                    }

                    this.dpkNaewon_date.SetDataValue(mNaewon_date);
                    this.dpkSetHopeDate.SetDataValue(mNaewon_date);

                    //Data가 없는 경우 화면 닫을지 여부
                    if (OpenParam.Contains("auto_close"))
                    {
                        mAuto_close = bool.Parse(OpenParam["auto_close"].ToString().Trim());
                        //if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
                        if (mAuto_close) this.ParentForm.Location = new Point(0 - ParentForm.Size.Width, ParentForm.Location.Y);
                    }

                    if (OpenParam.Contains("tel_yn"))
                    {
                        mTel_yn = OpenParam["tel_yn"].ToString().Trim();
                    }

                    if (TypeCheck.IsNull(mTel_yn))
                        mTel_yn = "%";

                    if (OpenParam.Contains("input_tab"))
                    {
                        mInput_tab = OpenParam["input_tab"].ToString().Trim();
                    }

                    if (OpenParam.Contains("io_gubun"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["io_gubun"].ToString()))
                        {
                            mIOgubun = OpenParam["io_gubun"].ToString();
                        }
                    }
                    if (OpenParam.Contains("childYN"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["childYN"].ToString()))
                        {
                            mChildYN = OpenParam["childYN"].ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }
            else
            {
                //mBunho = "00044383";
                //mGwa = "EN";
                mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                dpkNaewon_date.SetDataValue(mNaewon_date);
                mInput_gubun = "D0";
            }

            this.initScreen();

            //Set M/D Relation

            grdOCS1003.SetRelationKey("bunho", "bunho");
            grdOCS1003.SetRelationKey("naewon_date", "naewon_date");
            grdOCS1003.SetRelationKey("gwa", "gwa");
            grdOCS1003.SetRelationKey("input_gubun", "input_gubun");

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private CheckHideButtonInfo GetItemHideButton(List<CheckHideButtonInfo> lst, string code)
        {
            foreach (CheckHideButtonInfo item in lst)
            {
                if (item.Code.Equals(code)) return item;
            }
            return null;
        }

        private void grdOUT1001_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            //select 정보 reset
            //dloSelectOCS1001.Reset();
            //dloSelectOCS1003.Reset();
            //bool isSelect = false;

            this.SetSelectNaewon(-1);

            //SelectionBackColorChange(grdOUT1001);
            //this.DisplayListImage(grdOUT1001);
        }

        private void grdOCS1003_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            //SelectionBackColorChange(grdOCS1003);
            childSetImage();
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    //select 정보 reset
                    if (this.CurrMSLayout == grdOUT1001)
                    {
                        dloSelectOCS1003.Reset();
                    }

                    break;

                case FunctionType.Close:

                    dloSelectOCS1003.Dispose();

                    break;

                default:

                    break;
            }
        }

        private void grdOUT1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            // Cloud updated code START
            //GrdOUT1001RowFocusChanged();
            //grdOCS1003.ExecuteQuery = GetGrdOCS1003ForRowFocusChanged;
            // Cloud updated code END

            this.grdSangInfo.QueryLayout(true);

            this.grdOCS1003.SetBindVarValue("f_io_gubun", this.mIOgubun);
            if (!grdOCS1003.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }

            // Cloud updated
            //grdOCS1003.ExecuteQuery = GetGrdOCS1003;

            if (tabOrderGubun.SelectedTab == null) return;

            foreach (IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
            {
                if (tabOrderGubun.SelectedTab == page)
                    page.ImageIndex = 1;
                else
                    page.ImageIndex = 0;
            }

            //검사인 경우에는 실시일 기준으로 조회한다.
            if (tabOrderGubun.SelectedTab.Tag.ToString() == "4")
            {
                //                string filter = @" order_gubun_bas = 'G' 
                //                               or order_gubun_bas = 'H'
                //                               or order_gubun_bas = 'I'
                //                               or order_gubun_bas = 'J'
                //                               or order_gubun_bas = 'K'
                //                               or order_gubun_bas = 'L'
                //                               or order_gubun_bas = 'M'
                //                               or order_gubun_bas = 'N'
                //                               or order_gubun_bas = 'O'
                //                               or order_gubun_bas = 'Z'
                //                                 ";
                string filter = @" order_gubun_bas <> 'A' 
                               and order_gubun_bas <> 'B'
                               and order_gubun_bas <> 'C'
                               and order_gubun_bas <> 'D'
                               and order_gubun_bas <> 'E'
                               and order_gubun_bas <> 'F'
                                 ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "3")
            {
                string filter = @" order_gubun_bas = 'F' 
                                or order_gubun_bas = 'E'
                                or order_gubun_bas = 'N'
                                or order_gubun_bas = 'O'";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "2")
            {
                string filter = " order_gubun_bas = 'A' or order_gubun_bas = 'B' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "1")
            {
                string filter = " order_gubun_bas = 'C' or order_gubun_bas = 'D' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else
            {
                this.grdOCS1003.SetFilter("");
            }

            //this.ClearDetailInfo();

            //this.MakeGroupTab(this.grdOCS1003);

            this.SetInitialOrderGridCheckImage();

            //dloSelectOCS1003.Reset();

            //for(int i = 0; i < this.grdOUT1001.RowCount; i++)
            //{
            //    this.grdOUT1001.SetItemValue(i, "select", "N");
            //    SelectionBackColorChange(this.grdOUT1001, i, "N");
            //}

            this.childSetImage();
        }

        private void grdOCS1003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            //insert by jc [院内採用薬の場合ROWの色を塗る。]
            this.mColumnControl.ColumnColorForCodeQueryGrid(mIOgubun, grid, e); //sunab_check column 追加必！

            if (e.DataRow["bulyong_check"].ToString() == "Y" || e.DataRow["bulyong_check"].ToString() == "Z")
            {
                e.BackColor = ((XEditGridCell)grdOCS1003.CellInfos[e.ColName]).RowBackColor.Color;
                e.ForeColor = Color.Red;
                //insert by jc [bulyong_checkがYである時チェックボックスの後ろのNが見えてしまう不具合を修正] 2012/04/06
                if (e.ColName == "select")
                    e.ForeColor = System.Drawing.Color.Transparent;
            }
            if (((this.mIOgubun == "I" && grid.GetItemString(e.RowNumber, "io_yn") == "O")
                  || (this.mIOgubun == "O" && grid.GetItemString(e.RowNumber, "io_yn") == "I")
                  )
                  && this.mInput_gubun != "D7"
                )
            {
                e.BackColor = Color.DarkGray;
                return;
            }

            #region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
            switch (e.ColName)
            {
                case "bogyong_name": // 복용명
                    grdOCS1003[e.RowNumber, e.ColName].ToolTipText = grdOCS1003.GetItemString(e.RowNumber, "bogyong_name") + grdOCS1003.GetItemString(e.RowNumber, "dv_name");
                    if (
                          (
                               (this.mIOgubun == "I" && grdOCS1003.GetItemString(e.RowNumber, "io_yn") == "O")
                            || (this.mIOgubun == "O" && grdOCS1003.GetItemString(e.RowNumber, "io_yn") == "I")
                          )
                          && this.mInput_gubun != "D7"
                        )
                        e.BackColor = Color.Red;

                    break;

                case "child_yn":

                    e.ForeColor = Color.Transparent;

                    break;
                case "general_disp_yn":
                    if (this.grdOCS1003.GetItemString(e.RowNumber, e.ColName) == "Y")
                        e.BackColor = Color.LightCyan;
                    //else
                    //    e.BackColor = Color.Transparent;
                    break;

                // オーダ照会画面では完全に修正不可とする
                //case "nalsu":
                //    if (e.ColName == "nalsu" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C") && e.DataRow["donbog_yn"].ToString() != "Y")
                //    {
                //        e.ForeColor = Color.Red;
                //        e.BackColor = Color.LightGreen;
                //        e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, 12, FontStyle.Bold);
                //        this.gbxNalsu.Enabled = true;
                //    }
                //    break;

                //case "suryang":
                //    if (e.ColName == "suryang" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "D") || e.DataRow["donbog_yn"].ToString() == "Y")
                //    {
                //        e.ForeColor = Color.Red;
                //        e.BackColor = Color.LightGreen;
                //        e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, 12, FontStyle.Bold);
                //    }
                //    break;

                //case "dv":
                //    if (e.ColName == "dv" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C" && TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() == "Y"))
                //    {
                //        e.ForeColor = Color.Red;
                //        e.BackColor = Color.LightGreen;
                //        e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, 12, FontStyle.Bold);
                //    }
                //    break;

                //case "hope_date":
                //    //if ((e.DataRow["order_gubun"].ToString().Substring(1, 1) == "D") || (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C"))
                //    //{
                //        e.ForeColor = Color.Red;
                //        e.BackColor = Color.LightGreen;
                //        e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, 10, FontStyle.Bold);
                //    //}
                //    break;
                case "brought_drg_yn":
                    if (e.DataRow[e.ColName].ToString() == "Y")
                    {
                        e.ForeColor = Color.Red;
                    }
                    break;
            }
            #endregion


            // 処方状態による色変化 처방상태에 따른 색상 처리
            this.mHangmogInfo.ColumnColorForOrderState(mIOgubun, grid, e); // 처방상태에 따른 색상 처리

        }

        private void grdOCS1003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int rowIndex;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowIndex = grdOCS1003.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOCS1003.CurrentColNumber == 0)
                {
                    if (
                          ((this.mIOgubun == "I" && grdOCS1003.GetItemString(rowIndex, "io_yn") != "O")
                           || (this.mIOgubun == "O" && grdOCS1003.GetItemString(rowIndex, "io_yn") != "I")
                          )
                          && this.mInput_gubun != "D7"
                        )
                    {
                        //불용처리된 것은 선택을 막는다.
                        if (grdOCS1003.GetItemString(rowIndex, "bulyong_check") == "Y")
                        {
                            //불용인 경우에는 해당 항목의 심사기준을 보여준다.
                            mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS1003.GetItemString(rowIndex, "hangmog_code"));
                            mbxCap = NetInfo.Language == LangMode.Jr ? Resources.MessageText6_JP : Resources.MessageText6_Ko;
                            if (!TypeCheck.IsNull(mbxMsg)) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                            return;
                        }
                        //if (!this.mCanDoArrList.Contains(this.grdOCS1003.GetItemString(rowIndex, "input_tab")))
                        //{
                        //    XMessageBox.Show("定期処方で登録可能なオーダです。", "確認");
                        //    return;
                        //}

                        if (grdOCS1003.GetItemString(rowIndex, "select") == "N")
                        {
                            // 入院オーダで院内採用薬ではない場合は確認メッセージ出力
                            if (this.grdOCS1003.GetItemString(rowIndex, "wonnae_drg_yn") != "Y"
                                && this.mIOgubun == "I"
                                && (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "C"
                                    || this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "D"
                                    || this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "B"
                                   )
                                )
                            {
                                if (XMessageBox.Show("[ " + this.grdOCS1003.GetItemString(rowIndex, "hangmog_name") + Resources.MessageText7, Resources.MessageText6_JP, MessageBoxButtons.YesNo) == DialogResult.No)
                                    return;
                            }
                            grdOCS1003.SetItemValue(rowIndex, "select", "Y");
                            this.InsertBackTable(grdOCS1003.LayoutTable.Rows[rowIndex]);
                            SelectionBackColorChange(sender, rowIndex, "Y");


                            //외래오더에서 호출이고 입원do오다 선택시
                            //원외처리
                            if (this.mIOgubun == "O" && this.rbtIn.Checked)
                            {
                                if (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "C" ||
                                    this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "D")
                                {
                                    SetWonyoiOrderYN(rowIndex);
                                }
                            }
                        }
                        else
                        {
                            this.RemoveBackTable(grdOCS1003.LayoutTable.Rows[rowIndex]);
                            grdOCS1003.SetItemValue(rowIndex, "select", "N");
                            SelectionBackColorChange(sender, rowIndex, "N");
                        }

                        SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void grdOCS1003_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            if (e.CurrentRow >= 0)
            {
                // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
                this.mHangmogInfo.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
            }
        }

        private void dpkNaewon_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //select 정보 reset
            dloSelectOCS1003.Reset();
            grdOCS1003.Reset();
            grdOUT1001.SetBindVarValue("f_naewon_date", e.DataValue);
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        //전체진료과를 조회할 건지 여부
        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkAll.ImageIndex = 1;

                grdOUT1001.SetBindVarValue("f_gwa", "%");
            }
            else
            {
                chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkAll.ImageIndex = 0;

                grdOUT1001.SetBindVarValue("f_gwa", mGwa);
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

        }

        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            //this.ParentForm.WindowState = FormWindowState.Minimized;
            //XMessageBox.Show(mIsDrugJusa.ToString());
            if (this.dloSelectOCS1003.RowCount == 0)
            {
                if (XMessageBox.Show(Resources.MessageText9, Resources.MessageText6_JP, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.pbxUnderArrow.Visible = true;
                    timer_icon.Start();
                    return;
                }
            }
            CreateReturnLayout((sender as XButton).Tag.ToString());
        }

        private void chkIsNewGroup_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkIsNewGroup.Checked)
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkIsNewGroup.ImageIndex = 1;
                mIsNewGroupSer = true;

            }
            else
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkIsNewGroup.ImageIndex = 0;
                mIsNewGroupSer = false;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //bool isSelect = false;

            this.grdSelectAll(this.grdOCS1003);


        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            this.grdDeleteAll(this.grdOCS1003);


        }

        private void tabGroup_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                if (this.grdOCS1003.GetItemString(i, "group_ser") == this.tabGroup.SelectedTab.Tag.ToString())
                {
                    this.grdOCS1003.SetRowVisible(i, true);
                }
                else
                {
                    this.grdOCS1003.SetRowVisible(i, false);
                }
            }
        }

        private void rbtOut_CheckedChanged(object sender, System.EventArgs e)
        {
            //외래
            //select 정보 reset
            //dloSelectOCS1001.Reset();
            //dloSelectOCS1003.Reset();

            //201009 그리드 리셋
            grdOCS1003.Reset();

            //현재선택된 row trans
            //OCS1003
            //for (int i = 0; i < grdOCS1003.RowCount; i++)
            //{
            //    if (grdOCS1003.GetItemString(i, "select") == " ")
            //        dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
            //}

            if (rbtOut.Checked)
            {
                this.cboKijunGubun.Visible = false;
                this.pnlKijun.Visible = false;
                //입력구분
                //grdOCS1003.AutoSizeColumn(2, 0);

                //당일시행, 당일결과여부
                grdOCS1003.AutoSizeColumn(19, 80);
                grdOCS1003.AutoSizeColumn(20, 30);

                //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
                this.rbtOut.CheckedChanged -= new System.EventHandler(this.rbtOut_CheckedChanged);

                rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtOut.ImageIndex = 1;

                rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtIn.ImageIndex = 0;

                //grdOUT1001.SetBindVarValue("f_io_gubun", "O");
                IOGubun = "O";

            }
            //입원
            else
            {
                this.cboKijunGubun.Visible = true;
                this.pnlKijun.Visible = true;
                //입력구분
                //grdOCS1003.AutoSizeColumn(2, 77);

                //당일시행, 당일결과여부
                grdOCS1003.AutoSizeColumn(19, 30);
                grdOCS1003.AutoSizeColumn(20, 30);

                //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
                this.rbtIn.CheckedChanged -= new System.EventHandler(this.rbtOut_CheckedChanged);

                rbtIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtIn.ImageIndex = 1;

                rbtOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtOut.ImageIndex = 0;

                //grdOUT1001.SetBindVarValue("f_io_gubun", "I");
                IOGubun = "I";
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            PostCallHelper.PostCall(rbtEventCreate);
        }

        private void btnCplResult_Click(object sender, System.EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
            {
                //modify by jc
                this.OpenScreen_CPL0000Q01(this.pbxSearch.BunHo.ToString());
                //this.OpenScreen_CPL0000Q00(this.pbxSearch.BunHo.ToString());
            }
            //// 처방 입력 가능 여부
            //////if (!this.IsOrderInputCheck(true)) return;

            //// 검체검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseSizable, openParams);

        }

        private void btnXRTResult_Click(object sender, System.EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
            {
                this.OpenScreen_XRT0000Q00(this.pbxSearch.BunHo.ToString());
            }

            //// 방사선검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "XRTS", "XRT0000Q00", ScreenOpenStyle.PopUpSizable, openParams);

        }

        private void btnPFEResult_Click(object sender, System.EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.pbxSearch.BunHo.ToString() != "")
            {
                this.mMenuPFEResult.TrackPopup(this.PointToScreen(new Point(button.Location.X, button.Location.Y + (pbxSearch.Height + xPanel3.Height + xPanel4.Height))));
            }

            //// 각종검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "PFES", "PFE0000Q00", ScreenOpenStyle.PopUpSizable, openParams);
        }

        private void btnAPLResult_Click(object sender, System.EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
            {
                this.OpenScreen_ScanViewer(this.pbxSearch.BunHo.ToString());
            }

            //// 처방 입력 가능 여부
            //////if (!this.IsOrderInputCheck(true)) return;

            //// 각종검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "APLS", "APL0000Q00", ScreenOpenStyle.PopUpSizable, openParams);
        }

        private void btnINJResult_Click(object sender, System.EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
            {
                this.OpenScreen_INJ0000Q00(this.pbxSearch.BunHo.ToString());
            }

            //// 처방 입력 가능 여부
            //////if (!this.IsOrderInputCheck(true)) return;

            //// 각종검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "INJS", "INJ0000Q00", ScreenOpenStyle.PopUpSizable, openParams);
        }

        // 검사정보조회
        private void PopUpMenuGumsaInfo_Click(object sender, System.EventArgs e)
        {
            if (this.CurrMSLayout == null || CurrMSLayout.CurrentRowNumber < 0) return;

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("hangmog_code", CurrMSLayout.GetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_code"));
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void grdOCS1003_QueryStarting(object sender, CancelEventArgs e)
        {
            this.gbxNalsu.Enabled = false;

            grdOCS1003.SetBindVarValue("f_bunho", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "bunho"));
            grdOCS1003.SetBindVarValue("f_naewon_date", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "naewon_date").Replace(" 0:00:00", ""));
            grdOCS1003.SetBindVarValue("f_gwa", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "gwa"));
            grdOCS1003.SetBindVarValue("f_doctor", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "doctor"));
            grdOCS1003.SetBindVarValue("f_naewon_type", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "naewon_type"));
            grdOCS1003.SetBindVarValue("f_input_gubun", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "input_gubun"));
            grdOCS1003.SetBindVarValue("f_input_gubun", this.mInput_gubun);
            grdOCS1003.SetBindVarValue("f_tel_yn", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "tel_yn"));
            grdOCS1003.SetBindVarValue("f_input_tab", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "input_tab"));
            grdOCS1003.SetBindVarValue("f_jubsu_no", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "jubsu_no"));
            grdOCS1003.SetBindVarValue("f_pk_order", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pk_order"));
            grdOCS1003.SetBindVarValue("f_hosp_code", mHospCode);
            grdOCS1003.SetBindVarValue("f_generic_yn", cbxGeneric_YN.GetDataValue());
            grdOCS1003.SetBindVarValue("f_kijun", this.cboKijunGubun.SelectedValue.ToString());
        }

        private void grdOUT1001_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOUT1001.SetBindVarValue("f_bunho", this.pbxSearch.BunHo.ToString());
            grdOUT1001.SetBindVarValue("f_input_gubun", this.mInput_gubun);
            grdOUT1001.SetBindVarValue("f_tel_yn", mTel_yn);
            grdOUT1001.SetBindVarValue("f_hosp_code", mHospCode);
            grdOUT1001.SetBindVarValue("f_io_gubun", IOGubun);
            grdOUT1001.SetBindVarValue("f_input_tab", mInput_tab);

            if (this.cboKijunGubun.SelectedIndex < 0)
                this.cboKijunGubun.SelectedIndex = 0;

            grdOUT1001.SetBindVarValue("f_kijun", this.cboKijunGubun.SelectedValue.ToString());

            grdOUT1001.SetBindVarValue("f_selected_input_tab", this.tabOrderGubun.SelectedTab.Tag.ToString()); // 1:薬(01) 2:注射(03) 3:検査(04, 05, 06) 4:その他(07, 08, 09, 10)
        }

        private void xButtonList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void grdOCS1003_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            //オーダ照会画面では完全修正不可とする
            return;

            string currentGroupSer = "";
            string currentColumn = e.ColName;
            string currentNalsu = e.DataRow["nalsu"].ToString();
            XEditGrid grd = sender as XEditGrid;

            object previousValue = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value



            switch (e.ColName)
            {
                case "nalsu":
                    currentGroupSer = e.DataRow["group_ser"].ToString();

                    for (int i = 0; i < grd.RowCount; i++)
                    {
                        if (grd.GetItemValue(i, "group_ser").ToString() == currentGroupSer)
                        {
                            grd.SetItemValue(i, "nalsu", currentNalsu);

                            //変更されたROWがすでに選択された状態であればdloSelectOCS1003に変更する前の「日数」が入っているため、変更された「日数」を探して変更されたデータを変更しなければならない。
                            if (grd.GetItemString(i, "select") == "Y")
                            {
                                for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                                {
                                    if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(i, "pkocs1003"))
                                        this.dloSelectOCS1003.SetItemValue(kk, e.ColName, e.ChangeValue.ToString());
                                }
                            }
                        }
                    }
                    break;

                case "suryang":
                    //変更されたROWがすでに選択された状態であればdloSelectOCS1003に変更する前の「数量」が入っているため、変更された「数量」を探して変更されたデータを変更しなければならない。
                    if (grd.GetItemString(e.RowNumber, "select") == "Y")
                    {
                        for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                        {
                            if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(e.RowNumber, "pkocs1003"))
                                this.dloSelectOCS1003.SetItemValue(kk, e.ColName, e.ChangeValue.ToString());
                        }
                    }
                    break;
                case "hope_date":

                    #region
                    if (!TypeCheck.IsNull(e.ChangeValue))
                    {
                        if (!TypeCheck.IsDateTime(e.ChangeValue.ToString()))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "日付を正確に入力してください。" : "일자를 정확히 입력하십시오.";
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다                        
                        }

                        if (int.Parse(e.ChangeValue.ToString().Replace("/", "")) < int.Parse(this.mNaewon_date.Replace("/", "")))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "希望日は今日の日付より小さく指定できません。(" + this.mNaewon_date + "～)" : "검사희망일은 오늘날짜보다 작게 지정할수 없습니다.";
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다                        
                        }

                        // 희망일자 입력시 당임검사, 결과 여부 푼다
                        if (grd.CellInfos.Contains("dangil_gumsa_order_yn")) grd.SetItemValue(e.RowNumber, "dangil_gumsa_order_yn", "N");
                        if (grd.CellInfos.Contains("dangil_gumsa_result_yn")) grd.SetItemValue(e.RowNumber, "dangil_gumsa_result_yn", "N");

                        //変更されたROWがすでに選択された状態であればdloSelectOCS1003に変更する前の「数量」が入っているため、変更された「数量」を探して変更されたデータを変更しなければならない。
                        if (grd.GetItemString(e.RowNumber, "select") == "Y")
                        {
                            for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                            {
                                if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(e.RowNumber, "pkocs1003"))
                                    this.dloSelectOCS1003.SetItemValue(kk, e.ColName, e.ChangeValue.ToString());
                            }
                        }
                    }
                    #endregion


                    break;
            }
        }

        private void grdOUT1001_MouseDown(object sender, MouseEventArgs e)
        {
            //delete by jc [リストで選択機能を外してほしいって事で注釈処理] 2012/03/22
            int rowIndex;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowIndex = grdOUT1001.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOUT1001.CurrentColName != "select")
                {
                    return;
                }
                if (grdOUT1001.GetItemString(rowIndex, "select") == "N")
                {
                    grdOUT1001.SetItemValue(rowIndex, "select", "Y");
                    SelectionBackColorChange(grdOUT1001, rowIndex, "Y");
                    this.grdSelectAll(this.grdOCS1003);
                }
                else
                {
                    grdOUT1001.SetItemValue(rowIndex, "select", "N");
                    SelectionBackColorChange(grdOUT1001, rowIndex, "N");
                    this.grdDeleteAll(this.grdOCS1003);
                }
                if (grdOUT1001.CurrentColNumber == 0)
                {
                    if (grdOUT1001.GetItemString(rowIndex, "select") == "N")
                    {
                        grdOUT1001.SetItemValue(rowIndex, "select", "Y");
                        //외래오더에서 호출이고 입원do오다 선택시
                        //원외처리
                        if (this.mIOgubun == "O" && this.rbtIn.Checked)
                        {
                            if (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "C" ||
                                this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "D")
                            {
                                SetWonyoiOrderYN(rowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdOUT1001.SetItemValue(rowIndex, "select", "N");
                    }
                    SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);
                }
            }
        }

        #region unused code
        //처방행삭제
        private void PopUpMenuPfeResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand menu = sender as IHIS.X.Magic.Menus.MenuCommand;

            string targetUrl = "";
            string serverIP = "192.168.150.114";

//            string cmdText = @"SELECT CODE_NAME
//                                 FROM OCS0132
//                                WHERE CODE_TYPE = 'SERVER_IP'
//                                  AND CODE = 'ENDO'";

//            object retVal = Service.ExecuteScalar(cmdText);

//            if (!TypeCheck.IsNull(retVal))
//            {
//                serverIP = retVal.ToString();
//            }

            // Cloud updated code START
            OCS0132GetServerIpResult res = CacheService.Instance.Get<OCS0132GetServerIpArgs, OCS0132GetServerIpResult>(new OCS0132GetServerIpArgs(), delegate(OCS0132GetServerIpResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success;
                });

            if (res.ExecutionStatus == ExecutionStatus.Success && !TypeCheck.IsNull(res.ServerIp))
            {
                serverIP = res.ServerIp;
            }
            // Cloud updated code END

            switch (menu.Tag.ToString())
            {
                case "3":     // 이미지 결과 조회

                    try
                    {
                        targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.pbxSearch.BunHo.ToString() + "&TYPE=1";//&KEY=12345";

                        System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("other msg : " + other.Message);
                    }

                    break;

                case "4":

                    try
                    {
                        targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.pbxSearch.BunHo.ToString() + "&TYPE=2";//&KEY=12345";

                        System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("other msg : " + other.Message);
                    }


                    break;   // 레포트 결과 조회

                case "5":    // 심전도 결과 조회

                    if (this.pbxSearch.BunHo.ToString() != "")
                    {
                        EkgCallHelper.CallViewer(this.pbxSearch.BunHo.ToString());
                    }

                    break;
            }
        }
        #endregion

        private void tabOrderGubun_SelectionChanged(object sender, EventArgs e)
        {
            this.grdOUT1001.QueryLayout(false);
            /// <summary>
            /// tab 변경시 해당 처방조회
            /// </summary>
            /// 1:全体
            /// 2:薬
            /// 3:注射
            /// 4:検査
            /// 5:その他
            /// G 
            /// H
            /// I
            /// J
            /// K
            /// L
            /// M
            /// N
            /// O
            /// Z
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (tabOrderGubun.SelectedTab == null) return;

            foreach (IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
            {
                if (tabOrderGubun.SelectedTab == page)
                    page.ImageIndex = 1;
                else
                    page.ImageIndex = 0;
            }

            for (int i = 0; i < grdOUT1001.RowCount; i++)
            {
                grdOUT1001.SetItemValue(i, "select", "N");
                SelectionBackColorChange(grdOUT1001, i, "N");
                this.grdDeleteAll(this.grdOCS1003);
            }

            // grdOCS1003.QueryLayout(true);

            //검사인 경우에는 실시일 기준으로 조회한다.
            if (tabOrderGubun.SelectedTab.Tag.ToString() == "4")
            {
                string filter = @" order_gubun_bas <> 'A' 
                               and order_gubun_bas <> 'B'
                               and order_gubun_bas <> 'C'
                               and order_gubun_bas <> 'D'
                               and order_gubun_bas <> 'E'
                               and order_gubun_bas <> 'F'
                                 ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "3")
            {
                string filter = @" order_gubun_bas = 'F' 
                                or order_gubun_bas = 'E'
                                or order_gubun_bas = 'N'
                                or order_gubun_bas = 'O'";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "2")
            {
                string filter = " order_gubun_bas = 'A' or order_gubun_bas = 'B' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "1")
            {
                string filter = " order_gubun_bas = 'C' or order_gubun_bas = 'D' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else
            {
                this.grdOCS1003.SetFilter("");
            }

            //else if (tabOrderGubun.SelectedTab.Tag.ToString() == "%")
            //{
            //    string filter= @" order_gubun_bas <> '999' ";
            //    this.grdOCS1003.SetFilter(filter);
            //}
            //else
            //{
            //    grdOCS1003.QueryLayout(true);
            //}
            tabOrderGubunChanged();
            this.SetInitialOrderGridCheckImage();
            this.childSetImage();
        }

        private void grdOCS1003_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //内服薬、外用薬を除外して他のオーダは日数を変えることができなくする。
            //if (!(e.DataRow["order_gubun_bas"].ToString() == "C" || e.DataRow["order_gubun_bas"].ToString() == "D"))
            if (e.ColName == "nalsu" && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C" && TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() != "N")
                e.Protect = true;
            else if (e.ColName == "nalsu" && e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C" && TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() != "N")
                e.Protect = true;
            else if (e.ColName == "nalsu" && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C")
                e.Protect = true;

            if (e.ColName == "suryang" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) != "D" && TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() != "Y"))
                e.Protect = true;

            if (e.ColName == "dv" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C" || TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() != "Y"))
                e.Protect = true;

            //if (e.ColName == "hope_date" && (  e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C" // 内服
            //                                && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "D" // 外用
            //                                && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "E" // 画像検査
            //                                && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "F" // 検体検査
            //                                && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "N" // 生理検査
            //                                )
            //   )
            //    e.Protect = true;

            //if (  
            //     (
            //          (this.mIOgubun == "I" && grdOCS1003.GetItemString(e.RowNumber, "io_yn") == "O")
            //       || (this.mIOgubun == "O" && grdOCS1003.GetItemString(e.RowNumber, "io_yn") == "I")
            //     )
            //     && this.mInput_gubun != "D7"
            //    )
            //    e.Protect = true;


        }

        private void grdSangInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            grdSangInfo.SetBindVarValue("f_bunho", this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "bunho"));
            grdSangInfo.SetBindVarValue("f_naewon_date", this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "naewon_date"));
            grdSangInfo.SetBindVarValue("f_gwa", this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "gwa"));
            grdSangInfo.SetBindVarValue("f_doctor", this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "doctor"));
            grdSangInfo.SetBindVarValue("f_naewon_type", this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "naewon_type"));
            grdSangInfo.SetBindVarValue("f_jubsu_no", this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "jubsu_no"));
            //grdSangInfo.SetBindVarValue("f_io_gubun", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "io_gubun"));
            grdSangInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (rbtOut.Checked)
            {
                grdSangInfo.SetBindVarValue("f_io_gubun", "O");
            }
            else
            {
                grdSangInfo.SetBindVarValue("f_io_gubun", "I");
            }
        }

        private void pbxSearch_PatientSelected(object sender, EventArgs e)
        {
            this.grdSangInfo.Reset();
        }

        private void cbxGeneric_YN_CheckedChanged(object sender, EventArgs e)
        {
            //this.grdOCS1003.QueryLayout(true);
            this.tabOrderGubunChanged();
            childSetImage();
            //this.btnList.PerformClick(FunctionType.Query);
            //this.grdOUT1001.SelectRow(this.grdOUT1001.CurrentRowNumber);
        }

        private void dpkNaewon_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
                btnList.PerformClick(FunctionType.Close);
        }

        private void pbxSearch_Validated(object sender, EventArgs e)
        {
            this.grdOUT1001.QueryLayout(false);
            this.dloSelectOCS1003.Reset();
        }

        private void btnDatePlusMinus_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            if (ctl.Tag.ToString() == "-")
                this.dpkSetHopeDate.SetDataValue(DateTime.Parse(this.dpkSetHopeDate.GetDataValue()).AddDays(-1));
            else if (ctl.Tag.ToString() == "+")
                this.dpkSetHopeDate.SetDataValue(DateTime.Parse(this.dpkSetHopeDate.GetDataValue()).AddDays(+1));

            this.dpkSetHopeDate.AcceptData();
        }

        private void btnHope_date_Click(object sender, EventArgs e)
        {
            string order_gubun = "";
            XEditGrid grd = this.grdOCS1003;

            if (!IsSelectedOrder())
                return;

            for (int i = 0; i < grd.RowCount; i++)
            {
                order_gubun = this.grdOCS1003.GetItemString(i, "order_gubun").Substring(1, 1);
                // C 内服 D 外用 E 画像検査 F 検体検査 N 生理検査
                //if (this.mCanDoArrList.Contains(grd.GetItemString(i, "input_tab")))
                //{
                //変更されたROWがすでに選択された状態であればdloSelectOCS1003に変更する
                if (grd.GetItemString(i, "select") == "Y")
                {
                    grd.SetItemValue(i, "hope_date", this.dpkSetHopeDate.GetDataValue());
                    grd.SetItemValue(i, "dangil_gumsa_order_yn", "N");
                    grd.SetItemValue(i, "dangil_gumsa_result_yn", "N");

                    for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                    {
                        if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(i, "pkocs1003"))
                            this.dloSelectOCS1003.SetItemValue(kk, "hope_date", this.dpkSetHopeDate.GetDataValue());
                    }
                }
                //}
            }


        }

        private void cboKijunGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.grdOUT1001.QueryLayout(false);
        }

        private void grdOUT1001_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["is_order_yn"].ToString() == "Y")
            {
                e.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void btnNalsu_Click(object sender, EventArgs e)
        {
            XEditGrid grd = this.grdOCS1003;

            if (!IsSelectedOrder())
                return;

            for (int i = 0; i < grd.DisplayRowCount; i++)
            {
                if (grd.GetItemString(i, "order_gubun").Substring(1, 1) == "C"
                    && grd.GetItemString(i, "donbog_yn") != "Y"
                    && grd.GetItemString(i, "select") == "Y"
                   )
                {
                    grd.SetItemValue(i, "nalsu", this.cboNalsu.GetDataValue());

                    for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                    {
                        if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(i, "pkocs1003"))
                            this.dloSelectOCS1003.SetItemValue(kk, "nalsu", this.cboNalsu.GetDataValue());
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbxUnderArrow.Visible == true)
            {
                //System.Threading.Thread.Sleep(5000);
                pbxUnderArrow.Visible = false;
                timer_icon.Stop();
            }
        }

        private void dpkSetHopeDate_TextChanged(object sender, EventArgs e)
        {
            if (TypeCheck.IsDateTime(this.dpkSetHopeDate.GetDataValue())
                && TypeCheck.IsDateTime(this.dpkNaewon_date.GetDataValue()))
            {
                DateTime dt_hope_date = DateTime.Parse(this.dpkSetHopeDate.GetDataValue());
                DateTime dt_naewon_date = DateTime.Parse(this.mNaewon_date);

                if (dt_hope_date < dt_naewon_date)
                {
                    XMessageBox.Show(Resources.MessageText11 + this.mNaewon_date + "～)", Resources.MessageText6_JP);
                    this.dpkSetHopeDate.SetDataValue(this.mNaewon_date);
                    return;
                }
            }
        }

        #endregion

        #region Methods(private)

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void initScreen()
        {
            // Load data into combobox cells
            //GetComboListItem();

            // select
            this.grdOCS1003.AutoSizeColumn(1, 0);
            this.grdOUT1001.AutoSizeColumn(1, 0);
            // hope_date
            this.grdOCS1003.AutoSizeColumn(8, 0);

            this.cboKijunGubun.SelectedIndex = 0;
            // 여기서 처리 하세요
            //this.mOrderBiz.SetNumCombo(this.grdOCS1003, "suryang", true);
            //this.mOrderBiz.SetNumCombo(this.grdOCS1003, "nalsu", false);
            //this.mOrderBiz.SetNumCombo(this.grdOCS1003, "dv", false);

            //if (this.mIOgubun == "O" || ((XScreen)Opener).ScreenID != "OCS2003P01")
            if (this.mIOgubun == "O")
            {
                //this.btnProcessD0.Visible = true;
                this.btnProcessD0.Text = Resources.btnProcessD0;
                this.btnProcessD4.Visible = false;
                this.btnProcessD7.Visible = false;
                this.cboKijunGubun.Visible = false;
            }
            else
                this.cboKijunGubun.SelectedIndex = 1;

            this.grdOUT1001.AutoSizeColumn(5, 0);
            this.grdOUT1001.AutoSizeColumn(6, 0);
            this.grdOUT1001.AutoSizeColumn(7, 0);
        }

        private void PostLoad()
        {
            if (TypeCheck.IsNull(mBunho))
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null)
                {
                    this.pbxSearch.SetPatientID(patientInfo.BunHo);
                }
            }
            else
                this.pbxSearch.SetPatientID(mBunho);

            //comboBox생성
            CreateCombo();

            //DataLayout 생성
            CreateLayout();

            // IO_Gubun 에 대한 라디오 박스 처리
            if (this.mIOgubun == "O")
            {
                this.rbtOut.Checked = true;
            }
            else
            {
                this.rbtIn.Checked = true;
            }

            //check layout
            //FormWindowState가 Normal로 돌아가면서 문제가 생겨서 check Layout으로 check
            if (mAuto_close)
            {
                IHIS.Framework.MultiLayout dloCheckLayout;
                dloCheckLayout = this.grdOUT1001.CloneToLayout();
                dloCheckLayout.QuerySQL = grdOUT1001.QuerySQL;
                // 2015.03.18 AnhNV ADD Start
                dloCheckLayout.ExecuteQuery = GetGrdOUT1001;
                // 2015.03.18 AnhNV ADD End
                dloCheckLayout.SetBindVarValue("f_bunho", mBunho);
                dloCheckLayout.SetBindVarValue("f_naewon_date", mNaewon_date);
                dloCheckLayout.SetBindVarValue("f_gwa", mGwa);
                dloCheckLayout.SetBindVarValue("f_input_gubun", mInput_gubun);
                dloCheckLayout.SetBindVarValue("f_tel_yn", mTel_yn);
                dloCheckLayout.SetBindVarValue("f_hosp_code", mHospCode);

                if (!dloCheckLayout.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

                if (dloCheckLayout.RowCount < 1 && mAuto_close)
                {
                    this.Close();

                    dloSelectOCS1003.Dispose();
                    return;
                }
            }

            if (mAuto_close) this.ParentForm.Location = new Point(patientFormX, ParentForm.Location.Y);

            dpkNaewon_date.SetDataValue(mNaewon_date);


            // 전체과 디폴트 선택 
            this.chkAll.Checked = true;

            if (this.mIOgubun == "O")
                this.gbxHopeDate.Enabled = false;

            // 날수 콤보
            //this.mOrderBiz.SetNumCombo(this.cboNalsu, "nalsu", false);
            //this.cboNalsu.MaxDropDownItems = this.cboNalsu.Items.Count;

            if (this.cboNalsu.Items.Count > 0)
                this.cboNalsu.SelectedValue = "7";

            this.Refresh();

            cboKijunGubun.SelectedIndexChanged += new EventHandler(cboKijunGubun_SelectedIndexChanged);
            rbtOut.CheckedChanged += new EventHandler(rbtOut_CheckedChanged);
            chkAll.CheckedChanged += new EventHandler(chkAll_CheckedChanged);

            //set default checkbox
            chkAll.Checked = true;
            rbtOut.Checked = true;
            rbtIn.Checked = false;
            CheckAll();
        }



        /// <summary>
        /// DataLayout LayoutItems생성
        /// </summary>
        private void CreateLayout()
        {
            //OCS1003
            foreach (XGridCell cell in this.grdOCS1003.CellInfos)
            {
                dloSelectOCS1003.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS1003.InitializeLayoutTable();
        }

        /// <summary>
        /// CreateCombo
        /// </summary>
        private void CreateCombo()
        {
            #region comments
            //            IHIS.Framework.MultiLayout layoutCombo;
            //            layoutCombo = new MultiLayout();

            //            //주사
            //            layoutCombo.Reset();
            //            layoutCombo.LayoutItems.Clear();
            //            layoutCombo.LayoutItems.Add("code", DataType.String);
            //            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            //            layoutCombo.InitializeLayoutTable();

            //            layoutCombo.QuerySQL = @"SELECT A.CODE, A.CODE_NAME
            //                                       FROM OCS0132 A
            //                                      WHERE A.CODE_TYPE = 'JUSA'
            //                                        AND A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
            //                                      ORDER BY A.CODE";
            //            layoutCombo.QueryLayout(false);

            //            if (Service.ErrCode == 0 && layoutCombo.LayoutTable != null)
            //            {
            //                grdOCS1003.SetComboItems("jusa", layoutCombo.LayoutTable, "code_name", "code");
            //            }

            //            // Combo 세팅
            //            DataTable dtTemp = null;

            //            // 급여구분
            //            dtTemp = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
            //            this.grdOCS1003.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            //            // 이동촬영여부
            //            dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
            //            this.grdOCS1003.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            //            // 주사스피드구분
            //            dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
            //            this.grdOCS1003.SetListItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);
            #endregion

            // Cloud updated code
            ComboResult jusaRes = CacheService.Instance.Get<ComboJusaArgs, ComboResult>(new ComboJusaArgs());
            if (null != jusaRes)
            {
                this.grdOCS1003.SetComboItems("jusa", Utility.ConvertToDataTable(jusaRes.ComboItem), "code_name", "code");
            }

            ComboResult payRes = CacheService.Instance.Get<ComboPayArgs, ComboResult>(new ComboPayArgs());
            if (null != payRes)
            {
                this.grdOCS1003.SetComboItems("pay", Utility.ConvertToDataTable(payRes.ComboItem), "code_name", "code", XComboSetType.NoAppend);
            }

            ComboResult pyRes = CacheService.Instance.Get<ComboPortableYnArgs, ComboResult>(new ComboPortableYnArgs());
            if (null != pyRes)
            {
                this.grdOCS1003.SetComboItems("portable_yn", Utility.ConvertToDataTable(pyRes.ComboItem), "code_name", "code", XComboSetType.NoAppend);
            }

            // 주사스피드구분
            DataTable dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
            this.grdOCS1003.SetListItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);
        }

        string GetMaxGroupSer(MultiLayout layout)
        {
            int max = int.Parse(layout.GetItemString(0, "group_ser"));

            for (int i = 0; i < layout.RowCount; i++)
            {
                for (int j = i; j < layout.RowCount; j++)
                {
                    if (max < int.Parse(layout.GetItemString(j, "group_ser")))
                    {
                        max = int.Parse(layout.GetItemString(j, "group_ser"));
                    }
                }
            }
            max = max + 1;
            return max.ToString();
        }

        private void CreateReturnLayout(string aInputGubun)
        {
            this.AcceptData();

            if (this.mIOgubun == "O" || ((XScreen)Opener).ScreenID != "OCS2003P01")
                aInputGubun = this.mInput_gubun;

            string pk_order = "";
            int base_Nalsu = 0;
            DataRow row;
            //DataRow row2;
            //DataRow row3;

            for (int i = 0; i < dloSelectOCS1003.RowCount; i++)
            {
                row = dloSelectOCS1003.LayoutTable.Rows[i];

                //order 단위가 현재 존재하지 않는 경우
                if (row["ord_danui_check"].ToString() == "Y")
                {
                    //order 단위가 없는 경우에는 SKip
                    if (row["ord_danui"].ToString().Trim() == "")
                    {
                        dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                        i--;
                        continue;
                    }
                    else
                    {
                        if (!CheckOrd_danui(row["hangmog_code"].ToString(), row["ord_danui"].ToString()))
                        {
                            dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                            i--;
                            continue;
                        }
                    }
                }
                // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
                pk_order = row["pk_order"].ToString();
                base_Nalsu = int.Parse(row["nalsu"].ToString());


                //order_gubun
                //header '0':정규
                row["order_gubun"] = "0" + row["order_gubun"].ToString().Substring(1, 1);

                //내복약,외용약,주사재택은 DO오더의 일수를 그대로 가져 온다.
                if (row["order_gubun_bas"].ToString() == "C" || row["order_gubun_bas"].ToString() == "D" ||
                    ((row["order_gubun_bas"].ToString() == "A" || row["order_gubun_bas"].ToString() == "B") && row["home_care_yn"].ToString() == "Y"))
                {
                    row["nalsu"] = base_Nalsu;
                }

                //無効フラグはDoで持ってこないように
                row["muhyo"] = "N";
                //
                row["nday_yn"] = "N";
                row["emergency"] = "N";

            }

            if (dloSelectOCS1003.LayoutTable.Rows.Count < 1)
                this.Close();

            if (chkIsNewGroup.Checked)
                mIsNewGroupSer = true;
            else
                mIsNewGroupSer = false;


            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("isnewgroup", mIsNewGroupSer);
            commandParams.Add("OCS1003", dloSelectOCS1003);
            commandParams.Add("input_gubun", aInputGubun);
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }

        //날수 및 기타 기본정보변경
        private void CreateReturnLayout()
        {
            this.AcceptData();

            string pk_order = "";
            int base_Nalsu = 0;
            DataRow row;
            //DataRow row2;
            //DataRow row3;

            for (int i = 0; i < dloSelectOCS1003.RowCount; i++)
            {
                row = dloSelectOCS1003.LayoutTable.Rows[i];
                //insert by jc[同じgroup_serであれば新しいgroup_serに変える]
                //for (int j = 0; j < i; j++)
                //{
                //    row2 = dloSelectOCS1003.LayoutTable.Rows[j];
                //    if (row["group_ser"].ToString() == row2["group_ser"].ToString()
                //        //&& row["naewon_date"].ToString() != row2["naewon_date"].ToString()
                //        && row["fk_key1001"].ToString() != row2["fk_key1001"].ToString())
                //    {
                //        string MaxGroupSer = GetMaxGroupSer(dloSelectOCS1003);
                //        string str = row["group_ser"].ToString();
                //        for (int k = 0; k < dloSelectOCS1003.RowCount; k++)
                //        {
                //            row3 = dloSelectOCS1003.LayoutTable.Rows[k];
                //            if (str == row3["group_ser"].ToString()
                //          //      && row["naewon_date"].ToString() == row3["naewon_date"].ToString()
                //                && row["fk_key1001"].ToString() == row3["fk_key1001"].ToString())
                //            {
                //                dloSelectOCS1003.SetItemValue(k, "group_ser", MaxGroupSer);
                //            }
                //        }
                //    }
                //}
                //order 단위가 현재 존재하지 않는 경우
                if (row["ord_danui_check"].ToString() == "Y")
                {
                    //order 단위가 없는 경우에는 SKip
                    if (row["ord_danui"].ToString().Trim() == "")
                    {
                        dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                        i--;
                        continue;
                    }
                    else
                    {
                        if (!CheckOrd_danui(row["hangmog_code"].ToString(), row["ord_danui"].ToString()))
                        {
                            dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                            i--;
                            continue;
                        }
                    }
                }
                // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
                pk_order = row["pk_order"].ToString();
                base_Nalsu = int.Parse(row["nalsu"].ToString());


                //order_gubun
                //header '0':정규
                row["order_gubun"] = "0" + row["order_gubun"].ToString().Substring(1, 1);

                //내복약,외용약,주사재택은 DO오더의 일수를 그대로 가져 온다.
                if (row["order_gubun_bas"].ToString() == "C" || row["order_gubun_bas"].ToString() == "D" ||
                    ((row["order_gubun_bas"].ToString() == "A" || row["order_gubun_bas"].ToString() == "B") && row["home_care_yn"].ToString() == "Y"))
                {
                    row["nalsu"] = base_Nalsu;
                }
                //無効フラグはDoで持ってこないように
                row["muhyo"] = "N";
                //
                row["nday_yn"] = "N";
                row["emergency"] = "N";
            }

            if (dloSelectOCS1003.LayoutTable.Rows.Count < 1)
                this.Close();

            if (chkIsNewGroup.Checked)
                mIsNewGroupSer = true;
            else
                mIsNewGroupSer = false;


            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("isnewgroup", mIsNewGroupSer);
            commandParams.Add("OCS1003", dloSelectOCS1003);
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }

        /// <summary>
        /// 오더일자 List에 퇴원약여부 등을 표시한다.
        /// </summary>
        private void DisplayListImage(XGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    if (aGrd.GetItemValue(i, "toiwon_drg").ToString().Trim() == "Y") // 퇴원약
                    {
                        aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        aGrd[i + aGrd.HeaderHeights.Count, 0].ToolTipText = aGrd[i + aGrd.HeaderHeights.Count, 0].ToolTipText + (NetInfo.Language == LangMode.Jr ? Resources.MessageText5_JP : Resources.MessageText5_Ko);
                    }
                }
            }
            catch { }
            finally
            {

            }
        }

        private void SetWonyoiOrderYN(int rowIndex)
        {
            string inputSql = "";
            string tusuk_gwa = "";

            // Updated by Cloud: Function FN_AKU_LOAD_TUSUK_GWA is not be used!
            inputSql = " SELECT FN_AKU_LOAD_TUSUK_GWA GWA";
            inputSql += "   FROM SYS.DUAL A ";

            if (!TypeCheck.IsNull(Service.ExecuteScalar(inputSql)))
            {
                tusuk_gwa = Service.ExecuteScalar(inputSql).ToString();
            }

            //투석과이면 무조건 원내
            if (this.mGwa != tusuk_gwa)
            {
                //원외만가능
                if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "Y")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");
                //원내만가능
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "N")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");
                //기본원외
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "1")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");
                //기본원내
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "2")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");
                //그외는 원외처리
                else
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");

            }
            else
                this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");

        }

        private void SetSelectNaewon(int aRowNumber)
        {
            //int currentRow = aRowNumber;
            //bool select = false;
            //int start_row = -1;
            //int end_row = -1;

            //if (aRowNumber < 0)
            //{
            //    start_row = 0;
            //    end_row = this.grdOUT1001.RowCount;
            //}
            //else
            //{
            //    start_row = aRowNumber;
            //    end_row = aRowNumber + 1;
            //}

            //for (int i=start_row; i<end_row; i++)
            //{

            //    if (this.IsExistSelectedOrder(this.grdOUT1001.GetItemString(i, "pk_order"),
            //                                  this.grdOUT1001.GetItemString(i, "naewon_date"),
            //                                  this.grdOUT1001.GetItemString(i, "gwa"),
            //                                  this.grdOUT1001.GetItemString(i, "doctor")))
            //        select = true;
            //    else
            //        select = false;



            //    if (select)
            //    {
            //        grdOUT1001.SetItemValue(i, "select", "Y");
            //        SelectionBackColorChange(grdOUT1001, i, "Y");
            //    }
            //    else
            //    {
            //        grdOUT1001.SetItemValue(i, "select", "N");
            //        SelectionBackColorChange(grdOUT1001, i, "N");
            //    }
            //}
            //this.childSetImage();
        }

        private void SetInitialOrderGridCheckImage()
        {
            //try
            //{
            //    for (int i = 0; i < grdOCS1003.RowCount; i++)
            //    {
            //        if (this.IsExistSelectedOrder(this.grdOCS1003.GetItemString(i, "pkocs1003"),
            //                                      this.grdOCS1003.GetItemString(i, "naewon_date"),
            //                                      this.grdOCS1003.GetItemString(i, "gwa"),
            //                                      this.grdOCS1003.GetItemString(i, "doctor"),
            //                                      this.grdOCS1003.GetItemString(i, "group_ser")))
            //        {
            //            grdOCS1003.SetItemValue(i, "select", "Y");
            //            SelectionBackColorChange(grdOCS1003, i, "Y");
            //        }
            //        else
            //        {
            //            grdOCS1003.SetItemValue(i, "select", "N");
            //            SelectionBackColorChange(grdOCS1003, i, "N");

            //        }
            //    }
            //    this.childSetImage();
            //    this.setSelectedDloData();
            //}
            //catch (System.Exception e)
            //{
            //   XMessageBox.Show(e.Message);
            //}

        }

        //delete by jc [参照点がないため削除] 2012/04/10
        //private void MakeGroupTab(XEditGrid aGrid)
        //{
        //    string currentGroupSer = "";
        //    string title = "";
        //    IHIS.X.Magic.Controls.TabPage tpgGroup;

        //    this.tabGroup.SelectionChanged -= new EventHandler(tabGroup_SelectionChanged);

        //    // 탭페이지 클리어
        //    try
        //    {
        //        this.tabGroup.TabPages.Clear();
        //    }
        //    catch
        //    {
        //        this.tabGroup.Refresh();
        //    }

        //    for (int i = 0; i < aGrid.RowCount; i++)
        //    {
        //        if (currentGroupSer != aGrid.GetItemString(i, "group_ser"))
        //        {
        //            if (aGrid.GetItemString(i, "input_tab") == "01") // 약인경우는 그룹탭에 복용법을 같이 보여준다.
        //            {
        //                title = aGrid.GetItemString(i, "group_ser") + " グループ : " + aGrid.GetItemString(i, "bogyong_name");
        //            }
        //            else
        //            {
        //                title = aGrid.GetItemString(i, "group_ser") + " グループ";
        //            }

        //            tpgGroup = new IHIS.X.Magic.Controls.TabPage(title);
        //            tpgGroup.ImageList = this.ImageList;
        //            tpgGroup.ImageIndex = 0;
        //            tpgGroup.Tag = aGrid.GetItemString(i, "group_ser");

        //            this.tabGroup.TabPages.Add(tpgGroup);

        //            currentGroupSer = aGrid.GetItemString(i, "group_ser");
        //        }
        //    }

        //    this.tabGroup.SelectionChanged += new EventHandler(tabGroup_SelectionChanged);

        //    SetInitialOrderGridCheckImage();

        //    this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
        //}

        private void ClearDetailInfo()
        {
            //if (this.lblSelectOrder.Tag.ToString() == "Y")
            //{
            //    // 전체선택 해제 인경우 클리어
            //    lblSelectOrder_Click(this.lblSelectOrder, new EventArgs());
            //}

            this.btnDeleteAll.Tag = "N";
            this.btnDeleteAll.ImageIndex = 0;
            this.btnDeleteAll.Text = Resources.btnDeleteAllText;

            // 텝페이지 클리어
            try
            {
                this.tabGroup.TabPages.Clear();
            }
            catch
            {
                this.tabGroup.Refresh();
            }
        }

        private void InsertBackTable(DataRow dr)
        {
            //if (this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + dr["pkocs1003"].ToString()).Length <= 0)
            //    this.dloSelectOCS1003.LayoutTable.ImportRow(dr);

            //if (this.dloSelectOCS1003.LayoutTable.Select("order_gubun LIKE '%B' OR order_gubun LIKE '%C' OR order_gubun LIKE '%D'").Length > 0)
            //    this.mIsDrugJusa = true;
            //else
            //    this.mIsDrugJusa = false;

            //this.SetVisibleBtnProcess(this.mIsDrugJusa);

        }

        private void RemoveBackTable(DataRow dr)
        {
            //DataRow[] rows = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + dr["pkocs1003"].ToString());
            //foreach (DataRow row in rows)
            //    this.dloSelectOCS1003.LayoutTable.Rows.Remove(row);

            //if (this.dloSelectOCS1003.LayoutTable.Select("order_gubun LIKE '%B' OR order_gubun LIKE '%C' OR order_gubun LIKE '%D'").Length > 0)
            //    this.mIsDrugJusa = true;
            //else
            //    this.mIsDrugJusa = false;

            //this.SetVisibleBtnProcess(this.mIsDrugJusa);
        }

        private bool IsExistSelectedOrder(string aNaewonKey, string aOrderDate, string aGwa, string aDoctor, string aGroupSer)
        {
            //if (rbtOut.Checked == true)
            //{
            //    DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + aNaewonKey + " AND group_ser=" + aGroupSer);

            //    if (dr.Length > 0) return true;
            //}
            //else
            //{
            //    DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "' AND group_ser=" + aGroupSer);

            //    if (dr.Length > 0) return true;
            //}

            return false;
        }

        private bool IsExistSelectedOrder(string aNaewonKey, string aOrderDate, string aGwa, string aDoctor)
        {
            //if (rbtOut.Checked == true)
            //{
            //    DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey);

            //    if (dr.Length > 0) return true;
            //}
            //else
            //{
            //    DataRow[] dr = null;
            //    //DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey);

            //    if (this.cboKijunGubun.SelectedValue.ToString() == "O")
            //        dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "'");
            //    else
            //    {
            //        dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey + " AND ((ori_hope_date='" + aOrderDate + "') OR (ori_hope_date is null AND naewon_date='" + aOrderDate + "')) AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "'");

            //        //if (dr.Length == 0)
            //        //{
            //        //    dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "'");
            //        //}
            //    }

            //    if (dr.Length > 0) return true;
            //}

            return false;
        }

        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, string aGroupSer, bool select)
        private bool grdSelectAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (this.grdOCS1003.GetItemString(rowIndex, "wonnae_drg_yn") != "Y"
                    && this.mIOgubun == "I"
                    && (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "C"
                        || this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "D"
                        || this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "B"
                        )
                    )
                {
                    if (XMessageBox.Show("[ " + this.grdOCS1003.GetItemString(rowIndex, "hangmog_name") + Resources.MessageText7, Resources.MessageText6_JP, MessageBoxButtons.YesNo) == DialogResult.No)
                        continue;
                }

                if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
                {
                    if (
                           (this.mIOgubun == "I" && grdObject.GetItemString(rowIndex, "io_yn") != "O")
                        || (this.mIOgubun == "O" && grdObject.GetItemString(rowIndex, "io_yn") != "I")
                        || this.mInput_gubun == "D7"
                        )
                    {
                        //if (!this.mCanDoArrList.Contains(this.grdOCS1003.GetItemString(rowIndex, "input_tab")))
                        //    continue;

                        this.InsertBackTable(grdObject.LayoutTable.Rows[rowIndex]);
                        this.SelectionBackColorChange(grdObject, rowIndex, "Y");
                        grdObject.SetItemValue(rowIndex, "select", "Y");
                    }
                    else
                    {

                    }
                }
            }


            //선택된 Row 표시
            SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);

            return true;

        }

        private bool grdDeleteAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
                {
                    this.RemoveBackTable(grdObject.LayoutTable.Rows[rowIndex]);
                    this.SelectionBackColorChange(grdObject, rowIndex, "N");
                    grdObject.SetItemValue(rowIndex, "select", "N");
                }
            }
            //선택된 Row 표시
            SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);

            return true;
        }

        private bool SelectCurrentTab(string aGroupSer, bool IsSelect)
        {

            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                if (this.grdOCS1003.GetItemString(i, "group_ser") == aGroupSer)
                {
                    if (IsSelect)
                        this.InsertBackTable(this.grdOCS1003.LayoutTable.Rows[i]);
                    else
                        this.RemoveBackTable(this.grdOCS1003.LayoutTable.Rows[i]);
                }
            }

            return true;
        }

        private bool CheckOrd_danui(string hangmog_code, string ord_danui)
        {
            #region deleted by Cloud
            //bool chkExists = false;
            //string cmdText = string.Empty;
            //object retValu = null;
            ////実際項目コードに対してオーダ単位が合っているのか確認
            //cmdText = "SELECT FN_OCS_EXISTS_ORD_DANUI('" + hangmog_code + "', '" + ord_danui + "') "
            //        + "  FROM SYS.DUAL ";
            //retValu = Service.ExecuteScalar(cmdText);

            //if (Service.ErrCode != 0 || retValu.ToString() == "")
            //    chkExists = false;
            //else
            //    chkExists = true;

            //return chkExists;
            #endregion

            // Updated by Cloud
            bool chkExists = false;

            OCS1003Q09CheckOrdDanuiArgs args = new OCS1003Q09CheckOrdDanuiArgs();
            args.HangmogCode = hangmog_code;
            args.OrdDanui = ord_danui;
            OCS1003Q09CheckOrdDanuiResult res = CloudService.Instance.Submit<OCS1003Q09CheckOrdDanuiResult, OCS1003Q09CheckOrdDanuiArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.RetValue != "")
                {
                    chkExists = true;
                }
            }

            return chkExists;
        }

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
                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group
                            if (aGrd.GetItemValue(i, "input_gubun").ToString().Trim() == aGrd.GetItemValue(j, "input_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim() == aGrd.GetItemValue(j, "order_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim())
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
                        imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }

        private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
        {
            //XEditGrid grdObject = (XEditGrid)grid;

            //선택된 Row에대해서 색을 변경한다
            //data   Y :색을 변경, N :색을 변경 해제
            //image 설정
            //if (data == "Y")
            //{
            //    //image 변경
            //    if (grdObject.RowHeaderVisible)
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
            //    else
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
            //}
            //else
            //{
            //    //image 변경
            //    if (grdObject.RowHeaderVisible)
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
            //    else
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
            //}

            //for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            //{
            //    if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
            //    {
            //        // 돈복여부
            //        if (grdObject.GetItemString(currentRowIndex, "donbog_yn") == "Y")
            //        {
            //            grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
            //            continue;
            //        }

            //        // 불균등분할
            //        if (!TypeCheck.IsNull(grdObject.GetItemString(currentRowIndex, "dv_name")))
            //        {
            //            grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
            //            continue;
            //        }
            //    }

            //    if (data == "Y")
            //    {
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;

            //    }
            //    else
            //    {
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
            //    }
            //}
            //ntt
            //this.childSetImage();
        }

        private void SelectionBackColorChange(object grid)
        {
            //XEditGrid grdObject = (XEditGrid)grid;

            ////기존의 색으로 변경을 시킨다
            //for (int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            //{
            //    //불용은 넘어간다.
            //    if (grdObject.CellInfos.Contains("bulyong_check") && grdObject.GetItemString(rowIndex, "bulyong_check") == "Y") continue;

            //    if (grdObject.GetItemString(rowIndex, "select").ToString() == " ")
            //    {
            //        //image 변경
            //        //if (grdObject.RowHeaderVisible)
            //        //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
            //        //else
            //        //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

            //        //ColorYn Y :색을 변경, N :색을 변경 해제
            //        for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            //        {
            //            if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
            //            {
            //                // 돈복여부
            //                if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
            //                {
            //                    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
            //                    continue;
            //                }

            //                // 불균등분할
            //                if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
            //                {
            //                    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
            //                    continue;
            //                }
            //            }

            //            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
            //            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
            //        }
            //    }
            //    else
            //    {
            //        //image 변경
            //        //if (grdObject.RowHeaderVisible)
            //        //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
            //        //else
            //        //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

            //        for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            //        {
            //            if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
            //            {
            //                // 돈복여부
            //                if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
            //                {
            //                    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
            //                    continue;
            //                }

            //                // 불균등분할
            //                if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
            //                {
            //                    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
            //                    continue;
            //                }
            //            }

            //            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
            //            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
            //        }
            //    }
            //}

            //if (grdObject.Name == "grdOCS1003") DiaplayMixGroup(grdObject);

            ////ntt
            //this.childSetImage();
        }

        //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
        public void rbtEventCreate()
        {
            if (this.rbtOut.Checked)
                this.rbtOut.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            else
                this.rbtIn.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
        }

        #region Unused code
        /*
        #region Order_gubun Tab 변경
        /// <summary>
        /// tab 변경시 해당 처방조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabOrderGubun1_SelectionChanged(object sender, System.EventArgs e)
        {
            //if (tabOrderGubun.SelectedTab == null) return;

            //현재선택된 row trans
            //OCS1003
            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                if (grdOCS1003.GetItemString(i, "select") == " ")
                    dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
            }



            foreach (XGridCell cell in grdOCS1003.CellInfos)
            {
                if (cell.IsVisible)
                {
                    if (mInput_tab == "%" || this.mInputControl.IsVisibleColumn(mInput_tab, cell.CellName))
                    {
                        grdOCS1003.AutoSizeColumn(cell.Col, cell.CellWidth);
                    }
                    else
                    {
                        if (cell.CellName == "child_gubun")
                            grdOCS1003.AutoSizeColumn(cell.Col, cell.CellWidth);
                        else
                            grdOCS1003.AutoSizeColumn(cell.Col, 0);
                    }
                }
            }

            //검사인 경우에는 실시일 기준으로 조회한다.
            //検査の場合は実施日基準で照会する。
            //if (tabOrderGubun.SelectedTab.Tag.ToString() == "4" || tabOrderGubun.SelectedTab.Tag.ToString() == "5")
            if(mInput_tab.Equals("04") || mInput_tab.Equals("05") || mInput_tab.Equals("06"))
            {
                grdOUT1001[0, grdOUT1001.CellInfos["naewon_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "日付" : "일자";
                this.grdOUT1001.AutoSizeColumn(6, 0);
                this.grdOUT1001.AutoSizeColumn(7, 0);
                this.grdOCS1003.AutoSizeColumn(3, 80);

                #region [[  grdOUT1001 & grdOCS1001 QuerySQL Setting  ]]
                this.grdOUT1001.QuerySQL = @"SELECT DISTINCT    -- 4
                                                   NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) NAEWON_DATE,
                                                   A.GWA                             GWA,
                                                   FN_BAS_LOAD_GWA_NAME( A.GWA, A.ORDER_DATE)
                                                                                     GWA_NAME,
                                                   FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE) DOCTOR_NAME,
                                                   0                                 NALSU,
                                                   A.BUNHO                           BUNHO,
                                                   A.DOCTOR                          DOCTOR,
                                                   ''                                GUBUN_NAME ,
                                                   ''                                CHOJAE_NAME,
                                                   '0'                               NAEWON_TYPE,
                                                   0                                 JUBSU_NO   ,
                                                   A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR
                                                                                     PK_ORDER,
                                                   TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
                                                   :f_tel_yn                         TEL_YN,
                                                   'N'                               TOIWON_DRG,
                                                   :f_input_tab                      INPUT_TAB,
                                                   :f_io_gubun                       IO_GUBUN
                                              FROM OCS1003 A
                                             WHERE :f_io_gubun    = 'O'
                                               AND A.HOSP_CODE    = :f_hosp_code
                                               AND A.BUNHO        = :f_bunho
                                               AND A.ORDER_DATE   < :f_naewon_date
                                               AND A.GWA          LIKE :f_gwa
                                               AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
                                                    ( :f_input_gubun = 'NR'           ) OR
                                                    ( :f_input_gubun = 'D%'           ))
                                               AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
                                               AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
                                               AND NVL(A.DC_YN,'N')        = 'N'
                                               AND A.NALSU                 >= 0
                                            --   AND A.INPUT_TAB            = :f_input_tab
                                            --   AND (( :f_input_tab = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'       ) OR
                                            --        ( :f_input_tab = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'       ))
                                                       
                                            UNION ALL
                                            SELECT DISTINCT
                                                   NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                                                                                     NAEWON_DATE,
                                                   A.INPUT_GWA                       GWA        ,
                                                   FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE)
                                                                                     GWA_NAME,
                                                   FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE)
                                                                                     DOCTOR_NAME,
                                                   0                                 NALSU,
                                                   A.BUNHO                           BUNHO      ,
                                                   A.INPUT_DOCTOR                    DOCTOR     ,
                                                   ' '                               GUBUN_NAME ,
                                                   ' '                               CHOJAE_NAME,
                                                   '0'                               NAEWON_TYPE,
                                                   A.FKINP1001                       JUBSU_NO   ,
                                                   A.BUNHO||RTRIM(TO_CHAR(A.FKINP1001))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||RPAD(A.INPUT_GWA, 10)||RPAD(A.INPUT_DOCTOR, 10)
                                                                                     PK_ORDER   ,
                                                   TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
                                                   :f_tel_yn                         TEL_YN,
                                                   'N'                               TOIWON_DRG,
                                                   :f_input_tab                      INPUT_TAB,
                                                   :f_io_gubun                       IO_GUBUN
                                              FROM OCS2003 A
                                             WHERE :f_io_gubun    = 'I'
                                               AND A.HOSP_CODE    = :f_hosp_code        
                                               AND A.BUNHO        = :f_bunho
                                               AND A.ORDER_DATE  <= :f_naewon_date
                                               AND A.INPUT_GWA    LIKE :f_gwa
                                               AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
                                                    ( :f_input_gubun = 'NR'           ) OR
                                                    ( :f_input_gubun = 'D%'           ))
                                               AND A.IO_GUBUN             IS NULL
                                               AND A.NALSU               >= 0
                                               AND NVL(A.DISPLAY_YN,'Y')  = 'Y'
                                               AND NVL(A.DC_YN,'N')       = 'N'
                                            --   AND A.INPUT_TAB            = :f_input_tab
                                            --   AND (( :f_input_tab = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'       ) OR
                                            --        ( :f_input_tab = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'       ))
                                               AND A.FKINP1001            = ( SELECT MAX(C.PKINP1001)
                                                                                FROM VW_OCS_INP1001_02 C
                                                                               WHERE C.BUNHO       = :f_bunho
                                                                                 AND C.IPWON_DATE <= :f_naewon_date
                                                                                 AND C.HOSP_CODE   = :f_hosp_code   )
                                             ORDER BY 12 DESC";

                this.grdOCS1003.QuerySQL =    @"SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
                                                       A.GROUP_SER                                                GROUP_SER               ,
                                                       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
                                                       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
                                                       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                                                              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
                                                              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
                                                       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
                                                       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
                                                       A.SURYANG                                                  SURYANG                 ,
                                                       A.ORD_DANUI                                                ORD_DANUI               ,
                                                       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
                                                       A.DV_TIME                                                  DV_TIME                 ,
                                                       A.DV                                                       DV                      ,
                                                       A.NALSU                                                    NALSU                   ,
                                                       A.JUSA                                                     JUSA                    ,
                                                       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
                                                       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
                                                       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                                                                  BOGYONG_NAME            ,
                                                       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
                                                       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
                                                       A.PHARMACY                                                 PHARMACY                ,
                                                       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
                                                       A.POWDER_YN                                                POWDER_YN               ,
                                                       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
                                                       NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,
                                                       NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,
                                                       NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
                                                       A.PAY                                                      PAY                     ,
                                                       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
                                                       A.MUHYO                                                    MUHYO                   ,
                                                       A.PORTABLE_YN                                              PORTABLE_YN             ,
                                                       A.OCS_FLAG                                                 OCS_FLAG                ,
                                                       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
                                                       A.INPUT_TAB                                                INPUT_TAB               ,
                                                       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
                                                       A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,
                                                       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
                                                       A.JUNDAL_PART                                              JUNDAL_PART             ,
                                                       A.MOVE_PART                                                MOVE_PART               ,
                                                       A.BUNHO                                                    BUNHO                   ,
                                                       A.ORDER_DATE                                               NAEWON_DATE             ,
                                                       A.GWA                                                      GWA                     ,
                                                       A.DOCTOR                                                   DOCTOR                  ,
                                                       A.NAEWON_TYPE                                              NAEWON_TYPE             ,
                                                       A.FKOUT1001                                                PK_ORDER                ,
                                                       A.SEQ                                                      SEQ                     ,
                                                       A.PKOCS1003                                                PKOCS1003               ,
                                                       A.SUB_SUSUL                                                SUB_SUSUL               ,
                                                       A.SUTAK_YN                                                 SUTAK_YN                ,
                                                       A.AMT                                                      AMT                     ,
                                                       A.DV_1                                                     DV_1                    ,
                                                       A.DV_2                                                     DV_2                    ,
                                                       A.DV_3                                                     DV_3                    ,
                                                       A.DV_4                                                     DV_4                    ,
                                                       A.HOPE_DATE                                                HOPE_DATE               ,
                                                       A.ORDER_REMARK                                             ORDER_REMARK            ,
                                                       A.MIX_GROUP                                                MIX_GROUP               ,
                                                       A.HOME_CARE_YN                                             HOME_CARE_YN            ,
                                                       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
                                                       A.GONGBI_CODE                                              GONGBI_CODE             ,
                                                       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
                                                       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                                                                  DONBOK_YN               ,
                                                       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)
                                                                                                                  DV_NAME                 ,
                                                       B.SLIP_CODE                                                SLIP_CODE               ,
                                                       B.GROUP_YN                                                 GROUP_YN                ,
                                                       B.SG_CODE                                                  SG_CODE                 ,
                                                       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
                                                       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
                                                       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
                                                       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
                                                       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
                                                       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
                                                       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
                                                       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
                                                       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
                                                       A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
                                                       A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
                                                       ( CASE WHEN FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE) <> 'Y'
                                                              THEN 'N'
                                                              WHEN FN_OCS_BULYONG_CHECK_OUT   (B.HANGMOG_CODE, SYSDATE) = 'Y'
                                                               AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, TRUNC(SYSDATE)) <> A.HANGMOG_CODE
                                                              THEN 'Z'
                                                              ELSE 'Y' END )                                      BULYONG_CHECK           ,
                                                       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
                                                       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
                                                       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
                                                       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
                                                       A.TEL_YN                                                   TEL_YN                  ,
                                                       E.BUN_CODE                                                 BUN_CODE                ,
                                                       E.SG_GESAN                                                 SG_GESAN                ,
                                                       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
                                                       ''                                                         DRG_BUNRYU              ,
                                                       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('O',A.PKOCS1003),'3')      CHILD_GUBUN,
                                                       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
                                                       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,      
                                                       A.PKOCS1003                                               PARENTS_KEY,
                                                       A.BOM_SOURCE_KEY                                          CHILD_KEY,
                                                       LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||
                                                       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B')
                                                               AND A.HOPE_DATE IS NOT NULL
                                                              THEN TO_CHAR(A.HOPE_DATE, 'YYYYMMDD')
                                                              ELSE '00000000' END )||
                                                       LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                                                                                    CONT_KEY
                                                  FROM OCS0140 G,
                                                       OCS0132 F,
                                                       BAS0310 E,
                                                       OCS0116 D,
                                                       OCS0132 C,
                                                       OCS0103 B,
                                                       OCS1003 A
                                                 WHERE A.HOSP_CODE        = '" + EnvironInfo.HospCode + @"'
                                                   AND A.BUNHO            = :f_bunho
                                                   AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = :f_naewon_date
                                                   AND A.GWA              = :f_gwa
                                                   AND A.DOCTOR           = :f_doctor
                                                   --各部門関係なく照会できるようにするためinput_tabの制限をなくす。
                                                   --AND A.INPUT_TAB        = :f_input_tab
                                                   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
                                                        ( :f_input_gubun = 'NR'           ) OR
                                                        ( :f_input_gubun = 'D%'           ))
                                                   AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
                                                   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
                                                   AND NVL(A.DC_YN,'N')   = 'N'
                                                   AND A.NALSU           >= 0
                                                   AND B.HOSP_CODE        = A.HOSP_CODE
                                                   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
                                                   AND C.HOSP_CODE    (+) = A.HOSP_CODE
                                                   AND C.CODE         (+) = A.ORDER_GUBUN
                                                   AND C.CODE_TYPE    (+) = 'ORDER_GUBUN'
                                                   AND D.HOSP_CODE    (+) = A.HOSP_CODE
                                                   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
                                                   AND E.HOSP_CODE    (+) = B.HOSP_CODE
                                                   AND E.SG_CODE      (+) = B.SG_CODE
                                                   AND F.HOSP_CODE    (+) = A.HOSP_CODE
                                                   AND F.CODE         (+) = A.INPUT_GUBUN
                                                   AND F.CODE_TYPE    (+) = 'INPUT_GUBUN'
                                                   AND G.HOSP_CODE        = A.HOSP_CODE
                                                   AND G.ORDER_GUBUN      = A.ORDER_GUBUN
                                                   AND G.INPUT_TAB        = A.INPUT_TAB
                                                --   AND (( :f_input_tab = '%'           ) OR
                                                --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
                                                --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
                                                --        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
                                                --        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
                                                --        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
                                                --        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
                                                --        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
                                                --        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
                                                --        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
                                                UNION ALL
                                                SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
                                                       A.GROUP_SER                                                GROUP_SER               ,
                                                       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
                                                       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
                                                       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                                                              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
                                                              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
                                                       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
                                                       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
                                                       A.SURYANG                                                  SURYANG                 ,
                                                       A.ORD_DANUI                                                ORD_DANUI               ,
                                                       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
                                                       A.DV_TIME                                                  DV_TIME                 ,
                                                       A.DV                                                       DV                      ,
                                                       A.NALSU                                                    NALSU                   ,
                                                       A.JUSA                                                     JUSA                    ,
                                                       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
                                                       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
                                                       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                                                                  BOGYONG_NAME            ,
                                                       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
                                                       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
                                                       A.PHARMACY                                                 PHARMACY                ,
                                                       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
                                                       A.POWDER_YN                                                POWDER_YN               ,
                                                       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
                                                       'N'                                                        DANGIL_GUMSA_ORDER_YN   ,
                                                       'N'                                                        DANGIL_GUMSA_RESULT_YN  ,
                                                       NVL(A.EMERGENCY  , 'N')                                    EMERGENCY               ,
                                                       A.PAY                                                      PAY                     ,
                                                       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
                                                       A.MUHYO                                                    MUHYO                   ,
                                                       A.PORTABLE_YN                                              PORTABLE_YN             ,
                                                       A.OCS_FLAG                                                 OCS_FLAG                ,
                                                       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
                                                       A.INPUT_TAB                                                INPUT_TAB               ,
                                                       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
                                                       'N'                                                        AFTER_ACT_YN            ,
                                                       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
                                                       A.JUNDAL_PART                                              JUNDAL_PART             ,
                                                       NULL                                                       MOVE_PART               ,
                                                       A.BUNHO                                                    BUNHO                   ,
                                                       A.ORDER_DATE                                               NAEWON_DATE             ,
                                                       A.INPUT_PART                                               GWA                     ,
                                                       A.INPUT_ID                                                 DOCTOR                  ,
                                                       '0'                                                        NAEWON_TYPE             ,
                                                       A.FKINP1001                                                PK_ORDER                ,
                                                       A.SEQ                                                      SEQ                     ,
                                                       A.PKOCS2003                                                PKOCS1003               ,
                                                       A.SUB_SUSUL                                                SUB_SUSUL               ,
                                                       NULL                                                       SUTAK_YN                ,
                                                       A.AMT                                                      AMT                     ,
                                                       A.DV_1                                                     DV_1                    ,
                                                       A.DV_2                                                     DV_2                    ,
                                                       A.DV_3                                                     DV_3                    ,
                                                       A.DV_4                                                     DV_4                    ,
                                                       A.HOPE_DATE                                                HOPE_DATE               ,
                                                       A.ORDER_REMARK                                             ORDER_REMARK            ,
                                                       A.MIX_GROUP                                                MIX_GROUP               ,
                                                       'N'                                                        HOME_CARE_YN            ,
                                                       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
                                                       A.GONGBI_CODE                                              GONGBI_CODE             ,
                                                       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
                                                       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                                                                  DONBOK_YN               ,
                                                       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)
                                                                                                                  DV_NAME                 ,
                                                       B.SLIP_CODE                                                SLIP_CODE               ,
                                                       B.GROUP_YN                                                 GROUP_YN                ,
                                                       B.SG_CODE                                                  SG_CODE                 ,
                                                       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
                                                       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
                                                       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
                                                       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
                                                       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
                                                       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
                                                       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
                                                       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
                                                       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
                                                       A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
                                                       A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
                                                       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
                                                       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
                                                       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
                                                       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
                                                       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
                                                       A.TEL_YN                                                   TEL_YN                  ,
                                                       E.BUN_CODE                                                 BUN_CODE                ,
                                                       E.SG_GESAN                                                 SG_GESAN                ,
                                                       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
                                                       ''                                                         DRG_BUNRYU              ,
                                                       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('I',A.PKOCS2003),'3')      CHILD_GUBUN,
                                                       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
                                                       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,
                                                       A.PKOCS2003                                               PARENTS_KEY,
                                                       A.BOM_SOURCE_KEY                                          CHILD_KEY,
                                                       LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                                                                                        CONT_KEY
                                                  FROM OCS0140 G,
                                                       OCS0132 F,
                                                       BAS0310 E,
                                                       OCS0116 D,
                                                       OCS0132 C,
                                                       OCS0103 B,
                                                       OCS2003 A
                                                 WHERE A.HOSP_CODE        = '" + EnvironInfo.HospCode + @"'
                                                   AND A.BUNHO            = :f_bunho
                                                   AND A.FKINP1001        = :f_jubsu_no
                                                   AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = :f_naewon_date
                                                   AND A.INPUT_GWA        = :f_gwa
                                                   AND A.INPUT_DOCTOR     = :f_doctor
                                                  --各部門関係なく照会できるようにするためinput_tabの制限をなくす。
                                                  -- AND A.INPUT_TAB        = :f_input_tab
                                                   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
                                                        ( :f_input_gubun = 'NR'           ) OR
                                                        ( :f_input_gubun = 'D%'           ))
                                                   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
                                                   AND NVL(A.DC_YN,'N')   = 'N'
                                                   AND A.NALSU           >= 0
                                                   AND B.HOSP_CODE        = A.HOSP_CODE
                                                   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
                                                   AND C.HOSP_CODE    (+) = A.HOSP_CODE    
                                                   AND C.CODE         (+) = A.ORDER_GUBUN
                                                   AND C.CODE_TYPE    (+) = 'ORDER_GUBUN'
                                                   AND F.HOSP_CODE    (+) = A.HOSP_CODE
                                                   AND F.CODE         (+) = A.INPUT_GUBUN
                                                   AND F.CODE_TYPE    (+) = 'INPUT_GUBUN'
                                                   AND D.HOSP_CODE    (+) = A.HOSP_CODE
                                                   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
                                                   AND E.HOSP_CODE    (+) = B.HOSP_CODE
                                                   AND E.SG_CODE      (+) = B.SG_CODE
                                                   AND G.HOSP_CODE        = A.HOSP_CODE
                                                   AND G.ORDER_GUBUN      = A.ORDER_GUBUN
                                                   AND G.INPUT_TAB        = A.INPUT_TAB
                                                --   AND (( :f_input_tab = '%'           ) OR
                                                --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
                                                --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
                                                --        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
                                                --        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
                                                --        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
                                                --        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
                                                --        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
                                                --        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
                                                --        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
                                                 ORDER BY 92";
                #endregion
                //this.dsvLDOUT1001.WorkTp = '4';
                //this.dsvLDOCS1003.WorkTp = '5';
                //this.pnlSang.Visible = false;
            }
            else
            {
                grdOUT1001[0, grdOUT1001.CellInfos["naewon_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "オ―ダ日付" : "Order일자";
                this.grdOUT1001.AutoSizeColumn(6, 80);
                this.grdOUT1001.AutoSizeColumn(7, 80);
                this.grdOCS1003.AutoSizeColumn(3, 0);

                #region [[  grdOUT1001 & grdOCS1001 QuerySQL Setting  ]]
                this.grdOUT1001.QuerySQL =   @" SELECT A.NAEWON_DATE                     NAEWON_DATE,      -- 1
                                                       A.GWA                             GWA,
                                                       FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE)
                                                                                         GWA_NAME,
                                                       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                                                                         DOCTOR_NAME,
                                                       0                                 NALSU,
                                                       A.BUNHO                           BUNHO,
                                                       A.DOCTOR                          DOCTOR,
                                                       FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.NAEWON_DATE)
                                                                                         GUBUN_NAME ,
                                                       FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE)
                                                                                         CHOJAE_NAME,
                                                       A.NAEWON_TYPE                     NAEWON_TYPE,
                                                       A.JUBSU_NO                        JUBSU_NO   ,
                                                       A.PKOUT1001                       PK_ORDER,
                                                       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
                                                       :f_tel_yn                         TEL_YN,
                                                       'N'                               TOIWON_DRG,
                                                       :f_input_tab                      INPUT_TAB,
                                                       :f_io_gubun                       IO_GUBUN
                                                  FROM OUT1001 A
                                                 WHERE :f_io_gubun    = 'O'
                                                   AND A.HOSP_CODE    = :f_hosp_code                                                   
                                                   AND A.BUNHO        = :f_bunho
                                                   AND A.NAEWON_DATE <= :f_naewon_date
                                                   AND A.GWA         LIKE :f_gwa
                                                   AND EXISTS( SELECT 'X'
                                                                 FROM OCS0140 C,
                                                                      OCS1003 B
                                                                WHERE B.HOSP_CODE    = A.HOSP_CODE
                                                                  AND B.BUNHO        = A.BUNHO
                                                                  AND B.ORDER_DATE   = A.NAEWON_DATE
                                                                  AND B.GWA          = A.GWA
                                                                  AND B.DOCTOR       = A.DOCTOR
                                                                  AND B.NAEWON_TYPE  = A.NAEWON_TYPE
                                                                  AND NVL(B.TEL_YN     , 'N') LIKE :f_tel_yn
                                                                  AND NVL(B.DISPLAY_YN , 'Y') = 'Y'
                                                                  AND NVL(B.DC_YN,'N')   = 'N'
                                                                  AND B.NALSU           >= 0
                                                                  AND (( B.INPUT_GUBUN  = :f_input_gubun ) OR
                                                                       ( :f_input_gubun = 'NR'           ) OR
                                                                       ( :f_input_gubun = 'D%'           ))
                                                                  AND B.INPUT_TAB       = :f_input_tab
                                                                  AND C.HOSP_CODE       = B.HOSP_CODE                                                                  
                                                                  AND C.ORDER_GUBUN     = B.ORDER_GUBUN
                                                                  AND C.INPUT_TAB       = B.INPUT_TAB
                                                --                  AND (( :f_input_tab = '%'           ) OR
                                                --                       ( :f_input_tab = '1' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'C'       ) OR
                                                --                       ( :f_input_tab = '2' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'D'       ) OR
                                                --                       ( :f_input_tab = '3' AND C.INPUT_TAB                 = '02'      ) OR
                                                --                       ( :f_input_tab = '4' AND C.INPUT_TAB                 = '03'      ) OR
                                                --                       ( :f_input_tab = '5' AND C.INPUT_TAB                 = '04'      ) OR
                                                --                       ( :f_input_tab = '6' AND C.INPUT_TAB                 = '05'      ) OR
                                                --                       ( :f_input_tab = '7' AND C.INPUT_TAB                 = '06'      ) OR
                                                --                       ( :f_input_tab = '8' AND C.INPUT_TAB                 = '07'      ) OR
                                                --                       ( :f_input_tab = '9' AND C.INPUT_TAB                 = '08'      ) )
                                                                  AND ROWNUM = 1 )
                                                UNION ALL
                                                SELECT DISTINCT
                                                       A.ORDER_DATE                      NAEWON_DATE,
                                                       A.INPUT_GWA                       GWA        ,
                                                       FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE)
                                                                                         GWA_NAME,
                                                       FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE)
                                                                                         DOCTOR_NAME,
                                                       0                                 NALSU,
                                                       A.BUNHO                           BUNHO      ,
                                                       A.INPUT_DOCTOR                    DOCTOR     ,
                                                       ' '                               GUBUN_NAME ,
                                                       ' '                               CHOJAE_NAME,
                                                       '0'                               NAEWON_TYPE,
                                                       A.FKINP1001                       JUBSU_NO   ,
                                                       A.FKINP1001                       PK_ORDER   ,
                                                       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
                                                       :f_tel_yn                         TEL_YN     ,
                                                       FN_OCS_EXISTS_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE)
                                                                                                 TOIWON_DRG,
                                                       :f_input_tab                      INPUT_TAB,
                                                       :f_io_gubun                       IO_GUBUN
                                                  FROM OCS0140  B,
                                                       OCS2003  A
                                                 WHERE :f_io_gubun       = 'I'
                                                   AND A.HOSP_CODE       = :f_hosp_code                                                   
                                                   AND A.BUNHO           = :f_bunho
                                                   AND A.ORDER_DATE     <= :f_naewon_date
                                                   AND A.INPUT_GWA       LIKE :f_gwa
                                                   AND A.IO_GUBUN        IS NULL
                                                   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
                                                        ( :f_input_gubun = 'NR'           ) OR
                                                        ( :f_input_gubun = 'D%'           ))
                                                   AND A.NALSU               >= 0
                                                   AND NVL(A.DISPLAY_YN ,'Y') = 'Y'
                                                   AND NVL(A.DC_YN      ,'N') = 'N'
                                                   AND B.HOSP_CODE       = A.HOSP_CODE                                                   
                                                   AND B.ORDER_GUBUN     = A.ORDER_GUBUN
                                                   AND B.INPUT_TAB       = A.INPUT_TAB
                                                   AND B.INPUT_TAB       = :f_input_tab
                                                --   AND (( :f_input_tab = '%'           ) OR
                                                --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
                                                --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
                                                --        ( :f_input_tab = '3' AND B.INPUT_TAB                 = '02'      ) OR
                                                --        ( :f_input_tab = '4' AND B.INPUT_TAB                 = '03'      ) OR
                                                --        ( :f_input_tab = '5' AND B.INPUT_TAB                 = '04'      ) OR
                                                --        ( :f_input_tab = '6' AND B.INPUT_TAB                 = '05'      ) OR
                                                --        ( :f_input_tab = '7' AND B.INPUT_TAB                 = '06'      ) OR
                                                --        ( :f_input_tab = '8' AND B.INPUT_TAB                 = '07'      ) OR
                                                --        ( :f_input_tab = '9' AND B.INPUT_TAB                 = '08'      ) )
                                                   AND A.ORDER_DATE          >= ( SELECT MAX(C.TOIWON_DATE) - 90
                                                                                    FROM VW_OCS_INP1001_02 C
                                                                                   WHERE C.BUNHO       = :f_bunho
                                                                                     AND C.IPWON_DATE <= :f_naewon_date
                                                                                     AND C.HOSP_CODE   = :f_hosp_code   )
                                                  ORDER BY 12 DESC";

                this.grdOCS1003.QuerySQL = @"SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
                                                   A.GROUP_SER                                                GROUP_SER               ,
                                                   NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
                                                   A.HANGMOG_CODE                                             HANGMOG_CODE            ,
                                                   ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                                                          THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
                                                          ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
                                                   A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
                                                   D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
                                                   A.SURYANG                                                  SURYANG                 ,
                                                   A.ORD_DANUI                                                ORD_DANUI               ,
                                                   FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
                                                   A.DV_TIME                                                  DV_TIME                 ,
                                                   A.DV                                                       DV                      ,
                                                   A.NALSU                                                    NALSU                   ,
                                                   A.JUSA                                                     JUSA                    ,
                                                   FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
                                                   A.BOGYONG_CODE                                             BOGYONG_CODE            ,
                                                   FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                                                              BOGYONG_NAME            ,
                                                   A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
                                                   A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
                                                   A.PHARMACY                                                 PHARMACY                ,
                                                   A.DRG_PACK_YN                                              DRG_PACK_YN             ,
                                                   A.POWDER_YN                                                POWDER_YN               ,
                                                   A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
                                                   NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,
                                                   NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,
                                                   NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
                                                   A.PAY                                                      PAY                     ,
                                                   A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
                                                   A.MUHYO                                                    MUHYO                   ,
                                                   A.PORTABLE_YN                                              PORTABLE_YN             ,
                                                   A.OCS_FLAG                                                 OCS_FLAG                ,
                                                   A.ORDER_GUBUN                                              ORDER_GUBUN             ,
                                                   A.INPUT_TAB                                                INPUT_TAB               ,
                                                   A.INPUT_GUBUN                                              INPUT_GUBUN             ,
                                                   A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,
                                                   A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
                                                   A.JUNDAL_PART                                              JUNDAL_PART             ,
                                                   A.MOVE_PART                                                MOVE_PART               ,
                                                   A.BUNHO                                                    BUNHO                   ,
                                                   A.ORDER_DATE                                               ORDER_DATE              ,
                                                   A.GWA                                                      GWA                     ,
                                                   A.DOCTOR                                                   DOCTOR                  ,
                                                   A.NAEWON_TYPE                                              NAEWON_TYPE             ,
                                                   A.FKOUT1001                                                PK_ORDER                ,
                                                   A.SEQ                                                      SEQ                     ,
                                                   A.PKOCS1003                                                PKOCS1003               ,
                                                   A.SUB_SUSUL                                                SUB_SUSUL               ,
                                                   A.SUTAK_YN                                                 SUTAK_YN                ,
                                                   A.AMT                                                      AMT                     ,
                                                   A.DV_1                                                     DV_1                    ,
                                                   A.DV_2                                                     DV_2                    ,
                                                   A.DV_3                                                     DV_3                    ,
                                                   A.DV_4                                                     DV_4                    ,
                                                   A.HOPE_DATE                                                HOPE_DATE               ,
                                                   A.ORDER_REMARK                                             ORDER_REMARK            ,
                                                   A.MIX_GROUP                                                MIX_GROUP               ,
                                                   A.HOME_CARE_YN                                             HOME_CARE_YN            ,
                                                   NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
                                                   A.GONGBI_CODE                                              GONGBI_CODE             ,
                                                   FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
                                                   DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                                                              DONBOK_YN               ,
                                                   FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)
                                                                                                              DV_NAME                 ,
                                                   B.SLIP_CODE                                                SLIP_CODE               ,
                                                   B.GROUP_YN                                                 GROUP_YN                ,
                                                   B.SG_CODE                                                  SG_CODE                 ,
                                                   B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
                                                   B.INPUT_CONTROL                                            INPUT_CONTROL           ,
                                                   NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
                                                   DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
                                                   B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
                                                   NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
                                                   NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
                                                   DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
                                                   B.ORD_DANUI                                                ORD_DANUI_BAS           ,
                                                   A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
                                                   A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
                                                   ( CASE WHEN FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE) <> 'Y'
                                                          THEN 'N'
                                                          WHEN FN_OCS_BULYONG_CHECK_OUT   (B.HANGMOG_CODE, SYSDATE) = 'Y'
                                                           AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, TRUNC(SYSDATE)) <> A.HANGMOG_CODE
                                                          THEN 'Z'
                                                          ELSE 'Y' END )                                      BULYONG_CHECK           ,
                                                   FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
                                                   B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
                                                   NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
                                                   NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
                                                   A.TEL_YN                                                   TEL_YN                  ,
                                                   E.BUN_CODE                                                 BUN_CODE                ,
                                                   E.SG_GESAN                                                 SG_GESAN                ,
                                                   FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
                                                   ''                                                         DRG_BUNRYU              ,
                                                   DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('O',A.PKOCS1003),'3')      CHILD_GUBUN,
                                                   A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
                                                   A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,   
                                                   A.PKOCS1003                                               PARENTS_KEY,
                                                   A.BOM_SOURCE_KEY                                          CHILD_KEY,
                                                   LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||
                                                   ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B')
                                                           AND A.HOPE_DATE IS NOT NULL
                                                          THEN TO_CHAR(A.HOPE_DATE, 'YYYYMMDD')
                                                          ELSE '00000000' END )||
                                                   LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                                                                              CONT_KEY
                                              FROM OCS0140 G,
                                                   OCS0132 F,
                                                   BAS0310 E,
                                                   OCS0116 D,
                                                   OCS0132 C,
                                                   OCS0103 B,
                                                   OCS1003 A
                                             WHERE A.BUNHO            = :f_bunho
                                               AND A.ORDER_DATE       = :f_naewon_date
                                               AND A.GWA              = :f_gwa
                                               AND A.DOCTOR           = :f_doctor
                                               AND A.NAEWON_TYPE      = :f_naewon_type
                                               AND A.INPUT_TAB        = :f_input_tab
                                               AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
                                                    ( :f_input_gubun = 'NR'           ) OR
                                                    ( :f_input_gubun = 'D%'           ))
                                               AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
                                               AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
                                               AND NVL(A.DC_YN,'N')   = 'N'
                                               AND A.NALSU           >= 0
                                               AND B.HANGMOG_CODE     = A.HANGMOG_CODE
                                               AND C.CODE     (+)     = A.ORDER_GUBUN
                                               AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'
                                               AND F.CODE     (+)     = A.INPUT_GUBUN
                                               AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
                                               AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
                                               AND E.SG_CODE  (+)     = B.SG_CODE
                                               AND G.ORDER_GUBUN      = A.ORDER_GUBUN
                                               AND G.INPUT_TAB        = A.INPUT_TAB
                                            --   AND (( :f_input_tab = '%'           ) OR
                                            --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
                                            --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
                                            --        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
                                            --        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
                                            --        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
                                            --        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
                                            --        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
                                            --        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
                                            --        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
                                            UNION ALL
                                            SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
                                                   A.GROUP_SER                                                GROUP_SER               ,
                                                   NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
                                                   A.HANGMOG_CODE                                             HANGMOG_CODE            ,
                                                   ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                                                          THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
                                                          ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
                                                   A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
                                                   D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
                                                   A.SURYANG                                                  SURYANG                 ,
                                                   A.ORD_DANUI                                                ORD_DANUI               ,
                                                   FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
                                                   A.DV_TIME                                                  DV_TIME                 ,
                                                   A.DV                                                       DV                      ,
                                                   A.NALSU                                                    NALSU                   ,
                                                   A.JUSA                                                     JUSA                    ,
                                                   FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
                                                   A.BOGYONG_CODE                                             BOGYONG_CODE            ,
                                                   FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                                                              BOGYONG_NAME            ,
                                                   A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
                                                   A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
                                                   A.PHARMACY                                                 PHARMACY                ,
                                                   A.DRG_PACK_YN                                              DRG_PACK_YN             ,
                                                   A.POWDER_YN                                                POWDER_YN               ,
                                                   A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
                                                   'N'                                                        DANGIL_GUMSA_ORDER_YN   ,
                                                   'N'                                                        DANGIL_GUMSA_RESULT_YN  ,
                                                   NVL(A.EMERGENCY  , 'N')                                    EMERGENCY               ,
                                                   A.PAY                                                      PAY                     ,
                                                   A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
                                                   A.MUHYO                                                    MUHYO                   ,
                                                   A.PORTABLE_YN                                              PORTABLE_YN             ,
                                                   A.OCS_FLAG                                                 OCS_FLAG                ,
                                                   A.ORDER_GUBUN                                              ORDER_GUBUN             ,
                                                   A.INPUT_TAB                                                INPUT_TAB               ,
                                                   A.INPUT_GUBUN                                              INPUT_GUBUN             ,
                                                   'N'                                                        AFTER_ACT_YN            ,
                                                   A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
                                                   A.JUNDAL_PART                                              JUNDAL_PART             ,
                                                   NULL                                                       MOVE_PART               ,
                                                   A.BUNHO                                                    BUNHO                   ,
                                                   A.ORDER_DATE                                               NAEWON_DATE             ,
                                                   A.INPUT_PART                                               GWA                     ,
                                                   A.INPUT_ID                                                 DOCTOR                  ,
                                                   '0'                                                        NAEWON_TYPE             ,
                                                   A.FKINP1001                                                PK_ORDER                ,
                                                   A.SEQ                                                      SEQ                     ,
                                                   A.PKOCS2003                                                PKOCS1003               ,
                                                   A.SUB_SUSUL                                                SUB_SUSUL               ,
                                                   NULL                                                       SUTAK_YN                ,
                                                   A.AMT                                                      AMT                     ,
                                                   A.DV_1                                                     DV_1                    ,
                                                   A.DV_2                                                     DV_2                    ,
                                                   A.DV_3                                                     DV_3                    ,
                                                   A.DV_4                                                     DV_4                    ,
                                                   A.HOPE_DATE                                                HOPE_DATE               ,
                                                   A.ORDER_REMARK                                             ORDER_REMARK            ,
                                                   A.MIX_GROUP                                                MIX_GROUP               ,
                                                   'N'                                                        HOME_CARE_YN            ,
                                                   NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
                                                   A.GONGBI_CODE                                              GONGBI_CODE             ,
                                                   FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
                                                   DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                                                              DONBOK_YN               ,
                                                   FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)
                                                                                                              DV_NAME                 ,
                                                   B.SLIP_CODE                                                SLIP_CODE               ,
                                                   B.GROUP_YN                                                 GROUP_YN                ,
                                                   B.SG_CODE                                                  SG_CODE                 ,
                                                   B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
                                                   B.INPUT_CONTROL                                            INPUT_CONTROL           ,
                                                   NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
                                                   DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
                                                   B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
                                                   NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
                                                   NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
                                                   DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
                                                   B.ORD_DANUI                                                ORD_DANUI_BAS           ,
                                                   A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
                                                   A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
                                                   FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
                                                   FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
                                                   B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
                                                   NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
                                                   NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
                                                   A.TEL_YN                                                   TEL_YN                  ,
                                                   E.BUN_CODE                                                 BUN_CODE                ,
                                                   E.SG_GESAN                                                 SG_GESAN                ,
                                                   FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
                                                   ''                                                         DRG_BUNRYU              ,
                                                   DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('I',A.PKOCS2003),'3')      CHILD_GUBUN,
                                                   A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
                                                   A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,   
                                                   A.PKOCS2003                                               PARENTS_KEY,
                                                   A.BOM_SOURCE_KEY                                          CHILD_KEY,
                                                   LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                                                                              CONT_KEY
                                              FROM OCS0140 G,
                                                   OCS0132 F,
                                                   BAS0310 E,
                                                   OCS0116 D,
                                                   OCS0132 C,
                                                   OCS0103 B,
                                                   OCS2003 A
                                             WHERE A.BUNHO            = :f_bunho
                                               AND A.FKINP1001        = :f_jubsu_no
                                               AND A.ORDER_DATE       = :f_naewon_date
                                               AND A.INPUT_GWA        = :f_gwa
                                               AND A.INPUT_DOCTOR     = :f_doctor
                                               AND A.INPUT_TAB        = :f_input_tab
                                               AND (( A.INPUT_GUBUN   = :f_input_gubun ) OR
                                                    ( :f_input_gubun  = 'NR'           ) OR
                                                    ( :f_input_gubun  = 'D%'           ))
                                               AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
                                               AND NVL(A.DC_YN,'N')   = 'N'
                                               AND A.NALSU           >= 0
                                               AND B.HANGMOG_CODE     = A.HANGMOG_CODE
                                               AND C.CODE     (+)     = A.ORDER_GUBUN
                                               AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'
                                               AND F.CODE     (+)     = A.INPUT_GUBUN
                                               AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
                                               AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
                                               AND E.SG_CODE  (+)     = B.SG_CODE
                                               AND G.ORDER_GUBUN      = A.ORDER_GUBUN
                                               AND G.INPUT_TAB        = A.INPUT_TAB
                                            --   AND (( :f_input_tab = '%'           ) OR
                                            --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
                                            --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
                                            --        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
                                            --        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
                                            --        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
                                            --        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
                                            --        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
                                            --        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
                                            --        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
                                             ORDER BY 92";
                #endregion
                //this.dsvLDOUT1001.WorkTp = '1';
                //this.dsvLDOCS1003.WorkTp = '3';
                //this.pnlSang.Visible = true;
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", dpkNaewon_date.GetDataValue());
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            
        }

        #endregion
        */
        #endregion

        private void childSetImage()
        {
            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                //this.grdOCS1003[i, "child_yn"].ForeColor = IHIS.Framework.XColor.XGridColHeaderForeColor;
                string child_yn = this.grdOCS1003.GetItemString(i, "child_yn");

                switch (child_yn)
                {
                    case "Y":
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[6];
                        break;
                    case "N":
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[4];
                        break;
                    default:
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[4];
                        break;

                }
                this.grdOCS1003[i, "child_yn"].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
        }

        private void OpenScreen_CPL0000Q01(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("send_yn", "Y");
            openParams.Add("close_yn", "Y");

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.PopUpFixed, openParams);

            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }

        private void OpenScreen_XRT0000Q00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
        }

        private void OpenScreen_INJ0000Q00(string aBunho)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "INJS", "INJ0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }

        private void OpenScreen_ScanViewer(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "CPLS", "SCANVIEWER", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
        }

        private void tabOrderGubunChanged()
        {
            //<summary>
            //tab 변경시 해당 처방조회
            //</summary>
            //1:全体
            //2:薬
            //3:注射
            //4:検査
            //5:その他
            //G 
            //H
            //I
            //J
            //K
            //L
            //M
            //N
            //O
            //Z
            //<param name="sender"></param>
            //<param name="e"></param>
            if (tabOrderGubun.SelectedTab == null) return;

            foreach (IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
            {
                if (tabOrderGubun.SelectedTab == page)
                    page.ImageIndex = 1;
                else
                    page.ImageIndex = 0;
            }

            for (int i = 0; i < grdOUT1001.RowCount; i++)
            {
                grdOUT1001.SetItemValue(i, "select", "N");
                SelectionBackColorChange(grdOUT1001, i, "N");
                this.grdDeleteAll(this.grdOCS1003);
            }

            dloSelectOCS1003.Reset();

            for (int i = 0; i < this.grdOUT1001.RowCount; i++)
            {
                this.grdOUT1001.SetItemValue(i, "select", "N");
                SelectionBackColorChange(this.grdOUT1001, i, "N");
            }

            // grdOCS1003.QueryLayout(true);



            //검사인 경우에는 실시일 기준으로 조회한다.
            if (tabOrderGubun.SelectedTab.Tag.ToString() == "4")
            {
                string filter = @" order_gubun_bas <> 'A' 
                               and order_gubun_bas <> 'B'
                               and order_gubun_bas <> 'C'
                               and order_gubun_bas <> 'D'
                               and order_gubun_bas <> 'E'
                               and order_gubun_bas <> 'F'
                                 ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "3")
            {
                string filter = @" order_gubun_bas = 'F' 
                                or order_gubun_bas = 'E'
                                or order_gubun_bas = 'N'
                                or order_gubun_bas = 'O'";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "2")
            {
                string filter = " order_gubun_bas = 'A' or order_gubun_bas = 'B' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "1")
            {
                string filter = " order_gubun_bas = 'C' or order_gubun_bas = 'D' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else
            {
                this.grdOCS1003.SetFilter("");
            }
        }

        private bool IsSelectedOrder()
        {
            XEditGrid grd = this.grdOCS1003;

            int selectedCnt = 0;
            for (int i = 0; i < grd.DisplayRowCount; i++)
            {
                if (grd.GetItemString(i, "select") == "Y")
                {
                    selectedCnt++;
                    break;
                }
            }

            if (selectedCnt == 0)
            {
                XMessageBox.Show(Resources.MessageText10, Resources.MessageText6_JP);
                this.pbxUnderArrow.Visible = true;
                timer_icon.Start();
                return false;
            }

            return true;
        }

        #endregion

        #region Cloud updated code

        #region InitControlsToConnectCloud
        /// <summary>
        /// InitControlsToConnectCloud
        /// </summary>
        private void InitControlsToConnectCloud()
        {
            this.grdOUT1001.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_input_gubun",
                    "f_tel_yn",
                    "f_hosp_code",
                    "f_io_gubun",
                    "f_input_tab",
                    "f_kijun",
                    "f_selected_input_tab",
                    "f_naewon_date",
                    "f_gwa",
                });
            this.grdOCS1003.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_naewon_date",
                    "f_gwa",
                    "f_doctor",
                    "f_naewon_type",
                    "f_input_gubun",
                    "f_tel_yn",
                    "f_input_tab",
                    "f_jubsu_no",
                    "f_pk_order",
                    "f_hosp_code",
                    "f_generic_yn",
                    "f_kijun",
                    "f_io_gubun",
                });

            this.grdOUT1001.ExecuteQuery = GetGrdOUT1001;
            this.grdSangInfo.ExecuteQuery = GetGrdSangInfo;
            this.grdOCS1003.ExecuteQuery = GetGrdOCS1003;
        }
        #endregion

        #region GetGrdOUT1001
        /// <summary>
        /// GetGrdOUT1001
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOUT1001(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            OcsoOCS1003Q05ScheduleArgs args = new OcsoOCS1003Q05ScheduleArgs();
            args.InputGubun = list["f_input_gubun"].VarValue;
            args.TelYn = list["f_tel_yn"].VarValue;
            args.InputTab = list["f_input_tab"].VarValue;
            args.IoGubun = list["f_io_gubun"].VarValue;
            args.SelectedInputTab = list["f_selected_input_tab"].VarValue;
            args.Bunho = list["f_bunho"].VarValue;
            args.Kijun = list["f_kijun"].VarValue;
            args.NaewonDate = list["f_naewon_date"].VarValue;
            args.Gwa = list["f_gwa"].VarValue;
            OcsoOCS1003Q05ScheduleResult res = CloudService.Instance.Submit<OcsoOCS1003Q05ScheduleResult,
                OcsoOCS1003Q05ScheduleArgs>(args);

            if (null != res)
            {
                foreach (OcsoOCS1003Q05ScheduleItemInfo item in res.ScheduleItem)
                {
                    lObj.Add(new object[]
                    {
                        item.NaewonDate,
                        item.Gwa,
                        item.GwaName,
                        item.DoctorName,
                        item.Nalsu,
                        item.Bunho,
                        item.Doctor,
                        item.GubunName,
                        item.ChojaeName,
                        item.NaewonType,
                        item.JubsuNo,
                        item.PkOrder,
                        item.InputGubun,
                        item.TelYn,
                        item.ToiwonDrg,
                        item.InputTab,
                        item.IoGubun,
                        item.OcsCnt,
                    });
                }
            }

            //this._grdOUT1001Clone = lObj;

            return lObj;
        }
        #endregion

        #region GrdOUT1001RowFocusChanged
        /// <summary>
        /// GrdOUT1001RowFocusChanged
        /// </summary>
        //private void GrdOUT1001RowFocusChanged()
        //{
        //    OcsoOCS1003Q05GrdRowFocusChangedArgs args = new OcsoOCS1003Q05GrdRowFocusChangedArgs();
        //    // Order request params
        //    args.Bunho              = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "bunho");
        //    args.Doctor             = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "doctor");
        //    args.Gwa                = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "gwa");
        //    args.JubsuNo            = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "jubsu_no");
        //    args.NaewonDate         = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "naewon_date").Replace(" 0:00:00", "");
        //    args.GenericYn          = cbxGeneric_YN.GetDataValue();
        //    args.PkOrder            = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pk_order");
        //    args.InputTab           = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "input_tab");
        //    args.InputGubun         = this.mInput_gubun;
        //    args.TelYn              = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "tel_yn");
        //    args.Kijun              = this.cboKijunGubun.SelectedValue.ToString();
        //    // Disease request params
        //    args.IoGubun            = (rbtOut.Checked) ? "O" : "I";
        //    args.NaewonType         = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "naewon_type");

        //    //args.Bunho                  = grdOCS1003.BindVarList["f_bunho"].VarValue;
        //    //args.Doctor                 = grdOCS1003.BindVarList["f_doctor"].VarValue;
        //    //args.Gwa                    = grdOCS1003.BindVarList["f_gwa"].VarValue;
        //    //args.JubsuNo                = grdOCS1003.BindVarList["f_jubsu_no"].VarValue;
        //    //args.NaewonDate             = grdOCS1003.BindVarList["f_naewon_date"].VarValue;
        //    //args.GenericYn              = grdOCS1003.BindVarList["f_generic_yn"].VarValue;
        //    //args.PkOrder                = grdOCS1003.BindVarList["f_pk_order"].VarValue;
        //    //args.InputTab               = grdOCS1003.BindVarList["f_input_tab"].VarValue;
        //    //args.InputGubun             = grdOCS1003.BindVarList["f_input_gubun"].VarValue;
        //    //args.TelYn                  = grdOCS1003.BindVarList["f_tel_yn"].VarValue;
        //    //args.Kijun                  = grdOCS1003.BindVarList["f_kijun"].VarValue;
        //    //args.IoGubun                = grdOCS1003.BindVarList["f_io_gubun"].VarValue;
        //    //args.NaewonType             = grdOCS1003.BindVarList["f_naewon_type"].VarValue;
        //    OcsoOCS1003Q05GrdRowFocusChangedResult res = CloudService.Instance.Submit<OcsoOCS1003Q05GrdRowFocusChangedResult,
        //        OcsoOCS1003Q05GrdRowFocusChangedArgs>(args);

        //    if (null != res)
        //    {
        //        this._sangInfo = new List<object[]>();
        //        this._grdOCS1003 = new List<object[]>();

        //        #region Bind data
        //        foreach (OcsoOCS1003Q05DiseaseListItemInfo item in res.DiseaseItem)
        //        {
        //            this._sangInfo.Add(new object[]
        //            {
        //                item.JuSangYn,
        //                item.SangCode,
        //                item.GwaName,
        //                item.Ser,
        //                item.DisSangName,
        //                item.SangStartDate,
        //                item.SangEndDate,
        //                item.SangEndSayu,
        //                item.SangEndSayuName,
        //                item.Bunho,
        //                item.NaewonDate,
        //                item.Gwa,
        //                item.Doctor,
        //                item.NaewonType,
        //                item.JubsuNo,
        //                item.PkOrder,
        //                item.SangName,
        //                item.PreModifier1,
        //                item.PreModifier2,
        //                item.PreModifier3,
        //                item.PreModifier4,
        //                item.PreModifier5,
        //                item.PreModifier6,
        //                item.PreModifier7,
        //                item.PreModifier8,
        //                item.PreModifier9,
        //                item.PreModifier10,
        //                item.PreModifierName,
        //                item.PostModifier1,
        //                item.PostModifier2,
        //                item.PostModifier3,
        //                item.PostModifier4,
        //                item.PostModifier5,
        //                item.PostModifier6,
        //                item.PostModifier7,
        //                item.PostModifier8,
        //                item.PostModifier9,
        //                item.PostModifier10,
        //                item.PostModifierName,
        //                item.SangJindanDate,
        //                item.OrderByKey,
        //            });
        //        }

        //        foreach (OcsoOCS1003Q05OrderListItemInfo item in res.OrderItem)
        //        {
        //            this._grdOCS1003.Add(new object[]
        //            {
        //                item.InputGubunName,
        //                item.GroupSer,
        //                item.OrderGubunName,
        //                item.HangmogCode,
        //                item.HangmogName,
        //                item.SpecimenCode,
        //                item.SpecimenName,
        //                item.Suryang,
        //                item.OrdDanui,
        //                item.OrdDanuiName,
        //                item.DvTime,
        //                item.Dv,
        //                item.Nalsu,
        //                item.Jusa,
        //                item.JusaName,
        //                item.BogyongCode,
        //                item.BogyongName,
        //                item.JusaSpdGubun,
        //                item.HubalChangeYn,
        //                item.Pharmacy,
        //                item.DrgPackYn,
        //                item.PowderYn,
        //                item.WonyoiOrderYn,
        //                item.DangilGumsaOrderYn,
        //                item.DangilGumsaResultYn,
        //                item.Emergency,
        //                item.Pay,
        //                item.AntiCancerYn,
        //                item.Muhyo,
        //                item.PortableYn,
        //                item.OcsFlag,
        //                item.OrderGubun,
        //                item.InputTab,
        //                item.InputGubun,
        //                item.AfterActYn,
        //                item.JundalTable,
        //                item.JundalPart,
        //                item.MovePart,
        //                item.Bunho,
        //                item.OrderDate,
        //                item.Gwa,
        //                item.Doctor,
        //                item.NaewonType,
        //                item.PkOrder,
        //                item.Seq,
        //                item.Pkocs1003,
        //                item.SubSusul,
        //                item.SutakYn,
        //                item.Amt,
        //                item.Dv1,
        //                item.Dv2,
        //                item.Dv3,
        //                item.Dv4,
        //                item.HopeDate,
        //                item.OrderRemark,
        //                item.MixGroup,
        //                item.HomeCareYn,
        //                item.RegularYn,
        //                item.GongbiCode,
        //                item.GongbiName,
        //                item.DonbokYn,
        //                item.DvName,
        //                item.SlipCode,
        //                item.GroupYn,
        //                item.SgCode,
        //                item.OrderGubunBas,
        //                item.InputControl,
        //                item.SugaYn,
        //                item.EmergencyCheck,
        //                item.LimitSuryang,
        //                item.SpecimenYn,
        //                item.JaeryoYn,
        //                item.OrdDanuiCheck,
        //                item.OrdDanuiBas,
        //                item.JundalTableOut,
        //                item.JundalPartOut,
        //                item.MovePartOut,
        //                item.JundalTableInp,
        //                item.JundalPartInp,
        //                item.MovePartInp,
        //                item.BulyongCheck,
        //                item.WonyoiOrderCrYn,
        //                item.DefaultWonyoiOrderYn,
        //                item.NdayYn,
        //                item.MuhyoYn,
        //                item.TelYn,
        //                item.DrgInfo,
        //                item.DrgBunryu,
        //                item.ChildYn,
        //                item.BomSourceKey,
        //                item.BomOccurYn,
        //                item.OrgKey,
        //                item.ParentKey,
        //                item.BunCode,
        //                item.ContKey,
        //                item.Fkout1001,
        //                item.WonnaeDrgYn,
        //                item.DcYn,
        //                item.ResultDate,
        //                item.ConfirmCheck,
        //                item.SunabCheck,
        //                item.Dv5,
        //                item.Dv6,
        //                item.Dv7,
        //                item.Dv8,
        //                item.GeneralDispYn,
        //                item.GenericName,
        //                item.State,
        //                item.BogyongCodeSub,
        //                item.BogyongNameSub,
        //                item.OriHopeDate,
        //                item.IoYn,
        //                item.BroughtDrgYn,
        //            });
        //        }
        //        #endregion
        //    }
        //}
        #endregion

        #region GetGrdOCS1003
        /// <summary>
        /// GetGrdOCS1003
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS1003(BindVarCollection list)
        {
            List<object[]> lObj = new List<object[]>();

            OcsoOCS1003Q05OrderListArgs args = new OcsoOCS1003Q05OrderListArgs();

            args.Bunho                  = list["f_bunho"].VarValue;
            args.Doctor                 = list["f_doctor"].VarValue;
            args.GenericYn              = list["f_generic_yn"].VarValue;
            args.Gwa                    = list["f_gwa"].VarValue;
            args.InputGubun             = list["f_input_gubun"].VarValue;
            args.InputTab               = list["f_input_tab"].VarValue;
            args.JubsuNo                = list["f_jubsu_no"].VarValue;
            args.Kijun                  = list["f_kijun"].VarValue;
            args.NaewonDate             = list["f_naewon_date"].VarValue;
            args.PkOrder                = list["f_pk_order"].VarValue;
            args.TelYn                  = list["f_tel_yn"].VarValue;

            OcsoOCS1003Q05OrderListResult res = CloudService.Instance.Submit<OcsoOCS1003Q05OrderListResult,
                OcsoOCS1003Q05OrderListArgs>(args);

            if (null != res)
            {
                foreach (OcsoOCS1003Q05OrderListItemInfo item in res.OrderListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.InputGubunName,
                        item.GroupSer,
                        item.OrderGubunName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Suryang,
                        item.OrdDanui,
                        item.OrdDanuiName,
                        item.DvTime,
                        item.Dv,
                        item.Nalsu,
                        item.Jusa,
                        item.JusaName,
                        item.BogyongCode,
                        item.BogyongName,
                        (string.IsNullOrEmpty(item.JusaSpdGubun) ? " " : item.JusaSpdGubun),
                        item.HubalChangeYn,
                        item.Pharmacy,
                        item.DrgPackYn,
                        item.PowderYn,
                        item.WonyoiOrderYn,
                        item.DangilGumsaOrderYn,
                        item.DangilGumsaResultYn,
                        item.Emergency,
                        item.Pay,
                        item.AntiCancerYn,
                        item.Muhyo,
                        item.PortableYn,
                        item.OcsFlag,
                        item.OrderGubun,
                        item.InputTab,
                        item.InputGubun,
                        item.AfterActYn,
                        item.JundalTable,
                        item.JundalPart,
                        item.MovePart,
                        item.Bunho,
                        item.OrderDate,
                        item.Gwa,
                        item.Doctor,
                        item.NaewonType,
                        item.PkOrder,
                        item.Seq,
                        item.Pkocs1003,
                        item.SubSusul,
                        item.SutakYn,
                        item.Amt,
                        item.Dv1,
                        item.Dv2,
                        item.Dv3,
                        item.Dv4,
                        item.HopeDate,
                        item.OrderRemark,
                        item.MixGroup,
                        item.HomeCareYn,
                        item.RegularYn,
                        item.GongbiCode,
                        item.GongbiName,
                        item.DonbokYn,
                        item.DvName,
                        item.SlipCode,
                        item.GroupYn,
                        item.SgCode,
                        item.OrderGubunBas,
                        item.InputControl,
                        item.SugaYn,
                        item.EmergencyCheck,
                        item.LimitSuryang,
                        item.SpecimenYn,
                        item.JaeryoYn,
                        item.OrdDanuiCheck,
                        item.OrdDanuiBas,
                        item.JundalTableOut,
                        item.JundalPartOut,
                        item.MovePartOut,
                        item.JundalTableInp,
                        item.JundalPartInp,
                        item.MovePartInp,
                        item.BulyongCheck,
                        item.WonyoiOrderCrYn,
                        item.DefaultWonyoiOrderYn,
                        item.NdayYn,
                        item.MuhyoYn,
                        item.TelYn,
                        item.DrgInfo,
                        item.DrgBunryu,
                        item.ChildYn,
                        item.BomSourceKey,
                        item.BomOccurYn,
                        item.OrgKey,
                        item.ParentKey,
                        item.BunCode,
                        item.ContKey,
                        item.Fkout1001,
                        item.WonnaeDrgYn,
                        item.DcYn,
                        item.ResultDate,
                        item.ConfirmCheck,
                        item.SunabCheck,
                        item.Dv5,
                        item.Dv6,
                        item.Dv7,
                        item.Dv8,
                        item.GeneralDispYn,
                        item.GenericName,
                        item.State,
                        item.BogyongCodeSub,
                        item.BogyongNameSub,
                        item.OriHopeDate,
                        item.IoYn,
                        item.BroughtDrgYn,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdOCS1003ForRowFocusChanged
        /// <summary>
        /// GetGrdOCS1003ForRowFocusChanged
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        //private IList<object[]> GetGrdOCS1003ForRowFocusChanged(BindVarCollection list)
        //{
        //    return this._grdOCS1003;
        //}
        #endregion

        #region GetGrdSangInfo
        /// <summary>
        /// GetGrdSangInfo
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdSangInfo(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OcsoOCS1003Q05DiseaseListArgs args          = new OcsoOCS1003Q05DiseaseListArgs();
            args.Bunho                                  = bvc["f_bunho"].VarValue;
            args.Doctor                                 = bvc["f_doctor"].VarValue;
            args.Gwa                                    = bvc["f_gwa"].VarValue;
            args.IoGubun                                = bvc["f_io_gubun"].VarValue;
            args.JubsuNo                                = bvc["f_jubsu_no"].VarValue;
            args.NaewonDate                             = bvc["f_naewon_date"].VarValue;
            args.NaewonType                             = bvc["f_naewon_type"].VarValue;
            OcsoOCS1003Q05DiseaseListResult res = CloudService.Instance.Submit<OcsoOCS1003Q05DiseaseListResult,
                OcsoOCS1003Q05DiseaseListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.DiseaseListItem.ForEach(delegate(OcsoOCS1003Q05DiseaseListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.JuSangYn,
                        item.SangCode,
                        item.GwaName,
                        item.Ser,
                        item.DisSangName,
                        item.SangStartDate,
                        item.SangEndDate,
                        item.SangEndSayu,
                        item.SangEndSayuName,
                        item.Bunho,
                        item.NaewonDate,
                        item.Gwa,
                        item.Doctor,
                        item.NaewonType,
                        item.JubsuNo,
                        item.PkOrder,
                        item.SangName,
                        item.PreModifier1,
                        item.PreModifier2,
                        item.PreModifier3,
                        item.PreModifier4,
                        item.PreModifier5,
                        item.PreModifier6,
                        item.PreModifier7,
                        item.PreModifier8,
                        item.PreModifier9,
                        item.PreModifier10,
                        item.PreModifierName,
                        item.PostModifier1,
                        item.PostModifier2,
                        item.PostModifier3,
                        item.PostModifier4,
                        item.PostModifier5,
                        item.PostModifier6,
                        item.PostModifier7,
                        item.PostModifier8,
                        item.PostModifier9,
                        item.PostModifier10,
                        item.PostModifierName,
                        item.SangJindanDate,
                        item.OrderByKey,
                    });
                });
            }

            return lObj;
        }
        #endregion

        private void CheckAll()
        {
            if (chkAll.Checked)
            {
                chkAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkAll.ImageIndex = 1;

                grdOUT1001.SetBindVarValue("f_gwa", "%");
            }
            else
            {
                chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkAll.ImageIndex = 0;

                grdOUT1001.SetBindVarValue("f_gwa", mGwa);
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        #endregion
    }
}