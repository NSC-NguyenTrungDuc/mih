#region 사용 NameSpace 지정
using System;
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
	/// NUR6005U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR6005U00 : IHIS.Framework.XScreen
	{

		private int mFkinp1001 = 0;

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlButtom;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XEditGrid grdNUR6005;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.MultiLayout layComboSet;
		private IHIS.Framework.SingleLayout layFkinp1001;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private SingleLayoutItem singleLayoutItem1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR6005U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR6005U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlButtom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdNUR6005 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layFkinp1001 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR6005)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlTop.Size = new System.Drawing.Size(489, 34);
            this.pnlTop.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(489, 30);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlButtom
            // 
            this.pnlButtom.Controls.Add(this.btnList);
            this.pnlButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtom.Location = new System.Drawing.Point(0, 363);
            this.pnlButtom.Name = "pnlButtom";
            this.pnlButtom.Size = new System.Drawing.Size(489, 35);
            this.pnlButtom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(2, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 35);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdNUR6005);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 34);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(489, 329);
            this.pnlFill.TabIndex = 2;
            // 
            // grdNUR6005
            // 
            this.grdNUR6005.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdNUR6005.ColPerLine = 3;
            this.grdNUR6005.Cols = 4;
            this.grdNUR6005.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR6005.FixedCols = 1;
            this.grdNUR6005.FixedRows = 1;
            this.grdNUR6005.FocusColumnName = "infe_code";
            this.grdNUR6005.HeaderHeights.Add(21);
            this.grdNUR6005.Location = new System.Drawing.Point(0, 0);
            this.grdNUR6005.Name = "grdNUR6005";
            this.grdNUR6005.QuerySQL = resources.GetString("grdNUR6005.QuerySQL");
            this.grdNUR6005.RowHeaderVisible = true;
            this.grdNUR6005.Rows = 2;
            this.grdNUR6005.Size = new System.Drawing.Size(489, 329);
            this.grdNUR6005.TabIndex = 0;
            this.grdNUR6005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR6005_QueryStarting);
            this.grdNUR6005.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR6005_GridColumnChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "metress_gubun";
            this.xEditGridCell1.CellWidth = 160;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.HeaderText = "マットレス";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.MaxDropDownItems = 50;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "환자번호";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "start_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 140;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell3.HeaderText = "開始日付";
            this.xEditGridCell3.IsJapanYearType = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "end_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 140;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.HeaderText = "終了日付";
            this.xEditGridCell4.IsJapanYearType = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "fkinp1001";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // layComboSet
            // 
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboSet.QuerySQL = "SELECT CODE      CODE,\r\n       CODE_NAME CODE_NAME,\r\n       SORT_KEY\r\n  FROM NUR0" +
                "102\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = :f_code_type\r\n ORDER BY" +
                " 1, 3";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // layFkinp1001
            // 
            this.layFkinp1001.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layFkinp1001.QuerySQL = "SELECT PKINP1001\r\n  FROM VW_OCS_INP1001_01\r\n WHERE HOSP_CODE            = :f_hosp" +
                "_code\r\n   AND NVL(CANCEL_YN,\'N\')   = \'N\'\r\n   AND NVL(JAEWON_FLAG,\'N\') = \'Y\'\r\n   " +
                "AND BUNHO                = :f_bunho";
            this.layFkinp1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layFkinp1001_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "fkinp1001";
            // 
            // NUR6005U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlButtom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR6005U00";
            this.Size = new System.Drawing.Size(489, 398);
            this.UserChanged += new System.EventHandler(this.NUR6005U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR6005U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlButtom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR6005)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
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
				case "jeawonYn":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + "\n" +" 환자번호를 확인해 주세요"
						: "在院中の患者ではありません。" + "\n" + "患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bunho":
					msg = (NetInfo.Language == LangMode.Ko ? "환자번호를 확인해 주세요"
						: "患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "dup_chk":
					msg = (NetInfo.Language == LangMode.Ko ? "이미 입력된 정보입니다."
						: "もう入力された情報です。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "metress_gubun":
					msg = (NetInfo.Language == LangMode.Ko ? "매트리스 종류를 입력하세요."
						: "マットレスを入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption);
					break;
				case "start_date":
					msg = (NetInfo.Language == LangMode.Ko ? "시작일자를 입력하세요."
						: "開示日付けを入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption);
					break;
				case "end_date":
					msg = (NetInfo.Language == LangMode.Ko ? "종료일자가 시작일자보다 작을 수는 없습니다."
						: "終了日付が開始日付より大きくなければなれません。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
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

		// <summary>
		/// 수술예약 등록 콤보박스 셋팅
		/// </summary>
		/// <param name="aComboGubun">
		/// 콤보구분
		/// </param>
		#region 콤보박스 셋팅
		private void GetComboSetting(string aComboGubun)
        {
            this.layComboSet.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.layComboSet.SetBindVarValue("f_code_type", aComboGubun);

			if(this.layComboSet.QueryLayout(true))
			{
				switch(aComboGubun)
				{
					case "METRESS_GUBUN":
						if(this.layComboSet.LayoutTable.Rows.Count > 0)
						{
							this.grdNUR6005.SetComboItems("metress_gubun", this.layComboSet.LayoutTable, "code_name", "code");
						}
						break;
					default:
						break;
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}
		}
		#endregion

		#region 스크린 로드
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.grdNUR6005.SavePerformer = new XSavePerformer(this);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
            //this.btnList.PerformClick(FunctionType.Query);
		}

		private void PostLoad()
		{
            this.NUR6005U00_UserChanged(this, new System.EventArgs());
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

		#region 버튼리스트에서 버튼을 클릭을 했을 때
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					if(this.paBox.BunHo.ToString() == "")
					{
						this.GetMessage("bunho");
						e.IsBaseCall = false;
						return;
					}
					break;
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					e.IsBaseCall = false;

					this.grdNUR6005.Reset();

					if(this.grdNUR6005.QueryLayout(false))
					{
					}
					else
					{
						XMessageBox.Show(Service.ErrFullMsg);
						return;
					}
					break;
				case FunctionType.Update:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}
                    e.IsBaseCall = false;

					for(int i = 0; i < this.grdNUR6005.RowCount; i++)
					{
						if(this.grdNUR6005.GetRowState(i) == DataRowState.Added ||
							this.grdNUR6005.GetRowState(i) == DataRowState.Modified)
						{
							if(this.grdNUR6005.GetItemValue(i, "metress_gubun").ToString() == "")
							{
								e.IsBaseCall = false;
								this.GetMessage("metress_gubun");
								this.grdNUR6005.SetFocusToItem(i, "metress_gubun");
								return;
							}

							if(this.grdNUR6005.GetItemValue(i, "start_date").ToString() == "")
							{
								e.IsBaseCall = false;
								this.GetMessage("start_date");
								this.grdNUR6005.SetFocusToItem(i, "start_date");
								return;
							}
						}
					}

                    if (!this.grdNUR6005.SaveLayout())
                    {
                        this.GetMessage("save_false");
                        return;
                    }

                    this.GetMessage("save_true");

                    if (!this.grdNUR6005.QueryLayout(false))
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return;
                    }

					break;
				default:
					break;
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 한 후의 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
					if(this.paBox.BunHo.ToString() != "")
					{
						this.grdNUR6005.SetItemValue(this.grdNUR6005.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString());
						this.grdNUR6005.SetItemValue(this.grdNUR6005.CurrentRowNumber, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
						this.grdNUR6005.SetItemValue(this.grdNUR6005.CurrentRowNumber, "fkinp1001" , mFkinp1001.ToString());
					}
					break;
				default:
					break;
			}
		}
		#endregion		

		#region 중복체크
		private void grdNUR6005_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			DataRowState rowState = this.grdNUR6005.LayoutTable.Rows[e.RowNumber].RowState;

            SingleLayout layValidationDupchk = new SingleLayout();

			layValidationDupchk.LayoutItems.Add("YorN");
            layValidationDupchk.QuerySQL = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS (SELECT 'X'
                                                             FROM NUR6005
                                                            WHERE HOSP_CODE  = :f_hosp_code
                                                              AND BUNHO      = :f_bunho
                                                              AND START_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD'))";

            //layValidationDupchk.SetInValue("i_metress_gubun", this.grdNUR6005.GetItemValue(e.RowNumber, "metress_gubun"));
            layValidationDupchk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layValidationDupchk.SetBindVarValue("f_bunho", this.paBox.BunHo);
            layValidationDupchk.SetBindVarValue("f_start_date", this.grdNUR6005.GetItemString(e.RowNumber, "start_date"));

			switch(e.ColName)
			{
				case "metress_gubun":
				case "start_date":
					if(rowState == DataRowState.Added)
					{
                        layValidationDupchk.QueryLayout();
						
						if(!TypeCheck.IsNull(layValidationDupchk.GetItemValue("YorN")))
						{
							/* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
                            if (layValidationDupchk.GetItemValue("YorN").ToString() == "Y")
							{
								this.GetMessage("dup_chk");
                                grdNUR6005.SetFocusToItem(e.RowNumber, "start_date");
								e.Cancel = true;
								return;
							}
						}
					}
					break;
				case "end_date":
					if(this.grdNUR6005.GetItemValue(e.RowNumber, "end_date").ToString() != "")
					{
						if(int.Parse(DateTime.Parse(this.grdNUR6005.GetItemValue(e.RowNumber, "end_date").ToString()).ToString("yyyyMMdd")) <
							int.Parse(DateTime.Parse(this.grdNUR6005.GetItemValue(e.RowNumber, "start_date").ToString()).ToString("yyyyMMdd")))
						{
							this.GetMessage("end_date");
							e.Cancel = true;
							return;
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 팝업창으로 오픈이 됐을 때
		private void NUR6005U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
        //    this.grdNUR6005.SavePerformer = new XSavePerformer(this);
        //    PostCallHelper.PostCall(new PostMethod(PostLoad));
        //    this.btnList.PerformClick(FunctionType.Query);
		}
		#endregion

		#region 사용자 변경이 있을 때
		private void NUR6005U00_UserChanged(object sender, System.EventArgs e)
		{
			this.GetComboSetting("METRESS_GUBUN");

			this.CurrMSLayout = this.grdNUR6005;
			this.CurrMQLayout = this.grdNUR6005;

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
            this.btnList.PerformClick(FunctionType.Query);
		}
		#endregion

		#region 환자 등록번호가 입력이 됐을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{

			if(!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
				/* 재원화자 정보 조회 */
				this.Fkinp1001();
			}
		}
		#endregion

        #region 잘못된 환자번호 또는 Null값 입력 시
        private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            this.grdNUR6005.Reset();
        }
        #endregion

		/// <summary>
		/// 환자의 재원여부를 조회한다.
		/// </summary>
		#region 재원여부 조회
		private void Fkinp1001()
		{
            this.layFkinp1001.QueryLayout();
			/* 환자의 재원이력을 조회한다. */

            if (this.layFkinp1001.GetItemValue("fkinp1001").ToString() == "")
            {
                /* 재원 환자가 아니므로 메세지를 보여준다. */
                mFkinp1001 = 0;
                this.GetMessage("jeawonYn");
            }
            else
            {
                //재원환자일 경우
                mFkinp1001 = int.Parse(this.layFkinp1001.GetItemValue("fkinp1001").ToString());
            }

            /*매트리스 정보 조회*/
            if (this.grdNUR6005.QueryLayout(false)) { }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
		}
		#endregion

        #region QueryStarting
        private void layFkinp1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layFkinp1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layFkinp1001.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void grdNUR6005_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR6005.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR6005.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }
        #endregion

        #region XSavePerformer

        // private string mErrMsg = "";
        private class XSavePerformer : ISavePerformer
        {
            NUR6005U00 parent;

            public XSavePerformer(NUR6005U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = null;
                //parent.mErrMsg = ""; 

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                { 
                    case DataRowState.Added:

                        cmdText = @"SELECT 'Y'
                                      FROM DUAL
                                     WHERE EXISTS (SELECT 'X'
                                                     FROM NUR6005
                                                    WHERE HOSP_CODE  = :f_hosp_code
                                                      AND BUNHO      = :f_bunho
                                                      AND START_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD'))";


                        retVal = null;
                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (!TypeCheck.IsNull(retVal))
                        {
                            if (retVal.ToString() == "Y")
                            {
                                //parent.mErrMsg = "「" + item.BindVarList["f_start_date"].VarValue + "」日付のデータが既に登録されています。";
                                XMessageBox.Show("「" + item.BindVarList["f_start_date"].VarValue + "」日付のデータが既に登録されています。", "注意", MessageBoxIcon.Warning);
                                return false;
                            }
                        }

                        cmdText = @"INSERT INTO NUR6005
                                              ( SYS_DATE                          , SYS_ID      
                                              , UPD_DATE                          , UPD_ID      , HOSP_CODE 
                                              , METRESS_GUBUN                     , BUNHO       
                                              , START_DATE                        , END_DATE                          
                                              , FKINP1001                         , DATA_GUBUN)
                                         VALUES 
                                              ( SYSDATE                              , :q_user_id  
                                              , SYSDATE                              , :q_user_id  , :f_hosp_code
                                              , :f_metress_gubun                     , :f_bunho    
                                              , TO_DATE(:f_start_date, 'YYYY/MM/DD') , TO_DATE(:f_end_date, 'YYYY/MM/DD')
                                              , :f_fkinp1001                         , 'U' /*사용자가 갱신*/)";

                        break;

                    case DataRowState.Modified:

                        cmdText = @"UPDATE NUR6005
                                       SET UPD_ID        = :q_user_id
                                          ,UPD_DATE      = SYSDATE
                                          ,END_DATE      = :f_end_date
                                          ,METRESS_GUBUN = :f_metress_gubun
                                          ,DATA_GUBUN    = 'U' /*사용자가 갱신*/
                                     WHERE HOSP_CODE     = :f_hosp_code
                                       AND BUNHO         = :f_bunho
                                       AND START_DATE    = :f_start_date";
                        break;

                    case DataRowState.Deleted:

                        cmdText = @"DELETE NUR6005
                                     WHERE HOSP_CODE  = :f_hosp_code
                                       AND BUNHO      = :f_bunho
                                       AND START_DATE = :f_start_date";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion 


    }
}

