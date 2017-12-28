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
	/// NUR1010U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1010U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string sysid     = string.Empty;
		private string screen    = string.Empty;
		private string flag = "N";
		private string FindName = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XEditGrid grdNur1010;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XFindWorker fwkNurse;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XTextBox txtFkinp1001;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1010U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			//저장 수행자 Set
			this.grdNur1010.SavePerformer = new XSavePerformer(this);
			//저장 Layout List Set
			this.SaveLayoutList.Add(this.grdNur1010);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1010U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.txtFkinp1001 = new IHIS.Framework.XTextBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNur1010 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fwkNurse = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur1010)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtFkinp1001);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(491, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // txtFkinp1001
            // 
            this.txtFkinp1001.Location = new System.Drawing.Point(384, 5);
            this.txtFkinp1001.Name = "txtFkinp1001";
            this.txtFkinp1001.Size = new System.Drawing.Size(80, 20);
            this.txtFkinp1001.TabIndex = 1;
            this.txtFkinp1001.Visible = false;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(489, 29);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 251);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(491, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(2, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 33);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdNur1010
            // 
            this.grdNur1010.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell9,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdNur1010.ColPerLine = 3;
            this.grdNur1010.Cols = 4;
            this.grdNur1010.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNur1010.FixedCols = 1;
            this.grdNur1010.FixedRows = 1;
            this.grdNur1010.FocusColumnName = "damdang_nurse";
            this.grdNur1010.HeaderHeights.Add(21);
            this.grdNur1010.Location = new System.Drawing.Point(0, 36);
            this.grdNur1010.Name = "grdNur1010";
            this.grdNur1010.QuerySQL = resources.GetString("grdNur1010.QuerySQL");
            this.grdNur1010.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNur1010.RowHeaderVisible = true;
            this.grdNur1010.Rows = 2;
            this.grdNur1010.Size = new System.Drawing.Size(491, 215);
            this.grdNur1010.TabIndex = 12;
            this.grdNur1010.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNur1010_QueryEnd);
            this.grdNur1010.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNur1010_QueryStarting);
            this.grdNur1010.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNur1010_GridColumnChanged);
            this.grdNur1010.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdNur1010_GridFindSelected);
            this.grdNur1010.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdNur1010_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "患者番号";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "입원키";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 8;
            this.xEditGridCell9.CellName = "damdang_nurse";
            this.xEditGridCell9.CellWidth = 115;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.FindWorker = this.fwkNurse;
            this.xEditGridCell9.HeaderText = "担当看護師";
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "damdang_nurse_name";
            this.xEditGridCell3.CellWidth = 150;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderText = "担当看護師名";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "jukyong_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 180;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.HeaderText = "適用日付";
            this.xEditGridCell4.IsJapanYearType = true;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // NUR1010U00
            // 
            this.Controls.Add(this.grdNur1010);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1010U00";
            this.Size = new System.Drawing.Size(491, 286);
            this.Load += new System.EventHandler(this.NUR1010U00_Load);
            this.UserChanged += new System.EventHandler(this.NUR1010U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1010U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur1010)).EndInit();
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
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + " 환자번호를 확인해 주세요"
						: "在院中の患者ではありません。患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
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
				case "damdang_nurse":
					msg = (NetInfo.Language == LangMode.Ko ? "담당간호사의 직원No.를 입력해 주세요."
						: "担当看護師の職員Noを入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "jukyong_date":
					msg = (NetInfo.Language == LangMode.Ko ? "적용일자를 입력해 주세요."
						: "適用日付を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
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

		/// <summary>
		/// 환자번호로 입원키를 찾는다.
		/// </summary>
		#region 환자의 입원키를 찾는다.
		private void GetFkinp1001()
		{
			try
			{
                string cmdText = @"SELECT PKINP1001
                                     FROM VW_OCS_INP1001_01
                                    WHERE HOSP_CODE            = :f_hosp_code 
                                      AND NVL(CANCEL_YN,'N')   = 'N'
                                      AND NVL(JAEWON_FLAG,'N') = 'Y'
                                      AND BUNHO                = :f_bunho";

                BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
				bindVars.Add("f_bunho", paBox.BunHo.Trim());
				
                object retVal = Service.ExecuteScalar(cmdText, bindVars);

				if(TypeCheck.IsNull(retVal))
				{
					GetMessage("jeawonYn");
					grdNur1010.Enabled = false;
					paBox.Focus();
					return;
				}
				else
				{
					grdNur1010.Enabled = true;

					txtFkinp1001.SetDataValue(retVal.ToString());

					if(!grdNur1010.QueryLayout(false))
					{
						XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Service.ErrCode);
					}
				}
			}
			catch(Exception ex)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
				return;
			}
		}
		#endregion

		#region Screen Load
		private void NUR1010U00_Load(object sender, System.EventArgs e)
		{
			this.CurrMSLayout = this.grdNur1010;
			this.CurrMQLayout = this.grdNur1010;

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
		private void grdNur1010_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
		{
			this.grdNur1010.SetItemValue(e.RowNumber, "damdang_nurse_name", e.ReturnValues[1]);
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

					if(this.paBox.BunHo.ToString() == "" || this.txtFkinp1001.GetDataValue() == "")
					{
						e.IsBaseCall = false;
						this.GetMessage("bunho");
					}
					else
					{
					}
					break;
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					if(this.paBox.BunHo.ToString() == "")
					{
						e.IsBaseCall = false;
						this.GetMessage("bunho");
						return;
					}
					break;
				case FunctionType.Update:

                    e.IsBaseCall = false; 

					if(!this.AcceptData())
					{
						e.IsSuccess = false;
					}

					if(this.paBox.BunHo.ToString() == "")
					{
						this.GetMessage("bunho");
						this.paBox.Focus();
						return;
					}

					if(this.grdNur1010.RowCount > 0)
					{
						for(int i = 0; i < this.grdNur1010.RowCount; i++)
						{
							if(this.grdNur1010.GetItemString(i, "damdang_nurse") == "")
							{
								this.GetMessage("damdang_nurse");
								this.grdNur1010.SetFocusToItem(i, "damdang_nurse");
								return;
							}

							if(this.grdNur1010.GetItemString(i, "jukyong_date") == "")
							{
								this.GetMessage("jukyong_date");
								this.grdNur1010.SetFocusToItem(i, "jukyong_date");
								return;
							}
						}              
					}

                    // grdNur1010 저장처리 호출
                    if (!grdNur1010.SaveLayout())
                    {
                        XMessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                        return;
                    }

                    XMessageBox.Show("保存しました。", "保存", MessageBoxIcon.Information);      
					break;

				case FunctionType.Close:
					if(this.flag == "S")
					{
						IHIS.Framework.IXScreen aScreen;
						aScreen = XScreen.FindScreen(sysid, screen);

						if (aScreen == null)
						{              
							CommonItemCollection openParams  = new CommonItemCollection();
							openParams.Add( "NUR1010U00", "1010");
				
							XScreen.OpenScreenWithParam(this, sysid, screen, IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);

						}
						else
						{
							CommonItemCollection openParams  = new CommonItemCollection();
							openParams.Add("NUR1010U00", "1010");
							this.Close();
							aScreen.Command("NUR1010U00", openParams);
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 환자번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			this.grdNur1010.Reset();
			if(!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
				this.GetFkinp1001();
			}
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
						if(this.grdNur1010.RowCount > 0)
						{
							if(this.grdNur1010.CurrentRowNumber >= 0)
							{
								this.grdNur1010.SetItemValue(this.grdNur1010.CurrentRowNumber, "bunho", this.paBox.BunHo.Trim());
								this.grdNur1010.SetItemValue(this.grdNur1010.CurrentRowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
								this.grdNur1010.SetItemValue(this.grdNur1010.CurrentRowNumber,"jukyong_date",
									IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
							}
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 중복체크 및 간호사이름 로드
		private void grdNur1010_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			DataRowState rowState = this.grdNur1010.LayoutTable.Rows[e.RowNumber].RowState;

			string cmdText = @"SELECT 'Y'
								 FROM NUR1010
							    WHERE HOSP_CODE     = :f_hosp_code 
                                  AND BUNHO         = :f_bunho
								  AND FKINP1001     = :f_fkinp1001
								  AND JUKYONG_DATE  = :f_jukyong_date";

            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code",     EnvironInfo.HospCode);
			bindVars.Add("f_bunho",			grdNur1010.GetItemString(e.RowNumber, "bunho"));
			bindVars.Add("f_fkinp1001",		grdNur1010.GetItemString(e.RowNumber, "fkinp1001"));
			bindVars.Add("f_jukyong_date",	grdNur1010.GetItemString(e.RowNumber, "jukyong_date"));

			object retVal = Service.ExecuteScalar(cmdText, bindVars);

			switch(e.ColName)
			{
				case "jukyong_date":
                case "damdang_nurse":
					if(rowState == DataRowState.Added)
					{
						if(!TypeCheck.IsNull(retVal))
						{
							/* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
                            if (retVal.ToString().Equals("Y"))
                            {
                                if (e.ColName.Equals("jukyong_date"))
                                {
                                    e.Cancel = true;
                                }
                                GetMessage("validation_chk");
                                return;
                            }
						}
                        else
                        {
                            bindVars.Clear();
                            cmdText = "SELECT FN_ADM_LOAD_USER_NAME(:f_user_id) FROM DUAL";
                            bindVars.Add("f_user_id", grdNur1010.GetItemString(grdNur1010.CurrentRowNumber, "damdang_nurse"));
                            retVal = Service.ExecuteScalar(cmdText, bindVars);
                            if (retVal.ToString()!="")
                            {
                                grdNur1010.SetItemValue(grdNur1010.CurrentRowNumber, "damdang_nurse_name", retVal.ToString());
                            }
                            else
                            {
                                XMessageBox.Show("入力された担当看護師の番号を見つけませんでした。");
                                e.Cancel = true;
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
		private void NUR1010U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if(this.OpenParam != null)
			{
				this.sysid      = OpenParam["sysid"].ToString();
				this.screen     = OpenParam["screen"].ToString();
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
				this.flag = this.OpenParam["flag"].ToString();
			}
		}
		#endregion

		#region 등록번호를 잘못 입력을 했을 때
		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.grdNur1010.Reset();
		}
		#endregion

		#region 사용자변경이 있을 때
		private void NUR1010U00_UserChanged(object sender, System.EventArgs e)
		{
			this.grdNur1010.Reset();

			this.CurrMQLayout = this.grdNur1010;
			this.CurrMSLayout = this.grdNur1010;

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

		#region vsvValidationChk 맵핑
		private void grdNur1010_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if(grdNur1010.RowCount > 0)
			{
				for(int i=0; i < grdNur1010.RowCount; i++)
				{
					object code = grdNur1010.GetItemString(i, "damdang_nurse");
					if(!TypeCheck.IsNull(code))
					{
						grdNur1010.SetItemValue(i, "damdang_nurse_name", DamdangNurseName(code.ToString()));
					}
				}
			}
		}

		private string DamdangNurseName(string code)
		{
			string name;

			string cmdText = @"SELECT B.USER_NM 
								 FROM ADM3200 B 
								WHERE B.HOSP_CODE = :f_hosp_code
                                  AND B.DEPT_CODE LIKE '%' 
								  AND SYSDATE <= NVL(B.USER_END_YMD, TO_DATE('99981231', 'YYYY/MM/DD')) 
								  AND B.USER_ID = :f_code 
								  AND B.USER_GUBUN = '2'";
			BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
			bindVars.Add("f_code", code);

			object retVal = Service.ExecuteScalar(cmdText, bindVars);

			if(!TypeCheck.IsNull(retVal))
			{
				name = Service.ExecuteScalar(cmdText, bindVars).ToString();
			}
			else
			{
				name = "";
			}

			return name;
		}
		#endregion

		#region 해당병동 간호사로드
		private void grdNur1010_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
            this.fwkNurse.SetBindVarValue("f_buseo_code", UserInfo.BuseoCode);
            this.fwkNurse.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);		
		}
		#endregion

		#region grdNur1010 바인드변수 설정
		private void grdNur1010_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdNur1010.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			grdNur1010.SetBindVarValue("f_fkinp1001", txtFkinp1001.GetDataValue());
		}
		#endregion     

		#region XSavePerformer
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private NUR1010U00 parent = null;
			public XSavePerformer(NUR1010U00 parent)
			{
				this.parent = parent;
			}
			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdText = "";
                object retVal = null;

                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

				switch (item.RowState)
				{
					case DataRowState.Added:
                        cmdText
                            = @"INSERT INTO NUR1010 (SYS_DATE        , SYS_ID        , UPD_DATE       , UPD_ID      , HOSP_CODE  ,
					    							 BUNHO           , FKINP1001     , JUKYONG_DATE   ,
						    						 DAMDANG_NURSE)
							    VALUES              (SYSDATE         , :q_user_id    , SYSDATE          , :q_user_id  , :f_hosp_code, 
								    				 :f_bunho        , :f_fkinp1001  , :f_jukyong_date  ,
									    			 :f_damdang_nurse)";
						break;
					case DataRowState.Modified:
						cmdText
							= @"UPDATE NUR1010
								   SET UPD_ID        = :q_user_id,
									   UPD_DATE      = SYSDATE,
									   DAMDANG_NURSE = :f_damdang_nurse
								 WHERE HOSP_CODE     = :f_hosp_code 
                                   AND BUNHO         = :f_bunho
								   AND FKINP1001     = :f_fkinp1001
								   AND JUKYONG_DATE  = :f_jukyong_date";
						break;
					case DataRowState.Deleted:
						cmdText
							= @"DELETE NUR1010
								 WHERE HOSP_CODE    = :f_hosp_code 
                                   AND BUNHO        = :f_bunho
								   AND FKINP1001    = :f_fkinp1001
								   AND JUKYONG_DATE = :f_jukyong_date";
						break;
				}

				return Service.ExecuteNonQuery(cmdText, item.BindVarList);
			}
		}
		#endregion
	}
}

