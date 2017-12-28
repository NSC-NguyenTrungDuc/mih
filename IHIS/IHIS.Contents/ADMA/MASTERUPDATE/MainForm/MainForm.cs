using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.BASS
{
    public partial class MainForm : Form
    {
        private OdbcConnection mConnection;
        private OdbcDataAdapter mAdapter;
        private DataTable tempTable;

        private QueryType mCurrentType;

        private Hashtable SangHeaderText = new Hashtable();
        private Hashtable SusikHeaderText = new Hashtable();
        private Hashtable DrugHeaderText = new Hashtable();
        private Hashtable JinryoHeaderText = new Hashtable();
        private Hashtable TokuteiHeaderText = new Hashtable();

        public MainForm()
        {
            InitializeComponent();

            this.MakeHeaderTextInfo();

            mConnection = new OdbcConnection("DSN=orca;UID=orca;PWD=");

            Service.Connect();

        }

        #region Grid Header 관련(사용안함)

        private void MakeHeaderTextInfo()
        {
            // 상병
            this.SangHeaderText.Clear();
            this.SangHeaderText.Add("byomeicd", "病名コード");
            this.SangHeaderText.Add("byomei", "病名名称");
            this.SangHeaderText.Add("byomeikana", "病名名称カナ");
            this.SangHeaderText.Add("icd10", "ICD10");
            this.SangHeaderText.Add("byomeichgcd", "病名交換用コード");
            this.SangHeaderText.Add("syusaiymd", "収載年月日");
            this.SangHeaderText.Add("chgymd", "変更年月日");
            this.SangHeaderText.Add("haisiymd", "廃止年月日");
            
            // 수식어
            this.SusikHeaderText.Add("byomeicd", "修飾語コード");
            this.SusikHeaderText.Add("byomei", "修飾語名称");
            this.SusikHeaderText.Add("byomeikana", "修飾語名称カナ");
            this.SusikHeaderText.Add("syusaiymd", "収載年月日");
            this.SusikHeaderText.Add("chgymd", "変更年月日");
            this.SusikHeaderText.Add("haisiymd", "廃止年月日");

        }

        private void SetColumnHeaderText(QueryType aType)
        {
            switch (aType)
            {
                case QueryType.SangCode:

                    #region 상병코드 

                    foreach (DataGridViewColumn cl in this.gridData.Columns)
                    {
                        if (this.SangHeaderText.Contains(cl.Name))
                        {
                            cl.HeaderText = this.SangHeaderText[cl.Name].ToString();

                            switch (cl.Name)
                            {
                                case "byomei":
                                case "byomeikana":

                                    cl.Width = 200;

                                    break;
                            }
                        }
                        else
                            cl.Visible = false;
                    }

                    #endregion

                    break;

                case QueryType.SusikCode:

                    #region 수식어 코드

                    foreach (DataGridViewColumn cl in this.gridData.Columns)
                    {
                        if (this.SusikHeaderText.Contains(cl.Name))
                        {
                            cl.HeaderText = this.SusikHeaderText[cl.Name].ToString();

                            switch (cl.Name)
                            {
                                case "byomei":
                                case "byomeikana":

                                    cl.Width = 200;

                                    break;
                            }
                        }
                        else
                            cl.Visible = false;
                    }

                    #endregion

                    break;

                case QueryType.DrugCode:

                    break;

                case QueryType.JinryoHangwi:

                    break;

                case QueryType.TokuteiCode:

                    break;
            }
        }

        #endregion

        #region SQL QUERY 관련(사용안함)

        private string GetQueryText ( QueryType aType)
        {
            string cmd = "";

            switch (aType)
            {
                case QueryType.SangCode:

                    #region 상병코드 조회문

                    cmd = @"SELECT BYOMEICD        
                                 , BYOMEI          
                                 , BYOMEIMOJI      
                                 , TANBYOMEI       
                                 , TANBYOMEIMOJI   
                                 , BYOMEIKANA      
                                 , IKOSAKICD       
                                 , TOKSKNCD        
                                 , UTAGAIFLG       
                                 , TANDOKUKBN      
                                 , HKNSKYKBN       
                                 , HYOJUNCD        
                                 , SAITAKUKBN
                                 , BYOMEICHGCD     
                                 , ICD10           
                                 , SYUSAIYMD       
                                 , CHGYMD        
                                 , HAISIYMD      
                                 , TERMID        
                                 , OPID          
                                 , CREYMD        
                                 , UPYMD         
                                 , UPHMS         
                              FROM TBL_BYOMEI
                             WHERE BYOMEICD NOT LIKE 'ZZZ%'
                             ORDER BY BYOMEICD ";

                    #endregion

                    break;

                case QueryType.SusikCode:

                    #region 수식어 코드

                    cmd = @"SELECT BYOMEICD        
                                 , BYOMEI          
                                 , BYOMEIMOJI      
                                 , TANBYOMEI       
                                 , TANBYOMEIMOJI   
                                 , BYOMEIKANA      
                                 , IKOSAKICD       
                                 , TOKSKNCD        
                                 , UTAGAIFLG       
                                 , TANDOKUKBN      
                                 , HKNSKYKBN       
                                 , HYOJUNCD        
                                 , SAITAKUKBN
                                 , BYOMEICHGCD     
                                 , ICD10           
                                 , SYUSAIYMD       
                                 , CHGYMD        
                                 , HAISIYMD      
                                 , TERMID        
                                 , OPID          
                                 , CREYMD        
                                 , UPYMD         
                                 , UPHMS         
                              FROM TBL_BYOMEI
                             WHERE BYOMEICD LIKE 'ZZZ%'
                             ORDER BY BYOMEICD ";

                    #endregion

                    break;

                case QueryType.DrugCode:

                    #region 약코드

                    cmd = @"SELECT BYOMEICD        
                                 , BYOMEI          
                                 , BYOMEIMOJI      
                                 , TANBYOMEI       
                                 , TANBYOMEIMOJI   
                                 , BYOMEIKANA      
                                 , IKOSAKICD       
                                 , TOKSKNCD        
                                 , UTAGAIFLG       
                                 , TANDOKUKBN      
                                 , HKNSKYKBN       
                                 , HYOJUNCD        
                                 , SAITAKUKBN
                                 , BYOMEICHGCD     
                                 , ICD10           
                                 , SYUSAIYMD       
                                 , CHGYMD        
                                 , HAISIYMD      
                                 , TERMID        
                                 , OPID          
                                 , CREYMD        
                                 , UPYMD         
                                 , UPHMS         
                              FROM TBL_BYOMEI
                             WHERE BYOMEICD LIKE 'ZZZ%'
                             ORDER BY BYOMEICD ";

                    #endregion

                    break;
            }

            return cmd;
        }

        #endregion

        #region QueryData 
        
        // 미사용
        private void DataLoad(QueryType aType)
        {
            if (tempTable != null)
                tempTable.Dispose();
            tempTable = new DataTable();
            if (mAdapter != null)
                mAdapter.Dispose();
            mAdapter = new OdbcDataAdapter(this.GetQueryText(aType), this.mConnection);

            mAdapter.Fill(tempTable);

            this.gridData.DataSource = tempTable;

            this.SetColumnHeaderText(aType);
        }

        // sql 문으로 조회
        private void DataLoad(string cmd)
        {
            if (tempTable != null)
                tempTable.Dispose();
            tempTable = new DataTable();
            if (mAdapter != null)
                mAdapter.Dispose();
            mAdapter = new OdbcDataAdapter(cmd, this.mConnection);

            mAdapter.Fill(tempTable);

            this.gridData.DataSource = tempTable;

            //this.SetColumnHeaderText(aType);
        }

        #endregion QueryData

        #region tab 버튼(미사용?)

        private void tsbByouMei_Click(object sender, EventArgs e)
        {
            this.mCurrentType = QueryType.SangCode;

            this.DataLoad(QueryType.SangCode);
        }

        private void tsbSusikCode_Click(object sender, EventArgs e)
        {
            this.mCurrentType = QueryType.SusikCode;

            this.DataLoad(QueryType.SusikCode);
        }

        private void tspDrugCode_Click(object sender, EventArgs e)
        {
            this.mCurrentType = QueryType.DrugCode;

            this.DataLoad(QueryType.DrugCode);
        }

        private void tsbJinryoHangwi_Click(object sender, EventArgs e)
        {
            this.mCurrentType = QueryType.JinryoHangwi;

            this.DataLoad(QueryType.JinryoHangwi);
        }

        private void tsbTokuteiCode_Click(object sender, EventArgs e)
        {
            this.mCurrentType = QueryType.TokuteiCode;

            this.DataLoad(QueryType.TokuteiCode);
        }

        private void tsbJabiCode_Click(object sender, EventArgs e)
        {
            this.mCurrentType = QueryType.JabiCode;

            this.DataLoad(QueryType.JabiCode);
        }

        private void tabGubun_SelectionChanged(object sender, EventArgs e)
        {
            //mCurrentType = this.tabGubun.SelectedTab.Tag.ToString().
        }

        #endregion tab 버튼(미사용?)

        #region Toolbar 버튼(미사용?)

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            string cmd = "";

            switch (e.Func)
            {
                case FunctionType.Query:

                    #region Tab별 Query Call
                    //if (this.txtInitialSgCode.Text == "") return;

                    //if (this.txtInitialSgCode.Text != "" || this.tbxTableId.Text == "")
                    //    cmd = " SELECT * FROM TBL_TENSU WHERE SRYCD LIKE '" + this.txtInitialSgCode.Text + "%' ";
                    //else
                    //    cmd = " SELECT * FROM " + this.tbxTableId.Text;

                    if (this.tabGubun.SelectedTab == null) return;

                    cmd = this.GetQuerySQL(this.tabGubun.SelectedTab.Tag.ToString());

                    this.DataLoad(cmd);
                    #endregion Tab별 Query Call
                    break;

                case FunctionType.Update:

                    #region Commit처리 Call
                    Service.BeginTransaction();

                    //int i = 0;
                    //int colCnt = 0;
                    bool isSuccess = false;

                    switch (this.tabGubun.SelectedTab.Tag.ToString())
                    {
                        case "1":
                            //isSuccess = this.UpdateBoheom((DataTable)this.gridData.DataSource);
                            break;

                        case "2":    // 공비정보
                            //isSuccess = this.UpdateGongbi((DataTable)this.gridData.DataSource);
                            break;

                        case "3":    // 환자정보
                            isSuccess = this.UpdatePatient((DataTable)this.gridData.DataSource);
                            break;

                        case "4":

                            isSuccess = this.UpdatePaBoheom((DataTable)this.gridData.DataSource);

                            break;

                        case "5":

                            isSuccess = this.UpdatePatientGongbi((DataTable)this.gridData.DataSource);

                            break;

                        case "6":

                            isSuccess = this.UpdateSetOrder((DataTable)this.gridData.DataSource);

                            break;

                        case "7":

                            isSuccess = this.UpdateSetCode((DataTable)this.gridData.DataSource);

                            break;

                        case "8": // 사용자

                            isSuccess = this.UpdateUserMaster((DataTable)this.gridData.DataSource);

                            break;

                        case "9": // 우편번호

                            isSuccess = this.UpdateZipCode((DataTable)this.gridData.DataSource);

                            break;

                        case "10": // 보험종별마스터

                            isSuccess = this.UpdateJohapGubun((DataTable)this.gridData.DataSource);

                            break;

                        case "11": // 보험자마스터

                            isSuccess = this.UpdateJohapMaster((DataTable)this.gridData.DataSource);

                            break;

                        case "12": // 공비마스터

                            isSuccess = this.UpdateGongbiMaster((DataTable)this.gridData.DataSource);

                            break;

                        case "13":  // 환자별 상병

                            isSuccess = this.UpdatePatientSang((DataTable)this.gridData.DataSource);

                            break;

                        case "14":  // 점수마스타 - 자비

                            isSuccess = this.UpdateJabi((DataTable)this.gridData.DataSource);

                            break;
                            /*

                        case "15":  // 병원정보

                            isSuccess = this.UpdateHospInfo((DataTable)this.gridData.DataSource);

                            break;

                        case "16":  // 병동정보

                            isSuccess = this.UpdateHoDong((DataTable)this.gridData.DataSource);

                            break;

                        case "17":  // 병실정보

                            isSuccess = this.UpdateHoRoom((DataTable)this.gridData.DataSource);

                            break;
                             */

                    }
                    #region comment source
                    //try
                    //{
                    //    foreach (DataRow dr in ((DataTable)this.gridData.DataSource).Rows)
                    //    {
                    //        i++;

                    //        lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                    //        lbCount.Refresh();

                    //        //cmd = " INSERT INTO CNV0002  "
                    //        //    + " VALUES ( ";

                    //        //colCnt = 1;
                    //        //foreach (DataColumn cl in ((DataTable)this.gridData.DataSource).Columns)
                    //        //{
                    //        //    if (colCnt != 1) cmd += ",";
                                
                    //        //    if (cl.DataType.ToString() == "System.String")
                    //        //    {
                    //        //        cmd += "'" + dr[cl.ColumnName].ToString() + "'";
                    //        //    }
                    //        //    else
                    //        //    {
                    //        //        cmd += dr[cl.ColumnName].ToString();
                    //        //    }

                    //        //    colCnt++;
                    //        //}

                    //        //cmd += " )";

                    //        //cmd = " INSERT INTO CNV0003"
                    //        //    + " VALUES ( '" + dr["byomeicd"].ToString() + "'"
                    //        //            + " ,'" + dr["byomei"].ToString() + "'"
                    //        //            + " ,'" + dr["byomeimoji"].ToString() + "'"
                    //        //            + " ,'" + dr["tanbyomei"].ToString() + "'"
                    //        //            + " ,'" + dr["tanbyomeimoji"].ToString() + "'"
                    //        //            + " ,'" + dr["byomeikana"].ToString() + "'"
                    //        //            + " ,'" + dr["ikosakicd"].ToString() + "'"
                    //        //            + " ,'" + dr["tokskncd"].ToString() + "'"
                    //        //            + " ,'" + dr["utagaiflg"].ToString() + "'"
                    //        //            + " ,'" + dr["tandokukbn"].ToString() + "'"
                    //        //            + " ,'" + dr["hknskykbn"].ToString() + "'"
                    //        //            + " ,'" + dr["hyojuncd"].ToString() + "'"
                    //        //            + " ,'" + dr["saitakukbn"].ToString() + "'"
                    //        //            + " ,'" + dr["byomeichgcd"].ToString() + "'"
                    //        //            + " ,'" + dr["icd10"].ToString() + "'"
                    //        //            + " ,'" + dr["syusaiymd"].ToString() + "'"
                    //        //            + " ,'" + dr["chgymd"].ToString() + "'"
                    //        //            + " ,'" + dr["haisiymd"].ToString() + "'"
                    //        //            + " ,'" + dr["termid"].ToString() + "'"
                    //        //            + " ,'" + dr["opid"].ToString() + "'"
                    //        //            + " ,'" + dr["creymd"].ToString() + "'"
                    //        //            + " ,'" + dr["upymd"].ToString() + "'"
                    //        //            + " ,'" + dr["uphms"].ToString() + "') ";

                    //        if (Service.ExecuteNonQuery(cmd) == false)
                    //        {
                    //            MessageBox.Show(Service.ErrFullMsg);
                    //            return;
                    //        }
                    //    }
                    //}
                    //finally
                    //{
                    //}
                    #endregion comment source

                    if (isSuccess)
                        Service.CommitTransaction();
                    else
                        Service.RollbackTransaction();

                    #endregion Commit처리 Call
                    break;
                case FunctionType.Close :

                    this.Close();
                    break;

                case FunctionType.Process:

                    #region File 생성 처리 Call

                    string filename = @"c:\temp\111.xls";
                    //int cols = 0;

                    StreamWriter wr = new StreamWriter(filename);

                    foreach (DataColumn cl in this.gridData.Columns)
                    {
                        wr.Write(cl.ColumnName.ToString().ToUpper() + "\t");
                    }

                    wr.WriteLine();

                    foreach (DataRow dr in this.gridData.Rows)
                    {
                        foreach (DataColumn cl in this.gridData.Columns)
                        {
                            wr.Write(dr[cl.ColumnName].ToString() + "\t");
                        }

                        wr.WriteLine();
                    }

                    wr.Close();

                    #endregion File 처리 Call
                    break;
            }
        }

        #endregion

        #region Query 설정(각종 SQL)
        private string GetQuerySQL(string aGubun)
        {
            string returnCmd = "";

            switch (aGubun)
            {
                case "1":  // 보험 => 11로 대체

                    //returnCmd = " SELECT * FROM TBL_HKNNUM WHERE HKNKOHSBTKBN IN ('1', '4', '8') AND '" + DateTime.Now.ToString("yyyyMMdd") + "' BETWEEN TEKSTYMD AND TEKEDYMD; ";
                    returnCmd = " ";

                    break;

                case "2":  // 공비 => 12로 대체

                    //returnCmd = " SELECT * FROM TBL_HKNNUM WHERE HKNKOHSBTKBN IN ('5', '6', '7') AND '" + DateTime.Now.ToString("yyyyMMdd") + "' BETWEEN TEKSTYMD AND TEKEDYMD; ";
                    returnCmd = " ";

                    break;

                case "3":  // 환자정보

                    returnCmd = @"
SELECT    B.PTNUM   AS BUNHO
        , A.* 
  FROM    TBL_PTNUM B
        , TBL_PTINF A 
 WHERE B.PTID       =   A.PTID
";

                    break;

                case "4": // 환자별 보험

                    returnCmd = @"
SELECT    B.PTNUM   AS BUNHO
        , A.* 
  FROM    TBL_PTNUM     B
        , TBL_PTHKNINF  A
 WHERE A.SAKJOKBN   != '1' 
   AND B.PTID       = A.PTID
";

                    break;

                case "5": // 환자별 공비

                    returnCmd = @"
SELECT    B.PTNUM   AS BUNHO
        , A.* 
  FROM    TBL_PTNUM     B
        , TBL_PTKOHINF  A
 WHERE A.SAKJOKBN   != '1' 
   AND B.PTID       = A.PTID
   AND EXISTS       ( SELECT NULL
                        FROM TBL_HKNNUM z
		               WHERE Z.HKNKOHSBTKBN IN ('5', '6', '7') 
		                 AND Z.HKNNUM       = A.KOHNUM
		            ) 
";

                    break;

                case "6" : // 셋트 점수

                    returnCmd = " SELECT A.* FROM TBL_INPUTSET A ";

                    break;

                case "7":  // 셋트 코드

                    returnCmd = " SELECT A.* FROM TBL_INPUTCD A ";

                    break;

                case "8":  // 사용자마스터

                    returnCmd = @"
SELECT A.*
  FROM TBL_SYSKANRI A
 WHERE A.KANRICD IN ('1010')
 ORDER BY 
       A.KANRICD, A.KBNCD
";
/*
                    returnCmd = " SELECT A.* "
                        //+ "        , SUBSTRING(A.KANRITBL, 1  , 16)           AS USER_ID "
                        //+ "        , SUBSTRING(A.KANRITBL, 17 , 40)           AS USER_NAME_KANA "
                        //+ "        , SUBSTRING(A.KANRITBL "
                        //+ "                   , 97 - (LENGTH(SUBSTRING(A.KANRITBL, 17 , 40)::BYTEA) - 40) "
                        //+ "                   , 40 - ( ( LENGTH(A.KANRITBL::BYTEA) - LENGTH(A.KANRITBL) ) "
                        //+ "                           - ( LENGTH(SUBSTRING(A.KANRITBL, 17 , 40)::BYTEA) - 40 ) "
                        //+ "                          ) "
                        //+ "                   )                               AS USER_NAME "
                        //+ "        , SUBSTRING(A.KANRITBL::BYTEA, 205, 2)     AS GWA1 "
                        //+ "        , SUBSTRING(A.KANRITBL::BYTEA, 207, 2)     AS GWA2 "
                        //+ "        , SUBSTRING(A.KANRITBL::BYTEA, 209, 2)     AS GWA3 "
                        //+ "        , SUBSTRING(A.KANRITBL::BYTEA, 211, 2)     AS GWA4 "
                        //+ "        , SUBSTRING(A.KANRITBL::BYTEA, 213, 2)     AS GWA5 "
                        //+ "        , SUBSTRING(A.KANRITBL::BYTEA, 286, 40)    AS MAYAK_LICENSE "
                              + "   FROM TBL_SYSKANRI A "
                              + "  WHERE A.KANRICD IN ('1010') "
                        //+ "    AND  "
                              + "  ORDER BY A.KANRICD, A.KBNCD ; "
                              ;
*/
                    break;

                case "9":  // 우편번호

                    returnCmd = @"
SELECT A.* 
  FROM TBL_ADRS A 
 WHERE 1=1
 ORDER BY 
       A.POST, A.RENNUM
";

                    break;

                case "10":  // 보험종별마스터

                    returnCmd = @"
SELECT A.* 
  FROM TBL_HKNNUM A 
 WHERE A.HKNKOHSBTKBN IN ('1', '4', '8') 
 ORDER BY 
       A.HKNNUM, A.TEKSTYMD
";
                    // 전체를 대상으로 머지 
                    //+ "    AND '" + DateTime.Now.ToString("yyyyMMdd") + "' BETWEEN A.TEKSTYMD AND A.TEKEDYMD "

                    break;

                case "11":  // 보험자마스터

                    returnCmd = @"
SELECT A.* 
  FROM TBL_HKNJAINF A 
 WHERE 1=1 
 ORDER BY 
       A.HKNJANUM
";
                    break;

                case "12":  // 공비마스터

                    returnCmd = @"
SELECT A.* 
  FROM TBL_HKNNUM A 
 WHERE A.HKNKOHSBTKBN IN ('5', '6', '7') 
 ORDER BY 
       A.HKNNUM, A.TEKSTYMD
";
                              // 전체를 대상으로 머지 
                              //+ "    AND '" + DateTime.Now.ToString("yyyyMMdd") + "' BETWEEN A.TEKSTYMD AND A.TEKEDYMD "
                    break;

                case "13":  // 환자별 상병

                    returnCmd = @"
SELECT B.PTNUM
     , A.SRYKA
     , A.SRYYMD
     , A.RENNUM
     , A.KHNBYOMEICD
     , A.BYOMEIINPUTCD_1
     , A.BYOMEIINPUTCD_2
     , A.BYOMEIINPUTCD_3
     , A.BYOMEIINPUTCD_4
     , A.BYOMEIINPUTCD_5
     , A.BYOMEIINPUTCD_6
     , A.BYOMEICDSU
     , A.BYOMEICD_1
     , A.BYOMEICD_2
     , A.BYOMEICD_3
     , A.BYOMEICD_4
     , A.BYOMEICD_5
     , A.BYOMEICD_6
     , A.BYOMEICD_7
     , A.BYOMEICD_8
     , A.BYOMEICD_9
     , A.BYOMEICD_10
     , A.BYOMEICD_11
     , A.BYOMEICD_12
     , A.BYOMEICD_13
     , A.BYOMEICD_14
     , A.BYOMEICD_15
     , A.BYOMEICD_16
     , A.BYOMEICD_17
     , A.BYOMEICD_18
     , A.BYOMEICD_19
     , A.BYOMEICD_20
     , A.BYOMEICD_21
     , A.UTAGAIFLG
     , A.SYUBYOFLG
     , A.MANSEIKBN
     , A.NYUGAIKBN  
     , A.HKNCOMBI
     , A.REZEFLG
     , A.REZEMM
     , A.TENKIKBN
     , A.TENKIYMD
     , A.BYOMEI
     , A.BYOMEIMOJI
     , A.CHARTBYOMEI
     , A.CHARTBYOMEIMOJI
     , A.BYOMEIHENFLG
     , A.HKNBYOMEIFLG
     , A.RECEDENFLG
     , A.HKNNUM
     , A.KHNBUICD_1
     , A.KHNBUICD_2
     , A.KHNBUICD_3
     , A.DLTFLG
     , A.DLT_OPID
  FROM TBL_PTBYOMEI A
     , TBL_PTNUM B
 WHERE A.PTID = B.PTID
 ORDER BY B.PTNUM
        , A.SRYKA
	, A.SRYYMD
	, A.KHNBYOMEICD
	, A.RENNUM  
";

                    break;

                case "14":  // 점수마스터 자비

                    returnCmd = @"
SELECT A.* 
  FROM TBL_TENSU A 
 WHERE (   A.SRYCD    LIKE '095%'
        OR A.SRYCD    LIKE '096%'
       )
 ORDER BY
       A.SRYCD, A.YUKOSTYMD
";
                                // 전체를 대상으로 머지 
                                //+ "    AND '" + DateTime.Now.ToString("yyyyMMdd") + "' BETWEEN A.YUKOSTYMD AND A.TEKEDYMD "
                    break;
                /*

            case "15":  // 병원정보

                returnCmd = " SELECT A.* "
                          + "   FROM TBL_SYSKANRI A "
                          + "  WHERE A.KANRICD IN ('1001', '1002', '1003') "
                          // 전체를 대상으로 머지 
                          + "    AND '" + DateTime.Now.ToString("yyyyMMdd") + "' BETWEEN A.STYUKYMD AND A.EDYUKYMD "
                          + "  ORDER BY A.KANRICD ; ";
                          ;

                break;

            case "16":  // 병동정보

                returnCmd = " SELECT A.* "
                          + "   FROM TBL_SYSKANRI A "
                          + "  WHERE A.KANRICD IN ('5001') "
                    // 전체를 대상으로 머지 
                          + "    AND '" + DateTime.Now.ToString("yyyyMMdd") + "' BETWEEN A.STYUKYMD AND A.EDYUKYMD "
                          + "  ORDER BY A.KANRICD ; ";
                           ;

                break;

            case "17":  // 병실정보

                returnCmd = " SELECT A.* "
                          + "   FROM TBL_SYSKANRI A "
                          + "  WHERE A.KANRICD IN ('5002') "
                    // 전체를 대상으로 머지 
                          + "    AND '" + DateTime.Now.ToString("yyyyMMdd") + "' BETWEEN A.STYUKYMD AND A.yukoedymd "
                          + "  ORDER BY A.KANRICD ; ";
                           ;

                break;
                */
            }

            return returnCmd;
        }
        #endregion Query 설정

        #region Update 로직

        #region 보험(사용안함)

        private bool UpdateBoheom(DataTable aTable)
        {
            int i = 0;
            string cmd = "";
            string gubun = "";
            string gubunName = "";
            string johapGubun = "";

            foreach (DataRow dr in aTable.Rows)
            {
                i++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();


                switch (dr["hknnum"].ToString())
                {
                    case "060" : // 국보의 경우

                        gubun = "00";
                        gubunName = dr["tanseidoname"].ToString();
                        johapGubun = "10";

                        break;

                    case "971" : // 노재의 경우

                        gubun = "R1";
                        gubunName = "労災";
                        johapGubun = "50";

                        break;

                    case "973" : // 자배의 경우

                        gubun = "R3";
                        gubunName = "自賠責";
                        johapGubun = "30";

                        break;

                    default : // 그외의 경우

                        if (dr["hknnum"].ToString().Substring(0, 2) == "98") // 자비의 경우
                        {
                            gubun = "Z" + dr["hknnum"].ToString().Substring(2, 1);
                            gubunName = "自費";
                            johapGubun = "60"; // 자비
                        }
                        else
                        {
                            gubun = dr["hknnum"].ToString().Substring(1, 2);
                            gubunName = dr["tanseidoname"].ToString();
                            johapGubun = "";
                        }

                        break;

                }

                //cmd = " UPDATE BAS0210 "
                //    + "    SET END_DATE = TO_DATE(NVL(DECODE('" + dr["tekedymd"].ToString() + "', '99999999', '99981231', '" + dr["tekedymd"].ToString() + "'), '99981231'), 'YYYYMMDD') "
                //    + "  WHERE GUBUN = '" + gubun + "' "
                //    + "    AND START_DATE = TO_DATE(NVL(DECODE('" + dr["tekstymd"].ToString() + "', '00000000', '20000401', '" + dr["tekstymd"].ToString() + "'), '20000401'), 'YYYYMMDD') ";

                //if (Service.ExecuteNonQuery(cmd) == false)
                //{
                    cmd = " INSERT INTO BAS0210 "
                        + "      ( SYS_DATE , SYS_ID      , UPD_DATE  , UPD_ID "
                        + "      , GUBUN    , GUBUN_NAME  , START_DATE, END_DATE "
                        + "      , HOSP_CODE, JOHAP_GUBUN ) "
                        + " VALUES "
                        + "      ( SYSDATE  , 'CONV'      , SYSDATE   , 'CONV' "
                        + "      , '" + gubun + "', '" + gubunName + "' "
                        + "      , TO_DATE(NVL(DECODE('" + dr["tekstymd"].ToString() + "', '00000000', '20000401', '" + dr["tekstymd"].ToString() + "'), '20000401'), 'YYYYMMDD') "
                        + "      , TO_DATE(NVL(DECODE('" + dr["tekedymd"].ToString() + "', '99999999', '99981231', '" + dr["tekedymd"].ToString() + "'), '99981231'), 'YYYYMMDD') "
                        + "      , '" + EnvironInfo.HospCode + "', '" + johapGubun + "' )";

                    if (Service.ExecuteNonQuery(cmd) == false)
                        return false;
                //}

            }

            lbCount.Text = "";
            lbCount.Refresh();

            return true;
        }

        #endregion

        #region 공비(사용안함)

        private bool UpdateGongbi(DataTable aTable)
        {
            int i = 0;
            string cmd = "";
            //string gubun = "";
            //string gubunName = "";
            //string johapGubun = "";

            foreach (DataRow dr in aTable.Rows)
            {
                i++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                

                cmd = " INSERT INTO BAS0212 "
                    + " VALUES "
                    + "      ( SYSDATE, 'CONV', SYSDATE "
                    + "      , '" + dr["hknnum"].ToString() + "' "
                    + "      , TO_DATE(NVL(DECODE('" + dr["tekstymd"].ToString() + "', '00000000', '20000401', '" + dr["tekstymd"].ToString() + "'), '20000401'), 'YYYYMMDD') "
                    + "      , TO_DATE(NVL(DECODE('" + dr["tekedymd"].ToString() + "', '99999999', '99981231', '" + dr["tekedymd"].ToString() + "'), '99981231'), 'YYYYMMDD') "
                    + "      , '" + dr["hbtnum"].ToString() + "', '" + dr["tanseidoname"].ToString() + "', 'Y', NULL "
                    + "      , 'CONV', '" + EnvironInfo.HospCode + "' ) ";

                if (Service.ExecuteNonQuery(cmd) == false)
                    return false;

            }

            lbCount.Text = "";
            lbCount.Refresh();

            return true;
        }

        #endregion

        #region 환자정보 마이그레이션

        private bool UpdatePatient(DataTable aTable)
        {
            string bunho = "";
            string tel = "";
            string tel_gubun = "";

            int i = 0;
            string cmd = "";

            BindVarCollection bindVals = new BindVarCollection();

            cmd = @"
DECLARE
  CURSOR C1 (
               C_HOSP_CODE            OUT0101.HOSP_CODE   %TYPE
             , C_BUNHO                OUT0101.BUNHO       %TYPE
            ) IS
         SELECT NVL(A.IF_VALID_YN, 'N')         AS IF_VALID_YN
           FROM OUT0101 A
          WHERE A.HOSP_CODE        = C_HOSP_CODE
            AND A.BUNHO            = C_BUNHO
         ;
  M_IF_VALID_YN             OUT0101.IF_VALID_YN   %TYPE;
BEGIN
  M_IF_VALID_YN         := 'N'; 
  FOR A1 IN C1 (
                  :F_HOSP_CODE
                , :F_BUNHO
               )
  LOOP 
     M_IF_VALID_YN      := A1.IF_VALID_YN;
  END LOOP;
  IF (M_IF_VALID_YN = 'N') THEN
      UPDATE OUT0101 A
         SET   A.UPD_ID         = :F_UPD_ID
             , A.UPD_DATE       = SYSDATE
             , A.SUNAME         = :F_SUNAME1
             , A.SUNAME2        = FN_ADM_CONVERT_KATAKANA_HALF(2, :F_SUNAME2)
             , A.SEX            = :F_SEX
             , A.BIRTH          = TO_DATE(:F_BIRTH, 'YYYYMMDD')
             , A.ZIP_CODE1      = :F_ZIP1
             , A.ZIP_CODE2      = :F_ZIP2
             , A.ADDRESS1       = :F_ADDRESS
             , A.ADDRESS2       = NULL
             , A.TEL            = :F_TEL
             , A.TEL_GUBUN      = :F_TEL_GUBUN
             , A.IF_VALID_YN    = :F_VALID_YN
       WHERE A.HOSP_CODE        = :F_HOSP_CODE
         AND A.BUNHO            = :F_BUNHO
      ;
      IF (SQL%NOTFOUND) THEN
        INSERT INTO OUT0101 (
                SYS_DATE      , SYS_ID        , UPD_DATE        , UPD_ID 
              , HOSP_CODE     , BUNHO         , SUNAME          
              , SUNAME2        
              , SEX         
              , BIRTH         
              , ZIP_CODE1     , ZIP_CODE2      
              , ADDRESS1      , TEL           , TEL1        
              , TEL_GUBUN     , TEL_GUBUN2    , IF_VALID_YN
          ) VALUES (
                SYSDATE         , :F_SYS_ID       , SYSDATE           , :F_UPD_ID  
              , :F_HOSP_CODE    , :F_BUNHO        , :F_SUNAME1        
              , FN_ADM_CONVERT_KATAKANA_HALF(2, :F_SUNAME2)
              , :F_SEX
              , TO_DATE(:F_BIRTH, 'YYYYMMDD')
              , :F_ZIP1         , :F_ZIP2        
              , :F_ADDRESS      , :F_TEL          , :F_TEL1
              , :F_TEL_GUBUN    , :F_TEL_GUBUN2   , :F_VALID_YN
          ) ;    
      END IF;
  END IF;
--EXCEPTION
--  WHEN DUP_VAL_ON_INDEX THEN
--    NULL;
--  WHEN OTHERS           THEN
--    NULL;
END;
";

            foreach (DataRow dr in aTable.Rows)
            {
                i++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                bindVals.Clear();

                bindVals.Add("F_SYS_ID", "CONV");
                bindVals.Add("F_UPD_ID", "ORCA");                                                               //REQUIRED "ORCA"
                bindVals.Add("F_HOSP_CODE", EnvironInfo.HospCode);                                              //病院コード
                bunho = dr["bunho"].ToString().Trim();                                                          //患者番号
                bindVals.Add("F_BUNHO", BizCodeHelper.GetStandardBunHo(bunho));
                bindVals.Add("F_SUNAME1", dr["name"].ToString().Trim());
                bindVals.Add("F_SUNAME2", dr["kananame"].ToString().Trim());
                bindVals.Add("F_SEX", (dr["sex"].ToString().Trim()) == "1" ? "M" : "F");
                bindVals.Add("F_BIRTH", dr["birthday"].ToString().Trim());
                if (dr["home_post"].ToString().Trim() != "" && dr["home_post"].ToString().Length >= 7)
                {
                    bindVals.Add("F_ZIP1", dr["home_post"].ToString().Substring(0, 3).Trim());
                    bindVals.Add("F_ZIP2", dr["home_post"].ToString().Substring(3, 4).Trim());
                }
                else
                {
                    bindVals.Add("F_ZIP1", "");
                    bindVals.Add("F_ZIP2", "");
                }
                bindVals.Add("F_ADDRESS", dr["home_adrs"].ToString().Trim() + dr["home_banti"].ToString().Trim());
                // 1st
                tel = dr["home_tel1"].ToString().Trim();
                if (tel != "")
                {
                    if (tel.Length > 3
                        && (tel.Substring(0, 3) == "080" || tel.Substring(0, 3) == "090")
                       )
                    {
                        tel_gubun = "3";
                    }
                    else 
                    {
                        tel_gubun = "1";
                    }
                }
                else
                {
                        tel_gubun = "";
                }
                bindVals.Add("F_TEL", tel);
                bindVals.Add("F_TEL_GUBUN", tel_gubun);
                // 2nd
                tel = dr["home_tel2"].ToString().Trim();
                if (tel != "")
                {
                    if (tel.Length > 3
                        && (tel.Substring(0, 3) == "080" || tel.Substring(0, 3) == "090")
                       )
                    {
                        tel_gubun = "3";
                    }
                    else 
                    {
                        tel_gubun = "1";
                    }
                }
                else
                {
                        tel_gubun = "";
                }
                bindVals.Add("F_TEL1", tel);
                bindVals.Add("F_TEL_GUBUN2", tel_gubun);
                //
                bindVals.Add("F_VALID_YN", "Y");

                if (Service.ExecuteNonQuery(cmd, bindVals) == false)
                {
                    MessageBox.Show(bunho + " - " + Service.ErrFullMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            lbCount.Text = "";
            lbCount.Refresh();

            return true;
        }

        #endregion

        #region 환자별보험 마이그레이션

        private bool UpdatePaBoheom(DataTable aTable)
        {
            string bunho = "";
            string gubun = "";
            string strDateS = "", strDateE = "";

            int i = 0;
            string cmd = "";

            BindVarCollection bindVals = new BindVarCollection();

            cmd = @"
DECLARE
  CURSOR C1 (
               C_HOSP_CODE            OUT0102.HOSP_CODE   %TYPE
             , C_BUNHO                OUT0102.BUNHO       %TYPE
             , C_GUBUN                OUT0102.GUBUN       %TYPE
             , C_START_DATE           OUT0102.START_DATE  %TYPE
            ) IS
         SELECT NVL(A.IF_VALID_YN, 'N')         AS IF_VALID_YN
           FROM OUT0102 A
          WHERE A.HOSP_CODE        = C_HOSP_CODE
            AND A.BUNHO            = C_BUNHO
            AND A.GUBUN            = C_GUBUN
            AND A.START_DATE       = C_START_DATE
         ;
  M_IF_VALID_YN             OUT0102.IF_VALID_YN   %TYPE;
BEGIN
  M_IF_VALID_YN         := 'N'; 
  FOR A1 IN C1 (
                  :F_HOSP_CODE
                , :F_BUNHO
                , :F_GUBUN
                , TO_DATE(:F_START_DATE, 'YYYYMMDD')
               )
  LOOP 
     M_IF_VALID_YN      := A1.IF_VALID_YN;
  END LOOP;
  IF (M_IF_VALID_YN = 'N') THEN
      UPDATE OUT0102 A
         SET   A.UPD_ID         = :F_UPD_ID
             , A.UPD_DATE       = SYSDATE
             , A.END_DATE       = TO_DATE(:F_END_DATE, 'YYYYMMDD')
       WHERE A.HOSP_CODE        = :F_HOSP_CODE
         AND A.BUNHO            = :F_BUNHO
         AND A.GUBUN            = :F_GUBUN
         AND A.START_DATE       = TO_DATE(:F_START_DATE, 'YYYYMMDD')
      ;
      IF (SQL%NOTFOUND) THEN
        INSERT INTO OUT0102 A (
                SYS_DATE      , SYS_ID          , UPD_DATE           , UPD_ID           
              , HOSP_CODE     
              , START_DATE    
              , END_DATE
              , BUNHO         , GUBUN           , JOHAP 
              , GAEIN         , PINAME          
              , BON_GA_GUBUN  , GAEIN_NO        , LAST_CHECK_DATE 
              , CHUIDUK_DATE  , IF_VALID_YN      
          ) VALUES (
                SYSDATE          , :F_SYS_ID          , SYSDATE           , :F_UPD_ID
              , :F_HOSP_CODE     
              , TO_DATE(:F_START_DATE, 'YYYYMMDD')      
              , TO_DATE(:F_END_DATE, 'YYYYMMDD')
              , :F_BUNHO         , :F_GUBUN           , :F_JOHAP 
              , :F_GAEIN         , FN_ADM_CONVERT_KATAKANA_HALF(2, :F_PINAME)          
              , :F_BON_GA_GUBUN  , :F_GAEIN_NO        , TO_DATE(:F_LAST_CHECK_DATE, 'YYYYMMDD')
              , TO_DATE(:F_CHUIDUK_DATE, 'YYYYMMDD')  , :F_IF_VALID_YN      
          ) ;    
      END IF;
    END IF;
--EXCEPTION
--  WHEN DUP_VAL_ON_INDEX THEN
--    NULL;
--  WHEN OTHERS           THEN
--    NULL;
END;
";

            foreach (DataRow dr in aTable.Rows)
            {
                i++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                bindVals.Clear();

                //strDateS = dr["tekstymd"].ToString().Trim(); if (strDateS == "00000000" || strDateS == "") strDateS = "19000101";
                strDateS = dr["tekstymd"].ToString().Trim(); if (strDateS == "00000000" || strDateS == "") strDateS = "19900101";
                strDateE = dr["tekedymd"].ToString().Trim(); if (strDateE == "99999999" || strDateE == "") strDateE = "99981231";

                bunho = BizCodeHelper.GetStandardBunHo(dr["bunho"].ToString().Trim());

                gubun = dr["hknnum"].ToString().Trim();
                switch (gubun)
                {
                    case "060": // 국보의 경우
                        gubun = "00";
                        break;
                    case "971": // 노재의 경우
                        gubun = "R1";
                        break;
                    case "973": // 자배의 경우
                        gubun = "R3";
                        break;
                    case "975": // 공비의 경우(공해보험)
                        gubun = "K5";
                        break;
                    default: // 그외의 경우
                        if (gubun.Substring(0, 2) == "98") // 자비의 경우
                        {
                            gubun = "Z" + gubun.Substring(2, 1);
                        }
                        else
                        {
                            gubun = gubun.Substring(1, 2);
                        }
                        break;
                }

                bindVals.Add("F_SYS_ID", "CONV");
                bindVals.Add("F_UPD_ID", "ORCA");                                                               //REQUIRED "ORCA"
                bindVals.Add("F_HOSP_CODE", EnvironInfo.HospCode);                                              //病院コード
                bunho = dr["bunho"].ToString().Trim();                                                          //患者番号
                bindVals.Add("F_BUNHO", BizCodeHelper.GetStandardBunHo(bunho));
                bindVals.Add("F_GUBUN", gubun.Trim());
                bindVals.Add("F_START_DATE", strDateS.Trim());
                bindVals.Add("F_END_DATE", strDateE.Trim());
                bindVals.Add("F_JOHAP", dr["hknjanum"].ToString().Trim());
                bindVals.Add("F_GAEIN", dr["kigo"].ToString().Trim());
                bindVals.Add("F_PINAME", dr["hihknjaname"].ToString().Trim());
                bindVals.Add("F_BON_GA_GUBUN", (dr["honkzkkbn"].ToString() == "1" ? "0" : "1"));
                bindVals.Add("F_GAEIN_NO", dr["num"].ToString().Trim());
                if (dr["kakuninymd"].ToString().Length != 8)
                {
                    bindVals.Add("F_LAST_CHECK_DATE", "");
                }
                else
                {
                    bindVals.Add("F_LAST_CHECK_DATE", dr["kakuninymd"].ToString().Trim());
                }
                if (dr["skkgetymd"].ToString().Length != 8)
                {
                    bindVals.Add("F_CHUIDUK_DATE", dr["tekstymd"].ToString().Trim());
                }
                else
                {
                    bindVals.Add("F_CHUIDUK_DATE", dr["skkgetymd"].ToString().Trim());
                }
                bindVals.Add("F_IF_VALID_YN", "Y");

                if (Service.ExecuteNonQuery(cmd, bindVals) == false)
                {
                    MessageBox.Show(bunho + " - " + Service.ErrFullMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }

            }

            lbCount.Text = "";
            lbCount.Refresh();

            return true;
        }

        #endregion

        #region 환자별 공비 마이그레이션

        private bool UpdatePatientGongbi(DataTable aTable)
        {
            string bunho = "";
            string gubun = "";
            string strDateS = "", strDateE = "";

            int i = 0;
            string cmd = "";

            BindVarCollection bindVals = new BindVarCollection();

            cmd = @"
DECLARE
  CURSOR C1 (
               C_HOSP_CODE            OUT0105.HOSP_CODE   %TYPE
             , C_BUNHO                OUT0105.BUNHO       %TYPE
             , C_GONGBI_CODE          OUT0105.GONGBI_CODE %TYPE
             , C_START_DATE           OUT0105.START_DATE  %TYPE
            ) IS
         SELECT NVL(A.IF_VALID_YN, 'N')         AS IF_VALID_YN
           FROM OUT0105 A
          WHERE A.HOSP_CODE        = C_HOSP_CODE
            AND A.BUNHO            = C_BUNHO
            AND A.GONGBI_CODE      = C_GONGBI_CODE
            AND A.START_DATE       = C_START_DATE
         ;
  M_IF_VALID_YN             OUT0105.IF_VALID_YN   %TYPE;
BEGIN
  M_IF_VALID_YN         := 'N'; 
  FOR A1 IN C1 (
                  :F_HOSP_CODE
                , :F_BUNHO
                , :F_GONGBI_CODE
                , TO_DATE(:F_START_DATE, 'YYYYMMDD')
               )
  LOOP 
     M_IF_VALID_YN      := A1.IF_VALID_YN;
  END LOOP;
  IF (M_IF_VALID_YN = 'N') THEN
      UPDATE OUT0105 A
         SET   A.UPD_ID         = :F_UPD_ID
             , A.UPD_DATE       = SYSDATE
             , A.END_DATE       = TO_DATE(:F_END_DATE, 'YYYYMMDD')
       WHERE A.HOSP_CODE        = :F_HOSP_CODE
         AND A.BUNHO            = :F_BUNHO
         AND A.GONGBI_CODE      = :F_GONGBI_CODE
         AND A.START_DATE       = TO_DATE(:F_START_DATE, 'YYYYMMDD')
      ;
      IF (SQL%NOTFOUND) THEN
        INSERT INTO OUT0105 A (
                SYS_DATE      , SYS_ID          , UPD_DATE           , UPD_ID
              , HOSP_CODE     
              , START_DATE      
              , END_DATE
              , BUNHO         , GONGBI_CODE     , BUDAMJA_BUNHO 
              , SUGUBJA_BUNHO , LAST_CHECK_DATE 
              , IF_VALID_YN      
          ) VALUES (
                SYSDATE          , :F_SYS_ID          , SYSDATE           , :F_UPD_ID
              , :F_HOSP_CODE     
              , TO_DATE(:F_START_DATE, 'YYYYMMDD')      
              , TO_DATE(:F_END_DATE, 'YYYYMMDD')
              , :F_BUNHO         , :F_GONGBI_CODE     , :F_BUDAMJA_BUNHO
              , :F_SUGUBJA_BUNHO , TO_DATE(:F_LAST_CHECK_DATE, 'YYYYMMDD')
              , :F_IF_VALID_YN      
          ) ;    
      END IF;
  END IF;
--EXCEPTION
--  WHEN DUP_VAL_ON_INDEX THEN
--    NULL;
--  WHEN OTHERS           THEN
--    NULL;
END;
";
            foreach (DataRow dr in aTable.Rows)
            {
                i++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                //strDateS = dr["tekstymd"].ToString().Trim(); if (strDateS == "00000000" || strDateS == "") strDateS = "19000101";
                strDateS = dr["tekstymd"].ToString().Trim(); if (strDateS == "00000000" || strDateS == "") strDateS = "19900101";
                strDateE = dr["tekedymd"].ToString().Trim(); if (strDateE == "99999999" || strDateE == "") strDateE = "99981231";

                bindVals.Clear();

                bunho = BizCodeHelper.GetStandardBunHo(dr["bunho"].ToString().Trim());

                bindVals.Add("F_SYS_ID", "CONV");
                bindVals.Add("F_UPD_ID", "ORCA");                                                               //REQUIRED "ORCA"
                bindVals.Add("F_HOSP_CODE", EnvironInfo.HospCode);                                              //病院コード
                bunho = dr["bunho"].ToString().Trim();
                bindVals.Add("F_BUNHO", BizCodeHelper.GetStandardBunHo(bunho));
                bindVals.Add("F_START_DATE", strDateS.Trim());
                bindVals.Add("F_END_DATE", strDateE.Trim());
                bindVals.Add("F_BUDAMJA_BUNHO", dr["ftnjanum"].ToString().Trim());
                bindVals.Add("F_GONGBI_CODE", dr["kohnum"].ToString().Trim());
                bindVals.Add("F_SUGUBJA_BUNHO", dr["jkysnum"].ToString().Trim());
                if (dr["kakuninymd"].ToString().Length != 8)
                {
                    bindVals.Add("F_LAST_CHECK_DATE", "");
                }
                else
                {
                    bindVals.Add("F_LAST_CHECK_DATE", dr["kakuninymd"].ToString().Trim());
                }
                bindVals.Add("F_IF_VALID_YN", "Y");

                if (Service.ExecuteNonQuery(cmd, bindVals) == false)
                {
                    MessageBox.Show(bunho + " - " + Service.ErrFullMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            lbCount.Text = "";
            lbCount.Refresh();

            return true;
        }

        #endregion

        #region 셋트 코드

        private bool UpdateSetOrder(DataTable aTable)
        {

            int i = 0;
            string cmd = "";
            string bunho = "";
            //string gubun = "";

            foreach (DataRow dr in aTable.Rows)
            {
                i++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                cmd = " INSERT INTO CNV0007 "
                    + " VALUES "
                    + "      ( '" + dr["setcd"].ToString() + "' "
                    + "      , '" + dr["yukostymd"].ToString() + "' "
                    + "      , '" + dr["yukoedymd"].ToString() + "' "
                    + "      , " + dr["setseq"].ToString() 
                    +"      , '" + dr["inputcd"].ToString() + "' "
                    + "      , " + dr["suryo1"].ToString() 
                    +"      , " + dr["suryo2"].ToString() 
                    +"      , " + dr["kaisu"].ToString() 
                    +"      , '" + dr["coment"].ToString() + "' "
                    + "      , '" + dr["atai1"].ToString() + "' "
                    + "      , '" + dr["atai2"].ToString() + "' "
                    + "      , '" + dr["atai3"].ToString() + "' "
                    + "      , '" + dr["atai4"].ToString() + "' "
                    + "      , '" + dr["termid"].ToString() + "' "
                    + "      , '" + dr["opid"].ToString() + "' "
                    + "      , '" + dr["creymd"].ToString() + "' "
                    + "      , '" + dr["upymd"].ToString() + "' "
                    + "      , '" + dr["uphms"].ToString() + "' "
                    + "      , " + dr["hospnum"].ToString() 
                    +"      , '" + dr["inputkbn"].ToString() + "' "
                    + "      , " + dr["kansuryo"].ToString() + ") ";
                    
                    


                if (Service.ExecuteNonQuery(cmd) == false)
                {
                    MessageBox.Show(bunho + " - " + Service.ErrFullMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            lbCount.Text = "";
            lbCount.Refresh();

            return true;
        }

        #endregion

        #region 셋트 Code

        private bool UpdateSetCode(DataTable aTable)
        {

            int i = 0;
            string cmd = "";
            string bunho = "";
            //string gubun = "";

            foreach (DataRow dr in aTable.Rows)
            {
                i++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                cmd = " INSERT INTO CNV0008 "
                    + " VALUES "
                    + "      ( '" + dr["cdsyu"].ToString() + "' "
                    + "      , '" + dr["inputcd"].ToString() + "' "
                    + "      , '" + dr["srykbn"].ToString() + "' "
                    + "      , '" + dr["srycd"].ToString() +"' "
                    + "      , " + dr["dspseq"].ToString()
                    + "      , '" + dr["dspname"].ToString() + "' "
                    + "      , '" + dr["termid"].ToString() + "' "
                    + "      , '" + dr["opid"].ToString() + "' "
                    + "      , '" + dr["creymd"].ToString() + "' "
                    + "      , '" + dr["upymd"].ToString() + "' "
                    + "      , '" + dr["uphms"].ToString() + "' "
                    + "      , " + dr["hospnum"].ToString() + ") ";




                if (Service.ExecuteNonQuery(cmd) == false)
                {
                    MessageBox.Show(bunho + " - " + Service.ErrFullMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            lbCount.Text = "";
            lbCount.Refresh();

            return true;
        }

        #endregion

        #region 사용자마스터

        private bool UpdateUserMaster(DataTable aTable)
        {
            int i = 0, im = 0;
            string cmd = "";
            string cmd0 = "";
            string strDateS = "", strDateE = "";
            string strUserInfo = "";
            string strUserCode = "";
            string strUserDept = "";
            string strUserGroup = "";
            string strUserGubun = "";
            string strNurseConfirmYN = "";

            Service.BeginTransaction();

            foreach (DataRow dr in aTable.Rows)
            {
                i++; im++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                strDateS = dr["styukymd"].ToString(); if (strDateS == "00000000" || strDateS == "") strDateS = "19000101";
                strDateE = dr["edyukymd"].ToString(); if (strDateE == "99999999" || strDateE == "") strDateE = "99981231";

                strUserCode = dr["kbncd"].ToString().Trim();
                strUserInfo = dr["kanritbl"].ToString();

                if (strUserCode.ToString() != "00001")
                {

                    switch (strUserCode.Substring(0, 1))
                    {
                        case "1":  // 의국
                            strUserDept = "91000";
                            strUserGroup = "OCS";
                            strUserGubun = "1";
                            strNurseConfirmYN = "N";
                            break;

                        case "2":  // 간호부
                            strUserDept = "30000";
                            strUserGroup = "NUR";
                            strUserGubun = "2";
                            strNurseConfirmYN = "Y";

                            break;

                        case "3":  // 부문...
                            //strUserDept = "";
                            strUserDept = "59100";      // 전산실
                            //strUserGroup = "";
                            strUserGroup = "ADMIN";     // Admin
                            strUserGubun = "3";         // 기사
                            strNurseConfirmYN = "N";

                            break;

                        case "4":  // 사무
                            strUserDept = "51200";      // 외래청구
                            strUserGroup = "OUT";       // 외래회계
                            strUserGubun = "4";
                            strNurseConfirmYN = "N";

                            break;

                        case "5":  // 관리
                            strUserDept = "59100";     // 전산실
                            strUserGroup = "ADMIN";
                            strUserGubun = "5";
                            strNurseConfirmYN = "N";

                            break;

                        default:  // ???
                            strUserDept = "59100";      // 전산실
                            strUserGroup = "ADMIN";     // Admin
                            strUserGubun = "3";         // 기사
                            strNurseConfirmYN = "N";

                            break;
                    }

                    // ADM3200 : 시스템 사용자 등록
                    // BAS0271 : 의사정보 등록
                    // BAS0272 : 의사별 과 등록

                    #region cmd0 최초 로딩용
                    cmd0 = " DECLARE "
                        + "   M_DUMMY   VARCHAR2(1024) ; "
                        + "   M_GWALIST VARCHAR2(10) ; "
                        + "   R1 ADM3200%ROWTYPE ; "
                        + "   R2 BAS0271%ROWTYPE ; "
                        + "   R3 BAS0272%ROWTYPE ; "
                        + " BEGIN "
                        + "   M_DUMMY                       := '" + strUserInfo + "' ; "
                        + "   M_GWALIST                     := TRIM(SUBSTRB(M_DUMMY, 205, 10)) ; "
                        //+ "   dbms_output.put_line(m_dummy)  ; "
                        + "   R1.SYS_ID                     := 'CONV' ; "
                        + "   R1.CR_TIME                    := SYSDATE ; "
                        + "   R1.CR_MEMB                    := 'CONV' ; "
                        + "   R1.CR_TRM                     := 'CONV' ; "
                        + "   R1.HOSP_CODE                  := '" + EnvironInfo.HospCode + "' ; "
                        //+ "   R1.USER_ID                    := TRIM(SUBSTRB(M_DUMMY,  1, 16)) ; "
                        + "   R1.USER_ID                    := '" + strUserCode + "' ; "
                        + "   R1.USER_NM                    := TRIM(SUBSTRB(M_DUMMY, 97, 80)) ; "
                        + "   R1.USER_SCRT                  := '1111' ; "
                        + "   R1.DEPT_CODE                  := '" + strUserDept + "' ; "
                        + "   R1.USER_GROUP                 := '" + strUserGroup + "' ; "
                        + "   R1.USER_LEVEL                 :=  9 ; "
                        + "   R1.USER_GUBUN                 := '" + strUserGubun + "' ; "
                        + "   R1.USER_END_YMD               := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "   R1.NURSE_CONFIRM_ENABLE_YN    := '" + strNurseConfirmYN + "' ; "
                        //+ "     INSERT INTO ADM3200 ( "
                        + "     INSERT INTO ADM3200_T ( "
                        + "               SYS_ID                 , HOSP_CODE "
                        + "             , CR_TIME                , CR_MEMB                 , CR_TRM "
                        + "             , USER_ID                , USER_NM                 , USER_SCRT "
                        + "             , DEPT_CODE              , USER_GROUP              , USER_LEVEL                 , USER_GUBUN "
                        + "             , USER_END_YMD "
                        + "             , NURSE_CONFIRM_ENABLE_YN "
                        + "             ) VALUES ("
                        + "               R1.SYS_ID              , R1.HOSP_CODE "
                        + "             , R1.CR_TIME             , R1.CR_MEMB              , R1.CR_TRM "
                        + "             , R1.USER_ID             , R1.USER_NM              , R1.USER_SCRT "
                        + "             , R1.DEPT_CODE           , R1.USER_GROUP           , R1.USER_LEVEL              , R1.USER_GUBUN "
                        + "             , R1.USER_END_YMD "
                        + "             , R1.NURSE_CONFIRM_ENABLE_YN "
                        + "             ) ; "
                        + "   IF (R1.USER_GUBUN = '1') THEN "  // 의사
                        + "     R2.SYS_DATE             := R1.CR_TIME ; "
                        + "     R2.SYS_ID               := R1.SYS_ID ; "
                        + "     R2.HOSP_CODE            := R1.HOSP_CODE ; "
                        + "     R2.SABUN                := R1.USER_ID ; "
                        + "     R2.DOCTOR               := R1.USER_ID ; "
                        + "     R2.DOCTOR_NAME          := R1.USER_NM ; "
                        + "     R2.DOCTOR_NAME2         := TRIM(SUBSTRB(M_DUMMY,  17, 80)) ; "
                        + "     R2.START_DATE           := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                        + "     R2.END_DATE             := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "     R2.DOCTOR_GRADE         := '1' ; "
                        + "     R2.RESER_YN             := 'Y' ; "
                        + "     R2.OCS_STATUS           := 'Y' ; "
                        + "     R2.JUBSU_YN             := 'Y' ; "
                        + "     R2.CP_DOCTOR_YN         := 'Y' ; "
                        + "     R2.MAYAK_LICENSE        := TRIM(SUBSTRB(M_DUMMY, 286, 40)) ; "
                        //+ "     INSERT INTO BAS0271 ( "
                        + "       INSERT INTO BAS0271_T ( "
                        + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                        + "             , SABUN                  , DOCTOR                  , DOCTOR_NAME                   , DOCTOR_NAME2 "
                        + "             , START_DATE             , END_DATE "
                        + "             , DOCTOR_GRADE           , RESER_YN                , OCS_STATUS "
                        + "             , JUBSU_YN               , CP_DOCTOR_YN            , MAYAK_LICENSE "
                        + "             ) VALUES ("
                        + "               R2.SYS_DATE            , R2.SYS_ID               , R2.HOSP_CODE "
                        + "             , R2.SABUN               , R2.DOCTOR               , R2.DOCTOR_NAME                , R2.DOCTOR_NAME2 "
                        + "             , R2.START_DATE          , R2.END_DATE "
                        + "             , R2.DOCTOR_GRADE        , R2.RESER_YN             , R2.OCS_STATUS "
                        + "             , R2.JUBSU_YN            , R2.CP_DOCTOR_YN         , R2.MAYAK_LICENSE "
                        + "             ) ; "
                        + "     R3.SYS_DATE             := R2.SYS_DATE ; "
                        + "     R3.SYS_ID               := R2.SYS_ID ; "
                        + "     R3.HOSP_CODE            := R2.HOSP_CODE ; "
                        + "     R3.SABUN                := R2.SABUN ; "
                        + "     R3.DOCTOR               := R2.DOCTOR ; "
                        + "     R3.START_DATE           := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                        + "     R3.END_DATE             := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "     R3.MAIN_GWA_YN          := 'Y' ; "
                        + "     R3.DOCTOR_GWA   := TRIM(SUBSTR(M_GWALIST, 1, 2)) ; "
                        + "     WHILE (LENGTH(R3.DOCTOR_GWA) = 2 OR LENGTH(R3.DOCTOR_GWA) IS NOT NULL) LOOP "
                        + "       BEGIN "
                        //+ "       INSERT INTO BAS0272 ( "
                        + "         INSERT INTO BAS0272_T ( "
                        + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                        + "             , SABUN                  , DOCTOR "
                        + "             , START_DATE             , END_DATE "
                        + "             , DOCTOR_GWA             , MAIN_GWA_YN "
                        + "             ) VALUES ("
                        + "               R3.SYS_DATE            , R3.SYS_ID               , R3.HOSP_CODE "
                        + "             , R3.SABUN               , R3.DOCTOR "
                        + "             , R3.START_DATE          , R3.END_DATE "
                        + "             , R3.DOCTOR_GWA          , R3.MAIN_GWA_YN "
                        + "             ) ; "
                        + "       EXCEPTION "
                        + "         WHEN DUP_VAL_ON_INDEX THEN "
                        //+ "           UPDATE BAS0272 A "
                        + "           UPDATE BAS0272_T A "
                        + "              SET A.UPD_DATE         = R3.SYS_DATE "
                        + "                  , A.UPD_ID         = R3.SYS_ID "
                        + "                  , A.END_DATE       = R3.END_DATE "
                        + "            WHERE A.HOSP_CODE        = R3.HOSP_CODE "
                        + "              AND A.SABUN            = R3.SABUN "
                        + "              AND A.DOCTOR           = R3.DOCTOR "
                        + "              AND A.START_DATE       = R3.START_DATE "
                        + "              AND A.DOCTOR_GWA       = R3.DOCTOR_GWA "
                        + "              AND NOT EXISTS ( SELECT NULL "
                        //+ "                                 FROM BAS0272 Z "
                        + "                                 FROM BAS0272_T Z "
                        + "                                WHERE Z.HOSP_CODE            = R3.HOSP_CODE "
                        + "                                  AND Z.SABUN                = R3.SABUN "
                        + "                                  AND Z.DOCTOR               = R3.DOCTOR "
                        + "                                  AND Z.START_DATE           = R3.START_DATE "
                        + "                                  AND Z.DOCTOR_GWA           = R3.DOCTOR_GWA "
                        + "                                  AND Z.END_DATE             = R3.END_DATE "
                        + "                            ) ;"
                        //+ "         WHEN OTHERS THEN "
                        //+ "           NULL ; "
                        + "       END ; "
                        + "       M_GWALIST         := TRIM(SUBSTR(M_GWALIST, 3, 10)) ; "
                        + "       R3.DOCTOR_GWA     := TRIM(SUBSTR(M_GWALIST, 1, 2)) ; "
                        + "       R3.MAIN_GWA_YN    := 'N' ; "
                        + "    END LOOP ;  "
                        + "   END IF ; "
                        + " END ; "
                        ;
                    #endregion cmd0  최초 로딩용
                    #region cmd
                    cmd = " DECLARE "
                        + "   M_DUMMY   VARCHAR2(1024) ; "
                        + "   M_GWALIST VARCHAR2(10) ; "
                        + "   R1 ADM3200%ROWTYPE ; "
                        + "   R2 BAS0271%ROWTYPE ; "
                        + "   R3 BAS0272%ROWTYPE ; "
                        + " BEGIN "
                        + "   M_DUMMY                       := '" + strUserInfo + "' ; "
                        + "   M_GWALIST                     := TRIM(SUBSTRB(M_DUMMY, 205, 10)) ; "
                        //+ "   dbms_output.put_line(m_dummy)  ; "
                        + "   R1.SYS_ID                     := 'CONV' ; "
                        + "   R1.CR_TIME                    := SYSDATE ; "
                        + "   R1.CR_MEMB                    := 'CONV' ; "
                        + "   R1.CR_TRM                     := 'CONV' ; "
                        + "   R1.HOSP_CODE                  := '" + EnvironInfo.HospCode + "' ; "
                        //+ "   R1.USER_ID                    := TRIM(SUBSTRB(M_DUMMY,  1, 16)) ; "
                        + "   R1.USER_ID                    := '" + strUserCode + "' ; "
                        + "   R1.USER_NM                    := TRIM(SUBSTRB(M_DUMMY, 97, 80)) ; "
                        + "   R1.USER_SCRT                  := '1111' ; "
                        + "   R1.DEPT_CODE                  := '" + strUserDept + "' ; "
                        + "   R1.USER_GROUP                 := '" + strUserGroup + "' ; "
                        + "   R1.USER_LEVEL                 :=  9 ; "
                        + "   R1.USER_GUBUN                 := '" + strUserGubun + "' ; "
                        + "   R1.USER_END_YMD               := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "   R1.NURSE_CONFIRM_ENABLE_YN    := '" + strNurseConfirmYN + "' ; "
                        + "   BEGIN "
                        //+ "     INSERT INTO ADM3200 ( "
                        + "     INSERT INTO ADM3200_T ( "
                        + "               SYS_ID                 , HOSP_CODE "
                        + "             , CR_TIME                , CR_MEMB                 , CR_TRM "
                        + "             , USER_ID                , USER_NM                 , USER_SCRT "
                        + "             , DEPT_CODE              , USER_GROUP              , USER_LEVEL                 , USER_GUBUN "
                        + "             , USER_END_YMD "
                        + "             , NURSE_CONFIRM_ENABLE_YN "
                        + "             ) VALUES ("
                        + "               R1.SYS_ID              , R1.HOSP_CODE "
                        + "             , R1.CR_TIME             , R1.CR_MEMB              , R1.CR_TRM "
                        + "             , R1.USER_ID             , R1.USER_NM              , R1.USER_SCRT "
                        + "             , R1.DEPT_CODE           , R1.USER_GROUP           , R1.USER_LEVEL              , R1.USER_GUBUN "
                        + "             , R1.USER_END_YMD "
                        + "             , R1.NURSE_CONFIRM_ENABLE_YN "
                        + "             ) ; "
                        + "   EXCEPTION "
                        + "     WHEN DUP_VAL_ON_INDEX THEN "
                        //+ "       UPDATE ADM3200 A "
                        + "       UPDATE ADM3200_T A "
                        + "          SET A.UP_TIME          = R1.CR_TIME "
                        + "              , A.UP_MEMB        = R1.CR_MEMB "
                        + "              , A.USER_END_YMD   = R1.USER_END_YMD "
                        + "        WHERE A.HOSP_CODE        = R1.HOSP_CODE "
                        + "          AND A.USER_ID          = R1.USER_ID "
                        + "          AND NOT EXISTS ( SELECT NULL "
                        //+ "                             FROM ADM3200 Z "
                        + "                             FROM ADM3200_T Z "
                        + "                            WHERE Z.HOSP_CODE            = R1.HOSP_CODE "
                        + "                              AND Z.USER_ID              = R1.USER_ID "
                        + "                              AND Z.USER_END_YMD         = R1.USER_END_YMD "
                        + "                        ) "
                        + "       ; "
                        //+ "     WHEN OTHERS THEN "
                        //+ "       NULL ; "
                        + "   END ; "
                        + "   IF (R1.USER_GUBUN = '1') THEN "  // 의사
                        + "     R2.SYS_DATE             := R1.CR_TIME ; "
                        + "     R2.SYS_ID               := R1.SYS_ID ; "
                        + "     R2.HOSP_CODE            := R1.HOSP_CODE ; "
                        + "     R2.SABUN                := R1.USER_ID ; "
                        + "     R2.DOCTOR               := R1.USER_ID ; "
                        + "     R2.DOCTOR_NAME          := R1.USER_NM ; "
                        + "     R2.DOCTOR_NAME2         := TRIM(SUBSTRB(M_DUMMY,  17, 80)) ; "
                        + "     R2.START_DATE           := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                        + "     R2.END_DATE             := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "     R2.DOCTOR_GRADE         := '1' ; "
                        + "     R2.RESER_YN             := 'Y' ; "
                        + "     R2.OCS_STATUS           := 'Y' ; "
                        + "     R2.JUBSU_YN             := 'Y' ; "
                        + "     R2.CP_DOCTOR_YN         := 'Y' ; "
                        + "     R2.MAYAK_LICENSE        := TRIM(SUBSTRB(M_DUMMY, 286, 40)) ; "
                        + "     BEGIN "
                        //+ "     INSERT INTO BAS0271 ( "
                        + "       INSERT INTO BAS0271_T ( "
                        + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                        + "             , SABUN                  , DOCTOR                  , DOCTOR_NAME                   , DOCTOR_NAME2 "
                        + "             , START_DATE             , END_DATE "
                        + "             , DOCTOR_GRADE           , RESER_YN                , OCS_STATUS "
                        + "             , JUBSU_YN               , CP_DOCTOR_YN            , MAYAK_LICENSE "
                        + "             ) VALUES ("
                        + "               R2.SYS_DATE            , R2.SYS_ID               , R2.HOSP_CODE "
                        + "             , R2.SABUN               , R2.DOCTOR               , R2.DOCTOR_NAME                , R2.DOCTOR_NAME2 "
                        + "             , R2.START_DATE          , R2.END_DATE "
                        + "             , R2.DOCTOR_GRADE        , R2.RESER_YN             , R2.OCS_STATUS "
                        + "             , R2.JUBSU_YN            , R2.CP_DOCTOR_YN         , R2.MAYAK_LICENSE "
                        + "             ) ; "
                        + "     EXCEPTION "
                        + "       WHEN DUP_VAL_ON_INDEX THEN "
                        //+ "         UPDATE BAS0271 A "
                        + "         UPDATE BAS0271_T A "
                        + "            SET A.UPD_DATE         = R2.SYS_DATE "
                        + "                , A.UPD_ID         = R2.SYS_ID "
                        + "                , A.END_DATE       = R2.END_DATE "
                        + "          WHERE A.HOSP_CODE        = R2.HOSP_CODE "
                        + "            AND A.SABUN            = R2.SABUN "
                        + "            AND A.DOCTOR           = R2.DOCTOR "
                        + "            AND A.START_DATE       = R2.START_DATE "
                        + "            AND NOT EXISTS ( SELECT NULL "
                        //+ "                               FROM BAS0271 Z "
                        + "                               FROM BAS0271_T Z "
                        + "                              WHERE Z.HOSP_CODE            = R2.HOSP_CODE "
                        + "                                AND Z.SABUN                = R2.SABUN "
                        + "                                AND Z.DOCTOR               = R2.DOCTOR "
                        + "                                AND Z.START_DATE           = R2.START_DATE "
                        + "                                AND Z.END_DATE             = R2.END_DATE "
                        + "                          ) ;"
                        //+ "       WHEN OTHERS THEN "
                        //+ "         NULL ; "
                        + "     END ; "
                        + "     R3.SYS_DATE             := R2.SYS_DATE ; "
                        + "     R3.SYS_ID               := R2.SYS_ID ; "
                        + "     R3.HOSP_CODE            := R2.HOSP_CODE ; "
                        + "     R3.SABUN                := R2.SABUN ; "
                        + "     R3.DOCTOR               := R2.DOCTOR ; "
                        + "     R3.START_DATE           := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                        + "     R3.END_DATE             := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "     R3.MAIN_GWA_YN          := 'Y' ; "
                        + "     R3.DOCTOR_GWA   := TRIM(SUBSTR(M_GWALIST, 1, 2)) ; "
                        + "     WHILE (LENGTH(R3.DOCTOR_GWA) = 2 OR LENGTH(R3.DOCTOR_GWA) IS NOT NULL) LOOP "
                        + "       BEGIN "
                        //+ "       INSERT INTO BAS0272 ( "
                        + "         INSERT INTO BAS0272_T ( "
                        + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                        + "             , SABUN                  , DOCTOR "
                        + "             , START_DATE             , END_DATE "
                        + "             , DOCTOR_GWA             , MAIN_GWA_YN "
                        + "             ) VALUES ("
                        + "               R3.SYS_DATE            , R3.SYS_ID               , R3.HOSP_CODE "
                        + "             , R3.SABUN               , R3.DOCTOR "
                        + "             , R3.START_DATE          , R3.END_DATE "
                        + "             , R3.DOCTOR_GWA          , R3.MAIN_GWA_YN "
                        + "             ) ; "
                        + "       EXCEPTION "
                        + "         WHEN DUP_VAL_ON_INDEX THEN "
                        //+ "           UPDATE BAS0272 A "
                        + "           UPDATE BAS0272_T A "
                        + "              SET A.UPD_DATE         = R3.SYS_DATE "
                        + "                  , A.UPD_ID         = R3.SYS_ID "
                        + "                  , A.END_DATE       = R3.END_DATE "
                        + "            WHERE A.HOSP_CODE        = R3.HOSP_CODE "
                        + "              AND A.SABUN            = R3.SABUN "
                        + "              AND A.DOCTOR           = R3.DOCTOR "
                        + "              AND A.START_DATE       = R3.START_DATE "
                        + "              AND A.DOCTOR_GWA       = R3.DOCTOR_GWA "
                        + "              AND NOT EXISTS ( SELECT NULL "
                        //+ "                                 FROM BAS0272 Z "
                        + "                                 FROM BAS0272_T Z "
                        + "                                WHERE Z.HOSP_CODE            = R3.HOSP_CODE "
                        + "                                  AND Z.SABUN                = R3.SABUN "
                        + "                                  AND Z.DOCTOR               = R3.DOCTOR "
                        + "                                  AND Z.START_DATE           = R3.START_DATE "
                        + "                                  AND Z.DOCTOR_GWA           = R3.DOCTOR_GWA "
                        + "                                  AND Z.END_DATE             = R3.END_DATE "
                        + "                            ) ;"
                        //+ "         WHEN OTHERS THEN "
                        //+ "           NULL ; "
                        + "       END ; "
                        + "       M_GWALIST         := TRIM(SUBSTR(M_GWALIST, 3, 10)) ; "
                        + "       R3.DOCTOR_GWA     := TRIM(SUBSTR(M_GWALIST, 1, 2)) ; "
                        + "       R3.MAIN_GWA_YN    := 'N' ; "
                        + "    END LOOP ;  "
                        + "   END IF ; "
                        + " END ; "
                        ;
                    #endregion cmd
                    //cmd = " DECLARE "
                    cmd = " DECLARE "
                        //    의사과
                        + "   CURSOR CDG1  ( "
                        + "                   C_HOSP_CODE    BAS0272.HOSP_CODE  %TYPE "
                        + "                 , C_SABUN        BAS0272.SABUN      %TYPE "
                        + "                 , C_DOCTOR       BAS0272.DOCTOR     %TYPE "
                        + "                 , C_START_DATE   BAS0272.START_DATE %TYPE "
                        + "                 , C_DOCTOR_GWA   BAS0272.DOCTOR_GWA %TYPE "
                        + "                ) IS "
                        + "     SELECT  "
                        //               이번 적용일건이 이미 존재하는지의 여부
                        //               이번건이 있으면 'Y', 없고 이후건이 있으면 'N', 이후건도 없으면 NULL 
                        + "              MAX(DECODE(A.START_DATE, C_START_DATE, 'Y', 'N'))   AS IS_CUR_YN  "
                        //               이번 적용일건 이후 DATA가 있으면 직후 적용일을 읽어 이번건의 종료일(-1일) 반영, 
                        //               이후 DATA가 없고, 이번건이 이미 있으면 9998/12/31, 이번건도 없으면 NULL 
                        + "            , MIN(DECODE(A.START_DATE, C_START_DATE, TO_DATE('99981231', 'YYYYMMDD'), A.START_DATE))  "
                        + "                                                                 AS MIN_START_DATE  "
                        + "       FROM BAS0272 A "
                        //+ "       FROM BAS0272_T A "
                        + "      WHERE A.HOSP_CODE        = C_HOSP_CODE    "
                        + "        AND A.SABUN            = C_SABUN        "
                        + "        AND A.DOCTOR           = C_DOCTOR       "
                        + "        AND A.START_DATE       >= C_START_DATE   "
                        + "        AND A.DOCTOR_GWA       = C_DOCTOR_GWA   "
                        + "     ; "
                        //    의사
                        + "   CURSOR CD1  ( "
                        + "                   C_HOSP_CODE    BAS0271.HOSP_CODE  %TYPE "
                        + "                 , C_SABUN        BAS0271.SABUN      %TYPE "
                        + "                 , C_DOCTOR       BAS0271.DOCTOR     %TYPE "
                        + "                 , C_START_DATE   BAS0271.START_DATE %TYPE "
                        + "                ) IS "
                        + "     SELECT  "
                        //               이번 적용일건이 이미 존재하는지의 여부
                        //               이번건이 있으면 'Y', 없고 이후건이 있으면 'N', 이후건도 없으면 NULL 
                        + "              MAX(DECODE(A.START_DATE, C_START_DATE, 'Y', 'N'))   AS IS_CUR_YN  "
                        //               이번 적용일건 이후 DATA가 있으면 직후 적용일을 읽어 이번건의 종료일(-1일) 반영, 
                        //               이후 DATA가 없고, 이번건이 이미 있으면 9998/12/31, 이번건도 없으면 NULL 
                        + "            , MIN(DECODE(A.START_DATE, C_START_DATE, TO_DATE('99981231', 'YYYYMMDD'), A.START_DATE))  "
                        + "                                                                 AS MIN_START_DATE  "
                        + "       FROM BAS0271 A "
                        //+ "       FROM BAS0271_T A "
                        + "      WHERE A.HOSP_CODE        = C_HOSP_CODE    "
                        + "        AND A.SABUN            = C_SABUN        "
                        + "        AND A.DOCTOR           = C_DOCTOR       "
                        + "        AND A.START_DATE       >= C_START_DATE   "
                        + "     ; "
                        + "   M_DUMMY     VARCHAR2(1024) ; "
                        + "   M_MAIN_GWA  BAS0272.DOCTOR_GWA %TYPE ; "
                        + "   M_GWALIST   VARCHAR2(10) ; "
                        + "   R1          ADM3200%ROWTYPE ; "
                        + "   R2          BAS0271%ROWTYPE ; "
                        + "   R3          BAS0272%ROWTYPE ; "
                        + " BEGIN "
                        + "   M_DUMMY                       := '" + strUserInfo + "' ; "
                        + "   M_GWALIST                     := TRIM(SUBSTRB(M_DUMMY, 205, 10)) ; "
                        //
                        + "   R1.SYS_ID                     := 'CONV' ; "
                        + "   R1.CR_TIME                    := SYSDATE ; "
                        + "   R1.CR_MEMB                    := 'CONV' ; "
                        + "   R1.CR_TRM                     := 'CONV' ; "
                        + "   R1.HOSP_CODE                  := '" + EnvironInfo.HospCode + "' ; "
                        //+ "   R1.USER_ID                    := TRIM(SUBSTRB(M_DUMMY,  1, 16)) ; "
                        + "   R1.USER_ID                    := '" + strUserCode + "' ; "
                        + "   R1.USER_NM                    := TRIM(SUBSTRB(M_DUMMY, 97, 80)) ; "
                        + "   R1.USER_SCRT                  := '1111' ; "
                        + "   R1.DEPT_CODE                  := '" + strUserDept + "' ; "
                        + "   R1.USER_GROUP                 := '" + strUserGroup + "' ; "
                        + "   R1.USER_LEVEL                 :=  9 ; "
                        + "   R1.USER_GUBUN                 := '" + strUserGubun + "' ; "
                        + "   R1.USER_END_YMD               := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "   R1.NURSE_CONFIRM_ENABLE_YN    := '" + strNurseConfirmYN + "' ; "
                        + "   BEGIN "
                        + "     INSERT INTO ADM3200 ( "
                        //+ "     INSERT INTO ADM3200_T ( "
                        + "               SYS_ID                 , HOSP_CODE "
                        + "             , CR_TIME                , CR_MEMB                 , CR_TRM "
                        + "             , USER_ID                , USER_NM                 , USER_SCRT "
                        + "             , DEPT_CODE              , USER_GROUP              , USER_LEVEL                 , USER_GUBUN "
                        + "             , USER_END_YMD "
                        + "             , NURSE_CONFIRM_ENABLE_YN "
                        + "             ) VALUES ("
                        + "               R1.SYS_ID              , R1.HOSP_CODE "
                        + "             , R1.CR_TIME             , R1.CR_MEMB              , R1.CR_TRM "
                        + "             , R1.USER_ID             , R1.USER_NM              , R1.USER_SCRT "
                        + "             , R1.DEPT_CODE           , R1.USER_GROUP           , R1.USER_LEVEL              , R1.USER_GUBUN "
                        + "             , R1.USER_END_YMD "
                        + "             , R1.NURSE_CONFIRM_ENABLE_YN "
                        + "             ) ; "
                        + "   EXCEPTION "
                        + "     WHEN DUP_VAL_ON_INDEX THEN "
                        + "       UPDATE ADM3200 A "
                        //+ "       UPDATE ADM3200_T A "
                        + "          SET A.UP_TIME          = R1.CR_TIME "
                        + "              , A.UP_MEMB        = R1.CR_MEMB "
                        // ORCA 반영 데이타
                        + "              , A.USER_NM        = R1.USER_NM "
                        + "              , A.USER_END_YMD   = R1.USER_END_YMD "
                        //
                        + "        WHERE A.HOSP_CODE        = R1.HOSP_CODE "
                        + "          AND A.USER_ID          = R1.USER_ID "
                        + "          AND NOT EXISTS ( SELECT NULL "
                        + "                             FROM ADM3200 Z "
                        //+ "                             FROM ADM3200_T Z "
                        + "                            WHERE Z.HOSP_CODE            = R1.HOSP_CODE "
                        + "                              AND Z.USER_ID              = R1.USER_ID "
                        + "                              AND (   Z.USER_END_YMD     = R1.USER_END_YMD "
                        + "                                   OR Z.USER_END_YMD     IS NULL "
                        + "                                  ) "
                        + "                        ) "
                        + "       ; "
                        //+ "   WHEN OTHERS THEN "
                        //+ "       NULL ; "
                        + "   END ; "
                        // 사용자가 의사의 경우 의사 TABLE에 반영
                        + "   IF (R1.USER_GUBUN = '1') THEN "  // 의사
                        + "     R2.SYS_DATE             := R1.CR_TIME ; "
                        + "     R2.SYS_ID               := R1.SYS_ID ; "
                        + "     R2.HOSP_CODE            := R1.HOSP_CODE ; "
                        + "     R2.SABUN                := R1.USER_ID ; "
                        + "     R2.DOCTOR               := R1.USER_ID ; "
                        + "     R2.DOCTOR_NAME          := R1.USER_NM ; "
                        + "     R2.DOCTOR_NAME2         := FN_ADM_CONVERT_KATAKANA_HALF(2, TRIM(SUBSTRB(M_DUMMY,  17, 80))) ; "
                        + "     R2.START_DATE           := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                        + "     R2.END_DATE             := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "     R2.DOCTOR_GRADE         := '1' ; "
                        + "     R2.RESER_YN             := 'Y' ; "
                        + "     R2.OCS_STATUS           := 'Y' ; "
                        + "     R2.JUBSU_YN             := 'Y' ; "
                        + "     R2.CP_DOCTOR_YN         := 'Y' ; "
                        + "     R2.MAYAK_LICENSE        := TRIM(SUBSTRB(M_DUMMY, 286, 40)) ; "
                        //      이전것 종료처리
                        + "     UPDATE BAS0271 A "
                        //+ "     UPDATE BAS0271_T A "
                        + "        SET A.UPD_DATE         = R2.SYS_DATE "
                        + "            , A.UPD_ID         = R2.SYS_ID "
                        + "            , A.END_DATE       = R2.START_DATE - 1 "
                        + "      WHERE A.HOSP_CODE        = R2.HOSP_CODE "
                        + "        AND A.SABUN            = R2.SABUN "
                        + "        AND A.DOCTOR           = R2.DOCTOR "
                        + "        AND A.START_DATE       = ( SELECT MAX(Z.START_DATE) "
                        + "                                     FROM BAS0271 Z "
                        //+ "                                     FROM BAS0271_T Z "
                        + "                                    WHERE Z.HOSP_CODE            = R2.HOSP_CODE      "
                        + "                                      AND Z.SABUN                = R2.SABUN          "
                        + "                                      AND Z.DOCTOR               = R2.DOCTOR         "
                        + "                                      AND Z.START_DATE           < R2.START_DATE     "
                        + "                                      AND Z.END_DATE             > R2.START_DATE - 1 "
                        + "                                ) "
                        + "     ; "
                        //      현재이후 여부 CHECK 후 UPDATE/INSERT
                        + "     FOR A1 IN CD1 ( "
                        + "                      R2.HOSP_CODE  "
                        + "                    , R2.SABUN      "
                        + "                    , R2.DOCTOR     "
                        + "                    , R2.START_DATE "
                        + "                    ) "
                        + "     LOOP "
                        //        현재 것이 있으면
                        + "       IF (A1.IS_CUR_YN = 'Y') THEN "
                        + "         UPDATE BAS0271 A "
                        //+ "         UPDATE BAS0271_T A "
                        + "            SET A.UPD_DATE         = R2.SYS_DATE "
                        + "                , A.UPD_ID         = R2.SYS_ID "
                        + "                , A.END_DATE       = DECODE(A1.MIN_START_DATE "
                        //                                             이후 DATA가 없슴
                        + "                                            , TO_DATE('99981231', 'YYYYMMDD'), R2.END_DATE "
                        //                                             이후 DATA가 있으므로 종료처리
                        + "                                            , A1.MIN_START_DATE - 1) "
                        + "          WHERE A.HOSP_CODE        = R2.HOSP_CODE "
                        + "            AND A.SABUN            = R2.SABUN "
                        + "            AND A.DOCTOR           = R2.DOCTOR "
                        + "            AND A.START_DATE       = R2.START_DATE "
                        + "            AND (A.END_DATE        <> DECODE(A1.MIN_START_DATE "
                        + "                                            , TO_DATE('99981231', 'YYYYMMDD'), R2.END_DATE "
                        + "                                            , A1.MIN_START_DATE - 1) "
                        + "                 OR A.END_DATE     IS NULL) "
                        + "         ; "
                        //        현재 것이 없으면
                        + "       ELSE "
                        + "         INSERT INTO BAS0271 ( "
                        //+ "         INSERT INTO BAS0271_T ( "
                        + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                        + "             , SABUN                  , DOCTOR                  , DOCTOR_NAME                   , DOCTOR_NAME2 "
                        + "             , START_DATE             , END_DATE "
                        + "             , DOCTOR_GRADE           , RESER_YN                , OCS_STATUS "
                        + "             , JUBSU_YN               , CP_DOCTOR_YN            , MAYAK_LICENSE "
                        + "             ) VALUES ("
                        + "               R2.SYS_DATE            , R2.SYS_ID               , R2.HOSP_CODE "
                        + "             , R2.SABUN               , R2.DOCTOR               , R2.DOCTOR_NAME                , R2.DOCTOR_NAME2 "
                        + "             , R2.START_DATE          , DECODE(A1.MIN_START_DATE, NULL, R2.END_DATE, A1.MIN_START_DATE - 1) "
                        + "             , R2.DOCTOR_GRADE        , R2.RESER_YN             , R2.OCS_STATUS "
                        + "             , R2.JUBSU_YN            , R2.CP_DOCTOR_YN         , R2.MAYAK_LICENSE "
                        + "             ) ; "
                        + "       END IF ; "
                        + "     END LOOP; "
                        //      의사과 정보
                        + "     R3.SYS_DATE             := R2.SYS_DATE ; "
                        + "     R3.SYS_ID               := R2.SYS_ID ; "
                        + "     R3.HOSP_CODE            := R2.HOSP_CODE ; "
                        + "     R3.SABUN                := R2.SABUN ; "
                        + "     R3.DOCTOR               := R2.DOCTOR ; "
                        + "     R3.START_DATE           := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                        + "     R3.END_DATE             := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                        + "     R3.MAIN_GWA_YN          := 'Y' ; "
                        + "     R3.DOCTOR_GWA           := TRIM(SUBSTR(M_GWALIST, 1, 2)) ; "
                        //      리스트의 첫번째 것만 주과 구분자로 처리(INSERT에서만 처리)
                        + "     M_MAIN_GWA              := R3.DOCTOR_GWA ; "
                        + "     WHILE (LENGTH(R3.DOCTOR_GWA) = 2 OR LENGTH(R3.DOCTOR_GWA) IS NOT NULL) LOOP "
                        //        이전것 종료처리
                        + "       UPDATE BAS0272 A "
                        //+ "       UPDATE BAS0272_T A "
                        + "          SET A.UPD_DATE         = R3.SYS_DATE "
                        + "              , A.UPD_ID         = R3.SYS_ID "
                        + "              , A.END_DATE       = R3.START_DATE - 1 "
                        + "        WHERE A.HOSP_CODE        = R3.HOSP_CODE "
                        + "          AND A.SABUN            = R3.SABUN "
                        + "          AND A.DOCTOR           = R3.DOCTOR "
                        + "          AND A.DOCTOR_GWA       = R3.DOCTOR_GWA "
                        + "          AND A.START_DATE       = ( SELECT MAX(Z.START_DATE) "
                        + "                                       FROM BAS0272 Z "
                        //+ "                                       FROM BAS0272_T Z "
                        + "                                      WHERE Z.HOSP_CODE            = R3.HOSP_CODE      "
                        + "                                        AND Z.SABUN                = R3.SABUN          "
                        + "                                        AND Z.DOCTOR               = R3.DOCTOR         "
                        + "                                        AND Z.START_DATE           < R3.START_DATE     "
                        + "                                        AND Z.DOCTOR_GWA           = R3.DOCTOR_GWA     "
                        + "                                        AND Z.END_DATE             > R3.START_DATE - 1 "
                        + "                                  ) "
                        + "       ; "
                        //        현재이후 여부 CHECK 후 UPDATE/INSERT
                        + "       FOR A1 IN CDG1 ( "
                        + "                        R3.HOSP_CODE  "
                        + "                      , R3.SABUN      "
                        + "                      , R3.DOCTOR     "
                        + "                      , R3.START_DATE "
                        + "                      , R3.DOCTOR_GWA "
                        + "                      ) "
                        + "       LOOP "
                        //          현재 것이 있으면
                        + "         IF (A1.IS_CUR_YN = 'Y') THEN "
                        + "           UPDATE BAS0272 A "
                        //+ "           UPDATE BAS0272_T A "
                        + "              SET A.UPD_DATE         = R3.SYS_DATE "
                        + "                  , A.UPD_ID         = R3.SYS_ID "
                        + "                  , A.END_DATE       = DECODE(A1.MIN_START_DATE "
                        //                                               이후 DATA가 없슴
                        + "                                              , TO_DATE('99981231', 'YYYYMMDD'), R3.END_DATE "
                        //                                               이후 DATA가 있으므로 종료처리
                        + "                                              , A1.MIN_START_DATE - 1) "
                        + "            WHERE A.HOSP_CODE        = R3.HOSP_CODE "
                        + "              AND A.SABUN            = R3.SABUN "
                        + "              AND A.DOCTOR           = R3.DOCTOR "
                        + "              AND A.START_DATE       = R3.START_DATE "
                        + "              AND A.DOCTOR_GWA       = R3.DOCTOR_GWA "
                        + "              AND (A.END_DATE        <> DECODE(A1.MIN_START_DATE "
                        + "                                              , TO_DATE('99981231', 'YYYYMMDD'), R3.END_DATE "
                        + "                                              , A1.MIN_START_DATE - 1) "
                        + "                 OR A.END_DATE       IS NULL) "
                        + "           ; "
                        //          현재 것이 없으면
                        + "         ELSE "
                        + "           INSERT INTO BAS0272 ( "
                        //+ "           INSERT INTO BAS0272_T ( "
                        + "                 SYS_DATE               , SYS_ID                  , HOSP_CODE "
                        + "               , SABUN                  , DOCTOR "
                        + "               , START_DATE             , END_DATE "
                        + "               , DOCTOR_GWA             , MAIN_GWA_YN "
                        + "               ) VALUES ("
                        + "                 R3.SYS_DATE            , R3.SYS_ID               , R3.HOSP_CODE "
                        + "               , R3.SABUN               , R3.DOCTOR "
                        + "               , R3.START_DATE          , DECODE(A1.MIN_START_DATE, NULL, R3.END_DATE, A1.MIN_START_DATE - 1) "
                        + "               , R3.DOCTOR_GWA          , DECODE(R3.DOCTOR_GWA, M_MAIN_GWA, 'Y', 'N') "
                        + "               ) ; "
                        + "         END IF ; "
                        + "       END LOOP; "
                        //        NEXT GWA
                        + "       M_GWALIST         := TRIM(SUBSTR(M_GWALIST, 3, 10)) ; "
                        + "       R3.DOCTOR_GWA     := TRIM(SUBSTR(M_GWALIST, 1, 2)) ; "
                        + "       R3.MAIN_GWA_YN    := 'N' ; "
                        + "    END LOOP ;  "
                        + "   END IF ; "
                        + " END ; "
                        ;
                    //if (Service.ExecuteNonQuery(cmd0) == false)
                    if (Service.ExecuteNonQuery(cmd) == false)
                            return false;
                }

                if (im == 100)
                {
                    im = 0;
                    Service.CommitTransaction();
                    Service.BeginTransaction();
                }

            }

            lbCount.Text = "";
            lbCount.Refresh();

            Service.CommitTransaction();

            return true;
        }

        #endregion 사용자마스터

        #region 우편번호

        private bool UpdateZipCode(DataTable aTable)
        {
            int i = 0, im= 0;
            string cmd = "";
            string cmd0 = "";
            //string gubun = "";
            //string gubunName = "";
            //string johapGubun = "";

            Service.BeginTransaction();

            foreach (DataRow dr in aTable.Rows)
            {
                i++; im++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                #region cmd0 최초 로딩용
                cmd0 = " DECLARE "
                    + "   R1 BAS0123%ROWTYPE ; "
                    + " BEGIN "
                    + "   R1.SYS_DATE       := SYSDATE ; "
                    + "   R1.SYS_ID         := 'CONV' ; "
                    + "   R1.HOSP_CODE      := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.ZIP_CODE       := '" + dr["post"].ToString() + "' ; "
                    + "   R1.ZIP_CODE1      := SUBSTR('" + dr["post"].ToString() + "', 1, 3) ; "
                    + "   R1.ZIP_CODE2      := SUBSTR('" + dr["post"].ToString() + "', 4, 4) ; "
                    + "   R1.ZIP_NAME1      := TRIM(SUBSTRB('" + dr["prefname"].ToString() + "', 1, 60)) ; "
                    + "   R1.ZIP_NAME2      := TRIM(SUBSTRB('" + dr["cityname"].ToString() + "', 1, 60)) ; "
                    + "   R1.ZIP_NAME3      := TRIM(SUBSTRB('" + dr["townname"].ToString() + "', 1, 80)) ; "
                    + "   R1.ZIP_NAME_GANA1 := TRIM(SUBSTRB('" + dr["prefkana"].ToString() + "', 1, 60)) ; "
                    + "   R1.ZIP_NAME_GANA2 := TRIM(SUBSTRB('" + dr["citykana"].ToString() + "', 1, 60)) ; "
                    + "   R1.ZIP_NAME_GANA3 := TRIM(SUBSTRB('" + dr["townkana"].ToString() + "', 1, 80)) ; "
                    + "   R1.AUTO_YN        := 'Y' ; "
                    + "   R1.HYUNNAE_YN     := NULL ; "
                    + "   R1.DISPLAY_YN     := NULL ; "
                    //+ "   INSERT INTO BAS0123 ("
                    + "   INSERT INTO BAS0123_T ("
                    + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                    + "             , ZIP_CODE               , ZIP_CODE1               , ZIP_CODE2 "
                    + "             , ZIP_NAME1              , ZIP_NAME2               , ZIP_NAME3 "
                    + "             , ZIP_NAME_GANA1         , ZIP_NAME_GANA2          , ZIP_NAME_GANA3 "
                    + "             , AUTO_YN                , HYUNNAE_YN              , DISPLAY_YN "
                    + "             ) VALUES ("
                    + "               R1.SYS_DATE            , R1.SYS_ID               , R1.HOSP_CODE "
                    + "             , R1.ZIP_CODE            , R1.ZIP_CODE1            , R1.ZIP_CODE2 "
                    + "             , R1.ZIP_NAME1           , R1.ZIP_NAME2            , R1.ZIP_NAME3 "
                    + "             , R1.ZIP_NAME_GANA1      , R1.ZIP_NAME_GANA2       , R1.ZIP_NAME_GANA3 "
                    + "             , R1.AUTO_YN             , R1.HYUNNAE_YN           , R1.DISPLAY_YN "
                    + "             ) ; "
                    + " END ; "
                    ;
                #endregion cmd0 최초 로딩용
                #region cmd
                cmd = " DECLARE "
                    + "   R1 BAS0123%ROWTYPE ; "
                    + " BEGIN "
                    + "   R1.SYS_DATE       := SYSDATE ; "
                    + "   R1.SYS_ID         := 'CONV' ; "
                    + "   R1.HOSP_CODE      := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.ZIP_CODE       := '" + dr["post"].ToString() + "' ; "
                    + "   R1.ZIP_CODE1      := SUBSTR('" + dr["post"].ToString() + "', 1, 3) ; "
                    + "   R1.ZIP_CODE2      := SUBSTR('" + dr["post"].ToString() + "', 4, 4) ; "
                    + "   R1.ZIP_NAME1      := TRIM(SUBSTRB('" + dr["prefname"].ToString() + "', 1, 60)) ; "
                    + "   R1.ZIP_NAME2      := TRIM(SUBSTRB('" + dr["cityname"].ToString() + "', 1, 60)) ; "
                    + "   R1.ZIP_NAME3      := TRIM(SUBSTRB('" + dr["townname"].ToString() + "', 1, 80)) ; "
                    + "   R1.ZIP_NAME_GANA1 := TRIM(SUBSTRB('" + dr["prefkana"].ToString() + "', 1, 60)) ; "
                    + "   R1.ZIP_NAME_GANA2 := TRIM(SUBSTRB('" + dr["citykana"].ToString() + "', 1, 60)) ; "
                    + "   R1.ZIP_NAME_GANA3 := TRIM(SUBSTRB('" + dr["townkana"].ToString() + "', 1, 80)) ; "
                    + "   R1.AUTO_YN        := 'Y' ; "
                    + "   R1.HYUNNAE_YN     := NULL ; "
                    + "   R1.DISPLAY_YN     := NULL ; "
                    + "   INSERT INTO BAS0123 ("
                    //+ "   INSERT INTO BAS0123_T ("
                    + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                    + "             , ZIP_CODE               , ZIP_CODE1               , ZIP_CODE2 "
                    + "             , ZIP_NAME1              , ZIP_NAME2               , ZIP_NAME3 "
                    + "             , ZIP_NAME_GANA1         , ZIP_NAME_GANA2          , ZIP_NAME_GANA3 "
                    + "             , AUTO_YN                , HYUNNAE_YN              , DISPLAY_YN "
                    + "             ) VALUES ("
                    + "               R1.SYS_DATE            , R1.SYS_ID               , R1.HOSP_CODE "
                    + "             , R1.ZIP_CODE            , R1.ZIP_CODE1            , R1.ZIP_CODE2 "
                    + "             , R1.ZIP_NAME1           , R1.ZIP_NAME2            , R1.ZIP_NAME3 "
                    + "             , R1.ZIP_NAME_GANA1      , R1.ZIP_NAME_GANA2       , R1.ZIP_NAME_GANA3 "
                    + "             , R1.AUTO_YN             , R1.HYUNNAE_YN           , R1.DISPLAY_YN "
                    + "             ) ; "
                    + " EXCEPTION "
                    + "   WHEN DUP_VAL_ON_INDEX THEN "
                    + "     UPDATE BAS0123 A "
                    //+ "     UPDATE BAS0123_T A "
                    + "        SET A.UPD_DATE           = R1.SYS_DATE "
                    + "            , A.UPD_ID           = R1.SYS_ID "
                    + "            , A.ZIP_NAME_GANA1   = R1.ZIP_NAME_GANA1 "
                    + "            , A.ZIP_NAME_GANA2   = R1.ZIP_NAME_GANA2 "
                    + "            , A.ZIP_NAME_GANA3   = R1.ZIP_NAME_GANA3 "
                    //+ "            , A.AUTO_YN          = R1.AUTO_YN "
                    //+ "            , A.HYUNNAE_YN       = R1.HYUNNAE_YN "
                    //+ "            , A.DISPLAY_YN       = R1.DISPLAY_YN "
                    + "      WHERE A.HOSP_CODE          = R1.HOSP_CODE "
                    + "        AND A.ZIP_CODE           = R1.ZIP_CODE "
                    + "        AND A.ZIP_NAME1          = R1.ZIP_NAME1 "
                    + "        AND A.ZIP_NAME2          = R1.ZIP_NAME2 "
                    + "        AND A.ZIP_NAME3          = R1.ZIP_NAME3 "
                    + "     ; "
                    + "     NULL ; "
                    //+ "   WHEN OTHERS THEN "
                    //+ "     NULL ; "
                    + " END ; "
                    ;
                #endregion cmd

                //if (Service.ExecuteNonQuery(cmd0) == false)
                if (Service.ExecuteNonQuery(cmd) == false)
                        return false;

                if (im == 100)
                {
                    im = 0;
                    Service.CommitTransaction();
                    Service.BeginTransaction();
                }

            }

            lbCount.Text = "";
            lbCount.Refresh();

            Service.CommitTransaction();

            return true;
        }

        #endregion 우편번호

        #region 보험종별마스타

        private bool UpdateJohapGubun(DataTable aTable)
        {
            int i = 0, im = 0;
            string cmd = "";
            string cmd0 = "";
            string strDateS = "", strDateE = "";
            string gubun = "";
            string gubunName = "";
            string johapGubun = "";

            Service.BeginTransaction();

            foreach (DataRow dr in aTable.Rows)
            {
                i++; im++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                strDateS = dr["tekstymd"].ToString(); if (strDateS == "00000000" || strDateS == "") strDateS = "19000101";
                strDateE = dr["tekedymd"].ToString(); if (strDateE == "99999999" || strDateE == "") strDateE = "99981231";

                gubun       = dr["hknnum"].ToString();
                gubunName   = dr["tanseidoname"].ToString();
                //johapGubun  = "20";                             // default 사보

                switch (gubun)
                {
                    case "060" : // 국보의 경우

                        gubun           = "00";
                        johapGubun      = "10";

                        break;

                    case "971" : // 노재의 경우

                        gubun           = "R1";
                        gubunName       = "労災";
                        johapGubun      = "50";

                        break;

                    case "973" : // 자배의 경우

                        gubun           = "R3";
                        gubunName       = "自賠責";
                        johapGubun      = "30";

                        break;

                    case "975" : // 공비의 경우(공해보험)

                        gubun           = "K5";
                        johapGubun      = "XX";

                        break;

                    default : // 그외의 경우

                        if (gubun.Substring(0, 2) == "98")  // 자비의 경우
                        {
                            gubun       = "Z" + gubun.Substring(2, 1);
                            gubunName   = "自費";
                            johapGubun  = "60";
                        }
                        else                                // 그외의 경우 사보로 등록
                        {
                            gubun       = gubun.Substring(1, 2);
                            johapGubun  = "20";
                        }

                        break;

                }

                #region cmd0 최초 로딩용
                cmd0 = " DECLARE "
                    + "   R1 BAS0210%ROWTYPE ; "
                    + " BEGIN "
                    + "   R1.SYS_DATE           := SYSDATE ; "
                    + "   R1.SYS_ID             := 'CONV' ; "
                    + "   R1.HOSP_CODE          := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.GUBUN              := '" + gubun + "' ; "
                    + "   R1.GUBUN_NAME         := TRIM(SUBSTRB('" + gubunName + "', 1, 30)) ; "
                    + "   R1.JOHAP_GUBUN        :=  '" + johapGubun + "' ; "
                    + "   R1.START_DATE         := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                    + "   R1.END_DATE           := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    + "   R1.NURSECALL_GUBUN    := NULL ; "
                    + "   R1.GONGBI_YN          := NULL ; "
                    //+ "   INSERT INTO BAS0210 ("
                    + "   INSERT INTO BAS0210_T ("
                    + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                    + "             , GUBUN                  , GUBUN_NAME              , JOHAP_GUBUN "
                    + "             , START_DATE             , END_DATE "
                    + "             , NURSECALL_GUBUN        , GONGBI_YN "
                    + "             ) VALUES ("
                    + "               R1.SYS_DATE            , R1.SYS_ID               , R1.HOSP_CODE "
                    + "             , R1.GUBUN               , R1.GUBUN_NAME           , R1.JOHAP_GUBUN "
                    + "             , R1.START_DATE          , R1.END_DATE "
                    + "             , R1.NURSECALL_GUBUN     , R1.GONGBI_YN "
                    + "             ) ; "
                    + " END ; "
                    ;
                #endregion cmd0 최초 로딩용
                #region cmd
                cmd = " DECLARE "
                    + "   CURSOR C1  ( "
                    + "                   C_HOSP_CODE    BAS0210.HOSP_CODE   %TYPE "
                    + "                 , C_GUBUN        BAS0210.GUBUN       %TYPE "
                    + "                 , C_START_DATE   BAS0210.START_DATE  %TYPE "
                    + "                ) IS "
                    + "     SELECT  "
                    //               이번 적용일건이 이미 존재하는지의 여부
                    //               이번건이 있으면 'Y', 없고 이후건이 있으면 'N', 이후건도 없으면 NULL 
                    + "              MAX(DECODE(A.START_DATE, C_START_DATE, 'Y', 'N'))   AS IS_CUR_YN  "
                    //               이번 적용일건 이후 DATA가 있으면 직후 적용일을 읽어 이번건의 종료일(-1일) 반영, 
                    //               이후 DATA가 없고, 이번건이 이미 있으면 9998/12/31, 이번건도 없으면 NULL 
                    + "            , MIN(DECODE(A.START_DATE, C_START_DATE, TO_DATE('99981231', 'YYYYMMDD'), A.START_DATE))  "
                    + "                                                                 AS MIN_START_DATE  "
                    + "       FROM BAS0210 A "
                    //+ "       FROM BAS0210_T A "
                    + "      WHERE A.HOSP_CODE        = C_HOSP_CODE    "
                    + "        AND A.GUBUN            = C_GUBUN        "
                    + "        AND A.START_DATE       >= C_START_DATE   "
                    + "     ; "
                    + "   R1 BAS0210%ROWTYPE ; "
                    + " BEGIN "
                    + "   R1.SYS_DATE           := SYSDATE ; "
                    + "   R1.SYS_ID             := 'CONV' ; "
                    + "   R1.HOSP_CODE          := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.GUBUN              := '" + gubun + "' ; "
                    + "   R1.GUBUN_NAME         := TRIM(SUBSTRB('" + gubunName + "', 1, 30)) ; "
                    + "   R1.JOHAP_GUBUN        :=  '" + johapGubun + "' ; "
                    + "   R1.START_DATE         := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                    + "   R1.END_DATE           := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    + "   R1.NURSECALL_GUBUN    := NULL ; "
                    + "   R1.GONGBI_YN          := NULL ; "
                    //    이전것 종료처리
                    + "   UPDATE BAS0210 A "
                    //+ "   UPDATE BAS0210_T A "
                    + "      SET A.UPD_DATE         = R1.SYS_DATE "
                    + "          , A.UPD_ID         = R1.SYS_ID "
                    + "          , A.END_DATE       = R1.START_DATE - 1 "
                    + "    WHERE A.HOSP_CODE        = R1.HOSP_CODE "
                    + "      AND A.GUBUN            = R1.GUBUN "
                    + "      AND A.START_DATE       = ( SELECT MAX(Z.START_DATE) "
                    + "                                   FROM BAS0210 Z "
                    //+ "                                   FROM BAS0210_T Z "
                    + "                                  WHERE Z.HOSP_CODE            = R1.HOSP_CODE      "
                    + "                                    AND Z.GUBUN                = R1.GUBUN          "
                    + "                                    AND Z.START_DATE           < R1.START_DATE     "
                    + "                                    AND Z.END_DATE             > R1.START_DATE - 1 "
                    + "                              ) "
                    + "   ; "
                    //    현재이후 여부 CHECK 후 UPDATE/INSERT
                    + "   FOR A1 IN C1 ( "
                    + "                    R1.HOSP_CODE  "
                    + "                  , R1.GUBUN      "
                    + "                  , R1.START_DATE "
                    + "                  ) "
                    + "   LOOP "
                    //      현재 것이 있으면
                    + "     IF (A1.IS_CUR_YN = 'Y') THEN "
                    + "       UPDATE BAS0210 A "
                    //+ "       UPDATE BAS0210_T A "
                    + "          SET A.UPD_DATE         = R1.SYS_DATE "
                    + "              , A.UPD_ID         = R1.SYS_ID "
                    + "              , A.END_DATE       = DECODE(A1.MIN_START_DATE "
                    //                                           이후 DATA가 없슴
                    + "                                          , TO_DATE('99981231', 'YYYYMMDD'), R1.END_DATE "
                    //                                           이후 DATA가 있으므로 종료처리
                    + "                                          , A1.MIN_START_DATE - 1) "
                    + "        WHERE A.HOSP_CODE        = R1.HOSP_CODE "
                    + "          AND A.GUBUN            = R1.GUBUN "
                    + "          AND A.START_DATE       = R1.START_DATE "
                    + "          AND (A.END_DATE        <> DECODE(A1.MIN_START_DATE "
                    + "                                          , TO_DATE('99981231', 'YYYYMMDD'), R1.END_DATE "
                    + "                                          , A1.MIN_START_DATE - 1) "
                    + "               OR A.END_DATE     IS NULL) "
                    + "       ; "
                    //      현재 것이 없으면
                    + "     ELSE "
                    + "       INSERT INTO BAS0210 ( "
                    //+ "       INSERT INTO BAS0210_T ( "
                    + "               SYS_DATE               , SYS_ID                  , HOSP_CODE  "
                    + "             , GUBUN                  , GUBUN_NAME              , JOHAP_GUBUN "
                    + "             , START_DATE             , END_DATE "
                    + "             , NURSECALL_GUBUN        , GONGBI_YN "
                    + "             ) VALUES ("
                    + "               R1.SYS_DATE            , R1.SYS_ID               , R1.HOSP_CODE "
                    + "             , R1.GUBUN               , R1.GUBUN_NAME           , R1.JOHAP_GUBUN "
                    + "             , R1.START_DATE          , DECODE(A1.MIN_START_DATE, NULL, R1.END_DATE, A1.MIN_START_DATE - 1) "
                    + "             , R1.NURSECALL_GUBUN     , R1.GONGBI_YN "
                    + "           ) ; "
                    + "     END IF ; "
                    + "   END LOOP; "
                    + " END ; "
                    ;
                #endregion cmd

                //if (Service.ExecuteNonQuery(cmd0) == false)
                if (Service.ExecuteNonQuery(cmd) == false)
                        return false;

                if (im == 100)
                {
                    im = 0;
                    Service.CommitTransaction();
                    Service.BeginTransaction();
                }


            }

            lbCount.Text = "";
            lbCount.Refresh();

            Service.CommitTransaction();

            return true;
        }

        #endregion 보험종별마스타

        #region 보험자마스타

        private bool UpdateJohapMaster(DataTable aTable)
        {
            int i = 0, im = 0;
            string cmd = "";
            string cmd0 = "";
            //string cmd2 = "";
            string strDateS = "", strDateE = "";
            string strEndGubun = "";
            string gubun = "";
            //string gubunName = "";
            string johapGubun = "";

            Service.BeginTransaction();

            foreach (DataRow dr in aTable.Rows)
            {
                i++; im++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                //strDateS = dr[""].ToString(); if (strDateS == "00000000" || strDateS == "") strDateS = "20000101";
                strDateS = "19000101";
                strDateE    = dr["idoymd"].ToString(); if (strDateE == "00000000" || strDateE == "") strDateE = "99981231";
                strEndGubun = dr["idokbn"].ToString();

                gubun = dr["hknnum"].ToString();
                //gubunName = dr["tanseidoname"].ToString();
                //johapGubun  = "20";                             // default 사보

                switch (gubun)
                {
                    case "060": // 국보의 경우

                        gubun = "00";
                        johapGubun = "10";

                        break;

                    case "971": // 노재의 경우

                        gubun = "R1";
                        //gubunName = "労災";
                        johapGubun = "50";

                        break;

                    case "973": // 자배의 경우

                        gubun = "R3";
                        //gubunName = "自賠責";
                        johapGubun = "30";

                        break;

                    case "975": // 공비의 경우(공해보험)

                        gubun = "K5";
                        johapGubun = "XX";

                        break;

                    default: // 그외의 경우

                        if (gubun.Substring(0, 2) == "98")  // 자비의 경우
                        {
                            gubun = "Z" + gubun.Substring(2, 1);
                            //gubunName = "自費";
                            johapGubun = "60";
                        }
                        else                                // 그외의 경우 사보로 등록
                        {
                            gubun = gubun.Substring(1, 2);
                            johapGubun = "20";
                        }

                        break;

                }

                #region cmd0
                cmd0 = " DECLARE "
                    + "   M_END_GUBUN       VARCHAR2(1) ; "
                    + "   R1 BAS0110%ROWTYPE ; "
                    + " BEGIN "
                    + "   M_END_GUBUN := NVL('" + strEndGubun + "', '0') ; "
                    + "   R1.SYS_DATE           := SYSDATE ; "
                    + "   R1.SYS_ID             := 'CONV' ; "
                    + "   R1.HOSP_CODE          := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.JOHAP              := TRIM('" + dr["hknjanum"].ToString() + "') ; "
                    + "   R1.JOHAP_NAME         := TRIM(SUBSTRB('" + dr["hknjaname"].ToString() + "', 1, 60)) ; "
                    + "   R1.JOHAP_GUBUN        :=  '" + johapGubun + "' ; "
                    + "   R1.START_DATE         := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                    + "   R1.END_DATE           := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    + "   R1.ZIP_CODE1          := '" + dr["post"].ToString().Substring(0, 3) + "' ; "
                    + "   R1.ZIP_CODE2          := '" + dr["post"].ToString().Substring(3, 4) + "' ; "
                    + "   R1.ADDRESS            := TRIM(SUBSTRB('" + dr["banti"].ToString() + "', 1, 80)) ; "
                    + "   R1.TEL                := TRIM(SUBSTR('" + dr["tel"].ToString() + "', 1, 30)) ; "
                    + "   R1.CHECK_DIGIT_YN     :=  'Y' ; "
                    + "   R1.REMARK             := '" + dr["hknnum"].ToString() + "' ; "
                    + "   R1.GIHO               := TRIM('" + dr["kigo"].ToString() + "') ; "
                    //+ "     INSERT INTO BAS0110 ( "
                    + "       INSERT INTO BAS0110_T ( "
                    + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                    + "             , JOHAP                  , JOHAP_NAME              , JOHAP_GUBUN "
                    + "             , START_DATE             , END_DATE "
                    + "             , ZIP_CODE1              , ZIP_CODE2               , ADDRESS               , TEL "
                    + "             , CHECK_DIGIT_YN         , REMARK                  , GIHO "
                    + "             ) VALUES ("
                    + "               R1.SYS_DATE            , R1.SYS_ID               , R1.HOSP_CODE "
                    + "             , R1.JOHAP               , R1.JOHAP_NAME           , R1.JOHAP_GUBUN "
                    + "             , R1.START_DATE          , R1.END_DATE "
                    + "             , R1.ZIP_CODE1           , R1.ZIP_CODE2            , R1.ADDRESS            , R1.TEL "
                    + "             , R1.CHECK_DIGIT_YN      , R1.REMARK               , R1.GIHO "
                    + "             ) ; "
                    + " END ; "
                    ;
                #endregion cmd0
                #region cmd
                // orca에서 적용일 관리가 안되고 있슴
                // 따라서 ocs의 최종 적용일자 기준으로 update 처리함
                cmd = " DECLARE "
                    + "   M_END_GUBUN       VARCHAR2(1) ; "
                    + "   R1 BAS0110%ROWTYPE ; "
                    + " BEGIN "
                    + "   M_END_GUBUN := NVL('" + strEndGubun + "', '0') ; "
                    + "   R1.SYS_DATE           := SYSDATE ; "
                    + "   R1.SYS_ID             := 'CONV' ; "
                    + "   R1.HOSP_CODE          := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.JOHAP              := TRIM('" + dr["hknjanum"].ToString() + "') ; "
                    + "   R1.JOHAP_NAME         := FN_ADM_CONVERT_KATAKANA_FULL(TRIM(SUBSTRB('" + dr["hknjaname"].ToString() + "', 1, 60))) ; "
                    + "   R1.JOHAP_GUBUN        :=  '" + johapGubun + "' ; "
                    + "   R1.START_DATE         := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                    + "   R1.END_DATE           := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    + "   R1.ZIP_CODE1          := '" + dr["post"].ToString().Substring(0, 3) + "' ; "
                    + "   R1.ZIP_CODE2          := '" + dr["post"].ToString().Substring(3, 4) + "' ; "
                    + "   R1.ADDRESS            := FN_ADM_CONVERT_KATAKANA_FULL(TRIM(SUBSTRB('" + dr["banti"].ToString() + "', 1, 80))) ; "
                    + "   R1.TEL                := FN_ADM_CONVERT_KATAKANA_FULL(TRIM(SUBSTR('" + dr["tel"].ToString() + "', 1, 30))) ; "
                    + "   R1.CHECK_DIGIT_YN     :=  'Y' ; "
                    + "   R1.REMARK             := FN_ADM_CONVERT_KATAKANA_FULL(TRIM('" + dr["hknnum"].ToString() + "')) ; "
                    + "   R1.GIHO               := TRIM('" + dr["kigo"].ToString() + "') ; "
                    + "   IF (M_END_GUBUN = '0' OR M_END_GUBUN = '') THEN " // 폐지가 아니면 최종 정보 수정 없으면 INSERT
                    //+ "     R1.END_DATE           := NULL ; "
                    + "     UPDATE BAS0110 A "
                    //+ "     UPDATE BAS0110_T A "
                    + "        SET A.UPD_DATE             = R1.SYS_DATE "
                    + "            , A.UPD_ID             = R1.SYS_ID "
                    + "            , A.JOHAP_NAME         = R1.JOHAP_NAME "
                    + "            , A.ZIP_CODE1          = R1.ZIP_CODE1 "
                    + "            , A.ZIP_CODE2          = R1.ZIP_CODE2 "
                    + "            , A.ADDRESS            = R1.ADDRESS "
                    + "            , A.TEL                = R1.TEL "
                    + "            , A.REMARK             = R1.REMARK "
                    //             부활되는 경우를 위해
                    + "            , A.END_DATE           = R1.END_DATE "
                    + "      WHERE A.HOSP_CODE            = R1.HOSP_CODE "
                    + "        AND A.JOHAP                = R1.JOHAP "
                    + "        AND A.JOHAP_GUBUN          = R1.JOHAP_GUBUN "
                    + "        AND A.START_DATE = ( SELECT MAX(Z.START_DATE) "
                    + "                               FROM BAS0110 Z "
                    //+ "                               FROM BAS0110_T Z "
                    + "                              WHERE Z.HOSP_CODE            = A.HOSP_CODE "
                    + "                                AND Z.JOHAP                = A.JOHAP "
                    + "                                AND Z.JOHAP_GUBUN          = A.JOHAP_GUBUN "
                    + "                           )"
                    + "     ; "
                    + "     IF SQL%NOTFOUND THEN "
                    + "     INSERT INTO BAS0110 ( "
                    //+ "       INSERT INTO BAS0110_T ( "
                    + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                    + "             , JOHAP                  , JOHAP_NAME              , JOHAP_GUBUN "
                    + "             , START_DATE             , END_DATE "
                    + "             , ZIP_CODE1              , ZIP_CODE2               , ADDRESS               , TEL "
                    + "             , CHECK_DIGIT_YN         , REMARK                  , GIHO "
                    + "             ) VALUES ("
                    + "               R1.SYS_DATE            , R1.SYS_ID               , R1.HOSP_CODE "
                    + "             , R1.JOHAP               , R1.JOHAP_NAME           , R1.JOHAP_GUBUN "
                    + "             , R1.START_DATE          , R1.END_DATE "
                    + "             , R1.ZIP_CODE1           , R1.ZIP_CODE2            , R1.ADDRESS            , R1.TEL "
                    + "             , R1.CHECK_DIGIT_YN      , R1.REMARK               , R1.GIHO "
                    + "             ) ; "
                    + "     END IF ; "
                    + "   ELSE " // 폐지
                    //+ "     R1.END_DATE           := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    + "     UPDATE BAS0110 A "
                    //+ "     UPDATE BAS0110_T A "
                    + "        SET A.UPD_DATE             = R1.SYS_DATE "
                    + "            , A.UPD_ID             = R1.SYS_ID "
                    + "            , A.END_DATE           = R1.END_DATE "
                    + "      WHERE A.HOSP_CODE            = R1.HOSP_CODE "
                    + "        AND A.JOHAP                = R1.JOHAP "
                    + "        AND A.JOHAP_GUBUN          = R1.JOHAP_GUBUN "
                    //+ "        AND A.START_DATE           = R1.START_DATE "
                    + "     ; "
                    + "   END IF ; "
                    + " EXCEPTION "
                    + "   WHEN DUP_VAL_ON_INDEX THEN "
                    + "     NULL ; "
                    //+ "   WHEN OTHERS THEN "
                    //+ "     NULL ; "
                    + " END ; "
                    ;
                #endregion cmd

                //if (Service.ExecuteNonQuery(cmd0) == false)
                if (Service.ExecuteNonQuery(cmd) == false)
                        return false;

                if (im == 100)
                {
                    im = 0;
                    Service.CommitTransaction();
                    Service.BeginTransaction();
                }


            }

            lbCount.Text = "";
            lbCount.Refresh();

            Service.CommitTransaction();

            return true;
        }

        #endregion 보험자마스타

        #region 공비마스터

        private bool UpdateGongbiMaster(DataTable aTable)
        {
            int i = 0, im = 0;
            string cmd = "", cmd0 = "";
            string strDateS = "", strDateE = "";
            //string gubun = "";
            //string gubunName = "";
            //string johapGubun = "";

            Service.BeginTransaction();

            foreach (DataRow dr in aTable.Rows)
            {
                i++; im++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                strDateS = dr["tekstymd"].ToString(); if (strDateS == "00000000" || strDateS == "") strDateS = "19000101";
                strDateE = dr["tekedymd"].ToString(); if (strDateE == "99999999" || strDateE == "") strDateE = "99981231";

                #region cmd0
                cmd0 = " DECLARE "
                    + "   R1 BAS0212%ROWTYPE ; "
                    + " BEGIN "
                    //
                    + "   R1.SYS_DATE       := SYSDATE ; "
                    + "   R1.SYS_ID         := 'CONV' ; "
                    + "   R1.HOSP_CODE      := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.GONGBI_CODE    := TRIM('" + dr["hknnum"].ToString() + "') ; "
                    + "   R1.GONGBI_NAME    := TRIM(SUBSTRB('" + dr["tanseidoname"].ToString() + "', 1, 100)) ; "
                    + "   R1.LAW_NO         := TRIM('" + dr["hbtnum"].ToString() + "') ; "
                    + "   R1.START_DATE     := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                    + "   R1.END_DATE       := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    + "   R1.TOTAL_YN       := 'Y' ; "
                    + "   R1.GONGBI_JIYEOK  := NULL ; "
                    + "   R1.GONGBI_GUBUN   := NULL ; "
                    //
                    //+ "   INSERT INTO BAS0212 ("
                    + "   INSERT INTO BAS0212_T ("
                    + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                    + "             , GONGBI_CODE            , GONGBI_NAME             , LAW_NO "
                    + "             , START_DATE             , END_DATE "
                    + "             , TOTAL_YN               , GONGBI_JIYEOK           , GONGBI_GUBUN "
                    + "             ) VALUES ("
                    + "               R1.SYS_DATE            , R1.SYS_ID               , R1.HOSP_CODE "
                    + "             , R1.GONGBI_CODE         , R1.GONGBI_NAME          , R1.LAW_NO "
                    + "             , R1.START_DATE          , R1.END_DATE "
                    + "             , R1.TOTAL_YN            , R1.GONGBI_JIYEOK        , R1.GONGBI_GUBUN "
                    + "             ) ; "
                    + " END ; "
                    ;
                #endregion cmd0
                #region cmd
                cmd = " DECLARE "
                    + "   CURSOR C1  ( "
                    + "                   C_HOSP_CODE    BAS0212.HOSP_CODE   %TYPE "
                    + "                 , C_GONGBI_CODE  BAS0212.GONGBI_CODE %TYPE "
                    + "                 , C_START_DATE   BAS0212.START_DATE  %TYPE "
                    + "                ) IS "
                    + "     SELECT  "
                    //               이번 적용일건이 이미 존재하는지의 여부
                    //               이번건이 있으면 'Y', 없고 이후건이 있으면 'N', 이후건도 없으면 NULL 
                    + "              MAX(DECODE(A.START_DATE, C_START_DATE, 'Y', 'N'))   AS IS_CUR_YN  "
                    //               이번 적용일건 이후 DATA가 있으면 직후 적용일을 읽어 이번건의 종료일(-1일) 반영, 
                    //               이후 DATA가 없고, 이번건이 이미 있으면 9998/12/31, 이번건도 없으면 NULL 
                    + "            , MIN(DECODE(A.START_DATE, C_START_DATE, TO_DATE('99981231', 'YYYYMMDD'), A.START_DATE))  "
                    + "                                                                 AS MIN_START_DATE  "
                    + "       FROM BAS0212 A "
                    //+ "       FROM BAS0212_T A "
                    + "      WHERE A.HOSP_CODE        = C_HOSP_CODE    "
                    + "        AND A.GONGBI_CODE      = C_GONGBI_CODE        "
                    + "        AND A.START_DATE       >= C_START_DATE   "
                    + "     ; "
                    + "   R1 BAS0212%ROWTYPE ; "
                    + " BEGIN "
                    + "   R1.SYS_DATE       := SYSDATE ; "
                    + "   R1.SYS_ID         := 'CONV' ; "
                    + "   R1.HOSP_CODE      := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.GONGBI_CODE    := '" + dr["hknnum"].ToString() + "' ; "
                    + "   R1.GONGBI_NAME    := TRIM(SUBSTRB('" + dr["tanseidoname"].ToString() + "', 1, 100)) ; "
                    + "   R1.LAW_NO         := '" + dr["hbtnum"].ToString() + "' ; "
                    + "   R1.START_DATE     := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                    + "   R1.END_DATE       := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    + "   R1.TOTAL_YN       := 'Y' ; "
                    + "   R1.GONGBI_JIYEOK  := NULL ; "
                    + "   R1.GONGBI_GUBUN   := NULL ; "
                    //    이전것 종료처리
                    + "   UPDATE BAS0212 A "
                    //+ "   UPDATE BAS0212_T A "
                    + "      SET A.UPD_DATE         = R1.SYS_DATE "
                    + "          , A.UPD_ID         = R1.SYS_ID "
                    + "          , A.END_DATE       = R1.START_DATE - 1 "
                    + "    WHERE A.HOSP_CODE        = R1.HOSP_CODE "
                    + "      AND A.GONGBI_CODE      = R1.GONGBI_CODE "
                    + "      AND A.START_DATE       = ( SELECT MAX(Z.START_DATE) "
                    + "                                   FROM BAS0212 Z "
                    //+ "                                   FROM BAS0212_T Z "
                    + "                                  WHERE Z.HOSP_CODE            = R1.HOSP_CODE      "
                    + "                                    AND Z.GONGBI_CODE          = R1.GONGBI_CODE          "
                    + "                                    AND Z.START_DATE           < R1.START_DATE     "
                    + "                                    AND Z.END_DATE             > R1.START_DATE - 1 "
                    + "                              ) "
                    + "   ; "
                    //    현재이후 여부 CHECK 후 UPDATE/INSERT
                    + "   FOR A1 IN C1 ( "
                    + "                    R1.HOSP_CODE  "
                    + "                  , R1.GONGBI_CODE      "
                    + "                  , R1.START_DATE "
                    + "                  ) "
                    + "   LOOP "
                    //      현재 것이 있으면
                    + "     IF (A1.IS_CUR_YN = 'Y') THEN "
                    + "       UPDATE BAS0212 A "
                    //+ "       UPDATE BAS0212_T A "
                    + "          SET A.UPD_DATE         = R1.SYS_DATE "
                    + "              , A.UPD_ID         = R1.SYS_ID "
                    + "              , A.END_DATE       = DECODE(A1.MIN_START_DATE "
                    //                                           이후 DATA가 없슴
                    + "                                          , TO_DATE('99981231', 'YYYYMMDD'), R1.END_DATE "
                    //                                           이후 DATA가 있으므로 종료처리
                    + "                                          , A1.MIN_START_DATE - 1) "
                    + "        WHERE A.HOSP_CODE        = R1.HOSP_CODE "
                    + "          AND A.GONGBI_CODE      = R1.GONGBI_CODE "
                    + "          AND A.START_DATE       = R1.START_DATE "
                    + "          AND (A.END_DATE        <> DECODE(A1.MIN_START_DATE "
                    + "                                          , TO_DATE('99981231', 'YYYYMMDD'), R1.END_DATE "
                    + "                                          , A1.MIN_START_DATE - 1) "
                    + "               OR A.END_DATE     IS NULL) "
                    + "       ; "
                    //      현재 것이 없으면
                    + "     ELSE "
                    + "       INSERT INTO BAS0212 ( "
                    //+ "       INSERT INTO BAS0212_T ( "
                    + "               SYS_DATE               , SYS_ID                  , HOSP_CODE "
                    + "             , GONGBI_CODE            , GONGBI_NAME             , LAW_NO "
                    + "             , START_DATE             , END_DATE "
                    + "             , TOTAL_YN               , GONGBI_JIYEOK           , GONGBI_GUBUN "
                    + "             ) VALUES ("
                    + "               R1.SYS_DATE            , R1.SYS_ID               , R1.HOSP_CODE "
                    + "             , R1.GONGBI_CODE         , R1.GONGBI_NAME          , R1.LAW_NO "
                    + "             , R1.START_DATE          , DECODE(A1.MIN_START_DATE, NULL, R1.END_DATE, A1.MIN_START_DATE - 1) "
                    + "             , R1.TOTAL_YN            , R1.GONGBI_JIYEOK        , R1.GONGBI_GUBUN "
                    + "           ) ; "
                    + "     END IF ; "
                    + "   END LOOP; "
                    + " END ; "
                    ;
                #endregion cmd


                //if (Service.ExecuteNonQuery(cmd0) == false)
                if (Service.ExecuteNonQuery(cmd) == false)
                    return false;

                if (im == 100)
                {
                    im = 0;
                    Service.CommitTransaction();
                    Service.BeginTransaction();
                }

            }

            lbCount.Text = "";
            lbCount.Refresh();

            Service.CommitTransaction();

            return true;
        }

        #endregion 공비마스터

        #region 환자별 상병

        private bool UpdatePatientSang(DataTable aTable)
        {
            int i = 0;
            string cmd = "";
            string bunho = "";
            //string gubun = "";

            cmd = "DELETE FROM ORCA005 ";

            Service.ExecuteNonQuery(cmd);

            foreach (DataRow dr in aTable.Rows)
            {
                i++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                cmd = " INSERT INTO ORCA005 "
                    + " VALUES "
                    + "      ( '" + dr["ptnum"].ToString().Trim() + "' "
                    + "      , '" + dr["sryka"].ToString().Trim() + "' "
                    + "      , '" + dr["sryymd"].ToString().Trim() + "' "
                    + "      , '" + dr["rennum"].ToString().Trim() + "' "
                    + "      , '" + dr["khnbyomeicd"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeiinputcd_1"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeiinputcd_2"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeiinputcd_3"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeiinputcd_4"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeiinputcd_5"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeiinputcd_6"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicdsu"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_1"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_2"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_3"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_4"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_5"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_6"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_7"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_8"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_9"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_10"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_11"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_12"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_13"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_14"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_15"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_16"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_17"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_18"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_19"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_20"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeicd_21"].ToString().Trim() + "' "
                    + "      , '" + dr["utagaiflg"].ToString().Trim() + "' "
                    + "      , '" + dr["syubyoflg"].ToString().Trim() + "' "
                    + "      , '" + dr["manseikbn"].ToString().Trim() + "' "
                    + "      , '" + dr["nyugaikbn"].ToString().Trim() + "' "
                    + "      , '" + dr["hkncombi"].ToString().Trim() + "' "
                    + "      , '" + dr["rezeflg"].ToString().Trim() + "' "
                    + "      , '" + dr["rezemm"].ToString().Trim() + "' "
                    + "      , '" + dr["tenkikbn"].ToString().Trim() + "' "
                    + "      , '" + dr["tenkiymd"].ToString().Trim() + "' "
                    + "      , '" + dr["byomei"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeimoji"].ToString().Trim() + "' "
                    + "      , '" + dr["chartbyomei"].ToString().Trim() + "' "
                    + "      , '" + dr["chartbyomeimoji"].ToString().Trim() + "' "
                    + "      , '" + dr["byomeihenflg"].ToString().Trim() + "' "
                    + "      , '" + dr["hknbyomeiflg"].ToString().Trim() + "' "
                    + "      , '" + dr["recedenflg"].ToString().Trim() + "' "
                    + "      , '" + dr["hknnum"].ToString().Trim() + "' "
                    + "      , '" + dr["khnbuicd_1"].ToString().Trim() + "' "
                    + "      , '" + dr["khnbuicd_2"].ToString().Trim() + "' "
                    + "      , '" + dr["khnbuicd_3"].ToString().Trim() + "' "
                    + "      , '" + dr["dltflg"].ToString().Trim() + "') ";




                if (Service.ExecuteNonQuery(cmd) == false)
                {
                    lbCount.Text = "";
                    lbCount.Refresh();
                    MessageBox.Show(bunho + " - " + Service.ErrFullMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            if (i > 0)
            {
                ArrayList inList = new ArrayList();
                ArrayList outList = new ArrayList();
                cmd = "PR_OUT_OUTSANG_MIGRATION";

                lbCount.Text = "患者別傷病データを入力しています。";
                lbCount.Refresh();

                if (Service.ExecuteProcedure(cmd, inList, outList) == false)
                {
                    lbCount.Text = "";
                    lbCount.Refresh();
                    MessageBox.Show("Procedure Execute Error =>" + Service.ErrFullMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            lbCount.Text = "";
            lbCount.Refresh();

            return true;
        }

        #endregion

        #region 점수마스타 - 자비

        private bool UpdateJabi(DataTable aTable)
        {
            int i = 0, im = 0;
            string cmd = "";
            string strDateS = "", strDateE = "";
            //string gubun = "";

            Service.BeginTransaction();


            foreach (DataRow dr in aTable.Rows)
            {
                i++; im++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                strDateS = dr["yukostymd"].ToString(); if (strDateS == "00000000" || strDateS == "") strDateS = "19000101";
                strDateE = dr["yukoedymd"].ToString(); if (strDateE == "99999999" || strDateE == "") strDateE = "99981231";

                cmd = " DECLARE "
                    + "   R1                         BAS0310%ROWTYPE ; "
                    + "   IO_ERR_FLAG                VARCHAR2(100)   ; "
                    + " BEGIN "
                    + "   R1.SYS_ID             := 'CONV' ; "
                    //+ "   R1.HOSP_CODE          := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.SG_CODE            := '" + dr["srycd"].ToString() + "' ; "
                    + "   R1.SG_NAME            := SUBSTRB(TRIM('" + dr["name"].ToString() + "'), 1, 200) ; "
                    + "   R1.SG_NAME_KANA       := SUBSTRB(TRIM('" + dr["kananame"].ToString() + "'), 1, 200) ; "
                    // 적용일, 종료일
                    + "   R1.SG_YMD             := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                    + "   R1.BULYONG_YMD        := TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    //
                    + "   R1.DANUI              := '" + dr["tanicd"].ToString() + "' ; "
                    // POINT
                    + "   R1.POINT              := TO_NUMBER('" + dr["ten"].ToString() + "')  ; "
                    // 자비는 모두 금액
                    //+ "     R1.POINT_GUBUN        := '2' ; "
                    // 세금포함여부를 점수구분에 넣고있슴
                    //   프로시저에서 다시 tax_yn을 코드 구분으로 재세팅하므로 
                    //   향후 orca 화면기준으로 관리하게 되면 프로시저에서 재세팅 부분을 막도록 함.
                    + "   IF ('" + dr["tensikibetu"].ToString() + "' IN ('0')) THEN "
                    + "     R1.TAX_YN           := 'N' ; "
                    + "   ELSE "
                    + "     R1.TAX_YN           := 'Y' ; "
                    + "   END IF ; "
                    //
                    + "   PR_ADM_UPDATE_MASTER_JABI ( "
                    + "       R1.SYS_ID "
                    + "     , R1.SG_CODE "
                    + "     , R1.SG_NAME "
                    + "     , R1.SG_NAME_KANA "	    
                    + "     , R1.SG_YMD "	          
                    + "     , R1.BULYONG_YMD "	      
                    + "     , R1.DANUI "	            
                    + "     , R1.POINT "	            
                    + "     , R1.TAX_YN "      
                    + "     , IO_ERR_FLAG "
                    + "   ); "
                    + "END ; "
                    ;

                if (Service.ExecuteNonQuery(cmd) == false)
                    return false;

                if (im == 50)
                {
                    im = 0;
                    Service.CommitTransaction();
                    Service.BeginTransaction();
                }


            }

            lbCount.Text = "";
            lbCount.Refresh();

            Service.CommitTransaction();

            return true;
        }

        #endregion 점수마스타 - 자비

        #region 병원,병동,병실(미사용)
        /*
        #region 병원정보(미사용)

        private bool UpdateHospInfo(DataTable aTable)
        {
            int i = 0, im = 0;
            string cmd = "";
            string cmd1 = "";
            string cmd2 = "";
            string cmd3 = "";
            string cmd4 = "";
            string cmd5 = "";
            string cmd6 = "";
            string cmd9 = "";
            string strDateS = "", strDateE = "";
            string strDateS0 = "", strDateE0 = "";

            string strKanriCd = "";
            string strHospInfo1 = "";
            string strHospInfo2 = "";
            string strHospInfo3 = "";

            // 가져올게 별로 없슴
            return true;

            strDateS0 = "99981231";
            strDateE0 = "20000101";

            foreach (DataRow dr in aTable.Rows)
            {
                i++; im++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                strDateS = dr["styukymd"].ToString(); if (strDateS == "00000000" || strDateS == "") strDateS = "20000101";
                strDateE = dr["edyukymd"].ToString(); if (strDateE == "99999999" || strDateE == "") strDateE = "99981231";

                strKanriCd = dr["kanricd"].ToString().Trim();
                switch (strKanriCd) 
                {
                    case "1001":

                        strHospInfo1 = dr["kanritbl"].ToString();

                        if (strDateS0.CompareTo(strDateS) == 1) strDateS0 = strDateS;
                        if (strDateE0.CompareTo(strDateE) != 1) strDateE0 = strDateE;

                        break;

                    case "1002":

                        strHospInfo2 = dr["kanritbl"].ToString();

                        if (strDateS0.CompareTo(strDateS) == 1) strDateS0 = strDateS;
                        if (strDateE0.CompareTo(strDateE) != 1) strDateE0 = strDateE;

                        break;

                    case "1003":

                        strHospInfo3 = dr["kanritbl"].ToString();

                        if (strDateS0.CompareTo(strDateS) == 1) strDateS0 = strDateS;
                        if (strDateE0.CompareTo(strDateE) != 1) strDateE0 = strDateE;
                        
                        break;
                }
            }
    
            Service.BeginTransaction();

            cmd1 = " DECLARE "
                + "   M_DUMMY1   VARCHAR2(1024) ; "
                + "   M_DUMMY2   VARCHAR2(1024) ; "
                + "   M_DUMMY3   VARCHAR2(1024) ; "
                + "   R1         BAS0001%ROWTYPE ; "
                + " BEGIN "
                + "   R1 := NULL ; "
                   ;
            cmd2 = ""
                + "   M_DUMMY1                := '" + strHospInfo1 + "' ; "
                + "   M_DUMMY2                := '" + strHospInfo2 + "' ; "
                + "   M_DUMMY3                := '" + strHospInfo3 + "' ; "
                //
                + "   R1.SYS_DATE             := SYSDATE ; "
                + "   R1.SYS_ID               := 'CONV' ; "
                + "   R1.UPD_DATE             := R1.SYS_DATE ; "
                + "   R1.UPD_ID               := R1.SYS_ID ; "
                + "   R1.HOSP_CODE            := '" + EnvironInfo.HospCode + "' ; "
                + "   R1.START_DATE           := TO_DATE('" + strDateS0 + "', 'YYYYMMDD') ; "
                + "   R1.END_DATE             := TO_DATE('" + strDateE0 + "', 'YYYYMMDD') ; "
                + "   R1.YOYANG_GIHO          := TRIM(SUBSTRB(M_DUMMY1,  4,  7)) ; "
                //+ "   R1.YOYANG_NAME          := TRIM(SUBSTRB(M_DUMMY1, 36, 120)) ; "
                + "   R1.YOYANG_NAME          := TRIM(SUBSTRB(M_DUMMY1, 36, 50)) ; "
                //+ "   R1.YOYANG_NAME2       := NULL ; "
                + "   R1.ZIP_CODE1            := TRIM(SUBSTRB(M_DUMMY2,   1,   3)) ; "
                + "   R1.ZIP_CODE2            := TRIM(SUBSTRB(M_DUMMY2,   4,   4)) ; "
                + "   R1.ZIP_CODE             := R1.ZIP_CODE1 || R1.ZIP_CODE2 ; "
                + "   R1.ADDRESS              := TRIM(SUBSTRB(M_DUMMY2,   8, 100)) ; "
                + "   R1.ADDRESS1             := TRIM(SUBSTRB(M_DUMMY2, 108, 100)) ; "
                + "   R1.TEL                  := TRIM(SUBSTRB(M_DUMMY2, 208,  15)) ; "
                //+ "   R1.TEL1               := NULL ; "
                + "   R1.FAX                  := TRIM(SUBSTRB(M_DUMMY2, 223,  15)) ; "
                + "   R1.TOT_BED              := TO_NUMBER(TRIM(SUBSTRB(M_DUMMY1, 356,   4))) ; "
                + "   R1.HOMEPAGE             := TRIM(SUBSTRB(M_DUMMY3, 101, 100)) ; "
                + "   R1.EMAIL                := TRIM(SUBSTRB(M_DUMMY3,   1, 100)) ; "
                //+ "   R1.HOSP_JIN_GUBUN       := TRIM(SUBSTRB(M_DUMMY1, 11, 1)) ; "
                + "   R1.HOSP_JIN_GUBUN       := 'H' ; "
                + "   R1.DODOBUHYEUN_NO       := TRIM(SUBSTRB(M_DUMMY1,  1, 2)) ; "
                //+ "   R1.SIJUNGCHON_NO      := NULL ; "
                //+ "   R1.DIRECTOR             := NULL ; "
                //+ "   R1.ROUSAI_YOYANG_GIHO := TRIM(SUBSTRB(M_DUMMY1, 362, 40)) ; "
                //+ "   R1.JAEDAN_NAME        := NULL ; "
                + "   R1.SIMPLE_YOYANG_NAME   := TRIM(SUBSTRB(M_DUMMY1, 423, 20)) ; "
                //+ "   R1.SINGO_HO_CNT       := NULL ; "
                //+ "   R1.UPPER_HOSP_CODE    := NULL ; "
                //+ "   R1.OPEN_DATE          := NULL ; "
                + "   R1.COUNTRY_CODE         := TRIM(SUBSTRB(M_DUMMY1, 12, 3)) ; "
                + "   R1.PRESIDENT_NAME       := TRIM(SUBSTRB(M_DUMMY1, 276, 80)) ; "
                + "   R1.GWA_GUBUN            := TRIM(SUBSTRB(M_DUMMY1,  3,  1)) ; "
                + "   R1.ORCA_GIGWAN_CODE     := TRIM(SUBSTRB(M_DUMMY1, 12, 24)) ; "
                  ;
            cmd3 = ""
                + "       UPDATE BAS0001 A "
                //+ "       UPDATE BAS0001_T A "
                + "          SET   A.UPD_DATE               = R1.UPD_DATE "
                + "              , A.UPD_ID                 = R1.UPD_ID "
                + "              , A.END_DATE               = R1.END_DATE "
                + "              , A.YOYANG_GIHO            = R1.YOYANG_GIHO "
                + "              , A.YOYANG_NAME            = R1.YOYANG_NAME "
                + "              , A.ZIP_CODE1              = R1.ZIP_CODE1 "
                + "              , A.ZIP_CODE2              = R1.ZIP_CODE2 "
                + "              , A.ZIP_CODE               = R1.ZIP_CODE "
                + "              , A.ADDRESS                = R1.ADDRESS "
                + "              , A.ADDRESS1               = R1.ADDRESS1 "
                + "              , A.TEL                    = R1.TEL "
                + "              , A.FAX                    = R1.FAX "
                + "              , A.TOT_BED                = R1.TOT_BED "
                + "              , A.HOMEPAGE               = R1.HOMEPAGE "
                + "              , A.EMAIL                  = R1.EMAIL "
                + "              , A.HOSP_JIN_GUBUN         = R1.HOSP_JIN_GUBUN "
                + "              , A.DODOBUHYEUN_NO         = R1.DODOBUHYEUN_NO "
                + "              , A.SIMPLE_YOYANG_NAME     = R1.SIMPLE_YOYANG_NAME "
                + "              , A.COUNTRY_CODE           = R1.COUNTRY_CODE "
                + "              , A.PRESIDENT_NAME         = R1.PRESIDENT_NAME "
                + "              , A.GWA_GUBUN              = R1.GWA_GUBUN "
                + "              , A.ORCA_GIGWAN_CODE       = R1.ORCA_GIGWAN_CODE "
                + "        WHERE A.HOSP_CODE                = R1.HOSP_CODE "
                + "          AND A.YOYANG_GIHO              = R1.YOYANG_GIHO "
                + "          AND A.START_DATE               = R1.START_DATE "
                + "       ; "
                  ;
            cmd4 = ""
                + "      IF (SQL%NOTFOUND) THEN "
                + "        NULL ;  "
                  ;
            cmd5 = ""
                + "       UPDATE BAS0001 A "
                //+ "       UPDATE BAS0001_T A "
                + "          SET   A.UPD_DATE               = R1.UPD_DATE "
                + "              , A.UPD_ID                 = R1.UPD_ID "
                + "              , A.END_DATE               = R1.START_DATE - 1 "
                + "        WHERE A.HOSP_CODE                = R1.HOSP_CODE "
                + "          AND A.YOYANG_GIHO              = R1.YOYANG_GIHO "
                + "          AND A.START_DATE               < R1.START_DATE "
                + "          AND (   A.END_DATE             IS NULL "
                + "               OR A.END_DATE             >= R1.START_DATE "
                + "              )  "
                + "       ; "
                  ;
            cmd6 = ""
                + "       INSERT INTO BAS0001 ( "
                //+ "        INSERT INTO BAS0001_T ( "
                + "             SYS_DATE             , SYS_ID               , HOSP_CODE               "
                + "           , START_DATE           , END_DATE                                        "
                + "           , YOYANG_GIHO          , YOYANG_NAME          , YOYANG_NAME2          "
                + "           , ZIP_CODE1            , ZIP_CODE2            , ZIP_CODE               "
                + "           , ADDRESS              , ADDRESS1                                        "
                + "           , TEL                  , TEL1                 , FAX                    "
                + "           , TOT_BED              , HOMEPAGE             , EMAIL                   "
                + "           , HOSP_JIN_GUBUN       , DODOBUHYEUN_NO       , SIJUNGCHON_NO        "
                + "           , DIRECTOR             , ROUSAI_YOYANG_GIHO   , JAEDAN_NAME         "
                + "           , SIMPLE_YOYANG_NAME   , SINGO_HO_CNT         , PRESIDENT_NAME      "
                + "           , GWA_GUBUN            , COUNTRY_CODE         , ORCA_GIGWAN_CODE  "
                + "          ) VALUES ( "
                + "             R1.SYS_DATE             , R1.SYS_ID               , R1.HOSP_CODE "
                + "           , R1.START_DATE           , R1.END_DATE                                 "
                + "           , R1.YOYANG_GIHO          , R1.YOYANG_NAME          , R1.YOYANG_NAME2  "
                + "           , R1.ZIP_CODE1            , R1.ZIP_CODE2            , R1.ZIP_CODE       "
                + "           , R1.ADDRESS              , R1.ADDRESS1                                 "
                + "           , R1.TEL                  , R1.TEL1                 , R1.FAX          "
                + "           , R1.TOT_BED              , R1.HOMEPAGE             , R1.EMAIL           "
                + "           , R1.HOSP_JIN_GUBUN       , R1.DODOBUHYEUN_NO       , R1.SIJUNGCHON_NO"
                + "           , R1.DIRECTOR             , R1.ROUSAI_YOYANG_GIHO   , R1.JAEDAN_NAME      "
                + "           , R1.SIMPLE_YOYANG_NAME   , R1.SINGO_HO_CNT         , R1.PRESIDENT_NAME   "
                + "           , R1.GWA_GUBUN            , R1.COUNTRY_CODE         , R1.ORCA_GIGWAN_CODE   "
                + "          ) ; "
               ;
            cmd9 = ""
                + "      END IF; "
                + " END ; "
                ;
            cmd = cmd1
                + cmd2
                + cmd3
                + cmd4
                + cmd5
                + cmd6
                + cmd9
                ;

            if (Service.ExecuteNonQuery(cmd) == false)
                return false;
            
            lbCount.Text = "";
            lbCount.Refresh();

            Service.CommitTransaction();

            return true;
        }

        #endregion 병원정보

        #region 병동정보 (미사용) : 가져올게 없슴
        private bool UpdateHoDong(DataTable aTable)
        {
            int i = 0, im = 0;
            string cmd = "";
            string cmd1 = "";
            string cmd2 = "";
            string cmd3 = "";
            string cmd4 = "";
            string cmd5 = "";
            string cmd6 = "";
            string cmd9 = "";
            string strDateS = "", strDateE = "";
            string strDateS0 = "", strDateE0 = "";

            string strKanriCd = "";
            string strHoDongInfo = "";

            strDateS0 = "99981231";
            strDateE0 = "20000101";

            // 가져올게 별로 없슴
            return true;

            foreach (DataRow dr in aTable.Rows)
            {
                i++; im++;
                lbCount.Text = i.ToString() + "/" + ((DataTable)this.gridData.DataSource).Rows.Count.ToString();
                lbCount.Refresh();

                strDateS = dr["styukymd"].ToString(); if (strDateS == "00000000" || strDateS == "") strDateS = "20000101";
                strDateE = dr["edyukymd"].ToString(); if (strDateE == "99999999" || strDateE == "") strDateE = "99981231";

                strKanriCd = dr["kanricd"].ToString().Trim();
                strHoDongInfo = dr["kanritbl"].ToString();

                Service.BeginTransaction();

                cmd1 = " DECLARE "
                    + "   M_DUMMY1   VARCHAR2(1024) ; "
                    + "   R1         BAS0260%ROWTYPE ; "
                    + " BEGIN "
                    + "   R1 := NULL ; "
                       ;
                cmd2 = ""
                    + "   M_DUMMY1                := '" + strHoDongInfo + "' ; "
                    //
                    + "   R1.SYS_DATE             := SYSDATE ; "
                    + "   R1.SYS_ID               := 'CONV' ; "
                    + "   R1.UPD_DATE             := R1.SYS_DATE ; "
                    + "   R1.UPD_ID               := R1.SYS_ID ; "
                    //
                    + "   R1.BUSEO_CODE           := '30010' ; "  // 30010
                    //
                    + "   R1.HOSP_CODE            := '" + EnvironInfo.HospCode + "' ; "
                    + "   R1.START_DATE           := TO_DATE('" + strDateS + "', 'YYYYMMDD') ; "
                    + "   R1.BUSEO_NAME           := TRIM(SUBSTRB(M_DUMMY1,  3, 20)) ; "
                    + "   R1.BUSEO_GUBUN          := '2' ; "
                    + "   R1.PARENT_BUSEO         := NULL ; "
                    //+ "   R1.GWA                  := TRIM(SUBSTRB(M_DUMMY1, 35, 2)) ; "
                    + "   R1.GWA                  := TRIM(SUBSTRB(M_DUMMY1,  1, 2)) ; "
                    //
                    + "   R1.GWA_NAME             := TRIM(SUBSTRB(M_DUMMY1,  3, 20)) ; "
                    //+ "   R1.PARENT_GWA           := NULL ; "
                    + "   R1.OUT_JUBSU_YN         := 'N' ; "
                    + "   R1.IPWON_YN             := 'Y' ; "
                    + "   R1.OUT_SLIP_YN          := 'N' ; "
                    + "   R1.INP_SLIP_YN          := 'Y' ; "
                    //+ "   R1.INPUT_GUBUN          := NULL ; "
                    + "   R1.OUT_MOVE_YN          := 'Y' ; "
                    + "   R1.OUT_JUNDAL_PART_YN   := 'N' ; "
                    + "   R1.INP_JUNDAL_PART_YN   := 'Y' ; "
                    + "   R1.EURYOSEO_YN          := 'N' ; "
                    //+ "   R1.TEL                  := NULL ; "
                    //+ "   R1.GWA_GUBUN            := NULL ; "
                    //
                    + "   R1.MOVE_COMMENT         := TRIM(SUBSTRB(M_DUMMY1,  3, 20)) ; "
                    //+ "   R1.GWA_SORT2            := NULL ; "
                    //+ "   R1.GWA_SORT1            := NULL ; "
                    //+ "   R1.GWA_ENAME            := NULL ; "
                    //+ "   R1.GWA_SNAME            := NULL ; "
                    //+ "   R1.RMK                  := NULL ; "
                    + "   R1.END_DATE             :=  TO_DATE('" + strDateE + "', 'YYYYMMDD') ; "
                    //+ "   R1.ICU_YN               := NULL ; "
                    //+ "   R1.NRS_PARENT_BUSEO     := NULL ; "
                    //
                    + "   R1.BUSEO_NAME2          := TRIM(SUBSTRB(M_DUMMY1, 23, 10)) ; "
                    //+ "   R1.GWA_COLOR            := NULL ; "
                    + "   R1.HPC_HO_DONG_YN       := 'N' ; "
                    //+ "   R1.ADD_DOCTOR           := NULL ; "
                    //
                    + "   R1.GWA_NAME_KANA        := TRIM(SUBSTRB(M_DUMMY1,  3, 20)) ; "
                    ;
            cmd3 = ""
                //+ "       UPDATE BAS0260 A "
                + "       UPDATE BAS0260_T A "
                + "          SET   A.UPD_DATE                 = R1.UPD_DATE                 "
                + "              , A.UPD_ID                   = R1.UPD_ID                   "
                + "              , A.BUSEO_NAME               = R1.BUSEO_NAME               "
                //
                + "              , A.GWA                      = R1.GWA                      "
                + "              , A.END_DATE                 = R1.END_DATE                 "
                + "        WHERE A.HOSP_CODE                  = R1.HOSP_CODE "
                + "          AND A.BUSEO_CODE                 = R1.BUSEO_CODE "
                + "          AND A.START_DATE                 = R1.START_DATE "
                + "       ; "
                  ;
            cmd4 = ""
                + "      IF (SQL%NOTFOUND) THEN "
                + "        NULL ;  "
                  ;
            cmd5 = ""
                //+ "       UPDATE BAS0260 A "
                + "       UPDATE BAS0260_T A "
                + "          SET   A.UPD_DATE               = R1.UPD_DATE "
                + "              , A.UPD_ID                 = R1.UPD_ID "
                + "              , A.END_DATE               = R1.START_DATE - 1 "
                + "        WHERE A.HOSP_CODE                = R1.HOSP_CODE "
                + "          AND A.BUSEO_CODE               = R1.BUSEO_CODE "
                + "          AND A.START_DATE               < R1.START_DATE "
                + "          AND (   A.END_DATE             IS NULL "
                + "               OR A.END_DATE             >= R1.START_DATE "
                + "              )  "
                + "       ; "
                  ;
            cmd6 = ""
                //+ "       INSERT INTO BAS0260 ( "
                + "        INSERT INTO BAS0260_T ( "
                + "             SYS_DATE                 , SYS_ID                   , HOSP_CODE                                     "
                + "           , BUSEO_CODE               , START_DATE               , END_DATE                                       "
                + "           , BUSEO_NAME               , BUSEO_GUBUN                                                            "
                + "           , GWA                      , GWA_NAME                                                                "
                + "           , OUT_JUBSU_YN             , IPWON_YN                 , OUT_SLIP_YN              , INP_SLIP_YN         "
                + "           , OUT_MOVE_YN              , OUT_JUNDAL_PART_YN       , INP_JUNDAL_PART_YN       , EURYOSEO_YN       "
                + "           , TEL                      , GWA_GUBUN                , MOVE_COMMENT             , ICU_YN             "
                + "           , HPC_HO_DONG_YN                                                                                   "
                + "          ) VALUES ( "
                + "             R1.SYS_DATE                 , R1.SYS_ID                   , R1.HOSP_CODE                                     "
                + "           , R1.BUSEO_CODE               , R1.START_DATE               , R1.END_DATE                                       "
                + "           , R1.BUSEO_NAME               , R1.BUSEO_GUBUN "
                + "           , R1.GWA                      , R1.GWA_NAME "
                + "           , R1.OUT_JUBSU_YN             , R1.IPWON_YN                 , R1.OUT_SLIP_YN              , R1.INP_SLIP_YN         "
                + "           , R1.OUT_MOVE_YN              , R1.OUT_JUNDAL_PART_YN       , R1.INP_JUNDAL_PART_YN       , R1.EURYOSEO_YN       "
                + "           , R1.TEL                      , R1.GWA_GUBUN                , R1.MOVE_COMMENT             , R1.ICU_YN             "
                + "           , R1.HPC_HO_DONG_YN "
                + "          ) ; "
               ;
            cmd9 = ""
                + "      END IF; "
                + " END ; "
                ;
            cmd = cmd1
                + cmd2
                + cmd3
                + cmd4
                + cmd5
                + cmd6
                + cmd9
                ;

            if (Service.ExecuteNonQuery(cmd) == false)
                return false;

            }

            lbCount.Text = "";
            lbCount.Refresh();

            Service.CommitTransaction();

            return false;
        }

        #endregion 병동정보

        #region 병실정보(미사용)
        private bool UpdateHoRoom(DataTable aTable)
        {

            return false;
        }
        #endregion 병실정보
        */
        #endregion 병원,병동,병실(미사용)

        #endregion //Update 로직

    }

    #region 조회조건 Enum

    // 조회 조건 enum Type
    public enum QueryType
    {
        SangCode,      // 상병 코드
        SusikCode,     // 수식어 코드
        DrugCode,      // 약품 코드
        JinryoHangwi,  // 진료행위코드
        TokuteiCode,   // 특정기재 코드
        JabiCode       // 자비 코드
    }

    #endregion
}