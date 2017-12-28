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
using IHIS.CloudConnector.Contracts.Models.Nuri;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuri;
using IHIS.Framework;
using IHIS.NURI.Properties;

#endregion

namespace IHIS.NURI
{
    /// <summary>
    /// NUR1016U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class NUR1016U00 : IHIS.Framework.XScreen
    {
        #region 추가사항
        private string sysid = string.Empty;
        private string screen = string.Empty;
        private string flag = "N";
        #endregion

        #region 자동생성
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdNUR1016;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.MultiLayout layComboSet;
        private IHIS.Framework.SingleLayout layPknur1016Query;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private SingleLayoutItem singleLayoutItem1;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;

        private NUR1016U00GetComboListResult cboResult;
        private const string CACHE_NUR1016U00_COMBO_LIST_ITEM_KEYS = "NURI.Nur1016U00.CboListItem";
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region 생성자
        public NUR1016U00()
        {

            //tungtx
            cboResult = LoadDataAllComboBox();

            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.grdNUR1016.ParamList = new List<string>(new string[] { "f_hosp_code", "f_bunho" });
            this.grdNUR1016.ExecuteQuery = LoadDataGrdNUR1016;

            this.layComboSet.ParamList = new List<string>(new string[] { "f_hosp_code", "f_code_type" });
            this.layComboSet.ExecuteQuery = LoadDataLayComboSet;

            this.layPknur1016Query.ExecuteQuery = LoadDataLayPknur1016Query;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1016U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdNUR1016 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.layPknur1016Query = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1016)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Name = "pnlTop";
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdNUR1016);
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Name = "pnlFill";
            // 
            // grdNUR1016
            // 
            this.grdNUR1016.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdNUR1016.ColPerLine = 6;
            this.grdNUR1016.Cols = 7;
            resources.ApplyResources(this.grdNUR1016, "grdNUR1016");
            this.grdNUR1016.ExecuteQuery = null;
            this.grdNUR1016.FixedCols = 1;
            this.grdNUR1016.FixedRows = 1;
            this.grdNUR1016.FocusColumnName = "allergy_gubun";
            this.grdNUR1016.HeaderHeights.Add(25);
            this.grdNUR1016.Name = "grdNUR1016";
            this.grdNUR1016.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNUR1016.ParamList")));
            this.grdNUR1016.QuerySQL = resources.GetString("grdNUR1016.QuerySQL");
            this.grdNUR1016.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdNUR1016.RowHeaderVisible = true;
            this.grdNUR1016.Rows = 2;
            this.grdNUR1016.ToolTipActive = true;
            this.grdNUR1016.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR1016_GridColumnChanged);
            this.grdNUR1016.PreEndInitializing += new System.EventHandler(this.grdNUR1016_PreEndInitializing);
            this.grdNUR1016.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1016_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pknur1016";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
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
            this.xEditGridCell3.CellName = "allergy_gubun";
            this.xEditGridCell3.CellWidth = 90;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.MaxDropDownItems = 50;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 200;
            this.xEditGridCell4.CellName = "allergy_info";
            this.xEditGridCell4.CellWidth = 310;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "start_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 108;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "end_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 108;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "end_sayu";
            this.xEditGridCell7.CellWidth = 100;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 1000;
            this.xEditGridCell8.CellName = "input_text";
            this.xEditGridCell8.CellWidth = 200;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.DisplayMemoText = true;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "tag";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // layPknur1016Query
            // 
            this.layPknur1016Query.ExecuteQuery = null;
            this.layPknur1016Query.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layPknur1016Query.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPknur1016Query.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "pknur1016";
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
            // NUR1016U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            resources.ApplyResources(this, "$this");
            this.Name = "NUR1016U00";
            this.UserChanged += new System.EventHandler(this.NUR1016U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1016U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1016)).EndInit();
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
                case "allergy_gubun":
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
                case "max_length":
                    msg = Resources.MSG008_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "save_false":
                    msg = Resources.MSG009_MSG;
                    if (mErrMsg != "")
                        msg += "\r\n[" + mErrMsg + "]";
                    else
                        msg += "\r\n[" + Service.ErrFullMsg + "]";

                    caption = Resources.MSG009_CAP;
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
                    case "ALLERGY_GUBUN":
                        if (this.layComboSet.LayoutTable.Rows.Count > 0)
                        {
                            this.grdNUR1016.SetComboItems("allergy_gubun", this.layComboSet.LayoutTable, "code_name", "code");
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
        }
        #endregion

        #region Screen Load
        private void NUR1016U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            //tungtx
            //this.grdNUR1016.SavePerformer = new XSavePerformer(this);

            this.GetComboSetting("ALLERGY_GUBUN");

            this.CurrMSLayout = this.grdNUR1016;
            this.CurrMQLayout = this.grdNUR1016;

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
                //						int aRow = this.grdNUR1016.InsertRow(0);
                //
                //						if(this.DataServiceCall(this.layPknur1016Query))
                //						{
                //							this.grdNUR1016.SetItemValue(aRow, "pknur1016", this.layPknur1016Query.GetOutValue("pknur1016"));
                //							this.grdNUR1016.SetItemValue(aRow, "bunho", this.paBox.BunHo.ToString());
                //							this.grdNUR1016.SetItemValue(aRow, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                //						}
                //						else
                //						{
                //							XMessageBox.Show(this.layPknur1016Query.ErrFullMsg.ToString());
                //							return;
                //						}
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

        #region 사용자 변경이 있을 때
        private void NUR1016U00_UserChanged(object sender, System.EventArgs e)
        {
            //			this.CurrMILayout = this.grdNUR1016;
            //			this.CurrMOLayout = this.grdNUR1016;
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
        }
        #endregion

        #region 버튼리스트에서 클릭을 했을 때의 이벤트
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


                case FunctionType.Update:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    e.IsBaseCall = false;
                    e.IsSuccess = true;

                    for (int i = 0; i < this.grdNUR1016.RowCount; i++)
                    {
                        if (this.grdNUR1016.GetRowState(i) == DataRowState.Added ||
                            this.grdNUR1016.GetRowState(i) == DataRowState.Modified)
                        {
                            //시작일자가 현재 일자보다 미래 일 수는 없다.
                            if (this.grdNUR1016.GetItemValue(i, "start_date").ToString() != "")
                            {
                                if (int.Parse(DateTime.Parse(this.grdNUR1016.GetItemString(i, "start_date")).ToString("yyyyMMdd")) >
                                    int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                                {
                                    e.IsBaseCall = false;
                                    this.GetMessage("date_check");
                                    this.grdNUR1016.SetFocusToItem(i, "start_date");
                                    return;
                                }
                            }

                            if (this.grdNUR1016.GetItemValue(i, "start_date").ToString() == "")
                            {
                                e.IsBaseCall = false;
                                this.GetMessage("start_date");
                                this.grdNUR1016.SetFocusToItem(i, "start_date");
                                return;
                            }

                            if (this.grdNUR1016.GetItemValue(i, "allergy_gubun").ToString() == "")
                            {
                                e.IsBaseCall = false;
                                this.GetMessage("allergy_gubun");
                                this.grdNUR1016.SetFocusToItem(i, "allergy_gubun");
                                return;
                            }

                            //종료일자가 현재 일자보다 미래 일 수는 없다.
                            if (this.grdNUR1016.GetItemValue(i, "end_date").ToString() != "")
                            {
                                if (int.Parse(DateTime.Parse(this.grdNUR1016.GetItemString(i, "end_date")).ToString("yyyyMMdd")) >
                                    int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                                {
                                    e.IsBaseCall = false;
                                    this.GetMessage("date_check");
                                    this.grdNUR1016.SetFocusToItem(i, "end_date");
                                    return;
                                }
                            }
                        }
                    }

                    try
                    {
                        this.mErrMsg = "";

                        //Service.BeginTransaction();

                        //if (!this.grdNUR1016.SaveLayout())
                        //{
                        //    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                        //        throw new Exception();
                        //}

                        //ArrayList inputList = new ArrayList();
                        //ArrayList outputList = new ArrayList();

                        //inputList.Add(this.paBox.BunHo);
                        //inputList.Add("NUR1016");
                        //inputList.Add(UserInfo.UserID);

                        //if (!Service.ExecuteProcedure("PR_NUR_ALERGY_MAPPING", inputList, outputList))
                        //    throw new Exception();

                        //this.GetMessage("save_true");

                        //if (this.flag == "Y")
                        //{
                        //    this.flag = "S";
                        //}

                        //this.grdNUR1016.QueryLayout(false);
                        //Service.CommitTransaction();


                        //tungtx
                        List<NUR1016U00GrdNUR1016ListItemInfo> inputList = LoadInputListFromGridView();
                        if (inputList.Count > 0)
                        {
                            NUR1016U00PrNurAlergyMappingArgs args = new NUR1016U00PrNurAlergyMappingArgs();
                            args.GrdNUR1016List = inputList;
                            args.Bunho = this.paBox.BunHo;
                            args.TableId = "NUR1016";
                            args.UserId = UserInfo.UserID;

                            NUR1016U00PrNurAlergyMappingResult result =
                                CloudService.Instance
                                    .Submit<NUR1016U00PrNurAlergyMappingResult, NUR1016U00PrNurAlergyMappingArgs>(args);
                            if (result != null)
                            {
                                if (!result.SaveLayoutResult)
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                        throw new Exception();
                                }
                                if (result.PrResult == null)
                                {
                                    throw new Exception();
                                }
                                this.GetMessage("save_true");

                                if (this.flag == "Y")
                                {
                                    this.flag = "S";
                                }

                                this.grdNUR1016.QueryLayout(false);
                            }
                        }
                        else
                        {
                            this.GetMessage("save_true");

                        }
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        e.IsSuccess = false;
                        this.GetMessage("save_false");
                        return;
                    }


                    break;


                case FunctionType.Query:

                    if (this.paBox.BunHo == "")
                        return;

                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    e.IsBaseCall = false;

                    this.grdNUR1016.Reset();

                    if (this.grdNUR1016.QueryLayout(false))
                    {
                        if (this.grdNUR1016.RowCount == 0)
                        {
                            if (this.layPknur1016Query.QueryLayout())
                            {
                                int aRow = this.grdNUR1016.InsertRow(-1);
                                this.grdNUR1016.SetItemValue(aRow, "pknur1016", this.layPknur1016Query.GetItemValue("pknur1016"));
                                this.grdNUR1016.SetItemValue(aRow, "bunho", this.paBox.BunHo.ToString());
                                this.grdNUR1016.SetItemValue(aRow, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                this.grdNUR1016.SetItemValue(aRow, "end_sayu", "02");
                            }
                            else
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }
                        }
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
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
                            openParams.Add("NUR1016", "1016");

                            XScreen.OpenScreenWithParam(this, sysid, screen, IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);

                        }
                        else
                        {
                            CommonItemCollection openParams = new CommonItemCollection();
                            openParams.Add("NUR1016", "1016");
                            this.Close();
                            aScreen.Command("NUR1016U00", openParams);
                        }
                    }
                    break;
                default:
                    break;
            }
        }



        #endregion

        #region 버튼리스트에서 클릭을 한 후의 이벤트
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    if (this.paBox.BunHo.ToString() != "")
                    {
                        if (this.layPknur1016Query.QueryLayout())
                        {
                            this.grdNUR1016.SetItemValue(this.grdNUR1016.CurrentRowNumber, "pknur1016", this.layPknur1016Query.GetItemValue("pknur1016"));
                            this.grdNUR1016.SetItemValue(this.grdNUR1016.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString());
                            this.grdNUR1016.SetItemValue(this.grdNUR1016.CurrentRowNumber, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            this.grdNUR1016.SetItemValue(this.grdNUR1016.CurrentRowNumber, "end_sayu", "02");
                        }
                        else
                        {
                            XMessageBox.Show("layPknur1016Query query error.");
                            return;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 중복체크
        private void grdNUR1016_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdNUR1016.LayoutTable.Rows[e.RowNumber].RowState;

            SingleLayout layValidationDupchk = new SingleLayout();

            layValidationDupchk.LayoutItems.Add("YorN");

            //            layValidationDupchk.QuerySQL = @"SELECT 'Y'
            //                                              FROM DUAL
            //                                             WHERE EXISTS (SELECT 'X'
            //                                                             FROM NUR1016
            //                                                            WHERE HOSP_CODE     = :f_hosp_code
            //                                                              AND BUNHO         = :f_bunho
            //                                                              AND ALLERGY_GUBUN = :f_allergy_gubun
            //                                                              AND START_DATE    = TO_DATE(:f_start_date, 'YYYY/MM/DD')
            //                                                              AND NVL(CANCEL_YN, 'N') = 'N'  
            //                                                              )";

            //            layValidationDupchk.SetBindVarValue("f_pknur1016"    , this.grdNUR1016.GetItemValue(e.RowNumber, "pknur1016").ToString());
            //            layValidationDupchk.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());
            //            layValidationDupchk.SetBindVarValue("f_allergy_gubun", this.grdNUR1016.GetItemValue(e.RowNumber, "allergy_gubun").ToString());
            //            layValidationDupchk.SetBindVarValue("f_start_date", this.grdNUR1016.GetItemValue(e.RowNumber, "start_date").ToString());


            //tungtx
            layValidationDupchk.ParamList = new List<string>(new String[] { "f_pknur1016", "f_bunho", "f_allergy_gubun", "f_start_date" });
            layValidationDupchk.SetBindVarValue("f_pknur1016", this.grdNUR1016.GetItemValue(e.RowNumber, "pknur1016").ToString());
            layValidationDupchk.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());
            layValidationDupchk.SetBindVarValue("f_allergy_gubun", this.grdNUR1016.GetItemValue(e.RowNumber, "allergy_gubun").ToString());
            layValidationDupchk.SetBindVarValue("f_start_date", this.grdNUR1016.GetItemValue(e.RowNumber, "start_date").ToString());

            layValidationDupchk.ExecuteQuery = LoadDataLayValidationDupchk;

            switch (e.ColName)
            {
                case "allergy_info":
                    if (this.grdNUR1016.GetItemValue(e.RowNumber, "allergy_info").ToString().Length > 27)
                    {
                        this.GetMessage("max_length");
                        e.Cancel = true;
                        return;
                    }
                    break;
                case "allergy_gubun":
                case "start_date":
                    if (rowState == DataRowState.Added)
                    {
                        if (layValidationDupchk.QueryLayout())
                        {
                        }
                        else
                        {
                            if (Service.ErrCode != 0)
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
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
                    if (this.grdNUR1016.GetItemValue(e.RowNumber, "start_date").ToString() != "")
                    {
                        if (int.Parse(DateTime.Parse(this.grdNUR1016.GetItemValue(e.RowNumber, "start_date").ToString()).ToString("yyyyMMdd")) >
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
                    if (this.grdNUR1016.GetItemValue(e.RowNumber, "end_date").ToString() != "")
                    {
                        if (int.Parse(DateTime.Parse(this.grdNUR1016.GetItemValue(e.RowNumber, "end_date").ToString()).ToString("yyyyMMdd")) >
                            int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                        {
                            this.GetMessage("date_check");
                            e.Cancel = true;
                            return;
                        }
                    }
                    if (this.grdNUR1016.GetItemValue(e.RowNumber, "end_date").ToString() != "")
                    {
                        if (int.Parse(DateTime.Parse(this.grdNUR1016.GetItemValue(e.RowNumber, "end_date").ToString()).ToString("yyyyMMdd")) <
                            int.Parse(DateTime.Parse(this.grdNUR1016.GetItemValue(e.RowNumber, "start_date").ToString()).ToString("yyyyMMdd")))
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



        #region 환자번호를 입력을 했을 때
        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.grdNUR1016.Reset();

            if (this.grdNUR1016.QueryLayout(false))
            {
                if (this.grdNUR1016.RowCount == 0)
                {
                    if (this.layPknur1016Query.QueryLayout())
                    {
                        int aRow = this.grdNUR1016.InsertRow(-1);
                        this.grdNUR1016.SetItemValue(aRow, "pknur1016", this.layPknur1016Query.GetItemValue("pknur1016"));
                        this.grdNUR1016.SetItemValue(aRow, "bunho", this.paBox.BunHo.ToString());
                        this.grdNUR1016.SetItemValue(aRow, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        this.grdNUR1016.SetItemValue(aRow, "end_sayu", "02");
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return;
                    }
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }
        #endregion

        #region 환자번호를 잘못 입력을 했을 때
        private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            this.grdNUR1016.Reset();
        }
        #endregion

        private void grdNUR1016_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1016.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR1016.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }


        //tungtx
        string mErrMsg = "";

        /*   #region
           string mErrMsg = "";
           private class XSavePerformer : ISavePerformer
           {
               NUR1016U00 parent;

               public XSavePerformer(NUR1016U00 parent)
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
   //                        cmdText = @"SELECT 'Y'
   //                                      FROM DUAL
   //                                     WHERE EXISTS (SELECT 'X'
   //                                                     FROM NUR1016
   //                                                    WHERE HOSP_CODE     = :f_hosp_code
   //                                                      AND BUNHO         = :f_bunho
   //                                                      AND ALLERGY_GUBUN = :f_allergy_gubun
   //                                                      AND START_DATE    = TO_DATE(:f_start_date, 'YYYY/MM/DD')
   //                                                      AND NVL(CANCEL_YN, 'N') = 'N')";

   //                        object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                        
   //                        if (!TypeCheck.IsNull(retVal))
   //                        {
   //                            if (retVal.ToString() == "Y")
   //                            {
   //                                parent.mErrMsg = "「" + item.BindVarList["f_allergy_gubun"].VarValue + "」は既に同じ日付で登録されています。ご確認ください。";
   //                                return false;
   //                            }
   //                        }

                           cmdText = @"INSERT INTO NUR1016
                                            ( SYS_DATE         
                                            , SYS_ID                              
                                            , UPD_DATE         
                                            , UPD_ID            
                                            , HOSP_CODE
                                            , PKNUR1016        
                                            , BUNHO                               
                                            , ALLERGY_GUBUN    
                                            , ALLERGY_INFO     
                                            , START_DATE       
                                            , END_DATE
                                            , END_SAYU         
                                            , INPUT_TEXT                          
                                            , CANCEL_YN        )
                                       VALUES 
                                            ( SYSDATE          
                                            , :q_user_id                          
                                            , SYSDATE          
                                            , :q_user_id        
                                            , :f_hosp_code
                                            , :f_pknur1016     
                                            , :f_bunho                            
                                            , :f_allergy_gubun 
                                            , :f_allergy_info  
                                            , TO_DATE(:f_start_date, 'YYYY/MM/DD')
                                            , TO_DATE(:f_end_date, 'YYYY/MM/DD')
                                            , :f_end_sayu      
                                            , :f_input_text                       
                                            , 'N'              )";
                           break;


                       case DataRowState.Modified:

                           cmdText = @"UPDATE NUR1016
                                          SET UPD_ID        = :q_user_id,
                                              UPD_DATE      = SYSDATE,
                                              ALLERGY_INFO  = :f_allergy_info,
                                              END_DATE      = TO_DATE(:f_end_date, 'YYYY/MM/DD'),
                                              END_SAYU      = :f_end_sayu,
                                              INPUT_TEXT    = :f_input_text,
                                              CANCEL_YN     = 'N'
                                        WHERE HOSP_CODE     = :f_hosp_code
                                          AND PKNUR1016     = :f_pknur1016
                                          AND BUNHO         = :f_bunho
                                          AND ALLERGY_GUBUN = :f_allergy_gubun
                                          AND START_DATE    = :f_start_date";
                           break;


                       case DataRowState.Deleted:

                           cmdText = @"UPDATE NUR1016
                                          SET UPD_ID        = :q_user_id,
                                              UPD_DATE      = SYSDATE,
                                              CANCEL_YN     = 'Y'
                                        WHERE HOSP_CODE     = :f_hosp_code
                                          AND PKNUR1016     = :f_pknur1016
                                          AND BUNHO         = :f_bunho
                                          AND ALLERGY_GUBUN = :f_allergy_gubun
                                          AND START_DATE    = :f_start_date";
                           break;
                   }

                   return Service.ExecuteNonQuery(cmdText, item.BindVarList);
               }
           }
           #endregion*/

        private void grdNUR1016_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell7.ExecuteQuery = CreateCboXEditGridCell;
        }

        private IList<object[]> CreateCboXEditGridCell(BindVarCollection bindVarCollection)
        {
            IList<object[]> dataList = new List<object[]>();
            List<ComboListItemInfo> cboList = cboResult.XEditGridCell7List;
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


        private IList<object[]> LoadDataGrdNUR1016(BindVarCollection varlist)
        {
            List<object[]> dataList = new List<object[]>();
            NUR1016U00GrdNUR1016Args args = new NUR1016U00GrdNUR1016Args();
            args.Bunho = varlist["f_bunho"].VarValue;
            if (args.Bunho == null)
            {
                return dataList;
            }
            NUR1016U00GrdNUR1016Result result =
                CloudService.Instance.Submit<NUR1016U00GrdNUR1016Result, NUR1016U00GrdNUR1016Args>(args);
            if (result != null)
            {
                List<NUR1016U00GrdNUR1016ListItemInfo> grdList = result.GrdNUR1016List;
                foreach (NUR1016U00GrdNUR1016ListItemInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.Pknur1016,
                        info.Bunho,
                        info.AllergyGubun,
                        info.AllergyInfo,
                        info.StartDate,
                        info.EndDate,
                        info.EndSayu,
                        info.InputText,
                        info.YValue
                    });
                }
            }
            return dataList;
        }

        private NUR1016U00GetComboListResult LoadDataAllComboBox()
        {
            NUR1016U00GetComboListResult result = null;
            NUR1016U00GetComboListArgs args = new NUR1016U00GetComboListArgs();
            args.CodeTypeLayComboSet = "ALLERGY_GUBUN";

            result =
                CacheService.Instance.Get<NUR1016U00GetComboListArgs, NUR1016U00GetComboListResult>(args, delegate(NUR1016U00GetComboListResult listResult)
                    {
                        return listResult != null && listResult.ExecutionStatus == ExecutionStatus.Success &&
                               listResult.LayComboSetList != null && listResult.LayComboSetList.Count > 0;
                    });
            return result;
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

        private IList<object[]> LoadDataLayPknur1016Query(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            NUR1016U00SelectNextValArgs args = new NUR1016U00SelectNextValArgs();
            NUR1016U00SelectNextValResult result =
                CloudService.Instance.Submit<NUR1016U00SelectNextValResult, NUR1016U00SelectNextValArgs>(args);
            if (result != null)
            {
                string nextVal = result.NextVal;
                dataList.Add(new object[]
                {
                    nextVal
                });
            }
            return dataList;
        }

        private IList<object[]> LoadDataLayValidationDupchk(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            NuriNUR1016U00ValidationDuplicateCheckArgs args = new NuriNUR1016U00ValidationDuplicateCheckArgs();
            args.AllergyGubun = varlist["f_allergy_gubun"].VarValue;
            args.Bunho = varlist["f_bunho"].VarValue;
            args.StartDate = varlist["f_start_date"].VarValue;

            NuriNUR1016U00ValidationDuplicateCheckResult result =
                CloudService.Instance
                    .Submit<NuriNUR1016U00ValidationDuplicateCheckResult, NuriNUR1016U00ValidationDuplicateCheckArgs>(
                        args);
            if (result != null)
            {
                string ynResult = result.Result;
                dataList.Add(new object[]
                {
                    ynResult
                });
            }
            return dataList;
        }

        private List<NUR1016U00GrdNUR1016ListItemInfo> LoadInputListFromGridView()
        {
            List<NUR1016U00GrdNUR1016ListItemInfo> dataList = new List<NUR1016U00GrdNUR1016ListItemInfo>();

            for (int i = 0; i < grdNUR1016.RowCount; i++)
            {
                if (grdNUR1016.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                NUR1016U00GrdNUR1016ListItemInfo info = new NUR1016U00GrdNUR1016ListItemInfo();
                info.AllergyGubun = grdNUR1016.GetItemString(i, "allergy_gubun");
                info.AllergyInfo = grdNUR1016.GetItemString(i, "allergy_info");
                info.Bunho = grdNUR1016.GetItemString(i, "bunho");
                info.EndDate = grdNUR1016.GetItemString(i, "end_date");
                info.EndSayu = grdNUR1016.GetItemString(i, "end_sayu");
                info.InputText = grdNUR1016.GetItemString(i, "input_text");
                info.Pknur1016 = grdNUR1016.GetItemString(i, "pknur1016");
                info.StartDate = grdNUR1016.GetItemString(i, "start_date");
                info.YValue = grdNUR1016.GetItemString(i, "tag");

                info.RowState = grdNUR1016.GetRowState(i).ToString();



                dataList.Add(info);
            }

            if (grdNUR1016.DeletedRowTable != null && grdNUR1016.DeletedRowTable.Rows.Count > 0)
            {


                foreach (DataRow row in grdNUR1016.DeletedRowTable.Rows)
                {
                    NUR1016U00GrdNUR1016ListItemInfo info = new NUR1016U00GrdNUR1016ListItemInfo();
                    info.AllergyGubun = row["allergy_gubun"].ToString();
                    info.AllergyInfo = row["allergy_info"].ToString();
                    info.Bunho = row["bunho"].ToString();
                    info.EndDate = row["end_date"].ToString();
                    info.EndSayu = row["end_sayu"].ToString();
                    info.InputText = row["input_text"].ToString();
                    info.Pknur1016 = row["pknur1016"].ToString();
                    info.StartDate = row["start_date"].ToString();
                    info.YValue = row["tag"].ToString();

                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }
            return dataList;
        }
    }
}

