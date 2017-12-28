#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG0202U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG0202U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XEditGrid grdDRG0202;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XButtonList btnList;
        private XToolTip xToolTip1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG0202U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdDRG0202.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdDRG0202);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0202U00));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdDRG0202 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDRG0202)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdDRG0202);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(2, 2);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(956, 740);
            this.xPanel2.TabIndex = 1;
            // 
            // grdDRG0202
            // 
            this.grdDRG0202.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell7});
            this.grdDRG0202.ColPerLine = 6;
            this.grdDRG0202.Cols = 7;
            this.grdDRG0202.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDRG0202.FixedCols = 1;
            this.grdDRG0202.FixedRows = 1;
            this.grdDRG0202.HeaderHeights.Add(21);
            this.grdDRG0202.Location = new System.Drawing.Point(2, 2);
            this.grdDRG0202.Name = "grdDRG0202";
            this.grdDRG0202.QuerySQL = resources.GetString("grdDRG0202.QuerySQL");
            this.grdDRG0202.RowHeaderVisible = true;
            this.grdDRG0202.Rows = 2;
            this.grdDRG0202.Size = new System.Drawing.Size(950, 734);
            this.grdDRG0202.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.grdDRG0202.TabIndex = 0;
            this.grdDRG0202.ToolTipActive = true;
            this.grdDRG0202.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDRG0202_QueryStarting);
            this.grdDRG0202.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDRG0202_GridColumnChanged);
            this.grdDRG0202.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdDRG0202_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.CellWidth = 101;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.HeaderText = "項目コード";
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_name";
            this.xEditGridCell2.CellWidth = 280;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderText = "項目名称";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 99;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.HeaderText = "患者番号";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 99;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.HeaderText = "患者氏名";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "comments";
            this.xEditGridCell5.CellWidth = 221;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.DisplayMemoText = true;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell5.HeaderText = "コメント";
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "use_yn";
            this.xEditGridCell7.CellWidth = 95;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell7.HeaderText = "使用";
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "患者使用";
            this.xComboItem1.ValueItem = "N";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "患者使用不可";
            this.xComboItem2.ValueItem = "Y";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "患者警告";
            this.xComboItem3.ValueItem = "W";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(2, 742);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(956, 36);
            this.xPanel3.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(548, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(406, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // DRG0202U00
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Name = "DRG0202U00";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(960, 780);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDRG0202)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            grdDRG0202.QueryLayout(false);
		}
		#endregion

        #region properties
        bool isButtonClick = false;
        #endregion

        #region COMMAND
        //command 
		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch (command)
			{
				case "OCS0103Q00":
					//선택한 Data를 DataLayoutMIO로 반환합니다.
                    MultiLayout dloPatientInfo = (MultiLayout)commandParam["OCS0103"];

					//해당 DataLayoutMIO를 가지고 로직을 구현하세요...
					int rowCount = this.grdDRG0202.RowCount;
					int rowNum = 0;

					for (int i = 0; i < dloPatientInfo.RowCount; i++)
					{
						if ( i == 0 )
						{
							if ( grdDRG0202.CurrentRowNumber < 0 || isButtonClick ) 
							{
								if (isButtonClick)
								{
									rowNum = grdDRG0202.CurrentRowNumber;
								}
								rowNum = grdDRG0202.InsertRow(rowNum);
							}
							else
							{
								rowNum = grdDRG0202.CurrentRowNumber;                            
							}
						}
						else
						{
							rowNum = grdDRG0202.InsertRow(rowNum);
						}
						grdDRG0202.SetItemValue(rowNum, "hangmog_code", dloPatientInfo.GetItemValue(i, "hangmog_code"));
						grdDRG0202.SetItemValue(rowNum, "hangmog_name", dloPatientInfo.GetItemValue(i, "hangmog_name"));
					}
					
					isButtonClick = false;
					break;
	
			}
			
			return base.Command (command, commandParam);
		}
		#endregion

        #region grdDRG0202_GridFindClick
        private void grdDRG0202_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

			CommonItemCollection openParams  = new CommonItemCollection();
					

			switch (e.ColName)
			{
				case "hangmog_code": // 항목코드
					e.Cancel = true;  // Find 장 안띄움

					//값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
					openParams.Add("hangmog_code", ((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).GetDataValue());
					// Multi 선택여부 (default : MultiSelect )
					//openParams.Add("multiSelect", true);
					//항목조회화면 Open
					XScreen.OpenScreenWithParam( this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseSizable, openParams);

					break;
				
				
				case "bunho":
					e.Cancel = true;  // Find 장 안띄움

					XScreen.OpenScreenWithParam( this, "OUTS", "OUT0101Q00", ScreenOpenStyle.ResponseSizable, openParams);

					break;

				default:

					break;
			}
        }
        #endregion

        #region grdDRG0202 GridColumnChanged
        private void grdDRG0202_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			string bunho  = string.Empty;
			string name   = string.Empty;
			string mbxMsg = string.Empty;
			string mbxCap = string.Empty;

            string cmdText = string.Empty;
            object retVal = null;
            DataTable resTable = new DataTable();

			switch(e.ColName)
			{
				case "hangmog_code":
                    cmdText = "SELECT A.HANGMOG_NAME " +
		                        "FROM OCS0103 A " +
                               "WHERE A.HANGMOG_CODE = '" + this.grdDRG0202.GetItemString(grdDRG0202.CurrentRowNumber, "hangmog_code") + "'" +
                                 "AND A.HOSP_CODE    = '" + EnvironInfo.HospCode + "'";
                    retVal = Service.ExecuteScalar(cmdText);

                    if (!TypeCheck.IsNull(retVal))
                    {
                        name = retVal.ToString();
                        this.grdDRG0202.SetItemValue(this.grdDRG0202.CurrentRowNumber, "hangmog_name", name);
                    }
                    else if(TypeCheck.IsNull(retVal))
                    {
                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("hangmog_code", this.grdDRG0202.GetItemString(grdDRG0202.CurrentRowNumber, "hangmog_code"));
                        openParams.Add("multiSelect", false);

                        XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseSizable, openParams);
                    }
					break;

				case "bunho":
					if (this.grdDRG0202.GetItemString(this.grdDRG0202.CurrentRowNumber,"bunho") == "")
					{
						this.grdDRG0202.SetItemValue(this.grdDRG0202.CurrentRowNumber,"suname", "");
						return;
					}

					this.grdDRG0202.SetEditorValue(BizCodeHelper.GetStandardBunHo(this.grdDRG0202.GetItemString(grdDRG0202.CurrentRowNumber, "bunho")));
					
					cmdText = "SELECT A.BUNHO, A.SUNAME " +
						        "FROM OUT0101 A " +
						       "WHERE A.BUNHO = '" + BizCodeHelper.GetStandardBunHo(this.grdDRG0202.GetItemString(grdDRG0202.CurrentRowNumber, "bunho")) + "'" +
                                 "AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    resTable = Service.ExecuteDataTable(cmdText);

                    if (Service.ErrCode == 0)
					{
                        if(resTable.Rows.Count < 1)
                        {
							mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号を確認してください。"
								: "환자번호를 확인해주세요.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
							XMessageBox.Show(mbxMsg, mbxCap);

							e.Cancel = true;
							return;
						}
						bunho = resTable.Rows[0]["bunho"].ToString();
						name  = resTable.Rows[0]["suname"].ToString();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号を確認してください。"
							: "환자번호를 확인해주세요.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
						XMessageBox.Show(mbxMsg, mbxCap);

						e.Cancel = true;
						return;
					}
					this.grdDRG0202.SetItemValue(this.grdDRG0202.CurrentRowNumber, "bunho", bunho);
					this.grdDRG0202.SetItemValue(this.grdDRG0202.CurrentRowNumber, "suname", name);
					break;
				default:
					break;
			}
		
		}
		#endregion

        #region 버튼리스트 이벤트
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Update:
					e.IsBaseCall = false;

					//
                    string cmdText = @"SELECT 'Y'
                                         FROM DRG0202
                                        WHERE HANGMOG_CODE = :f_hangmog_code
                                          AND BUNHO        = :f_bunho
                                          AND ROWNUM       = 1
                                          AND HOSP_CODE    = :f_hosp_code";
                    object retVal = null;
                    BindVarCollection bindVars = new BindVarCollection();
					for(int i=0; i<grdDRG0202.RowCount; i++)
					{
						if (grdDRG0202.GetRowState(i) == DataRowState.Added)
						{
							if (TypeCheck.IsNull(grdDRG0202.GetItemString(i,"hangmog_code")))
							{
								XMessageBox.Show("項目コードを先に入力してください。", "注意", MessageBoxIcon.Warning);
								e.IsSuccess = false;
								return;
							}
							if (TypeCheck.IsNull(grdDRG0202.GetItemString(i,"bunho")))
							{
                                XMessageBox.Show("患者番号を入力してください。", "注意", MessageBoxIcon.Warning);
								e.IsSuccess = false;
								return;
                            }
                            retVal = null;
                            bindVars.Clear();
                            bindVars.Add("f_hangmog_code", grdDRG0202.GetItemString(i, "hangmog_code"));
                            bindVars.Add("f_bunho", grdDRG0202.GetItemString(i, "bunho"));
                            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                            retVal = Service.ExecuteScalar(cmdText, bindVars);

                            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                            {
                                XMessageBox.Show("既に入力された情報があります。", "入力エラー", MessageBoxIcon.Warning);
                                return;
                            }
						}
					}

                    if (!grdDRG0202.SaveLayout()) { XMessageBox.Show(Service.ErrFullMsg); return; }
                    XMessageBox.Show("保存しました", "保存", MessageBoxIcon.Information);
				    break;
			}
        }
        #endregion

        #region HOSP_CODE Setting
        private void grdDRG0202_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDRG0202.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        /* ====================================== SAVEPERFORMER ====================================== */

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private DRG0202U00 parent = null;
            public XSavePerformer(DRG0202U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO DRG0202
                                                   ( SYS_DATE  , SYS_ID      , UPD_DATE  , HANGMOG_CODE ,
                                                     BUNHO     , COMMENTS    , USE_YN    , HOSP_CODE)
                                             VALUES
                                                   ( SYSDATE   , :q_user_id  , SYSDATE   , :f_hangmog_code ,
                                                     :f_bunho  , :f_comments , :f_use_yn , :f_hosp_code)";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE DRG0202
                                               SET UPD_ID       = :q_user_id    ,
                                                   UPD_DATE     = SYSDATE       ,
                                                   USE_YN       = :f_use_yn     ,
                                                   COMMENTS     = :f_comments
                                             WHERE HANGMOG_CODE = :f_hangmog_code
                                               AND BUNHO        = :f_bunho
                                               AND HOSP_CODE    = :f_hosp_code";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE DRG0202
                                             WHERE HANGMOG_CODE = :f_hangmog_code
                                               AND BUNHO        = :f_bunho
                                               AND HOSP_CODE    = :f_hosp_code";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        /* ====================================== SAVEPERFORMER ====================================== */
    }
}

/* 2010.06.21 河中*/