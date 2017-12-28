#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG2010Q02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG2010Q03 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XDatePicker dptFromDate;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XDatePicker dptToDate;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XEditGrid grdPRNList;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XDWWorker dwPrint;
        private XLabel xLabel2;
        private XDictComboBox cbxBuseo;
        private XLabel xLabel7;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell12;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DRG2010Q03()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG2010Q03));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dptToDate = new IHIS.Framework.XDatePicker();
            this.dptFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdPRNList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.dwPrint = new IHIS.Framework.XDWWorker();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPRNList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(5, 579);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1157, 36);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(911, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dptToDate);
            this.xPanel1.Controls.Add(this.dptFromDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.cbxBuseo);
            this.xPanel1.Controls.Add(this.xLabel7);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1157, 36);
            this.xPanel1.TabIndex = 3;
            // 
            // dptToDate
            // 
            this.dptToDate.Location = new System.Drawing.Point(328, 8);
            this.dptToDate.Name = "dptToDate";
            this.dptToDate.Size = new System.Drawing.Size(96, 20);
            this.dptToDate.TabIndex = 2;
            this.dptToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dptToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dptFromDate_DataValidating);
            // 
            // dptFromDate
            // 
            this.dptFromDate.Location = new System.Drawing.Point(222, 8);
            this.dptFromDate.Name = "dptFromDate";
            this.dptFromDate.Size = new System.Drawing.Size(96, 20);
            this.dptFromDate.TabIndex = 0;
            this.dptFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dptFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dptFromDate_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel2.Location = new System.Drawing.Point(142, 8);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(80, 20);
            this.xLabel2.TabIndex = 298;
            this.xLabel2.Text = "実施日付";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxBuseo
            // 
            this.cbxBuseo.Location = new System.Drawing.Point(44, 7);
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.Size = new System.Drawing.Size(92, 21);
            this.cbxBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxBuseo.TabIndex = 296;
            this.cbxBuseo.UserSQL = resources.GetString("cbxBuseo.UserSQL");
            this.cbxBuseo.SelectionChangeCommitted += new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel7.Location = new System.Drawing.Point(4, 7);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(40, 21);
            this.xLabel7.TabIndex = 297;
            this.xLabel7.Text = "病棟";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel4
            // 
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel4.Location = new System.Drawing.Point(314, 12);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(16, 20);
            this.xLabel4.TabIndex = 24;
            this.xLabel4.Text = "~";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdPRNList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 41);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(1157, 538);
            this.xPanel2.TabIndex = 4;
            // 
            // grdPRNList
            // 
            this.grdPRNList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell19,
            this.xEditGridCell18,
            this.xEditGridCell17,
            this.xEditGridCell33,
            this.xEditGridCell21,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell30,
            this.xEditGridCell12});
            this.grdPRNList.ColPerLine = 15;
            this.grdPRNList.Cols = 16;
            this.grdPRNList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPRNList.FixedCols = 1;
            this.grdPRNList.FixedRows = 1;
            this.grdPRNList.HeaderHeights.Add(27);
            this.grdPRNList.Location = new System.Drawing.Point(2, 2);
            this.grdPRNList.Name = "grdPRNList";
            this.grdPRNList.QuerySQL = resources.GetString("grdPRNList.QuerySQL");
            this.grdPRNList.ReadOnly = true;
            this.grdPRNList.RowHeaderVisible = true;
            this.grdPRNList.Rows = 2;
            this.grdPRNList.Size = new System.Drawing.Size(1151, 532);
            this.grdPRNList.TabIndex = 0;
            this.grdPRNList.ToolTipActive = true;
            this.grdPRNList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPRNList_QueryStarting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "order_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.HeaderText = "オーダ日付";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "doctor_name";
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.HeaderText = "診療医";
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell26.CellName = "bunho";
            this.xEditGridCell26.Col = 5;
            this.xEditGridCell26.HeaderText = "患者番号";
            this.xEditGridCell26.SuppressRepeating = true;
            this.xEditGridCell26.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellLen = 50;
            this.xEditGridCell27.CellName = "suname";
            this.xEditGridCell27.CellWidth = 140;
            this.xEditGridCell27.Col = 6;
            this.xEditGridCell27.HeaderText = "患者氏名";
            this.xEditGridCell27.SuppressRepeating = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ho_dong";
            this.xEditGridCell5.CellWidth = 30;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.HeaderText = "病棟";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "ho_code";
            this.xEditGridCell6.CellWidth = 30;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.HeaderText = "病室";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 15;
            this.xEditGridCell7.CellName = "hangmog_code";
            this.xEditGridCell7.Col = 7;
            this.xEditGridCell7.HeaderText = "項目コード";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 30;
            this.xEditGridCell8.CellName = "hangmog_name";
            this.xEditGridCell8.CellWidth = 229;
            this.xEditGridCell8.Col = 8;
            this.xEditGridCell8.HeaderText = "項目コード名";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "suryang";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.CellWidth = 30;
            this.xEditGridCell19.Col = 9;
            this.xEditGridCell19.HeaderText = "数量";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell18.CellName = "dv_time";
            this.xEditGridCell18.CellWidth = 30;
            this.xEditGridCell18.Col = 11;
            this.xEditGridCell18.HeaderText = "DV";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dv";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.CellWidth = 30;
            this.xEditGridCell17.Col = 12;
            this.xEditGridCell17.HeaderText = "回数";
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "nalsu";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell33.CellWidth = 30;
            this.xEditGridCell33.Col = 13;
            this.xEditGridCell33.HeaderText = "日数";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "ord_danui";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "ord_danui";
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ord_danui_name";
            this.xEditGridCell9.CellWidth = 40;
            this.xEditGridCell9.Col = 10;
            this.xEditGridCell9.HeaderText = "単位";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bogyong_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "bogyong_code";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 30;
            this.xEditGridCell30.CellName = "bogyong_name";
            this.xEditGridCell30.CellWidth = 120;
            this.xEditGridCell30.Col = 14;
            this.xEditGridCell30.HeaderText = "服用法";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "acting_date";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.Col = 15;
            this.xEditGridCell12.HeaderText = "実施日付";
            // 
            // dwPrint
            // 
            this.dwPrint.DataWindowObject = "d_drg900";
            this.dwPrint.IsPreviewStatusPopup = true;
            this.dwPrint.LibraryList = "..\\DRGS\\drgs.drg2010q03.pbd";
            this.dwPrint.PaperSize = IHIS.Framework.DataWindowPaperSize.A4;
            this.dwPrint.PrintStart += new System.ComponentModel.CancelEventHandler(this.dwPrint_PrintStart);
            // 
            // DRG2010Q03
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlBottom);
            this.Name = "DRG2010Q03";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1167, 620);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.DRG2010Q03_ScreenOpen);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPRNList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Common Properties
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    if (!this.grdPRNList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
                    break;
                case FunctionType.Print:
                    dwPrint.Print();
                    break;
                default:
                    break;
            }
        }

        private void DRG2010Q03_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            this.dptFromDate.SetDataValue(EnvironInfo.GetSysDate());
            this.dptToDate.SetDataValue(EnvironInfo.GetSysDate());

            this.cbxBuseo.SelectedIndex = 0;
        }

        //private void grdPHY1002_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        //{
        //    if (e.DataRow["dc_yn"].ToString() == "Y")
        //    {
        //        e.DrawMiddleLine = true;
        //        e.MiddleLineColor = Color.Red;

        //    }
        //}

        private void dwPrint_PrintStart(object sender, CancelEventArgs e)
        {
            this.dwPrint.SourceTable = this.grdPRNList.LayoutTable;
        }

        private void grdPRNList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPRNList.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdPRNList.SetBindVarValue("f_from_date", dptFromDate.GetDataValue());
            this.grdPRNList.SetBindVarValue("f_to_date", dptToDate.GetDataValue());
            this.grdPRNList.SetBindVarValue("f_ho_dong", cbxBuseo.GetDataValue());
        }

        private void cbxBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void dptFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
    }
}

