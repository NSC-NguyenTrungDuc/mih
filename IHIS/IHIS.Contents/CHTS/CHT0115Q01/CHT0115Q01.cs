#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CHTS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Chts;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Chts;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
#endregion

namespace IHIS.CHTS
{
	/// <summary>
	/// CHT0110U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CHT0115Q01 : IHIS.Framework.XScreen
	{
        private string mbxMsg = "";
        private string mbxCap = "";

        private XPanel xPanel1;
        private XEditGrid grdCHT0115;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XButtonList xButtonList;
        private XPanel xPanel2;
        private XDictComboBox cboDetailGubun;
        private XLabel xLabel1;


        /// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CHT0115Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //set ParamList
            grdCHT0115.ParamList = new List<string>(new String[] { "f_susik_detail_gubun", "f_code_type", "f_page_number" });

            //set ExecuteQuery
		    grdCHT0115.ExecuteQuery = LoadDataGrdCHT0115;
		    cboDetailGubun.ExecuteQuery = LoadDataCboDetailGubun;

            //initialize comboBox
		    cboDetailGubun.SetDictDDLB();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHT0115Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xButtonList = new IHIS.Framework.XButtonList();
            this.grdCHT0115 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboDetailGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0115)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xButtonList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.Location = new System.Drawing.Point(0, 550);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1165, 35);
            this.xPanel1.TabIndex = 0;
            // 
            // xButtonList
            // 
            this.xButtonList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.xButtonList.Location = new System.Drawing.Point(678, 0);
            this.xButtonList.Name = "xButtonList";
            this.xButtonList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList.Size = new System.Drawing.Size(487, 35);
            this.xButtonList.TabIndex = 0;
            this.xButtonList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdCHT0115
            // 
            this.grdCHT0115.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13});
            this.grdCHT0115.ColPerLine = 13;
            this.grdCHT0115.Cols = 13;
            this.grdCHT0115.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCHT0115.ExecuteQuery = null;
            this.grdCHT0115.FixedRows = 1;
            this.grdCHT0115.HeaderHeights.Add(31);
            this.grdCHT0115.Location = new System.Drawing.Point(0, 34);
            this.grdCHT0115.Name = "grdCHT0115";
            this.grdCHT0115.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCHT0115.ParamList")));
            this.grdCHT0115.QuerySQL = resources.GetString("grdCHT0115.QuerySQL");
            this.grdCHT0115.Rows = 2;
            this.grdCHT0115.Size = new System.Drawing.Size(1165, 516);
            this.grdCHT0115.TabIndex = 1;
            this.grdCHT0115.ToolTipActive = true;
            this.grdCHT0115.PreEndInitializing += new System.EventHandler(this.grdCHT0115_PreEndInitializing);
            this.grdCHT0115.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCHT0115_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "susik_code";
            this.xEditGridCell1.CellWidth = 86;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderText = "修飾語\r\n コード";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 40;
            this.xEditGridCell2.CellName = "susik_name";
            this.xEditGridCell2.CellWidth = 159;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderText = "修飾語名称";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 60;
            this.xEditGridCell3.CellName = "susik_name_gana";
            this.xEditGridCell3.CellWidth = 164;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderText = "カナ";
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "susik_cr_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 70;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderText = "収載年月日";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "susik_upd_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 106;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderText = "変更年月日";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "susik_disable_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 70;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderText = "廃止年月日";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 8;
            this.xEditGridCell7.CellName = "susik_gwanri_no";
            this.xEditGridCell7.CellWidth = 89;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderText = "管理番号";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 8;
            this.xEditGridCell8.CellName = "susik_gubun";
            this.xEditGridCell8.CellWidth = 65;
            this.xEditGridCell8.Col = 8;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderText = "区分";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 9;
            this.xEditGridCell9.CellName = "susik_change_code";
            this.xEditGridCell9.CellWidth = 79;
            this.xEditGridCell9.Col = 7;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderText = "交換用\r\n コード";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 1;
            this.xEditGridCell10.CellName = "susik_detail_gubun";
            this.xEditGridCell10.CellWidth = 94;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderText = "詳細区分";
            this.xEditGridCell10.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "start_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 84;
            this.xEditGridCell11.Col = 10;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderText = "開始日付";
            this.xEditGridCell11.IsUpdatable = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "end_date";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.CellWidth = 92;
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderText = "終了日付";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "sort";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.CellWidth = 70;
            this.xEditGridCell13.Col = 12;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderText = "順\r\n番";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.cboDetailGubun);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1165, 34);
            this.xPanel2.TabIndex = 2;
            // 
            // cboDetailGubun
            // 
            this.cboDetailGubun.ExecuteQuery = null;
            this.cboDetailGubun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboDetailGubun.Location = new System.Drawing.Point(77, 6);
            this.cboDetailGubun.Name = "cboDetailGubun";
            this.cboDetailGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDetailGubun.ParamList")));
            this.cboDetailGubun.Size = new System.Drawing.Size(171, 21);
            this.cboDetailGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDetailGubun.TabIndex = 1;
            this.cboDetailGubun.SelectedValueChanged += new System.EventHandler(this.cboDetailGubun_SelectedValueChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.xLabel1.Location = new System.Drawing.Point(6, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(71, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "詳細区分";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CHT0115Q01
            // 
            this.Controls.Add(this.grdCHT0115);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "CHT0115Q01";
            this.Size = new System.Drawing.Size(1165, 585);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0115)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{	
			//Set Current Grid
			this.CurrMSLayout = this.grdCHT0115;
			this.CurrMQLayout = this.grdCHT0115;

            //this.grdCHT0115.SavePerformer = new XSavePerformer(this);
            this.cboDetailGubun.SelectedIndex = 0;
			            
			//상병조회
			this.grdCHT0115.QueryLayout(false);
		}		
		
		#endregion
        		
		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			SetMsg("");

			switch (e.Func)
			{
				case FunctionType.Insert:
					
					
					break;
				

				case FunctionType.Update:

                    e.IsBaseCall = false;

                    //if(this.grdCHT0115.SaveLayout())
					if(SaveGrdCHT0115())
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.mbxMsg_JP : Resource.mbxMsg_Ko;
						SetMsg(mbxMsg);
					    this.grdCHT0115.QueryLayout(false);
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.mbxMsg2_JP : Resource.mbxMsg2_Ko; 
						mbxMsg = mbxMsg + Service.ErrMsg;
						mbxCap = NetInfo.Language == LangMode.Jr ? Resource.mbxCap_JP : "Save Error";
						XMessageBox.Show(mbxMsg, mbxCap);
					}

					break;
					
				default:

					break;
			}
		}


	    #endregion

        private void grdCHT0115_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdCHT0115.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdCHT0115.SetBindVarValue("f_susik_detail_gubun", this.cboDetailGubun.GetDataValue());
        }

        private void cboDetailGubun_SelectedValueChanged(object sender, EventArgs e)
        {
            this.grdCHT0115.QueryLayout(false);
        }
		
        string mErrMsg = "";
        #region XSavePerformer
//        private class XSavePerformer : ISavePerformer
//        {
//            CHT0115Q01 parent;

//            public XSavePerformer(CHT0115Q01 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                
//                parent.mErrMsg = "";

//                switch (item.RowState)
//                { 
//                    case DataRowState.Added:

//                        cmdText = @"SELECT 'Y'
//                                      FROM CHT0115
//                                     WHERE HOSP_CODE  = :f_hosp_code
//                                       AND SUSIK_CODE = :f_susik_code
//                                       AND ROWNUM = 1";
//                        object t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (!TypeCheck.IsNull(t_chk))
//                        {
//                            if (t_chk.ToString() == "Y")
//                            {
//                                parent.mErrMsg = "[" + item.BindVarList["f_susik_code"].VarValue + Resource.parent;
//                                return false;
//                            }
//                        }

//                        cmdText = @"INSERT INTO CHT0115
//                                       ( SYS_DATE           , SYS_ID             , 
//                                         UPD_DATE           , UPD_ID             , HOSP_CODE          ,
//                                         SUSIK_CODE         , SUSIK_NAME         , SUSIK_NAME_GANA    , 
//                                         SUSIK_CR_DATE      , SUSIK_UPD_DATE     , SUSIK_DISABLE_DATE ,
//                                         SUSIK_GWANRI_NO    , SUSIK_GUBUN        , SUSIK_CHANGE_CODE  ,
//                                         SUSIK_DETAIL_GUBUN , START_DATE         , END_DATE           ,
//                                         SORT )
//                                 VALUES
//                                       ( SYSDATE               , :q_user_id            , 
//                                         SYSDATE               , :q_user_id            , :f_hosp_code          , 
//                                         :f_susik_code         , :f_susik_name         , :f_susik_name_gana    , 
//                                         :f_susik_cr_date      , :f_susik_upd_date     , :f_susik_disable_date ,
//                                         :f_susik_gwanri_no    , :f_susik_gubun        , :f_susik_change_code  , 
//                                         :f_susik_detail_gubun , :f_start_date         , :f_end_date           ,
//                                         :f_sort              )";


//                        break;

//                    case DataRowState.Modified:

//                        cmdText = @"UPDATE CHT0115
//                                       SET UPD_ID              = :q_user_id            ,
//                                           UPD_DATE            = SYSDATE               ,                                           
//                                           SUSIK_NAME          = :f_susik_name      ,
//                                           SUSIK_NAME_GANA     = :f_susik_name_gana     ,
//                                           SUSIK_CR_DATE       = :f_susik_cr_date           ,
//                                           SUSIK_UPD_DATE      = :f_susik_upd_date         ,  
//                                           SUSIK_DISABLE_DATE  = :f_susik_disable_date      ,
//                                           SUSIK_GWANRI_NO     = :f_susik_gwanri_no     ,
//                                           SUSIK_GUBUN         = :f_susik_gubun           ,
//                                           SUSIK_CHANGE_CODE   = :f_susik_change_code         ,    
//                                           SUSIK_DETAIL_GUBUN  = :f_susik_detail_gubun           ,                                              
//                                           END_DATE            = :f_end_date           ,
//                                           SORT                = :f_sort           
//                                     WHERE HOSP_CODE           = :f_hosp_code
//                                       AND SUSIK_CODE          = :f_susik_code 
//                                       AND START_DATE          = :f_start_date       ";
//                        break;

//                    case DataRowState.Deleted:

//                        cmdText = @"DELETE CHT0115
//                                     WHERE HOSP_CODE           = :f_hosp_code
//                                       AND SUSIK_CODE          = :f_susik_code 
//                                       AND START_DATE          = :f_start_date       ";
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        private void grdCHT0115_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell10.ExecuteQuery = LoadDataXEditGridCell10;
        }

	    #region CloudService

        private IList<object[]> LoadDataXEditGridCell10(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            CHTSXEditSusikGubunArgs args = new CHTSXEditSusikGubunArgs();
            //ComboResult result =
            //    CacheService.Instance.Get<CHTSXEditSusikGubunArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_CHTS_XEDITGRIDCELL_SUSIK_GUBUN, args, delegate(ComboResult comboResult)
            //        {
            //            return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
            //                   comboResult.ComboItem.Count > 0;
            //        });
            ComboResult result = CacheService.Instance.Get<CHTSXEditSusikGubunArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }

            return res;
        }

        private IList<object[]> LoadDataCboDetailGubun(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            CHTSCboSusikGubunArgs args = new CHTSCboSusikGubunArgs();
            //ComboResult result =
            //    CacheService.Instance.Get<CHTSCboSusikGubunArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_CHTS_CBO_SUSIK_GUBUN, args, delegate(ComboResult comboResult)
            //        {
            //            return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
            //                   comboResult.ComboItem.Count > 0;
            //        });
            ComboResult result = CacheService.Instance.Get<CHTSCboSusikGubunArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }

            return res;
        }

        private List<object[]> LoadDataGrdCHT0115(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        CHT0115Q01grdCHT0115Args args = new CHT0115Q01grdCHT0115Args();
            args.SusikDetailGubun = bc["f_susik_detail_gubun"] != null
                ? bc["f_susik_detail_gubun"].VarValue
	            : "";
            args.PageNumber = bc["f_page_number"].VarValue;
            args.Offset = "200";
	        CHT0115Q01grdCHT0115Result result =
	            CloudService.Instance.Submit<CHT0115Q01grdCHT0115Result, CHT0115Q01grdCHT0115Args>(
	                args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (CHT0115Q01grdCHT0115Info item in result.ListGrdInfo)
	            {
	                object[] objects =
	                {
	                    item.SusikCode,
	                    item.SusikName,
	                    item.SusikNameGana,
	                    item.SusikCrDate,
	                    item.SusikUpdDate,
	                    item.SusikDisableDate,
	                    item.SusikGwanriNo,
	                    item.SusikGubun,
	                    item.SusikChangeCode,
	                    item.SusikDetailGubun,
	                    item.StartDate,
	                    item.EndDate,
	                    item.Sort
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        private bool SaveGrdCHT0115()
        {
            List<CHT0115Q01grdCHT0115Info> inputList = GetListFromGrdCHT0115();
            if (inputList.Count == 0)
            {
                return true;
            }

            CHT0115Q01TransactionalArgs args = new CHT0115Q01TransactionalArgs(inputList, UserInfo.UserID);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, CHT0115Q01TransactionalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (!result.Result)
                {
                    if (result.Msg != "")
                    {
                        String cloudMsg = "[" + result.Msg + Resource.parent;
                        XMessageBox.Show(cloudMsg);
                    }
                }

                return result.Result;
            }

            return false;
        }

	    private List<CHT0115Q01grdCHT0115Info> GetListFromGrdCHT0115()
	    {
	        List<CHT0115Q01grdCHT0115Info> dataList = new List<CHT0115Q01grdCHT0115Info>();
	        for (int i = 0; i < grdCHT0115.RowCount; i++)
	        {
	            if (grdCHT0115.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }
	            CHT0115Q01grdCHT0115Info info = new CHT0115Q01grdCHT0115Info();
                info.SusikCode = grdCHT0115.GetItemString(i, "susik_code");
                info.SusikName = grdCHT0115.GetItemString(i, "susik_name");
                info.SusikNameGana = grdCHT0115.GetItemString(i, "susik_name_gana");
                info.SusikCrDate = grdCHT0115.GetItemString(i, "susik_cr_date");
                info.SusikUpdDate = grdCHT0115.GetItemString(i, "susik_upd_date");
                info.SusikDisableDate = grdCHT0115.GetItemString(i, "susik_disable_date");
                info.SusikGwanriNo = grdCHT0115.GetItemString(i, "susik_gwanri_no");
                info.SusikGubun = grdCHT0115.GetItemString(i, "susik_gubun");
                info.SusikChangeCode = grdCHT0115.GetItemString(i, "susik_change_code");
                info.SusikDetailGubun = grdCHT0115.GetItemString(i, "susik_detail_gubun");
                info.StartDate = grdCHT0115.GetItemString(i, "start_date");
                info.EndDate = grdCHT0115.GetItemString(i, "end_date");
                info.Sort = grdCHT0115.GetItemString(i, "sort");
	            info.RowState = grdCHT0115.GetRowState(i).ToString();

                dataList.Add(info);
	        }

	        if (grdCHT0115.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdCHT0115.DeletedRowTable.Rows)
	            {
                    CHT0115Q01grdCHT0115Info info = new CHT0115Q01grdCHT0115Info();
	                info.SusikCode = row["susik_code"].ToString();
                    info.StartDate = row["start_date"].ToString();
	                info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
	            }
	        }
	        return dataList;
	    }

	    #endregion






    }
}

