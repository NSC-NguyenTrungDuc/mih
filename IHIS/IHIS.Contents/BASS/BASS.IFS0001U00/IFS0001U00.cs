#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Text;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.BASS.Properties;
using IHIS.CloudConnector.Contracts.Models.System;
#endregion

namespace IHIS.BASS
{
    /// <summary>
    /// IFS0001U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class IFS0001U00 : IHIS.Framework.XScreen
    {
        #region Auto generated code

        #region components(auto)
        private IHIS.Framework.XEditGrid grdDetail;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        #endregion components(auto)

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        #region creator, dispose
        private System.ComponentModel.Container components = null;
        private XEditGridCell xEditGridCell6;
        private XPanel xPanel2;
        private XTextBox txbSearchCode;
        private XLabel xLabel2;
        private XDisplayBox dbxSearchGubunName;
        private XLabel xLabel18;
        private XFindBox fbxSearchGubun;
        private XPanel xPanel5;
        private XFindWorker fwkCommon;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private Splitter splitter1;
        private string mbxMsg = "";

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }
        #endregion creator, dispose

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IFS0001U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txbSearchCode = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxSearchGubunName = new IHIS.Framework.XDisplayBox();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.fbxSearchGubun = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xPanel5 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
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
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell8});
            this.grdMaster.ColPerLine = 3;
            this.grdMaster.Cols = 3;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(20);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 179;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellLen = 80;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 271;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "remark";
            this.xEditGridCell6.CellWidth = 83;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "acct_type";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell9});
            this.grdDetail.ColPerLine = 3;
            this.grdDetail.Cols = 3;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(23);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.QuerySQL = resources.GetString("grdDetail.QuerySQL");
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 145;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 80;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 307;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellLen = 4000;
            this.xEditGridCell7.CellName = "remark";
            this.xEditGridCell7.CellWidth = 91;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "acct_type";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.txbSearchCode);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.dbxSearchGubunName);
            this.xPanel2.Controls.Add(this.xLabel18);
            this.xPanel2.Controls.Add(this.fbxSearchGubun);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // txbSearchCode
            // 
            this.txbSearchCode.AccessibleDescription = null;
            this.txbSearchCode.AccessibleName = null;
            resources.ApplyResources(this.txbSearchCode, "txbSearchCode");
            this.txbSearchCode.BackgroundImage = null;
            this.txbSearchCode.Name = "txbSearchCode";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dbxSearchGubunName
            // 
            this.dbxSearchGubunName.AccessibleDescription = null;
            this.dbxSearchGubunName.AccessibleName = null;
            resources.ApplyResources(this.dbxSearchGubunName, "dbxSearchGubunName");
            this.dbxSearchGubunName.Image = null;
            this.dbxSearchGubunName.Name = "dbxSearchGubunName";
            // 
            // xLabel18
            // 
            this.xLabel18.AccessibleDescription = null;
            this.xLabel18.AccessibleName = null;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel18.Image = null;
            this.xLabel18.Name = "xLabel18";
            // 
            // fbxSearchGubun
            // 
            this.fbxSearchGubun.AccessibleDescription = null;
            this.fbxSearchGubun.AccessibleName = null;
            resources.ApplyResources(this.fbxSearchGubun, "fbxSearchGubun");
            this.fbxSearchGubun.BackgroundImage = null;
            this.fbxSearchGubun.FindWorker = this.fwkCommon;
            this.fbxSearchGubun.Name = "fbxSearchGubun";
            this.fbxSearchGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSearchGubun_DataValidating);
            this.fbxSearchGubun.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSearchGubun_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.InputSQL = resources.GetString("fwkCommon.InputSQL");
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "code";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "code_name";
            this.findColumnInfo4.ColWidth = 140;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.grdDetail);
            this.xPanel5.Controls.Add(this.grdMaster);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            // 
            // IFS0001U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnList);
            this.Font = null;
            this.Name = "IFS0001U00";
            this.Load += new System.EventHandler(this.IFS0001U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.xPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        #region Fields
        private string mHospCode = "";
        private string mMsg = "";
        private string mCap = "";
        private bool tFlag = false;
        #endregion user variable

        #region Constructor
        /// <summary>
        /// IFS0001U00
        /// </summary>
        public IFS0001U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // updated by Cloud
            InitializeCloud();
        }
        #endregion

        #region Events

        private void IFS0001U00_Load(object sender, System.EventArgs e)
        {
            this.mHospCode = EnvironInfo.HospCode;

            //this.grdMaster.SavePerformer = new XSavePeformer(this);
            //this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            // 마스터, 디테일 Relation 
            this.grdDetail.SetRelationKey("code_type", "code_type");
            this.grdDetail.SetRelationTable("ifs0002");

            ((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).ApplyByteLimit = true;
            ((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).MaxLength = 80;
            ((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).TextChanged += new System.EventHandler(this.xTextBox1_TextChanged);

            this.grdMaster.QueryLayout(false);
        }

        private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            if (tFlag)
            {
                if (e.ColName == "code_type")
                {
                    #region deleted by Cloud
                    //ArrayList inputList = new ArrayList();
                    //ArrayList outputList = new ArrayList();

                    //inputList.Add("Y");                     // master_check
                    //inputList.Add(EnvironInfo.HospCode);    // hosp_code
                    //inputList.Add(e.ChangeValue);           // code_type
                    //inputList.Add(e.ChangeValue);           // code 마스터에서는 무의미

                    //Service.ExecuteProcedure("PKG_IFS_BAS.PR_CHECK_DUP_IFS0001", inputList, outputList);

                    //if (!TypeCheck.IsNull(outputList[0]))
                    //{
                    //    if (outputList[0].ToString() == "Y")
                    //    {
                    //        XMessageBox.Show("既に同じコード類型が登録されています。", "注意", MessageBoxIcon.Warning);
                    //        e.Cancel = true;
                    //    }
                    //}
                    #endregion

                    // updated by Cloud
                    IFS0001U00PrCheckDupArgs args = new IFS0001U00PrCheckDupArgs();
                    args.MasterCheck = "Y";
                    args.CodeType = e.ChangeValue.ToString();
                    args.Code = e.ChangeValue.ToString();
                    IFS0001U00PrCheckDupResult res = CloudService.Instance.Submit<IFS0001U00PrCheckDupResult, IFS0001U00PrCheckDupArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (res.DupYn == "Y")
                        {
                            XMessageBox.Show("既に同じコード類型が登録されています。", "注意", MessageBoxIcon.Warning);
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            if (e.ColName == "code")
            {
                #region deleted by Cloud
                //ArrayList inputList = new ArrayList();
                //ArrayList outputList = new ArrayList();

                //inputList.Add("N");                     // master_check
                //inputList.Add(EnvironInfo.HospCode);    // hosp_code
                //inputList.Add(this.grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type")); //code_type
                //inputList.Add(e.ChangeValue);           // code　마스터에서는 무의미

                //Service.ExecuteProcedure("PKG_IFS_BAS.PR_CHECK_DUP_IFS0001", inputList, outputList);

                //if (!TypeCheck.IsNull(outputList[0]))
                //{
                //    if (outputList[0].ToString() == "Y")
                //    {
                //        XMessageBox.Show("既に同じコードが登録されています。", "注意", MessageBoxIcon.Warning);
                //        e.Cancel = true;
                //    }
                //}
                #endregion

                // updated by Cloud
                IFS0001U00PrCheckDupArgs args = new IFS0001U00PrCheckDupArgs();
                args.MasterCheck = "N";
                args.CodeType = this.grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                args.Code = e.ChangeValue.ToString();
                IFS0001U00PrCheckDupResult res = CloudService.Instance.Submit<IFS0001U00PrCheckDupResult, IFS0001U00PrCheckDupArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.DupYn == "Y")
                    {
                        XMessageBox.Show(Properties.Resources.MSG1, Properties.Resources.MSGCAP1, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            tFlag = false;

            switch (e.Func)
            {
                case FunctionType.Query:
                    this.grdMaster.QueryLayout(false);
                    break;
                case FunctionType.Insert:

                    tFlag = true;

                    if (this.CurrMSLayout == this.grdMaster)
                    {
                        if (Find_AddedRowState() == "Y")
                        {
                            XMessageBox.Show(Properties.Resources.MSG2, Properties.Resources.MSGCAP2);
                            e.IsBaseCall = false;
                        }
                    }

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    try
                    {
                        #region  deleted by Cloud
                        //Service.BeginTransaction();

                        //if (this.grdMaster.SaveLayout())
                        //{
                        //    if (this.grdDetail.SaveLayout())
                        //    {
                        //        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : "保存が完了しました。";

                        //        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";

                        //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //    }
                        //    else
                        //        throw new Exception();
                        //}
                        //else
                        //    throw new Exception();

                        //Service.CommitTransaction();
                        #endregion

                        // updated by Cloud
                        IFS0001U00SaveLayoutArgs args = new IFS0001U00SaveLayoutArgs();
                        args.UserId = UserInfo.UserID;

                        //MED-2619: added 2015/08/11
                        bool valid = true;
                        args.GrdMstItem = GetGrdMasterForSaveLayout(out valid);
                        if (!valid)
                        {
                            throw new Exception();
                        }

                        args.GrdDetailItem = GetGrdDetailForSaveLayout();
                        // No change?
                        if (args.GrdMstItem.Count == 0 && args.GrdDetailItem.Count == 0) return;
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, IFS0001U00SaveLayoutArgs>(args);

                        if (!TypeCheck.IsNull(res.Msg))
                        {
                            string[] errCd = res.Msg.Split('-');

                            switch (errCd[0])
                            {
                                case "1":
                                    XMessageBox.Show(Properties.Resources.CHAR1 + errCd[1] + Properties.Resources.MSG3, Properties.Resources.MSGCAP1, MessageBoxIcon.Warning);
                                    break;
                                case "2":
                                    XMessageBox.Show(Properties.Resources.CHAR1 + errCd[1] + Properties.Resources.MSG4, Properties.Resources.MSGCAP1, MessageBoxIcon.Warning);
                                    break;
                                case "3":
                                    XMessageBox.Show(Properties.Resources.CHAR1 + errCd[1] + Properties.Resources.MSG3, Properties.Resources.MSGCAP1, MessageBoxIcon.Warning);
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                        {
                            this.mMsg = Properties.Resources.MSG10;
                            this.mCap = Properties.Resources.MSGCAP3;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // refresh the screen
                            btnList.PerformClick(FunctionType.Query);
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        this.mMsg = Properties.Resources.MSG8;

                        this.mMsg += "\r\n" + Service.ErrFullMsg;

                        this.mCap = Properties.Resources.MSGCAP8;
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }
                    break;
            }
        }

        private void xButton1_Click(object sender, System.EventArgs e)
        {
            Color color = Color.Silver;

            XMessageBox.Show(color.R.ToString() + "." + color.G.ToString() + "." + color.B.ToString());
        }

        private void xTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            XTextBox st = (XTextBox)sender;

            if (GetStringByte(st.GetDataValue()) > st.MaxLength)
            {
                st.Text = SubstringByte(st.GetDataValue(), 0, 30);
                st.Select(st.Text.Length, 1);
            }
        }

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        #endregion

        #region Methods(private)

        private string Find_AddedRowState()
        {
            if (this.CurrMSLayout == this.grdMaster)
            {
                // 마스터 그리드 새로 삽입된 행 검색
                for (int i = 0; i < this.grdMaster.RowCount; i++)
                {
                    if (this.grdMaster.LayoutTable.Rows[i].RowState == DataRowState.Added)
                        return "Y";
                }

                // 마스터에 새로운 행이 없을경우 디테일도 검색
                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    if (this.grdDetail.LayoutTable.Rows[i].RowState == DataRowState.Added)
                        return "Y";
                }
            }
            return "N";
        }

        private int GetStringByte(string s)
        {
            int returnByte = 0;

            if (s.Length == 0)
            {
                return returnByte;
            }

            Encoding JisEncoding = Encoding.GetEncoding("Shift-JIS");
            returnByte = JisEncoding.GetByteCount(s);
            return returnByte;
        }

        private string SubstringByte(string s, int startIndex, int length)
        {
            string returnString = "";
            int limitLen, cutLen;
            string padSpace = " ";

            if (GetStringByte(s) == 0 || GetStringByte(s) < startIndex || length < 1)
            {
                return returnString;
            }

            limitLen = GetStringByte(s) - startIndex;

            if (length > limitLen)
            {
                cutLen = limitLen;
            }
            else
            {
                cutLen = length;
            }

            Encoding JisEncoding = Encoding.GetEncoding("Shift-JIS");
            Byte[] encodingByte = JisEncoding.GetBytes(s);

            returnString = JisEncoding.GetString(encodingByte, startIndex, cutLen);
            encodingByte = JisEncoding.GetBytes(returnString);

            if (encodingByte[encodingByte.Length - 1] == 0)
            {
                returnString = JisEncoding.GetString(encodingByte, 0, cutLen - 1);
            }

            if (length > cutLen)
            {
                padSpace = padSpace.PadRight(length - cutLen);
                returnString = returnString + padSpace;
            }
            return returnString;
        }

        #endregion

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private IFS0001U00 parent = null;

            public XSavePeformer(IFS0001U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                switch (callerId)
                { 
                    case '1':
                        switch (item.RowState)
                        { 
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM SYS.DUAL
                                             WHERE EXISTS ( SELECT NULL
                                                              FROM IFS0001 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code 
                                                               AND A.CODE_TYPE = :f_code_type 
                                                          )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + "」は既に登録されています。", "注意", MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"INSERT INTO IFS0001 (
                                                   SYS_DATE　      , SYS_ID　　     , UPD_DATE          , UPD_ID
                                                 , HOSP_CODE       , CODE_TYPE　　　, CODE_TYPE_NAME    , REMARK  
                                        ) VALUES(  SYSDATE         , :q_user_id　   , SYSDATE           , :q_user_id　
                                                 , :f_hosp_code    , :f_code_type   , :f_code_type_name , :f_remark
                                                )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE IFS0001 A
                                               SET A.UPD_ID         = :q_user_id
                                                 , A.UPD_DATE       = SYSDATE
                                                 , A.CODE_TYPE_NAME = :f_code_type_name
                                                 , A.REMARK         = :f_remark
                                             WHERE A.HOSP_CODE      = :f_hosp_code
                                               AND A.CODE_TYPE      = :f_code_type";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"SELECT 'Y'
                                              FROM SYS.DUAL
                                             WHERE EXISTS ( SELECT NULL
                                                              FROM IFS0002 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.CODE_TYPE = :f_code_type 
                                                          )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + "」は詳細コードが登録されているため削除出来ません。", "注意", MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"DELETE 
                                              FROM IFS0001 A
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.CODE_TYPE = :f_code_type";

                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM SYS.DUAL
                                             WHERE EXISTS ( SELECT NULL
                                                              FROM IFS0002 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.CODE_TYPE = :f_code_type
                                                               AND A.CODE      = :f_code        
                                                          )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_code"].VarValue + "」は既に登録されています。", "注意", MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"INSERT INTO IFS0002 (
                                                   SYS_DATE         , SYS_ID         , UPD_DATE      , UPD_ID
                                                 , HOSP_CODE        , CODE_TYPE      , CODE          , CODE_NAME
                                                 , REMARK
                                       ) VALUES (  SYSDATE          , :q_user_id     , SYSDATE       , :q_user_id
                                                 , :f_hosp_code     , :f_code_type   , :f_code       , :f_code_name
                                                 , :f_remark
                                                )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE IFS0002 A
                                               SET A.UPD_ID    = :q_user_id
                                                 , A.UPD_DATE  = SYSDATE
                                                 , A.CODE_NAME = :f_code_name
                                                 , A.REMARK    = :f_remark
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.CODE_TYPE = :f_code_type
                                               AND A.CODE      = :f_code      ";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE  
                                              FROM IFS0002 A
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.CODE_TYPE = :f_code_type
                                               AND A.CODE      = :f_code    ";

                                break;
                        }

                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // grdDetail
            grdDetail.ParamList = new List<string>(new string[] { "f_code_type", "f_page_number" });
            grdDetail.ExecuteQuery = GetGrdDetail;

            // grdMaster
            grdMaster.ParamList = new List<string>(new string[] { "f_code_type" });
            grdMaster.ExecuteQuery = GetGrdMaster;

            fwkCommon.ParamList = new List<string>(new String[] { "f_code_type", "f_find1"});
            fwkCommon.ExecuteQuery = LoadDataFwkCommon;

            //Load code acct
            IFS0001U00FindBoxInitArgs args = new IFS0001U00FindBoxInitArgs();
            args.Code = "ACCT_TYPE";
            ComboResult result = CloudService.Instance.Submit<ComboResult, IFS0001U00FindBoxInitArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.ComboItem.Count > 0)
                {
                    fbxSearchGubun.Text = result.ComboItem[0].Code;
                    fbxSearchGubun.AcceptData();
                }
            }
        }
        #endregion

        #region GetGrdMaster
        /// <summary>
        /// GetGrdMaster
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdMaster(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            IFS0001U00GrdMasterArgs args = new IFS0001U00GrdMasterArgs();
            args.CodeType = txbSearchCode.Text;
            args.AcctType = fbxSearchGubun.Text;
            IFS0001U00GrdMasterResult res = CloudService.Instance.Submit<IFS0001U00GrdMasterResult, IFS0001U00GrdMasterArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdMstItem.ForEach(delegate(IFS0001U00GrdMasterInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.CodeType,
                        item.CodeTypeName,
                        item.Remark,
                        item.AcctType,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdDetail
        /// <summary>
        /// GetGrdDetail
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdDetail(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            IFS0001U00GrdDetailArgs args = new IFS0001U00GrdDetailArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            args.AcctType = fbxSearchGubun.Text;
            args.PageNumber = bvc["f_page_number"].VarValue;
            args.Offset = "200";
            IFS0001U00GrdDetailResult res = CloudService.Instance.Submit<IFS0001U00GrdDetailResult, IFS0001U00GrdDetailArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdDetailItem.ForEach(delegate(IFS0001U00GrdDetailInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.CodeType,
                        item.Code,
                        item.CodeName,
                        item.Remark,
                        item.AcctType,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdMasterForSaveLayout
        /// <summary>
        /// GetGrdMasterForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<IFS0001U00GrdMasterInfo> GetGrdMasterForSaveLayout(out bool isValid)
        {
            isValid = true;
            List<IFS0001U00GrdMasterInfo> lstData = new List<IFS0001U00GrdMasterInfo>();

            // For insert/update
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdMaster.GetRowState(i) == DataRowState.Unchanged) continue;
                if (String.IsNullOrEmpty(grdMaster.GetItemString(i, "code_type")) || String.IsNullOrEmpty(grdMaster.GetItemString(i, "code_type_name")))
                {
                    isValid = false;
                    return lstData;
                }

                IFS0001U00GrdMasterInfo item    = new IFS0001U00GrdMasterInfo();
                item.CodeType                   = grdMaster.GetItemString(i, "code_type");
                item.CodeTypeName               = grdMaster.GetItemString(i, "code_type_name");
                item.Remark                     = grdMaster.GetItemString(i, "remark");
                item.AcctType                   = fbxSearchGubun.Text;
                item.RowState                   = grdMaster.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // For delete
            if (null != grdMaster.DeletedRowTable)
            {
                foreach (DataRow dr in grdMaster.DeletedRowTable.Rows)
                {
                    IFS0001U00GrdMasterInfo item    = new IFS0001U00GrdMasterInfo();
                    item.CodeType                   = dr["code_type"].ToString();
                    item.CodeTypeName               = dr["code_type_name"].ToString();
                    item.Remark                     = dr["remark"].ToString();
                    item.AcctType                   = fbxSearchGubun.Text;
                    item.RowState                   = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetGrdDetailForSaveLayout
        /// <summary>
        /// GetGrdDetailForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<IFS0001U00GrdDetailInfo> GetGrdDetailForSaveLayout()
        {
            List<IFS0001U00GrdDetailInfo> lstData = new List<IFS0001U00GrdDetailInfo>();

            // For insert/update
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged) continue;

                IFS0001U00GrdDetailInfo item    = new IFS0001U00GrdDetailInfo();
                item.Code                       = grdDetail.GetItemString(i, "code");
                item.CodeName                   = grdDetail.GetItemString(i, "code_name");
                item.CodeType                   = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                item.Remark                     = grdDetail.GetItemString(i, "remark");
                item.AcctType                   = fbxSearchGubun.Text;
                item.RowState                   = grdDetail.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // For delete
            if (null != grdDetail.DeletedRowTable)
            {
                foreach (DataRow dr in grdDetail.DeletedRowTable.Rows)
                {
                    IFS0001U00GrdDetailInfo item    = new IFS0001U00GrdDetailInfo();
                    item.Code                       = dr["code"].ToString();
                    item.CodeName                   = dr["code_name"].ToString();
                    item.CodeType                   = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                    item.Remark                     = dr["remark"].ToString();
                    item.AcctType                   = fbxSearchGubun.Text;
                    item.RowState                   = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        /// <summary>
        /// Load data for fwkCommon
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataFwkCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            IFS0001U00FindBoxArgs args = new IFS0001U00FindBoxArgs();
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            ComboResult result = CloudService.Instance.Submit<ComboResult, IFS0001U00FindBoxArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
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

        private void fbxSearchGubun_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = (XFindBox)sender;

            switch (control.Name)
            {
                case "fbxSearchGubun":
                    this.fwkCommon.AutoQuery = true;
                    this.fwkCommon.ServerFilter = true;
                    this.fwkCommon.FormText = Resources.TEXT12;// "会計システム";
                    this.fwkCommon.ColInfos[0].HeaderText = Resources.TEXT16;
                    this.fwkCommon.ColInfos[0].ColWidth = 200;
                    this.fwkCommon.ColInfos[1].HeaderText = Resources.TEXT11;
                    this.fwkCommon.ColInfos[1].ColWidth = 250;
                    this.fwkCommon.SetBindVarValue("f_find1", "");

                    this.fwkCommon.ExecuteQuery = LoadDataFwkCommon;
                    break;
            }
        }

        #endregion

        private void fbxSearchGubun_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
            {
                dbxSearchGubunName.SetDataValue("");
                return;
            }

            IFS0001U00FindBoxValidateArgs args = new IFS0001U00FindBoxValidateArgs();
            args.CodeType = e.DataValue;
            args.CodeName = "";

            ComboResult result = CloudService.Instance.Submit<ComboResult, IFS0001U00FindBoxValidateArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.ComboItem.Count > 0)
                {
                    string retVal = result.ComboItem[0].CodeName;
                    if (TypeCheck.IsNull(retVal))
                    {
                        this.mbxMsg = Resources.MSG9;

                        this.SetMsg(this.mbxMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }
                    else
                    {
                        this.dbxSearchGubunName.SetEditValue(retVal);
                        dbxSearchGubunName.AcceptData();
                        this.grdMaster.QueryLayout(true);
                    }
                }
                else
                {
                    this.mbxMsg = Resources.MSG9;

                    this.SetMsg(this.mbxMsg, MsgType.Error);

                    this.dbxSearchGubunName.SetEditValue("");
                    dbxSearchGubunName.AcceptData();

                    e.Cancel = true;

                    return;
                }
            }
            
        }
    }
}