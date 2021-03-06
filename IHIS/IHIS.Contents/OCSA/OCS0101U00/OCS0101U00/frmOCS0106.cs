using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.OCSA.Properties;

namespace IHIS.OCSA
{
    /// <summary>
    /// frmOCS0106에 대한 요약 설명입니다.
    /// </summary>
    public class frmOCS0106 : IHIS.Framework.XForm
    {
        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";
        //protected string returnFrm = "N";
        #endregion

        #region [SaveEnd]
        bool isgrdOCS0106Save = false;
        bool isSaved0106 = false;
        #endregion

        private string slip_code = "";
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGrid grdOCS0106;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XFindWorker fdwSpecimen_code;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private System.Windows.Forms.PictureBox pictureBox1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmOCS0106(string i_slip_code)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
            //

            slip_code = i_slip_code;

            this.SaveLayoutList.Add(grdOCS0106);
            grdOCS0106.SavePerformer = new XSavePerformer(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOCS0106));
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0106 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.fdwSpecimen_code = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0106
            // 
            resources.ApplyResources(this.grdOCS0106, "grdOCS0106");
            this.grdOCS0106.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdOCS0106.ColPerLine = 3;
            this.grdOCS0106.Cols = 4;
            this.grdOCS0106.FixedCols = 1;
            this.grdOCS0106.FixedRows = 1;
            this.grdOCS0106.FocusColumnName = "specimen_code";
            this.grdOCS0106.HeaderHeights.Add(24);
            this.grdOCS0106.Name = "grdOCS0106";
            this.grdOCS0106.QuerySQL = resources.GetString("grdOCS0106.QuerySQL");
            this.grdOCS0106.RowHeaderVisible = true;
            this.grdOCS0106.Rows = 2;
            this.grdOCS0106.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0106_MouseDown);
            this.grdOCS0106.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOCS0106_ItemValueChanging);
            this.grdOCS0106.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOCS0106_DragDrop);
            this.grdOCS0106.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0106_QueryStarting);
            this.grdOCS0106.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0106_PreSaveLayout);
            this.grdOCS0106.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0106_GridColumnChanged);
            this.grdOCS0106.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0106_DragEnter);
            this.grdOCS0106.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdOCS0106_GridFindSelected);
            this.grdOCS0106.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS0106_SaveEnd);
            this.grdOCS0106.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOCS0106_GiveFeedback);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "slip_code";
            this.xEditGridCell1.Col = -1;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 1;
            this.xEditGridCell2.CellName = "default_yn";
            this.xEditGridCell2.CellWidth = 43;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 3;
            this.xEditGridCell3.CellName = "specimen_code";
            this.xEditGridCell3.CellWidth = 92;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.FindWorker = this.fdwSpecimen_code;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // fdwSpecimen_code
            // 
            this.fdwSpecimen_code.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fdwSpecimen_code.FormText = Resources.FDWSPECIMEN_CODE_FORMTEXT;
            this.fdwSpecimen_code.InputSQL = "SELECT SPECIMEN_CODE, SPECIMEN_NAME\r\n FROM OCS0116\r\n WHERE ( :f_specimen_code IS " +
                "NULL OR SPECIMEN_CODE = :f_specimen_code )\r\n ORDER BY SPECIMEN_CODE";
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "specimen_code";
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "specimen_name";
            this.findColumnInfo2.ColWidth = 434;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "specimen_name";
            this.xEditGridCell4.CellWidth = 453;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "seq";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // frmOCS0106
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.grdOCS0106);
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmOCS0106";
            this.Load += new System.EventHandler(this.frmOCS0106_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.xButtonList1, 0);
            this.Controls.SetChildIndex(this.grdOCS0106, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Form Load시 해당검체를 조회한다.
        /// </summary>
        private void frmOCS0106_Load(object sender, System.EventArgs e)
        {
            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0106;
            this.CurrMQLayout = this.grdOCS0106;

            if (slip_code.Trim() != "")
            {
                grdOCS0106.SetBindVarValue("f_slip_code", slip_code);
                grdOCS0106.QueryLayout(false);
            }

            //InitValue 설정
            ((XEditGridCell)grdOCS0106.CellInfos["slip_code"]).InitValue = slip_code;
        }

        #region [Drag row]
        private void grdOCS0106_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (grdOCS0106.GetHitRowNumber(e.Y) < 0) return;
            int curRowIndex = grdOCS0106.GetHitRowNumber(e.Y);
            string dragInfo = "[" + grdOCS0106.GetItemString(curRowIndex, "specimen_code") + "]" + grdOCS0106.GetItemString(curRowIndex, "specimen_name");
            DragHelper.CreateDragCursor(grdOCS0106, dragInfo, this.Font);

            grdOCS0106.DoDragDrop(curRowIndex, DragDropEffects.Move);
        }

        private void grdOCS0106_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Client Point
            int fromRowNum = int.Parse(e.Data.GetData("System.Int32").ToString());
            Point clientPoint = grdOCS0106.PointToClient(new Point(e.X, e.Y));

            int toRowNum = grdOCS0106.GetHitRowNumber(clientPoint.Y);

            if (toRowNum == fromRowNum || toRowNum < 0)
            {
                //Edit상태로 만든다.
                grdOCS0106.SetFocusToItem(toRowNum, grdOCS0106.CurrentColNumber);
                return;
            }

            DataRow backRow = grdOCS0106.LayoutTable.NewRow();
            foreach (DataColumn col in grdOCS0106.LayoutTable.Columns)
            {
                backRow[col.ColumnName] = grdOCS0106.GetItemString(toRowNum, col.ColumnName);
                grdOCS0106.SetItemValue(toRowNum, col.ColumnName, grdOCS0106.GetItemString(fromRowNum, col.ColumnName));
                grdOCS0106.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
            }

            grdOCS0106.SetFocusToItem(toRowNum, grdOCS0106.CurrentColNumber);

            backRow = null;
        }

        private void grdOCS0106_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;  // Copy 표시
            e.Effect = DragDropEffects.Move;  // Move 표시
        }

        private void grdOCS0106_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }
        #endregion

        #region [grdOCS0106 Event]
        private void grdOCS0106_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "specimen_code":
                    if (e.ChangeValue.ToString().Trim() == "") break;

                    //중복 Check
                    for (int i = 0; i < grdOCS0106.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0106.GetItemString(i, "specimen_code").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resources.MSG012_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                                return;
                            }
                        }
                    }

                    string cmdText = " SELECT SPECIMEN_NAME "
                        + "   FROM OCS0116 "
                        + "  WHERE SPECIMEN_CODE = :f_specimen_code ";

                    IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
                    bindVars.Add("f_specimen_code", e.ChangeValue.ToString().Trim());

                    object retVal = Service.ExecuteScalar(cmdText, bindVars);
                    if (retVal != null)
                    {
                        grdOCS0106.SetItemValue(e.RowNumber, "specimen_name", retVal.ToString());
                    }
                    else
                    {
                        mbxMsg = Resources.MSG013_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void grdOCS0106_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
        {
            if (e.ColName == "specimen_code")
                grdOCS0106.SetItemValue(e.RowNumber, "specimen_name", e.ReturnValues.GetValue(1).ToString());
        }

        private void grdOCS0106_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.ToString() == "Y")
            {
                for (int i = 0; i < grdOCS0106.RowCount; i++)
                {
                    if (i != e.RowNumber)
                        grdOCS0106.SetItemValue(i, "default_yn", "N");
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
                    break;
                case FunctionType.Update:
                    break;
                case FunctionType.Delete:
                    break;
                case FunctionType.Close:
                    
                   
                    if (this.grdOCS0106.RowCount == 0)
                    { 
                        if(this.grdOCS0106.DeletedRowTable!=null && this.grdOCS0106.DeletedRowTable.Rows.Count >0 )

                            if (XMessageBox.Show(Resources.MSG014_MSG, Resources.MSG014_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                xButtonList1.PerformClick(FunctionType.Update);
                            }
                            else
                            {
                                return;
                            }

                        return;
                    }

                    //1行以上残して削除及び追加・修正したとき
                    for (int i = 0; i < this.grdOCS0106.RowCount; i++)
                    {
                        //削除
                        if (this.grdOCS0106.DeletedRowTable != null &&
                            this.grdOCS0106.DeletedRowTable.Rows.Count > 0)
                        {
                            if (XMessageBox.Show(Resources.MSG014_MSG, Resources.MSG014_CAP,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                xButtonList1.PerformClick(FunctionType.Update);
                            }
                            else
                            {
                                return;
                            }

                            return;
                        }
                        //追加・修正
                        if (this.grdOCS0106.LayoutTable.Rows[i].RowState == DataRowState.Added ||
                            this.grdOCS0106.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                        {
                            if (XMessageBox.Show(Resources.MSG015_MSG, Resources.MSG014_CAP,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                xButtonList1.PerformClick(FunctionType.Update);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [Save Starting / End]
        private void grdOCS0106_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            isgrdOCS0106Save = e.IsSuccess;
            isSaved0106 = true;

            if (isSaved0106)
            {
                if (isgrdOCS0106Save)
                {
                    mbxMsg = Resources.MSG016_MSG;
                    SetMsg(mbxMsg);
                }
                else
                {
                    mbxMsg = Resources.MSG017_MSG;
                    mbxCap = "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }

                isgrdOCS0106Save = false;
                isSaved0106 = false;
            }
        }

        private void grdOCS0106_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            for (int rowIndex = 0; rowIndex < grdOCS0106.RowCount; rowIndex++)
            {
                if (grdOCS0106.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0106.GetItemString(rowIndex, "specimen_code").Trim() == "")
                    {
                        grdOCS0106.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (grdOCS0106.GetItemString(rowIndex, "specimen_name").Trim() == "")
                {
                    mbxMsg = Resources.MSG013_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0106.SetFocusToItem(rowIndex, "specimen_code");
                    return;
                }

                //slip_code
                grdOCS0106.SetItemValue(rowIndex, "slip_code", slip_code);

                //serial
                grdOCS0106.SetItemValue(rowIndex, "seq", rowIndex + 1);
            }
        }
        #endregion

        #region 그리드에 바인드 변수(병원코드) 설정
        private void grdOCS0106_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0106.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        #region [SavePerformer Class]
        private class XSavePerformer : ISavePerformer
        {
            private frmOCS0106 parent = null;
            private string cmdText = String.Empty;

            public XSavePerformer(frmOCS0106 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                if (item.BindVarList["f_default_yn"].VarValue == "") item.BindVarList["f_default_yn"].VarValue = "N";

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        //  UPD_DATE,UPD_ID 주가
                        cmdText = @"
								INSERT INTO OCS0106
							          ( SYS_DATE,
                                        SYS_ID,
                                        SLIP_CODE,
                                        SPECIMEN_CODE,
                                        DEFAULT_YN,
                                        SEQ,
                                        HOSP_CODE,
                                        UPD_DATE,
                                        UPD_ID)
								 VALUES
							          ( SYSDATE,
                                        :f_user_id,
                                        :f_slip_code,
                                        :f_specimen_code,
                                        :f_default_yn,
                                        :f_seq,
                                        :f_hosp_code,
                                         SYSDATE,
                                        :f_user_id
                                      )";
                        break;
                    case DataRowState.Modified:
                        cmdText = @"UPDATE OCS0106
									   SET UPD_ID        = :f_user_id,
										   UPD_DATE      = SYSDATE,
										   SLIP_CODE     = :f_slip_code    ,
										   SPECIMEN_CODE = :f_specimen_code,
										   SEQ           = :f_seq          ,
										   DEFAULT_YN    = :f_default_yn 
									 WHERE SLIP_CODE     = :f_slip_code
									   AND SPECIMEN_CODE = :f_specimen_code
                                       AND HOSP_CODE     = :f_hosp_code";
                        break;
                    case DataRowState.Deleted:
                        cmdText = @"DELETE OCS0106
									 WHERE SLIP_CODE     = :f_slip_code
									   AND SPECIMEN_CODE = :f_specimen_code
                                       AND HOSP_CODE     = :f_hosp_code";
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
    }
}
