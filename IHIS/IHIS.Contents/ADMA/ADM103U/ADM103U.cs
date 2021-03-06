/*******************************************************************************
 * 프로그램명: ADM103U
 *  내    용 : 사용자그룹의 아이디와 이름을 조회,입력,수정,삭제
 *  작 성 자 : 김민수
 *  날    짜 : 2005.2.10
 * ****************************************************************************/

#region 사용 NameSpace 지정
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.ADMA.Properties;
#endregion

namespace IHIS.ADMA
{
	/// <summary>
	/// ADM103U에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class ADM103U : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.MultiLayout userGrpQry;
	
		//private IHIS.Framework.DataServiceMISO dbUpdate;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGrid grdUserGrp;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		//private IHIS.Framework.SingleLayout dsvGrpDupCheck;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private Panel panel1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        //tungtx
        private XLabel xLabel2;
        private IHIS.Framework.XFindBox fbxHospitalCode;
        private IHIS.Framework.XFindWorker fwkCommon;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XDisplayBox dbxHospName;
        private SingleLayoutItem singleLayoutItem1;
        private IHIS.Framework.SingleLayout layCommon;

		public ADM103U()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //set ParamList
            this.layCommon.ParamList = new List<string>(new String[] { "f_hosp_code" });

		    this.grdUserGrp.ExecuteQuery = ExecuteQueryADM103UgrdUserGrp;
		    this.fwkCommon.ExecuteQuery = LoadDataFwkCommon;
		    this.layCommon.ExecuteQuery = LoadDataLayCommon;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM103U));
            this.dbxHospName = new IHIS.Framework.XDisplayBox();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.fbxHospitalCode = new IHIS.Framework.XFindBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.userGrpQry = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.grdUserGrp = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.userGrpQry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // dbxHospName
            // 
            this.dbxHospName.AccessibleDescription = null;
            this.dbxHospName.AccessibleName = null;
            resources.ApplyResources(this.dbxHospName, "dbxHospName");
            this.dbxHospName.Font = null;
            this.dbxHospName.Image = null;
            this.dbxHospName.Name = "dbxHospName";
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hosp";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "hosp_name";
            this.findColumnInfo2.ColWidth = 155;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.FormText = "病院コード";
            this.fwkCommon.InputSQL = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            this.fwkCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkCommon_QueryStarting);
            // 
            // fbxHospitalCode
            // 
            this.fbxHospitalCode.AccessibleDescription = null;
            this.fbxHospitalCode.AccessibleName = null;
            resources.ApplyResources(this.fbxHospitalCode, "fbxHospitalCode");
            this.fbxHospitalCode.BackgroundImage = null;
            this.fbxHospitalCode.FindWorker = this.fwkCommon;
            this.fbxHospitalCode.Font = null;
            this.fbxHospitalCode.Name = "fbxHospitalCode";
            this.fbxHospitalCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHospitalCode_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = null;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
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
            // userGrpQry
            // 
            this.userGrpQry.ExecuteQuery = null;
            this.userGrpQry.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.userGrpQry.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("userGrpQry.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "user_group";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "group_nm";
            // 
            // grdUserGrp
            // 
            resources.ApplyResources(this.grdUserGrp, "grdUserGrp");
            this.grdUserGrp.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdUserGrp.ColPerLine = 3;
            this.grdUserGrp.Cols = 3;
            this.grdUserGrp.ExecuteQuery = null;
            this.grdUserGrp.FixedRows = 1;
            this.grdUserGrp.HeaderHeights.Add(34);
            this.grdUserGrp.Name = "grdUserGrp";
            this.grdUserGrp.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdUserGrp.ParamList")));
            this.grdUserGrp.Rows = 2;
            this.grdUserGrp.ToolTipActive = true;
            this.grdUserGrp.Load += new System.EventHandler(this.grdUserGrp_Load);
            this.grdUserGrp.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdUserGrp_GridButtonClick);
            this.grdUserGrp.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdUserGrp_RowFocusChanged);
            this.grdUserGrp.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdUserGrp_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "user_group";
            this.xEditGridCell3.CellWidth = 111;
            this.xEditGridCell3.CellLen = 6;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 20;
            this.xEditGridCell4.CellName = "group_nm";
            this.xEditGridCell4.CellWidth = 283;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ButtonText = global::IHIS.ADMA.Properties.Resources.xEditGridCell5_ButtonText;
            this.xEditGridCell5.CellName = "reg_entr_sys";
            this.xEditGridCell5.CellWidth = 76;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.dbxHospName);
            this.panel1.Controls.Add(this.fbxHospitalCode);
            this.panel1.Controls.Add(this.xLabel2);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            this.layCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCommon_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxHospName;
            this.singleLayoutItem1.DataName = "HospitalName";
            // 
            // ADM103U
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdUserGrp);
            this.Controls.Add(this.xButtonList1);
            this.Name = "ADM103U";
            this.Load += new System.EventHandler(this.ADM103U_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userGrpQry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        #region Screen 변수
        private string mMsg = "";
        private string mCap = "";
        private string mHospCode;
        #endregion

        private void ADM103U_Load(object sender, EventArgs e)
        {
            //this.grdUserGrp.SavePerformer = new XSavePeformer(this);
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                this.panel1.Visible = true;
                this.mHospCode = fbxHospitalCode.Text;
                this.grdUserGrp.Height = 424;
                this.grdUserGrp.Location = new Point(5, 51);
            }
            else
            {
                this.panel1.Visible = false;
                this.mHospCode = UserInfo.HospCode;
                this.grdUserGrp.Height = 469;
                this.grdUserGrp.Location = new Point(5, 5);
            }
        }

		#region 버튼클릭 이벤트
		//delete 시에 삭제확인메세지를 띄움
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			if ( e.Func == FunctionType.Delete )
			{
                DialogResult dialogResult = DialogResult.No;
                switch (NetInfo.Language)
                {
                    case LangMode.Vi:
                        dialogResult = XMessageBox.Show(Resources.MSG_1, Resources.MSG_Caption_1, MessageBoxButtons.YesNo);
                        break;
                    case LangMode.Jr:
                        dialogResult = XMessageBox.Show(grdUserGrp[this.grdUserGrp.CurrentRowNumber + 1, 1].Value.ToString() +
                            Resources.MSG_1, Resources.MSG_Caption_1, MessageBoxButtons.YesNo);
                        break;
                    default:
                        dialogResult = XMessageBox.Show(grdUserGrp[this.grdUserGrp.CurrentRowNumber + 1, 1].Value.ToString() +
                            Resources.MSG_1, Resources.MSG_Caption_1, MessageBoxButtons.YesNo);
                        break;
                }

				if (dialogResult == DialogResult.Yes )
				{
					e.IsBaseCall = true;
				}
				else
				{
					e.IsBaseCall = false;
				}
			}
            switch(e.Func)
            {
                case FunctionType.Query:
                    this.grdUserGrp.QueryLayout(false);
                    break;
                case FunctionType.Delete:
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;

                    // Fixes required check
                    string errMsg = "";

                    ADM103SaveLayoutArgs args = new ADM103SaveLayoutArgs();
                    args.ItemInfo = CreateUgrdUserGrpInfo(out errMsg);

                    // Required check
                    // Fixes bug https://nextop-asia.atlassian.net/browse/MED-4639
                    if (!TypeCheck.IsNull(errMsg))
                    {
                        XMessageBox.Show(errMsg, Resources.MSG_Caption_3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    args.SysId = UserInfo.UserID;
                    args.HospCode = mHospCode;
                    if (args.ItemInfo.Count > 0)
                    {
                        UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, ADM103SaveLayoutArgs>(args);
                        if (updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result == true)
                        {
                            this.mMsg = Resources.MSG_2;
                            this.mCap = Resources.MSG_Caption_2;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.grdUserGrp.QueryLayout(false);
                        }
                        else
                        {
                            this.mCap = Resources.MSG_Caption_3;
                            XMessageBox.Show(Resources.MSG_3, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

//                    if (this.grdUserGrp.SaveLayout())
                    //if (grdUser_SaveLayout())
                    //{
                    //    this.mMsg = Resources.MSG_2;
                    //    this.mCap = Resources.MSG_Caption_2;
                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.grdUserGrp.QueryLayout(false);
                    //}
                    //else
                    //{
                    //    this.mCap = Resources.MSG_Caption_3;
                    //    XMessageBox.Show(Resources.MSG_3, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    break;
            }
		}
		#endregion

		private void grdUserGrp_Load(object sender, System.EventArgs e)
		{
            //this.CurrMILayout = this.grdUserGrp;
            //this.CurrMOLayout = this.grdUserGrp;

			//최초 입력가능하도록 행입력
			this.grdUserGrp.InsertRow();

		}

		private void grdUserGrp_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			//버튼 활성화 처리 (Inserted된 Row는 버튼 활성화 하면 안됨)
			if ((e.CurrentRow >= 0) && (this.grdUserGrp.GetRowState(e.CurrentRow) == DataRowState.Added))
			{
				this.grdUserGrp.ChangeButtonEnable("reg_entr_sys", e.CurrentRow, false);
			}
		}

		private void grdUserGrp_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{
			if (e.ColName == "reg_entr_sys")
			{
                string userGroup = e.DataRow["user_group"].ToString();
                RegSystemForm dlg = new RegSystemForm(userGroup, mHospCode);
                dlg.ShowDialog(EnvironInfo.MdiForm);
                dlg.Dispose();

                //TODO open screen COMSYS
                //string userGroup = e.DataRow["user_group"].ToString();
                //string hospCode = this.fbxHospitalCode.Text;

                //CommonItemCollection openParams = new CommonItemCollection();
                //openParams.Add("user_group", userGroup);
                //openParams.Add("hosp_code", hospCode);

                //XScreen.OpenScreenWithParam(this, "ADMA", "COMSYS", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);
                
			}
		}
        #region XSavePeformer
//        private class XSavePeformer : ISavePerformer
//        {
//            private ADM103U parent = null;

//            public XSavePeformer(ADM103U parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_dup_check = "";

//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("f_sys_id", UserInfo.UserID);

//                switch (callerID)
//                {
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @" INSERT INTO ADM3100
//                                             (  HOSP_CODE
//                                             ,  USER_GROUP
//                                             ,  GROUP_NM 
//                                             ,  UP_MEMB
//                                             ,  UP_TIME
//                                             ,  CR_MEMB
//                                             ,  CR_TIME )
//                                        VALUES (:f_hosp_code
//                                             ,  :f_user_group
//                                             ,  :f_group_nm
//                                             ,  :f_sys_id
//                                             ,   SYSDATE
//                                             ,  :f_sys_id
//                                             ,   SYSDATE ) ";
//                                break;
//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE ADM3100
//                                               SET GROUP_NM    = :f_group_nm
//                                                 , UP_MEMB     = :f_sys_id
//                                                 , UP_TIME     = SYSDATE
//                                             WHERE HOSP_CODE   = :f_hosp_code
//                                               AND USER_GROUP  = :f_user_group ";
//                                break;
//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE FROM ADM3100
//                                             WHERE HOSP_CODE    = :f_hosp_code
//                                               AND USER_GROUP   = :f_user_group ";
//                                break;
//                        }
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        private void grdUserGrp_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdUserGrp.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        #region Connect to cloud service

        /// <summary>
        /// ExecuteQueryADM103UgrdUserGrp
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryADM103UgrdUserGrp(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UgrdUserGrpArgs args = new ADM103UgrdUserGrpArgs();
            args.HospCode = mHospCode;
            ADM103UgrdUserGrpResult result = CloudService.Instance.Submit<ADM103UgrdUserGrpResult, ADM103UgrdUserGrpArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM103UgrdUserGrpInfo item in result.UserList)
                {
                    object[] objects =
                    {
                        item.UserGroup,
                        item.GroupNm
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
	    private bool grdUser_SaveLayout()
	    {
            //ADM103SaveLayoutArgs args = new ADM103SaveLayoutArgs();
            //args.ItemInfo = CreateUgrdUserGrpInfo();
            //args.SysId = UserInfo.UserID;
            ////args.HospCode = this.fbxHospitalCode.Text;
            //args.HospCode = mHospCode;
            //if (args.ItemInfo == null || args.ItemInfo.Count < 0)
            //{
            //    return true;
            //}
            //UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, ADM103SaveLayoutArgs>(args);
            //if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
            //    updateResult.Result == false)
            //{
            //    return false;
            //}
	        return true;
	    }

        /// <summary>
        /// CreateUgrdUserGrpInfo
        /// </summary>
        /// <returns></returns>
	    private List<ADM103UgrdUserGrpInfo> CreateUgrdUserGrpInfo(out string errMsg)
	    {
            errMsg = "";

	        List<ADM103UgrdUserGrpInfo> lstGrdUserGrpItem = new List<ADM103UgrdUserGrpInfo>();
	        for (int i = 0; i < grdUserGrp.RowCount; i++)
	        {
	            if (grdUserGrp.GetRowState(i) == DataRowState.Added || grdUserGrp.GetRowState(i) == DataRowState.Modified)
	            {
                    // Required check
                    if (TypeCheck.IsNull(grdUserGrp.GetItemString(i, "user_group")))
                    {
                        // ユーザーグループ
                        //XMessageBox.Show(Resources.MSG_4, Resources.CAP_SAVE_FAIL, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errMsg = Resources.MSG_4;
                        return new List<ADM103UgrdUserGrpInfo>();
                    }
                    if (TypeCheck.IsNull(grdUserGrp.GetItemString(i, "group_nm")))
                    {
                        // グループ名称
                        //XMessageBox.Show(Resources.MSG_5, Resources.CAP_SAVE_FAIL, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errMsg = Resources.MSG_5;
                        return new List<ADM103UgrdUserGrpInfo>();
                    }

	                ADM103UgrdUserGrpInfo grpInfo = new ADM103UgrdUserGrpInfo();
	                grpInfo.GroupNm = grdUserGrp.GetItemString(i, "group_nm");
	                grpInfo.UserGroup = grdUserGrp.GetItemString(i, "user_group");
	                grpInfo.RowState = grdUserGrp.GetRowState(i).ToString();
                    lstGrdUserGrpItem.Add(grpInfo);
	            }
	        }
	        if (grdUserGrp.DeletedRowTable != null && grdUserGrp.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdUserGrp.DeletedRowTable.Rows)
	            {
                    ADM103UgrdUserGrpInfo grpInfo = new ADM103UgrdUserGrpInfo();
	                grpInfo.GroupNm = row["group_nm"].ToString();
                    grpInfo.UserGroup = row["user_group"].ToString();
	                grpInfo.RowState = DataRowState.Deleted.ToString();
                    lstGrdUserGrpItem.Add(grpInfo);
	            }
	        }
	        return lstGrdUserGrpItem;
	    }

        private List<object[]> LoadDataFwkCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UGetFwkHospitalArgs args = new ADM103UGetFwkHospitalArgs();
            ADM103UGetFwkHospitalResult result = CloudService.Instance.Submit<ADM103UGetFwkHospitalResult, ADM103UGetFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.HospList)
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

        private List<object[]> LoadDataLayCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UValidateFwkHospitalArgs args = new ADM103UValidateFwkHospitalArgs();
            args.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            ADM103UValidateFwkHospitalResult result = CloudService.Instance.Submit<ADM103UValidateFwkHospitalResult, ADM103UValidateFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.HospName
                });
            }
            return res;
        } 


        
        #endregion

        private void fbxHospitalCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.mHospCode = fbxHospitalCode.Text;

            this.layCommon.QueryLayout();

            this.grdUserGrp.QueryLayout(true);
        }

        private void fwkCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCommon.SetBindVarValue("f_hosp_code", mHospCode);
            //this.layCommon.SetBindVarValue("f_code", this.fbxHospitalCode.Text);
        }
    }
}

