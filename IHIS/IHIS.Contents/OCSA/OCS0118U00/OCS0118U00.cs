#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0118U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0118U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";
        bool isgrdOCS0118Save = false;
        bool isSaved0118 = false;

        string mHospCode = EnvironInfo.HospCode;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XFindWorker fwkOCS0103;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XEditGrid grdOCS0118;
        private IHIS.Framework.XTextBox txtHangmog_code_q;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0118U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            SaveLayoutList.Add(grdOCS0118);
            //grdOCS0118.SavePerformer = new XSavePerformer(this);
            this.grdOCS0118.ExecuteQuery = GrdOCS0118GetData;
        }

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

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0118U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtHangmog_code_q = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.fwkOCS0103 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0118 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0118)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.txtHangmog_code_q);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // txtHangmog_code_q
            // 
            this.txtHangmog_code_q.AccessibleDescription = null;
            this.txtHangmog_code_q.AccessibleName = null;
            resources.ApplyResources(this.txtHangmog_code_q, "txtHangmog_code_q");
            this.txtHangmog_code_q.ApplyByteLimit = true;
            this.txtHangmog_code_q.BackgroundImage = null;
            this.txtHangmog_code_q.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHangmog_code_q.Font = null;
            this.txtHangmog_code_q.Name = "txtHangmog_code_q";
            this.txtHangmog_code_q.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHangmog_code_q_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Font = null;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // fwkOCS0103
            // 
            this.fwkOCS0103.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkOCS0103.ExecuteQuery = null;
            this.fwkOCS0103.FormText = "オ―ダコード";
            this.fwkOCS0103.InputSQL = resources.GetString("fwkOCS0103.InputSQL");
            this.fwkOCS0103.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkOCS0103.ParamList")));
            this.fwkOCS0103.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkOCS0103.SearchTextCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.fwkOCS0103.ServerFilter = true;
            this.fwkOCS0103.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkOCS0103_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hangmog_code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "hangmog_name";
            this.findColumnInfo2.ColWidth = 448;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.Yes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Font = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0118
            // 
            resources.ApplyResources(this.grdOCS0118, "grdOCS0118");
            this.grdOCS0118.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell4,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell10,
            this.xEditGridCell11});
            this.grdOCS0118.ColPerLine = 5;
            this.grdOCS0118.Cols = 6;
            this.grdOCS0118.ExecuteQuery = null;
            this.grdOCS0118.FixedCols = 1;
            this.grdOCS0118.FixedRows = 1;
            this.grdOCS0118.FocusColumnName = "hangmog_code";
            this.grdOCS0118.HeaderHeights.Add(25);
            this.grdOCS0118.Name = "grdOCS0118";
            this.grdOCS0118.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0118.ParamList")));
            this.grdOCS0118.QuerySQL = resources.GetString("grdOCS0118.QuerySQL");
            this.grdOCS0118.RowHeaderVisible = true;
            this.grdOCS0118.Rows = 2;
            this.grdOCS0118.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0118.ToolTipActive = true;
            this.grdOCS0118.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdOCS0118_GridFindSelected);
            this.grdOCS0118.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0118_SaveStarting);
            this.grdOCS0118.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0118_GridColumnChanged);
            this.grdOCS0118.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS0118_GridFindClick);
            this.grdOCS0118.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS0118_SaveEnd);
            this.grdOCS0118.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0118_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "conv_class";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "conv_gubun";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AutoTabDataSelected = true;
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.CellWidth = 101;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.FindWorker = this.fwkOCS0103;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.CellWidth = 281;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AutoTabDataSelected = true;
            this.xEditGridCell7.CellName = "conv_hangmog";
            this.xEditGridCell7.CellWidth = 103;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.FindWorker = this.fwkOCS0103;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "conv_hangmog_name";
            this.xEditGridCell8.CellWidth = 323;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "remark";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "start_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 96;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            // 
            // OCS0118U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdOCS0118);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "OCS0118U00";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0118)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        #region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
        public override object Command(string command, CommonItemCollection commandParam)
        {
            return base.Command(command, commandParam);
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            grdOCS0118.QueryLayout(false);
        }
        #endregion

        #region [grdOCS0118]
        private void grdOCS0118_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            object previousValue = grdOCS0118.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

            switch (e.ColName)
            {
                case "hangmog_code":
                case "conv_hangmog":
                    if (e.ChangeValue.ToString().Trim() == "")
                    {
                        if (e.ColName == "hangmog_code") grdOCS0118.SetItemValue(e.RowNumber, "hangmog_name", "");
                        if (e.ColName == "conv_hangmog") grdOCS0118.SetItemValue(e.RowNumber, "conv_hangmog_name", "");
                        return;
                    }

                    for (int i = 0; i < grdOCS0118.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0118.GetItemString(i, "hangmog_code").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダコードが重複されます。 確認してください。" : "항목코드가 중복됩니다. 확인바랍니다.";
                                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                this.UndoPreviousValue(grdOCS0118, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                                break;
                            }
                        }
                    }

                    // layCommon 처리
                    //                    string cmdText = @"SELECT A.HANGMOG_NAME
                    //                                         FROM OCS0103 A
                    //                                        WHERE A.HANGMOG_CODE = '" + e.ChangeValue.ToString() +@"'
                    //                                          AND A.HOSP_CODE    = '" + mHospCode + @"'
                    //                                          AND ROWNUM = 1";
                    //                    object retVal = Service.ExecuteScalar(cmdText);
                    OCS0118U00CheckHangmogCodeInfo ret = CheckHangmogCode(e.ChangeValue.ToString());
                    if (ret == null)
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダコードに間違いがあります。 ご確認ください。" : "항목코드가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.UndoPreviousValue(grdOCS0118, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.
                    }
                    else
                    {
                        if (e.ColName == "hangmog_code") grdOCS0118.SetItemValue(e.RowNumber, "hangmog_name", ret.HangmogName.ToString());
                        if (e.ColName == "conv_hangmog") grdOCS0118.SetItemValue(e.RowNumber, "conv_hangmog_name", ret.HangmogName.ToString());
                    }
                    // layCommon
                    break;
                default:
                    break;
            }
        }

        private void grdOCS0118_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
        {
            this.AcceptData();
        }

        private void grdOCS0118_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0118.SetBindVarValue("f_hangmog_name_inx", JapanTextHelper.GetFullKatakana(txtHangmog_code_q.GetDataValue().Trim(), true));
        }

        private void grdOCS0118_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            isgrdOCS0118Save = e.IsSuccess;
            isSaved0118 = true;

            if (isSaved0118)
            {
                if (isgrdOCS0118Save)
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
                    SetMsg(mbxMsg);
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다.";
                    mbxMsg = mbxMsg + e.ErrMsg;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }

                isgrdOCS0118Save = false;
                isSaved0118 = false;
            }
        }

        private void grdOCS0118_SaveStarting(object sender, GridRecordEventArgs e) //System.ComponentModel.CancelEventArgs e)
        {
            AcceptData();

            System.ComponentModel.CancelEventArgs ca = new CancelEventArgs(true);

            for (int rowIndex = 0; rowIndex < grdOCS0118.RowCount; rowIndex++)
            {
                if (grdOCS0118.LayoutTable.Rows[rowIndex].RowState == DataRowState.Unchanged) continue;

                if (grdOCS0118.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0118.GetItemString(rowIndex, "hangmog_name").Trim() == "")
                    {
                        grdOCS0118.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (!TypeCheck.IsDateTime(grdOCS0118.GetItemString(rowIndex, "start_date")))
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "適用日付が正確ではないです. 確認してください." : "적용일자가 정확하지않습니다. 확인바랍니다.";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0118.SetFocusToItem(rowIndex, "start_date");
                    ca.Cancel = true;
                    return;
                }

                if (TypeCheck.IsNull(grdOCS0118.GetItemString(rowIndex, "conv_hangmog_name")))
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "代替オーダが正確ではないです. 確認してください." : "대체처방이 정확하지않습니다. 확인바랍니다.";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0118.SetFocusToItem(rowIndex, "conv_hangmog");
                    ca.Cancel = true;
                    return;
                }
            }
        }
        #endregion

        #region [Button List Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    break;
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
                    if (chkCell.RowNumber < 0)
                    {
                        int insertRow = grdOCS0118.InsertRow(grdOCS0118.CurrentRowNumber);

                        //grdOCS0118
                        grdOCS0118.SetItemValue(insertRow, "conv_class", "2");
                        grdOCS0118.SetItemValue(insertRow, "conv_gubun", "1");
                        grdOCS0118.SetItemValue(insertRow, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    }
                    else
                    {
                        e.IsBaseCall = false;
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    }
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    SaveData();
                    break;
                case FunctionType.Delete:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [Control]
        private void txtHangmog_code_q_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            grdOCS0118.QueryLayout(false);
        }
        #endregion

        #region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
        /// <summary>
        /// Insert한 Row 중에 Not Null필드 미입력 Row Search
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
        /// </remarks>
        /// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }
            }

            return celReturn;
        }
        #endregion

        #region [Grid Undo관련 ]
        #region XEditGrid에 값을 세팅하되 이전의 RowState를 유지하며, Option 해당 컬럼에서 포커스를 유지시킨다 (UndoPreviousValue)
        /// <summary> 
        /// XEditGrid에 값을 세팅하되 이전의 RowState를 유지하며, Option해당 컬럼에서 포커스를 유지시킨다
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <param name="aRow"> int Row </param>
        /// <param name="aColName"> string 컬럼 </param>
        /// <param name="aPreviousValue"> object Setting할 Value </param>
        /// <param name="aIsProtecedFocus"> bool Optional 포커스이동막을지여부(Defalut : True) </param>
        /// <returns> void </returns>
        private void UndoPreviousValue(XEditGrid aGrd, int aRow, string aColName, object aPreviousValue)
        {
            this.UndoPreviousValue(aGrd, aRow, aColName, aPreviousValue, true);
        }
        private void UndoPreviousValue(XEditGrid aGrd, int aRow, string aColName, object aPreviousValue, bool aIsProtecedFocus)
        {
            if (aGrd == null || aRow < 0 || aColName == "") return;

            // 이전 값으로 세팅한다
            // 값을 세팅하면 Row의 상태가 변화가 되므로, 해당 Row의 상태가 UnChanged인 경우는 변경후에 다시 UnChanged로 바꾸어 준다
            // 단, Added인 경우는 Detached 상태였으면, Detached로 바꾸어 줘야 하나, A___Grid는 InsertRow시 이미 Added상태이므로, 처리불가함
            DataRowState previousRowState = aGrd.GetRowState(aRow);

            if (previousRowState != DataRowState.Deleted) aGrd.SetItemValue(aRow, aColName, aPreviousValue); // 이전 데이타로 복귀

            // 이전 Row상태가 UnChanged인 경우 UnChanged로 Undo시킴
            if (previousRowState == DataRowState.Unchanged) aGrd.LayoutTable.Rows[aRow].AcceptChanges();

            if (aIsProtecedFocus) // 포커스이동막을지여부
            {
                Objects objects = new Objects(aGrd, aRow, aColName);
                PostCallHelper.PostCall(new PostMethodObject(PostSetFocusToItem), ((object)objects)); // 현재 Column으로 Focus이동처리
            }
        }

        #region Objects Class(PostCall 메소드 사용용)
        // PostCall 메소드 사용시 Argument로 Object 하나만 넘길수 있다. 두개이상 Argument가 필요한 경우 아래의 구조체를 사용하자
        private class Objects
        {
            public object obj1; public object obj2; public object obj3; public object obj4; public object obj5;

            public Objects(object aObj1, object aObj2)
            {
                obj1 = aObj1; obj2 = aObj2; obj3 = null; obj4 = null; obj5 = null;
            }
            public Objects(object aObj1, object aObj2, object aObj3)
            {
                obj1 = aObj1; obj2 = aObj2; obj3 = aObj3; obj4 = null; obj5 = null;
            }
            public Objects(object aObj1, object aObj2, object aObj3, object aObj4)
            {
                obj1 = aObj1; obj2 = aObj2; obj3 = aObj3; obj4 = aObj4; obj5 = null;
            }
            public Objects(object aObj1, object aObj2, object aObj3, object aObj4, object aObj5)
            {
                obj1 = aObj1; obj2 = aObj2; obj3 = aObj3; obj4 = aObj4; obj5 = aObj5;
            }
        }
        #endregion

        private void PostSetFocusToItem(object aObjs)
        {
            try
            {
                Objects objects = (Objects)aObjs;
                ((XGrid)objects.obj1).Focus();
                ((XGrid)objects.obj1).SetFocusToItem(((int)objects.obj2), ((string)objects.obj3));
            }
            catch { }
        }
        #endregion
        #endregion

        #region [XSavePerformer Class]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0118U00 parent = null;

            public XSavePerformer(OCS0118U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"INSERT INTO OCS0118
                                         (  SYS_DATE
                                          , SYS_ID
                                          , CONV_CLASS
                                          , CONV_GUBUN
                                          , HANGMOG_CODE
                                          , CONV_HANGMOG
                                          , START_DATE
                                          , REMARK
                                          , HOSP_CODE
                                         )
                                    VALUES 
                                         (  SYSDATE
                                          , :f_user_id
                                          , :f_conv_class
                                          , :f_conv_gubun
                                          , :f_hangmog_code
                                          , :f_conv_hangmog
                                          , :f_start_date
                                          , :f_remark
                                          , :f_hosp_code
                                         )";
                        break;
                    case DataRowState.Modified:
                        cmdText = @"UPDATE OCS0118
                                       SET UPD_ID      = :f_user_id
                                         , UPD_DATE     = SYSDATE
                                         , CONV_HANGMOG = :f_conv_hangmog
                                         , START_DATE   = :f_start_date
                                         , REMARK       = :f_remark
                                     WHERE CONV_CLASS   = :f_conv_class
                                       AND CONV_GUBUN   = :f_conv_gubun
                                       AND HANGMOG_CODE = :f_hangmog_code
                                       AND HOSP_CODE    = :f_hosp_code";
                        break;
                    case DataRowState.Deleted:
                        cmdText = @"DELETE OCS0118
                                     WHERE CONV_CLASS   = :f_conv_class
                                       AND CONV_GUBUN   = :f_conv_gubun
                                       AND HANGMOG_CODE = :f_hangmog_code
                                       AND HOSP_CODE    = :f_hosp_code";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void fwkOCS0103_QueryStarting(object sender, CancelEventArgs e)
        {
            //fwkOCS0103.SetBindVarValue("f_find1", CurrMQLayout.GetItemValue(CurrMQLayout.CurrentRowNumber, CurrMQLayout.CurrentColName).ToString());
            //fwkOCS0103.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        #region Connect to cloud
        //HungNV added
        private IList<object[]> GrdOCS0118GetData(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS0118U00GrdOCS0118Args args = new OCS0118U00GrdOCS0118Args();
            args.HangmogNameInx = bvc["f_hangmog_name_inx"].VarValue;
            OCS0118U00GrdOCS0118Result res = CloudService.Instance.Submit<OCS0118U00GrdOCS0118Result, OCS0118U00GrdOCS0118Args>(args);
            if (null != res)
            {
                foreach (OCS0118U00GrdOCS0118Info item in res.GrdOCS0118Info)
                {
                    lObj.Add(new object[]
                    {
                        item.ConvCls,
                        item.ConvGubun,
                        item.HangmogCode,
                        item.HangmogName,
                        item.ConvHangmog,
                        item.ConvHangmogName,
                        item.Remark,
                        item.StartDate
                    });
                }
            }
            return lObj;
        }

        private OCS0118U00CheckHangmogCodeInfo CheckHangmogCode(string hangmogCode)
        {
            OCS0118U00CheckHangmogCodeArgs args = new OCS0118U00CheckHangmogCodeArgs();
            args.HangmogCode = hangmogCode;
            OCS0118U00CheckHangmogCodeResult res = CloudService.Instance.Submit<OCS0118U00CheckHangmogCodeResult, OCS0118U00CheckHangmogCodeArgs>(args);

            if (null != res && res.ExecutionStatus == ExecutionStatus.Success)
            {
                return res.CheckHangmocCodeInfo.Count > 0 ? res.CheckHangmocCodeInfo[0] : null;
            }
            return null;
        }

        private IList<object[]> xFindWorker_GetOCS0103Data(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstResult = new List<object[]>();
            OCS0118U00FwkOCS0103Args args = new OCS0118U00FwkOCS0103Args(bindVarCollection["f_find1"].VarValue);
            OCS0118U00FwkOCS0103Result result = CloudService.Instance.Submit<OCS0118U00FwkOCS0103Result, OCS0118U00FwkOCS0103Args>(args);
            if (result != null)
            {
                IList<OCS0118U00FwkOCS0103Info> lstDataInfo = result.FwkOCS0103Info;
                if (lstDataInfo != null && lstDataInfo.Count > 0)
                {
                    foreach (OCS0118U00FwkOCS0103Info item in lstDataInfo)
                    {
                        object[] obj =
                        {
                            item.HangmogCode,
                            item.HangmogName
                        };
                        lstResult.Add(obj);
                    }
                }
            }
            return lstResult;
        }
        private void SaveData()
        {
            OCS0118U00GrdSaveLayoutArgs args = new OCS0118U00GrdSaveLayoutArgs();
            args.GrdSaveLayoutInfo = GetListDataForSaveLayout();
            if (args.GrdSaveLayoutInfo.Count <= 0) return;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS0118U00GrdSaveLayoutArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
            {
                this.grdOCS0118.ResetUpdate();
                XMessageBox.Show(Resources.OCS0118_SMS01, Resources.OCS0118_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XMessageBox.Show(Resources.OCS0118_SMS02, Resources.OCS0118_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<OCS0118U00GrdSaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<OCS0118U00GrdSaveLayoutInfo> lstData = new List<OCS0118U00GrdSaveLayoutInfo>();

            for (int i = 0; i < this.grdOCS0118.RowCount; i++)  
            {
                // Skip unchanged rows
                if (grdOCS0118.GetRowState(i) == DataRowState.Unchanged) continue;
                OCS0118U00GrdSaveLayoutInfo item = new OCS0118U00GrdSaveLayoutInfo();
                item.ConvCls = grdOCS0118.GetItemString(i, "conv_class");
                item.ConvGubun = grdOCS0118.GetItemString(i, "conv_gubun");
                item.ConvHangmog = grdOCS0118.GetItemString(i, "conv_hangmog");
                item.HangmogCode = grdOCS0118.GetItemString(i, "hangmog_code");
                item.Remark = grdOCS0118.GetItemString(i, "remark");
                item.StartDate = grdOCS0118.GetItemString(i, "start_date");
                item.SysId = UserInfo.UserID;
                item.RowState = grdOCS0118.GetRowState(i).ToString();
                lstData.Add(item);
            }

            if (null != grdOCS0118.DeletedRowTable)
            {
                for (int i = 0; i < grdOCS0118.DeletedRowTable.Rows.Count; i++)
                {
                    OCS0118U00GrdSaveLayoutInfo item = new OCS0118U00GrdSaveLayoutInfo();
                    item.ConvCls = Convert.ToString(grdOCS0118.DeletedRowTable.Rows[i]["conv_class"]);
                    item.ConvGubun = Convert.ToString(grdOCS0118.DeletedRowTable.Rows[i]["conv_gubun"]);
                    item.HangmogCode = Convert.ToString(grdOCS0118.DeletedRowTable.Rows[i]["hangmog_code"]);
                    item.Remark = "";
                    item.StartDate = "";
                    item.SysId = "";
                    item.ConvHangmog = "";
                    item.RowState = DataRowState.Deleted.ToString();
                    lstData.Add(item);
                }
            }
            return lstData;
        }
        #endregion

        private void grdOCS0118_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            fwkOCS0103.ColInfos.Clear();
            fwkOCS0103.ServerFilter = false;
            switch (e.ColName)
            {
                case "hangmog_code":
                    fwkOCS0103.AutoQuery = true;
                    fwkOCS0103.ServerFilter = false;
                    fwkOCS0103.ParamList = new List<string>(new String[] { "f_find1" });
                    fwkOCS0103.BindVarList.Clear();
                    //fwkOCS0103.BindVarList.Add("hangmog_name", this.mHospCode);
                    //fwkOCS0103.BindVarList.Add("hangmog_code", this.grdOCS0118.GetItemString(e.RowNumber, "naewon_date"));
                    fwkOCS0103.ExecuteQuery = xFindWorker_GetOCS0103Data;
                    this.fwkOCS0103.ColInfos.Clear();
                    this.fwkOCS0103.ColInfos.Add("hangmog_code", Resources.OCS0118HangmogCode, FindColType.String, 80, 0, true, FilterType.No);
                    this.fwkOCS0103.ColInfos.Add("hangmog_name", Resources.OCS0118HangmogName, FindColType.String, 200, 0, true, FilterType.InitYes);
                    this.fwkOCS0103.ColInfos[0].ColAlign = HorizontalAlignment.Center;
                    break;
                case "conv_hangmog":
                    fwkOCS0103.AutoQuery = true;
                    fwkOCS0103.ServerFilter = false;
                    fwkOCS0103.ParamList = new List<string>(new String[] { "f_find1" });
                    fwkOCS0103.BindVarList.Clear();
                    fwkOCS0103.ExecuteQuery = xFindWorker_GetOCS0103Data;
                    this.fwkOCS0103.ColInfos.Clear();
                    this.fwkOCS0103.ColInfos.Add("hangmog_code", Resources.OCS0118HangmogCode, FindColType.String, 80, 0, true, FilterType.No);
                    this.fwkOCS0103.ColInfos.Add("hangmog_name", Resources.OCS0118HangmogName, FindColType.String, 200, 0, true, FilterType.InitYes);
                    this.fwkOCS0103.ColInfos[0].ColAlign = HorizontalAlignment.Center;
                    break;
            }

        }
    }
}

