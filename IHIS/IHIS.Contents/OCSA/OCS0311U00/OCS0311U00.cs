#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// XRT0101U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0311U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XMstGrid grdHangmogCode;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XMstGrid grdSetCode;
        private IHIS.Framework.SingleLayout layDupHangmogCode;
        private IHIS.Framework.SingleLayout layDupSetCode;
        private IHIS.Framework.XEditGrid grdSetHangmog;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDictComboBox cboSetPart;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.SingleLayout layDupSetHangmog;
        private IHIS.Framework.SingleLayout laySetHangmog;
        private IHIS.Framework.XFindWorker fwkDanui;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.SingleLayout layDanui;
        private IHIS.Framework.SingleLayout layHangmogCode;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private System.ComponentModel.IContainer components = null;

        public OCS0311U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.grdSetHangmog.ParamList = new List<string>(new String[] { "f_hosp_code", "f_set_part", "f_hangmog_code", "f_set_code" });
            this.grdHangmogCode.ParamList = new List<string>(new String[] { "f_hosp_code", "f_set_part" });
            this.grdSetCode.ParamList = new List<string>(new String[] { "f_hosp_code", "f_set_part", "f_hangmog_code" });

            this.layHangmogCode.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code2", "f_code" });
            this.layDupHangmogCode.ParamList = new List<string>(new String[] { "f_hosp_code", "f_set_part", "f_hangmog_code" });
            this.layDupSetCode.ParamList = new List<string>(new String[] { "f_hosp_code", "f_set_part", "f_hangmog_code", "f_set_code" });
            this.layDupSetHangmog.ParamList = new List<string>(new String[] { "f_hosp_code", "f_set_part", "f_hangmog_code", "f_set_code", "f_set_hangmog_code" });
            this.laySetHangmog.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code" });
            this.layDanui.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code" });
            //this.fwkDanui.ParamList
            cboSetPart.ParamList = new List<string>(new String[] { "f_curr_group_id" });

            //execute query
            grdSetHangmog.ExecuteQuery = LoadDataGrdSetHangmog;
            grdHangmogCode.ExecuteQuery = LoadDataGrdHangmogCode;
            grdSetCode.ExecuteQuery = LoadDataGrdSetCode;

            layHangmogCode.ExecuteQuery = LoadDataLayHangmogCode;
            layDupHangmogCode.ExecuteQuery = LoadDataLayDupHangmogCode;
            layDupSetCode.ExecuteQuery = LoadDataLayDupSetCode;
            layDupSetHangmog.ExecuteQuery = LoadDataLayDupSetHangmog;
            laySetHangmog.ExecuteQuery = LoadDataLaySetHangmog;
            layDanui.ExecuteQuery = LoadDataLayDanui;
            fwkDanui.ExecuteQuery = LoadDataFwkDanuiFirst;
            cboSetPart.ExecuteQuery = LoadDataCboSetPart;

            ApplyFont();
        }
        private void ApplyFont()
        {
            if (NetInfo.Language == LangMode.Vi || NetInfo.Language == LangMode.En)
            {
                ((System.ComponentModel.ISupportInitialize)(this.grdSetHangmog)).BeginInit();

                xGridHeader1.HeaderFont = Service.COMMON_FONT;

                ((System.ComponentModel.ISupportInitialize)(this.grdSetHangmog)).EndInit();
            }
        }

        /// <summary>
        /// get data for cboSetPart
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataCboSetPart(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00CboPartBySetTableArgs args = new OCS0311U00CboPartBySetTableArgs();
            args.CurrGroupId = bc["f_curr_group_id"] != null ? bc["f_curr_group_id"].VarValue : "";
            OCS0311U00CboPartBySetTableResult result = CloudService.Instance.Submit<OCS0311U00CboPartBySetTableResult, OCS0311U00CboPartBySetTableArgs>(args);
            if (result != null)
            {
                foreach (ComboListItemInfo item in result.CboPartBySetTable)
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
        /// get data for fwkDanui when initializing
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataFwkDanuiFirst(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ComboOrdDanuiArgs args = new ComboOrdDanuiArgs();
            ComboResult result = CacheService.Instance.Get<ComboOrdDanuiArgs, ComboResult>(args);
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

        /// <summary>
        /// get data for layDanui
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayDanui(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00LayDanuiArgs args = new OCS0311U00LayDanuiArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            OCS0311U00LayDanuiResult result = CloudService.Instance.Submit<OCS0311U00LayDanuiResult, OCS0311U00LayDanuiArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.LayDanui
                });
            }
            return res;
        }


        /// <summary>
        /// get data for laySethangmog
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLaySetHangmog(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00laySetHangmogArgs args = new OCS0311U00laySetHangmogArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            OCS0311U00laySetHangmogResult result = CloudService.Instance.Submit<OCS0311U00laySetHangmogResult, OCS0311U00laySetHangmogArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0311U00laySetHangmogListInfo item in result.LaySetHangmog)
                {
                    object[] objects = 
				    { 
					    item.HangmogName, 
					    item.OrdDanui, 
					    item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        }


        /// <summary>
        /// get data for layDupSetHangmog
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayDupSetHangmog(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00layDupSetHangmogArgs args = new OCS0311U00layDupSetHangmogArgs();
            args.SetPart = bc["f_set_part"] != null ? bc["f_set_part"].VarValue : "";
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            args.SetCode = bc["f_set_code"] != null ? bc["f_set_code"].VarValue : "";
            args.SetValueHangmogCode = bc["f_set_hangmog_code"] != null ? bc["f_set_hangmog_code"].VarValue : "";
            OCS0311U00layDupSetHangmogResult result = CloudService.Instance.Submit<OCS0311U00layDupSetHangmogResult, OCS0311U00layDupSetHangmogArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.LayDupSetHangmog
                });
            }
            return res;
        }


        /// <summary>
        /// get data for layDupSetCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayDupSetCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00layDupSetCodeArgs args = new OCS0311U00layDupSetCodeArgs();
            args.SetPart = bc["f_set_part"] != null ? bc["f_set_part"].VarValue : "";
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            args.SetCode = bc["f_set_code"] != null ? bc["f_set_code"].VarValue : "";
            OCS0311U00layDupSetCodeResult result = CloudService.Instance.Submit<OCS0311U00layDupSetCodeResult, OCS0311U00layDupSetCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.LayDupSetCode
                });
            }
            return res;
        }


        /// <summary>
        /// get data for layDupHangmogCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayDupHangmogCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00layDupHangmogCodeArgs args = new OCS0311U00layDupHangmogCodeArgs();
            args.SetPart = bc["f_set_part"] != null ? bc["f_set_part"].VarValue : "";
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            OCS0311U00layDupHangmogCodeResult result = CloudService.Instance.Submit<OCS0311U00layDupHangmogCodeResult, OCS0311U00layDupHangmogCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.LayDupHangmogCode
                });
            }
            return res;
        }


        /// <summary>
        /// get data for layHangmogCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayHangmogCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00LayHangmogCodeArgs args = new OCS0311U00LayHangmogCodeArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.Code2 = bc["f_code_2"] != null ? bc["f_code_2"].VarValue : "";
            OCS0311U00LayHangmogCodeResult result = CloudService.Instance.Submit<OCS0311U00LayHangmogCodeResult, OCS0311U00LayHangmogCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.HangmogCode
                });
            }
            return res;
        }


        /// <summary>
        /// get data for grdSetCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdSetCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00grdSetCodeListArgs args = new OCS0311U00grdSetCodeListArgs();
            args.SetPart = bc["f_set_part"] != null ? bc["f_set_part"].VarValue : "";
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            OCS0311U00grdSetCodeListResult result = CloudService.Instance.Submit<OCS0311U00grdSetCodeListResult, OCS0311U00grdSetCodeListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0311U00grdSetCodeListInfo item in result.GrdSetCode)
                {
                    object[] objects = 
				    { 
					    item.SetPart, 
					    item.HangmogCode, 
					    item.SetCode, 
					    item.Comments, 
					    item.SetCodeName, 
				    };
                    res.Add(objects);
                }
            }
            return res;
        }


        /// <summary>
        /// get data for grdHangmogCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdHangmogCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00grdHangmogCodeArgs args = new OCS0311U00grdHangmogCodeArgs();
            args.SetPart = bc["f_set_part"] != null ? bc["f_set_part"].VarValue : "";
            OCS0311U00grdHangmogCodeResult result = CloudService.Instance.Submit<OCS0311U00grdHangmogCodeResult, OCS0311U00grdHangmogCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0311U00grdHangmogCodeListInfo item in result.GrdHangmog)
                {
                    object[] objects = 
				    { 
					    item.SetPart, 
					    item.HangmogCode, 
					    item.HangmogName, 
				    };
                    res.Add(objects);
                }
            }
            return res;
        }


        /// <summary>
        /// get data for grdSetHangmog
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdSetHangmog(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00grdSetHangmogArgs args = new OCS0311U00grdSetHangmogArgs();
            args.SetPart = bc["f_set_part"] != null ? bc["f_set_part"].VarValue : "";
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            args.SetCode = bc["f_set_code"] != null ? bc["f_set_code"].VarValue : "";
            OCS0311U00grdSetHangmogResult result = CloudService.Instance.Submit<OCS0311U00grdSetHangmogResult, OCS0311U00grdSetHangmogArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0311U00grdSetHangmogListInfo item in result.GrdSetHangmog)
                {
                    object[] objects = 
				    { 
					    item.SetPart, 
					    item.HangCode, 
					    item.SetCode, 
					    item.SetHangmogCode, 
					    item.HangmogName, 
					    item.Suryang, 
					    item.Danui, 
					    item.DanuiName, 
					    item.BulyongYn, 
				    };
                    res.Add(objects);
                }
            }
            return res;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0311U00));
            this.grdHangmogCode = new IHIS.Framework.XMstGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdSetCode = new IHIS.Framework.XMstGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.cboSetPart = new IHIS.Framework.XDictComboBox();
            this.grdSetHangmog = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.fwkDanui = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.layDupHangmogCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.layDupSetCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layDupSetHangmog = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.laySetHangmog = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.layDanui = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.layHangmogCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmogCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSetCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSetHangmog)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdHangmogCode
            // 
            resources.ApplyResources(this.grdHangmogCode, "grdHangmogCode");
            this.grdHangmogCode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13});
            this.grdHangmogCode.ColPerLine = 2;
            this.grdHangmogCode.Cols = 3;
            this.grdHangmogCode.ExecuteQuery = null;
            this.grdHangmogCode.FixedCols = 1;
            this.grdHangmogCode.FixedRows = 1;
            this.grdHangmogCode.HeaderHeights.Add(26);
            this.grdHangmogCode.Name = "grdHangmogCode";
            this.grdHangmogCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdHangmogCode.ParamList")));
            this.grdHangmogCode.RowHeaderVisible = true;
            this.grdHangmogCode.Rows = 2;
            this.grdHangmogCode.Click += new System.EventHandler(this.grdHangmogCode_Click);
            this.grdHangmogCode.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grd_GridFindSelected);
            this.grdHangmogCode.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdHangmogCode_PreSaveLayout);
            this.grdHangmogCode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdHangmogCode_GridColumnChanged);
            this.grdHangmogCode.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdHangmogCode_GridFindClick);
            this.grdHangmogCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmogCode_QueryStarting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "set_part";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "hangmog_code";
            this.xEditGridCell12.CellWidth = 103;
            this.xEditGridCell12.Col = 1;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 100;
            this.xEditGridCell13.CellName = "hangmog_name";
            this.xEditGridCell13.CellWidth = 185;
            this.xEditGridCell13.Col = 2;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdSetCode
            // 
            resources.ApplyResources(this.grdSetCode, "grdSetCode");
            this.grdSetCode.CallerID = '2';
            this.grdSetCode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell15,
            this.xEditGridCell7});
            this.grdSetCode.ColPerLine = 3;
            this.grdSetCode.Cols = 4;
            this.grdSetCode.ExecuteQuery = null;
            this.grdSetCode.FixedCols = 1;
            this.grdSetCode.FixedRows = 1;
            this.grdSetCode.HeaderHeights.Add(26);
            this.grdSetCode.MasterLayout = this.grdHangmogCode;
            this.grdSetCode.Name = "grdSetCode";
            this.grdSetCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSetCode.ParamList")));
            this.grdSetCode.RowHeaderVisible = true;
            this.grdSetCode.Rows = 2;
            this.grdSetCode.Click += new System.EventHandler(this.grdSetCode_Click);
            this.grdSetCode.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdSetCode_PreSaveLayout);
            this.grdSetCode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdSetCode_GridColumnChanged);
            this.grdSetCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSetCode_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "set_part";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "hangmog_code";
            this.xEditGridCell4.CellWidth = 96;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "set_code";
            this.xEditGridCell6.CellWidth = 113;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 4000;
            this.xEditGridCell15.CellName = "comment";
            this.xEditGridCell15.CellWidth = 123;
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.DisplayMemoText = true;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.ShowReservedMemoButton = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 50;
            this.xEditGridCell7.CellName = "set_code_name";
            this.xEditGridCell7.CellWidth = 341;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // cboSetPart
            // 
            this.cboSetPart.AccessibleDescription = null;
            this.cboSetPart.AccessibleName = null;
            resources.ApplyResources(this.cboSetPart, "cboSetPart");
            this.cboSetPart.BackgroundImage = null;
            this.cboSetPart.ExecuteQuery = null;
            this.cboSetPart.Name = "cboSetPart";
            this.cboSetPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSetPart.ParamList")));
            this.cboSetPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSetPart.SelectedIndexChanged += new System.EventHandler(this.cboSetPart_SelectedIndexChanged);
            // 
            // grdSetHangmog
            // 
            this.grdSetHangmog.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdSetHangmog, "grdSetHangmog");
            this.grdSetHangmog.ApplyPaintEventToAllColumn = true;
            this.grdSetHangmog.CallerID = '3';
            this.grdSetHangmog.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19});
            this.grdSetHangmog.ColPerLine = 5;
            this.grdSetHangmog.Cols = 6;
            this.grdSetHangmog.ExecuteQuery = null;
            this.grdSetHangmog.FixedCols = 1;
            this.grdSetHangmog.FixedRows = 2;
            this.grdSetHangmog.HeaderHeights.Add(34);
            this.grdSetHangmog.HeaderHeights.Add(0);
            this.grdSetHangmog.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdSetHangmog.MasterLayout = this.grdSetCode;
            this.grdSetHangmog.Name = "grdSetHangmog";
            this.grdSetHangmog.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSetHangmog.ParamList")));
            this.grdSetHangmog.RowHeaderVisible = true;
            this.grdSetHangmog.Rows = 3;
            this.grdSetHangmog.ToolTipActive = true;
            this.grdSetHangmog.Click += new System.EventHandler(this.grdSetHangmog_Click);
            this.grdSetHangmog.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grd_GridFindSelected);
            this.grdSetHangmog.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdSetHangmog_PreSaveLayout);
            this.grdSetHangmog.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdSetHangmog_GridColumnChanged);
            this.grdSetHangmog.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdSetHangmog_GridFindClick);
            this.grdSetHangmog.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSetHangmog_GridCellPainting);
            this.grdSetHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSetHangmog_QueryStarting);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 30;
            this.xEditGridCell5.CellName = "set_part";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "hangmog_code";
            this.xEditGridCell8.CellWidth = 96;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 60;
            this.xEditGridCell9.CellName = "set_code";
            this.xEditGridCell9.CellWidth = 345;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "set_hangmog_code";
            this.xEditGridCell10.CellWidth = 102;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 100;
            this.xEditGridCell14.CellName = "set_hangmog_name";
            this.xEditGridCell14.CellWidth = 315;
            this.xEditGridCell14.Col = 2;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "suryang";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell16.CellWidth = 59;
            this.xEditGridCell16.Col = 3;
            this.xEditGridCell16.DecimalDigits = 2;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.InitValue = "1";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 6;
            this.xEditGridCell17.CellName = "danui";
            this.xEditGridCell17.CellWidth = 46;
            this.xEditGridCell17.Col = 4;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.FindWorker = this.fwkDanui;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.Row = 1;
            // 
            // fwkDanui
            // 
            this.fwkDanui.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkDanui.ExecuteQuery = null;
            this.fwkDanui.FormText = global::IHIS.OCSA.Properties.Resources.FWKDANUI_FORMTEXT;
            this.fwkDanui.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkDanui.ParamList")));
            this.fwkDanui.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.ColWidth = 81;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 139;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "danui_name";
            this.xEditGridCell18.CellWidth = 73;
            this.xEditGridCell18.Col = 5;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.Row = 1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "bulyong_yn";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 46;
            // 
            // layDupHangmogCode
            // 
            this.layDupHangmogCode.ExecuteQuery = null;
            this.layDupHangmogCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.layDupHangmogCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupHangmogCode.ParamList")));
            this.layDupHangmogCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupHangmogCode_QueryStarting);
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "dup_yn";
            // 
            // layDupSetCode
            // 
            this.layDupSetCode.ExecuteQuery = null;
            this.layDupSetCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDupSetCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupSetCode.ParamList")));
            this.layDupSetCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupSetCode_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.cboSetPart);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdSetHangmog);
            this.xPanel3.Controls.Add(this.splitter2);
            this.xPanel3.Controls.Add(this.grdSetCode);
            this.xPanel3.Controls.Add(this.splitter1);
            this.xPanel3.Controls.Add(this.grdHangmogCode);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // splitter2
            // 
            this.splitter2.AccessibleDescription = null;
            this.splitter2.AccessibleName = null;
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.BackgroundImage = null;
            this.splitter2.Font = null;
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
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
            // layDupSetHangmog
            // 
            this.layDupSetHangmog.ExecuteQuery = null;
            this.layDupSetHangmog.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4});
            this.layDupSetHangmog.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupSetHangmog.ParamList")));
            this.layDupSetHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupSetHangmog_QueryStarting);
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "dup_yn";
            // 
            // laySetHangmog
            // 
            this.laySetHangmog.ExecuteQuery = null;
            this.laySetHangmog.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5,
            this.singleLayoutItem7,
            this.singleLayoutItem8});
            this.laySetHangmog.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySetHangmog.ParamList")));
            this.laySetHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySetHangmog_QueryStarting);
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "set_hangmog_name";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "ord_danui";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "ord_danui_name";
            // 
            // layDanui
            // 
            this.layDanui.ExecuteQuery = null;
            this.layDanui.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem6});
            this.layDanui.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDanui.ParamList")));
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "danui_name";
            // 
            // layHangmogCode
            // 
            this.layHangmogCode.ExecuteQuery = null;
            this.layHangmogCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layHangmogCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layHangmogCode.ParamList")));
            this.layHangmogCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHangmogCode_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "hangmog_name";
            // 
            // OCS0311U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0311U00";
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmogCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSetCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSetHangmog)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            // TODO:  XRT0101U00.OnLoad 구현을 추가합니다.
            base.OnLoad(e);

            //this.grdHangmogCode.SavePerformer = new XSavePerformer(this);
            //this.grdSetCode.SavePerformer = this.grdHangmogCode.SavePerformer;
            //this.grdSetHangmog.SavePerformer = this.grdHangmogCode.SavePerformer;

            this.grdSetCode.SetRelationKey("set_part", "set_part");
            this.grdSetCode.SetRelationKey("hangmog_code", "hangmog_code");
            this.grdSetCode.SetRelationTable("OCS0312");

            this.grdSetHangmog.SetRelationKey("set_part", "set_part");
            this.grdSetHangmog.SetRelationKey("hangmog_code", "hangmog_code");
            this.grdSetHangmog.SetRelationKey("set_code", "set_code");
            this.grdSetHangmog.SetRelationTable("OCS0313");

            // 検査PARTセット
            this.setCboPartBySetTable();

            this.cboSetPart.SelectedIndex = 0;

            if (!this.grdHangmogCode.QueryLayout(false))
                XMessageBox.Show(Service.ErrFullMsg);
        }
        #endregion

        #region [setCboPartBySetTable クライアントＩＰによる検査PARTセット]
        private void setCboPartBySetTable()
        {
            this.cboSetPart.ResetData();

            if (EnvironInfo.CurrGroupID == "OCS")
            {
                // 基準情報（PFE0102）から取得、システムによる検査パート設定
                //                this.cboSetPart.UserSQL = @"SELECT CODE, CODE_NAME
                //                                          FROM OCS0132
                //                                         WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                //                                           AND CODE_TYPE = 'SET_PART'
                //                                         ORDER BY GROUP_KEY";

                //tungtx
                this.cboSetPart.SetBindVarValue("f_curr_group_id", "OCS");
            }
            else if (EnvironInfo.CurrGroupID == "OPR")
            {

                // 基準情報（PFE0102）から取得、システムによる検査パート設定
                //                this.cboSetPart.UserSQL = @"SELECT CODE, CODE_NAME
                //                                          FROM OCS0132
                //                                         WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                //                                           AND CODE_TYPE = 'SET_PART'
                //                                           AND GROUP_KEY = 'OP'";

                this.cboSetPart.SetBindVarValue("f_curr_group_id", "OPR");
            }
            else
            {

                // 基準情報（PFE0102）から取得、システムによる検査パート設定
                //                this.cboSetPart.UserSQL = @"SELECT CODE, CODE_NAME
                //                                          FROM OCS0132
                //                                         WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                //                                           AND CODE_TYPE = 'SET_PART'
                //                                           AND GROUP_KEY = '" + EnvironInfo.CurrGroupID + @"'";
                this.cboSetPart.SetBindVarValue("f_curr_group_id", EnvironInfo.CurrGroupID);
            }

            this.cboSetPart.SetDictDDLB();

            this.grdHangmogCode.QueryLayout(false);
        }
        #endregion

        #region 항목 테이블 중복체크(입력시 hangmog_code)
        private void grdHangmogCode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            SetMsg("");
            if (e.ColName != "hangmog_code")
                return;

            if (e.ChangeValue.ToString() == "")
            {
                e.DataRow["hangmog_name"] = "";
                return;
            }


            DataRowState rowState = this.grdHangmogCode.LayoutTable.Rows[this.grdHangmogCode.CurrentRowNumber].RowState;
            // 입력 버튼이 클릭 되었을 때만 체크
            if (rowState == DataRowState.Added)
            {
                // 만약 마스터테이블에 존재한다면, 'Y'를 그렇지않으면, 'N'을 리턴
                this.layDupHangmogCode.SetBindVarValue("f_hangmog_code", e.ChangeValue.ToString());
                this.layDupHangmogCode.QueryLayout();
                if (this.layDupHangmogCode.GetItemValue("dup_yn").ToString() == "Y")
                {
                    string msg = Resources.MSG001_MSG;
                    XMessageBox.Show(this.grdHangmogCode.GetItemString(this.grdHangmogCode.CurrentRowNumber, e.ColName) +
                        msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                    e.Cancel = true;
                    return;
                }
            }

            layHangmogCode.SetBindVarValue("f_code", e.ChangeValue.ToString());
            layHangmogCode.QueryLayout();

            if (layHangmogCode.GetItemValue("hangmog_name").ToString().Length == 0)
            {
                SetMsg(Resources.MSG002_MSG, MsgType.Error);
                e.Cancel = true;
                CommonItemCollection openParams = new CommonItemCollection();
                //값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
                openParams.Add("hangmog_code", grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber, e.ColName));
                // Multi 선택여부 (default : MultiSelect )
                openParams.Add("multiSelect", true);

                //항목조회화면 Open
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseSizable, openParams);
            }
            grdHangmogCode.SetItemValue(e.RowNumber, "hangmog_name", layHangmogCode.GetItemValue("hangmog_name").ToString());

        }
        #endregion

        #region 세트 테이블 중복체크(입력시 set_code)
        private void grdSetCode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            if (e.ColName != "set_code")
                return;

            DataRowState rowState = this.grdSetCode.LayoutTable.Rows[this.grdSetCode.CurrentRowNumber].RowState;
            //입력 버튼이 클릭 되었을 때만 체크
            if (rowState == DataRowState.Added)
            {
                layDupSetCode.SetBindVarValue("f_set_code", e.ChangeValue.ToString());
                this.layDupSetCode.QueryLayout();
                if (this.layDupSetCode.GetItemValue("dup_yn").ToString() == "Y")
                {
                    string msg = (Resources.MSG001_MSG);
                    XMessageBox.Show(this.grdSetCode.GetItemString(this.grdSetCode.CurrentRowNumber, e.ColName) +
                        msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                    e.Cancel = true;
                }
            }

        }
        #endregion

        #region 세트항목 테이블 중복체크(입력시 set_hangmog_code)
        private void grdSetHangmog_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            SetMsg("");

            DataRowState rowState = this.grdSetHangmog.LayoutTable.Rows[this.grdSetHangmog.CurrentRowNumber].RowState;
            //입력 버튼이 클릭 되었을 때만 체크
            if (rowState == DataRowState.Added)
            {
                // 입력된 셀이 코드 컬럼이면,
                if (e.ColName == "set_hangmog_code")
                {
                    layDupSetHangmog.SetBindVarValue("f_set_hangmog_code", e.ChangeValue.ToString());

                    this.layDupSetHangmog.QueryLayout();
                    if (this.layDupSetHangmog.GetItemValue("dup_yn").ToString() == "Y")
                    {
                        string msg = (Resources.MSG001_MSG);
                        XMessageBox.Show(this.grdSetHangmog.GetItemString(this.grdSetHangmog.CurrentRowNumber, e.ColName) +
                            msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                        e.Cancel = true;
                    }
                }
            }

            if (e.ColName == "set_hangmog_code")
            {
                if (this.grdSetHangmog.GetItemString(e.RowNumber, e.ColName).Length > 0)
                {
                    this.laySetHangmog.SetBindVarValue("f_code", e.ChangeValue.ToString());
                    this.laySetHangmog.QueryLayout();

                    if (this.laySetHangmog.GetItemValue("set_hangmog_name").ToString().Length == 0)
                    {
                        SetMsg(Resources.MSG002_MSG, MsgType.Error);
                        e.Cancel = true;
                        CommonItemCollection openParams = new CommonItemCollection();
                        //값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
                        openParams.Add("hangmog_code", this.grdSetHangmog.GetItemString(this.grdSetHangmog.CurrentRowNumber, e.ColName));
                        // Multi 선택여부 (default : MultiSelect )
                        openParams.Add("multiSelect", true);

                        //항목조회화면 Open
                        XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseSizable, openParams);
                    }
                    this.grdSetHangmog.SetItemValue(e.RowNumber, "set_hangmog_name", this.laySetHangmog.GetItemValue("set_hangmog_name").ToString());
                    this.grdSetHangmog.SetItemValue(e.RowNumber, "danui", this.laySetHangmog.GetItemValue("ord_danui").ToString());
                    this.grdSetHangmog.SetItemValue(e.RowNumber, "danui_name", this.laySetHangmog.GetItemValue("ord_danui_name").ToString());

                }
                else
                {
                    this.grdSetHangmog.SetItemValue(e.RowNumber, "set_hangmog_name", DBNull.Value);
                    this.grdSetHangmog.SetItemValue(e.RowNumber, "suryang", DBNull.Value);
                    this.grdSetHangmog.SetItemValue(e.RowNumber, "danui", DBNull.Value);
                    this.grdSetHangmog.SetItemValue(e.RowNumber, "danui_name", DBNull.Value);
                }
            }

            if (e.ColName == "danui")
            {
                layDanui.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layDanui.SetBindVarValue("f_code", e.ChangeValue.ToString());
                layDanui.QueryLayout();
                if (layDanui.GetItemValue("danui_name").ToString().Length == 0)
                {
                    SetMsg(Resources.MSG002_MSG, MsgType.Error);
                    e.Cancel = true;
                }
                grdSetHangmog.SetItemValue(e.RowNumber, "danui_name", layDanui.GetItemValue("danui_name").ToString());
            }
        }
        #endregion

        #region 버튼리스트 클릭 후 이벤트
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //초기화가 된 후 포커스 마스터 그리드로..
                case FunctionType.Reset:
                    this.CurrMQLayout = this.grdHangmogCode;
                    break;
                case FunctionType.Insert:
                    if (this.CurrMSLayout == this.grdSetCode)
                    {
                        int partNum = 0, maxValue = 0;

                        for (int i = 0; i <= grdSetCode.RowCount; i++)
                        {
                            if (grdSetCode.GetItemString(i, "set_code") != "")
                            {
                                string seq = grdSetCode.GetItemString(i, "set_code").Replace(grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber, "set_part"), "");
                                partNum = int.Parse(seq);
                                if (maxValue < partNum)
                                    maxValue = partNum;
                            }
                        }
                        maxValue = maxValue + 1;
                        //string set_code = grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber,"set_part") + maxValue.ToString().PadLeft(3,'0');
                        string set_code = this.cboSetPart.GetDataValue().ToString().Trim() + maxValue.ToString().PadLeft(3, '0');

                        grdSetCode.SetItemValue(grdSetCode.CurrentRowNumber, "set_code", set_code);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Find 정의 (GridFindClick)
        private void grdHangmogCode_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

            string hangmog_code = grd.GetItemString(e.RowNumber, "hangmog_code"); // 항목코드

            switch (e.ColName)
            {
                case "hangmog_code": // 항목코드
                    e.Cancel = true;  // Find 장 안띄움

                    CommonItemCollection openParams = new CommonItemCollection();
                    //값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
                    openParams.Add("hangmog_code", ((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).GetDataValue());
                    // Multi 선택여부 (default : MultiSelect )
                    openParams.Add("multiSelect", true);
                    //항목조회화면 Open
                    XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseSizable, openParams);

                    break;
                default:
                    break;
            }

        }

        private void grdSetHangmog_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

            string hangmog_code = grd.GetItemString(e.RowNumber, "set_hangmog_code"); // 항목코드

            switch (e.ColName)
            {
                case "set_hangmog_code": // 항목코드
                    e.Cancel = true;  // Find 장 안띄움

                    CommonItemCollection openParams = new CommonItemCollection();
                    //값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
                    openParams.Add("hangmog_code", ((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).GetDataValue());
                    // Multi 선택여부 (default : MultiSelect )
                    openParams.Add("multiSelect", true);
                    //항목조회화면 Open
                    XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseSizable, openParams);

                    break;

                case "danui":

                    //string hangmogCode = this.grdSetHangmog.GetItemString(this.grdSetHangmog.CurrentRowNumber, "set_hangmog_code");

                    fwkDanui.AutoQuery = true;
                    fwkDanui.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
                    //fwkDanui.InputSQL =
                    //    " SELECT B.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI) , B.SEQ "
                    //    + " FROM OCS0108 B "
                    //    + "    , OCS0103 A "
                    //    + "WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() "
                    //    + "  AND A.HANGMOG_CODE = '" + hangmogCode + "' "
                    //    + "  AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE"
                    //    + "  AND B.HOSP_CODE = A.HOSP_CODE"
                    //    + "  AND B.HANGMOG_CODE = A.HANGMOG_CODE"
                    //    + "  AND B.HANGMOG_START_DATE = A.START_DATE"
                    //    + "  ORDER BY 3, 1, 2 ";

                    fwkDanui.ExecuteQuery = LoadDataFwkDanuiSecond;

                    fwkDanui.ColInfos.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.FWKDANUI_ORD_DANUI_TEXT, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.FWKDANUI_ORD_DANUI_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.Yes)});
                    fwkDanui.ColAppearance.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.FWKDANUI_ORD_DANUI_TEXT, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.FWKDANUI_ORD_DANUI_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.Yes)});

                    break;
                default:
                    break;
            }
        }

        private List<object[]> LoadDataFwkDanuiSecond(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0311U00grdSetHangmogGridFindArgs args = new OCS0311U00grdSetHangmogGridFindArgs();
            args.HangmogCode = this.grdSetHangmog.GetItemString(this.grdSetHangmog.CurrentRowNumber, "set_hangmog_code");
            OCS0311U00grdSetHangmogGridFindResult result = CloudService.Instance.Submit<OCS0311U00grdSetHangmogGridFindResult, OCS0311U00grdSetHangmogGridFindArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0311U00grdSetHangmogGridFindListInfo item in result.GrdSetHangmog)
                {
                    object[] objects = 
				{ 
					item.OrdDanui, 
					item.CodeName, 
					item.Seq
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion



        #region Find 데이타 선택시 Value 세팅.. (GridFindSelected)
        private void grd_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            grd.AcceptData();
        }
        #endregion


        #region 타Screen에서 Open (Command)
        public override object Command(string command, CommonItemCollection commandParam)
        {
            // Command Event Parameter : commandParam을 기억해둔다.(Command Event에서 처리못하는 케이스에서 사용됨(ScreenOpen(Response)후 바로 아래에서 로직 기술해야되는경우)
            //this.mCommand = command; this.mCommandParam = commandParam; 

            switch (command.Trim())
            {
                case "OCS0103Q00": //항목검색

                    #region
                    if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null &&
                        ((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
                    {
                        if (this.CurrMSLayout == grdHangmogCode)
                        {
                            int set_row = -1;

                            if (this.grdHangmogCode.CurrentRowNumber >= 0)
                                set_row = this.grdHangmogCode.CurrentRowNumber;

                            int cnt = 0;

                            foreach (DataRow row in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
                            {
                                string hangmog_code = row["hangmog_code"].ToString();
                                string hangmog_name = row["hangmog_name"].ToString();

                                if (cnt != 0)
                                {
                                    set_row = grdHangmogCode.InsertRow();
                                }

                                this.grdHangmogCode.SetFocusToItem(set_row, "hangmog_code");
                                this.grdHangmogCode.SetEditorValue(hangmog_code);

                                cnt++;
                            }

                            grdHangmogCode.AcceptData();
                        }
                        else
                        {
                            int set_row = -1;

                            if (this.grdSetHangmog.CurrentRowNumber >= 0)
                                set_row = this.grdSetHangmog.CurrentRowNumber;

                            int cnt = 0;

                            foreach (DataRow row in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
                            {
                                string hangmog_code = row["hangmog_code"].ToString();
                                string hangmog_name = row["hangmog_name"].ToString();

                                if (cnt != 0)
                                {
                                    set_row = grdSetHangmog.InsertRow();
                                }

                                this.grdSetHangmog.SetFocusToItem(set_row, "set_hangmog_code");
                                this.grdSetHangmog.SetEditorValue(hangmog_code);

                                cnt++;
                            }

                            grdSetHangmog.AcceptData();
                        }
                    }

                    break;
                    #endregion

                default:
                    break;
            }

            return base.Command(command, commandParam);
        }
        #endregion



        #region 그리드 클릭 이벤트 처리
        private void grdHangmogCode_Click(object sender, System.EventArgs e)
        {
            if (grdHangmogCode.RowCount == 0)
                btnList.PerformClick(FunctionType.Insert);
        }

        private void grdSetCode_Click(object sender, System.EventArgs e)
        {
            if (grdHangmogCode.RowCount > 0)
                if (grdSetCode.RowCount == 0) btnList.PerformClick(FunctionType.Insert);
        }

        private void grdSetHangmog_Click(object sender, System.EventArgs e)
        {
            if (grdSetCode.RowCount > 0)
                if (grdSetHangmog.RowCount == 0) btnList.PerformClick(FunctionType.Insert);
        }
        #endregion

        #region 버튼리스트 클릭
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    if (this.CurrMSLayout == grdSetCode)
                    {
                        if (grdHangmogCode.RowCount == 0) e.IsBaseCall = false;
                    }
                    else if (this.CurrMQLayout == grdSetHangmog)
                    {
                        if (grdSetCode.RowCount == 0) e.IsBaseCall = false;
                    }
                    break;
                case FunctionType.Query:
                    grdHangmogCode.QueryLayout(false);
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    try
                    {
                        //Service.BeginTransaction();

                        //if (!this.grdHangmogCode.SaveLayout())
                        //    throw new Exception();

                        //if (!this.grdSetCode.SaveLayout())
                        //    throw new Exception();

                        //if (!this.grdSetHangmog.SaveLayout())
                        //    throw new Exception();

                        //Service.CommitTransaction();

                        //XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Information);

                        List<OCS0311U00grdHangmogCodeListInfo> grdHangmogCodeList = GetListFromGrdHangmogCode();
                        List<OCS0311U00grdSetCodeListInfo> grdSetCodeList = GetListFromGrdSetCode();
                        List<OCS0311U00grdSetHangmogListInfo> grdSetHangmogList = GetListFromGrdSetHangmog();

                        //2015/09/17 updated due to MED-4176
                        if (grdHangmogCodeList.Count == 0 && grdSetCodeList.Count == 0 && grdSetHangmogList.Count == 0)
                        {
                            XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Information);
                            grdHangmogCode.QueryLayout(false);
                        }

                        if (grdSetCodeList.Count > 0)
                        {
                            foreach (OCS0311U00grdSetCodeListInfo setCodeListInfo in grdSetCodeList)
                            {
                                if (setCodeListInfo.HangmogCode != null)
                                {
                                    if (TypeCheck.IsNull(setCodeListInfo.SetCode) || TypeCheck.IsNull(setCodeListInfo.SetCodeName))
                                    {
                                        XMessageBox.Show(Resources.MSG007, Resources.MSG004_CAP, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }

                        //MED-4176
                        //if (grdSetHangmogList.Count == 0)
                        //{
                        //    XMessageBox.Show(Resources.MSG006, Resources.MSG004_CAP, MessageBoxIcon.Error);
                        //    return;
                        //}

                        OCS0311U00SaveLayoutArgs args = new OCS0311U00SaveLayoutArgs(UserInfo.UserID, grdHangmogCodeList, grdSetCodeList, grdSetHangmogList);
                        UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS0311U00SaveLayoutArgs>(args);

                        if (result.ExecutionStatus == ExecutionStatus.Success && result.Result == true)
                        {
                            XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Information);
                            grdHangmogCode.QueryLayout(false);
                        }
                        else
                        {
                            XMessageBox.Show(Resources.MSG004_MSG + Service.ErrFullMsg, Resources.MSG004_CAP, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        XMessageBox.Show(Resources.MSG004_MSG + Service.ErrFullMsg, Resources.MSG004_CAP, MessageBoxIcon.Error);
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// save all changed items in all gridview to db
        /// </summary>
        /// <returns></returns>
        private bool SaveAllGrd()
        {
            List<OCS0311U00grdHangmogCodeListInfo> grdHangmogCodeList = GetListFromGrdHangmogCode();
            List<OCS0311U00grdSetCodeListInfo> grdSetCodeList = GetListFromGrdSetCode();
            List<OCS0311U00grdSetHangmogListInfo> grdSetHangmogList = GetListFromGrdSetHangmog();

            OCS0311U00SaveLayoutArgs args = new OCS0311U00SaveLayoutArgs(UserInfo.UserID, grdHangmogCodeList, grdSetCodeList, grdSetHangmogList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS0311U00SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

        private List<OCS0311U00grdSetHangmogListInfo> GetListFromGrdSetHangmog()
        {

            List<OCS0311U00grdSetHangmogListInfo> dataList = new List<OCS0311U00grdSetHangmogListInfo>();
            for (int i = 0; i < grdSetHangmog.RowCount; i++)
            {
                //pre-save
                if (grdSetHangmog.GetRowState(i) == DataRowState.Added)
                    grdSetHangmog.SetItemValue(i, "set_part", cboSetPart.GetDataValue());

                if (grdSetHangmog.GetRowState(i) == DataRowState.Unchanged || String.IsNullOrEmpty(grdSetHangmog.GetItemString(i, "set_hangmog_code")))
                {
                    continue;
                }

                // Skip empty input
                //if (TypeCheck.IsNull(grdSetHangmog.GetItemString(i, "set_part"))
                //    || TypeCheck.IsNull(this.grdHangmogCode.GetItemString(i, "hangmog_code"))
                //    || TypeCheck.IsNull(this.grdSetCode.GetItemString(i, "set_code")))
                if (TypeCheck.IsNull(grdSetHangmog.GetItemString(i, "set_part"))                   
                    || TypeCheck.IsNull(this.grdSetCode.GetItemString(i, "set_code")))
                {
                    continue;
                }

                //get items from grdSetHangmog
                OCS0311U00grdSetHangmogListInfo info = new OCS0311U00grdSetHangmogListInfo();
                info.SetPart = grdSetHangmog.GetItemString(i, "set_part");
                info.HangCode = this.grdSetCode.GetItemString(this.grdHangmogCode.CurrentRowNumber, "hangmog_code");
                info.SetCode = this.grdSetCode.GetItemString(this.grdSetCode.CurrentRowNumber, "set_code");
                info.SetHangmogCode = grdSetHangmog.GetItemString(i, "set_hangmog_code");
                info.HangmogName = grdSetHangmog.GetItemString(i, "set_hangmog_name");
                info.Suryang = grdSetHangmog.GetItemString(i, "suryang");
                info.Danui = grdSetHangmog.GetItemString(i, "danui");
                info.DanuiName = grdSetHangmog.GetItemString(i, "danui_name");
                info.BulyongYn = grdSetHangmog.GetItemString(i, "bulyong_yn");
                info.RowState = grdSetHangmog.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdSetHangmog.DeletedRowTable != null && grdSetHangmog.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdSetHangmog.DeletedRowTable.Rows)
                {
                    OCS0311U00grdSetHangmogListInfo info = new OCS0311U00grdSetHangmogListInfo();
                    info.SetPart = row["set_part"].ToString();
                    info.HangCode = this.grdSetCode.GetItemString(this.grdSetCode.CurrentRowNumber, "hangmog_code");
                    info.SetCode = this.grdSetCode.GetItemString(this.grdSetCode.CurrentRowNumber, "set_code");
                    info.SetHangmogCode = row["set_hangmog_code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
        }

        private List<OCS0311U00grdSetCodeListInfo> GetListFromGrdSetCode()
        {
            List<OCS0311U00grdSetCodeListInfo> dataList = new List<OCS0311U00grdSetCodeListInfo>();
            for (int i = 0; i < grdSetCode.RowCount; i++)
            {
                //pre-save
                if (grdSetCode.GetRowState(i) == DataRowState.Added)
                    grdSetCode.SetItemValue(i, "set_part", cboSetPart.GetDataValue());

                if (grdSetCode.GetRowState(i) == DataRowState.Unchanged || String.IsNullOrEmpty(grdSetCode.GetItemString(i, "set_code")))
                {
                    continue;
                }

                //get items from grdSetCode
                OCS0311U00grdSetCodeListInfo info = new OCS0311U00grdSetCodeListInfo();
                info.SetPart = grdSetCode.GetItemString(i, "set_part");
                info.HangmogCode = grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber, "hangmog_code");
                info.SetCode = this.grdSetCode.GetItemString(i, "set_code");
                info.Comments = grdSetCode.GetItemString(i, "comment");
                info.SetCodeName = grdSetCode.GetItemString(i, "set_code_name");
                info.RowState = grdSetCode.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdSetCode.DeletedRowTable != null && grdSetCode.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdSetCode.DeletedRowTable.Rows)
                {
                    OCS0311U00grdSetCodeListInfo info = new OCS0311U00grdSetCodeListInfo();
                    info.SetPart = row["set_part"].ToString();
                    info.HangmogCode = grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber, "hangmog_code");
                    info.SetCode = row["set_code"].ToString();
                    info.SetCodeName = row["set_code_name"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
        }

        private List<OCS0311U00grdHangmogCodeListInfo> GetListFromGrdHangmogCode()
        {
            List<OCS0311U00grdHangmogCodeListInfo> dataList = new List<OCS0311U00grdHangmogCodeListInfo>();
            for (int i = 0; i < grdHangmogCode.RowCount; i++)
            {
                //pre-save
                //Enum rowState = grdHangmogCode.GetRowState(i);
                if (grdHangmogCode.GetRowState(i) == DataRowState.Added)
                    grdHangmogCode.SetItemValue(i, "set_part", cboSetPart.GetDataValue());

                if (grdHangmogCode.GetRowState(i) == DataRowState.Unchanged || String.IsNullOrEmpty(grdHangmogCode.GetItemString(i, "hangmog_code")))
                {
                    continue;
                }

                //get items from grdSetCode
                OCS0311U00grdHangmogCodeListInfo info = new OCS0311U00grdHangmogCodeListInfo();
                info.SetPart = grdHangmogCode.GetItemString(i, "set_part");
                info.HangmogCode = grdHangmogCode.GetItemString(i, "hangmog_code");
                info.HangmogName = grdHangmogCode.GetItemString(i, "hangmog_name");
                info.RowState = grdHangmogCode.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdHangmogCode.DeletedRowTable != null && grdHangmogCode.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdHangmogCode.DeletedRowTable.Rows)
                {
                    OCS0311U00grdHangmogCodeListInfo info = new OCS0311U00grdHangmogCodeListInfo();
                    info.SetPart = row["set_part"].ToString();
                    info.HangmogCode = row["hangmog_code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
        }

        #endregion

        #region 조회조건 변경시 재조회
        private void cboSetPart_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.grdHangmogCode.QueryLayout(false);
        }
        #endregion

        #region 불용 색 처리
        private void grdSetHangmog_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.DataRow["bulyong_yn"].ToString() == "Y")
            {
                e.DrawMiddleLine = true;
                e.MiddleLineColor = Color.Red;
            }
        }
        #endregion

        private void grdHangmogCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdHangmogCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdHangmogCode.SetBindVarValue("f_set_part", this.cboSetPart.GetDataValue());
        }

        private void layDupHangmogCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupHangmogCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupHangmogCode.SetBindVarValue("f_set_part", this.cboSetPart.GetDataValue());
        }

        private void layHangmogCode_QueryStarting(object sender, CancelEventArgs e)
        {
            layHangmogCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layHangmogCode.SetBindVarValue("f_code2", cboSetPart.GetDataValue());
        }

        private void layDupSetCode_QueryStarting(object sender, CancelEventArgs e)
        {
            layDupSetCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layDupSetCode.SetBindVarValue("f_set_part", this.cboSetPart.GetDataValue());
            layDupSetCode.SetBindVarValue("f_hangmog_code", grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber, "hangmog_code"));
        }

        private void layDupSetHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            layDupSetHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layDupSetHangmog.SetBindVarValue("f_set_part", this.cboSetPart.GetDataValue());
            layDupSetHangmog.SetBindVarValue("f_hangmog_code", grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber, "hangmog_code"));
            layDupSetHangmog.SetBindVarValue("f_set_code", grdSetCode.GetItemString(grdSetCode.CurrentRowNumber, "set_code"));
        }

        private void laySetHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            laySetHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdSetCode_QueryStarting(object sender, CancelEventArgs e)
        {
            grdSetCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdSetCode.SetBindVarValue("f_set_part", grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber, "set_part"));
            grdSetCode.SetBindVarValue("f_hangmog_code", grdHangmogCode.GetItemString(grdHangmogCode.CurrentRowNumber, "hangmog_code"));
        }
        #region 저장전 인변수 셋팅
        private void grdHangmogCode_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if (e.RowState == DataRowState.Added)
                grdHangmogCode.SetItemValue(e.RowNumber, "set_part", cboSetPart.GetDataValue());
        }

        private void grdSetCode_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if (e.RowState == DataRowState.Added)
                grdSetCode.SetItemValue(e.RowNumber, "set_part", cboSetPart.GetDataValue());
        }

        private void grdSetHangmog_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if (e.RowState == DataRowState.Added)
                grdSetHangmog.SetItemValue(e.RowNumber, "set_part", cboSetPart.GetDataValue());
        }

        #endregion

        #region XSavePerformer

        //        private class XSavePerformer : ISavePerformer
        //        {
        //            OCS0311U00 parent;

        //            public XSavePerformer(OCS0311U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char CallerID, RowDataItem item)
        //            {
        //                string cmdText = "";

        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //                switch (CallerID)
        //                { 
        //                    case '1':
        //                        switch (item.RowState)
        //                        { 
        //                            case DataRowState.Added:
        //                                cmdText = @"INSERT INTO OCS0311
        //                                                 ( SYS_DATE,            SYS_ID,           UPD_DATE,           UPD_ID,
        //                                                   HOSP_CODE,           SET_PART,         HANGMOG_CODE         ) 
        //                                            VALUES 
        //                                                 ( SYSDATE,             :q_user_id,       SYSDATE,            :q_user_id,
        //                                                   :f_hosp_code,        :f_set_part,      :f_hangmog_code      )";
        //                                break;

        //                            case DataRowState.Modified:

        //                                break;

        //                            case DataRowState.Deleted:
        //                                cmdText = @"DELETE OCS0311
        //                                             WHERE HOSP_CODE    = :f_hosp_code
        //                                               AND SET_PART     = :f_set_part
        //                                               AND HANGMOG_CODE = :f_hangmog_code";
        //                                break;
        //                        }
        //                        break;


        //                    case '2':
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:
        //                                cmdText = @"INSERT INTO OCS0312  
        //                                                 ( SYS_DATE,        SYS_ID,         UPD_DATE,        UPD_ID,
        //                                                   HOSP_CODE,       SET_PART,       HANGMOG_CODE,    SET_CODE,
        //                                                   SET_CODE_NAME,   COMMENTS       ) 
        //                                            VALUES 
        //                                                 ( SYSDATE,         :q_user_id,     SYSDATE,         :q_user_id,
        //                                                   :f_hosp_code,    :f_set_part,    :f_hangmog_code, :f_set_code,
        //                                                   :f_set_code_name,:f_comments    )";
        //                                break;

        //                            case DataRowState.Modified:
        //                                cmdText = @"UPDATE OCS0312
        //                                               SET UPD_ID         = :q_user_id
        //                                                 , UPD_DATE       = SYSDATE
        //                                                 , SET_CODE_NAME  = :f_set_code_name
        //                                                 , COMMENTS       = :f_comments
        //                                             WHERE HOSP_CODE      = :f_hosp_code 
        //                                               AND SET_PART       = :f_set_part
        //                                               AND HANGMOG_CODE   = :f_hangmog_code
        //                                               AND SET_CODE       = :f_set_code";
        //                                break;

        //                            case DataRowState.Deleted:
        //                                cmdText = @"DELETE OCS0312
        //                                             WHERE HOSP_CODE      = :f_hosp_code 
        //                                               AND SET_PART          = :f_set_part
        //                                               AND HANGMOG_CODE      = :f_hangmog_code
        //                                               AND SET_CODE          = :f_set_code";
        //                                break;
        //                        }
        //                        break;


        //                    case '3':
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:
        //                                cmdText = @"INSERT INTO OCS0313 
        //                                                 ( SYS_DATE,            SYS_ID,            UPD_DATE,           UPD_ID,
        //                                                   HOSP_CODE,           SET_PART,          HANGMOG_CODE,       SET_CODE,
        //                                                   SET_HANGMOG_CODE,    SURYANG,           DANUI         ) 
        //                                            VALUES 
        //                                                 ( SYSDATE,             :q_user_id,        SYSDATE,            :q_user_id,
        //                                                  :f_hosp_code,         :f_set_part,       :f_hangmog_code,    :f_set_code,
        //                                                  :f_set_hangmog_code,  :f_suryang,        :f_danui)";
        //                                break;

        //                            case DataRowState.Modified:
        //                                cmdText = @"UPDATE OCS0313
        //                                               SET UPD_ID            = :q_user_id
        //                                                 , UPD_DATE          = SYSDATE
        //                                                 , SURYANG           = :f_suryang
        //                                                 , DANUI             = :f_danui
        //                                             WHERE HOSP_CODE         = :f_hosp_code
        //                                               AND SET_PART          = :f_set_part
        //                                               AND HANGMOG_CODE      = :f_hangmog_code
        //                                               AND SET_CODE          = :f_set_code
        //                                               AND SET_HANGMOG_CODE  = :f_set_hangmog_code";
        //                                break;

        //                            case DataRowState.Deleted:
        //                                cmdText = @"DELETE OCS0313
        //                                             WHERE HOSP_CODE         = :f_hosp_code
        //                                               AND SET_PART          = :f_set_part
        //                                               AND HANGMOG_CODE      = :f_hangmog_code
        //                                               AND SET_CODE          = :f_set_code
        //                                               AND SET_HANGMOG_CODE  = :f_set_hangmog_code";
        //                                break;
        //                        }
        //                        break;


        //                }
        //                return Service.ExecuteNonQuery(cmdText, item.BindVarList);

        //            }
        //        }
        #endregion

        private void grdSetHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSetHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSetHangmog.SetBindVarValue("f_set_part", this.grdSetCode.GetItemString(this.grdSetCode.CurrentRowNumber, "set_part"));
            this.grdSetHangmog.SetBindVarValue("f_hangmog_code", this.grdSetCode.GetItemString(this.grdSetCode.CurrentRowNumber, "hangmog_code"));
            this.grdSetHangmog.SetBindVarValue("f_set_code", this.grdSetCode.GetItemString(this.grdSetCode.CurrentRowNumber, "set_code"));
        }
    }
}

