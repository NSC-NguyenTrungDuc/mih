using System;
using System.IO;
using System.Net;
using System.Reflection;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Events;
using IHIS.CloudConnector.Messaging;
//using IHIS.Framework;
using System.Collections.Generic;
using ProtoBuf;
using WebSocket4Net;
using ErrorEventArgs = SuperSocket.ClientEngine.ErrorEventArgs;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using Snappy;
using IHIS.Framework;

namespace IHIS.CloudConnector.Socket
{
    public class WebSocketClient
    {
        private static readonly MethodInfo DeserializeMethod = typeof(Serializer).GetMethod("Deserialize");
        private String _socketUrl;
        private WebSocket _websocket;
        private ConnectionStatus _status;
        private static String _sessionId;
        private readonly Dictionary<string, string> _servicesMap;
        private static readonly object lockObject = new object();
        private static readonly object lockStatus = new object();

        public static String SessionId
        {
            set { _sessionId = value; }
            get { return _sessionId; }
        }

        public WebSocketClient(string socketUrl)
        {
            _socketUrl = socketUrl;
            _status = ConnectionStatus.Disconnected;
            _servicesMap = Utility.Utility.CreateServicesMap();
        }

        public string SocketUrl
        {
            get { return _socketUrl; }
        }

        public ConnectionStatus Status
        {
            get { return _status; }
        }

        public ConnectionStatus Connect(string socketUrl, bool force)
        {
            if (_socketUrl == null || !_socketUrl.Equals(socketUrl) || force)
            {
                DisConnect();
                _socketUrl = socketUrl;
            }
            if (_status == ConnectionStatus.Disconnected)
            {
                _websocket = new WebSocket(_socketUrl);
                _websocket.Opened += websocket_Opened;
                _websocket.Error += websocket_Error;
                _websocket.Closed += websocket_Closed;
                _websocket.DataReceived += websocket_DataReceived;
                _websocket.MessageReceived += _websocket_MessageReceived;
                _websocket.Open();
                _status = ConnectionStatus.Connecting;
                ConnectionEvent eEvent = new ConnectionEvent(_status);
                EventAggregator.Instance.Publish(eEvent);
            }
            return _status;
        }

        public ConnectionStatus Connect()
        {
            return Connect(_socketUrl, false);
        }

        public void DisConnect()
        {
            if (_status != ConnectionStatus.Disconnected)
            {
                _status = ConnectionStatus.Disconnecting;
                try
                {
                    lock (lockObject)
                    {
                        _websocket.Close();

                        Monitor.Wait(lockObject, 5000);
                    }
                }
                catch (Exception e)
                {
                    
                    Logs.WriteLog(e.Message);
                    Logs.WriteLog(e.StackTrace);
                }
                finally { }
            }
        }

        private void _websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine("Message recieved: {0}", e.Message);
        }

        public void websocket_DataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                Console.WriteLine("Data recieved: {0}", e.Data);
                MemoryStream stream = new MemoryStream(e.Data);
                RpcMessage message = Serializer.Deserialize<RpcMessage>(stream);

                Console.WriteLine("Payload Class: {0}", message.payload_class);

                // https://sofiamedix.atlassian.net/browse/MED-8157
                //byte[] payloadData = message.compress ? SnappyCodec.Uncompress(message.payload_data, 0, message.payload_data.Length) : message.payload_data;
                byte[] payloadData = message.compress ? Snappy.Sharp.Snappy.Uncompress(message.payload_data) : message.payload_data;

                Object payload = RpcMessage.Result.SUCCESS == message.result ? ParsePayload(payloadData, message.payload_class) : null;
                //Console.WriteLine(payload.ToString());

                if (payload != null && _sessionId == null && payload.GetType().IsAssignableFrom(typeof(AdmLoginFormCheckLoginUserResponse)))
                {
                    AdmLoginFormCheckLoginUserResponse response = (AdmLoginFormCheckLoginUserResponse)payload;
                    if (!string.IsNullOrEmpty(response.session_id))
                    {
                        _sessionId = response.session_id;
                    }
                }

                RpcResult result = new RpcResult(message.source_id, (int)message.result, payload);
                EventAggregator.Instance.Publish(result);
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("WebsocketClient.DataReceive error. Message: " + ex.Message);
                Logs.EndWriteLog();
            }
        }

        public void websocket_Closed(object sender, EventArgs e)
        {
            Logs.WriteLog("Connection closed.");
            //Console.WriteLine("Connection Closed");
            _status = ConnectionStatus.Disconnected;
            lock (lockObject)
            {
                Monitor.PulseAll(lockObject);
            }
            ConnectionEvent eEvent = new ConnectionEvent(_status);
            EventAggregator.Instance.Publish(eEvent);
        }

        public void websocket_Error(object sender, ErrorEventArgs e)
        {
            //Console.WriteLine("Error: {0}", e.Exception);
            //Logs.WriteLog(Thread.CurrentThread.ToString() + " connection error. Message: " + e.Exception.ToString());
            Logs.WriteLog(" connection error. Message: " + e.Exception.ToString());
            //throw new Exception("Websocket connection error. Message: " + e.Exception.InnerException.Message);
        }

        public void websocket_Opened(object sender, EventArgs e)
        {
            //Console.WriteLine("Connection Connected");
            Logs.WriteLog("Connection opened.");
            _status = ConnectionStatus.Connected;
            lock (lockStatus)
            {
                Monitor.PulseAll(lockStatus);
            }
            if (!string.IsNullOrEmpty(_sessionId))
            {
                AdmLoginOnBehalfOfRequest request = new AdmLoginOnBehalfOfRequest();
                request.session_id = _sessionId;
                Send<AdmLoginOnBehalfOfRequest>(request, 0L);
            }
            ConnectionEvent eEvent = new ConnectionEvent(_status);
            EventAggregator.Instance.Publish(eEvent);
        }

        public void Send<T>(T payloadData, long messageId) where T : IExtensible
        {
            try
            {
                if (_status != ConnectionStatus.Connected)
                {
                    lock (lockStatus)
                    {
                        Monitor.Wait(lockStatus, 5000);
                    }
                    if (_status != ConnectionStatus.Connected)
                    {
                        Logs.WriteLog(string.Format("Timedout while connecting to websocket {0}", _socketUrl));
                        RpcResult result = new RpcResult(messageId, 99, null);
                        EventAggregator.Instance.Publish(result);
                    }
                }

                String payloadClass = payloadData.GetType().Name;
                string service = _servicesMap[payloadClass];
                RpcMessage message = new RpcMessage();
                message.service = service;
                message.version = "1.0.0";
                message.payload_class = payloadClass;
                message.id = messageId;
                message.client_id = Utility.Utility.GetMacAddress() + "-" + messageId;
                // write log
                Logs.WriteLog("ClientID - " + message.client_id);

                MemoryStream stream = new MemoryStream();
                Serializer.Serialize(stream, payloadData);

                // 2016.03.14
                // https://sofiamedix.atlassian.net/browse/MED-8157
                //message.payload_data = stream.ToArray();
                byte[] sendBytes = stream.ToArray();
                bool compress = Boolean.Parse(ConfigurationManager.AppSettings.Get("Compress"));
                int compressThreshold = Int32.Parse(ConfigurationManager.AppSettings.Get("CompressThreshold"));
                bool compression = compress && sendBytes.Length >= compressThreshold;
                //message.payload_data = compression ? SnappyCodec.Compress(sendBytes, 0, sendBytes.Length) : sendBytes;

                message.payload_data = compression && payloadClass != "AdmLoginOnBehalfOfRequest" ? Snappy.Sharp.Snappy.Compress(sendBytes) : sendBytes;
                message.compress = compression;
                stream = new MemoryStream();
                Serializer.Serialize(stream, message);
                byte[] data = stream.ToArray();

                try
                {
                    _websocket.Send(data, 0, data.Length);
                }
                catch (Exception e)
                {
                    //int a = 0;
                    Logs.WriteLog(compress.ToString());
                    Logs.WriteLog(compressThreshold.ToString());
                    Logs.WriteLog(e.Message);
                    Logs.WriteLog(e.StackTrace);
                }
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("WebsocketClient.Send error. Message: " + ex.Message);
                Logs.EndWriteLog();
            }
        }

        private Object ParsePayload(byte[] data, String payloadClass)
        {
            if (null == data || null == payloadClass) return null;
            MemoryStream stream = new MemoryStream(data);
            MethodInfo newMethod =
                DeserializeMethod.MakeGenericMethod(Type.GetType("IHIS.CloudConnector.Messaging." + payloadClass));
            return newMethod.Invoke(null, new object[] { stream });
        }

        public WebSocketState GetWebsocketState()
        {
            return _websocket.State;
        }
    }
}