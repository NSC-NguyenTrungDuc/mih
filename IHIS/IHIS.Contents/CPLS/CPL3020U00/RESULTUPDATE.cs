using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.CPLS
{
	/// <summary>
	/// CHANGETIME에 대한 요약 설명입니다.
	/// </summary>
	public class RESULTUPDATE : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XMstGrid grdUpdateSayu;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XFindWorker fwkDummy;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.SingleLayout vsvJubsuja;
		private IHIS.Framework.XButton btnUpdate;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XGridHeader xGridHeader3;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RESULTUPDATE()
		{
			InitializeComponent();
		}

		public RESULTUPDATE(string aLabNo, string aHangmogCode, string aSpecimenCode, string aEmergency, string aBeforeResult, string aBeforeGumsaja, string aPkcpl3020)
		{
			InitializeComponent();
            this.grdUpdateSayu.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdUpdateSayu.SetBindVarValue("f_lab_no", aLabNo);
            this.grdUpdateSayu.SetBindVarValue("f_hangmog_code", aHangmogCode);
            this.grdUpdateSayu.SetBindVarValue("f_specimen_code", aSpecimenCode);
            this.grdUpdateSayu.SetBindVarValue("f_emergency", aEmergency);
			
			this.mLabNo = aLabNo;
			this.mHangmogCode = aHangmogCode;
			this.mSpecimenCode = aSpecimenCode;
			this.mEmergency = aEmergency;
			this.mBeforeResult = aBeforeResult;
			this.mBeforeGumsaja = aBeforeGumsaja;
			this.mPkcpl3020 = aPkcpl3020;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RESULTUPDATE));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnUpdate = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdUpdateSayu = new IHIS.Framework.XMstGrid();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fwkDummy = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.vsvJubsuja = new IHIS.Framework.SingleLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdateSayu)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnUpdate);
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            // 
            // grdUpdateSayu
            // 
            this.grdUpdateSayu.AddedHeaderLine = 1;
            this.grdUpdateSayu.ApplyPaintEventToAllColumn = true;
            this.grdUpdateSayu.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell7});
            this.grdUpdateSayu.ColPerLine = 7;
            this.grdUpdateSayu.ColResizable = true;
            this.grdUpdateSayu.Cols = 7;
            this.grdUpdateSayu.ControlBinding = true;
            resources.ApplyResources(this.grdUpdateSayu, "grdUpdateSayu");
            this.grdUpdateSayu.FixedRows = 2;
            this.grdUpdateSayu.HeaderHeights.Add(21);
            this.grdUpdateSayu.HeaderHeights.Add(0);
            this.grdUpdateSayu.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2,
            this.xGridHeader3});
            this.grdUpdateSayu.Name = "grdUpdateSayu";
            this.grdUpdateSayu.QuerySQL = resources.GetString("grdUpdateSayu.QuerySQL");
            this.grdUpdateSayu.Rows = 3;
            this.grdUpdateSayu.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdUpdateSayu_GridFindSelected);
            this.grdUpdateSayu.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdUpdateSayu_PreSaveLayout);
            this.grdUpdateSayu.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdUpdateSayu_GridColumnChanged);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "lab_no";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "specimen_code";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "emergency";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 5;
            this.xEditGridCell3.CellName = "password";
            this.xEditGridCell3.CellWidth = 51;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.PasswordChar = '*';
            this.xEditGridCell3.Row = 1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gumsaja";
            this.xEditGridCell4.CellWidth = 107;
            this.xEditGridCell4.Col = 1;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.Row = 1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "dummy";
            this.xEditGridCell5.CellWidth = 49;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell5.FindWorker = this.fwkDummy;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.Row = 1;
            // 
            // fwkDummy
            // 
            this.fwkDummy.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkDummy.FormText = "取消事由照会";
            this.fwkDummy.InputSQL = resources.GetString("fwkDummy.InputSQL");
            this.fwkDummy.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkDummy.ServerFilter = true;
            this.fwkDummy.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkDummy_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 467;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "ref_comment";
            this.xEditGridCell6.CellWidth = 306;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.Row = 1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "hangmog_code";
            this.xEditGridCell17.CellWidth = 131;
            this.xEditGridCell17.Col = 4;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "before_gumsaja";
            this.xEditGridCell18.CellWidth = 118;
            this.xEditGridCell18.Col = 5;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.Row = 1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "before_result";
            this.xEditGridCell19.CellWidth = 130;
            this.xEditGridCell19.Col = 6;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.Row = 1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "cancel_date";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "cancel_time";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "pkcpl3020";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 51;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 2;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 49;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 5;
            this.xGridHeader3.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            this.xGridHeader3.HeaderWidth = 118;
            // 
            // vsvJubsuja
            // 
            this.vsvJubsuja.QuerySQL = "SELECT MT_NAME\r\n  FROM CPL0127\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND MT_CODE  " +
                " = :f_code ";
            // 
            // RESULTUPDATE
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.grdUpdateSayu);
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RESULTUPDATE";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.grdUpdateSayu, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdateSayu)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region fields
		private string mLabNo = "";
		private string mSpecimenCode = "";
		private string mEmergency = "";
		private string mHangmogCode = "";
		private string mBeforeResult = "";
		private string mBeforeGumsaja = "";
		private string mPkcpl3020 = "";
		#endregion
	
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.grdUpdateSayu.QueryLayout(false);

			if ( this.grdUpdateSayu.RowCount == 0 )
				this.grdUpdateSayu.InsertRow();

			this.grdUpdateSayu.SetFocusToItem(0,"password");
		}

		#region 그리드의 파인드 선택 후
		private void grdUpdateSayu_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
		{
			this.grdUpdateSayu.SetItemValue(e.RowNumber,"ref_comment",e.ReturnValues[1].ToString());
		}
		#endregion

		#region vsvJubsuja_PreServiceCall
		private void vsvJubsuja_PreServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.vsvJubsuja.SetBindVarValue("f_code",this.grdUpdateSayu.GetItemString(this.grdUpdateSayu.CurrentRowNumber,"password"));
		}
		#endregion

		#region btnUpdate_Click
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			this.grdUpdateSayu.AcceptData();
			if ( this.grdUpdateSayu.GetItemString(this.grdUpdateSayu.CurrentRowNumber,"ref_comment").Length > 0 )
			{
                this.grdUpdateSayu.SaveLayout();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				XMessageBox.Show("사유는 꼭 입력되어야합니다.");	
			}
		}
		#endregion

        #region grdUpdateSayu_PreSaveLayout
        private void grdUpdateSayu_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if ((e.RowState == System.Data.DataRowState.Added) || (e.RowState == System.Data.DataRowState.Modified))
            {
                this.grdUpdateSayu.SetItemValue(e.RowNumber, "lab_no", this.mLabNo);
                this.grdUpdateSayu.SetItemValue(e.RowNumber, "specimen_code", this.mSpecimenCode);
                this.grdUpdateSayu.SetItemValue(e.RowNumber, "emergency", this.mEmergency);
                this.grdUpdateSayu.SetItemValue(e.RowNumber, "hangmog_code", this.mHangmogCode);
                this.grdUpdateSayu.SetItemValue(e.RowNumber, "before_result", this.mBeforeResult);
                //this.grdUpdateSayu.SetItemValue(e.RowNumber, "before_gumsaja", this.mBeforeGumsaja);
                this.grdUpdateSayu.SetItemValue(e.RowNumber, "gumsaja", "kimminsoo");
                this.grdUpdateSayu.SetItemValue(e.RowNumber, "before_gumsaja", "kimminsoo");
                this.grdUpdateSayu.SetItemValue(e.RowNumber, "pkcpl3020", this.mPkcpl3020);
            }
        }
		#endregion

        private void fwkDummy_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkDummy.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdUpdateSayu_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "password")
            {
                SetMsg("");

                this.vsvJubsuja.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.vsvJubsuja.SetBindVarValue("f_code", e.ChangeValue.ToString());

                this.vsvJubsuja.QueryLayout();

                if (vsvJubsuja.GetItemValue("gumsaja").ToString() == "")
                {
                    e.Cancel = true;
                    SetMsg("検査者のパスワードが正しくありません。",MsgType.Error);

                    return;
                }

                this.grdUpdateSayu.SetItemValue(e.RowNumber, "gumsaja", vsvJubsuja.GetItemValue("gumsaja").ToString());
            
            }
        }

        #region XSavePerformer

        private class XSavePerformer : ISavePerformer
        {
            RESULTUPDATE parent;

            public XSavePerformer(RESULTUPDATE parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                switch (item.RowState)
                { 
                    case System.Data.DataRowState.Added:
                        cmdText = @"INSERT INTO CPL3088 (
                                             SYS_DATE,          SYS_ID,            
                                             UPD_DATE,          UPD_ID,         HOSP_CODE, 
                                            ,LAB_NO        
                                            ,SPECIMEN_CODE 
                                            ,EMERGENCY     
                                            ,GUMSAJA       
                                            ,REF_COMMENT   
                                            ,HANGMOG_CODE  
                                            ,BEFORE_GUMSAJA
                                            ,BEFORE_RESULT 
                                            ,CANCEL_DATE   
                                            ,CANCEL_TIME   
                                        ) VALUES (
                                            SYSDATE,            :q_user_id,           
                                            SYSDATE,            :q_user_id,     :f_hosp_code,
                                            ,:f_lab_no        
                                            ,:f_specimen_code 
                                            ,:f_emergency     
                                            ,:f_gumsaja       
                                            ,:f_ref_comment   
                                            ,:f_hangmog_code  
                                            ,:f_before_gumsaja
                                            ,:f_before_result 
                                            ,TRUNC(SYSDATE)   
                                            ,TO_CHAR(SYSDATE,'HH24MI')  
                                            )";

                        Service.ExecuteNonQuery(cmdText, item.BindVarList);

                        cmdText = @"UPDATE CPL3020
                                       SET UPD_ID          = :q_user_id
                                         , SYS_DATE         = SYSDATE
                                         , CONFIRM_DATE     = NULL   
                                         , CONFIRM_YN       = 'N'   
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND PKCPL3020        = :f_pkcpl3020";

                        if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                        {
                            XMessageBox.Show("保存処理中にエラーが発生しました。\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                            return false;
                        }

                        break;

                    case System.Data.DataRowState.Modified:
                        cmdText = @"UPDATE CPL3088
                                       SET UPD_ID           = :q_user_id
                                         , SYS_DATE         = SYSDATE
                                         , GUMSAJA          = :f_gumsaja                          
                                         , REF_COMMENT      = :f_ref_comment                        
                                         , BEFORE_GUMSAJA   = :f_before_gumsaja                      
                                         , BEFORE_RESULT    = :f_before_result 
                                         , CANCEL_DATE      = TRUNC(SYSDATE)   
                                         , CANCEL_TIME      = TO_CHAR(SYSDATE,'HH24MI')   
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND HANGMOG_CODE     = :f_hangmog_code                         
                                       AND LAB_NO           = :f_lab_no                                                                             
                                       AND SPECIMEN_CODE    = :f_specimen_code                                                
                                       AND EMERGENCY        = :f_emergency";

                        if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                        {
                            XMessageBox.Show("保存処理中にエラーが発生しました。\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                            return false;
                        }

                        cmdText = @"UPDATE CPL3020
                                       SET UPD_ID          = :q_user_id
                                         , SYS_DATE         = SYSDATE
                                         , CONFIRM_DATE     = NULL   
                                         , CONFIRM_YN       = 'N'   
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND PKCPL3020        = :f_pkcpl3020";

                        if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                        {
                            XMessageBox.Show("保存処理中にエラーが発生しました。\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                            return false;
                        }

                        break;

                    case System.Data.DataRowState.Deleted:

                        break;
                }
                return true;
            }
        }

        #endregion

    }
}
