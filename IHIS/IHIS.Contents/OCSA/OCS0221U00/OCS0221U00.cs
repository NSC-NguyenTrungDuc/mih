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
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0221U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0221U00 : IHIS.Framework.XScreen
    {
        bool isOCS0221Save = false;
        bool isOCS0222Save = false;
        bool isSaved0221 = false;
        bool isSaved0222 = false;

        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";
        //사용자
        string mMemb;
        //hospital code
        //string mHospCode = EnvironInfo.HospCode;
        string mHospCode = UserInfo.HospCode;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XMstGrid grdOCS0221;
        private IHIS.Framework.XEditGrid grdOCS0222;
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
        private XHospBox xHospBox;
        private int TheFlag;
        private int TheFlag1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0221U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            SaveLayoutList.Add(grdOCS0221);
            SaveLayoutList.Add(grdOCS0222);

            //			grdOCS0221.SavePerformer = new XSavePerformer(this);
            //			grdOCS0222.SavePerformer = grdOCS0221.SavePerformer;

            grdOCS0221.ParamList = CreateGrdOCS0221ParamList();
            grdOCS0221.ExecuteQuery = LoadGrdOCS0221;
            grdOCS0222.ParamList = CreateGrdOCS0222ParamList();
            grdOCS0222.ExecuteQuery = LoadGrdOCS0222;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0221U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOCS0221 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOCS0222 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xHospBox = new IHIS.Framework.XHospBox();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0221)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0222)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdOCS0221);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOCS0221
            // 
            resources.ApplyResources(this.grdOCS0221, "grdOCS0221");
            this.grdOCS0221.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdOCS0221.ColPerLine = 1;
            this.grdOCS0221.Cols = 2;
            this.grdOCS0221.ExecuteQuery = null;
            this.grdOCS0221.FixedCols = 1;
            this.grdOCS0221.FixedRows = 1;
            this.grdOCS0221.FocusColumnName = "category_name";
            this.grdOCS0221.HeaderHeights.Add(21);
            this.grdOCS0221.Name = "grdOCS0221";
            this.grdOCS0221.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0221.ParamList")));
            this.grdOCS0221.QuerySQL = resources.GetString("grdOCS0221.QuerySQL");
            this.grdOCS0221.RowHeaderVisible = true;
            this.grdOCS0221.Rows = 2;
            this.grdOCS0221.ToolTipActive = true;
            this.grdOCS0221.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0221_PreSaveLayout);
            this.grdOCS0221.CheckDetailLayout += new System.ComponentModel.CancelEventHandler(this.grdOCS0221_CheckDetailLayout);
            this.grdOCS0221.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0221.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdOCS0221_RowFocusChanging);
            this.grdOCS0221.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS0221_GridColumnProtectModify);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "memb";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "seq";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellLen = 2;
            this.xEditGridCell3.CellName = "category_gubun";
            this.xEditGridCell3.CellWidth = 86;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "category_name";
            this.xEditGridCell4.CellWidth = 293;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "comment_limit";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.InitValue = "200";
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdOCS0222);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdOCS0222
            // 
            resources.ApplyResources(this.grdOCS0222, "grdOCS0222");
            this.grdOCS0222.CallerID = '2';
            this.grdOCS0222.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11});
            this.grdOCS0222.ColPerLine = 2;
            this.grdOCS0222.Cols = 3;
            this.grdOCS0222.ExecuteQuery = null;
            this.grdOCS0222.FixedCols = 1;
            this.grdOCS0222.FixedRows = 1;
            this.grdOCS0222.FocusColumnName = "comment_title";
            this.grdOCS0222.HeaderHeights.Add(21);
            this.grdOCS0222.MasterLayout = this.grdOCS0221;
            this.grdOCS0222.Name = "grdOCS0222";
            this.grdOCS0222.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0222.ParamList")));
            this.grdOCS0222.QuerySQL = resources.GetString("grdOCS0222.QuerySQL");
            this.grdOCS0222.RowHeaderVisible = true;
            this.grdOCS0222.Rows = 2;
            this.grdOCS0222.ToolTipActive = true;
            this.grdOCS0222.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0222_PreSaveLayout);
            this.grdOCS0222.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0222.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0222_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "memb";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "seq";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "serial";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.CellLen = 100;
            this.xEditGridCell9.CellName = "comment_title";
            this.xEditGridCell9.CellWidth = 161;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell9.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.CellLen = 4000;
            this.xEditGridCell10.CellName = "comment_text";
            this.xEditGridCell10.CellWidth = 384;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.DisplayMemoText = true;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell10.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "dummy";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xHospBox
            // 
            this.xHospBox.AccessibleDescription = null;
            this.xHospBox.AccessibleName = null;
            resources.ApplyResources(this.xHospBox, "xHospBox");
            this.xHospBox.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox.BackgroundImage = null;
            this.xHospBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHospBox.HospCode = global::IHIS.OCSA.Properties.Resource.OCS0221U00_SaveError;
            this.xHospBox.Name = "xHospBox";
            this.xHospBox.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox_DataValidating);
            this.xHospBox.FindClick += new System.EventHandler(this.xHospBox_FindClick);
            // 
            // OCS0221U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xHospBox);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0221U00";
            this.Load += new System.EventHandler(this.OCS0221U00_Load);
            this.UserChanged += new System.EventHandler(this.OCS0221U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0221U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0221)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0222)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        #region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "F")
                return base.Command(command, commandParam);

            mMemb = commandParam["memb"].ToString();

            return base.Command(command, commandParam);
        }
        #endregion

        private void OCS0221U00_Load(object sender, System.EventArgs e)
        {
            // 2015.06.23 Cloud updated START
            //this.mHospCode = "K01"; // test data
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox.Visible = true;
                xButtonList1.SetEnabled(FunctionType.Insert, false);
                xButtonList1.SetEnabled(FunctionType.Update, false);
                xButtonList1.SetEnabled(FunctionType.Delete, false);
            }
            else
            {
                xHospBox.Visible = false;
                //xPanel2.Dock = DockStyle.Fill;
                //grdOCS0221.Dock = DockStyle.Fill;
                //xPanel3.Dock = DockStyle.Fill;
                //grdOCS0222.Dock = DockStyle.Fill;
            }
            // 2015.06.23 Cloud updated END

            //Set M/D Relation
            grdOCS0222.SetRelationKey("memb", "memb");
            grdOCS0222.SetRelationKey("seq", "seq");

            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0221;
            this.CurrMQLayout = this.grdOCS0221;

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            this.OCS0221U00_UserChanged(this, new System.EventArgs());
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////		
        }

        private void OCS0221U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
        }

        /// <summary>
        /// 사용자 변경시
        /// </summary>
        /// <remarks>
        /// 사용자별 상용어를 제조회한다.
        /// </remarks>
        private void OCS0221U00_UserChanged(object sender, System.EventArgs e)
        {
            //사용자 그룹이 ADMIN인 경우에는 병원공통 상용어를 관리하도록 한다.
            if (UserInfo.UserGroup == "ADMIN" || UserInfo.UserGroup == "SAM")
                mMemb = "ADMIN";
            else
                mMemb = UserInfo.UserID.ToString();

            grdOCS0221.SetBindVarValue("f_memb", mMemb);
            grdOCS0221.SetBindVarValue("f_hosp_code", mHospCode);
            grdOCS0221.QueryLayout(false);
        }

        #endregion

        #region [Combo 생성]
        private void CreateCombo()
        {
            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

            //SLIP_GUBUN DataLayout;
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("category_gubun", DataType.String);
            layoutCombo.LayoutItems.Add("category_name", DataType.String);
            layoutCombo.InitializeLayoutTable();

            layoutCombo.QuerySQL = ""
            + " SELECT CODE, CODE_NAME "
            + "   FROM OCS0132 "
            + "  WHERE CODE_TYPE = 'CATEGORY_GUBUN' "
            + "  ORDER BY 1 ";

            if (layoutCombo.QueryLayout(false))
            {
                grdOCS0221.SetComboItems("category_gubun", layoutCombo.LayoutTable, "category_name", "category_gubun");
            }
        }
        #endregion

        #region [OCS0221 Key값을 가져온다.]
        private int GetOCS0221_key()
        {
            /*string cmdText = "SELECT OCS0221_SEQ.NEXTVAL FROM DUAL " ;
                        					
                                    object retSeq = Service.ExecuteScalar(cmdText);
                                            
                                    if(retSeq == null)
                                    {
                                        mbxMsg = NetInfo.Language == LangMode.Jr ?  "データエラー発生の恐れがあります。": Resource.OCS0221U00_text1;
                                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                                        XMessageBox.Show(mbxMsg, mbxCap);						
                                    }
                                    else
                                    {
                                        return int.Parse(retSeq.ToString());
                                    }*/

            OcsaOCS0221U00SeqArgs args = new OcsaOCS0221U00SeqArgs();
            OcsaOCS0221U00SeqResult result = CloudService.Instance.Submit<OcsaOCS0221U00SeqResult, OcsaOCS0221U00SeqArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success && result.SeqNextval != "")
            {
                return int.Parse(result.SeqNextval);
            }
            else
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "データエラー発生の恐れがあります。" : Resource.OCS0221U00_text1;
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap);
            }

            return 0;
        }
        #endregion

        #region [Button List Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    int currentRow = -1;
                    int insertRow = -1;

                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

                    if (chkCell.RowNumber < 0)
                    {
                        if (this.CurrMSLayout == grdOCS0221)
                        {
                            //병원공통인 경우에는 Category를 기준정보에서 관리하도록 한다.
                            if (mMemb == "ADMIN")
                                break;

                            e.IsBaseCall = false;

                            int seq = this.GetOCS0221_key();
                            if (seq != 0)
                            {
                                insertRow = grdOCS0221.InsertRow(-1);
                                grdOCS0221.SetItemValue(insertRow, "memb", mMemb);
                                grdOCS0221.SetItemValue(insertRow, "seq", seq);
                                //사용자 상용어
                                grdOCS0221.SetItemValue(insertRow, "category_gubun", "99");
                                grdOCS0221.SetFocusToItem(insertRow, "category_name");
                            }
                            else
                                break;
                        }
                        else
                        {
                            currentRow = grdOCS0221.CurrentRowNumber;
                            if (currentRow >= 0)
                            {
                                insertRow = grdOCS0222.InsertRow(-1);
                                grdOCS0222.SetItemValue(insertRow, "memb", mMemb);
                                grdOCS0222.SetItemValue(insertRow, "seq", grdOCS0221.GetItemInt(currentRow, "seq"));
                            }
                        }
                    }
                    else
                    {
                        e.IsBaseCall = false;
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    }

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    OcsaOCS0221U00SaveLayoutArgs args = new OcsaOCS0221U00SaveLayoutArgs();
                    args.Ocs0221SaveItem = GetOcs0221ListDataForSaveLayout();
                    args.Ocs0222SaveItem = GetOcs0222ListDataForSaveLayout();
                    args.UserId = UserInfo.UserID;
                    args.HospCode = this.mHospCode;
                    if (args.Ocs0221SaveItem.Count == 0 && args.Ocs0222SaveItem.Count == 0)
                    {
                        XMessageBox.Show(Resource.OCS0221U00_Error1, Resource.OCS0221U00_SaveError1);
                        break;
                    }

                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, OcsaOCS0221U00SaveLayoutArgs>(args);

                    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result)
                    {
                        XMessageBox.Show(Resource.OCS0221U00_save, Resource.OCS0221U00_SaveEnd, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        grdOCS0221.QueryLayout(false);
                        grdOCS0222.QueryLayout(false);
                    }
                    else
                    {
                        XMessageBox.Show(Resource.OCS0221U00_save, Resource.OCS0221U00_SaveEnd, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;

                case FunctionType.Delete:

                    if (this.CurrMSLayout == grdOCS0221)
                    {
                        if (grdOCS0221.GetItemString(grdOCS0221.CurrentRowNumber, "category_gubun") != "99")
                            e.IsBaseCall = false;
                    }

                    break;

                default:
                    break;
            }
        }

        private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [grdOCS0221]
        private void grdOCS0221_CheckDetailLayout(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckDetailData(sender))
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void grdOCS0221_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.DataRow["category_gubun"].ToString() == "99")
                e.Protect = false;
            else
                e.Protect = true;
        }
        /// <summary>
        /// Detail Data 존재여부를 check합니다.
        /// </summary>
        private bool CheckDetailData(object aGrd)
        {
            bool returnValue = false;

            if (aGrd == null)
                return returnValue;

            XMstGrid mstGrid = null;

            try
            {
                mstGrid = (XMstGrid)aGrd;
            }
            catch
            {
                return returnValue;
            }

            int chk = 0;

            try
            {
                foreach (object obj in this.Controls)
                {
                    if (obj.GetType().Name.ToString().IndexOf("Panel") >= 0)
                    {
                        foreach (object panObj in ((Panel)obj).Controls)
                        {
                            if (panObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)panObj).MasterLayout == mstGrid)
                            {
                                chk = chk + ((XGrid)panObj).RowCount;
                            }
                            else
                                if (panObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)panObj).MasterLayout == mstGrid)
                                {
                                    foreach (DataRow row in ((XEditGrid)panObj).LayoutTable.Rows)
                                        if (row.RowState != DataRowState.Added)
                                            chk = chk + 1;

                                    chk = chk + ((XEditGrid)panObj).DeletedRowCount;
                                }
                                else
                                    if (panObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)panObj).MasterLayout == mstGrid)
                                    {
                                        foreach (DataRow row in ((XMstGrid)panObj).LayoutTable.Rows)
                                            if (row.RowState != DataRowState.Added)
                                                chk = chk + 1;

                                        chk = chk + ((XMstGrid)panObj).DeletedRowCount;
                                    }
                        }
                    }
                    else
                        if (obj.GetType().Name.ToString().IndexOf("GroupBox") >= 0)
                        {
                            foreach (object gbxObj in ((GroupBox)obj).Controls)
                            {
                                if (gbxObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)gbxObj).MasterLayout == mstGrid)
                                {
                                    chk = chk + ((XGrid)gbxObj).RowCount;
                                }
                                else
                                    if (gbxObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)gbxObj).MasterLayout == mstGrid)
                                    {
                                        foreach (DataRow row in ((XEditGrid)gbxObj).LayoutTable.Rows)
                                            if (row.RowState != DataRowState.Added)
                                                chk = chk + 1;

                                        chk = chk + ((XEditGrid)gbxObj).DeletedRowCount;
                                    }
                                    else
                                        if (gbxObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)gbxObj).MasterLayout == mstGrid)
                                        {
                                            foreach (DataRow row in ((XMstGrid)gbxObj).LayoutTable.Rows)
                                                if (row.RowState != DataRowState.Added)
                                                    chk = chk + 1;

                                            chk = chk + ((XMstGrid)gbxObj).DeletedRowCount;
                                        }
                            }
                        }
                        else
                            if (obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
                            {
                                chk = chk + ((XGrid)obj).RowCount;
                            }
                            else
                                if (obj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)obj).MasterLayout == mstGrid)
                                {
                                    foreach (DataRow row in ((XEditGrid)obj).LayoutTable.Rows)
                                        if (row.RowState != DataRowState.Added)
                                            chk = chk + 1;

                                    chk = chk + ((XEditGrid)obj).DeletedRowCount;
                                }
                                else
                                    if (obj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)obj).MasterLayout == mstGrid)
                                    {
                                        foreach (DataRow row in ((XMstGrid)obj).LayoutTable.Rows)
                                            if (row.RowState != DataRowState.Added)
                                                chk = chk + 1;

                                        chk = chk + ((XMstGrid)obj).DeletedRowCount;
                                    }
                }
            }
            catch
            {
            }

            if (chk > 0)
                returnValue = true;

            return returnValue;
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
        /// <returns> celReturn.RowNumber <0 미입력데이타="미입력데이타"없음="없음"></0>
        /// </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null)
                return celReturn;

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

        #region [SaveStart / End]
        private void grdOCS0222_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0222.SetBindVarValue("f_memb", grdOCS0221.GetItemString(grdOCS0221.CurrentRowNumber, "memb"));
            grdOCS0222.SetBindVarValue("f_seq", grdOCS0221.GetItemString(grdOCS0221.CurrentRowNumber, "seq"));
            grdOCS0222.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOCS0221_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            CancelEventArgs ce = new CancelEventArgs(true);

            bool chkVaildation = false;

            //grdOCS0221
            for (int rowIndex = 0; rowIndex < grdOCS0221.RowCount; rowIndex++)
            {
                if (grdOCS0221.GetItemString(rowIndex, "category_gubun").Trim() == "")
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "常用句区分に間違いがあります。 ご確認ください。" : Resource.OCS0221U00_text2;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0221.SetFocusToItem(rowIndex, "category_gubun");
                    chkVaildation = true;
                    break;
                }

                if (grdOCS0221.GetItemString(rowIndex, "category_name").Trim() == "")
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "常用句区分名に間違いがあります。 ご確認ください。" : Resource.OCS0221U00_text3;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0221.SetFocusToItem(rowIndex, "category_name");
                    chkVaildation = true;
                    break;
                }
            }

            if (chkVaildation)
            {
                ce.Cancel = true;
                return;
            }
        }

        private void grdOCS0222_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            CancelEventArgs ce = new CancelEventArgs(true);

            bool chkVaildation = false;
            //grdOCS0222
            for (int rowIndex = 0; rowIndex < grdOCS0222.RowCount; rowIndex++)
            {
                if (grdOCS0222.GetItemString(rowIndex, "comment_title").Trim() == "")
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "常用句名に間違いがあります。 ご確認ください。" : Resource.OCS0221U00_text4;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0222.SetFocusToItem(rowIndex, "comment_title");
                    chkVaildation = true;
                    break;
                }

                if (grdOCS0222.GetItemString(rowIndex, "comment_text").Trim() == "")
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "常用句に間違いがあります。 ご確認ください。" : Resource.OCS0221U00_text5;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0222.SetFocusToItem(rowIndex, "comment_text");
                    chkVaildation = true;
                    break;
                }

                if (chkVaildation)
                    ce.Cancel = true;
            }
        }

        private void SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            switch (e.CallerID)
            {
                case '1':
                    isOCS0221Save = e.IsSuccess;
                    isSaved0221 = true;
                    break;
                case '2':
                    isOCS0222Save = e.IsSuccess;
                    isSaved0222 = true;
                    break;
            }

            if (isSaved0221 && isSaved0222)
            {
                if (isOCS0221Save && isOCS0222Save)
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : Resource.OCS0221U00_save;
                    SetMsg(mbxMsg);
                    XMessageBox.Show(mbxMsg, Resource.OCS0221U00_SaveEnd); //추가
                    grdOCS0222.QueryLayout(false);
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : Resource.OCS0221U00_SaveError;
                    mbxMsg = mbxMsg + e.ErrMsg;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }

                isOCS0221Save = false;
                isOCS0222Save = false;
                isSaved0221 = false;
                isSaved0222 = false;
            }
        }

        #endregion

        #region [XSavePerformer Class]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0221U00 parent = null;

            public XSavePerformer(OCS0221U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                //UPD_ID,UPD_DATE 추가
                                cmdText = @"INSERT INTO OCS0221
                                             ( SYS_DATE
                                             , SYS_ID
                                             , MEMB
                                             , MEMB_GUBUN
                                             , SEQ
                                             , CATEGORY_GUBUN
                                             , CATEGORY_NAME
                                             , COMMENT_LIMIT
                                             , HOSP_CODE
                                             , UPD_ID
                                             , UPD_DATE)
                                         VALUES
                                             ( SYSDATE
                                             , :f_user_id
                                             , :f_memb
                                             , NVL(:f_memb_gubun, '1')
                                             , :f_seq 
                                             , :f_category_gubun
                                             , :f_category_name 
                                             , 0
                                             , :f_hosp_code
                                             , :f_user_id
                                             , SYSDATE)";
                                break;
                            case DataRowState.Modified:
                                //UPD_ID 추가
                                cmdText = @"BEGIN
                                          UPDATE OCS0221
                                             SET UPD_ID        = :f_user_id,
                                                 UPD_DATE      = SYSDATE,
                                                 CATEGORY_NAME = :f_category_name
                                           WHERE MEMB          = :f_memb
                                             AND MEMB_GUBUN    = '1'
                                             AND SEQ           = :f_seq
                                             AND HOSP_CODE     = :f_hosp_code;
                                               
                                          IF SQL%NOTFOUND THEN
                                          INSERT INTO OCS0221
                                               ( SYS_DATE, SYS_ID ,          UPD_DATE ,       MEMB,          MEMB_GUBUN ,
                                                 SEQ,      CATEGORY_GUBUN,   CATEGORY_NAME,   COMMENT_LIMIT, HOSP_CODE, UPD_ID )
                                          VALUES
                                               ( SYSDATE, :f_user_id,        SYSDATE,         :f_memb,      NVL(:f_memb_gubun, 1) ,
                                                 :f_seq , :f_category_gubun, 'CATEGORY_NAME' , 0 ,          :f_hosp_code , :f_user_id);
                                          END IF;
                                        END;";
                                break;
                            case DataRowState.Deleted:
                                //SEQ 추가
                                cmdText = @"DELETE OCS0221
                                         WHERE MEMB       = :f_memb
                                           AND MEMB_GUBUN = '1'
                                           AND HOSP_CODE  = :f_hosp_code
                                           AND SEQ        = :f_seq";
                                break;
                        }
                        break;
                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                //UPD_ID,UPD_DATE 추가
                                cmdText = @"INSERT INTO OCS0222
                                             ( SYS_DATE
                                             , SYS_ID
                                             , MEMB
                                             , MEMB_GUBUN
                                             , SEQ
                                             , SERIAL
                                             , COMMENT_TITLE
                                             , COMMENT_TEXT
                                             , HOSP_CODE
                                             , UPD_ID
                                             , UPD_DATE)
                                        SELECT SYSDATE
                                             , :f_user_id
                                             , :f_memb
                                             , NVL(:f_memb_gubun, '1')
                                             , :f_seq
                                             , NVL(MAX(SERIAL), 0) + 1
                                             , :f_comment_title
                                             , :f_comment_text
                                             , :f_hosp_code
                                             , :f_user_id
                                             , SYSDATE
                                          FROM OCS0222
                                         WHERE MEMB       = :f_memb
                                           AND MEMB_GUBUN = '1'
                                           AND SEQ        = :f_seq
                                           AND HOSP_CODE  = :f_hosp_code";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE OCS0222
                                           SET UPD_ID        = :f_user_id,
                                               UPD_DATE      = SYSDATE,
                                               COMMENT_TITLE = :f_comment_title ,
                                               COMMENT_TEXT  = :f_comment_text
                                         WHERE MEMB          = :f_memb
                                           AND MEMB_GUBUN    = '1'
                                           AND SEQ           = :f_seq
                                           AND SERIAL        = :f_serial
                                           AND HOSP_CODE     = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = "DELETE OCS0222"
                                + " WHERE MEMB       = :f_memb"
                                + "   AND MEMB_GUBUN = '1'"
                                + "   AND SEQ        = :f_seq"
                                + "   AND SERIAL     = :f_serial"
                                + "   AND HOSP_CODE  = :f_hosp_code";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdOCS0221_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            string sMsg = "";
            if (Find_AddedRowState_OCS0222() != "N")
            {
                if (Find_AddedRowState_OCS0222() == "U")
                    sMsg = Resource.OCS0221U00_txt_confirm_edit;
                else
                    sMsg = Resource.OCS0221U00_txt_confirm_delete;

                if (XMessageBox.Show(sMsg, Resource.OCS0221U00_text_cy, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    xButtonList1.PerformClick(FunctionType.Update);
                }
            }
        }

        #region 詳細に追加・削除した行が未保存状態であれば”U”,”D”とする
        private string Find_AddedRowState_OCS0222()
        {
            //詳細に行追加
            for (int i = 0; i < this.grdOCS0222.RowCount; i++)
            {
                if (this.grdOCS0222.LayoutTable.Rows[i].RowState == DataRowState.Added ||
                this.grdOCS0222.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                    return "U";
            }
            //詳細を削除
            if (this.grdOCS0222.DeletedRowTable != null && this.grdOCS0222.DeletedRowTable.Rows.Count > 0)
            {
                return "D";
            }
            //何もないとき
            return "N";
        }
        #endregion

        #region cloud service

        private List<string> CreateGrdOCS0221ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_memb");
            return paramList;
        }

        private List<object[]> LoadGrdOCS0221(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OcsaOCS0221U00CommonDataArgs args = new OcsaOCS0221U00CommonDataArgs();
            args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.HospCode = this.mHospCode;
            OcsaOCS0221U00CommonDataResult result = CloudService.Instance.Submit<OcsaOCS0221U00CommonDataResult, OcsaOCS0221U00CommonDataArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OcsaOCS0221U00GrdOCS0221ListInfo item in result.GridItem)
                {
                    object[] objects = { item.Memb,
                    item.FSeq,
                    item.CategoryGubun,
                    item.CategoryName,
                    item.CommentLimit };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<string> CreateGrdOCS0222ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_seq");
            paramList.Add("f_memb");
            return paramList;
        }

        private List<object[]> LoadGrdOCS0222(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OcsaOCS0221U00GrdOCS0222ListArgs args = new OcsaOCS0221U00GrdOCS0222ListArgs();
            args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.Seq = bc["f_seq"] != null ? bc["f_seq"].VarValue : "";
            args.HospCode = this.mHospCode;
            OcsaOCS0221U00GrdOCS0222ListResult result = CloudService.Instance.Submit<OcsaOCS0221U00GrdOCS0222ListResult, OcsaOCS0221U00GrdOCS0222ListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OcsaOCS0221U00GrdOCS0222ListInfo item in result.GridItem)
                {
                    object[] objects = { item.Memb,
                    item.Seq,
                    item.Serial,
                    item.CommentTitle,
                    item.CommentText };
                    res.Add(objects);
                }
            }
            return res;
        }
        #region GetOcs0221ListDataForSaveLayout
        /// <summary>
        /// GetOcs0221ListDataForSaveLayout
        /// </summary>
        /// <returns></returns>

        private List<OcsaOCS0221U00GrdOCS0221ListInfo> GetOcs0221ListDataForSaveLayout()
        {
            List<OcsaOCS0221U00GrdOCS0221ListInfo> lstResult = new List<OcsaOCS0221U00GrdOCS0221ListInfo>();

            for (int i = 0; i < grdOCS0221.RowCount; i++)
            {
                if (!DataRowState.Unchanged.ToString().Equals(grdOCS0221.GetRowState(i).ToString()))
                {
                    OcsaOCS0221U00GrdOCS0221ListInfo item = new OcsaOCS0221U00GrdOCS0221ListInfo();
                    item.Memb = grdOCS0221.GetItemString(i, "memb");
                    item.FSeq = grdOCS0221.GetItemString(i, "seq");
                    item.CategoryGubun = grdOCS0221.GetItemString(i, "category_gubun");
                    item.CategoryName = grdOCS0221.GetItemString(i, "category_name");
                    item.CommentLimit = grdOCS0221.GetItemString(i, "comment_limit");

                    item.DataRowState = grdOCS0221.GetRowState(i).ToString();

                    if (item.CategoryName != "")
                    {
                        lstResult.Add(item);
                        TheFlag = 0;
                    }
                    else
                    {
                        TheFlag = 1;
                    }

                }
            }

            // Delete
            if (null != grdOCS0221.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0221.DeletedRowTable.Rows)
                {
                    OcsaOCS0221U00GrdOCS0221ListInfo item = new OcsaOCS0221U00GrdOCS0221ListInfo();
                    item.Memb = Convert.ToString(dr["memb"]);
                    item.FSeq = Convert.ToString(dr["seq"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }
        #endregion

        #region GetOcs0222ListDataForSaveLayout
        /// <summary>
        /// GetOcs0222ListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OcsaOCS0221U00GrdOCS0222ListInfo> GetOcs0222ListDataForSaveLayout()
        {
            List<OcsaOCS0221U00GrdOCS0222ListInfo> lstResult = new List<OcsaOCS0221U00GrdOCS0222ListInfo>();

            for (int i = 0; i < grdOCS0222.RowCount; i++)
            {
                OcsaOCS0221U00GrdOCS0222ListInfo item = new OcsaOCS0221U00GrdOCS0222ListInfo();
                if (!DataRowState.Unchanged.ToString().Equals(grdOCS0222.GetRowState(i).ToString()))
                {
                    item.Memb = grdOCS0222.GetItemString(i, "memb");
                    item.Seq = grdOCS0222.GetItemString(i, "seq");
                    item.Serial = grdOCS0222.GetItemString(i, "serial");
                    item.CommentTitle = grdOCS0222.GetItemString(i, "comment_title");
                    item.CommentText = grdOCS0222.GetItemString(i, "comment_text");
                    item.DataRowState = grdOCS0222.GetRowState(i).ToString();
                    if (TypeCheck.IsNull(item.CommentTitle))
                    {
                        XMessageBox.Show(Resource.OCS0221U00_Waining1);
                        grdOCS0222.SetFocusToItem(i, "comment_title");
                        break;
                    }

                    lstResult.Add(item);
                }
            }


            // Delete
            if (null != grdOCS0222.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0222.DeletedRowTable.Rows)
                {
                    OcsaOCS0221U00GrdOCS0222ListInfo item = new OcsaOCS0221U00GrdOCS0222ListInfo();
                    item.Memb = Convert.ToString(dr["memb"]);
                    item.Seq = Convert.ToString(dr["seq"]);
                    item.Serial = Convert.ToString(dr["serial"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }
        #endregion

        #endregion

        private void xHospBox_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox.HospCode;
            grdOCS0221.QueryLayout(true);
            grdOCS0222.QueryLayout(true);
        }

        private void xHospBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = e.DataValue;
                grdOCS0221.QueryLayout(true);
                grdOCS0222.QueryLayout(true);
            }
        }
    }
}

