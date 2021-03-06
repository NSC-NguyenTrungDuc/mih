#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0113U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0113U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";
        // Save Process
        bool isgrdOCS0113Save = false;
        bool isSaved0113 = false;
        // 병원코드
        string mHospCode = EnvironInfo.HospCode;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XTextBox txtHangmog_name_inx;
        private IHIS.Framework.XLabel xLabel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView tvwSlip_Info;
        private IHIS.Framework.XPanel xPanel4;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XMstGrid grdOCS0103;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XLabel xLabel63;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGrid grdOCS0113;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell96;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.MultiLayout laySlip_Info;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private XEditGridCell xEditGridCell4;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0113U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // TODO comment use connect cloud
            /*SaveLayoutList.Add(grdOCS0113);
            grdOCS0113.SavePerformer = new XSavePerformer(this);*/

            // Create ParamList and ExecuteQuery
            grdOCS0103.ParamList = new List<string>(new String[] { "f_slip_code", "f_hangmog_name_inx" });
            grdOCS0103.ExecuteQuery = ExecuteQueryGrdOCS0103;

            grdOCS0113.ParamList = new List<string>(new String[] { "f_hangmog_code" });
            grdOCS0113.ExecuteQuery = ExecuteQueryGrdOCS0113;

            laySlip_Info.ExecuteQuery = ExecuteQueryLaySlipList;

        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0113U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtHangmog_name_inx = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdOCS0113 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0103 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xLabel63 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.tvwSlip_Info = new System.Windows.Forms.TreeView();
            this.laySlip_Info = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySlip_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.txtHangmog_name_inx);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // txtHangmog_name_inx
            // 
            resources.ApplyResources(this.txtHangmog_name_inx, "txtHangmog_name_inx");
            this.txtHangmog_name_inx.Name = "txtHangmog_name_inx";
            this.txtHangmog_name_inx.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHangmog_name_inx_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xPanel5);
            this.xPanel3.Controls.Add(this.splitter1);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.tvwSlip_Info);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdOCS0113);
            this.xPanel5.Controls.Add(this.xLabel63);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Name = "xPanel5";
            // 
            // grdOCS0113
            // 
            resources.ApplyResources(this.grdOCS0113, "grdOCS0113");
            this.grdOCS0113.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell4});
            this.grdOCS0113.ColPerLine = 4;
            this.grdOCS0113.Cols = 4;
            this.grdOCS0113.ExecuteQuery = null;
            this.grdOCS0113.FixedRows = 1;
            this.grdOCS0113.FocusColumnName = "specimen_code";
            this.grdOCS0113.HeaderHeights.Add(21);
            this.grdOCS0113.MasterLayout = this.grdOCS0103;
            this.grdOCS0113.Name = "grdOCS0113";
            this.grdOCS0113.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0113.ParamList")));
            this.grdOCS0113.Rows = 2;
            this.grdOCS0113.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0113_GridColumnChanged);
            this.grdOCS0113.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS0113_SaveEnd);
            this.grdOCS0113.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOCS0113_ItemValueChanging);
            this.grdOCS0113.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS0113_GridColumnProtectModify);
            this.grdOCS0113.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0113_QueryStarting);
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "hangmog_code";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "seq";
            this.xEditGridCell95.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell95.CellWidth = 40;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellLen = 1;
            this.xEditGridCell96.CellName = "default_yn";
            this.xEditGridCell96.CellWidth = 46;
            this.xEditGridCell96.Col = 1;
            this.xEditGridCell96.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.AutoTabDataSelected = true;
            this.xEditGridCell97.CellLen = 3;
            this.xEditGridCell97.CellName = "specimen_code";
            this.xEditGridCell97.CellWidth = 71;
            this.xEditGridCell97.Col = 2;
            this.xEditGridCell97.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell97.ExecuteQuery = null;
            this.xEditGridCell97.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsUpdatable = false;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellLen = 100;
            this.xEditGridCell98.CellName = "specimen_name";
            this.xEditGridCell98.CellWidth = 226;
            this.xEditGridCell98.Col = 3;
            this.xEditGridCell98.ExecuteQuery = null;
            this.xEditGridCell98.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "hangmog_start_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // grdOCS0103
            // 
            resources.ApplyResources(this.grdOCS0103, "grdOCS0103");
            this.grdOCS0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3});
            this.grdOCS0103.ColPerLine = 2;
            this.grdOCS0103.Cols = 2;
            this.grdOCS0103.ExecuteQuery = null;
            this.grdOCS0103.FixedRows = 1;
            this.grdOCS0103.HeaderHeights.Add(21);
            this.grdOCS0103.Name = "grdOCS0103";
            this.grdOCS0103.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0103.ParamList")));
            this.grdOCS0103.Rows = 2;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "slip_code";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.CellWidth = 89;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.CellWidth = 214;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xLabel63
            // 
            this.xLabel63.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel63, "xLabel63");
            this.xLabel63.EdgeRounding = false;
            this.xLabel63.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel63.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel63.Name = "xLabel63";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xLabel1);
            this.xPanel4.Controls.Add(this.grdOCS0103);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // tvwSlip_Info
            // 
            this.tvwSlip_Info.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tvwSlip_Info, "tvwSlip_Info");
            this.tvwSlip_Info.HideSelection = false;
            this.tvwSlip_Info.ImageList = this.ImageList;
            this.tvwSlip_Info.Name = "tvwSlip_Info";
            this.tvwSlip_Info.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSlip_Info_AfterSelect);
            // 
            // laySlip_Info
            // 
            this.laySlip_Info.ExecuteQuery = null;
            this.laySlip_Info.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.laySlip_Info.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySlip_Info.ParamList")));
            this.laySlip_Info.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySlip_Info_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "slip_gubun";
            this.multiLayoutItem1.IsNotNull = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "slip_gubun_name";
            this.multiLayoutItem2.IsNotNull = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "slip_code";
            this.multiLayoutItem3.IsNotNull = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "slip_name";
            this.multiLayoutItem4.IsNotNull = true;
            // 
            // OCS0113U00
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0113U00";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.laySlip_Info)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {

            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0103;
            this.CurrMQLayout = this.grdOCS0103;

            splitter1.BackColor = XColor.XPanelBorderColor.Color;

            //Set M/D Relation
            grdOCS0113.SetRelationKey("hangmog_code", "hangmog_code");

            //FindBox
            ((XFindBox)((XEditGridCell)grdOCS0113.CellInfos["specimen_code"]).CellEditor.Editor).FindWorker = GetFindWorker("specimen_code");

            laySlip_Info.QueryLayout(false);

            //Show TreeView 
            ShowSlip_Info();
        }
        #endregion

        #region [TreeView Slip Info]
        private void ShowSlip_Info()
        {
            tvwSlip_Info.Nodes.Clear();
            if (laySlip_Info.RowCount < 1) return;

            string slip_gubun = "";
            TreeNode node;

            foreach (DataRow row in laySlip_Info.LayoutTable.Rows)
            {
                if (slip_gubun != row["slip_gubun"].ToString())
                {
                    node = new TreeNode(row["slip_gubun_name"].ToString());
                    node.Tag = row["slip_gubun"].ToString();
                    tvwSlip_Info.Nodes.Add(node);
                    slip_gubun = row["slip_gubun"].ToString();
                }

                node = new TreeNode(row["slip_name"].ToString());
                node.Tag = row["slip_code"].ToString();
                tvwSlip_Info.Nodes[tvwSlip_Info.Nodes.Count - 1].Nodes.Add(node);
            }

            tvwSlip_Info.SelectedNode = tvwSlip_Info.Nodes[0].Nodes[0];
        }

        private void tvwSlip_Info_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                if (tvwSlip_Info.SelectedNode.Parent == null) return;

                string slip_code = tvwSlip_Info.SelectedNode.Tag.ToString();

                grdOCS0103.SetBindVarValue("f_slip_code", slip_code);
                grdOCS0103.SetBindVarValue("f_hangmog_name_inx", "");
                grdOCS0103.SetBindVarValue("f_hosp_code", mHospCode);
                grdOCS0103.QueryLayout(false);
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        #region [Load Code Name]

        /// <summary>
        /// 해당 코드에 대한 명을 가져옵니다.
        /// </summary>
        /// <param name="codeMode">코드구분</param>
        /// <param name="code">코드Value</param>
        /// <returns></returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";
            string cmdText = "";

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "specimen_code":

                    // TODO comment use connect cloud
                    /*cmdText = " SELECT SPECIMEN_NAME "
                        + "   FROM OCS0116 "
                        + "  WHERE SPECIMEN_CODE = :f_code";

                    IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
                    bindVars.Add("f_code", code);
                    object retVal = Service.ExecuteScalar(cmdText, bindVars);*/

                    // Connect to cloud
                    OCS0113U00GetCodeNameArgs vOCS0113U00GetCodeNameArgs = new OCS0113U00GetCodeNameArgs();
                    vOCS0113U00GetCodeNameArgs.Code = code;
                    OCS0113U00GetCodeNameResult result = CloudService.Instance.Submit<OCS0113U00GetCodeNameResult, OCS0113U00GetCodeNameArgs>(vOCS0113U00GetCodeNameArgs);
                    if (result == null || result.ExecutionStatus != ExecutionStatus.Success ||
                        result.SpecimenName == null)
                    {
                        mbxMsg = Resources.MSG001_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                    }
                    else
                        codeName = result.SpecimenName;
                    break;
                default:
                    break;
            }

            return codeName;
        }
        #endregion

        #region [GetFindWorker]
        private XFindWorker GetFindWorker(string findMode)
        {
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();

            switch (findMode)
            {
                case "specimen_code":
                    fdwCommon.AutoQuery = true;

                    // TODO comment use connect cloud
                    /*fdwCommon.InputSQL = " SELECT A.SPECIMEN_CODE, A.SPECIMEN_NAME "
                                       + "   FROM OCS0116 A "
                                       + "  WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE";*/

                    fdwCommon.ExecuteQuery = ExecuteQueryGetFindWorker;
                    fdwCommon.FormText = Resources.FDWCOMMON_FORMTEXT;
                    fdwCommon.ColInfos.Add("specimen_code", Resources.FDWCOMMON_SPECIMEN_CODE_TEXT, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("specimen_name", Resources.FDWCOMMON_SPECIMEN_NAME_TEXT, FindColType.String, 300, 0, true, FilterType.No);
                    break;
                default:
                    break;
            }

            return fdwCommon;
        }
        #endregion

        #region [Control]
        private void txtHangmog_name_inx_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                if (e.DataValue.Trim() == "") return;

                grdOCS0103.SetBindVarValue("f_slip_code", "");
                grdOCS0103.SetBindVarValue("f_hangmog_name_inx", JapanTextHelper.GetFullKatakana(e.DataValue.Trim(), true));
                grdOCS0103.SetBindVarValue("f_hosp_code", mHospCode);
                grdOCS0103.QueryLayout(false);
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        #region [grdOCS0113]
        private void grdOCS0113_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "seq":
                    if (e.ChangeValue.ToString().Trim() == "1")
                    {
                        mbxMsg = Resources.MSG002_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    break;
                case "specimen_code":
                    if (e.ChangeValue.ToString().Trim() == "") break;

                    //중복 Check
                    for (int i = 0; i < grdOCS0113.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0113.GetItemString(i, "specimen_code").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resources.MSG003_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    string specimen_name = GetCodeName("specimen_code", e.ChangeValue.ToString().Trim());

                    if (specimen_name == "")
                        e.Cancel = true;
                    else
                        grdOCS0113.SetItemValue(e.RowNumber, "specimen_name", specimen_name);
                    break;
                default:
                    break;
            }
        }

        private void grdOCS0113_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            //항목에서 등록하는 부분은 protect
            //if (e.DataRow["seq"].ToString() == "1")
            //    e.Protect = true;
            //else
            //    e.Protect = false;
        }

        private void grdOCS0113_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.ToString() == "Y")
            {
                for (int i = 0; i < grdOCS0113.RowCount; i++)
                {
                    if (i != e.RowNumber)
                        grdOCS0113.SetItemValue(i, "default_yn", "N");
                }
            }
        }

        private void grdOCS0113_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0113.SetBindVarValue("f_hangmog_code", grdOCS0103.GetItemString(grdOCS0103.CurrentRowNumber, "hangmog_code"));
            grdOCS0113.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOCS0113_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            isgrdOCS0113Save = e.IsSuccess;
            isSaved0113 = true;

            if (isSaved0113)
            {
                if (isgrdOCS0113Save)
                {
                    mbxMsg = Resources.MSG004_MSG;
                    SetMsg(mbxMsg);
                }
                else
                {
                    mbxMsg = Resources.MSG005_MSG;
                    mbxMsg = mbxMsg + e.ErrMsg;
                    mbxCap = "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }

                isgrdOCS0113Save = false;
                isSaved0113 = false;
            }
        }
        #endregion

        #region [Button List Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            SetMsg("");

            switch (e.Func)
            {
                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    if (this.CurrMSLayout != grdOCS0113 || grdOCS0103.CurrentRowNumber < 0)
                        return;

                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = grdOCS0113.InsertRow();
                        grdOCS0113.SetItemValue(currentRow, "hangmog_code", grdOCS0103.GetItemString(grdOCS0103.CurrentRowNumber, "hangmog_code"));
                        grdOCS0113.SetItemValue(currentRow, "hangmog_start_date", EnvironInfo.GetSysDate());
                        grdOCS0113.SetItemValue(currentRow, "seq", MaxOrd_danui_max());
                    }
                    else
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    break;
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    string hangmog_name_inx = txtHangmog_name_inx.GetDataValue().Trim();
                    if (hangmog_name_inx == "") return;

                    grdOCS0103.SetBindVarValue("f_slip_code", "");
                    grdOCS0103.SetBindVarValue("f_hangmog_name_inx", hangmog_name_inx);
                    grdOCS0103.SetBindVarValue("f_hosp_code", mHospCode);

                    grdOCS0103.QueryLayout(false);
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;

                    CancelEventArgs ca = new CancelEventArgs(true);

                    for (int rowIndex = 0; rowIndex < grdOCS0113.RowCount; rowIndex++)
                    {
                        if (grdOCS0113.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                        {
                            //Key값이 없으면 삭제처리
                            if (grdOCS0113.GetItemString(rowIndex, "specimen_code").Trim() == "")
                            {
                                grdOCS0113.DeleteRow(rowIndex);
                                rowIndex = rowIndex - 1;
                                continue;
                            }
                        }

                        if (grdOCS0113.GetItemString(rowIndex, "specimen_name").Trim() == "")
                        {
                            mbxMsg = Resources.MSG006_MSG;
                            mbxCap = "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            grdOCS0113.SetFocusToItem(rowIndex, "specimen_code");
                            return;
                        }

                        if (grdOCS0113.GetItemString(rowIndex, "seq").Trim() == "")
                        {
                            mbxMsg = Resources.MSG007_MSG;
                            mbxCap = "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            grdOCS0113.SetFocusToItem(rowIndex, "seq");
                            return;
                        }
                    }


//                    if (!grdOCS0113.SaveLayout()) XMessageBox.Show(Service.ErrFullMsg);
                    // SaveLayout
                    e.IsSuccess = GrdOCS0113SaveLayout();
                    isgrdOCS0113Save = e.IsSuccess;
                    isSaved0113 = true;

                    if (isSaved0113)
                    {
                        if (isgrdOCS0113Save)
                        {
                            mbxMsg = Resources.MSG004_MSG;
                            SetMsg(mbxMsg);
                            mbxCap = Resources.MSG001_CAP;
                            XMessageBox.Show(mbxMsg, mbxCap);
                        }
                        else
                        {
                            mbxMsg = Resources.MSG005_MSG;
//                            mbxMsg = mbxMsg + e.ErrMsg;
//                            mbxCap = "Save Error";
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Hand);
                        }

                        isgrdOCS0113Save = false;
                        isSaved0113 = false;
                    }

                    break;
                default:
                    break;
            }
        }

        private int MaxOrd_danui_max()
        {
            int returnValue = 0;

            for (int i = 0; i < grdOCS0113.RowCount; i++)
            {
                if (!TypeCheck.IsNull(grdOCS0113.GetItemString(i, "seq")))
                {
                    if (int.Parse(grdOCS0113.GetItemString(i, "seq")) > returnValue)
                        returnValue = int.Parse(grdOCS0113.GetItemString(i, "seq"));
                }
            }

            returnValue++;

            return returnValue;
        }
        #endregion

        #region [ laySlip SetBindVarValue ]
        private void laySlip_Info_QueryStarting(object sender, CancelEventArgs e)
        {
            laySlip_Info.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        #region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
        /// <summary>
        /// Insert한 Row 중에 Not Null필드 미입력 Row Search
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
        /// </remarks>
        /// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }
            }

            return celReturn;
        }
        #endregion


        #region Connect to cloud
        /// <summary>
        /// ExecuteQueryLaySlipListItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryLaySlipList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0113U00LaySlipInfoArgs vOCS0113U00LaySlipInfoArgs = new OCS0113U00LaySlipInfoArgs();
            OCS0113U00LaySlipInfoResult result = CloudService.Instance.Submit<OCS0113U00LaySlipInfoResult, OCS0113U00LaySlipInfoArgs>(vOCS0113U00LaySlipInfoArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0113U00LaySlipListItemInfo item in result.ListLaySlipInfo)
                {
                    object[] objects =
                    {
                        item.SlipGubun,
                        item.SlipGubunName,
                        item.SlipCode,
                        item.SlipName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOCS0113ListItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOCS0113(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0113U00GrdOCS0113Args vOCS0113U00GrdOCS0113Args = new OCS0113U00GrdOCS0113Args();
            vOCS0113U00GrdOCS0113Args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            OCS0113U00GrdOCS0113Result result = CloudService.Instance.Submit<OCS0113U00GrdOCS0113Result, OCS0113U00GrdOCS0113Args>(vOCS0113U00GrdOCS0113Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0113U00GrdOCS0113ListItemInfo item in result.ListGrd)
                {
                    object[] objects =
                    {
                        item.HangmogCode,
                        item.Seq,
                        item.DefaultYn,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.HangmogStatDate,
                        item.RowState
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> ExecuteQueryGrdOCS0103(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0113U00GrdOCS0103Args vOCS0113U00GrdOCS0103Args = new OCS0113U00GrdOCS0103Args();
            vOCS0113U00GrdOCS0103Args.SlipCode = bc["f_slip_code"] != null ? bc["f_slip_code"].VarValue : "";
            vOCS0113U00GrdOCS0103Args.HangmogNameInx = bc["f_hangmog_name_inx"] != null ? bc["f_hangmog_name_inx"].VarValue : "";
            OCS0113U00GrdOCS0103Result result = CloudService.Instance.Submit<OCS0113U00GrdOCS0103Result, OCS0113U00GrdOCS0103Args>(vOCS0113U00GrdOCS0103Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0113U00GrdOCS0103ListItemInfo item in result.ListGrd)
                {
                    object[] objects =
                    {
                        item.SlipCode,
                        item.HangmongCode,
                        item.HangmogName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGetFindWorker
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGetFindWorker(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0113U00GetFindWorkerArgs vOCS0113U00GetFindWorkerArgs = new OCS0113U00GetFindWorkerArgs();
            OCS0113U00GetFindWorkerResult result = CloudService.Instance.Submit<OCS0113U00GetFindWorkerResult, OCS0113U00GetFindWorkerArgs>(vOCS0113U00GetFindWorkerArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ListCombo)
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

        /// <summary>
        /// GrdOCS0113SaveLayout
        /// </summary>
        /// <returns></returns>
        private bool GrdOCS0113SaveLayout()
        {
            OCS0113U00TransactionalArgs args = new OCS0113U00TransactionalArgs();
            args.ListItem = CreateListGrdOCS0113Item();
            args.UserId = UserInfo.UserID;
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, OCS0113U00TransactionalArgs>(args);
            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CreateListGrdOCS0113Item
        /// </summary>
        /// <returns></returns>
        private List<OCS0113U00GrdOCS0113ListItemInfo> CreateListGrdOCS0113Item()
        {
            List<OCS0113U00GrdOCS0113ListItemInfo> listItemInfo = new List<OCS0113U00GrdOCS0113ListItemInfo>();
            for (int i = 0; i < grdOCS0113.RowCount; i++)
            {
                if (grdOCS0113.GetRowState(i) == DataRowState.Added ||
                    grdOCS0113.GetRowState(i) == DataRowState.Modified)
                {
                    OCS0113U00GrdOCS0113ListItemInfo itemInfo = new OCS0113U00GrdOCS0113ListItemInfo();
                    itemInfo.HangmogCode = grdOCS0113.GetItemString(i, "hangmog_code");
                    itemInfo.Seq = grdOCS0113.GetItemString(i, "seq");
                    itemInfo.DefaultYn = grdOCS0113.GetItemString(i, "default_yn");
                    itemInfo.SpecimenCode = grdOCS0113.GetItemString(i, "specimen_code");
                    itemInfo.SpecimenName = grdOCS0113.GetItemString(i, "specimen_name");
                    itemInfo.HangmogStatDate = grdOCS0113.GetItemString(i, "hangmog_start_date");
                    itemInfo.RowState = grdOCS0113.GetRowState(i).ToString();
 
                    listItemInfo.Add(itemInfo);
                }
            }

            if (grdOCS0113.DeletedRowTable != null && grdOCS0113.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0113.DeletedRowTable.Rows)
                {
                    OCS0113U00GrdOCS0113ListItemInfo itemInfo = new OCS0113U00GrdOCS0113ListItemInfo();
                    itemInfo.HangmogCode = row[ "hangmog_code"].ToString();
                    itemInfo.Seq = row[ "seq"].ToString();
                    itemInfo.DefaultYn = row[ "default_yn"].ToString();
                    itemInfo.SpecimenCode = row[ "specimen_code"].ToString();
                    itemInfo.SpecimenName = row[ "specimen_name"].ToString();
                    itemInfo.HangmogStatDate = row["hangmog_start_date"].ToString();
                    itemInfo.RowState = DataRowState.Deleted.ToString();

                    listItemInfo.Add(itemInfo);
                }
            }
            return listItemInfo;
        }
        #endregion


        #region [XSavePerformer Class]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0113U00 parent = null;

            public XSavePerformer(OCS0113U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = ""
                        + "	INSERT INTO OCS0113 "
                        + "		(SYS_DATE, SYS_ID, HANGMOG_CODE, SPECIMEN_CODE, SEQ, DEFAULT_YN, HOSP_CODE, HANGMOG_START_DATE) "
                        + "	VALUES "
                        + "		(SYSDATE, :f_user_id, :f_hangmog_code, :f_specimen_code, :f_seq, :f_default_yn, :f_hosp_code, :f_hangmog_start_date) ";
                        break;
                    case DataRowState.Modified:
                        cmdText = ""
                        + "	UPDATE OCS0113                          "
                        + "	   SET UPD_ID        = :f_user_id     , "
                        + "		   UPD_DATE      = SYSDATE        , "
                        + "		   SEQ           = :f_seq         , "
                        + "		   DEFAULT_YN    = :f_default_yn    "
                        + "	 WHERE HANGMOG_CODE  = :f_hangmog_code  "
                        + "	   AND SPECIMEN_CODE = :f_specimen_code "
                        + "    AND HOSP_CODE     = :f_hosp_code";
                        break;
                    case DataRowState.Deleted:
                        cmdText = "DELETE OCS0113 "
                                + "  WHERE HANGMOG_CODE  = :f_hangmog_code "
                                + "    AND SPECIMEN_CODE = :f_specimen_code"
                                + "    AND HOSP_CODE     = :f_hosp_code";

                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

    }
}

