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
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Messaging;
using IHIS.Framework;
using IHIS.OCSA.Properties;
using OCS0801U00GrdOCS0801ListItemInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0801U00GrdOCS0801ListItemInfo;
using OCS0801U00GrdOCS0802ListItemInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0801U00GrdOCS0802ListItemInfo;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0801U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0801U00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		#endregion

		#region [Instance Variable]
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		private DataTable mLayDtBuffer       = null; // Answer Copy & Paste용 Buffer DataTable
        private string mHospCode = EnvironInfo.HospCode;
		
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XMstGrid grdOCS0801;
		private IHIS.Framework.XEditGrid grdOCS0802;
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
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0801U00()
        {
            /* SavePerformer 생성 */
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            //this.grdOCS0801.SavePerformer = new XSavePerformer(this);
            //this.grdOCS0802.SavePerformer = this.grdOCS0801.SavePerformer;
            ////저장 Layout List Set
            //this.SaveLayoutList.Add(this.grdOCS0801);
            //this.SaveLayoutList.Add(this.grdOCS0802);


			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리

            //set ParamList
            this.grdOCS0802.ParamList = new List<string>(new String[] { "f_pat_status" });

            //set ExecuteQuery
		    this.grdOCS0801.ExecuteQuery = LoadDataGrdOCS0801;
		    this.grdOCS0802.ExecuteQuery = LoadDataGrdOCS0802;
        }

	    #region CloudService

	    private List<object[]> LoadDataGrdOCS0801(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        OCS0801U00GrdOCS0801Args args = new OCS0801U00GrdOCS0801Args();
	        OCS0801U00GrdOCS0801Result result =
	            CloudService.Instance.Submit<OCS0801U00GrdOCS0801Result, OCS0801U00GrdOCS0801Args>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (OCS0801U00GrdOCS0801ListItemInfo item in result.ListItemInfo)
	            {
	                object[] objects =
	                {
	                    item.PatStatus,
	                    item.PatStatusName,
	                    item.Ment,
	                    item.Seq,
	                    item.RowSate
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        private List<object[]> LoadDataGrdOCS0802(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0801U00GrdOCS0802Args args = new OCS0801U00GrdOCS0802Args();
            args.PatStatus = bc["f_pat_status"] != null ? bc["f_pat_status"].VarValue : "";
            OCS0801U00GrdOCS0802Result result = CloudService.Instance.Submit<OCS0801U00GrdOCS0802Result, OCS0801U00GrdOCS0802Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0801U00GrdOCS0802ListItemInfo item in result.ListInfo)
                {
                    object[] objects = 
				{ 
					item.PatStatus, 
					item.PatStatusCode, 
					item.PatStatusName, 
					item.Ment, 
					item.Seq, 
					item.RowSate
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private bool SaveOCS0801U00()
        {
            List<OCS0801U00GrdOCS0801ListItemInfo> input_0801 = GetListFromGrd0801();
            List<OCS0801U00GrdOCS0802ListItemInfo> input_0802 = GetListFromGrd0802();
            if (input_0801.Count == 0 && input_0802.Count == 0)
            {
                return true;
            }
            OCS0801U00TransactionalArgs args = new OCS0801U00TransactionalArgs(input_0801, input_0802, UserInfo.UserID);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS0801U00TransactionalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (!result.Result)
                {
                    switch (result.Msg)
                    {
                        case "Added":
                            XMessageBox.Show(Resources.MSG009_MSG, Resources.MSG009_CAP, MessageBoxIcon.Error);
                            break;
                        case "Deleted":
                            XMessageBox.Show(Resources.MSG010_MSG, Resources.MSG010_CAP, MessageBoxIcon.Error);
                            break;
                        default:
                            break;
                    }
                }
                return result.Result;
            }

            return false;
        }

	    private List<OCS0801U00GrdOCS0802ListItemInfo> GetListFromGrd0802()
	    {
            List<OCS0801U00GrdOCS0802ListItemInfo> dataList = new List<OCS0801U00GrdOCS0802ListItemInfo>();
            for (int i = 0; i < grdOCS0802.RowCount; i++)
            {
                if (grdOCS0802.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                OCS0801U00GrdOCS0802ListItemInfo info = new OCS0801U00GrdOCS0802ListItemInfo();
                info.PatStatus = grdOCS0801.GetItemString(grdOCS0801.CurrentRowNumber, "pat_status");
                info.PatStatusCode = grdOCS0802.GetItemString(i, "pat_status_code");
                info.PatStatusName = grdOCS0802.GetItemString(i, "pat_status_code_name");
                info.Ment = grdOCS0802.GetItemString(i, "ment");
                info.Seq = grdOCS0802.GetItemString(i, "seq");
                info.RowSate = grdOCS0802.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdOCS0802.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0802.DeletedRowTable.Rows)
                {
                    OCS0801U00GrdOCS0802ListItemInfo info = new OCS0801U00GrdOCS0802ListItemInfo();
                    info.PatStatus = grdOCS0801.GetItemString(grdOCS0801.CurrentRowNumber, "pat_status");
                    info.PatStatusCode = row["pat_status_code"].ToString();
                    info.RowSate = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
	    }

	    private List<OCS0801U00GrdOCS0801ListItemInfo> GetListFromGrd0801()
	    {
	        List<OCS0801U00GrdOCS0801ListItemInfo> dataList = new List<OCS0801U00GrdOCS0801ListItemInfo>();
	        for (int i = 0; i < grdOCS0801.RowCount; i++)
	        {
	            if (grdOCS0801.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }

                OCS0801U00GrdOCS0801ListItemInfo info = new OCS0801U00GrdOCS0801ListItemInfo();
	            info.PatStatus = grdOCS0801.GetItemString(i, "pat_status");
                info.PatStatusName = grdOCS0801.GetItemString(i, "pat_status_name");
	            info.Ment = grdOCS0801.GetItemString(i, "ment");
	            info.Seq = grdOCS0801.GetItemString(i, "seq");
	            info.RowSate = grdOCS0801.GetRowState(i).ToString();

                dataList.Add(info);
	        }

	        if (grdOCS0801.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdOCS0801.DeletedRowTable.Rows)
	            {
                    OCS0801U00GrdOCS0801ListItemInfo info = new OCS0801U00GrdOCS0801ListItemInfo();
                    info.PatStatus = row["pat_status"].ToString();
	                info.RowSate = DataRowState.Deleted.ToString();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0801U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnPaste = new IHIS.Framework.XButton();
            this.pbxCopy = new IHIS.Framework.XPictureBox();
            this.btnCopy = new IHIS.Framework.XButton();
            this.grdOCS0801 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.grdOCS0802 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0801)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0802)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.btnPaste);
            this.xPanel1.Controls.Add(this.pbxCopy);
            this.xPanel1.Controls.Add(this.btnCopy);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnPaste
            // 
            this.btnPaste.AccessibleDescription = null;
            this.btnPaste.AccessibleName = null;
            resources.ApplyResources(this.btnPaste, "btnPaste");
            this.btnPaste.BackgroundImage = null;
            this.btnPaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaste.Font = null;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // pbxCopy
            // 
            this.pbxCopy.AccessibleDescription = null;
            this.pbxCopy.AccessibleName = null;
            resources.ApplyResources(this.pbxCopy, "pbxCopy");
            this.pbxCopy.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.pbxCopy.BackgroundImage = null;
            this.pbxCopy.Font = null;
            this.pbxCopy.ImageLocation = null;
            this.pbxCopy.Name = "pbxCopy";
            this.pbxCopy.Protect = false;
            this.pbxCopy.TabStop = false;
            this.pbxCopy.Click += new System.EventHandler(this.pbxCopy_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleDescription = null;
            this.btnCopy.AccessibleName = null;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.BackgroundImage = null;
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.Font = null;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // grdOCS0801
            // 
            this.grdOCS0801.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOCS0801, "grdOCS0801");
            this.grdOCS0801.ApplyPaintEventToAllColumn = true;
            this.grdOCS0801.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdOCS0801.ColPerLine = 2;
            this.grdOCS0801.Cols = 3;
            this.grdOCS0801.ExecuteQuery = null;
            this.grdOCS0801.FixedCols = 1;
            this.grdOCS0801.FixedRows = 2;
            this.grdOCS0801.FocusColumnName = "pat_status";
            this.grdOCS0801.HeaderHeights.Add(22);
            this.grdOCS0801.HeaderHeights.Add(0);
            this.grdOCS0801.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS0801.Name = "grdOCS0801";
            this.grdOCS0801.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0801.ParamList")));
            this.grdOCS0801.QuerySQL = "SELECT A.PAT_STATUS     ,\r\n       A.PAT_STATUS_NAME,\r\n       A.MENT           ,\r\n" +
                "       A.SEQ\r\n  FROM OCS0801 A\r\n WHERE A.HOSP_CODE = :f_hosp_code\r\n ORDER BY A.P" +
                "AT_STATUS";
            this.grdOCS0801.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0801.RowHeaderVisible = true;
            this.grdOCS0801.Rows = 3;
            this.grdOCS0801.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0801_GridColumnChanged);
            this.grdOCS0801.Enter += new System.EventHandler(this.grdOCS0801_Enter);
            this.grdOCS0801.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0801_GridCellPainting);
            this.grdOCS0801.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0801_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 2;
            this.xEditGridCell1.CellName = "pat_status";
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
            this.xEditGridCell2.CellName = "pat_status_name";
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
            // grdOCS0802
            // 
            this.grdOCS0802.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOCS0802, "grdOCS0802");
            this.grdOCS0802.ApplyPaintEventToAllColumn = true;
            this.grdOCS0802.CallerID = '2';
            this.grdOCS0802.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40});
            this.grdOCS0802.ColPerLine = 3;
            this.grdOCS0802.Cols = 4;
            this.grdOCS0802.EnableMultiSelection = true;
            this.grdOCS0802.ExecuteQuery = null;
            this.grdOCS0802.FixedCols = 1;
            this.grdOCS0802.FixedRows = 2;
            this.grdOCS0802.FocusColumnName = "pat_status_code";
            this.grdOCS0802.HeaderHeights.Add(22);
            this.grdOCS0802.HeaderHeights.Add(0);
            this.grdOCS0802.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdOCS0802.MasterLayout = this.grdOCS0801;
            this.grdOCS0802.Name = "grdOCS0802";
            this.grdOCS0802.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0802.ParamList")));
            this.grdOCS0802.QuerySQL = resources.GetString("grdOCS0802.QuerySQL");
            this.grdOCS0802.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0802.RowHeaderVisible = true;
            this.grdOCS0802.Rows = 3;
            this.grdOCS0802.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0802.SelectionModeChangeable = true;
            this.grdOCS0802.TogglingRowSelection = true;
            this.grdOCS0802.ToolTipActive = true;
            this.grdOCS0802.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0802_GridColumnChanged);
            this.grdOCS0802.Enter += new System.EventHandler(this.grdOCS0802_Enter);
            this.grdOCS0802.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0802_GridCellPainting);
            this.grdOCS0802.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0802_QueryStarting);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 2;
            this.xEditGridCell36.CellName = "pat_status";
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
            this.xEditGridCell37.CellLen = 2;
            this.xEditGridCell37.CellName = "pat_status_code";
            this.xEditGridCell37.CellWidth = 41;
            this.xEditGridCell37.Col = 1;
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
            this.xEditGridCell38.CellName = "pat_status_code_name";
            this.xEditGridCell38.CellWidth = 292;
            this.xEditGridCell38.Col = 2;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell38.IsNotNull = true;
            this.xEditGridCell38.Row = 1;
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
            this.xEditGridCell40.Col = 3;
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
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Font = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdOCS0801);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // OCS0801U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdOCS0802);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "OCS0801U00";
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0801)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0802)).EndInit();
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
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			//Set Current Grid
			this.CurrMSLayout = this.grdOCS0801;
			this.CurrMQLayout = this.grdOCS0801;

			//Set M/D Relation
			grdOCS0802.SetRelationKey("pat_status", "pat_status");

            if (!grdOCS0801.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
		}
		
		#endregion

		#region [Load Code Name]
        
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)    // e.ColName, e.ChangeValue
		{
			string codeName = "";

            string cmdQuery = "";
            object retValue = null;
            BindVarCollection bindQry = new BindVarCollection();
            bindQry.Add("f_code", code);
            bindQry.Add("f_hosp_code", mHospCode);

			if(code.Trim() == "" ) return codeName;

            OCS0801U00GetCodeNameArgs args = new OCS0801U00GetCodeNameArgs();
            OCS0801U00GetCodeNameResult result = new OCS0801U00GetCodeNameResult();

			switch (codeMode)
			{
				case "pat_status":

//                    cmdQuery = @"SELECT A.PAT_STATUS_NAME
//                                   FROM OCS0801 A
//                                  WHERE A.HOSP_CODE  = :f_hosp_code
//                                    AND A.PAT_STATUS = :f_code";
//                    retValue = Service.ExecuteScalar(cmdQuery, bindQry);

//                    if (!TypeCheck.IsNull(retValue))
//                    {
//                        codeName = retValue.ToString();
//                    }
//                    else
//                    {
//                        codeName = "";
//                    }

			        args.CodeMode = "pat_status";
			        args.Code = code;
			        result = CloudService.Instance.Submit<OCS0801U00GetCodeNameResult, OCS0801U00GetCodeNameArgs>(args);
			        if (result.ExecutionStatus == ExecutionStatus.Success && result.CodeName != "")
			        {
			            codeName = result.CodeName;
			        }
			        else
			        {
			            codeName = "";
			        }

					break;

				case "pat_status_code":

					string pat_status = grdOCS0802.GetItemString(grdOCS0802.CurrentRowNumber, "pat_status");
                    bindQry.Add("f_pat_status", pat_status);

					if(TypeCheck.IsNull(pat_status)) break;

//                    cmdQuery = @"SELECT A.PAT_STATUS_CODE_NAME
//                                   FROM OCS0802 A
//                                  WHERE A.HOSP_CODE       = :f_hosp_code
//                                    AND A.PAT_STATUS_CODE = :f_code
//                                    AND A.PAT_STATUS      = :f_pat_status";
//                    retValue = Service.ExecuteScalar(cmdQuery, bindQry);

//                    if (!TypeCheck.IsNull(retValue))
//                    {
//                        codeName = retValue.ToString();
//                    }
//                    else
//                    {
//                        codeName = "";
//                    }

                    args.CodeMode = "pat_status_code";
                    args.Code = code;
			        args.PatStatus = pat_status;
                    result = CloudService.Instance.Submit<OCS0801U00GetCodeNameResult, OCS0801U00GetCodeNameArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.CodeName != "")
                    {
                        codeName = result.CodeName;
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

		#region [grdOCS0801 Event]

		private void grdOCS0801_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			object previousValue   = grdOCS0801.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

			bool duple = false;

			switch (e.ColName)
			{
				case "pat_status":
                    
					if(e.ChangeValue.ToString().Trim() == "" ) break;
                    
					// 중복 Check
					// 현재 화면
					for(int i = 0; i < grdOCS0801.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0801.GetItemString(i, "pat_status").Trim() == e.ChangeValue.ToString().Trim() )
							{
                                mbxMsg = Resources.MSG001_MSG;
								mbxCap = "";
								XMessageBox.Show(mbxMsg, mbxCap);
								this.mOrderFunc.UndoPreviousValue(grdOCS0801, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.
								duple = true;
							}
						}
					} 

					if(duple) break;

					// Delete Table Check
					// 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
					bool deleted = false;
					if(grdOCS0801.DeletedRowTable != null)
					{
						foreach(DataRow row in grdOCS0801.DeletedRowTable.Rows)
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
						this.mOrderFunc.UndoPreviousValue(grdOCS0801, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.					
					}
					
					break;

				default:
					break;
			}
		
		}
        
		/// <summary>
		/// Master 삭제시 Detail정보 확인
		/// </summary>
		private void grdOCS0801_CheckDetailLayout(object sender, System.ComponentModel.CancelEventArgs e)
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

		private void grdOCS0801_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
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

		private void grdOCS0801_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;

			//Set Current Grid
			this.CurrMSLayout = grd; this.CurrMQLayout = grd;

			// 빈 Grid시 New Row Insert
			if (grd.RowCount == 0) this.xButtonList1.PerformClick(FunctionType.Insert); // <= ButtonList 클릭 : 추후 PostEvent로 바꿀에정임.(사용자 클릭시 바로 Edit상태가 안되므로..)		
		}

		#endregion

		#region [grdOCS0802 Event]

		private void grdOCS0802_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{	
			object previousValue   = grdOCS0802.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

			bool duple = false;

			switch (e.ColName)
			{
				case "pat_status_code":
                    
					if(e.ChangeValue.ToString().Trim() == "" ) break;
                    
					// 중복 Check
					// 현재 화면
					for(int i = 0; i < grdOCS0802.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0802.GetItemString(i, "pat_status").Trim() == e.ChangeValue.ToString().Trim() )
							{
								mbxMsg = Resources.MSG002_MSG;
								mbxCap = "";
								XMessageBox.Show(mbxMsg, mbxCap);
								this.mOrderFunc.UndoPreviousValue(grdOCS0802, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.	
								duple = true;
							}
						}
					} 

					if(duple) break;

					// Delete Table Check
					// 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
					bool deleted = false;
					if(grdOCS0802.DeletedRowTable != null)
					{
						foreach(DataRow row in grdOCS0802.DeletedRowTable.Rows)
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
					string pat_status_code_name = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

					if(pat_status_code_name != "")
					{
						mbxMsg = Resources.MSG003_MSG;
						mbxCap = "";
						XMessageBox.Show(mbxMsg, mbxCap);
						this.mOrderFunc.UndoPreviousValue(grdOCS0802, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.					
					}
					
					break;

				default:
					break;
			}
		}
		
		private void grdOCS0802_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
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

		private void grdOCS0802_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			
		}
		
		private void grdOCS0802_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;

			//Set Current Grid
			this.CurrMSLayout = grd; this.CurrMQLayout = grd;

			// 빈 Grid시 New Row Insert
			if (grd.RowCount == 0) this.xButtonList1.PerformClick(FunctionType.Insert); // <= ButtonList 클릭 : 추후 PostEvent로 바꿀에정임.(사용자 클릭시 바로 Edit상태가 안되므로..)		
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
						if(this.CurrMSLayout == grdOCS0801)
						{
							currentRow = grdOCS0801.InsertRow();
						}
						else if(this.CurrMSLayout == grdOCS0802)
						{	
							if( grdOCS0801.CurrentRowNumber < 0 ) return;
 
							currentRow = grdOCS0802.InsertRow();
							grdOCS0802.SetItemValue(currentRow, "pat_status", grdOCS0801.GetItemString(grdOCS0801.CurrentRowNumber, "pat_status"));	
							grdOCS0802.SetItemValue(currentRow, "seq", 99);	
						}
					}
					else
						((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
					
					break;

				
				case FunctionType.Update:

					if(SaveMethod())
					{
						mbxMsg = Resources.MSG004_MSG;
						SetMsg(mbxMsg);
                        //if (!grdOCS0802.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
					    grdOCS0801.QueryLayout(false);
					}
                    else
                    {
                        mbxMsg = Resources.MSG005_MSG;
                        mbxMsg = mbxMsg + Service.ErrFullMsg;
                        mbxCap = Resources.MSG005_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
                        return;
                    }

					break;

				case FunctionType.Delete:

					if(CurrMSLayout == grdOCS0801)
					{
						if(CheckDetailData(grdOCS0801))
						{
							mbxMsg = Resources.MSG006_MSG; 
							mbxCap = Resources.MSG006_CAP;
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

        #region [ SaveMethod ]
        private bool SaveMethod()
        {
            #region 저장전 Validation Check
            bool cancelFlag = false;

            CancelEventArgs ce = new CancelEventArgs(true);

            //grdOCS0801
            for (int rowIndex = 0; rowIndex < grdOCS0801.RowCount; rowIndex++)
            {
                if (grdOCS0801.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (TypeCheck.IsNull(grdOCS0801.GetItemString(rowIndex, "pat_status").Trim()))
                    {
                        grdOCS0801.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (TypeCheck.IsNull(grdOCS0801.GetItemString(rowIndex, "pat_status_name").Trim()))
                {
                    grdOCS0801.Focus();
                    grdOCS0801.SetFocusToItem(rowIndex, "pat_status_name");
                    cancelFlag = false;
                    break;
                }
            }

            if (cancelFlag)
            {
                ce.Cancel = true;
                return false;
            }

            string pat_status = grdOCS0801.GetItemString(grdOCS0801.CurrentRowNumber, "pat_status");

            //grdOCS0802
            for (int rowIndex = 0; rowIndex < grdOCS0802.RowCount; rowIndex++)
            {
                if (grdOCS0802.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    grdOCS0802.SetItemValue(rowIndex, "pat_status", pat_status);

                    //Key값이 없으면 삭제처리
                    if (TypeCheck.IsNull(grdOCS0802.GetItemString(rowIndex, "pat_status_code").Trim()))
                    {
                        grdOCS0802.DeleteRow(rowIndex);
                        rowIndex--;
                    }
                }

                if (TypeCheck.IsNull(grdOCS0802.GetItemString(rowIndex, "pat_status_code_name").Trim()))
                {
                    grdOCS0802.Focus();
                    grdOCS0802.SetFocusToItem(rowIndex, "pat_status_code_name");
                    cancelFlag = false;
                    break;
                }
            }

            if (cancelFlag)
            {
                ce.Cancel = true;
                return false;
            }
            #endregion

            //try
            //{
            //    Service.BeginTransaction();
            //    //if (!grdOCS0801.SaveLayout()) throw new Exception();
            //    if (!grdOCS0802.SaveLayout()) throw new Exception();
            //}
            //catch
            //{
            //    Service.RollbackTransaction();
            //    return false;
            //}
            //Service.CommitTransaction();
            //return true;

            return SaveOCS0801U00();
        }



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

			if (grdOCS0802.LayoutTable == null) return;

			bool isSelectedRow = false; // Select 여부 
			ArrayList selectedRow = new ArrayList();  // Selected Row's

			for (int i = 0; i < this.grdOCS0802.RowCount; i++)
			{
				if (this.grdOCS0802.IsSelectedRow(i) && this.grdOCS0802.IsVisibleRow(i)) // Select 여부 체크
				{					
					selectedRow.Add(i);
					isSelectedRow = true; 
				}
			}
			
			if (!isSelectedRow) 
			{
				mbxMsg = Resources.MSG007_MSG;

				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;			
			}

			this.pbxCopy.Visible = false; // 디폴트 Copy할 데이타 선택여부 False

			// DataTable 비워 있는 경우 테이블 구조 복제
			if (this.mLayDtBuffer == null) this.mLayDtBuffer = this.grdOCS0802.LayoutTable.Clone();

			this.mLayDtBuffer.Rows.Clear(); // Buffer DataTable Clear

			for (int i = 0; i < selectedRow.Count; i++)
			{
				this.mLayDtBuffer.ImportRow(this.grdOCS0802.LayoutTable.Rows[(int)selectedRow[i]]);
			}

			this.pbxCopy.Visible = true; // Copy할 데이타 선택여부 true
			this.grdOCS0802.UnSelectAll();
		}
		#endregion
		
		#region Answer Paste
		private void btnPaste_Click(object sender, System.EventArgs e)
		{
			if(grdOCS0801.CurrentRowNumber < 0) return;

			string mbxMsg = "", mbxCap = "";

			if (this.mLayDtBuffer == null || this.mLayDtBuffer.Rows.Count == 0) 
			{
				mbxMsg = Resources.MSG008_MSG;

				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;
			}

			foreach (DataRow row in this.mLayDtBuffer.Rows) 
			{
				row["pat_status"] = grdOCS0801.GetItemString(grdOCS0801.CurrentRowNumber, "pat_status");
				
				int insertRow = -1;
				insertRow = grdOCS0802.InsertRow(-1);
				foreach(XGridCell cell in this.grdOCS0802.CellInfos)
				{
					grdOCS0802.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);					
				}	
			}

			this.grdOCS0802.UnSelectAll();

		}
		#endregion

        #region 각 그리드에 바인드변수 설정
        private void grdOCS0801_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0801.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOCS0802_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0802.SetBindVarValue("f_pat_status", grdOCS0801.GetItemString(grdOCS0801.CurrentRowNumber, "pat_status"));
            grdOCS0802.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        bool flag = true;

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0801U00 parent = null;
            public XSavePerformer(OCS0801U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                // 중복 체크 변수
                string cmdDupChk = "";
                object retDupChk = null;

                //Grid에서 넘어온 Bind 변수에 q_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                if (!parent.flag)
                                {
                                    parent.flag = true;
                                    return false;
                                }
                                cmdDupChk = @"SELECT 'Y'
                                               FROM OCS0801
                                              WHERE PAT_STATUS = :f_pat_status
                                                AND HOSP_CODE  = :f_hosp_code
                                                AND ROWNUM     = 1";
                                retDupChk = Service.ExecuteScalar(cmdDupChk, item.BindVarList);
                                if (!TypeCheck.IsNull(retDupChk) && retDupChk.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show(Resources.MSG009_MSG, Resources.MSG009_CAP, MessageBoxIcon.Error);
                                    if (parent.flag == true) parent.flag = false;
                                    return false;
                                }
                                cmdText = @"INSERT INTO OCS0801
                                                   ( SYS_DATE           , SYS_ID     , UPD_DATE, PAT_STATUS    ,
                                                     PAT_STATUS_NAME    , MENT       , SEQ     , HOSP_CODE )
                                             VALUES
                                                   ( SYSDATE            , :q_user_id , SYSDATE , :f_pat_status ,
                                                     :f_pat_status_name , :f_ment    , :f_seq  , :f_hosp_code  )";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE OCS0801
                                               SET UPD_ID          = :q_user_id        ,
                                                   UPD_DATE        = SYSDATE           ,
                                                   PAT_STATUS_NAME = :f_pat_status_name,
                                                   MENT            = :f_ment           ,
                                                   SEQ             = :f_seq
                                             WHERE PAT_STATUS      = :f_pat_status
                                               AND HOSP_CODE       = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdDupChk = @"SELECT 'Y'
                                                FROM OCS0802
                                               WHERE PAT_STATUS = :f_pat_status
                                                 AND HOSP_CODE  = :f_hosp_code
                                                 AND ROWNUM     = 1";
                                retDupChk = Service.ExecuteScalar(cmdDupChk, item.BindVarList);
                                if (!TypeCheck.IsNull(retDupChk) && retDupChk.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show(Resources.MSG010_MSG, Resources.MSG010_CAP, MessageBoxIcon.Error);
                                    return false;
                                }
                                cmdText = @"DELETE OCS0801
                                             WHERE PAT_STATUS = :f_pat_status
                                               AND HOSP_CODE  = :f_hosp_code";
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                if (!parent.flag)
                                {
                                    parent.flag = true;
                                    return false;
                                }
                                cmdDupChk = @"SELECT 'Y'
                                                FROM OCS0802
                                               WHERE PAT_STATUS      = :f_pat_status
                                                 AND PAT_STATUS_CODE = :f_pat_status_code
                                                 AND HOSP_CODE       = :f_hosp_code
                                                 AND ROWNUM          = 1";
                                retDupChk = Service.ExecuteScalar(cmdDupChk, item.BindVarList);
                                if (!TypeCheck.IsNull(retDupChk) && retDupChk.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show(Resources.MSG009_MSG, Resources.MSG009_CAP, MessageBoxIcon.Error);
                                    if (parent.flag == true) parent.flag = false;
                                    return false;
                                }
                                cmdText = @"INSERT INTO OCS0802
                                                   ( SYS_DATE            , UPD_ID                  , UPD_DATE  , PAT_STATUS    ,
                                                     PAT_STATUS_CODE     , PAT_STATUS_CODE_NAME    , MENT      , SEQ           , HOSP_CODE)
                                             VALUES
                                                   ( SYSDATE             , :q_user_id              , SYSDATE   , :f_pat_status ,
                                                     :f_pat_status_code  , :f_pat_status_code_name , :f_ment   , :f_seq        , :f_hosp_code  )";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE OCS0802
                                               SET UPD_ID               = :q_user_id             ,
                                                   UPD_DATE             = SYSDATE                ,
                                                   PAT_STATUS_CODE_NAME = :f_pat_status_code_name,
                                                   MENT                 = :f_ment                ,
                                                   SEQ                  = :f_seq
                                             WHERE PAT_STATUS           = :f_pat_status
                                               AND PAT_STATUS_CODE      = :f_pat_status_code
                                               AND HOSP_CODE            = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE OCS0802
                                             WHERE PAT_STATUS      = :f_pat_status
                                               AND PAT_STATUS_CODE = :f_pat_status_code
                                               AND HOSP_CODE       = :f_hosp_code";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

    }
}

