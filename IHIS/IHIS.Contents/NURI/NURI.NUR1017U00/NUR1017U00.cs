#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;
using IHIS.CloudConnector.Contracts.Results.Nuri;
using IHIS.CloudConnector.Messaging;
using IHIS.Framework;
using IHIS.NURI.Properties;
using NUR1017U00GrdNUR1017ListItemInfo = IHIS.CloudConnector.Contracts.Models.Nuri.NUR1017U00GrdNUR1017ListItemInfo;
using ComboListItemInfo = IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo;

#endregion

namespace IHIS.NURI
{
    /// <summary>
    /// NUR1017U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class NUR1017U00 : IHIS.Framework.XScreen
    {
        #region 추가사항
        private string sysid = string.Empty;
        private string screen = string.Empty;
        private string flag = "N";
        #endregion

        #region 자동생성
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlButtom;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XEditGrid grdNUR1017;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.MultiLayout layComboSet;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;

        private NUR1017U00GetComboListResult cboResult;
        private const string CACHE_NUR1017U00_COMBO_LIST_ITEM_KEYS = "NURI.Nur1017U00.CboListItem";
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region 생성자
        public NUR1017U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            cboResult = LoadDataAllComboBox();
            InitializeComponent();


            grdNUR1017.ExecuteQuery = LoadDataGrdNUR1017;
            layComboSet.ExecuteQuery = LoadDataLayComboSet;
        }



        #endregion

        #region 소멸자
        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1017U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlButtom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdNUR1017 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1017)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlButtom
            // 
            this.pnlButtom.AccessibleDescription = null;
            this.pnlButtom.AccessibleName = null;
            resources.ApplyResources(this.pnlButtom, "pnlButtom");
            this.pnlButtom.BackgroundImage = null;
            this.pnlButtom.Controls.Add(this.btnList);
            this.pnlButtom.Font = null;
            this.pnlButtom.Name = "pnlButtom";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.grdNUR1017);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // grdNUR1017
            // 
            resources.ApplyResources(this.grdNUR1017, "grdNUR1017");
            this.grdNUR1017.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdNUR1017.ColPerLine = 6;
            this.grdNUR1017.Cols = 7;
            this.grdNUR1017.ExecuteQuery = null;
            this.grdNUR1017.FixedCols = 1;
            this.grdNUR1017.FixedRows = 1;
            this.grdNUR1017.FocusColumnName = "infe_jaeryo";
            this.grdNUR1017.HeaderHeights.Add(26);
            this.grdNUR1017.Name = "grdNUR1017";
            this.grdNUR1017.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNUR1017.ParamList")));
            this.grdNUR1017.QuerySQL = resources.GetString("grdNUR1017.QuerySQL");
            this.grdNUR1017.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdNUR1017.RowHeaderVisible = true;
            this.grdNUR1017.Rows = 2;
            this.grdNUR1017.ToolTipActive = true;
            this.grdNUR1017.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR017_GridColumnChanged);
            this.grdNUR1017.PreEndInitializing += new System.EventHandler(this.grdNUR1017_PreEndInitializing);
            this.grdNUR1017.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR017_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "infe_code";
            this.xEditGridCell1.CellWidth = 160;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.MaxDropDownItems = 50;
            this.xEditGridCell1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "start_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 110;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "end_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 110;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "infe_jaeryo";
            this.xEditGridCell5.CellWidth = 110;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.MaxDropDownItems = 50;
            this.xEditGridCell5.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "end_sayu";
            this.xEditGridCell6.CellWidth = 110;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.MaxDropDownItems = 50;
            this.xEditGridCell6.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 500;
            this.xEditGridCell7.CellName = "input_text";
            this.xEditGridCell7.CellWidth = 200;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.DisplayMemoText = true;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "tag";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "pknur1017";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // layComboSet
            // 
            this.layComboSet.ExecuteQuery = null;
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboSet.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layComboSet.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // NUR1017U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlButtom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1017U00";
            this.UserChanged += new System.EventHandler(this.NUR1017U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1017U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlButtom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1017)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 메세지 일괄 처리
        /// </summary>
        /// <param name="aMesgGubun">
        /// 메세지 구분
        /// </param>
        #region 메세지처리
        private void GetMessage(string aMesgGubun)
        {
            string msg = string.Empty;
            string caption = string.Empty;

            switch (aMesgGubun)
            {
                case "bunho":
                    msg = Resources.MSG001_MSG;
                    caption = Resources.MSG001_CAP;
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "dup_chk":
                    msg = Resources.MSG002_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "infe_code":
                    msg = Resources.MSG003_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption);
                    break;
                case "start_date":
                    msg = Resources.MSG004_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption);
                    break;
                case "end_date":
                    msg = Resources.MSG005_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption);
                    break;
                case "date_check":
                    msg = Resources.MSG006_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption);
                    break;
                case "save_true":
                    msg = Resources.MSG007_MSG;
                    caption = Resources.MSG001_CAP;
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "save_false":
                    msg = Resources.MSG008_MSG;
                    if (mErrMsg != "")
                        msg += "\r\n[" + mErrMsg + "]";
                    else if (!string.IsNullOrEmpty(Service.ErrFullMsg))
                        msg += "\r\n[" + Service.ErrFullMsg + "]";
                    caption = Resources.MSG009_MSG;
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }
        #endregion

        // <summary>
        /// 수술예약 등록 콤보박스 셋팅
        /// </summary>
        /// <param name="aComboGubun">
        /// 콤보구분
        /// </param>
        #region 콤보박스 셋팅
        private void GetComboSetting(string aComboGubun)
        {
            this.layComboSet.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layComboSet.SetBindVarValue("f_code_type", aComboGubun);

            if (this.layComboSet.QueryLayout(true))
            {
                switch (aComboGubun)
                {
                    case "INFE_CODE":
                        if (this.layComboSet.RowCount > 0)
                        {
                            this.grdNUR1017.SetComboItems("infe_code", this.layComboSet.LayoutTable, "code_name", "code");
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }
        #endregion

        #region 스크린 로드
        //		protected override void OnLoad(EventArgs e)
        //		{
        //			base.OnLoad (e);
        //			PostCallHelper.PostCall(new PostMethod(PostLoad));
        //		}
        //
        //		private void PostLoad()
        //		{
        //			/* 감염증 콤보 셋팅 */
        //			this.GetComboSetting("INFE_CODE");
        //
        //			this.CurrMILayout = this.grdNUR017;
        //			this.CurrMOLayout = this.grdNUR017;
        //
        //			if (this.OpenParam != null)
        //			{
        //				this.sysid      = OpenParam["sysid"].ToString();
        //				this.screen     = OpenParam["screen"].ToString();
        //				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
        //				this.flag = this.OpenParam["flag"].ToString();
        //			}
        //			else
        //			{
        //				//현재스크린 환자번호
        //				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
        //				if (patientInfo != null)
        //				{
        //					this.paBox.SetPatientID(patientInfo.BunHo);
        //				}
        //			}
        //		}
        //
        #endregion

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.paBox.Focus();
                this.paBox.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
            {
                return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

        #region 버튼리스트에서 버튼을 클릭을 했을 때
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    if (this.paBox.BunHo.ToString() == "")
                    {
                        this.GetMessage("bunho");
                        this.paBox.Focus();
                        e.IsBaseCall = false;
                        return;
                    }
                    break;

                case FunctionType.Close:
                    if (this.flag == "S")
                    {
                        IHIS.Framework.IXScreen aScreen;
                        aScreen = XScreen.FindScreen(sysid, screen);

                        if (aScreen == null)
                        {
                            CommonItemCollection openParams = new CommonItemCollection();
                            openParams.Add("NUR1017", "1017");

                            XScreen.OpenScreenWithParam(this, sysid, screen, IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);

                        }
                        else
                        {
                            CommonItemCollection openParams = new CommonItemCollection();
                            openParams.Add("NUR1017", "1017");
                            this.Close();
                            aScreen.Command("NUR1017U00", openParams);
                        }
                    }
                    break;

                case FunctionType.Query:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    e.IsBaseCall = false;

                    this.grdNUR1017.Reset();

                    if (this.grdNUR1017.QueryLayout(false))
                    {
                        if (this.grdNUR1017.RowCount == 0)
                        {
                            int aRow = this.grdNUR1017.InsertRow(-1);
                            this.grdNUR1017.SetItemValue(aRow, "bunho", this.paBox.BunHo.ToString());
                            this.grdNUR1017.SetItemValue(aRow, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            this.grdNUR1017.SetItemValue(aRow, "end_sayu", "02");
                        }
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return;
                    }
                    break;


                case FunctionType.Update:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    for (int i = 0; i < this.grdNUR1017.RowCount; i++)
                    {
                        if (this.grdNUR1017.GetRowState(i) == DataRowState.Added ||
                            this.grdNUR1017.GetRowState(i) == DataRowState.Modified)
                        {
                            //시작일자가 현재 일자보다 미래 일 수는 없다.
                            if (this.grdNUR1017.GetItemValue(i, "start_date").ToString() != "")
                            {
                                if (int.Parse(DateTime.Parse(this.grdNUR1017.GetItemString(i, "start_date")).ToString("yyyyMMdd")) >
                                    int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                                {
                                    e.IsBaseCall = false;
                                    this.GetMessage("date_check");
                                    this.grdNUR1017.SetFocusToItem(i, "start_date");
                                    return;
                                }
                            }

                            if (this.grdNUR1017.GetItemValue(i, "start_date").ToString() == "")
                            {
                                e.IsBaseCall = false;
                                this.GetMessage("start_date");
                                this.grdNUR1017.SetFocusToItem(i, "start_date");
                                return;
                            }

                            if (this.grdNUR1017.GetItemValue(i, "infe_code").ToString() == "")
                            {
                                e.IsBaseCall = false;
                                this.GetMessage("infe_code");
                                this.grdNUR1017.SetFocusToItem(i, "infe_code");
                                return;
                            }

                            //종료일자가 현재 일자보다 미래 일 수는 없다.
                            if (this.grdNUR1017.GetItemValue(i, "end_date").ToString() != "")
                            {
                                if (int.Parse(DateTime.Parse(this.grdNUR1017.GetItemString(i, "end_date")).ToString("yyyyMMdd")) >
                                    int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                                {
                                    e.IsBaseCall = false;
                                    this.GetMessage("date_check");
                                    this.grdNUR1017.SetFocusToItem(i, "end_date");
                                    return;
                                }
                            }
                        }
                    }

                    try
                    {
                        this.mErrMsg = "";

                        //Service.BeginTransaction();

                        //if (!this.grdNUR1017.SaveLayout())
                        //    throw new Exception();

                        //this.GetMessage("save_true");

                        //if (this.flag == "Y")
                        //{
                        //    this.flag = "S";
                        //}

                        //this.grdNUR1017.QueryLayout(false);
                        //Service.CommitTransaction();
                        List<NUR1017U00GrdNUR1017ListItemInfo> inputList = LoadDataInputList();
                        NUR1017U00SaveLayoutArgs args = new NUR1017U00SaveLayoutArgs();
                        args.UserId = UserInfo.UserID;
                        args.GrdList = inputList;

                        NUR1017U00SaveLayoutResult result =
                            CloudService.Instance.Submit<NUR1017U00SaveLayoutResult, NUR1017U00SaveLayoutArgs>(args);

                        if (result != null)
                        {
                            if (!result.SaveLayoutResult)
                                throw new Exception();

                            this.GetMessage("save_true");

                            if (this.flag == "Y")
                            {
                                this.flag = "S";
                            }

                            this.grdNUR1017.QueryLayout(false);
                        }
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        e.IsSuccess = false;
                        this.GetMessage("save_false");
                        return;
                    }
                    break;
                default:
                    break;
            }
        }



        #endregion

        #region 버튼리스트에서 버튼을 클릭을 한 후의 이벤트
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    if (this.paBox.BunHo.ToString() != "")
                    {
                        this.grdNUR1017.SetItemValue(this.grdNUR1017.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString());
                        this.grdNUR1017.SetItemValue(this.grdNUR1017.CurrentRowNumber, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        this.grdNUR1017.SetItemValue(this.grdNUR1017.CurrentRowNumber, "end_sayu", "02");
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 중복체크
        private void grdNUR017_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdNUR1017.LayoutTable.Rows[e.RowNumber].RowState;

            SingleLayout layValidationDupchk = new SingleLayout();

            layValidationDupchk.LayoutItems.Add("YorN");

            //            layValidationDupchk.QuerySQL = @"SELECT 'Y'
            //                                                  FROM DUAL
            //                                                     WHERE EXISTS (SELECT 'X'
            //                                                                     FROM NUR1017
            //                                                                    WHERE HOSP_CODE  = :f_hosp_code
            //                                                                      AND INFE_CODE  = :f_infe_code
            //                                                                      AND BUNHO      = :f_bunho
            //                                                                      AND START_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD')
            //                                                                      AND NVL(CANCEL_YN, 'N') = 'N')";

            //            layValidationDupchk.SetBindVarValue("f_infe_code", this.grdNUR1017.GetItemString(e.RowNumber, "infe_code"));
            //            layValidationDupchk.SetBindVarValue("f_infe_code", this.grdNUR1017.GetItemString(e.RowNumber, "infe_code"));
            //            layValidationDupchk.SetBindVarValue("f_bunho", this.paBox.BunHo);
            //            layValidationDupchk.SetBindVarValue("f_start_date", this.grdNUR1017.GetItemString(e.RowNumber, "start_date"));

            layValidationDupchk.ParamList = new List<string>(new String[] { "f_infe_code", "f_bunho", "f_start_date" });
            layValidationDupchk.SetBindVarValue("f_infe_code", this.grdNUR1017.GetItemString(e.RowNumber, "infe_code"));
            layValidationDupchk.SetBindVarValue("f_bunho", this.paBox.BunHo);
            layValidationDupchk.SetBindVarValue("f_start_date", this.grdNUR1017.GetItemString(e.RowNumber, "start_date"));

            layValidationDupchk.ExecuteQuery = LoadDataLayValidationDupchk;

            switch (e.ColName)
            {
                case "infe_code":
                case "start_date":
                    if (rowState == DataRowState.Added)
                    {
                        if (!layValidationDupchk.QueryLayout())
                        {
                            if (Service.ErrCode != 0)
                            {
                                XMessageBox.Show(Service.ErrFullMsg.ToString());
                                return;
                            }
                        }

                        if (!TypeCheck.IsNull(layValidationDupchk.GetItemValue("YorN")))
                        {
                            /* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
                            if (layValidationDupchk.GetItemValue("YorN").ToString() == "Y")
                            {
                                this.GetMessage("dup_chk");
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    //시작일자가 현재 일자보다 미래 일 수는 없다.
                    if (this.grdNUR1017.GetItemValue(e.RowNumber, "start_date").ToString() != "")
                    {
                        if (int.Parse(DateTime.Parse(this.grdNUR1017.GetItemString(e.RowNumber, "start_date")).ToString("yyyyMMdd")) >
                            int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                        {
                            this.GetMessage("date_check");
                            e.Cancel = true;
                            return;
                        }
                    }
                    break;
                case "end_date":
                    //종료일자가 현재 일자보다 미래 일 수는 없다.
                    if (this.grdNUR1017.GetItemValue(e.RowNumber, "end_date").ToString() != "")
                    {
                        if (int.Parse(DateTime.Parse(this.grdNUR1017.GetItemString(e.RowNumber, "end_date")).ToString("yyyyMMdd")) >
                            int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                        {
                            this.GetMessage("date_check");
                            e.Cancel = true;
                            return;
                        }
                    }
                    if (this.grdNUR1017.GetItemValue(e.RowNumber, "end_date").ToString() != "")
                    {
                        if (int.Parse(DateTime.Parse(this.grdNUR1017.GetItemValue(e.RowNumber, "end_date").ToString()).ToString("yyyyMMdd")) <
                            int.Parse(DateTime.Parse(this.grdNUR1017.GetItemValue(e.RowNumber, "start_date").ToString()).ToString("yyyyMMdd")))
                        {
                            this.GetMessage("end_date");
                            e.Cancel = true;
                            return;
                        }
                    }
                    break;
                default:
                    break;
            }
        }



        #endregion

        #region 팝업창으로 오픈이 됐을 때
        private void NUR1017U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            //tungtx
            //this.grdNUR1017.SavePerformer = new XSavePerformer(this);

            /* 감염증 콤보 셋팅 */
            //this.GetComboSetting("INFE_CODE");

            this.CurrMSLayout = this.grdNUR1017;
            this.CurrMQLayout = this.grdNUR1017;

            if (this.OpenParam != null)
            {
                if (OpenParam.Contains("sysid"))
                {
                    if (OpenParam["sysid"].ToString() != "")
                        this.sysid = OpenParam["sysid"].ToString();
                }

                if (OpenParam.Contains("screen"))
                {
                    if (OpenParam["screen"].ToString() != "")
                        this.screen = OpenParam["screen"].ToString();
                }

                if (OpenParam.Contains("bunho"))
                {
                    if (OpenParam["bunho"].ToString() != "")
                        this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
                }

                if (OpenParam.Contains("flag"))
                {
                    if (this.OpenParam["flag"].ToString() != "")
                        this.flag = this.OpenParam["flag"].ToString();
                }

                //				if(OpenParam.Contains("insert_yn"))
                //				{
                //					if(this.OpenParam["insert_yn"].ToString() != "" && this.OpenParam["insert_yn"].ToString() == "Y")
                //					{
                //						int aRow = this.grdNUR017.InsertRow(0);
                //						this.grdNUR017.SetItemValue(aRow, "bunho", this.paBox.BunHo.ToString());
                //						this.grdNUR017.SetItemValue(aRow, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                //					}
                //				}
            }
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
            }
        }
        #endregion

        #region 사용자 변경이 있을 때
        private void NUR1017U00_UserChanged(object sender, System.EventArgs e)
        {
            /* 감염증 콤보 셋팅 */
            //this.GetComboSetting("INFE_CODE");

            this.CurrMSLayout = this.grdNUR1017;
            this.CurrMQLayout = this.grdNUR1017;

            if (this.OpenParam != null)
            {
                if (OpenParam["sysid"].ToString() != "")
                    this.sysid = OpenParam["sysid"].ToString();

                if (OpenParam["screen"].ToString() != "")
                    this.screen = OpenParam["screen"].ToString();

                this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());

                if (this.OpenParam["flag"].ToString() != "")
                    this.flag = this.OpenParam["flag"].ToString();
            }
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
            }
        }
        #endregion

        #region 환자 등록번호가 입력이 됐을 때
        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.grdNUR1017.Reset();

            if (!this.grdNUR1017.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            else
            {
                if (this.grdNUR1017.RowCount == 0)
                {
                    int aRow = this.grdNUR1017.InsertRow(-1);
                    this.grdNUR1017.SetItemValue(aRow, "bunho", this.paBox.BunHo.ToString());
                    this.grdNUR1017.SetItemValue(aRow, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    this.grdNUR1017.SetItemValue(aRow, "end_sayu", "02");
                }
            }
        }
        #endregion

        #region 환자번호를 잘못 입력을 했을 때
        private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            this.grdNUR1017.Reset();
        }
        #endregion

        private void grdNUR017_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1017.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR1017.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        //tungtx
        string mErrMsg = "";

        /*#region XSavePerformer
        string mErrMsg = "";
        private class XSavePerformer : ISavePerformer
        {
            NUR1017U00 parent;

            public XSavePerformer(NUR1017U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                parent.mErrMsg = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"SELECT 'Y'
                                      FROM DUAL
                                     WHERE EXISTS (SELECT 'X'
                                                     FROM NUR1017
                                                    WHERE HOSP_CODE  = :f_hosp_code
                                                      AND INFE_CODE  = :f_infe_code
                                                      AND BUNHO      = :f_bunho
                                                      AND START_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD')
                                                      AND NVL(CANCEL_YN, 'N') = 'N')
                                                      AND INFE_CODE  <> '99'         ";

                        object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (!TypeCheck.IsNull(retVal))
                        {
                            if (retVal.ToString() == "Y")
                            {
                                cmdText = @"SELECT CODE_NAME
                                              FROM NUR0102 
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE_TYPE = 'INFE_CODE'
                                               AND CODE      = :f_infe_code";
                                object infe_name = Service.ExecuteScalar(cmdText, item.BindVarList);
                                
                                parent.mErrMsg = "「" + infe_name.ToString() + "」は既に同じ日付で登録されています。ご確認ください。";
                                return false;
                            }
                        }

                        cmdText = @"INSERT INTO NUR1017
                                         ( SYS_DATE                          
                                         , SYS_ID            
                                         , UPD_DATE                            
                                         , UPD_ID                         
                                         , HOSP_CODE
                                         , INFE_CODE                         
                                         , BUNHO              
                                         , START_DATE                          
                                         , END_DATE                          
                                         , END_SAYU           
                                         , INPUT_TEXT                          
                                         , INFE_JAERYO                       
                                         , PKNUR1017          
                                         , CANCEL_YN     )
                                    VALUES 
                                         ( SYSDATE                           
                                         , :q_user_id         
                                         , SYSDATE                          
                                         , :q_user_id                       
                                         , :f_hosp_code                            
                                         , :f_infe_code                      
                                         , :f_bunho           
                                         , TO_DATE(:f_start_date, 'YYYY/MM/DD')
                                         , TO_DATE(:f_end_date, 'YYYY/MM/DD')
                                         , :f_end_sayu        
                                         , :f_input_text                       
                                         , :f_infe_jaeryo                    
                                         , NUR1017_SEQ.NEXTVAL
                                         , 'N')";
                        break;


                    case DataRowState.Modified:

                        cmdText = @"UPDATE NUR1017
                                       SET UPD_ID      = :q_user_id,
                                           UPD_DATE    = SYSDATE,
                                           END_DATE    = :f_end_date,
                                           END_SAYU    = :f_end_sayu,
                                           INPUT_TEXT  = :f_input_text,
                                           INFE_JAERYO = :f_infe_jaeryo,
                                           CANCEL_YN   = 'N'
                                     WHERE HOSP_CODE   = :f_hosp_code
                                       AND PKNUR1017   = :f_pknur1017";
                        break;


                    case DataRowState.Deleted:

                        cmdText = @"UPDATE NUR1017
                                       SET UPD_ID      = :q_user_id,
                                           UPD_DATE    = SYSDATE,
                                           CANCEL_YN   = 'Y'
                                     WHERE HOSP_CODE   = :f_hosp_code
                                       AND PKNUR1017   = :f_pknur1017";
                        break;
                }

                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                {
                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                        parent.mErrMsg = Service.ErrFullMsg;

                    return false;
                }

                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();

                inputList.Add(item.BindVarList["f_bunho"].VarValue);
                inputList.Add(item.BindVarList["f_infe_code"].VarValue);
                inputList.Add("NUR1017");
                inputList.Add(UserInfo.UserID);

                return Service.ExecuteProcedure("PR_NUR_INFE_MAPPING", inputList, outputList);
            }
        }
        #endregion*/

        private NUR1017U00GetComboListResult LoadDataAllComboBox()
        {
            NUR1017U00GetComboListResult result = null;
            NUR1017U00GetComboListArgs args = new NUR1017U00GetComboListArgs();
            args.CodeTypeLayComboSet = "INFE_CODE";
            args.CodeTypeXEditGridCell1 = "INFE_CODE";
            args.CodeTypeXEditGridCell5 = "NUR1017_INFE_JAERYO";
            args.CodeTypeXEditGridCell6 = "NUR1017_INFE_END_SAYU";
            result =CacheService.Instance.Get<NUR1017U00GetComboListArgs, NUR1017U00GetComboListResult>(args);
            return result;
        }

        private IList<object[]> LoadDataGrdNUR1017(BindVarCollection varlist)
        {
            List<object[]> dataList = new List<object[]>();
            NUR1017U00GrdNUR1017Args args = new NUR1017U00GrdNUR1017Args();
            args.Bunho = paBox.BunHo;
            if (args.Bunho == null)
            {
                return dataList;
            }

            NUR1017U00GrdNUR1017Result result =
                CloudService.Instance.Submit<NUR1017U00GrdNUR1017Result, NUR1017U00GrdNUR1017Args>(args);
            if (result != null)
            {
                List<NUR1017U00GrdNUR1017ListItemInfo> grdList = result.GrdNUR1017List;
                foreach (NUR1017U00GrdNUR1017ListItemInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.InfeCode,
                        info.Bunho,
                        info.StartDate,
                        info.EndDate,
                        info.InfeJaeryo,
                        info.EndSayu,
                        info.InputText,
                        info.YValue,
                        info.Pknur1017

                    });
                }
            }
            return dataList;
        }

        private void grdNUR1017_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell1.ExecuteQuery = GetDataXEditGridCell1;
            this.xEditGridCell5.ExecuteQuery = GetDataXEditGridCell5;
            this.xEditGridCell6.ExecuteQuery = GetDataXEditGridCell6;

        }

        private IList<object[]> GetDataXEditGridCell6(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            List<ComboListItemInfo> cboList = cboResult.XEditGridCell6List;
            if (cboList != null)
            {
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return dataList;
        }

        private IList<object[]> GetDataXEditGridCell5(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            List<ComboListItemInfo> cboList = cboResult.XEditGridCell5List;
            if (cboList != null)
            {
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return dataList;
        }

        private IList<object[]> GetDataXEditGridCell1(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            List<ComboListItemInfo> cboList = cboResult.XEditGridCell1List;
            if (cboList != null)
            {
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return dataList;
        }
        private IList<object[]> LoadDataLayComboSet(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            List<ComboListItemInfo> cboList = cboResult.LayComboSetList;
            if (cboList != null)
            {
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return dataList;
        }

        private IList<object[]> LoadDataLayValidationDupchk(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            NUR1017U00LayValidationDupchkArgs args = new NUR1017U00LayValidationDupchkArgs();
            args.Bunho = varlist["f_bunho"].VarValue;
            args.InfeCode = varlist["f_infe_code"].VarValue;
            args.StartDate = varlist["f_start_date"].VarValue;

            NUR1017U00LayValidationDupchkResult result =
                CloudService.Instance
                    .Submit<NUR1017U00LayValidationDupchkResult, NUR1017U00LayValidationDupchkArgs>(
                        args);
            if (result != null)
            {
                string ynResult = result.YValue;
                dataList.Add(new object[]
                {
                    ynResult
                });
            }
            return dataList;
        }

        private List<NUR1017U00GrdNUR1017ListItemInfo> LoadDataInputList()
        {
            List<NUR1017U00GrdNUR1017ListItemInfo> dataList = new List<NUR1017U00GrdNUR1017ListItemInfo>();

            for (int i = 0; i < grdNUR1017.RowCount; i++)
            {
                NUR1017U00GrdNUR1017ListItemInfo info = new NUR1017U00GrdNUR1017ListItemInfo();
                info.Bunho = grdNUR1017.GetItemString(i, "bunho");
                info.EndDate = grdNUR1017.GetItemString(i, "end_date");
                info.StartDate = grdNUR1017.GetItemString(i, "start_date");
                info.InfeCode = grdNUR1017.GetItemString(i, "infe_code");
                info.InfeJaeryo = grdNUR1017.GetItemString(i, "infe_jaeryo");
                info.EndSayu = grdNUR1017.GetItemString(i, "end_sayu");
                info.InputText = grdNUR1017.GetItemString(i, "input_text");
                info.Pknur1017 = grdNUR1017.GetItemString(i, "pknur1017");
                info.YValue = grdNUR1017.GetItemString(i, "tag");

                info.RowState = grdNUR1017.GetRowState(i).ToString();
                dataList.Add(info);
            }

            if (grdNUR1017.DeletedRowTable != null && grdNUR1017.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdNUR1017.DeletedRowTable.Rows)
                {
                    NUR1017U00GrdNUR1017ListItemInfo info = new NUR1017U00GrdNUR1017ListItemInfo();
                    info.Bunho = row["bunho"].ToString();
                    info.EndDate = row["end_date"].ToString();
                    info.StartDate = row["start_date"].ToString();
                    info.InfeCode = row["infe_code"].ToString();
                    info.InfeJaeryo = row["infe_jaeryo"].ToString();
                    info.EndSayu = row["end_sayu"].ToString();
                    info.InputText = row["input_text"].ToString();
                    info.Pknur1017 = row["pknur1017"].ToString();
                    info.YValue = row["tag"].ToString();

                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }

            return dataList;
        }
    }
}

