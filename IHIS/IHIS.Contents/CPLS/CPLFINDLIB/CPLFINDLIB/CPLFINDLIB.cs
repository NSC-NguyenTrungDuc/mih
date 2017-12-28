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
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
	/// <summary>
	/// CPLFINDLIB에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPLFINDLIB : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XTextBox txtSearch;
		private IHIS.Framework.XEditGrid grdFind;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
        private SingleLayout layCPL0155;
        private SingleLayoutItem singleLayoutItem1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPLFINDLIB()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            // Create Pramlist And ExecuteQuery
            this.layCPL0155.ParamList = new List<string>(new String[] { "f_result_form" });
		    this.layCPL0155.ExecuteQuery = ExecuteQueryLayCPL0155;

            this.grdFind.ParamList = new List<string>(new String[] { "f_result_form", "f_code_type", "f_find", "f_isExist" });
		    this.grdFind.ExecuteQuery = ExecuteQueryGrdFind;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPLFINDLIB));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdFind = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layCPL0155 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFind)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdFind);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(258, 790);
            this.xPanel1.TabIndex = 0;
            // 
            // grdFind
            // 
            this.grdFind.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdFind.ColPerLine = 2;
            this.grdFind.Cols = 2;
            this.grdFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFind.FixedRows = 1;
            this.grdFind.HeaderHeights.Add(23);
            this.grdFind.Location = new System.Drawing.Point(0, 36);
            this.grdFind.Name = "grdFind";
            this.grdFind.RowHeaderBackColor = IHIS.Framework.XColor.XCalendarMonthBackColor;
            this.grdFind.Rows = 2;
            this.grdFind.Size = new System.Drawing.Size(256, 714);
            this.grdFind.TabIndex = 0;
            this.grdFind.DoubleClick += new System.EventHandler(this.grdFind_DoubleClick);
            this.grdFind.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdFind_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "code";
            this.xEditGridCell1.CellWidth = 64;
            this.xEditGridCell1.HeaderBackColor = IHIS.Framework.XColor.XProgressBarBackColor;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XMatrixBackColor;
            this.xEditGridCell1.HeaderText = "コード";
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "code_name";
            this.xEditGridCell2.CellWidth = 173;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderBackColor = IHIS.Framework.XColor.XProgressBarBackColor;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XMatrixBackColor;
            this.xEditGridCell2.HeaderText = "コード名";
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 750);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(256, 38);
            this.xPanel3.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "選 択", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(4, 2);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.txtSearch);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(256, 36);
            this.xPanel2.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(64, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(186, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearch_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel1.Location = new System.Drawing.Point(6, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(56, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "検 索";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layCPL0155
            // 
            this.layCPL0155.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "isExist";
            // 
            // CPLFINDLIB
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPLFINDLIB";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(268, 800);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPLFINDLIB_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFind)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad	
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			this.CurrMQLayout = this.grdFind;
		}
		#endregion

		#region 오픈스크린
        string mWorkTp = "";
        string mResultForm = "";
		private void CPLFINDLIB_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            mWorkTp = "";
            mResultForm = "";

			if ( this.OpenParam.Contains("work_tp") && !TypeCheck.IsNull(OpenParam["work_tp"]) )
			{
                mWorkTp = OpenParam["work_tp"].ToString();
			}
            //if ( this.OpenParam.Contains("service_name") && !TypeCheck.IsNull(OpenParam["service_name"]) )
            //{
            //    dsvFind.ServiceName = OpenParam["service_name"].ToString();
            //}
            //if ( this.OpenParam.Contains("product_name") && !TypeCheck.IsNull(OpenParam["product_name"]) )
            //{
            //    dsvFind.ProductName = OpenParam["product_name"].ToString();
            //}
			if ( this.OpenParam.Contains("result_form") && !TypeCheck.IsNull(OpenParam["result_form"]) )
			{
                mResultForm = OpenParam["result_form"].ToString();
			}
			this.grdFind.QueryLayout(false);
		}
		#endregion

		#region 검색
		private void txtSearch_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.btnList.PerformClick(FunctionType.Query);
		}
		#endregion

		#region 파인드 더블 클릭시
		private void grdFind_DoubleClick(object sender, System.EventArgs e)
		{
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "cpl_result"   , grdFind.GetItemString(grdFind.CurrentRowNumber,"code_name"));
			scrOpener.Command(this.ScreenID, commandParams);

			this.Close();
		}
		#endregion

		#region 버튼리스트 클릭
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			if ( e.Func == FunctionType.Process )
			{
				IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

				CommonItemCollection commandParams  = new CommonItemCollection();
				commandParams.Add( "cpl_result"   , grdFind.GetItemString(grdFind.CurrentRowNumber,"code_name"));
				scrOpener.Command(this.ScreenID, commandParams);

				this.Close();
			}
		}
		#endregion

		#region 단축키 설정
		protected override bool ProcessDialogKey(Keys keyData)
		{
			//IHIS.Framework.Kernel32.Beep();
			//IHIS.Framework.Kernel32.Warn();
			Keys keyCode = (Keys)(((int)keyData << 16) >> 16);
			Keys keyModifier = (Keys)(((int)keyData >> 16) << 16);

			switch (keyCode)
			{
				case Keys.Enter:
					if ( grdFind.Focused == true )
					{
						btnList_ButtonClick(null,null);
					}
					break;
				default:
					break;
			}
			return base.ProcessDialogKey(keyData);
		}
		#endregion

        private void grdFind_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCPL0155.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layCPL0155.SetBindVarValue("f_result_form", this.mResultForm);
            this.layCPL0155.QueryLayout();

            // TODO comment use connect cloud
            /*if(this.layCPL0155.GetItemValue("isExist").ToString() == "Y")
            {
                this.grdFind.QuerySQL = @"SELECT CODE
                                               , CODE_NAME
                                            FROM CPL0155
                                           WHERE RESULT_CODE_GUBUN    = :f_result_form
                                             AND ((CODE        LIKE '%'||:f_find||'%')
                                              OR  (CODE_NAME   LIKE '%'||:f_find||'%'))
                                           ORDER BY CODE  ";
            }
            else
            {
                this.grdFind.QuerySQL = @"SELECT CODE
                                               , CODE_NAME
                                            FROM CPL0109
                                           WHERE CODE_TYPE = '38'
                                             AND ((CODE        LIKE '%'||:f_find||'%')
                                              OR  (CODE_NAME   LIKE '%'||:f_find||'%'))
                                           ORDER BY CODE  ";
            }
            */

            this.grdFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdFind.SetBindVarValue("f_result_form", mResultForm);
            this.grdFind.SetBindVarValue("f_find", this.txtSearch.Text);
            this.grdFind.SetBindVarValue("f_code_type", "38");
            this.grdFind.SetBindVarValue("f_isExist", this.layCPL0155.GetItemValue("isExist").ToString());


        }

        #region Connect to cloud service
        /// <summary> 
        /// layCPL0155
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
	    private IList<object[]> ExecuteQueryLayCPL0155(BindVarCollection var)
	    {
            IList<object[]> lstObject = new List<object[]>();
            CPL3020U00FwkResultGetYArgs args = new CPL3020U00FwkResultGetYArgs();
	        args.ResultForm = var["f_result_form"].VarValue;
            CPL3020U00FwkResultGetYResult getYResult =
                CloudService.Instance.Submit<CPL3020U00FwkResultGetYResult, CPL3020U00FwkResultGetYArgs>(args);
	        if (getYResult != null && getYResult.ExecutionStatus == ExecutionStatus.Success)
	        {
                lstObject.Add(new object[] { getYResult.YValue });
	        }
	        return lstObject;
        }

	    private IList<object[]> ExecuteQueryGrdFind(BindVarCollection var)
	    {
            IList<object[]> lstObject = new List<object[]>();
            CPLFINDLIBGrdFindArgs args = new CPLFINDLIBGrdFindArgs();
	        args.CodeType = var["f_code_type"].VarValue;
	        args.Find = var["f_find"].VarValue;
	        args.ResultForm = var["f_result_form"].VarValue;
	        args.IsExist = var["f_isExist"].VarValue;

	        ComboResult result = CloudService.Instance.Submit<ComboResult, CPLFINDLIBGrdFindArgs>(args);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<ComboListItemInfo> lstComboListItemInfo = result.ComboItem;
	            if (lstComboListItemInfo != null && lstComboListItemInfo.Count > 0)
	            {
	                foreach (ComboListItemInfo itemInfo in lstComboListItemInfo)
	                {
	                    lstObject.Add(new object[] {itemInfo.Code, itemInfo.CodeName});
	                }
	            }
	        }
	        return lstObject;
	    } 
        #endregion 
    }
}

