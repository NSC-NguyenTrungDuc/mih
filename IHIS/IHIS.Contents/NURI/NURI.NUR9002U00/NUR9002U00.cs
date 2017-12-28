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

namespace IHIS.NURI
{
	/// <summary>
	/// NUR9002U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR9002U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string In_out_gubun = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XEditGrid grdNUR9002;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XGridHeader xGridHeader1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR9002U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}
		#endregion

		#region 소멸자
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR9002U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNUR9002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR9002)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlTop.Size = new System.Drawing.Size(960, 35);
            this.pnlTop.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(960, 30);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 555);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(960, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Location = new System.Drawing.Point(473, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 35);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdNUR9002
            // 
            this.grdNUR9002.AddedHeaderLine = 1;
            this.grdNUR9002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell9});
            this.grdNUR9002.ColPerLine = 5;
            this.grdNUR9002.Cols = 6;
            this.grdNUR9002.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR9002.FixedCols = 1;
            this.grdNUR9002.FixedRows = 2;
            this.grdNUR9002.FocusColumnName = "`";
            this.grdNUR9002.HeaderHeights.Add(25);
            this.grdNUR9002.HeaderHeights.Add(0);
            this.grdNUR9002.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdNUR9002.Location = new System.Drawing.Point(0, 35);
            this.grdNUR9002.Name = "grdNUR9002";
            this.grdNUR9002.QuerySQL = resources.GetString("grdNUR9002.QuerySQL");
            this.grdNUR9002.RowHeaderVisible = true;
            this.grdNUR9002.Rows = 3;
            this.grdNUR9002.Size = new System.Drawing.Size(960, 520);
            this.grdNUR9002.TabIndex = 2;
            this.grdNUR9002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR9002_QueryStarting);
            this.grdNUR9002.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR9002_SaveEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pknur9002";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "pknur9002";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 9;
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 90;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "患者番号";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.CellWidth = 120;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "患者氏名";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 5;
            this.xEditGridCell4.CellName = "input_id";
            this.xEditGridCell4.CellWidth = 90;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.HeaderText = "入力者";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.Row = 1;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "input_id_name";
            this.xEditGridCell8.CellWidth = 120;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.HeaderText = "入力者";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "input_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 130;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.HeaderText = "入力日付";
            this.xEditGridCell5.IsJapanYearType = true;
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "in_out_gubun";
            this.xEditGridCell6.CellWidth = 70;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.HeaderText = "入力区分";
            this.xEditGridCell6.RowSpan = 2;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "外来";
            this.xComboItem1.ValueItem = "O";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "入院";
            this.xComboItem2.ValueItem = "I";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 4000;
            this.xEditGridCell7.CellName = "remark";
            this.xEditGridCell7.CellWidth = 505;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.DisplayMemoText = true;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.HeaderText = "症状";
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 1;
            this.xEditGridCell9.CellName = "tag";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "tag";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "入力者";
            this.xGridHeader1.HeaderWidth = 90;
            // 
            // NUR9002U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.grdNUR9002);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR9002U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR9002U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR9002)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "bunho":
					msg = (NetInfo.Language == LangMode.Ko ? "환자번호를 입력하십시오."
						: "患者番号を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "input_date":
					msg = (NetInfo.Language == LangMode.Ko ? "입력일자를 입력해 주세요."
						: "入力日付を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "in_out_gubun":
					msg = (NetInfo.Language == LangMode.Ko ? "입력구분을 선택해주세요."
						: "入力区分を選択してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "保存";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
					msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load
		private void NUR9002U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            this.grdNUR9002.SavePerformer = new XSavePerformer(this);

			this.CurrMSLayout = this.grdNUR9002;
			this.CurrMQLayout = this.grdNUR9002;

			if(EnvironInfo.CurrSystemID.ToString() == "NURI" || EnvironInfo.CurrSystemID.ToString() == "OCSI")
			{
				this.In_out_gubun = "I";
			}
			else
			{
				this.In_out_gubun = "O";
			}

			if (this.OpenParam != null)
			{
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.paBox.SetPatientID(patientInfo.BunHo);
				}
			}
		}
		#endregion

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
				this.paBox.Focus();
				this.paBox.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
				return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion

		#region 환자번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() != "")
			{
				if(!this.grdNUR9002.QueryLayout(false))
				{
					XMessageBox.Show(Service.ErrFullMsg.ToString());
					return;
				}
			}
		}
		#endregion

		#region 환자번호를 잘못 입력을 했을 때
		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.grdNUR9002.Reset();
		}
		#endregion

		#region 버튼클릭 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					break;
				case FunctionType.Insert:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					if(this.paBox.BunHo.ToString() == "")
					{
						this.GetMessage("bunho");
						this.paBox.Focus();
						e.IsBaseCall = false;
						return;
					}
					break;
				case FunctionType.Delete:
					break;
				case FunctionType.Update:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}
                    e.IsBaseCall = false;
					/* 필수 입력사항이 입력이 되있는지 체크를 한다. */
					for(int i = 0; i < this.grdNUR9002.RowCount; i++)
					{
						if(this.grdNUR9002.GetItemValue(i, "input_date").ToString() == "")
						{
							this.GetMessage("input_date");
							this.grdNUR9002.SetFocusToItem(i, "input_date");
							e.IsBaseCall = false;
							return;
						}
						
						if(this.grdNUR9002.GetItemValue(i, "in_out_gubun").ToString() == "")
						{
							this.GetMessage("in_out_gubun");
							this.grdNUR9002.SetFocusToItem(i, "in_out_gubun");
							e.IsBaseCall = false;
							return;
						}
                    }
                    e.IsSuccess = true;
                    if (!this.grdNUR9002.SaveLayout())
                    {
                        e.IsSuccess = false;
                    }


					break;
				default:
					break;
			}
		}
		#endregion

		#region 버튼클릭 후 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
					if(this.paBox.BunHo.ToString() != "")
					{
						this.grdNUR9002.SetItemValue(this.grdNUR9002.CurrentRowNumber, "pknur9002"   , "");
						this.grdNUR9002.SetItemValue(this.grdNUR9002.CurrentRowNumber, "bunho"       , this.paBox.BunHo.ToString());
						this.grdNUR9002.SetItemValue(this.grdNUR9002.CurrentRowNumber, "suname"      , this.paBox.SuName.ToString());
						this.grdNUR9002.SetItemValue(this.grdNUR9002.CurrentRowNumber, "input_date"  , EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
						this.grdNUR9002.SetItemValue(this.grdNUR9002.CurrentRowNumber, "in_out_gubun", In_out_gubun);
						this.grdNUR9002.SetItemValue(this.grdNUR9002.CurrentRowNumber, "tag"         , "Y");

						this.grdNUR9002.AcceptData();
					}
					break;
				case FunctionType.Delete:
					break;
				default:
					break;
			}
		}
		#endregion

        private void grdNUR9002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR9002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR9002.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        #region 저장 후 이벤트
        private void grdNUR9002_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                /* 재조회 */
                if (!this.grdNUR9002.QueryLayout(false))
                {
                    XMessageBox.Show(Service.ErrFullMsg.ToString());
                    return;
                }
                this.GetMessage("save_true");
                return;
            }
            else
            {
                this.GetMessage("save_false");
                return;
            }

        }
		#endregion

        #region XSavePerformer

        private class XSavePerformer : ISavePerformer
        {
            NUR9002U00 parent;

            public XSavePerformer(NUR9002U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                { 
                    case DataRowState.Added:

                        cmdText = @"INSERT INTO NUR9002
                                         ( SYS_DATE           , SYS_ID         , UPD_DATE  , UPD_ID     , HOSP_CODE,
                                           PKNUR9002          , BUNHO          , INPUT_ID  ,
                                           INPUT_DATE         , IN_OUT_GUBUN   , REMARK)
                                    VALUES             
                                         ( SYSDATE            , :q_user_id     , SYSDATE   , :q_user_id , :f_hosp_code,
                                           NUR9002_SEQ.NEXTVAL, :f_bunho       , :q_user_id,
                                           :f_input_date      , :f_in_out_gubun, :f_remark)";
                        break;

                    case DataRowState.Modified:

                        cmdText = @"UPDATE NUR9002
                    	               SET UPD_ID       = :f_input_id    ,
                    	                   UPD_DATE     = SYSDATE        ,
                    	                   INPUT_ID     = :f_input_id    ,
                    	                   INPUT_DATE   = :f_input_date  ,
                    	                   IN_OUT_GUBUN = :f_in_out_gubun,
                    	                   REMARK       = :f_remark
                    	             WHERE HOSP_CODE    = :f_hosp_code 
                                       AND PKNUR9002    = :f_pknur9002 ";
                        break;

                    case DataRowState.Deleted:

                        cmdText = @"DELETE NUR9002
                                     WHERE HOSP_CODE    = :f_hosp_code 
                                       AND PKNUR9002 = :f_pknur9002";

                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion 

    }
}

