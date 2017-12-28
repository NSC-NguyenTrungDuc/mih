/****************************************************************************
 * 프로그램명: ADM101U
 *  내    용 : 그룹/시스템을 조회, 입력, 수정, 삭제
 *  작 성 자 : 김민수
 *  날    짜 : 2005.2.1
 * *************************************************************************/

#region 사용 NameSpace 지정
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using IHIS.ADMA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.ADMA
{
    /// <summary>
    /// ADM101U에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class ADM101U : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XEditGrid grdSystem;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XMstGrid grdGroup;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XFindWorker fwkBuseoQry;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private XTextBox xTextBox1;
        private XButton xButton1;
        private MultiLayout multiLayout1;
        private MultiLayoutItem multiLayoutItem1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ADM101U()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.btnList.PerformClick(FunctionType.Query);

            // TODO comment use connect cloud
            /*//저장 Layout List Set
            this.SaveLayoutList.Add(this.grdGroup);
            this.SaveLayoutList.Add(this.grdSystem);
            //저장 Performer Set
            this.grdGroup.SavePerformer = new XSavePerformer(this);
            this.grdSystem.SavePerformer = grdGroup.SavePerformer;*/

            grdGroup.ParamList = new List<string>(new String[] { "f_grp_id", "f_grp_nm" });
            grdGroup.ExecuteQuery = ExecuteQueryGrdGroupItem;

            grdSystem.ParamList = new List<string>(new String[] { "f_grp_id" });
            grdSystem.ExecuteQuery = ExecuteQueryGrdSystemItem;

            fwkBuseoQry.ExecuteQuery = ExecuteQueryFwkBuseoQry;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM101U));
            this.grdSystem = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.fwkBuseoQry = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.grdGroup = new IHIS.Framework.XMstGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xTextBox1 = new IHIS.Framework.XTextBox();
            this.xButton1 = new IHIS.Framework.XButton();
            this.multiLayout1 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiLayout1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdSystem
            // 
            resources.ApplyResources(this.grdSystem, "grdSystem");
            this.grdSystem.CallerID = '2';
            this.grdSystem.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10});
            this.grdSystem.ColPerLine = 10;
            this.grdSystem.Cols = 10;
            this.grdSystem.ExecuteQuery = null;
            this.grdSystem.FixedRows = 1;
            this.grdSystem.HeaderHeights.Add(54);
            this.grdSystem.MasterLayout = this.grdGroup;
            this.grdSystem.Name = "grdSystem";
            this.grdSystem.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSystem.ParamList")));
            this.grdSystem.QuerySQL = resources.GetString("grdSystem.QuerySQL");
            this.grdSystem.Rows = 2;
            this.grdSystem.ToolTipActive = true;
            this.grdSystem.UseDefaultTransaction = false;
            this.grdSystem.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdSystem_GridColumnChanged);
            this.grdSystem.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdSystem_SaveEnd);
            this.grdSystem.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSystem_GridCellPainting);
            this.grdSystem.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdSystem_GridColumnProtectModify);
            this.grdSystem.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSystem_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 1;
            this.xEditGridCell3.CellName = "grp_id";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 4;
            this.xEditGridCell4.CellName = "sys_id";
            this.xEditGridCell4.CellWidth = 73;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 20;
            this.xEditGridCell5.CellName = "sys_nm";
            this.xEditGridCell5.CellWidth = 65;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sys_seq";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.CellWidth = 40;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "adm_sys_yn";
            this.xEditGridCell13.CellWidth = 49;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.InitValue = "Y";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "msg_sys_yn";
            this.xEditGridCell14.CellWidth = 48;
            this.xEditGridCell14.Col = 4;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.InitValue = "N";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "sys_desc";
            this.xEditGridCell15.CellWidth = 79;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "mang_dept";
            this.xEditGridCell7.CellWidth = 63;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.FindWorker = this.fwkBuseoQry;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkBuseoQry
            // 
            this.fwkBuseoQry.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkBuseoQry.ExecuteQuery = null;
            this.fwkBuseoQry.FormText = "부서코드검색";
            this.fwkBuseoQry.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkBuseoQry.ParamList")));
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "buseoCode";
            this.findColumnInfo1.ColWidth = 106;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "buseoName";
            this.findColumnInfo2.ColWidth = 238;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "mang_dept_nm";
            this.xEditGridCell8.CellWidth = 76;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "mang_dept1";
            this.xEditGridCell9.CellWidth = 71;
            this.xEditGridCell9.Col = 9;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "mang_dept_nm1";
            this.xEditGridCell10.CellWidth = 78;
            this.xEditGridCell10.Col = 8;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // grdGroup
            // 
            resources.ApplyResources(this.grdGroup, "grdGroup");
            this.grdGroup.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell16});
            this.grdGroup.ColPerLine = 5;
            this.grdGroup.Cols = 5;
            this.grdGroup.ExecuteQuery = null;
            this.grdGroup.FixedRows = 1;
            this.grdGroup.HeaderHeights.Add(54);
            this.grdGroup.Name = "grdGroup";
            this.grdGroup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGroup.ParamList")));
            this.grdGroup.QuerySQL = resources.GetString("grdGroup.QuerySQL");
            this.grdGroup.Rows = 2;
            this.grdGroup.ToolTipActive = true;
            this.grdGroup.UseDefaultTransaction = false;
            this.grdGroup.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdGroup_QueryEnd);
            this.grdGroup.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGroup_QueryStarting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 3;
            this.xEditGridCell11.CellName = "grp_id";
            this.xEditGridCell11.CellWidth = 62;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell11.IsNotNull = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 20;
            this.xEditGridCell12.CellName = "grp_nm";
            this.xEditGridCell12.CellWidth = 107;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCell12.IsNotNull = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "grp_seq";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.CellWidth = 32;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "grp_desc";
            this.xEditGridCell2.CellWidth = 62;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 3;
            this.xEditGridCell16.CellName = "disp_grp_id";
            this.xEditGridCell16.CellWidth = 72;
            this.xEditGridCell16.Col = 3;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell16.IsNotNull = true;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xTextBox1
            // 
            this.xTextBox1.AccessibleDescription = null;
            this.xTextBox1.AccessibleName = null;
            resources.ApplyResources(this.xTextBox1, "xTextBox1");
            this.xTextBox1.BackgroundImage = null;
            this.xTextBox1.Name = "xTextBox1";
            // 
            // xButton1
            // 
            this.xButton1.AccessibleDescription = null;
            this.xButton1.AccessibleName = null;
            resources.ApplyResources(this.xButton1, "xButton1");
            this.xButton1.BackgroundImage = null;
            this.xButton1.Name = "xButton1";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // multiLayout1
            // 
            this.multiLayout1.ExecuteQuery = null;
            this.multiLayout1.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1});
            this.multiLayout1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("multiLayout1.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "grp_nm";
            // 
            // ADM101U
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.xTextBox1);
            this.Controls.Add(this.grdSystem);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdGroup);
            this.Controls.Add(this.btnList);
            this.Name = "ADM101U";
            ((System.ComponentModel.ISupportInitialize)(this.grdSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiLayout1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        #region OnLoad
        //detail grid의 relationkey를 셋팅
        protected override void OnLoad(EventArgs e)
        {
            // TODO:  ADM101U.OnLoad 구현을 추가합니다.
            base.OnLoad(e);

            this.grdSystem.SetRelationKey("grp_id", "grp_id");
            this.grdSystem.SetRelationTable("ADM0200");
            //최초 입력가능하도록 행입력
            this.grdGroup.InsertRow();
        }
        #endregion

        #region 버튼클릭이벤트
        // 버튼클릭시 이벤트 처리(delete시 확인창 띄움)
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            Service.debugFileWrite("2010.05.08. kimminsoo ADM101U");
            /*if (e.Func == FunctionType.Insert)
            {
                if (this.CurrMSLayout == this.grdGroup)
                {
                    for (int i = 0; i < this.grdGroup.RowCount; i++)
                    {
                        if (grdGroup.LayoutTable.Rows[i].RowState == DataRowState.Added)
                        {
                            e.IsBaseCall = false;
                            XMessageBox.Show(Resources.MSG_1, Resources.Caption_1);
                            break;
                        }
                    }
                }
            }
            // delete가 일어났을 때,
            else if (e.Func == FunctionType.Delete)
            {
                
            } */

            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    grdGroup.QueryLayout(false);
                    grdSystem.QueryLayout(false);
                    break;
                case FunctionType.Insert:
                    if (this.CurrMSLayout == this.grdGroup)
                    {
                        for (int i = 0; i < this.grdGroup.RowCount; i++)
                        {
                            if (grdGroup.LayoutTable.Rows[i].RowState == DataRowState.Added)
                            {
                                e.IsBaseCall = false;
                                XMessageBox.Show(Resources.MSG_1, Resources.Caption_1);
                                break;
                            }
                        }
                    }
                    break;
                case FunctionType.Update:
                    if (ADM101USaveLayout())
                        XMessageBox.Show(Resources.MSG_2, Resources.MSG_Caption_1, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case FunctionType.Delete:
                    break;
            }
        }
        #endregion

        private void grdGroup_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Group 조회전 Bind 변수 SET
            int rowNum = grdGroup.CurrentRowNumber;
            if (rowNum >= 0)
            {
                //f_grp_id, f_grp_nm
                //grdGroup.SetBindVarValue("f_grp_id", grdGroup.GetItemString(rowNum, "grp_id"));
                //grdGroup.SetBindVarValue("f_grp_nm", grdGroup.GetItemString(rowNum, "grp_nm"));
            }
        }

        private void grdSystem_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //조회 Bind 변수 SET
            int rowNum = grdGroup.CurrentRowNumber;
            if (rowNum >= 0)
                grdSystem.SetBindVarValue("f_grp_id", grdGroup.GetItemString(rowNum, "grp_id"));
        }

        private void grdSystem_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            //주관부서  Check
            if ((e.ColName == "mang_dept") || (e.ColName == "mang_dept1"))
            {
                // TODO comment use connect cloud
                /*string cmdText
                    = "SELECT A.BUSEO_NAME FROM BAS0260 A "
                    + " WHERE A.BUSEO_CODE = :f_buseo_code"
                    + "   AND A.BUSEO_YMD = (SELECT MAX(B.BUSEO_YMD) FROM BAS0260 B WHERE A.BUSEO_CODE = B.BUSEO_CODE)";
                //BIND 변수 SET
                BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_buseo_code", e.ChangeValue.ToString());
                object retVal = Service.ExecuteScalar(cmdText, bindVars);*/

                // Connect to cloud
                ADM101UGrdSystemGridColumnChangedArgs vADM101UGrdSystemGridColumnChangedArgs = new ADM101UGrdSystemGridColumnChangedArgs();
                vADM101UGrdSystemGridColumnChangedArgs.BuseoCode = e.ChangeValue.ToString();
                ADM101UGrdSystemGridColumnChangedResult result =
                    CloudService.Instance
                        .Submit<ADM101UGrdSystemGridColumnChangedResult, ADM101UGrdSystemGridColumnChangedArgs>(
                            vADM101UGrdSystemGridColumnChangedArgs);
                if (result == null || result.ExecutionStatus != ExecutionStatus.Success || result.ItemInfo == null
                    || result.ItemInfo.Count < 0)
                {
                    this.SetMsg(XMsg.GetMsg("M001"), MsgType.Error); //부서코드를 잘못 입력하셨습니다.
                    e.Cancel = true;
                    return;
                }
                if (e.ColName == "mang_dept")
                    grdSystem.SetItemValue(e.RowNumber, "mang_dept_nm", result.ItemInfo[0].DataValue);
                else
                    grdSystem.SetItemValue(e.RowNumber, "mang_dept_nm1", result.ItemInfo[0].DataValue);
            }
        }


        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private ADM101U parent = null;
            public XSavePerformer(ADM101U parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("f_user_id", UserInfo.UserID);

                switch (callerID)
                {
                    case '1':  //그룹 List 저장
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText
                                    = "INSERT INTO ADM0100 "
                                    + " (GRP_ID,    GRP_NM,    GRP_SEQ,    GRP_DESC, DISP_GRP_ID, CR_MEMB, CR_TIME, CR_TRM ) "
                                    + "VALUES"
                                    + " (:f_grp_id, :f_grp_nm, :f_grp_seq, :f_grp_desc, :f_disp_grp_id, :f_user_id, SYSDATE, NULL)";
                                break;
                            case DataRowState.Modified:
                                cmdText
                                    = "UPDATE ADM0100"
                                    + "   SET GRP_SEQ     = :f_grp_seq"
                                    + "      ,GRP_NM      = :f_grp_nm"
                                    + "      ,GRP_DESC    = :f_grp_desc"
                                    + "      ,DISP_GRP_ID = :f_disp_grp_id"
                                    + "      ,UP_MEMB     = :f_user_id"
                                    + "      ,UP_TIME     = SYSDATE"
                                    + " WHERE GRP_ID      = :f_grp_id";
                                break;
                            case DataRowState.Deleted:
                                cmdText
                                    = "DELETE ADM0100"
                                    + " WHERE GRP_ID = :f_grp_id";
                                break;
                        }
                        break;
                    case '2':  //시스템 List 저장
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText
                                    = "INSERT INTO ADM0200"
                                    + " (GRP_ID, SYS_ID, SYS_NM, SYS_SEQ, ADM_SYS_YN, MSG_SYS_YN, SYS_DESC, MANG_DEPT, MANG_DEPT1, CR_MEMB, CR_TIME)"
                                    + " VALUES"
                                    + " (:f_grp_id, :f_sys_id, :f_sys_nm, :f_sys_seq, :f_adm_sys_yn, :f_msg_sys_yn, :f_sys_desc, :f_mang_dept, :f_mang_dept1, :f_user_id, SYSDATE)";
                                break;
                            case DataRowState.Modified:
                                cmdText
                                    = "UPDATE ADM0200"
                                    + "   SET GRP_ID     = :f_grp_id"
                                    + "      ,SYS_NM     = :f_sys_nm"
                                    + "      ,ADM_SYS_YN = :f_adm_sys_yn"
                                    + "      ,MSG_SYS_YN = :f_msg_sys_yn"
                                    + "      ,SYS_SEQ    = :f_sys_seq"
                                    + "      ,SYS_DESC   = :f_sys_desc"
                                    + "      ,MANG_DEPT  = :f_mang_dept"
                                    + "      ,MANG_DEPT1 = :f_mang_dept1"
                                    + "      ,UP_MEMB    = :f_user_id"
                                    + "      ,UP_TIME    = SYSDATE"
                                    + " WHERE SYS_ID     = :f_sys_id";
                                break;
                            case DataRowState.Deleted:
                                cmdText
                                    = "DELETE ADM0200 WHERE SYS_ID = :f_sys_id";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdGroup_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                string test = grdGroup.GetItemString(5, "grp_nm");

                System.Text.Encoding utf8 = System.Text.Encoding.GetEncoding("UTF-8");

                System.Text.Encoding a949 = System.Text.Encoding.GetEncoding(949);

                System.Text.Encoding shift = System.Text.Encoding.GetEncoding(932);



                byte[] bt = utf8.GetBytes(test);

                char[] ch = utf8.GetChars(bt);

                byte[] bt2 = shift.GetBytes(ch);

                string a = a949.GetString(bt2);

                xTextBox1.Text = a;

            }
            else
            {
                MessageBox.Show(e.ErrMsg);
            }
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            // TODO comment use connect to cloud
            /*this.multiLayout1.QuerySQL = @"select grp_nm from adm0100 where grp_id = 'OUT'";
            this.multiLayout1.QueryLayout(true);

            string test = this.multiLayout1.GetItemString(0, "grp_nm");*/

            // Connect to cloud
            string test = "";
            ADM101UGetGrpNmArgs args = new ADM101UGetGrpNmArgs();
            ADM101UGetGrpNmResult grpNmResult =
                CloudService.Instance.Submit<ADM101UGetGrpNmResult, ADM101UGetGrpNmArgs>(args);
            if (grpNmResult != null && grpNmResult.ExecutionStatus == ExecutionStatus.Success)
            {
                test = grpNmResult.GrpNm;
            }

            System.Text.Encoding utf8 = System.Text.Encoding.GetEncoding("UTF-8");

            System.Text.Encoding a949 = System.Text.Encoding.GetEncoding(949);

            System.Text.Encoding shift = System.Text.Encoding.GetEncoding(932);



            byte[] bt = utf8.GetBytes(test);

            char[] ch = utf8.GetChars(bt);

            byte[] bt2 = shift.GetBytes(ch);

            string a = shift.GetString(bt);

            xTextBox1.Text = a;

            //this.xTextBox1.Text = test;

        }

        private void grdSystem_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (!e.IsSuccess)
            {
                XMessageBox.Show(e.ErrMsg);
            }
        }

        private void grdSystem_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {

        }

        private void grdSystem_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            //switch (e.ColName)
            //{
            //    case "sys_id":
            //        e.Protect = true;
            //        break;
            //}
        }

        #region Connect to cloud service
        /// <summary>
        /// ExecuteQueryGrdGroupItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdGroupItem(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM101UGrdGroupArgs vADM101UGrdGroupArgs = new ADM101UGrdGroupArgs();
            vADM101UGrdGroupArgs.GrpId = bc["f_grp_id"] != null ? bc["f_grp_id"].VarValue : "";
            vADM101UGrdGroupArgs.GrpNm = bc["f_grp_nm"] != null ? bc["f_grp_nm"].VarValue : "";
            ADM101UGrdGroupResult result = CloudService.Instance.Submit<ADM101UGrdGroupResult, ADM101UGrdGroupArgs>(vADM101UGrdGroupArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM101UGrdGroupItemInfo item in result.ItemInfo)
                {
                    object[] objects =
                    {
                        item.GrpId,
                        item.GrpNm,
                        item.GrpSeq,
                        item.GrpDesc,
                        item.DispGrpId
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdSystemItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdSystemItem(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM101UGrdSystemArgs vADM101UGrdSystemArgs = new ADM101UGrdSystemArgs();
            vADM101UGrdSystemArgs.GrpId = bc["f_grp_id"] != null ? bc["f_grp_id"].VarValue : "";
            ADM101UGrdSystemResult result =
                CloudService.Instance.Submit<ADM101UGrdSystemResult, ADM101UGrdSystemArgs>(vADM101UGrdSystemArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM101UgrdSystemItemInfo item in result.ItemInfo)
                {
                    object[] objects =
                    {
                        item.GrpId,
                        item.SysId,
                        item.SysNm,
                        item.SysSeq,
                        item.AdmSysYn,
                        item.MsgSysYn,
                        item.SysDesc,
                        item.MangDept,
                        item.BuseoName1,
                        item.MangDept1,
                        item.BuseoName2
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryFwkBuseoQry
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryFwkBuseoQry(BindVarCollection varCollection)
        {
            List<object[]> lstObject = new List<object[]>();
            ADM101UFwkBuseoQryArgs args = new ADM101UFwkBuseoQryArgs();
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, ADM101UFwkBuseoQryArgs>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstComboListItemInfo = comboResult.ComboItem;
                if (lstComboListItemInfo != null && lstComboListItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo itemInfo in lstComboListItemInfo)
                    {
                        lstObject.Add(new object[]
	                    {
    	                    itemInfo.Code,
                            itemInfo.CodeName
	                    });
                    }

                }
            }
            return lstObject;
        }

        /// <summary>
        /// ADM101USaveLayout
        /// </summary>
        /// <returns></returns>
        private bool ADM101USaveLayout()
        {
            ADM101USaveLayoutArgs args = new ADM101USaveLayoutArgs();
            args.GrdGroupItem = CreateListADM101UGrdGroupItemInfo();
            args.GrdSystemItem = CreateListADM101UgrdSystemItemInfo();
            args.UserId = UserInfo.UserID;
            if (args.GrdGroupItem.Count <= 0 && args.GrdSystemItem.Count <= 0) return false;
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, ADM101USaveLayoutArgs>(args);
            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                XMessageBox.Show(Resources.MSG_3, Resources.MSG_Caption_1, MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check validate input
        /// </summary>
        /// <returns></returns>
        private bool checkValidate()
        {
            List<ADM101UGrdGroupItemInfo> GrdGroupItem = CreateListADM101UGrdGroupItemInfo();
            List<ADM101UgrdSystemItemInfo> GrdSystemItem = CreateListADM101UgrdSystemItemInfo();
            foreach (ADM101UgrdSystemItemInfo infoSystem in GrdSystemItem)
            {
                if (String.IsNullOrEmpty(infoSystem.SysId) || String.IsNullOrEmpty(infoSystem.SysNm) ||
                    String.IsNullOrEmpty(infoSystem.SysSeq))
                {
                    return false;
                }

            }
            foreach (ADM101UGrdGroupItemInfo infoGroup in GrdGroupItem)
            {
                if (String.IsNullOrEmpty(infoGroup.GrpSeq) || String.IsNullOrEmpty(infoGroup.GrpId) ||
                    String.IsNullOrEmpty(infoGroup.GrpNm) || String.IsNullOrEmpty(infoGroup.DispGrpId))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// CreateListADM101UGrdGroupItemInfo
        /// </summary>
        /// <returns></returns>
        private List<ADM101UGrdGroupItemInfo> CreateListADM101UGrdGroupItemInfo()
        {
            List<ADM101UGrdGroupItemInfo> listItemInfos = new List<ADM101UGrdGroupItemInfo>();
            for (int i = 0; i < grdGroup.RowCount; i++)
            {
                if (grdGroup.GetRowState(i) == DataRowState.Added || grdGroup.GetRowState(i) == DataRowState.Modified)
                {
                    ADM101UGrdGroupItemInfo info = new ADM101UGrdGroupItemInfo();
                    info.GrpId = grdGroup.GetItemString(i, "grp_id");
                    info.GrpNm = grdGroup.GetItemString(i, "grp_nm");
                    info.GrpSeq = grdGroup.GetItemString(i, "grp_seq");
                    info.GrpDesc = grdGroup.GetItemString(i, "grp_desc");
                    info.DispGrpId = grdGroup.GetItemString(i, "disp_grp_id");
                    info.DataRowState = grdGroup.GetRowState(i).ToString();
                    if (string.IsNullOrEmpty(info.GrpSeq))
                    {
                        XMessageBox.Show(Resources.MSG_SEQ, Resources.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdGroup.SetFocusToItem(i, "grp_seq");
                        return new List<ADM101UGrdGroupItemInfo>();
                    }

                    listItemInfos.Add(info);
                }
            }
            if (grdGroup.DeletedRowTable != null && grdGroup.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdGroup.DeletedRowTable.Rows)
                {
                    ADM101UGrdGroupItemInfo info = new ADM101UGrdGroupItemInfo();
                    info.GrpId = row["grp_id"].ToString();
                    info.GrpNm = row["grp_nm"].ToString();
                    info.GrpSeq = row["grp_seq"].ToString();
                    info.GrpDesc = row["grp_desc"].ToString();
                    info.DispGrpId = row["disp_grp_id"].ToString();
                    info.DataRowState = DataRowState.Deleted.ToString();

                    listItemInfos.Add(info);
                }
            }
            return listItemInfos;
        }

        /// <summary>
        /// CreateListADM101UgrdSystemItemInfo
        /// </summary>
        /// <returns></returns>
        private List<ADM101UgrdSystemItemInfo> CreateListADM101UgrdSystemItemInfo()
        {
            List<ADM101UgrdSystemItemInfo> listItemInfos = new List<ADM101UgrdSystemItemInfo>();
            for (int i = 0; i < grdSystem.RowCount; i++)
            {
                if (grdSystem.GetRowState(i) == DataRowState.Added || grdSystem.GetRowState(i) == DataRowState.Modified)
                {
                    ADM101UgrdSystemItemInfo info = new ADM101UgrdSystemItemInfo();
                    info.GrpId = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "grp_id");
                    info.SysId = grdSystem.GetItemString(i, "sys_id");
                    info.SysNm = grdSystem.GetItemString(i, "sys_nm");
                    info.SysSeq = grdSystem.GetItemString(i, "sys_seq");
                    info.AdmSysYn = grdSystem.GetItemString(i, "adm_sys_yn");
                    info.MsgSysYn = grdSystem.GetItemString(i, "msg_sys_yn");
                    info.SysDesc = grdSystem.GetItemString(i, "sys_desc");
                    info.MangDept = grdSystem.GetItemString(i, "mang_dept");
                    info.BuseoName1 = grdSystem.GetItemString(i, "mang_dept_nm");
                    info.MangDept1 = grdSystem.GetItemString(i, "mang_dept1");
                    info.BuseoName2 = grdSystem.GetItemString(i, "mang_dept_nm1");
                    info.DataRowState = grdSystem.GetRowState(i).ToString();
                    if (string.IsNullOrEmpty(info.SysSeq))
                    {
                        XMessageBox.Show(Resources.MSG_SEQ, Resources.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdGroup.SetFocusToItem(i, "sys_seq");
                        return new List<ADM101UgrdSystemItemInfo>();
                    }
                    if (string.IsNullOrEmpty(info.SysId))
                    {
                        XMessageBox.Show(Resources.MSG_SYS_ID, Resources.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdGroup.SetFocusToItem(i, "sys_id");
                        return new List<ADM101UgrdSystemItemInfo>();
                    }
                    if (string.IsNullOrEmpty(info.SysNm))
                    {
                        XMessageBox.Show(Resources.MSG_SYS_NAME, Resources.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdGroup.SetFocusToItem(i, "sys_nm");
                        return new List<ADM101UgrdSystemItemInfo>();
                    }
                    listItemInfos.Add(info);
                }
            }
            if (grdSystem.DeletedRowTable != null && grdSystem.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdSystem.DeletedRowTable.Rows)
                {
                    ADM101UgrdSystemItemInfo info = new ADM101UgrdSystemItemInfo();
                    info.GrpId = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "grp_id");
                    info.SysId = row["sys_id"].ToString();
                    info.SysNm = row["sys_nm"].ToString();
                    info.SysSeq = row["sys_seq"].ToString();
                    info.AdmSysYn = row["adm_sys_yn"].ToString();
                    info.MsgSysYn = row["msg_sys_yn"].ToString();
                    info.SysDesc = row["sys_desc"].ToString();
                    info.MangDept = row["mang_dept"].ToString();
                    info.BuseoName1 = row["mang_dept_nm"].ToString();
                    info.MangDept1 = row["mang_dept1"].ToString();
                    info.BuseoName2 = row["mang_dept_nm1"].ToString();
                    info.DataRowState = DataRowState.Deleted.ToString();

                    listItemInfos.Add(info);
                }
            }
            return listItemInfos;
        }
        #endregion
    }
}

