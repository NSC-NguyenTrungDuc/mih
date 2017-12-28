#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using System.Text;
#endregion

namespace IHIS.BASS
{
    /// <summary>
    /// BAS0101U04에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class BAS0101U04 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XEditGrid grdDetail;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private XEditGridCell xEditGridCell9;
        private Splitter splitter1;
        private string code_type = "";
        private string mHospCode = "";
        private XEditGridCell xEditGridCell10;
        private const string PID_SEQ_WRONG = "PID_SEQ_WRONG";

        public BAS0101U04()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            grdDetail.ParamList = new List<string>(new String[] { "f_code_type" });
            grdDetail.ExecuteQuery = ExecuteQueryGrdDetail;

            grdMaster.ParamList = new List<string>(new String[] { "f_code_type", "f_page_number" });
            grdMaster.ExecuteQuery = ExecuteQueryGrdMaster;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0101U04));
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell9});
            this.grdMaster.ColPerLine = 3;
            this.grdMaster.Cols = 3;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(22);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.Enter += new System.EventHandler(this.grdMaster_Enter);
            this.grdMaster.PreEndInitializing += new System.EventHandler(this.grdMaster_PreEndInitializing);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 168;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellLen = 30;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 229;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellLen = 30;
            this.xEditGridCell9.CellName = "admin_gubun";
            this.xEditGridCell9.CellWidth = 88;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell10});
            this.grdDetail.ColPerLine = 5;
            this.grdDetail.Cols = 5;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(23);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.Enter += new System.EventHandler(this.grdDetail_Enter);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 98;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 80;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 270;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "group_key";
            this.xEditGridCell6.CellWidth = 115;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellLen = 4000;
            this.xEditGridCell7.CellName = "remark";
            this.xEditGridCell7.CellWidth = 128;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "sort_key";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 61;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellLen = 100;
            this.xEditGridCell10.CellName = "psw_text";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            // BAS0101U04
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdMaster);
            this.Controls.Add(this.btnList);
            this.Name = "BAS0101U04";
            this.Load += new System.EventHandler(this.BAS0101U04_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private bool tFlag = false;

        private void BAS0101U04_Load(object sender, System.EventArgs e)
        {
            this.mHospCode = EnvironInfo.HospCode;

            this.grdMaster.SavePerformer = new XSavePeformer(this);
            this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            // 마스터, 디테일 Relation 
            this.grdDetail.SetRelationKey("code_type", "code_type");
            this.grdDetail.SetRelationTable("bas0102");

            ((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).ApplyByteLimit = true;
            ((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).MaxLength = 30;

            ((XTextBox)((XEditGridCell)grdMaster.CellInfos["code_type_name"]).CellEditor.Editor).TextChanged += new System.EventHandler(this.xTextBox1_TextChanged);

            //this.grdMaster.QueryLayout(false);
            this.grdMaster.QueryLayout(false);
        }

        private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            if (tFlag)
            {
                if (e.ColName == "code_type")
                {
                    /*ArrayList inputList = new ArrayList();
                    ArrayList outputList = new ArrayList();

                    inputList.Add("Y");           // master_check
                    inputList.Add(e.ChangeValue); //code_type
                    inputList.Add(e.ChangeValue); //col_id　마스터에서는 무의미

                    Service.ExecuteProcedure("PR_OUT_CHECK_DUP_BAS0101", inputList, outputList);*/

                    string DupYn = CheckDupBas0101("Y", e.ChangeValue.ToString(), e.ChangeValue.ToString());
                    if (!TypeCheck.IsNull(DupYn))
                    {
                        if (DupYn == "Y")
                        {
                            XMessageBox.Show(Resources.MSG_1, Resources.Caption_1, MessageBoxIcon.Warning);
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            if (e.ColName == "code")
            {
                /*ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();

                inputList.Add("N");           // master_check
                inputList.Add(this.grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type")); //code_type
                inputList.Add(e.ChangeValue); //col_id　마스터에서는 무의미

                Service.ExecuteProcedure("PR_OUT_CHECK_DUP_BAS0101", inputList, outputList);*/

                string DupYn = CheckDupBas0101("N", this.grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type"), e.ChangeValue.ToString());
                if (!TypeCheck.IsNull(DupYn))
                {
                    if (DupYn == "Y")
                    {
                        XMessageBox.Show(Resources.MSG_2, Resources.Caption_1, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }

            // https://sofiamedix.atlassian.net/browse/MED-15909
            if (e.ColName == "code_name" && grdDetail.GetItemString(e.RowNumber, "code").ToUpper() == "PASSWORD")
            {
                grdDetail.SetItemValue(e.RowNumber, "psw_text", e.ChangeValue);
                grdDetail.SetItemValue(e.RowNumber, "code_name", "********");
            }
        }

        private string mMsg = "";
        private string mCap = "";
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            tFlag = false;

            switch (e.Func)
            {
                case FunctionType.Query:
                    this.grdMaster.QueryLayout(false);
                    //this.grdMaster.QueryLayout(true);
                    break;
                case FunctionType.Insert:

                    tFlag = true;

                    if (this.CurrMSLayout == this.grdMaster)
                    {
                        if (Find_AddedRowState() == "Y")
                        {
                            XMessageBox.Show(Resources.MSG_3, Resources.Caption_2);
                            e.IsBaseCall = false;
                        }
                    }

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    try
                    {
                        //====MED-14258
                        if (code_type == "MBS_SYSTEM") {
                            //1. validation
                            if (!Validate_MBS_SYTEM())
                            {
                                return;
                            }
                        //    //2 Notify to MBS system
                        //    BAS0101U04SendToMBSArgs args1 = new BAS0101U04SendToMBSArgs();
                        //    args1.HospCode = UserInfo.HospCode;
                        //    args1.UseMovieTalk = grdDetail.GetItemString(0, "code_name");
                        //    args1.UseSurvey = grdDetail.GetItemString(1, "code_name");
                        //    args1.Locale = "";

                        //    BAS0101U04SendToMBSResult res = CloudService.Instance.Submit<BAS0101U04SendToMBSResult, BAS0101U04SendToMBSArgs>(args1);
                        //    if (res.Status != 0)
                        //    {
                        //        XMessageBox.Show(Resources.CMO_M006, Resources.Caption_2, MessageBoxIcon.Error);
                        //        return;
                        //    }
                        }

                        if (code_type == "PAYMENT_GW_GMO")
                        {
                            if (!validate_PAYMENT_GW_GMO())
                            {
                                return;
                            }
                        }
                       
                        // 3. Update to table BAS0102
                        if (grdMaster.ValidateCell())
                        {
                            if(!ValidateStartPatientId()) return;
                            BAS0101U04SaveLayoutArgs args = new BAS0101U04SaveLayoutArgs();
                            args.GrdDetailInfo = CreateListGrdDetailInfo();
                            args.GrdMasterInfo = CreateListGrdMasterInfo();
                            args.UserId = UserInfo.UserID;

                            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, BAS0101U04SaveLayoutArgs>(args);

                            if (updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result == true)
                            {
                                this.mMsg = Resources.MSG_4;

                                this.mCap = Resources.Caption_3;//NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";

                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Commit updates
                                grdMaster.ResetUpdate();
                                grdDetail.ResetUpdate();
                            }
                            else if (!string.IsNullOrEmpty(updateResult.Msg) && updateResult.Msg.StartsWith(PID_SEQ_WRONG))
                            {
                                string[] strValue = updateResult.Msg.Split('.');
                                this.mMsg = string.Format(Resources.BAS0101U04_SaveFail_PID_SEQ, Resources.BAS0101U04_PID_SEQ, strValue.Length > 1 ? strValue[1] : "");
                                this.mCap = Resources.Caption_3;
                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            //if (!CreateSaveLayout())
                            //{
                            //    throw new Exception();
                            //}
                            // TODO comment use connect cloud
                            /* Service.BeginTransaction();

                             if (this.grdMaster.SaveLayout())
                             {
                                 if (this.grdDetail.SaveLayout())
                                 {
                                     this.mMsg = Resources.MSG_4;

                                     this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";

                                     XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                 }
                                 else
                                     throw new Exception();
                             }
                             else
                                 throw new Exception();

                             Service.CommitTransaction();*/
                        }
                    }
                    catch (Exception ex)
                    {
                        //                        Service.RollbackTransaction();
                        this.mMsg = Resources.MSG_5;
						//https://sofiamedix.atlassian.net/browse/MED-10610
                        //this.mMsg += "\r\n" + ex.Message;

                        this.mCap = Resources.Caption_3;
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    break;
            }
        }

        private bool Validate_MBS_SYTEM()
        {
            string use_movie_talk = grdDetail.GetItemString(0, "code_name");
            string use_survey = grdDetail.GetItemString(1, "code_name");

            if (use_movie_talk != "1" && use_movie_talk != "0")
            {
                MessageBox.Show(String.Format(Resources.ADM_MSG008, "USE_MOVIE_TALK"), Resources.Caption_2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (use_survey != "1" && use_survey != "0")
            {
                MessageBox.Show(String.Format(Resources.ADM_MSG008, "USE_SURVEY"), Resources.Caption_2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (use_movie_talk == "0" && use_survey == "1")
            {
                MessageBox.Show(String.Format(Resources.ADM_MSG009, "USE_MOVIE_TALK"), Resources.Caption_2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            
        }

        private bool validate_PAYMENT_GW_GMO()
        { 
            string code = "";
            string code_name = "";
            string user_auth = "";
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetItemString(i,"code") == "USE_AUTH")
                {
                    int tmp = 0;
                    if (grdDetail.GetItemString(i, "code_name") != "Y" && grdDetail.GetItemString(i, "code_name") != "N")
                    {
                        MessageBox.Show(Resources.ADM_MSG012, Resources.Caption_2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (grdDetail.GetItemString(i,"code_name") == "Y")
                        {
                            for (int j = 0; j < grdDetail.RowCount; j++)
                            {
                                if (grdDetail.GetItemString(j,"code") == "AUTH_AMT")
                                {
                                    if (int.TryParse(grdDetail.GetItemString(j,"code_name"),out tmp))
                                    {
                                        if (tmp <= 0)
                                        {
                                            MessageBox.Show(Resources.ADM_MSG010, Resources.Caption_2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        else if (grdDetail.GetItemString(i, "code_name") == "N")
                        {
                            for (int j = 0; j < grdDetail.RowCount; j++)
                            {
                                if (grdDetail.GetItemString(j,"code") == "AUTH_AMT")
                                {
                                    if (int.TryParse(grdDetail.GetItemString(j,"code_name"),out tmp))
                                    {
                                        if (tmp > 0)
                                        {
                                            MessageBox.Show(Resources.ADM_MSG011, Resources.Caption_2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return false;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return true;
        }

        private bool ValidateStartPatientId()
        {
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Added || grdDetail.GetRowState(i) == DataRowState.Modified)
                {
                    if (grdDetail.GetItemString(i, "code_type") == Resources.BAS0101U04_CONST_CODE_TYPE_STARTING_PID)
                    {
                        string code = grdDetail.GetItemString(i, "code");
                        string codeName = grdDetail.GetItemString(i, "code_name");
                        if (!string.IsNullOrEmpty(code) && code.Trim().ToUpper() == Resources.BAS0101U04_PID_SEQ)
                        {
                            if (!ValidateValue(codeName, Resources.BAS0101U04_PID_SEQ))
                            {
                                grdDetail.SetFocusToItem(i, "code_name");
                                return false;
                            }
                        }
                        else if (!string.IsNullOrEmpty(code) && code.Trim().ToUpper() == Resources.BAS0101U04_SEQ_STEP)
                        {
                            if (!ValidateValue(codeName, Resources.BAS0101U04_SEQ_STEP))
                            {
                                grdDetail.SetFocusToItem(i, "code_name");
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool ValidateValue(string codeName, string strName)
        {
            int stepSeq = 0;
            if (!Int32.TryParse(codeName, out stepSeq))
            {
                this.mMsg = string.Format(Resources.BAS0101U04_ValidateStartPatientId_Must_Be_Number, strName);
                this.mCap = Resources.Caption_3;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (stepSeq <= 0)
            {
                this.mMsg = string.Format(Resources.BAS0101U04_ValidateValue_BiggerThan0Char, strName);
                this.mCap = Resources.Caption_3;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (stepSeq.ToString(CultureInfo.InvariantCulture).Length > 9)
            {
                this.mMsg = string.Format(Resources.BAS0101U04_ValidateStartPatientId_MustLestThan10Char, strName);
                this.mCap = Resources.Caption_3;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SetMaxLengthForStartPatientId(BindVarCollection bc)
        {
            ((XTextBox)((XEditGridCell)grdDetail.CellInfos["code_name"]).CellEditor.Editor).MaxLength = 80;
            if (bc["f_code_type"] != null && bc["f_code_type"].VarValue == Resources.BAS0101U04_CONST_CODE_TYPE_STARTING_PID)
            {
                ((XTextBox)((XEditGridCell)grdDetail.CellInfos["code_name"]).CellEditor.Editor).MaxLength = 9;
            }
        }

        private string Find_AddedRowState()
        {
            if (this.CurrMSLayout == this.grdMaster)
            {
                // 마스터 그리드 새로 삽입된 행 검색
                for (int i = 0; i < this.grdMaster.RowCount; i++)
                {
                    if (this.grdMaster.LayoutTable.Rows[i].RowState == DataRowState.Added)
                        return "Y";
                }

                // 마스터에 새로운 행이 없을경우 디테일도 검색
                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    if (this.grdDetail.LayoutTable.Rows[i].RowState == DataRowState.Added)
                        return "Y";
                }
            }
            return "N";
        }

        private void xButton1_Click(object sender, System.EventArgs e)
        {
            Color color = Color.Silver;

            XMessageBox.Show(color.R.ToString() + "." + color.G.ToString() + "." + color.B.ToString());
        }

        private int GetStringByte(string s)
        {
            int returnByte = 0;

            if (s.Length == 0)
            {
                return returnByte;
            }

            Encoding JisEncoding = Encoding.GetEncoding("Shift-JIS");
            returnByte = JisEncoding.GetByteCount(s);
            return returnByte;
        }

        private string SubstringByte(string s, int startIndex, int length)
        {
            string returnString = "";
            int limitLen, cutLen;
            string padSpace = " ";

            if (GetStringByte(s) == 0 || GetStringByte(s) < startIndex || length < 1)
            {
                return returnString;
            }

            limitLen = GetStringByte(s) - startIndex;

            if (length > limitLen)
            {
                cutLen = limitLen;
            }
            else
            {
                cutLen = length;
            }

            Encoding JisEncoding = Encoding.GetEncoding("Shift-JIS");
            Byte[] encodingByte = JisEncoding.GetBytes(s);

            returnString = JisEncoding.GetString(encodingByte, startIndex, cutLen);
            encodingByte = JisEncoding.GetBytes(returnString);

            if (encodingByte[encodingByte.Length - 1] == 0)
            {
                returnString = JisEncoding.GetString(encodingByte, 0, cutLen - 1);
            }

            if (length > cutLen)
            {
                padSpace = padSpace.PadRight(length - cutLen);
                returnString = returnString + padSpace;
            }
            return returnString;
        }

        private void xTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            XTextBox st = (XTextBox)sender;

            if (GetStringByte(st.GetDataValue()) > st.MaxLength)
            {
                st.Text = SubstringByte(st.GetDataValue(), 0, 30);
                st.Select(st.Text.Length, 1);
            }
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0101U04 parent = null;

            public XSavePeformer(BAS0101U04 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM SYS.DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0101
                                                             WHERE HOSP_CODE = :f_hosp_code 
                                                               AND CODE_TYPE = :f_code_type )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + "」は既に登録されています。", Resources.Caption_1, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"INSERT INTO BAS0101
                                                 ( SYS_DATE　      , SYS_ID　　     , UPD_DATE          , UPD_ID
                                                 , HOSP_CODE       , CODE_TYPE　　　, CODE_TYPE_NAME           , ADMIN_GUBUN  )
                                            VALUES(SYSDATE         , :q_user_id　   , SYSDATE           , :q_user_id　
                                                 , :f_hosp_code    , :f_code_type    , :f_code_type_name       ,:f_admin_gubun  )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0101
                                               SET UPD_ID         = :q_user_id
                                                 , UPD_DATE       = SYSDATE
                                                 , CODE_TYPE_NAME = :f_code_type_name
                                                 , ADMIN_GUBUN = :f_admin_gubun
                                             WHERE HOSP_CODE      = :f_hosp_code
                                               AND CODE_TYPE      = :f_code_type";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"SELECT 'Y'
                                              FROM SYS.DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0102
                                                             WHERE HOSP_CODE = :f_hosp_code
                                                               AND CODE_TYPE = :f_code_type )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + "」は詳細コードが登録されているため削除出来ません。", Resources.Caption_1, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"DELETE FROM BAS0101
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND CODE_TYPE = :f_code_type";

                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0102
                                                             WHERE HOSP_CODE = :f_hosp_code
                                                               AND CODE_TYPE = :f_code_type
                                                               AND CODE      = :f_code        )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_code"].VarValue + "」は既に登録されています。", Resources.Caption_1, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"INSERT INTO BAS0102
                                                 ( SYS_DATE         , SYS_ID         , UPD_DATE      , UPD_ID
                                                 , HOSP_CODE        , CODE_TYPE      , CODE          , CODE_NAME
                                                 , GROUP_KEY        , REMARK         , SORT_KEY   )
                                            VALUES(SYSDATE          , :q_user_id     , SYSDATE       , :q_user_id
                                                 , :f_hosp_code     , :f_code_type   , :f_code       , :f_code_name
                                                 , :f_group_key     , :f_remark      , :f_sort_key     )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0102
                                             SET UPD_ID    = :q_user_id
                                               , UPD_DATE  = SYSDATE
                                               , CODE_NAME = :f_code_name
                                               , GROUP_KEY = :f_group_key
                                               , REMARK    = :f_remark
                                               , SORT_KEY  = :f_sort_key
                                           WHERE HOSP_CODE = :f_hosp_code
                                             AND CODE_TYPE = :f_code_type
                                             AND CODE      = :f_code      ";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM BAS0102
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE_TYPE = :f_code_type
                                               AND CODE      = :f_code    ";

                                break;
                        }

                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdMaster_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell9.ExecuteQuery = ComboAdminGubun;
        }

        #region Connect to cloud
        /// <summary>
        /// ExecuteQueryGrdDetail
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdDetail(BindVarCollection bc)
        {
            SetMaxLengthForStartPatientId(bc);
            List<object[]> res = new List<object[]>();
            BAS0101U04GrdDetailArgs vBAS0101U04GrdDetailArgs = new BAS0101U04GrdDetailArgs();
            vBAS0101U04GrdDetailArgs.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            code_type = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";

            BAS0101U04GrdDetailResult result = CloudService.Instance.Submit<BAS0101U04GrdDetailResult, BAS0101U04GrdDetailArgs>(vBAS0101U04GrdDetailArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0101U04GrdDetailInfo item in result.GrdDetailInfo)
                {
                    object[] objects =
                    {
                        item.CodeType,
                        item.Code,
                        // https://sofiamedix.atlassian.net/browse/MED-15909
                        item.Code.ToUpper() == "PASSWORD" ? "********" : item.CodeName,
                        item.GroupKey,
                        item.Remark,
                        item.SortKey,
                        item.DataRowState
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdMaster
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0101U04GrdMasterArgs vBAS0101U04GrdMasterArgs = new BAS0101U04GrdMasterArgs();
            vBAS0101U04GrdMasterArgs.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            vBAS0101U04GrdMasterArgs.PageNumber = bc["f_page_number"].VarValue;
            vBAS0101U04GrdMasterArgs.Offset = "200";
            BAS0101U04GrdMasterResult result = CloudService.Instance.Submit<BAS0101U04GrdMasterResult, BAS0101U04GrdMasterArgs>(vBAS0101U04GrdMasterArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0101U04GrdMasterInfo item in result.GrdMasterItem)
                {
                    object[] objects =
                    {
                        item.CodeType,
                        item.CodeTypeName,
                        item.AdminGubun,
                        item.DataRowState
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CreateSaveLayout()
        {
            BAS0101U04SaveLayoutArgs args = new BAS0101U04SaveLayoutArgs();
            args.GrdDetailInfo = CreateListGrdDetailInfo();
            args.GrdMasterInfo = CreateListGrdMasterInfo();
            args.UserId = UserInfo.UserID;
            if (args.GrdMasterInfo.Count > 0)
            {
                UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, BAS0101U04SaveLayoutArgs>(args);
                if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                    updateResult.Result == false)
                {
                    return false;
                }
                this.mMsg = Resources.MSG_4;
                this.mCap = Resources.Cation_4;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.grdMaster.ResetUpdate();
            }
            return true;
        }

        /// <summary>
        /// CreateListGrdDetailInfo
        /// </summary>
        /// <returns></returns>
        private List<BAS0101U04GrdDetailInfo> CreateListGrdDetailInfo()
        {
            List<BAS0101U04GrdDetailInfo> ListGrdDetailInfo = new List<BAS0101U04GrdDetailInfo>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Added || grdDetail.GetRowState(i) == DataRowState.Modified)
                {
                    // Required check for コード類型
                    if (TypeCheck.IsNull(grdDetail.GetItemString(i, "code_name"))
                        || TypeCheck.IsNull(grdDetail.GetItemString(i, "code")))
                    {
                        throw new Exception();
                    }

                    // https://sofiamedix.atlassian.net/browse/MED-15909
                    string codeName = grdDetail.GetItemString(i, "code_name");
                    if (grdDetail.GetItemString(i, "code").ToUpper() == "PASSWORD")
                    {
                        codeName = grdDetail.GetItemString(i, "psw_text");
                    }

                    BAS0101U04GrdDetailInfo detailInfo = new BAS0101U04GrdDetailInfo();
                    detailInfo.CodeType = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                    detailInfo.Code = grdDetail.GetItemString(i, "code");
                    detailInfo.CodeName = codeName;
                    detailInfo.GroupKey = grdDetail.GetItemString(i, "group_key");
                    detailInfo.Remark = grdDetail.GetItemString(i, "remark");
                    detailInfo.SortKey = grdDetail.GetItemString(i, "sort_key");
                    detailInfo.DataRowState = grdDetail.GetRowState(i).ToString();
                    ListGrdDetailInfo.Add(detailInfo);
                }
            }
            if (grdDetail.DeletedRowTable != null && grdDetail.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
                {
                    BAS0101U04GrdDetailInfo detailInfo = new BAS0101U04GrdDetailInfo();
                    detailInfo.CodeType = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                    detailInfo.Code = row["code"].ToString();
                    detailInfo.CodeName = row["code_name"].ToString();
                    detailInfo.GroupKey = row["group_key"].ToString();
                    detailInfo.Remark = row["remark"].ToString();
                    detailInfo.SortKey = row["sort_key"].ToString();
                    detailInfo.DataRowState = DataRowState.Deleted.ToString();

                    ListGrdDetailInfo.Add(detailInfo);
                }
            }
            return ListGrdDetailInfo;
        }

        /// <summary>
        /// CreateListGrdMasterInfo
        /// </summary>
        /// <returns></returns>
        private List<BAS0101U04GrdMasterInfo> CreateListGrdMasterInfo()
        {
            List<BAS0101U04GrdMasterInfo> ListGrdMasterInfo = new List<BAS0101U04GrdMasterInfo>();
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) == DataRowState.Added || grdMaster.GetRowState(i) == DataRowState.Modified)
                {
                    // Required check for コード類型
                    if (TypeCheck.IsNull(grdMaster.GetItemString(i, "code_type")) || TypeCheck.IsNull(grdMaster.GetItemString(i, "code_type_name")))
                    {
                        throw new Exception();
                    }

                    BAS0101U04GrdMasterInfo grdMasterInfo = new BAS0101U04GrdMasterInfo();
                    grdMasterInfo.CodeType = grdMaster.GetItemString(i, "code_type");
                    grdMasterInfo.CodeTypeName = grdMaster.GetItemString(i, "code_type_name");
                    grdMasterInfo.AdminGubun = grdMaster.GetItemString(i, "admin_gubun");
                    grdMasterInfo.DataRowState = grdMaster.GetRowState(i).ToString();
                    ListGrdMasterInfo.Add(grdMasterInfo);
                }
            }
            if (grdMaster.DeletedRowTable != null && grdMaster.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdMaster.DeletedRowTable.Rows)
                {
                    BAS0101U04GrdMasterInfo grdMasterInfo = new BAS0101U04GrdMasterInfo();
                    grdMasterInfo.CodeType = row["code_type"].ToString();
                    grdMasterInfo.CodeTypeName = row["code_type_name"].ToString();
                    grdMasterInfo.AdminGubun = row["admin_gubun"].ToString();
                    grdMasterInfo.DataRowState = DataRowState.Deleted.ToString();
                    ListGrdMasterInfo.Add(grdMasterInfo);
                }

            }
            return ListGrdMasterInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aMasterCheck"></param>
        /// <param name="aCodeType"></param>
        /// <param name="aColId"></param>
        /// <returns></returns>
        private String CheckDupBas0101(string aMasterCheck, string aCodeType, string aColId)
        {
            BAS0101U04GrdMasterGridColumnChangedArgs vBAS0101U04GrdMasterGridColumnChangedArgs =
                new BAS0101U04GrdMasterGridColumnChangedArgs();

            vBAS0101U04GrdMasterGridColumnChangedArgs.MasterCheck = aMasterCheck;
            vBAS0101U04GrdMasterGridColumnChangedArgs.CodeType = aCodeType;
            vBAS0101U04GrdMasterGridColumnChangedArgs.ColId = aColId;
            BAS0101U04GrdMasterGridColumnChangedResult result =
                CloudService.Instance
                    .Submit<BAS0101U04GrdMasterGridColumnChangedResult, BAS0101U04GrdMasterGridColumnChangedArgs>(
                        vBAS0101U04GrdMasterGridColumnChangedArgs);
            if (result == null || result.ExecutionStatus != ExecutionStatus.Success)
            {
                return null;
            }
            return result.DupYn;
        }

        /// <summary>
        /// ComboAdminGubun
        /// </summary>
        /// <returns></returns>
        private IList<object[]> ComboAdminGubun(BindVarCollection var)
        {
            IList<object[]> res = new List<object[]>();
            ComboAdminGubunArgs args = new ComboAdminGubunArgs();
            args.CodeType = "ADMIN_GUBUN";
            ComboResult comboResult =
                CacheService.Instance.Get<ComboAdminGubunArgs, ComboResult>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
                {
                    res.Add(new object[] { info.Code, info.CodeName });
                }
            }
            return res;
        }
        #endregion

        /// <summary>
        /// 2016.02.05 AnhNV Added
        /// https://sofiamedix.atlassian.net/browse/MED-7280
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdMaster_Enter(object sender, EventArgs e)
        {
            if (UserInfo.AdminType != AdminType.SuperAdmin)
            {
                btnList.SetEnabled(FunctionType.Delete, false);
                btnList.SetEnabled(FunctionType.Insert, false);
                btnList.SetEnabled(FunctionType.Update, false);
                btnList.SetEnabled(FunctionType.Reset, false);
            }
        }

        private void grdDetail_Enter(object sender, EventArgs e)
        {
            if (code_type == "MBS_SYSTEM")
            {
                xEditGridCell4.IsReadOnly = true;
                btnList.SetEnabled(FunctionType.Delete, false);
                btnList.SetEnabled(FunctionType.Insert, false);
                btnList.SetEnabled(FunctionType.Update, true);
                btnList.SetEnabled(FunctionType.Reset, false);
            }
            else
            {
                btnList.SetEnabled(FunctionType.Delete, true);
                btnList.SetEnabled(FunctionType.Insert, true);
                btnList.SetEnabled(FunctionType.Update, true);
                btnList.SetEnabled(FunctionType.Reset, true);
            }
        }
    }
}

