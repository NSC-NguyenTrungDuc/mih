using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using IHIS.CloudConnector.Socket;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector;

namespace IHIS.Framework
{
    /// <summary>
    /// MainEntry에 대한 요약 설명입니다.
    /// </summary>
    public class MainEntry
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {          
            if (args.Length == 45) // 2015.12.12 updated: included Orca and Misa server info
            {
                string groupID = "";
                string groupName = "";
                string systemID = "";
                string systemName = "";
                string userID = "";
                string userPswd = "";
                string sessionId = "";

                try
                {
                    groupID = args[0];
                    groupName = args[1];
                    systemID = args[2];
                    systemName = args[3];
                    userID = args[4].Trim();
                    userPswd = args[5].Trim();
                    UserInfo.HospCode = args[6];
                    UserInfo.UserGroup = args[7];
                    sessionId = args[8];
                    UserInfo.DoctorDrugCheck = args[9].Equals("True");
                    UserInfo.CheckDosage = args[10].Equals("True");
                    UserInfo.CheckInteraction = args[11].Equals("True");
                    UserInfo.CheckKinki = args[12].Equals("True");
                    NetInfo.Language = (LangMode)Int32.Parse(args[13]);
                    // 2015.12.04 AnhNV updated: Orca and Misa server info
                    UserInfo.OrcaIp = args[14].Trim();
                    UserInfo.OrcaUser = args[15].Trim();
                    UserInfo.OrcaPassword = args[16].Trim();
                    UserInfo.OrcaPort = args[17].Trim();
                    UserInfo.OrcaHospCode = args[18].Trim();
                    UserInfo.OrcaPortRcvClaim = args[19].Trim();
                    UserInfo.MisaIp = args[20].Trim();
                    UserInfo.MisaUser = args[21].Trim();
                    UserInfo.MisaPwd = args[22].Trim();
                    UserInfo.MisaDbInsurName = args[23].Trim();
                    UserInfo.MisaInstanceName = args[24].Trim();
                    UserInfo.MisaDbNonInsurName = args[25].Trim();
                    UserInfo.ChangePwdFlg = args[26].Trim();
                    UserInfo.FirstLoginFlg = args[27].Trim();
                    UserInfo.LastPwdChange = args[28].Trim();
                    UserInfo.PwdHistory = args[29].Trim();
                    UserInfo.CurrentTime = args[30].Trim();
                    // MED-10181
                    UserInfo.VpnYn = args[31].Equals("True");
                    UserInfo.InvUsage = args[32].Equals("True");
                    UserInfo.UsePHR = args[33].Trim();
                    UserInfo.TimeZone = args[34].Trim();
                    // https://sofiamedix.atlassian.net/browse/MED-9831
                    UserInfo.UserName = args[35].Trim();
                    // https://sofiamedix.atlassian.net/browse/MED-15740
                    UserInfo.CplSpecimenAuto = args[36].Trim();
                    UserInfo.CplDevBlood = args[37].Trim();
                    UserInfo.CplDevUrine = args[38].Trim();
                    UserInfo.CplDevBio = args[39].Trim();
                    UserInfo.CplServer = args[40].Trim();
                    UserInfo.CplPort = args[41].Trim();
                    UserInfo.CplDatabase = args[42].Trim();
                    UserInfo.CplUserId = args[43].Trim();
                    UserInfo.CplPassword = args[44].Trim();

                    switch (NetInfo.Language)
                    {
                        case LangMode.Jr:
                            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP", true);
                            Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP", true);
                            break;
                        case LangMode.En:
                            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en", true);
                            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", true);
                            break;
                        case LangMode.Vi:
                            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN", true);
                            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN", true);
                            break;
                    }
                    if (!string.IsNullOrEmpty(sessionId))
                    {
                        WebSocketClient.SessionId = sessionId;
                    }

                    UserInfo.UserID = userID;
                    UserInfo.UserPswd = userPswd;

                    CloudService.Instance.Connect();
                }
                catch
                {
                    return;
                }

                /*<SESSION> 2006.11.08 업무시스템 exe가 각각 다른 AppDomain에서 구동이 되므로 AppDomain간
                 * DB Connection을 공유하지 못함. 이렇게 되면 여러개의 Connection을 사용해야 하는 부담이 있는데,
                 * 이를 어떻게 처리할지 추후 정리하고 ,일단 여러개의 Connection사용
                 * 업무시스템이 기동중이 상황에서 IHIS 종료시 다른 Session이 종료되는지 확인해 봐야 한다.
                 * Main Process가 Close 되면 다른 Session도 같이 종료됨
                 */

                // Cloud service
                /*if (!Service.Connect())
                {
                    string msg = XMsg.GetMsg("M008"); //DB와 연결할 수 없어, 프로그램을 실행할 수 없습니다.
                    XMessageBox.Show(msg, XMsg.GetMsg("M004"));  //M004.업무시스템 실행에러
                    return;
                }*/


                //2005.11.23 사용자 ID가 없으면 ShowLoginForm, 있으면 비밀번호 Check없이 CheckUser
                if (/*userID == ""*/systemID == "OCSO")
                {
                    if (!ShowLoginForm(systemID, systemName))
                    {
                        //Thread반드시 종료, 명시적으로 종료하지 않으면 return을 하더라도
                        //Starter의 OpenSystem에서 Thread구동된 것이 종료가 되지 않는 경우도 발생함.
                        //따라서, 반드시 명시적으로 Thread종료후 Return 필요함
                        Application.ExitThread();
                        return;
                    }
                }
                else if (systemID != "ADMA" && systemID != "ADMM" && systemID != "ADMS")
                {
                    if (!CheckUser(systemID, userID))
                    {
                        //Thread반드시 종료, 명시적으로 종료하지 않으면 return을 하더라도
                        //Starter의 OpenSystem에서 Thread구동된 것이 종료가 되지 않는 경우도 발생함.
                        //따라서, 반드시 명시적으로 Thread종료후 Return 필요함
                        Application.ExitThread();
                        return;
                    }
                }

                // 시스템 예외 처리 핸들러 생성
                SystemExceptionHandler sh = new SystemExceptionHandler();

                try
                {
                    // Thread Exception 발생시 시스템 예외 처리 Event 구동
                    //Application.ApplicationExit += new EventHandler(OnApplicationExit);
                    Application.ThreadException += new ThreadExceptionEventHandler(sh.OnThreadException);
                    Application.Run(new MdiForm(groupID, groupName, systemID, systemName));
                    //종료시 DisConnect
                    Service.DisConnect();
                }
                catch (Exception xe)
                {
                    //string msg = XMsg.GetMsg("M003") + "\n" + XMsg.GetMsg("M007", xe);  // "업무시스템에서 비정상적인 에러가 발생했습니다.\n" + "에러[" + xe.Message + "]"
                    //string title = XMsg.GetMsg("M004"); // 업무시스템 실행에러
                    //MessageBox.Show(msg, title);
                    Logs.WriteLog("CommonMdiForm::Main systemID=" + systemID + ",sysName=" + systemName + ",Error=" + xe.Message);
                    Logs.WriteLog("CommonMdiForm::Main StackTrace=" + xe.StackTrace);
                }
            }
            else
            {
                string msg = XMsg.GetMsg("M005"); // 해당 업무시스템은 단독으로 실행할 수 없습니다.
                string title = XMsg.GetMsg("M004"); // 업무시스템 실행에러
                MessageBox.Show(msg, title);
            }
        }
        private static bool ShowLoginForm(string systemID, string systemName)
        {
            ArrayList gwaInfoList = new ArrayList();
            bool rel = false;
            string errMsg = "";
            if (!UserInfoUtil.GetDocotorGwaList(UserInfo.UserID, gwaInfoList, out errMsg))
            {
                XMessageBox.Show(errMsg);
                return false;
            }
            DoctorGwaInfo doctorGwaInfo = gwaInfoList[0] as DoctorGwaInfo;
            if (doctorGwaInfo != null)
            {
                string userID = doctorGwaInfo.DoctorID;
                string gwa = userID.Substring(0, 2);
                string gwaName = "";
                CheckUserDoctorLoginArgs userDoctorLoginArgs = new CheckUserDoctorLoginArgs();
                userDoctorLoginArgs.Gwa = gwa;
                userDoctorLoginArgs.UserInfo = new UserRequestInfo();
                userDoctorLoginArgs.UserInfo.SysId = systemID.Trim();
                //userDoctorLoginArgs.UserInfo.UserId = txtUserID.Text.Trim();
                userDoctorLoginArgs.UserInfo.UserId = UserInfo.UserID;
                //userDoctorLoginArgs.UserInfo.UserScrt = txtPswd.Text;
                userDoctorLoginArgs.UserInfo.UserScrt = UserInfo.UserPswd;
                userDoctorLoginArgs.UserInfo.ScrtCheckYn = "Y";
                userDoctorLoginArgs.UserInfo.IpAddr = Service.ClientIP;
                CheckUserDoctorLoginResult userDoctorLoginResult =
                    CloudService.Instance.Submit<CheckUserDoctorLoginResult, CheckUserDoctorLoginArgs>(
                        userDoctorLoginArgs);
                if (!TypeCheck.IsNull(userDoctorLoginResult.GwaName))
                {
                    gwaName = userDoctorLoginResult.GwaName;
                }
                //if (!UserInfoUtil.CheckUserDoctor(this.txtUserID.Text, this.txtPswd.Text, gwa, gwaName, userDoctorLoginResult, out errMsg))
                if (!UserInfoUtil.CheckUserDoctor(UserInfo.UserID, UserInfo.UserPswd, gwa, gwaName, userDoctorLoginResult, out errMsg))
                {
                    //lbMsg.Text = errMsg;
                    //this.txtUserID.Focus();
                    return rel;
                }
                //UserInfoUtil.RegisterSystemUser(this.systemID, UserInfo.UserID);
            }
            else
            {
                return rel;
            }
            return true;
        }
        private static bool CheckUser(string systemID, string userID)
        {
            bool ret = false;
            string errMsg;

            //string errMsg = "";
            //bool ret = UserInfoUtil.CheckUser(systemID, userID, out errMsg);
            //if (!ret) //실패시 ErrMsg
            //    XMessageBox.Show(errMsg, XMsg.GetMsg("M006")); //사용자로그인 
            //return ret;

            // Cloud service
            CheckUserLoginArgs userLoginArgs = new CheckUserLoginArgs();
            userLoginArgs.UserId = UserInfo.UserID;
            userLoginArgs.SystemId = systemID;
            userLoginArgs.UserInfo = new UserRequestInfo();
            userLoginArgs.UserInfo.SysId = systemID.Trim();
            userLoginArgs.UserInfo.UserId = UserInfo.UserID;
            userLoginArgs.UserInfo.UserScrt = UserInfo.UserPswd;
            userLoginArgs.UserInfo.ScrtCheckYn = "Y";
            userLoginArgs.UserInfo.IpAddr = Service.ClientIP;
            CheckUserLoginResult userLoginResult =
                CloudService.Instance.Submit<CheckUserLoginResult, CheckUserLoginArgs>(userLoginArgs);

            if (userLoginResult.SubPartDoctor != "NULL")
            {
                ret = UserInfoUtil.CheckUser(userLoginResult.SubPartDoctor, UserInfo.UserPswd, userLoginResult, out errMsg);
            }
            else
            {
                ret = UserInfoUtil.CheckUser(UserInfo.UserID, UserInfo.UserPswd, userLoginResult, out errMsg);
            }

            if (!ret)
            {
                XMessageBox.Show(errMsg, XMsg.GetMsg("M006")); //사용자로그인 
            }

            return ret;

            //string errMsg = "";
            //bool ret = UserInfoUtil.CheckUser(systemID, userID, out errMsg);
            //if (!ret) //실패시 ErrMsg
            //    XMessageBox.Show(errMsg, XMsg.GetMsg("M006")); //사용자로그인 
            //return ret;
            //return true;
        }

        private static void OnApplicationExit(object sender, System.EventArgs e)
        {
            Logs.WriteLog("IHIS.Commmon OnApplicationExit");
            // DB Disconnect
            Service.DisConnect();
        }
    }
}
