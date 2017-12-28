using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using IHIS.Framework;

namespace IHIS.DRGS
{
    /// <summary>
    /// FINDPA에 대한 요약 설명입니다.
    /// </summary>
    public class LockForm : IHIS.Framework.XForm
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGrid grdLockList;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XButtonList btnList;
        private ImageList imageList1;
        private XPanel xPanel2;
        private XLabel xLabel6;
        private XDatePicker dtpToDate;
        private XDatePicker dtpFromDate;
        private XLabel xLabel3;
        private IContainer components;

        public LockForm()
        {
            InitializeComponent();

            //저장 수행자 Set
            this.grdLockList.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdLockList);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockForm));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdLockList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.DRGS.Properties.Resources.layBongtuLabel3, -1, global::IHIS.DRGS.Properties.Resources.layBongtuLabel3),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "終 了", 0, global::IHIS.DRGS.Properties.Resources.layBongtuLabel3),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "開 始", 1, global::IHIS.DRGS.Properties.Resources.layBongtuLabel3),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.DRGS.Properties.Resources.layBongtuLabel3, -1, global::IHIS.DRGS.Properties.Resources.layBongtuLabel3)});
            this.btnList.ImageList = this.imageList1;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SecurityLock.ico");
            this.imageList1.Images.SetKeyName(1, "진료의사.gif");
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdLockList);
            this.xPanel3.Controls.Add(this.xPanel2);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdLockList
            // 
            resources.ApplyResources(this.grdLockList, "grdLockList");
            this.grdLockList.ApplyPaintEventToAllColumn = true;
            this.grdLockList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell10});
            this.grdLockList.ColPerLine = 6;
            this.grdLockList.Cols = 7;
            this.grdLockList.ExecuteQuery = null;
            this.grdLockList.FixedCols = 1;
            this.grdLockList.FixedRows = 1;
            this.grdLockList.HeaderHeights.Add(33);
            this.grdLockList.Name = "grdLockList";
            this.grdLockList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdLockList.ParamList")));
            this.grdLockList.QuerySQL = resources.GetString("grdLockList.QuerySQL");
            this.grdLockList.RowHeaderVisible = true;
            this.grdLockList.Rows = 2;
            this.grdLockList.ToolTipActive = true;
            this.grdLockList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdLockList_GridCellPainting);
            this.grdLockList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdLockList_QueryStarting);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "key";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "start_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 120;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "start_time";
            this.xEditGridCell2.CellWidth = 50;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.Mask = "##:##";
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "end_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 120;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "end_time";
            this.xEditGridCell4.CellWidth = 50;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.Mask = "##:##";
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "input_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 100;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "input_user";
            this.xEditGridCell6.CellWidth = 90;
            this.xEditGridCell6.Col = 6;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "cancel_date";
            this.xEditGridCell7.CellWidth = 100;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "cancel_user";
            this.xEditGridCell8.CellWidth = 90;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "cancel_yn";
            this.xEditGridCell10.CellWidth = 34;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.dtpToDate);
            this.xPanel2.Controls.Add(this.dtpFromDate);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel6.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // dtpToDate
            // 
            this.dtpToDate.AccessibleDescription = null;
            this.dtpToDate.AccessibleName = null;
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.BackgroundImage = null;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtp_DataValidating);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.AccessibleDescription = null;
            this.dtpFromDate.AccessibleName = null;
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.BackgroundImage = null;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtp_DataValidating);
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackColor = IHIS.Framework.XColor.XListBoxBackColor;
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XGridSelectedCellBackColor;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // LockForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "LockForm";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel3, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLockList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());
            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(-7));

            if (!grdLockList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }
        #endregion

        private void processLock()
        {
            if (grdLockList.RowCount > 0)
            {
                if (TypeCheck.IsNull(grdLockList.GetItemValue(0, "end_date"))) return;
            }
            int row = grdLockList.InsertRow(0);
            
            grdLockList.SetItemValue(row, "start_date", EnvironInfo.GetSysDate());
            grdLockList.SetItemValue(row, "start_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
            
            
            if (!grdLockList.SaveLayout()) XMessageBox.Show(Service.ErrFullMsg); 
            if (!grdLockList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }


        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void xButton1_Click(object sender, System.EventArgs e)
        {
            int row = grdLockList.InsertRow(0);

            grdLockList.SetItemValue(row, "start_date", EnvironInfo.GetSysDate());
            grdLockList.SetItemValue(row, "start_time", "1730");
            grdLockList.SetItemValue(row, "end_date", EnvironInfo.GetSysDate().AddDays(1));
            grdLockList.SetItemValue(row, "end_time", "0800");
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    if (!grdLockList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    processLock();
                    break;
                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    processUnLock();
                    break;
            
            }
        }

        private void grdLockList_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (grdLockList.GetItemString(e.RowNumber, "cancel_yn") == "Y")
                e.ForeColor = Color.OrangeRed;
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            int row = grdLockList.InsertRow(0);

            grdLockList.SetItemValue(row, "start_date", EnvironInfo.GetSysDate());
            grdLockList.SetItemValue(row, "start_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));

            if (!grdLockList.SaveLayout()) { XMessageBox.Show(Service.ErrFullMsg); return; }
            if (!grdLockList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        private void processUnLock()
        {
            for (int i = 0; i < grdLockList.RowCount; i++)
            {
                if ((grdLockList.GetItemString(i, "end_date") == "") && (grdLockList.GetItemString(i, "cancel_yn") == "N"))
                {
                    grdLockList.SetItemValue(i, "end_date", EnvironInfo.GetSysDate());
                    grdLockList.SetItemValue(i, "end_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                }
            }

            if (!grdLockList.SaveLayout()) XMessageBox.Show(Service.ErrFullMsg);
            if (!grdLockList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }


        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private LockForm parent = null;
            public XSavePerformer(LockForm parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 q_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                switch (item.RowState)
                {
                    case DataRowState.Modified:
                        cmdText = @"UPDATE DRG9043
                                       SET UPD_ID      = :q_user_id
                                         , UPD_DATE    = SYSDATE
                                         , END_DATE    = :f_end_date
                                         , END_TIME    = :f_end_time
                                         , CANCEL_DATE = DECODE(:f_cancel_yn,'Y',TRUNC(SYSDATE),NULL)
                                         , CANCEL_USER = :q_user_id
                                     WHERE ROWID       = :f_key";
                        break;
                    case DataRowState.Added:
                        cmdText = @"INSERT INTO DRG9043( SYS_DATE
                                                        ,SYS_ID
                                                        ,UPD_DATE
                                                        ,UPD_ID
                                                        ,START_DATE
                                                        ,START_TIME
                                                        ,END_DATE
                                                        ,END_TIME
                                                        ,INPUT_DATE
                                                        ,INPUT_USER
                                                        ,CANCEL_DATE
                                                        ,CANCEL_USER
                                                        ,HOSP_CODE
                                                        )
                                                 VALUES( SYSDATE
                                                        ,:q_user_id
                                                        ,SYSDATE
                                                        ,:q_user_id
                                                        ,:f_start_date
                                                        ,:f_start_time
                                                        ,:f_end_date
                                                        ,:f_end_time
                                                        ,TRUNC(SYSDATE)
                                                        ,:q_user_id
                                                        ,NULL
                                                        ,NULL
                                                        ,FN_ADM_LOAD_HOSP_CODE()
                                                        )";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdLockList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdLockList.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            grdLockList.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
        }

        private void dtp_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.grdLockList.QueryLayout(true);
        }
    }
}
