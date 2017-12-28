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
	/// NUR2004U02에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR2004U02 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdINP2004;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;

		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPatientBox paBox;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR2004U02()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR2004U02));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdINP2004 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2004)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 555);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(951, 35);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", 3, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(626, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.Size = new System.Drawing.Size(325, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdINP2004
            // 
            this.grdINP2004.AddedHeaderLine = 1;
            this.grdINP2004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell15,
            this.xEditGridCell3,
            this.xEditGridCell16,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14});
            this.grdINP2004.ColPerLine = 14;
            this.grdINP2004.Cols = 14;
            this.grdINP2004.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP2004.FixedRows = 2;
            this.grdINP2004.HeaderHeights.Add(21);
            this.grdINP2004.HeaderHeights.Add(21);
            this.grdINP2004.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdINP2004.Location = new System.Drawing.Point(0, 33);
            this.grdINP2004.Name = "grdINP2004";
            this.grdINP2004.QuerySQL = resources.GetString("grdINP2004.QuerySQL");
            this.grdINP2004.Rows = 3;
            this.grdINP2004.Size = new System.Drawing.Size(951, 522);
            this.grdINP2004.TabIndex = 1;
            this.grdINP2004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP2004_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "cancel_yn";
            this.xEditGridCell1.CellWidth = 21;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "取\r\n消";
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "입원키";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 75;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "患者番号";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "trans_cnt";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "횟차";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "from_ho_dong";
            this.xEditGridCell5.CellWidth = 35;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "病棟";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.Row = 1;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "from_ho_code";
            this.xEditGridCell6.CellWidth = 35;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "病室";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.Row = 1;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "from_bed_no";
            this.xEditGridCell7.CellWidth = 35;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "病床";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.Row = 1;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "from_gwa";
            this.xEditGridCell8.CellWidth = 110;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "診療科";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.Row = 1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "from_doctor";
            this.xEditGridCell9.CellWidth = 110;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "主治医";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "to_ho_dong";
            this.xEditGridCell10.CellWidth = 35;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "病棟";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.Row = 1;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "to_ho_code";
            this.xEditGridCell11.CellWidth = 35;
            this.xEditGridCell11.Col = 10;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "病室";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.Row = 1;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "to_bed_no";
            this.xEditGridCell12.CellWidth = 35;
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "病床";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.Row = 1;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "to_gwa";
            this.xEditGridCell13.CellWidth = 110;
            this.xEditGridCell13.Col = 12;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderText = "診療科";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.Row = 1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "to_doctor";
            this.xEditGridCell14.CellWidth = 110;
            this.xEditGridCell14.Col = 13;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "主治医";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.Row = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlTop.Size = new System.Drawing.Size(951, 33);
            this.pnlTop.TabIndex = 2;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(951, 30);
            this.paBox.TabIndex = 0;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "start_date";
            this.xEditGridCell15.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell15.CellWidth = 90;
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "申請日";
            this.xEditGridCell15.IsJapanYearType = true;
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.RowSpan = 2;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "suname";
            this.xEditGridCell16.CellWidth = 113;
            this.xEditGridCell16.Col = 2;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "患者名";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 5;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "[ 変 更 前 ]";
            this.xGridHeader1.HeaderWidth = 35;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 9;
            this.xGridHeader2.ColSpan = 5;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderText = "[ 変 更 後 ]";
            this.xGridHeader2.HeaderWidth = 35;
            // 
            // NUR2004U02
            // 
            this.Controls.Add(this.grdINP2004);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "NUR2004U02";
            this.Size = new System.Drawing.Size(951, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR2004U02_ScreenOpen);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2004)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 조회
		private void GetQuery()
		{
			this.grdINP2004.Reset();

			//if (this.paBox.BunHo.ToString() == "") return;

			if (!this.grdINP2004.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}
		}
		#endregion

		#region Screen Load
		private void NUR2004U02_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            this.grdINP2004.SavePerformer = new XSavePerformer(this);

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
            this.grdINP2004.QueryLayout(false);

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

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					//조회
					GetQuery();
					break;
				case FunctionType.Update:
                    e.IsBaseCall = false;
                    
                    string msg = string.Empty;
                    string caption = string.Empty;

                    if (this.grdINP2004.SaveLayout())
                    { 
                        msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
                            : "保存しました。";
                        caption = NetInfo.Language == LangMode.Ko ? "알림" 
                            : "保存";
                        XMessageBox.Show(msg, caption, MessageBoxIcon.Information);

                        //조회
                        GetQuery();
                    }
                    else
                    { 
                        msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
                            : "保存に失敗しました。ご確認ください。";
                        msg += "\r\n[" + Service.ErrFullMsg + "]";
                        caption = NetInfo.Language == LangMode.Ko ? "알림" 
                            : "保存失敗";
                        XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                    }

					break;
				default:
					break;
			}
		}
		#endregion

		#region 환자번호가 입력이 됐을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			//조회
			GetQuery();
		}
		#endregion

        #region grdINP2004_QueryStarting
        private void grdINP2004_QueryStarting(object sender, CancelEventArgs e)
        {
//            string cmdText= @"SELECT A.PKINP1001
//                                FROM VW_OCS_INP1001_01 A
//                               WHERE A.HOSP_CODE           = :f_hosp_code
//                                 AND A.BUNHO               = :f_bunho
//                                 AND NVL(A.CANCEL_YN, 'N') = 'N'
//                                 AND A.JAEWON_FLAG         = 'Y'
//                                 AND ROWNUM                = 1   ";
//            BindVarCollection bc = new BindVarCollection();
//            bc.Add("f_hosp_code", EnvironInfo.HospCode);
//            bc.Add("f_bunho", paBox.BunHo);

//            object pkinp1001 = Service.ExecuteScalar(cmdText, bc);

//            if (TypeCheck.IsNull(pkinp1001))
//                return;

            this.grdINP2004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP2004.SetBindVarValue("f_bunho", paBox.BunHo);
            //this.grdINP2004.SetBindVarValue("f_fkinp1001", pkinp1001.ToString());

        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            NUR2004U02 parent;

            public XSavePerformer(NUR2004U02 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char CallerID, RowDataItem item)
            {
                string cmdText = "";

                if (item.BindVarList["f_cancel_yn"].VarValue != "Y")
                    return true;

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                switch (item.RowState)
                { 
                    case DataRowState.Modified:

                        if (item.BindVarList["f_cancel_yn"].VarValue == "Y")
                        {
                            cmdText = @"UPDATE INP2004
                                           SET TO_NURSE_CONFIRM_ID   = :q_user_id
                                             , TO_NURSE_CONFIRM_DATE = TRUNC(SYSDATE)
                                             , CANCEL_YN             = 'Y'
                                         WHERE HOSP_CODE = :f_hosp_code
                                           AND FKINP1001 = :f_fkinp1001
                                           AND BUNHo     = :f_bunho
                                           AND TRANS_CNT = :f_trans_cnt";
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            
            }
        }
        #endregion

    }
}

