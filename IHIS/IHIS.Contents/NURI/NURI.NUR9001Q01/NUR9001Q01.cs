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
	/// NUR9001Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR9001Q01 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string sysid     = string.Empty;
		private string screen    = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XEditGrid grdToiwonList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

        #region 생성자
        private string mHospCode = "";
		public NUR9001Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            mHospCode = EnvironInfo.HospCode;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR9001Q01));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdToiwonList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdToiwonList)).BeginInit();
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
            this.pnlTop.Size = new System.Drawing.Size(523, 35);
            this.pnlTop.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(523, 31);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 434);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(523, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Location = new System.Drawing.Point(279, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdToiwonList);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 35);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(523, 399);
            this.pnlFill.TabIndex = 2;
            // 
            // grdToiwonList
            // 
            this.grdToiwonList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdToiwonList.ColPerLine = 4;
            this.grdToiwonList.Cols = 5;
            this.grdToiwonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdToiwonList.FixedCols = 1;
            this.grdToiwonList.FixedRows = 1;
            this.grdToiwonList.HeaderHeights.Add(21);
            this.grdToiwonList.Location = new System.Drawing.Point(0, 0);
            this.grdToiwonList.Name = "grdToiwonList";
            this.grdToiwonList.QuerySQL = resources.GetString("grdToiwonList.QuerySQL");
            this.grdToiwonList.ReadOnly = true;
            this.grdToiwonList.RowHeaderVisible = true;
            this.grdToiwonList.Rows = 2;
            this.grdToiwonList.Size = new System.Drawing.Size(523, 399);
            this.grdToiwonList.TabIndex = 0;
            this.grdToiwonList.DoubleClick += new System.EventHandler(this.grdToiwonList_DoubleClick);
            this.grdToiwonList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdToiwonList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ipwon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 120;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.HeaderText = "入院日付";
            this.xEditGridCell1.IsJapanYearType = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "toiwon_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 120;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell2.HeaderText = "退院日付";
            this.xEditGridCell2.IsJapanYearType = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 120;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.HeaderText = "患者番号";
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 120;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.HeaderText = "患者氏名";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "pkinp1001";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "pkinp1001";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // NUR9001Q01
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR9001Q01";
            this.Size = new System.Drawing.Size(523, 469);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR9001Q01_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdToiwonList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 팝업으로 오픈이 됐을 때
		private void NUR9001Q01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if(this.OpenParam != null)
			{
				this.paBox.SetPatientID(OpenParam["bunho"].ToString());
				this.sysid      = OpenParam["sysid"].ToString();
				this.screen     = OpenParam["screen"].ToString();
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
				if(!grdToiwonList.QueryLayout(false))
				{
					XMessageBox.Show(Service.ErrFullMsg.ToString());
					return;
				}
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

                    if (!grdToiwonList.QueryLayout(false))
                    {
                        XMessageBox.Show(Service.ErrFullMsg.ToString());
                        return;
                    }
					break;
				default:
					break;
			}
		}
		#endregion

		#region 그리드에서 두번 클릭을 했을 때
		private void grdToiwonList_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.grdToiwonList.CurrentRowNumber >= 0)
			{	
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen(sysid, screen);

				if (aScreen == null)
				{              
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "toiwon_date", this.grdToiwonList.GetItemValue(this.grdToiwonList.CurrentRowNumber, "toiwon_date"));
					openParams.Add( "fkinp1001", this.grdToiwonList.GetItemValue(this.grdToiwonList.CurrentRowNumber, "pkinp1001"));
                    openParams.Add("bunho", this.grdToiwonList.GetItemValue(this.grdToiwonList.CurrentRowNumber, "bunho"));
				
					XScreen.OpenScreenWithParam(this, sysid, screen, IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
				}
				else
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "toiwon_date", this.grdToiwonList.GetItemValue(this.grdToiwonList.CurrentRowNumber, "toiwon_date"));
					openParams.Add( "fkinp1001", this.grdToiwonList.GetItemValue(this.grdToiwonList.CurrentRowNumber, "pkinp1001"));
                    openParams.Add( "bunho", this.grdToiwonList.GetItemValue(this.grdToiwonList.CurrentRowNumber, "bunho"));
					this.Close();
					aScreen.Command("toiwon_date", openParams);
				}
			}
		}
		#endregion

        #region grdToiwonList 쿼리 바인드 변수 설정
        private void grdToiwonList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdToiwonList.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdToiwonList.SetBindVarValue("f_bunho", paBox.BunHo);
        }
        #endregion
    }
}

//[[ ============================================= Edit End 20100602 河中 ============================================= ]]

