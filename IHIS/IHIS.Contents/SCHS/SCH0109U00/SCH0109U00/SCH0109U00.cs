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
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.SCHS.Properties;
using Microsoft.Win32;
#endregion

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH0109U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0109U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XButtonList btnList;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XEditGrid grdDetail;
		private IHIS.Framework.XMstGrid grdMaster;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XTextBox txtCodeTypeName;
		private IHIS.Framework.XTextBox txtCodeType;
		private IHIS.Framework.SingleLayout layDupM;
        private IHIS.Framework.SingleLayout layDupD;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SCH0109U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //this.grdMaster.SavePerformer = new XSavePerformer(this);
            //this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            //this.SaveLayoutList.Add(this.grdMaster);
            //this.SaveLayoutList.Add(this.grdDetail);

            this.grdMaster.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code_type", "f_code_type_name" });
            this.grdDetail.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code_type" });
            this.layDupD.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code_type", "f_code" });

		    this.grdMaster.ExecuteQuery = LoadDataGrdMaster;
		    this.grdDetail.ExecuteQuery = LoadDataGrdDetail;
		    this.layDupD.ExecuteQuery = LoadDataLayDupD;
		}

        /// <summary>
        /// Load data for layDupD
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayDupD(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SCH0109U00LayDupDArgs args = new SCH0109U00LayDupDArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            SCH0109U00LayDupDResult result = CloudService.Instance.Submit<SCH0109U00LayDupDResult, SCH0109U00LayDupDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.RetValue
                });
            }
            return res;
        } 


        /// <summary>
        /// Loaddata for grdDetail
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private List<object[]> LoadDataGrdDetail(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SCH0109U00GrdDetailArgs args = new SCH0109U00GrdDetailArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            SCH0109U00GrdDetailResult result = CloudService.Instance.Submit<SCH0109U00GrdDetailResult, SCH0109U00GrdDetailArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (SCH0109U00GrdDetailInfo item in result.GrdDetailList)
                {
                    object[] objects = 
				    { 
					    item.CodeType, 
					    item.Code, 
					    item.CodeName, 
					    item.CodeName2, 
					    item.Code2, 
					    item.DataRowState
				    };
                    res.Add(objects);
                }
            }
            return res;
        } 


        /// <summary>
        /// load data for grdMaster
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private List<object[]> LoadDataGrdMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SCH0109U00GrdMasterArgs args = new SCH0109U00GrdMasterArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            args.CodeTypeName = bc["f_code_type_name"] != null ? bc["f_code_type_name"].VarValue : "";
            SCH0109U00GrdMasterResult result = CloudService.Instance.Submit<SCH0109U00GrdMasterResult, SCH0109U00GrdMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (SCH0109U00GrdMasterInfo item in result.GrdMasterList)
                {
                    object[] objects = 
				    { 
					    item.CodeType, 
					    item.CodeTypeName, 
					    item.DataRowState
				    };
                    res.Add(objects);
                }
            }
            return res;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0109U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtCodeTypeName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtCodeType = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.layDupM = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDupD = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.grdDetail);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7});
            this.grdDetail.ColPerLine = 4;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 5;
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
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 235;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 40;
            this.xEditGridCell6.CellName = "code_name2";
            this.xEditGridCell6.CellWidth = 145;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "code2";
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 1;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 2;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(21);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 20;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 120;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 323;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
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
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.grdMaster);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.txtCodeTypeName);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.txtCodeType);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // txtCodeTypeName
            // 
            this.txtCodeTypeName.AccessibleDescription = null;
            this.txtCodeTypeName.AccessibleName = null;
            resources.ApplyResources(this.txtCodeTypeName, "txtCodeTypeName");
            this.txtCodeTypeName.BackgroundImage = null;
            this.txtCodeTypeName.Name = "txtCodeTypeName";
            this.txtCodeTypeName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtCodeTypeName_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // txtCodeType
            // 
            this.txtCodeType.AccessibleDescription = null;
            this.txtCodeType.AccessibleName = null;
            resources.ApplyResources(this.txtCodeType, "txtCodeType");
            this.txtCodeType.BackgroundImage = null;
            this.txtCodeType.Name = "txtCodeType";
            this.txtCodeType.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtCodeType_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "code";
            this.xEditGridCell17.Col = 4;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            // 
            // layDupM
            // 
            this.layDupM.ExecuteQuery = null;
            this.layDupM.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupM.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupM.ParamList")));
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
            this.layDupD.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupD_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // SCH0109U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Name = "SCH0109U00";
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.xPanel4.ResumeLayout(false);
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
			this.grdDetail.SetRelationKey("code_type","code_type");
			this.grdDetail.SetRelationTable("cpl0109");
			this.CurrMQLayout = this.grdMaster;

            this.grdMaster.QueryLayout(true);
		}
		#endregion

		#region 마스터 테이블 중복체크(입력시 code type)
		private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
            //DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;
            //// 입력 버튼이 클릭 되었을 때만 체크
            //if ( rowState == DataRowState.Added )
            //{
            //    // 입력된 셀이 코드타입 컬럼이라면,
            //    if ( e.ColName == "code_type" )
            //    {
            //        // 만약 마스터테이블에 존재한다면, 'Y'를 그렇지않으면, 'N'을 리턴
            //        this.layDupM.QueryLayout();
            //        if ( this.layDupM.GetItemValue("dup_yn").ToString() == "Y" )
            //        {
            //            string msg = Resources.MSG001_MSG;
            //            XMessageBox.Show( this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber,"code_type")  +
            //                msg,Resources.MSG001_CAP, MessageBoxButtons.OK );
            //            e.Cancel = true;
            //        }
            //    }
            //}
		}
		#endregion

		#region 디테일 테이블 중복체크(입력시 code)
		private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			DataRowState rowState = this.grdDetail.LayoutTable.Rows[this.grdDetail.CurrentRowNumber].RowState;
			//입력 버튼이 클릭 되었을 때만 체크
			if ( rowState == DataRowState.Added )
			{
				// 입력된 셀이 코드 컬럼이면,
				if ( e.ColName == "code" )
				{
                    this.layDupD.QueryLayout();
                    if (this.layDupD.GetItemValue("dup_yn").ToString() == "Y")
					{
						string msg = Resources.MSG002_MSG;
						XMessageBox.Show( this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber,"code") +
							msg,Resources.MSG001_CAP, MessageBoxButtons.OK );
						e.Cancel = true;
					}
				}
			}
		}
		#endregion

		private void txtCodeType_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.txtCodeTypeName.SetDataValue("");
			this.grdMaster.QueryLayout(false);
		}

		private void txtCodeTypeName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.grdMaster.QueryLayout(false);
		}


        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMaster.SetBindVarValue("f_code_type", this.txtCodeType.GetDataValue());
            this.grdMaster.SetBindVarValue("f_code_type_name", this.txtCodeTypeName.GetDataValue());
        }

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
        }

        private void layDupD_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupD.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupD.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
            this.layDupD.SetBindVarValue("f_code", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "code"));
        }

        #region XSavePerformer

//        private class XSavePerformer : ISavePerformer
//        {
//            private SCH0109U00 parent;

//            public XSavePerformer(SCH0109U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";

//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);

//                switch (callerID)
//                { 
//                    case '1':
//                        switch (item.RowState)
//                        { 
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO SCH0108 
//                                                 ( SYS_DATE     , SYS_ID          
//                                                 , UPD_DATE     , UPD_ID        , HOSP_CODE
//                                                 , CODE_TYPE    , CODE_TYPE_NAME  ) 
//                                            VALUES 
//                                                 ( SYSDATE      , :q_user_id        
//                                                 , SYSDATE      , :q_user_id    , :f_hosp_code
//                                                 , :f_code_type , :f_code_type_name )";
//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE SCH0108
//                                               SET UPD_ID          = :q_user_id
//                                                 , UPD_DATE        = SYSDATE
//                                                 , CODE_TYPE_NAME  = :f_code_type_name
//                                             WHERE HOSP_CODE       = :f_hosp_code
//                                               AND CODE_TYPE       = :f_code_type";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DECLARE
//                                               RESULT   VARCHAR2(1);
//                                            BEGIN
//                                               RESULT := 'N';
//                                               FOR X IN (SELECT 'X' 
//                                                           FROM SCH0109
//                                                          WHERE HOSP_CODE = :f_hosp_code
//                                                            AND CODE_TYPE = :f_code_type) LOOP
//                                                   RESULT := 'Y';
//                                               END LOOP;
//                                               
//                                               IF RESULT = 'Y' THEN
//                                                  DELETE SCH0109
//                                                   WHERE HOSP_CODE = :f_hosp_code
//                                                     AND CODE_TYPE = :f_code_type;
//                                               END IF;
//
//                                               DELETE SCH0108
//                                                WHERE HOSP_CODE = :f_hosp_code
//                                                  AND CODE_TYPE = :f_code_type;
//                                            END; ";

//                                break;
//                        }
//                        break;

//                    case '2':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO SCH0109 
//                                                 ( SYS_DATE     , SYS_ID        
//                                                 , UPD_DATE     , UPD_ID        , HOSP_CODE
//                                                 , CODE_TYPE    , CODE          , CODE_NAME
//                                                 , CODE_NAME2   , CODE2         ) 
//                                            VALUES 
//                                                 ( SYSDATE      , :q_user_id
//                                                 , SYSDATE      , :q_user_id    , :f_hosp_code
//                                                 , :f_code_type , :f_code       , :f_code_name
//                                                 , :f_code_name2, :f_code2      )";
//                                break;

//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE SCH0109
//                                               SET SYS_ID     = :q_user_id
//                                                 , UPD_DATE   = SYSDATE
//                                                 , CODE_NAME  = :f_code_name
//                                                 , CODE_NAME2 = :f_code_name2
//                                                 , CODE2      = :f_code2
//                                             WHERE HOSP_CODE  = :f_hosp_code
//                                               AND CODE_TYPE  = :f_code_type
//                                               AND CODE       = :f_code";
//                                break;

//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE SCH0109
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

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
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
                    if (SaveGrdDetail())
                    {
                        //XMessageBox.Show("Save done!");
                        this.grdDetail.QueryLayout(false);
                    }
                    else
                    {
                        //XMessageBox.Show("Save failed!");
                    }
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// save all changed items in grdDetail
        /// </summary>
        /// <returns></returns>
	    private bool SaveGrdDetail()
	    {
            List<SCH0109U00GrdDetailInfo> inputList = GetListFromGrdDetail();
	        if (inputList.Count == 0)
	        {
	            return false;
	        }
            SCH0109U00XSavePerformerArgs args = new SCH0109U00XSavePerformerArgs(inputList, UserInfo.UserID);
	        UpdateResult result = CloudService.Instance.Submit<UpdateResult, SCH0109U00XSavePerformerArgs>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            return result.Result;
	        }
	        return false;
	    }

        /// <summary>
        /// get all changed item to List object
        /// </summary>
        /// <returns></returns>
	    private List<SCH0109U00GrdDetailInfo> GetListFromGrdDetail()
	    {
	        List<SCH0109U00GrdDetailInfo> dataList = new List<SCH0109U00GrdDetailInfo>();
	        for (int i = 0; i < grdDetail.RowCount; i++)
	        {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged || String.IsNullOrEmpty(grdDetail.GetItemString(i, "code")))
	            {
	                continue;
	            }

                SCH0109U00GrdDetailInfo info = new SCH0109U00GrdDetailInfo();
	            info.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                info.Code = grdDetail.GetItemString(i, "code");
                info.CodeName = grdDetail.GetItemString(i, "code_name");
                info.CodeName2 = grdDetail.GetItemString(i, "code_name2");
                info.Code2 = grdDetail.GetItemString(i, "code2");
	            info.DataRowState = grdDetail.GetRowState(i).ToString();

                dataList.Add(info);
	        }

	        if (grdDetail.DeletedRowTable != null && grdDetail.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
	            {
                    SCH0109U00GrdDetailInfo info = new SCH0109U00GrdDetailInfo();
	                info.Code = row["code"].ToString();
                    info.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
	                info.DataRowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
	            }       
	        }
            return dataList;
	    }
	}
}

