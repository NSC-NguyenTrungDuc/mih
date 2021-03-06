using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.ADM.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;

namespace IHIS.ADMA
{
	/// <summary>
	/// DoctorIlgwalRegForm에 대한 요약 설명입니다.
	/// </summary>
	public class DoctorIlgwalRegForm : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDisplayBox xDisplayBox2;
		private IHIS.Framework.XDisplayBox xDisplayBox1;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel xLabel10;
		private IHIS.Framework.XEditMask emkUserSeq;
		private IHIS.Framework.XTextBox txtUserScr;
		private IHIS.Framework.XTextBox txtUserName;
		private IHIS.Framework.XFindBox fbxUserDept;
		private IHIS.Framework.XDisplayBox dbxUserDeptName;
		private IHIS.Framework.XDisplayBox dbxUserGroupName;
		private IHIS.Framework.XFindBox fbxUserGroup;
		private IHIS.Framework.XEditMask emkUserLevel;
		private IHIS.Framework.XDictComboBox cboUserGubun;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XDictComboBox cboDoctorGrade;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.SingleLayout dsvProcessCall;
		private IHIS.Framework.SingleLayout vsvCommon;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

	    private String mHospCode;

		public DoctorIlgwalRegForm(String hospCode)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
		    this.mHospCode = hospCode;
		    cboDoctorGrade.ExecuteQuery = ExecuteQueryCboDoctorGrade;
		    cboDoctorGrade.SetDictDDLB();

		    cboUserGubun.ExecuteQuery = ExecuteQueryCboUserGubun;
            cboUserGubun.SetDictDDLB();
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorIlgwalRegForm));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboDoctorGrade = new IHIS.Framework.XDictComboBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.emkUserLevel = new IHIS.Framework.XEditMask();
            this.cboUserGubun = new IHIS.Framework.XDictComboBox();
            this.dbxUserGroupName = new IHIS.Framework.XDisplayBox();
            this.fbxUserGroup = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.dbxUserDeptName = new IHIS.Framework.XDisplayBox();
            this.fbxUserDept = new IHIS.Framework.XFindBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.emkUserSeq = new IHIS.Framework.XEditMask();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtUserScr = new IHIS.Framework.XTextBox();
            this.txtUserName = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xDisplayBox2 = new IHIS.Framework.XDisplayBox();
            this.xDisplayBox1 = new IHIS.Framework.XDisplayBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dsvProcessCall = new IHIS.Framework.SingleLayout();
            this.vsvCommon = new IHIS.Framework.SingleLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightBlue);
            this.xPanel2.Controls.Add(this.cboDoctorGrade);
            this.xPanel2.Controls.Add(this.xLabel8);
            this.xPanel2.Controls.Add(this.emkUserLevel);
            this.xPanel2.Controls.Add(this.cboUserGubun);
            this.xPanel2.Controls.Add(this.dbxUserGroupName);
            this.xPanel2.Controls.Add(this.fbxUserGroup);
            this.xPanel2.Controls.Add(this.dbxUserDeptName);
            this.xPanel2.Controls.Add(this.fbxUserDept);
            this.xPanel2.Controls.Add(this.xLabel10);
            this.xPanel2.Controls.Add(this.emkUserSeq);
            this.xPanel2.Controls.Add(this.xLabel7);
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.txtUserScr);
            this.xPanel2.Controls.Add(this.txtUserName);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.xDisplayBox2);
            this.xPanel2.Controls.Add(this.xDisplayBox1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // cboDoctorGrade
            // 
            this.cboDoctorGrade.ExecuteQuery = null;
            resources.ApplyResources(this.cboDoctorGrade, "cboDoctorGrade");
            this.cboDoctorGrade.Name = "cboDoctorGrade";
            this.cboDoctorGrade.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDoctorGrade.ParamList")));
            this.cboDoctorGrade.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // emkUserLevel
            // 
            resources.ApplyResources(this.emkUserLevel, "emkUserLevel");
            this.emkUserLevel.Name = "emkUserLevel";
            // 
            // cboUserGubun
            // 
            this.cboUserGubun.ExecuteQuery = null;
            resources.ApplyResources(this.cboUserGubun, "cboUserGubun");
            this.cboUserGubun.Name = "cboUserGubun";
            this.cboUserGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboUserGubun.ParamList")));
            this.cboUserGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // dbxUserGroupName
            // 
            resources.ApplyResources(this.dbxUserGroupName, "dbxUserGroupName");
            this.dbxUserGroupName.Name = "dbxUserGroupName";
            // 
            // fbxUserGroup
            // 
            this.fbxUserGroup.AutoTabDataSelected = true;
            this.fbxUserGroup.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxUserGroup, "fbxUserGroup");
            this.fbxUserGroup.Name = "fbxUserGroup";
            this.fbxUserGroup.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxUserGroup.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            // 
            // dbxUserDeptName
            // 
            resources.ApplyResources(this.dbxUserDeptName, "dbxUserDeptName");
            this.dbxUserDeptName.Name = "dbxUserDeptName";
            // 
            // fbxUserDept
            // 
            this.fbxUserDept.AutoTabDataSelected = true;
            this.fbxUserDept.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxUserDept, "fbxUserDept");
            this.fbxUserDept.Name = "fbxUserDept";
            this.fbxUserDept.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxUserDept.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Name = "xLabel10";
            // 
            // emkUserSeq
            // 
            resources.ApplyResources(this.emkUserSeq, "emkUserSeq");
            this.emkUserSeq.Mask = "##";
            this.emkUserSeq.Name = "emkUserSeq";
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // txtUserScr
            // 
            this.txtUserScr.ApplyByteLimit = true;
            resources.ApplyResources(this.txtUserScr, "txtUserScr");
            this.txtUserScr.Name = "txtUserScr";
            // 
            // txtUserName
            // 
            this.txtUserName.ApplyByteLimit = true;
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xDisplayBox2
            // 
            this.xDisplayBox2.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            resources.ApplyResources(this.xDisplayBox2, "xDisplayBox2");
            this.xDisplayBox2.Name = "xDisplayBox2";
            // 
            // xDisplayBox1
            // 
            this.xDisplayBox1.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            resources.ApplyResources(this.xDisplayBox1, "xDisplayBox1");
            this.xDisplayBox1.Name = "xDisplayBox1";
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dsvProcessCall
            // 
            this.dsvProcessCall.ExecuteQuery = null;
            this.dsvProcessCall.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvProcessCall.ParamList")));
            // 
            // vsvCommon
            // 
            this.vsvCommon.ExecuteQuery = null;
            this.vsvCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvCommon.ParamList")));
            // 
            // DoctorIlgwalRegForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "DoctorIlgwalRegForm";
            this.Load += new System.EventHandler(this.DoctorIlgwalRegForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region From 변수

        //private string mMsg = "";
        //private string mCap = "";

		private string mUserNm = "";

		#endregion

		#region Property

		public string UserNm
		{
			get 
			{
				return this.mUserNm;
			}
		}

		#endregion

		#region Form Load 

		private void DoctorIlgwalRegForm_Load(object sender, System.EventArgs e)
		{	
			this.InitForm();
		}

		#endregion

		#region Function

		private void InitForm ()
		{
			this.fbxUserGroup.SetEditValue("OCS"); // 의사
			this.fbxUserGroup.AcceptData();
            this.cboUserGubun.SetDataValue("1");  // 의사니깐...			
		}

		#endregion

		#region XFindBox

		private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XFindBox control = sender as XFindBox ;

			switch (control.Name)
			{
				case "fbxUserDept" : 

					/*this.fwkCommon.InputSQL = "SELECT A.BUSEO_CODE, A.BUSEO_NAME " +
						                      "  FROM BAS0260 A " +
                                              " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'" +
                                              "   AND A.BUSEO_YMD = ( SELECT MAX(Z.BUSEO_YMD) " +
                                              "                         FROM BAS0260 Z " +
                                              "                        WHERE Z.HOSP_CODE  = A.HOSP_CODE " +
                                              "                          AND Z.BUSEO_CODE = A.BUSEO_CODE " +
						                      "                          AND Z.BUSEO_YMD <= TRUNC(SYSDATE) ) " +
						                      "   AND A.BUSEO_GUBUN = '1' " +
						                      " ORDER BY A.BUSEO_CODE ";*/

					this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.SetBindVarValue("f_control_name", "fbxUserDept");
                    this.fwkCommon.ExecuteQuery = ExecuteQueryFwkCommon;
					this.fwkCommon.ColInfos.Add("code", Resources.FindBox_Title_Code, FindColType.String, 80, 0, true, FilterType.No);
					this.fwkCommon.ColInfos.Add("code_name", Resources.FindBox_Title_Name, FindColType.String, 200, 0, true, FilterType.Yes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					break;

				case "fbxUserGroup" : 

					/*this.fwkCommon.InputSQL = "SELECT A.USER_GROUP, A.GROUP_NM "
                                            + "  FROM ADM3100 A "
                                            +"  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                            ;*/

					this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.SetBindVarValue("f_control_name", "fbxUserGroup");
			        this.fwkCommon.ExecuteQuery = ExecuteQueryFwkCommon;
					this.fwkCommon.ColInfos.Add("code", Resources.FindBox_Title_Code, FindColType.String, 80, 0, true, FilterType.No);
					this.fwkCommon.ColInfos.Add("code_name", Resources.FindBox_Title_Name, FindColType.String, 200, 0, true, FilterType.Yes);
					this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					break;
			}
		}

		private void FindBox_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			XFindBox control = sender as XFindBox ;
			//string name = "";

			switch (control.Name )
			{
				case "fbxUserDept":

					if (e.DataValue == "")
					{
						this.dbxUserDeptName.SetDataValue("");
						this.SetMsg("");

						return ;
					}

					#region 서비스 셋팅 

                    //this.vsvCommon.InputSQL = "SELECT A.BUSEO_NAME " +
                    //                          "  FROM BAS0260 A " +
                    //                          " WHERE A.BUSEO_CODE = '" + e.DataValue + "' " +
                    //                          "   AND A.BUSEO_YMD  = ( SELECT MAX(Z.BUSEO_YMD) " +
                    //                          "                          FROM BAS0260 Z " +
                    //                          "                         WHERE Z.BUSEO_CODE = A.BUSEO_CODE " +
                    //                          "                           AND Z.BUSEO_YMD <= TRUNC(SYSDATE) ) " ;
                    //this.vsvCommon.OutputLayoutItems.Clear();
                    //this.vsvCommon.OutputLayoutItems.Add("buseo_name", DataType.String);

					#endregion

                    //this.vsvCommon.Call();

                    //name = this.vsvCommon.GetOutValue("buseo_name").ToString();

                    //if (name == "")
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "부서코드가 정확하지 않습니다." : "部署コードが正確ではないです。 確認願います。";
						
                    //    this.SetMsg(this.mMsg, MsgType.Error);

                    //    e.Cancel = true;

                    //    return;
                    //}
                    //else
                    //{
                    //    this.dbxUserDeptName.SetDataValue(name);
                    //    this.SetMsg("");
                    //    return;
                    //}


					break;

				case "fbxUserGroup":

					if (e.DataValue == "")
					{
						this.dbxUserGroupName.SetDataValue("");
						this.SetMsg("");

						return ;
					}

					#region 서비스 셋팅 

                    //this.vsvCommon.InputSQL = "SELECT A.GROUP_NM " +
                    //                          "  FROM ADM3100 A " +
                    //                          " WHERE A.USER_GROUP = '" + e.DataValue + "' " ;
						                      
                    //this.vsvCommon.OutputLayoutItems.Clear();
                    //this.vsvCommon.OutputLayoutItems.Add("group_name", DataType.String);

					#endregion

                    //this.vsvCommon.Call();

                    //name = this.vsvCommon.GetOutValue("group_name").ToString();

                    //if (name == "")
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "그룹코드가 정확하지 않습니다." : "グループコードが正確ではないです。 確認願います。";
						
                    //    this.SetMsg(this.mMsg, MsgType.Error);

                    //    e.Cancel = true;

                    //    return;
                    //}
                    //else
                    //{
                    //    this.dbxUserGroupName.SetDataValue(name);
                    //    this.SetMsg("");
                    //    return;
                    //}

					break;
			}
		}

		#endregion

        #region Connect to cloud
        /// <summary>
        /// ExecuteQueryCboDoctorGrade
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryCboDoctorGrade(BindVarCollection var)
        {
            List<object[]> res = new List<object[]>();
            CboDoctorGradeArgs args = new CboDoctorGradeArgs();
            args.CodeType = "DOCTOR_GRADE";
            args.HospCode = this.mHospCode;
            ComboResult comboResult = CacheService.Instance.Get<CboDoctorGradeArgs, ComboResult>(args);
                //CacheService.Instance.Get<CboDoctorGradeArgs, ComboResult>(
                //    Constants.CacheKeyCbo.CACHE_COMBO_DOCTOR_GRADE,
                //    args, delegate(ComboResult result)
                //    {
                //        return
                //            result != null && result.ExecutionStatus == ExecutionStatus.Success && result.ComboItem != null &&
                //            result.ComboItem.Count > 0;
                //    });

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
        /// ExecuteQueryFwkCommon
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryFwkCommon(BindVarCollection var)
        {
            List<object[]> res = new List<object[]>();
            ADM104UFindBoxArgs args = new ADM104UFindBoxArgs();
            args.ControlName = var["f_control_name"].VarValue;
            ComboResult comboResult =
                CloudService.Instance.Submit<ComboResult, ADM104UFindBoxArgs>(args);

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
        /// ExecuteQueryCboUserGubun
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryCboUserGubun(BindVarCollection var)
        {
            List<object[]> res = new List<object[]>();
            ComboADM1110GetByColNameArgs args = new ComboADM1110GetByColNameArgs();
            args.ColName = "USER_GUBUN";
            args.HospCode = this.mHospCode;
            ComboResult comboResult = CacheService.Instance.Get<ComboADM1110GetByColNameArgs, ComboResult>(args);
                //CacheService.Instance.Get<ComboADM1110GetByColNameArgs, ComboResult>(
                //    Constants.CacheKeyCbo.CACHE_COMBO_ADM1110_GET_BY_COL_USER_GUBUN,
                //    args, delegate(ComboResult result)
                //    {
                //        return
                //            result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                //            result.ComboItem != null && result.ComboItem.Count > 0;
                //    });

            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
                {
                    res.Add(new object[] {info.Code, info.CodeName});
                }
            }
            return res;
        }

        #endregion

        #region XButtonList

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process :

					e.IsBaseCall = false;

                    //this.dsvProcessCall.SetInValue("user_seq"    , this.emkUserSeq.GetDataValue());
                    //this.dsvProcessCall.SetInValue("doctor_grade", this.cboDoctorGrade.GetDataValue());
                    //this.dsvProcessCall.SetInValue("user_nm"     , this.txtUserName.GetDataValue());
                    //this.dsvProcessCall.SetInValue("pass_wd"     , this.txtUserScr.GetDataValue());
                    //this.dsvProcessCall.SetInValue("buseo_code"  , this.fbxUserDept.GetDataValue());
                    //this.dsvProcessCall.SetInValue("user_group"  , this.fbxUserGroup.GetDataValue());
                    //this.dsvProcessCall.SetInValue("user_level"  , this.emkUserLevel.GetDataValue());
                    //this.dsvProcessCall.SetInValue("user_gubun"  , this.cboUserGubun.GetDataValue());

                    //if (this.DataServiceCall(this.dsvProcessCall))
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "	정상적으로 처리 되었습니다" : "正常に処理が終了しました。";
                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "처리완료" : "処理終了";

                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
							 
                    //    this.mUserNm = this.txtUserName.GetDataValue();
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "처리에 실패 하였습니다." : "処理に失敗しました。";
                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "처리실패" : "処理失敗";

                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

					break;

				case FunctionType.Close :

					this.Close();

					break;
			}
		}

		#endregion

	}
}
