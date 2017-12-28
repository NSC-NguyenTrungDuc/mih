using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using IHIS.Framework;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Configuration;
using IHIS.CloudConnector.Caching;

namespace IHIS
{
    /// <summary>
    /// Provides methods for working with VPN server
    /// </summary>
    public static class VPNHelpers
    {
        #region Constants

        public const string VPN_CERT = "VPN_CERT";
        public const string VPN_KEY = "VPN_KEY";
        public const string VPN_CONN_KEY = "VPN_CONN_KEY";

        #endregion

        #region Fields & Properties

        /// <summary>
        /// Returns TRUE when a certificate is expired, otherwise FALSE.
        /// </summary>
        public static bool CertExpired
        {
            get { return UserInfo.VpnYn && UserInfo.CertExpired == "Y"; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Determines when a VPN client is installed and running on end-user computer or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsVPNRunning()
        {
            bool ret = false;
            string serviceName = string.Empty;

            try
            {
                serviceName = ConfigurationManager.AppSettings["VPNProcessName"];
                ServiceController service = new ServiceController(serviceName);

                // Running
                if (service.Status == ServiceControllerStatus.Running)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }

            return ret;
        }

        /// <summary>
        /// Auto reconnect to VPN server if has valid settings before
        /// </summary>
        public static void Reconnect(string newConn)
        {
            if (CacheService.Instance.IsSet(VPN_CONN_KEY))
            {
                string connectionName = CacheService.Instance.Get(VPN_CONN_KEY, "").ToString();
                if (!string.IsNullOrEmpty(connectionName) && connectionName.Contains(newConn))
                {
                    int ret = 1;
                    ret = StartProcess();
                    ret = ExtAccountConnect(connectionName);
                }
            }
        }

        /// <summary>
        /// Starts and waits for the service to reach the running status, or for the specified time-out to expire.
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="timeoutMilliseconds"></param>
        /// <returns></returns>
        public static bool StartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);

                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);

                return false;
            }
            finally { }
        }

        /// <summary>
        /// Stops and waits for the service to reach the stopped status, or for the specified time-out to expire.
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="timeoutMilliseconds"></param>
        /// <returns></returns>
        public static bool StopService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);

                return false;
            }
            finally { }
        }

        public static void RunCmd(string cmd)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = cmd;
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        #endregion

        #region Unmanage code

        [DllImport("vpn-api.dll")]
        public static extern int Install();

        [DllImport("vpn-api.dll")]
        public static extern int StartProcess();

        [DllImport("vpn-api.dll")]
        public static extern int AccountConnect();

        [DllImport("vpn-api.dll")]
        public static extern int AccountDisconnect();

        [DllImport("vpn-api.dll")]
        public static extern int AccountCreate(string user_name);

        [DllImport("vpn-api.dll")]
        public static extern int AccountCertSet(string key, string cert);

        [DllImport("vpn-api.dll")]
        public static extern int AccountStatusGet();

        [DllImport("vpn-api.dll")]
        public static extern int AccountDelete();

        [DllImport("vpn-api.dll")]
        public static extern int NicCreate();

        [DllImport("vpn-api.dll")]
        public static extern int NicDelete();

        [DllImport("vpn-api.dll")]
        public static extern int NicDisable();

        [DllImport("vpn-api.dll")]
        public static extern int NicEnable();

        [DllImport("vpn-api.dll")]
        public static extern int ExtAccountConnect(string connection_name);

        [DllImport("vpn-api.dll")]
        public static extern int ExtAccountDisconnect(string connection_name);

        [DllImport("vpn-api.dll")]
        public static extern int ExtAccountCertSet(string connection_name, string key, string cert);

        [DllImport("vpn-api.dll")]
        public static extern int ExtAccountDelete(string connection_name);

        /// <summary>
        /// ExtAccountStatusGet
        /// </summary>
        /// <param name="connection_name"></param>
        /// <returns>
        /// 37: Offline
        /// 36: Connection name is invalid
        /// 0: Online
        /// </returns>
        [DllImport("vpn-api.dll")]
        public static extern int ExtAccountStatusGet(string connection_name);

        [DllImport("vpn-api.dll")]
        public static extern int ExtAccountCreate(string vpn_connection_name, string user_name);

        #endregion
    }
}
