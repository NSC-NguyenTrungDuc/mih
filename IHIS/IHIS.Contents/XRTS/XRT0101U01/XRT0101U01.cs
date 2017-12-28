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
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.XRTS.Properties;

#endregion

namespace IHIS.XRTS
{
	/// <summary>
	/// XRT0101U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class XRT0101U01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XMstGrid grdMcode;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGrid grdDcode;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.SingleLayout layDupM;
        private IHIS.Framework.SingleLayout layDupD;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XButton btnIfQry;
		private System.Windows.Forms.ToolTip toolTip;
		private IHIS.Framework.XButton xButton1;
		private IHIS.Framework.XButton xButton2;
		private IHIS.Framework.XButton xButton3;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
		private System.ComponentModel.IContainer components;

		public XRT0101U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            //this.grdMcode.SavePerformer = new XSavePerformer(this);
            //this.grdDcode.SavePerformer = this.grdMcode.SavePerformer;

            //set ParamList
            this.grdMcode.ParamList = new List<string>(new String[] { "f_code_type" });
            this.grdDcode.ParamList = new List<string>(new String[] { "f_code_type", "f_code_name", "f_code" });
            this.layDupM.ParamList = new List<string>(new String[] { "f_code_type" });
            this.layDupD.ParamList = new List<string>(new String[] { "f_code_type", "f_code" });

            //set ExecuteQuery
		    this.grdMcode.ExecuteQuery = LoadDataGrdMCode;
		    this.grdDcode.ExecuteQuery = LoadDataGrdDCode;
		    this.layDupM.ExecuteQuery = LoadDataLayDupM;
            this.layDupD.ExecuteQuery = LoadDataLayDupD;
		}

	    #region CloudService

        /// <summary>
        /// ComboAdminGubun
        /// </summary>
        /// <returns></returns>
        private IList<object[]> ComboAdminGubun(BindVarCollection var)
        {
            IList<object[]> res = new List<object[]>();
            ComboAdminGubunArgs args = new ComboAdminGubunArgs();
            args.CodeType = "ADMIN_GUBUN";
            ComboResult comboResult =
                CacheService.Instance.Get<ComboAdminGubunArgs, ComboResult>(args, delegate(ComboResult result)
                    {
                        return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                               result.ComboItem != null && result.ComboItem.Count > 0;
                    });
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
                {
                    res.Add(new object[] { info.Code, info.CodeName });
                }
            }
            return res;
        }

        /// <summary>
        /// LoadData for layDupD
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayDupD(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0101U01LayDupDArgs args = new XRT0101U01LayDupDArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            XRT0101U01LayDupDResult result = CloudService.Instance.Submit<XRT0101U01LayDupDResult, XRT0101U01LayDupDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.YValue
                });
            }
            return res;
        } 


        /// <summary>
        /// LoadData for layDupM
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayDupM(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0101U01LayDupMArgs args = new XRT0101U01LayDupMArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            XRT0101U01LayDupMResult result = CloudService.Instance.Submit<XRT0101U01LayDupMResult, XRT0101U01LayDupMArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.YValue
                });
            }
            return res;
        } 


        /// <summary>
        /// LoadData for grdMCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private List<object[]> LoadDataGrdMCode(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        XRT0101U01GrdMcodeArgs args = new XRT0101U01GrdMcodeArgs();
	        args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
	        XRT0101U01GrdMcodeResult result =
	            CloudService.Instance.Submit<XRT0101U01GrdMcodeResult, XRT0101U01GrdMcodeArgs>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (XRT0101U01GrdMcodeListItemInfo item in result.GrdList)
	            {
	                object[] objects =
	                {
	                    item.CodeType,
	                    item.CodeTypeName,
	                    item.AdminGubun
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// LoadData for grdDCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdDCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0101U01GrdDcodeArgs args = new XRT0101U01GrdDcodeArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.CodeName = bc["f_code_name"] != null ? bc["f_code_name"].VarValue : "";
            XRT0101U01GrdDcodeResult result = CloudService.Instance.Submit<XRT0101U01GrdDcodeResult, XRT0101U01GrdDcodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0101U01GrdDcodeListItemInfo item in result.GrdList)
                {
                    object[] objects = 
				{ 
					item.CodeType, 
					item.Code, 
					item.Code2, 
					item.CodeName, 
					item.CodeName2, 
					item.Seq, 
					item.CodeValue, 
					item.TrimValue, 
					item.RowState
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private bool SaveXRT0101U01()
        {
            List<XRT0101U01GrdMcodeListItemInfo> inputMcode = GetListFromGrdMcode();
            List<XRT0101U01GrdDcodeListItemInfo> inputDcode = GetListFromGrdDcode();
            if (inputMcode.Count == 0 && inputDcode.Count == 0)
            {
                return true;
            }
            XRT0101U01SaveLayoutArgs args = new XRT0101U01SaveLayoutArgs(UserInfo.UserID, inputMcode, inputDcode);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, XRT0101U01SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

	    private List<XRT0101U01GrdDcodeListItemInfo> GetListFromGrdDcode()
	    {
            List<XRT0101U01GrdDcodeListItemInfo> dataList = new List<XRT0101U01GrdDcodeListItemInfo>();
            for (int i = 0; i < grdDcode.RowCount; i++)
            {
                if (grdDcode.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                XRT0101U01GrdDcodeListItemInfo info = new XRT0101U01GrdDcodeListItemInfo();
                info.CodeType = this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type");
                info.Code = grdDcode.GetItemString(i, "code");
                info.Code2 = grdDcode.GetItemString(i, "code2");
                info.CodeName = grdDcode.GetItemString(i, "code_name");
                info.CodeName2 = grdDcode.GetItemString(i, "code2_name");
                info.Seq = grdDcode.GetItemString(i, "seq");
                info.CodeValue = grdDcode.GetItemString(i, "code_value");
                info.RowState = grdDcode.GetRowState(i).ToString();

                dataList.Add(info);
            }
            if (grdDcode.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDcode.DeletedRowTable.Rows)
                {
                    XRT0101U01GrdDcodeListItemInfo info = new XRT0101U01GrdDcodeListItemInfo();
                    info.CodeType = this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type");
                    info.Code = row["code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }

            return dataList;
	    }

	    private List<XRT0101U01GrdMcodeListItemInfo> GetListFromGrdMcode()
	    {
	        List<XRT0101U01GrdMcodeListItemInfo> dataList = new List<XRT0101U01GrdMcodeListItemInfo>();
	        for (int i = 0; i < grdMcode.RowCount; i++)
	        {
	            if (grdMcode.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }
                XRT0101U01GrdMcodeListItemInfo info = new XRT0101U01GrdMcodeListItemInfo();
	            info.CodeType = grdMcode.GetItemString(i, "code_type");
                info.CodeTypeName = grdMcode.GetItemString(i, "code_type_name");
                info.AdminGubun = grdMcode.GetItemString(i, "admin_gubun");
	            info.RowState = grdMcode.GetRowState(i).ToString();

                dataList.Add(info);
	        }
	        if (grdMcode.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdMcode.DeletedRowTable.Rows)
	            {
                    XRT0101U01GrdMcodeListItemInfo info = new XRT0101U01GrdMcodeListItemInfo();
                    info.CodeType = row["code_type"].ToString();
	                info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
	            }
	        }

	        return dataList;
	    }

	    #endregion




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

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT0101U01));
            this.grdMcode = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdDcode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.layDupM = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDupD = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.btnIfQry = new IHIS.Framework.XButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.xButton1 = new IHIS.Framework.XButton();
            this.xButton2 = new IHIS.Framework.XButton();
            this.xButton3 = new IHIS.Framework.XButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).BeginInit();
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
            this.xEditGridCell2,
            this.xEditGridCell9});
            this.grdMcode.ColPerLine = 3;
            this.grdMcode.ColResizable = true;
            this.grdMcode.Cols = 4;
            this.grdMcode.ExecuteQuery = null;
            this.grdMcode.FixedCols = 1;
            this.grdMcode.FixedRows = 1;
            this.grdMcode.HeaderHeights.Add(24);
            this.grdMcode.Name = "grdMcode";
            this.grdMcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMcode.ParamList")));
            this.grdMcode.QuerySQL = resources.GetString("grdMcode.QuerySQL");
            this.grdMcode.RowHeaderVisible = true;
            this.grdMcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdMcode, resources.GetString("grdMcode.ToolTip"));
            this.grdMcode.ToolTipActive = true;
            this.grdMcode.UseDefaultTransaction = false;
            this.grdMcode.Click += new System.EventHandler(this.grdMcode_Click);
            this.grdMcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMcode_GridColumnChanged);
            this.grdMcode.PreEndInitializing += new System.EventHandler(this.grdMcode_PreEndInitializing);
            this.grdMcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMcode_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 83;
            this.xEditGridCell1.Col = 1;
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
            this.xEditGridCell2.CellLen = 30;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 198;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "admin_gubun";
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
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
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell10});
            this.grdDcode.ColPerLine = 5;
            this.grdDcode.ColResizable = true;
            this.grdDcode.Cols = 6;
            this.grdDcode.ExecuteQuery = null;
            this.grdDcode.FixedCols = 1;
            this.grdDcode.FixedRows = 1;
            this.grdDcode.HeaderHeights.Add(24);
            this.grdDcode.MasterLayout = this.grdMcode;
            this.grdDcode.Name = "grdDcode";
            this.grdDcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDcode.ParamList")));
            this.grdDcode.QuerySQL = resources.GetString("grdDcode.QuerySQL");
            this.grdDcode.RowHeaderVisible = true;
            this.grdDcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdDcode, resources.GetString("grdDcode.ToolTip"));
            this.grdDcode.ToolTipActive = true;
            this.grdDcode.UseDefaultTransaction = false;
            this.grdDcode.Click += new System.EventHandler(this.grdDcode_Click);
            this.grdDcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDcode_GridColumnChanged);
            this.grdDcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDcode_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 53;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.CellLen = 40;
            this.xEditGridCell5.CellName = "code2";
            this.xEditGridCell5.CellWidth = 51;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.CellLen = 100;
            this.xEditGridCell6.CellName = "code_name";
            this.xEditGridCell6.CellWidth = 221;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell7.CellLen = 40;
            this.xEditGridCell7.CellName = "code2_name";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.CellName = "seq";
            this.xEditGridCell8.CellWidth = 47;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 30;
            this.xEditGridCell10.CellName = "code_value";
            this.xEditGridCell10.CellWidth = 198;
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
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
            this.layDupD.QuerySQL = resources.GetString("layDupD.QuerySQL");
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
            this.btnIfQry.Image = ((System.Drawing.Image)(resources.GetObject("btnIfQry.Image")));
            this.btnIfQry.Name = "btnIfQry";
            this.toolTip.SetToolTip(this.btnIfQry, resources.GetString("btnIfQry.ToolTip"));
            this.btnIfQry.Click += new System.EventHandler(this.btnIfQry_Click);
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // xButton1
            // 
            this.xButton1.AccessibleDescription = null;
            this.xButton1.AccessibleName = null;
            resources.ApplyResources(this.xButton1, "xButton1");
            this.xButton1.BackgroundImage = null;
            this.xButton1.Name = "xButton1";
            this.toolTip.SetToolTip(this.xButton1, resources.GetString("xButton1.ToolTip"));
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // xButton2
            // 
            this.xButton2.AccessibleDescription = null;
            this.xButton2.AccessibleName = null;
            resources.ApplyResources(this.xButton2, "xButton2");
            this.xButton2.BackgroundImage = null;
            this.xButton2.Name = "xButton2";
            this.toolTip.SetToolTip(this.xButton2, resources.GetString("xButton2.ToolTip"));
            this.xButton2.Click += new System.EventHandler(this.xButton2_Click);
            // 
            // xButton3
            // 
            this.xButton3.AccessibleDescription = null;
            this.xButton3.AccessibleName = null;
            resources.ApplyResources(this.xButton3, "xButton3");
            this.xButton3.BackgroundImage = null;
            this.xButton3.Name = "xButton3";
            this.toolTip.SetToolTip(this.xButton3, resources.GetString("xButton3.ToolTip"));
            this.xButton3.Click += new System.EventHandler(this.xButton3_Click);
            // 
            // XRT0101U01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xButton3);
            this.Controls.Add(this.xButton2);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.btnIfQry);
            this.Controls.Add(this.grdDcode);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdMcode);
            this.Name = "XRT0101U01";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	
		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			// TODO:  XRT0101U00.OnLoad 구현을 추가합니다.
			base.OnLoad (e);

			this.grdDcode.SetRelationKey("code_type","code_type");
			this.grdDcode.SetRelationTable("XRT0102");

			if( !this.grdMcode.QueryLayout(false))
				XMessageBox.Show(Resources.TEXT1 + Service.ErrFullMsg ,Resources.TEXT2, MessageBoxIcon.Error);

			this.toolTip.SetToolTip(this.btnIfQry,Resources.TEXT3);

            //MED-7294
            if (UserInfo.HospCode != "NTA")
            {
                DisableCRUD();
            }
		}
		#endregion

		#region 마스터 테이블 중복체크(입력시 code type)
		private void grdMcode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{	
			DataRowState rowState = this.grdMcode.LayoutTable.Rows[this.grdMcode.CurrentRowNumber].RowState;
			// 입력 버튼이 클릭 되었을 때만 체크
			if ( rowState == DataRowState.Added )
			{
				// 입력된 셀이 코드타입 컬럼이라면,
				if ( e.ColName == "code_type" )
				{
					// 만약 마스터테이블에 존재한다면, 'Y'를 그렇지않으면, 'N'을 리턴
					this.layDupM.QueryLayout();
					if ( this.layDupM.GetItemValue("dup_yn").ToString() == "Y" )
					{
						string msg = (NetInfo.Language == LangMode.Ko ? Resources.TEXT4
							: Resources.TEXT5);
						XMessageBox.Show( this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber,"code_type")  +
							msg,Resources.TEXT6, MessageBoxButtons.OK );
						e.Cancel = true;
					}
				}
			}
		}
		#endregion

		#region 디테일 테이블 중복체크(입력시 code)
		private void grdDcode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			DataRowState rowState = this.grdDcode.LayoutTable.Rows[this.grdDcode.CurrentRowNumber].RowState;
			//입력 버튼이 클릭 되었을 때만 체크
			if ( rowState == DataRowState.Added )
			{
				// 입력된 셀이 코드 컬럼이면,
				if ( e.ColName == "code" )
				{
				
					this.layDupD.QueryLayout();
					if ( this.layDupD.GetItemValue("dup_yn").ToString() == "Y" )
					{
						string msg = (NetInfo.Language == LangMode.Ko ? Resources.TEXT4
							: Resources.TEXT5);
						XMessageBox.Show( this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber,"code") +
							msg,Resources.TEXT6, MessageBoxButtons.OK );
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
			if ( flag%2 == 0)
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
				string query = (NetInfo.Language == LangMode.Ko ? Resources.TEXT7
					: Resources.TEXT8);
				this.btnIfQry.Text = query;
			}
			//검색실행버튼을 클릭시
			else
			{
				//현재스크린의 아웃포커스가 마스터그리드라면,
				if (this.CurrMQLayout == this.grdMcode)
				{
                    this.grdMcode.SetBindVarValue("f_code_type", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type"));
                    this.grdMcode.QueryLayout(false);
				}
				//현재스크린의 아웃포커스가 디테일그리드라면,
				else if (this.CurrMQLayout == this.grdDcode)
				{
                    this.grdDcode.QueryLayout(false);
				}
				//버튼의 텍스트를 변경
				string query = (NetInfo.Language == LangMode.Ko ? Resources.TEXT9
					: Resources.TEXT10);
				this.btnIfQry.Text = query;
			}
			//검색실행이 끝난후 다시 중복체크이벤트를 살려두어야함
			if (flag%2 == 1)
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
					if ( this.CurrMQLayout == this.grdMcode && flag%2 == 1)
						this.grdMcode.SetFocusToItem(this.grdMcode.CurrentRowNumber,"code_type_name");
					else if ( this.CurrMQLayout == this.grdDcode && flag%2 == 1)
						this.grdDcode.SetFocusToItem(this.grdDcode.CurrentRowNumber,"code2");
					
					this.btnIfQry_Click(new object(),new System.EventArgs());
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
					if ( this.CurrMQLayout == this.grdMcode )
					{
                        this.grdMcode.SetBindVarValue("f_code_type", "");
					}
					else
					{
						this.grdDcode.SetBindVarValue("f_code","");
                        this.grdDcode.SetBindVarValue("f_code_name", "");
					}
					break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = true;

                    //try
                    //{
                    //    Service.BeginTransaction();

                    //    if (!this.grdMcode.SaveLayout())
                    //        throw new Exception();
                    //    if (!this.grdDcode.SaveLayout())
                    //        throw new Exception();

                    //    Service.CommitTransaction();

                    //    XMessageBox.Show(Resources.TEXT11,Resources.TEXT12,MessageBoxIcon.Asterisk);
                    //}
                    //catch
                    //{
                    //    Service.RollbackTransaction();
                    //    e.IsSuccess = false;
                    //    XMessageBox.Show(Resources.TEXT13,Resources.TEXT14, MessageBoxIcon.Error);
                    //}

			        if (SaveXRT0101U01())
			        {
                        XMessageBox.Show(Resources.TEXT11, Resources.TEXT12, MessageBoxIcon.Asterisk);
                        //btnList.PerformClick(FunctionType.Query);
                        grdMcode.ResetUpdate();
                        grdDcode.ResetUpdate();
			        }
			        else
			        {
                        e.IsSuccess = false;
                        XMessageBox.Show(Resources.TEXT13, Resources.TEXT14, MessageBoxIcon.Error);
			        }

                    break;

				default:
					break;
			}
		}


	    private void xButton1_Click(object sender, System.EventArgs e)
		{
			string msg = (NetInfo.Language == LangMode.Ko ? Resources.TEXT15
				: Resources.TEXT16);
			XMessageBox.Show( msg,Resources.TEXT6, MessageBoxButtons.YesNo );
		}

		private void xButton2_Click(object sender, System.EventArgs e)
		{
			string msg = (NetInfo.Language == LangMode.Ko ? Resources.TEXT15
				: Resources.TEXT17);
			XMessageBox.Show( msg,Resources.TEXT6, MessageBoxButtons.OK );
		}

		private void xButton3_Click(object sender, System.EventArgs e)
		{
			string msg = (NetInfo.Language == LangMode.Ko ? Resources.TEXT18
				: Resources.TEXT19);
			XMessageBox.Show( msg,Resources.TEXT6, MessageBoxButtons.OK );
		}

        private void grdMcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMcode.SetBindVarValue("f_code_type", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type"));
        }

        private void grdDcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDcode.SetBindVarValue("f_code_type", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type"));
        }

        private void layDupM_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupM.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupM.SetBindVarValue("f_code_type", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type"));
        }

        private void layDupD_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupD.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupD.SetBindVarValue("f_code_type", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type"));
            this.layDupD.SetBindVarValue("f_code", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "code"));
        }

        private void grdMcode_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell9.ExecuteQuery = ComboAdminGubun;
        }

        private void EnableCRUD()
        {
            btnList.SetEnabled(FunctionType.Insert, true);
            btnList.SetEnabled(FunctionType.Delete, true);
            btnList.SetEnabled(FunctionType.Update, true);
            btnList.SetEnabled(FunctionType.Reset, true);
        }

        private void DisableCRUD()
        {
            btnList.SetEnabled(FunctionType.Insert, false);
            btnList.SetEnabled(FunctionType.Delete, false);
            btnList.SetEnabled(FunctionType.Update, false);
            btnList.SetEnabled(FunctionType.Reset, false);
            this.grdMcode.ReadOnly = true;
        }

        private void grdMcode_Click(object sender, EventArgs e)
        {
            //MED-7294
            if (UserInfo.HospCode != "NTA")
            {
                DisableCRUD();
            }
        }

        private void grdDcode_Click(object sender, EventArgs e)
        {
            //MED-7294
            EnableCRUD();
        }

        #region XSavePerformer 

//        private class XSavePerformer : ISavePerformer
//        {
//            XRT0101U01 parent;

//            public XSavePerformer(XRT0101U01 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                switch(callerID)
//                {
//                    case '1':

//                    switch (item.RowState)
//                    { 
//                        case DataRowState.Added:
//                            cmdText = @"INSERT INTO XRT0101 (
//                                              SYS_DATE,              SYS_ID,                   
//                                              UPD_DATE,              UPD_ID,                 HOSP_CODE,
//                                              CODE_TYPE,             CODE_TYPE_NAME,         ADMIN_GUBUN
//                                            ) VALUES (
//                                              SYSDATE,               :q_user_id,               
//                                              SYSDATE,               :q_user_id,           :f_hosp_code,
//                                              :f_code_type,          :f_code_type_name,    :f_admin_gubun )";
//                            break;

//                        case DataRowState.Modified:
//                            cmdText = @"UPDATE XRT0101
//                                           SET UPD_ID          = :q_user_id
//                                             , UPD_DATE        = SYSDATE
//                                             , CODE_TYPE_NAME  = :f_code_type_name
//                                             , ADMIN_GUBUN     = :f_admin_gubun
//                                         WHERE HOSP_CODE       = :f_hosp_code
//                                           AND CODE_TYPE       = :f_code_type  ";

//                            break;

//                        case DataRowState.Deleted:
//                            cmdText = @"DECLARE
//                                           RESULT   VARCHAR2(1);
//                                        BEGIN
//                                           RESULT := 'N';
//                                           FOR X IN (SELECT 'X' 
//                                                       FROM XRT0102
//                                                      WHERE HOSP_CODE = :f_hosp_code
//                                                        AND CODE_TYPE = :f_code_type) LOOP
//                                               RESULT := 'Y';
//                                           END LOOP;
//                                             
//                                           DELETE XRT0101
//                                            WHERE HOSP_CODE = :f_hosp_code
//                                              AND CODE_TYPE = :f_code_type;
//                                              
//                                           if RESULT = 'Y' THEN
//                                              DELETE XRT0102
//                                               WHERE HOSP_CODE = :f_hosp_code
//                                                 AND CODE_TYPE = :f_code_type;
//                                           END IF;                                           
//                                        END;  ";

//                            break;
//                    }
//                    break;

//                    case '2':

//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO XRT0102 (
//                                                  SYS_DATE,        SYS_ID,          
//                                                  UPD_DATE,        UPD_ID,          HOSP_CODE,
//                                                  CODE_TYPE,       CODE,            CODE_NAME,
//                                                  CODE2,           CODE_NAME2,      SEQ,
//                                                  CODE_VALUE
//                                                ) VALUES (
//                                                  SYSDATE,         :q_user_id,     
//                                                  SYSDATE,         :q_user_id,      :f_hosp_code,
//                                                  :f_code_type,    :f_code,         :f_code_name,
//                                                  :f_code2,        NULL,            :f_seq,
//                                                  :f_code_value)";
//                                break;

//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE XRT0102
//                                               SET UPD_ID            = :q_user_id
//                                                 , UPD_DATE          = SYSDATE
//                                                 , CODE2             = :f_code2
//                                                 , CODE_NAME         = :f_code_name
//                                                 , SEQ               = :f_seq
//                                                 , CODE_VALUE        = :f_code_value
//                                             WHERE HOSP_CODE         = :f_hosp_code
//                                               AND CODE_TYPE         = :f_code_type
//                                               AND CODE              = :f_code";
//                                break;

//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE XRT0102
//                                             WHERE HOSP_CODE = :f_hosp_code
//                                               AND CODE_TYPE = :f_code_type
//                                               AND CODE      = :f_code ";
//                                break;
//                        }
//                    break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

    }
}

