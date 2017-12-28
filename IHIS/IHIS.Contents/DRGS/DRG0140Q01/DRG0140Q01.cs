#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using IHIS.Framework;
using IHIS.DRGS.Properties;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG0140Q01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG0140Q01 : IHIS.Framework.XScreen
    {
        private System.Windows.Forms.Panel pnlBottom;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private Panel panel1;
        private XLabel lbXrayRoom;
        private XLabel xLabel32;
        private XLabel xLabel2;
        private XLabel xLabel4;
        private XLabel xLabel3;
        private XLabel xLabel1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DRG0140Q01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.grdMaster.ExecuteQuery = LoadDataGrdMaster;
        }

        #region CloudService

        private List<object[]> LoadDataGrdMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            DRG0140U00GrdMasterArgs args = new DRG0140U00GrdMasterArgs();
            args.Code = "";
            DRG0140U00GrdMasterResult result =
                CloudService.Instance.Submit<DRG0140U00GrdMasterResult, DRG0140U00GrdMasterArgs>(
                    args);
            if (result != null)
            {
                foreach (ComboListItemInfo item in result.GrdMasterItem)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion


        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0140Q01));
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbXrayRoom = new IHIS.Framework.XLabel();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "선택.gif");
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 2;
            this.grdMaster.Cols = 3;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(27);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.ReadOnly = true;
            this.grdMaster.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            this.grdMaster.DoubleClick += new System.EventHandler(this.grdMaster_DoubleClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "code";
            this.xEditGridCell1.CellWidth = 90;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XGridSelectedCellBackColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_name";
            this.xEditGridCell2.CellWidth = 250;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XGridSelectedCellBackColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // pnlBottom
            // 
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Controls.Add(this.xLabel4);
            this.pnlBottom.Controls.Add(this.xLabel3);
            this.pnlBottom.Controls.Add(this.xLabel1);
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackColor = IHIS.Framework.XColor.XLabelBackColor;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F2, global::IHIS.DRGS.Properties.Resources.btnChoose, 0, "HotPink"),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lbXrayRoom);
            this.panel1.Controls.Add(this.xLabel32);
            this.panel1.Controls.Add(this.xLabel2);
            this.panel1.Name = "panel1";
            // 
            // lbXrayRoom
            // 
            resources.ApplyResources(this.lbXrayRoom, "lbXrayRoom");
            this.lbXrayRoom.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.lbXrayRoom.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbXrayRoom.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lbXrayRoom.Name = "lbXrayRoom";
            // 
            // xLabel32
            // 
            resources.ApplyResources(this.xLabel32, "xLabel32");
            this.xLabel32.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel32.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel32.EdgeRounding = false;
            this.xLabel32.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel32.Name = "xLabel32";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // DRG0140Q01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.grdMaster);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.panel1);
            this.Name = "DRG0140Q01";
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            grdMaster.QueryLayout(false);

            base.OnLoad(e);
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.CurrMQLayout = this.grdMaster;
                    break;

                case FunctionType.Process:
                    e.IsBaseCall = false;
                    IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

                    CommonItemCollection commandParams = new CommonItemCollection();
                    commandParams.Add("pre_small_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code"));
                    scrOpener.Command(this.ScreenID, commandParams);

                    this.Close();
                    break;

                default:
                    break;
            }
        }

        #region 각 그리드/레이아웃에 바인드변수 설정
        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        #region 그리드 더블 클릭 이벤트
        private void grdDetail_DoubleClick(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Process);
        }
        #endregion

        #region 그리드 더블 클릭시 선택
        private void grdMaster_DoubleClick(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Process);
        }
        #endregion


    }
}

