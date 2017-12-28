#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IFC.ADMA.Properties;
using IHIS.CloudConnector;
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
    /// ADM108U에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class ADM108U : IHIS.Framework.XScreen
    {
        private TreeNode selectedNode = null;  //선택된 Node
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XFindWorker fwkPgmID;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.MultiLayout laySysList;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private XPanel pnlTop;
        private XPanel pnlLeft;
        private XTreeView tvwSystem;
        private XPanel pnlRight;
        private XEditGrid grdList;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XDisplayBox dbxHospitalNm;
        private XFindBox fbxHospitalID;
        private XLabel xLabel4;
        private XFindWorker fwkHospitalID;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ADM108U()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            grdList.ParamList = CreateGrdListParamList();
            grdList.ExecuteQuery = LoadGrdList;
            fwkPgmID.ExecuteQuery = LoadFwkPgmId;
            laySysList.ExecuteQuery = LoadLaySysList;

            // MED-14133
            this.ApplyMultiHospital();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM108U));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.fwkPgmID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.laySysList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.dbxHospitalNm = new IHIS.Framework.XDisplayBox();
            this.fbxHospitalID = new IHIS.Framework.XFindBox();
            this.fwkHospitalID = new IHIS.Framework.XFindWorker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.tvwSystem = new IHIS.Framework.XTreeView();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySysList)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
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
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // fwkPgmID
            // 
            this.fwkPgmID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4,
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkPgmID.ExecuteQuery = null;
            this.fwkPgmID.InputSQL = "SELECT A.PGM_ID, A.PGM_NM, A.SYS_ID , B.SYS_NM\r\nFROM ADM0300 A, ADM0200 B\r\nWHERE " +
                "A.SYS_ID = B.SYS_ID\r\nAND     A.PGM_TP = \'P\'  -- 프로그램만\r\nORDER BY A.SYS_ID, A.PGM_" +
                "ID";
            this.fwkPgmID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkPgmID.ParamList")));
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "pgm_id";
            this.findColumnInfo3.ColWidth = 109;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.Yes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "pgm_nm";
            this.findColumnInfo4.ColWidth = 224;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.Yes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sys_id";
            this.findColumnInfo1.ColWidth = 65;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.Yes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sys_nm";
            this.findColumnInfo2.ColWidth = 141;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.Yes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // laySysList
            // 
            this.laySysList.ExecuteQuery = null;
            this.laySysList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.laySysList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySysList.ParamList")));
            this.laySysList.QuerySQL = "SELECT SYS_ID, SYS_NM \r\n  FROM ADM0200\r\n WHERE NVL(MSG_SYS_YN,\'N\') = \'N\' -- 메세지시스" +
                "템은 제외\r\n ORDER BY SYS_ID";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sys_id";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "sys_nm";
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.dbxHospitalNm);
            this.pnlTop.Controls.Add(this.fbxHospitalID);
            this.pnlTop.Controls.Add(this.xLabel4);
            this.pnlTop.Name = "pnlTop";
            // 
            // dbxHospitalNm
            // 
            resources.ApplyResources(this.dbxHospitalNm, "dbxHospitalNm");
            this.dbxHospitalNm.Name = "dbxHospitalNm";
            // 
            // fbxHospitalID
            // 
            this.fbxHospitalID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHospitalID.FindWorker = this.fwkHospitalID;
            resources.ApplyResources(this.fbxHospitalID, "fbxHospitalID");
            this.fbxHospitalID.Name = "fbxHospitalID";
            this.fbxHospitalID.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHospitalID_DataValidating);
            this.fbxHospitalID.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxID_FindSelected);
            this.fbxHospitalID.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxHospitalID_FindClick);
            // 
            // fwkHospitalID
            // 
            this.fwkHospitalID.ExecuteQuery = null;
            this.fwkHospitalID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkHospitalID.ParamList")));
            // 
            // xLabel4
            // 
            this.xLabel4.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvwSystem);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            // 
            // tvwSystem
            // 
            resources.ApplyResources(this.tvwSystem, "tvwSystem");
            this.tvwSystem.ImageList = this.ImageList;
            this.tvwSystem.Name = "tvwSystem";
            this.tvwSystem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSystem_AfterSelect);
            this.tvwSystem.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwSystem_BeforeSelect);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grdList);
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.Name = "pnlRight";
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdList.ColPerLine = 5;
            this.grdList.Cols = 5;
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedRows = 1;
            this.grdList.FocusColumnName = "pgm_id";
            this.grdList.HeaderHeights.Add(26);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            this.grdList.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdList_PreSaveLayout);
            this.grdList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdList_GridColumnChanged);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellLen = 100;
            this.xEditGridCell6.CellName = "sys_id";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "seq";
            this.xEditGridCell1.CellWidth = 47;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.Mask = "#";
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "pgm_sys_id";
            this.xEditGridCell2.CellWidth = 102;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "pgm_sys_nm";
            this.xEditGridCell5.CellWidth = 128;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellLen = 100;
            this.xEditGridCell3.CellName = "pgm_id";
            this.xEditGridCell3.CellWidth = 135;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.FindWorker = this.fwkPgmID;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "pgm_nm";
            this.xEditGridCell4.CellWidth = 277;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // ADM108U
            // 
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            resources.ApplyResources(this, "$this");
            this.Name = "ADM108U";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySysList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (UserInfo.AdminType != AdminType.SuperAdmin)
            {
                //시스템 리스트 조회 TreeView Set
                SetTreeView();
            }

            this.SaveLayoutList.Add(grdList);

            grdList.SavePerformer = new XSavePerformer(this);
        }
        #endregion

        private void SetTreeView()
        {
            //TreeView 구성
            this.tvwSystem.Nodes.Clear();

            //시스템 LIST 조회하여 Tree 구성
            if (this.laySysList.QueryLayout(true))
            {
                TreeNode tNode = null;
                string text = "";
                foreach (DataRow dtRow in this.laySysList.LayoutTable.Rows)
                {
                    text = dtRow["sys_id"].ToString() + "." + dtRow["sys_nm"].ToString();
                    tNode = new TreeNode(text, 0, 0);
                    tNode.Tag = dtRow["sys_id"].ToString(); //Tag에 시스템 ID 저장
                    this.tvwSystem.Nodes.Add(tNode);
                }
                this.tvwSystem.ExpandAll();
            }
        }

        private void tvwSystem_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //해당 시스템 선택시에 해당시스템의 메인 ScreenList Call
            //BIND 변수 SET (f_sys_id)
            this.grdList.SetBindVarValue("f_sys_id", e.Node.Tag.ToString());
            //Grid 조회
            this.grdList.QueryLayout(true);
            this.selectedNode = e.Node;
        }

        private void grdList_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            if (e.ColName == "pgm_id")
            {
                if (e.ChangeValue.ToString() == "") //""이면 프로그램명,시스템ID, 시스템명 Clear
                {
                    this.grdList.SetItemValue(e.RowNumber, "pgm_nm", "");
                    this.grdList.SetItemValue(e.RowNumber, "pgm_sys_id", "");
                    this.grdList.SetItemValue(e.RowNumber, "pgm_sys_nm", "");
                }
                else
                {
                    /*//입력된 프로그램ID로 프로그램명, 시스템ID등을 조회
                    string cmdText
                        = " SELECT A.PGM_NM, A.SYS_ID, B.SYS_NM"
                        + "   FROM ADM0300 A, ADM0200 B"
                        + "  WHERE A.SYS_ID = B.SYS_ID"
                        + "    AND A.PGM_TP = 'P'"
                        + "    AND A.PGM_ID = :f_pgm_id";
                    BindVarCollection bindVars = new BindVarCollection();
                    bindVars.Add("f_pgm_id", e.ChangeValue.ToString());
                    DataTable table = Service.ExecuteDataTable(cmdText, bindVars);
                    if ((table == null) || (table.Rows.Count < 1))
                    {
                        //Clear Data
                        this.grdList.SetItemValue(e.RowNumber, "pgm_nm", "");
                        this.grdList.SetItemValue(e.RowNumber, "pgm_sys_id", "");
                        this.grdList.SetItemValue(e.RowNumber, "pgm_sys_nm", "");
                        this.SetMsg(Resources.MSG_001, MsgType.Error);
                        e.Cancel = true;
                        return;
                    }
                    //컬럼 SET
                    this.grdList.SetItemValue(e.RowNumber, "pgm_nm", table.Rows[0][0].ToString());
                    this.grdList.SetItemValue(e.RowNumber, "pgm_sys_id", table.Rows[0][1].ToString());
                    this.grdList.SetItemValue(e.RowNumber, "pgm_sys_nm", table.Rows[0][2].ToString());*/

                    ADM108UTvwSystemListArgs args = new ADM108UTvwSystemListArgs();
                    args.PgmId = e.ChangeValue.ToString();
                    ADM108UTvwSystemListResult result =
                        CloudService.Instance.Submit<ADM108UTvwSystemListResult, ADM108UTvwSystemListArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.TvwSystemListItemInfo.Count > 0)
                    {
                        this.grdList.SetItemValue(e.RowNumber, "pgm_nm", result.TvwSystemListItemInfo[0].PgmNm);
                        this.grdList.SetItemValue(e.RowNumber, "pgm_sys_id", result.TvwSystemListItemInfo[0].SysId);
                        this.grdList.SetItemValue(e.RowNumber, "pgm_sys_nm", result.TvwSystemListItemInfo[0].SysNm);
                    }
                    else
                    {
                        //Clear Data
                        this.grdList.SetItemValue(e.RowNumber, "pgm_nm", "");
                        this.grdList.SetItemValue(e.RowNumber, "pgm_sys_id", "");
                        this.grdList.SetItemValue(e.RowNumber, "pgm_sys_nm", "");
                        this.SetMsg(Resources.MSG_001, MsgType.Error);
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            //저장전 순번 다시 조정
            if (e.Func == FunctionType.Update)
            {
                e.IsBaseCall = false;

                // MED-14362
                if (!CheckBeforeInsert()) return;

                ADM108USaveLayoutArgs args = new ADM108USaveLayoutArgs();
                args.GrdListItemInfo = GetGrdListForSaveLayout();
                args.UserId = UserInfo.UserID;
                // https://sofiamedix.atlassian.net/browse/MED-14133
                args.HospCode = this.mHospCode;
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, ADM108USaveLayoutArgs>(args);

                // MED-14364
                if (result.ExecutionStatus == ExecutionStatus.Success && result.Result)
                {
                    // Succeeded!
                    XMessageBox.Show(Resources.MSG005, Resources.CAP003, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    grdList.Reset();
                    grdList.QueryLayout(true);
                }
                else
                {
                    // Failed!
                    XMessageBox.Show(Resources.MSG006, Resources.CAP003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.Func == FunctionType.Query)
            {
                //시스템리스트 다시조회
                SetTreeView();
                e.IsBaseCall = false;
            }
        }

        private void tvwSystem_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            //Node 변경되기전에 Grid에 변경사항이 있으면 저장처리
            if ((this.selectedNode != null) && (this.selectedNode.Text != e.Node.Text))
            {
                //변경된 건이 있으면 저장확인
                if (grdList.GetChangedRowCount('A') > 0)
                {
                    if (XMessageBox.Show(Resources.MSG_002, Resources.CAP_002, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        this.btnList.PerformClick(FunctionType.Update);
                }
            }
        }

        private void grdList_PreSaveLayout(object sender, IHIS.Framework.GridRecordEventArgs e)
        {
            //저장전 Insert시에 sys_id SET
            if (e.RowState == DataRowState.Added)
            {
                //Tag에 저장된 Sys_ID SET
                TreeNode tNode = this.tvwSystem.SelectedNode;
                grdList.SetItemValue(e.RowNumber, "sys_id", tNode.Tag.ToString());
            }
        }

        #region [ XSavePerformer     :  입력/변경/삭제 private class ]
        /// <summary>
        /// XSavePerformer 를 private class로 선언하는 이유는 
        /// XSavePerformer의 parent (화면) 의 세부 controls 들을 제어 하기 위해서 이다. 
        /// public class 로 선언할경우 화면 내부의 값들을 제어 할수 없음.
        /// </summary>
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            /// <summary>
            /// 현재 화면 생성자(프로그램명)을 parent 로 지정 
            /// </summary>
            private ADM108U parent = null;

            /// <summary>
            /// XSavePerformer 를 사용.
            /// </summary>
            /// <param name="parent">화면 생성자 (프로그램명)</param>
            public XSavePerformer(ADM108U parent)
            {
                this.parent = parent;
            }

            /// <summary>
            /// 실제 쿼리문을 db에 보내는 함수
            /// </summary>
            /// <param name="callerID"> 각 그리드의 CallerID ( IFC 의 LayoutID와 동일 )              </param>
            /// <param name="item">     각 로우의 현재 상태를 나타낸다 . ( I/U/D >> 입력/변경/삭제 ) </param>
            /// <returns>nonquery 리턴 : 조회 문이 아닌 경우에만 사용 하는 쿼리 실행 </returns>
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //f_user_id BIND 변수 SET
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText
                            = "INSERT INTO ADM0500 (SYS_ID, SEQ, PGM_SYS_ID, PGM_ID, CR_MEMB, CR_TIME)"
                            + " VALUES(:f_sys_id, :f_seq, :f_pgm_sys_id, :f_pgm_id, :f_user_id, SYSDATE)";
                        break;
                    case DataRowState.Modified:
                        /* 순번 조정이 가능하므로 최초 UPDATE 후에 없으면 INSERT */
                        cmdText
                            = "BEGIN"
                            + "  UPDATE ADM0500"
                            + "     SET PGM_SYS_ID = :f_pgm_sys_id"
                            + "        ,PGM_ID     = :f_pgm_id"
                            + "        ,UP_MEMB    = :f_user_id"
                            + "        ,UP_TIME    = SYSDATE"
                            + "   WHERE SYS_ID = :f_sys_id"
                            + "     AND SEQ = :f_seq;"
                            + "  IF SQL%NOTFOUND THEN"
                            + "    INSERT INTO ADM0500 (SYS_ID, SEQ, PGM_SYS_ID, PGM_ID, CR_MEMB, CR_TIME) "
                            + "    VALUES(:f_sys_id, :f_seq, :f_pgm_sys_id, :f_pgm_id, :f_user_id, SYSDATE);"
                            + "  END IF; "
                            + "END;";

                        break;
                    case DataRowState.Deleted:
                        cmdText
                            = "DELETE ADM0500"
                            + " WHERE SYS_ID = :f_sys_id"
                            + "   AND SEQ    = :f_seq";
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);

            }
        }
        #endregion

        #region cloud services

        private List<string> CreateGrdListParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_sys_id");
            return paramList;
        }

        private List<object[]> LoadGrdList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM108UGrdListArgs args = new ADM108UGrdListArgs();
            args.SysId = bc["f_sys_id"] != null ? bc["f_sys_id"].VarValue : "";
            // https://sofiamedix.atlassian.net/browse/MED-14133
            args.HospCode = this.mHospCode;
            ADM108UGrdListResult result = CloudService.Instance.Submit<ADM108UGrdListResult, ADM108UGrdListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM108UGrdListItemInfo item in result.GrdListItemInfo)
                {
                    object[] objects = 
				{ 
					item.SysId, 
					item.Seq, 
					item.PgmSysId, 
					item.SysNm, 
					item.PgmId, 
					item.PgmNm
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadFwkPgmId(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM108UFwkPgmIDArgs args = new ADM108UFwkPgmIDArgs();
            args.HospCode = this.mHospCode;
            ADM108UFwkPgmIDResult result = CloudService.Instance.Submit<ADM108UFwkPgmIDResult, ADM108UFwkPgmIDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM108UFwkPgmIdListItemInfo item in result.FwkPgmIdListItemInfo)
                {
                    object[] objects = 
				{ 
					item.PgmId, 
					item.PgmNm, 
					item.SysId, 
					item.SysNm
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadLaySysList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM108ULaySysListArgs args = new ADM108ULaySysListArgs();
            // https://sofiamedix.atlassian.net/browse/MED-14133
            args.HospCode = this.mHospCode;
            ADM108ULaySysListResult result = CloudService.Instance.Submit<ADM108ULaySysListResult, ADM108ULaySysListArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                result.LaySysListItemInfo.ForEach(delegate(ComboListItemInfo item)
                {
                    res.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return res;
        }

        private List<ADM108UGrdListItemInfo> GetGrdListForSaveLayout()
        {
            List<ADM108UGrdListItemInfo> lstResult = new List<ADM108UGrdListItemInfo>();
            
            // pre save
            for (int i = 0; i < this.grdList.RowCount; i++)
            {
                if (grdList.GetRowState(i) == DataRowState.Added)
                {
                    //Tag에 저장된 Sys_ID SET
                    TreeNode tNode = this.tvwSystem.SelectedNode;                    
                    grdList.SetItemValue(i, "sys_id", tNode.Tag.ToString());
                }
            }

            for (int i = 0; i < grdList.RowCount; i++)
            {
                // https://sofiamedix.atlassian.net/browse/MED-14361
                if (grdList.GetRowState(i) == DataRowState.Unchanged) continue;

                ADM108UGrdListItemInfo item = new ADM108UGrdListItemInfo();
                item.SysId = tvwSystem.SelectedNode.Tag.ToString();
                item.Seq = grdList.GetItemString(i, "seq");
                item.PgmSysId = grdList.GetItemString(i, "pgm_sys_id");
                item.SysNm = grdList.GetItemString(i, "pgm_sys_nm");
                item.PgmId = grdList.GetItemString(i, "pgm_id");
                item.PgmNm = grdList.GetItemString(i, "pgm_nm");
                item.NewSeq = (i + 1).ToString();
                if (grdList.GetRowState(i) == DataRowState.Unchanged && !item.Seq.Equals(item.NewSeq))
                {
                    item.DataRowState = DataRowState.Modified.ToString();
                }
                else
                {
                    item.DataRowState = grdList.GetRowState(i).ToString();    
                }
                lstResult.Add(item);
            }

            // Delete
            if (null != grdList.DeletedRowTable)
            {
                foreach (DataRow dr in grdList.DeletedRowTable.Rows)
                {
                    ADM108UGrdListItemInfo item = new ADM108UGrdListItemInfo();
                    item.SysId = Convert.ToString(dr["sys_id"]);
                    item.Seq = Convert.ToString(dr["seq"]);

                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        #endregion

        #region MED-14133

        private string mHospCode = "";

        private void ApplyMultiHospital()
        {
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                // Show Findbox hospital
                pnlTop.Dock = DockStyle.Top;
                pnlTop.Visible = true;

                // FindWorker
                fwkHospitalID.ExecuteQuery = GetFwkHospitalId;
            }
            else
            {
                pnlTop.Dock = DockStyle.None;
                pnlTop.Visible = false;
                this.mHospCode = UserInfo.HospCode;
            }
        }

        private void fbxHospitalID_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkHospitalID.ColInfos.Clear();
            this.fwkHospitalID.ColInfos.Add("code", Resources.FindBox_Title_Code, FindColType.String, 80, 0, true, FilterType.No);
            this.fwkHospitalID.ColInfos.Add("code_name", Resources.FindBox_Title_Name, FindColType.String, 200, 0, true, FilterType.No);
        }

        private void fbxHospitalID_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.mHospCode = fbxHospitalID.Text;

            ADM103UValidateFwkHospitalArgs args = new ADM103UValidateFwkHospitalArgs();
            args.HospCode = this.mHospCode;
            ADM103UValidateFwkHospitalResult result = CloudService.Instance.Submit<ADM103UValidateFwkHospitalResult, ADM103UValidateFwkHospitalArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                this.dbxHospitalNm.SetDataValue(result.HospName);
            }
            else
            {
                this.dbxHospitalNm.ResetData();
            }

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void fbxID_FindSelected(object sender, FindEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            XDisplayBox dbxBox = this.dbxHospitalNm;
            dbxBox = this.dbxHospitalNm;
            if (TypeCheck.IsNull(e.ReturnValues) == true)
            {
                dbxBox.SetDataValue("");
            }
            else
            {
                dbxBox.SetDataValue(e.ReturnValues[1].ToString());
                this.mHospCode = e.ReturnValues[0].ToString();
                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        private IList<object[]> GetFwkHospitalId(BindVarCollection bvc)
        {
            List<object[]> res = new List<object[]>();

            ADM103UGetFwkHospitalResult result = CloudService.Instance.Submit<ADM103UGetFwkHospitalResult, ADM103UGetFwkHospitalArgs>(new ADM103UGetFwkHospitalArgs());
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                result.HospList.ForEach(delegate(ComboListItemInfo item)
                {
                    res.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return res;
        }

        #endregion

        #region Check Validate
        private bool CheckBeforeInsert()
        {
            if (this.tvwSystem.SelectedNode == null)
            {
                XMessageBox.Show(Resources.MSG_004, Resources.MSG_Notice, MessageBoxIcon.Warning);
                return false;
            }

            //if (grdList.RowCount > 0)
            //{
            //    for (int i = 0; i < grdList.RowCount; i++)
            //    {
                    
            //        if (grdList.GetRowState(i) == DataRowState.Unchanged) continue;
            //        if (String.IsNullOrEmpty(grdList.GetItemString(i, "pgm_sys_id")))
            //        {
            //            XMessageBox.Show(Resources.MSG_003, Resources.MSG_Notice, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }
            //}
            return true;
        }
        #endregion
    }
}