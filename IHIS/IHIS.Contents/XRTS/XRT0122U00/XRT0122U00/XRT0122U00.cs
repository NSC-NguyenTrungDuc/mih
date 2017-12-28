#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.XRTS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
#endregion

namespace IHIS.XRTS
{
    /// <summary>
    /// XRT0122U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class XRT0122U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XMstGrid grdMcode;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGrid grdDcode;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.SingleLayout layDupM;
        private IHIS.Framework.SingleLayout layDupD;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XButton btnIfQry;
        private System.Windows.Forms.ToolTip toolTip;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private MultiLayout layCombo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private SingleLayout layCodeName;
        private SingleLayoutItem singleLayoutItem3;
        private XEditGridCell xEditGridCell6;
        private System.ComponentModel.IContainer components;

        public XRT0122U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            ApplyFont();
            //this.grdMcode.SavePerformer = new XSavePerformer(this);
            //this.grdDcode.SavePerformer = this.grdMcode.SavePerformer;

            // updated by Cloud
            InitItemControls();
        }

        private void ApplyFont()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).BeginInit();
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell1);
                ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).EndInit();
            }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT0122U00));
            this.grdMcode = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdDcode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.layDupM = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDupD = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.btnIfQry = new IHIS.Framework.XButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.layCombo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layCodeName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdMcode
            // 
            resources.ApplyResources(this.grdMcode, "grdMcode");
            this.grdMcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMcode.ColPerLine = 1;
            this.grdMcode.ColResizable = true;
            this.grdMcode.Cols = 2;
            this.grdMcode.ExecuteQuery = null;
            this.grdMcode.FixedCols = 1;
            this.grdMcode.FixedRows = 1;
            this.grdMcode.HeaderHeights.Add(21);
            this.grdMcode.Name = "grdMcode";
            this.grdMcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMcode.ParamList")));
            this.grdMcode.ReadOnly = true;
            this.grdMcode.RowHeaderVisible = true;
            this.grdMcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdMcode, resources.GetString("grdMcode.ToolTip"));
            this.grdMcode.ToolTipActive = true;
            this.grdMcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMcode_GridColumnChanged);
            this.grdMcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMcode_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellName = "buwi_bunryu";
            this.xEditGridCell1.CellWidth = 227;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellLen = 50;
            this.xEditGridCell2.CellName = "buwi_bunryu_name";
            this.xEditGridCell2.CellWidth = 270;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.toolTip.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
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
            this.toolTip.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // grdDcode
            // 
            resources.ApplyResources(this.grdDcode, "grdDcode");
            this.grdDcode.CallerID = '2';
            this.grdDcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdDcode.ColPerLine = 3;
            this.grdDcode.ColResizable = true;
            this.grdDcode.Cols = 4;
            this.grdDcode.ExecuteQuery = null;
            this.grdDcode.FixedCols = 1;
            this.grdDcode.FixedRows = 1;
            this.grdDcode.HeaderHeights.Add(21);
            this.grdDcode.MasterLayout = this.grdMcode;
            this.grdDcode.Name = "grdDcode";
            this.grdDcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDcode.ParamList")));
            this.grdDcode.QuerySQL = resources.GetString("grdDcode.QuerySQL");
            this.grdDcode.RowHeaderVisible = true;
            this.grdDcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdDcode, resources.GetString("grdDcode.ToolTip"));
            this.grdDcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDcode_GridColumnChanged);
            this.grdDcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDcode_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "buwi_bunryu";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "buwi_code";
            this.xEditGridCell4.CellWidth = 150;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 50;
            this.xEditGridCell5.CellName = "buwi_name";
            this.xEditGridCell5.CellWidth = 400;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sort_seq";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.CellWidth = 45;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.MaxinumCipher = 3;
            // 
            // layDupM
            // 
            this.layDupM.ExecuteQuery = null;
            this.layDupM.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupM.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupM.ParamList")));
            this.layDupM.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupM_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // layDupD
            // 
            this.layDupD.ExecuteQuery = null;
            this.layDupD.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDupD.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupD.ParamList")));
            this.layDupD.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupD_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // btnIfQry
            // 
            this.btnIfQry.AccessibleDescription = null;
            this.btnIfQry.AccessibleName = null;
            resources.ApplyResources(this.btnIfQry, "btnIfQry");
            this.btnIfQry.BackgroundImage = null;
            this.btnIfQry.Font = null;
            this.btnIfQry.Image = ((System.Drawing.Image)(resources.GetObject("btnIfQry.Image")));
            this.btnIfQry.Name = "btnIfQry";
            this.toolTip.SetToolTip(this.btnIfQry, resources.GetString("btnIfQry.ToolTip"));
            this.btnIfQry.Click += new System.EventHandler(this.btnIfQry_Click);
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // layCombo
            // 
            this.layCombo.ExecuteQuery = null;
            this.layCombo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layCombo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCombo.ParamList")));
            this.layCombo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCombo_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // layCodeName
            // 
            this.layCodeName.ExecuteQuery = null;
            this.layCodeName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.layCodeName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCodeName.ParamList")));
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "code_name";
            // 
            // XRT0122U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnIfQry);
            this.Controls.Add(this.grdDcode);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdMcode);
            this.Font = null;
            this.Name = "XRT0122U00";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCombo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            // TODO:  XRT0122U00.OnLoad 구현을 추가합니다.
            base.OnLoad(e);

            this.grdDcode.SetRelationKey("buwi_bunryu", "buwi_bunryu");
            this.grdDcode.SetRelationTable("XRT0122");

            SetCombo();

            if (!this.grdMcode.QueryLayout(false))
                XMessageBox.Show(Resource.XMessageBox4, Resource.XMessageBoxCaption3, MessageBoxIcon.Error);

            this.toolTip.SetToolTip(this.btnIfQry, Resource.XMessageBox3);
        }
        #endregion

        private void SetCombo()
        {
            // deleted by Cloud
            //this.layCombo.QueryLayout(true);
            //this.grdMcode.SetComboItems("buwi_bunryu", this.layCombo.LayoutTable, "code_name", "code");

            // Updated by Cloud
            DataTable dt = Utility.ConvertToDataTable(GetBuwiCombo());
            //List<object[]> lObj = GetBuwiCombo();
            this.grdMcode.SetComboItems("buwi_bunryu", /*Utility.ConvertToDataTable(lObj)*/dt, "code_name", "code");
        }

        #region 마스터 테이블 중복체크(입력시 code type)
        private void grdMcode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdMcode.LayoutTable.Rows[this.grdMcode.CurrentRowNumber].RowState;
            // 입력 버튼이 클릭 되었을 때만 체크
            if (rowState == DataRowState.Added)
            {
                // 입력된 셀이 코드타입 컬럼이라면,
                if (e.ColName == "buwi_bunryu")
                {
                    #region deleted by Cloud
                    //// 만약 마스터테이블에 존재한다면, 'Y'를 그렇지않으면, 'N'을 리턴
                    //this.layDupM.QueryLayout();
                    //if ( this.layDupM.GetItemValue("dup_yn").ToString() == "Y" )
                    //{
                    //    string msg = (NetInfo.Language == LangMode.Ko ? Resource.msg_Ko
                    //        : Resource.msg_JP);
                    //    XMessageBox.Show( this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber,"buwi_bunryu")  +
                    //        msg,Resource.XMessageBoxCaption4, MessageBoxButtons.OK );
                    //    e.Cancel = true;
                    //    return;
                    //}
                    #endregion

                    // updated by Cloud
                    XRT0122U00LayDupMArgs args = new XRT0122U00LayDupMArgs();
                    args.BuwiBunryu = this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu");
                    XRT0122U00LayDupResult res = CloudService.Instance.Submit<XRT0122U00LayDupResult, XRT0122U00LayDupMArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.DupYn == "Y")
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resource.msg_Ko
                            : Resource.msg_JP);
                        XMessageBox.Show(this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu") +
                            msg, Resource.XMessageBoxCaption4, MessageBoxButtons.OK);
                        e.Cancel = true;
                        return;
                    }

                    //this.layCodeName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    //this.layCodeName.SetBindVarValue("f_code", e.ChangeValue.ToString());
                    //this.layCodeName.QueryLayout();

                    //this.grdMcode.SetItemValue(e.RowNumber, "buwi_bunryu_name", this.layCodeName.GetItemValue("code_name"));
                }
            }
        }
        #endregion

        #region 디테일 테이블 중복체크(입력시 code)
        private void grdDcode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdDcode.LayoutTable.Rows[this.grdDcode.CurrentRowNumber].RowState;
            //입력 버튼이 클릭 되었을 때만 체크
            if (rowState == DataRowState.Added)
            {
                // 입력된 셀이 코드 컬럼이면,
                if (e.ColName == "buwi_code")
                {
                    #region deleted by Cloud
                    //this.layDupD.QueryLayout();
                    //if ( this.layDupD.GetItemValue("dup_yn").ToString() == "Y" )
                    //{
                    //    string msg = (NetInfo.Language == LangMode.Ko ? Resource.msg_Ko
                    //        : Resource.msg_JP);
                    //    XMessageBox.Show( this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber,"buwi_code") +
                    //        msg,Resource.XMessageBoxCaption4, MessageBoxButtons.OK );
                    //    e.Cancel = true;
                    //}
                    #endregion

                    // Updated by Cloud
                    XRT0122U00LayDupDArgs args = new XRT0122U00LayDupDArgs();
                    args.BuwiBunryu = this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu");
                    args.BuwiCode = this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_code");
                    XRT0122U00LayDupResult res = CloudService.Instance.Submit<XRT0122U00LayDupResult, XRT0122U00LayDupDArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.DupYn == "Y")
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resource.msg_Ko
                            : Resource.msg_JP);
                        XMessageBox.Show(this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_code") +
                            msg, Resource.XMessageBoxCaption4, MessageBoxButtons.OK);
                        e.Cancel = true;
                    }
                }
            }
        }
        #endregion

        #region 조건조회/검색실행 버튼 클릭
        //검색중인지 아닌지의 여부(0->조건조회가능모드, 1->조건검색모드)
        int flag = 0;
        private void btnIfQry_Click(object sender, System.EventArgs e)
        {
            //만약 초기화된 상태라면 무조건 마스터그리드에 조건조회가 타도록 설정
            if (this.grdMcode.LayoutTable.Rows.Count == 0 && this.grdDcode.LayoutTable.Rows.Count == 0)
                this.CurrMQLayout = this.grdMcode;

            //마스터인지 디테일인지의 여부
            string MorD = "";

            //조건조회버튼을 클릭시
            if (flag % 2 == 0)
            {
                //현재스크린의 아웃포커스가 마스터그리드라면,
                if (this.CurrMQLayout == this.grdMcode)
                {
                    //중복체크의 이벤트가 타지 안토록 설정
                    this.grdMcode.GridColumnChanged -= new IHIS.Framework.GridColumnChangedEventHandler(this.grdMcode_GridColumnChanged);
                    this.grdMcode.Reset();
                    this.grdMcode.InsertRow();
                    MorD = "M";
                }
                //현재스크린의 아웃포커스가 디테일그리드라면,
                else if (this.CurrMQLayout == this.grdDcode)
                {
                    //중복체크의 이벤트가 타지 안토록 설정
                    this.grdDcode.GridColumnChanged -= new IHIS.Framework.GridColumnChangedEventHandler(this.grdDcode_GridColumnChanged);
                    this.grdDcode.Reset();
                    this.grdDcode.InsertRow();
                    MorD = "D";
                }
                //버튼의 텍스트를 변경
                string query = (NetInfo.Language == LangMode.Ko ? Resource.query_Msg_Ko
                    : Resource.query_Msg_JP);
                this.btnIfQry.Text = query;
            }
            //검색실행버튼을 클릭시
            else
            {
                //현재스크린의 아웃포커스가 마스터그리드라면,
                if (this.CurrMQLayout == this.grdMcode)
                {
                    this.grdMcode.SetBindVarValue("f_buwi_bunryu", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu"));
                    this.grdMcode.QueryLayout(false);
                }
                //현재스크린의 아웃포커스가 디테일그리드라면,
                else if (this.CurrMQLayout == this.grdDcode)
                {
                    this.grdDcode.QueryLayout(false);
                }
                //버튼의 텍스트를 변경
                string query = (NetInfo.Language == LangMode.Ko ? Resource.query2_Msg_Ko
                    : Resource.query2_Msg_JP);
                this.btnIfQry.Text = query;
            }
            //검색실행이 끝난후 다시 중복체크이벤트를 살려두어야함
            if (flag % 2 == 1)
            {
                if (MorD == "M")
                    this.grdMcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMcode_GridColumnChanged);
                else if (MorD == "D")
                    this.grdDcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDcode_GridColumnChanged);
            }

            //버튼이 조건조회인지 검색실행인지의 여부를 결정하는 플래그
            flag++;
        }
        #endregion

        #region 단축키 설정
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                //조건조회/검색실행버튼에 단축키 F1을 맵핑
                case Keys.F1:
                    //버튼을 그냥 클릭했을 때는 문제가 없으나,
                    //단축키로 버튼클릭 이벤트를 발생시킬 때에는,
                    //현재위치한 셀에 포커스가 그대로 있기 때문에 의도한 값이 
                    //조회서비스의 인밸류값으로 셋팅이 되지가 않는다.
                    //따라서 강제로 다른 셀로 포커스를 이동시켜준다.
                    if (this.CurrMQLayout == this.grdMcode && flag % 2 == 1)
                        this.grdMcode.SetFocusToItem(this.grdMcode.CurrentRowNumber, "buwi_bunryu_name");
                    else if (this.CurrMQLayout == this.grdDcode && flag % 2 == 1)
                        this.grdDcode.SetFocusToItem(this.grdDcode.CurrentRowNumber, "code2");

                    this.btnIfQry_Click(new object(), new System.EventArgs());
                    break;
                default:
                    break;
            }

            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region 버튼리스트 클릭 후 이벤트
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //초기화가 된 후 포커스 마스터 그리드로..
                case FunctionType.Reset:
                    this.CurrMQLayout = this.grdMcode;
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    if (this.CurrMQLayout == this.grdMcode)
                    {
                        this.grdMcode.SetBindVarValue("f_buwi_bunryu", "");
                    }
                    else
                    {
                        this.grdDcode.SetBindVarValue("f_buwi_code", "");
                        this.grdDcode.SetBindVarValue("f_buwi_name", "");
                    }
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = true;

                    #region deleted by Cloud
                    //try
                    //{
                    //    Service.BeginTransaction();

                    //    if (!this.grdMcode.SaveLayout())
                    //        throw new Exception();
                    //    if (!this.grdDcode.SaveLayout())
                    //        throw new Exception();

                    //    Service.CommitTransaction();

                    //    XMessageBox.Show(Resource.xMessageBox1, Resource.xMessageCaption1, MessageBoxIcon.Asterisk);
                    //}
                    //catch
                    //{
                    //    Service.RollbackTransaction();
                    //    e.IsSuccess = false;
                    //    XMessageBox.Show(Resource.xMessageBox2, Resource.xMessageCaption2, MessageBoxIcon.Error);
                    //}
                    #endregion

                    // updated by Cloud
                    XRT0122U00SaveLayoutArgs args = new XRT0122U00SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.SaveLayoutItem = GetListDataForSaveLayout();

                    if (args.SaveLayoutItem.Count == 0)
                    {
                        XMessageBox.Show(Resource.xMessageBox1, Resource.xMessageCaption1, MessageBoxIcon.Asterisk);
                        break;
                    }

                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, XRT0122U00SaveLayoutArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
                    {
                        XMessageBox.Show(Resource.xMessageBox1, Resource.xMessageCaption1, MessageBoxIcon.Asterisk);
                        grdMcode.ResetUpdate();
                        grdDcode.ResetUpdate();
                    }
                    else
                    {
                        e.IsSuccess = false;
                        XMessageBox.Show(Resource.xMessageBox2, Resource.xMessageCaption2, MessageBoxIcon.Error);
                    }

                    break;
                case FunctionType.Insert:
                case FunctionType.Delete:
                    if (CurrMSLayout == this.grdMcode)
                    {
                        e.IsBaseCall = false;
                        return;
                    }
                    break;
                default:
                    break;
            }
        }

        private void grdMcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMcode.SetBindVarValue("f_buwi_bunryu", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu"));
        }

        private void grdDcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDcode.SetBindVarValue("f_buwi_bunryu", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu"));
            this.grdDcode.SetBindVarValue("f_buwi_code", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_code"));
            this.grdDcode.SetBindVarValue("f_buwi_name", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_name"));
        }

        private void layDupD_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.layDupD.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.layDupD.SetBindVarValue("f_buwi_bunryu", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu"));
            //this.layDupD.SetBindVarValue("f_buwi_code", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_code"));
        }

        private void layDupM_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.layDupM.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.layDupM.SetBindVarValue("f_buwi_bunryu", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "buwi_bunryu"));
        }

        private void layCombo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCombo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        #region XSavePerformer
        // deleted by Cloud
        //        private class XSavePerformer : ISavePerformer
        //        {
        //            XRT0122U00 parent;

        //            public XSavePerformer(XRT0122U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
        //                switch (callerID)
        //                {
        //                    case '1':

        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:
        //                                cmdText = @"INSERT INTO XRT0121 (
        //                                                  SYS_DATE,              SYS_ID,                  
        //                                                  UPD_DATE,              UPD_ID,                  HOSP_CODE,
        //                                                  BUWI_BUNRYU,           BUWI_BUNRYU_NAME
        //                                                ) VALUES (
        //                                                  SYSDATE,               :q_user_id,               
        //                                                  SYSDATE,               :q_user_id,            :f_hosp_code,
        //                                                  :f_buwi_bunryu,        :f_buwi_bunryu_name    )";
        //                                break;

        //                            case DataRowState.Modified:
        //                                cmdText = @"UPDATE XRT0121
        //                                               SET UPD_ID           = :q_user_id
        //                                                 , UPD_DATE         = SYSDATE
        //                                                 , BUWI_BUNRYU_NAME = :f_buwi_bunryu_name
        //                                             WHERE HOSP_CODE        = :f_hosp_code
        //                                               AND BUWI_BUNRYU      = :f_buwi_bunryu";

        //                                break;

        //                            case DataRowState.Deleted:
        //                                cmdText = @"DECLARE
        //                                               RESULT   VARCHAR2(1);
        //                                            BEGIN
        //                                               RESULT := 'N';
        //                                               FOR X IN (SELECT 'X' 
        //                                                           FROM XRT0122
        //                                                          WHERE HOSP_CODE   = :f_hosp_code
        //                                                            AND BUWI_BUNRYU = :f_buwi_bunryu) LOOP
        //                                                   RESULT := 'Y';
        //                                               END LOOP;
        //                                                 
        //                                               DELETE XRT0121
        //                                                WHERE HOSP_CODE   = :f_hosp_code
        //                                                  AND BUWI_BUNRYU = :f_buwi_bunryu;
        //                                                
        //                                               if RESULT = 'Y' THEN
        //                                                  DELETE XRT0122
        //                                                   WHERE HOSP_CODE   = :f_hosp_code
        //                                                     AND BUWI_BUNRYU = :f_buwi_bunryu;
        //                                               END IF;
        //                                            END;";

        //                                break;
        //                        }
        //                        break;

        //                    case '2':

        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:
        //                                cmdText = @"INSERT INTO XRT0122 (
        //                                                  SYS_DATE,         SYS_ID,          
        //                                                  UPD_DATE,         UPD_ID,        HOSP_CODE,
        //                                                  BUWI_BUNRYU,      BUWI_CODE,      
        //                                                  BUWI_NAME  ,      SORT_SEQ
        //                                                ) VALUES (
        //                                                  SYSDATE,          :q_user_id,      
        //                                                  SYSDATE,          :q_user_id,    :f_hosp_code, 
        //                                                  :f_buwi_bunryu,   :f_buwi_code  ,
        //                                                  :f_buwi_name  ,   NVL(:f_sort_seq,0)
        //                                                  )";
        //                                break;

        //                            case DataRowState.Modified:
        //                                cmdText = @"UPDATE XRT0122
        //                                               SET UPD_ID      = :q_user_id
        //                                                 , UPD_DATE    = SYSDATE
        //                                                 , BUWI_NAME   = :f_buwi_name
        //                                                 , SORT_SEQ    = NVL(:f_sort_seq,0)
        //                                             WHERE HOSP_CODE   = :f_hosp_code
        //                                               AND BUWI_BUNRYU = :f_buwi_bunryu
        //                                               AND BUWI_CODE   = :f_buwi_code";
        //                                break;

        //                            case DataRowState.Deleted:
        //                                cmdText = @"DELETE XRT0122
        //                                             WHERE HOSP_CODE   = :f_hosp_code
        //                                               AND BUWI_BUNRYU = :f_buwi_bunryu
        //                                               AND BUWI_CODE   = :f_buwi_code";
        //                                break;
        //                        }
        //                        break;
        //                }

        //                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //            }
        //        }
        #endregion

        #region Cloud updated code

        #region InitItemControls
        /// <summary>
        /// InitItemControls
        /// </summary>
        private void InitItemControls()
        {
            // grdMcode
            this.grdMcode.ParamList = new List<string>(new string[] { "f_buwi_bunryu" });
            this.grdMcode.ExecuteQuery = GetGrdMcode;

            // grdDcode
            this.grdDcode.ParamList = new List<string>(new string[]
                {
                    "f_buwi_bunryu",
                    "f_buwi_code",
                    "f_buwi_name",
                    "f_flag",
                });
            this.grdDcode.ExecuteQuery = GetGrdDcode;
        }
        #endregion

        #region GetGrdMcode
        /// <summary>
        /// GetGrdMcode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdMcode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT0122U00GrdMcodeArgs args = new XRT0122U00GrdMcodeArgs();
            args.BuwiBunryu = bvc["f_buwi_bunryu"].VarValue;
            XRT0122U00GrdMcodeResult res = CloudService.Instance.Submit<XRT0122U00GrdMcodeResult, XRT0122U00GrdMcodeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.McodeItem.ForEach(delegate(XRT0122U00GrdMcodeInfo item)
                {
                    lObj.Add(new object[] { item.BuwiBunryu, item.BuwiBunryuName });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdDcode
        /// <summary>
        /// GetGrdDcode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdDcode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT0122U00GrdDcodeArgs args = new XRT0122U00GrdDcodeArgs();
            args.BuwiBunryu = bvc["f_buwi_bunryu"].VarValue;
            args.BuwiCode = bvc["f_buwi_code"].VarValue;
            args.BuwiName = bvc["f_buwi_name"].VarValue;
            args.Flag = bvc["f_flag"].VarValue;
            XRT0122U00GrdDcodeResult res = CloudService.Instance.Submit<XRT0122U00GrdDcodeResult, XRT0122U00GrdDcodeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.DcodeItem.ForEach(delegate(XRT0122U00GrdDcodeInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.BuwiBunryu,
                        item.BuwiCode,
                        item.BuwiName,
                        item.SortSeq,
                        item.Key,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetBuwiCombo
        /// <summary>
        /// GetBuwiCombo
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private List<ComboListItemInfo> GetBuwiCombo()
        {
            List<ComboListItemInfo> lstCombo = new List<ComboListItemInfo>();

            ComboResult res = CacheService.Instance.Get<CboBuwiBunryuArgs, ComboResult>(new CboBuwiBunryuArgs());

            if (null != res && null != res.ComboItem)
            {
                lstCombo = res.ComboItem;
            }

            return lstCombo;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<XRT0122U00SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<XRT0122U00SaveLayoutInfo> lstData = new List<XRT0122U00SaveLayoutInfo>();

            for (int i = 0; i < grdMcode.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdMcode.GetRowState(i) == DataRowState.Unchanged) continue;

                XRT0122U00SaveLayoutInfo item = new XRT0122U00SaveLayoutInfo();
                item.CallerId = "1";
                item.BuwiBunryu = grdMcode.GetItemString(i, "buwi_bunryu");
                item.BuwiBunryuName = grdMcode.GetItemString(i, "buwi_bunryu_name");
                item.RowState = grdMcode.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdMcode.DeletedRowTable)
            {
                for (int i = 0; i < grdMcode.DeletedRowTable.Rows.Count; i++)
                {
                    XRT0122U00SaveLayoutInfo item = new XRT0122U00SaveLayoutInfo();
                    item.CallerId = "1";
                    item.BuwiBunryu = grdMcode.DeletedRowTable.Rows[i]["buwi_bunryu"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            for (int i = 0; i < grdDcode.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdDcode.GetRowState(i) == DataRowState.Unchanged) continue;

                XRT0122U00SaveLayoutInfo item = new XRT0122U00SaveLayoutInfo();
                item.CallerId = "2";
                item.BuwiBunryu = grdMcode.GetItemString(grdMcode.CurrentRowNumber, "buwi_bunryu");
                item.BuwiCode = grdDcode.GetItemString(i, "buwi_code");
                item.BuwiName = grdDcode.GetItemString(i, "buwi_name");
                item.SortSeq = grdDcode.GetItemString(i, "sort_seq");
                item.RowState = grdDcode.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdDcode.DeletedRowTable)
            {
                for (int i = 0; i < grdDcode.DeletedRowTable.Rows.Count; i++)
                {
                    XRT0122U00SaveLayoutInfo item = new XRT0122U00SaveLayoutInfo();
                    item.CallerId = "2";
                    item.BuwiBunryu = grdMcode.GetItemString(grdMcode.CurrentRowNumber, "buwi_bunryu");
                    item.BuwiCode = grdDcode.DeletedRowTable.Rows[i]["buwi_code"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #endregion
    }
}

