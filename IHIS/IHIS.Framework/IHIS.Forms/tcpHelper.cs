using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace IHIS.Framework
{
    /// <summary>
    /// TcpSendType enum (Tcp send byte include type)
    /// </summary>
    public enum TcpSendType
    {
        /// <summary>
        /// include data byte count
        /// </summary>
        SetByteCnt,
        /// <summary>
        /// include out data byte count
        /// </summary>
        NonSetByteCnt
    }

    /// <summary>
    /// tcp/ip socket 통신을 통해 메세지 send하기 위한 클래스
    /// </summary>
    public class tcpHelper
    {
        // base Encoding을 따라감.
        private Encoding encoding = Service.BaseEncoding;
        	
        #region socket connect
        /// <summary>
        /// tcp/ip 통신 연결
        /// </summary>
        public Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            //IPHostEntry hostEntry = null;
            IPAddress[] addressList;

            // Get host related information.
            //hostEntry = Dns.GetHostEntry(server);
            addressList = Dns.GetHostAddresses(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            //foreach (IPAddress ipa in hostEntry.AddressList)
            foreach (IPAddress ipa in addressList)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPEndPoint ipe = new IPEndPoint(ipa, port);
                    Socket tempSocket =
                        new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    tempSocket.Connect(ipe);

                    if (tempSocket.Connected)
                    {
                        s = tempSocket;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return s;
        }
        #endregion

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(string ip, int port, string data)
        {
            try
            {
                Socket s = ConnectSocket(ip, port);

                int retVal = Send(s, encoding.GetBytes(data));

                s.Close();

                return retVal;
            }
            catch (SocketException se)
            {
                XMessageBox.Show("ErrorCode[" + se.ErrorCode + "]:" + se.Message);
                return -1;
            }
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(string ip, int port, byte[] dataBytes)
        {
            try
            {
                Socket s = ConnectSocket(ip, port);

                if (s == null)
                    return -1;
                byte[] buffer = new byte[dataBytes.Length + 5];
                encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
                Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);

                int retVal = s.Send(buffer, buffer.Length, 0) - 5;

                s.Close();

                return retVal;
            }
            catch (SocketException se)
            {
                XMessageBox.Show("ErrorCode[" + se.ErrorCode + "]:" + se.Message);
                return -1;
            }
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(Socket s, string data)
        {
            return Send(s, encoding.GetBytes(data));
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(Socket s, byte[] dataBytes)
        {
            if (s == null)
                return -1;
            byte[] buffer = new byte[dataBytes.Length + 5];
            encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
            Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);
            return s.Send(buffer, buffer.Length, 0) - 5;
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(string ip, int port, string data, TcpSendType tst)
        {
            try
            {
                Socket s = ConnectSocket(ip, port);

                if (TcpSendType.SetByteCnt == tst)
                {
                    int retVal = Send(s, encoding.GetBytes(data));
                    s.Close();
                    return retVal;
                }
                else
                {
                    int retVal = Send(s, encoding.GetBytes(data), TcpSendType.NonSetByteCnt);
                    s.Close();
                    return retVal;
                }
            }
            catch (SocketException se)
            {
                XMessageBox.Show("ErrorCode[" + se.ErrorCode + "]:" + se.Message);
                return -1;
            }
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(string ip, int port, byte[] dataBytes, TcpSendType tst)
        {
            try
            {
                Socket s = ConnectSocket(ip, port);

                if (s == null)
                    return -1;
                if (TcpSendType.SetByteCnt == tst)
                {
                    byte[] buffer = new byte[dataBytes.Length + 5];
                    encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
                    Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);
                    return s.Send(buffer, buffer.Length, 0) - 5;
                }
                else
                {
                    return s.Send(dataBytes);
                }
            }
            catch (SocketException se)
            {
                XMessageBox.Show("ErrorCode[" + se.ErrorCode + "]:" + se.Message);
                return -1;
            }
        }


        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(Socket s, string data, TcpSendType tst)
        {
            if (TcpSendType.SetByteCnt == tst)
                return Send(s, encoding.GetBytes(data));
            else
                return Send(s, encoding.GetBytes(data), TcpSendType.NonSetByteCnt);
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(Socket s, byte[] dataBytes, TcpSendType tst)
        {
            if (s == null)
                return -1;
            if (TcpSendType.SetByteCnt == tst)
            {
                byte[] buffer = new byte[dataBytes.Length + 5];
                encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
                Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);
                return s.Send(buffer, buffer.Length, 0) - 5;
            }
            else
            {
                return s.Send(dataBytes);
            }
        }


        #region 인코딩 방식 추가 send method overloading
        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(string ip, int port, string data, Encoding ecd)
        {
            try
            {
                Socket s = ConnectSocket(ip, port);
                if ( ecd != null ) encoding = ecd;

                int retVal = Send(s, encoding.GetBytes(data));
                s.Close();
                return retVal;
            }
            catch (SocketException se)
            {
                XMessageBox.Show("ErrorCode[" + se.ErrorCode + "]:" + se.Message);
                return -1;
            }
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(string ip, int port, byte[] dataBytes, Encoding ecd)
        {
            try
            {
                Socket s = ConnectSocket(ip, port);
                if (ecd != null) encoding = ecd;
                
                if (s == null)
                    return -1;
                byte[] buffer = new byte[dataBytes.Length + 5];
                encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
                Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);

                int retVal = s.Send(buffer, buffer.Length, 0) - 5;
                s.Close();
                return retVal;
            }
            catch (SocketException se)
            {
                XMessageBox.Show("ErrorCode[" + se.ErrorCode + "]:" + se.Message);
                return -1;
            }
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(Socket s, string data, Encoding ecd)
        {
            if (ecd != null) encoding = ecd;
                
            return Send(s, encoding.GetBytes(data));
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(Socket s, byte[] dataBytes, Encoding ecd)
        {
            if (s == null)
                return -1;
            byte[] buffer = new byte[dataBytes.Length + 5];
            if (ecd != null) encoding = ecd;
            
            encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
            Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);
            return s.Send(buffer, buffer.Length, 0) - 5;
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(string ip, int port, string data, TcpSendType tst, Encoding ecd)
        {
            try
            {
                Socket s = ConnectSocket(ip, port);
                if (ecd != null) encoding = ecd;

                if (TcpSendType.SetByteCnt == tst)
                {
                    int retVal = Send(s, encoding.GetBytes(data));
                    s.Close();
                    return retVal;
                }
                else
                {
                    int retVal = Send(s, encoding.GetBytes(data), TcpSendType.NonSetByteCnt);
                    s.Close();
                    return retVal;
                }
            }
            catch (SocketException se)
            {
                XMessageBox.Show("ErrorCode[" + se.ErrorCode + "]:" + se.Message);
                return -1;
            }
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(string ip, int port, byte[] dataBytes, TcpSendType tst, Encoding ecd)
        {
            try
            {
                Socket s = ConnectSocket(ip, port);

                if (s == null)
                    return -1;
                if (TcpSendType.SetByteCnt == tst)
                {
                    byte[] buffer = new byte[dataBytes.Length + 5];
                    if (ecd != null) encoding = ecd;
                    encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
                    Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);
                    int retVal = s.Send(buffer, buffer.Length, 0) - 5;
                    s.Close();
                    return retVal;
                }
                else
                {
                    int retVal = s.Send(dataBytes);
                    s.Close();
                    return retVal;
                }
            }
            catch (SocketException se)
            {
                XMessageBox.Show("ErrorCode[" + se.ErrorCode + "]:" + se.Message);
                return -1;
            }
        }


        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(Socket s, string data, TcpSendType tst, Encoding ecd)
        {
            if (ecd != null) encoding = ecd;
            if (TcpSendType.SetByteCnt == tst)
                return Send(s, encoding.GetBytes(data));
            else
                return Send(s, encoding.GetBytes(data), TcpSendType.NonSetByteCnt);
        }

        /// <summary>
        /// tcp/ip socket 통신을 통해 메세지 send
        /// </summary>
        public int Send(Socket s, byte[] dataBytes, TcpSendType tst, Encoding ecd)
        {
            if (s == null)
                return -1;
            if (TcpSendType.SetByteCnt == tst)
            {
                byte[] buffer = new byte[dataBytes.Length + 5];
                if (ecd != null) encoding = ecd;
                encoding.GetBytes(dataBytes.Length.ToString().PadLeft(5, '0'), 0, 5, buffer, 0);
                Array.Copy(dataBytes, 0, buffer, 5, dataBytes.Length);

                int retVal = s.Send(buffer, buffer.Length, 0) - 5;
                s.Close();
                return retVal;
            }
            else
            {
                int retVal = s.Send(dataBytes);
                s.Close();
                return retVal;
            }
        }
        #endregion



        private byte[] Recv(Socket s)
        {
            if (s == null)
                return null;

            byte[] lenBuffer = new byte[5];
            int len = 0;
            try
            {
                len = s.Receive(lenBuffer, 0, lenBuffer.Length, 0);
            }
            catch (SocketException se)
            {
                XMessageBox.Show(se.ErrorCode.ToString());
                XMessageBox.Show(se.Message);
            }
            if (len < 5)
                return null;
            int size = int.Parse(encoding.GetString(lenBuffer));
            byte[] buffer = new byte[size];
            int offset = 0;
            while (size > 0)
            {
                len = s.Receive(buffer, offset, size, SocketFlags.None);
                offset += len;
                size -= len;
            }
            return buffer;
        }

        private string RecvString(Socket s)
        {
            byte[] dataBytes = Recv(s);
            return encoding.GetString(dataBytes);
        }
    }
}



