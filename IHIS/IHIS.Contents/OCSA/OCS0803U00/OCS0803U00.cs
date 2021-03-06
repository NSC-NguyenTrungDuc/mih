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
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
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
	/// OCS0803U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0803U00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		#endregion

		#region [Instance Variable]
		//Message처리
		string mbxMsg = "", mbxCap = "";
        string mHospCode = EnvironInfo.HospCode;

		private DataTable mLayDtBuffer       = null; // Answer Copy & Paste용 Buffer DataTable		
		
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XMstGrid grdOCS0803;
		private IHIS.Framework.XEditGrid grdOCS0804;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPictureBox pbxCopy;
		private IHIS.Framework.XButton btnPaste;
		private IHIS.Framework.XButton btnCopy;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0803U00()
		{
            // 이 호출은 Windows Form 디자이너에 필요합니다.

            /* SavePerformer 생성 */
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            //this.grdOCS0803.SavePerformer = new XSavePerformer(this);
            //this.grdOCS0804.SavePerformer = this.grdOCS0803.SavePerformer;
            ////저장 Layout List Set
            //this.SaveLayoutList.Add(this.grdOCS0803);
            //this.SaveLayoutList.Add(this.grdOCS0804);


			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리

            //set Paramlist
            this.grdOCS0804.ParamList = new List<string>(new String[] { "f_pat_status_gr" });

            //set ExecuteQuery
		    this.grdOCS0804.ExecuteQuery = LoadDataGrdOCS0804;
		    this.grdOCS0803.ExecuteQuery = LoadDataGrdOCS0803;
		}

	    #region CloudService

        private IList<object[]> LoadFdwCommonCase2(BindVarCollection varlist)
        {
            string pat_status = grdOCS0804.GetItemString(grdOCS0804.CurrentRowNumber, "pat_status");
            List<object[]> res = new List<object[]>();
            OCS0803U00GetFindWorkerArgs args = new OCS0803U00GetFindWorkerArgs();
            args.FindMode = "break_pat_status_code";
            args.PatStatus = pat_status;
            OCS0803U00GetFindWorkerResult result = CloudService.Instance.Submit<OCS0803U00GetFindWorkerResult, OCS0803U00GetFindWorkerArgs>(args);
            if (result != null)
            {
                foreach (ComboListItemInfo item in result.FindWorker)
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

        private IList<object[]> LoadFdwCommonCase1(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            OCS0803U00GetFindWorkerArgs args = new OCS0803U00GetFindWorkerArgs();
            args.FindMode = "pat_status";
            
            OCS0803U00GetFindWorkerResult result = CloudService.Instance.Submit<OCS0803U00GetFindWorkerResult, OCS0803U00GetFindWorkerArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.FindWorker)
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
        /// get data for grdOCS0804
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private List<object[]> LoadDataGrdOCS0804(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        OCS0803U00grdOCS0804Args args = new OCS0803U00grdOCS0804Args();
	        args.PatStatusGr = bc["f_pat_status_gr"] != null ? bc["f_pat_status_gr"].VarValue : "";
	        OCS0803U00grdOCS0804Result result =
	            CloudService.Instance.Submit<OCS0803U00grdOCS0804Result, OCS0803U00grdOCS0804Args>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (OCS0803U00grdOCS0804ItemInfo item in result.ItemInfo)
	            {
	                object[] objects =
	                {
	                    item.PatStatusGr,
	                    item.PatStatus,
	                    item.PatStatusName,
	                    item.IndispensableYn,
	                    item.BreakPatStatusCode,
	                    item.PatStatusCodeName,
	                    item.Ment,
	                    item.Seq,
	                    item.RowState
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// get data for grdOCS0803
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdOCS0803(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0803U00grdOCS0803Args args = new OCS0803U00grdOCS0803Args();
            OCS0803U00grdOCS0803Result result = CloudService.Instance.Submit<OCS0803U00grdOCS0803Result, OCS0803U00grdOCS0803Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0803U00grdOCS0803ItemInfo item in result.ItemInfo)
                {
                    object[] objects = 
				{ 
					item.PatStatusGr, 
					item.PatStatusGrName, 
					item.Ment, 
					item.Seq, 
					item.RowState
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataLayOutCombo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0803U00CreateComboArgs args = new OCS0803U00CreateComboArgs();
            OCS0803U00CreateComboResult result = CloudService.Instance.Submit<OCS0803U00CreateComboResult, OCS0803U00CreateComboArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboListItem)
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

        private bool SaveOCS0803U00()
        {
            List<OCS0803U00grdOCS0803ItemInfo> input_0803 = GetListOCS0803FromGrid();
            List<OCS0803U00grdOCS0804ItemInfo> input_0804 = GetListOCS0804FromGrid();
            if (input_0803.Count == 0 && input_0804.Count == 0)
            {
                return true;
            }
            OCS0803U00ExecuteArgs args = new OCS0803U00ExecuteArgs(input_0804, input_0803, UserInfo.UserID);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS0803U00ExecuteArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }

            return false;
        }

	    private List<OCS0803U00grdOCS0804ItemInfo> GetListOCS0804FromGrid()
	    {
            List<OCS0803U00grdOCS0804ItemInfo> dataList = new List<OCS0803U00grdOCS0804ItemInfo>();
            for (int i = 0; i < grdOCS0804.RowCount; i++)
            {
                if (grdOCS0804.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                OCS0803U00grdOCS0804ItemInfo info = new OCS0803U00grdOCS0804ItemInfo();
                info.PatStatusGr = grdOCS0803.GetItemString(grdOCS0803.CurrentRowNumber, "pat_status_gr");
                info.PatStatus = grdOCS0804.GetItemString(i, "pat_status");
                info.PatStatusName = grdOCS0804.GetItemString(i, "pat_status_name");
                info.IndispensableYn = grdOCS0804.GetItemString(i, "indispensable_yn");
                info.BreakPatStatusCode = grdOCS0804.GetItemString(i, "break_pat_status_code");
                info.PatStatusCodeName = grdOCS0804.GetItemString(i, "pat_status_code_name");
                info.Ment = grdOCS0804.GetItemString(i, "ment");
                info.Seq = grdOCS0804.GetItemString(i, "seq");
                info.RowState = grdOCS0804.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdOCS0804.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0804.DeletedRowTable.Rows)
                {
                    OCS0803U00grdOCS0804ItemInfo info = new OCS0803U00grdOCS0804ItemInfo();
                    info.PatStatusGr = grdOCS0803.GetItemString(grdOCS0803.CurrentRowNumber, "pat_status_gr");
                    info.PatStatus = row["pat_status"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
	    }

	    private List<OCS0803U00grdOCS0803ItemInfo> GetListOCS0803FromGrid()
	    {
	        List<OCS0803U00grdOCS0803ItemInfo> dataList = new List<OCS0803U00grdOCS0803ItemInfo>();
	        for (int i = 0; i < grdOCS0803.RowCount; i++)
	        {
	            if (grdOCS0803.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }
                OCS0803U00grdOCS0803ItemInfo info = new OCS0803U00grdOCS0803ItemInfo();
	            info.PatStatusGr = grdOCS0803.GetItemString(i, "pat_status_gr");
                info.PatStatusGrName = grdOCS0803.GetItemString(i, "pat_status_gr_name");
                info.Ment = grdOCS0803.GetItemString(i, "ment");
	            info.Seq = grdOCS0803.GetItemString(i, "seq");
	            info.RowState = grdOCS0803.GetRowState(i).ToString();

                dataList.Add(info);
	        }

	        if (grdOCS0803.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdOCS0803.DeletedRowTable.Rows)
	            {
                    OCS0803U00grdOCS0803ItemInfo info = new OCS0803U00grdOCS0803ItemInfo();
                    info.PatStatusGr = row["pat_status_gr"].ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0803U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnPaste = new IHIS.Framework.XButton();
            this.pbxCopy = new IHIS.Framework.XPictureBox();
            this.btnCopy = new IHIS.Framework.XButton();
            this.grdOCS0803 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.grdOCS0804 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0803)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0804)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.btnPaste);
            this.xPanel1.Controls.Add(this.pbxCopy);
            this.xPanel1.Controls.Add(this.btnCopy);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnPaste
            // 
            this.btnPaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            resources.ApplyResources(this.btnPaste, "btnPaste");
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // pbxCopy
            // 
            this.pbxCopy.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            resources.ApplyResources(this.pbxCopy, "pbxCopy");
            this.pbxCopy.Name = "pbxCopy";
            this.pbxCopy.Protect = false;
            this.pbxCopy.TabStop = false;
            this.pbxCopy.Click += new System.EventHandler(this.pbxCopy_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // grdOCS0803
            // 
            this.grdOCS0803.AddedHeaderLine = 1;
            this.grdOCS0803.ApplyPaintEventToAllColumn = true;
            this.grdOCS0803.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdOCS0803.ColPerLine = 2;
            this.grdOCS0803.Cols = 3;
            resources.ApplyResources(this.grdOCS0803, "grdOCS0803");
            this.grdOCS0803.ExecuteQuery = null;
            this.grdOCS0803.FixedCols = 1;
            this.grdOCS0803.FixedRows = 2;
            this.grdOCS0803.FocusColumnName = "pat_status_gr";
            this.grdOCS0803.HeaderHeights.Add(34);
            this.grdOCS0803.HeaderHeights.Add(0);
            this.grdOCS0803.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS0803.Name = "grdOCS0803";
            this.grdOCS0803.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0803.ParamList")));
            this.grdOCS0803.QuerySQL = "SELECT A.PAT_STATUS_GR     ,\r\n       A.PAT_STATUS_GR_NAME,\r\n       A.MENT        " +
                "      ,\r\n       A.SEQ\r\n  FROM OCS0803 A\r\n WHERE A.HOSP_CODE  = :f_hosp_code\r\n OR" +
                "DER BY A.PAT_STATUS_GR";
            this.grdOCS0803.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0803.RowHeaderVisible = true;
            this.grdOCS0803.Rows = 3;
            this.grdOCS0803.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0803_GridColumnChanged);
            this.grdOCS0803.Enter += new System.EventHandler(this.grdOCS0803_Enter);
            this.grdOCS0803.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0803_GridCellPainting);
            this.grdOCS0803.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0803_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 2;
            this.xEditGridCell1.CellName = "pat_status_gr";
            this.xEditGridCell1.CellWidth = 53;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.Row = 1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "pat_status_gr_name";
            this.xEditGridCell2.CellWidth = 274;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.Row = 1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 200;
            this.xEditGridCell3.CellName = "ment";
            this.xEditGridCell3.CellWidth = 72;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "seq";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 235;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 53;
            // 
            // grdOCS0804
            // 
            this.grdOCS0804.AddedHeaderLine = 1;
            this.grdOCS0804.ApplyPaintEventToAllColumn = true;
            this.grdOCS0804.CallerID = '2';
            this.grdOCS0804.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell39,
            this.xEditGridCell40});
            this.grdOCS0804.ColPerLine = 6;
            this.grdOCS0804.Cols = 7;
            resources.ApplyResources(this.grdOCS0804, "grdOCS0804");
            this.grdOCS0804.EnableMultiSelection = true;
            this.grdOCS0804.ExecuteQuery = null;
            this.grdOCS0804.FixedCols = 1;
            this.grdOCS0804.FixedRows = 2;
            this.grdOCS0804.FocusColumnName = "pat_status";
            this.grdOCS0804.HeaderHeights.Add(34);
            this.grdOCS0804.HeaderHeights.Add(0);
            this.grdOCS0804.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdOCS0804.MasterLayout = this.grdOCS0803;
            this.grdOCS0804.Name = "grdOCS0804";
            this.grdOCS0804.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0804.ParamList")));
            this.grdOCS0804.QuerySQL = resources.GetString("grdOCS0804.QuerySQL");
            this.grdOCS0804.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0804.RowHeaderVisible = true;
            this.grdOCS0804.Rows = 3;
            this.grdOCS0804.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0804.SelectionModeChangeable = true;
            this.grdOCS0804.TogglingRowSelection = true;
            this.grdOCS0804.ToolTipActive = true;
            this.grdOCS0804.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0804_GridColumnChanged);
            this.grdOCS0804.Enter += new System.EventHandler(this.grdOCS0804_Enter);
            this.grdOCS0804.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS0804_GridFindClick);
            this.grdOCS0804.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0804_GridCellPainting);
            this.grdOCS0804.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0804_QueryStarting);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 2;
            this.xEditGridCell36.CellName = "pat_status_gr";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsNotNull = true;
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AutoTabDataSelected = true;
            this.xEditGridCell37.CellLen = 2;
            this.xEditGridCell37.CellName = "pat_status";
            this.xEditGridCell37.CellWidth = 41;
            this.xEditGridCell37.Col = 1;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell37.IsNotNull = true;
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.Row = 1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 100;
            this.xEditGridCell38.CellName = "pat_status_name";
            this.xEditGridCell38.CellWidth = 239;
            this.xEditGridCell38.Col = 2;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell38.IsNotNull = true;
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.Row = 1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 1;
            this.xEditGridCell5.CellName = "indispensable_yn";
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AutoTabDataSelected = true;
            this.xEditGridCell6.CellLen = 2;
            this.xEditGridCell6.CellName = "break_pat_status_code";
            this.xEditGridCell6.CellWidth = 65;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 100;
            this.xEditGridCell7.CellName = "pat_status_code_name";
            this.xEditGridCell7.CellWidth = 139;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 200;
            this.xEditGridCell39.CellName = "ment";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellLen = 2;
            this.xEditGridCell40.CellName = "seq";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.CellWidth = 40;
            this.xEditGridCell40.Col = 6;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.RowSpan = 2;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 1;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 41;
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOCS0803);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // OCS0803U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.grdOCS0804);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0803U00";
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0803)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0804)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		#region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			return base.Command (command, commandParam);
		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            
			CreateCombo();

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			//Set Current Grid
			this.CurrMSLayout = this.grdOCS0803;
			this.CurrMQLayout = this.grdOCS0803;

			//Set M/D Relation
			grdOCS0804.SetRelationKey("pat_status_gr", "pat_status_gr");

            if (!this.grdOCS0803.QueryLayout(false)) XMessageBox.Show(Service.ErrMsg);
		}
		
		#endregion

		#region [Combo 생성]
		
		private void CreateCombo()
		{
            IHIS.Framework.MultiLayout layoutCombo;
            layoutCombo = new MultiLayout();

			//필수조건
			layoutCombo.Reset();
			layoutCombo.LayoutItems.Clear();
			layoutCombo.LayoutItems.Add("code", DataType.String);
			layoutCombo.LayoutItems.Add("code_name", DataType.String);
			layoutCombo.InitializeLayoutTable();

//            layoutCombo.QuerySQL = @"SELECT CODE
//                                          , CODE_NAME
//                                       FROM OCS0132
//                                      WHERE HOSP_CODE = :f_hosp_code
//                                        AND CODE_TYPE = 'INDISPENSABLE_YN'
//                                        AND CODE <> 'Z'     -- 注意「주의 사용처 불분명...」
//                                      ORDER BY CODE";
//            layoutCombo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
		    layoutCombo.ExecuteQuery = LoadDataLayOutCombo;

            if (!layoutCombo.QueryLayout(false)) XMessageBox.Show(Service.ErrMsg);
            else
            {
                grdOCS0804.SetListItems("indispensable_yn", layoutCombo.LayoutTable, "code_name", "code");
            }
		}
		#endregion

		#region [Load Code Name]
        
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";

            string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_code", code);
            bindVars.Add("f_hosp_code", mHospCode);
            object retVal = null;

			if(code.Trim() == "" ) return codeName;

			switch (codeMode)
			{
				case "pat_status_gr":

//                    cmdText = @"SELECT A.PAT_STATUS_GR_NAME
//                                  FROM OCS0803 A
//                                 WHERE A.HOSP_CODE     = :f_hosp_code
//                                   AND A.PAT_STATUS_GR = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVars);
//                    if (!TypeCheck.IsNull(retVal))
//                    {
//                        codeName = retVal.ToString();
//                    }
//                    else
//                    {
//                        codeName = "";
//                    }

                    OCS0803U00GetCodeNameArgs args1 = new OCS0803U00GetCodeNameArgs();
			        args1.CodeMode = "pat_status_gr";
			        args1.Code = code;
			        OCS0803U00GetCodeNameResult result1 =
			            CloudService.Instance.Submit<OCS0803U00GetCodeNameResult, OCS0803U00GetCodeNameArgs>(args1);
			        if (result1.ExecutionStatus == ExecutionStatus.Success && result1.CodeName != "")
			        {
			            codeName = result1.CodeName;
			        }
			        else
			        {
                        codeName = "";
			        }

					break;

				case "pat_status":

//                    cmdText = @"SELECT A.PAT_STATUS_NAME
//                                  FROM OCS0801 A
//                                 WHERE A.HOSP_CODE   = :f_hosp_code
//                                   AND A.PAT_STATUS  = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVars);
//                    if (!TypeCheck.IsNull(retVal))
//                    {
//                        codeName = retVal.ToString();
//                    }
//                    else
//                    {
//                        codeName = "";
//                    }

                    OCS0803U00GetCodeNameArgs args2 = new OCS0803U00GetCodeNameArgs();
                    args2.CodeMode = "pat_status";
                    args2.Code = code;
                    OCS0803U00GetCodeNameResult result2 =
                        CloudService.Instance.Submit<OCS0803U00GetCodeNameResult, OCS0803U00GetCodeNameArgs>(args2);
                    if (result2.ExecutionStatus == ExecutionStatus.Success && result2.CodeName != "")
                    {
                        codeName = result2.CodeName;
                    }
                    else
                    {
                        codeName = "";
                    }

					break;

				case "break_pat_status_code":

					string pat_status = grdOCS0804.GetItemString(grdOCS0804.CurrentRowNumber, "pat_status");
                    bindVars.Add("f_pat_status", pat_status);

					if(TypeCheck.IsNull(pat_status)) break;
                                       
//                    cmdText = @"SELECT A.PAT_STATUS_CODE_NAME
//                                  FROM OCS0802 A
//                                 WHERE A.HOSP_CODE       = :f_hosp_code
//                                   AND A.PAT_STATUS      = :f_pat_status
//                                   AND A.PAT_STATUS_CODE = :f_code";
//                    retVal = Service.ExecuteScalar(cmdText, bindVars);
//                    if (!TypeCheck.IsNull(retVal))
//                    {
//                        codeName = retVal.ToString();
//                    }
//                    else
//                    {
//                        codeName = "";
//                    }

                    OCS0803U00GetCodeNameArgs args3 = new OCS0803U00GetCodeNameArgs();
                    args3.CodeMode = "break_pat_status_code";
                    args3.Code = code;
			        args3.PatStatus = pat_status;
                    OCS0803U00GetCodeNameResult result3 =
                        CloudService.Instance.Submit<OCS0803U00GetCodeNameResult, OCS0803U00GetCodeNameArgs>(args3);
                    if (result3.ExecutionStatus == ExecutionStatus.Success && result3.CodeName != "")
                    {
                        codeName = result3.CodeName;
                    }
                    else
                    {
                        codeName = "";
                    }

					break;
				
				default:
					break;
			}

			return codeName;
		}

		#endregion

		#region [GetFindWorker]

		private XFindWorker GetFindWorker(string findMode)
		{
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
			
			switch (findMode)
			{	
				case "pat_status":
                    
					fdwCommon.AutoQuery = true;	
					fdwCommon.ServerFilter = false;
                    //fdwCommon.InputSQL =  "SELECT A.PAT_STATUS, A.PAT_STATUS_NAME "   
                    //                    + "  FROM OCS0801 A "
                    //                    + " WHERE A.HOSP_CODE  = '" + mHospCode + "'"
                    //                    + " ORDER BY A.PAT_STATUS ";
			        fdwCommon.ExecuteQuery = LoadFdwCommonCase1;
                    
					fdwCommon.FormText = Resources.FDWCOMMON_FORMTEXT_1;
					fdwCommon.ColInfos.Add("pat_status", Resources.FDWCOMMON_PAT_STATUS_TEXT_1, FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("pat_status_name", Resources.FDWCOMMON_PAT_STATUS_NAME_TEXT_1, FindColType.String, 300, 0, true, FilterType.Yes);

					break;
			    
				case "break_pat_status_code":

                    //string pat_status = grdOCS0804.GetItemString(grdOCS0804.CurrentRowNumber, "pat_status");
                    
					fdwCommon.AutoQuery = true;
					fdwCommon.ServerFilter = false;
                    //fdwCommon.InputSQL =  "SELECT A.PAT_STATUS_CODE, A.PAT_STATUS_CODE_NAME "   
                    //                    + "  FROM OCS0802 A "
                    //                    + " WHERE A.HOSP_CODE  = '" + mHospCode + "' "
                    //                    + "   AND A.PAT_STATUS      = '" + pat_status + "' "
                    //                    + " ORDER BY NVL(A.SEQ, 99), A.PAT_STATUS_CODE ";

                    fdwCommon.ExecuteQuery = LoadFdwCommonCase2;
                                    
					fdwCommon.FormText = Resources.FDWCOMMON_FORMTEXT_2;
					fdwCommon.ColInfos.Add("pat_status_code"     , Resources.FDWCOMMON_PAT_STATUS_CODE_TEXT_2, FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("pat_status_code_name", Resources.FDWCOMMON_PAT_STATUS_CODE_NAME_TEXT_2, FindColType.String, 300, 0, true, FilterType.No);

					break;
			    
				default:
					
					break;
			}

			return fdwCommon;
		}



	    #endregion

		#region [grdOCS0803 Event]

		private void grdOCS0803_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			object previousValue   = grdOCS0803.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

			bool duple = false;

			switch (e.ColName)
			{
				case "pat_status_gr":
                    
					if(e.ChangeValue.ToString().Trim() == "" ) break;
                    
					// 중복 Check
					// 현재 화면
					for(int i = 0; i < grdOCS0803.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0803.GetItemString(i, "pat_status_gr").Trim() == e.ChangeValue.ToString().Trim() )
							{
								mbxMsg = Resources.MSG001_MSG;
								mbxCap = "";
								XMessageBox.Show(mbxMsg, mbxCap);
								this.mOrderFunc.UndoPreviousValue(grdOCS0803, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.
								duple = true;
							}
						}
					} 

				    if(duple) break;

					// Delete Table Check
					// 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
					bool deleted = false;
					if(grdOCS0803.DeletedRowTable != null)
					{
						foreach(DataRow row in grdOCS0803.DeletedRowTable.Rows)
						{
							if(row[e.ColName].ToString() == e.ChangeValue.ToString())
							{
								deleted = true;
								break;
							}
						}
					}

					if(deleted) break;
                    
					//Check Origin Data
					string pat_status_name = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

					if(pat_status_name != "")
					{
						mbxMsg = Resources.MSG001_MSG;
						mbxCap = "";
						XMessageBox.Show(mbxMsg, mbxCap);
						this.mOrderFunc.UndoPreviousValue(grdOCS0803, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.					
					}
					
					break;

				default:
					break;
			}
		
		}
        
		/// <summary>
		/// Master 삭제시 Detail정보 확인
		/// </summary>
		private void grdOCS0803_CheckDetailLayout(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XMstGrid mstGrid = sender as XMstGrid;

			if (mstGrid.CurrentRowNumber < 0) return;
			
			int chk = 0;

			try
			{
				foreach( object obj in this.Controls )
				{
					if( obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
					{	
						chk = chk + ((XGrid)obj).RowCount;						
					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XEditGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XEditGrid)obj).DeletedRowCount;

					}
					else if( obj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XMstGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XMstGrid)obj).DeletedRowCount;
					}
					else if( obj.GetType().Name.ToString().IndexOf("XPanel") >= 0  )
					{
						foreach( object panObj in ((XPanel)obj).Controls )
						{
							if( panObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)panObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)panObj).RowCount;						
							}
							else if( panObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)panObj).DeletedRowCount;

							}
							else if( panObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)panObj).DeletedRowCount;
							}							
						}
					}
				}
			}
			catch {}

			if(chk > 0)
			{				
				e.Cancel = true;
			}
			else
				e.Cancel = false;
		
		}

		private void grdOCS0803_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;	

			// 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
			if ( (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable && e.DataRow.RowState != DataRowState.Added ) ||
				((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly ) 
			{
				//e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
				e.BackColor = XColor.XDisplayBoxBackColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
			}		
		
		}

		private void grdOCS0803_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;

			//Set Current Grid
			this.CurrMSLayout = grd; this.CurrMQLayout = grd;

			// 빈 Grid시 New Row Insert
			if (grd.RowCount == 0) this.xButtonList1.PerformClick(FunctionType.Insert); // <= ButtonList 클릭 : 추후 PostEvent로 바꿀에정임.(사용자 클릭시 바로 Edit상태가 안되므로..)		
		}

		#endregion

		#region [grdOCS0804 Event]

		private void grdOCS0804_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{	
			object previousValue   = grdOCS0804.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value
			bool duple = false;

			switch (e.ColName)
			{
				case "pat_status":
				    
					if(TypeCheck.IsNull(e.ChangeValue.ToString().Trim())) 
					{
						grdOCS0804.SetItemValue(e.RowNumber, "pat_status_name", "");
						break;
					}
                    
					// 중복 Check
					// 현재 화면
					for(int i = 0; i < grdOCS0803.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0804.GetItemString(i, "pat_status").Trim() == e.ChangeValue.ToString().Trim() )
							{
								mbxMsg = Resources.MSG002_MSG;
								mbxCap = "";
								XMessageBox.Show(mbxMsg, mbxCap);
								this.mOrderFunc.UndoPreviousValue(grdOCS0803, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.		
								duple = true;
							}
						}
					} 

					if(duple) break;
                    
					//Check Origin Data
					string pat_status_name = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

					if( TypeCheck.IsNull(pat_status_name) )
					{
						mbxMsg = Resources.MSG003_MSG;
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

						this.mOrderFunc.UndoPreviousValue(grdOCS0804, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.										
					}
					else
						grdOCS0804.SetItemValue(e.RowNumber, "pat_status_name", pat_status_name);
					
					break;
				
				case "break_pat_status_code":
                    
					if(TypeCheck.IsNull(e.ChangeValue.ToString().Trim())) 
					{
						grdOCS0804.SetItemValue(e.RowNumber, "pat_status_code_name", "");
						break;
					}
                    
					//Check Origin Data
					string pat_status_code_name = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

					if( TypeCheck.IsNull(pat_status_code_name) )
					{
						mbxMsg = Resources.MSG003_MSG;
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

						this.mOrderFunc.UndoPreviousValue(grdOCS0804, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.	
					}
					else
						grdOCS0804.SetItemValue(e.RowNumber, "pat_status_code_name", pat_status_code_name);
					
					break;

				default:
					break;
			}
		}

		private void grdOCS0804_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

			switch (e.ColName)
			{
				case "pat_status":            // 환자상태관리항목

					((XFindBox)((XEditGridCell)grdOCS0804.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.GetFindWorker(e.ColName);

					break;


				case "break_pat_status_code": // 오더중지 Answer 코드

					((XFindBox)((XEditGridCell)grdOCS0804.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.GetFindWorker(e.ColName);

					break;

				default:

					break;
			}
		
		}
		
		
		private void grdOCS0804_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;	

			// 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
			if ( (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable && e.DataRow.RowState != DataRowState.Added ) ||
				((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly ) 
			{
				//e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
				e.BackColor = XColor.XDisplayBoxBackColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
			}		
			
		}

		private void grdOCS0804_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			
		}
		
		private void grdOCS0804_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;

			//Set Current Grid
			this.CurrMSLayout = grd; this.CurrMQLayout = grd;

			// 빈 Grid시 New Row Insert
			if (grd.RowCount == 0) this.xButtonList1.PerformClick(FunctionType.Insert); // <= ButtonList 클릭 : 추후 PostEvent로 바꿀에정임.(사용자 클릭시 바로 Edit상태가 안되므로..)		
		}

		#endregion

		#region [상병중복 check]

		private bool CheckDoubleSang_code(string sang_code)
		{
			bool checkDuble = false;
			//중복 Check
			for(int i = 0; i < grdOCS0804.RowCount; i++)
			{
				if(i != grdOCS0804.CurrentRowNumber )
				{
					if( grdOCS0804.GetItemString(i, "sang_code").Trim() == sang_code )
					{
						mbxMsg = Resources.MSG004_MSG + sang_code + "]";
						mbxCap = Resources.MSG004_CAP;
						XMessageBox.Show(mbxMsg, mbxCap);
						checkDuble= true;
						break;
					}
				}
			} 

			return checkDuble;

		}


		#endregion
        
		#region [Button List Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:

					e.IsBaseCall = false;
					
					DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

					if(chkCell.RowNumber < 0)
					{
						int currentRow = -1;
						if(this.CurrMSLayout == grdOCS0803)
						{
							currentRow = grdOCS0803.InsertRow();
						}
						else if(this.CurrMSLayout == grdOCS0804)
						{	
							if( grdOCS0803.CurrentRowNumber < 0 ) return;
 
							currentRow = grdOCS0804.InsertRow();
							grdOCS0804.SetItemValue(currentRow, "pat_status_gr", grdOCS0803.GetItemString(grdOCS0803.CurrentRowNumber, "pat_status_gr"));	
							grdOCS0804.SetItemValue(currentRow, "indispensable_yn", "N");	
							grdOCS0804.SetItemValue(currentRow, "seq", 99);	
						}
					}
					else
						((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
					
					break;

				
				case FunctionType.Update:

					if(SaveMethod())
					{
						mbxMsg = Resources.MSG005_MSG;
						SetMsg(mbxMsg);
                        //if (!grdOCS0804.QueryLayout(false)) XMessageBox.Show(Service.ErrMsg);
					    grdOCS0803.QueryLayout(false);
					}
					else
					{
						mbxMsg = Resources.MSG006_MSG; 
						mbxMsg = mbxMsg + Service.ErrMsg;
						mbxCap = Resources.MSG006_CAP;
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
					}

					break;

				case FunctionType.Delete:

					if(CurrMSLayout == grdOCS0803)
					{
						if(CheckDetailData(grdOCS0803))
						{
							mbxMsg = Resources.MSG007_MSG; 
							mbxCap = Resources.MSG007_CAP;
							XMessageBox.Show(mbxMsg, mbxCap);
							e.IsBaseCall = false;
						}
					}

					break;
					

				default:

					break;
			}	
		
		}

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:

					
					break;

				default:

					break;
			}	
		
		}
		#endregion
		

		#region [SaveMethod ]

		/// <summary>
		/// 저장전 Validation Check
		/// </summary>
        private bool SaveMethod()
        {
            CancelEventArgs ce = new CancelEventArgs();

            #region 저장전 Validation Check
            bool cancelFlag = false;

            //grdOCS0803
            for (int rowIndex = 0; rowIndex < grdOCS0803.RowCount; rowIndex++)
            {
                if (grdOCS0803.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (TypeCheck.IsNull(grdOCS0803.GetItemString(rowIndex, "pat_status_gr").Trim()))
                    {
                        grdOCS0803.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (TypeCheck.IsNull(grdOCS0803.GetItemString(rowIndex, "pat_status_gr_name").Trim()))
                {
                    grdOCS0803.Focus();
                    grdOCS0803.SetFocusToItem(rowIndex, "pat_status_gr_name");
                    cancelFlag = false;
                    break;
                }
            }

            if (cancelFlag)
            {
                ce.Cancel = true;
                return false;
            }

            string pat_status_gr = grdOCS0803.GetItemString(grdOCS0803.CurrentRowNumber, "pat_status_gr");

            //grdOCS0804
            for (int rowIndex = 0; rowIndex < grdOCS0804.RowCount; rowIndex++)
            {
                if (grdOCS0804.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    grdOCS0804.SetItemValue(rowIndex, "pat_status_gr", pat_status_gr);

                    //Key값이 없으면 삭제처리
                    if (TypeCheck.IsNull(grdOCS0804.GetItemString(rowIndex, "pat_status_name").Trim()))
                    {
                        grdOCS0804.DeleteRow(rowIndex);
                        rowIndex--;
                    }
                }
            }
            #endregion

            //try
            //{
            //    Service.BeginTransaction();
            //    if (!grdOCS0804.SaveLayout()) throw new Exception();
            //}
            //catch
            //{
            //    Service.RollbackTransaction();
            //    return false;
            //}
            //Service.CommitTransaction();
            //return true;

		    return SaveOCS0803U00();
        }



	    //private void dsvSave_ServiceStart(object sender, IHIS.Framework.ServiceStartEventArgs e)
        //{
        //    AcceptData();

        //    bool cancelFlag = false;

        //    //grdOCS0803
        //    for(int rowIndex = 0; rowIndex < grdOCS0803.RowCount; rowIndex++)
        //    {
        //        if(grdOCS0803.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
        //        {
        //            //Key값이 없으면 삭제처리
        //            if( TypeCheck.IsNull(grdOCS0803.GetItemString(rowIndex, "pat_status_gr").Trim()) )
        //            {
        //                grdOCS0803.DeleteRow(rowIndex);
        //                rowIndex = rowIndex - 1;
        //                continue;
        //            }
        //        }

        //        if( TypeCheck.IsNull(grdOCS0803.GetItemString(rowIndex, "pat_status_gr_name").Trim()) )
        //        {
        //            grdOCS0803.Focus();
        //            grdOCS0803.SetFocusToItem( rowIndex, "pat_status_gr_name");
        //            cancelFlag = false;
        //            break;
        //        }
        //    }

        //    if(cancelFlag)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }

        //    string pat_status_gr = grdOCS0803.GetItemString(grdOCS0803.CurrentRowNumber, "pat_status_gr");

        //    //grdOCS0804
        //    for(int rowIndex = 0; rowIndex < grdOCS0804.RowCount; rowIndex++)
        //    {
        //        if(grdOCS0804.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
        //        {
        //            grdOCS0804.SetItemValue(rowIndex, "pat_status_gr", pat_status_gr);

        //            //Key값이 없으면 삭제처리
        //            if( TypeCheck.IsNull(grdOCS0804.GetItemString(rowIndex, "pat_status_name").Trim()) )
        //            {
        //                grdOCS0804.DeleteRow(rowIndex);
        //                rowIndex--;						
        //            }
        //        }	
        //    }
		
        //}

		#endregion

		#region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
		/// <summary>
		/// Insert한 Row 중에 Not Null필드 미입력 Row Search
		/// </summary>
		/// <remarks>
		/// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
		private DataGridCell GetEmptyNewRow(object aGrd)
		{
			DataGridCell celReturn = new DataGridCell(-1, -1);

			if (aGrd == null) return celReturn;

			XEditGrid grdChk = null;
            
			try
			{
				grdChk = (XEditGrid)aGrd;
			}
			catch
			{
				return celReturn;
			}

			foreach (XEditGridCell cell in grdChk.CellInfos)
			{
				// NotNull Check
				if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly) 
				{
					for( int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
					{
						if(grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
						{
							celReturn.ColumnNumber = cell.Col;
							celReturn.RowNumber   = rowIndex;
							break;
						}
					}

					if(celReturn.RowNumber < 0) 
						continue;
					else
						break;
				}

			}

			return celReturn;
		}
		#endregion
	
		#region [Detail Data존재여부 check]

		/// <summary>
		/// Detail Data 존재여부를 check합니다.
		/// </summary>
		private bool CheckDetailData(object aGrd)
		{
			bool returnValue = false;

			if (aGrd == null) return returnValue;

			XMstGrid mstGrid = null;
            
			try
			{
				mstGrid = (XMstGrid)aGrd;
			}
			catch
			{
				return returnValue;
			}

			int chk = 0;

			try
			{
				foreach( object obj in this.Controls )
				{
					if( obj.GetType().Name.ToString().IndexOf("Panel") >= 0 )
					{
						foreach( object panObj in ((Panel)obj).Controls )
						{
							if( panObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)panObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)panObj).RowCount;						
							}
							else if( panObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)panObj).DeletedRowCount;

							}
							else if( panObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)panObj).DeletedRowCount;
							}
						}
					}
					else if( obj.GetType().Name.ToString().IndexOf("GroupBox") >= 0 )
					{
						foreach( object gbxObj in ((GroupBox)obj).Controls )
						{						
							if( gbxObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)gbxObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)gbxObj).RowCount;						
							}
							else if( gbxObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)gbxObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)gbxObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)gbxObj).DeletedRowCount;

							}
							else if( gbxObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)gbxObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)gbxObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)gbxObj).DeletedRowCount;
							}
						}
					}
					else if( obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
					{	
						chk = chk + ((XGrid)obj).RowCount;						
					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XEditGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XEditGrid)obj).DeletedRowCount;

					}
					else if( obj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XMstGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XMstGrid)obj).DeletedRowCount;
					}
				}
			}
			catch {}

			if(chk > 0)							
				returnValue = true;

			return returnValue;
		}

		#endregion

		#region Answer Copy
		private void pbxCopy_Click(object sender, System.EventArgs e)
		{
			if (this.btnCopy != null) this.btnCopy.PerformClick();
		}
		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			string mbxMsg = "", mbxCap = "";

			if (grdOCS0804.LayoutTable == null) return;

			bool isSelectedRow = false; // Select 여부 
			ArrayList selectedRow = new ArrayList();  // Selected Row's

			for (int i = 0; i < this.grdOCS0804.RowCount; i++)
			{
				if (this.grdOCS0804.IsSelectedRow(i) && this.grdOCS0804.IsVisibleRow(i)) // Select 여부 체크
				{					
					selectedRow.Add(i);
					isSelectedRow = true; 
				}
			}
			
			if (!isSelectedRow) 
			{
				mbxMsg = Resources.MSG008_MSG;

				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;			
			}

			this.pbxCopy.Visible = false; // 디폴트 Copy할 데이타 선택여부 False

			// DataTable 비워 있는 경우 테이블 구조 복제
			if (this.mLayDtBuffer == null) this.mLayDtBuffer = this.grdOCS0804.LayoutTable.Clone();

			this.mLayDtBuffer.Rows.Clear(); // Buffer DataTable Clear

			for (int i = 0; i < selectedRow.Count; i++)
			{
				this.mLayDtBuffer.ImportRow(this.grdOCS0804.LayoutTable.Rows[(int)selectedRow[i]]);
			}

			this.pbxCopy.Visible = true; // Copy할 데이타 선택여부 true
			this.grdOCS0804.UnSelectAll();
		}
		#endregion
		
		#region Answer Paste
		private void btnPaste_Click(object sender, System.EventArgs e)
		{
			if(grdOCS0803.CurrentRowNumber < 0) return;

			string mbxMsg = "", mbxCap = "";

			if (this.mLayDtBuffer == null || this.mLayDtBuffer.Rows.Count == 0) 
			{
				mbxMsg = Resources.MSG009_MSG;

				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;
			}

			foreach (DataRow row in this.mLayDtBuffer.Rows) 
			{
				row["pat_status_gr"] = grdOCS0803.GetItemString(grdOCS0803.CurrentRowNumber, "pat_status_gr");
				
				int insertRow = -1;
				insertRow = grdOCS0804.InsertRow(-1);
				foreach(XGridCell cell in this.grdOCS0804.CellInfos)
				{
					grdOCS0804.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);					
				}	
			}

			this.grdOCS0804.UnSelectAll();

		}
		#endregion

        #region 각 그리드의 바인드변수 설정
        private void grdOCS0803_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0803.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOCS0804_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0804.SetBindVarValue("f_pat_status_gr", grdOCS0803.GetItemString(grdOCS0803.CurrentRowNumber, "pat_status_gr"));
            grdOCS0804.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion


        #region XSavePerformer
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private OCS0803U00 parent = null;
//            public XSavePerformer(OCS0803U00 parent)
//            {
//                this.parent = parent;
//            }
//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                string chkDupl = "";
//                object retDupl = null;
//                //Grid에서 넘어온 Bind 변수에 q_user_id SET
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

//                switch (callerID)
//                {
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                chkDupl = @"SELECT 'Y'
//                                              FROM OCS0803
//                                             WHERE PAT_STATUS_GR = :f_pat_status_gr
//                                               AND HOSP_CODE     = :f_hosp_code
//                                               AND ROWNUM        = 1";
//                                retDupl = Service.ExecuteScalar(cmdText, item.BindVarList);
//                                if (!TypeCheck.IsNull(retDupl) && retDupl.ToString().Equals("Y"))
//                                {
//                                    XMessageBox.Show(Resources.MSG010_MSG, Resources.MSG010_CAP);
//                                    return false;
//                                }

//                                cmdText = @"INSERT INTO OCS0803
//                                                   ( SYS_DATE              , SYS_ID     , PAT_STATUS_GR    ,
//                                                     PAT_STATUS_GR_NAME    , MENT       , SEQ              , HOSP_CODE)
//                                             VALUES
//                                                   ( SYSDATE               , :q_user_id , :f_pat_status_gr ,
//                                                     :f_pat_status_gr_name , :f_ment    , :f_seq           , :f_hosp_code)";
//                                break;
//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE OCS0803
//                                               SET UPD_ID             = :q_user_id           ,
//                                                   UPD_DATE           = SYSDATE              ,
//                                                   PAT_STATUS_GR_NAME = :f_pat_status_gr_name,
//                                                   MENT               = :f_ment              ,
//                                                   SEQ                = :f_seq
//                                             WHERE PAT_STATUS_GR      = :f_pat_status_gr
//                                               AND HOSP_CODE          = :f_hosp_code";
//                                break;
//                            case DataRowState.Deleted:
//                                chkDupl = @"SELECT 'Y'
//                                              FROM OCS0804
//                                             WHERE PAT_STATUS_GR = :f_pat_status_gr
//                                               AND HOSP_CODE     = :f_hosp_code
//                                               AND ROWNUM = 1";
//                                retDupl = Service.ExecuteScalar(cmdText, item.BindVarList);
//                                if (!TypeCheck.IsNull(retDupl) && retDupl.ToString().Equals("Y"))
//                                {
//                                    XMessageBox.Show(Resources.MSG011_MSG, Resources.MSG011_CAP);
//                                    return false;
//                                }

//                                cmdText = @"DELETE OCS0803
//                                             WHERE PAT_STATUS_GR   = :f_pat_status_gr
//                                               AND HOSP_CODE       = :f_hosp_code";
//                                break;
//                        }
//                        break;

//                    case '2':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                chkDupl = @"SELECT 'Y'
//                                              FROM OCS0804
//                                             WHERE PAT_STATUS_GR  = :f_pat_status_gr
//                                               AND PAT_STATUS     = :f_pat_status
//                                               AND HOSP_CODE      = :f_hosp_code
//                                               AND ROWNUM = 1";
//                                retDupl = Service.ExecuteScalar(cmdText, item.BindVarList);
//                                if (!TypeCheck.IsNull(retDupl) && retDupl.ToString().Equals("Y"))
//                                {
//                                    XMessageBox.Show(Resources.MSG010_MSG, Resources.MSG010_CAP);
//                                    return false;
//                                }

//                                cmdText = @"INSERT INTO OCS0804
//                                                   ( SYS_DATE       , SYS_ID              , PAT_STATUS_GR ,
//                                                     PAT_STATUS     , INDISPENSABLE_YN    , BREAK_PAT_STATUS_CODE    , MENT    ,
//                                                     SEQ            , HOSP_CODE)
//                                             VALUES
//                                                   ( SYSDATE        , :q_user_id          , :f_pat_status_gr   ,
//                                                     :f_pat_status  , :f_indispensable_yn , :f_break_pat_status_code , :f_ment ,
//                                                     :f_seq         , :f_hosp_code  )";
//                                break;
//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE OCS0804
//                                               SET UPD_ID                = :q_user_id              ,
//                                                   UPD_DATE              = SYSDATE                 ,
//                                                   INDISPENSABLE_YN      = :f_indispensable_yn     ,
//                                                   BREAK_PAT_STATUS_CODE = :f_break_pat_status_code,
//                                                   MENT                  = :f_ment                 ,
//                                                   SEQ                   = :f_seq
//                                             WHERE PAT_STATUS_GR         = :f_pat_status_gr
//                                               AND PAT_STATUS            = :f_pat_status
//                                               AND HOSP_CODE             = :f_hosp_code";
//                                break;
//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE OCS0804
//                                             WHERE PAT_STATUS_GR = :f_pat_status_gr
//                                               AND PAT_STATUS    = :f_pat_status
//                                               AND HOSP_CODE     = :f_hosp_code";
//                                break;
//                        }
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion
	}
}

