using System.Collections.Generic;
using IFC.ADM.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Messaging;
using ADM201UGrdDicDetailItemInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM201UGrdDicDetailItemInfo;
using ADM201UGrdDicMasterItemInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM201UGrdDicMasterItemInfo;

#region 사용 NameSpace 지정

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Data;
#endregion

#region 작성자 정보
// 작  성  일 : 2005. 1. 28
// 작  성  자 : 신 종 석
// 관련테이블 : ADM101M00, ADM101M10
// 내      용 : 자료사전 입력, 수정, 검색 화면
#endregion

namespace IHIS.ADMA
{
	#region 자료사전 등록 ADM201U 메인 클래스
	/// <summary>
	/// ADM201U에 대한 요약 설명입니다.
	/// </summary?
	[ToolboxItem(false)]
	public class ADM201U : IHIS.Framework.XScreen
	{
		[DataBindable]
		public string BindProp
		{
			get { return "A";}
			set { }
		}
		private IHIS.Framework.XPanel pnlComment;
		private IHIS.Framework.XEditGrid grdDicDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XPanel xPanel1;
		private System.ComponentModel.IContainer components = null;
		private IHIS.Framework.XMstGrid grdDicMaster;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XTextBox txtComment;
		private IHIS.Framework.XButtonList btnListEntry;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.MultiLayout multiLayout1;
		private IHIS.Framework.SingleLayout singleLayout1;
		private IHIS.Framework.XLabel lblComment;
        private const int maxPagerow = 200;

		/// <summary>
		/// 기본 생성자
		/// </summary>
		public ADM201U()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            
			//저장 Layout List Set
			this.SaveLayoutList.Add(this.grdDicMaster);
			this.SaveLayoutList.Add(this.grdDicDetail);
			//저장 Performer Set
			//this.grdDicMaster.SavePerformer = new XSavePerformer(this);
			//this.grdDicDetail.SavePerformer = grdDicMaster.SavePerformer;

		    this.grdDicMaster.ParamList = CreateGrdDicMasterParamList();
		    this.grdDicMaster.ExecuteQuery = LoadGrdDicMaster;
		    this.grdDicDetail.ParamList = CreateGrdDicDetailParamList();
		    this.grdDicDetail.ExecuteQuery = LoadGrdDicDetail;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM201U));
            this.pnlComment = new IHIS.Framework.XPanel();
            this.txtComment = new IHIS.Framework.XTextBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.lblComment = new IHIS.Framework.XLabel();
            this.grdDicDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.grdDicMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.btnListEntry = new IHIS.Framework.XButtonList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.multiLayout1 = new IHIS.Framework.MultiLayout();
            this.singleLayout1 = new IHIS.Framework.SingleLayout();
            this.pnlComment.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDicDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDicMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnListEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiLayout1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // pnlComment
            // 
            this.pnlComment.AccessibleDescription = null;
            this.pnlComment.AccessibleName = null;
            resources.ApplyResources(this.pnlComment, "pnlComment");
            this.pnlComment.BackgroundImage = null;
            this.pnlComment.Controls.Add(this.txtComment);
            this.pnlComment.Controls.Add(this.xPanel1);
            this.pnlComment.Font = null;
            this.pnlComment.Name = "pnlComment";
            // 
            // txtComment
            // 
            this.txtComment.AccessibleDescription = null;
            this.txtComment.AccessibleName = null;
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.BackgroundImage = null;
            this.txtComment.Font = null;
            this.txtComment.Name = "txtComment";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.lblComment);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // lblComment
            // 
            this.lblComment.AccessibleDescription = null;
            this.lblComment.AccessibleName = null;
            resources.ApplyResources(this.lblComment, "lblComment");
            this.lblComment.BackColor = IHIS.Framework.XColor.XFindBoxFindBackColor;
            this.lblComment.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.lblComment.BorderColor = IHIS.Framework.XColor.XFindBoxFindBackColor;
            this.lblComment.GradientEndColor = IHIS.Framework.XColor.XFindBoxFindBackColor;
            this.lblComment.Image = null;
            this.lblComment.Name = "lblComment";
            // 
            // grdDicDetail
            // 
            resources.ApplyResources(this.grdDicDetail, "grdDicDetail");
            this.grdDicDetail.CallerID = '2';
            this.grdDicDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdDicDetail.ColPerLine = 2;
            this.grdDicDetail.Cols = 2;
            this.grdDicDetail.ExecuteQuery = null;
            this.grdDicDetail.FixedRows = 1;
            this.grdDicDetail.HeaderHeights.Add(35);
            this.grdDicDetail.MasterLayout = this.grdDicMaster;
            this.grdDicDetail.Name = "grdDicDetail";
            this.grdDicDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDicDetail.ParamList")));
            this.grdDicDetail.QuerySQL = "SELECT A.COL_ID, A.CODE, A.CODE_NM   \r\n  FROM ADM1110 A\r\n WHERE A.COL_ID = :f_col" +
                "_id\r\n ORDER BY A.COL_ID, A.CODE";
            this.grdDicDetail.Rows = 2;
            this.grdDicDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDicDetail_QueryStarting);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 30;
            this.xEditGridCell7.CellName = "col_id";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "code";
            this.xEditGridCell8.CellWidth = 102;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 30;
            this.xEditGridCell9.CellName = "code_nm";
            this.xEditGridCell9.CellWidth = 154;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCell9.IsNotNull = true;
            // 
            // grdDicMaster
            // 
            resources.ApplyResources(this.grdDicMaster, "grdDicMaster");
            this.grdDicMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell5});
            this.grdDicMaster.ColPerLine = 5;
            this.grdDicMaster.Cols = 5;
            this.grdDicMaster.ControlBinding = true;
            this.grdDicMaster.ExecuteQuery = null;
            this.grdDicMaster.FixedRows = 1;
            this.grdDicMaster.HeaderHeights.Add(35);
            this.grdDicMaster.Name = "grdDicMaster";
            this.grdDicMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDicMaster.ParamList")));
            this.grdDicMaster.QuerySQL = "SELECT A.COL_ID, A.COL_NM, A.COL_TP, A.COL_LEN, A.COL_SCAL , A.CMMT\r\n  FROM ADM11" +
                "00 A\r\n WHERE (A.COL_ID LIKE \'%\'||:f_col_id ||\'%\' AND A.COL_NM LIKE \'%\'||:f_col_n" +
                "m || \'%\') ";
            this.grdDicMaster.Rows = 2;
            this.grdDicMaster.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdDicMaster_RowFocusChanging);
            this.grdDicMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDicMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "col_id";
            this.xEditGridCell1.CellWidth = 144;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 50;
            this.xEditGridCell2.CellName = "col_nm";
            this.xEditGridCell2.CellWidth = 248;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 1;
            this.xEditGridCell3.CellName = "col_tp";
            this.xEditGridCell3.CellWidth = 110;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.DictColumn = "COL_TP";
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 4;
            this.xEditGridCell4.CellName = "col_len";
            this.xEditGridCell4.CellWidth = 58;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.txtComment;
            this.xEditGridCell6.CellName = "cmmt";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 1;
            this.xEditGridCell5.CellName = "col_scal";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.CellWidth = 72;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // btnListEntry
            // 
            this.btnListEntry.AccessibleDescription = null;
            this.btnListEntry.AccessibleName = null;
            resources.ApplyResources(this.btnListEntry, "btnListEntry");
            this.btnListEntry.BackgroundImage = null;
            this.btnListEntry.Font = null;
            this.btnListEntry.Name = "btnListEntry";
            this.btnListEntry.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnListEntry.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnListEntry_ButtonClick);
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
            // multiLayout1
            // 
            this.multiLayout1.ExecuteQuery = null;
            this.multiLayout1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("multiLayout1.ParamList")));
            // 
            // singleLayout1
            // 
            this.singleLayout1.ExecuteQuery = null;
            this.singleLayout1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("singleLayout1.ParamList")));
            // 
            // ADM201U
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdDicDetail);
            this.Controls.Add(this.grdDicMaster);
            this.Controls.Add(this.btnListEntry);
            this.Controls.Add(this.pnlComment);
            this.Font = null;
            this.Name = "ADM201U";
            this.pnlComment.ResumeLayout(false);
            this.pnlComment.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDicDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDicMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnListEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiLayout1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Form Load Event
	
		/// <summary>
		/// 최초 Load시 발생하는 이벤트 핸들러
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			// TODO:  ADM201U.OnLoad 구현을 추가합니다.

			this.grdDicDetail.SetRelationKey("col_id","col_id");      /* 디테일 마스터 간의 관계 설정 */
			this.grdDicDetail.SetRelationTable("ADM1110");
            base.OnLoad (e);

			this.CurrMSLayout = this.grdDicMaster;
			this.CurrMQLayout = this.grdDicMaster;

			//최초 행 입력
			this.grdDicMaster.InsertRow();
		}

		#endregion


		private void grdDicMaster_RowFocusChanging(object sender, IHIS.Framework.RowFocusChangingEventArgs e)
		{
			//Row변경전 Detail에 수정된 값이 있으면 저장 확인
			if ((e.CurrentRow >= 0) && (this.grdDicDetail.GetChangedRowCount('A') > 0))
			{
				if (XMessageBox.Show("자료사전 Detail에 변경된 내용이 있습니다. 저장하시겠습니까?", "변경내역확인", MessageBoxButtons.YesNo)
					== DialogResult.Yes)
				{
					this.btnListEntry.PerformClick(FunctionType.Update);
				}
			}
		}

		private void grdDicDetail_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//조회조건 BIND 변수 SET (MASTER의 col_id SET)
			int rowNum = grdDicMaster.CurrentRowNumber;
			if (rowNum >= 0)
				this.grdDicDetail.SetBindVarValue("f_col_id", grdDicMaster.GetItemValue(rowNum, "col_id").ToString());
			else
				e.Cancel = true; //조회하지 않음
																										  

		}

		private void grdDicMaster_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//조회조건 BIND 변수 SET (f_col_id, f_col_nm)
			int rowNum = grdDicMaster.CurrentRowNumber;
			if (rowNum >= 0)
			{
				this.grdDicMaster.SetBindVarValue("f_col_id", grdDicMaster.GetItemValue(rowNum, "col_id").ToString());
				this.grdDicMaster.SetBindVarValue("f_col_nm", grdDicMaster.GetItemValue(rowNum, "col_nm").ToString());
			}
		}

		#region XSavePerformer
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private ADM201U parent = null;
			public XSavePerformer(ADM201U parent)
			{
				this.parent = parent;
			}
			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdText = "";
				//Grid에서 넘어온 Bind 변수에 f_user_id SET
				item.BindVarList.Add("f_user_id", UserInfo.UserID);

				switch (callerID)
				{
					case '1':  //자료사전 MASTER 저장(ADM1100)
					switch (item.RowState)
					{
						case DataRowState.Added:
							cmdText 
								= "INSERT INTO ADM1100 "
								+ " (COL_ID,    COL_NM,    COL_TP,    COL_LEN, COL_SCAL, CMMT, CR_MEMB, CR_TIME) "
								+ "VALUES"
								+ " (:f_col_id, :f_col_nm, :f_col_tp, :f_col_len, :f_col_scal, :f_cmmt, :f_user_id, SYSDATE)";
							break;
						case DataRowState.Modified:
							cmdText
								= "UPDATE ADM1100"
								+ "   SET COL_NM   = :f_col_nm"
								+ "      ,COL_TP   = :f_col_tp"
								+ "      ,COL_LEN  = :f_col_len"
								+ "      ,COL_SCAL = :f_col_scal"
								+ "      ,CMMT     = :f_cmmt"
								+ "      ,UP_MEMB  = :f_user_id"
								+ "      ,UP_TIME  = SYSDATE"
								+ " WHERE COL_ID   = :f_col_id";
							break;
						case DataRowState.Deleted:
							cmdText
								= "DELETE ADM1100"
								+ " WHERE COL_ID = :f_col_id";
							break;
					}
						break;
					case '2':  //자료사전 Detail 저장
					switch (item.RowState)
					{
						case DataRowState.Added:
							cmdText
								= "INSERT INTO ADM1110"
								+ " (COL_ID,  CODE, CODE_NM, CR_MEMB, CR_TIME)"
								+ " VALUES(:f_col_id, :f_code, :f_code_nm, :f_user_id, SYSDATE)";
							break;
						case DataRowState.Modified:
							cmdText
								= "UPDATE ADM1110"
								+ "   SET CODE_NM    = :f_code_nm"
								+ "      ,UP_MEMB    = :f_user_id"
								+ "      ,UP_TIME    = SYSDATE"
								+ " WHERE COL_ID     = :f_col_id"
								+ "   AND CODE       = :f_code";
							break;
						case DataRowState.Deleted:
							cmdText
								= "DELETE ADM1110 WHERE COL_ID = :f_col_id AND CODE = :f_code";
							break;
					}
						break;
				}

				return Service.ExecuteNonQuery(cmdText, item.BindVarList);
			}
		}
		#endregion

        #region cloud services
        
        private List<string> CreateGrdDicMasterParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_col_id");
            paramList.Add("f_col_nm");
            paramList.Add("f_page_number");
            paramList.Add("f_offset");
            return paramList;
        }

        private List<object[]> LoadGrdDicMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM201UGrdDicMasterArgs args = new ADM201UGrdDicMasterArgs();
            args.ColId = bc["f_col_id"] != null ? bc["f_col_id"].VarValue : "";
            args.ColNm = bc["f_col_nm"] != null ? bc["f_col_nm"].VarValue : "";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            args.Offset = maxPagerow.ToString();
            ADM201UGrdDicMasterResult result = CloudService.Instance.Submit<ADM201UGrdDicMasterResult, ADM201UGrdDicMasterArgs>(args);
            if (result != null)
            {
                foreach (ADM201UGrdDicMasterItemInfo item in result.GrdDicMasterItemInfo)
                {
                    object[] objects = 
				{ 
					item.ColId, 
					item.ColNm, 
					item.ColTp, 
					item.ColLen,
					item.Cmmt,
					item.ColScal
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<string> CreateGrdDicDetailParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_col_id");
            paramList.Add("f_page_number");
            paramList.Add("f_offset");
            return paramList;
        }

        private List<object[]> LoadGrdDicDetail(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM201UGrdDicDetailArgs args = new ADM201UGrdDicDetailArgs();
            args.ColId = bc["f_col_id"] != null ? bc["f_col_id"].VarValue : "";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            args.Offset = maxPagerow.ToString();
            ADM201UGrdDicDetailResult result = CloudService.Instance.Submit<ADM201UGrdDicDetailResult, ADM201UGrdDicDetailArgs>(args);
            if (result != null)
            {
                foreach (ADM201UGrdDicDetailItemInfo item in result.GrdDicDetailItemInfo)
                {
                    object[] objects = 
				    { 
					    item.ColId, 
					    item.Code, 
					    item.CodeNm
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<ADM201UGrdDicMasterItemInfo> GetGrdDicMasterForSaveLayout()
        {
            List<ADM201UGrdDicMasterItemInfo> lstResult = new List<ADM201UGrdDicMasterItemInfo>();

            for (int i = 0; i < grdDicMaster.RowCount; i++)
            {
                if (grdDicMaster.GetRowState(i) == DataRowState.Unchanged) continue;
                ADM201UGrdDicMasterItemInfo item = new ADM201UGrdDicMasterItemInfo();
                item.ColId = grdDicMaster.GetItemString(i, "col_id");
                item.ColNm = grdDicMaster.GetItemString(i, "col_nm");
                item.ColTp = grdDicMaster.GetItemString(i, "col_tp");
                item.ColLen = grdDicMaster.GetItemString(i, "col_len");
                item.ColScal = grdDicMaster.GetItemString(i, "col_scal");
                item.Cmmt = grdDicMaster.GetItemString(i, "cmmt");

                item.DataRowState = grdDicMaster.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdDicMaster.DeletedRowTable)
            {
                foreach (DataRow dr in grdDicMaster.DeletedRowTable.Rows)
                {
                    ADM201UGrdDicMasterItemInfo item = new ADM201UGrdDicMasterItemInfo();
                    item.ColId = Convert.ToString(dr["col_id"]);

                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        private List<ADM201UGrdDicDetailItemInfo> GetGrdDicDetailForSaveLayout()
        {
            List<ADM201UGrdDicDetailItemInfo> lstResult = new List<ADM201UGrdDicDetailItemInfo>();

            for (int i = 0; i < grdDicDetail.RowCount; i++)
            {
                if (grdDicDetail.GetRowState(i) == DataRowState.Unchanged) continue;
                ADM201UGrdDicDetailItemInfo item = new ADM201UGrdDicDetailItemInfo();
                item.ColId = grdDicMaster.GetItemString(this.grdDicMaster.CurrentRowNumber, "col_id");
                item.Code = grdDicDetail.GetItemString(i, "code");
                item.CodeNm = grdDicDetail.GetItemString(i, "code_nm");

                item.DataRowState = grdDicDetail.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdDicDetail.DeletedRowTable)
            {
                foreach (DataRow dr in grdDicDetail.DeletedRowTable.Rows)
                {
                    ADM201UGrdDicDetailItemInfo item = new ADM201UGrdDicDetailItemInfo();
                    item.ColId = Convert.ToString(dr["col_id"]);
                    item.Code = Convert.ToString(dr["code"]);

                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        #endregion

        private void btnListEntry_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    ADM201USaveLayoutArgs args = new ADM201USaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.GrdDicMasterItemInfo = GetGrdDicMasterForSaveLayout();
                    args.GrdDicDetailItemInfo = GetGrdDicDetailForSaveLayout();
                    if (args.GrdDicMasterItemInfo.Count == 0 && args.GrdDicDetailItemInfo.Count == 0)
                    {
                        XMessageBox.Show(Resources.MSG_SAVE_ERROR, Resources.MSG_CAP, MessageBoxIcon.Error);
                    }
                    else
                    {
                        UpdateResult result = CloudService.Instance.Submit<UpdateResult, ADM201USaveLayoutArgs>(args);

                        if (result.ExecutionStatus == ExecutionStatus.Success)
                        {
                            XMessageBox.Show(Resources.MSG_SAVE_SUCCESSS, Resources.MSG_CAP, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XMessageBox.Show(Resources.MSG_SAVE_ERROR, Resources.MSG_CAP, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }
    }

	#endregion
}

