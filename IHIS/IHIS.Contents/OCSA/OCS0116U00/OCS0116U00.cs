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
#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0116U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0116U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";

        bool isgrdOCS0116Save = false;
        bool isSaved0116 = false;

        string mHospCode = EnvironInfo.HospCode;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XPictureBox xPictureBox1;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XComboBox cboSpecimen_gubun;
        private IHIS.Framework.XEditGrid grdOCS0116;
        private IHIS.Framework.XTextBox txtSpecimen_index;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0116U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            grdOCS0116.SavePerformer = new XSavePerformer(this);
            SaveLayoutList.Add(grdOCS0116);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0116U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboSpecimen_gubun = new IHIS.Framework.XComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtSpecimen_index = new IHIS.Framework.XTextBox();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0116 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0116)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.cboSpecimen_gubun);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.txtSpecimen_index);
            this.xPanel1.Controls.Add(this.xPictureBox1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(884, 30);
            this.xPanel1.TabIndex = 0;
            // 
            // cboSpecimen_gubun
            // 
            this.cboSpecimen_gubun.Location = new System.Drawing.Point(88, 6);
            this.cboSpecimen_gubun.Name = "cboSpecimen_gubun";
            this.cboSpecimen_gubun.Size = new System.Drawing.Size(122, 21);
            this.cboSpecimen_gubun.TabIndex = 0;
            this.cboSpecimen_gubun.SelectedIndexChanged += new System.EventHandler(this.cboSpecimen_gubun_SelectedIndexChanged);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(4, 6);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(82, 20);
            this.xLabel2.TabIndex = 23;
            this.xLabel2.Text = "検体区分";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(222, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(82, 20);
            this.xLabel1.TabIndex = 21;
            this.xLabel1.Text = "検索語";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSpecimen_index
            // 
            this.txtSpecimen_index.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSpecimen_index.Location = new System.Drawing.Point(306, 6);
            this.txtSpecimen_index.Name = "txtSpecimen_index";
            this.txtSpecimen_index.Size = new System.Drawing.Size(430, 20);
            this.txtSpecimen_index.TabIndex = 1;
            this.txtSpecimen_index.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSpecimen_index_DataValidating);
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.Size = new System.Drawing.Size(882, 28);
            this.xPictureBox1.TabIndex = 22;
            this.xPictureBox1.TabStop = false;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 550);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(884, 38);
            this.xPanel2.TabIndex = 1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(446, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(406, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0116
            // 
            this.grdOCS0116.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3});
            this.grdOCS0116.ColPerLine = 3;
            this.grdOCS0116.Cols = 3;
            this.grdOCS0116.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0116.FixedRows = 1;
            this.grdOCS0116.FocusColumnName = "specimen_code";
            this.grdOCS0116.HeaderHeights.Add(21);
            this.grdOCS0116.Location = new System.Drawing.Point(0, 30);
            this.grdOCS0116.Name = "grdOCS0116";
            this.grdOCS0116.QuerySQL = resources.GetString("grdOCS0116.QuerySQL");
            this.grdOCS0116.Rows = 2;
            this.grdOCS0116.Size = new System.Drawing.Size(884, 520);
            this.grdOCS0116.TabIndex = 2;
            this.grdOCS0116.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0116_QueryStarting);
            this.grdOCS0116.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0116_SaveStarting);
            this.grdOCS0116.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0116_GridColumnChanged);
            this.grdOCS0116.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS0116_SaveEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 3;
            this.xEditGridCell1.CellName = "specimen_gubun";
            this.xEditGridCell1.CellWidth = 127;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "検体区分";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 3;
            this.xEditGridCell2.CellName = "specimen_code";
            this.xEditGridCell2.CellWidth = 98;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "検体コード";
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 100;
            this.xEditGridCell3.CellName = "specimen_name";
            this.xEditGridCell3.CellWidth = 633;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "検体コード名";
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // OCS0116U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.grdOCS0116);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0116U00";
            this.Size = new System.Drawing.Size(884, 588);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0116)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0116;
            this.CurrMQLayout = this.grdOCS0116;

            //Create Combo
            CreateCombo();
        }
        #endregion

        #region [Combo 생성]

        private void CreateCombo()
        {
            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

            //검체구분 DataLayout;
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.InitializeLayoutTable();

            layoutCombo.QuerySQL = " SELECT CODE, CODE||'.'||CODE_NAME CODE_NAME"
                                 + "   FROM OCS0132 "
                                 + "  WHERE HOSP_CODE = '" + mHospCode + "' "
                                 + "    AND CODE_TYPE = 'SPECIMEN_GUBUN' "
                                 + "  ORDER BY SORT_KEY ";

            if (layoutCombo.QueryLayout(false) && layoutCombo.RowCount > 0)
            {
                cboSpecimen_gubun.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
                grdOCS0116.SetComboItems("specimen_gubun", layoutCombo.LayoutTable, "code_name", "code");
            }

            cboSpecimen_gubun.SelectedValue = EnvironInfo.CurrGroupID.Trim();

            if (this.cboSpecimen_gubun.SelectedIndex < 0)
                cboSpecimen_gubun.SelectedIndex = 0;
        }
        #endregion

        #region [Control Event]
        private void cboSpecimen_gubun_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            grdOCS0116.QueryLayout(false);
        }

        private void txtSpecimen_index_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            grdOCS0116.QueryLayout(false);
        }
        #endregion

        #region [grdOCS0116]
        private void grdOCS0116_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "specimen_code":

                    // 중복 Check
                    // 현재 화면
                    for (int i = 0; i < grdOCS0116.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0116.GetItemString(i, e.ColName.Trim()).Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "検体コードが重複されます. 確認してください." : "검체코드가 중복됩니다. 확인바랍니다.";
                                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    // Delete Table Check
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    bool deleted = false;
                    if (grdOCS0116.DeletedRowTable != null)
                    {
                        foreach (DataRow row in grdOCS0116.DeletedRowTable.Rows)
                        {
                            if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                            {
                                deleted = true;
                                break;
                            }
                        }
                    }

                    if (deleted) break;

                    //Check Origin Data
                    string cmdText = @"SELECT 'Y'
                                         FROM OCS0116
                                        WHERE SPECIMEN_CODE = '" + e.ChangeValue.ToString() +  @"'
                                          AND ROWNUM        = 1
                                          AND HOSP_CODE     = '" + mHospCode + "'";
                    object retVal = Service.ExecuteScalar(cmdText);

                    if(!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "検体コードが重複です。 ご確認してください." : "검체코드가 중복됩니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void grdOCS0116_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0116.SetBindVarValue("f_hosp_code", mHospCode);
            grdOCS0116.SetBindVarValue("f_specimen_name", txtSpecimen_index.GetDataValue());
            grdOCS0116.SetBindVarValue("f_specimen_gubun", cboSpecimen_gubun.GetDataValue());
        }

        private void grdOCS0116_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            isgrdOCS0116Save = e.IsSuccess;
            isSaved0116 = true;

            if (isSaved0116)
            {
                if (isgrdOCS0116Save)
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
                    SetMsg(mbxMsg);
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다.";
                    mbxMsg = mbxMsg + Service.ErrMsg;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }

                isgrdOCS0116Save = false;
                isSaved0116 = false;
            }
        }

        private void grdOCS0116_SaveStarting(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            System.ComponentModel.CancelEventArgs ca = new CancelEventArgs(true);

            //grdOCS0116
            for (int rowIndex = 0; rowIndex < grdOCS0116.RowCount; rowIndex++)
            {
                if (grdOCS0116.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0116.GetItemString(rowIndex, "specimen_code").Trim() == "")
                    {
                        grdOCS0116.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }


                if (grdOCS0116.GetItemString(rowIndex, "specimen_name").Trim() == "")
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "検体コード名に間違いがあります。ご確認ください." : "검체코드명이 정확하지않습니다. 확인바랍니다.";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0116.SetFocusToItem(rowIndex, "specimen_name");
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
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = CurrMSLayout.InsertRow();
                        //검체코드구분값
                        grdOCS0116.SetItemValue(currentRow, "specimen_gubun", cboSpecimen_gubun.SelectedValue);
                    }
                    else
                    {
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    }
                    break;
                case FunctionType.Update:
                    break;
                default:
                    break;
            }
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

        #region [XSavePerformer Class]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0116U00 parent = null;

            public XSavePerformer(OCS0116U00 parent)
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
                        cmdText = @"INSERT INTO OCS0116
                                          (  SYS_DATE
                                           , SYS_ID
                                           , SPECIMEN_GUBUN
                                           , SPECIMEN_CODE
                                           , SPECIMEN_NAME
                                           , HOSP_CODE
                                          )
                                    VALUES
                                          (  SYSDATE
                                           , :f_user_id
                                           , :f_specimen_gubun
                                           , :f_specimen_code
                                           , :f_specimen_name
                                           , :f_hosp_code
                                           )";
                        break;
                    case DataRowState.Modified:
                        cmdText = @"UPDATE OCS0116
                                       SET UPD_ID         = :f_upd_id
                                         , UPD_DATE       = :f_upd_date
                                         , SPECIMEN_GUBUN = :f_specimen_gubun
                                         , SPECIMEN_NAME  = :f_specimen_name
                                     WHERE SPECIMEN_CODE  = :f_specimen_code
                                       AND HOSP_CODE      = :f_hosp_code";
                        break;
                    case DataRowState.Deleted:
                        cmdText = "DELETE OCS0116 "
                                + " WHERE SPECIMEN_CODE = :f_specimen_code"
                                + "   AND HOSP_CODE     = :f_hosp_code";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

    }
}

