/*******************************************************************************
 * ﾇﾁｷﾎｱﾗｷ･ｸ・ ADM106U
 *  ｳｻ    ｿ・: ｸﾞｴｺｵ﨧ﾏ
 *             ｰ｢ｰ｢ﾀﾇ ｽﾃｽｺﾅﾛｿ｡ ｸﾞｴｺｸｦ ｵ﨧ﾏﾇﾏｰ・
 *             ｰ｢ｰ｢ﾀﾇ ｸﾞｴｺｿ｡ ﾇﾁｷﾎｱﾗｷ･ﾀﾇ ｵ﨧ﾏﾀﾌ ｰ｡ｴﾉﾄﾉ ﾇﾘﾁﾖｴﾂ ﾇﾁｷﾎｱﾗｷ･
 *  ﾀﾛ ｼｺ ﾀﾚ : ｱ雹ﾎｼ・
 *  ｳｯ    ﾂ･ : 2005.2.20
 * ****************************************************************************/

#region namespace
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.ADMA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
#endregion

namespace IHIS.ADMA
{
    /// <summary>
    /// ADM106Uｿ｡ ｴ・ﾑ ｿ萓・ｼｳｸ暲ﾔｴﾏｴﾙ.
    /// </summary>
    [ToolboxItem(false)]
    public class ADM106U : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XTreeView menuTree;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private System.Windows.Forms.ImageList imageList1;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGrid grdMenuList;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XDisplayBox dbxSysNm;
        private IHIS.Framework.XFindBox fbxSysID;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.FindColumnInfo findColumnInfo5;
        private IHIS.Framework.FindColumnInfo findColumnInfo6;
        private IHIS.Framework.XFindWorker fwkSysID;
        private IHIS.Framework.FindColumnInfo findColumnInfo7;
        private IHIS.Framework.FindColumnInfo findColumnInfo8;
        private IHIS.Framework.XFindWorker fwkPgmID;
        private MultiLayout layTreeQuery;
        private XButton btnUp;
        private XButton btnDown;
        private XPanel xPanel3;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayout layTreeChild;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private System.ComponentModel.IContainer components;

        public ADM106U()
        {
            InitializeComponent();

            #region 저장용 Save Performer 지정

            //this.grdMenuList.SavePerformer = new XSavePerformer(this);

            #endregion

            //set Paramlist
            this.fwkPgmID.ParamList = new List<string>(new String[] { "f_pgm_id" });
            this.grdMenuList.ParamList = new List<string>(new String[] { "f_sys_id", "f_upper_menu" });
            this.layTreeQuery.ParamList = new List<string>(new String[] { "f_sys_id", "f_upper_menu" });
            this.layTreeChild.ParamList = new List<string>(new String[] { "f_sys_id", "f_upper_menu" });

            //set ExecuteQuery
            this.fwkPgmID.ExecuteQuery = LoadDataFwkPgmID;
            this.fwkSysID.ExecuteQuery = LoadDataFwkSysID;
            this.grdMenuList.ExecuteQuery = LoadDataMakeQuery;
            this.layTreeQuery.ExecuteQuery = LoadDataMakeQuery;
            this.layTreeChild.ExecuteQuery = LoadDataMakeQuery;
        }


        #region CloudService

        private IList<object[]> LoadDataFwkSysID(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            ADM106UFwkSysIdArgs args = new ADM106UFwkSysIdArgs();
            ComboResult result = CacheService.Instance.Get<ADM106UFwkSysIdArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        }

        private List<object[]> LoadDataFwkPgmID(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM106UFwkPgmIDArgs args = new ADM106UFwkPgmIDArgs();
            args.PgmId = bc["f_pgm_id"] != null ? bc["f_pgm_id"].VarValue : "";
            ADM106UFwkPgmIDResult result = CloudService.Instance.Submit<ADM106UFwkPgmIDResult, ADM106UFwkPgmIDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.FwkList)
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

        private List<object[]> LoadDataMakeQuery(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM106UMakeQueryListItemArgs args = new ADM106UMakeQueryListItemArgs();
            args.SysId = bc["f_sys_id"] != null ? bc["f_sys_id"].VarValue : "";
            args.UpperMenu = bc["f_upper_menu"] != null ? bc["f_upper_menu"].VarValue : "";
            ADM106UMakeQueryListItemResult result = CloudService.Instance.Submit<ADM106UMakeQueryListItemResult, ADM106UMakeQueryListItemArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM106UMakeQueryListItemInfo item in result.ListInfo)
                {
                    object[] objects = 
				{ 
					item.SysId, 
					item.TrId, 
					item.TrSeq, 
					item.PgmId, 
					item.UpprMenu, 
					item.PgmNm, 
					item.PgmTp, 
					item.PgmOpenTp, 
					item.ShortCut, 
					item.MenuParam
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private bool SaveGrdMenuList()
        {
            List<ADM106UMakeQueryListItemInfo> inputList = GetListFromGrdMenuList();
            if (inputList.Count == 0)
                return true;
            
            ADM106USaveLayoutArgs args = new ADM106USaveLayoutArgs(UserInfo.UserID,
                Service.ClientIP.Substring(Service.ClientIP.Length - 6, 6), inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, ADM106USaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (!result.Result)
                {
                    if (result.Msg == "Added")
                    {
                        XMessageBox.Show(Resources.TEXT1, Resources.TEXT2, MessageBoxIcon.Error);
                    }
                    else
                    {
                        XMessageBox.Show(result.Msg);

                    }
                }
                xButtonList1.PerformClick(FunctionType.Query);
                return result.Result;
            }
            return false;
        }

        private List<ADM106UMakeQueryListItemInfo> GetListFromGrdMenuList()
        {
            List<ADM106UMakeQueryListItemInfo> dataList = new List<ADM106UMakeQueryListItemInfo>();
            for (int i = 0; i < grdMenuList.RowCount; i++)
            {
                if (grdMenuList.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                ADM106UMakeQueryListItemInfo info = new ADM106UMakeQueryListItemInfo();
                info.SysId = grdMenuList.GetItemString(i, "sys_id");
                info.TrId = grdMenuList.GetItemString(i, "tr_id");
                info.TrSeq = grdMenuList.GetItemString(i, "tr_seq");
                info.PgmId = grdMenuList.GetItemString(i, "pgm_id");
                info.UpprMenu = grdMenuList.GetItemString(i, "uppr_menu");
                info.PgmNm = grdMenuList.GetItemString(i, "pgm_nm");
                info.PgmTp = grdMenuList.GetItemString(i, "pgm_tp");
                info.PgmOpenTp = grdMenuList.GetItemString(i, "pgm_open_tp");
                info.RowState = grdMenuList.GetRowState(i).ToString();

                dataList.Add(info);
            }
            if (grdMenuList.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdMenuList.DeletedRowTable.Rows)
                {
                    ADM106UMakeQueryListItemInfo info = new ADM106UMakeQueryListItemInfo();
                    info.SysId = row["sys_id"].ToString();
                    info.TrId = row["tr_id"].ToString();
                    info.TrSeq = row["tr_seq"].ToString();
                    info.PgmId = row["pgm_id"].ToString();
                    info.UpprMenu = row["uppr_menu"].ToString();
                    info.PgmNm = row["pgm_nm"].ToString();
                    info.PgmTp = row["pgm_tp"].ToString();
                    info.PgmOpenTp = row["pgm_open_tp"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }

        #endregion



        /// <summary>
        /// Dispose 구현
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
        /// 디자이너에서 생성한 코드들
        /// 원래 글자가 깨졌어요
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM106U));
            this.menuTree = new IHIS.Framework.XTreeView();
            this.grdMenuList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.fwkPgmID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.fbxSysID = new IHIS.Framework.XFindBox();
            this.fwkSysID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo8 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dbxSysNm = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layTreeQuery = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.btnUp = new IHIS.Framework.XButton();
            this.btnDown = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.layTreeChild = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMenuList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layTreeQuery)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layTreeChild)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "닫힌폴더.gif");
            this.ImageList.Images.SetKeyName(1, "열린폴더.gif");
            this.ImageList.Images.SetKeyName(2, "보기.gif");
            // 
            // menuTree
            // 
            resources.ApplyResources(this.menuTree, "menuTree");
            this.menuTree.HideSelection = false;
            this.menuTree.ImageList = this.ImageList;
            this.menuTree.Name = "menuTree";
            this.menuTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.menuTree_AfterSelect);
            // 
            // grdMenuList
            // 
            this.grdMenuList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell8,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell6});
            this.grdMenuList.ColPerLine = 3;
            this.grdMenuList.Cols = 4;
            resources.ApplyResources(this.grdMenuList, "grdMenuList");
            this.grdMenuList.ExecuteQuery = null;
            this.grdMenuList.FixedCols = 1;
            this.grdMenuList.FixedRows = 1;
            this.grdMenuList.HeaderHeights.Add(38);
            this.grdMenuList.Name = "grdMenuList";
            this.grdMenuList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMenuList.ParamList")));
            this.grdMenuList.RowHeaderVisible = true;
            this.grdMenuList.Rows = 2;
            this.grdMenuList.ToolTipActive = true;
            this.grdMenuList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMenuList_GridColumnChanged);
            this.grdMenuList.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdMenuList_SaveEnd);
            this.grdMenuList.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdMenuList_GridColumnProtectModify);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "sys_id";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 5;
            this.xEditGridCell2.CellName = "tr_id";
            this.xEditGridCell2.CellWidth = 84;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "tr_seq";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 61;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell8.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AutoTabDataSelected = true;
            this.xEditGridCell3.CellLen = 20;
            this.xEditGridCell3.CellName = "pgm_id";
            this.xEditGridCell3.CellWidth = 131;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.FindWorker = this.fwkPgmID;
            this.xEditGridCell3.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell3.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkPgmID
            // 
            this.fwkPgmID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkPgmID.ExecuteQuery = null;
            this.fwkPgmID.FormText = global::IHIS.ADMA.Properties.Resources.TEXT3;
            this.fwkPgmID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkPgmID.ParamList")));
            this.fwkPgmID.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "pgm_id";
            this.findColumnInfo3.ColWidth = 116;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "pgm_nm";
            this.findColumnInfo4.ColWidth = 301;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 3;
            this.xEditGridCell4.CellName = "uppr_menu";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 40;
            this.xEditGridCell5.CellName = "pgm_nm";
            this.xEditGridCell5.CellWidth = 292;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell5.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 3;
            this.xEditGridCell7.CellName = "pgm_tp";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pgm_open_tp";
            this.xEditGridCell6.CellWidth = 128;
            this.xEditGridCell6.CodeDisplay = false;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.DictColumn = "PGM_OPEN_TP";
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell6.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // fbxSysID
            // 
            this.fbxSysID.AutoTabDataSelected = true;
            this.fbxSysID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxSysID.FindWorker = this.fwkSysID;
            resources.ApplyResources(this.fbxSysID, "fbxSysID");
            this.fbxSysID.Name = "fbxSysID";
            this.fbxSysID.Validating += new System.ComponentModel.CancelEventHandler(this.fbxSysID_Validating);
            // 
            // fwkSysID
            // 
            this.fwkSysID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo7,
            this.findColumnInfo8});
            this.fwkSysID.ExecuteQuery = null;
            this.fwkSysID.FormText = global::IHIS.ADMA.Properties.Resources.TEXT4;
            this.fwkSysID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkSysID.ParamList")));
            this.fwkSysID.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColName = "sys_id";
            this.findColumnInfo7.ColWidth = 116;
            this.findColumnInfo7.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo7, "findColumnInfo7");
            // 
            // findColumnInfo8
            // 
            this.findColumnInfo8.ColName = "sys_nm";
            this.findColumnInfo8.ColWidth = 210;
            this.findColumnInfo8.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo8, "findColumnInfo8");
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sysID";
            this.findColumnInfo1.ColWidth = 99;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sysNM";
            this.findColumnInfo2.ColWidth = 235;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "pgmID";
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "pgmNM";
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.dbxSysNm);
            this.xPanel2.Controls.Add(this.fbxSysID);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Name = "xPanel2";
            // 
            // dbxSysNm
            // 
            resources.ApplyResources(this.dbxSysNm, "dbxSysNm");
            this.dbxSysNm.Name = "dbxSysNm";
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // layTreeQuery
            // 
            this.layTreeQuery.ExecuteQuery = null;
            this.layTreeQuery.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10});
            this.layTreeQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTreeQuery.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sys_id";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "tr_id";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "tr_seq";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pgm_id";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "upper_menu";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "pgm_nm";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "pgm_tp";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "pgm_open_tp";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "short_cut";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "menu_param";
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.Name = "btnUp";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.Name = "btnDown";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.menuTree);
            this.xPanel3.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // layTreeChild
            // 
            this.layTreeChild.ExecuteQuery = null;
            this.layTreeChild.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.layTreeChild.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTreeChild.ParamList")));
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "sys_id";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "tr_id";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "tr_seq";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "pgm_id";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "upper_menu";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "pgm_nm";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "pgm_tp";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "pgm_open_tp";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "short_cut";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "menu_param";
            // 
            // ADM106U
            // 
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.grdMenuList);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "ADM106U";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ADM106U_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMenuList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layTreeQuery)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layTreeChild)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region MakeQuery

        //private string MakeQuery(string aSysID, string aUpperMenu)
        //{
        //    string queryText = " SELECT A.SYS_ID "
        //                    + "      , A.TR_ID "
        //                    + "      , A.TR_SEQ "
        //                    + "      , A.PGM_ID "
        //                    + "      , A.UPPR_MENU "
        //                    + "      , NVL(A.MENU_TITLE, B.PGM_NM) PGM_NM "
        //                    + "      , B.PGM_TP "
        //                    + "      , A.PGM_OPEN_TP "
        //                    + "      , A.SHORT_CUT "
        //                    + "      , A.MENU_PARAM "
        //                    + "   FROM ADM0300 B, ADM4100 A "
        //                    + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
        //                    + "    AND A.PGM_ID    = B.PGM_ID "
        //                    + "    AND A.SYS_ID    = '" + aSysID + "'";

        //    if (aUpperMenu == "")
        //    {
        //        queryText += "    AND A.UPPR_MENU IS NULL ";
        //    }
        //    else
        //    {
        //        queryText += "    AND NVL(A.UPPR_MENU,'x') = NVL('" + aUpperMenu + "','x')";
        //    }

        //    queryText += "    ORDER BY A.TR_SEQ ";

        //    return queryText;
        //}

        #endregion

        #region Query Grid Data

        private void QueryGridData(string aSysid, TreeNode aSelectedNode)
        {
            if (aSelectedNode == null) return;

            string uppermenu = ((Hashtable)aSelectedNode.Tag)["tr_id"].ToString();
            //this.grdMenuList.QuerySQL = this.MakeQuery(aSysid, uppermenu);

            this.grdMenuList.SetBindVarValue("f_sys_id", aSysid);
            this.grdMenuList.SetBindVarValue("f_upper_menu", uppermenu);

            this.grdMenuList.QueryLayout(true);
        }

        #endregion

        #region TreeMake

        private void MakeMenuTreeRoot(string aSysid)
        {
            Hashtable nodeInfo;
            TreeNode rootnode;
            TreeNode childnode;
            this.menuTree.Nodes.Clear();

            rootnode = new TreeNode(this.dbxSysNm.GetDataValue(), 0, 1);
            nodeInfo = new Hashtable();
            nodeInfo.Add("sys_id", aSysid);
            nodeInfo.Add("tr_id", "");
            nodeInfo.Add("pgm_id", "");
            nodeInfo.Add("pgm_tp", "M");
            rootnode.Tag = nodeInfo;

            menuTree.Nodes.Add(rootnode);

            //this.layTreeQuery.QuerySQL = this.MakeQuery(aSysid, "");
            this.layTreeQuery.SetBindVarValue("f_sys_id", aSysid);
            this.layTreeQuery.SetBindVarValue("f_upper_menu", "");

            this.layTreeQuery.QueryLayout(true);

            //MessageBox.Show(this.layTreeQuery.GetItemString(0, "pgm_nm"));

            foreach (DataRow dr in this.layTreeQuery.LayoutTable.Rows)
            {
                if (dr["pgm_tp"].ToString() == "M")
                    childnode = new TreeNode(dr["pgm_nm"].ToString(), 0, 1);
                else
                    childnode = new TreeNode(dr["pgm_nm"].ToString(), 2, 2);

                nodeInfo = new Hashtable();
                nodeInfo.Add("sys_id", aSysid);
                nodeInfo.Add("tr_id", dr["tr_id"].ToString());
                nodeInfo.Add("pgm_id", dr["pgm_id"].ToString());
                nodeInfo.Add("pgm_tp", dr["pgm_tp"].ToString());

                childnode.Tag = nodeInfo;

                MakeMenuTreeChild(aSysid, childnode);

                rootnode.Nodes.Add(childnode);
            }

            rootnode.Expand();

            //menuTree.ExpandAll();

        }

        private void MakeMenuTreeChild(string aSysid, TreeNode aParent)
        {
            Hashtable nodeInfo;
            TreeNode childnode;
            string upperMenu = "";

            if (aParent == null) return;

            aParent.Nodes.Clear();

            upperMenu = ((Hashtable)aParent.Tag)["tr_id"].ToString();

            //this.layTreeChild.QuerySQL = this.MakeQuery(aSysid, upperMenu);
            this.layTreeChild.SetBindVarValue("f_sys_id", aSysid);
            this.layTreeChild.SetBindVarValue("f_upper_menu", upperMenu);

            this.layTreeChild.QueryLayout(true);

            foreach (DataRow dr in this.layTreeChild.LayoutTable.Rows)
            {
                if (dr["pgm_tp"].ToString() == "M")
                    childnode = new TreeNode(dr["pgm_nm"].ToString(), 0, 1);
                else
                    childnode = new TreeNode(dr["pgm_nm"].ToString(), 2, 2);

                nodeInfo = new Hashtable();
                nodeInfo.Add("sys_id", aSysid);
                nodeInfo.Add("tr_id", dr["tr_id"].ToString());
                nodeInfo.Add("pgm_id", dr["pgm_id"].ToString());
                nodeInfo.Add("pgm_tp", dr["pgm_tp"].ToString());

                childnode.Tag = nodeInfo;

                aParent.Nodes.Add(childnode);
            }
        }

        #endregion

        #region MenuTree EventHandler
        private void menuTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.CurrMQLayout = this.grdMenuList;

            this.QueryGridData(this.fbxSysID.GetDataValue(), e.Node);

            this.menuTree.SelectedNode.Expand();
        }
        #endregion

        #region	grdMenuList Event

        private void grdMenuList_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "pgm_open_tp")
            {
                if (e.DataRow["pgm_id"].ToString().Substring(e.DataRow["pgm_id"].ToString().Length - 1, 1) == "M")
                    e.Protect = true;
                else
                    e.Protect = false;
            }
        }

        private void grdMenuList_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            string cmdText = "";
            object retVal = "";
            switch (e.ColName)
            {
                case "pgm_id":
                    //cmdText
                    //    = "SELECT PGM_NM FROM ADM0300 "
                    //    + " WHERE PGM_ID  = '" + this.grdMenuList.GetItemString(this.grdMenuList.CurrentRowNumber, "pgm_id") + "'";

                    //retVal = Service.ExecuteScalar(cmdText);

                    ADM106UGetPgmNameArgs args = new ADM106UGetPgmNameArgs(this.grdMenuList.GetItemString(this.grdMenuList.CurrentRowNumber, "pgm_id"));
                    ADM106UGetPgmNameResult result =
                        CloudService.Instance.Submit<ADM106UGetPgmNameResult, ADM106UGetPgmNameArgs>(args);

                    //if (retVal == null)
                    if (String.IsNullOrEmpty(result.PgmNm))
                    {
                        XMessageBox.Show(Resources.TEXT5, Resources.TEXT6, MessageBoxIcon.Information);
                        this.grdMenuList.SetFocusToItem(this.grdMenuList.CurrentRowNumber, "pgm_id");
                    }
                    else
                    {
                        //this.grdMenuList.SetItemValue(this.grdMenuList.CurrentRowNumber, "pgm_nm", retVal.ToString());
                        this.grdMenuList.SetItemValue(this.grdMenuList.CurrentRowNumber, "pgm_nm", result.PgmNm);
                    }
                    break;
                default:
                    break;
            }

        }

        private void grdMenuList_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (!e.IsSuccess)
            {
                XMessageBox.Show(e.ErrMsg + " " + Service.ErrFullMsg, Resources.TEXT2, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Update 관련

        private void ReMakeTrSeq()
        {
            for (int i = 0; i < this.grdMenuList.RowCount; i++)
            {
                if (this.grdMenuList.GetItemString(i, "tr_seq") != (i + 1).ToString() ||
                    this.grdMenuList.GetItemString(i, "tr_seq") == "")
                {
                    this.grdMenuList.SetItemValue(i, "tr_seq", i + 1);
                }
            }
        }

        #endregion

        #region XButtonList
        // 버튼 리스트 관련 이벤트
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            //string cmdText = "";

            switch (e.Func)
            {
                case FunctionType.Query:
                    this.grdMenuList.QueryLayout(false);
                    break;
                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    this.grdMenuList.DeleteRow(this.grdMenuList.CurrentRowNumber);
                    break;
                case FunctionType.Reset:

                    e.IsBaseCall = false;

                    this.Reset();

                    this.menuTree.Nodes.Clear();

                    this.fbxSysID.Focus();

                    break;
                case FunctionType.Update:

                    this.AcceptData();

                    // TR_SEQ 순번 재조정
                    this.ReMakeTrSeq();

                    //if (this.grdMenuList.SaveLayout())
                    if (checkValidate())
                    {
                        if (!SaveGrdMenuList())
                        {
                            e.IsSuccess = false;
                            XMessageBox.Show(Resources.MSG_SAVE_ERROR, Resources.MSG_NOTE, MessageBoxIcon.Error);
                        }
                        this.grdMenuList.QueryLayout(false);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_RQ_INPUT, Resources.MSG_NOTE, MessageBoxIcon.Warning);
                    }

                    break;
                case FunctionType.Insert:
                    if (this.menuTree.SelectedNode == null) return;

                    Hashtable nodeInfo = this.menuTree.SelectedNode.Tag as Hashtable;

                    if (nodeInfo["pgm_tp"].ToString() == "P")
                    {
                        XMessageBox.Show(Resources.TEXT7, Resources.TEXT6, MessageBoxIcon.Stop);
                        return;
                    }

                    e.IsBaseCall = false;

                    int newRow = this.grdMenuList.InsertRow(this.grdMenuList.CurrentRowNumber);

                    this.grdMenuList.SetItemValue(newRow, "sys_id", this.fbxSysID.GetDataValue());
                    this.grdMenuList.SetItemValue(newRow, "uppr_menu", nodeInfo["tr_id"].ToString());
                    this.grdMenuList.SetItemValue(newRow, "tr_id", "0000");

                    break;

            }
        }



        #endregion

        #region XButtonList Post Event
        //TreeNode oldnode;
        //int cntinsert = 1;
        private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {

            switch (e.Func)
            {
                case FunctionType.Update:
                    if (e.IsSuccess)
                    {
                        if (this.menuTree.SelectedNode != null)
                        {
                            if (this.menuTree.SelectedNode.Parent == null)
                                this.MakeMenuTreeRoot(this.fbxSysID.GetDataValue());
                            else
                                this.MakeMenuTreeChild(this.fbxSysID.GetDataValue(), this.menuTree.SelectedNode);
                            this.QueryGridData(this.fbxSysID.GetDataValue(), this.menuTree.SelectedNode);
                        }
                    }
                    else
                    {
                        XMessageBox.Show(Resources.TEXT8, Resources.TEXT6, MessageBoxIcon.Error);
                    }
                    break;
            }
        }
        #endregion

        #region 행변경

        private void ChangeGridRow(int aFromRow, int aToRow)
        {

            MultiLayout tempLay = this.grdMenuList.CloneToLayout();
            foreach (DataRow dr in this.grdMenuList.LayoutTable.Rows)
            {
                tempLay.LayoutTable.ImportRow(dr);
            }

            this.grdMenuList.LayoutTable.Rows.Clear();

            int currentColNum = (this.grdMenuList.CurrentColNumber < 0 ? 0 : this.grdMenuList.CurrentColNumber);


            for (int i = 0; i < tempLay.LayoutTable.Rows.Count; i++)
            {
                if (aFromRow == i) continue;

                if (aToRow == i)
                {
                    // 위로 올릴때
                    if (aFromRow > aToRow)
                    {
                        this.grdMenuList.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aFromRow]);
                        this.grdMenuList.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aToRow]);
                    }
                    // 밑으로 내릴때
                    else
                    {
                        this.grdMenuList.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aToRow]);
                        this.grdMenuList.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aFromRow]);
                    }
                }
                else
                {
                    this.grdMenuList.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[i]);
                }
            }

            this.grdMenuList.DisplayData();
            this.grdMenuList.SetFocusToItem(aToRow, currentColNum, false);
        }

        #endregion

        #region XFindBox

        private void fbxSysID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //string cmdText = " SELECT SYS_NM FROM ADM0200 WHERE SYS_ID = '" + this.fbxSysID.GetDataValue() + "'";

            //object retVal = Service.ExecuteScalar(cmdText);

            ADM106UGetSysNameArgs args = new ADM106UGetSysNameArgs(this.fbxSysID.GetDataValue());
            ADM106UGetSysNameResult result =
                CloudService.Instance.Submit<ADM106UGetSysNameResult, ADM106UGetSysNameArgs>(args);

            //if (retVal == null)
            if (String.IsNullOrEmpty(result.SysNm))
            {
                e.Cancel = true;

                //XMessageBox.Show(Resources.TEXT9, Resources.TEXT6, MessageBoxIcon.Error);
            }
            else
            {
                //this.dbxSysNm.SetDataValue(retVal.ToString());
                this.dbxSysNm.SetDataValue(result.SysNm);
                //this.SetMenuTree();
                this.MakeMenuTreeRoot(this.fbxSysID.GetDataValue());
            }

        }

        #endregion

        #region XSavePerformer

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {

            private ADM106U parent = null;


            public XSavePerformer(ADM106U parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = "";

                item.BindVarList.Add("f_q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_q_user_trm", Service.ClientIP.Substring(Service.ClientIP.Length - 6, 6));

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                #region Insert
                                cmdText
                                    = " SELECT MAX(TO_NUMBER(NVL(TR_ID,'0'))) + 1 FROM ADM4100 "
                                    + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                    + "    AND SYS_ID = '" + item.BindVarList["f_sys_id"].VarValue + "'";

                                retVal = Service.ExecuteScalar(cmdText);

                                if (retVal == null)
                                {
                                    XMessageBox.Show(" TR_ID 生成に失敗しました。", "保存失敗", MessageBoxIcon.Error);
                                    return false;
                                }

                                string trID = retVal.ToString().PadLeft(5, '0');

                                cmdText
                                    = "   INSERT INTO ADM4100 (SYS_ID, TR_ID, PGM_ID, TR_SEQ, UPPR_MENU, PGM_OPEN_TP, "
                                    + "                        MENU_PARAM, MENU_TITLE, CR_MEMB, CR_TRM,   CR_TIME  , HOSP_CODE )  "
                                    + "                VALUES (:f_sys_id, '" + trID + "', :f_pgm_id, :f_tr_seq, :f_uppr_menu, :f_pgm_open_tp,"
                                    + "                        '', :f_pgm_nm, :f_q_user_id, :f_q_user_trm, SYSDATE ,'" + EnvironInfo.HospCode + "') ";

                                break;
                                #endregion
                            case DataRowState.Modified:
                                #region Update
                                cmdText
                                    = " UPDATE ADM4100 "
                                    + "    SET PGM_ID      = :f_pgm_id, "
                                    + "        MENU_TITLE  = :f_pgm_nm, "
                                    + "        TR_SEQ      = :f_tr_seq, "
                                    + "        UPPR_MENU   = :f_uppr_menu, "
                                    + "        PGM_OPEN_TP = :f_pgm_open_tp, "
                                    //+ "        MENU_PARAM  = :f_menu_param, "
                                    + "        UP_MEMB     = :f_q_user_id,"
                                    + "        UP_TRM      = :f_q_user_trm, "
                                    + "        UP_TIME     = SYSDATE"
                                    + "  WHERE HOSP_CODE   = '" + EnvironInfo.HospCode + "'"
                                    + "    AND SYS_ID      = :f_sys_id "
                                    + "    AND TR_ID       = :f_tr_id ";
                                break;
                                #endregion
                            case DataRowState.Deleted:
                                #region Delete
                                cmdText
                                    = "DELETE ADM4100 "
                                    + " WHERE SYS_ID = :f_sys_id "
                                    + "   AND TR_ID  = :f_tr_id ";

                                if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    cmdText = " SELECT 'X' FROM ADM4100 "
                                            + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                            + "    AND SYS_ID = :f_sys_id AND UPPR_MENU = :f_tr_id ";
                                    retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                    if (retVal == null)
                                    {
                                        cmdText = "";
                                    }
                                    else
                                    {
                                        if (retVal.ToString() == "X")
                                        {
                                            cmdText
                                                = " DELETE ADM4100 "
                                                + "  WHERE SYS_ID = :f_sys_id "
                                                + "    AND UPPR_MENU = :f_tr_id ";
                                        }
                                    }
                                }
                                else
                                {
                                    XMessageBox.Show("Delete Failed.");
                                    return false;
                                }
                                break;
                                #endregion
                        }

                        if (cmdText != "")
                        {
                            if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                cmdText
                                    = "UPDATE ADM4310 "
                                    + "   SET MENU_GEN_YN = 'N' "
                                    + "  WHERE HOSP_CODE   = '" + EnvironInfo.HospCode + "'"
                                    + "    AND SYS_ID      = :f_sys_id "
                                    ;

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);
                                return true;
                            }
                            else
                            {
                                XMessageBox.Show("Failed");
                                return false;
                            }
                        }
                        else
                        {
                            cmdText
                                = "UPDATE ADM4310 "
                                + "   SET MENU_GEN_YN  = 'N' "
                                + "  WHERE HOSP_CODE   = '" + EnvironInfo.HospCode + "'"
                                + "    AND SYS_ID      = :f_sys_id "
                                ;

                            Service.ExecuteNonQuery(cmdText, item.BindVarList);
                            return true;
                        }
                    default:    // CallerID ﾀ・ﾞ ｽﾇﾆﾐ 
                        break;
                }
                return true;
            }
        }
        #endregion

        #region XButton

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.grdMenuList.RowCount == 0 ||
                this.grdMenuList.CurrentRowNumber == this.grdMenuList.RowCount - 1 ||
                this.grdMenuList.CurrentRowNumber < 0)
            {
                return;
            }

            this.ChangeGridRow(this.grdMenuList.CurrentRowNumber, this.grdMenuList.CurrentRowNumber + 1);

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.grdMenuList.RowCount == 0 ||
                this.grdMenuList.CurrentRowNumber == 0 ||
                this.grdMenuList.CurrentRowNumber < 0) return;

            this.ChangeGridRow(this.grdMenuList.CurrentRowNumber, this.grdMenuList.CurrentRowNumber - 1);
        }

        #endregion

        private void ADM106U_Load(object sender, EventArgs e)
        {
            this.fbxSysID.Focus();
        }

        
        private bool checkValidate()
        {
            ADM106UGetPgmNameArgs args = new ADM106UGetPgmNameArgs(this.grdMenuList.GetItemString(this.grdMenuList.CurrentRowNumber, "pgm_id"));
            ADM106UGetPgmNameResult result =
                CloudService.Instance.Submit<ADM106UGetPgmNameResult, ADM106UGetPgmNameArgs>(args);

            
            if (String.IsNullOrEmpty(result.PgmNm))
            {
                return false;
                
                
               
            }
            else
            {
                return true;
            }
            
        }
    }
}

