using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using IHIS.CloudConnector;
using IHIS.Framework;
using Microsoft.Win32;
using IHIS.CloudConnector.Caching;
using System.Deployment.Application;
using System.IO.IsolatedStorage;
using System.Configuration;
using System.Collections;

namespace IHIS
{
    /// <summary>
    /// Main Entry
    /// </summary>
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Assert, Unrestricted = true)]
    internal class MainEntry
    {

        const string PROC_NAME = "KCCK";
        const int MSG_IHIS_INSTANCE_FOCUS = (int)(Msgs.WM_USER + 101);
        const long TIME_INTERVAL = 150000000; //Ticks기준 15sec(15초*1천만)
        public MainEntry()
        {
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected void Dispose(bool disposing)
        {
        }
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                /*<.NET 2005>
                 * NET Framework에서는 사용자가 스레드로부터 안전하지 않은 방식으로 컨트롤에 액세스할 경우 이를 감지할 수 있습니다. 디버거에서 응용 프로그램을 실행할 때 컨트롤을 만든 스레드가 아닌 스레드에서 해당 컨트롤을 호출하려고 하면 "컨트롤 이름 컨트롤이 자신이 만들어진 스레드가 아닌 스레드에서 액세스되었습니다."라는 메시지와 함께 InvalidOperationException이 발생합니다. 
                 * 이 예외는 일부 환경에서 런타임에 디버깅하는 동안 안정적으로 발생합니다. 이 예외는 .NET Framework 버전 2.0 이전의 .NET Framework에서 작성한 응용 프로그램을 디버깅할 때 발생할 수 있습니다. 
                 * 이 문제가 발견되면 해결하는 것이 좋지만 CheckForIllegalCrossThreadCalls 속성을 false로 설정하여 해당 기능을 비활성화할 수 있습니다. 그러면 컨트롤이 Visual Studio .NET 2003 및 .NET Framework 1.1에서와 같은 방식으로 실행됩니다. 
                 */
                Control.CheckForIllegalCrossThreadCalls = false;

                // https://sofiamedix.atlassian.net/browse/MED-10662
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

                //시작창 Show (4sec후 자동 닫힘)
                //StartingForm dlg = new StartingForm(4);
                //dlg.Show();
                CheckForShortcut();
                //CacheService.Instance.ToString();

                //2005.06.23 IHIS 기동여부 Check 로직 변경, 사용자가 연속으로 두번 실행하는 경우
                //WindowHandle이 없는 상황에서 Check하게 되므로 IHIS가 두번 뜨는 문제가 발생함.
                //Process.GetProcessesByName("IHIS")로 Check하는 Logic이 시간을 좀 더 걸릴 수 있으나 확실한 방법이므로
                //Process로 Check하도록 변경함
                Process[] processes = Process.GetProcessesByName(PROC_NAME);
                //Process[] processes = Process.GetProcessesByName("KCCK");
                if (processes.Length > 1)
                {
                    //IHIS Window Handle Find, 있으면 FormMain Handle에 Msg를 줌, 없으면 실행
                    IntPtr winHandle = FindMainWindowHandle();
                    if (winHandle != IntPtr.Zero)
                    {
                        //IHIS.exe Icon 실행시
                        if (args.Length == 0)
                        {
                            User32.PostMessage(winHandle, MSG_IHIS_INSTANCE_FOCUS, 0, 0);
                        }
                        else if (args.Length == 1) // 업무시스템 Icon 실행시
                        {
                            //Shared Memory에 Memory할당하여 시스템 ID 관리
                            //다른 Process에 Msg를 전달하므로 COPYDATASTRUCT에 데이타를 담아 WM_COPYDATA Msg로 SEND
                            //받는 쪽에서는 PtrToStructure, PtrToStringAuto로 데이타를 받음
                            //
                            string sendData = args[0];
                            COPYDATASTRUCT cds = new COPYDATASTRUCT();
                            //UNICODE 기준 (TEXT.Lengh + 1(Null)) * 2
                            cds.cbData = (sendData.Length + 1) * 2;
                            //Auto (Win2000이상은 UNICODE, Win98 :Ansi로 Marshaling)
                            cds.lpData = Marshal.StringToHGlobalAuto(sendData);
                            //의미없음 (int형의 데이타를 전송시에 dwData에 설정하여 보냄)
                            cds.dwData = 0;
                            // cds Data Size Memory Alloc (int형(4byte) * 3)
                            IntPtr lParam = Marshal.AllocHGlobal(12);

                            // cds를 IntPtr로 Convert
                            Marshal.StructureToPtr(cds, lParam, false);

                            //CopyData Send
                            User32.SendMessage(winHandle, (int)Msgs.WM_COPYDATA, IntPtr.Zero, lParam);

                            //Memory Free
                            Marshal.FreeCoTaskMem(cds.lpData);
                            Marshal.FreeHGlobal(lParam);
                        }
                        return;
                    }
                    else //IHIS를 연속으로 Click하여 아직 첫번째 Process의 WindowHandle이 만들어 지기 전이면 현재 Process Close
                    {
                        //IHIS 프로세스가 2개이상이면 다시 Check
                        //연속 Click시에 첫번째,두번째 모두 processes.Length > 1인 상태이므로 두번째를 종료했으면
                        //첫번째는 실행할 수 있도록 다시 한번 IHIS 프로세스 Check하여 2개이상이면 현재 PROCESS Kill
                        //2006.04.12 연속 DoubleClick 이외에 ifc.exe가 제대로 Process에서 정리가 안되서 남아 있는 경우
                        //좀비Process때문에 현재 Process를 죽이면 좀비는 죽지않고, 현재가 죽어 문제가 된다.
                        //따라서, process의 StartTime을 판단하여 일정시간(최초 기동시 속도 고려 15sec)이전의 프로세스는 좀비로 판단하여
                        //좀비를 제거하고 아니면 현재프로세스를 제거한다.
                        bool isJombyKilled = false;
                        foreach (Process proc in processes)
                        {
                            if (DateTime.Now.Ticks - proc.StartTime.Ticks > TIME_INTERVAL)
                            {
                                isJombyKilled = true;
                                proc.Kill();
                            }
                        }
                        //좀비가 아니면 현재 Kill
                        if (!isJombyKilled)
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logs.WriteLog("Main", "MainEntry 중복 실행 방지 오류 : " + e.Message);
                Debug.WriteLine("중복 실행 방지 오류 : " + e.Message);
            }

            //최초 기동후 어셈블리 변경에 의해 IHISLaucher에서 재기동시 Check
            bool rerun = false;
            string[] runArgs;


            //IHISLauncher에 의해 재기동시 (특정 그룹ID,시스템ID,시스템명이 없는경우)
            if ((args.Length == 1) && (args[0].Equals("RERUN")))
            {
                rerun = true;
                runArgs = new string[0];
            }
            //IHISLauncher에 의해 재기동시 (시스템ID가 있는경우)
            else if ((args.Length == 2) && (args[0].Equals("RERUN")))
            {
                rerun = true;
                runArgs = new string[1];
                runArgs[0] = args[1];
            }
            // 바탕화면에서 해당시스템 바로가기를 Click시
            else if (args.Length == 1)
            {
                runArgs = new string[1];
                runArgs[0] = args[0];
            }
            else  //IHIS.exe 기동시
            {
                runArgs = new string[0];
            }

            //DB Connect
            //			if (!Service.Connect()) 
            //                return;

            //1.VersionManger 기동(Rerun시는 다시 IHISLauncher 기동하지 않음)
            if (!rerun)
            {
                string errMsg = "", title = "";
                title = XMsg.GetMsg("M007"); // 파일수신에러
                VersionResult result = VersionResult.Success;
                try
                {
                    //result = DownloadCommFiles();
                }
                catch (Exception xe)
                {
                    errMsg = XMsg.GetMsg("M008") + "\n"  //파일을 다운로드하는데 실패하였습니다.
                            + XMsg.GetMsg("M009") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
                            + XMsg.GetMsg("M010") + "\n"  //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
                            + "Error[" + xe.Message + "]";
                    XMessageBox.Show(errMsg, title);
                    Logs.WriteLog("Main", xe.StackTrace);
                    return;
                }
                if (result == VersionResult.CopyError) //재기동 필요시
                {
                    //Library Update에 따른 Rerun 필요시 종료후 다시실행
                    // Launcher 기동
                    // Argument : 원본Path + 대상Path + Product명 + 실행File명 + 기타 Args
                    string launcherPgm = "IHISLauncher";
                    string pArgs = "";
                    pArgs = "\"" + VersionManager.DownPath + "\" \"" + VersionManager.BinPath + "\" \"" +
                        PROC_NAME + "\" \"" + Application.ExecutablePath + "\"";
                    //바탕화면에서 
                    if (args.Length == 1)
                        pArgs += " \"" + args[0] + "\"";

                    Process.Start(Application.StartupPath + "\\" + launcherPgm, pArgs);
                    return;
                }
                else if (result == VersionResult.DownError)
                {
                    // 파일 Copy실패시 어떻게 처리할 것인가 결정필요함(일단 실행불가)
                    errMsg = XMsg.GetMsg("M008") + "\n"  //파일을 다운로드하는데 실패하였습니다.
                        + XMsg.GetMsg("M009") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
                        + XMsg.GetMsg("M010");      //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.

                    XMessageBox.Show(errMsg, title);
                    return;
                }
                else if (result == VersionResult.DeleteFail)
                {
                    // 파일 Copy실패시 어떻게 처리할 것인가 결정필요함(일단 실행불가)
                    errMsg = XMsg.GetMsg("M011") + "\n"  //다운로드 디렉토리에 있는 파일을 삭제하지 못했습니다.
                        + XMsg.GetMsg("M009") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
                        + XMsg.GetMsg("M010");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
                    XMessageBox.Show(errMsg, title);
                    return;
                }
            }

            try
            {
                //FormMain 기동
                // args SET , IHIS.exe 기동시는 args없음, 각 업무시스템 Icon 기동시는 시스템ID  전달
                //XPStyle로 적용 (XP Style로 적용하지 않음)
                //시마다병원은 2000이 많으므로 XP 적용이 안됨, 따라서,기본컨트롤의 모양을 수정함.
                //				Application.EnableVisualStyles();
                //				Application.DoEvents();

                //Application.Run(new MainForm(runArgs));
                ////종료시 DisConnect
                //Service.DisConnect();

                #region 2015.12.18 Deleted

                //// 2015.12.16 https://nextop-asia.atlassian.net/browse/MED-6224
                //CloudService.Instance.Connect();

                //string hospCode = CacheService.Instance.Get("CACHE_HOSP_CODE", "").ToString();
                //string hospName = "";

                //if (hospCode == "")
                //{
                //    FormSelectHospCode formHsp = new FormSelectHospCode();
                //    formHsp.StartPosition = FormStartPosition.CenterScreen;
                //    formHsp.ShowDialog();

                //    if (formHsp.DialogResult == DialogResult.OK)
                //    {
                //        hospCode = CacheService.Instance.Get("CACHE_HOSP_CODE", "").ToString();
                //        hospName = formHsp.HospName;

                //        LoginForm frm = new LoginForm(hospCode, hospName);
                //        frm.ShowDialog();
                //        if (frm.DialogResult == DialogResult.OK)
                //        {
                //            Application.Run(new MainForm(runArgs));
                //        }
                //        else
                //        {
                //            //Application.Exit();
                //        }
                //    }
                //}
                //else
                //{
                //    LoginForm frm = new LoginForm(hospCode, hospName);
                //    frm.ShowDialog();
                //    if (frm.DialogResult == DialogResult.OK)
                //    {
                //        Application.Run(new MainForm(runArgs));
                //    }
                //    else
                //    {
                //        //Application.Exit();
                //    }
                //}

                #endregion

                LoginForm frm = new LoginForm();
                frm.ShowDialog();
                MainForm frmMain = new MainForm(runArgs);

                if (frm.DialogResult == DialogResult.OK)
                {
                    Application.Run(frmMain);
                }
                else
                {
                    //Application.Exit();
                }

                // 2016.01.28 AnhNV fix https://sofiamedix.atlassian.net/browse/MED-6712
                // Do not change, remove this line to avoid warning CS1690: marshal-by-reference
                bool isRestart = frmMain.restart;

                if (isRestart == true)
                {
                    // Kills current process and Restart app.
                    Application.Restart();
                    Process.GetCurrentProcess().Kill();
                }

                Logs.WriteLog("[APPLICATION EXECUTABLEPATH]: " + Application.ExecutablePath);
            }
            catch (Exception xe)
            {
                Logs.WriteLog("Main", "MainEntry IHIS Run Error=" + xe.Message);
                Logs.WriteLog("Main", "MainEntry IHIS Run StackTrace=" + xe.StackTrace);
            }
        }

        /// <summary>
        /// Disconnect from VPN when exiting app - https://sofiamedix.atlassian.net/browse/MED-10662
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY, "").ToString()))
                {
                    VPNHelpers.ExtAccountDisconnect(CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY, "").ToString());
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        /// <summary>
        /// This will create a Application Reference file on the users desktop
        /// if they do not already have one when the program is loaded.
        /// Check for them running the deployed version before doing this,
        /// so it doesn't kick it when you're running it from Visual Studio.
        /// </summary
        static void CheckForShortcut()
        {
            try
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                    Logs.WriteLog("IsFirstRun: " + ad.IsFirstRun.ToString());
                    Assembly code = Assembly.GetExecutingAssembly();
                    string company = string.Empty;
                    string description = string.Empty;
                    if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
                    {
                        AssemblyCompanyAttribute ascompany =
                            (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
                            typeof(AssemblyCompanyAttribute));
                        company = ascompany.Company;
                    }
                    if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
                    {
                        AssemblyDescriptionAttribute asdescription =
                            (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
                            typeof(AssemblyDescriptionAttribute));
                        description = asdescription.Description;
                    }
                    Logs.WriteLog("Company: " + company);
                    Logs.WriteLog("Description(Application name): " + description);
                    if (company != string.Empty && description != string.Empty)
                    {
                        string desktopPath = string.Empty;
                        desktopPath = string.Concat(
                            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            "\\", description, ".appref-ms");
                        string shortcutName = string.Empty;
                        shortcutName = string.Concat(
                            Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                            "\\", company, "\\", description, ".appref-ms");
                        System.IO.File.Copy(shortcutName, desktopPath, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog("Shortcut error: " + ex.Message);
                Logs.WriteLog("Shortcut error stack trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// IHIS 기동에 필요한 공용 Libarary, File을 Download합니다.
        /// </summary>
        /// <returns> 재기동 필요시에 true, 필요없으면 false </returns>
        private static VersionResult DownloadCommFiles()
        {
            //다운로드 Flag에 따라 처리함.
            if (!Service.IsAssemblyDownLoad)
                return VersionResult.Success;

            VersionManager ver = new VersionManager("STA", "STA", "bin");
            VersionResult result = ver.DownloadFiles();

            //Rerun이 아닐때 환경파일을 Down받았으면 DB 다시 Connect
            //Rerun시는 File복사후 재기동하므로 ReConnect할 필요없음
            if ((result == VersionResult.Success) && VersionManager.ConfigFileDownloaded)
            {
                Service.DisConnect();

                Service.Connect();
            }
            //2006.06.15 Barcode Font 다운로드시 BarCode Font 등록 추가
            if (VersionManager.FontDownloaded)
            {
                RegisterBarCodeFont();
            }

            return result;
        }
        #region FindMainWindowHandle (IHIS Handle 찾기)
        private static IntPtr FindMainWindowHandle()
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = User32.FindWindow(null, "[IHIS]");
            }
            catch
            {
                ptr = IntPtr.Zero;
            }
            return ptr;
        }
        #endregion

        #region BarCode Font 등록 (Font를 단순히 Fonts Dir에 복사하기만 하면 바코드 폰드 등록안됨, Resource 등록해야함.)
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern int AddFontResource(string fileName);
        private static void RegisterBarCodeFont()
        {
            string fileName = Directory.GetParent(Environment.SystemDirectory).FullName + "\\Fonts\\" + VersionManager.BarCodeFontFile;
            if (File.Exists(fileName))
            {
                try
                {
                    AddFontResource(fileName);
                }
                catch (Exception xe)
                {
                    Logs.WriteLog("Main", "바코드폰드 등록에러=" + xe.Message);
                }
            }
        }
        #endregion
    }
}
