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

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0122U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0122U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";
        bool isgrdOCS0122Save = false;
        bool issaved0122 = false;

        string mHospCode = EnvironInfo.HospCode;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XDisplayBox dbxBuseo_name;
        private IHIS.Framework.XFindBox fbxBuseo_code;
        private IHIS.Framework.XFindWorker fwkOCS0103;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XEditGrid grdOCS0122;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0122U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            SaveLayoutList.Add(grdOCS0122);
            grdOCS0122.SavePerformer = new XSavePerformer(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0122U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxBuseo_name = new IHIS.Framework.XDisplayBox();
            this.fbxBuseo_code = new IHIS.Framework.XFindBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.fwkOCS0103 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0122 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0122)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.dbxBuseo_name);
            this.xPanel1.Controls.Add(this.fbxBuseo_code);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(960, 34);
            this.xPanel1.TabIndex = 0;
            // 
            // dbxBuseo_name
            // 
            this.dbxBuseo_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxBuseo_name.EdgeRounding = false;
            this.dbxBuseo_name.Location = new System.Drawing.Point(188, 6);
            this.dbxBuseo_name.Name = "dbxBuseo_name";
            this.dbxBuseo_name.Size = new System.Drawing.Size(254, 20);
            this.dbxBuseo_name.TabIndex = 14;
            // 
            // fbxBuseo_code
            // 
            this.fbxBuseo_code.ApplyByteLimit = true;
            this.fbxBuseo_code.AutoTabDataSelected = true;
            this.fbxBuseo_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxBuseo_code.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fbxBuseo_code.Location = new System.Drawing.Point(102, 6);
            this.fbxBuseo_code.MaxLength = 10;
            this.fbxBuseo_code.Name = "fbxBuseo_code";
            this.fbxBuseo_code.Size = new System.Drawing.Size(86, 20);
            this.fbxBuseo_code.TabIndex = 0;
            this.fbxBuseo_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBuseo_code_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Enabled = false;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Location = new System.Drawing.Point(6, 6);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(94, 20);
            this.xLabel4.TabIndex = 10;
            this.xLabel4.Text = "部署";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkOCS0103
            // 
            this.fwkOCS0103.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkOCS0103.FormText = "オ―ダコード";
            this.fwkOCS0103.InputSQL = resources.GetString("fwkOCS0103.InputSQL");
            this.fwkOCS0103.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkOCS0103.SearchTextCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.fwkOCS0103.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hangmog_code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "オ―ダコード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "hangmog_name";
            this.findColumnInfo2.ColWidth = 448;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.Yes;
            this.findColumnInfo2.HeaderText = "オ―ダコード名";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 546);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(960, 44);
            this.xPanel2.TabIndex = 2;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(550, 6);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(406, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0122
            // 
            this.grdOCS0122.AddedHeaderLine = 1;
            this.grdOCS0122.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell9,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8});
            this.grdOCS0122.ColPerLine = 6;
            this.grdOCS0122.Cols = 6;
            this.grdOCS0122.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0122.FixedRows = 2;
            this.grdOCS0122.HeaderHeights.Add(21);
            this.grdOCS0122.HeaderHeights.Add(0);
            this.grdOCS0122.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS0122.Location = new System.Drawing.Point(0, 34);
            this.grdOCS0122.Name = "grdOCS0122";
            this.grdOCS0122.QuerySQL = resources.GetString("grdOCS0122.QuerySQL");
            this.grdOCS0122.Rows = 3;
            this.grdOCS0122.Size = new System.Drawing.Size(960, 512);
            this.grdOCS0122.TabIndex = 1;
            this.grdOCS0122.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0122_QueryStarting);
            this.grdOCS0122.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0122_SaveStarting);
            this.grdOCS0122.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0122_GridColumnChanged);
            this.grdOCS0122.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS0122_SaveEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "buseo_code";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "buseo_code";
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AutoTabDataSelected = true;
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.FindWorker = this.fwkOCS0103;
            this.xEditGridCell2.HeaderText = "項目コード";
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.CellWidth = 363;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderText = "項目コード名";
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "jaego_qty";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 64;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderText = "在庫数量";
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ord_danui";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "ord_danui";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "subul_danui";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "subul_danui";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "subul_danui_name";
            this.xEditGridCell6.CellWidth = 82;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.HeaderText = "受払単位";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "subul_buseo";
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.HeaderText = "受払請求部署";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.Row = 1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "subul_buseo_name";
            this.xEditGridCell8.CellWidth = 154;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.HeaderText = "受払請求部署";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "受払請求部署";
            // 
            // OCS0122U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.grdOCS0122);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0122U00";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0122)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        #region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
        public override object Command(string command, CommonItemCollection commandParam)
        {
            //			switch (command)
            //			{
            //				case "BAS0270":
            //					DataLayoutMIO dloDoctorInfo = (DataLayoutMIO)commandParam["BAS0270"];
            //
            //					grdOCS0303.SetItemValue(grdOCS0303.CurrentRowNumber, "act_doctor", dloDoctorInfo.LayoutTable.Rows[0]["doctor"]);
            //					grdOCS0303.SetItemValue(grdOCS0303.CurrentRowNumber, "act_doctor_name", dloDoctorInfo.LayoutTable.Rows[0]["doctor_name"]);
            //
            //					
            //					break;
            //			}
            //	
            //			if(command == "F") return base.Command (command, commandParam);
            //
            //			mMemb = commandParam["memb"].ToString();

            return base.Command(command, commandParam);
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            fbxBuseo_code.FindWorker = this.GetFindWorker("buseo_code", "");
            fwkOCS0103.SetBindVarValue("f_hangmog_code", "");
            fwkOCS0103.SetBindVarValue("f_order_gubun", "");
            fwkOCS0103.SetBindVarValue("f_jaeryo_yn", "Y");

            //사용자 부서
            //			if( !TypeCheck.IsNull(OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items["input_part"].ToString()) )
            //			{
            //				fbxBuseo_code.SetDataValue(OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items["input_part"].ToString());
            //				string buseo_name = GetCodeName("buseo_code", OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items["input_part"].ToString());
            //
            //				if(TypeCheck.IsNull(buseo_name))
            //					fbxBuseo_code.SetDataValue("");
            //				else
            //				{
            //					dbxBuseo_name.SetDataValue(buseo_name);
            //					dsvLDOCS0122.Call();			
            //				}
            //			}

            if (!TypeCheck.IsNull(UserInfo.Gwa))
            {
                fbxBuseo_code.SetDataValue(UserInfo.Gwa);
                string buseo_name = GetCodeName("buseo_code", UserInfo.Gwa);

                if (TypeCheck.IsNull(buseo_name))
                    fbxBuseo_code.SetDataValue("");
                else
                {
                    dbxBuseo_name.SetDataValue(buseo_name);
                    grdOCS0122.QueryLayout(false);
                }
            }
        }

        #endregion

        #region [GetFindWorker]
        private XFindWorker GetFindWorker(string findMode, string ref_code)
        {
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
            switch (findMode)
            {
                case "buseo_code":
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;
                    fdwCommon.InputSQL = ""
                        + " SELECT A.INPUT_PART, A.INPUT_PART_NAME                                    "
                        + "	  FROM VW_OCS_INPUT_PART A                                                "
                        + "  ORDER BY A.INPUT_PART ";

                    fdwCommon.FormText = "部署照会";
                    fdwCommon.ColInfos.Add("hangmog_code", "部署コード", FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("hangmog_name", "部署名 ", FindColType.String, 300, 0, true, FilterType.Yes);
                    break;
                default:
                    break;
            }

            return fdwCommon;
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
                case "buseo_code":
                    cmdText = ""
                        + " SELECT A.INPUT_PART_NAME "
                        + "	  FROM VW_OCS_INPUT_PART A "
                        + "	 WHERE A.INPUT_PART = :f_code "
                        + "    AND ROWNUM = 1 ";

                    IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
                    bindVars.Add("f_code", code);

                    object retVal = Service.ExecuteScalar(cmdText, bindVars);

                    if (retVal == null)
                        codeName = "";
                    else
                        codeName = retVal.ToString();
                    break;
                default:
                    break;
            }

            return codeName;
        }

        #endregion

        #region [Control Event]
        private void fbxBuseo_code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            dbxBuseo_name.SetDataValue("");
            grdOCS0122.Reset();

            string buseo_name = GetCodeName("buseo_code", e.DataValue);
            if (buseo_name == "")
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "部署コードが正確ではないです。 確認してください。" : "부서코드가 정확하지않습니다. 확인바랍니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap);
            }
            else
            {
                dbxBuseo_name.SetDataValue(buseo_name);
                grdOCS0122.QueryLayout(false);
            }
        }
        #endregion

        #region [grdOCS0122]
        private void grdOCS0122_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            string cmdText = "";
            IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
            switch (e.ColName)
            {
                case "hangmog_code":
                    if (e.ChangeValue.ToString().Trim() == "")
                    {
                        grdOCS0122.SetItemValue(e.RowNumber, "hangmog_name", "");
                        grdOCS0122.SetItemValue(e.RowNumber, "jaego_qty", 1);
                        grdOCS0122.SetItemValue(e.RowNumber, "ord_danui", "");
                        grdOCS0122.SetItemValue(e.RowNumber, "subul_danui", "");
                        grdOCS0122.SetItemValue(e.RowNumber, "subul_danui_name", "");
                        grdOCS0122.SetItemValue(e.RowNumber, "subul_buseo", "");
                        grdOCS0122.SetItemValue(e.RowNumber, "subul_buseo_name", "");
                        return;
                    }

                    for (int i = 0; i < grdOCS0122.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0122.GetItemString(i, "hangmog_code").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダコードが重複されます。 確認してください。" : "항목코드가 중복됩니다. 확인바랍니다.";
                                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                                break;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    cmdText = ""
                        + "  SELECT A.HANGMOG_NAME,                 "
                        + "         A.ORD_DANUI   ,                 "
                        + "         B.SUBUL_DANUI ,                 "
                        + "         FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.SUBUL_DANUI)  "
                        + "                                          SUBUL_DANUI_NAME, "
                        + "         B.SUBUL_BUSEO ,                 "
                        + "         FN_BAS_LOAD_BUSEO_NAME(B.SUBUL_BUSEO, SYSDATE) SUBUL_BUSEO_NAME  "
                        + "    FROM OCS0103 A,                      "
                        + "         INV0110 B                       "
                        + "   WHERE A.HANGMOG_CODE  = :f_value      "
                        + "     AND B.JAERYO_CODE	= A.JAERYO_CODE "
                        + "     AND ROWNUM = 1                      ";

                    bindVars.Add("f_value", e.ChangeValue.ToString().Trim());
                    DataTable retDt = Service.ExecuteDataTable(cmdText, bindVars);

                    if (retDt.Rows.Count <= 0)
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダコードが正確ではないです。 確認してください。" : "항목코드가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        grdOCS0122.SetItemValue(e.RowNumber, "hangmog_name", retDt.Rows[0]["hangmog_name"].ToString());
                        grdOCS0122.SetItemValue(e.RowNumber, "jaego_qty", 1);
                        grdOCS0122.SetItemValue(e.RowNumber, "ord_danui", retDt.Rows[0]["ord_danui"].ToString());
                        grdOCS0122.SetItemValue(e.RowNumber, "subul_danui", retDt.Rows[0]["subul_danui"].ToString());
                        grdOCS0122.SetItemValue(e.RowNumber, "subul_danui_name", retDt.Rows[0]["subul_danui_name"].ToString());
                        grdOCS0122.SetItemValue(e.RowNumber, "subul_buseo", retDt.Rows[0]["subul_buseo"].ToString());
                        grdOCS0122.SetItemValue(e.RowNumber, "subul_buseo_name", retDt.Rows[0]["subul_buseo_name"].ToString());
                    }
                    break;
                default:
                    break;
            }
        }

        private void grdOCS0122_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0122.SetBindVarValue("f_buseo_code", fbxBuseo_code.GetDataValue());
            grdOCS0122.SetBindVarValue("f_hosp_code",  mHospCode);
        }

        private void grdOCS0122_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            isgrdOCS0122Save = e.IsSuccess;
            issaved0122 = true;

            if (issaved0122)
            {
                if (isgrdOCS0122Save)
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
                    SetMsg(mbxMsg);
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다.";
                    mbxMsg = mbxMsg + Service.ErrMsg;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }

                isgrdOCS0122Save = false;
                issaved0122 = false;
            }
        }

        private void grdOCS0122_SaveStarting(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            //grdOCS0122
            string buseo_code = fbxBuseo_code.GetDataValue().Trim();

            for (int rowIndex = 0; rowIndex < grdOCS0122.RowCount; rowIndex++)
            {
                if (grdOCS0122.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0122.GetItemString(rowIndex, "hangmog_name").Trim() == "")
                    {
                        grdOCS0122.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }

                    grdOCS0122.SetItemValue(rowIndex, "buseo_code", buseo_code);
                }
            }
        }
        #endregion

        #region [Button List]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    break;
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
                    if (chkCell.RowNumber < 0)
                    {
                        int insertRow = grdOCS0122.InsertRow(grdOCS0122.CurrentRowNumber);

                        //grdOCS0122
                        string buseo_code = fbxBuseo_code.GetDataValue().Trim();
                        grdOCS0122.SetItemValue(insertRow, "buseo_code", buseo_code);
                        grdOCS0122.SetItemValue(insertRow, "jaego_qty", 1);
                    }
                    else
                    {
                        e.IsBaseCall = false;
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    }
                    break;
                case FunctionType.Update:
                    break;
                case FunctionType.Delete:
                    break;
                default:
                    break;
            }
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

        #region [XSavePerformer Class]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0122U00 parent = null;

            public XSavePerformer(OCS0122U00 parent)
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
                        cmdText = @"INSERT INTO OCS0122
                                         (  SYS_DATE
                                          , SYS_ID
                                          , BUSEO_CODE
                                          , HANGMOG_CODE
                                          , JAEGO_QTY
                                          , HOSP_CODE
                                         )
                                    VALUES
                                         (  SYSDATE
                                          , :f_user_id
                                          , :f_buseo_code
                                          , :f_hangmog_code
                                          , :f_jaego_qty
                                          , :f_hosp_code
                                         )";
                        break;
                    case DataRowState.Modified:
                        cmdText = @"UPDATE OCS0122
                                       SET UPD_ID       = :f_user_id
                                         , UPD_DATE     = SYSDATE
                                         , JAEGO_QTY    = :f_jaego_qty  
                                     WHERE BUSEO_CODE   = :f_buseo_code 
                                       AND HANGMOG_CODE = :f_hangmog_code
                                       AND HOSP_CODE    = :f_hosp_code";
                        break;
                    case DataRowState.Deleted:
                        cmdText = @"DELETE OCS0122
                                     WHERE HANGMOG_CODE = :f_hangmog_code
                                       AND HOSP_CODE    = :f_hosp_code";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

    }
}

