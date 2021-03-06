using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector;
using System.Runtime.InteropServices;
using IHIS.CloudConnector.Caching;
using System.Threading;
using IHIS.Framework;

namespace IHIS
{
    /// <summary>
    /// MED-9298
    /// Generats a new VPN certificate for new clinic
    /// </summary>
    public partial class FormSettingVPN : Form
    {
        #region Constants

        private const int ERR_NO_ERROR = 0; // No error
        private const int ERR_CONNECT_FAILED = 1; // Connection to the server has failed
        private const int ERR_SERVER_IS_NOT_VPN = 2; // The destination server is not a VPN server
        private const int ERR_DISCONNECTED = 3; // The connection has been interrupted
        private const int ERR_PROTOCOL_ERROR = 4; // Protocol error
        private const int ERR_CLIENT_IS_NOT_VPN = 5; // Connecting client is not a VPN client
        private const int ERR_USER_CANCEL = 6; // User cancel
        private const int ERR_AUTHTYPE_NOT_SUPPORTED = 7; // Specified authentication method is not supported
        private const int ERR_HUB_NOT_FOUND = 8; // The HUB does not exist
        private const int ERR_AUTH_FAILED = 9; // Authentication failure
        private const int ERR_HUB_STOPPING = 10; // HUB is stopped
        private const int ERR_SESSION_REMOVED = 11; // Session has been deleted
        private const int ERR_ACCESS_DENIED = 12; // Access denied
        private const int ERR_SESSION_TIMEOUT = 13; // Session times out
        private const int ERR_INVALID_PROTOCOL = 14; // Protocol is invalid
        private const int ERR_TOO_MANY_CONNECTION = 15; // Too many connections
        private const int ERR_HUB_IS_BUSY = 16; // Too many sessions of the HUB
        private const int ERR_PROXY_CONNECT_FAILED = 17; // Connection to the proxy server fails
        private const int ERR_PROXY_ERROR = 18; // Proxy Error
        private const int ERR_PROXY_AUTH_FAILED = 19; // Failed to authenticate on the proxy server
        private const int ERR_TOO_MANY_USER_SESSION = 20; // Too many sessions of the same user
        private const int ERR_LICENSE_ERROR = 21; // License error
        private const int ERR_DEVICE_DRIVER_ERROR = 22; // Device driver error
        private const int ERR_INTERNAL_ERROR = 23; // Internal error
        private const int ERR_SECURE_DEVICE_OPEN_FAILED = 24; // The secure device cannot be opened
        private const int ERR_SECURE_PIN_LOGIN_FAILED = 25; // PIN code is incorrect
        private const int ERR_SECURE_NO_CERT = 26; // Specified certificate is not stored
        private const int ERR_SECURE_NO_PRIVATE_KEY = 27; // Specified private key is not stored
        private const int ERR_SECURE_CANT_WRITE = 28; // Write failure
        private const int ERR_OBJECT_NOT_FOUND = 29; // Specified object can not be found
        private const int ERR_VLAN_ALREADY_EXISTS = 30; // Virtual LAN card with the specified name already exists
        private const int ERR_VLAN_INSTALL_ERROR = 31; // Specified virtual LAN card cannot be created
        private const int ERR_VLAN_INVALID_NAME = 32; // Specified name of the virtual LAN card is invalid
        private const int ERR_NOT_SUPPORTED = 33; // Unsupported
        private const int ERR_ACCOUNT_ALREADY_EXISTS = 34; // Account already exists
        private const int ERR_ACCOUNT_ACTIVE = 35; // Account is operating
        private const int ERR_ACCOUNT_NOT_FOUND = 36; // Specified account doesn't exist
        private const int ERR_ACCOUNT_INACTIVE = 37; // Account is offline
        private const int ERR_INVALID_PARAMETER = 38; // Parameter is invalid
        private const int ERR_SECURE_DEVICE_ERROR = 39; // Error has occurred in the operation of the secure device
        private const int ERR_NO_SECURE_DEVICE_SPECIFIED = 40; // Secure device is not specified
        private const int ERR_VLAN_IS_USED = 41; // Virtual LAN card in use by account
        private const int ERR_VLAN_FOR_ACCOUNT_NOT_FOUND = 42; // Virtual LAN card of the account can not be found
        private const int ERR_VLAN_FOR_ACCOUNT_USED = 43; // Virtual LAN card of the account is already in use
        private const int ERR_VLAN_FOR_ACCOUNT_DISABLED = 44; // Virtual LAN card of the account is disabled
        private const int ERR_INVALID_VALUE = 45; // Value is invalid
        private const int ERR_NOT_FARM_CONTROLLER = 46; // Not a farm controller
        private const int ERR_TRYING_TO_CONNECT = 47; // Attempting to connect
        private const int ERR_CONNECT_TO_FARM_CONTROLLER = 48; // Failed to connect to the farm controller
        private const int ERR_COULD_NOT_HOST_HUB_ON_FARM = 49; // A virtual HUB on farm could not be created
        private const int ERR_FARM_MEMBER_HUB_ADMIN = 50; // HUB cannot be managed on a farm member
        private const int ERR_NULL_PASSWORD_LOCAL_ONLY = 51; // Accepting only local connections for an empty password
        private const int ERR_NOT_ENOUGH_RIGHT = 52; // Right is insufficient
        private const int ERR_LISTENER_NOT_FOUND = 53; // Listener can not be found
        private const int ERR_LISTENER_ALREADY_EXISTS = 54; // Listener already exists
        private const int ERR_NOT_FARM_MEMBER = 55; // Not a farm member
        private const int ERR_CIPHER_NOT_SUPPORTED = 56; // Encryption algorithm is not supported
        private const int ERR_HUB_ALREADY_EXISTS = 57; // HUB already exists
        private const int ERR_TOO_MANY_HUBS = 58; // Too many HUBs
        private const int ERR_LINK_ALREADY_EXISTS = 59; // Link already exists
        private const int ERR_LINK_CANT_CREATE_ON_FARM = 60; // The link can not be created on the server farm
        private const int ERR_LINK_IS_OFFLINE = 61; // Link is off-line
        private const int ERR_TOO_MANY_ACCESS_LIST = 62; // Too many access list
        private const int ERR_TOO_MANY_USER = 63; // Too many users
        private const int ERR_TOO_MANY_GROUP = 64; // Too many Groups
        private const int ERR_GROUP_NOT_FOUND = 65; // Group can not be found
        private const int ERR_USER_ALREADY_EXISTS = 66; // User already exists
        private const int ERR_GROUP_ALREADY_EXISTS = 67; // Group already exists
        private const int ERR_USER_AUTHTYPE_NOT_PASSWORD = 68; // Authentication method of the user is not a password authentication
        private const int ERR_OLD_PASSWORD_WRONG = 69; // The user does not exist or the old password is wrong
        private const int ERR_LINK_CANT_DISCONNECT = 73; // Cascade session cannot be disconnected
        private const int ERR_ACCOUNT_NOT_PRESENT = 74; // Not completed configure the connection to the VPN server
        private const int ERR_ALREADY_ONLINE = 75; // It is already online
        private const int ERR_OFFLINE = 76; // It is offline
        private const int ERR_NOT_RSA_1024 = 77; // The certificate is not RSA 1024bit
        private const int ERR_SNAT_CANT_DISCONNECT = 78; // SecureNAT session cannot be disconnected
        private const int ERR_SNAT_NEED_STANDALONE = 79; // SecureNAT works only in stand-alone HUB
        private const int ERR_SNAT_NOT_RUNNING = 80; // SecureNAT function is not working
        private const int ERR_SE_VPN_BLOCK = 81; // Stopped by PacketiX VPN Block
        private const int ERR_BRIDGE_CANT_DISCONNECT = 82; // Bridge session can not be disconnected
        private const int ERR_LOCAL_BRIDGE_STOPPING = 83; // Bridge function is stopped
        private const int ERR_LOCAL_BRIDGE_UNSUPPORTED = 84; // Bridge feature is not supported
        private const int ERR_CERT_NOT_TRUSTED = 85; // Certificate of the destination server can not be trusted
        private const int ERR_PRODUCT_CODE_INVALID = 86; // Product code is different
        private const int ERR_VERSION_INVALID = 87; // Version is different
        private const int ERR_CAPTURE_DEVICE_ADD_ERROR = 88; // Adding capture device failure
        private const int ERR_VPN_CODE_INVALID = 89; // VPN code is different
        private const int ERR_CAPTURE_NOT_FOUND = 90; // Capture device can not be found
        private const int ERR_LAYER3_CANT_DISCONNECT = 91; // Layer-3 session cannot be disconnected
        private const int ERR_LAYER3_SW_EXISTS = 92; // L3 switch of the same already exists
        private const int ERR_LAYER3_SW_NOT_FOUND = 93; // Layer-3 switch can not be found
        private const int ERR_INVALID_NAME = 94; // Name is invalid
        private const int ERR_LAYER3_IF_ADD_FAILED = 95; // Failed to add interface
        private const int ERR_LAYER3_IF_DEL_FAILED = 96; // Failed to delete the interface
        private const int ERR_LAYER3_IF_EXISTS = 97; // Interface that you specified already exists
        private const int ERR_LAYER3_TABLE_ADD_FAILED = 98; // Failed to add routing table
        private const int ERR_LAYER3_TABLE_DEL_FAILED = 99; // Failed to delete the routing table
        private const int ERR_LAYER3_TABLE_EXISTS = 100; // Routing table entry that you specified already exists
        private const int ERR_BAD_CLOCK = 101; // Time is queer
        private const int ERR_LAYER3_CANT_START_SWITCH = 102; // The Virtual Layer 3 Switch can not be started
        private const int ERR_CLIENT_LICENSE_NOT_ENOUGH = 103; // Client connection licenses shortage
        private const int ERR_BRIDGE_LICENSE_NOT_ENOUGH = 104; // Bridge connection licenses shortage
        private const int ERR_SERVER_CANT_ACCEPT = 105; // Not Accept on the technical issues
        private const int ERR_SERVER_CERT_EXPIRES = 106; // Destination VPN server has expired
        private const int ERR_MONITOR_MODE_DENIED = 107; // Monitor port mode was rejected
        private const int ERR_BRIDGE_MODE_DENIED = 108; // Bridge-mode or Routing-mode was rejected
        private const int ERR_IP_ADDRESS_DENIED = 109; // Client IP address is denied
        private const int ERR_TOO_MANT_ITEMS = 110; // Too many items
        private const int ERR_MEMORY_NOT_ENOUGH = 111; // Out of memory
        private const int ERR_OBJECT_EXISTS = 112; // Object already exists
        private const int ERR_FATAL = 113; // A fatal error occurred
        private const int ERR_SERVER_LICENSE_FAILED = 114; // License violation has occurred on the server side
        private const int ERR_SERVER_INTERNET_FAILED = 115; // Server side is not connected to the Internet
        private const int ERR_CLIENT_LICENSE_FAILED = 116; // License violation occurs on the client side
        private const int ERR_BAD_COMMAND_OR_PARAM = 117; // Command or parameter is invalid
        private const int ERR_INVALID_LICENSE_KEY = 118; // License key is invalid
        private const int ERR_NO_VPN_SERVER_LICENSE = 119; // There is no valid license for the VPN Server
        private const int ERR_NO_VPN_CLUSTER_LICENSE = 120; // There is no cluster license
        private const int ERR_NOT_ADMINPACK_SERVER = 121; // Not trying to connect to a server with the Administrator Pack license
        private const int ERR_NOT_ADMINPACK_SERVER_NET = 122; // Not trying to connect to a server with the Administrator Pack license (for .NET)
        private const int ERR_BETA_EXPIRES = 123; // Destination Beta VPN Server has expired
        private const int ERR_BRANDED_C_TO_S = 124; // Branding string of connection limit is different (Authentication on the server side)
        private const int ERR_BRANDED_C_FROM_S = 125; // Branding string of connection limit is different (Authentication for client-side)
        private const int ERR_AUTO_DISCONNECTED = 126; // VPN session is disconnected for a certain period of time has elapsed
        private const int ERR_CLIENT_ID_REQUIRED = 127; // Client ID does not match
        private const int ERR_TOO_MANY_USERS_CREATED = 128; // Too many created users
        private const int ERR_SUBSCRIPTION_IS_OLDER = 129; // Subscription expiration date Is earlier than the build date of the VPN Server
        private const int ERR_ILLEGAL_TRIAL_VERSION = 130; // Many trial license is used continuously
        private const int ERR_NAT_T_TWO_OR_MORE = 131; // There are multiple servers in the back of a global IP address in the NAT-T connection
        private const int ERR_DUPLICATE_DDNS_KEY = 132; // DDNS host key duplicate
        private const int ERR_DDNS_HOSTNAME_EXISTS = 133; // Specified DDNS host name already exists
        private const int ERR_DDNS_HOSTNAME_INVALID_CHAR = 134; // Characters that can not be used for the host name is included
        private const int ERR_DDNS_HOSTNAME_TOO_LONG = 135; // Host name is too long
        private const int ERR_DDNS_HOSTNAME_IS_EMPTY = 136; // Host name is not specified
        private const int ERR_DDNS_HOSTNAME_TOO_SHORT = 137; // Host name is too short
        private const int ERR_MSCHAP2_PASSWORD_NEED_RESET = 138; // Necessary that password is changed
        private const int ERR_DDNS_DISCONNECTED = 139; // Communication to the dynamic DNS server is disconnected
        private const int ERR_SPECIAL_LISTENER_ICMP_ERROR = 140; // The ICMP socket can not be opened
        private const int ERR_SPECIAL_LISTENER_DNS_ERROR = 141; // Socket for DNS port can not be opened
        private const int ERR_OPENVPN_IS_NOT_ENABLED = 142; // OpenVPN server feature is not enabled
        private const int ERR_NOT_SUPPORTED_AUTH_ON_OPENSOURCE = 143; // It is the type of user authentication that are not supported in the open source version
        private const int ERR_VPNGATE = 144; // Operation on VPN Gate Server is not available
        private const int ERR_VPNGATE_CLIENT = 145; // Operation on VPN Gate Client is not available
        private const int ERR_VPNGATE_INCLIENT_CANT_STOP = 146; // Can not be stopped if operating within VPN Client mode
        private const int ERR_NOT_SUPPORTED_FUNCTION_ON_OPENSOURCE = 147; // It is a feature that is not supported in the open source version
        private const int ERR_SUSPENDING = 148; // System is suspending        

        #endregion

        #region Fields & properties

        private string _hospCode;
        private string _connectionName;
        private static readonly object _lockObj = new object();

        public string HospCode
        {
            get { return !string.IsNullOrEmpty(this._connectionName) ? this._connectionName : ""; }
            set { _hospCode = value; }
        }

        #endregion

        #region Constructors

        public FormSettingVPN()
        {
            InitializeComponent();

            // MED-14286
            if (NetInfo.Language != LangMode.Jr)
            {
                this.Font = new Font("Arial", 8.75f);
            }
        }

        public FormSettingVPN(string hospCode, string connectionName)
        {
            InitializeComponent();

            this._hospCode = hospCode;
            this._connectionName = connectionName;

            // MED-14286
            if (NetInfo.Language != LangMode.Jr)
            {
                this.Font = new Font("Arial", 8.75f);
            }
        }

        #endregion

        #region Events

        private void FormSettingVPN_Load(object sender, EventArgs e)
        {
            try
            {
                string cert = Convert.ToString(CacheService.Instance.Get(VPNHelpers.VPN_CERT + this._hospCode, ""));
                string key = Convert.ToString(CacheService.Instance.Get(VPNHelpers.VPN_KEY + this._hospCode, ""));
                // https://sofiamedix.atlassian.net/browse/MED-14015
                string userId = CacheService.Instance.Get("VPN_USER_ID", "").ToString();

                this.txtVPNCert.Text = cert;
                this.txtVPNKey.Text = key;

                // https://sofiamedix.atlassian.net/browse/MED-13956
                if (!string.IsNullOrEmpty(userId))
                {
                    this.txtUserID.Text = userId;
                }
                else if (!string.IsNullOrEmpty(this._connectionName))
                {
                    string[] conns = this._connectionName.Split('_');

                    if (conns.Length > 0)
                    {
                        this.txtUserID.Text = this._connectionName.Split('_')[1];
                    }
                }

                this.ApplyMultiLanguages();
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private void btnVPN_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseCert_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = false;
                    ofd.Filter = "Certificate Files|*.cer;*.crt";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtVPNCert.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private void btnBrowseKey_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = false;
                    ofd.Filter = "Key Files|*.key";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtVPNKey.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHospCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Moves to next control when hitting Enter key
            if (e.KeyChar == (char)13)
            {
                this.txtVPNCert.Focus();
            }
        }

        private void txtVPNCert_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Moves to next control when hitting Enter key
            if (e.KeyChar == (char)13)
            {
                this.txtVPNKey.Focus();
            }
        }

        private void txtVPNKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Moves to next control when hitting Enter key
            if (e.KeyChar == (char)13)
            {
                this.btnSave.Focus();
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            int ret = 1;
            // https://sofiamedix.atlassian.net/browse/MED-13956
            string connectionName = this._hospCode + "_" + this.txtUserID.Text.Trim();

            try
            {
                this.lbErrMsg.Text = "";

                // https://sofiamedix.atlassian.net/browse/MED-13956
                if (txtUserID.Text.Trim() == "")
                {
                    lbErrMsg.Text = XMsg.GetMsg("M001"); // 사용자ID가 입력되지 않았습니다.
                    txtUserID.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(this.txtVPNCert.Text) || string.IsNullOrEmpty(this.txtVPNKey.Text))
                {
                    this.lbErrMsg.Text = XMsg.GetMsg("MSG020");
                    return;
                }

                // Connecting
                this.lbErrMsg.Text = XMsg.GetMsg("MSG027");

                // Expired check
                if (VPNHelpers.CertExpired)
                {
                    lbErrMsg.Text = XMsg.GetMsg("MSG021");
                    return;
                }

                // Disconnect current connection
                if (!string.IsNullOrEmpty(CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY, "").ToString()))
                {
                    ret = VPNHelpers.ExtAccountDisconnect(CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY, "").ToString());
                }

                ret = VPNHelpers.StartProcess();
                ret = VPNHelpers.NicCreate();

                // https://sofiamedix.atlassian.net/browse/MED-13956
                //ret = VPNHelpers.ExtAccountCreate(this._connectionName, this._connectionName);
                //ret = VPNHelpers.ExtAccountCertSet(this._connectionName, this.txtVPNKey.Text.Trim(), this.txtVPNCert.Text.Trim());
                //ret = VPNHelpers.ExtAccountConnect(this._connectionName);
                ret = VPNHelpers.ExtAccountCreate(connectionName, connectionName);
                ret = VPNHelpers.ExtAccountCertSet(connectionName, this.txtVPNKey.Text.Trim(), this.txtVPNCert.Text.Trim());
                ret = VPNHelpers.ExtAccountConnect(connectionName);

                if (ret == 0)
                {
                    int i = 0;
                    while (i < 20)
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-13956
                        //// https://sofiamedix.atlassian.net/browse/MED-12981
                        //ret = VPNHelpers.ExtAccountStatusGet(this._connectionName);
                        ret = VPNHelpers.ExtAccountStatusGet(connectionName);
                        if (ret == 6)
                        {
                            break;
                        }

                        // Authentication failed
                        if (ret == 4)
                        {
                            this.lbErrMsg.Text = XMsg.GetMsg("MSG017");
                            break;
                        }

                        Thread.Sleep(300);
                    }
                }

                // Connect succeeded(6) or already connected(35)
                if (ret == 6 || ret == 35)
                {
                    lock (_lockObj)
                    {
                        Monitor.Wait(_lockObj, 6000);
                    }

                    // Connected OK!
                    this.lbErrMsg.Text = XMsg.GetMsg("MSG016");

                    // Stored cert
                    // https://sofiamedix.atlassian.net/browse/MED-13956
                    CacheService.Instance.Set(VPNHelpers.VPN_CERT + this._hospCode, this.txtVPNCert.Text.Trim(), TimeSpan.MaxValue);
                    CacheService.Instance.Set(VPNHelpers.VPN_KEY + this._hospCode, this.txtVPNKey.Text.Trim(), TimeSpan.MaxValue);
                    // Lastest connected connection name
                    CacheService.Instance.Set(VPNHelpers.VPN_CONN_KEY + this._hospCode, connectionName, TimeSpan.MaxValue);
                    CacheService.Instance.Set(VPNHelpers.VPN_CONN_KEY, connectionName, TimeSpan.MaxValue); // for others which contains no hosp_code

                    // https://sofiamedix.atlassian.net/browse/MED-14015
                    CacheService.Instance.Set("VPN_USER_ID", this.txtUserID.Text.Trim(), TimeSpan.MaxValue);
                }
                else
                {
                    // Failed to connect
                    this.lbErrMsg.Text = XMsg.GetMsg("MSG017");
                    VPNHelpers.ExtAccountDisconnect(connectionName);
                }
            }
            catch (Exception ex)
            {
                // Failed to connect
                this.lbErrMsg.Text = XMsg.GetMsg("MSG017");

                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally
            {
            }
        }

        #endregion

        #region Methods(private)

        private void ApplyMultiLanguages()
        {
            try
            {
                this.Text = XMsg.GetField("btnSettingVPN.Text");
                this.lbVPNInfo.Text = XMsg.GetField("lbVPNInfo.Text");
                this.lbVPNCert.Text = XMsg.GetField("lbVPNCert.Text");
                this.lbVPNKey.Text = XMsg.GetField("lbVPNKey.Text");
                this.btnSave.Text = XMsg.GetField("btnSave.Text");
                this.btnCancel.Text = XMsg.GetField("F017");
                this.btnTestConnection.Text = XMsg.GetField("btnTestConnection.Text");
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private void UpdateSetting()
        {

        }

        #endregion
    }
}