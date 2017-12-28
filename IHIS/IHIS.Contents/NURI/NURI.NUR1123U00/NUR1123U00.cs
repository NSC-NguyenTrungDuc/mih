#region 사용 NameSpace 지정
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using IHIS.Framework;
#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// NUR0101U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1123U00 : IHIS.Framework.XScreen
    {
        #region [자동 생성 코드]
        
        #region 컨트롤 변수
        private IHIS.Framework.XMstGrid grdMaster;
		private IHIS.Framework.XEditGrid grdDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XLabel lblCode_type;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlLeft;
        private IHIS.Framework.XPanel pnlFill;
        private MultiLayout layComboItems;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XEditGridCell xEditGridCell6;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1123U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}
		#endregion

		#region 소멸자
		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		#endregion

		#region 디자인 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1123U00));
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.lblCode_type = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.layComboItems = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layComboItems)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 1;
            this.grdMaster.Cols = 2;
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.FocusColumnName = "code_type";
            this.grdMaster.HeaderHeights.Add(19);
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.QuerySQL = "SELECT NVL(CODE, \' \')      CODE,\r\n       NVL(CODE_NAME, \' \') CODE_NAME\r\n  FROM NU" +
                "R0102\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = \'WATCH_TEMPLATE\'\r\n OR" +
                "DER BY SORT_KEY";
            this.grdMaster.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.Size = new System.Drawing.Size(447, 556);
            this.grdMaster.TabIndex = 2;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grd_SaveEnd);
            this.grdMaster.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdMaster_RowFocusChanging);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 150;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 397;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.HeaderText = "区分";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // grdDetail
            // 
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdDetail.ColPerLine = 3;
            this.grdDetail.Cols = 4;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.FocusColumnName = "code";
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.Location = new System.Drawing.Point(0, 0);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.QuerySQL = resources.GetString("grdDetail.QuerySQL");
            this.grdDetail.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.Size = new System.Drawing.Size(502, 556);
            this.grdDetail.TabIndex = 3;
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grd_SaveEnd);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 127;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.HeaderText = "コード";
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 282;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.HeaderText = "コード名称";
            this.xEditGridCell5.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sort_key";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.CellWidth = 47;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.HeaderText = "順番";
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(460, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 32);
            this.btnList.TabIndex = 5;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.blsButton_ButtonClick);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.lblCode_type);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(949, 0);
            this.pnlTop.TabIndex = 7;
            // 
            // lblCode_type
            // 
            this.lblCode_type.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblCode_type.EdgeRounding = false;
            this.lblCode_type.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode_type.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblCode_type.Location = new System.Drawing.Point(7, 6);
            this.lblCode_type.Name = "lblCode_type";
            this.lblCode_type.Size = new System.Drawing.Size(93, 21);
            this.lblCode_type.TabIndex = 10;
            this.lblCode_type.Text = "コード類型";
            this.lblCode_type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 556);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(949, 34);
            this.pnlBottom.TabIndex = 8;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdMaster);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(447, 556);
            this.pnlLeft.TabIndex = 9;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdDetail);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(447, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(502, 556);
            this.pnlFill.TabIndex = 10;
            // 
            // layComboItems
            // 
            this.layComboItems.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboItems.QuerySQL = "SELECT NVL(CODE, \' \')      CODE,\r\n       NVL(CODE_NAME, \' \') CODE_NAME\r\n  FROM NU" +
                "R0102\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = \'WATCH_TEMPLATE\'\r\n OR" +
                "DER BY SORT_KEY";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code_type";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_type_name";
            // 
            // NUR1123U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1123U00";
            this.Size = new System.Drawing.Size(949, 590);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layComboItems)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #endregion


        #region [APL 초기설정 코드]
        private string mHospCode = "";
        private string code_type = "";
        protected override void OnLoad(EventArgs e)
		{
            mHospCode = EnvironInfo.HospCode;
			base.OnLoad (e);

            // SaveLayout 설정
            this.SaveLayoutList.Add(this.grdMaster);
            this.SaveLayoutList.Add(this.grdDetail);

            // 그리드 SavePerformer 설정
            this.grdMaster.SavePerformer = new XSavePerformer(this);
            this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            // 마스터-디테일 관계 설정
            this.grdDetail.SetRelationKey("code_type", "code_type");
            this.grdDetail.SetRelationTable("NUR1123");

            this.CurrMSLayout = this.grdMaster;

            // 코드유형에 따른 마스터 그리드 설정
            this.grdMaster.QueryLayout(false);

            //바이탈싸인에서 열었을 때 파라미터 받아와 그 파라미터값으로 포커스 이동. 2012.01.26
            if (this.OpenParam != null)
            {
                code_type = this.OpenParam["code_type"].ToString();
                for (int i = 0; i < grdMaster.Rows; i++)
                {
                    if (this.grdMaster.GetItemString(i, "code_type") == code_type)
                    {
                        this.grdMaster.SetFocusToItem(i, 0);
                    }
                }
            }
		}
        #endregion

        #region [메세지 처리 코드]

        private void ShowMessage(string separation)
        {
            string msg = string.Empty;
            string cpt = string.Empty;

            switch (separation)
            {
                case "MasterInsert":
                    msg = "新たに入力された行があります。先に保存をしてください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailInsert":
                    msg = "コード入力するには\n先にコード類型を登録する必要があります。";
                    cpt = "コード類型入力確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDeleteGrid":
                    msg = String.Format("[{0}]は詳細コードを持っています。\nこのコード類型を削除するには先に詳細コードを削除してください。",
                                         grdMaster[grdMaster.CurrentRowNumber, "code_type"].Value.ToString());
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDeleteDB":
                    msg = "細部内訳があり、削除することができません。\n細部内訳を消してから保存してください。";
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDup":
                    msg = String.Format("[{0}]は既に存在しているコード類型です。他のコード類型を入力してください。",
                                         grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailDup":
                    msg = String.Format("[{0}]は既に存在しているコード類型です。他のコード類型を入力してください。",
                                         grdDetail.GetItemValue(grdDetail.CurrentRowNumber, "code").ToString());
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterCodeTypeNull":
                    msg = "コード類型を入力してくだたい。";
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterCodeTypeNameNull":
                    msg = "コード類型名称を入力してくだたい。";
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailCodeNull":
                    msg = "コードを入力してくだたい。";
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "SaveSuccess":
                    msg = "保存しました。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ServiceError":
                    msg = String.Format("処理中にエラーが発生しました。\n\nエラー内容：{0}", Service.ErrFullMsg);
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;
                    
                default:
                    break;
            }
        }

        #endregion

        #region [조회/입력/삭제/초기화 처리 코드]

        #region 조회/입력/삭제 버튼 처리
        private void blsButton_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
                case FunctionType.Query:
                    this.grdMaster.QueryLayout(false);
                    break;

				case FunctionType.Insert:

                    e.IsBaseCall = false;
                    if (this.CurrMQLayout == this.grdDetail)
                    {
                        if (this.grdMaster.RowCount > 0)
                        {
                            int rowNum = this.grdDetail.InsertRow(-1);
                            this.grdDetail.SetFocusToItem(rowNum, "code");
                        }
                    }
					break;

                case FunctionType.Delete:

                    if (this.CurrMQLayout != this.grdDetail)
                    {
                        e.IsBaseCall = false;
                        return;
                    }
                    break;
				
                case FunctionType.Update:
                    if (MasterGridNullCheck() || DetailGridNullCheck())
                    {
                        e.IsBaseCall = false;
                    }
                    break;

                default:
					break;
			}
        }
        #endregion

       
		#endregion


        #region [코드유형에 따른 마스터 그리드 설정 코드]

        /// <summary>
        /// 코드유형 콤보박스 아이템 선택 시, 해당하는 데이타를 마스터 그리드에 설정한다. 
        /// </summary>
        private void cboCdty_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.grdMaster.QueryLayout(false);
        }

        #endregion

        #region [마스터/디테일 그리드 바인드변수 설정 코드]

        #region 마스터 바인드변수 설정
        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", this.mHospCode);
        }
        #endregion

        #region 디테일 바인드변수 설정
        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdDetail.SetBindVarValue("f_code_type", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
        }
        #endregion

        #endregion

        #region [마스터/디테일 데이타 체크 코드]

        #region 마스터 그리드 필수입력컬럼 체크
        /// <summary>
        /// 마스터 그리드의 필수입력컬럼을 체크한다.
        /// </summary>
        /// <returns>
        /// true  : 누락컬럼 유
        /// false : 누락컬럼 무
        /// </returns>
        private bool MasterGridNullCheck()
        {
            for (int i = 0; i < grdMaster.LayoutTable.Rows.Count; i++)
            {
                if (grdMaster.LayoutTable.Rows[i].RowState == DataRowState.Added || grdMaster.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                {
                    if (TypeCheck.IsNull(grdMaster.GetItemValue(i, "code_type")))
                    {
                        grdMaster.SetFocusToItem(i, "code_type");
                        ShowMessage("MasterCodeTypeNull");
                        return true;
                    }
                    if (TypeCheck.IsNull(grdMaster.GetItemValue(i, "code_type_name")))
                    {
                        grdMaster.SetFocusToItem(i, "code_type_name");
                        ShowMessage("MasterCodeTypeNameNull");
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region 디테일 그리드 필수입력컬럼 체크
        /// <summary>
        /// 디테일 그리드의 필수입력컬럼을 체크한다.
        /// </summary>
        /// <returns>
        /// true  : 누락컬럼 유
        /// false : 누락컬럼 무
        /// </returns>
        private bool DetailGridNullCheck()
        {
            for (int i = 0; i < grdDetail.LayoutTable.Rows.Count; i++)
            {
                if (grdDetail.LayoutTable.Rows[i].RowState == DataRowState.Added || grdDetail.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                {
                    if (TypeCheck.IsNull(grdDetail.GetItemValue(i, "code")))
                    {
                        grdDetail.SetFocusToItem(i, "code");
                        ShowMessage("DetailCodeNull");
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region 마스터 데이타 중복 체크
        private void grdMaster_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            // 마스터 그리드의 Row 상태를 설정
            DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;

            // 입력버튼을 클릭을 했을 때
            if (rowState == DataRowState.Added)
            {
                // 입력된 Cell이 코드 유형 Cell일 경우에
                if (e.ColName == "code_type")
                {
                    // 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다.
                    string cmdText = string.Empty;
                    object retVal = null;
                    BindVarCollection bindVals = new BindVarCollection();

                    cmdText = @"SELECT 'Y'
                                  FROM DUAL
                                 WHERE EXISTS (SELECT 'X'
                                                 FROM NUR0102
                                                WHERE HOSP_CODE = :f_hosp_code 
                                                  AND CODE_TYPE = 'WATCH_TEMPLATE')";

                    bindVals.Add("f_hosp_code", this.mHospCode);
                    bindVals.Add("f_code_type", grdMaster.GetItemValue(e.RowNumber, "code_type").ToString());

                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    if (Service.ErrCode == 0)
                    {
                        if (retVal != null && retVal.ToString().Equals("Y"))
                        {
                            ShowMessage("MasterDup");
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region 디테일 데이타 중복 체크
        private void grdDetail_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            // 디테일 그리드의 Row 상태를 설정
            DataRowState rowState = this.grdDetail.LayoutTable.Rows[this.grdDetail.CurrentRowNumber].RowState;

            // 입력버튼을 클릭을 했을 때
            if (rowState == DataRowState.Added)
            {
                // 입력된 Cell이 코드 Cell일 경우에 
                if (e.ColName == "code")
                {
                    // 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다.
                    string cmdText = string.Empty;
                    object retVal = null;
                    BindVarCollection bindVals = new BindVarCollection();

                    cmdText = @"SELECT 'Y'
                                  FROM DUAL
                                 WHERE EXISTS (SELECT 'X'
                                                 FROM NUR1123
                                                WHERE HOSP_CODE = :f_hosp_code 
                                                  AND CODE_TYPE = :f_code_type
                                                  AND CODE      = :f_code)";

                    bindVals.Add("f_hosp_code", this.mHospCode);
                    bindVals.Add("f_code_type", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
                    bindVals.Add("f_code", grdDetail.GetItemValue(e.RowNumber, "code").ToString());

                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    if (Service.ErrCode == 0)
                    {
                        if (retVal != null && retVal.ToString().Equals("Y"))
                        {
                            ShowMessage("DetailDup");
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #region [데이타 저장 완료 메시지 설정 코드]

        private bool masterFlag = false;
        private bool detailFlag = false;

        /// <summary>
        /// 마스터/디테일 데이타 저장 완료 후, 메세지를 표시한다.
        /// </summary>
        private void grd_SaveEnd(object sender, SaveEndEventArgs e)
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
                    ShowMessage("SaveSuccess");

                    masterFlag = false;
                    detailFlag = false;
                }
            }
            else
            {
                ShowMessage("ServiceError");

                masterFlag = false;
                detailFlag = false;
            }
        }

		#endregion

        
        #region [XSavePerformer]

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR1123U00 parent = null;

            public XSavePerformer(NUR1123U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO NUR0102 (SYS_DATE, 
//                                                                 SYS_ID,
//                                                                 UPD_DATE,
//                                                                 UPD_ID, 
//                                                                 HOSP_CODE,
//                                                                 CODE_TYPE, 
//                                                                 CODE_TYPE_NAME)
//                                                        VALUES  (SYSDATE, 
//                                                                 :q_user_id, 
//                                                                 SYSDATE, 
//                                                                 :q_user_id,
//                                                                 :f_hosp_code,
//                                                                 :f_code_type, 
//                                                                 :f_code_type_name)";
//                                break;

//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE NUR0101
//                                               SET UPD_ID         = :q_user_id,
//                                                   UPD_DATE       = SYSDATE,
//                                                   CODE_TYPE      = :f_code_type,
//                                                   CODE_TYPE_NAME = :f_code_type_name
//                                             WHERE HOSP_CODE      = :f_hosp_code
//                                               AND CODE_TYPE      = :f_code_type";
//                                break;

//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE NUR0101
//                                             WHERE HOSP_CODE      = :f_hosp_code
//                                               AND CODE_TYPE = :f_code_type";
//                                break;
//                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO NUR1123 (SYS_DATE, 
                                                                 SYS_ID,
                                                                 UPD_DATE,
                                                                 UPD_ID, 
                                                                 HOSP_CODE,
                                                                 CODE_TYPE, 
                                                                 CODE, 
                                                                 CODE_NAME,
                                                                 SORT_KEY  )
                                                        VALUES  (SYSDATE, 
                                                                 :q_user_id, 
                                                                 SYSDATE, 
                                                                 :q_user_id,
                                                                 :f_hosp_code,
                                                                 :f_code_type, 
                                                                 :f_code, 
                                                                 :f_code_name,
                                                                 :f_sort_key   )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR1123
                                               SET UPD_ID    = :q_user_id,
                                                   UPD_DATE  = SYSDATE,
                                                   CODE_TYPE = :f_code_type,
                                                   CODE      = :f_code,
                                                   CODE_NAME = :f_code_name,
                                                   SORT_KEY  = :f_sort_key
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE_TYPE = :f_code_type
                                               AND CODE      = :f_code";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR1123
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE_TYPE = :f_code_type
                                               AND CODE      = :f_code";
                                break;
                        }
                        break;

                    default:
                        break;

                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        #endregion

        private void grdMaster_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) != DataRowState.Unchanged)
                {
                    if (XMessageBox.Show("変更されたデータがあります。保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        grdDetail.SaveLayout();
                    }
                }
            }
        }
    }
}

