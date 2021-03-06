using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using IHIS.X.Magic.Menus;

namespace IHIS.Framework
{
    /// <summary>
    /// 환경정보 Static Class
    /// </summary>
    public class EnvironInfo
    {
        #region Fields
        //public const string		Product = "IHIS";		// Product명
        public const string Product = "IHIS";		// Product명
        //IFC는 15021, IHIS는 16021
        public const int UdpPort = 16021;		//Udp Msg Port
        const string LOGIN_IMAGE_NAME = "Login.gif";
        const string MAIN_ICON_NAME = "IHIS.ico";
        const string MONITER_KEY = "SOFTWARE\\IHIS\\MONITOR\\";
        private static string imagePath;		// Image Path
        private static MdiForm mdiForm = null;
        private static object mdiMenu = null;
        private static string currGroupID = string.Empty;
        private static string currGroupName = string.Empty;
        private static string currSystemID = string.Empty;
        private static string currSystemName = string.Empty;
        //환자번호 다른 시스템으로 전달 Window Msg
        const int MSG_TRANSFER_BUNHO = (int)(Win32.Msgs.WM_USER + 130);
        //<변환미확정> 환경변수로 어떻게 관리할 것인가.
        private static int bunhoLength = 9; //환자번호 자동 Format 길이(시마다9자리,가네보 8자리)
        //병원코드 추가. 2010.07.06. kimminsoo
        private static string hospCode = string.Empty;
        //2010.07.07. kimminsoo 로그인시 과선택이 필요한 경우에 필요한 변수들
        private static bool showDoctorGwaListAtLogin = false;//진료과 콤보를 보여줄지 말지 셋팅. default = false;
        private static ArrayList gwaListShowingSystemList = new ArrayList();//진료과 콤보를 보여줄 시스템 리스트
        // 2015.11.05 Cloud added
        private static ORCAServerInfo _ORCAserverInfo;
        public static Boolean IsReal = false;
        #endregion

        #region Properties
        //MdiForm
        public static MdiForm MdiForm
        {
            get { return mdiForm; }
            set { mdiForm = value; }
        }
        // 메뉴
        internal static object MdiMenu
        {
            get { return mdiMenu; }
            set { mdiMenu = value; }
        }
        public static string ImagePath
        {
            get { return imagePath; }
        }

        // <<2017.07.20>> DLL_CROSS START : DLL 의 교차참조 해결을 위함
        //                Forms.EnvironInfo 의 ClientIP 를 Service로 옮김.
        //                EnvironInfo.ClientIP 를 Service.ClientIP로 변경
        //
        #region
        //public static string ClientIP
        //{
        //    get
        //    {
        //        try
        //        {
        //            //IP 2개이상 지정된 PC의 경우 최종  IP가 사용하는 IP임
        //            IPAddress[] ipList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

        //            if (ipList.Length > 0)
        //            {
        //                foreach (IPAddress ipa in ipList)
        //                {
        //                    if (ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        //                    {
        //                        return ipa.ToString();
        //                    }
        //                }
        //            }
        //            //if (ipList.Length > 0)
        //            //	return ipList[ipList.Length -1].ToString();
        //            //else
        //            return "UnKnown";
        //        }
        //        catch
        //        {
        //            return "UnKnown";
        //        }
        //    }
        //}
        #endregion
        // <<2017.07.20>> DLL_CROSS END

        public static string CurrGroupID
        {
            get { return currGroupID; }
            set { currGroupID = value; }
        }
        public static string CurrGroupName
        {
            get { return currGroupName; }
            set { currGroupName = value; }
        }
        public static string CurrSystemID
        {
            get { return currSystemID; }
            set { currSystemID = value; }
        }
        public static string CurrSystemName
        {
            get { return currSystemName; }
            set { currSystemName = value; }
        }
        public static int BunhoLength  //BizCodeHelper에서 환자번호 자동변환시 사용
        {
            get { return bunhoLength; }
        }
        public static string HospCode  //병원코드 추가. 2010.07.06 kimminsoo
        {
            get { return hospCode; }
        }
        public static bool ShowDoctorGwaListAtLogin // 로그인 화면에 과 콤보를 보여줄지 여부
        {
            get { return showDoctorGwaListAtLogin; }
        }
        public static ArrayList GwaListShowingSystemList // 로그인 화면에 과콤보를 보여주어야할 시스템 리스트
        {
            get { return gwaListShowingSystemList; }
        }
        // 2015.11.05 Cloud added
        public static ORCAServerInfo ORCAserverInfo
        {
            get { return _ORCAserverInfo; }
        }
        #endregion

        #region 생성자
        static EnvironInfo()
        {
            try
            {
                imagePath = Directory.GetParent(Application.StartupPath).FullName + @"\Images";
                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);

                hospCode = (String.IsNullOrEmpty(UserInfo.HospCode)) ? Service.GetConfigString("HOSP", "CODE", "XXX") : UserInfo.HospCode;

                if (Service.GetConfigString("DoctorGwaListAtLogin", "SHOW", "N") == "Y")
                    showDoctorGwaListAtLogin = true;
                else
                    showDoctorGwaListAtLogin = false;


                gwaListShowingSystemList = XmlHelper.getValue(XmlHelper.getNode(XmlHelper.getNode(Service.ConfigXml.ChildNodes, "Config").ChildNodes, "DoctorGwaListAtLogin"), "ShowingSystemID");
                // 2015.11.05 Cloud added
                _ORCAserverInfo = new ORCAServerInfo();
                System.Xml.XmlNode nodes = XmlHelper.getNode(Service.ConfigXml.ChildNodes, "Config");
                _ORCAserverInfo.Host = XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "HOST")[0].ToString();
                _ORCAserverInfo.BookingPort = XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "BOOKING_PORT")[0].ToString();
                _ORCAserverInfo.OrderPort = XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "ORDER_PORT")[0].ToString();
                _ORCAserverInfo.User = XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "USER")[0].ToString();
                _ORCAserverInfo.Password = XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "PASSWORD")[0].ToString();
                _ORCAserverInfo.ContentType = XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "CONTENT_TYPE")[0].ToString();
                _ORCAserverInfo.BookingUrl = XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "BOOKING_URL")[0].ToString();
                _ORCAserverInfo.TempFileName = XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "TEMP_FILE_NAME")[0].ToString();
                _ORCAserverInfo.TempFolder = Path.Combine(Application.StartupPath, XmlHelper.getValue(XmlHelper.getNode(nodes.ChildNodes, "ORCA_SERVER"), "TEMP_FOLDER")[0].ToString());
            }
            catch { }
        }
        #endregion

        #region Method
        //2010.08.06 KIMMINSOO getServerMsg() 추가
        //3tier에 있던 함수.. 추후 어떻게 가져갈지 방향을 정할 필요가 있음.
        public static string GetServerMsg(int msgNum)
        {
            /*string cmdText = "SELECT JAPAN_MSG FROM ADM0003 WHERE ADM0003_PK = '" + msgNum + "'";
            
            object retVal = Service.ExecuteScalar(cmdText);

            if (retVal == null) return null;
            return retVal.ToString();*/

            // Cloud service
            FormEnvironInfoMessageArgs args = new FormEnvironInfoMessageArgs();
            StringResult data = CloudService.Instance.Submit<StringResult, FormEnvironInfoMessageArgs>(args);
            return data.Result;
        }

        /// <summary>
        /// IHIS.config 파일에서 [EKG_VIEWER] NODE의 PATH에서 가져오기
        /// </summary>
        /// <returns></returns>
        public static string GetEkgViewerPath()
        {
            //IHIS.config 파일에서 [EKG_VIEWER] NODE의 PATH에서 가져오기
            return Service.GetConfigString("EKG_VIEWER", "PATH", @"C:\Program Files\Fukuda Denshi\ECG Viewer FEV-40\FEV-40.exe");
        }

        /// <summary>
        /// IMAGE 서버 IP를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static string GetImageServerIP()
        {
            //IHIS.config 파일에서 [IMAGE_SERVER] NODE의 IP에서 가져오기
            return Service.GetConfigString("IMAGE_SERVER", "IP", "192.168.150.119");
        }
        public static string GetImageUserID()
        {
            //IHIS.config 파일에서 [IMAGE_SERVER] NODE의 IP에서 가져오기
            return Service.GetConfigString("IMAGE_SERVER", "USER_ID", "ihisimage");
        }
        public static string GetImageUserPW()
        {
            //IHIS.config 파일에서 [IMAGE_SERVER] NODE의 IP에서 가져오기
            return Service.GetConfigString("IMAGE_SERVER", "USER_PW", "ihisimage");
        }


        /// <summary>
        /// 검사 인터페이스 데몬 서버 IP를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static string GetInterfaceIP()
        {
            //IHIS.config 파일에서 [INTERFACE] NODE의 IP에서 가져오기
            return Service.GetConfigString("INTERFACE", "IP", "192.168.150.119");
        }

        public static int GetInterfacePort()
        {
            //IHIS.config 파일에서 [INTERFACE] NODE의 IP에서 가져오기
            int port = 14200;
            string sPort = Service.GetConfigString("INTERFACE", "PORT", "14200");
            if (TypeCheck.IsInt(sPort))
                port = int.Parse(sPort);
            return port;
        }

        /// <summary>
        /// 회계 인터페이스 데몬 서버 IP를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static string GetKaikeiIP()
        {
            //IHIS.config 파일에서 [KAIKEI] NODE의 IP에서 가져오기
            return Service.GetConfigString("KAIKEI", "IP", "192.168.150.300");
        }

        public static int GetKaiKeiPort()
        {
            //IHIS.config 파일에서 [KAIKEI] NODE의 IP에서 가져오기
            int port = 10009;
            string sPort = Service.GetConfigString("KAIKEI", "PORT", "10009");
            if (TypeCheck.IsInt(sPort))
                port = int.Parse(sPort);
            return port;
        }

        /// <summary>
        /// ORCA SERVER IP를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static string GetOrcaIP()
        {
            //IHIS.config 파일에서 [ORCA_SERVER] NODE의 IP에서 가져오기
            return Service.GetConfigString("ORCA_SERVER", "IP", "192.168.150.300");
        }

        public static int GetOrcaPort()
        {
            //IHIS.config 파일에서 [ORCA_SERVER] NODE의 IP에서 가져오기
            int port = 10009;
            string sPort = Service.GetConfigString("ORCA_SERVER", "PORT", "10009");
            if (TypeCheck.IsInt(sPort))
                port = int.Parse(sPort);
            return port;
        }

        /// <summary>
        /// 파일을 다운로드할 서버 IP를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static string GetDownloadServerIP()
        {
            //IHIS.config 파일에서 [SERVER] NODE의 IP에서 가져오기
            //return Service.GetConfigString("SERVER", "IP", "222.106.127.66");
            String ServerType = Service.GetConfigString("SERVER", "IP", "127.0.0.1");

            //XMessageBox.Show(ServerType);

            if (ServerType.Equals("192.168.11.11"))
                EnvironInfo.IsReal = true;
            else
                EnvironInfo.IsReal = false;

            return ServerType;
        }
        public static DateTime GetSysDate()
        {
            try
            {
                //2006.07.11 DB종류에 따라 SQL문 변경
                /*string cmdText = "SELECT TO_CHAR(SYSDATE,'YYYY/MM/DD') FROM DUAL";
                if (Service.CurrentDBKind == DataBaseKind.SqlServer)
                    cmdText = "SELECT   CONVERT(CHAR(10), GETDATE(), 111)";  //For SqlServer

                object data = Service.ExecuteScalar(cmdText);
                if (data != null)
                    return DateTime.Parse(data.ToString());
                else
                    return DateTime.Today;*/

                // Cloud service
                FormEnvironInfoSysDateArgs args = new FormEnvironInfoSysDateArgs();
                StringResult data = CloudService.Instance.Submit<StringResult, FormEnvironInfoSysDateArgs>(args);
                if (!String.IsNullOrEmpty(data.Result))
                {
                    return DateTime.Parse(data.Result);
                }
                else
                {
                    return DateTime.Today;
                }
            }
            catch
            {
                return DateTime.Today;
            }

        }
        public static DateTime GetSysDateTime()
        {
            try
            {
                /*//2006.07.11 DB종류에 따라 SQL문 변경
                string cmdText = "SELECT TO_CHAR(SYSDATE,'YYYY/MM/DD HH24:MI:SS') FROM DUAL";
                if (Service.CurrentDBKind == DataBaseKind.SqlServer)
                    cmdText = "SELECT   CONVERT(CHAR(10), GETDATE(), 111) + ' ' + CONVERT(CHAR(10), GETDATE(), 108) ";  //For SqlServer

                object data = Service.ExecuteScalar(cmdText);
                if (data != null)
                    return DateTime.Parse(data.ToString());
                else
                    return DateTime.Now;*/

                // Cloud service
                FormEnvironInfoSysDateTimeArgs args = new FormEnvironInfoSysDateTimeArgs();
                StringResult data = CloudService.Instance.Submit<StringResult, FormEnvironInfoSysDateTimeArgs>(args);
                if (!String.IsNullOrEmpty(data.Result))
                {
                    return DateTime.Parse(data.Result);
                }
                else
                {
                    return DateTime.Now;
                }
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public static IntPtr FindIHISHandle()
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
        //Login.gif를 사용하는 사용자로그인,비밀번호변경,로그아웃 창의 Image 설정
        public static void SetBackgroundImage(Form form)
        {
            try
            {
                string fileName = EnvironInfo.ImagePath + "\\" + EnvironInfo.LOGIN_IMAGE_NAME;
                if (File.Exists(fileName))
                {
                    Bitmap backImg = Image.FromFile(fileName) as Bitmap;
                    form.BackgroundImage = backImg;
                    //Bitmap TransParent (테두리가 TransParent이므로 적용안함)
                    Color tColor = backImg.GetPixel(0, 0);
                    backImg.MakeTransparent(tColor);

                    //Size 설정 (MaxSize도 고정)
                    form.ClientSize = backImg.Size;
                    form.MaximumSize = backImg.Size;

                    //Form의 Region 설정
                    form.Region = new Region(CalculateGraphicsPath(backImg));

                }
                fileName = EnvironInfo.ImagePath + "\\" + EnvironInfo.MAIN_ICON_NAME;
                if (File.Exists(fileName))
                {
                    form.Icon = new Icon(fileName);
                }
            }
            finally { }
        }
        private static GraphicsPath CalculateGraphicsPath(Bitmap bitmap)
        {

            GraphicsPath graphicsPath = new GraphicsPath();

            // TransParent Color
            Color tColor = bitmap.GetPixel(0, 0);

            //Bitmap의 크기는 408,300
            // 0 ~ 5까지는 TransParent 계산, 6 ~ 294까지는 Rect 적용(TransParent없음)
            // 295 ~height까지 TransParent 계산

            int colOpaquePixel = 0;
            Rectangle rect = Rectangle.Empty;

            // Go through all rows (Y axis)
            for (int row = 0; row < 5; row++)
            {
                // Reset value
                colOpaquePixel = 0;

                // Go through all columns (X axis)
                for (int col = 0; col < bitmap.Width; col++)
                {
                    if (bitmap.GetPixel(col, row) != tColor)
                    {
                        colOpaquePixel = col;
                        int colNext = col;
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == tColor)
                                break;
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));
                        rect = new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1);
                        col = colNext;
                    }
                }
            }
            graphicsPath.AddRectangle(new Rectangle(0, 5, bitmap.Width, 290));
            for (int row = 295; row < bitmap.Height; row++)
            {
                // Reset value
                colOpaquePixel = 0;

                // Go through all columns (X axis)
                for (int col = 0; col < bitmap.Width; col++)
                {
                    if (bitmap.GetPixel(col, row) != tColor)
                    {
                        colOpaquePixel = col;
                        int colNext = col;
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == tColor)
                                break;
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));
                        rect = new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1);
                        col = colNext;
                    }
                }
            }

            // Return calculated graphics path
            return graphicsPath;
        }
        #endregion

        #region ColorStyle 적용 Method
        public static bool SetActiveColorStyle(string styleName)
        {
            if (EnvironInfo.MdiForm != null)
                return EnvironInfo.MdiForm.SetActiveColorStyle(styleName);

            return false;
        }
        #endregion

        #region MDI 오픈 Monitor 위치 지정, 화면 Open 모니터 위치 지정
        internal static void SetMDIMonitorIndex()
        {
            //모니터 선택 Form을 띄워서 선택하게 한다. 단 Monitor가 1개이면 적용하지 않는다.
            //Resitry는 IFC/MONITOR/시스템ID에 Key = MDI, value = 모니터Index 관리
            /*RegistryKey rkey = Registry.LocalMachine;
            RegistryKey rkey1 = rkey.OpenSubKey(MONITER_KEY + EnvironInfo.CurrSystemID,true);
            if (rkey1 == null)
                rkey1 = rkey.CreateSubKey(MONITER_KEY + EnvironInfo.CurrSystemID);
            object retVal = rkey1.GetValue("MDI");*/
            string key = Constants.CacheKeyCbo.CACHE_COMMON_MONITOR_PREFIX + EnvironInfo.CurrSystemID + ".MDI";
            object retVal = CacheService.Instance.Get(key, null);
            int monitorIndex = 0;
            if (retVal == null)
                monitorIndex = 0; //기본값
            else
                monitorIndex = Math.Max(0, Int32.Parse(retVal.ToString()));
            SelectMonitorForm dlg = new SelectMonitorForm(monitorIndex);
            if (dlg.ShowDialog() == DialogResult.OK) //Registry Set
            {
                CacheService.Instance.Set(key, dlg.MonitorIndex.ToString(), TimeSpan.MaxValue);
                /*rkey1.SetValue("MDI", dlg.MonitorIndex.ToString());*/
            }
            /*rkey1.Close();
            rkey.Close();*/
        }
        internal static int GetMDIMonitorIndex()
        {
            //Registry에 등록되어 있지 않으면 0, 있으면 해당 Monitor Index, 단 등록된 것보다 현재 모니터의 갯수가 작으면 Min값
            /*RegistryKey rkey = Registry.LocalMachine;
            RegistryKey rkey1 = rkey.OpenSubKey(MONITER_KEY + EnvironInfo.CurrSystemID, false);
            if (rkey1 == null) return 0;
            object retVal = rkey1.GetValue("MDI");*/
            string key = Constants.CacheKeyCbo.CACHE_COMMON_MONITOR_PREFIX + EnvironInfo.CurrSystemID + ".MDI";
            object retVal = CacheService.Instance.Get(key, null);
            int mIndex = 0;
            if (retVal != null) //0는 기본값
                mIndex = Math.Max(0, Math.Min(Int32.Parse(retVal.ToString()), SystemInformation.MonitorCount));
            return mIndex;
        }
        public static void SetScreenMonitorIndex(XScreen screen)  //화면의 Monitor Index 지정
        {
            if (screen == null) return;
            if (screen.ScreenInfo == null) return;
            /*RegistryKey rkey = Registry.LocalMachine;
            RegistryKey rkey1 = rkey.OpenSubKey(MONITER_KEY + EnvironInfo.CurrSystemID,true);
            if (rkey1 == null)
                rkey1 = rkey.CreateSubKey(MONITER_KEY + EnvironInfo.CurrSystemID);
            object retVal = rkey1.GetValue(screen.ScreenInfo.PgmID); //해당 화면ID의 값 Get*/
            string key = Constants.CacheKeyCbo.CACHE_COMMON_MONITOR_PREFIX + EnvironInfo.CurrSystemID + "." + screen.ScreenInfo.PgmID;
            object retVal = CacheService.Instance.Get(key, null);
            int monitorIndex = 0;
            if (retVal == null)
                monitorIndex = 0; //기본값(미지정)
            else
                monitorIndex = Math.Max(0, Int32.Parse(retVal.ToString()));
            SelectMonitorForm dlg = new SelectMonitorForm(monitorIndex);
            if (dlg.ShowDialog() == DialogResult.OK) //Registry Set
            {
                CacheService.Instance.Set(key, dlg.MonitorIndex.ToString(), TimeSpan.MaxValue);
                /*rkey1.SetValue(screen.ScreenInfo.PgmID, dlg.MonitorIndex.ToString());*/
            }
            /*rkey1.Close();
            rkey.Close();*/
        }
        internal static int GetScreenMonitorIndex(ScreenInfo screenInfo)
        {
            if (screenInfo == null) return 0;

            //Registry에 등록되어 있지 않으면 0, 있으면 해당 Monitor Index, 단 등록된 것보다 현재 모니터의 갯수가 작으면 Min값
            /*RegistryKey rkey = Registry.LocalMachine;
            RegistryKey rkey1 = rkey.OpenSubKey(MONITER_KEY + EnvironInfo.CurrSystemID, false);
            if (rkey1 == null) return 0;
            object retVal = rkey1.GetValue(screenInfo.PgmID);*/
            string key = Constants.CacheKeyCbo.CACHE_COMMON_MONITOR_PREFIX + EnvironInfo.CurrSystemID + "." + screenInfo.PgmID;
            object retVal = CacheService.Instance.Get(key, null);
            int mIndex = 0;
            if (retVal != null)
                mIndex = Math.Max(0, Math.Min(Int32.Parse(retVal.ToString()), SystemInformation.MonitorCount));
            return mIndex;
        }
        #endregion

        #region TransferBunho(환자번호 다른 시스템으로 전달)
        public static void TransferBunho(string systemID, string userID, string bunho)
        {
            TransferBunho(systemID, userID, bunho, "");
        }
        public static void TransferBunho(string systemID, string userID, string bunho, string screenID)
        {
            //IHIS의 MainForm에서 처리 LOGIC
            //지정한 시스템이 안띄워져 있으면 userID로 띄우고, 환자번호 전달
            //띄워져 있으면 MDI로 Window Msg 전달
            //MdiForm에서는 그 메세지를 받아서 현재 Open된 화면의 OnReceiveBunho Method를 Call
            //wParam = 시스템ID + TAB + 사용자 ID + TAB + 환자번호 + TAB + 화면ID
            IntPtr ihisHandle = FindIHISHandle();
            if (ihisHandle != IntPtr.Zero)
            {
                string param = systemID + "\t" + userID + "\t" + bunho + "\t" + screenID;
                IntPtr wParam = Marshal.StringToHGlobalAuto(param);
                User32.SendMessage(ihisHandle, MSG_TRANSFER_BUNHO, wParam, IntPtr.Zero);
            }
        }
        #endregion

        #region [WriteLog]
        public static void WriteLog(string logMsg)
        {
            Logs.WriteLog(logMsg);
            /*
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
            */
        }
        #endregion [WriteLog]
    }

    public class ORCAServerInfo
    {
        private string host = "";
        private string bookingPort = "";
        private string orderPort = "";
        private string user = "";
        private string password = "";
        private string contentType = "";
        private string bookingUrl = "";
        private string tempFolder = "";
        private string tempFileName = "";

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public string BookingPort
        {
            get { return bookingPort; }
            set { bookingPort = value; }
        }

        public string OrderPort
        {
            get { return orderPort; }
            set { orderPort = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        public string BookingUrl
        {
            get { return bookingUrl; }
            set { bookingUrl = value; }
        }

        public string TempFolder
        {
            get { return tempFolder; }
            set { tempFolder = value; }
        }

        public string TempFileName
        {
            get { return tempFileName; }
            set { tempFileName = value; }
        }
    }
}
