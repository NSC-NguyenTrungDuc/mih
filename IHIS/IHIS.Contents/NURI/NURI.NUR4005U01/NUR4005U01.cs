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
	/// NUR4005U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR4005U01 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string sysid     = string.Empty;
		private string screen    = string.Empty;
		private string FindName = string.Empty;
        private DateTime mPlan_date;
        private string mFkinp1001 = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XEditGrid grdNUR4005;
		private IHIS.Framework.XFindWorker fwkNurse;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XTextBox txtFkNUR4001;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XGridHeader xGridHeader1;
        private XButton btnNursingPass;
        private XButton btnChiryo;
        private XButton btnVital;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR4005U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			//저장 수행자 Set
			this.grdNUR4005.SavePerformer = new XSavePerformer(this);
			//저장 Layout List Set
			this.SaveLayoutList.Add(this.grdNUR4005);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR4005U01));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.txtFkNUR4001 = new IHIS.Framework.XTextBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNUR4005 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.fwkNurse = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.btnVital = new IHIS.Framework.XButton();
            this.btnChiryo = new IHIS.Framework.XButton();
            this.btnNursingPass = new IHIS.Framework.XButton();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4005)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.txtFkNUR4001);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1089, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(3, 2);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(1081, 29);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // txtFkNUR4001
            // 
            this.txtFkNUR4001.Location = new System.Drawing.Point(953, 9);
            this.txtFkNUR4001.Name = "txtFkNUR4001";
            this.txtFkNUR4001.Size = new System.Drawing.Size(80, 20);
            this.txtFkNUR4001.TabIndex = 1;
            this.txtFkNUR4001.Visible = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnNursingPass);
            this.pnlBottom.Controls.Add(this.btnChiryo);
            this.pnlBottom.Controls.Add(this.btnVital);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 251);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1089, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(600, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 33);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdNUR4005
            // 
            this.grdNUR4005.AddedHeaderLine = 1;
            this.grdNUR4005.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7});
            this.grdNUR4005.ColPerLine = 6;
            this.grdNUR4005.Cols = 7;
            this.grdNUR4005.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR4005.FixedCols = 1;
            this.grdNUR4005.FixedRows = 2;
            this.grdNUR4005.FocusColumnName = "damdang_nurse";
            this.grdNUR4005.HeaderHeights.Add(21);
            this.grdNUR4005.HeaderHeights.Add(0);
            this.grdNUR4005.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdNUR4005.IsAllDataQuery = true;
            this.grdNUR4005.Location = new System.Drawing.Point(0, 36);
            this.grdNUR4005.Name = "grdNUR4005";
            this.grdNUR4005.QuerySQL = resources.GetString("grdNUR4005.QuerySQL");
            this.grdNUR4005.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR4005.RowHeaderVisible = true;
            this.grdNUR4005.Rows = 3;
            this.grdNUR4005.Size = new System.Drawing.Size(1089, 215);
            this.grdNUR4005.TabIndex = 12;
            this.grdNUR4005.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR4005_ItemValueChanging);
            this.grdNUR4005.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR4005_QueryEnd);
            this.grdNUR4005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR4005_QueryStarting);
            this.grdNUR4005.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR4005_GridColumnChanged);
            this.grdNUR4005.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdNUR4005_GridFindSelected);
            this.grdNUR4005.GridDDLBSetting += new IHIS.Framework.GridDDLBSettingEventHandler(this.grdNUR4005_GridDDLBSetting);
            this.grdNUR4005.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdNUR4005_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "fknur4001";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "fknur4001";
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gubun";
            this.xEditGridCell2.CellWidth = 49;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell2.HeaderText = "区分";
            this.xEditGridCell2.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell2.UserSQL = resources.GetString("xEditGridCell2.UserSQL");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "reser_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell3.HeaderText = "評価予定日";
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 2000;
            this.xEditGridCell4.CellName = "valu_contents";
            this.xEditGridCell4.CellWidth = 658;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.DisplayMemoText = true;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell4.HeaderText = "評価内容";
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "valu_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.HeaderText = "評価日";
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "valuer";
            this.xEditGridCell6.CellWidth = 62;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell6.FindWorker = this.fwkNurse;
            this.xEditGridCell6.HeaderText = "評価者";
            this.xEditGridCell6.Row = 1;
            // 
            // fwkNurse
            // 
            this.fwkNurse.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkNurse.FormText = "看護師";
            this.fwkNurse.InputSQL = resources.GetString("fwkNurse.InputSQL");
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "sabun";
            this.findColumnInfo1.ColWidth = 100;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "職員No.";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sabun_name";
            this.findColumnInfo2.ColWidth = 193;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "職員名";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "valuer_name";
            this.xEditGridCell7.CellWidth = 116;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.HeaderText = "看護師名";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 5;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "評価者";
            this.xGridHeader1.HeaderWidth = 62;
            // 
            // btnVital
            // 
            this.btnVital.Location = new System.Drawing.Point(3, 5);
            this.btnVital.Name = "btnVital";
            this.btnVital.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnVital.Size = new System.Drawing.Size(82, 23);
            this.btnVital.TabIndex = 1;
            this.btnVital.Text = "温度板";
            this.btnVital.Click += new System.EventHandler(this.btnVital_Click);
            // 
            // btnChiryo
            // 
            this.btnChiryo.Location = new System.Drawing.Point(91, 5);
            this.btnChiryo.Name = "btnChiryo";
            this.btnChiryo.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnChiryo.Size = new System.Drawing.Size(82, 23);
            this.btnChiryo.TabIndex = 2;
            this.btnChiryo.Text = "治療計画";
            this.btnChiryo.Click += new System.EventHandler(this.btnChiryo_Click);
            // 
            // btnNursingPass
            // 
            this.btnNursingPass.Location = new System.Drawing.Point(179, 5);
            this.btnNursingPass.Name = "btnNursingPass";
            this.btnNursingPass.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnNursingPass.Size = new System.Drawing.Size(82, 23);
            this.btnNursingPass.TabIndex = 3;
            this.btnNursingPass.Text = "看護記録";
            this.btnNursingPass.Click += new System.EventHandler(this.btnNursingPass_Click);
            // 
            // NUR4005U01
            // 
            this.Controls.Add(this.grdNUR4005);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR4005U01";
            this.Size = new System.Drawing.Size(1089, 286);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR4005U01_Closing);
            this.Load += new System.EventHandler(this.NUR4005U01_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR4005U01_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4005)).EndInit();
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
					msg = (NetInfo.Language == LangMode.Ko ? " 환자번호를 확인해 주세요"
						: "患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "query":
					msg = (NetInfo.Language == LangMode.Ko ? "조회실패."
						: "照会失敗。");
					caption = (NetInfo.Language == LangMode.Ko ? "Error"
						: "エラー");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "validation_chk":
					msg = (NetInfo.Language == LangMode.Ko ? "이미 입력된 정보입니다."
						: "既に入力されている日付です。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
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
						: "エラー";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load
		private void NUR4005U01_Load(object sender, System.EventArgs e)
		{
			this.CurrMSLayout = this.grdNUR4005;
			this.CurrMQLayout = this.grdNUR4005;

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

		#region 그리드의 파인드박스에서 선택을 했을 때
		private void grdNUR4005_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
		{
			this.grdNUR4005.SetItemValue(e.RowNumber, "valuer_name", e.ReturnValues[1]);
            grdNUR4005.AcceptData();
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때

        private bool grdNUR4005_Validation()
        {
            for (int i = 0; i < grdNUR4005.RowCount; i++)
            {
                if (grdNUR4005.GetItemValue(i, "reser_date") == null)
                {
                    XMessageBox.Show("予定日を入力してください");
                    grdNUR4005.SetFocusToItem(i, "reser_date");
                    return false;
                }
                if (grdNUR4005.GetItemString(i, "gubun") != "")
                {
                    if (grdNUR4005.GetItemString(i, "valuer") == "")
                    {
                        XMessageBox.Show("評価者を入力してください");
                        grdNUR4005.SetFocusToItem(i, "valuer");
                        return false;
                    }
                    if (grdNUR4005.GetItemString(i, "valu_date") == "")
                    {
                        XMessageBox.Show("評価日を入力してください");
                        grdNUR4005.SetFocusToItem(i, "valu_date");
                        return false;
                    }
                }
            }

            return true;
        }

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

					if(this.paBox.BunHo.ToString() == "" || this.txtFkNUR4001.GetDataValue() == "")
					{
						e.IsBaseCall = false;
						this.GetMessage("bunho");
					}
					break;

				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

                    if (this.paBox.BunHo.ToString() == "" || this.txtFkNUR4001.GetDataValue() == "")
					{
						e.IsBaseCall = false;
						this.GetMessage("bunho");
						return;
					}
					break;

				case FunctionType.Update:

                    e.IsBaseCall = false;
                    if (!grdNUR4005.AcceptData())
                    {
                        e.IsSuccess = false;
                    }

                    if (!grdNUR4005_Validation())
                    {
                        e.IsSuccess = false;
                        return;
                    }

                    // grdNUR4005 저장처리 호출
                    if (!grdNUR4005.SaveLayout())
                    {
                        XMessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                        return;
                    }

                    XMessageBox.Show("保存しました。", "保存", MessageBoxIcon.Information);      
					break;

				default:
					break;
			}
		}
		#endregion

		#region 환자번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			this.grdNUR4005.Reset();
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭 한 후의 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
					if(this.paBox.BunHo.ToString() != "")
					{
						if(this.grdNUR4005.RowCount > 0)
						{
							if(this.grdNUR4005.CurrentRowNumber >= 0)
							{
								this.grdNUR4005.SetItemValue(this.grdNUR4005.CurrentRowNumber, "fknur4001", this.txtFkNUR4001.GetDataValue());
                                //this.grdNUR4005.SetItemValue(this.grdNUR4005.CurrentRowNumber,"valu_date",
                                //    IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
							}
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 팝업화면으로 오픈이 됐을 때
		private void NUR4005U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if(e.OpenParam != null)
			{
                try
                {
                    this.sysid = e.OpenParam["sysid"].ToString();
                    this.screen = e.OpenParam["screen"].ToString();
                    this.paBox.SetPatientID(e.OpenParam["bunho"].ToString());
                    this.txtFkNUR4001.Text = e.OpenParam["fknur4001"].ToString();
                    this.mPlan_date = DateTime.Parse(e.OpenParam["plan_date"].ToString());
                    this.mFkinp1001 = e.OpenParam["fkinp1001"].ToString();

                    this.grdNUR4005.QueryLayout(false);
                }
                catch
                {
                    XMessageBox.Show("患者、看護診断情報が正しくありません。");
                }
			}
		}
		#endregion

		#region 등록번호를 잘못 입력을 했을 때
		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
            this.Close();
		}
		#endregion

		#region 해당병동 간호사로드
		private void grdNUR4005_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
            this.fwkNurse.SetBindVarValue("f_buseo_code", UserInfo.BuseoCode);
            this.fwkNurse.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);		
		}
		#endregion

        #region grdNUR4005 바인드변수 설정
        private void grdNUR4005_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdNUR4005.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			grdNUR4005.SetBindVarValue("f_fknur4001", txtFkNUR4001.GetDataValue());
		}
		#endregion     

		#region XSavePerformer
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private NUR4005U01 parent = null;
			public XSavePerformer(NUR4005U01 parent)
			{
				this.parent = parent;
			}
			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdText = "";

                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

				switch (item.RowState)
				{
					case DataRowState.Added:
                        cmdText
                            = @"INSERT INTO NUR4005(    SYS_DATE        , SYS_ID        , UPD_DATE  , UPD_ID        , 
                                                        HOSP_CODE       , FKNUR4001     , GUBUN     , RESER_DATE    , 
                                                        VALU_CONTENTS   , VALU_DATE     , VALUER    )
                                             VALUES(    SYSDATE         , :q_user_id    , SYSDATE   , :q_user_id    ,
                                                        :f_hosp_code    , :f_fknur4001  , :f_gubun  , :f_reser_date ,
                                                        :f_valu_contents, :f_valu_date  , :f_valuer)";
						break;
					case DataRowState.Modified:
						cmdText
                            = @"UPDATE NUR4005
                                   SET UPD_DATE         = SYSDATE
                                     , UPD_ID           = :q_user_id
                                     , GUBUN            = :f_gubun
                                     , VALU_CONTENTS    = :f_valu_contents
                                     , VALU_DATE        = :f_valu_date
                                     , VALUER           = :f_valuer
                                 WHERE HOSP_CODE        = :f_hosp_code
                                   AND FKNUR4001        = :f_fknur4001
                                   AND RESER_DATE       = :f_reser_date";
						break;
					case DataRowState.Deleted:
						cmdText
                            = @"DELETE NUR4005
								 WHERE HOSP_CODE        = :f_hosp_code
                                   AND FKNUR4001        = :f_fknur4001
                                   AND RESER_DATE       = :f_reser_date";
						break;
				}

				return Service.ExecuteNonQuery(cmdText, item.BindVarList);
			}
		}
		#endregion

        private void grdNUR4005_GridDDLBSetting(object sender, GridDDLBSettingEventArgs e)
        {
            grdNUR4005.SetComboBindVarValue("gubun", "f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdNUR4005_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "gubun")
            {
                if (e.ChangeValue.Equals(""))
                {
                    this.grdNUR4005.SetItemValue(e.RowNumber, "valu_date", "");
                    this.grdNUR4005.SetItemValue(e.RowNumber, "valuer", "");
                    this.grdNUR4005.SetItemValue(e.RowNumber, "valuer_name", "");
                }
                else
                {
                    this.grdNUR4005.SetItemValue(e.RowNumber, "valu_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                }
            }
        }

        private void NUR4005U01_Closing(object sender, CancelEventArgs e)
        {
            ((XScreen)this.Opener).Command(this.Name, new CommonItemCollection());
        }

        private void grdNUR4005_QueryEnd(object sender, QueryEndEventArgs e)
        {
            grdNUR4005.SetFocusToItem(grdNUR4005.RowCount - 1, 1);
        }

        private void btnNursingPass_Click(object sender, EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("bunho", paBox.BunHo);
            cic.Add("record_date", IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            cic.Add("fkinp1001", mFkinp1001);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR9001U00", ScreenOpenStyle.PopUpFixed, cic);
        }

        private void btnVital_Click(object sender, EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            cic.Add("bunho", paBox.BunHo);
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1020Q00", ScreenOpenStyle.PopUpFixed, cic);
        }

        private void btnChiryo_Click(object sender, System.EventArgs e)
        {        
            IXScreen screen = XScreen.FindScreen("OCSI", "OCS6010U10");

            if (screen == null)
            {
                CommonItemCollection cic = new CommonItemCollection();
                cic.Add("bunho", paBox.BunHo);
                cic.Add("fkinp1001", this.mFkinp1001);
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.PopUpFixed, cic);
            }
            else
            {
                screen.Activate();
                XPatientInfo pInfo = new XPatientInfo(paBox.BunHo, "", "", "", this.mFkinp1001, PatientPKGubun.In, this.ScreenID);
                XScreen.SendPatientInfo(pInfo);
            }
        }

        private void grdNUR4005_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            this.grdNUR4005.GridColumnChanged -= new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR4005_GridColumnChanged);
            
            if (e.ColName == "valuer")
            {
                BindVarCollection bindVar = new BindVarCollection();
                string strCmd = @"SELECT FN_ADM_LOAD_USER_NM(:f_valuer, :f_date) FROM SYS.DUAL";

                bindVar.Add("f_valuer", e.ChangeValue.ToString());
                bindVar.Add("f_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                object retVar = Service.ExecuteScalar(strCmd, bindVar);

                if (retVar.ToString() == "")
                {
                    XMessageBox.Show("ユーザを検索できませんでした。");
                    grdNUR4005.SetItemValue(e.RowNumber, e.ColName, "");
                    grdNUR4005.SetItemValue(e.RowNumber, "valuer_name", "");

                    PostCallHelper.PostCall(SetValuer, e.RowNumber);

                }
                else
                {
                    this.grdNUR4005.SetItemValue(e.RowNumber, "valuer_name", retVar.ToString());
                }
            }

            if (e.ColName == "reser_date")
            {
                if(this.mPlan_date > this.grdNUR4005.GetItemDateTime(e.RowNumber, e.ColName))
                {
                    XMessageBox.Show("計画日 [" + mPlan_date.ToShortDateString() + "]より前の日は指定できません。");
                    grdNUR4005.SetItemValue(e.RowNumber, e.ColName, null);

                    PostCallHelper.PostCall(SetReserDate, e.RowNumber);
                }
            }
            this.grdNUR4005.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR4005_GridColumnChanged);
        }

        private void SetValuer(int rowNum)
        {
            grdNUR4005.SetFocusToItem(rowNum, "valuer");
        }
        private void SetReserDate(int rowNum)
        {
            grdNUR4005.SetFocusToItem(rowNum, "reser_date");
        }
	}
}

