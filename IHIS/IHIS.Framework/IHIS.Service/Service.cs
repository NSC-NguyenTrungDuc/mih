using System;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using System.Globalization;
using System.Drawing;

namespace IHIS.Framework
{
    public class Service
    {
        // Static Members
        static Dictionary<String, String> strLogMsg = new Dictionary<String, String>();

        #region Static Fields
        const string MSG_TITLE = "DB Connection";
        static Encoding baseEncoding = Encoding.GetEncoding("ks_c_5601-1987");
        static Encoding koEncoding = null; //한글 Encoding
        static Encoding jpEncoding = null; //일본어 Encoding
        //static LangMode langMode = LangMode.Ko;
        //static string configFileName = "IHIS.config";  //IHIS 환경파일
        static string configFileName = "KCCK.config";  //IHIS 환경파일
        static string errMsg = "";    //Service Call시 발생한 Msg(Oracle Error 약식)
        static string errFullMsg = "";  //Oracle Full Err Msg
        static int errCode = 0;	  //Oracle Error Code (정상 0, Oracle 이외의 에러는 -1)
        static XmlDocument configXml = new XmlDocument();  //config File Xml 관리 Document
        //MultiSession 관련(
        static SessionInfo currentSession = null;  //현재 선택된 Session 정보
        static bool isDefaultSession = true;  //현재 Session이 기본 Session인지 여부
        static bool isAssemblyDownload = true;  //어셈블리 다운로드 여부 (IHIS.config에서 관리, 서버에서 파일 다운로드 여부)

        static int callstackdeeps = 20;

        // MED-14286
        /// <summary>
        /// Arial, 8.75f
        /// </summary>
        public static readonly Font COMMON_FONT = new Font("Arial", 8.75f);
        /// <summary>
        /// Arial, 8.75f, Bold style
        /// </summary>
        public static readonly Font COMMON_FONT_BOLD = new Font("Arial", 8.75f, FontStyle.Bold);

        #endregion

        #region Static Properties
        internal static IDbConnection Connection
        {
            get
            {
                if (currentSession == null) return null;

                return currentSession.Connection;
            }
        }
        internal static IDbTransaction Transaction
        {
            get
            {
                if (currentSession == null) return null;

                return currentSession.Transaction;
            }

            set
            {
                if (currentSession == null) return;

                currentSession.Transaction = value;
            }
        }
        /// <summary>
        /// 기본문자 Encoding을 가져옵니다.(LangMode에 따라 변경)
        /// </summary>
        public static Encoding BaseEncoding
        {
            get { return baseEncoding; }
        }
        /// <summary>
        /// 한글 Encoding을 가져옵니다.
        /// </summary>
        public static Encoding KoEncoding
        {
            get { return koEncoding; }
        }
        /// <summary>
        /// 일본어 Encoding을 가져옵니다.
        /// </summary>
        public static Encoding JpEncoding
        {
            get { return jpEncoding; }
        }
        ///// <summary>
        ///// 언어 모드(Ko:한글, Jr.일본어)
        ///// </summary>
        //public static LangMode LangMode
        //{
        //    get { return langMode; }
        //}
        public static string ErrMsg
        {
            get { return errMsg; }
        }
        public static string ErrFullMsg
        {
            get { return errFullMsg; }
        }
        public static int ErrCode
        {
            get { return errCode; }
        }
        //IHIS 환경파일명(IHIS.config)
        public static string ConfigFileName
        {
            get { return configFileName; }
        }
        //현재 Session이 기본 Session인지 여부
        public static bool IsDefaultSession
        {
            get { return isDefaultSession; }
        }
        //환경파일을 Load한 XmlDocument
        public static XmlDocument ConfigXml
        {
            get { return configXml; }
        }
        internal static SessionInfo CurrentSession
        {
            get { return Service.currentSession; }
        }
        //현재 DB Session의 종류
        public static DataBaseKind CurrentDBKind
        {
            get
            {
                try
                {
                    return Service.currentSession.DBKind;
                }
                catch
                {
                    return DataBaseKind.Oracle;
                }
            }
        }
        //DbKind에 따른 Bind 변수의 Symbol (Oracle -> :, SqlServer -> @)
        public static string BindSymbol
        {
            get
            {
                //<미확정> ODBC, OleDb의 경우는 Symbol 관리를 어떻게 할 것인가
                string symbol = ":";
                if (CurrentDBKind == DataBaseKind.SqlServer)
                    symbol = "@";

                //2010.03.25. 김민수 테스트 중 - OleDb 의 경우
                //if (Service.currentSession.ProviderKind == ProviderKind.OleDB)
                //    symbol = ":";

                return symbol;

            }
        }
        public static bool IsAssemblyDownLoad
        {
            get { return isAssemblyDownload; }
        }

        // <<2017.07.20>> DLL_CROSS START : DLL 의 교차참조 해결을 위함
        //                Forms.EnvironInfo 의 ClientIP 를 Service로 옮김.
        //                추가 : using System.Net;
        //                
        public static string ClientIP
        {
            get
            {
                try
                {
                    //IP 2개이상 지정된 PC의 경우 최종  IP가 사용하는 IP임
                    IPAddress[] ipList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

                    if (ipList.Length > 0)
                    {
                        foreach (IPAddress ipa in ipList)
                        {
                            if (ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                return ipa.ToString();
                            }
                        }
                    }
                    //if (ipList.Length > 0)
                    //	return ipList[ipList.Length -1].ToString();
                    //else
                    return "UnKnown";
                }
                catch
                {
                    return "UnKnown";
                }
            }
        }
        // <<2017.07.20>> DLL_CROSS END

        // <<2017.07.26>> DLL_CROSS START
        private static string hospCode = string.Empty;

        public static string HospCode
        {
            get { return hospCode; }
        }
        // <<2017.07.26>> DLL_CROSS END

        #endregion

        #region Static Constructor(s)
        /// <summary>
        /// Service static 생성자
        /// </summary>
        static Service()
        {
            //config Xml Load
            string fileName = Application.StartupPath + "\\" + configFileName;
            if (!File.Exists(fileName))
            {
                //throw new Exception("IHIS config file(IHIS.config) does not exist");
                Debug.WriteLine("IHIS config file(IHIS.config) does not exist");
                return;
            }
            try
            {
                TextReader textReader = new StreamReader(fileName);
                XmlReader xmlReader = new XmlTextReader(textReader);
                configXml.Load(xmlReader);
                xmlReader.Close();
                textReader.Close();
            }
            catch (Exception xe)
            {
                //throw new Exception("IHIS config file load error[" + xe.Message + "]");
                Debug.WriteLine("IHIS config file load error[" + xe.Message + "]");
                return;
            }

            //LanguageMode
            SetLangMode();

            //어셈블리 다운로드 여부 SET
            //<미확정> 임시용 어셈블리 Version Check하지 않고 프로그램 실행
            isAssemblyDownload = (GetConfigString("DOWNLOAD", "MODE", "On").ToUpper() == "ON" ? true : false);

            // Encoding Type Set (Default로 SET)
            baseEncoding = (NetInfo.Language == LangMode.Ko ? Encoding.GetEncoding("ks_c_5601-1987")
                : (NetInfo.Language == LangMode.Jr ? Encoding.GetEncoding("Shift_JIS") : Encoding.ASCII));
            //2005.10.27 한글, 일본어 Encoding 추가
            koEncoding = Encoding.GetEncoding("ks_c_5601-1987");
            jpEncoding = Encoding.GetEncoding("Shift_JIS");

            //Default Session Set (현재 DbInfo Set)
            Service.currentSession = SessionInfo.SessionInfoList["Default"] as SessionInfo;

            baseEncoding = jpEncoding;

            hospCode = GetConfigString("HOSP", "CODE", "T01");


        }
        #endregion

        #region GetConfigString, SetConfigString (Config File에서 지정한 Session의 Key의 값을 가져옴)
        public static string GetConfigString(string session, string key, string defaultValue)
        {
            try
            {
                //지정한 Element의 Attribute 의 값 Get
                foreach (XmlNode node in configXml.DocumentElement.ChildNodes)
                {
                    if (node.Name == session)
                    {
                        if (node.Attributes[key] != null)
                            return node.Attributes[key].Value;
                        else
                            return defaultValue;
                    }
                }
            }
            catch
            {
                return defaultValue;
            }

            return defaultValue;

        }
        //지정된 Node에 key Attribute Set
        public static void SetConfigString(string session, string key, string setValue)
        {
            try
            {
                XmlNode sNode = null;
                foreach (XmlNode node in configXml.DocumentElement.ChildNodes)
                {
                    if (node.Name == session)
                    {
                        if (node.Attributes[key] != null)
                            node.Attributes[key].Value = setValue;
                        else
                            ((XmlElement)node).SetAttribute(key, setValue);
                        sNode = node;
                        break;
                    }
                }
                //Node가 없으면 Set
                if (sNode == null)
                {
                    XmlElement element = configXml.CreateElement(session);
                    element.SetAttribute(key, setValue);
                    configXml.DocumentElement.AppendChild(element);
                }

                //Save Config File
                using (TextWriter tw = new StreamWriter(Application.StartupPath + "\\" + configFileName, false, baseEncoding))
                    configXml.Save(tw);
            }
            catch { }
        }
        #endregion

        #region SetLangMode (언어Mode Set)
        private static void SetLangMode()
        {
            switch (CultureInfo.CurrentUICulture.Name)
            {
                case "ja-JP":
                    NetInfo.Language = LangMode.Jr;
                    break;
                case "en":
                    NetInfo.Language = LangMode.En;
                    break;
                case "vi-VN":
                    NetInfo.Language = LangMode.Vi;
                    break;
                default:
                    NetInfo.Language = LangMode.Jr;
                    break;
            }
            //string mode = GetConfigString("LANG", "MODE", "Jr");
            ////언어모드 설정
            //NetInfo.Language = (mode == "Ko" ? LangMode.Ko : (mode == "Jr" ? LangMode.Jr : LangMode.En));
        }
        #endregion

        #region ChangeSession (Session을 변경함), SetDefaultSession(기본 Session을 설정)
        public static bool ChangeSession(string sessionName)
        {
            if (!SessionInfo.SessionInfoList.Contains(sessionName))
            {
                string msg = XMsg.GetMsg("M003");  //Session명을 잘못 지정하셨습니다.
                MessageBox.Show(msg, MSG_TITLE);
                return false;
            }
            //현재 Session을 지정한 Session으로 설정
            Service.currentSession = SessionInfo.SessionInfoList[sessionName] as SessionInfo;

            //기본 Session 여부 false Set
            Service.isDefaultSession = false;

            return true;
        }
        public static void SetDefaultSession()
        {
            //현재 Session을 기본 Session으로 설정
            Service.currentSession = SessionInfo.SessionInfoList["Default"] as SessionInfo;

            //기본 Session 여부 복구
            Service.isDefaultSession = true;
        }
        #endregion

        #region Connect, DisConnect (DB 연결 및 해제)
        public static bool Connect()
            {
            string msg = "";

            if (Service.Connection == null) return false;

            //이미 열려 있으면 Return
            if (Service.Connection.State == ConnectionState.Open) return true;

            try
            {
                Service.Connection.Open();

                #region deleted by Cloud
                ////2006.05.09 Oracle로 연결시에 Session의 NLS_DATE_FORMAT을 YYYY/MM/DD 형식으로 변경하는 Logic 추가
                ////Oracle Client 설치시에 Registry(HKLM/SOFTWARE/ORACLE의 NLS_LANG을 KOREAN_KOREA.UTF8, NLS_DATE_FORMAT = YYYY/MM/DD
                ////로 해주면 Session에 관계없이 Format이 잡힌다고 설명서에는 나와있는데, 설정을 해도 계속 DD-MON-RR형태로 조회됨.
                ////따라서, 일단은 Session의 NLS_DATE_FORMAT을 Alter하여 처리함.
                //if (Service.currentSession.DBKind == DataBaseKind.Oracle)
                //{
                //    string dmlText = "ALTER SESSION SET NLS_DATE_FORMAT = 'YYYY/MM/DD'";
                //    Service.ExecuteNonQuery(dmlText);
                //}

                ////2010.07.28. kimminsoo DB Objects에 hosp_code 관련 로직 추가에 필요한 작업
                //string hosp_code = GetConfigString("HOSP", "CODE", "K01");
                //string sqlText = "SELECT A.HOSP_CODE FROM ADM5000 A WHERE A.IP_ADDR = SYS_CONTEXT('USERENV','IP_ADDRESS')";
                //object retVal = Service.ExecuteScalar(sqlText);
                //if (retVal == null)
                //{
                //    //insert
                //    sqlText = "INSERT INTO ADM5000 VALUES (SYSDATE,SYS_CONTEXT('USERENV','IP_ADDRESS'),'" + hosp_code + "')";
                //}
                //else
                //{
                //    //update
                //    sqlText = "UPDATE ADM5000 SET HOSP_CODE = '" + hosp_code + "' WHERE IP_ADDR = SYS_CONTEXT('USERENV','IP_ADDRESS')";
                //}

                //if (!Service.ExecuteNonQuery(sqlText))
                //{
                //    debugFileWrite("hosp_code update err" + Service.errCode + " : " + Service.ErrFullMsg);
                //}
                #endregion

                // updated by Cloud
                FwServiceConnectArgs args = new FwServiceConnectArgs();
                args.DbKind = Service.currentSession.DBKind.ToString();
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, FwServiceConnectArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {

                }
            }
            catch (Exception xe)
            {
                if (xe is InvalidOperationException)  //이미 연결된 경우
                    msg = XMsg.GetMsg("M001");  //이미 DB 연결되었습니다.
                else //Db 연결 오류
                    msg = XMsg.GetMsg("M002", xe); //DB 연결에러[" + xe.Message + "]"
                MessageBox.Show(msg, MSG_TITLE);
                return false;
            }
            return true;
        }

        public static void DisConnect()
        {
            //Connect 해제
            if (Service.Connection == null) return;
            if (Service.Connection.State == ConnectionState.Closed) return;

            Service.Connection.Close();
        }
        #endregion

        #region <RECONN_DB> DB의 연결이 임시적으로 끊겼는지 여부를 확인하고 다시 DB 연결처리하기(Network문제로 인해 중간에 연결이 끊긴경우) 이즈스카 병원으로 받은 소스로 추가(2012.04.17)
        private static bool CheckExceptionAndReConnect(Exception xe)
        {
            if ((currentSession.ProviderKind == ProviderKind.Oracle) && (xe is OracleException))
            {
                OracleException oex = (OracleException)xe;
                /* DB Connect 오류 코드
                 * ORA-01012: not logged on
                 * ORA-00257: archiver error. Connect internal only,
                 * ORA-03113: end-of-file on communication channel
                 * ORA-03114: not connected to ORACLE 
                 * ORA-03135: connection lost contact 
                 * ORA-04068: existing state of packagesstringstringstring has been discarded 
                 * <TEST_RESULT> Lan선 접속불량시 ErrorCode가 ORA-12152로 오지 않고, State는 open상태
                 * 그다음 또 call했을 경우 ORA-03114, State는 Closed상태임.
                 * ORA-12150, Unable to send data. Connection probably disconnected.
                 * ORA-12152,  Unable to send break message. Connection probably disconnected.
                 * ORA-12153  Not currently connected to a remote host 도 추가.
                 */
                int code = Math.Abs(oex.Code);
                if (code == 1012 || code == 257 || code == 3113 || code == 3114 || code == 3135 || code == 4068
                    || code == 12150 || code == 12152 || code == 12153)
                {
                    /*OracleException발생시 DB를 다시 연결할때 return Service.Connect()할때 DB가 끊긴상태에서도 Service.Connection.State가 Open상태로 남아 있는지
                    아니면 다른 상태가 되는지 확인요, DB가 끊긴상태에서도 Open상태로 남아 있다면 다르게 구현해야함.
                    MySQL로는 test결과 Client에서 disConnect하거나, 서버에서 해당 Session을 죽이면 State가 Closed로 됨.
                    DB Session이 끊긴경우 State가 Closed이면 다시 연결하는 로직이 더 낳을지도, (아래 MySQL과 같이) <NEED_TEST>
                    */
                    debugFileWrite("Service::CheckExceptionAndReConnect ErrorCode=" + code);
                    debugFileWrite("Service::CheckExceptionAndReConnect Service.Connection.State=" + Service.Connection.State.ToString());
                    return Service.Connect();
                }
                else if (Service.Connection.State == ConnectionState.Closed || Service.Connection.State == ConnectionState.Broken)
                {
                    debugFileWrite("Service::CheckExceptionAndReConnect ErrorCode=" + code);
                    debugFileWrite("Service::CheckExceptionAndReConnect Service.Connection.State=" + Service.Connection.State.ToString());
                    //Reconnect
                    return Service.Connect();
                }
                return false;

            }
            else if (currentSession.ProviderKind == ProviderKind.MySql)  //MySQL
            {
                /*MySQL Provider는 다른 Exception으로 conversion 불가하며 message가 Client에서 Close하면 "DB Connection is not opened" 나옴.
                 * 서버에서 해당 Session을 죽이면 맨 처음은 Connection unexpectedly terminated 후에 DB Connection is not opened.
                 * 이 상태에 Service.Connection.State는 Closed상태가 됨.
                 * 따라서, message를 가지고 판단하지 말고, State를 가지고 판단하는 것이 타당할듯.
                 * 서버에서 강제로 Session을 종료한 경우는 Command를 call하기 전까지는 Open상태이다가 Command Call후 Exception이 발생하면서
                 * Closed상태가 됨, 따라서, 각 Exeute 함수에서 Command Call전에 if (State != Opened) Service.Connect()를 하면 처음 Call시는
                 * Exception이 발생한 후에 다음 처리부터 정상적으로 작동하므로 Exception에서 처리하는 것이 타당함.
                 */
                if (Service.Connection.State == ConnectionState.Closed || Service.Connection.State == ConnectionState.Broken)
                    return Service.Connect();
                return false;
            }
            else if (currentSession.ProviderKind == ProviderKind.SqlServer)
            {
                //<NOT_DEF> SqlException으로 변환가능한지 확인필요(MSSQL) 일단 MySQL과 동일한 기준으로 처리함.
                if (Service.Connection.State == ConnectionState.Closed || Service.Connection.State == ConnectionState.Broken)
                    return Service.Connect();
                return false;
            }
            else //OleDB, ODBC 도 MySQL과 동일하게 처리함.
            {
                if (Service.Connection.State == ConnectionState.Closed || Service.Connection.State == ConnectionState.Broken)
                    return Service.Connect();
                return false;
            }
        }
        #endregion

        #region private utility Methods
        //2006.08.10 ParseBindVarList에 SQL을 계속 분석하여 Bind변수를 찾지 않고, 같은 SQL은 Hash에서 관리하여 Hash에서 바로 가져오도록 처리
        private static Hashtable bindVarListHash = new Hashtable();
        /// <summary>
        /// CommandText에서 BindVar를 분석하여 전달된 Parameter를 Return함
        /// </summary>
        /// <param name="commandText"> SQL Text </param>
        /// <param name="bindVarList"> Bind 변수 List </param>
        /// <returns></returns>
        private static IDbDataParameter[] ParseBindVarList(string commandText, BindVarCollection bindVarList)
        {
            //실제 SQL의 Bind변수보다 적게 bindVarList를 지정하면 ORA-01008: not all variables bound 에러 발생
            //IN 값을 잘못해서 InOut으로 지정시는 에러 발생하지 않음
            //Out값에 Size를 지정하지 않으면 Parameter 'f_number': No size set for variable length data type: String.
            //InOut값을 In으로만 지정시는 ORA-06502: PL/SQL: numeric or value error: character string buffer too small
            //Return되는 값이 ValueLen보다 큰 경우는 ORA-06502: PL/SQL: numeric or value error 에 발생함.
            //IN 값의 Size가 실제 데이타 보다 작으면 SQL 분석시 잘려서 분석되어 데이타가 없다는 에러가 발생할 가능성이 있음

            //SQL 구분에서 BindVar 분석
            //2006.08.10 SQL을 계속 분석하여 Bind변수를 찾지 않고, 같은 SQL은 Hash에서 관리하여 Hash에서 바로 가져오도록 처리
            BindVarCollection bindList = null;
            if (bindVarListHash.Contains(commandText))
                bindList = (BindVarCollection)bindVarListHash[commandText];
            else
            {
                bindList = new BindVarCollection();  //정확한 Bind 변수 List
                SQLHelper.InitBindVarList(commandText, bindList);
                bindVarListHash.Add(commandText, bindList);
            }

            foreach (BindVar bVar in bindVarList)
            {
                //SQL내에 분석한 Bind변수와 일치하면 전달받은 Value, ValueLen Set
                if (bindList.Contains(bVar.VarName))
                {
                    BindVar bindVar = bindList[bVar.VarName];
                    bindVar.VarValue = bVar.VarValue;
                    bindVar.ValueLen = bVar.ValueLen;
                }
            }
            if (bindList.Count > 0)
            {
                IDbDataParameter[] commandParameters = new IDbDataParameter[bindList.Count];
                for (int i = 0; i < bindList.Count; i++)
                {
                    BindVar bindVar = bindList[i];
                    //2006.07.20 in Oracle VarValue가 ""으로 넘어가도 NVL 가능한데, in SqlServer에서는 ISNULL이 안됨
                    //따라서, DBNull.Value로 넘김
                    /*2006.08.03 <미확정>
                     * VS2003에서 SQL Server, Oracle이 Driver를 Microsoft OLE DB Provider for SQL Server 사용
                     * VS2005에서 SQL Server는 .NET Framework Data Provider for SQL Server, Oracle은 .NET Framework Data Provider for Oracle 사용
                     * 이 차이로 인해 SQL문에 :f_xxx (Oracle), @f_xxx(SqlServer)사용시에 commandParameter의 Name을 설정하는 기준이 달라짐
                     * VS2003 Oracle에서는 Name을 f_xxx로 하든, :f_xxx로 하든 관계없이 잘 연동이 되나,
                     *        SqlServer에서는 Name을 f_xxx로 하면 에러가 발생(변수로 인식못함) 하고, @f_xxx로 하면 정상적으로 작동됨
                     * 따라서, SqlServer 에러 방지를 위해 일단 Parameter의 Name은 :f_xxx, @f_xxx로 설정한다.
                     */
                    //commandParameters[i] = Service.currentSession.DbFactory.NewDataParamater(bindVar.VarName, bindVar.VarValue);
                    //commandParameters[i] = Service.currentSession.DbFactory.NewDataParamater(bindVar.VarName, (bindVar.VarValue == string.Empty ? DBNull.Value : (object) bindVar.VarValue));
                    commandParameters[i] = Service.currentSession.DbFactory.NewDataParamater(Service.BindSymbol + bindVar.VarName, (bindVar.VarValue == string.Empty ? DBNull.Value : (object)bindVar.VarValue));


                    //<미확정> BindVar에 대해 Output 데이타를 어떻게 설정할지는 여러가지 Case를 봐가며 추가할지 여부 확정
                    //2006.03.27 BindVar의 isOutValue 속성에 따라 설정하기
                    //IN 값을 InOut 값으로 지정해도 SQL 수행에는 문제가 없으므로 따로 IsOutValue를 관리하지 않고 모두 InOut으로 설정하는 방법은 어떨까..
                    //일단은 IsOutValue를 관리하지 않고, 모두 InOut으로 관리하는 방향으로 가자.
                    commandParameters[i].Direction = ParameterDirection.InputOutput;
                    commandParameters[i].Size = bindVar.ValueLen;
                }
                return commandParameters;
            }
            else
                return new IDbDataParameter[0];
        }
        /// <summary>
        /// This method is used to attach array of IDbDataParameter to a IDbCommand.
        /// 
        /// This method will assign a value of DbNull to any parameter with a direction of
        /// InputOutput and a value of null.  
        /// 
        /// This behavior will prevent default values from being used, but
        /// this will be the less common case than an intended pure output parameter (derived as InputOutput)
        /// where the user provided no input value.
        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of IDbDataParameters to be added to command</param>
        private static void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                debugFileWriteParam(commandParameters);
                string cmdText = command.CommandText;
                foreach (IDbDataParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);

                        /* 2010.03.16. kimminsoo 수정 
                         * oledb의 경우 기존의 :f_xxx 와 같은 포멧으로 넘겨 받을수가 없음
                         * 파라미터 명칭으로 구분하지 않고 순서로 구분해주고 있음.
                         * select * from aa where aa.bb = ? and aa.cc = ?;
                         * 이런식임. 따라서 command의 commandText를 수정해주어야함.
                         */
                        //oledb 일때 처리방식
                        //if (Service.currentSession.ProviderKind == ProviderKind.OleDB)
                        //{
                            //Debug.WriteLine(command.CommandText.Replace(":", "'").Replace(p.ParameterName, p.Value.ToString() + "'"));
                        //    command.CommandText = command.CommandText.Replace(":", "'").Replace(p.ParameterName, p.Value.ToString() + "'");
                        //}
                        // 2010.11.25 kimminsoo 수정 디버그 파일에 파라미터 같이 찍어주기
                        cmdText = cmdText.Replace(p.ParameterName, "'" + p.Value.ToString() + "'");
                    }
                }
                debugFileWrite(cmdText);
            }
        }

        /// <summary>
        /// This method assigns an array of values to an array of IDbDataParameters
        /// </summary>
        /// <param name="commandParameters">Array of IDbDataParameters to be assigned values</param>
        /// <param name="parameterValues">Array of objects holding the values to be assigned</param>
        private static void AssignParameterValues(IDbDataParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                // Do nothing if we get no data
                return;
            }

            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            // Iterate through the IDbDataParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if (paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if (parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }


        /// <summary>
        /// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
        /// to the provided command
        /// </summary>
        /// <param name="command">The IDbCommand to be prepared</param>
        /// <param name="connection">A valid IDbConnection, on which to execute this command</param>
        /// <param name="transaction">A valid IDbTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of IDbDataParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        private static void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open) throw new Exception("DB Connection is not opened");

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            // BeginTransaction을 통해 넘겨받은 Transaction 객체를 전달함. BeginTran 호출후 Command에 Transaction 객체를 할당
            //하지 않으면 오류가 발생하므로 반드시 객체를 할당해야함.
            if (Service.Transaction != null)
            {
                if (Service.Transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            else
            {
                debugFileWrite(command.CommandText);
            }

            return;
        }
        private static void ResetErrMsg()
        {
            Service.errCode = 0;
            Service.errFullMsg = "";
            Service.errMsg = "";
        }
        private static void SetErrMsg(Exception xe)
        {
            if (xe is OracleException)
            {
                //Oracle Full Msg = ORA-20201: 사용자ID를 잘못 입력하셨습니다.\nORA-06512: at \"MEDI.PR_ADM_CHECK_LOGIN\", line 163\nORA-06512: at line 1\n
                OracleException oxe = xe as OracleException;
                Service.errFullMsg = xe.Message;
                string msg = xe.Message;
                int index1 = msg.IndexOf("\n");
                int index2 = msg.IndexOf(":");
                if (index1 >= 0 && index2 >= 0 && index1 > index2)  //errmsg는 첫번째 Line의 메세지만 처리함.
                    Service.errMsg = msg.Substring(index2 + 1, index1 - index2 - 1).Trim();
                Service.errCode = oxe.Code;  //Oracle Error Code
            }
            else
            {
                Service.errFullMsg = xe.Message;
                Service.errMsg = xe.Message;
                Service.errCode = -1;
            }
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// Execute a IDbCommand (that returns no resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static bool ExecuteNonQuery(string commandText)
        {
            // Pass through the call providing null for the set of IDbDataParameters
            return ExecuteNonQuery(CommandType.Text, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// BinVarList를 이용하여 SQL문의 Parameter 설정하는 Method (BEGIN-END, INSERT, UPDATE, DELETE ...)
        /// </summary>
        /// <param name="commandText"> 처리 SQL </param>
        /// <param name="bindVarList"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string commandText, BindVarCollection bindVarList)
        {
            IDbDataParameter[] commandParameters = ParseBindVarList(commandText, bindVarList);

            if (commandParameters.Length > 0)
            {
                bool ret = ExecuteNonQuery(CommandType.Text, commandText, commandParameters);
                if (ret) //성공시 bindVarList에서 OutValue로 설정된 값 설정
                {
                    //<미확정> bindVarList의 갯수 > Parameter의 갯수보다 큼 (Match 안된 bindVar가 있을 수 있음)
                    //따라서, Params을 기준으로 BindVarList에 일치하는 Name이 있으면 설정해야함

                    BindVar bVar = null;
                    IDbDataParameter dbParam = null;
                    for (int i = 0; i < commandParameters.Length; i++)
                    {
                        dbParam = commandParameters[i];
                        bVar = bindVarList[dbParam.ParameterName];
                        if (bVar != null)
                            bVar.VarValue = dbParam.Value.ToString();
                    }
                }
                return ret;
            }
            else
                return ExecuteNonQuery(CommandType.Text, commandText, null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns no resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(CommandType.StoredProcedure, "PublishOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        private static bool ExecuteNonQuery(CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            try
            {
                debugFileWrite("ExecuteNonQuery start : " + DateTime.Now.ToString());

                //2010.07.24.kimminsoo
                //commandText에 끝문자가 ; 이면 해당 문자 삭제하고 처리하기. 그렇지 않으면 에러 발생함.
                //if (commandText.Length > 0 && commandText.Substring(commandText.Length - 1, 1).IndexOf(";") >= 0)
                //{
                //    commandText = commandText.Substring(0, commandText.Length - 1);
                //}

                ResetErrMsg();
                // Create a command and prepare it for execution
                IDbCommand cmd = Service.currentSession.DbFactory.NewCommand();

                //2006.03.28 Transaction 객체 관리
                PrepareCommand(cmd, Service.Connection, Service.Transaction, commandType, commandText, commandParameters);

                // Finally, execute the command
                int ret = cmd.ExecuteNonQuery();
                /* ret Value Check (2007.10.01)
                 * case Oracle
                 *  Insert, Update, delete 문은 반영된 행의 갯수, 0.반영된 행의 갯수가 없으면 에러로 처리한다. --> 2010.11.25 kimminsoo 수정:0인경우는 성공으로 판단
                 *  PL/SQL문 : 성공시 1, 실패시 Exception
                 *  Procedure : 성공시 1, 실패시 Exception
                 *  CREATE OR ALTER 등 DDL문(Table,SP 생성문) : 성공시 0, 실패시 Exception  --> 2010.11.25 kimminsoo 수정:이 케이스 때문에 0인 경우도 성공으로 판단해야함
                 *  문제는 각 Case마다 성공값이 다르므로 어떻게 판단해야 하는가가 문제가 있다. 특히 I,U,D문은 0를 실패로 --> 2010.11.25 kimminsoo 수정:0인경우도 성공으로 판단
                 *  CREATE문은 0를 성공으로 판단하여야 하는 문제가 가장크다. 
                 *  MS_SQL, MY_SQL등은 CASE별 확인필요 (거의 Oracle과 동일하다고 생각됨)
                 *  따라서, DDL문을 제공하는 Method (ExecuteDDL) 을 따로 제공하는 것으로 정리하자.
                 */
                //ret Value Check (UPDATE,INSERT,DELETE문은 반영된 행의 갯수 Return, 다른형식문은 -1)
                //따라서, 성공 기준을 ret > 0 이거나 -1인 경우만 true 아니면 false로 처리한다.

                // Detach the IDbDataParameters from the command object, so they can be used again
                cmd.Parameters.Clear();
                // 2010.11.25 kimminsoo 수정 : 0인 경우도 당연히 성공으로 판단해야함.  기존로직 --> bool retVal = (ret > 0 ? true : (ret == -1 ? true : false));
                bool retVal = (ret >= 0 ? true : (ret == -1 ? true : false));
                if (!retVal) //ErrorMsg SET
                {
                    Service.errCode = -1;
                    Service.errFullMsg = "Execute Error(Data does not changed)";
                    Service.errMsg = "Execute Error(Data does not changed)";

                    debugFileWrite("error : " + Service.ErrFullMsg);
                }

                debugFileWrite("end : " + DateTime.Now.ToString());
             
                return retVal;
            }
            catch (Exception xe)
            {
                //<RECONN_DB>DB연결오류로 재연결 성공시에는 자신을 한번 더 Call
                if (CheckExceptionAndReConnect(xe))
                    return ExecuteNonQuery(commandType, commandText, commandParameters);

                debugFileWrite("error : " + Service.ErrFullMsg);
                debugFileWrite("end : " + DateTime.Now.ToString());

                SetErrMsg(xe);
                Service.RollbackTransaction(); //에러시 Transaction 종료

                int j = 0;
                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    if (sf.GetFileLineNumber() != 0)
                    {
                        debugFileWrite(sf.GetFileName() + " [" + sf.GetMethod().ToString() + "] " + sf.GetFileLineNumber().ToString());
                        j++;
                    }
                    if (j > callstackdeeps) break;
                }
                return false;
            }
        }
        #endregion ExecuteNonQuery

        #region ExecuteProcedure
        public static bool ExecuteProcedure(string spName, params object[] parameterValues)
        {
            try
            {
                ResetErrMsg();

                if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

                // If we receive parameter values, we need to figure out where they go
                if ((parameterValues != null) && (parameterValues.Length > 0))
                {
                    // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
                    IDbDataParameter[] commandParameters = ServiceParameterCache.GetSpParameterSet(Service.Connection, spName);

                    // Assign the provided values to these parameters based on parameter order
                    AssignParameterValues(commandParameters, parameterValues);

                    // Call the overload that takes an array of IDbDataParameters
                    return ExecuteNonQuery(CommandType.StoredProcedure, spName, commandParameters);
                }
                else
                {
                    // Otherwise we can just call the SP without params
                    return ExecuteNonQuery(CommandType.StoredProcedure, spName, null);
                }
            }
            catch (Exception xe)
            {
                SetErrMsg(xe);
                return false;
            }
        }
        /// <summary>
        /// Procedure를 call하는 Method
        /// </summary>
        /// <param name="spName"> Procedure 명 </param>
        /// <param name="inputList"> Procedure Argument중에서 IN Value를 포함하는 List </param>
        /// <returns> INOUT, OUT Value를 포함하는 ArrayList </returns>
        public static bool ExecuteProcedure(string spName, ArrayList inputList, ArrayList outputList)
        {
            bool result = true;

            try
            {
                ResetErrMsg();

                if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
                if (outputList == null) throw new ArgumentNullException("outputList");

                //OutData Clear
                outputList.Clear();

                // Procedure에 저장된 Parameter 분석
                IDbDataParameter[] commandParameters = ServiceParameterCache.GetSpParameterSet(Service.Connection, spName);

                /*IDbDataParameter중에서 Direction이 Input인 Parameter에 inputList의 Data Set
                  Checkt사항 1.Input의 갯수와 InputList의 갯수 비교
                 */
                if ((inputList != null) && (commandParameters.Length > 0))
                {
                    int index = 0;
                    foreach (IDbDataParameter op in commandParameters)
                    {
                        //Input이면 inputList에 값 설정
                        if (op.Direction == ParameterDirection.Input)
                        {
                            if (inputList.Count > index)
                            {
                                op.Value = inputList[index];
                            }
                            else  //InputList의 갯수가 모자람 에러처리
                                throw new DataException("ExecuteProcedure : InputList count is less than inputparameters");

                            index++;
                        }
                    }
                }
                // 실행결과 성공이면 INOUT, OUT 변수를 outList에 Set
                result = ExecuteNonQuery(CommandType.StoredProcedure, spName, commandParameters);
                if (result)
                {
                    //INOUT, OUT 변수를 parameterValues Set
                    foreach (IDbDataParameter op in commandParameters)
                    {
                        if ((op.Direction == ParameterDirection.InputOutput) || (op.Direction == ParameterDirection.Output))
                            outputList.Add(op.Value);
                    }
                }
            }
            catch (Exception xe)
            {
                SetErrMsg(xe);
                return false;
            }
            return result;
        }
        /// <summary>
        /// Procedure를 call하는 Method
        /// </summary>
        /// <param name="spName"> Procedure 명 </param>
        /// <param name="inputList"> Procedure Argument중에서 IN Value를 포함하는 Hashtable </param>
        /// <returns> INOUT, OUT Value를 포함하는 Hashtable </returns>
        public static bool ExecuteProcedure(string spName, Hashtable inputList, Hashtable outputList)
        {
            bool result = true;

            try
            {
                ResetErrMsg();

                if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
                if (outputList == null) throw new ArgumentNullException("outputList");

                //OutData Clear
                outputList.Clear();

                // Procedure에 저장된 Parameter 분석
                IDbDataParameter[] commandParameters = ServiceParameterCache.GetSpParameterSet(Service.Connection, spName);

                /*IDbDataParameter중에서 Direction이 Input인 Parameter에 inputList의 Data Set
                 * DataParameter의 ParameterName과 동일한 이름을 가진 InputList의 데이타를 SET 
                  Checkt사항 : ParameterName을 InputList에서 포함하고 있지 않으면 에러
                 */
                if ((inputList != null) && (commandParameters.Length > 0))
                {
                    foreach (IDbDataParameter op in commandParameters)
                    {
                        //Input이면 inputList에 값 설정
                        if (op.Direction == ParameterDirection.Input)
                        {
                            if (inputList.ContainsKey(op.ParameterName))
                                op.Value = inputList[op.ParameterName];
                            else
                                throw new DataException("ExecuteProcedure : InputList does not contain parameter, name[" + op.ParameterName + "]");
                        }
                    }
                }
                // 실행결과 성공이면 INOUT, OUT 변수를 outList에 Set
                result = ExecuteNonQuery(CommandType.StoredProcedure, spName, commandParameters);
                if (result)
                {
                    //INOUT, OUT 변수를 parameterValues Set
                    foreach (IDbDataParameter op in commandParameters)
                    {
                        if ((op.Direction == ParameterDirection.InputOutput) || (op.Direction == ParameterDirection.Output))
                            outputList.Add(op.ParameterName, op.Value);
                    }
                }
            }
            catch (Exception xe)
            {
                SetErrMsg(xe);
                return false;
            }
            return result;
        }
        #endregion

        #region ExecuteDataTable
        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataTable table = ExecuteDataTable(CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataTable ExecuteDataTable(string commandText)
        {
            // Pass through the call providing null for the set of IDbDataParameters
            return ExecuteDataTable(CommandType.Text, commandText, (IDbDataParameter[])null);
        }
        public static DataTable ExecuteDataTable(string commandText, BindVarCollection bindVarList)
        {
            IDbDataParameter[] commandParameters = ParseBindVarList(commandText, bindVarList);

            if (commandParameters.Length > 0)
                return ExecuteDataTable(CommandType.Text, commandText, commandParameters);
            else
                return ExecuteDataTable(CommandType.Text, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataTable ds = ExecuteDataTable(CommandType.StoredProcedure, "GetOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        private static DataTable ExecuteDataTable(CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            try
            {
                debugFileWrite("ExecuteDataTable start : " + DateTime.Now.ToString());

                //2010.07.24.kimminsoo
                //commandText에 끝문자가 ; 이면 해당 문자 삭제하고 처리하기. 그렇지 않으면 에러 발생함.
                //if (commandText.Length > 0 && commandText.Substring(commandText.Length - 1, 1).IndexOf(";") >= 0)
                //{
                //    if (!(commandText.IndexOf("BEGIN") >= 0 && commandText.IndexOf("END") >= 0))
                //        commandText = commandText.Substring(0, commandText.Length - 1);
                //}

                ResetErrMsg();

                // Create a command and prepare it for execution
                IDbCommand cmd = Service.currentSession.DbFactory.NewCommand();
                PrepareCommand(cmd, Service.Connection, Service.Transaction, commandType, commandText, commandParameters);

                // Create the DataAdapter & DataTable
                DbDataAdapter da = Service.currentSession.DbFactory.NewDataAdapter(cmd);

                DataTable table = new DataTable();

                // Fill the DataTable using default values for DataTable names, etc
                da.Fill(table);

                // Detach the IDbDataParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                da.Dispose();

                debugFileWrite("end : " + DateTime.Now.ToString());

                // Return the dataset
                return table;
            }
            catch (Exception xe)
            {
                //<RECONN_DB>DB연결오류로 재연결 성공시에는 자신을 한번 더 Call
                if (CheckExceptionAndReConnect(xe))
                    return ExecuteDataTable(commandType, commandText, commandParameters);

                debugFileWrite("error : " + Service.ErrFullMsg);
                debugFileWrite("end : " + DateTime.Now.ToString());

                SetErrMsg(xe);
                Service.RollbackTransaction(); //에러시 Transaction 종료

                int j = 0;
                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    if (sf.GetFileLineNumber() != 0)
                    {
                        debugFileWrite(sf.GetFileName() + " [" + sf.GetMethod().ToString() + "] " + sf.GetFileLineNumber().ToString());
                        j++;
                    }
                    if (j > callstackdeeps) break;
                }
                return null;
            }
        }
        #endregion ExecuteDataTable

        #region ExecuteDDL (DDL(Data Definition Language) SQL문 처리하기) 2007.10.01
        public static bool ExecuteDDL(string commandText)
        {
            //DDL문 (Create, drop, Alter 등 데이타 정의 SQL문)의 경우 ExecuteNonQuery를 써도 정상적으로 작동은 되나
            //성공여부를 판단하기가 ExecuteNonQuery와 다른 판단기준이 되어야 한다.
            //ExecuteNonQuery에서는 Return값을 다시 한번 판단하나, DDL문은 DDL문이 성공이면 0, 실패이면 Exception이
            //발생하므로 Return값을 판단하지 않고 처리한다.
            try
            {
                debugFileWrite("ExecuteDDL start : " + DateTime.Now.ToString());

                //2010.07.24.kimminsoo
                //commandText에 끝문자가 ; 이면 해당 문자 삭제하고 처리하기. 그렇지 않으면 에러 발생함.
                //if (commandText.Length > 0 && commandText.Substring(commandText.Length - 1, 1).IndexOf(";") >= 0)
                //{
                //    commandText = commandText.Substring(0, commandText.Length - 1);
                //}
                
                ResetErrMsg();
                // Create a command and prepare it for execution
                IDbCommand cmd = Service.currentSession.DbFactory.NewCommand();

                //2006.03.28 Transaction 객체 관리
                PrepareCommand(cmd, Service.Connection, Service.Transaction, CommandType.Text, commandText, null);

                debugFileWrite(cmd.CommandText);

                // Finally, execute the command
                cmd.ExecuteNonQuery();

                debugFileWrite("end : " + DateTime.Now.ToString());

                return true;
            }
            catch (Exception xe)
            {
                //<RECONN_DB>DB연결오류로 재연결 성공시에는 자신을 한번 더 Call
                if (CheckExceptionAndReConnect(xe))
                    return ExecuteDDL(commandText);

                debugFileWrite("error : " + Service.ErrFullMsg);
                debugFileWrite("end : " + DateTime.Now.ToString());

                SetErrMsg(xe);
                Service.RollbackTransaction(); //에러시 Transaction 종료
                return false;
            }
        }
        #endregion

        #region ExecuteReader

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  IDataReader dr = ExecuteReader(CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A IDataReader containing the resultset generated by the command</returns>
        public static IDataReader ExecuteReader(string commandText)
        {
            // Pass through the call providing null for the set of IDbDataParameters
            return ExecuteReader(CommandType.Text, commandText, (IDbDataParameter[])null);
        }

        public static IDataReader ExecuteReader(string commandText, BindVarCollection bindVarList)
        {
            IDbDataParameter[] commandParameters = ParseBindVarList(commandText, bindVarList);

            if (commandParameters.Length > 0)
                return ExecuteReader(CommandType.Text, commandText, commandParameters);
            else
                return ExecuteReader(CommandType.Text, commandText, (IDbDataParameter[])null);
        }
        /// <summary>
        /// Create and prepare a IDbCommand, and call ExecuteReader with the appropriate CommandBehavior.
        /// </summary>
        /// <remarks>
        /// If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
        /// 
        /// If the caller provided the connection, we want to leave it to them to manage.
        /// </remarks>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="connection">A valid IDbConnection, on which to execute this command</param>
        /// <param name="transaction">A valid IDbTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of IDbDataParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="connectionOwnership">Indicates whether the connection parameter was provided by the caller, or created by DbHelper</param>
        /// <returns>IDataReader containing the results of the command</returns>
        private static IDataReader ExecuteReader(CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            try
            {
                debugFileWrite("ExecuteReader start : " + DateTime.Now.ToString());

                //2010.07.24.kimminsoo
                //commandText에 끝문자가 ; 이면 해당 문자 삭제하고 처리하기. 그렇지 않으면 에러 발생함.
                //if (commandText.Length > 0 && commandText.Substring(commandText.Length - 1, 1).IndexOf(";") >= 0)
                //{
                //    commandText = commandText.Substring(0, commandText.Length - 1);
                //}

                ResetErrMsg();

                // Create a command and prepare it for execution
                IDbCommand cmd = Service.currentSession.DbFactory.NewCommand();

                PrepareCommand(cmd, Service.Connection, Service.Transaction, commandType, commandText, commandParameters);

                // Create a reader
                IDataReader dataReader;

                dataReader = cmd.ExecuteReader();

                // Detach the IDbDataParameters from the command object, so they can be used again.
                // HACK: There is a problem here, the output parameter values are fletched 
                // when the reader is closed, so if the parameters are detached from the command
                // then the SqlReader can큧 set its values. 
                // When this happen, the parameters can큧 be used again in other command.
                bool canClear = true;
                foreach (IDbDataParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }

                if (canClear)
                {
                    cmd.Parameters.Clear();
                }

                debugFileWrite("end : " + DateTime.Now.ToString());
             
                return dataReader;
            }
            catch (Exception xe)
            {
                //<RECONN_DB>DB연결오류로 재연결 성공시에는 자신을 한번 더 Call
                if (CheckExceptionAndReConnect(xe))
                    return ExecuteReader(commandType, commandText, commandParameters);

                debugFileWrite("error : " + Service.ErrFullMsg);
                debugFileWrite("end : " + DateTime.Now.ToString());

                SetErrMsg(xe);
                Service.RollbackTransaction(); //에러시 Transaction 종료
                int j = 0;
                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    if (sf.GetFileLineNumber() != 0)
                    {
                        debugFileWrite(sf.GetFileName() + " [" + sf.GetMethod().ToString() + "] " + sf.GetFileLineNumber().ToString());
                        j++;
                    }
                    if (j > callstackdeeps) break;
                }
                return null;
            }
        }

        #endregion ExecuteReader

        #region ExecuteScalar
        /// <summary>
        /// Execute a IDbCommand (that returns a 1x1 resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(string commandText)
        {
            // Pass through the call providing null for the set of IDbDataParameters
            return ExecuteScalar(CommandType.Text, commandText, (IDbDataParameter[])null);
        }

        public static object ExecuteScalar(string commandText, BindVarCollection bindVarList)
        {
            IDbDataParameter[] commandParameters = ParseBindVarList(commandText, bindVarList);

            if (commandParameters.Length > 0)
                return ExecuteScalar(CommandType.Text, commandText, commandParameters);
            else
                return ExecuteScalar(CommandType.Text, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a 1x1 resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(CommandType.StoredProcedure, "GetOrderCount", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        private static object ExecuteScalar(CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            try
            {
                debugFileWrite("ExecuteScalar start : " + DateTime.Now.ToString());

                //2010.07.24.kimminsoo
                //commandText에 끝문자가 ; 이면 해당 문자 삭제하고 처리하기. 그렇지 않으면 에러 발생함.
                //if (commandText.Length > 0 && commandText.Substring(commandText.Length - 1, 1).IndexOf(";") >= 0)
                //{
                //    commandText = commandText.Substring(0, commandText.Length - 1);
                //}

                ResetErrMsg();

                // Create a command and prepare it for execution
                IDbCommand cmd = Service.currentSession.DbFactory.NewCommand();

                PrepareCommand(cmd, Service.Connection, Service.Transaction, commandType, commandText, commandParameters);

                // Execute the command & return the results
                object retval = cmd.ExecuteScalar();

                // Detach the IDbDataParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                debugFileWrite("end : " + DateTime.Now.ToString());

                return retval;
            }
            catch (Exception xe)
            {
                //<RECONN_DB>DB연결오류로 재연결 성공시에는 자신을 한번 더 Call
                if (CheckExceptionAndReConnect(xe))
                    return ExecuteScalar(commandType, commandText, commandParameters);

                debugFileWrite("error : " + Service.ErrFullMsg);
                debugFileWrite("end : " + DateTime.Now.ToString());

                SetErrMsg(xe);
                Service.RollbackTransaction(); //에러시 Transaction  int j = 0;

                int j = 0;
                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    if (sf.GetFileLineNumber() != 0)
                    {
                        debugFileWrite(sf.GetFileName() + " [" + sf.GetMethod().ToString() + "] " + sf.GetFileLineNumber().ToString());
                        j++;
                    }
                    if (j > callstackdeeps) break ;
                }
                
                return null;
            }
           
        }
        #endregion ExecuteScalar

        #region FillDataTable (DataTable에 Data Set)
        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataTable(dbInfo, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>    
        public static bool FillDataTable(string commandText, DataTable dataTable)
        {
            return FillDataTable(CommandType.Text, commandText, dataTable, null);
        }
        public static bool FillDataTable(string commandText, DataTable dataTable, BindVarCollection bindVarList)
        {
            IDbDataParameter[] commandParameters = ParseBindVarList(commandText, bindVarList);

            if (commandParameters.Length > 0)
                return FillDataTable(CommandType.Text, commandText, dataTable, commandParameters);
            else
                return FillDataTable(CommandType.Text, commandText, dataTable, null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataTable(dbInfo, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        private static bool FillDataTable(CommandType commandType, string commandText, DataTable dataTable, params IDbDataParameter[] commandParameters)
        {
            try
            {
                debugFileWrite("FillDataTable start : " + DateTime.Now.ToString());

                //2010.07.24.kimminsoo
                //commandText에 끝문자가 ; 이면 해당 문자 삭제하고 처리하기. 그렇지 않으면 에러 발생함.
                //if (commandText.Length > 0 && commandText.Substring(commandText.Length - 1, 1).IndexOf(";") >= 0)
                //{
                //    commandText = commandText.Substring(0, commandText.Length - 1);
                //}
                
                ResetErrMsg();

                if (dataTable == null) throw new ArgumentNullException("DataTable");

                // Create a command and prepare it for execution
                IDbCommand command = Service.currentSession.DbFactory.NewCommand();
                PrepareCommand(command, Service.Connection, Service.Transaction, commandType, commandText, commandParameters);

                // Create the DataAdapter & DataSet
                DbDataAdapter dataAdapter = Service.currentSession.DbFactory.NewDataAdapter(command);

                // Fill the DataSet using default values for DataTable names, etc
                dataAdapter.Fill(dataTable);

                // Detach the IDbDataParameters from the command object, so they can be used again
                command.Parameters.Clear();

                dataAdapter.Dispose();

                debugFileWrite("end : " + DateTime.Now.ToString());

            }
            catch (Exception xe)
            {
                //<RECONN_DB>DB연결오류로 재연결 성공시에는 자신을 한번 더 Call
                if (CheckExceptionAndReConnect(xe))
                    return FillDataTable(commandType, commandText, dataTable, commandParameters);

                debugFileWrite("error : " + Service.ErrFullMsg);
                debugFileWrite("end : " + DateTime.Now.ToString());

                SetErrMsg(xe);
                Service.RollbackTransaction(); //에러시 Transaction 종료
                return false;
            }
            return true;
        }
        #endregion

        #region BeginTransaction, EndTransaction
        /// <summary>
        /// Transaction 시작
        /// </summary>
        public static void BeginTransaction()
        {
            if (Service.Connection == null) return;

            //기존 Transaction은 제거
            if (Service.Transaction != null)
                Service.Transaction.Rollback();

            Service.Transaction = Service.Connection.BeginTransaction();
        }

        //2006.08.02 마지막 상태에 따라 Commit, Rollback하는 RollbackTransaction을 없애고, CommitTransaction, RollbackTransaction으로 처리
        public static void CommitTransaction()
        {
            try
            {
                if (Service.Connection == null) return;
                if (Service.Transaction == null) return;

                Service.Transaction.Commit();

            }
            catch { }
            finally
            {
                //Reset
                Service.Transaction = null;
            }
        }

        public static void RollbackTransaction()
        {
            try
            {
                if (Service.Connection == null) return;
                if (Service.Transaction == null) return;

                Service.Transaction.Rollback();

            }
            catch { }
            finally
            {
                //Reset
                Service.Transaction = null;
            }
        }
        #endregion

        #region GetDbDataAdapter, GetDbCommandBulider
        public static DbDataAdapter GetDbDataAdapter(string commandText)
        {
            // Create a command and prepare it for execution
            IDbCommand cmd = Service.currentSession.DbFactory.NewCommand();
            PrepareCommand(cmd, Service.Connection, Service.Transaction, CommandType.Text, commandText, (IDbDataParameter[])null);
            // Create the DataAdapter & DataTable
            DbDataAdapter da = Service.currentSession.DbFactory.NewDataAdapter(cmd);
            return da;
        }
        public static Component GetDbCommandBuilder(DbDataAdapter adapter)
        {
            return Service.currentSession.DbFactory.NewDbCommandBuilder(adapter);
        }
        #endregion

        #region [getWordByByte]
        public static string getWordByByte(String src, int sPos, int byteCount)
        {
            System.Text.Encoding myEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");

            byte[] buf = myEncoding.GetBytes(src);

            while (buf.Length < byteCount)
            {
                buf = myEncoding.GetBytes(String.Format("{0}{1}", src, " "));
            }

            //Logs.ErrWriteLog("getWordByByte", String.Format("[getWordByByte]  Error\n[{0}]\n[{1}]\n[{2}]", src, buf.Length.ToString(), byteCount));

            string result = myEncoding.GetString(buf, sPos, byteCount);

            //if (byteCount != result.Length)
            //{
            //    result = myEncoding.GetString(buf, sPos, byteCount);
            //}
            return result;
        }

        public static string getWordByByte(string src, int byteCount)
        {
            System.Text.Encoding myEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");

            byte[] buf = myEncoding.GetBytes(src);

            string result = myEncoding.GetString(buf, byteCount, buf.Length - byteCount);

            return result;
        }
        #endregion

        #region [WriteLog] [debugFileWrite]

        #region [debugFileWrite] 
        public static void debugFileWrite(String aLogMsg)
        {
            bool isDebuggingMode = (GetConfigString("DEBUG", "MODE", "On").ToUpper() == "ON" ? true : false);

            if (isDebuggingMode)
            {
                Logs.WriteLog(null, null, ".txt", aLogMsg);
                //WriteLog(null, null, ".txt", aLogMsg);

                /*
                string today = DateTime.Now.ToString("yyyyMMdd");
                string path = @"c:\IHIS\debug\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + today + ".txt";
                // This text is added only once to the file.
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(debug_str);
                    }
                }
                else
                {

                    // This text is always added, making the file longer over time
                    // if it is not deleted.
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(debug_str);
                    }
                }
                */
            }
        }
        #endregion [debugFileWrite] 

        #region [debugFileWriteParam]
        private static void debugFileWriteParam(IDbDataParameter[] commandParameters)
        {
            if (commandParameters != null)
            {
                foreach (IDbDataParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }

                        debugFileWrite(p.ParameterName + ":" + p.Value.ToString());
                    }
                }
            }
        }
        #endregion [debugFileWriteParam]

        #region [ErrWriteLog]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMsg"></param>
        public static void ErrWriteLog(string aLogMsg)
        {
            Logs.WriteLog(null, null, ".err", aLogMsg);
            //WriteLog(null, null, ".err", aLogMsg);
            //WriteLog(null, null, ".log", String.Format("[ERROR]{0}", aLogMsg));
        }

        public static void ErrWriteLog(string aFileTag, string aLogMsg)
        {
            Logs.WriteLog(null, aFileTag, ".err", aLogMsg);
            //WriteLog(null, aFileTag, ".err", aLogMsg);
            //WriteLog(null, aFileTag, ".log", String.Format("[ERROR]{0}", aLogMsg));
        }
        public static void ErrWriteLog(string aPathName, string aFileTag, string aLogMsg)
        {
            Logs.WriteLog(aPathName, aFileTag, ".err", aLogMsg);
            //WriteLog(aPathName, aFileTag, ".err", aLogMsg);
            //WriteLog(aPathName, aFileTag, ".log", String.Format("[ERROR]{0}", aLogMsg));
        }
        #endregion

        #region [StartWriteLog] public
        /// <summary>
        /// 2016.01.27 AnhNV added
        /// </summary>
        public static void StartWriteLog()
        {
            Logs.WriteLog(null, null, ".log", "==============================================================================");
            //WriteLog(null, null, ".log", "==============================================================================");
        }
        #endregion

        #region [EndWriteLog] public
        /// <summary>
        /// 2016.01.27 AnhNV added
        /// </summary>
        public static void EndWriteLog()
        {
            Logs.WriteLog(null, null, ".log", "==============================================================================");
            //WriteLog(null, null, ".log", "==============================================================================");
        }
        #endregion

        #region [WriteLog] public
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMsg"></param>
        public static void WriteLog(string aLogMsg)
        {
            Logs.WriteLog(null, null, ".log", aLogMsg);
            //WriteLog(null, null, ".log", aLogMsg);
        }
        /*
        public static void WriteLog(string logMsg)
        {
            try
            {
                //2007.08.20 LOG는 일자별로 관리
                string fileName = Application.StartupPath + "\\IHISLOG" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                string str = "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "]";
                str += logMsg;
                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true);
                file.WriteLine(str);
                file.Close();
            }
            catch { }
        }
        */

        public static void WriteLog(string aFileTag, string aLogMsg)
        {
            Logs.WriteLog(null, aFileTag, ".log", aLogMsg);
            //WriteLog(null, aFileTag, ".log", aLogMsg);
        }
        public static void WriteLog(string aPathName, string aFileTag, string aLogMsg)
        {
            Logs.WriteLog(aPathName, aFileTag, ".log", aLogMsg);
            //WriteLog(aPathName, aFileTag, ".log", aLogMsg);
        }
        #endregion [WriteLog] public

        #region [WriteLog] private
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPath"></param>
        /// <param name="aLogFileTag"></param>
        /// <param name="aFileExt"></param>
        /// <param name="aLogMsg"></param>
        //private static void WriteLog(string aPath, string aFileTag, string aFileExt, string aLogMsg)
        //{
        //    Object lockObject = new Object();
        //    String logIndex = "";

        //    try
        //    {
        //        string today = DateTime.Now.ToString("yyyyMMdd");
        //        //string today = DateTime.Now.ToString("yyyyMMdd-HH");

        //        string pathName = "";
        //        string fileName = "";

        //        if (aPath == null)
        //        {
        //            //pathName = AppDomain.CurrentDomain.BaseDirectory;
        //            pathName = Application.StartupPath + "\\" + "debug";
        //        }
        //        else
        //        {
        //            pathName = aPath;
        //        }

        //        if (aFileTag == null)
        //        {
        //            fileName = pathName + "\\" + today + "-" + "IHIS" + aFileExt;
        //            //fileName = pathName + "\\" + today + "-" + "KCCK" + aFileExt;
        //        }
        //        else
        //        {
        //            fileName = pathName + "\\" + today + "-" + aFileTag + aFileExt;
        //        }

        //        if (!Directory.Exists(pathName))
        //        {
        //            Directory.CreateDirectory(pathName);
        //        }

        //        // This text is added only once to the file.
        //        lock (lockObject)
        //        {
        //            if (aFileTag == null || aFileTag.Length == 0) aFileTag = "NULL";
        //            logIndex = aFileTag + aFileExt;

        //            if (strLogMsg.ContainsKey(logIndex))
        //            {
        //                if (strLogMsg[logIndex].Length == 0)
        //                {
        //                    strLogMsg[logIndex] = String.Format("[{0}]: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), aLogMsg);
        //                }
        //                else
        //                {
        //                    strLogMsg[logIndex] = String.Format("{0}\n[{1}]: {2}", strLogMsg[logIndex], DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss:fff"), aLogMsg);
        //                }
        //            }
        //            else
        //            {
        //                strLogMsg.Add(logIndex, String.Format("[{0}]: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), aLogMsg));
        //            }

        //            String str = strLogMsg[logIndex];
        //            // Write the string to a file.
        //            //System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true);

        //            if (!File.Exists(fileName))
        //            {
        //                // Create a file to write to.
        //                //using (StreamWriter sw = File.CreateText(fileName))
        //                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.GetEncoding("shift_jis")))
        //                {
        //                    try
        //                    {
        //                        sw.WriteLine(str);
        //                        strLogMsg[logIndex] = "";
        //                        //sw.Close();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        throw new Exception(string.Format("StackTrace: {0} \n Message {1}", ex.StackTrace, ex.Message));
        //                    }
        //                    finally
        //                    {
        //                        sw.Flush();
        //                        sw.Close();
        //                        sw.Dispose();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                //FileInfo fInfo = new FileInfo(fileName);

        //                // This text is always added, making the file longer over time
        //                // if it is not deleted.
        //                //using (StreamWriter sw = File.AppendText(fileName))
        //                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.GetEncoding("shift_jis")))
        //                {
        //                    try
        //                    {
        //                        sw.WriteLine(str);
        //                        //sw.WriteLine(String.Format("[{0}]{1}", fInfo.Length, str));
        //                        strLogMsg[logIndex] = "";
        //                        //sw.Close();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        throw new Exception(string.Format("StackTrace: {0} \n Message {1}", ex.StackTrace, ex.Message));
        //                    }
        //                    finally
        //                    {
        //                        sw.Flush();
        //                        sw.Close();
        //                        sw.Dispose();
        //                    }
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception xe)
        //    {
        //        string errStr = String.Format("[{0}]:{1}\n[errorMessage={2}]\n[StackTrace={3}]", DateTime.Now.ToString("yyyy-MM-dd=HH:mm:ss:fff"), aLogMsg, xe.Message, xe.StackTrace);

        //        strLogMsg[logIndex] = String.Format("\n{0}\n[{1}]\n", strLogMsg[logIndex], errStr);
        //        //WriteLog(aPath, aFileTag, String.Format("{0}err", aFileExt), errStr);
        //    }
        //}
        #endregion [WriteLog] private

        #endregion [WriteLog] [debugFileWrite]
    }

    #region ServiceParameterCache
    internal class ServiceParameterCache
    {
        #region private methods, variables, and constructors

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Stored Procedure에 의 Arguement를 분석한다.
        /// </summary>
        /// <param name="connection"> Oracle Connection </param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">Whether or not to include their return value parameter</param>
        /// <returns>The parameter array discovered.</returns>
        private static IDbDataParameter[] DiscoverSpParameterSet(IDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            /*2006.08.10 Transaction이 할당되었을때 SqlServer, Oracle의 차이가 발생
             * Oracle에서는 connection에 Transaction이 연결된 경우 DeriveParameters() call시에 command에 Transaction만 할당하면 정상작동함.
             * 그런데, SqlServer에서는 connection에 Tran이 연결된 경우 command에 Transaction을 할당을 해도 SqlCommandBuilder.DeriveParameters(..) 시에
             * 명령에 할당된 연결이 보류 중인 로컬 트랜잭션에 연결되어 있는 경우 Execute를 사용하려면 트랜잭션 개체가 필요합니다. 
             * 명령의 Transaction 속성이 초기화되지 않았습니다 
             * 이 에러 메세지는 Command에 Tran이 연결되지 않았다는 것인데, Tran을 연결한 상태에서도 이 에러가 발생함.
             * 그래서, 원 소스인 SQLHelper에서도 GetSpParameterSet(..)에서 Connection을 Clone하여 Clone한 Connection을 넘기고,
             * 이 Method에서 DeriveParameters()호출전에 connection.Open -> 호출 -> Close하는 Logic으로 구현됨.
             * 정확한 원인은 확인해 봐야 하나, SqlServer에서 Tran이 처리되는 규칙이 다르기 때문에 그런것으로 보인다.
             * 일단 이 에러를 방지하기위해 SqlServer인 경우 Tran이 있으면 Connection을 Clone하고 처리하도록함.
             */

            IDbCommand cmd = null;
            IDbConnection cloneConnection = null;
            if (Service.Transaction == null) //Tran이 없는 경우은 기본 Connection 사용 Command 생성
                cmd = Service.CurrentSession.DbFactory.NewCommand(spName, connection);
            else if (Service.CurrentDBKind == DataBaseKind.SqlServer) //Tran이 있는 경우 SqlServer이면 Connection Clone
            {
                cloneConnection = (IDbConnection)((ICloneable)connection).Clone();
                cmd = Service.CurrentSession.DbFactory.NewCommand(spName, cloneConnection);
            }
            else //Tran이 있고 SqlServer가 아닌 경우 기본 Connection 사용
                cmd = Service.CurrentSession.DbFactory.NewCommand(spName, connection);

            //Command 에 Transaction 할당
            cmd.CommandType = CommandType.StoredProcedure;

            //2006.03.30 Transaction을 시작하였으면 Command에 Transaction 객체를 할당하여 Call해야 에러가 발생하지 않음
            // 그렇지 않으면 Execute requires the Command object to have a Transaction object when the Connection object assigned to the Command is in a pending local transaction.  The Transaction property of the Command has not been initialized. 
            // 위와 같이 Command에 Transation이 할당되지 않았음을 나타내는 에러가 발생함
            cmd.Transaction = Service.Transaction;  //Transaction 할당

            //Clone Connection Open
            if (cloneConnection != null)
                cloneConnection.Open();
            //IDbCommand에 지정된 저장 프로시저의 매개 변수 정보를 검색하여 지정된 IDbCommand 개체의 Parameters 컬렉션을 채웁니다
            Service.CurrentSession.DbFactory.DeriveParameters(cmd);
            //Clone Connection Close
            if (cloneConnection != null)
            {
                cloneConnection.Close();
                cloneConnection.Dispose();
            }

            //이 부분은 확인하여 Parameters에 무엇이 오는지 확인해 보고 처리하자.
            /*2006.03.23 SQL Server는 Function이 따로 없어서 Procedure에서 Return value를 가진다.
             * 그래서 DeriveParameters(..) 호출시에 Return Value가 맨 앞에 오므로 포함여부에 따라 첫번째 Return Value를 제거한다.
             * 그러나, Oracle에서는 Function은 SQL로 호출하고, Procedure는 Return value가 없으므로 이 과정이 필요가 없다.
             * 따라서, 포함여부 Argument가 필요가 없어진다. 일단은 통일하기 위해 호출하는 측에서 모두 True로 넘긴다.
             */
            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            IDbDataParameter[] discoveredParameters = new IDbDataParameter[cmd.Parameters.Count];

            cmd.Parameters.CopyTo(discoveredParameters, 0);

            // Init the parameters with a DBNull value
            // Parameter의 기본 Type만 분석하고 Value는 Init
            foreach (IDbDataParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }
            return discoveredParameters;
        }

        /// <summary>
        /// Deep copy of cached IDbDataParameter array
        /// </summary>
        /// <param name="originalParameters"></param>
        /// <returns></returns>
        private static IDbDataParameter[] CloneParameters(IDbDataParameter[] originalParameters)
        {
            IDbDataParameter[] clonedParameters = new IDbDataParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (IDbDataParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion private methods, variables, and constructors

        #region caching functions

        /// <summary>
        /// 분석한 Parameter를 Cashe에 보관처리함.(같은 Procedure 분석시 다시 분석하지 않고 재사용)
        /// Key 값을 commandText로 관리하므로 Select문을 적용시에는 Bind변수를 사용하고 Parameter로 Bind변수를 넘겨야
        /// Cache에서 SQL이 적게 관리되고 Parsing도 빠르다. Bind변수를 사용하지 않으면 같은 SQL이 조건값이 달라지므로
        /// 여러개의 Cache가 관리되고 속도도 빠르지 않다. 반드시 조건이 변경되는 경우는 Bind변수 사용
        /// </summary>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters to be cached</param>
        public static void CacheParameterSet(string connectionString, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");
            //Hashtable의 Key는 Unique를 보장하기 위해 아래와 같이 지정함
            string hashKey = connectionString + ":" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An array of SqlParamters</returns>
        public static IDbDataParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            IDbDataParameter[] cachedParameters = paramCache[hashKey] as IDbDataParameter[];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions

        #region Parameter Discovery Functions
        /// <summary>
        /// Retrieves the set of IDbDataParameter appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid IDbConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of IDbDataParameter</returns>
        public static IDbDataParameter[] GetSpParameterSet(IDbConnection connection, string spName)
        {
            //2006.07.12 Oracle은 Procedure에 Return Value가 없으므로 includeReturnValueParameter = true
            //SqlServer은 Procedure 분석시에 Return Value가 포함되어 나오므로 includeReturnValueParameter = false
            //<미확정> SqlServer에서 Procedure의 Return Value를 사용하고자 할 경우에는 또 문제가 있음. 
            //추후 다른 부분과 같이 명확히 반영하도록 해야함.
            bool includeReturnValueParameter = true;
            if (Service.CurrentDBKind == DataBaseKind.SqlServer)
                includeReturnValueParameter = false;
            return GetSpParameterSet(connection, spName, includeReturnValueParameter);
        }

        /// <summary>
        /// Retrieves the set of IDbDataParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="connection">A valid IDbConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of IDbDataParameters</returns>
        public static IDbDataParameter[] GetSpParameterSet(IDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
        }

        /// <summary>
        /// Retrieves the set of IDbDataParameters appropriate for the stored procedure
        /// </summary>
        /// <param name="dbInfo">A valid DbInfo</param>
        /// <param name="connection">A valid IDbConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of IDbDataParameters</returns>
        private static IDbDataParameter[] GetSpParameterSetInternal(IDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");

            IDbDataParameter[] cachedParameters;

            cachedParameters = paramCache[hashKey] as IDbDataParameter[];
            if (cachedParameters == null)
            {
                IDbDataParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                paramCache[hashKey] = spParameters;
                cachedParameters = spParameters;
            }

            return CloneParameters(cachedParameters);
        }

        #endregion Parameter Discovery Functions

    }
    #endregion
}
