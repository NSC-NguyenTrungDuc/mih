#region 사용 NameSpace 지정
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments;
using IHIS.CloudConnector.Contracts.Arguments.Invs;
using IHIS.CloudConnector.Contracts.Models.Invs;
using IHIS.CloudConnector.Contracts.Results.Invs;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.INVS.Properties;
using IHIS.CloudConnector.Contracts.Models.System;
#endregion

namespace IHIS.INVS
{
    /// <summary>
    /// INV0101U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class INV0101U01 : IHIS.Framework.XScreen
    {
        #region [자동 생성 코드]

        #region 컨트롤 변수
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XEditGrid grdDetail;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XComboBox cboCdty;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XLabel lblCode_type;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlLeft;
        private IHIS.Framework.XPanel pnlFill;
        private MultiLayout layComboItems;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region 생성자
        public INV0101U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            grdMaster.ExecuteQuery = LoadGrdMaster;
            grdDetail.ExecuteQuery = LoadGrdDetail;

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

        #region 디자인 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV0101U01));
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.cboCdty = new IHIS.Framework.XComboBox();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.lblCode_type = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.layComboItems = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layComboItems)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell6});
            this.grdMaster.ColPerLine = 3;
            this.grdMaster.Cols = 4;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.FocusColumnName = "code_type";
            this.grdMaster.HeaderHeights.Add(22);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grd_SaveEnd);
            this.grdMaster.PreEndInitializing += new System.EventHandler(this.grdMaster_PreEndInitializing);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 160;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 181;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "admin_gubun";
            this.xEditGridCell6.CellWidth = 101;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell6.UserSQL = resources.GetString("xEditGridCell6.UserSQL");
            // 
            // grdDetail
            // 
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell3});
            this.grdDetail.ColPerLine = 3;
            this.grdDetail.Cols = 4;
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.FocusColumnName = "code";
            this.grdDetail.HeaderHeights.Add(23);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.QuerySQL = resources.GetString("grdDetail.QuerySQL");
            this.grdDetail.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grd_SaveEnd);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 125;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 259;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sort_key";
            this.xEditGridCell7.CellWidth = 115;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.blsButton_ButtonClick);
            // 
            // cboCdty
            // 
            resources.ApplyResources(this.cboCdty, "cboCdty");
            this.cboCdty.Name = "cboCdty";
            this.cboCdty.SelectedIndexChanged += new System.EventHandler(this.cboCdty_SelectedIndexChanged);
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.lblCode_type);
            this.pnlTop.Controls.Add(this.cboCdty);
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Name = "pnlTop";
            // 
            // lblCode_type
            // 
            this.lblCode_type.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblCode_type.EdgeRounding = false;
            resources.ApplyResources(this.lblCode_type, "lblCode_type");
            this.lblCode_type.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblCode_type.Name = "lblCode_type";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdMaster);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdDetail);
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Name = "pnlFill";
            // 
            // layComboItems
            // 
            this.layComboItems.ExecuteQuery = null;
            this.layComboItems.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboItems.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layComboItems.ParamList")));
            this.layComboItems.QuerySQL = "SELECT NVL(CODE_TYPE, \' \')      CODE_TYPE,\r\n       NVL(CODE_TYPE_NAME, \' \') CODE_" +
                "TYPE_NAME\r\n  FROM INV0101\r\n WHERE HOSP_CODE = :f_hosp_code\r\n ORDER BY 1";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code_type";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_type_name";
            // 
            // INV0101U01
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            resources.ApplyResources(this, "$this");
            this.Name = "INV0101U01";
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layComboItems)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        #region [APL 초기설정 코드]
        private string mHospCode = "";
        protected override void OnLoad(EventArgs e)
        {
            mHospCode = EnvironInfo.HospCode;
            base.OnLoad(e);

            // SaveLayout 설정
            this.SaveLayoutList.Add(this.grdMaster);
            this.SaveLayoutList.Add(this.grdDetail);

            // 그리드 SavePerformer 설정
            //this.grdMaster.SavePerformer = new XSavePerformer(this);
            this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            // 마스터-디테일 관계 설정
            this.grdDetail.SetRelationKey("code_type", "code_type");
            this.grdDetail.SetRelationTable("INV0102");

            this.CurrMSLayout = this.grdMaster;

            // 코드유형 콤보박스 설정
            this.ComboSetting();

            // 코드유형에 따른 마스터 그리드 설정
            this.grdMaster.QueryLayout(false);

            if (EnvironInfo.CurrSystemID == "DRGS")
            {
                this.cboCdty.Enabled = false;
                this.cboCdty.SetEditValue("SPECIALDRUG");
                this.cboCdty.AcceptData();
            }
        }
        #endregion

        #region [메세지 처리 코드]

        private void ShowMessage(string separation)
        {
            string msg = string.Empty;
            string cpt = string.Empty;

            switch (separation)
            {
                case "MasterInsert":
                    //msg = "新たに入力された行があります。先に保存をしてください。";
                    //cpt = "お知らせ";
                    msg = Resources.MSG_1;
                    cpt = Resources.CAP_1;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailInsert":
                    //msg = "コード入力するには\n先にコード類型を登録する必要があります。";
                    //cpt = "コード類型入力確認";
                    msg = Resources.MSG_2;
                    cpt = Resources.CAP_2;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDeleteGrid":
                    //msg = String.Format("[{0}]は詳細コードを持っています。\nこのコード類型を削除するには先に詳細コードを削除してください。",
                    //                     grdMaster[grdMaster.CurrentRowNumber, "code_type"].Value.ToString());
                    //cpt = "確認";
                    msg = String.Format(Resources.MSG_3, grdMaster[grdMaster.CurrentRowNumber, "code_type"].Value.ToString());
                    cpt = Resources.CAP_3;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDeleteDB":
                    //msg = "細部内訳があり、削除することができません。\n細部内訳を消してから保存してください。";
                    //cpt = "確認";
                    msg = Resources.MSG_4;
                    cpt = Resources.CAP_4;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDup":
                    //msg = String.Format("[{0}]は既に存在しているコード類型です。他のコード類型を入力してください。",
                    //                     grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
                    //cpt = "確認";
                    msg = String.Format(Resources.MSG_5, grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
                    cpt = Resources.CAP_5;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailDup":
                    //msg = String.Format("[{0}]は既に存在しているコード類型です。他のコード類型を入力してください。",
                    //                     grdDetail.GetItemValue(grdDetail.CurrentRowNumber, "code").ToString());
                    //cpt = "確認";
                    msg = String.Format(Resources.MSG_6, grdDetail.GetItemValue(grdDetail.CurrentRowNumber, "code").ToString());
                    cpt = Resources.CAP_6;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterCodeTypeNull":
                    //msg = "コード類型を入力してくだたい。";
                    //cpt = "確認";
                    msg = Resources.MSG_7;
                    cpt = Resources.CAP_7;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterCodeTypeNameNull":
                    //msg = "コード類型名称を入力してくだたい。";
                    //cpt = "確認";
                    msg = Resources.MSG_8;
                    cpt = Resources.CAP_8;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailCodeNull":
                    //msg = "コードを入力してくだたい。";
                    //cpt = "確認";
                    msg = Resources.MSG_9;
                    cpt = Resources.CAP_9;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "SaveSuccess":
                    //msg = "保存しました。";
                    //cpt = "お知らせ";
                    msg = Resources.MSG_10;
                    cpt = Resources.CAP_10;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ServiceError":
                    //msg = String.Format("処理中にエラーが発生しました。\n\nエラー内容：{0}", Service.ErrFullMsg);
                    //cpt = "エラー";
                    msg = String.Format(Resources.MSG_11, Service.ErrFullMsg);                    
                    cpt = Resources.CAP_11;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region [조회/입력/삭제/초기화 처리 코드]

        #region 조회/입력/삭제 버튼 처리
        private void blsButton_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.grdMaster.QueryLayout(false);
                    break;

                case FunctionType.Insert:
                    if (this.CurrMSLayout == this.grdMaster)
                    {
                        if (this.grdMaster.RowCount > 0)
                        {
                            for (int i = 0; i < this.grdMaster.RowCount; i++)
                            {
                                // 마스터 그리드 2행 이상 입력 방지
                                if (this.grdMaster.LayoutTable.Rows[i].RowState == DataRowState.Added)
                                {
                                    ShowMessage("MasterInsert");
                                    e.IsBaseCall = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        // 마스터 그리드 데이타 존재 여부 확인
                        if (this.grdMaster.RowCount == 0)
                        {
                            ShowMessage("DetailInsert");
                            e.IsBaseCall = false;
                        }
                    }
                    break;

                case FunctionType.Delete:
                    if (this.CurrMSLayout == grdMaster)
                    {
                        // 디테일 그리드 데이타 존재 여부 확인
                        if (this.grdDetail.RowCount > 0)
                        {
                            ShowMessage("MasterDeleteGrid");
                            e.IsBaseCall = false;
                        }
                        // 디테일 DB 데이타 존재 여부 확인
                        else
                        {
                            //                            string cmdText = string.Empty;
                            //                            object retVal = null;
                            //                            BindVarCollection bindVals = new BindVarCollection();

                            //                            cmdText = @"SELECT 'Y'
                            //                                          FROM DUAL
                            //                                         WHERE EXISTS (SELECT 'X'
                            //                                                         FROM INV0102
                            //                                                        WHERE HOSP_CODE = :f_hosp_code 
                            //                                                          AND CODE_TYPE = :f_code_type)";

                            //                            bindVals.Add("f_hosp_code", this.mHospCode);
                            //                            bindVals.Add("f_code_type", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());

                            //                            retVal = Service.ExecuteScalar(cmdText, bindVals);
                            CheckData0101U01Args args = new CheckData0101U01Args();
                            args.CodeType = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString();
                            CheckData0101U01Result result = CloudService.Instance.Submit<CheckData0101U01Result, CheckData0101U01Args>(args);

                            // DB 처리 성공
                            //if (Service.ErrCode == 0)
                            //{
                            //    if (retVal != null && retVal.ToString().Equals("Y"))
                            //    {
                            //        ShowMessage("MasterDeleteDB");
                            //        e.IsBaseCall = false;
                            //    }
                            //}                            
                            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                            {
                                if (result.DelDetail.ToString().Equals("Y"))
                                {
                                    ShowMessage("MasterDeleteDB");
                                    e.IsBaseCall = false;
                                }
                            }
                            // DB 처리 실패
                            else
                            {
                                ShowMessage("ServiceError");
                                e.IsBaseCall = false;
                            }
                        }
                    }
                    break;

                case FunctionType.Update:
                    if (SaveGrdLayOut())
                    {
                        XMessageBox.Show(Resources.MSG_10, Resources.CAP_7, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_12, Resources.CAP_12, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MasterGridNullCheck() || DetailGridNullCheck())
                    {
                        e.IsBaseCall = false;
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region 초기화 버튼 클릭 후 처리
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Reset:
                    if (EnvironInfo.CurrSystemID == "DRGS")
                    {
                        this.cboCdty.Enabled = false;
                        this.cboCdty.SetEditValue("SPECIALDRUG");
                        this.cboCdty.AcceptData();
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

        #endregion

        #region [코드유형 데이타 취득 및 설정 코드]

        /// <summary>
        /// 취득한 DB 데이타를 코드유형 콤보박스에 설정한다.
        /// </summary>
        public void ComboSetting()
        {
            this.layComboItems.SetBindVarValue("f_hosp_code", this.mHospCode);
            if (layComboItems.QueryLayout(true))
            {
                if (layComboItems.LayoutTable.Rows.Count > 0)
                {
                    this.cboCdty.SetComboItems(this.layComboItems.LayoutTable, "code_type_name", "code_type", XComboSetType.AppendAll);
                }
            }
        }

        #endregion

        #region [코드유형에 따른 마스터 그리드 설정 코드]

        /// <summary>
        /// 코드유형 콤보박스 아이템 선택 시, 해당하는 데이타를 마스터 그리드에 설정한다. 
        /// </summary>
        private void cboCdty_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.grdMaster.QueryLayout(false);
        }

        #endregion

        #region [마스터/디테일 그리드 바인드변수 설정 코드]

        #region 마스터 바인드변수 설정
        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdMaster.SetBindVarValue("f_code_type", cboCdty.GetDataValue());
        }
        #endregion

        #region 디테일 바인드변수 설정
        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdDetail.SetBindVarValue("f_code_type", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
        }
        #endregion

        #endregion

        #region [마스터/디테일 데이타 체크 코드]

        #region 마스터 그리드 필수입력컬럼 체크
        /// <summary>
        /// 마스터 그리드의 필수입력컬럼을 체크한다.
        /// </summary>
        /// <returns>
        /// true  : 누락컬럼 유
        /// false : 누락컬럼 무
        /// </returns>
        private bool MasterGridNullCheck()
        {
            for (int i = 0; i < grdMaster.LayoutTable.Rows.Count; i++)
            {
                if (grdMaster.LayoutTable.Rows[i].RowState == DataRowState.Added || grdMaster.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                {
                    if (TypeCheck.IsNull(grdMaster.GetItemValue(i, "code_type")))
                    {
                        grdMaster.SetFocusToItem(i, "code_type");
                        ShowMessage("MasterCodeTypeNull");
                        return true;
                    }
                    if (TypeCheck.IsNull(grdMaster.GetItemValue(i, "code_type_name")))
                    {
                        grdMaster.SetFocusToItem(i, "code_type_name");
                        ShowMessage("MasterCodeTypeNameNull");
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region 디테일 그리드 필수입력컬럼 체크
        /// <summary>
        /// 디테일 그리드의 필수입력컬럼을 체크한다.
        /// </summary>
        /// <returns>
        /// true  : 누락컬럼 유
        /// false : 누락컬럼 무
        /// </returns>
        private bool DetailGridNullCheck()
        {
            for (int i = 0; i < grdDetail.LayoutTable.Rows.Count; i++)
            {
                if (grdDetail.LayoutTable.Rows[i].RowState == DataRowState.Added || grdDetail.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                {
                    if (TypeCheck.IsNull(grdDetail.GetItemValue(i, "code")))
                    {
                        grdDetail.SetFocusToItem(i, "code");
                        ShowMessage("DetailCodeNull");
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region 마스터 데이타 중복 체크
        private void grdMaster_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            // 마스터 그리드의 Row 상태를 설정
            DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;

            // 입력버튼을 클릭을 했을 때
            if (rowState == DataRowState.Added)
            {
                // 입력된 Cell이 코드 유형 Cell일 경우에
                if (e.ColName == "code_type")
                {
                    // 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다.
                    //                    string cmdText = string.Empty;
                    //                    object retVal = null;
                    //                    BindVarCollection bindVals = new BindVarCollection();

                    //                    cmdText = @"SELECT 'Y'
                    //                                  FROM DUAL
                    //                                 WHERE EXISTS (SELECT 'X'
                    //                                                 FROM INV0101
                    //                                                WHERE HOSP_CODE = :f_hosp_code 
                    //                                                  AND CODE_TYPE = :f_code_type)";

                    //                    bindVals.Add("f_hosp_code", this.mHospCode);
                    //                    bindVals.Add("f_code_type", grdMaster.GetItemValue(e.RowNumber, "code_type").ToString());

                    //                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    //                    if (Service.ErrCode == 0)
                    //                    {
                    //                        if (retVal != null && retVal.ToString().Equals("Y"))
                    //                        {
                    //                            ShowMessage("MasterDup");
                    //                            e.Cancel = true;
                    //                        }
                    //                    }
                    CheckData0101U01Args args = new CheckData0101U01Args();
                    args.CodeType = grdMaster.GetItemValue(e.RowNumber, "code_type").ToString();
                    CheckData0101U01Result result = CloudService.Instance.Submit<CheckData0101U01Result, CheckData0101U01Args>(args);
                    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (result.CheckMaster.ToString().Equals("Y"))
                        {
                            ShowMessage("MasterDup");
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region 디테일 데이타 중복 체크
        private void grdDetail_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            // 디테일 그리드의 Row 상태를 설정
            DataRowState rowState = this.grdDetail.LayoutTable.Rows[this.grdDetail.CurrentRowNumber].RowState;

            // 입력버튼을 클릭을 했을 때
            if (rowState == DataRowState.Added)
            {
                // 입력된 Cell이 코드 Cell일 경우에 
                if (e.ColName == "code")
                {
                    //                    // 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다.
                    //                    string cmdText = string.Empty;
                    //                    object retVal = null;
                    //                    BindVarCollection bindVals = new BindVarCollection();

                    //                    cmdText = @"SELECT 'Y'
                    //                                  FROM DUAL
                    //                                 WHERE EXISTS (SELECT 'X'
                    //                                                 FROM INV0102
                    //                                                WHERE HOSP_CODE = :f_hosp_code 
                    //                                                  AND CODE_TYPE = :f_code_type
                    //                                                  AND CODE      = :f_code)";

                    //                    bindVals.Add("f_hosp_code", this.mHospCode);
                    //                    bindVals.Add("f_code_type", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
                    //                    bindVals.Add("f_code", grdDetail.GetItemValue(e.RowNumber, "code").ToString());

                    //                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    //                    if (Service.ErrCode == 0)
                    //                    {
                    //                        if (retVal != null && retVal.ToString().Equals("Y"))
                    //                        {
                    //                            ShowMessage("DetailDup");
                    //                            e.Cancel = true;
                    //                        }
                    //                    }
                    CheckData0101U01Args args = new CheckData0101U01Args();
                    args.CodeType = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString();
                    args.Code = grdDetail.GetItemValue(e.RowNumber, "code").ToString();
                    CheckData0101U01Result result = CloudService.Instance.Submit<CheckData0101U01Result, CheckData0101U01Args>(args);

                    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (result.CheckDetail.ToString().Equals("Y"))
                        {
                            ShowMessage("DetailDup");
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #region [데이타 저장 완료 메시지 설정 코드]

        private bool masterFlag = false;
        private bool detailFlag = false;

        /// <summary>
        /// 마스터/디테일 데이타 저장 완료 후, 메세지를 표시한다.
        /// </summary>
        private void grd_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                if (e.CallerID == '1')
                {
                    this.masterFlag = true;
                }
                else if (e.CallerID == '2')
                {
                    this.detailFlag = true;
                }

                if (this.masterFlag && this.detailFlag)
                {
                    ShowMessage("SaveSuccess");
                    this.ComboSetting();

                    masterFlag = false;
                    detailFlag = false;
                }
            }
            else
            {
                ShowMessage("ServiceError");

                masterFlag = false;
                detailFlag = false;
            }
        }

        #endregion

        /// <summary>
        /// Connect to Clound service
        /// </summary>
        private IList<object[]> LoadGrdMaster(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            INV0101U01GridMasterArgs args = new INV0101U01GridMasterArgs();
            args.CodeType = bc["f_code_type"].VarValue == null ? "" : bc["f_code_type"].VarValue;
            INV0101U01GridMasterResult result = CloudService.Instance.Submit<INV0101U01GridMasterResult, INV0101U01GridMasterArgs>(args);

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<INV0101U01GridMasterInfo> listListInfo = result.GrdMasterInfo;
                if (listListInfo != null && listListInfo.Count > 0)
                {
                    foreach (INV0101U01GridMasterInfo item in listListInfo)
                    {
                        object[] objects = 
                            {
                                item.CodeType,
                                item.CodeTypeName,
                                item.AdminGubun
                            };
                        res.Add(objects);
                    }
                }

            }
            return res;
        }

        private IList<object[]> LoadGrdDetail(BindVarCollection bvc)
        {
            IList<object[]> res = new List<object[]>();
            INV0101U01GridDetailArgs args = new INV0101U01GridDetailArgs();
            args.CodeType = bvc["f_code_type"].VarValue == null ? "" : bvc["f_code_type"].VarValue;
            INV0101U01GridDetailResult result = CloudService.Instance.Submit<INV0101U01GridDetailResult, INV0101U01GridDetailArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<INV0101U01GridDetailInfo> lstListInfo = result.GrdDetailInfo;
                if (lstListInfo != null && lstListInfo.Count > 0)
                {
                    foreach (INV0101U01GridDetailInfo item in lstListInfo)
                    {
                        object[] objects = 
                            {                               
                                item.Code,                                
                                item.CodeName,
                                item.CodeType,                                
                                item.SortKey
                            };
                        res.Add(objects);
                    }
                }
            }
            return res;
        }

        private bool SaveGrdLayOut()
        {
            List<INV0101U01GridMasterInfo> lstMaster = GetListMaster();
            List<INV0101U01GridDetailInfo> lstDetail = GetListDetail();
            SaveLayoutINV0101U01Args args = new SaveLayoutINV0101U01Args();
            args.ListMaster = lstMaster;
            args.ListDetail = lstDetail;
            args.UserId = UserInfo.UserID;
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, SaveLayoutINV0101U01Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

        private List<INV0101U01GridMasterInfo> GetListMaster()
        {
            List<INV0101U01GridMasterInfo> dataList = new List<INV0101U01GridMasterInfo>();
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) == DataRowState.Unchanged) continue;
                INV0101U01GridMasterInfo info = new INV0101U01GridMasterInfo();
                info.CodeType = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString();
                info.CodeTypeName = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type_name").ToString();
                info.AdminGubun = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "admin_gubun").ToString();
                info.RowState = grdMaster.GetRowState(i).ToString();
                dataList.Add(info);
            }
            if (grdMaster.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdMaster.DeletedRowTable.Rows)
                {
                    INV0101U01GridMasterInfo info = new INV0101U01GridMasterInfo();
                    info.CodeType = row["code_type"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }
            return dataList;
        }

        private List<INV0101U01GridDetailInfo> GetListDetail()
        {
            List<INV0101U01GridDetailInfo> dataList = new List<INV0101U01GridDetailInfo>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged) continue;
                INV0101U01GridDetailInfo info = new INV0101U01GridDetailInfo();
                info.Code = grdDetail.GetItemString(i, "code").ToString();
                info.CodeType = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString();
                info.CodeName = grdDetail.GetItemString(i, "code_name").ToString();
                info.SortKey = grdDetail.GetItemString(i, "sort_key").ToString();
                info.RowState = grdDetail.GetRowState(i).ToString();
                dataList.Add(info);
            }
            if (grdDetail.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
                {
                    INV0101U01GridDetailInfo info = new INV0101U01GridDetailInfo();
                    info.CodeType = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString();
                    info.Code = row["code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }
            return dataList;
        }

        private List<object[]> LoadDataXEditGridCell6(BindVarCollection bvc)
        {
            List<object[]> res = new List<object[]>();
            INV0101U01LoadComboArgs args = new INV0101U01LoadComboArgs();
            ComboResult result = CloudService.Instance.Submit<ComboResult, INV0101U01LoadComboArgs>(args);

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    object[] objects = 
                        {
                            item.Code,
                            item.CodeName
                        };
                    res.Add(objects);
                }
            }
            return res;
        }

        private void grdMaster_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell6.ExecuteQuery = LoadDataXEditGridCell6;
        }

        //        #region [XSavePerformer]

        //        private class XSavePerformer : IHIS.Framework.ISavePerformer
        //        {
        //            private INV0101U01 parent = null;

        //            public XSavePerformer(INV0101U01 parent)
        //            {
        //                this.parent = parent;
        //            }
        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";

        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

        //                switch (callerID)
        //                {
        //                    case '1':
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:
        //                                cmdText = @"INSERT INTO INV0101 (SYS_DATE, 
        //                                                                 SYS_ID,
        //                                                                 UPD_DATE,
        //                                                                 UPD_ID, 
        //                                                                 HOSP_CODE,
        //                                                                 CODE_TYPE, 
        //                                                                 CODE_TYPE_NAME,
        //                                                                 ADMIN_GUBUN )
        //                                                        VALUES  (SYSDATE, 
        //                                                                 :q_user_id, 
        //                                                                 SYSDATE, 
        //                                                                 :q_user_id,
        //                                                                 :f_hosp_code,
        //                                                                 :f_code_type, 
        //                                                                 :f_code_type_name,
        //                                                                 :f_admin_gubun)";
        //                                break;

        //                            case DataRowState.Modified:
        //                                cmdText = @"UPDATE INV0101
        //                                               SET UPD_ID         = :q_user_id,
        //                                                   UPD_DATE       = SYSDATE,
        //                                                   CODE_TYPE      = :f_code_type,
        //                                                   CODE_TYPE_NAME = :f_code_type_name,
        //                                                   ADMIN_GUBUN    = :f_admin_gubun
        //                                             WHERE HOSP_CODE      = :f_hosp_code
        //                                               AND CODE_TYPE      = :f_code_type";
        //                                break;

        //                            case DataRowState.Deleted:
        //                                cmdText = @"DELETE INV0101
        //                                             WHERE HOSP_CODE      = :f_hosp_code
        //                                               AND CODE_TYPE = :f_code_type";
        //                                break;
        //                        }
        //                        break;

        //                    case '2':
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:
        //                                cmdText = @"INSERT INTO INV0102 (SYS_DATE, 
        //                                                                 SYS_ID,
        //                                                                 UPD_DATE,
        //                                                                 UPD_ID, 
        //                                                                 HOSP_CODE,
        //                                                                 CODE_TYPE, 
        //                                                                 CODE, 
        //                                                                 CODE_NAME,
        //                                                                 SORT_KEY  )
        //                                                        VALUES  (SYSDATE, 
        //                                                                 :q_user_id, 
        //                                                                 SYSDATE, 
        //                                                                 :q_user_id,
        //                                                                 :f_hosp_code,
        //                                                                 :f_code_type, 
        //                                                                 :f_code, 
        //                                                                 :f_code_name,
        //                                                                 :f_sort_key     )";
        //                                break;

        //                            case DataRowState.Modified:
        //                                cmdText = @"UPDATE INV0102
        //                                               SET UPD_ID    = :q_user_id,
        //                                                   UPD_DATE  = SYSDATE,
        //                                                   CODE_TYPE = :f_code_type,
        //                                                   CODE      = :f_code,
        //                                                   CODE_NAME = :f_code_name,
        //                                                   SORT_KEY  = :f_sort_key
        //                                             WHERE HOSP_CODE = :f_hosp_code
        //                                               AND CODE_TYPE = :f_code_type
        //                                               AND CODE      = :f_code";
        //                                break;

        //                            case DataRowState.Deleted:
        //                                cmdText = @"DELETE INV0102
        //                                             WHERE HOSP_CODE = :f_hosp_code
        //                                               AND CODE_TYPE = :f_code_type
        //                                               AND CODE      = :f_code";
        //                                break;
        //                        }
        //                        break;

        //                    default:
        //                        break;

        //                }
        //                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //            }
        //        }

        //        #endregion


    }
}

