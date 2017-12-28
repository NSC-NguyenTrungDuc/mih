#region 사용 NameSpace 지정
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Invs;
using IHIS.CloudConnector.Contracts.Results.Invs;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Models.Invs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.INVS.Properties;
#endregion

namespace IHIS.INVS
{
	/// <summary>
	/// INV0101U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INV0101U00 : IHIS.Framework.XScreen
    {
        #region [자동 생성 코드]
        
        #region 컨트롤 변수

        private IHIS.Framework.XEditGrid grdDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XComboBox cboCdty;
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
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XMstGrid grdMaster;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public INV0101U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            grdMaster.ParamList = new List<string>(new String[] { "f_code_type" });
            grdMaster.ExecuteQuery = LoadGrdMaster;
            grdDetail.ParamList = new List<string>(new String[] { "f_code_type" });
            grdDetail.ExecuteQuery = LoadGrdDetail;
            layComboItems.ExecuteQuery = LoadComboItem;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV0101U00));
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.cboCdty = new IHIS.Framework.XComboBox();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.lblCode_type = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.layComboItems = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layComboItems)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.ApplyPaintEventToAllColumn = true;
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell8});
            this.grdDetail.ColPerLine = 6;
            this.grdDetail.Cols = 7;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.FocusColumnName = "code";
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grd_SaveEnd);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
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
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
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
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sort_key";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.CellWidth = 47;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 15;
            this.xEditGridCell7.CellName = "code2";
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "code3";
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 100;
            this.xEditGridCell8.CellName = "remark";
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.DisplayMemoText = true;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 1;
            this.grdMaster.Cols = 2;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.FocusColumnName = "code_type";
            this.grdMaster.HeaderHeights.Add(19);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grd_SaveEnd);
            this.grdMaster.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdMaster_RowFocusChanging);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type_name";
            this.xEditGridCell1.CellWidth = 150;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
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
            this.xEditGridCell2.CellName = "code_type";
            this.xEditGridCell2.CellWidth = 397;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.blsButton_ButtonClick);
            // 
            // cboCdty
            // 
            this.cboCdty.AccessibleDescription = null;
            this.cboCdty.AccessibleName = null;
            resources.ApplyResources(this.cboCdty, "cboCdty");
            this.cboCdty.BackgroundImage = null;
            this.cboCdty.Name = "cboCdty";
            this.cboCdty.SelectedIndexChanged += new System.EventHandler(this.cboCdty_SelectedIndexChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.lblCode_type);
            this.pnlTop.Controls.Add(this.cboCdty);
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // lblCode_type
            // 
            this.lblCode_type.AccessibleDescription = null;
            this.lblCode_type.AccessibleName = null;
            resources.ApplyResources(this.lblCode_type, "lblCode_type");
            this.lblCode_type.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblCode_type.EdgeRounding = false;
            this.lblCode_type.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblCode_type.Image = null;
            this.lblCode_type.Name = "lblCode_type";
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // pnlLeft
            // 
            this.pnlLeft.AccessibleDescription = null;
            this.pnlLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.BackgroundImage = null;
            this.pnlLeft.Controls.Add(this.grdMaster);
            this.pnlLeft.Font = null;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.grdDetail);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // layComboItems
            // 
            this.layComboItems.ExecuteQuery = null;
            this.layComboItems.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboItems.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layComboItems.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code_type";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_type_name";
            // 
            // INV0101U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "INV0101U00";
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
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
        private string mMsg = "";
        private string mCap = "";
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
           // this.grdMaster.SavePerformer = new XSavePerformer(this);
            //this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            // 마스터-디테일 관계 설정
            //this.grdDetail.SetRelationKey("code_type", "code_type");
            //this.grdDetail.SetRelationTable("INV0102");

            this.CurrMSLayout = this.grdMaster;

            // 코드유형 콤보박스 설정
			this.ComboSetting();

            // 코드유형에 따른 마스터 그리드 설정
            this.grdMaster.QueryLayout(false);

            if (EnvironInfo.CurrSystemID == "DRGS")
			{
				this.cboCdty.Enabled = false;
				this.cboCdty.SetEditValue("SPECIALDRUG");
				this.cboCdty.AcceptData();
			}
            //this.grdMaster.SetFocusToItem(1, 0);
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
                    msg = Resources.MSG_001;
                    cpt = Resources.MSG_001_CAP;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);                    
                    break;

                case "DetailInsert":
                    msg = Resources.MSG_002;
                    cpt = Resources.MSG_002_CAP;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDeleteGrid":
                    msg = String.Format(Resources.MSG_003,grdMaster[grdMaster.CurrentRowNumber, "code_type"].Value.ToString());
                    cpt = Resources.MSG_XN;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDeleteDB":
                    msg = Resources.MSG_004;
                    cpt = Resources.MSG_XN;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDup":
                    msg = String.Format(Resources.MSG_005,
                                         grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
                    cpt = Resources.MSG_XN;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailDup":
                    msg = String.Format(Resources.MSG_006,
                                         grdDetail.GetItemValue(grdDetail.CurrentRowNumber, "code").ToString());
                    cpt = Resources.MSG_XN;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterCodeTypeNull":
                    msg = Resources.MSG_007;
                    cpt = Resources.MSG_XN;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterCodeTypeNameNull":
                    msg = Resources.MSG_008;
                    cpt = Resources.MSG_XN;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailCodeNull":
                    msg = Resources.MSG_007;
                    cpt = Resources.MSG_XN;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "SaveSuccess":
                    msg = Resources.MSG_009;
                    cpt = Resources.MSG_TB;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ServiceError":
                    msg = Resources.MSG_010;
                    cpt = Resources.MSG_ERROR;
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
                    e.IsBaseCall = false;
                    if (MasterGridNullCheck() || DetailGridNullCheck())
                    {
                        return;
                    }
                    try
                    {
                        if (SaveGrd())
                        {
                            this.mMsg = Resources.MSG_009;

                            this.mCap = Resources.MSG_XN;

                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grdMaster.QueryLayout(false);
                        }
                    }
                    catch
                    {
                        this.mMsg = Resources.MSG_ERROR;

                        this.mCap = Resources.MSG_TB;
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }

                    break;

                default:
					break;
			}
        }
        #endregion

        #region 초기화 버튼 클릭 후 처리
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Reset:
                    if (EnvironInfo.CurrSystemID == "DRGS")
                    {
                        this.cboCdty.Enabled = false;
                        this.cboCdty.SetEditValue("SPECIALDRUG");
                        this.cboCdty.AcceptData();
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion
        
		#endregion

        #region [코드유형 데이타 취득 및 설정 코드]
        
        /// <summary>
        /// 취득한 DB 데이타를 코드유형 콤보박스에 설정한다.
        /// </summary>
        public void ComboSetting()
        {
            this.layComboItems.SetBindVarValue("f_hosp_code", this.mHospCode);
            if (layComboItems.QueryLayout(true))
            {
                if (layComboItems.LayoutTable.Rows.Count > 0)
                {
                    this.cboCdty.SetComboItems(this.layComboItems.LayoutTable, "code_type_name", "code_type",XComboSetType.AppendAll);
                }
            }
        }

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
            //this.grdMaster.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdMaster.SetBindVarValue("f_code_type", cboCdty.GetDataValue());
        }
        #endregion

        #region 디테일 바인드변수 설정
        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdDetail.SetBindVarValue("f_hosp_code", this.mHospCode);
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
                    #region Comment by Cloud
                    // 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다.
//                    string cmdText = string.Empty;
//                    object retVal = null;
//                    BindVarCollection bindVals = new BindVarCollection();

//                    cmdText = @"SELECT 'Y'
//                                  FROM DUAL
//                                 WHERE EXISTS (SELECT 'X'
//                                                 FROM INV0101
//                                                WHERE HOSP_CODE = :f_hosp_code 
//                                                  AND CODE_TYPE = :f_code_type)";

//                    bindVals.Add("f_hosp_code", this.mHospCode);
//                    bindVals.Add("f_code_type", grdMaster.GetItemValue(e.RowNumber, "code_type").ToString());

//                    retVal = Service.ExecuteScalar(cmdText, bindVals);

//                    if (Service.ErrCode == 0)
//                    {
//                        if (retVal != null && retVal.ToString().Equals("Y"))
//                        {
//                            ShowMessage("MasterDup");
//                            e.Cancel = true;
//                        }
//                    }
                    #endregion
                    CheckDuplicateDataINV0101Args args = new CheckDuplicateDataINV0101Args();
                    args.Code = "";
                    args.CodeType = grdDetail.GetItemValue(e.RowNumber, "code").ToString();
                    CheckDuplicateDataINV0101Result result = CloudService.Instance.Submit<CheckDuplicateDataINV0101Result, CheckDuplicateDataINV0101Args>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.CheckMaster.Equals("Y"))
                    {
                        ShowMessage("DetailDup");
                        e.Cancel = true;
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
                #region Comment by Cloud
//                if (e.ColName == "code")
//                {
//                    // 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다.
//                    string cmdText = string.Empty;
//                    object retVal = null;
//                    BindVarCollection bindVals = new BindVarCollection();

//                    cmdText = @"SELECT 'Y'
//                                  FROM DUAL
//                                 WHERE EXISTS (SELECT 'X'
//                                                 FROM INV0102
//                                                WHERE HOSP_CODE = :f_hosp_code 
//                                                  AND CODE_TYPE = :f_code_type
//                                                  AND CODE      = :f_code)";

//                    bindVals.Add("f_hosp_code", this.mHospCode);
//                    bindVals.Add("f_code_type", grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString());
//                    bindVals.Add("f_code", grdDetail.GetItemValue(e.RowNumber, "code").ToString());

//                    retVal = Service.ExecuteScalar(cmdText, bindVals);

//                    if (Service.ErrCode == 0)
//                    {
//                        if (retVal != null && retVal.ToString().Equals("Y"))
//                        {
//                            ShowMessage("DetailDup");
//                            e.Cancel = true;
//                        }
//                    }
//                } 
                #endregion
                 CheckDuplicateDataINV0101Args args = new CheckDuplicateDataINV0101Args();
                    args.Code = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type").ToString();
                    args.CodeType = grdDetail.GetItemValue(e.RowNumber, "code").ToString();
                    CheckDuplicateDataINV0101Result result = CloudService.Instance.Submit<CheckDuplicateDataINV0101Result, CheckDuplicateDataINV0101Args>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.CheckDetail.Equals("Y"))
                    {
                        ShowMessage("DetailDup");
                        e.Cancel = true;
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
                    this.ComboSetting();

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

        
//        #region [XSavePerformer]

//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private INV0101U00 parent = null;

//            public XSavePerformer(INV0101U00 parent)
//            {
//                this.parent = parent;
//            }
//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

//                switch (callerID)
//                {
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO INV0101 (SYS_DATE, 
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
//                                cmdText = @"UPDATE INV0101
//                                               SET UPD_ID         = :q_user_id,
//                                                   UPD_DATE       = SYSDATE,
//                                                   CODE_TYPE      = :f_code_type,
//                                                   CODE_TYPE_NAME = :f_code_type_name
//                                             WHERE HOSP_CODE      = :f_hosp_code
//                                               AND CODE_TYPE      = :f_code_type";
//                                break;

//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE INV0101
//                                             WHERE HOSP_CODE      = :f_hosp_code
//                                               AND CODE_TYPE = :f_code_type";
//                                break;
//                        }
//                        break;

//                    case '2':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO INV0102 (SYS_DATE, 
//                                                                 SYS_ID,
//                                                                 UPD_DATE,
//                                                                 UPD_ID, 
//                                                                 HOSP_CODE,
//                                                                 CODE_TYPE, 
//                                                                 CODE, 
//                                                                 CODE_NAME,
//                                                                 SORT_KEY)
//                                                        VALUES  (SYSDATE, 
//                                                                 :q_user_id, 
//                                                                 SYSDATE, 
//                                                                 :q_user_id,
//                                                                 :f_hosp_code,
//                                                                 :f_code_type, 
//                                                                 :f_code, 
//                                                                 :f_code_name,
//                                                                 :f_sort_key)";
//                                break;

//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE INV0102
//                                               SET UPD_ID    = :q_user_id,
//                                                   UPD_DATE  = SYSDATE,
//                                                   CODE_TYPE = :f_code_type,
//                                                   CODE      = :f_code,
//                                                   CODE_NAME = :f_code_name,
//                                                   SORT_KEY  = :f_sort_key
//                                             WHERE HOSP_CODE = :f_hosp_code
//                                               AND CODE_TYPE = :f_code_type
//                                               AND CODE      = :f_code";
//                                break;

//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE INV0102
//                                             WHERE HOSP_CODE = :f_hosp_code
//                                               AND CODE_TYPE = :f_code_type
//                                               AND CODE      = :f_code";
//                                break;
//                        }
//                        break;

//                    default:
//                        break;

//                }
//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }

//        #endregion

        private void grdMaster_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) != DataRowState.Unchanged)
                {
                    if (XMessageBox.Show(Resources.MSG_011, Resources.MSG_XN, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        grdDetail.SaveLayout();
                    }
                }
            }
        }

        #region Add by Cloud
   
        /// <summary>
        ///     Load Grid Master
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> LoadGrdMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            LoadGrdMasterINV0101Args args = new LoadGrdMasterINV0101Args();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            LoadGrdMasterINV0101Result result = CloudService.Instance.Submit<LoadGrdMasterINV0101Result, LoadGrdMasterINV0101Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (LoadGrdMasterINV0101Info item in result.ListMaster)
                {
                    object[] objects =
	                {
	                    item.CodeType,
                        item.CodeName
	                };
                    res.Add(objects);
                }
            }
            return res;
        }
        /// <summary>
        ///     Load Grid Detail -- LoadGrdDetail
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> LoadGrdDetail(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            LoadGrdDetailINV0101Args args = new LoadGrdDetailINV0101Args();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            LoadGrdDetailINV0101Result result = CloudService.Instance.Submit<LoadGrdDetailINV0101Result, LoadGrdDetailINV0101Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (LoadGrdDetailINV0101Info item in result.ListDetail)
                {
                    object[] objects =
	                {
                        item.CodeType,
                        item.Code,
                        item.CodeName,
                        item.SortKey,
                        item.Code2,
                        item.Code3,
                        item.Remark
	                };
                    res.Add(objects);
                }
            }
            return res;
        }
        /// <summary>
        ///     Load Combo -- LoadComboItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> LoadComboItem(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            LoadComboINV0101Args args = new LoadComboINV0101Args();
            ComboResult result = CloudService.Instance.Submit<ComboResult, LoadComboINV0101Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    res.Add(new object[] { item.Code, item.CodeName });
                }
            }
            return res;
        }
        /// <summary>
        ///     Check Duplicate
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private bool SaveGrd()
        {
            List<LoadGrdDetailINV0101Info> inputDetailList = GetListFromGrdDetail();
            if (inputDetailList.Count == 0)
            {
                return true;
            }
            //List<LoadGrdDetailINV0101Info> inputMasterList = GetListFromGrdMaster();
            //if (inputMasterList.Count == 0)
            //{
            //    return true;
            //}
            SaveLayoutINV0101Args args = new SaveLayoutINV0101Args();
            args.ListDetail = inputDetailList;
            args.ListMaster = new List<LoadGrdMasterINV0101Info>();
            args.UserId = UserInfo.UserID;

            UpdateResult result = CloudService.Instance.Submit<UpdateResult, SaveLayoutINV0101Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.Result == false)
                {

                    XMessageBox.Show(Resources.MSG_ERROR, Resources.MSG_TB, MessageBoxIcon.Warning);
                    
                }
                return result.Result;

            }

            return false;

        }
        private List<LoadGrdDetailINV0101Info> GetListFromGrdDetail()
        {
            List<LoadGrdDetailINV0101Info> dataList = new List<LoadGrdDetailINV0101Info>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                LoadGrdDetailINV0101Info info = new LoadGrdDetailINV0101Info();
                info.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                info.Code = grdDetail.GetItemString(i, "code");
                info.CodeName = grdDetail.GetItemString(i, "code_name");                
                info.SortKey = grdDetail.GetItemString(i, "sort_key");
                info.Code2 = grdDetail.GetItemString(i, "code2");
                info.Code3 = grdDetail.GetItemString(i, "code3");
                info.Remark = grdDetail.GetItemString(i, "remark");
                info.RowState = grdDetail.GetRowState(i).ToString(); 
                if (info.Code != "" && info.CodeName != "")
                {
                    dataList.Add(info);
                    
                }             
                
            }

            if (grdDetail.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
                {
                    LoadGrdDetailINV0101Info info = new LoadGrdDetailINV0101Info();
                    info.Code = row["code"].ToString();
                    info.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }      
        

        #endregion

    }
}
