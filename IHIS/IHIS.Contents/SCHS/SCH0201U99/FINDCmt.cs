using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.SCHS
{
    /// <summary>
    /// FINDComment에 대한 요약 설명입니다.
    /// </summary>
    public class FINDCmt : IHIS.Framework.XForm
    {
        private string bunho, reser_date, gwa;

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGrid grdComment;
        private IHIS.Framework.XEditGrid grdReserComment;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FINDCmt(string ar_bunho, string ar_reser_date, string ar_gwa)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
            //
            bunho = ar_bunho;
            reser_date = ar_reser_date;
            gwa = ar_gwa;

            this.grdReserComment.SavePerformer = new XSavePerformer(this);
            this.grdComment.SavePerformer = this.grdReserComment.SavePerformer;

            this.grdReserComment.QueryLayout(true);

            this.grdComment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdComment.SetBindVarValue("f_bunho", bunho);
            this.grdComment.SetBindVarValue("f_reser_date", reser_date);
            this.grdComment.SetBindVarValue("f_gwa", gwa);

            this.grdComment.QueryLayout(false);
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

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FINDCmt));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdComment = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdReserComment = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserComment)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdComment);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdComment
            // 
            this.grdComment.CallerID = '2';
            this.grdComment.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdComment.ColPerLine = 1;
            this.grdComment.Cols = 2;
            resources.ApplyResources(this.grdComment, "grdComment");
            this.grdComment.ExecuteQuery = null;
            this.grdComment.FixedCols = 1;
            this.grdComment.FixedRows = 1;
            this.grdComment.HeaderHeights.Add(21);
            this.grdComment.Name = "grdComment";
            this.grdComment.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdComment.ParamList")));
            this.grdComment.QuerySQL = resources.GetString("grdComment.QuerySQL");
            this.grdComment.RowHeaderVisible = true;
            this.grdComment.Rows = 2;
            this.grdComment.ToolTipActive = true;
            this.grdComment.UseDefaultTransaction = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "reser_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gwa";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "seq";
            this.xEditGridCell3.CellWidth = 50;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "comments";
            this.xEditGridCell4.CellWidth = 638;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.grdReserComment);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // xLabel1
            // 
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // grdReserComment
            // 
            this.grdReserComment.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell7});
            this.grdReserComment.ColPerLine = 3;
            this.grdReserComment.Cols = 3;
            resources.ApplyResources(this.grdReserComment, "grdReserComment");
            this.grdReserComment.ExecuteQuery = null;
            this.grdReserComment.FixedRows = 1;
            this.grdReserComment.HeaderHeights.Add(21);
            this.grdReserComment.Name = "grdReserComment";
            this.grdReserComment.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdReserComment.ParamList")));
            this.grdReserComment.QuerySQL = "SELECT A.CODE                CODE\r\n     , A.CODE_NAME           CODE_NAME\r\n  FROM" +
                " SCH0003 A\r\n WHERE A.HOSP_CODE = :f_hosp_code\r\n ORDER BY 1";
            this.grdReserComment.Rows = 2;
            this.grdReserComment.ToolTipActive = true;
            this.grdReserComment.UseDefaultTransaction = false;
            this.grdReserComment.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdReserComment_GridButtonClick);
            this.grdReserComment.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdReserComment_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "code";
            this.xEditGridCell1.CellWidth = 50;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_name";
            this.xEditGridCell2.CellWidth = 579;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell7.ButtonImage")));
            this.xEditGridCell7.CellName = "chk";
            this.xEditGridCell7.CellWidth = 34;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // FINDCmt
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel1);
            this.Name = "FINDCmt";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.xPanel1.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReserComment)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case IHIS.Framework.FunctionType.Update:

                    e.IsBaseCall = false;

                    try
                    {
                        Service.BeginTransaction();

                        //if (!this.grdReserComment.SaveLayout())
                        //    throw new Exception();

                        //for (int i = 0; i < grdComment.RowCount; i++)
                        //{
                        //    if(this.grdComment.)
                        //    grdComment.SetItemValue(i, "bunho", bunho);
                        //    grdComment.SetItemValue(i, "reser_date", reser_date);
                        //    grdComment.SetItemValue(i, "gwa", gwa);
                        //    grdComment.SetItemValue(i, "seq", i);

                        //    /* ???
                        //    this.grdComment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        //    this.grdComment.SetBindVarValue("f_bunho", bunho);
                        //    this.grdComment.SetBindVarValue("f_reser_date", reser_date);
                        //    this.grdComment.SetBindVarValue("f_gwa", gwa);
                        //     */
                        //}

                        if (!this.grdReserComment.SaveLayout())
                        {
                            if (mErrMsg == "")
                                mErrMsg = Service.ErrFullMsg;
                            throw new Exception();
                        }


                        if (!this.grdComment.SaveLayout())
                        {
                            if (mErrMsg == "")
                                mErrMsg = Service.ErrFullMsg;
                            throw new Exception();
                        }

                        Service.CommitTransaction();
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        if (mErrMsg != "")
                            XMessageBox.Show(mErrMsg, "保存失敗", MessageBoxIcon.Error);
                        return;
                    }

                    this.grdReserComment.QueryLayout(false);

                    //this.Close();

                    break;

                case IHIS.Framework.FunctionType.Delete:

                    if (this.CurrMSLayout == grdReserComment)
                    {
                        if (MessageBox.Show("削除しますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
                            e.IsBaseCall = false;
                    }

                    break;

                case IHIS.Framework.FunctionType.Insert:
                    e.IsBaseCall = false;

                    if (this.CurrMSLayout == grdReserComment)
                    {
                        this.grdReserComment.InsertRow(-1);
                    }
                    else
                        if (this.CurrMSLayout == grdComment)
                        {
                            if (this.grdComment.RowCount < 7)
                            {
                                int row = this.grdComment.InsertRow(-1);
                                grdComment.SetItemValue(row, "bunho", bunho);
                                grdComment.SetItemValue(row, "reser_date", reser_date);
                                grdComment.SetItemValue(row, "gwa", gwa);
                            }
                            else
                            {
                                XMessageBox.Show("予約コメントは最大7項目まで入力可能です。", "注意", MessageBoxIcon.Warning);
                            }
                        }

                    break;
                default:
                    break;

            }
        }


        private void grdReserComment_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
        {
            string comments = grdReserComment.GetItemString(grdReserComment.CurrentRowNumber, "code_name");
            if (this.grdComment.RowCount < 7)
            {
                int row = grdComment.InsertRow(-1);
                grdComment.SetItemValue(row, "bunho", bunho);
                grdComment.SetItemValue(row, "reser_date", reser_date);
                grdComment.SetItemValue(row, "gwa", gwa);
                grdComment.SetItemValue(row, "comments", comments);
            }
            else
            {
                XMessageBox.Show("予約コメントは最大7項目まで入力可能です。", "注意", MessageBoxIcon.Warning);
            }
        }

        private void grdReserComment_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdReserComment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        #region XSavePerformer
        string mErrMsg = "";
        private class XSavePerformer : ISavePerformer
        {
            FINDCmt parent;

            public XSavePerformer(FINDCmt parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                parent.mErrMsg = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case System.Data.DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM SCH0003
                                                             WHERE HOSP_CODE = :f_hosp_code 
                                                               AND CODE      = :f_code     )";

                                object dupYN = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(dupYN))
                                {
                                    if (dupYN.ToString() == "Y")
                                    {
                                        parent.mErrMsg = "コード「" + item.BindVarList["f_code"].VarValue + "」は既に登録されています。";
                                        return false;
                                    }
                                }

                                cmdText = @"INSERT INTO SCH0003
                                                 ( SYS_DATE 
                                                 , SYS_ID
                                                 , UPD_DATE
                                                 , UPD_ID
                                                 , HOSP_CODE
                                                 , CODE
                                                 , CODE_NAME )
                                            VALUES(SYSDATE
                                                 , :q_user_id
                                                 , SYSDATE
                                                 , :q_user_id
                                                 , :f_hosp_code
                                                 , :f_code
                                                 , :f_code_name )";
                                break;

                            case System.Data.DataRowState.Modified:
                                cmdText = @"UPDATE SCH0003
                                               SET UPD_ID    = :q_user_id
                                                 , UPD_DATE  = SYSDATE
                                                 , CODE_NAME = :f_code_name
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE      = :f_code";
                                break;

                            case System.Data.DataRowState.Deleted:
                                cmdText = @"DELETE FROM SCH0003
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE      = :f_code";

                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case System.Data.DataRowState.Added:

                                cmdText = @"SELECT NVL(MAX(SEQ), 0) + 1 SEQ
                                              FROM SCH0299
                                             WHERE HOSP_CODE  = :f_hosp_code 
                                               AND BUNHO      = :f_bunho
                                               AND RESER_DATE = :f_reser_date       
                                               AND GWA        = :f_gwa";

                                object seq = Service.ExecuteScalar(cmdText, item.BindVarList);

                                item.BindVarList.Add("f_seq", seq.ToString());

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM SCH0299
                                                             WHERE HOSP_CODE  = :f_hosp_code 
                                                               AND BUNHO      = :f_bunho
                                                               AND RESER_DATE = :f_reser_date       
                                                               AND GWA        = :f_gwa
                                                               AND SEQ        = :f_seq    )";

                                object dupYN = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(dupYN))
                                {
                                    if (dupYN.ToString() == "Y")
                                    {
                                        parent.mErrMsg = "既に同じコメントが登録されています。（" + item.BindVarList["f_reser_date"].VarValue + "、" + item.BindVarList["f_gwa"].VarValue + "、" + item.BindVarList["f_seq"].VarValue + "）";
                                        return false;
                                    }
                                }

                                cmdText = @"INSERT INTO SCH0299
                                                 ( SYS_DATE
                                                 , SYS_ID
                                                 , UPD_DATE
                                                 , UPD_ID
                                                 , HOSP_CODE 
                                                 , BUNHO
                                                 , RESER_DATE
                                                 , GWA
                                                 , SEQ
                                                 , COMMENTS  )
                                            VALUES(SYSDATE
                                                 , :q_user_id
                                                 , SYSDATE
                                                 , :q_user_id
                                                 , :f_hosp_code
                                                 , :f_bunho
                                                 , :f_reser_date
                                                 , :f_gwa
                                                 , :f_seq
                                                 , :f_comments     )";
                                break;

                            case System.Data.DataRowState.Modified:
                                cmdText = @"UPDATE SCH0299
                                               SET UPD_ID     = :q_user_id
                                                 , UPD_DATE   = SYSDATE
                                                 , COMMENTS   = :f_comments
                                             WHERE HOSP_CODE  = :f_hosp_code 
                                               AND BUNHO      = :f_bunho
                                               AND RESER_DATE = :f_reser_date
                                               AND GWA        = :f_gwa
                                               AND SEQ        = :f_seq";
                                break;

                            case System.Data.DataRowState.Deleted:
                                cmdText = @"DELETE SCH0299
                                             WHERE HOSP_CODE  = :f_hosp_code 
                                               AND BUNHO      = :f_bunho
                                               AND RESER_DATE = :f_reser_date
                                               AND GWA        = :f_gwa
                                               AND SEQ        = :f_seq";

                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
    }
}
