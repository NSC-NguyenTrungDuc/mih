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
	/// NUR0901U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR0901U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string soap_gubun  = string.Empty;
		#endregion

        #region [자동 생성 코드]
        
        #region 컨트롤 변수
        private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlLeft;
		private IHIS.Framework.XPanel pnlFill;
		private System.Windows.Forms.Label lblSoap_gubun;
		private IHIS.Framework.XComboBox cboSoap_gubun;
		private IHIS.Framework.XMstGrid grdNUR0901;
		private IHIS.Framework.XEditGrid grdNUR0902;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
		private System.Windows.Forms.Label lblHo_dong;
		private IHIS.Framework.XBuseoCombo cboHo_dong;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
        private MultiLayout layComboSet;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

        #region 생성자
        public NUR0901U00()
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

		#region 디자인 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR0901U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong = new System.Windows.Forms.Label();
            this.cboSoap_gubun = new IHIS.Framework.XComboBox();
            this.lblSoap_gubun = new System.Windows.Forms.Label();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdNUR0901 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdNUR0902 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0901)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0902)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.cboHo_dong);
            this.pnlTop.Controls.Add(this.lblHo_dong);
            this.pnlTop.Controls.Add(this.cboSoap_gubun);
            this.pnlTop.Controls.Add(this.lblSoap_gubun);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(960, 31);
            this.pnlTop.TabIndex = 0;
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.Location = new System.Drawing.Point(40, 4);
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(121, 21);
            this.cboHo_dong.TabIndex = 3;
            this.cboHo_dong.SelectedValueChanged += new System.EventHandler(this.cboHo_dong_SelectedValueChanged);
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.AutoSize = true;
            this.lblHo_dong.BackColor = System.Drawing.Color.Transparent;
            this.lblHo_dong.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo_dong.Location = new System.Drawing.Point(3, 7);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(35, 13);
            this.lblHo_dong.TabIndex = 2;
            this.lblHo_dong.Text = "病棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSoap_gubun
            // 
            this.cboSoap_gubun.Location = new System.Drawing.Point(297, 3);
            this.cboSoap_gubun.MaxDropDownItems = 50;
            this.cboSoap_gubun.Name = "cboSoap_gubun";
            this.cboSoap_gubun.Size = new System.Drawing.Size(140, 21);
            this.cboSoap_gubun.TabIndex = 1;
            this.cboSoap_gubun.SelectedValueChanged += new System.EventHandler(this.cboSoap_gubun_SelectedValueChanged);
            // 
            // lblSoap_gubun
            // 
            this.lblSoap_gubun.AutoSize = true;
            this.lblSoap_gubun.BackColor = System.Drawing.Color.Transparent;
            this.lblSoap_gubun.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoap_gubun.Location = new System.Drawing.Point(168, 7);
            this.lblSoap_gubun.Name = "lblSoap_gubun";
            this.lblSoap_gubun.Size = new System.Drawing.Size(128, 13);
            this.lblSoap_gubun.TabIndex = 0;
            this.lblSoap_gubun.Text = "経過記録SOAP区分";
            this.lblSoap_gubun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(471, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 33);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.grdNUR0901);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 31);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(474, 524);
            this.pnlLeft.TabIndex = 2;
            // 
            // grdNUR0901
            // 
            this.grdNUR0901.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdNUR0901.ColPerLine = 4;
            this.grdNUR0901.Cols = 4;
            this.grdNUR0901.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR0901.FixedRows = 1;
            this.grdNUR0901.FocusColumnName = "soap_bun1";
            this.grdNUR0901.HeaderHeights.Add(28);
            this.grdNUR0901.Location = new System.Drawing.Point(0, 0);
            this.grdNUR0901.Name = "grdNUR0901";
            this.grdNUR0901.QuerySQL = resources.GetString("grdNUR0901.QuerySQL");
            this.grdNUR0901.Rows = 2;
            this.grdNUR0901.Size = new System.Drawing.Size(472, 522);
            this.grdNUR0901.TabIndex = 0;
            this.grdNUR0901.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR0901_GridColumnChanged);
            this.grdNUR0901.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR_SaveEnd);
            this.grdNUR0901.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR0901_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 1;
            this.xEditGridCell1.CellName = "soap_gubun";
            this.xEditGridCell1.CellWidth = 45;
            this.xEditGridCell1.HeaderText = "SOAP\r\n区分";
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 2;
            this.xEditGridCell2.CellName = "soap_bun1";
            this.xEditGridCell2.CellWidth = 75;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "SOAP\r\n大分類コード";
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 200;
            this.xEditGridCell3.CellName = "soap_bun1_name";
            this.xEditGridCell3.CellWidth = 296;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.DisplayMemoText = true;
            this.xEditGridCell3.HeaderText = "SOAP\r\n大分類名";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "sort_key";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 35;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.HeaderText = "順序";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 4;
            this.xEditGridCell5.CellName = "ho_dong";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "병동";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // pnlFill
            // 
            this.pnlFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFill.Controls.Add(this.grdNUR0902);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(474, 31);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(486, 524);
            this.pnlFill.TabIndex = 3;
            // 
            // grdNUR0902
            // 
            this.grdNUR0902.CallerID = '2';
            this.grdNUR0902.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11});
            this.grdNUR0902.ColPerLine = 3;
            this.grdNUR0902.Cols = 3;
            this.grdNUR0902.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR0902.FixedRows = 1;
            this.grdNUR0902.FocusColumnName = "soap_bun2";
            this.grdNUR0902.HeaderHeights.Add(28);
            this.grdNUR0902.Location = new System.Drawing.Point(0, 0);
            this.grdNUR0902.MasterLayout = this.grdNUR0901;
            this.grdNUR0902.Name = "grdNUR0902";
            this.grdNUR0902.QuerySQL = resources.GetString("grdNUR0902.QuerySQL");
            this.grdNUR0902.Rows = 2;
            this.grdNUR0902.Size = new System.Drawing.Size(484, 522);
            this.grdNUR0902.TabIndex = 0;
            this.grdNUR0902.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR0902_QueryStarting);
            this.grdNUR0902.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR0902_GridColumnChanged);
            this.grdNUR0902.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR_SaveEnd);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 1;
            this.xEditGridCell6.CellName = "soap_gubun";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "SOAP\r\n区分";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 2;
            this.xEditGridCell7.CellName = "soap_bun1";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "SOAP\r\n大分類コード";
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 2;
            this.xEditGridCell8.CellName = "soap_bun2";
            this.xEditGridCell8.CellWidth = 75;
            this.xEditGridCell8.HeaderText = "SOAP\r\n小分類コード";
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 200;
            this.xEditGridCell9.CellName = "soap_bun2_name";
            this.xEditGridCell9.CellWidth = 355;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.DisplayMemoText = true;
            this.xEditGridCell9.HeaderText = "SOAP\r\n小分類名";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "sort_key";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.CellWidth = 35;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.HeaderText = "順序";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 4;
            this.xEditGridCell11.CellName = "ho_dong";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "병동";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // layComboSet
            // 
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboSet.QuerySQL = resources.GetString("layComboSet.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "soap_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "soap_gubun_code";
            // 
            // NUR0901U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR0901U00";
            this.Load += new System.EventHandler(this.NUR0901U00_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0901)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0902)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #endregion


        #region [APL 초기설정 관련 코드]
        private string mHospCode = "";
        private void NUR0901U00_Load(object sender, System.EventArgs e)
        {
            this.mHospCode = EnvironInfo.HospCode;
            this.SaveLayoutList.Add(this.grdNUR0901);
            this.SaveLayoutList.Add(this.grdNUR0902);

            this.grdNUR0901.SavePerformer = new XSavePerformer(this);
            this.grdNUR0902.SavePerformer = this.grdNUR0901.SavePerformer;

            /* 마스터와 디테일 테이블 연결 */
            this.grdNUR0902.SetRelationKey("soap_gubun", "soap_gubun");
            this.grdNUR0902.SetRelationKey("soap_bun1", "soap_bun1");
            this.grdNUR0902.SetRelationKey("ho_dong", "ho_dong");

            /* 콤보셋팅 */
            this.SetComboSetting();

            /* 콤보 디폴트 선택 */
            this.cboHo_dong.SetDataValue("1");

            /* 다른화면에서 스크린오픈 시 파라미터 받아오는 부분 추가 2011.12.26 woo*/
            if (this.OpenParam != null)
            {
                if (OpenParam.Contains("ho_dong"))
                {
                    if (TypeCheck.IsNull(OpenParam["ho_dong"].ToString().Trim()))
                    {
                        XMessageBox.Show("病棟を確認してください。", "お知らせ");
                        return;
                    }
                    else
                    {
                        string ho_dong = OpenParam["ho_dong"].ToString().Trim();
                        this.cboHo_dong.SetDataValue(ho_dong);
                    }
                }

                if (OpenParam.Contains("soap_gubun"))
                {
                    if (TypeCheck.IsNull(OpenParam["soap_gubun"].ToString().Trim()))
                    {
                        //XMessageBox.Show("SOAP区分を確認してください。", "お知らせ");
                        return;
                    }
                    else
                    {
                        string soap_gubun = OpenParam["soap_gubun"].ToString().Trim();
                        this.cboSoap_gubun.SetDataValue(soap_gubun);
                    }
                }
            }
        }

        #endregion

        #region [메세지 처리 코드]

        /// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string cpt = string.Empty;
			
			switch(aMesgGubun)
			{
				case "ho_dong":
					msg = "病棟が選択されていません。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
					break;
				case "soap_gubun":
					msg = "SOAP区分を入力してください。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
					break;
				case "select_soap":
					msg = "SOAP区分を選択してください。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
					break;
				case "soap_bun1":
					msg = "SOAP大分類コードを入力してください。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt , MessageBoxIcon.Information);
					break;
				case "soap_bun2":
					msg = "SOAP小分類コードを入力してください。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt , MessageBoxIcon.Information);
					break;
				case "master":
					msg = "SOAP区分の大分類情報を入力してください。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
					break;
				case "validation_chk":
					msg = "既に入力されている情報です。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
					break;
				case "delete_yn":
					msg = "細部内訳があり、削除することができません。" + "\n" +
						  "細部内訳を消してから保存してください。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = "保存しました。";
					cpt = "お知らせ";
					XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = "保存に失敗しました。ご確認ください。";
					msg += "\r\n[" + Service.ErrFullMsg + "]";
					cpt = "エラー";
					XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

        #region [입력/삭제/저장 처리 관련 코드]

        #region 입력/삭제/저장 버튼 클릭 처리
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    /* 입력Row가 마스터인지 디테일인지 체크 */
                    if (this.CurrMSLayout == this.grdNUR0901)
                    {
                        if (this.grdNUR0901.RowCount >= 0)
                        {
                            for (int i = 0; i < this.grdNUR0901.RowCount; i++)
                            {
                                if (this.grdNUR0901.LayoutTable.Rows[i].RowState == DataRowState.Added)
                                {
                                    if (this.grdNUR0901.GetItemString(i, "soap_gubun").ToString().Trim() == "")
                                    {
                                        e.IsBaseCall = false;
                                        this.GetMessage("soap_gubun");
                                        this.grdNUR0901.SetFocusToItem(i, "soap_gubun");
                                        break;
                                    }

                                    if (this.grdNUR0901.GetItemString(i, "soap_bun1").ToString().Trim() == "")
                                    {
                                        e.IsBaseCall = false;
                                        this.GetMessage("soap_bun1");
                                        this.grdNUR0901.SetFocusToItem(i, "soap_bun1");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        /* 마스터의 정보가 없으면 디테일 입력 불가능 */
                        if (this.grdNUR0901.RowCount == 0)
                        {
                            this.GetMessage("master");
                            e.IsBaseCall = false;
                            break;
                        }
                        /* 해당 마스터의 키값이 없으면 입력 불가능 */
                        else if (this.grdNUR0901.GetItemString(this.grdNUR0901.CurrentRowNumber, "soap_gubun") == "" ||
                                 this.grdNUR0901.GetItemString(this.grdNUR0901.CurrentRowNumber, "soap_bun1") == "")
                        {
                            if (this.grdNUR0901.GetItemString(this.grdNUR0901.CurrentRowNumber, "soap_gubun") == "")
                            {
                                this.GetMessage("soap_gubun");
                                this.grdNUR0901.SetFocusToItem(this.grdNUR0901.CurrentRowNumber, "soap_gubun");
                                e.IsBaseCall = false;
                            }
                            else
                            {
                                this.GetMessage("soap_bun1");
                                this.grdNUR0901.SetFocusToItem(this.grdNUR0901.CurrentRowNumber, "soap_bun1");
                                e.IsBaseCall = false;
                            }
                        }
                        else
                        {
                            /* 해당 데테일 Row의 키값이 없으면 더이상 입력 불가능 */
                            if (this.grdNUR0902.RowCount >= 0)
                            {
                                for (int i = 0; i < this.grdNUR0902.RowCount; i++)
                                {
                                    if (this.grdNUR0902.LayoutTable.Rows[i].RowState == DataRowState.Added)
                                    {
                                        if (this.grdNUR0902.GetItemString(i, "soap_bun2").ToString().Trim() == "")
                                        {
                                            this.GetMessage("soap_bun2");
                                            e.IsBaseCall = false;
                                            this.grdNUR0902.SetFocusToItem(i, "soap_bun2");
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case FunctionType.Delete:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    if (this.CurrMSLayout == this.grdNUR0901)
                    {
                        if (!this.NUR0901DeleteChk())
                        {
                            this.GetMessage("delete_yn");
                            e.IsBaseCall = false;
                            break;
                        }
                    }
                    break;

                case FunctionType.Update:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    if (this.grdNUR0901.RowCount > 0)
                    {
                        int i = 0;

                        for (i = 0; i < this.grdNUR0901.RowCount; i++)
                        {
                            if (this.grdNUR0901.GetItemValue(i, "soap_gubun").ToString().Trim() == "")
                            {
                                this.GetMessage("soap_gubun");
                                e.IsBaseCall = false;
                                this.grdNUR0901.SetFocusToItem(i, "soap_gubun");
                                return;
                            }
                            else if (this.grdNUR0901.GetItemValue(i, "soap_bun1").ToString().Trim() == "")
                            {
                                this.GetMessage("soap_bun1");
                                e.IsBaseCall = false;
                                this.grdNUR0901.SetFocusToItem(i, "soap_bun1");
                                return;
                            }
                        }
                    }

                    if (this.grdNUR0902.RowCount > 0)
                    {
                        for (int i = 0; i < this.grdNUR0902.RowCount; i++)
                        {
                            if (this.grdNUR0902.GetItemValue(i, "soap_bun2").ToString().Trim() == "")
                            {
                                this.GetMessage("soap_bun2");
                                e.IsBaseCall = false;
                                this.grdNUR0902.SetFocusToItem(i, "soap_bun2");
                                return;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region 입력버튼 클릭 후 처리
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    if (this.CurrMSLayout == this.grdNUR0901)
                    {
                        if (this.cboHo_dong.GetDataValue().ToString() != "")
                            this.grdNUR0901.SetItemValue(this.grdNUR0901.CurrentRowNumber, "ho_dong", this.cboHo_dong.GetDataValue());
                        else
                        {
                            this.GetMessage("ho_dong");
                            this.cboHo_dong.Focus();
                            return;
                        }

                        if (this.cboSoap_gubun.GetDataValue().ToString() != "")
                            this.grdNUR0901.SetItemValue(this.grdNUR0901.CurrentRowNumber, "soap_gubun", this.cboSoap_gubun.GetDataValue());
                        else
                        {
                            this.GetMessage("select_soap");
                            this.cboSoap_gubun.Focus();
                            return;
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

        #endregion

        #region [중환자실환자대장등록 데이타 취득 및 설정 코드]

        // <summary>
        /// 중환자실환자대장등록 데이타를 취득 후, 콤보박스에 설정한다.
        /// </summary>
		private void SetComboSetting()
		{
            this.layComboSet.SetBindVarValue("f_hosp_code", this.mHospCode);
			if(this.layComboSet.QueryLayout(false))
			{
				if(this.layComboSet.LayoutTable.Rows.Count > 0)
				{
					this.cboSoap_gubun.SetComboItems(this.layComboSet.LayoutTable, "soap_gubun_code", "soap_gubun");
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}
		}

		#endregion

        #region [경과기록SOAP마스터의 삭제가능여부 체크 코드]

        private bool NUR0901DeleteChk()
		{
            string cmdText = String.Empty;
            object retVal = null;
            BindVarCollection bindVals = new BindVarCollection();

            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS (SELECT 'X' 
                                         FROM NUR0902
                                        WHERE HOSP_CODE  = :f_hosp_code
                                          AND HO_DONG    = :f_ho_dong
                                          AND SOAP_GUBUN = :f_soap_gubun
                                          AND SOAP_BUN1  = :f_soap_bun1
                                          AND VALD       = 'Y'
                                          AND ROWNUM     = 1)";

            bindVals.Add("f_hosp_code", this.mHospCode);
            bindVals.Add("f_soap_gubun", this.grdNUR0901.GetItemString(this.grdNUR0901.CurrentRowNumber, "soap_gubun"));
            bindVals.Add("f_soap_bun1", this.grdNUR0901.GetItemString(this.grdNUR0901.CurrentRowNumber, "soap_bun1"));
            bindVals.Add("f_ho_dong", this.grdNUR0901.GetItemString(this.grdNUR0901.CurrentRowNumber, "ho_dong"));

            retVal = Service.ExecuteScalar(cmdText, bindVals);

            if (Service.ErrCode == 0)
            {
                /* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
                if (retVal != null && retVal.ToString().Equals("Y"))
                {
                    return false;
                }
            }
         
			return true;
		}

		#endregion

		#region [경과기록SOAP마스터/디테일 중복 체크 코드]

        #region 경과기록SOAP마스터 중복 체크
        private void grdNUR0901_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
            string cmdText = String.Empty;
            object retVal = null;
            BindVarCollection bindVals = new BindVarCollection();

			DataRowState rowState = this.grdNUR0901.LayoutTable.Rows[e.RowNumber].RowState;

            if (rowState == DataRowState.Added)
            {
                cmdText = @"SELECT 'Y'
                              FROM DUAL
                             WHERE EXISTS (SELECT 'X'
                                             FROM NUR0901
                                            WHERE HOSP_CODE  = :f_hosp_code
                                              AND HO_DONG    = :f_ho_dong
                                              AND SOAP_GUBUN = :f_soap_gubun
                                              AND SOAP_BUN1  = :f_soap_bun1 
                                              AND VALD       = 'Y')";

                bindVals.Add("f_hosp_code", this.mHospCode);
                bindVals.Add("f_ho_dong", this.grdNUR0901.GetItemString(e.RowNumber, "ho_dong"));
                bindVals.Add("f_soap_gubun", this.grdNUR0901.GetItemString(e.RowNumber, "soap_gubun"));
                bindVals.Add("f_soap_bun1", this.grdNUR0901.GetItemString(e.RowNumber, "soap_bun1"));

                retVal = Service.ExecuteScalar(cmdText, bindVals);

                if (Service.ErrCode == 0)
                {
                    /* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
                    if (retVal != null && retVal.ToString().Equals("Y"))
                    {
                        this.GetMessage("validation_chk");
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
        #endregion

        #region 경과기록SOAP디테일 중복 체크
		private void grdNUR0902_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
            string cmdText = String.Empty;
            object retVal = null;
            BindVarCollection bindVals = new BindVarCollection();
            
			DataRowState rowState = this.grdNUR0902.LayoutTable.Rows[e.RowNumber].RowState;

            if (rowState == DataRowState.Added)
            {

                cmdText = @"SELECT 'Y' 
                              FROM DUAL
                             WHERE EXISTS (SELECT 'X'
                                             FROM NUR0902
                                            WHERE HOSP_CODE  = :f_hosp_code
                                              AND HO_DONG    = :f_ho_dong
                                              AND SOAP_GUBUN = :f_soap_gubun
                                              AND SOAP_BUN1  = :f_soap_bun1
                                              AND SOAP_BUN2  = :f_soap_bun2
                                              AND VALD       = 'Y')";

                bindVals.Add("f_hosp_code", this.mHospCode);
                bindVals.Add("f_ho_dong", this.grdNUR0901.GetItemString(e.RowNumber, "ho_dong"));
                bindVals.Add("f_soap_gubun", this.grdNUR0901.GetItemString(e.RowNumber, "soap_gubun"));
                bindVals.Add("f_soap_bun1", this.grdNUR0901.GetItemString(e.RowNumber, "soap_bun1"));
                bindVals.Add("f_soap_bun2", e.ChangeValue.ToString());

                retVal = Service.ExecuteScalar(cmdText, bindVals);

                if (Service.ErrCode == 0)
                {
                    /* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
                    if (retVal != null && retVal.ToString().Equals("Y"))
                    {
                        this.GetMessage("validation_chk");
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
        #endregion

        #endregion

		#region [SOAP구분에 따른 경과기록SOAP마스터 취득 및 설정 코드]

		private void cboSoap_gubun_SelectedValueChanged(object sender, System.EventArgs e)
		{
			this.soap_gubun = this.cboSoap_gubun.GetDataValue();

			this.grdNUR0901.Reset();
			this.grdNUR0902.Reset();

			this.CurrMSLayout = this.grdNUR0901;
			this.CurrMQLayout = this.grdNUR0901;

			if(this.grdNUR0901.QueryLayout(false))
			{
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
		}

		#endregion

		#region [병동에 따른 경과기록SOAP마스터 취득 및 설정 코드]

		private void cboHo_dong_SelectedValueChanged(object sender, System.EventArgs e)
		{
            this.cboSoap_gubun.SetDataValue("S");
			if(this.cboSoap_gubun.GetDataValue().ToString() != "")
			{
                
				this.CurrMSLayout = this.grdNUR0901;
				this.CurrMQLayout = this.grdNUR0901;

				if(this.grdNUR0901.QueryLayout(false))
				{
				}
				else
				{
					XMessageBox.Show(Service.ErrFullMsg);
					return;
				}
			}
		}

		#endregion

        #region [경과기록SOAP마스터/디테일 바인드 변수 설정 코드]
        
        #region 경과기록SOAP마스터 바인드 변수 설정
        private void grdNUR0901_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR0901.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR0901.SetBindVarValue("f_ho_dong", cboHo_dong.GetDataValue());
            grdNUR0901.SetBindVarValue("f_soap_gubun", cboSoap_gubun.GetDataValue());
        }
        #endregion

        #region 경과기록SOAP디테일 바인드 변수 설정
        private void grdNUR0902_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR0902.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR0902.SetBindVarValue("f_ho_dong", grdNUR0901.GetItemValue(grdNUR0901.CurrentRowNumber, "ho_dong").ToString());
            grdNUR0902.SetBindVarValue("f_soap_gubun", grdNUR0901.GetItemValue(grdNUR0901.CurrentRowNumber, "soap_gubun").ToString());
            grdNUR0902.SetBindVarValue("f_soap_bun1", grdNUR0901.GetItemValue(grdNUR0901.CurrentRowNumber, "soap_bun1").ToString());
        }
        #endregion

        #endregion 

        #region [데이타 저장 완료 메시지 설정 코드]

        private bool masterFlag = false;
        private bool detailFlag = false;

        private void grdNUR_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                if (e.CallerID == '1')
                {
                    this.masterFlag = true;
                }
                else if (e.CallerID == '2')
                {
                    this.detailFlag = true;
                }

                if (this.masterFlag && this.detailFlag)
                {
                    this.GetMessage("save_true");

                    masterFlag = false;
                    detailFlag = false;
                }
            }
            else
            {
                this.GetMessage("save_false");

                masterFlag = false;
                detailFlag = false;
            }
        }

        #endregion


        #region [XSavePerformer]

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR0901U00 parent = null;

            public XSavePerformer(NUR0901U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = string.Empty;
                string action = string.Empty;
                object retVal = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1':
                        cmdText = @"SELECT 'Y'
                                      FROM DUAL
                                     WHERE EXISTS (SELECT 'X' 
                                                     FROM NUR0901
                                                    WHERE HOSP_CODE  = :f_hosp_code
                                                      AND HO_DONG    = :f_ho_dong
                                                      AND SOAP_GUBUN = :f_soap_gubun
                                                      AND SOAP_BUN1  = :f_soap_bun1 )";

                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (Service.ErrCode == 0)
                        {
                            if (retVal !=null && retVal.ToString().Equals("Y"))
                            {
                                action = "U";
                            }
                            else
                            {
                                action = "I";
                            }
                        }
                        else
                        {
                            return false;
                        }
                        
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                if (action.Equals("I"))
                                {
                                    cmdText = @"INSERT INTO NUR0901 (SYS_DATE,               SYS_ID,                 
                                                                     UPD_DATE,               UPD_ID,                 HOSP_CODE,
                                                                     HO_DONG,                SOAP_GUBUN,             SOAP_BUN1,
                                                                     SOAP_BUN1_NAME,         SORT_KEY,               VALD)
                                                            VALUES  (SYSDATE,                :q_user_id,             
                                                                     SYSDATE,                :q_user_id,             :f_hosp_code,
                                                                     :f_ho_dong,             :f_soap_gubun,          :f_soap_bun1, 
                                                                     :f_soap_bun1_name,      :f_sort_key,            'Y')";
                                }
                                else
                                {
                                    cmdText = @"UPDATE NUR0901
                                               SET UPD_ID         = :q_user_id,
                                                   UPD_DATE       = SYSDATE,
                                                   SOAP_BUN1_NAME = :f_soap_bun1_name,
                                                   SORT_KEY       = :f_sort_key,
                                                   VALD           = 'Y'
                                             WHERE HOSP_CODE      = :f_hosp_code
                                               AND HO_DONG        = :f_ho_dong
                                               AND SOAP_GUBUN     = :f_soap_gubun
                                               AND SOAP_BUN1      = :f_soap_bun1";
                                }
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR0901
                                               SET UPD_ID        = :q_user_id,
                                                   UPD_DATE       = SYSDATE,
                                                   SOAP_BUN1_NAME = :f_soap_bun1_name,
                                                   SORT_KEY       = :f_sort_key
                                             WHERE HOSP_CODE      = :f_hosp_code
                                               AND HO_DONG        = :f_ho_dong
                                               AND SOAP_GUBUN     = :f_soap_gubun
                                               AND SOAP_BUN1      = :f_soap_bun1
                                               AND VALD           = 'Y'";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"UPDATE NUR0901
                                               SET UPD_ID     = :q_user_id,
                                                   UPD_DATE   = SYSDATE,
                                                   VALD       = 'N'
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND HO_DONG    = :f_ho_dong
                                               AND SOAP_GUBUN = :f_soap_gubun
                                               AND SOAP_BUN1  = :f_soap_bun1
                                               AND VALD       = 'Y'";
                                break;
                        }
                        break;

                    case '2':
                        cmdText = @"SELECT 'Y'
                                      FROM DUAL
                                     WHERE EXISTS (SELECT 'X' 
                                                     FROM NUR0902
                                                    WHERE HOSP_CODE  = :f_hosp_code
                                                      AND HO_DONG    = :f_ho_dong
                                                      AND SOAP_GUBUN = :f_soap_gubun
                                                      AND SOAP_BUN1  = :f_soap_bun1
                                                      AND SOAP_BUN2  = :f_soap_bun2 )";

                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (Service.ErrCode == 0)
                        {
                            if (retVal != null && retVal.ToString().Equals("Y"))
                            {
                                action = "U";
                            }
                            else
                            {
                                action = "I";
                            }
                        }
                        else
                        {
                            return false;
                        }

                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                if (action.Equals("I"))
                                {
                                    cmdText = @"INSERT INTO NUR0902 (SYS_DATE,              SYS_ID,
                                                                     UPD_DATE,              UPD_ID,                 HOSP_CODE,
                                                                     HO_DONG,               SOAP_GUBUN,             SOAP_BUN1, 
                                                                     SOAP_BUN2,             SOAP_BUN2_NAME,         SORT_KEY, 
                                                                     VALD)
                                                            VALUES  (SYSDATE,               :q_user_id,             
                                                                     SYSDATE,               :q_user_id,             :f_hosp_code,
                                                                     :f_ho_dong,            :f_soap_gubun,          :f_soap_bun1, 
                                                                     :f_soap_bun2,          :f_soap_bun2_name,      :f_sort_key, 
                                                                     'Y')";
                                }
                                else
                                {
                                    cmdText = @"UPDATE NUR0902
                                                   SET UPD_ID         = :q_user_id,
                                                       UPD_DATE       = SYSDATE,
                                                       SOAP_BUN2_NAME = :f_soap_bun2_name,
                                                       SORT_KEY       = :f_sort_key,
                                                       VALD           = 'Y'
                                                 WHERE HOSP_CODE      = :f_hosp_code
                                                   AND HO_DONG        = :f_ho_dong
                                                   AND SOAP_GUBUN     = :f_soap_gubun
                                                   AND SOAP_BUN1      = :f_soap_bun1
                                                   AND SOAP_BUN2      = :f_soap_bun2";
                                }
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR0902
                                               SET UPD_ID         = :q_user_id,
                                                   UPD_DATE       = SYSDATE,
                                                   SOAP_BUN2_NAME = :f_soap_bun2_name,
                                                   SORT_KEY       = :f_sort_key
                                             WHERE HOSP_CODE      = :f_hosp_code
                                               AND HO_DONG        = :f_ho_dong
                                               AND SOAP_GUBUN     = :f_soap_gubun
                                               AND SOAP_BUN1      = :f_soap_bun1
                                               AND SOAP_BUN2      = :f_soap_bun2
                                               AND VALD           = 'Y'";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"UPDATE NUR0902
                                               SET UPD_ID     = :q_user_id,
                                                   UPD_DATE   = SYSDATE,
                                                   VALD       = 'N'
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND HO_DONG    = :f_ho_dong
                                               AND SOAP_GUBUN = :f_soap_gubun
                                               AND SOAP_BUN1  = :f_soap_bun1
                                               AND SOAP_BUN2  = :f_soap_bun2
                                               AND VALD       = 'Y'";
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
	}
}

