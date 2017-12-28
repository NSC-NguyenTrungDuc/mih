#region 사용 NameSpace 지정
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
    /// ADM102U??????붿빟 ?ㅻ챸?낅땲??
    /// </summary>
    [ToolboxItem(false)]
    public class ADM102U : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XLabel xLabel1;
        /// <summary>
        /// ?꾩닔 ?붿옄?대꼫 蹂?섏엯?덈떎.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private IHIS.Framework.XFindWorker fwkSysID;
        private IHIS.Framework.XEditGrid grdList;
        private IHIS.Framework.XDisplayBox dbxSysNm;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XFindBox fbxSysID;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;

        public ADM102U()
        {
            // ???몄텧? Windows Form ?붿옄?대꼫???꾩슂?⑸땲??
            InitializeComponent();


            ////????섑뻾??Set
            //this.grdList.SavePerformer = new XSavePerformer(this);
            ////???Layout List Set
            //this.SaveLayoutList.Add(this.grdList);

            //set ParamList
            grdList.ParamList = new List<string>(new String[] { "f_sys_id" });

            //set ExecuteQuery
            grdList.ExecuteQuery = LoadDataGrdList;
            fwkSysID.ExecuteQuery = LoadDataFwkSysID;
        }



        #region CloudService

        private IList<object[]> LoadDataFwkSysID(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            ADM102UFwkSysIdArgs args = new ADM102UFwkSysIdArgs();
            ComboResult result =
                //CacheService.Instance.Get<ADM102UFwkSysIdArgs, ComboResult>(
                //    Constants.CacheKeyCbo.CACHE_ADM102U_FWK_SYSID, args, delegate(ComboResult comboResult)
                //    {
                //        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                //               comboResult.ComboItem.Count > 0;
                //    });
                CacheService.Instance.Get<ADM102UFwkSysIdArgs, ComboResult>(args);

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

        private List<object[]> LoadDataGrdList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM102UGrdListArgs args = new ADM102UGrdListArgs();
            args.SysId = bc["f_sys_id"] != null ? bc["f_sys_id"].VarValue : "";
            ADM102UGrdListResult result = CloudService.Instance.Submit<ADM102UGrdListResult, ADM102UGrdListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM102UGrdListItemInfo item in result.GrdList)
                {
                    object[] objects =
                    {
                        item.PgmId,
                        item.PgmNm,
                        item.PgmTp,
                        item.SysId,
                        item.ProdId,
                        item.SrvcId,
                        item.PgmEntGrad,
                        item.PgmUpdGrad,
                        item.PgmScrt,
                        item.PgmDupYn,
                        item.EndYn,
                        item.PgmAcsYn,
                        item.MangMemb,
                        item.AsmName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private bool SaveGrdList()
        {
            ////pre-save 
            //if (e.RowState == DataRowState.Added)
            //    grdList.SetItemValue(e.RowNumber, "sys_id", this.fbxSysID.GetDataValue());
            List<ADM102UGrdListItemInfo> inputList = GetListFromGrdList();
            if (inputList.Count == 0)
            {
                return true;
            }
            foreach (ADM102UGrdListItemInfo info in inputList)
            {
                if (info.PgmId == "" || info.PgmNm == "")
                {
                    return false;
                }

                //if (inputList.Equals("PgmId") == true || inputList.Equals("PgmNm") == true)
                //{
                //    return false;
                //}
                continue;
            }
            ADM102USaveLayoutArgs args = new ADM102USaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, ADM102USaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }

            return false;
        }

        private List<ADM102UGrdListItemInfo> GetListFromGrdList()
        {
            List<ADM102UGrdListItemInfo> dataList = new List<ADM102UGrdListItemInfo>();
            for (int i = 0; i < grdList.RowCount; i++)
            {
                if (grdList.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                //pre-save
                if (grdList.GetRowState(i) == DataRowState.Added)
                {
                    grdList.SetItemValue(i, "sys_id", this.fbxSysID.GetDataValue());
                }

                ADM102UGrdListItemInfo info = new ADM102UGrdListItemInfo();
                info.PgmId = grdList.GetItemString(i, "pgm_id");
                info.PgmNm = grdList.GetItemString(i, "pgm_nm");
                info.PgmTp = grdList.GetItemString(i, "pgm_tp");
                info.SysId = grdList.GetItemString(i, "sys_id");
                info.ProdId = grdList.GetItemString(i, "prod_id");
                info.SrvcId = grdList.GetItemString(i, "srvc_id");
                info.PgmEntGrad = grdList.GetItemString(i, "pgm_end_grad");
                info.PgmUpdGrad = grdList.GetItemString(i, "pgm_upd_grad");
                info.PgmScrt = grdList.GetItemString(i, "pgm_scrt");
                info.PgmDupYn = grdList.GetItemString(i, "pgm_dup_yn");
                info.EndYn = grdList.GetItemString(i, "end_yn");
                info.PgmAcsYn = grdList.GetItemString(i, "pgm_acs_yn");
                info.MangMemb = grdList.GetItemString(i, "mang_memb");
                info.AsmName = grdList.GetItemString(i, "asm_name");
                info.RowState = grdList.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdList.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdList.DeletedRowTable.Rows)
                {
                    ADM102UGrdListItemInfo info = new ADM102UGrdListItemInfo();
                    info.PgmId = row["pgm_id"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }

        #endregion




        /// <summary>
        /// ?ъ슜 以묒씤 紐⑤뱺 由ъ냼?ㅻ? ?뺣━?⑸땲??
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
        /// ?붿옄?대꼫 吏?먯뿉 ?꾩슂??硫붿꽌?쒖엯?덈떎.
        /// ??硫붿꽌?쒖쓽 ?댁슜??肄붾뱶 ?몄쭛湲곕줈 ?섏젙?섏? 留덉떗?쒖삤.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM102U));
            this.fbxSysID = new IHIS.Framework.XFindBox();
            this.fwkSysID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.dbxSysNm = new IHIS.Framework.XDisplayBox();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // fbxSysID
            // 
            this.fbxSysID.AccessibleDescription = null;
            this.fbxSysID.AccessibleName = null;
            resources.ApplyResources(this.fbxSysID, "fbxSysID");
            this.fbxSysID.BackgroundImage = null;
            this.fbxSysID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxSysID.FindWorker = this.fwkSysID;
            this.fbxSysID.Name = "fbxSysID";
            this.fbxSysID.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSysID_DataValidating);
            // 
            // fwkSysID
            // 
            this.fwkSysID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkSysID.ExecuteQuery = null;
            this.fwkSysID.FormText = global::IHIS.ADMA.Properties.Resources.TEXT1;
            this.fwkSysID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkSysID.ParamList")));
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sysID";
            this.findColumnInfo1.ColWidth = 98;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sysNM";
            this.findColumnInfo2.ColWidth = 226;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // dbxSysNm
            // 
            this.dbxSysNm.AccessibleDescription = null;
            this.dbxSysNm.AccessibleName = null;
            resources.ApplyResources(this.dbxSysNm, "dbxSysNm");
            this.dbxSysNm.Image = null;
            this.dbxSysNm.Name = "dbxSysNm";
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell3,
            this.xEditGridCell24,
            this.xEditGridCell25});
            this.grdList.ColPerLine = 13;
            this.grdList.Cols = 13;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(31);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.Rows = 2;
            this.grdList.Load += new System.EventHandler(this.ADM102U_Load);
            this.grdList.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdList_PreSaveLayout);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 20;
            this.xEditGridCell1.CellName = "pgm_id";
            this.xEditGridCell1.CellWidth = 83;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 40;
            this.xEditGridCell2.CellName = "pgm_nm";
            this.xEditGridCell2.CellWidth = 141;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCell2.IsNotNull = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 1;
            this.xEditGridCell14.CellName = "pgm_tp";
            this.xEditGridCell14.CellWidth = 63;
            this.xEditGridCell14.Col = 2;
            this.xEditGridCell14.DictColumn = "PGM_TP";
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsNotNull = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 4;
            this.xEditGridCell15.CellName = "sys_id";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsNotNull = true;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "prod_id";
            this.xEditGridCell17.CellWidth = 56;
            this.xEditGridCell17.Col = 4;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.ImeMode = IHIS.Framework.ColumnImeMode.EngLower;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "srvc_id";
            this.xEditGridCell18.CellWidth = 52;
            this.xEditGridCell18.Col = 5;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "pgm_end_grad";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.CellWidth = 96;
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "pgm_upd_grad";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.CellWidth = 96;
            this.xEditGridCell20.Col = 7;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellLen = 8;
            this.xEditGridCell21.CellName = "pgm_scrt";
            this.xEditGridCell21.CellWidth = 96;
            this.xEditGridCell21.Col = 8;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellLen = 1;
            this.xEditGridCell22.CellName = "pgm_dup_yn";
            this.xEditGridCell22.CellWidth = 103;
            this.xEditGridCell22.Col = 9;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 1;
            this.xEditGridCell23.CellName = "end_yn";
            this.xEditGridCell23.CellWidth = 100;
            this.xEditGridCell23.Col = 10;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 1;
            this.xEditGridCell3.CellName = "pgm_acs_yn";
            this.xEditGridCell3.CellWidth = 72;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "mang_memb";
            this.xEditGridCell24.CellWidth = 81;
            this.xEditGridCell24.Col = 11;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellLen = 30;
            this.xEditGridCell25.CellName = "asm_name";
            this.xEditGridCell25.CellWidth = 133;
            this.xEditGridCell25.Col = 12;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
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
            // ADM102U
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.dbxSysNm);
            this.Controls.Add(this.fbxSysID);
            this.Name = "ADM102U";
            this.Load += new System.EventHandler(this.ADM102U_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region ADM102_Load(,)
        // 濡쒕뵫?쒖“?뚮퉬?쒖꽦??
        private void ADM102U_Load(object sender, System.EventArgs e)
        {
            this.CurrMSLayout = this.grdList;
            this.CurrMQLayout = this.grdList;
        }
        #endregion

        private void fbxSysID_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //?쒖뒪?쒕챸 Clear
            this.dbxSysNm.SetDataValue("");

            if (e.DataValue == "") return;

            //?쒖뒪?쏧D ?낅젰???쒖뒪?쒕챸 SET (硫붿꽭吏 ?쒖뒪?쒖? ?쒖쇅)
            //string cmdText = "SELECT SYS_NM FROM ADM0200 WHERE NVL(MSG_SYS_YN,'N') = 'N' AND SYS_ID ='" + e.DataValue + "'";
            //object retVal = Service.ExecuteScalar(cmdText);

            ADM102UGetSysNmArgs args = new ADM102UGetSysNmArgs(e.DataValue);
            ADM102UGetSysNmResult result = CloudService.Instance.Submit<ADM102UGetSysNmResult, ADM102UGetSysNmArgs>(args);
            //if (retVal == null)
            if (result.ExecutionStatus != ExecutionStatus.Success || String.IsNullOrEmpty(result.SysNm))
            {
                this.SetMsg(Resources.TEXT2); //?쒖뒪?쏧D瑜??섎せ ?낅젰
                e.Cancel = true;
                return;
            }
            //?쒖뒪?쒕챸 SET
            //this.dbxSysNm.SetDataValue(retVal.ToString());
            this.dbxSysNm.SetDataValue(result.SysNm);
            //議고쉶, ?꾩껜 議고쉶
            this.grdList.QueryLayout(true);
        }

        private void grdList_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //??μ쟾 Check (?쒖뒪?쏧D ?낅젰?щ? ?뺤씤)
            if (this.fbxSysID.GetDataValue() == "")
            {
                this.SetMsg(XMsg.GetMsg("M002"), MsgType.Error);  //?쒖뒪?쏧D瑜?癒쇱? ?낅젰?섏떗?쒖삤.
                e.Cancel = true;
                this.fbxSysID.Focus();
            }
            //議고쉶臾?Bind 蹂??SET (f_sys_id)
            this.grdList.SetBindVarValue("f_sys_id", fbxSysID.GetDataValue());

        }

        private void grdList_PreSaveLayout(object sender, IHIS.Framework.GridRecordEventArgs e)
        {
            //媛?????μ쟾???덈줈 ?낅젰???됱쓽 寃쎌슦 SYS_ID SET
            if (e.RowState == DataRowState.Added)
                grdList.SetItemValue(e.RowNumber, "sys_id", this.fbxSysID.GetDataValue());
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            //?낅젰,??μ쟾???쒖뒪??ID ?낅젰?щ? ?뺤씤
            if ((e.Func == FunctionType.Insert) || (e.Func == FunctionType.Update))
            {
                if (this.fbxSysID.GetDataValue() == "")
                {
                    this.SetMsg(Resources.TEXT3, MsgType.Error); //?쒖뒪?쏧D瑜?癒쇱? ?낅젰?섏떗?쒖삤.
                    e.IsBaseCall = false; //Base Call?섏? ?딆쓬 (湲곕낯湲곕뒫 ?섑뻾?섏? ?딆쓬)
                    this.fbxSysID.Focus();
                }
            }

            switch (e.Func)
            {
                    case FunctionType.Update:
                    if (SaveGrdList())
                    {
                        btnList.PerformClick(FunctionType.Query);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_SAVE_ERROR, Resources.MSG_SAVE_ERROR_CAP, MessageBoxIcon.Error);
                        btnList.PerformClick(FunctionType.Query);
                    }

                    break;
            }
        }


        #region XSavePerformer
        //private class XSavePerformer : IHIS.Framework.ISavePerformer
        //{
        //    private ADM102U parent = null;
        //    public XSavePerformer(ADM102U parent)
        //    {
        //        this.parent = parent;
        //    }
        //    public bool Execute(char callerID, RowDataItem item)
        //    {
        //        string cmdText = "";
        //        //Grid?먯꽌 ?섏뼱??Bind 蹂?섏뿉 f_user_id SET
        //        item.BindVarList.Add("f_user_id", UserInfo.UserID);


        //        switch (item.RowState)
        //        {
        //            case DataRowState.Added:
        //                cmdText
        //                    = "INSERT INTO ADM0300 "
        //                    + " (PGM_ID, PGM_NM, PGM_TP, SYS_ID, PROD_ID, SRVC_ID, PGM_ENT_GRAD, PGM_UPD_GRAD, "
        //                    + "  PGM_SCRT, PGM_DUP_YN, PGM_ACS_YN, END_YN, MANG_MEMB, ASM_NAME, CR_MEMB,CR_TIME) "
        //                    + "VALUES"
        //                    + " (:f_pgm_id, :f_pgm_nm, :f_pgm_tp, :f_sys_id, :f_prod_id, :f_srvc_id, :f_pgm_ent_grad, :f_pgm_upd_grad, "
        //                    + "  :f_pgm_scrt, :f_pgm_dup_yn, :f_pgm_acs_yn, :f_end_yn, :f_mang_memb, :f_asm_name, :f_user_id, SYSDATE)";
        //                break;
        //            case DataRowState.Modified:
        //                cmdText
        //                    = "UPDATE ADM0300"
        //                    + "   SET PGM_NM       = :f_pgm_nm"
        //                    + "      ,PGM_TP       = :f_pgm_tp"
        //                    + "      ,SYS_ID       = :f_sys_id"
        //                    + "      ,PROD_ID      = :f_prod_id"
        //                    + "      ,SRVC_ID      = :f_srvc_id"
        //                    + "      ,PGM_ENT_GRAD = :f_pgm_ent_grad"
        //                    + "      ,PGM_UPD_GRAD = :f_pgm_upd_grad"
        //                    + "      ,PGM_SCRT     = :f_pgm_scrt"
        //                    + "      ,PGM_DUP_YN   = :f_pgm_dup_yn"
        //                    + "      ,PGM_ACS_YN   = :f_pgm_acs_yn"
        //                    + "      ,END_YN       = :f_end_yn"
        //                    + "      ,MANG_MEMB    = :f_mang_memb"
        //                    + "      ,ASM_NAME     = :f_asm_name"
        //                    + "      ,UP_MEMB     = :f_user_id"
        //                    + "      ,UP_TIME     = SYSDATE"
        //                    + " WHERE PGM_ID      = :f_pgm_id";
        //                break;
        //            case DataRowState.Deleted:
        //                cmdText
        //                    = "DELETE ADM0300"
        //                    + " WHERE PGM_ID = :f_pgm_id";
        //                break;
        //        }

        //        return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //    }
        //}
        #endregion

    }

}

