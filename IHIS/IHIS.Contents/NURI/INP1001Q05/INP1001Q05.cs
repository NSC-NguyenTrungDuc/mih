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
	/// INP1001Q05에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INP1001Q05 : IHIS.Framework.XScreen
	{
        private XPanel xPanel1;
        private XPanel xPanel2;
        private XPanel xPanel3;
        private XPatientBox paBox;
        private XEditGrid grIpwonHistory;
        private XButtonList xButtonList1;
        private XEditGridCell XEditGridCell1;
        private XEditGridCell XEditGridCell2;
        private XEditGridCell XEditGridCell12;
        private XEditGridCell XEditGridCell13;
        private XEditGridCell XEditGridCell14;
        private XEditGridCell XEditGridCell15;
        private XEditGridCell XEditGridCell16;
        private XEditGridCell XEditGridCell17;
        private XEditGridCell XEditGridCell18;
        private XEditGridCell XEditGridCell19;
        private XEditGridCell XEditGridCell20;
        private XEditGridCell XEditGridCell21;
        private XEditGridCell XEditGridCell22;
        private XEditGridCell XEditGridCell23;
        private XEditGridCell XEditGridCell24;
        private XEditGridCell XEditGridCell25;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public INP1001Q05()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP1001Q05));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grIpwonHistory = new IHIS.Framework.XEditGrid();
            this.XEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grIpwonHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(896, 36);
            this.xPanel1.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(896, 36);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 550);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(896, 40);
            this.xPanel2.TabIndex = 1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Location = new System.Drawing.Point(649, 3);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grIpwonHistory);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(0, 36);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(896, 514);
            this.xPanel3.TabIndex = 2;
            // 
            // grIpwonHistory
            // 
            this.grIpwonHistory.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.XEditGridCell2,
            this.XEditGridCell12,
            this.XEditGridCell14,
            this.XEditGridCell15,
            this.XEditGridCell16,
            this.XEditGridCell17,
            this.XEditGridCell18,
            this.XEditGridCell19,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.XEditGridCell20,
            this.XEditGridCell21,
            this.XEditGridCell22,
            this.XEditGridCell23,
            this.XEditGridCell24,
            this.XEditGridCell25,
            this.XEditGridCell13});
            this.grIpwonHistory.ColPerLine = 9;
            this.grIpwonHistory.Cols = 10;
            this.grIpwonHistory.DefaultHeight = 26;
            this.grIpwonHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grIpwonHistory.FixedCols = 1;
            this.grIpwonHistory.FixedRows = 1;
            this.grIpwonHistory.HeaderHeights.Add(31);
            this.grIpwonHistory.Location = new System.Drawing.Point(0, 0);
            this.grIpwonHistory.Name = "grIpwonHistory";
            this.grIpwonHistory.QuerySQL = resources.GetString("grIpwonHistory.QuerySQL");
            this.grIpwonHistory.RowHeaderVisible = true;
            this.grIpwonHistory.Rows = 2;
            this.grIpwonHistory.Size = new System.Drawing.Size(896, 514);
            this.grIpwonHistory.TabIndex = 0;
            this.grIpwonHistory.ToolTipActive = true;
            // 
            // XEditGridCell2
            // 
            this.XEditGridCell2.CellName = "pkinp1001";
            this.XEditGridCell2.Col = -1;
            this.XEditGridCell2.IsReadOnly = true;
            this.XEditGridCell2.IsVisible = false;
            this.XEditGridCell2.Row = -1;
            // 
            // XEditGridCell12
            // 
            this.XEditGridCell12.CellName = "ipwon_date";
            this.XEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.XEditGridCell12.CellWidth = 100;
            this.XEditGridCell12.Col = 1;
            this.XEditGridCell12.HeaderText = "入院日付";
            this.XEditGridCell12.IsJapanYearType = true;
            this.XEditGridCell12.IsReadOnly = true;
            // 
            // XEditGridCell14
            // 
            this.XEditGridCell14.CellName = "ipwon_type";
            this.XEditGridCell14.Col = -1;
            this.XEditGridCell14.IsReadOnly = true;
            this.XEditGridCell14.IsVisible = false;
            this.XEditGridCell14.Row = -1;
            // 
            // XEditGridCell15
            // 
            this.XEditGridCell15.CellName = "ipwon_type_name";
            this.XEditGridCell15.CellWidth = 100;
            this.XEditGridCell15.Col = 3;
            this.XEditGridCell15.HeaderText = "入院タイプ";
            this.XEditGridCell15.IsReadOnly = true;
            this.XEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XEditGridCell16
            // 
            this.XEditGridCell16.CellName = "gwa";
            this.XEditGridCell16.Col = -1;
            this.XEditGridCell16.IsReadOnly = true;
            this.XEditGridCell16.IsVisible = false;
            this.XEditGridCell16.Row = -1;
            // 
            // XEditGridCell17
            // 
            this.XEditGridCell17.CellName = "gwa_name";
            this.XEditGridCell17.Col = 4;
            this.XEditGridCell17.HeaderText = "診療科";
            this.XEditGridCell17.IsReadOnly = true;
            // 
            // XEditGridCell18
            // 
            this.XEditGridCell18.CellName = "doctor";
            this.XEditGridCell18.Col = -1;
            this.XEditGridCell18.IsReadOnly = true;
            this.XEditGridCell18.IsVisible = false;
            this.XEditGridCell18.Row = -1;
            // 
            // XEditGridCell19
            // 
            this.XEditGridCell19.CellName = "doctor_name";
            this.XEditGridCell19.CellWidth = 143;
            this.XEditGridCell19.Col = 5;
            this.XEditGridCell19.HeaderText = "主治医";
            this.XEditGridCell19.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "pkinp1002";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gubun";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // XEditGridCell20
            // 
            this.XEditGridCell20.CellName = "ho_dong1";
            this.XEditGridCell20.Col = -1;
            this.XEditGridCell20.IsReadOnly = true;
            this.XEditGridCell20.IsVisible = false;
            this.XEditGridCell20.Row = -1;
            // 
            // XEditGridCell21
            // 
            this.XEditGridCell21.CellName = "ho_dong_name";
            this.XEditGridCell21.CellWidth = 69;
            this.XEditGridCell21.Col = 6;
            this.XEditGridCell21.HeaderText = "病棟";
            this.XEditGridCell21.IsReadOnly = true;
            this.XEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XEditGridCell22
            // 
            this.XEditGridCell22.CellName = "ho_code1";
            this.XEditGridCell22.CellWidth = 57;
            this.XEditGridCell22.Col = 7;
            this.XEditGridCell22.HeaderText = "病室";
            this.XEditGridCell22.IsReadOnly = true;
            this.XEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XEditGridCell23
            // 
            this.XEditGridCell23.CellName = "toiwon_date";
            this.XEditGridCell23.CellType = IHIS.Framework.XCellDataType.Date;
            this.XEditGridCell23.CellWidth = 100;
            this.XEditGridCell23.Col = 8;
            this.XEditGridCell23.HeaderText = "退院日付";
            this.XEditGridCell23.IsJapanYearType = true;
            this.XEditGridCell23.IsReadOnly = true;
            // 
            // XEditGridCell24
            // 
            this.XEditGridCell24.CellName = "toiwon_res_date";
            this.XEditGridCell24.CellType = IHIS.Framework.XCellDataType.Date;
            this.XEditGridCell24.Col = -1;
            this.XEditGridCell24.IsReadOnly = true;
            this.XEditGridCell24.IsVisible = false;
            this.XEditGridCell24.Row = -1;
            // 
            // XEditGridCell25
            // 
            this.XEditGridCell25.CellName = "toiwon_result";
            this.XEditGridCell25.CellWidth = 140;
            this.XEditGridCell25.Col = 9;
            this.XEditGridCell25.HeaderText = "退院事由";
            this.XEditGridCell25.IsReadOnly = true;
            // 
            // XEditGridCell13
            // 
            this.XEditGridCell13.CellName = "jaewon_ilsu";
            this.XEditGridCell13.CellWidth = 60;
            this.XEditGridCell13.Col = 2;
            this.XEditGridCell13.HeaderText = "入院日数";
            this.XEditGridCell13.IsReadOnly = true;
            this.XEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // XEditGridCell1
            // 
            this.XEditGridCell1.CellName = "empty";
            this.XEditGridCell1.CellWidth = 28;
            this.XEditGridCell1.Col = 1;
            // 
            // INP1001Q05
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "INP1001Q05";
            this.Size = new System.Drawing.Size(896, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.INP1001Q05_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grIpwonHistory)).EndInit();
            this.ResumeLayout(false);

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

        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            { 
                case FunctionType.Query :
                    e.IsBaseCall = false;
                    this.grIpwonHistory.Reset();
                    Load_INP1001Q05();
                    break;
            }
        }

        private void Load_INP1001Q05()
        {
            BindVarCollection bindVar = new BindVarCollection();
            ArrayList alInput = new ArrayList();
            ArrayList alOutput = new ArrayList();
            string total_ilsu = string.Empty;

            this.grIpwonHistory.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grIpwonHistory.SetBindVarValue("f_bunho", paBox.BunHo);
            this.grIpwonHistory.QueryLayout(true);

            
            for (int i = 0; i < this.grIpwonHistory.RowCount; ++i)
            {
                alInput.Add(this.grIpwonHistory.GetItemString(i,"pkinp1001"));
                alInput.Add(this.grIpwonHistory.GetItemString(i, "pkinp1002"));
                alInput.Add(this.grIpwonHistory.GetItemString(i, "gubun"));

                if (this.grIpwonHistory.GetItemString(i, "toiwon_date") == "")
                {
                    alInput.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                }
                else alInput.Add(this.grIpwonHistory.GetItemString(i, "toiwon_date"));

                if (Service.ExecuteProcedure("PR_INP_LOAD_GISAN_JAEWON_ILSU", alInput, alOutput))
                {
                    total_ilsu = alOutput[0].ToString();

                }

                this.grIpwonHistory.SetItemValue(i, "jaewon_ilsu", total_ilsu);
            }

            this.grIpwonHistory.ResetUpdate();
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            if (paBox.BunHo != null)
            {
                Load_INP1001Q05();
            }
        }

        private void INP1001Q05_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            string sysDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

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

	}
}

