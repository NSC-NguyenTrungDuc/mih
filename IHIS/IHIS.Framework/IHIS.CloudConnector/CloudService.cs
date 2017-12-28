using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Threading;
using IHIS.CloudConnector.Contracts.Arguments;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Events;
using IHIS.CloudConnector.Mappings;
using IHIS.CloudConnector.Socket;
using ProtoBuf;
using WebSocket4Net;
using System.Timers;
using IHIS.CloudConnector.Contracts.Arguments.System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.CloudConnector
{
    public delegate Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CacheCallback<TR, TA>(TA args, TR result);
    public class CloudService
    {
        private static readonly CloudService _instance = new CloudService();
        private readonly WebSocketClient _socketClient;
        private bool useVpn = false;
        private readonly object _globalLock = new object();
        private long _messageCounter = 0;
        private readonly Dictionary<long, Tuple<object, RpcResult>> _syncMessages = new Dictionary<long, Tuple<object, RpcResult>>();
        private readonly Dictionary<object, KeyValuePair<int, object>> cacheOnce = new Dictionary<object, KeyValuePair<int, object>>();
        private static readonly MethodInfo MapMethod = GetMapMethod();
        private readonly Dictionary<string, long> _timeoutSpecial;
        private bool isInformed = false;


        private static MethodInfo GetMapMethod()
        {
            foreach (MethodInfo method in typeof(Mapper).GetMethods())
            {
                if (method.GetParameters().Length == 2 && method.IsGenericMethod && method.Name.Equals("Map"))
                {
                    return method;
                }
            }
            throw new InvalidOperationException("Can't find method Map");
        }

        public static CloudService Instance
        {
            get { return _instance; }
        }

        private CloudService()
        {
            // socketClient = new WebSocketClient(Logs.GetConfigString("CLOUD", "URL", "ws://localhost:8890"), Logs.GetConfigString("CLOUD", "SERVICE", "MED"), Logs.GetConfigString("CLOUD", "VERSION", "1234"));
            Console.WriteLine("Init CloudService instance");
            // _socketClient = new WebSocketClient(Logs.GetConfigString("CLOUD", "URL", "wss://nfx.posismo.com:8890"), Logs.GetConfigString("CLOUD", "SERVICE", "Socket"), Logs.GetConfigString("CLOUD", "VERSION", "38868"));

            // MED-10181
            //String socketUrl = ConfigurationManager.AppSettings["SocketUrl"];
            useVpn = UserInfo.VpnYn;
            String socketUrl = Utility.Utility.GetConfig("SocketUrl", UserInfo.VpnYn);

            _socketClient = new WebSocketClient(socketUrl);
            _timeoutSpecial = Utility.Utility.CreateTimeOutSpecial();

            EventAggregator.Instance.Subscribe<ConnectionEvent>(OnConnectionStatusChanged);
            EventAggregator.Instance.Subscribe<RpcResult>(OnMessageReceived);
 
        }

        public void EnsureVpnYn()
        {
            string vpn = Utility.Utility.GetConfig("SocketUrl", true);
            string novpn = Utility.Utility.GetConfig("SocketUrl", false);

            if (vpn == novpn)
            {
                _socketClient.DisConnect();
            }
            if (UserInfo.VpnYn != useVpn)
            {
                useVpn = UserInfo.VpnYn;
                String socketUrl = Utility.Utility.GetConfig("SocketUrl", UserInfo.VpnYn);
                _socketClient.Connect(socketUrl, true);
            }
        }

        private void OnMessageReceived(RpcResult rpcResult)
        {
            if (_syncMessages.ContainsKey(rpcResult.Id))
            {
                Tuple<object, RpcResult> result;
                _syncMessages.TryGetValue(rpcResult.Id, out result);
                if (result != null)
                {
                    result.Value2 = rpcResult;
                    lock (result.Value1)
                    {
                        Monitor.PulseAll(result.Value1);
                    }
                }
            }
        }

        private void OnConnectionStatusChanged(ConnectionEvent connectionEvent)
        {
            if (connectionEvent.Status != ConnectionStatus.Connecting && connectionEvent.Status != ConnectionStatus.Disconnecting)
                lock (_globalLock)
                {
                    Monitor.PulseAll(_globalLock);
                }
        }

        public bool Connect()
        {
            try
            {
                ConnectionStatus status = _socketClient.Connect();
                if (status != ConnectionStatus.Connected)
                {
                    lock (_globalLock)
                    {
                        Logs.WriteLog("Connecting to server...");
                        Monitor.Wait(_globalLock,
                            new TimeSpan(int.Parse(ConfigurationManager.AppSettings["ConnectionTimeout"])));
                    }
                }
                Logs.WriteLog("Connected");
                return _socketClient.Status == ConnectionStatus.Connected;
            }
            catch (Exception e)
            {
                Logs.WriteLog("Exception: " + e.StackTrace);
                return false;
            }
        }

        public TR Submit<TR, TA>(TA args)
            where TR : IContractResult
            where TA : class, IContractArgs {
                return Submit<TR, TA>(args, false);
        }

        private Dictionary<object, object> cache = new Dictionary<object, object>();

        public bool MemoryCacheContainsKey<TA>(TA args)
            where TA : class, IContractArgs
        {
            return cache.ContainsKey(args);
        }

        public TR Submit<TR, TA>(TA args, bool inMemoryCache)
            where TR : IContractResult
            where TA : class, IContractArgs {
                return Submit<TR, TA>(args, inMemoryCache, null);
        }

        public TR Submit<TR, TA>(TA args, bool inMemoryCache, CacheCallback<TR, TA> callback)
            where TR : IContractResult
            where TA : class, IContractArgs
        {
            if (inMemoryCache && cache.ContainsKey(args)) {
                return (TR)cache[args];
            }

            if (cacheOnce.ContainsKey(args))
            {
                KeyValuePair<int, object> keyValuePair = cacheOnce[args];
                TR r = (TR) keyValuePair.Value;
                cacheOnce.Remove(args);
                int keyNew = keyValuePair.Key - 1;
                if (keyNew > 0)
                {
                    KeyValuePair<int, object> keyValuePairNew = new KeyValuePair<int, object>(keyNew, keyValuePair.Value);
                    cacheOnce.Add(args, keyValuePairNew);
                }
                return r;
            }

            if (!isInformed)
            {
                if (!IsInternetConnected())
                {
                    if (NetInfo.Language == LangMode.Jr)
                    {
                        MessageBox.Show("インターネットとの接続に失敗しました。登録していないデータが失われた可能性があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lost internet connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.isInformed = true;
                } 
            }

            Tuple<object, RpcResult> result = null;
            try
            {
                if (_socketClient.GetWebsocketState() == WebSocketState.Closed)
                {
                    CloudService.Instance.Connect();
                    if (_socketClient.GetWebsocketState() == WebSocketState.Closed)
                    {
                        return Activator.CreateInstance<TR>();
                    }
                    else
                    {
                        AdmLoginFormCheckLoginUserArgs argsa = new AdmLoginFormCheckLoginUserArgs();
                        argsa.User = UserInfo.UserID;
                        argsa.Password = UserInfo.UserPswd;
                        AdmLoginFormCheckLoginUserResult res = CloudService.Instance.Submit<AdmLoginFormCheckLoginUserResult, AdmLoginFormCheckLoginUserArgs>(argsa);
                    }
                }

                IExtensible request = args.GetRequestInstance();
                MethodInfo newMethod = MapMethod.MakeGenericMethod(request.GetType(), typeof(TA));
                newMethod.Invoke(Mapper.Instance, new object[] { request, args });
                long messageId = Interlocked.Increment(ref _messageCounter);
                object _lock = new object();
                _syncMessages.Add(messageId, new Tuple<object, RpcResult>(_lock, null));
                lock (_lock)
                {
                    Logs.WriteLog("[SEND] - " + args.GetType());
                    _socketClient.Send(request, messageId);
                    if (_timeoutSpecial.ContainsKey(request.GetType().Name))
                    {
                        long timeout;
                        _timeoutSpecial.TryGetValue(request.GetType().Name, out timeout);
                        Monitor.Wait(_lock, new TimeSpan(timeout));
                    }
                    else
                    {
                        Monitor.Wait(_lock, new TimeSpan(Convert.ToInt64(ConfigurationManager.AppSettings["RequestTimeout"])));
                    }
                }
                _syncMessages.TryGetValue(messageId, out result);
                _syncMessages.Remove(messageId);
                if (result == null || result.Value2 == null)
                {
                    Logs.WriteLog("[RECEIVE] - Result is NULL");
                    return Activator.CreateInstance<TR>();
                }

                // write log
                StringBuilder logReceiveMsgSb = new StringBuilder("[RECEIVE] - ");
                if (result.Value2.GetPayload<TR>().ExecutionStatus == ExecutionStatus.Success)
                    logReceiveMsgSb.Append("SUCCESS");
                else if (result.Value2.GetPayload<TR>().ExecutionStatus == ExecutionStatus.Failure)
                    logReceiveMsgSb.Append("FAILURE");
                else if (result.Value2.GetPayload<TR>().ExecutionStatus == ExecutionStatus.Timeout)
                    logReceiveMsgSb.Append("TIMEOUT");
                else logReceiveMsgSb.Append("UNKNOWN");
                logReceiveMsgSb.Append(" - ");
                logReceiveMsgSb.Append(result.Value2.GetPayload<TR>().GetType());
                Logs.WriteLog(logReceiveMsgSb.ToString());
                TR r = result.Value2.GetPayload<TR>();
                if (inMemoryCache) {
                    cache.Add(args, r);
                }

                // https://sofiamedix.atlassian.net/browse/MED-12344
                if (r.ExecutionStatus == ExecutionStatus.Maintainance)
                {
                    string msg = "";
                    string cap = "";

                    switch (NetInfo.Language)
                    {
                        case LangMode.En:
                            msg = "System is in maintenance mode. It only support to read data.";
                            cap = "Warning!";
                            break;
                        case LangMode.Jr:
                            msg = "ただいまメンテナンス中ですので書き込みはできません。" + Environment.NewLine + "過去に記録したデータの参照は可能です。";
                            cap = "警告!";
                            break;
                        case LangMode.Vi:
                            msg = "Hệ thống đang bảo trì nên chỉ hỗ trợ đọc dữ liệu.";
                            cap = "Cảnh báo!";
                            break;
                    }

                    MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (callback != null && r.ExecutionStatus == ExecutionStatus.Success)
                {
                    Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = callback(args, r);
                    if (cacheData != null)
                    {
                        foreach (KeyValuePair<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> pair in cacheData)
                        {
                            foreach (KeyValuePair<object, KeyValuePair<int, object>> sp in pair.Value)
                            {
                                IContractResult res = (IContractResult)sp.Value.Value;
                                res.ExecutionStatus = ExecutionStatus.Success;
                                KeyValuePair<int, object> kpPair = new KeyValuePair<int, object>(sp.Value.Key, res);
                                if (pair.Key == CachePolicy.ONCE)
                                {
                                    if (cacheOnce.ContainsKey(sp.Key))
                                    {
                                        cacheOnce.Remove(sp.Key);
                                    }
                                    cacheOnce.Add(sp.Key, kpPair);
                                }
                                if (pair.Key == CachePolicy.SESSION && !cache.ContainsKey(sp.Key)) cache.Add(sp.Key, res);
                            }
                        }
                    }
                }
                return r;
            }
            catch (Exception e)
            
            {
                Logs.WriteLog("Exception: " + e.StackTrace);
                if (result == null || result.Value2 == null)
                {
                    return Activator.CreateInstance<TR>();
                }
                return result.Value2.GetPayload<TR>();
            }

            //return result.Value2.GetPayload<TR>();
        }

        public void Execute<TA>(TA args)
            where TA : class, IContractArgs
        {
            IExtensible request = args.GetRequestInstance();
            MethodInfo newMethod = MapMethod.MakeGenericMethod(request.GetType(), typeof(TA));
            newMethod.Invoke(Mapper.Instance, new object[] { request, args });
            //Mapper.Instance.Map(request, args);
            _socketClient.Send(request, Interlocked.Increment(ref _messageCounter));
        }

        private static int ERROR_SUCCESS = 0;
        public static bool IsInternetConnected()
        {
            int dwConnectionFlags = 0;
            if (!InternetGetConnectedState(out dwConnectionFlags, 0))
                return false;

            if (InternetAttemptConnect(0) != ERROR_SUCCESS)
                return false;

            return true;
        }


        [DllImport("wininet.dll", SetLastError = true)]
        public static extern int InternetAttemptConnect(uint res);


        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetConnectedState(out int flags, int reserved);
    }

    class Tuple<T1, T2>
    {
        private T1 _value1;
        private T2 _value2;

        public Tuple(T1 value1, T2 value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        public T1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }

        public T2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
    }

    public enum CachePolicy {
        ONCE,
        SESSION
    }
}