#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IFC.BASS;
using IFC.BASS.Properties;
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
	/// BAS0230U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0230U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGrid grdBAS0230;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDatePicker dtpBunYMD;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.MultiLayout dsvQueryBunCode;

		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0230U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            // Create ParamList and ExecuteQuery
            this.grdBAS0230.ParamList = new List<string>(new String[] { "f_start_ymd" });
		    this.grdBAS0230.ExecuteQuery = ExecuteQueryGrdBas0230;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0230U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dtpBunYMD = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grdBAS0230 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.dsvQueryBunCode = new IHIS.Framework.MultiLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0230)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsvQueryBunCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dtpBunYMD);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // dtpBunYMD
            // 
            resources.ApplyResources(this.dtpBunYMD, "dtpBunYMD");
            this.dtpBunYMD.Name = "dtpBunYMD";
            this.dtpBunYMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBunYMD_KeyDown);
            this.dtpBunYMD.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpBunYMD_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // grdBAS0230
            // 
            this.grdBAS0230.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3});
            this.grdBAS0230.ColPerLine = 3;
            this.grdBAS0230.Cols = 3;
            resources.ApplyResources(this.grdBAS0230, "grdBAS0230");
            this.grdBAS0230.ExecuteQuery = null;
            this.grdBAS0230.FixedRows = 1;
            this.grdBAS0230.HeaderHeights.Add(23);
            this.grdBAS0230.Name = "grdBAS0230";
            this.grdBAS0230.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0230.ParamList")));
            this.grdBAS0230.Rows = 2;
            this.grdBAS0230.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBunCode_GridColumnChanged);
            this.grdBAS0230.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grd_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 2;
            this.xEditGridCell1.CellName = "bun_code";
            this.xEditGridCell1.CellWidth = 66;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 30;
            this.xEditGridCell2.CellName = "bun_name";
            this.xEditGridCell2.CellWidth = 491;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bun_ymd";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 110;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // dsvQueryBunCode
            // 
            this.dsvQueryBunCode.ExecuteQuery = null;
            this.dsvQueryBunCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvQueryBunCode.ParamList")));
            // 
            // BAS0230U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.grdBAS0230);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.btnList);
            this.Name = "BAS0230U00";
            resources.ApplyResources(this, "$this");
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BAS0230U00_Closing);
            this.Load += new System.EventHandler(this.BAS0230U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0230)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsvQueryBunCode)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region DatePicker

		private void dtpBunYMD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				//this.DataServiceCall(this.dsvQueryBunCode);
                this.grdBAS0230.QueryLayout(false);
			}
		}

		#endregion

		#region ButtonList

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
            switch (e.Func)
            {
                case FunctionType.Reset:
                    this.dtpBunYMD.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    break;
                case FunctionType.Insert:
                    this.grdBAS0230.SetItemValue(grdBAS0230.CurrentRowNumber, "bun_ymd", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    break;
            }
            //switch (e.Func)
            //{
            //    case FunctionType.Insert:
            //        if (e.IsSuccess)
            //        {
            //            if (TypeCheck.IsDateTime(this.dtpBunYMD.GetDataValue()))
            //            {
            //                this.grdBunCode.SetItemValue(grdBunCode.CurrentRowNumber, "bun_ymd", this.dtpBunYMD.GetDataValue());
            //            }
            //            else
            //            {
            //                this.grdBunCode.SetItemValue(grdBunCode.CurrentRowNumber, "bun_ymd", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            //            }
            //        }
            //        break;
            //    case FunctionType.Reset:
            //        this.dtpBunYMD.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            //        this.dtpBunYMD.AcceptData();
            //        break;
            //}
		}

		#endregion

		#region Grid

		private void grdBunCode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			switch (e.ColName)
			{
				case "bun_code":
                    if (DupCheck(e.ChangeValue.ToString(), e.DataRow["bun_ymd"].ToString()))
					{
						string msg = (Resource.TEXT1);
						this.SetMsg(msg, MsgType.Error);
						e.Cancel = true;
					}
					break;
				case "bun_ymd":
                    if (DupCheck(e.DataRow["bun_code"].ToString(), e.ChangeValue.ToString()))
					{
						string msg = (Resource.TEXT1);
						//this.SetMsg(msg, MsgType.Error);
                        string mcap = Resource.TEXT2;
                        XMessageBox.Show(msg, mcap);
						e.Cancel = true;
					}
					break;


			}
		}

		#endregion

		#region 중복체크
		private bool DupCheck(string aValue, string aDate)
		{
			if (this.grdBAS0230.DeletedRowTable != null)
			{
				foreach (DataRow dr in grdBAS0230.DeletedRowTable.Rows)
				{
					if (dr["bun_code"].ToString() == aValue)
					{
						return false;
					}
				}
			}
			// 현재 그리드에서 찾는다.
			for (int i=0; i<this.grdBAS0230.RowCount; i++)
			{
				if (i != this.grdBAS0230.CurrentRowNumber &&
					this.grdBAS0230.GetItemString(i, "bun_code") == aValue &&
                    this.grdBAS0230.GetItemString(i, "bun_ymd") == aDate)
				{
					return true;
				}
			}
			return false;
		}

		#endregion

		private void BAS0230U00_Load(object sender, System.EventArgs e)
		{
            this.grdBAS0230.SavePerformer = new XSavePeformer(this);
            this.SaveLayoutList.Add(grdBAS0230);
			this.dtpBunYMD.SetDataValue(DateTime.Today);
            this.grdBAS0230.QueryLayout(false);
		}
        string mMsg = "";
        string mCap = "";
        string mCheck = "";
        bool boolSave = true;

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this.boolSave = true;

            switch(e.Func)
            {
                case FunctionType.Insert:
                    break;
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdBAS0230.QueryLayout(false);
                    break;
                case FunctionType.Delete:
                    break;
                case FunctionType.Update:
                    //e.IsSuccess = true;
                    e.IsBaseCall = false;

                    this.mCheck = "";

//                    if (this.grdBAS0230.SaveLayout())
                    if (GrdBas0230SaveLayout())
                    {
                        //e.IsSuccess = false;
                        this.mMsg = Resource.TEXT3;
                        this.mCap = Resource.TEXT4;
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.grdBAS0230.QueryLayout(false);
                    }
                    else
                    {
                        this.boolSave = false;
                        this.mCap = Resource.TEXT5;
                        if (Service.ErrFullMsg == "")
                        {
                            string mesg = Resource.TEXT6;
                            this.mMsg = this.mCheck + mesg;

                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else 
                        {
                            this.mMsg = Resource.TEXT6;
                            this.mMsg += "\r\n" + Service.ErrFullMsg;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0230U00 parent = null;

            public XSavePeformer(BAS0230U00 parent)
            {
                this.parent = parent;
            }

            #region 입력값 체크
            private int Validateion_Check(BindVarCollection BindVarList)
            {
                int value = 0;
                string messg = "";
                if (BindVarList["f_bun_code"].VarValue =="")
                {
                    messg += NetInfo.Language == LangMode.Ko ? "분류코드" : Resource.TEXT7;
                    value = 1;
                }
                if (BindVarList["f_bun_name"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "분류명" : Resource.TEXT8;
                    value = 1;
                }
                if (BindVarList["f_bun_ymd"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "적용일" : Resource.TEXT9;
                    value = 1;
                }
                parent.mCheck = messg;
                return value;
            }
            #endregion

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
               
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);  //병원코드
                item.BindVarList.Add("f_user_id", UserInfo.UserID);         //갱신자ID
               
                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                if (Validateion_Check(item.BindVarList)!=0)
                                {
                                    return false;
                                }
                                cmdText = @"INSERT INTO BAS0230
                                                 ( SYS_DATE         , SYS_ID              , UPD_DATE       
                                                 , UPD_ID           , HOSP_CODE           , BUN_CODE  
                                                 , BUN_YMD          , BUN_NAME )
                                            VALUES
                                                 ( SYSDATE          , :f_user_id          , SYSDATE        
                                                , :f_user_id        , :f_hosp_code        , :f_bun_code
                                                , :f_bun_ymd        , :f_bun_name )";
                                break;
                            case DataRowState.Modified:
                                if (Validateion_Check(item.BindVarList) != 0)
                                {
                                    return false;
                                }
                                cmdText = @"UPDATE BAS0230
                                               SET UPD_ID      = :f_user_id
                                                , UPD_DATE     = SYSDATE
                                                , BUN_CODE     = :f_bun_code
                                                , BUN_YMD      = :f_bun_ymd
                                                , BUN_NAME     = :f_bun_name
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND BUN_CODE     = :f_bun_code
                                               AND BUN_YMD      = :f_bun_ymd ";

                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM BAS0230
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND BUN_CODE     = :f_bun_code
                                               AND BUN_YMD      = :f_bun_ymd ";

                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grd_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0230.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);          //병원코드
            this.grdBAS0230.SetBindVarValue("f_start_ymd", this.dtpBunYMD.GetDataValue()); //적용일
        }
        //적용일 셋팅이벤트
        private void dtpBunYMD_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                this.grdBAS0230.QueryLayout(false);
            }
        }

        private void BAS0230U00_Closing(object sender, CancelEventArgs e)
        {
            if (this.boolSave == false)
            {
                e.Cancel = true;
            }
        }

        #region Connect to cloud

        /// <summary>
        /// ExecuteQueryGrdBas0230
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdBas0230(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        BAS0230U00GrdBas0230Args vBAS0230U00GrdBas0230Args = new BAS0230U00GrdBas0230Args();
	        vBAS0230U00GrdBas0230Args.StartYmd = bc["f_start_ymd"] != null ? bc["f_start_ymd"].VarValue : "";
	        BAS0230U00GrdBas0230Result result =
	            CloudService.Instance.Submit<BAS0230U00GrdBas0230Result, BAS0230U00GrdBas0230Args>(
	                vBAS0230U00GrdBas0230Args);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (BAS0230U00GrdBas0230Info item in result.GrdBas0230Info)
	            {
	                object[] objects =
	                {
	                    item.BunCode,
	                    item.BunName,
	                    item.BunYmd
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
        }

        /// <summary>
        /// GrdBas0230SaveLayout
        /// </summary>
        /// <returns></returns>
	    private bool GrdBas0230SaveLayout()
	    {
            // Validateion_Check
            for (int i = 0; i < grdBAS0230.RowCount; i++)
            {
                if (grdBAS0230.GetRowState(i) == DataRowState.Added ||
                    grdBAS0230.GetRowState(i) == DataRowState.Modified)
                {
                    int check = Validateion_Check(grdBAS0230.GetItemString(i, "bun_code"),
                        grdBAS0230.GetItemString(i, "bun_name"), grdBAS0230.GetItemString(i, "bun_ymd"));
                    if (check != 0)
                    {
                        return false;
                    }
                }
            }

            BAS0230U00GrdBas0230SaveLayoutArgs args = new BAS0230U00GrdBas0230SaveLayoutArgs();
	        args.ItemInfo = CreateListGrdBas0230Item();
	        args.UserId = UserInfo.UserID;
	        if (args.ItemInfo == null)
	        {
	            return false;
	        }
	        UpdateResult result = CloudService.Instance.Submit<UpdateResult, BAS0230U00GrdBas0230SaveLayoutArgs>(args);
	        if (result == null || result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
	        {
	            return false;
	        }
	        return true;
	    }

        /// <summary>
        /// CreateListGrdBas0230Item
        /// </summary>
        /// <returns></returns>
	    private List<BAS0230U00GrdBas0230Info> CreateListGrdBas0230Item()
	    {
	        List<BAS0230U00GrdBas0230Info> lsBas0230Info = new List<BAS0230U00GrdBas0230Info>();
	        for (int i = 0; i < grdBAS0230.RowCount; i++)
	        {
	            if (grdBAS0230.GetRowState(i) == DataRowState.Added || grdBAS0230.GetRowState(i) == DataRowState.Modified)
	            {
	                BAS0230U00GrdBas0230Info info = new BAS0230U00GrdBas0230Info();
                    info.BunCode = grdBAS0230.GetItemString(i, "bun_code");
                    info.BunName = grdBAS0230.GetItemString(i, "bun_name");
                    info.BunYmd = grdBAS0230.GetItemString(i, "bun_ymd");
                    info.DataRowState = grdBAS0230.GetRowState(i).ToString();

                    lsBas0230Info.Add(info);
	            }
	        }
	        if (grdBAS0230.DeletedRowTable != null && grdBAS0230.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdBAS0230.DeletedRowTable.Rows)
	            {
                    BAS0230U00GrdBas0230Info info = new BAS0230U00GrdBas0230Info();
                    info.BunCode = row["bun_code"].ToString();
                    info.BunName = row["bun_name"].ToString();
                    info.BunYmd = row["bun_ymd"].ToString();
                    info.DataRowState = DataRowState.Deleted.ToString();

                    lsBas0230Info.Add(info);
	            }
	        }
	        return lsBas0230Info;
	    }

        /// <summary>
        /// Validateion_Check
        /// </summary>
        /// <param name="aBunCode"></param>
        /// <param name="aBunName"></param>
        /// <param name="aBunYmd"></param>
        /// <returns></returns>
        private int Validateion_Check(string aBunCode, string aBunName, string aBunYmd)
        {
            int value = 0;
            string messg = "";
            if (aBunCode == "")
            {
                messg += Resource.TEXT7;
                value = 1;
            }
            if (aBunName == "")
            {
                if (value == 1)
                {
                    messg += ",";
                }
                messg += Resource.TEXT8;
                value = 1;
            }
            if (aBunYmd == "")
            {
                if (value == 1)
                {
                    messg += ",";
                }
                messg += Resource.TEXT9;
                value = 1;
            }
            mCheck = messg;
            return value;
        }
        #endregion
    }
}

