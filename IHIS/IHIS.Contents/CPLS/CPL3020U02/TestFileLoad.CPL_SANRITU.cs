using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.CPLS
{
    public partial class TestFileLoad : XForm
    {
    }


    #region [CplSanRituPtInfo]
    internal class CplSanRituPtInfo
    {
        const int CONST_LINE_LEN = 128;
        String logFileTag = null;

        #region Fields
        private string PK = "";                         // PK
        //
        private string record_gubun = "";               // 레코드 구분
        private string senta_code = "";                 // 센타코드
        private string irai_key = "";                   // 의뢰키
        private string karute_no = "";                  // 카르테NO
        private string kanjamei = "";                   // 환자이름
        private string koumokusuu = "";                 // 결과항목수
        private string houkokubi = "";                  // 보고일
        private string yobi1 = "";                      // 예비1
        private string yobi2 = "";                      // 예비2
        //
        private string temp = "";                       // CONST_LINE_LEN 맞춤용
        //
        private List<CplSanRituResult> cplSanRituResult = null;   // 검사결과정보
        #endregion Fields
        //
        public CplSanRituPtInfo()
        {
            cplSanRituResult = new List<CplSanRituResult>();
        }

        #region Parse CplSanRituPtInfo
        //public Boolean Parse(OCSReqMsg aReqMsg, String aReceiveData)
        public Boolean Parse(String aServiceID, String aReceiveData)
        {
            //logFileTag = aReqMsg.ServiceID;
            logFileTag = aServiceID;

            try
            {
                aReceiveData = Service.getWordByByte(aReceiveData, 0);
                //
                this.record_gubun = Service.getWordByByte(aReceiveData, 0, 2).Trim();      // 레코드 구분
                this.senta_code = Service.getWordByByte(aReceiveData, 2, 6).Trim();        // 센타코드
                this.irai_key = Service.getWordByByte(aReceiveData, 8, 20).Trim();         // 의뢰키
                this.karute_no = Service.getWordByByte(aReceiveData, 28, 15).Trim();       // 카르테NO
                this.kanjamei = Service.getWordByByte(aReceiveData, 43, 20).Trim();        // 환자이름
                this.koumokusuu = Service.getWordByByte(aReceiveData, 63, 3).Trim();       // 결과항목수
                this.houkokubi = Service.getWordByByte(aReceiveData, 66, 10).Trim();       // 보고일
                this.yobi1  = Service.getWordByByte(aReceiveData, 76, 10).Trim();          // 예비1
                this.yobi2  = Service.getWordByByte(aReceiveData, 86, 10).Trim();          // 예비2
                //
                this.temp = Service.getWordByByte(aReceiveData, 96, (CONST_LINE_LEN - 96 - 1)).Trim(); // 
                //
                Service.WriteLog(logFileTag, String.Format("Patient Information Parsing End=[{0}]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")));

                // 처리한 환자정보 다음 position = 검사결과정보 start position
                aReceiveData = Service.getWordByByte(aReceiveData, CONST_LINE_LEN);
                //
                #region 검사결과정보
                //Service.WriteLog(logFileTag, "aCplSanRituPtInfo.insuCnt.Trim() [" + aCplSanRituPtInfo.insuCnt.Trim() + "]");

                int cntResult = Convert.ToInt16(this.koumokusuu.Trim());                        // 결과수
                string resultData = "";
                try
                {

                    for (int i = 0; i < cntResult; i++)
                    {
                        // 검사결과정보 1 단위 정보
                        resultData = Service.getWordByByte(aReceiveData, 0, CONST_LINE_LEN);

                        //Service.WriteLog(logFileTag, "Receive InsData " + "[" + insData + "]");

                        if (this.cplSanRituResult == null)
                        {
                            this.cplSanRituResult = new List<CplSanRituResult>();
                        }
                        CplSanRituResult cplSRResult = new CplSanRituResult();

                        //if (!(cplSRResult.Parse(aReqMsg, resultData)))
                        if (!(cplSRResult.Parse(aServiceID, resultData)))
                        {
                            throw new Exception(String.Format("parse CplSanRituResult error[{0}[{1}]", i, resultData));
                        }
                        //
                        this.cplSanRituResult.Add(cplSRResult);
                        // next position
                        aReceiveData = Service.getWordByByte(aReceiveData, CONST_LINE_LEN);
                    }
                }
                catch (Exception xe)
                {
                    throw new Exception(String.Format("parse CplSanRituResult info error[cnt={0}][{1}[{2}]", cntResult, xe.Message, xe.StackTrace));
                }
                #endregion 검사결과정보

                return true;
            }
            catch (Exception xe)
            {
                Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] Parse error[{0}][{1}]", xe.Message, xe.StackTrace));
                return false;
            }
        }
        #endregion Parse CplSanRituPtInfo

        #region SetData CplSanRituPtInfo
        //public Boolean SetData(OCSReqMsg aReqMsg)
        public Boolean SetData(String aServiceID)
        {
            //logFileTag = aReqMsg.ServiceID;
            logFileTag = aServiceID;

            //DBSession DBService = new DBSession(aReqMsg.ServiceID);
            //DBSession DBService = new DBSession(aServiceID);
            //Service.Connect();

            bool bolval = false;
            
            object retVal = null;
            string cmdText = "";
            //
            try
            {
                #region delete by Cloud
                //                //if (!DBService.Connect())
                //                if (!Service.Connect())
                //                {
                //                    //Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] SetData : DB Connect Error[{0}]", DBService.ErrMsg));
                //                    Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] SetData : DB Connect Error[{0}]", Service.ErrMsg));
                //                    return false;
                //                }
                //                //Service.WriteLog(logFileTag, "DB Connect");
                //                //
                //                //DBService.BeginTransaction();
                //                Service.BeginTransaction();
                //                //
                //                cmdText = @"SELECT IFS7203_SEQ.NEXTVAL FROM SYS.DUAL";
                //                //
                //                //retVal = DBService.ExecuteScalar(cmdText);
                //                retVal = Service.ExecuteScalar(cmdText);
                //                if (retVal == null)
                //                {
                //                    //Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] SetData : Patient PK Creation Error :[{0}]", DBService.ErrFullMsg));
                //                    Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] SetData : Patient PK Creation Error :[{0}]", Service.ErrFullMsg));
                //                    return false;
                //                }
                //                //환자정보 PrimaryKey 취득
                //                this.PK = retVal.ToString();

                //                BindVarCollection bindVals = new BindVarCollection();

                //                cmdText = @"INSERT INTO IFS7203 (
                //                                      SYS_DATE       , SYS_ID         , HOSP_CODE      
                //                                    , PKIFS7203      
                //                                    , RECORD_GUBUN          , SENTA_CODE                , IRAI_KEY
                //                                    , KARUTE_NO             , KANJAMEI     
                //                                    , KOUMOKUSUU            , HOUKOKUBI    
                //                                    , YOBI1                 , YOBI2        
                //                                    , IF_DATE       
                //                                    , IF_TIME       
                //                                    , IF_FLAG         
                //                                    , IF_ERR         
                //                              ) VALUES (
                //                                      SYSDATE        , 'IF'           , :f_hosp_code   
                //                                    , :f_primaryKey  
                //                                    , :f_record_gubun          , :f_senta_code          , :f_irai_key
                //                                    , :f_karute_no             , :f_kanjamei     
                //                                    , :f_koumokusuu            , :f_houkokubi    
                //                                    , :f_yobi1                 , :f_yobi2        
                //                                    , TRUNC(SYSDATE)
                //                                    , TO_CHAR(SYSDATE,'HH24MISS')
                //                                    , '10'
                //                                    , NULL
                //                             )
                //                           ";
                //                //
                //                bindVals.Clear();
                //                //
                //                bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
                //                bindVals.Add("f_primaryKey", this.PK.Trim());                  // PK
                //                //
                //                bindVals.Add("f_record_gubun", this.record_gubun.Trim());        // 레코드 구분
                //                bindVals.Add("f_senta_code", this.senta_code.Trim());            // 센타코드
                //                bindVals.Add("f_irai_key", this.irai_key.Trim());                // 의뢰키
                //                bindVals.Add("f_karute_no", this.karute_no.Trim());              // 카르테NO
                //                bindVals.Add("f_kanjamei", this.kanjamei.Trim());                // 환자이름
                //                bindVals.Add("f_koumokusuu", this.koumokusuu.Trim());            // 결과항목수
                //                bindVals.Add("f_houkokubi", this.houkokubi.Trim());              // 보고일
                //                bindVals.Add("f_yobi1", this.yobi1.Trim());                      // 예비1
                //                bindVals.Add("f_yobi2", this.yobi2.Trim());                      // 예비2
                //                //
                //                //bolval = DBService.ExecuteNonQuery(cmdText, bindVals);
                //                bolval = Service.ExecuteNonQuery(cmdText, bindVals);
                //                if (bolval == false)
                //                {
                //                    //DBService.RollbackTransaction();
                //                    //Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] SetData Error:[{0}]", DBService.ErrFullMsg));
                //                    //DBService.sqlHelper.SQLErrmessagOutput(logFileTag, cmdText, bindVals);
                //                    Service.RollbackTransaction();
                //                    Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] SetData Error:[{0}]", Service.ErrFullMsg));
                //                    //Service.sqlHelper.SQLErrmessagOutput(logFileTag, cmdText, bindVals);
                //                    return false;
                //                } 
                #endregion
                //2015/09/24
                CPL3020U02SetDataIFS7203Args args = new CPL3020U02SetDataIFS7203Args();
                args.RecordGubun = this.record_gubun.Trim();
                args.SentaCode = this.senta_code.Trim();
                args.IraiKey = this.irai_key.Trim();
                args.KaruteNo = this.karute_no.Trim();
                args.Kanjamei = this.kanjamei.Trim();
                args.Koumokusuu = this.koumokusuu.Trim();
                args.Houkokubi = this.houkokubi.Trim();
                args.Yobi1 = this.yobi1.Trim();
                args.Yobi2 = this.yobi2.Trim();
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, CPL3020U02SetDataIFS7203Args>(args);
                if (result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
                {
                    Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] SetData Error:[{0}]", Service.ErrFullMsg));
                    return false;
                }
                //return this.PK
                this.PK = result.Msg;
                foreach (CplSanRituResult cplSRResult in this.cplSanRituResult)
                {
                    cplSRResult.FK = this.PK;
                    //
                    //if (cplSRResult.SetData(aReqMsg) == false)
                    if (cplSRResult.SetData(aServiceID) == false)
                    {
                        //throw new Exception(String.Format("[CplSanRituPtInfo] SetData CplSanRituResult Error[{0}]", DBService.ErrFullMsg));
                        throw new Exception(String.Format("[CplSanRituPtInfo] SetData CplSanRituResult Error[{0}]", Service.ErrFullMsg));
                    }
                }
                //DBService.CommitTransaction();
                //Service.CommitTransaction();
                //
                return true;
            }
            catch (Exception xe)
            {
                //DBService.RollbackTransaction();
                //Service.RollbackTransaction();
                Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituPtInfo] SetData Exception:[{0}][{1}]", xe.Message, xe.StackTrace));
                return false;
            }
            finally
            {
                //DBService.DisConnect();
                //Service.DisConnect();
            }
        }
        #endregion SetData CplSanRituPtInfo

    }

    #region [CplSanRituResult]
    internal class CplSanRituResult
    {
        const int CONST_LINE_LEN = 128;
        String logFileTag = null;

        #region Fields
        public string FK = "";                          // 환자 Master PK
        //
        private string PK = "";                         // PK
        //
        private string record_gubun = "";               // 레코드구분   
        private string senta_code = "";                 // 센타코드
        private string irai_key = "";                   // 의뢰키
        private string hangmog_code = "";               // 검사항목코드
        private string result_code = "";                // 결과항목코드
        private string specimen_ser = "";               // 검체코드
        private string result_val = "";                 // 결과값
        private string danui = "";                      // 단위
        private string from_standard = "";              // 기준값(Min)
        private string to_standard = "";                // 기준값(Max)
        private string emergency = "";                  // 지급보고
        private string yobi1 = "";                      // 예비
        //
        private string temp = "";                       // CONST_LINE_LEN byte 맞춤용
        #endregion Fields

        #region Parse CplSanRituResult
        //public Boolean Parse(OCSReqMsg aReqMsg, String aReceiveData)
        public Boolean Parse(String aServiceID, String aReceiveData)
        {
            //logFileTag = aReqMsg.ServiceID;
            logFileTag = aServiceID;

            try
            {
                this.record_gubun = aReceiveData.Substring(0, 2).Trim();                          // 레코드구분   
                this.senta_code = aReceiveData.Substring(2, 6).Trim();                            // 센타코드
                this.irai_key = aReceiveData.Substring(8, 20).Trim();                             // 의뢰키
                this.hangmog_code = aReceiveData.Substring(28, 10).Trim();                        // 검사항목코드
                this.result_code = aReceiveData.Substring(38, 10).Trim();                         // 결과항목코드
                this.specimen_ser = aReceiveData.Substring(48, 15).Trim();                        // 검체코드
                this.result_val = Service.getWordByByte(aReceiveData, 63, 10).Trim();             // 결과값
                this.danui = Service.getWordByByte(aReceiveData, 73, 10).Trim();                  // 단위
                this.from_standard = Service.getWordByByte(aReceiveData, 83, 10).Trim();          // 기준값(Min)
                this.to_standard = Service.getWordByByte(aReceiveData, 93, 10).Trim();            // 기준값(Max)
                this.emergency = Service.getWordByByte(aReceiveData, 103, 1).Trim();              // 지급보고
                this.yobi1 = Service.getWordByByte(aReceiveData, 104, 10).Trim();                 // 예비
                //
                this.temp = Service.getWordByByte(aReceiveData, 114, (CONST_LINE_LEN - 114 - 1)).Trim(); // 
                //
                return true;
            }
            catch (Exception xe)
            {
                Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] Parse error[{0}][{1}]", xe.Message, xe.StackTrace));
                return false;
            }
        }
        #endregion Parse CplSanRituResult

        #region SetData CplSanRituResult
        //public Boolean SetData(OCSReqMsg aReqMsg)
        public Boolean SetData(String aServiceID)
        {
            //logFileTag = aReqMsg.ServiceID;
            logFileTag = aServiceID;

            //DBSession DBService = new DBSession(aReqMsg.ServiceID);
            //DBSession DBService = new DBSession(aServiceID);
            #region delete by Cloud version
            //            Service.Connect();

            //            bool bolval = false;
            //            string cmdText = "";
            //            object retVal = null;

            //            cmdText = @"SELECT IFS7204_SEQ.NEXTVAL FROM SYS.DUAL";
            //            //
            //            //retVal = DBService.ExecuteScalar(cmdText);
            //            retVal = Service.ExecuteScalar(cmdText);
            //            if (retVal == null)
            //            {
            //                //Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData : CplSanRituResult PK Creation Error :[{0}]", DBService.ErrFullMsg));
            //                Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData : CplSanRituResult PK Creation Error :[{0}]", Service.ErrFullMsg));
            //                return false;
            //            }
            //            //검사결과 PrimaryKey 취득
            //            this.PK = retVal.ToString();
            //            //
            //            try
            //            {
            //                BindVarCollection bindVals = new BindVarCollection();

            //                cmdText = @"INSERT INTO IFS7204
            //                                ( SYS_DATE          , SYS_ID            , HOSP_CODE
            //                                 , PKIFS7204
            //                                 , RECORD_GUBUN          , SENTA_CODE                , IRAI_KEY
            //                                 , HANGMOG_CODE          , RESULT_CODE               , SPECIMEN_SER  
            //                                 , RESULT_VAL            , DANUI         
            //                                 , FROM_STANDARD         , TO_STANDARD   
            //                                 , EMERGENCY             , YOBI1         
            //                                 , FKIFS7203
            //                                 , IF_DATE
            //                                 , IF_TIME
            //                                 , IF_FLAG
            //                                 , IF_ERR
            //                            ) VALUES (
            //                                   SYSDATE          , 'IF'            , :f_hosp_code
            //                                 , :f_primaryKey            
            //                                 , :f_record_gubun          , :f_senta_code                , :f_irai_key
            //                                 , :f_hangmog_code          , :f_result_code               , :f_specimen_ser  
            //                                 , :f_result_val            , :f_danui         
            //                                 , :f_from_standard         , :f_to_standard   
            //                                 , :f_emergency             , :f_yobi1         
            //                                 , :f_fk
            //                                 , TRUNC(SYSDATE) 
            //                                 , TO_CHAR(SYSDATE,'HH24MISS') 
            //                                 , '10'
            //                                 , NULL
            //                                 )
            //                            ";
            //                //
            //                //if (!DBService.Connect())
            //                if (!Service.Connect())
            //                {
            //                    //Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData : DB Connect Error[{0}]", DBService.ErrMsg));
            //                    Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData : DB Connect Error[{0}]", Service.ErrMsg));
            //                    return false;
            //                }
            //                //Service.WriteLog(logFileTag, "DB Connect");
            //                //
            //                bindVals.Clear();
            //                //
            //                bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
            //                //
            //                bindVals.Add("f_fk", this.FK.Trim());                                          // FK
            //                //
            //                bindVals.Add("f_primaryKey", this.PK.Trim());                                  // PK
            //                //
            //                bindVals.Add("f_record_gubun", this.record_gubun.Trim());                        // 레코드구분   
            //                bindVals.Add("f_senta_code", this.senta_code.Trim());                            // 센타코드
            //                bindVals.Add("f_irai_key", this.irai_key.Trim());                                // 의뢰키
            //                bindVals.Add("f_hangmog_code", this.hangmog_code.Trim());                        // 검사항목코드
            //                bindVals.Add("f_result_code", this.result_code.Trim());                          // 결과항목코드
            //                bindVals.Add("f_specimen_ser", this.specimen_ser.Trim());                        // 검체코드
            //                bindVals.Add("f_result_val", this.result_val.Trim());                            // 결과값
            //                bindVals.Add("f_danui", this.danui.Trim());                                      // 단위
            //                bindVals.Add("f_from_standard", this.from_standard.Trim());                      // 기준값(Min)
            //                bindVals.Add("f_to_standard", this.to_standard.Trim());                          // 기준값(Max)
            //                bindVals.Add("f_emergency", this.emergency.Trim());                              // 지급보고
            //                bindVals.Add("f_yobi1", this.yobi1.Trim());                                      // 예비
            //                //
            //                //bolval = DBService.ExecuteNonQuery(cmdText, bindVals);
            //                bolval = Service.ExecuteNonQuery(cmdText, bindVals);
            //                if (bolval == false)
            //                {
            //                    ////DBService.RollbackTransaction();
            //                    //Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData Error:[{0}]", DBService.ErrFullMsg));
            //                    //DBService.sqlHelper.SQLErrmessagOutput(logFileTag, cmdText, bindVals);
            //                    //Service.RollbackTransaction();
            //                    Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData Error:[{0}]", Service.ErrFullMsg));
            //                    //Service.sqlHelper.SQLErrmessagOutput(logFileTag, cmdText, bindVals);
            //                    return false;
            //                }
            //                return true;
            //            }
            //            catch (Exception xe)
            //            {
            //                //DBService.RollbackTransaction();
            //                Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData Exception:[{0}][{1}]", xe.Message, xe.StackTrace));
            //                return false;
            //            } 
            #endregion
            try
            {
                CPL3020U02SetDataIFS7204Args args = new CPL3020U02SetDataIFS7204Args();
                args.Danui = this.danui.Trim();
                args.Emergency = this.emergency.Trim();
                args.Fk = this.FK.Trim();
                args.FromStandard = this.from_standard.Trim();
                args.HangmogCode = this.hangmog_code.Trim();
                args.IraiKey = this.irai_key.Trim();
                args.RecordGubun = this.record_gubun.Trim();
                args.ResultCode = this.result_code.Trim();
                args.ResultVal = this.result_val.Trim();
                args.SentaCode = this.senta_code.Trim();
                args.SpecimenSer = this.specimen_ser.Trim();
                args.ToStandard = this.to_standard.Trim();
                args.Yobi1 = this.yobi1.Trim();
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, CPL3020U02SetDataIFS7204Args>(args);
                if (result.ExecutionStatus != ExecutionStatus.Success && !result.Result)
                {
                    Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData Error:[{0}]", Service.ErrFullMsg));
                    return false;
                }
                this.PK = result.Msg;
                return true;
            }
            catch (Exception xe)
            {
                //DBService.RollbackTransaction();
                Service.ErrWriteLog(logFileTag, String.Format("[CplSanRituResult] SetData Exception:[{0}][{1}]", xe.Message, xe.StackTrace));
                return false;
            }
        }
        #endregion SetData CplSanRituResult

    }
    #endregion [CplSanRituResult]

    #endregion  [CplSanRituPtInfo]
}
