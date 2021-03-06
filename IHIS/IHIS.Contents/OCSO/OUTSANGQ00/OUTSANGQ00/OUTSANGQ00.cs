using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCSO.Properties;

namespace IHIS.OCSO
{
    public partial class OUTSANGQ00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";

        //입원,외래구분
        private string mIO_gubun = "O";
        //등록번호
        private string mBunho = "";
        //진료과
        private string mGwa = "";
        //기준일자
        private string mNaewon_date = "";
        //phy8003data
        private DataTable mInDataRow;
        //全体選択可否
        private string mAllSelect = "N";
        //진료과 layout
        IHIS.Framework.MultiLayout layoutGwa = new MultiLayout();

        //hospital code
        private string mHospCode = EnvironInfo.HospCode;

        #endregion

        public OUTSANGQ00()
        {
            InitializeComponent();

            grdOutSang.ParamList = new List<string>(new String[] { "f_gwa", "f_io_gubun", "f_all_sang_yn", "f_bunho", "f_gijun_date" });

            grdOutSang.ExecuteQuery = LoadDataGrdOutSang;

            //TODO disable IN Hospital Tab MED-5790
            rbtIn.Visible = false;
            rbtOut.Width = 192;
        }

        #region [Screen Event]

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 타Screen에서 Open (Command)
        public override object Command(string command, CommonItemCollection commandParam)
        {
            // Command Event Parameter : commandParam을 기억해둔다.(Command Event에서 처리못하는 케이스에서 사용됨(ScreenOpen(Response)후 바로 아래에서 로직 기술해야되는경우)
            //this.mCommand = command; this.mCommandParam = commandParam; 

            int insertRow;
            int currentRow;
            string display_sang_name;

            switch (command.Trim())
            {
                case "CHT0115Q00": // 수식어정보

                    if (commandParam.Contains("CHT0115") && (MultiLayout)commandParam["CHT0115"] != null &&
                        ((MultiLayout)commandParam["CHT0115"]).RowCount > 0)
                    {
                        if (this.grdOutSang.CurrentRowNumber >= 0)
                        {
                            this.grdOutSang.Focus();
                            this.grdOutSang.SetFocusToItem(this.grdOutSang.CurrentRowNumber, "sang_code");

                            foreach (XEditGridCell cell in grdOutSang.CellInfos)
                            {
                                if (((MultiLayout)commandParam["CHT0115"]).LayoutItems.Contains(cell.CellName))
                                    grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, cell.CellName, ((MultiLayout)commandParam["CHT0115"]).GetItemString(0, cell.CellName));
                            }

                            //display 상병명
                            display_sang_name = grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "pre_modifier_name")
                                + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_name")
                                + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "post_modifier_name");
                            grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "display_sang_name", display_sang_name);

                            grdOutSang.Refresh();


                        }
                    }
                    break;

                case "CHT0110Q01": // 상병조회

                    if (commandParam.Contains("CHT0110") && (MultiLayout)commandParam["CHT0110"] != null &&
                        ((MultiLayout)commandParam["CHT0110"]).RowCount > 0)
                    {
                        currentRow = this.grdOutSang.CurrentRowNumber;
                        this.grdOutSang.Focus();

                        foreach (DataRow row in ((MultiLayout)commandParam["CHT0110"]).LayoutTable.Rows)
                        {
                            if (currentRow >= 0)
                            {
                                this.grdOutSang.SetItemValue(currentRow, "sang_code", row["sang_code"]);
                                this.grdOutSang.SetItemValue(currentRow, "sang_name", row["sang_name"]);

                                display_sang_name = grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "pre_modifier_name")
                                    + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_name")
                                    + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "post_modifier_name");
                                grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "display_sang_name", display_sang_name);

                                grdOutSang.Refresh();
                                currentRow = -1;
                            }
                            else
                            {
                                insertRow = this.grdOutSang.InsertRow(this.grdOutSang.CurrentRowNumber);
                                this.grdOutSang.SetItemValue(insertRow, "bunho", pbxSearch.BunHo);
                                this.grdOutSang.SetItemValue(insertRow, "gwa", tvwGwa.SelectedNode.Tag.ToString());
                                this.grdOutSang.SetItemValue(insertRow, "naewon_date", this.dtpNaewon_Date.GetDataValue());
                                this.grdOutSang.SetItemValue(insertRow, "sang_start_date", this.dtpNaewon_Date.GetDataValue());
                                this.grdOutSang.SetItemValue(insertRow, "sang_code", row["sang_code"]);
                                this.grdOutSang.SetItemValue(insertRow, "sang_name", row["sang_name"]);
                                this.grdOutSang.SetItemValue(insertRow, "display_sang_name", row["sang_name"]);
                            }
                        }

                        this.grdOutSang.AcceptData();
                    }

                    break;

                case "OCS0204Q00": // 사용자 약속상병조회					

                    #region
                    if (commandParam.Contains("OCS0205") && (MultiLayout)commandParam["OCS0205"] != null &&
                        ((MultiLayout)commandParam["OCS0205"]).RowCount > 0)
                    {
                        currentRow = this.grdOutSang.CurrentRowNumber;
                        this.grdOutSang.Focus();

                        foreach (DataRow row in ((MultiLayout)commandParam["OCS0205"]).LayoutTable.Rows)
                        {
                            if (currentRow >= 0)
                            {
                                insertRow = currentRow;
                                currentRow = -1;
                            }
                            else
                            {
                                insertRow = this.grdOutSang.InsertRow(this.grdOutSang.CurrentRowNumber);
                                this.grdOutSang.SetItemValue(insertRow, "bunho", pbxSearch.BunHo);
                                this.grdOutSang.SetItemValue(insertRow, "gwa", tvwGwa.SelectedNode.Tag.ToString());
                                this.grdOutSang.SetItemValue(insertRow, "naewon_date", this.dtpNaewon_Date.GetDataValue());
                                this.grdOutSang.SetItemValue(insertRow, "sang_start_date", this.dtpNaewon_Date.GetDataValue());
                            }

                            foreach (XEditGridCell cell in grdOutSang.CellInfos)
                            {
                                if (((MultiLayout)commandParam["OCS0205"]).LayoutItems.Contains(cell.CellName))
                                    grdOutSang.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                            }

                            //display 상병명
                            display_sang_name = grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "pre_modifier_name")
                                + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_name")
                                + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "post_modifier_name");
                            grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "display_sang_name", display_sang_name);

                            grdOutSang.Refresh();
                        }

                        this.grdOutSang.AcceptData();
                    }

                    break;
                    #endregion


            }

            return base.Command(command, commandParam);
        }
        #endregion
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnLoad(EventArgs e)
        {
            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("io_gubun"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["io_gubun"].ToString()))
                            mIO_gubun = OpenParam["io_gubun"].ToString();
                    }

                    if (OpenParam.Contains("bunho"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["bunho"].ToString()))
                            mBunho = OpenParam["bunho"].ToString();
                    }

                    if (OpenParam.Contains("gwa"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["gwa"].ToString()))
                            mGwa = OpenParam["gwa"].ToString();
                    }

                    if (OpenParam.Contains("naewon_date"))
                    {
                        if (!TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                            mNaewon_date = OpenParam["naewon_date"].ToString();
                    }
                    if (OpenParam.Contains("phy8003"))
                        this.mInDataRow = (DataTable)OpenParam["phy8003"];

                    if (OpenParam.Contains("nut0002"))
                        this.mInDataRow = (DataTable)OpenParam["nut0002"];

                    if (OpenParam.Contains("AllSelect"))
                    {
                        this.mAllSelect = OpenParam["AllSelect"].ToString();
                        this.chkAll.Checked = true;
                    }


                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void SetInitialOrderGridData(DataTable aInData)
        {
            if (this.mInDataRow != null)
            {
                for (int i = 0; i < this.grdOutSang.RowCount; i++)
                {
                    for (int j = 0; j < this.mInDataRow.Rows.Count; j++)
                    {
                        if (this.grdOutSang.GetItemString(i, "pkoutsang") == this.mInDataRow.Rows[j]["fkoutsang"].ToString())
                        {
                            this.grdOutSang.SetItemValue(i, "select", "Y");
                            break;
                        }
                    }
                }
            }
            this.grdOutSang.ResetUpdate();
        }

        private void PostLoad()
        {
            if (mIO_gubun == "O")
                this.rbtOut.Checked = true;
            else
                this.rbtIn.Checked = true;

            if (TypeCheck.IsNull(mGwa))
                mGwa = UserInfo.Gwa;

            if (!TypeCheck.IsDateTime(mNaewon_date))
                mNaewon_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            dtpNaewon_Date.SetDataValue(mNaewon_date);

            if (TypeCheck.IsNull(mBunho))
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null)
                {
                    this.pbxSearch.SetPatientID(patientInfo.BunHo);
                }

            }
            else
                this.pbxSearch.SetPatientID(mBunho);

            ShowGwa();

            //insert by jc [傷病を他の画面から取得できるようにする] 2012/10/19
            CreateLayout();

        }

        private void CreateLayout()
        {
            layReturnValue = grdOutSang.CloneToLayout();
        }

        #endregion

        #region [Control]

        private void dtpNaewon_Date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.LoadData();
        }

        private void rbtOut_CheckedChanged(object sender, System.EventArgs e)
        {
            //외래
            if (rbtOut.Checked)
            {
                rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtOut.ImageIndex = 6;

                rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtIn.ImageIndex = 5;

            }
            //입원
            else
            {
                rbtIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtIn.ImageIndex = 6;

                rbtOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtOut.ImageIndex = 5;
            }

            LoadData();

        }

        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {

            if (chkAll.Checked)
            {
                chkAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkAll.ImageIndex = 6;

                dtpNaewon_Date.Enabled = false;
            }
            else
            {
                chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkAll.ImageIndex = 5;

                dtpNaewon_Date.Enabled = true;
            }

            LoadData();
        }

        #endregion

        #region [ButtonList]

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    LoadData();

                    break;

                default:

                    break;
            }
        }

        #endregion		

        #region 환자번호입력시
        private void pbxSearch_PatientSelected(object sender, System.EventArgs e)
        {
            ControlClear();

            if (!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
                LoadData();
        }

        private void pbxSearch_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            ControlClear();
        }


        #endregion		

        #region [Function]

        /// <summary>
        /// Control정보 Reset
        /// </summary>
        private void ControlClear()
        {
            //this.tvwGwa.Nodes.Clear();
            this.grdOutSang.Reset();
        }


        #endregion

        #region [TreeView 진료과]

        private void CreateGwaData()
        {
            layoutGwa.Reset();
            layoutGwa.LayoutItems.Clear();
            layoutGwa.LayoutItems.Add("gwa", DataType.String);
            layoutGwa.LayoutItems.Add("gwa_name", DataType.String);
            layoutGwa.InitializeLayoutTable();

//            layoutGwa.QuerySQL = @"SELECT A.GWA, A.BUSEO_NAME
//                                     FROM BAS0260 A
//                                    WHERE A.OUT_JUBSU_YN = 'Y'
//                                      AND A.HOSP_CODE    = '" + mHospCode + @"'
//                                      AND A.BUSEO_NAME != 'ICM'
//                                      AND A.START_DATE   = (SELECT MAX(B.START_DATE)              
//                                                              FROM BAS0260 B                     
//                                                             WHERE B.BUSEO_CODE  = A.BUSEO_CODE   
//                                                               AND B.START_DATE <= TRUNC(SYSDATE)
//                                                               AND B.HOSP_CODE   = A.HOSP_CODE  )
//                                   UNION
//                                   SELECT '%' AS GWA, '全体' AS BUSEO_NAME 
//                                   FROM DUAL   
//                                   ORDER BY GWA";

            layoutGwa.ExecuteQuery = LoadDataLayoutGwa;

            layoutGwa.QueryLayout(true);
        }


        private void ShowGwa()
        {
            tvwGwa.Nodes.Clear();
            //외래접수가능한 과를 기준으로 생성
            CreateGwaData();
            if (this.layoutGwa.RowCount < 1) return;

            TreeNode node;

            foreach (DataRow row in layoutGwa.LayoutTable.Rows)
            {
                node = new TreeNode(row["gwa_name"].ToString());
                node.Tag = row["gwa"].ToString();
                tvwGwa.Nodes.Add(node);
            }

            //リハビリ依頼書から呼び出された時にはデフォルト「全体」にする。
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;
            if (scrOpener.ScreenID == "PHY8002U00" || scrOpener.ScreenID == "PHY8002U01" || scrOpener.ScreenID == "NUT0001U00")
            {
                if (tvwGwa.SelectedNode == null)
                    tvwGwa.SelectedNode = tvwGwa.Nodes[0];
                return;
            }
            
            //해당 사용자의 진료과 선택
            foreach (TreeNode nodeGwa in tvwGwa.Nodes)
            {
                if (mGwa == nodeGwa.Tag.ToString())
                {
                    tvwGwa.SelectedNode = nodeGwa;
                    break;
                }
            }

            if (tvwGwa.SelectedNode == null)
                tvwGwa.SelectedNode = tvwGwa.Nodes[0];

        }

        private void tvwGwa_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            LoadData();
        }

        #endregion

        #region [Data Load]

        private void LoadData()
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;


                if (tvwGwa.SelectedNode != null) this.grdOutSang.SetBindVarValue("f_gwa", tvwGwa.SelectedNode.Tag.ToString());

                if (rbtOut.Checked)
                    this.grdOutSang.SetBindVarValue("f_io_gubun", "O");
                else
                    this.grdOutSang.SetBindVarValue("f_io_gubun", "I");

                if (chkAll.Checked)
                    this.grdOutSang.SetBindVarValue("f_all_sang_yn", "Y");
                else
                    this.grdOutSang.SetBindVarValue("f_all_sang_yn", "N");

                this.grdOutSang.SetBindVarValue("f_bunho", pbxSearch.BunHo);
                this.grdOutSang.SetBindVarValue("f_gijun_date", dtpNaewon_Date.GetDataValue());
                this.grdOutSang.SetBindVarValue("f_hosp_code", mHospCode);

                this.grdOutSang.QueryLayout(true);
            }
            finally
            {
                SetMsg(" ");
                this.SetInitialOrderGridData(this.mInDataRow);
                Cursor.Current = System.Windows.Forms.Cursors.Default;

            }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        #region [상병입력 Grid Event]

        #region  필드 색상/폰트 관리 Event (GridCellPainting)
        /// <remarks>
        /// 로직으로 필드 색상 변경
        /// </remarks>
        private void grdOutSang_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            // 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
            // ReadOnly인 경우 
            if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly))
            {
                //e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
                e.BackColor = XColor.XDisplayBoxBackColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
            }
            else
            {
                // 상병종료일이 입력되지 않은 경우는 종료사유 입력 불가
                switch (e.ColName)
                {
                    case "display_sang_name": // Display 상병명
                        // 직접입력가능 상병코드인 경우는 상병명 직접입력가능(상병코드 : OCS.OrderVariables.WORD_SANG_CODE)
                        //if (!this.mOrderBiz.IsDirectInputSangName(grd.GetItemString(e.RowNumber, "sang_code")))
                        if (e.DataRow["sang_code"].ToString().Trim() != "0000999" && e.DataRow["sang_code"].ToString().Trim() != "")
                        {
                            //e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = XColor.XDisplayBoxBackColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;						
                        }

                        break;

                    case "sang_end_sayu": // 상병종료사유
                        if (TypeCheck.IsNull(grd.GetItemValue(e.RowNumber, "sang_end_date")))
                        {
                            //e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = XColor.XDisplayBoxBackColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
                        }
                        break;
                }
            }

        }
        #endregion

        private void btnProcess_Click(object sender, EventArgs e)
        {
            CreateReturnValue();
        }

        /// <summary>
        /// 선택한정보를 layReturnValue로 생성합니다.		
        /// </summary>
        private void CreateReturnValue()
        {
            this.AcceptData();

            BackSelectRow();

            if (layReturnValue.RowCount < 1)
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.TEXT1 : Resources.TEXT2;
                mbxCap = NetInfo.Language == LangMode.Jr ? Resources.TEXT3 : Resources.TEXT4;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("OUTSANG", layReturnValue);
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }

        /// <summary>
        /// 해당 Grid가 다시 load되기 전에 선택된 row를 backup
        /// </summary>
        private void BackSelectRow()
        {
            this.AcceptData();

            foreach (DataRow row in grdOutSang.LayoutTable.Rows)
            {
                if (row["select"].ToString() == "Y")
                    layReturnValue.LayoutTable.ImportRow(row);
            }
        }
        #endregion

        private void grdOutSang_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            int currRow = grd.GetHitRowNumber(e.Y);
            string currColName = grd.CurrentColName;

            if (currRow < 0)
                return;

            //選択された傷病が有効であるのかをチェック。厚労省のSTART_DATEと患者傷病のSANG_START_DATEのチェック。
            if (currColName == "select" || e.Clicks == 2)
            {
                if (!IsEnableSangCode(grd, currRow))
                    return;

                if (e.Clicks == 2)
                {
                    grd.SetItemValue(currRow, "select", "Y");
                    this.btnProcess.PerformClick();
                }

            }
        }

        public bool IsEnableSangCode(XEditGrid grd, int currRow)
        {
            bool result = true;
//            string cmd = @" 
//                                SELECT TO_CHAR(A.SANG_START_DATE, 'YYYY/MM/DD') SANG_START_DATE
//                                     , TO_CHAR(B.START_DATE, 'YYYY/MM/DD') START_DATE
//                                  FROM OUTSANG A
//                                      ,CHT0110 B
//                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                   AND A.PKOUTSANG = :f_pkoutsang
//                                   AND A.BUNHO     = :f_bunho                                   
//                                   AND B.HOSP_CODE = A.HOSP_CODE
//                                   AND B.SANG_CODE = A.SANG_CODE
//                                   --AND B.START_DATE > A.SANG_START_DATE 
//                              ";
//            BindVarCollection bindvar = new BindVarCollection();
//            bindvar.Add("f_hosp_code", EnvironInfo.HospCode);
//            bindvar.Add("f_pkoutsang", grd.GetItemString(currRow, "pkoutsang"));
//            bindvar.Add("f_bunho", this.pbxSearch.BunHo);


//            //object obj = Service.ExecuteScalar(cmd, bindvar);
//            DataTable dt = Service.ExecuteDataTable(cmd, bindvar);

            OUTSANGQ00IsEnableSangCodeArgs args = new OUTSANGQ00IsEnableSangCodeArgs();
            args.Bunho = this.pbxSearch.BunHo;
            args.Pkoutsang = grd.GetItemString(currRow, "pkoutsang");
            OUTSANGQ00IsEnableSangCodeResult cloudResult =
                CloudService.Instance.Submit<OUTSANGQ00IsEnableSangCodeResult, OUTSANGQ00IsEnableSangCodeArgs>(args);

            //if (dt != null)
            if (cloudResult.ExecutionStatus == ExecutionStatus.Success && cloudResult.ListItem != null && cloudResult.ListItem.Count > 0)
            {
                //if (DateTime.Parse(dt.Rows[0]["SANG_START_DATE"].ToString()) < DateTime.Parse(dt.Rows[0]["START_DATE"].ToString()))
                if (DateTime.Parse(cloudResult.ListItem[0].SangStartDate) < DateTime.Parse(cloudResult.ListItem[0].StartDate))
                {
                    //XMessageBox.Show(Resources.TEXT5 + dt.Rows[0]["SANG_START_DATE"].ToString() + Resources.TEXT6 + dt.Rows[0]["START_DATE"].ToString() + "」", Resources.TEXT3);
                    XMessageBox.Show(Resources.TEXT5 + cloudResult.ListItem[0].SangStartDate + Resources.TEXT6 + cloudResult.ListItem[0].StartDate + "」", Resources.TEXT3);
                    result = false;
                }

            }
            else
                result = false;

            return result;
        }
      
        ///////////////////////////////////////////////////////////////////////////////////////////////////////		

        #region CloudService

        private List<object[]> LoadDataGrdOutSang(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OUTSANGQ00GrdOutSangArgs args = new OUTSANGQ00GrdOutSangArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            args.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            args.AllSangYn = bc["f_all_sang_yn"] != null ? bc["f_all_sang_yn"].VarValue : "";
            args.GijunDate = bc["f_gijun_date"] != null ? bc["f_gijun_date"].VarValue : "";
            OUTSANGQ00GrdOutSangResult result =
                CloudService.Instance.Submit<OUTSANGQ00GrdOutSangResult, OUTSANGQ00GrdOutSangArgs>(
                    args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OUTSANGQ00GrdOutSangInfo item in result.ListItem)
                {
                    object[] objects =
                    {
                        item.Bunho,
                        item.Gwa,
                        item.GwaName,
                        item.IoGubun,
                        item.PkSeq,
                        item.NaewonDate,
                        item.Doctor,
                        item.NaewonType,
                        item.JubsuNo,
                        item.Fkinp1001,
                        item.InputId,
                        item.SangCode,
                        item.SangName,
                        item.DisSangName,
                        item.JuSangYn,
                        item.SangStartDate,
                        item.SangEndDate,
                        item.SangEndSayu,
                        item.SangEndSayuName,
                        item.Ser,
                        item.PreModifier1,
                        item.PreModifier2,
                        item.PreModifier3,
                        item.PreModifier4,
                        item.PreModifier5,
                        item.PreModifier6,
                        item.PreModifier7,
                        item.PreModifier8,
                        item.PreModifier9,
                        item.PreModifier10,
                        item.PreModifierName,
                        item.PostModifier1,
                        item.PostModifier2,
                        item.PostModifier3,
                        item.PostModifier4,
                        item.PostModifier5,
                        item.PostModifier6,
                        item.PostModifier7,
                        item.PostModifier8,
                        item.PostModifier9,
                        item.PostModifier10,
                        item.PostModifierName,
                        item.Selected,
                        item.Pkoutsang,
                        item.SangJindanDate,
                        item.ContKey
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataLayoutGwa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OUTSANGQ00LayoutGwaArgs args = new OUTSANGQ00LayoutGwaArgs();
            ComboResult result =
                CacheService.Instance.Get<OUTSANGQ00LayoutGwaArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }

            return res;
        }

        #endregion


        

    }
}