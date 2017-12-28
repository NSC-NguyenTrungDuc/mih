using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;

namespace IHIS.BASS
{
    public partial class BAS0310P01 : XScreen
    {
        public BAS0310P01()
        {
            InitializeComponent();
        }

        #region Screen 사용 변수

        private QueryType mCurrentType;
        private XEditGrid mCurrentGrid;
        private MultiLayout mUpdateLayout;

        private string mUpdateProcName = "";
        private string mProcGubun = "";
        
        // TRUE : Test Table 사용, FALSE : 운영 Table 사용
        private Boolean mIsTestTable = false;

        private string mMsg = "";
        private string mCap = "";
        private int pageSize = 20000;
        private int currentpage = 1;

        #endregion

        #region Screen Open 이벤트

        private void BAS0310P01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            grdSangMaster.ParamList= new List<string>();
            grdSangMaster.ExecuteQuery = LoadDataGrdSangMaster;
            grdSusikMaster.ParamList= new List<string>();
            grdSusikMaster.ExecuteQuery = LoadDataGrdSusikMaster;
            grdDrugMaster.ParamList= new List<string>();
            grdDrugMaster.ExecuteQuery = LoadDataGrdDrugMaster;
            grdTokuteiMaster.ParamList= new List<string>();
            grdTokuteiMaster.ExecuteQuery = LoadDataGrdTokuteiMaster;
            grdJinryoMaster.ParamList= new List<string>();
            grdJinryoMaster.ExecuteQuery = LoadDataGrdJinryoMaster;
            grdJojeMaster.ParamList= new List<string>();
            grdJojeMaster.ExecuteQuery = LoadDataGrdJojeMaster;
            grdGenDrgMaster.ParamList= new List<string>();
            grdGenDrgMaster.ExecuteQuery = LoadDataGrdGenDrgMaster;
            grdGenDrgMap.ParamList= new List<string>();
            grdGenDrgMap.ExecuteQuery = LoadDataGrdGenDrgMap;
            grdDrgSakura.ParamList= new List<string>();
            grdDrgSakura.ExecuteQuery = LoadDataGrdDrgSakura;
            grdYJCode.ParamList= new List<string>();
            grdYJCode.ExecuteQuery = LoadDataGrdYJCode;
            // 오픈 이벤트
            // 최초 선택되는 항목은 상병마스터이다.
            this.tsbByouMei.PerformClick();
        }

        #endregion

        #region 각종 Method

        private void SetCurrentText(string aText)
        {
            this.lbCurrentText.Text = "【" + aText + "】";
        }

        #endregion

        #region 파일 읽기 관련 

        private bool GetSourceFilePath(ref string aFilePath, ref string aFileName)
        {
            this.ofdFileSearch.Reset();
            aFilePath = "";
            aFileName = "";

            DialogResult result = this.ofdFileSearch.ShowDialog();

            if (result != DialogResult.OK)
                return false;

            if (this.ofdFileSearch.FileName.Length <= 0) return false;

            string [] temp  = this.ofdFileSearch.FileName.Split('\\');

            for (int i = 0; i < temp.Length; i++)
            {
                if (i == temp.Length - 1)
                {
                    aFileName = temp[i];
                }
                else
                {
                    aFilePath += temp[i] + @"\";
                }
            }

            return true;
        }

        private bool ReadFile(string aFilePath, string aFileName)
        {
            StreamReader sr = new StreamReader(aFilePath + aFileName, Encoding.GetEncoding("Shift-JIS"));
            string line = "";
            string defaultText = Resources.MSG_001;// "データをロードしています。";
            string[] data;
            DataRow dtRow;
            int cnt = 0;
            int errCnt = 0;
            ArrayList errRow = new ArrayList();
            string progressText = "";

            this.InitProgressBar(0, 0);
            this.SetProgressBarVisible(true, false, true);



            try
            {
                mUpdateLayout = this.mCurrentGrid.CloneToLayout();

                while ((line = sr.ReadLine()) != null)
                {
                    cnt++;
                    switch (this.mCurrentType)
                    {
                        case QueryType.YJCode:
                        case QueryType.DrgSakura:
                            if (cnt == 1)
                            { // 1st row is header
                                continue;
                            }
                            break;

                        default :
                            break;
                    }

                    progressText = cnt.ToString() + Resources.MSG_002 + defaultText;

                    // 50건 단위로 프로그래스바 표시
                    if (cnt % 50 == 0)
                        this.SetProgressValue(cnt, progressText);

                    data = line.Split(new char[] { ',' });

                    if (data.Length == mUpdateLayout.LayoutTable.Columns.Count)
                    {
                        dtRow = mUpdateLayout.LayoutTable.NewRow();
                        for (int i = 0; i < data.Length; i++)
                        {

                            dtRow[i] = data[i].Trim().Replace("\"", "");
                        }

                        mUpdateLayout.LayoutTable.Rows.Add(dtRow);
                    }
                    else
                    {
                        errCnt += 1;
                        errRow.Add(cnt);
                    }
                }
            }
            finally
            {
                this.SetProgressBarVisible(false, false, false);
            }

            if (errCnt != 0)
            {
                int concatCnt = 0;

                this.mCap = NetInfo.Language == LangMode.Ko ? "데이터로드실패" : "データロード失敗";
                this.mMsg = NetInfo.Language == LangMode.Ko ? "파일로드중 에러가 발생하였습니다." : "ファイルロード中エーラが発生しました。確認して下さい。";
                this.mMsg += "\n========================================================================\n";
                foreach (object err in errRow)
                {
                    concatCnt += 1;
                    this.mMsg += ((int)err).ToString() +
                                 (NetInfo.Language == LangMode.Ko ? "행의 데이터 로드 실패" : "行のデータロード失敗") + "\n";

                    if (concatCnt > 30)
                    {
                        this.mMsg += "..........." + "\n";
                        break;
                    }
                }

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        #endregion

        #region Progress Bar 관련

        private void SetProgressBarVisible(bool aPanelVisible, bool aIsProgressBarVisible, bool aIsTextVisible)
        {
            this.pgbBar.Visible = aIsProgressBarVisible;
            this.lbPgText.Visible = aIsTextVisible;
            this.pnlProgress.Visible = aPanelVisible;
            this.pnlProgress.BringToFront();
        }

        private void InitProgressBar(int aMinimum, int aMaximum)
        {
            this.pgbBar.Minimum = aMinimum;
            this.pgbBar.Maximum = aMaximum;

            this.lbPgText.Text = "";
        }

        private void SetProgressValue(int aCntValue, string aText)
        {
            if (this.pgbBar.Visible)
                this.pgbBar.Value = aCntValue;
            this.lbPgText.Text = aText;

            this.pnlProgress.Refresh();
            this.pgbBar.Refresh();
            this.lbPgText.Refresh();
        }

        #endregion

        #region Update 관련

        private bool UpdateTempTable(MultiLayout aLayout)
        {
            string tableName = "";
            string cmd = "";
            int cnt = 0;
            string progressText = "";
            //string strTableKey = "";

            #region 업데이트 대상 테이블 선정

            switch (this.mCurrentType)
            {
                case QueryType.SangCode:      // 상병코드 ADM9990

                    tableName = mIsTestTable ? "ADM9990_T" : "ADM9990";

                    break;

                case QueryType.SusikCode :    // 수식어 코드 ADM9991 

                    tableName = mIsTestTable ? "ADM9991_T" : "ADM9991";

                    break;

                case QueryType.DrugCode :     // 약품 ADM9992

                    tableName = mIsTestTable ? "ADM9992_T" : "ADM9992";

                    break;

                case QueryType.JinryoCode:    // 진료행위 마스터 ADM9995

                    tableName = mIsTestTable ? "ADM9995_T" : "ADM9995";

                    break;

                case QueryType.TokuteiCode:   // 특정기재 ADM9993

                    tableName = mIsTestTable ? "ADM9993_T" : "ADM9993";

                    break;

                case QueryType.JojeCode:      // 조제료 ADM9996

                    tableName = mIsTestTable ? "ADM9996_T" : "ADM9996";

                    break;

                case QueryType.DrgSakura:      // サクラ薬マスター ADM9982

                    tableName = mIsTestTable ? "ADM9982_T" : "ADM9982";

                    break;

                case QueryType.GenDrg:        // 一般名処方マスター ADM9997

                    tableName = mIsTestTable ? "ADM9997_T" : "ADM9997";

                    break;

                case QueryType.GenDrgMap:     // 一般名処方マッピング ADM9998

                    tableName = mIsTestTable ? "ADM9998_T" : "ADM9998";

                    break;

                case QueryType.YJCode:        // YJ Code ADM9983

                    tableName = mIsTestTable ? "ADM9983_T" : "ADM9983";

                    break;

            }

            #endregion

            this.InitProgressBar(0, this.mUpdateLayout.RowCount);
            
            this.SetProgressBarVisible(true, true, true);

            #region 화면 Data를 ADM Table에 Insert 

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                Service.BeginTransaction();

                //progressText = "既存データを削除しています。。";
                //progressText = "既存データを 최신 정보로 갱신합니다.";
                progressText = "既存データを最新情報に更新します。";
                this.SetProgressValue(0, progressText);

                // 이제 업데이트 시작 
                // 최종 상태만을 관리한다.
                foreach (DataRow dr in aLayout.LayoutTable.Rows)
                {
                    cnt++;

                    // 삭제 먼저
                    // table의 unique key column은 3번째 column이다("A3")
                    // (현재 대상에서는 A3 가 모두 KEY FIEL 임 - 추가시에는 확인이 필요함)
                    // YJ Code マスターは A1 が　キーです。
                    // サクラ薬マスターは A1 が　キーです。
                    // 一般名処方マスターは A2 が　キーです。
                    // 一般名処方マッピングは A6 が　キーです。
                    //strTableKey = dr["3"].ToString().Trim();
                    switch (this.mCurrentType)
                    {
                        case QueryType.YJCode:
                        case QueryType.DrgSakura:
                            cmd = "DELETE FROM " + tableName + " WHERE A1 = '" + dr["1"].ToString().Trim() + "'";
                            break;

                        case QueryType.GenDrg:
                            cmd = "DELETE FROM " + tableName + " WHERE A2 = '" + dr["2"].ToString().Trim() + "'";
                            break;

                        case QueryType.GenDrgMap:
                            cmd = "DELETE FROM " + tableName + " WHERE A6 = '" + dr["6"].ToString().Trim() + "'";
                            break;

                        default:
                            cmd = "DELETE FROM " + tableName + " WHERE A3 = '" + dr["3"].ToString().Trim() + "'";
                            break;
                    }
                    if (Service.ExecuteNonQuery(cmd) == false)
                    {
                        // 신규의 경우 삭제대상이 없으므로 오류 무시 
                        //Service.RollbackTransaction();

                        //this.mMsg = "既存データ削除に失敗しました。- " + Service.ErrFullMsg;
                        //this.mCap = "アップデート";
                        //MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //return false;
                    }

                    // 50건 단위로 프로그래스바 표시
                    progressText = cnt.ToString() + "/" + aLayout.LayoutTable.Rows.Count.ToString();
                    if (cnt % 50 == 0)
                        this.SetProgressValue(cnt, progressText);

                    cmd = "INSERT INTO " + tableName + " ( SYS_DATE, SYS_ID ";

                    // 컬럼 생성 
                    for (int i = 0; i < aLayout.LayoutTable.Columns.Count; i++)
                    {
                        cmd += ",A" + aLayout.LayoutTable.Columns[i].ColumnName;
                    }

                    cmd += ") VALUES ( SYSDATE, '" + UserInfo.UserID + "'";

                    // 데이터생성 
                    for (int i = 0; i < aLayout.LayoutTable.Columns.Count; i++)
                    {
                        cmd += ",'" + dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString().Replace("'","''") + "'";
                    }

                    cmd += " ) ";

                    
                    if (Service.ExecuteNonQuery(cmd) == false)
                    {
                        Service.RollbackTransaction();

                        //this.mMsg = "既存データ削除に失敗しました。- " + Service.ErrFullMsg;
                        //this.mMsg = "既存データ갱신에失敗しました。- " + Service.ErrFullMsg;
                        this.mMsg = "既存データ更新に失敗しました。- " + Service.ErrFullMsg;
                        this.mMsg += "[" + dr["3"].ToString() + "] " + dr["5"].ToString();
                        this.mCap = "アップデート";
                        MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }

                }

            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.SetProgressBarVisible(false, false, false);
            }

            Service.CommitTransaction();

            #endregion 화면 Data를 ADM Table에 Insert

            return true;
        }
        /// <summary>
        /// Use for Cloud
        /// </summary>
        /// <param name="aLayout"></param>
        /// <returns></returns>
        private bool UpdateTempTableNew(MultiLayout aLayout)
        {
            currentpage = 1;
            string tableName = "";
            string cmd = "";
            int cnt = 0;
            string progressText = "";
            #region 업데이트 대상 테이블 선정

            switch (this.mCurrentType)
            {
                case QueryType.SangCode:      // 상병코드 ADM9990

                    tableName = mIsTestTable ? "ADM9990_T" : "ADM9990";

                    break;

                case QueryType.SusikCode:    // 수식어 코드 ADM9991 

                    tableName = mIsTestTable ? "ADM9991_T" : "ADM9991";

                    break;

                case QueryType.DrugCode:     // 약품 ADM9992

                    tableName = mIsTestTable ? "ADM9992_T" : "ADM9992";

                    break;

                case QueryType.JinryoCode:    // 진료행위 마스터 ADM9995

                    tableName = mIsTestTable ? "ADM9995_T" : "ADM9995";

                    break;

                case QueryType.TokuteiCode:   // 특정기재 ADM9993

                    tableName = mIsTestTable ? "ADM9993_T" : "ADM9993";

                    break;

                case QueryType.JojeCode:      // 조제료 ADM9996

                    tableName = mIsTestTable ? "ADM9996_T" : "ADM9996";

                    break;

                case QueryType.DrgSakura:      // サクラ薬マスター ADM9982

                    tableName = mIsTestTable ? "ADM9982_T" : "ADM9982";

                    break;

                case QueryType.GenDrg:        // 一般名処方マスター ADM9997

                    tableName = mIsTestTable ? "ADM9997_T" : "ADM9997";

                    break;

                case QueryType.GenDrgMap:     // 一般名処方マッピング ADM9998

                    tableName = mIsTestTable ? "ADM9998_T" : "ADM9998";

                    break;

                case QueryType.YJCode:        // YJ Code ADM9983

                    tableName = mIsTestTable ? "ADM9983_T" : "ADM9983";

                    break;

            }

            #endregion

            #region 화면 Data를 ADM Table에 Insert

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                while ((currentpage - 1) * pageSize < aLayout.LayoutTable.Rows.Count)
                {
                    BAS0310P01GrdSaveLayArgs args = new BAS0310P01GrdSaveLayArgs();
                    args.TableName = tableName;
                    args.CurrentType = mCurrentType.ToString();
                    args.UserId = UserInfo.UserID;
                    args.Dt = PrepareInsert(aLayout);

                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, BAS0310P01GrdSaveLayArgs>(args);
                    if (!TypeCheck.IsNull(result.Msg))
                    {
                        this.mMsg = Resources.MSG_003; // "既存データ更新に失敗しました。- ";
                        this.mMsg += result.Msg; //"[" + dr["3"].ToString() + "] " + dr["5"].ToString();
                        this.mCap = Resources.MSG_004; // "アップデート";
                        MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }


                    if (result == null || result.ExecutionStatus != ExecutionStatus.Success ||
                        result.Result == false)
                    {
                        return false;
                    }
                    currentpage ++;
                }
                return true;

            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.SetProgressBarVisible(false, false, false);
            }

            #endregion 화면 Data를 ADM Table에 Insert


        }

        #endregion 
        
        #region OLD Update 관련
        
        private bool UpdateTempTableOLD(MultiLayout aLayout)
        {
            string tableName = "";
            string cmd = "";
            int cnt = 0;
            string progressText = "";

            #region 업데이트 대상 테이블 선정

            switch (this.mCurrentType)
            {
                case QueryType.SangCode:      // 상병코드 ADM9990

                    tableName = "ADM9990";

                    break;

                case QueryType.SusikCode :    // 수식어 코드 ADM9991 

                    tableName = "ADM9991";

                    break;

                case QueryType.DrugCode :     // 약품 ADM9992

                    tableName = "ADM9992";

                    break;

                case QueryType.JinryoCode:    // 진료행위 마스터 ADM9995

                    tableName = "ADM9995";

                    break;

                case QueryType.TokuteiCode:   // 특정기재 ADM9993

                    tableName = "ADM9993";

                    break;

                case QueryType.JojeCode :

                    tableName = "ADM9996";

                    break;

            }

            #endregion

            this.InitProgressBar(0, this.mUpdateLayout.RowCount);
            this.SetProgressBarVisible(true, true, true);

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // 삭제 먼저
                cmd = "DELETE FROM " + tableName;

                Service.BeginTransaction();

                progressText = "既存データを削除しています。。";
                this.SetProgressValue(0, progressText);

                if (Service.ExecuteNonQuery(cmd) == false)
                {
                    //Service.RollbackTransaction();

                    //this.mMsg = "既存データ削除に失敗しました。- " + Service.ErrFullMsg;
                    //this.mCap = "アップデート";
                    //MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //return false;
                }

                
                // 이제 업데이트 시작 
                foreach (DataRow dr in aLayout.LayoutTable.Rows)
                {
                    cnt++;

                    // 100건 단위로 프로그래스바 표시
                    progressText = cnt.ToString() + "/" + aLayout.LayoutTable.Rows.Count.ToString();
                    if (cnt % 100 == 0)
                        this.SetProgressValue(cnt, progressText);

                    cmd = "INSERT INTO " + tableName + " ( SYS_DATE, SYS_ID ";

                    // 컬럼 생성 
                    for (int i = 0; i < aLayout.LayoutTable.Columns.Count; i++)
                    {
                        cmd += ",A" + aLayout.LayoutTable.Columns[i].ColumnName;
                    }

                    cmd += ") VALUES ( SYSDATE, '" + UserInfo.UserID + "'";

                    // 데이터생성 
                    for (int i = 0; i < aLayout.LayoutTable.Columns.Count; i++)
                    {
                        cmd += ",'" + dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString() + "'";
                    }

                    cmd += " ) ";

                    
                    if (Service.ExecuteNonQuery(cmd) == false)
                    {
                        Service.RollbackTransaction();

                        this.mMsg = "既存データ削除に失敗しました。- " + Service.ErrFullMsg;
                        this.mMsg += "[" + dr["3"].ToString() + "] " + dr["5"].ToString();
                        this.mCap = "アップデート";
                        MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }

                }

            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.SetProgressBarVisible(false, false, false);
            }

            Service.CommitTransaction();

            return true;
        }

        #endregion

        #region Control 이벤트

        #region Tool Bar 버튼 이벤트

        private void toolBarButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;

            // 현재 그리드 전체 리셋
            foreach (object cnt in this.Controls)
            {
                if (cnt is XEditGrid)
                {
                    ((XEditGrid)cnt).Reset();
                    ((XEditGrid)cnt).Visible = false;
                }
            }

            switch (button.Name)
            {
                case "tsbByouMei":      // 병명마스터
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.SangCode;
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_SANG";
                    this.mProcGubun = "";
                    this.SetCurrentText(Resources.MSG_005);    

                    this.mCurrentGrid = this.grdSangMaster;
                    this.grdSangMaster.Visible = true;
                    this.grdSangMaster.Dock = DockStyle.Fill;
                    
                    break;

                case "tsbSusikCode":    // 수식어마스터
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.SusikCode;
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_SUSIK";
                    this.mProcGubun = "";
                    this.SetCurrentText(Resources.MSG_006);

                    this.mCurrentGrid = this.grdSusikMaster;
                    this.grdSusikMaster.Visible = true;
                    this.grdSusikMaster.Dock = DockStyle.Fill;

                    break;

                case "tsbDrugCode":     // 약품마스터
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.DrugCode;
                    //this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_DRUG";
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_COM";
                    this.mProcGubun = "DRG";
                    this.SetCurrentText(Resources.MSG_007);

                    this.mCurrentGrid = this.grdDrugMaster;
                    this.grdDrugMaster.Visible = true;
                    this.grdDrugMaster.Dock = DockStyle.Fill;

                    break;

                case "tsbJinryoHangwi": // 진료행위마스터
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.JinryoCode;
                    //this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_JINRYO";
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_COM";
                    this.mProcGubun = "JIN";
                    this.SetCurrentText(Resources.MSG_008);

                    this.mCurrentGrid = this.grdJinryoMaster;
                    this.grdJinryoMaster.Visible = true;
                    this.grdJinryoMaster.Dock = DockStyle.Fill;

                    break;

                case "tsbTokuteiCode":  // 특정기재마스터
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.TokuteiCode;
                    //this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_SPECIAL";
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_COM";
                    this.mProcGubun = "SPC";
                    this.SetCurrentText(Resources.MSG_009);

                    this.mCurrentGrid = this.grdTokuteiMaster;
                    this.grdTokuteiMaster.Visible = true;
                    this.grdTokuteiMaster.Dock = DockStyle.Fill;

                    break;

                case "tsbJoje":  // 조제행위
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.JojeCode;
                    //this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_JOJE";
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_COM";
                    this.mProcGubun = "JOJ";
                    this.SetCurrentText(Resources.MSG_010);

                    this.mCurrentGrid = this.grdJojeMaster;
                    this.grdJojeMaster.Visible = true;
                    this.grdJojeMaster.Dock = DockStyle.Fill;

                    break;

                case "tsbDrgSakura":  // サクラ薬マスター
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.DrgSakura;
                    //this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_SAKURADRG";
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_SAKURA";
                    this.mProcGubun = "DRG";
                    this.SetCurrentText(Resources.MSG_011);

                    this.mCurrentGrid = this.grdDrgSakura;
                    this.grdDrgSakura.Visible = true;
                    this.grdDrgSakura.Dock = DockStyle.Fill;

                    break;

                case "tsbGenDrg":  // 一般名処方マスター
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.GenDrg;
                    //this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_JOJE";
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_GD";
                    this.mProcGubun = "MST";
                    this.SetCurrentText(Resources.MSG_012);

                    this.mCurrentGrid = this.grdGenDrgMaster;
                    this.grdGenDrgMaster.Visible = true;
                    this.grdGenDrgMaster.Dock = DockStyle.Fill;

                    break;

                case "tsbGenDrgMap":  // 一般名処方マッピング
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.GenDrgMap;
                    //this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_JOJE";
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_GD";
                    this.mProcGubun = "MAP";
                    this.SetCurrentText(Resources.MSG_013);

                    this.mCurrentGrid = this.grdGenDrgMap;
                    this.grdGenDrgMap.Visible = true;
                    this.grdGenDrgMap.Dock = DockStyle.Fill;

                    break;

                case "tsbYJCode":    // YJ Code
                    btnList.SetEnabled(FunctionType.Update, true);
                    this.mCurrentType = QueryType.YJCode;
                    //this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_JOJE";
                    this.mUpdateProcName = "PR_ADM_UPDATE_MASTER_GD";
                    this.mProcGubun = "YJC";
                    this.SetCurrentText(Resources.MSG_014);

                    this.mCurrentGrid = this.grdYJCode;
                    this.grdYJCode.Visible = true;
                    this.grdYJCode.Dock = DockStyle.Fill;

                    break;
            }
        }

        #endregion 

        #region 버튼 리스트

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    this.mCurrentGrid.QueryLayout(true);

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    string filePath = "";
                    string fileName = "";

                    if (this.GetSourceFilePath(ref filePath, ref fileName) == false)
                            return;
                    

                    switch (this.mCurrentType)
                    {
                        case QueryType.GenDrg:
                        case QueryType.GenDrgMap:
                            String filePathName = filePath + fileName;
                            String sheetName = "";
                            switch (this.mCurrentType)
                            {
                                case QueryType.GenDrg:
                                    sheetName = Resources.MSG_015;// "一般名処方マスタ";
                                    break;
                                case QueryType.GenDrgMap:
                                    sheetName = Resources.MSG_016;// "例外コード品目対照表";
                                    break;
                            }
                            //excel load
                            //TExcel tExcel = new TExcel(filePathName.ToString(), sheetName);
                            TExcel tExcel = new TExcel(fileName.ToString(), sheetName);
                            DataTable dataTable = tExcel.GetDataTable();

                            mUpdateLayout = this.mCurrentGrid.CloneToLayout();

                            //if (data.Length == mUpdateLayout.LayoutTable.Columns.Count)
                            {
                                DataRow dtRowPre = mUpdateLayout.LayoutTable.NewRow();
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    DataRow dtRow;
                                    switch (this.mCurrentType)
                                    {
                                        case QueryType.GenDrg:
                                            // 2nd column is key : index is 1 
                                            if (dataRow.ItemArray[1].ToString().Trim().Length == 0) break;

                                            dtRow = mUpdateLayout.LayoutTable.NewRow();

                                            //dtRow = dataRow;
                                            //for (int i = 0; i < dataRow.ItemArray.Length; i++)
                                            for (int i = 0; i < dtRow.ItemArray.Length; i++)
                                            {
                                                dtRow[i] = dataRow.ItemArray[i].ToString().Trim();
                                            }
                                            mUpdateLayout.LayoutTable.Rows.Add(dtRow);

                                            break;

                                        case QueryType.GenDrgMap:
                                            // 6th column is key : index is 5 
                                            if (dataRow.ItemArray[5].ToString().Trim().Length == 0) break;
                                            //
                                            int ii;
                                            ii = 0;
                                            dtRow = mUpdateLayout.LayoutTable.NewRow();
                                            // 同じ一般名情報は NULL
                                            if (dataRow.ItemArray[1].ToString().Trim().Length == 0)
                                            {
                                                // 同じ一般名情報は コピー
                                                //dtRow = dataRow;
                                                for (; ii < 5; ii++)
                                                {
                                                    dtRow[ii] = dtRowPre[ii];
                                                }

                                            }

                                            //DataRow dtRow = mUpdateLayout.LayoutTable.NewRow();

                                            //for (; ii < dataRow.ItemArray.Length; ii++)
                                            for (; ii < dtRow.ItemArray.Length; ii++)
                                            {
                                                dtRow[ii] = dataRow.ItemArray[ii].ToString().Trim();
                                            }

                                            for (int j = 0; j < dtRow.ItemArray.Length; j++)
                                            {
                                                dtRowPre[j] = dtRow[j];
                                            }
                                            mUpdateLayout.LayoutTable.Rows.Add(dtRow);

                                            break;
                                    }
                                }
                            }
                            break;

                        default:
                            if (this.ReadFile(filePath, fileName) == false)
                                return;
                            break;

                    }

                    if (this.UpdateTempTableNew(this.mUpdateLayout) == true)
                    {
                        this.btnList.PerformClick(FunctionType.Query);

                        this.btnList.PerformClick(FunctionType.Process);
                    }

                    break;

                case FunctionType.Process :

                    e.IsBaseCall = false;

                    this.mMsg = this.lbCurrentText.Text + Resources.MSG_017;//" をアップデートしますか？";
                    this.mCap = Resources.MSG_018; //"作業確認";

                    if (MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        return;
                    }

                    ArrayList inList = new ArrayList();
                    ArrayList outList = new ArrayList();

                    inList.Add(UserInfo.UserID);
                    inList.Add(mProcGubun);
                    outList.Add(UserInfo.UserID);

                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        //this.InitProgressBar(0, 0);
                        //this.SetProgressBarVisible(true, false, true);

                        //this.SetProgressValue(0, this.lbCurrentText.Text + "をアップデートしています。しばらくお待ちください。");

                        // 一般名処方マスター, 一般名処方マッピング, 상병, 상병수식어, 점수마스터, 항목마스터로 반영

                        BAS0310P01ProcessArgs arg= new BAS0310P01ProcessArgs();
                        arg.UserId = UserInfo.UserID;
                        arg.UpdateProcName = this.mUpdateProcName;
                        arg.ProcGubun = mProcGubun;

                        UpdateResult result = CloudService.Instance.Submit<UpdateResult, BAS0310P01ProcessArgs>(arg);
                        if (result == null || result.ExecutionStatus != ExecutionStatus.Success ||
                        result.Result == false)
                        //if (Service.ExecuteProcedure(this.mUpdateProcName, inList, outList) == false)
                        {
                            this.mMsg = Resources.MSG_019;// "アップデートに失敗しました。- ";// + Service.ErrFullMsg;
                            this.mCap = Resources.MSG_020;// "確認";

                            MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        /*
                        foreach (object ov in outList)
                        {
                            if (ov.ToString().Equals("0"))
                            {
                                this.mMsg = "アップデートに失敗しました。- " + Service.ErrFullMsg;
                                this.mCap = "確認";
                                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        */
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;

                        this.SetProgressBarVisible(false, false, false);
                    }

                    break;
            }
        }

        #endregion


        #endregion

        #region CloudService LoadData

        private List<object[]> LoadDataGrdSangMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdSangMasterArgs args = new BAS0310P01GrdSangMasterArgs();

            BAS0310P01GrdSangMasterResult result =
                CloudService.Instance.Submit<BAS0310P01GrdSangMasterResult, BAS0310P01GrdSangMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdSangMasterInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19,item.A20,
                        item.A21,item.A22,item.A23,item.A24,item.A25,
                        item.A26,item.A27,item.A28,item.A29,item.A30,
                        item.A31,item.A32,item.A33,item.A34,item.A35,
                        item.A36,item.A37,item.A38,item.A39,item.A40,
                        item.A41,item.A42,item.A43,item.A44,item.A45, 
                        item.A46

	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdSusikMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdSusikMasterArgs args = new BAS0310P01GrdSusikMasterArgs();

            BAS0310P01GrdSusikMasterResult result =
                CloudService.Instance.Submit<BAS0310P01GrdSusikMasterResult, BAS0310P01GrdSusikMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdSusikMasterInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19

	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdDrugMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdDrugMasterArgs args = new BAS0310P01GrdDrugMasterArgs();

            BAS0310P01GrdDrugMasterResult result =
                CloudService.Instance.Submit<BAS0310P01GrdDrugMasterResult, BAS0310P01GrdDrugMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdDrugMasterInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19,item.A20,
                        item.A21,item.A22,item.A23,item.A24,item.A25,
                        item.A26,item.A27,item.A28,item.A29,item.A30,
                        item.A31,item.A32,item.A33,item.A34,item.A35

	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdTokuteiMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdTokuteiMasterArgs args = new BAS0310P01GrdTokuteiMasterArgs();

            BAS0310P01GrdTokuteiMasterResult result =
                CloudService.Instance.Submit<BAS0310P01GrdTokuteiMasterResult, BAS0310P01GrdTokuteiMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdTokuteiMasterInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19,item.A20,
                        item.A21,item.A22,item.A23,item.A24,item.A25,
                        item.A26,item.A27,item.A28,item.A29,item.A30,
                        item.A31,item.A32,item.A33,item.A34,item.A35,
                        item.A36,item.A37

	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdJinryoMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdJinryoMasterArgs args = new BAS0310P01GrdJinryoMasterArgs();

            BAS0310P01GrdJinryoMasterResult result =
                CloudService.Instance.Submit<BAS0310P01GrdJinryoMasterResult, BAS0310P01GrdJinryoMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdJinryoMasterInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19,item.A20,
                        item.A21,item.A22,item.A23,item.A24,item.A25,
                        item.A26,item.A27,item.A28,item.A29,item.A30,
                        item.A31,item.A32,item.A33,item.A34,item.A35,
                        item.A36,item.A37,item.A38,item.A39,item.A40,
						item.A41,item.A42,item.A43,item.A44,item.A45,
						item.A46,item.A47,item.A48,item.A49,item.A50,
                        item.A51,item.A52,item.A53,item.A54,item.A55,
                        item.A56,item.A57,item.A58,item.A59,item.A60,
                        item.A61,item.A62,item.A63,item.A64,item.A65,
                        item.A66,item.A67,item.A68,item.A69,item.A70,
                        item.A71,item.A72,item.A73,item.A74,item.A75,
                        item.A76,item.A77,item.A78,item.A79,item.A80,
                        item.A81,item.A82,item.A83,item.A84,item.A85,
                        item.A86,item.A87,item.A88,item.A89,item.A90,
                        item.A91,item.A92,item.A93,item.A94,item.A95,
                        item.A96,item.A97,item.A98,item.A99,item.A100,
                        item.A101,item.A102,item.A103,item.A104,item.A105,
                        item.A106,item.A107,item.A108,item.A109,item.A110,
                        item.A111,item.A112,item.A113,item.A114,item.A115,
                        item.A116,item.A117,item.A118,item.A119,item.A120,
                        item.A121,item.A122


	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdJojeMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdJojeMasterArgs args = new BAS0310P01GrdJojeMasterArgs();
            BAS0310P01GrdJojeMasterResult result =
                CloudService.Instance.Submit<BAS0310P01GrdJojeMasterResult, BAS0310P01GrdJojeMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdJojeMasterInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19,item.A20,
                        item.A21,item.A22,item.A23,item.A24,item.A25,
                        item.A26,item.A27,item.A28,item.A29,item.A30,
                        item.A31,item.A32,item.A33,item.A34,item.A35,
                        item.A36,item.A37,item.A38,item.A39,item.A40,
						item.A41,item.A42,item.A43,item.A44,item.A45,
						item.A46,item.A47,item.A48,item.A49,item.A50,
                        item.A51,item.A52,item.A53,item.A54,item.A55,
                        item.A56,item.A57,item.A58,item.A59,item.A60,
                        item.A61,item.A62,item.A63,item.A64,item.A65


	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdGenDrgMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdGenDrgMasterArgs args = new BAS0310P01GrdGenDrgMasterArgs();

            BAS0310P01GrdGenDrgMasterResult result =
                CloudService.Instance.Submit<BAS0310P01GrdGenDrgMasterResult, BAS0310P01GrdGenDrgMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdGenDrgMasterInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19,item.A20


	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdGenDrgMap(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdGenDrgMapArgs args = new BAS0310P01GrdGenDrgMapArgs();

            BAS0310P01GrdGenDrgMapResult result =
                CloudService.Instance.Submit<BAS0310P01GrdGenDrgMapResult, BAS0310P01GrdGenDrgMapArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdGenDrgMapInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19,item.A20,
                        item.A21,item.A22,item.A23,item.A24,item.A25,
                        item.A26,item.A27,item.A28,item.A29,item.A30
	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdYJCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdYjCodeArgs args = new BAS0310P01GrdYjCodeArgs();
            BAS0310P01GrdYjCodeResult result =
                CloudService.Instance.Submit<BAS0310P01GrdYjCodeResult, BAS0310P01GrdYjCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdYjCodeInfo item in result.Dt)
                {
                    object[] objects =
	                {
	                    item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9,item.A10,
                        item.A11,item.A12,item.A13,item.A14,item.A15,
                        item.A16,item.A17,item.A18,item.A19,item.A20,
                        item.A21,item.A22,item.A23,item.A24
	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdDrgSakura(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0310P01GrdDrgSakuraArgs args = new BAS0310P01GrdDrgSakuraArgs();
            BAS0310P01GrdDrgSakuraResult result =
                CloudService.Instance.Submit<BAS0310P01GrdDrgSakuraResult, BAS0310P01GrdDrgSakuraArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0310P01GrdDrgSakuraInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.A1,item.A2,item.A3,item.A4,item.A5,
                        item.A6,item.A7,item.A8,item.A9
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<BAS0310P01GrdJinryoMasterInfo> PrepareInsert(MultiLayout aLayout)
        {
            List<BAS0310P01GrdJinryoMasterInfo> lst = new List<BAS0310P01GrdJinryoMasterInfo>();
            int index = aLayout.LayoutTable.Rows.Count;
            if (currentpage * pageSize < aLayout.LayoutTable.Rows.Count)
            {
                index = currentpage*pageSize;
            }
            else
            {
                index = aLayout.LayoutTable.Rows.Count;
            }
            for(int j = (currentpage - 1) * pageSize; j < index; j++)
            {
                BAS0310P01GrdJinryoMasterInfo info = new BAS0310P01GrdJinryoMasterInfo();
                DataRow dr = aLayout.LayoutTable.Rows[j];
                #region
                info.A1 = ""; info.A2 = ""; info.A3 = ""; info.A4 = ""; info.A5 = ""; info.A6 = ""; info.A7 = ""; info.A8 = ""; info.A9 = ""; info.A10 = "";
                info.A11 = ""; info.A12 = ""; info.A13 = ""; info.A14 = ""; info.A15 = ""; info.A16 = ""; info.A17 = ""; info.A18 = ""; info.A19 = ""; info.A20 = "";
                info.A21 = ""; info.A22 = ""; info.A23 = ""; info.A24 = ""; info.A25 = ""; info.A26 = ""; info.A27 = ""; info.A28 = ""; info.A29 = ""; info.A30 = "";
                info.A31 = ""; info.A32 = ""; info.A33 = ""; info.A34 = ""; info.A35 = ""; info.A36 = ""; info.A37 = ""; info.A38 = ""; info.A39 = ""; info.A40 = "";
                info.A41 = ""; info.A42 = ""; info.A43 = ""; info.A44 = ""; info.A45 = ""; info.A46 = ""; info.A47 = ""; info.A48 = ""; info.A49 = ""; info.A50 = "";
                info.A51 = ""; info.A52 = ""; info.A53 = ""; info.A54 = ""; info.A55 = ""; info.A56 = ""; info.A57 = ""; info.A58 = ""; info.A59 = ""; info.A60 = "";
                info.A61 = ""; info.A62 = ""; info.A63 = ""; info.A64 = ""; info.A65 = ""; info.A66 = ""; info.A67 = ""; info.A68 = ""; info.A69 = ""; info.A70 = "";
                info.A71 = ""; info.A72 = ""; info.A73 = ""; info.A74 = ""; info.A75 = ""; info.A76 = ""; info.A77 = ""; info.A78 = ""; info.A79 = ""; info.A80 = "";
                info.A81 = ""; info.A82 = ""; info.A83 = ""; info.A84 = ""; info.A85 = ""; info.A86 = ""; info.A87 = ""; info.A88 = ""; info.A89 = ""; info.A90 = "";
                info.A91 = ""; info.A92 = ""; info.A93 = ""; info.A94 = ""; info.A95 = ""; info.A96 = ""; info.A97 = ""; info.A98 = ""; info.A99 = ""; info.A100 = "";
                info.A101 = ""; info.A102 = ""; info.A103 = ""; info.A104 = ""; info.A105 = ""; info.A106 = ""; info.A107 = ""; info.A108 = ""; info.A109 = ""; info.A110 = "";
                info.A111 = ""; info.A112 = ""; info.A113 = ""; info.A114 = ""; info.A115 = ""; info.A116 = ""; info.A117 = ""; info.A118 = ""; info.A119 = ""; info.A120 = "";
                info.A121 = ""; info.A122 = "";
                #endregion
                for (int i = 0; i < aLayout.LayoutTable.Columns.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            info.A1 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 1:
                            info.A2 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 2:
                            info.A3 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 3:
                            info.A4 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 4:
                            info.A5 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 5:
                            info.A6 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 6:
                            info.A7 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 7:
                            info.A8 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 8:
                            info.A9 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 9:
                            info.A10 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 10:
                            info.A11 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 11:
                            info.A12 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 12:
                            info.A13 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 13:
                            info.A14 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 14:
                            info.A15 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 15:
                            info.A16 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 16:
                            info.A17 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 17:
                            info.A18 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 18:
                            info.A19 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 19:
                            info.A20 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 20:
                            info.A21 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 21:
                            info.A23 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 22:
                            info.A23 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 23:
                            info.A24 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 24:
                            info.A25 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 25:
                            info.A26 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 26:
                            info.A27 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 27:
                            info.A28 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 28:
                            info.A29 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 29:
                            info.A30 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 30:
                            info.A31 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 31:
                            info.A32 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 32:
                            info.A33 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 33:
                            info.A34 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 34:
                            info.A35 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 35:
                            info.A36 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 36:
                            info.A37 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 37:
                            info.A38 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 38:
                            info.A39 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 39:
                            info.A40 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 40:
                            info.A41 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 41:
                            info.A42 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 42:
                            info.A43 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 43:
                            info.A44 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 44:
                            info.A45 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 45:
                            info.A46 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 46:
                            info.A47 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 47:
                            info.A48 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 48:
                            info.A49 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 49:
                            info.A50 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 50:
                            info.A51 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 51:
                            info.A52 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 52:
                            info.A53 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 53:
                            info.A54 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 54:
                            info.A55 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 55:
                            info.A56 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 56:
                            info.A57 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 57:
                            info.A58 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 58:
                            info.A59 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 59:
                            info.A60 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 60:
                            info.A61 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 61:
                            info.A62 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 62:
                            info.A63 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 63:
                            info.A64 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 64:
                            info.A65 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 65:
                            info.A66 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 66:
                            info.A67 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 67:
                            info.A68 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 68:
                            info.A69 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 69:
                            info.A70 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 70:
                            info.A71 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 71:
                            info.A72 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 72:
                            info.A73 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 73:
                            info.A74 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 74:
                            info.A75 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 75:
                            info.A76 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 76:
                            info.A77 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 77:
                            info.A78 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 78:
                            info.A79 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 79:
                            info.A80 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 80:
                            info.A81 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 81:
                            info.A82 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 82:
                            info.A83 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 83:
                            info.A84 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 84:
                            info.A85 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 85:
                            info.A86 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 86:
                            info.A87 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 87:
                            info.A88 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 88:
                            info.A89 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 89:
                            info.A90 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 90:
                            info.A91 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 91:
                            info.A92 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 92:
                            info.A93 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 93:
                            info.A94 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 94:
                            info.A95 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 95:
                            info.A96 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 96:
                            info.A97 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 97:
                            info.A98 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 98:
                            info.A99 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 99:
                            info.A100 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 100:
                            info.A101 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 101:
                            info.A102 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 102:
                            info.A103 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 103:
                            info.A104 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 104:
                            info.A105 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 105:
                            info.A106 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 106:
                            info.A107 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 107:
                            info.A108 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 108:
                            info.A109 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 109:
                            info.A110 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 110:
                            info.A111 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 111:
                            info.A112 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 112:
                            info.A113 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 113:
                            info.A114 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 114:
                            info.A115 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 115:
                            info.A116 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 116:
                            info.A117 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 117:
                            info.A118 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 118:
                            info.A119 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 119:
                            info.A120 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 120:
                            info.A121 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        case 121:
                            info.A122 = dr[aLayout.LayoutTable.Columns[i].ColumnName].ToString();
                            break;
                        
                    }
                }
                lst.Add(info);
            }
            return lst;
        }

        #endregion
    }

    #region Enum Query Type

    public enum QueryType
    {
        SangCode   ,       // 상병코드
        SusikCode  ,       // 수식어코드
        DrugCode   ,       // 약품코드
        JinryoCode ,       // 진료행위
        TokuteiCode,       // 특정기재
        JojeCode   ,       // 조제행위
        YJCode     ,       // YJ CODE マスター
        DrgSakura  ,       // サクラ薬マスター
        GenDrg     ,       // 一般名処方マスター
        GenDrgMap          // 一般名処方マッピング
    }

    #endregion

    
}