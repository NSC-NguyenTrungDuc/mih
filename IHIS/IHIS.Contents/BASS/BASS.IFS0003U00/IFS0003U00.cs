#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
//using Microsoft.Win32;
#endregion

namespace IHIS.BASS
{
    /// <summary>
    /// IFS0003U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class IFS0003U00 : IHIS.Framework.XScreen
    {
        #region IHIS CONTOLS
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XLabel xLabel1;
        private XEditGrid grdIFS0003;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        #endregion
        private XDatePicker xDateMapGubunYmd;
        private XDisplayBox dbxSearchGubunName;
        private XLabel xLabel18;
        private XFindBox fbxSearchGubun;
        private SingleLayout layCommon;
        private SingleLayout layDupCheck;
        private SingleLayoutItem singleLayoutItem1;
        private XFindWorker fwkCommon;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XFindWorker fwkCode;
        private FindColumnInfo findColumnInfo5;
        private FindColumnInfo findColumnInfo6;
        private XLabel xLabel2;
        private XTextBox txbSearchCode;
        private XDisplayBox txtNameAcct;
        private XLabel xLabel3;
        private XFindBox fbxAcct;
        private string mbxMsg = "";

        #region Main, Distruction
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public IFS0003U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //set ParamList
            layCommon.ParamList = new List<string>(new String[] { "f_code_type", "f_code" });
            fwkCommon.ParamList = new List<string>(new String[] { "f_code_type", "f_col_name", "f_find1", "f_map_gubun", "f_page_number" });
            fwkCode.ParamList = new List<string>(new String[] { "f_code_type", "f_col_name", "f_find1", "f_map_gubun", "f_page_number" });
            grdIFS0003.ParamList = new List<string>(new String[] { "f_map_gubun", "f_map_gubun_ymd", "f_code", "f_page_number"});
            //set ExecuteQuery
            layCommon.ExecuteQuery = LoadDataLayCommon;
            fwkCommon.ExecuteQuery = LoadDataFwkCommon;
            fwkCode.ExecuteQuery = LoadDataFwkCommon;
            grdIFS0003.ExecuteQuery = LoadDataGrdIFS0003;

            IFS0001U00FindBoxInitArgs args = new IFS0001U00FindBoxInitArgs();
            args.Code = "ACCT_TYPE";
            ComboResult result = CloudService.Instance.Submit<ComboResult, IFS0001U00FindBoxInitArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.ComboItem.Count > 0)
                {
                    fbxAcct.Text = result.ComboItem[0].Code;
                    fbxAcct.AcceptData();
                }
            }
        }

        #region CloudService

        /// <summary>
        /// Load data for layCommon
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            IFS0003U00FbxSearchGubunArgs args = new IFS0003U00FbxSearchGubunArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            IFS0003U00FbxSearchGubunResult result = CloudService.Instance.Submit<IFS0003U00FbxSearchGubunResult, IFS0003U00FbxSearchGubunArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.CodeName
                });
            }
            return res;
        }


        /// <summary>
        /// Load data for fwkCommon and fwkCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataFwkCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            IFS0003U00GridFindClickArgs args = new IFS0003U00GridFindClickArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            args.MapGubun = bc["f_map_gubun"] != null ? bc["f_map_gubun"].VarValue : "";
            args.ColName = bc["f_col_name"] != null ? bc["f_col_name"].VarValue : "";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            args.Offset = bc["f_offset"] != null ? bc["f_offset"].VarValue : "";
            IFS0003U00GridFindClickResult result = CloudService.Instance.Submit<IFS0003U00GridFindClickResult, IFS0003U00GridFindClickArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.CboList)
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


        /// <summary>
        /// Load data for grdIFS0003
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdIFS0003(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            IFS0003U00GrdIFS0003Args args = new IFS0003U00GrdIFS0003Args();
            args.MapGubun = bc["f_map_gubun"] != null ? bc["f_map_gubun"].VarValue : "";
            args.MapGubunYmd = bc["f_map_gubun_ymd"] != null ? bc["f_map_gubun_ymd"].VarValue : "";
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.AcctType = fbxAcct.Text;
            args.PageNumber = bc["f_page_number"].VarValue;
            args.Offset = "200";
            IFS0003U00GrdIFS0003Result result = CloudService.Instance.Submit<IFS0003U00GrdIFS0003Result, IFS0003U00GrdIFS0003Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (IFS0003U00GrdIFS0003Info item in result.GrdList)
                {
                    object[] objects = 
				{ 
					item.MapGubun, 
					item.MapGubunYmd, 
					item.OcsCode, 
					item.OcsCodeName, 
					item.OcsDefaultYn, 
					item.IfCode, 
					item.IfCodeName, 
					item.IfDefaultYn, 
					item.Remark
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// save grdIFS0003
        /// </summary>
        /// <returns></returns>
        private bool SaveGrdIFS0003()
        {
            List<IFS0003U00GrdIFS0003Info> inputList = GetListFromGrdIFS0003();
            if (inputList.Count == 0)
            {
                return true;
            }
            IFS0003U00SaveLayoutArgs args = new IFS0003U00SaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, IFS0003U00SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (!result.Result)
                {
                    if (!String.IsNullOrEmpty(result.Msg))
                    {
                        string[] msg = result.Msg.Split(Convert.ToChar(" "));
                        XMessageBox.Show(Resources.TEXT25 + msg[0] + Resources.TEXT26 +
                            Resources.TEXT27 + msg[1] + Resources.TEXT28 +
                            Resources.TEXT29, Resources.TEXT30, MessageBoxIcon.Warning);
                    }
                    return result.Result;
                }
                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.TEXT5 : Resources.TEXT6;
                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.TEXT7 : Resources.TEXT8;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.grdIFS0003.QueryLayout(false);
                return result.Result;
            }

            return false;
        }

        /// <summary>
        /// get list object from grdIFS0003
        /// </summary>
        /// <returns></returns>
        private List<IFS0003U00GrdIFS0003Info> GetListFromGrdIFS0003()
        {
            List<IFS0003U00GrdIFS0003Info> dataList = new List<IFS0003U00GrdIFS0003Info>();
            for (int i = 0; i < grdIFS0003.RowCount; i++)
            {
                if (grdIFS0003.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                IFS0003U00GrdIFS0003Info info = new IFS0003U00GrdIFS0003Info();
                info.MapGubun = grdIFS0003.GetItemString(i, "map_gubun");
                info.MapGubunYmd = grdIFS0003.GetItemString(i, "map_gubun_ymd");
                info.OcsCode = grdIFS0003.GetItemString(i, "ocs_code");
                info.OcsCodeName = grdIFS0003.GetItemString(i, "ocs_code_name");
                info.OcsDefaultYn = grdIFS0003.GetItemString(i, "ocs_default_yn");
                if (string.IsNullOrEmpty(grdIFS0003.GetItemString(i, "if_code")))
                {
                    XMessageBox.Show(Resources.WARNING_SMS, Resources.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<IFS0003U00GrdIFS0003Info>();
                }

                info.IfCode = grdIFS0003.GetItemString(i, "if_code");
                info.IfCodeName = grdIFS0003.GetItemString(i, "if_code_name");
                info.IfDefaultYn = grdIFS0003.GetItemString(i, "if_default_yn");
                info.Remark = grdIFS0003.GetItemString(i, "remark");
                info.RowState = grdIFS0003.GetRowState(i).ToString();
                info.AcctType = fbxAcct.Text;

                dataList.Add(info);
            }
            if (grdIFS0003.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdIFS0003.DeletedRowTable.Rows)
                {
                    IFS0003U00GrdIFS0003Info info = new IFS0003U00GrdIFS0003Info();
                    info.MapGubun = row["map_gubun"].ToString();
                    info.MapGubunYmd = row["map_gubun_ymd"].ToString();
                    info.OcsCode = row["ocs_code"].ToString();
                    info.IfCode = row["if_code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    info.AcctType = fbxAcct.Text;
                    dataList.Add(info);
                }
            }

            return dataList;
        }

        #endregion

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
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IFS0003U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdIFS0003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fwkCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtNameAcct = new IHIS.Framework.XDisplayBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.fbxAcct = new IHIS.Framework.XFindBox();
            this.txbSearchCode = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxSearchGubunName = new IHIS.Framework.XDisplayBox();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.fbxSearchGubun = new IHIS.Framework.XFindBox();
            this.xDateMapGubunYmd = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIFS0003)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
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
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.grdIFS0003);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdIFS0003
            // 
            this.grdIFS0003.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdIFS0003, "grdIFS0003");
            this.grdIFS0003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdIFS0003.ColPerLine = 9;
            this.grdIFS0003.Cols = 10;
            this.grdIFS0003.ExecuteQuery = null;
            this.grdIFS0003.FixedCols = 1;
            this.grdIFS0003.FixedRows = 2;
            this.grdIFS0003.HeaderHeights.Add(19);
            this.grdIFS0003.HeaderHeights.Add(25);
            this.grdIFS0003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdIFS0003.Name = "grdIFS0003";
            this.grdIFS0003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdIFS0003.ParamList")));
            this.grdIFS0003.QuerySQL = resources.GetString("grdIFS0003.QuerySQL");
            this.grdIFS0003.RowHeaderVisible = true;
            this.grdIFS0003.Rows = 3;
            this.grdIFS0003.ToolTipActive = true;
            this.grdIFS0003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdIFS0003_GridColumnChanged);
            this.grdIFS0003.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdIFS0003_GridFindClick);
            this.grdIFS0003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIFS0003_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "map_gubun";
            this.xEditGridCell3.CellWidth = 167;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "map_gubun_ymd";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 90;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 30;
            this.xEditGridCell5.CellName = "ocs_code";
            this.xEditGridCell5.CellWidth = 83;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.FindWorker = this.fwkCode;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.Row = 1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkCode
            // 
            this.fwkCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6});
            this.fwkCode.ExecuteQuery = null;
            this.fwkCode.FormText = global::IHIS.BASS.Properties.Resources.TEXT1;
            this.fwkCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCode.ParamList")));
            this.fwkCode.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCode.ServerFilter = true;
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "code";
            this.findColumnInfo5.ColWidth = 102;
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "code_name";
            this.findColumnInfo6.ColWidth = 233;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellLen = 80;
            this.xEditGridCell6.CellName = "ocs_code_name";
            this.xEditGridCell6.CellWidth = 193;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.Row = 1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellLen = 1;
            this.xEditGridCell8.CellName = "ocs_default_yn";
            this.xEditGridCell8.CellWidth = 30;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellLen = 30;
            this.xEditGridCell9.CellName = "if_code";
            this.xEditGridCell9.CellWidth = 89;
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.FindWorker = this.fwkCommon;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.Row = 1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.FormText = global::IHIS.BASS.Properties.Resources.TEXT2;
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
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellLen = 80;
            this.xEditGridCell10.CellName = "if_code_name";
            this.xEditGridCell10.CellWidth = 191;
            this.xEditGridCell10.Col = 7;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.Row = 1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellLen = 1;
            this.xEditGridCell11.CellName = "if_default_yn";
            this.xEditGridCell11.CellWidth = 28;
            this.xEditGridCell11.Col = 8;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.Row = 1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellLen = 4000;
            this.xEditGridCell12.CellName = "remark";
            this.xEditGridCell12.CellWidth = 63;
            this.xEditGridCell12.Col = 9;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 3;
            this.xGridHeader1.ColSpan = 3;
            this.xGridHeader1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 83;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 6;
            this.xGridHeader2.ColSpan = 3;
            this.xGridHeader2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 89;
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
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.txtNameAcct);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.fbxAcct);
            this.xPanel2.Controls.Add(this.txbSearchCode);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.dbxSearchGubunName);
            this.xPanel2.Controls.Add(this.xLabel18);
            this.xPanel2.Controls.Add(this.fbxSearchGubun);
            this.xPanel2.Controls.Add(this.xDateMapGubunYmd);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // txtNameAcct
            // 
            this.txtNameAcct.AccessibleDescription = null;
            this.txtNameAcct.AccessibleName = null;
            resources.ApplyResources(this.txtNameAcct, "txtNameAcct");
            this.txtNameAcct.Image = null;
            this.txtNameAcct.Name = "txtNameAcct";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // fbxAcct
            // 
            this.fbxAcct.AccessibleDescription = null;
            this.fbxAcct.AccessibleName = null;
            resources.ApplyResources(this.fbxAcct, "fbxAcct");
            this.fbxAcct.BackgroundImage = null;
            this.fbxAcct.FindWorker = this.fwkCommon;
            this.fbxAcct.Name = "fbxAcct";
            this.fbxAcct.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxAcct_DataValidating);
            this.fbxAcct.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxAcct_FindClick);
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
            // xDateMapGubunYmd
            // 
            this.xDateMapGubunYmd.AccessibleDescription = null;
            this.xDateMapGubunYmd.AccessibleName = null;
            resources.ApplyResources(this.xDateMapGubunYmd, "xDateMapGubunYmd");
            this.xDateMapGubunYmd.BackgroundImage = null;
            this.xDateMapGubunYmd.IsVietnameseYearType = false;
            this.xDateMapGubunYmd.Name = "xDateMapGubunYmd";
            this.xDateMapGubunYmd.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xDateMapGubunYmd_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // layDupCheck
            // 
            this.layDupCheck.ExecuteQuery = null;
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupCheck.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // IFS0003U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "IFS0003U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.IFS0003U00_Closing);
            this.Load += new System.EventHandler(this.IFS0003U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIFS0003)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region IFS0003U00_Load
        private void IFS0003U00_Load(object sender, EventArgs e)
        {
            //this.grdIFS0003.SavePerformer = new XSavePeformer(this);

            this.xDateMapGubunYmd.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.grdIFS0003.QueryLayout(false);
        }
        #endregion

        #region fbxSearchGubun_FindClick [マッピング区分FIND]
        private void fbxSearchGubun_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = (XFindBox)sender;

            switch (control.Name)
            {
                case "fbxSearchGubun":
                    this.fwkCommon.FormText = Resources.TEXT3;
                    this.fwkCommon.ColInfos[0].HeaderText = Resources.TEXT16;
                    this.fwkCommon.ColInfos[0].ColWidth = 140;
                    this.fwkCommon.ColInfos[1].HeaderText = Resources.TEXT32;
                    this.fwkCommon.ColInfos[1].ColWidth = 250;

                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    switch (fbxAcct.Text)
                    {
                        case "00":
                            this.fwkCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_ORCA");
                            break;
                        case "01":
                            this.fwkCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_SKR");
                            break;
                        // MED-16347
                        case "02":
                            this.fwkCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_ALL");
                            break;
                        case "20":
                            this.fwkCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_MISA");
                            break;
                    }
                    
                    //tungtx
                    this.fwkCommon.SetBindVarValue("f_col_name", "if_code");
                    this.fwkCommon.ExecuteQuery = LoadDataFwkCommon;
                    break;
            }
        }
        #endregion

        #region fbxSearchGubun_DataValidating [マッピング区分DataValidating]
        private void fbxSearchGubun_DataValidating(object sender, DataValidatingEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            SingleLayoutItem sli = new SingleLayoutItem();

            this.layCommon.LayoutItems.Clear();

            switch (control.Name)
            {
                case "fbxSearchGubun":
                    //                    this.layCommon.QuerySQL = @"SELECT A.CODE_NAME
                    //                                              FROM IFS0002 A
                    //                                             WHERE A.HOSP_CODE   = :f_hosp_code 
                    //                                               AND A.CODE_TYPE   = :f_code_type
                    //                                               AND A.CODE        = :f_code ";
                    sli.DataName = "gubun_name";
                    sli.BindControl = this.dbxSearchGubunName;
                    this.layCommon.LayoutItems.Add(sli);

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_code", this.fbxSearchGubun.GetDataValue());
                    switch (fbxAcct.Text)
                    {
                        case "00":
                            this.layCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_ORCA");
                            break;
                        case "01":
                            this.layCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_SKR");
                            break;
                        case "20":
                            this.layCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_MISA");
                            break;
                    }
                    this.layCommon.QueryLayout();
                    this.grdIFS0003.QueryLayout(false);
                    break;
            }
        }
        #endregion

        #region xDateMapGubunYmd_DataValidating [適用日付DataValidating]
        private void xDateMapGubunYmd_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                this.grdIFS0003.QueryLayout(false);
            }
        }
        #endregion

        #region grdIFS0003_QueryStarting
        private void grdIFS0003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string code = "%";

            if (!TypeCheck.IsNull(this.txbSearchCode.GetDataValue())) code = this.txbSearchCode.GetDataValue();

            this.grdIFS0003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdIFS0003.SetBindVarValue("f_map_gubun", this.fbxSearchGubun.GetDataValue());
            this.grdIFS0003.SetBindVarValue("f_map_gubun_ymd", this.xDateMapGubunYmd.GetDataValue());
            this.grdIFS0003.SetBindVarValue("f_code", code);
        }
        #endregion

        #region grdIFS0003_GridFindClick [GRIDのコードFIND]
        private void grdIFS0003_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            if (e.ColName == "if_code")
            {
                string map_gubun = this.grdIFS0003.GetItemString(e.RowNumber, "map_gubun");

                this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.fwkCommon.SetBindVarValue("f_code_type", map_gubun);

                //tungtx
                this.fwkCommon.SetBindVarValue("f_col_name", "if_code");

                this.fwkCommon.FormText = Resources.TEXT4;
                this.fwkCommon.ColInfos[0].HeaderText = Resources.TEXT69;
                this.fwkCommon.ColInfos[1].HeaderText = Resources.TEXT70;
            }

            if (e.ColName == "ocs_code")
            {
                string map_gubun = this.grdIFS0003.GetItemString(e.RowNumber, "map_gubun");
                map_gubun = map_gubun.Replace("ORCA", "SKR");

                //string InputSQL = "";
                //InputSQL = @"  SELECT A.CODE         AS CODE     "+
                //            "        , A.CODE_NAME    AS NAME    "+  
                //            "     FROM "+"VW_IFS_"+map_gubun+" A "+
                //            "    WHERE A.HOSP_CODE    = :f_hosp_code ";

                //this.fwkCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                //this.fwkCode.InputSQL = InputSQL;

                this.fwkCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.fwkCode.SetBindVarValue("f_col_name", "ocs_code");
                this.fwkCode.SetBindVarValue("f_map_gubun", map_gubun);

            }
        }
        #endregion

        #region grdIFS0003_GridColumnChanged [OCS,IFコードのコード名を自動設定]
        private void grdIFS0003_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            IFS0003U00GridColumnChangeArgs args = new IFS0003U00GridColumnChangeArgs();
            IFS0003U00GridColumnChangeResult result = new IFS0003U00GridColumnChangeResult();

            switch (e.ColName)
            {
                case "ocs_code":
                    //                    SingleLayout ocsCommon = new SingleLayout();
                    //                    ocsCommon.QuerySQL = @"SELECT  PKG_IFS_BAS.FN_LOAD_OCS_CODE_NAME(:f_hosp_code, :f_map_gubun, :f_code ) OCS_CODE_NAME
                    //                                              FROM DUAL ";

                    //                    ocsCommon.LayoutItems.Add("ocs_code_name");
                    //                    ocsCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    //                    ocsCommon.SetBindVarValue("f_map_gubun", this.fbxSearchGubun.GetDataValue());
                    //                    ocsCommon.SetBindVarValue("f_code", this.grdIFS0003.GetItemString(e.RowNumber, "ocs_code"));

                    args.Code = this.grdIFS0003.GetItemString(e.RowNumber, "ocs_code");
                    args.ColName = "ocs_code";
                    args.MapGubun = this.fbxSearchGubun.GetDataValue().Replace("ORCA", "SKR");

                    result =
                        CloudService.Instance.Submit<IFS0003U00GridColumnChangeResult, IFS0003U00GridColumnChangeArgs>(
                            args);

                    //if (ocsCommon.QueryLayout())
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        //if (ocsCommon.GetItemValue("ocs_code_name").ToString() != "")
                        if (!String.IsNullOrEmpty(result.Result))
                        {
                            //this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", ocsCommon.GetItemValue("ocs_code_name").ToString());
                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", result.Result);
                        }
                        else
                        {
                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code", "");
                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", "");
                        }
                    }
                    else
                    {
                        this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code", "");
                        this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", "");
                    }

                    break;

                case "if_code":

                    //SingleLayout layCommon = new SingleLayout();
                    //layCommon.QuerySQL = @"SELECT  PKG_IFS_BAS.FN_LOAD_IF_CODE_NAME(:f_hosp_code, :f_map_gubun, :f_code ) IF_CODE_NAME FROM DUAL ";

                    //layCommon.LayoutItems.Add("if_code_name");
                    //layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    //layCommon.SetBindVarValue("f_map_gubun", this.fbxSearchGubun.GetDataValue());
                    //layCommon.SetBindVarValue("f_code", this.grdIFS0003.GetItemString(e.RowNumber, "if_code"));

                    args.Code = this.grdIFS0003.GetItemString(e.RowNumber, "if_code");
                    args.ColName = "if_code";
                    args.MapGubun = this.fbxSearchGubun.GetDataValue();

                    result =
                        CloudService.Instance.Submit<IFS0003U00GridColumnChangeResult, IFS0003U00GridColumnChangeArgs>(
                            args);

                    //if (layCommon.QueryLayout())
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        //this.grdIFS0003.SetItemValue(e.RowNumber, "if_code_name", layCommon.GetItemValue("if_code_name").ToString());
                        this.grdIFS0003.SetItemValue(e.RowNumber, "if_code_name", result.Result);
                    }
                    else
                    {
                        this.grdIFS0003.SetItemValue(e.RowNumber, "if_code", "");
                        this.grdIFS0003.SetItemValue(e.RowNumber, "if_code_name", "");
                    }
                    break;
            }
        }
        #endregion


        #region [ btnList_ButtonClick ]

        string mMsg = "";
        string mCap = "";
        string mCheck = "";
        bool boolSave = true;

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            this.boolSave = true;

            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;
                    this.grdIFS0003.QueryLayout(false);

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    //if (this.grdIFS0003.SaveLayout())
                    try
                    {
                        if (grdIFS0003.ValidateCell())
                        {
                            if (!SaveGrdIFS0003())
                            {
                                this.boolSave = false;
                                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.TEXT9 : Resources.TEXT10;
                                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.TEXT13 : Resources.TEXT14;
                                this.mMsg += "\r\n" + Service.ErrFullMsg;
                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
						//https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(ex.Message, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    
                    break;

                case FunctionType.Insert:
                    if (!String.IsNullOrEmpty(fbxSearchGubun.Text))
                    {
                        e.IsBaseCall = false;

                        int rowNum = this.grdIFS0003.InsertRow();

                        this.grdIFS0003.SetItemValue(rowNum, "map_gubun_ymd", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                        if (!TypeCheck.IsNull(this.fbxSearchGubun.GetDataValue()))
                        {
                            int cntNumber = this.grdIFS0003.CurrentRowNumber - 1;
                            this.grdIFS0003.SetItemValue(rowNum, "map_gubun", this.fbxSearchGubun.GetDataValue());
                        }
                    }
                    else
                    {
                        fbxSearchGubun.Focus();
                    }

                    break;

                default:
                    break;
            }
        }



        #endregion


        #region [ XSavePeformer ]
        //        public class XSavePeformer : ISavePerformer
        //        {
        //            IFS0003U00 parent = null;

        //            public XSavePeformer(IFS0003U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            private int Validateion_Check(BindVarCollection BindVarList)
        //            {
        //                int value = 0;
        //                string messg = "";
        //                if (BindVarList["f_map_gubun"].VarValue == "")
        //                {
        //                    messg += NetInfo.Language == LangMode.Ko ? Resources.TEXT15 : Resources.TEXT16;
        //                    value = 1;
        //                }
        //                if (BindVarList["f_ocs_code"].VarValue == "")
        //                {
        //                    if (value == 1)
        //                    {
        //                        messg += ",";
        //                    }
        //                    messg += NetInfo.Language == LangMode.Ko ? Resources.TEXT17 : Resources.TEXT18;
        //                    value = 2;
        //                }
        //                if (BindVarList["f_ocs_default_yn"].VarValue == "")
        //                {
        //                    if (value > 1)
        //                    {
        //                        messg += ",";
        //                    }
        //                    messg += NetInfo.Language == LangMode.Ko ? "OCS_YN" : "OCS_YN";
        //                    value = 3;
        //                }
        //                if (BindVarList["f_if_code"].VarValue == "")
        //                {
        //                    if (value > 1)
        //                    {
        //                        messg += ",";
        //                    }
        //                    messg += NetInfo.Language == LangMode.Ko ? Resources.TEXT19 : Resources.TEXT20;
        //                    value = 4;
        //                }
        //                if (BindVarList["f_if_default_yn"].VarValue == "")
        //                {
        //                    if (value > 1)
        //                    {
        //                        messg += ",";
        //                    }
        //                    messg += NetInfo.Language == LangMode.Ko ? "IF_YN" : "IF_YN";
        //                    value = 5;
        //                }
        //                if (BindVarList["f_map_gubun_ymd"].VarValue == "")
        //                {
        //                    if (value > 1)
        //                    {
        //                        messg += ",";
        //                    }
        //                    messg += NetInfo.Language == LangMode.Ko ? Resources.TEXT21 : Resources.TEXT22;
        //                    value = 6;
        //                }
        //                if (BindVarList["f_remark"].VarValue == "")
        //                {
        //                    if (value > 1)
        //                    {
        //                        messg += ",";
        //                    }
        //                    messg += NetInfo.Language == LangMode.Ko ? Resources.TEXT23 : Resources.TEXT24;
        //                    value = 7;
        //                }
        //                parent.mCheck = messg;
        //                return value;
        //            }            

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                object t_dup_check = "";

        //                item.BindVarList.Add("f_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //                switch (callerID)
        //                {
        //                    case '1':

        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:

        //                                //if (Validateion_Check(item.BindVarList) != 0)
        //                                //{
        //                                //    return false;
        //                                //}

        //                                cmdText = @"SELECT 'Y' 
        //            	                                  FROM DUAL
        //            	                                 WHERE EXISTS ( SELECT 'X'
        //                                                                  FROM IFS0003
        //                                                                 WHERE HOSP_CODE      = :f_hosp_code
        //                                                                   AND MAP_GUBUN      = :f_map_gubun
        //                                                                   AND OCS_CODE       = :f_ocs_code
        //                                                                   AND MAP_GUBUN_YMD  = :f_map_gubun_ymd) ";

        //                                t_dup_check = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                                if (!TypeCheck.IsNull(t_dup_check))
        //                                {
        //                                    if (t_dup_check.ToString() == "Y")
        //                                    {
        //                                        XMessageBox.Show(Resources.TEXT25 + item.BindVarList["f_map_gubun"].VarValue + Resources.TEXT26 +
        //                                                         Resources.TEXT27 + item.BindVarList["f_map_gubun_ymd"].VarValue + Resources.TEXT28 +
        //                                                         Resources.TEXT29, Resources.TEXT30, MessageBoxIcon.Warning);
        //                                        return false;
        //                                    }
        //                                }

        //                                cmdText = @"UPDATE IFS0003 A
        //										    SET A.UPD_ID            = :f_user_id
        //										      , A.UPD_DATE          = SYSDATE
        //										      , A.REMARK            = :f_remark
        //									      WHERE A.HOSP_CODE         = :f_hosp_code
        //                                            AND A.MAP_GUBUN         = :f_map_gubun
        //										    AND A.MAP_GUBUN_YMD     = :f_map_gubun_ymd
        //										    AND A.OCS_CODE          = :f_ocs_code";
        //                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

        //                                cmdText = @"INSERT INTO IFS0003 (
        //                                                            SYS_DATE,       SYS_ID,             UPD_DATE,           UPD_ID,
        //                                                            HOSP_CODE,      MAP_GUBUN,          MAP_GUBUN_YMD,
        //                                                            OCS_CODE,       OCS_DEFAULT_YN,     IF_CODE,            IF_DEFAULT_YN,
        //                                                            REMARK
        //        									    ) VALUES (
        //									                        SYSDATE,        :f_user_id,         sysdate,            NULL,
        //									                        :f_hosp_code,   :f_map_gubun,       :f_map_gubun_ymd,
        //                                                            :f_ocs_code,    :f_ocs_default_yn,  :f_if_code,         :f_if_default_yn,
        //									                        :f_remark )";

        //                                break;
        //                            case DataRowState.Modified:

        //                                //if (Validateion_Check(item.BindVarList) != 0)
        //                                //{
        //                                //    return false;
        //                                //}
        //                                cmdText = @"UPDATE IFS0003 A
        //										    SET A.UPD_ID            = :f_user_id
        //										      , A.UPD_DATE          = SYSDATE
        //                                              , MAP_GUBUN_YMD       = :f_map_gubun_ymd
        //                                              , OCS_CODE            = :f_ocs_code
        //                                              , OCS_DEFAULT_YN      = :f_ocs_default_yn
        //                                              , IF_CODE             = :f_if_code
        //                                              , IF_DEFAULT_YN       = :f_if_default_yn
        //										      , A.REMARK            = :f_remark
        //									      WHERE A.HOSP_CODE         = :f_hosp_code
        //                                            AND A.MAP_GUBUN         = :f_map_gubun
        //										    AND A.MAP_GUBUN_YMD     = :f_map_gubun_ymd
        //										    AND A.OCS_CODE          = :f_ocs_code";
        //                                break;

        //                            case DataRowState.Deleted:

        //                                cmdText = @"DELETE
        //                                           FROM IFS0003 A
        //									      WHERE A.HOSP_CODE         = :f_hosp_code
        //                                            AND A.MAP_GUBUN         = :f_map_gubun
        //										    AND A.MAP_GUBUN_YMD     = :f_map_gubun_ymd
        //										    AND A.OCS_CODE          = :f_ocs_code
        //										    AND A.IF_CODE           = :f_if_code";
        //                                break;
        //                        }
        //                        break;
        //                }
        //                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //            }
        //        }
        #endregion

        #region IFS0003U00_Closing
        private void IFS0003U00_Closing(object sender, CancelEventArgs e)
        {
            if (this.boolSave == false)
            {
                e.Cancel = true;
            }
        }
        #endregion

        private void fbxAcct_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = (XFindBox)sender;

            this.fwkCommon.AutoQuery = true;
            this.fwkCommon.ServerFilter = true;
            this.fwkCommon.FormText = Resources.TEXT12;// "会計システム";
            this.fwkCommon.ColInfos[0].HeaderText = Resources.TEXT16;
            this.fwkCommon.ColInfos[0].ColWidth = 200;
            this.fwkCommon.ColInfos[1].HeaderText = Resources.TEXT11;
            this.fwkCommon.ColInfos[1].ColWidth = 250;
            this.fwkCommon.SetBindVarValue("f_find1", "");

            this.fwkCommon.ExecuteQuery = LoadDataFwkCommonAcct;
        }

        /// <summary>
        /// Load data for fwkCommon
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataFwkCommonAcct(BindVarCollection bc)
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

        private void fbxAcct_DataValidating(object sender, DataValidatingEventArgs e)
        {
            fbxSearchGubun.SetDataValue("");
            this.grdIFS0003.QueryLayout(false);

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
                        this.txtNameAcct.SetEditValue(retVal);
                        txtNameAcct.AcceptData();
                    }
                }
                else
                {
                    this.mbxMsg = Resources.MSG9;

                    this.SetMsg(this.mbxMsg, MsgType.Error);

                    this.txtNameAcct.SetEditValue("");
                    txtNameAcct.AcceptData();

                    e.Cancel = true;

                    return;
                }
            }
        }
    }
}