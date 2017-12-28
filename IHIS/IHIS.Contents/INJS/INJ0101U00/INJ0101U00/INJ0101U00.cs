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
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Models.Injs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.INJS.Properties;
#endregion

namespace IHIS.INJS
{
	/// <summary>
	/// INJ0101U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INJ0101U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XMstGrid grdMaster;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XMstGrid grdDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public INJ0101U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

		    grdMaster.ExecuteQuery = LoadDataGrdMaster;

            grdDetail.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code_type"});
		    grdDetail.ExecuteQuery = LoadDataGrdDetail;
		}

	    private IList<object[]> LoadDataGrdDetail(BindVarCollection varlist)
	    {
            IList<object[]> dataList = new List<object[]>();
            INJ0101U00GrdDetailArgs args = new INJ0101U00GrdDetailArgs();
	        args.CodeType = varlist["f_code_type"].VarValue;
            INJ0101U00GrdDetailResult result =
                CloudService.Instance.Submit<INJ0101U00GrdDetailResult, INJ0101U00GrdDetailArgs>(args);
            if (result != null)
            {
                List<INJ0101U00GrdDetailInfo> grdList = result.ListItem;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (INJ0101U00GrdDetailInfo info in grdList)
                    {
                        dataList.Add(new object[]
	                    {
	                       info.CodeType,
                            info.Code,
                            info.CodeName
	                    });
                    }
                }
            }
            return dataList;
	    }

	    private IList<object[]> LoadDataGrdMaster(BindVarCollection varlist)
	    {
	        IList<object[]> dataList = new List<object[]>();
            INJ0101U00GrdMasterArgs args = new INJ0101U00GrdMasterArgs();
            INJ0101U00GrdMasterResult result =
                CloudService.Instance.Submit<INJ0101U00GrdMasterResult, INJ0101U00GrdMasterArgs>(args);
            if (result != null)
            {
                List<ComboListItemInfo> grdList = result.ListItem;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (ComboListItemInfo info in grdList)
                    {
                        dataList.Add(new object[]
	                    {
	                       info.Code,
                           info.CodeName
	                    });
                    }
                }
            }
	        return dataList;
	    }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ0101U00));
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdDetail = new IHIS.Framework.XMstGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 1;
            this.grdMaster.Cols = 2;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.FocusColumnName = "nut_no1";
            this.grdMaster.HeaderHeights.Add(21);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 119;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 30;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 402;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdDetail
            // 
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdDetail.ColPerLine = 2;
            this.grdDetail.Cols = 3;
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "code_type";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 4;
            this.xEditGridCell5.CellName = "code";
            this.xEditGridCell5.CellWidth = 117;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 50;
            this.xEditGridCell6.CellName = "code_name";
            this.xEditGridCell6.CellWidth = 327;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdDetail);
            this.xPanel1.Controls.Add(this.grdMaster);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // INJ0101U00
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            resources.ApplyResources(this, "$this");
            this.Name = "INJ0101U00";
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            //this.grdMaster.SavePerformer = new XSavePeformer(this);
            //this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            grdDetail.SetRelationKey("code_type", "code_type");
			grdDetail.SetRelationTable("INJ0102");

            this.grdMaster.QueryLayout(false);
		}

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
        }

        private string mMsg = "";
        private string mCap = "";
        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    if (this.CurrMQLayout == this.grdDetail)
                    {
                        if (this.grdMaster.RowCount > 0)
                        {
                            int rowNum = this.grdDetail.InsertRow(-1);
                            this.grdDetail.SetFocusToItem(rowNum, "code");
                        }
                    }
                    break;

                case FunctionType.Delete:

                    if (this.CurrMQLayout != this.grdDetail)
                    {
                        e.IsBaseCall = false;
                        return;
                    }
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    try
                    {
                        //Service.BeginTransaction();
                        //if (this.grdMaster.SaveLayout())
                        //{
                            //if (this.grdDetail.SaveLayout())
                            if (SaveGrdDetail())
                            {
                                this.mMsg =  Resource.INJ0101U00_save_OK ;

                                this.mCap = Resource.INJ0101U00_save_hh;

                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.xButtonList1.PerformClick(FunctionType.Query);

                            }
                            else
                                throw new Exception();
                        //}
                        //else
                        //    throw new Exception();

                        //Service.CommitTransaction();
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        this.mMsg =  Resource.INJ0101U00_XSAVE_TB ;

                        this.mMsg += "\r\n" + Service.ErrFullMsg;

                        this.mCap = Resource.INJ0101U00_XSAVE_TB;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    break;
            }
        }


	    private void grdMaster_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdDetail.QueryLayout(false);
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdMaster_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
//            string cmdText = @"SELECT 'Y' 
//                                  FROM DUAL 
//                                 WHERE EXISTS ( SELECT A.CODE_TYPE       
//                                                  FROM INJ0101 A
//                                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                                   AND A.CODE_TYPE = :f_code_type ) ";

            


            if (e.ChangeValue.ToString() == "")
                return;

            if (e.ColName == "code_type")
            {
                for (int i = 0; i < this.grdMaster.RowCount; i++)
                {
                    if (i == e.RowNumber)
                        continue;

                    if (this.grdMaster.GetItemString(i, e.ColName) == e.ChangeValue.ToString())
                    {
                        XMessageBox.Show(Resource.INJ0101U00_TEXT_DUPLICATE_MA, Resource.INJ0101U00_TEXT_CY, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                }


                //BindVarCollection bc = new BindVarCollection();

                //bc.Add("f_hosp_code", EnvironInfo.HospCode);
                //bc.Add("f_code_type", e.ChangeValue.ToString());

                //object dup_yn = Service.ExecuteScalar(cmdText, bc);

                //tungtx
                INJ0101U00GrdMasterGridColumnChangedArgs args =
                    new INJ0101U00GrdMasterGridColumnChangedArgs(e.ChangeValue.ToString());
                INJ0101U00GrdMasterGridColumnChangedResult result =
                    CloudService.Instance
                        .Submit<INJ0101U00GrdMasterGridColumnChangedResult, INJ0101U00GrdMasterGridColumnChangedArgs>(args);

                //if (!TypeCheck.IsNull(dup_yn))
                if (!TypeCheck.IsNull(result))
                {
                    //if (dup_yn.ToString() == "Y")
                    if (result.YValue == "Y")
                    {
                        bool isDup = true;
                        foreach (DataRow dr in grdMaster.DeletedRowTable.Rows)
                        {
                            if (dr["code_type"].ToString() == e.ChangeValue.ToString())
                                isDup = false;
                        }

                        if (isDup)
                        {

                            XMessageBox.Show(Resource.INJ0101U00_TEXT_DUPLICATE_MA, Resource.INJ0101U00_TEXT_CY, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
        }

        private void grdDetail_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
//            string cmdText = @"SELECT 'Y' 
//                                  FROM DUAL 
//                                 WHERE EXISTS ( SELECT A.CODE       
//                                                  FROM INJ0102 A 
//                                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                                   AND A.CODE_TYPE = :f_code_type
//                                                   AND A.CODE      = :f_code     ) ";

            if (e.ChangeValue.ToString() == "")
                return;

            if (e.ColName == "code")
            {
                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    if (i == e.RowNumber)
                        continue;

                    if (this.grdDetail.GetItemString(i, e.ColName) == e.ChangeValue.ToString())
                    {
                        XMessageBox.Show(Resource.INJ0101U00_TEXT_DUPLICATE_MA, Resource.INJ0101U00_TEXT_CY, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                }


                //BindVarCollection bc = new BindVarCollection();

                //bc.Add("f_hosp_code", EnvironInfo.HospCode);
                //bc.Add("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
                //bc.Add("f_code", e.ChangeValue.ToString());

                //object dup_yn = Service.ExecuteScalar(cmdText, bc);

                //tungtx
                INJ0101U00GrdDetailGridColumnChangedArgs args =
                    new INJ0101U00GrdDetailGridColumnChangedArgs(this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"), e.ChangeValue.ToString());
                INJ0101U00GrdDetailGridColumnChangedResult result =
                    CloudService.Instance
                        .Submit<INJ0101U00GrdDetailGridColumnChangedResult, INJ0101U00GrdDetailGridColumnChangedArgs>(args);

                //if (!TypeCheck.IsNull(dup_yn))
                if (!TypeCheck.IsNull(result))
                {
                    //if (dup_yn.ToString() == "Y")
                    if (result.YValue == "Y")
                    {
                        bool isDup = true;
                        foreach (DataRow dr in grdDetail.DeletedRowTable.Rows)
                        {
                            if (dr["code_type"].ToString() == this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"))
                            {
                                if (dr["code"].ToString() == e.ChangeValue.ToString())
                                    isDup = false;
                            }
                        }

                        if (isDup)
                        {

                            XMessageBox.Show(Resource.INJ0101U00_TEXT_DUPLICATE_MA, Resource.INJ0101U00_TEXT_CY, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
        }

        private bool SaveGrdDetail()
        {
            List<INJ0101U00GrdDetailInfo> inputList = GetListFromGrdDetail();
            if (inputList.Count == 0)
            {
                return true;
            }

            INJ0101U00GrdDetailSaveLayoutArgs args = new INJ0101U00GrdDetailSaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, INJ0101U00GrdDetailSaveLayoutArgs>(args);
            if (result == null)
            {
                return false;
            }
            return result.Result;
        }

	    private List<INJ0101U00GrdDetailInfo> GetListFromGrdDetail()
	    {
	        List<INJ0101U00GrdDetailInfo> dataList = new List<INJ0101U00GrdDetailInfo>();
	        for (int i = 0; i < grdDetail.RowCount; i++)
	        {
	            if (grdDetail.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }

                if (TypeCheck.IsNull(grdDetail.GetItemString(i, "code")))
                {
                    throw new Exception(Resource.MSG_REQ);
                }

	            INJ0101U00GrdDetailInfo info = new INJ0101U00GrdDetailInfo();
	            info.Code = grdDetail.GetItemString(i, "code");
	            info.CodeName = grdDetail.GetItemString(i, "code_name");
                //info.CodeType = grdDetail.GetItemString(i, "code_type");
	            info.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
	            info.RowState = grdDetail.GetRowState(i).ToString();
                dataList.Add(info);
	        }

	        if (grdDetail.DeletedRowTable != null && grdDetail.DeletedRowTable.Rows.Count > 0)
	        {
	            foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
	            {
                    INJ0101U00GrdDetailInfo info = new INJ0101U00GrdDetailInfo();
	                info.Code = row["code"].ToString();
                    info.CodeName = row["code_name"].ToString();
                    info.CodeType = row["code_type"].ToString();
	                info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
	            }
	        }

	        return dataList;
	    }

	    #region XSavePeformer
//        private class XSavePeformer : ISavePerformer
//        {
//            private INJ0101U00 parent = null;

//            public XSavePeformer(INJ0101U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerId, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_chk = "";

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                switch (callerId)
//                {
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO INJ0101 
//                                                 ( SYS_DATE,        SYS_ID,            UPD_DATE,     UPD_ID,    HOSP_CODE ,
//                                                   CODE_TYPE,       CODE_TYPE_NAME ) 
//                                            VALUES 
//                                                 ( SYSDATE,         :q_user_id,        SYSDATE,      :q_user_id, :f_hosp_code,
//                                                   :f_code_type,    :f_code_type_name)";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE INJ0101
//                                               SET UPD_ID         = :q_user_id
//                                                 , UPD_DATE       = SYSDATE
//                                                 , CODE_TYPE_NAME = :f_code_type_name
//                                             WHERE HOSP_CODE      = :f_hosp_code 
//                                               AND CODE_TYPE      = :f_code_type";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE INJ0101
//                                             WHERE HOSP_CODE      = :f_hosp_code 
//                                               AND CODE_TYPE = :f_code_type";

//                                break;
//                        }
//                        break;

//                    case '2':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO INJ0102 (
//                                                  SYS_DATE,        SYS_ID,       UPD_DATE,    UPD_ID,    HOSP_CODE,
//                                                  CODE_TYPE,       CODE,         CODE_NAME
//                                                ) VALUES (
//                                                  SYSDATE,         :q_user_id,   SYSDATE,     :q_user_id, :f_hosp_code,
//                                                  :f_code_type,    :f_code,      :f_code_name)";
//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE INJ0102
//                                               SET UPD_ID    = :q_user_id
//                                                 , UPD_DATE  = SYSDATE
//                                                 , CODE_NAME = :f_code_name
//                                             WHERE HOSP_CODE = :f_hosp_code 
//                                               AND CODE_TYPE = :f_code_type
//                                               AND CODE      = :f_code";
//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE INJ0102
//                                             WHERE HOSP_CODE = :f_hosp_code 
//                                               AND CODE_TYPE = :f_code_type
//                                               AND CODE      = :f_code";
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

