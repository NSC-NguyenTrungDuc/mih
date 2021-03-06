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
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// IFS0004U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class IFS0004U01 : IHIS.Framework.XScreen
	{
        #region IHIS Controls
        private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlLeft;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XFlatLabel xFlatLabel1;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XEditGrid grdDetail;
		private IHIS.Framework.XFindBox fbxNu_Gubun;
        private IHIS.Framework.XDisplayBox dbxNu_Gubun_Name;
		private IHIS.Framework.XEditGridCell xEditGridCellcode_type;
		private IHIS.Framework.XEditGridCell xEditGridCellcode_type_name;
		private IHIS.Framework.XEditGridCell xEditGridCellment;
		private IHIS.Framework.XEditGridCell xEditGridCellcode;
		private IHIS.Framework.XEditGridCell xEditGridCellcode_name;
		private IHIS.Framework.XEditGridCell xEditGridCellsort_key;
		private IHIS.Framework.XEditGridCell xEditGridCellgroup_key;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell1;
        #endregion IHIS Controls
        
        #region Etc Variables
        /// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        string mbxMsg = "", mbxCap = "";

        bool isgrdMasterSave = false;
        bool isSavedMaster = false;
        bool isgrdDetailSave = false;
        bool isSavedDetail = false;

        string mHospCode = EnvironInfo.HospCode;

        //private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        //private IHIS.OCS.OrderFunc mOrderFunc = null;       // OCS 그룹 Function 라이브러리
        //
        private IHIS.BASS.ComBiz mComBiz = null;               // BASS SYSTEM Business 라이브러리
        private IHIS.BASS.ComFunc mComFunc = null;              // BASS SYSTEM Function 라이브러리
        private XDatePicker xDateYmd;
        private XLabel xLabel1;            

        private Hashtable mHtControl = null;                  // Control과 연결할 HashTable

        #endregion Etc Variables

		public IFS0004U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			//this.mOrderBiz  = new IHIS.OCS.OrderBiz();                    // OCS 그룹 Business 라이브러리
            //this.mOrderFunc = new IHIS.OCS.OrderFunc();                   // OCS 그룹 Function 라이브러리

            this.mComBiz  = new IHIS.BASS.ComBiz();                       // BASS SYSTEM Business 라이브러리
            this.mComFunc = new IHIS.BASS.ComFunc();                      // BASS SYSTEM Function 라이브러리
		
            //SaveLayoutList.Add(grdMaster);
            //SaveLayoutList.Add(grdDetail);

            //grdMaster.SavePerformer = new XSavePerformer(this);
            //grdDetail.SavePerformer = grdMaster.SavePerformer;

            this.grdMaster.ParamList = new List<string>(new String[] { "f_nu_gubun", "f_nu_ymd" });
            this.grdDetail.ParamList = new List<string>(new String[] { "f_nu_gubun", "f_nu_code", "f_nu_ymd", "f_cur_ymd" });

		    this.grdMaster.ExecuteQuery = LoadDataGrdMaster;
		    this.grdDetail.ExecuteQuery = LoadDataGrdDetail;
		}

	    #region CloudService


	    private List<object[]> LoadDataGrdMaster(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        IFS0004U01grdMasterArgs args = new IFS0004U01grdMasterArgs();
	        args.NuGubun = bc["f_nu_gubun"] != null ? bc["f_nu_gubun"].VarValue : "";
	        args.NuYmd = bc["f_nu_ymd"] != null ? bc["f_nu_ymd"].VarValue : "";
	        IFS0004U01grdMasterResult result =
	            CloudService.Instance.Submit<IFS0004U01grdMasterResult, IFS0004U01grdMasterArgs>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (IFS0004U01grdMasterListItemInfo item in result.GrdList)
	            {
	                object[] objects =
	                {
	                    item.NuGubun,
	                    item.NuCode,
	                    item.NuYmd,
	                    item.NuCodeName
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

	    private List<object[]> LoadDataGrdDetail(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        IFS0004U01grdDetailtArgs args = new IFS0004U01grdDetailtArgs();
	        args.CurYmd = bc["f_cur_ymd"] != null ? bc["f_cur_ymd"].VarValue : "";
	        args.NuGubun = bc["f_nu_gubun"] != null ? bc["f_nu_gubun"].VarValue : "";
	        args.NuCode = bc["f_nu_code"] != null ? bc["f_nu_code"].VarValue : "";
	        args.NuYmd = bc["f_nu_ymd"] != null ? bc["f_nu_ymd"].VarValue : "";
	        IFS0004U01grdDetailtResult result =
	            CloudService.Instance.Submit<IFS0004U01grdDetailtResult, IFS0004U01grdDetailtArgs>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (IFS0004U01grdDetailtListItemInfo item in result.GrdList)
	            {
	                object[] objects =
	                {
	                    item.NuGubun,
	                    item.NuCode,
	                    item.NuYmd,
	                    item.BunCode,
	                    item.BunName,
	                    item.SgCode,
	                    item.SgName
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        //private bool ValidateGrdMaster()
        //{
        //    for (int i = 0; i < grdMaster.RowCount; i++)
        //    {
        //        if (grdMaster.GetRowState(i) != DataRowState.Unchanged && String.IsNullOrEmpty(grdMaster.GetItemString(i, "nu_code")))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //private bool SaveIFS0004U01()
        //{
        //    List<IFS0004U01grdMasterListItemInfo> inputMaster = GetListFromGrdMaster();
        //    List<IFS0004U01grdDetailtListItemInfo> inputDetail = GetListFromGrdDetail();
        //    if (inputMaster.Count == 0 && inputDetail.Count == 0)
        //    {
        //        return true;
        //    }

        //    IFS0004U01TransactionalArgs args = new IFS0004U01TransactionalArgs(inputDetail, inputMaster, UserInfo.UserID);
        //    UpdateResult result = CloudService.Instance.Submit<UpdateResult, IFS0004U01TransactionalArgs>(args);
        //    if (result.ExecutionStatus == ExecutionStatus.Success)
        //    {
        //        return result.Result;
        //    }

        //    return false;
        //}

	    private string Msg = "";
        //private bool checkValidate(List<IFS0004U01grdMasterListItemInfo> inputMaster, List<IFS0004U01grdDetailtListItemInfo> inputDetail)
        //{
            //List<IFS0004U01grdMasterListItemInfo> inputMaster = GetListFromGrdMaster();
            //List<IFS0004U01grdDetailtListItemInfo> inputDetail = GetListFromGrdDetail();
            //if (inputMaster.Count > 0)
            //{
            //    foreach (IFS0004U01grdMasterListItemInfo infoMaster in inputMaster)
            //    {
            //        if (infoMaster.NuCode == "" || infoMaster.NuCodeName == "" || infoMaster.NuGubun == "")
            //        {
            //            Msg = Resources.WARNING_SMS;
            //            return false;
            //        }
            //    }
            //}
            //if (inputDetail.Count > 0)
            //{
            //    foreach (IFS0004U01grdDetailtListItemInfo infoDetail in inputDetail)
            //    {
            //        if (infoDetail.BunCode == "" || infoDetail.SgCode == "")
            //        {
            //            Msg = Resources.WARNING_SMS;
            //            return false;
            //        }
            //    }
            //}
            //return true;
        //}

	    private List<IFS0004U01grdDetailtListItemInfo> GetListFromGrdDetail(out string errMsg)
	    {
            errMsg = string.Empty;

            List<IFS0004U01grdDetailtListItemInfo> dataList = new List<IFS0004U01grdDetailtListItemInfo>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                // Required check
                if (TypeCheck.IsNull(grdDetail.GetItemString(i, "bun_code")))
                {
                    errMsg = Resources.BUN_CODE_REQ;
                    return dataList;
                }

                if (TypeCheck.IsNull(grdDetail.GetItemString(i, "sg_code")))
                {
                    errMsg = Resources.SG_CODE;
                    return dataList;
                }

                IFS0004U01grdDetailtListItemInfo info = new IFS0004U01grdDetailtListItemInfo();
                info.NuGubun = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_gubun");
                info.NuCode =  grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_code");
                info.NuYmd =    grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_ymd");
                info.BunCode = grdDetail.GetItemString(i, "bun_code");
                info.BunName = grdDetail.GetItemString(i, "bun_name");
                info.SgCode = grdDetail.GetItemString(i, "sg_code");
                info.SgName = grdDetail.GetItemString(i, "sg_name");
                info.RowState = grdDetail.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdDetail.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
                {
                    IFS0004U01grdDetailtListItemInfo info = new IFS0004U01grdDetailtListItemInfo();
                    info.NuGubun = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_gubun");
                    info.NuCode = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_code");
                    info.NuYmd = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_ymd");
                    info.BunCode = row["bun_code"].ToString();
                    info.SgCode = row["sg_code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
	    }

	    private List<IFS0004U01grdMasterListItemInfo> GetListFromGrdMaster(out string errMsg)
	    {
            errMsg = string.Empty;

	        List<IFS0004U01grdMasterListItemInfo> dataList = new List<IFS0004U01grdMasterListItemInfo>();
	        for (int i = 0; i < grdMaster.RowCount; i++)
	        {
	            if (grdMaster.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }

                // Required check
                //if (TypeCheck.IsNull(grdMaster.GetItemString(i, "nu_gubun")))
                //{
                //    errMsg = Resources.NU_GUBUN_REQ;
                //    return dataList;
                //}

                if (TypeCheck.IsNull(grdMaster.GetItemString(i, "nu_code")))
                {
                    errMsg = Resources.NU_CODE_REQ;
                    return dataList;
                }

                if (TypeCheck.IsNull(grdMaster.GetItemString(i, "nu_ymd")))
                {
                    errMsg = Resources.NU_YMD_REQ;
                    return dataList;
                }

                if (TypeCheck.IsNull(grdMaster.GetItemString(i, "nu_code_name")))
                {
                    errMsg = Resources.NU_CODE_NAME;
                    return dataList;
                }

	            IFS0004U01grdMasterListItemInfo info = new IFS0004U01grdMasterListItemInfo();
	            info.NuGubun = this.fbxNu_Gubun.GetDataValue();
                info.NuCode = grdMaster.GetItemString(i, "nu_code");
                info.NuYmd = grdMaster.GetItemString(i, "nu_ymd");
                info.NuCodeName = grdMaster.GetItemString(i, "nu_code_name");
	            info.RowState = grdMaster.GetRowState(i).ToString();

                dataList.Add(info);
	        }

	        if (grdMaster.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdMaster.DeletedRowTable.Rows)
	            {
                    IFS0004U01grdMasterListItemInfo info = new IFS0004U01grdMasterListItemInfo();
                    info.NuGubun = this.fbxNu_Gubun.GetDataValue();
                    info.NuCode = row["nu_code"].ToString();
                    info.NuYmd = row["nu_ymd"].ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IFS0004U01));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xDateYmd = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.dbxNu_Gubun_Name = new IHIS.Framework.XDisplayBox();
            this.fbxNu_Gubun = new IHIS.Framework.XFindBox();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCellcode_type = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellcode_type_name = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellment = new IHIS.Framework.XEditGridCell();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCellcode = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellcode_name = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellsort_key = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellgroup_key = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlTop.Controls.Add(this.xDateYmd);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.xFlatLabel1);
            this.pnlTop.Controls.Add(this.dbxNu_Gubun_Name);
            this.pnlTop.Controls.Add(this.fbxNu_Gubun);
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // xDateYmd
            // 
            this.xDateYmd.AccessibleDescription = null;
            this.xDateYmd.AccessibleName = null;
            resources.ApplyResources(this.xDateYmd, "xDateYmd");
            this.xDateYmd.BackgroundImage = null;
            this.xDateYmd.Font = null;
            this.xDateYmd.Name = "xDateYmd";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Font = null;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.AccessibleDescription = null;
            this.xFlatLabel1.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // dbxNu_Gubun_Name
            // 
            this.dbxNu_Gubun_Name.AccessibleDescription = null;
            this.dbxNu_Gubun_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxNu_Gubun_Name, "dbxNu_Gubun_Name");
            this.dbxNu_Gubun_Name.Image = null;
            this.dbxNu_Gubun_Name.Name = "dbxNu_Gubun_Name";
            // 
            // fbxNu_Gubun
            // 
            this.fbxNu_Gubun.AccessibleDescription = null;
            this.fbxNu_Gubun.AccessibleName = null;
            resources.ApplyResources(this.fbxNu_Gubun, "fbxNu_Gubun");
            this.fbxNu_Gubun.BackgroundImage = null;
            this.fbxNu_Gubun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxNu_Gubun.Name = "fbxNu_Gubun";
            this.fbxNu_Gubun.FindClick += new System.ComponentModel.CancelEventHandler(this.Control_FindClick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.AccessibleDescription = null;
            this.pnlLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.BackgroundImage = null;
            this.pnlLeft.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlLeft.Controls.Add(this.grdMaster);
            this.pnlLeft.DrawBorder = true;
            this.pnlLeft.Font = null;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ApplyAutoInsertion = true;
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCellcode_type,
            this.xEditGridCellcode_type_name,
            this.xEditGridCell1,
            this.xEditGridCellment});
            this.grdMaster.ColPerLine = 3;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 3;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(19);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.Enter += new System.EventHandler(this.grdMaster_Enter);
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.ProcessKeyDown += new System.Windows.Forms.KeyEventHandler(this.grdMaster_ProcessKeyDown);
            this.grdMaster.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdMaster.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMaster_GridCellPainting);
            this.grdMaster.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdMaster_GridCellFocusChanged);
            this.grdMaster.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdMaster_GridColumnProtectModify);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCellcode_type
            // 
            this.xEditGridCellcode_type.ApplyPaintingEvent = true;
            this.xEditGridCellcode_type.CellLen = 3;
            this.xEditGridCellcode_type.CellName = "nu_gubun";
            this.xEditGridCellcode_type.CellWidth = 130;
            this.xEditGridCellcode_type.Col = -1;
            this.xEditGridCellcode_type.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCellcode_type, "xEditGridCellcode_type");
            this.xEditGridCellcode_type.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellcode_type.IsNotNull = true;
            this.xEditGridCellcode_type.IsUpdatable = false;
            this.xEditGridCellcode_type.IsVisible = false;
            this.xEditGridCellcode_type.Row = -1;
            // 
            // xEditGridCellcode_type_name
            // 
            this.xEditGridCellcode_type_name.CellLen = 4;
            this.xEditGridCellcode_type_name.CellName = "nu_code";
            this.xEditGridCellcode_type_name.CellWidth = 93;
            this.xEditGridCellcode_type_name.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCellcode_type_name, "xEditGridCellcode_type_name");
            this.xEditGridCellcode_type_name.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCellcode_type_name.IsNotNull = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "nu_ymd";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            // 
            // xEditGridCellment
            // 
            this.xEditGridCellment.AutoInsertAtEnterKey = true;
            this.xEditGridCellment.CellLen = 60;
            this.xEditGridCellment.CellName = "nu_code_name";
            this.xEditGridCellment.CellWidth = 246;
            this.xEditGridCellment.Col = 2;
            this.xEditGridCellment.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCellment, "xEditGridCellment");
            this.xEditGridCellment.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlFill.Controls.Add(this.grdDetail);
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.ApplyAutoInsertion = true;
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCellcode,
            this.xEditGridCellcode_name,
            this.xEditGridCell11,
            this.xEditGridCellsort_key,
            this.xEditGridCellgroup_key,
            this.xEditGridCell10,
            this.xEditGridCell13});
            this.grdDetail.ColPerLine = 4;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 4;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(19);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.QuerySQL = resources.GetString("grdDetail.QuerySQL");
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.Enter += new System.EventHandler(this.grdDetail_Enter);
            this.grdDetail.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdDetail_GridFindClick);
            this.grdDetail.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdDetail_RowFocusChanged);
            this.grdDetail.ProcessKeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDetail_ProcessKeyDown);
            this.grdDetail.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdDetail.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDetail_GridCellPainting);
            this.grdDetail.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdDetail_GridCellFocusChanged);
            this.grdDetail.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdDetail_GridColumnProtectModify);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCellcode
            // 
            this.xEditGridCellcode.ApplyPaintingEvent = true;
            this.xEditGridCellcode.CellLen = 3;
            this.xEditGridCellcode.CellName = "nu_gubun";
            this.xEditGridCellcode.CellWidth = 59;
            this.xEditGridCellcode.Col = -1;
            this.xEditGridCellcode.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCellcode, "xEditGridCellcode");
            this.xEditGridCellcode.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellcode.IsNotNull = true;
            this.xEditGridCellcode.IsVisible = false;
            this.xEditGridCellcode.Row = -1;
            // 
            // xEditGridCellcode_name
            // 
            this.xEditGridCellcode_name.CellLen = 3;
            this.xEditGridCellcode_name.CellName = "nu_code";
            this.xEditGridCellcode_name.CellWidth = 160;
            this.xEditGridCellcode_name.Col = -1;
            this.xEditGridCellcode_name.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCellcode_name, "xEditGridCellcode_name");
            this.xEditGridCellcode_name.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCellcode_name.IsNotNull = true;
            this.xEditGridCellcode_name.IsVisible = false;
            this.xEditGridCellcode_name.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "nu_ymd";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 99;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsNotNull = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xEditGridCellsort_key
            // 
            this.xEditGridCellsort_key.CellLen = 2;
            this.xEditGridCellsort_key.CellName = "bun_code";
            this.xEditGridCellsort_key.CellWidth = 61;
            this.xEditGridCellsort_key.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCellsort_key.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCellsort_key, "xEditGridCellsort_key");
            this.xEditGridCellsort_key.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCellsort_key.IsNotNull = true;
            this.xEditGridCellsort_key.IsUpdatable = false;
            // 
            // xEditGridCellgroup_key
            // 
            this.xEditGridCellgroup_key.CellLen = 80;
            this.xEditGridCellgroup_key.CellName = "bun_name";
            this.xEditGridCellgroup_key.CellWidth = 119;
            this.xEditGridCellgroup_key.Col = 1;
            this.xEditGridCellgroup_key.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCellgroup_key, "xEditGridCellgroup_key");
            this.xEditGridCellgroup_key.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellgroup_key.IsReadOnly = true;
            this.xEditGridCellgroup_key.IsUpdatable = false;
            this.xEditGridCellgroup_key.IsUpdCol = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AutoInsertAtEnterKey = true;
            this.xEditGridCell10.CellName = "sg_code";
            this.xEditGridCell10.CellWidth = 83;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell10.IsNotNull = true;
            this.xEditGridCell10.IsUpdatable = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 80;
            this.xEditGridCell13.CellName = "sg_name";
            this.xEditGridCell13.CellWidth = 222;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsUpdCol = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
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
            // IFS0004U01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = null;
            this.Name = "IFS0004U01";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [메소드 모듈]

		#region HashTable과 연결할 Control's Setting (SetHashTableBinding)
		/// <summary>
		/// HashTable과 연결할 Control's Setting
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="aHt"> HashTable 해당 Object </param>
		/// <param name="aObj"> object 해당 Object </param>
		/// <returns> void </returns>
		private void SetHashTableBinding(Hashtable aHt, object aObj)
		{
			if (aObj == null) return;

			if (aHt == null) aHt = new Hashtable();

			try
			{
				if (aObj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XComboBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XComboBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XComboBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XComboBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XComboBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XComboBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XComboBox)aObj).SelectedIndexChanged += new System.EventHandler(this.Control_SelectedIndexChanged);
				}
				else if (aObj.GetType().Name.ToString().IndexOf("XListBox") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XListBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XListBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XListBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XListBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XListBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XListBox)aObj).SelectedIndexChanged += new System.EventHandler(this.Control_SelectedIndexChanged);
				}
				else if(aObj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XTextBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XTextBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XTextBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XTextBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XTextBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XTextBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
				{						
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XEditMask)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XEditMask)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XEditMask)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XEditMask)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XEditMask)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XEditMask)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XCheckBox") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XCheckBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XCheckBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XCheckBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XCheckBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XCheckBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XCheckBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XCheckBox)aObj).CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
				}
				else if(aObj.GetType().ToString().IndexOf("XRadioButton") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XRadioButton)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XRadioButton)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XRadioButton)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XRadioButton)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XRadioButton)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XRadioButton)aObj).CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
				}
				else if(aObj.GetType().ToString().IndexOf("XDatePicker") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XDatePicker)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XDatePicker)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XDatePicker)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XDatePicker)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XDatePicker)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XDatePicker)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XDisplayBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XDisplayBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XDisplayBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XDisplayBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XDisplayBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XDisplayBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XMemoBox") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XMemoBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XMemoBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XMemoBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XMemoBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XMemoBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XMemoBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XFindBox") >= 0)
				{
					aHt.Add(this.mComFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XFindBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XFindBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XFindBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XFindBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XFindBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XFindBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XFindBox)aObj).FindClick += new System.ComponentModel.CancelEventHandler(this.Control_FindClick);
					((XFindBox)aObj).FindSelected += new IHIS.Framework.FindEventHandler(this.Control_FindSelected);
				}

			}
			catch(Exception ex)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//MessageBox.Show(ex.Message, "HashTable Binding Error");
			}			
		}
		#endregion

		#region Row Insert시 Insert 가능여부 체크 (IsInsertRowEanbled)
		/// <summary>
		/// Row Insert시 Insert 가능여부 체크
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <param name="aInsertRow"> int Insert Row </param>
		/// <returns> bool </returns>
		private bool IsInsertRowEanbled(XEditGrid aGrd, int aInsertRow)
		{
			if (aGrd == null) return false;

			string mbxMsg = "", mbxCap = "";

			if (aGrd == this.grdMaster) // Master
			{
			}
			else if (aGrd == this.grdDetail) // Detail
			{
				if (this.grdMaster.RowCount == 0 || 
					TypeCheck.IsNull(this.grdMaster.GetItemValue(this.grdMaster.CurrentRowNumber, "nu_code")))
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ?  Resources.TEXT1 : 
						Resources.TEXT2;
					mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;

					XMessageBox.Show(mbxMsg, mbxCap,2);

					return false;
				}
			}

			return true;
		}
		#endregion

		#region Row Delete시 Delete 가능여부 체크 (IsDeleteRowEanbled)
		/// <summary>
		/// Row Delete시 Delete 가능여부 체크
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <param name="aDeleteRow"> int Delete Row </param>
		/// <returns> bool </returns>
		private bool IsDeleteRowEanbled(XEditGrid aGrd, int aDeleteRow)
		{
			if (aGrd == null || (aDeleteRow < 0 || aDeleteRow >= aGrd.RowCount)) return false;

			string mbxMsg = "", mbxCap = "";

			if (aGrd == this.grdMaster) // Master
			{
				// Detail 존재여부 체크 (**Master/Detail관계인 경우 FrameWork에선 Table Select하여 존재여부 체크를 한다(SetRelationTable..))
				if (this.grdDetail.RowCount > 0) 
				{					
					mbxMsg = NetInfo.Language == LangMode.Jr ?  Resources.TEXT5 : 
						Resources.TEXT6;
					mbxMsg = String.Format(mbxMsg, aGrd.GetItemString(aGrd.CurrentRowNumber, "nu_code"));
					mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT7 : Resources.TEXT8;

					XMessageBox.Show(mbxMsg, mbxCap, 2);
					
					return false;
				}
			}
			else if (aGrd == this.grdDetail) // Detail
			{

			}

			return true;
		}
		#endregion

        #endregion [메소드 모듈]

        #region [Screen Event]

        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			this.PostLoad();
		}

		/// <summary>
		/// Screen Load시 Post Event로 Call 되서 Load시 처리할 로직들을 기술한다
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <returns> void </returns>
		private void PostLoad()
		{	
			//Set Current Grid
			this.CurrMSLayout = this.grdMaster; 
            this.CurrMQLayout = this.grdMaster;
 
			// HashTable과 연결할 Control's Setting
			foreach(object obj in this.pnlTop.Controls)
			{
				this.SetHashTableBinding(this.mHtControl, obj);
			}

			// Master/Detail Key 
			this.grdDetail.SetRelationTable("IFS0005");
            this.grdDetail.SetRelationKey("nu_gubun", "nu_gubun");
            this.grdDetail.SetRelationKey("nu_code", "nu_code");
            this.grdDetail.SetRelationKey("nu_ymd", "nu_ymd");

            // init
            // 
            this.xDateYmd.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            //
            this.fbxNu_Gubun.SetEditValue("100");
            this.fbxNu_Gubun.AcceptData();
            //
			// 전체 데이타 조회
			this.btnList.PerformClick(FunctionType.Query);

			// 첫번째 Focus Control 세팅
			this.fbxNu_Gubun.Focus();
        }
        #endregion [Screen Event]

        #region [ButtonList Event]

        #region buttonList ButtonList 클릭 Event : Find SQL조건 및 필드 정의 (btnList_ButtonClick)
        /// <remarks>
		/// </remarks>
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset: // 화면 Reset

					break;

				case FunctionType.Query: // 조회

					break;

				case FunctionType.Insert: // 입력 

					// ReadOnly인 경우는 처리불가
					if (((XEditGrid)this.CurrMSLayout).ReadOnly) {e.IsSuccess  = false;	e.IsBaseCall = false; break;}

					// Key입력(F5..)으로도 버튼클릭이 가능하므로, 최종 에디트중인 데이타 있으면 Aceept해야함
					if (!this.AcceptData()) {e.IsSuccess  = false; e.IsBaseCall = false; break;}

					// Insert한 Row 중에 Not Null필드 미입력 Row Search 하여 해당 Row로 이동
					XCell emptyNewCell = this.mComFunc.GetEmptyNewRow((XEditGrid)this.CurrMSLayout);

					if (emptyNewCell != null) 
					{
						e.IsSuccess  = false;
						e.IsBaseCall = false;                                     
						((XEditGrid)this.CurrMSLayout).SetFocusToItem(emptyNewCell.Row, emptyNewCell.CellName);
						break;
					}

					// Insert 가능여부 체크 
					if (!this.IsInsertRowEanbled(((XEditGrid)this.CurrMSLayout), ((XEditGrid)this.CurrMSLayout).CurrentRowNumber))
					{
						e.IsSuccess  = false;
						e.IsBaseCall = false; 
						break;		 
					}

					break;

				case FunctionType.Delete: // 삭제

					// ReadOnly인 경우는 처리불가
					if (((XEditGrid)this.CurrMSLayout).ReadOnly) {e.IsSuccess  = false;	e.IsBaseCall = false; break;}

					// Delete 가능여부 체크 
					if (!this.IsDeleteRowEanbled(((XEditGrid)this.CurrMSLayout), ((XEditGrid)this.CurrMSLayout).CurrentRowNumber))
					{
						e.IsSuccess  = false;
						e.IsBaseCall = false;
						break;		 
					}

					break;

				case FunctionType.Update: // 저장

					// InsertRow나 저장의 경우 BaseCall로 FrameWork에서 저장하지 않고 직접 로직을 기술하는 경우
					// 반드시 처리전에 AcceptData()를 Call해서, 최종Control Value Check를 해야함.
					// 유저가 버튼클릭(Focus이동)에 의하지 않고, 평션키로 로직수행하는 경우 최종 에디트 데이타 반영안됨
					// e.IsBaseCall = false;
					//if (!this.AcceptData()) {e.IsSuccess  = false; e.IsBaseCall = false; break;}					
					//if (!this.DataServiceCall(this.dsvSave)) e.IsSuccess = false;

                    //validate
                    //if (!ValidateGrdMaster())
                    //{
                    //    break;
                    //}

                    string errMsg = string.Empty;

                    List<IFS0004U01grdMasterListItemInfo> inputMaster = GetListFromGrdMaster(out errMsg);
                    if (!TypeCheck.IsNull(errMsg))
                    {
                        XMessageBox.Show(errMsg, Resources.WARNING, MessageBoxIcon.Warning);
                        return;
                    }
                    List<IFS0004U01grdDetailtListItemInfo> inputDetail = GetListFromGrdDetail(out errMsg);
                    if (!TypeCheck.IsNull(errMsg))
                    {
                        XMessageBox.Show(errMsg, Resources.WARNING, MessageBoxIcon.Warning);
                        return;
                    }
                    if (inputMaster.Count == 0 && inputDetail.Count == 0)
                    {
                        break;
                    }
                    IFS0004U01TransactionalArgs args = new IFS0004U01TransactionalArgs(inputDetail, inputMaster, UserInfo.UserID);
                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, IFS0004U01TransactionalArgs>(args);

                    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result)
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT14 : Resources.TEXT15;
                        mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
                        XMessageBox.Show(mbxMsg, mbxCap, 2);

                        grdMaster.ResetUpdate();
                        grdDetail.ResetUpdate();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT16 : Resources.TEXT17;
                        mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Hand);
                    }

                    //if (checkValidate(inputMaster, inputDetail))
                    //{
                    //    IFS0004U01TransactionalArgs args = new IFS0004U01TransactionalArgs(inputDetail, inputMaster, UserInfo.UserID);
                    //    UpdateResult result = CloudService.Instance.Submit<UpdateResult, IFS0004U01TransactionalArgs>(args);

                    //    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result)
                    //    {
                    //        mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT14 : Resources.TEXT15;
                    //        mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
                    //        XMessageBox.Show(mbxMsg, mbxCap, 2);
                    //        //btnList.PerformClick(FunctionType.Query);

                    //        grdMaster.ResetUpdate();
                    //        grdDetail.ResetUpdate();
                    //    }
                    //    else
                    //    {
                    //        mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT16 : Resources.TEXT17;
                    //        mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
                    //        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Hand);
                    //    }
                    //}
                    //else
                    //{
                    //    //XMessageBox.Show(Msg, Resources.WARNING,MessageBoxIcon.Warning);
                    //}

			        break;

				default:
					break;
			}

        }





	    #endregion buttonList ButtonList 클릭 Event

        #region buttonList ButtonList 클릭 성공 이후 Event : 작업성공시 처리 로직을 기술한다 (btnList_PostButtonClick)
        /// <remarks>
		/// Insert Row후에 디폴트값 세팅등.. 버튼리스트 작업후 기술사항을 기술한다
		/// </remarks>
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{

				case FunctionType.Query: // 조회

					break;

				case FunctionType.Insert: // 입력 

					// 입력후 Default값 세팅할 경우가 있는 경우 여기서 기술한다

					break;

				case FunctionType.Delete: // 삭제

					break;

				case FunctionType.Update: // 저장

					break;

				default:
					break;
			}		
		}
		#endregion

        #endregion [ButtonList Event]

        #region [Control's Event]

        #region Control Get Focus시 구동 Event (Control_Enter)
        /// <remarks>
		/// Binding된 Grid가 있는 경우 Current Grid 세팅등도 해야함
		/// </remarks>
		private void Control_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;
		}
		#endregion

		#region Control Lost Focus시 구동 Event (Control_Leave)
		/// <remarks>
		/// </remarks>
		private void Control_Leave(object sender, System.EventArgs e)
		{
			if (sender == null) return;
		}
		#endregion

		#region Control Value변경시 처리 Event (Control_DataValidating)
		/// <remarks>
		/// Binding된 Grid가 있는 경우 Current Grid 세팅등도 해야함
		/// </remarks>
		private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{	
			if (sender == null) return;

			string mbxMsg = "", mbxCap = "";

			string colName = this.mComFunc.GetHashTableColumnName(sender); // 현재 매핑되는 컬럼명을 얻어온다

			string dataValue = e.DataValue.ToString().Trim();

			switch (colName)
			{
				case "nu_gubun": // 진료구분의 외래/입원 적용구분

					// 각종기준정보에서 코드명칭을 얻어온다
					//if (TypeCheck.IsNull(dataValue) || dataValue == "%") 
					//{
					//	this.dbxNu_Gubun_Name.SetDataValue("");
					//}
					//else 
					{
                        DataRow dRow = this.mComBiz.LoadIFS0002Info("IF_SKR_JINRYO_GUBUN", dataValue);

						if (dRow != null)
						{
							this.dbxNu_Gubun_Name.SetDataValue(dRow["code_name"]);
						}
						else
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT9 : Resources.TEXT10;
							mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);

							e.Cancel = true;

							return;							
						}
					}

					// 입력 코드로 데이타 조회
                    //grdMaster.QueryLayout(false);
                    this.btnList.PerformClick(FunctionType.Query);

					break;

				default:
					break;
			}
		}
		#endregion

		#region Control 더블클릭시 구동 Event (Control_DoubleClick)
		/// <remarks>
		/// </remarks>
		private void Control_DoubleClick(object sender, System.EventArgs e)
		{
			if (sender == null) return;
		}
		#endregion

		#region Control KeyDown Event (Control_KeyPress)
		/// <remarks>
		/// </remarks>
		private void Control_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (sender == null) return;		
		}
		#endregion

		#region Control Keyup Event (Control_KeyPress)
		/// <remarks>
		/// </remarks>
		private void Control_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (sender == null) return;		
		}
		#endregion

		#region Combo Control SelectIndexChanged시 구동 Event (Control_SelectedIndexChanged)
		/// <remarks>
		/// </remarks>
		private void Control_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (sender == null || (sender.GetType().Name.ToString().IndexOf("XComboBox") < 0 && sender.GetType().Name.ToString().IndexOf("XListBox") < 0)) return;
		}
		#endregion

		#region Check Control Check Changed시 구동 Event (Control_CheckedChanged)
		/// <remarks>
		/// </remarks>
		private void Control_CheckedChanged(object sender, System.EventArgs e)
		{
			if (sender == null || sender.GetType().Name.ToString().IndexOf("XCheckBox") < 0) return;
		}
		#endregion

		#region Find Control FindClick Event : Find SQL조건 및 필드 정의 (Control_FindClick)
		/// <remarks>
		/// </remarks>
		private void Control_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (sender == null || sender.GetType().Name.ToString().IndexOf("XFindBox") < 0) return;

			XFindBox fbx = sender as XFindBox;

			string colName = this.mComFunc.GetHashTableColumnName(sender);

            fbx.FindWorker = this.mComBiz.GetFindWorker(colName); // 컬럼별 Find 정보 얻기
		}
		#endregion

		#region Find Control FindSelected Event : Find 데이타 선택시 Value 세팅.. (Control_FindSelected)
		private void Control_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
		{
			if (sender == null || sender.GetType().Name.ToString().IndexOf("XFindBox") < 0) return;

			XFindBox fbx = sender as XFindBox;

			string colName = this.mComFunc.GetHashTableColumnName(sender);

			fbx.AcceptData(); // DataValidating Event에서 선택한 값에 대한 Validation / 정보 세팅 로직 처리함 		
		}
		#endregion

		#endregion

		#region [Master Grid Event]

		#region Focus 진입시 (Enter)
		/// <remarks>
		/// 빈 Grid시 New Row Insert
		/// </remarks>
		private void grdMaster_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;

			//Set Current Grid
			this.CurrMSLayout = grd; this.CurrMQLayout = grd;

			// 빈 Grid시 New Row Insert
			if (grd.RowCount == 0) this.btnList.PerformClick(FunctionType.Insert); // <= ButtonList 클릭 : 추후 PostEvent로 바꿀에정임.(사용자 클릭시 바로 Edit상태가 안되므로..)
		}
		#endregion

		#region 컬럼 Focus 이동시 (GridCellFocusChanged)	
		/// <remarks>
		/// 컬럼 Focus시 디폴트 값이나, 특정 컬럼이 미리 입력이 되어 있어야 되는 경우등 처리..
		/// </remarks>
		private void grdMaster_GridCellFocusChanged(object sender, IHIS.Framework.XGridCellFocusChangedEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;
		}
		#endregion

		#region Row 이동시 (RowFocusChanged)
		/// <remarks>
		/// </remarks>
		private void grdMaster_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		
		}
		#endregion

		#region 컬럼 값 변경시 (GridColumnChanged)
		/// <remarks>
		/// Validation Check, 추가 정보 세팅..
		/// </remarks>
		private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			string mbxMsg = "", mbxCap = "";

			object previousValue = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

			switch (e.ColName)
			{
				case "nu_code": // 코드형태
					string nu_code = e.ChangeValue.ToString().Trim();

					if (TypeCheck.IsNull(nu_code)) break;

					// 각종기준정보에서 코드타입명칭을 얻어온다 (기존 데이타 여부 확인)
                    //DataRow dRow = this.mComBiz.LoadIFS0004Info(nu_code);
                    DataRow dRow = this.mComBiz.LoadIFS0001Info(nu_code);

					if (dRow != null)
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT11 : Resources.TEXT12;
						mbxMsg = String.Format(mbxMsg, nu_code);
						mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);

						e.Cancel = true;

						return;
					}

					break;

				default:
					break;
			}
		}
		#endregion

		#region 필드 Protect관리 Event(GridColumnProtectModify)
		/// <remarks>
		/// 로직으로 수정불가 필드 정의
		/// </remarks>
		private void grdMaster_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		
		}
		#endregion

		#region  필드 색상/폰트 관리 Event  (GridCellPainting)
		/// <remarks>
		/// 로직으로 필드 색상 변경
		/// </remarks>
		private void grdMaster_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			// 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
			if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable && 
				(grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified))
			{
				e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
				e.BackColor = XColor.XGridAlterateRowBackColor.Color;
			}

		}
		#endregion

		#region 특수Key Input시 (ProcessKeyDown)
		/// <remarks>
		/// Last Row에서 Key Down시 Insert Row처리
		/// </remarks>
		private void grdMaster_ProcessKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;

			if (grd.FocusCell == null) return;

			switch (e.KeyCode)
			{

				case Keys.Down: // Key Down 입력시 Last Row인 경우 Insert Row를 수행함
					/*----------------------------------------------------------------------------------------------------------------
					 * KeyDown 구동안됨.. 일단 보류.
										if (grd.CurrentRowNumber == (grd.RowCount -1))
										{
											// Insert한 Row 중에 Not Null필드 미입력 Row Search하여 미입력 데이타가 없는 경우 Insert
											if (this.GetEmptyNewRow((XEditGrid)this.CurrMSLayout) < 0)
											{		
												this.btnList.PerformClick(FunctionType.Insert);

												// Edit 상태
												PostCallHelper.PostCall(new PostMethod(grd.StartEdit));
											}
										}
					----------------------------------------------------------------------------------------------------------------*/
					break;
			}
		}
		#endregion

		#endregion

		#region [Detail Grid Event]

		#region Focus 진입시 (Enter)
		/// <remarks>
		/// 빈 Grid시 New Row Insert
		/// </remarks>
		private void grdDetail_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		

			//Set Current Grid
			this.CurrMSLayout = grd; this.CurrMQLayout = grd;

			// 빈 Grid시 New Row Insert
			if (grd.RowCount == 0) this.btnList.PerformClick(FunctionType.Insert); // <= ButtonList 클릭 : 추후 PostEvent로 바꿀에정임.(사용자 클릭시 바로 Edit상태가 안되므로..)		
		}
		#endregion

		#region 컬럼 Focus 이동시 (GridCellFocusChanged)	
		/// <remarks>
		/// 컬럼 Focus시 디폴트 값이나, 특정 컬럼이 미리 입력이 되어 있어야 되는 경우등 처리..
		/// </remarks>
		private void grdDetail_GridCellFocusChanged(object sender, IHIS.Framework.XGridCellFocusChangedEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;
		}
		#endregion

		#region Row 이동시 (RowFocusChanged)
		/// <remarks>
		/// </remarks>
		private void grdDetail_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		
		}
		#endregion

		#region 컬럼 값 변경시 (GridColumnChanged)
		/// <remarks>
		/// Validation Check, 추가 정보 세팅..
		/// </remarks>
		private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{	
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			string mbxMsg = "", mbxCap = "";

			object previousValue = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

            //if (this.grdMaster.RowCount == 0 || 
            //    TypeCheck.IsNull(this.grdMaster.GetItemValue(this.grdMaster.CurrentRowNumber, "nu_code")))
            //{
            //    mbxMsg = NetInfo.Language == LangMode.Jr ?  "コードデータを入力しようとすればコード類型データを先に入力をしなければならないです." : 
            //        "코드데이타를 입력하시려면 코드유형 데이타를 먼저 입력을 해야 합니다.";
            //    mbxCap = NetInfo.Language == LangMode.Jr ? "確 認" : "확 인";

            //    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);

            //    e.Cancel = true;
            //    return;
            //}

            //string nu_code = this.grdMaster.GetItemValue(this.grdMaster.CurrentRowNumber, "nu_code").ToString();

            string cur_ymd = this.xDateYmd.GetDataValue();

			switch (e.ColName)
            {
                #region bun_code
                case "bun_code":        // 점수 분류코드
                    {
                        string code = e.ChangeValue.ToString().Trim();

                        if (TypeCheck.IsNull(code)) break;

                        string codeName = "";

                        if (code.Equals("%"))
                        {
                            codeName = Resources.TEXT13; 
                        }
                        else
                        {
                            this.mComBiz.LoadColumnCodeName(e.ColName, code, cur_ymd, ref codeName);
                        }

                        grd.SetItemValue(e.RowNumber, "bun_name", codeName.ToString());

                        //// 각종기준정보에서 코드명칭을 얻어온다 (기존 데이타 여부 확인)
                        ////DataRow dRow = this.mComBiz.LoadIFS0005Info(nu_code, code);
                        //DataRow dRow = this.mComBiz.LoadIFS0002Info(nu_code, code);

                        //if (dRow != null)
                        //{
                        //    mbxMsg = NetInfo.Language == LangMode.Jr ? "既存の登録データ[{0}]が　存在します. 確認してください." : "기존에 등록된 데이타[{0}]가 존재합니다. 확인바랍니다.";
                        //    mbxMsg = String.Format(mbxMsg, code);
                        //    mbxCap = NetInfo.Language == LangMode.Jr ? "確 認" : "확 인";
                        //    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);

                        //    e.Cancel = true;

                        //    return;
                        //}
                    }
                    break;
                #endregion bun_code

                #region sg_code
                case "sg_code":        // 점수 코드
                    {
                        string code = e.ChangeValue.ToString().Trim();

                        if (TypeCheck.IsNull(code)) break;

                        string codeName = "";

                        if (code.Equals("%"))
                        {
                            codeName = Resources.TEXT13;
                        }
                        else
                        {
                            this.mComBiz.LoadColumnCodeName(e.ColName, code, cur_ymd, ref codeName);
                        }

                        grd.SetItemValue(e.RowNumber, "sg_name", codeName.ToString());
                    }

                    break;

                #endregion sg_code

                default:
					break;
			}
		}
		#endregion

		#region 필드 Protect관리 Event(GridColumnProtectModify)
		/// <remarks>
		/// 로직으로 수정불가 필드 정의
		/// </remarks>
		private void grdDetail_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		
		}
		#endregion

		#region  필드 색상/폰트 관리 Event  (GridCellPainting)
		/// <remarks>
		/// 로직으로 필드 색상 변경
		/// </remarks>
		private void grdDetail_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			// 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
			if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable && 
				(grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified))
			{
				e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
				e.BackColor = XColor.XGridAlterateRowBackColor.Color;
			}
		}
		#endregion

		#region 특수Key Input시 (ProcessKeyDown)
		/// <remarks>
		/// Last Row에서 Key Down시 Insert Row처리
		/// </remarks>
		private void grdDetail_ProcessKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		

		}
		#endregion

        #region Find Click
        private void grdDetail_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            switch (e.ColName)
            {
                #region bun_code
                case "bun_code":
                    {
                        XFindBox fbx = grd.Controls["bun_code"] as XFindBox;

                        string cur_ymd = this.xDateYmd.GetDataValue();

                        fbx.FindWorker = this.mComBiz.GetFindWorker(e.ColName, cur_ymd);

                    }
                    break;
                #endregion bun_code

                #region sg_code
                case "sg_code":
                    {
                        XFindBox fbx = grd.Controls["sg_code"] as XFindBox;

                        string cur_ymd = this.xDateYmd.GetDataValue();

                        fbx.FindWorker = this.mComBiz.GetFindWorker(e.ColName, cur_ymd);

                    }
                    break;
                #endregion sg_code
            }
        }
        #endregion Find Click


        #endregion [Detail Grid Event]

        #region [Query Event]
        private void grdMaster_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
            grdMaster.SetBindVarValue("f_hosp_code", mHospCode);
            //
            grdMaster.SetBindVarValue("f_nu_gubun", this.fbxNu_Gubun.GetDataValue());
            grdMaster.SetBindVarValue("f_nu_ymd", this.xDateYmd.GetDataValue());
        }

		private void grdDetail_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
            grdDetail.SetBindVarValue("f_hosp_code", mHospCode);
            //
            grdDetail.SetBindVarValue("f_nu_gubun", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_gubun"));
            grdDetail.SetBindVarValue("f_nu_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_code"));
            grdDetail.SetBindVarValue("f_nu_ymd", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "nu_ymd"));
            grdDetail.SetBindVarValue("f_cur_ymd", this.xDateYmd.GetDataValue());
        }
		#endregion

		#region [Save Event]
		private void SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
		{
			switch(e.CallerID)
			{
				case '1':
					isgrdMasterSave = e.IsSuccess;
					isSavedMaster = true;
					break;
				case '2':
					isgrdDetailSave = e.IsSuccess;
					isSavedDetail = true;
					break;
			}

			if(isSavedMaster && isSavedDetail)
			{
				if(isgrdMasterSave && isgrdDetailSave)
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT14 : Resources.TEXT15;
					mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
					XMessageBox.Show(mbxMsg, mbxCap, 2);
				}
				else
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT16 : Resources.TEXT17;
					mbxMsg += "\r\n[" + e.ErrMsg + "]";
					mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Hand);
				}

				isgrdMasterSave = false;
				isSavedMaster = false;
				isgrdDetailSave = false;
				isSavedDetail = false;
			}
        }

        #endregion [Save Event]

        #region [XSavePerformer]
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private IFS0004U01 parent = null;

//            public XSavePerformer(IFS0004U01 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";

//                //item.BindVarList.Clear();
//                item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

//                switch(callerID)
//                {
//                    #region Master
//                    case '1':
//                        switch(item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO IFS0004 (
//								  	 	           SYS_DATE
//                                                 , SYS_ID
//                                                 , UPD_DATE
//                                                 , UPD_ID
//                                                 , HOSP_CODE
//                                                 , NU_GUBUN
//                                                 , NU_CODE
//                                                 , NU_YMD
//                                                 , NU_CODE_NAME
//		   				 	          ) VALUES (
//                                                   SYSDATE
//                                                 , :f_user_id
//                                                 , NULL
//                                                 , NULL
//                                                 , :f_hosp_code 
//                                                 , :f_nu_gubun
//                                                 , :f_nu_code
//                                                 , :f_nu_ymd
//                                                 , :f_nu_code_name
//                                      )";
//                                break;
//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE IFS0004 A
//                                               SET A.UPD_ID         = :f_user_id
//                                                 , A.UPD_DATE       = SYSDATE
//                                                 , A.NU_CODE_NAME   = :f_nu_code_name
//                                             WHERE A.HOSP_CODE      = :f_hosp_code
//                                               AND A.NU_GUBUN       = :f_nu_gubun
//                                               AND A.NU_CODE        = :f_nu_code
//                                               AND A.NU_YMD         = :f_nu_ymd
//                                          ";
//                                break;
//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE IFS0004 A
//                                             WHERE A.HOSP_CODE      = :f_hosp_code
//                                               AND A.NU_GUBUN       = :f_nu_gubun
//                                               AND A.NU_CODE        = :f_nu_code
//                                               AND A.NU_YMD         = :f_nu_ymd
//                                          ";
//                                break;
//                        }
//                        break;
//                    #endregion Master

//                    #region Detail
//                    case '2':
//                        switch(item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO IFS0005 (
//								  	 	           SYS_DATE
//                                                 , SYS_ID
//                                                 , UPD_DATE
//                                                 , UPD_ID
//                                                 , HOSP_CODE
//                                                 , NU_GUBUN
//                                                 , NU_CODE
//                                                 , NU_YMD
//                                                 , BUN_CODE
//                                                 , SG_CODE
//		   				 	          ) VALUES (
//                                                   SYSDATE
//                                                 , :f_user_id
//                                                 , NULL
//                                                 , NULL
//                                                 , :f_hosp_code 
//                                                 , :f_nu_gubun
//                                                 , :f_nu_code
//                                                 , :f_nu_ymd
//                                                 , :f_bun_code
//                                                 , :f_sg_code
//                                      )";
//                                break;
//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE IFS0005 A
//                                               SET A.UPD_ID         = :f_user_id
//                                                 , A.UPD_DATE       = SYSDATE
//                                                 , A.BUN_CODE       = :f_bun_code
//                                                 , A.SG_CODE        = :f_sg_code
//                                             WHERE A.HOSP_CODE      = :f_hosp_code
//                                               AND A.NU_GUBUN       = :f_nu_gubun
//                                               AND A.NU_CODE        = :f_nu_code
//                                               AND A.NU_YMD         = :f_nu_ymd
//                                          ";
//                                break;
//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE IFS0005 A
//                                             WHERE A.HOSP_CODE      = :f_hosp_code
//                                               AND A.NU_GUBUN       = :f_nu_gubun
//                                               AND A.NU_CODE        = :f_nu_code
//                                               AND A.NU_YMD         = :f_nu_ymd
//                                               AND A.BUN_CODE       = :f_bun_code
//                                               AND A.SG_CODE        = :f_sg_code
//                                          ";
//                                break;
//                        }
//                        break;
//                    #endregion Detail
//                }

//                return Service.ExecuteNonQuery(cmdText,item.BindVarList);
//            }
//        }
		#endregion
    }
}

