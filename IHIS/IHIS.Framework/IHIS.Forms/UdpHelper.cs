using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Data;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.Framework
{
    public class UdpHelper
    {
        private static int mDefaultPort = 16021;
        private Encoding mEncoding = Service.JpEncoding;
        private static string mMsgDelim = "@";

        public static void BroadcateMessage(string aSenderId, string aData)
        {
            string cmd = " SELECT DISTINCT A.IP_ADDR "
                       + "   FROM ADM0600 A "
                       + "  WHERE A.MSG_TYPE = 'IMG' "
                       + "    AND TRUNC(A.REGI_TIME) = TRUNC(SYSDATE) ";

            DataTable ipTable = Service.ExecuteDataTable(cmd);

            if (ipTable != null && ipTable.Rows.Count > 0)
            {
                foreach ( DataRow ip in ipTable.Rows)
                    UdpHelper.SendMsg(UdpMsgType.IMG, "", "", "", "", "", ip["ip_addr"].ToString(), UdpHelper.mDefaultPort, aData);
            }
        }

        public static void SendMsgToID(string aSenderId, string aRecieverId, string aTitle, string aData)
        {
            string cmd = " SELECT DISTINCT A.IP_ADDR"
                       + "   FROM ADM3400 A "
                       + "  WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                       + "    AND A.USER_ID = '" + aRecieverId + "' "
                       + "    AND TRUNC(A.ENTR_TIME) = TRUNC(SYSDATE)" ;

            DataTable ipTable = Service.ExecuteDataTable(cmd);

            string senderName = UdpHelper.GetUserNm(aSenderId);
            string recieverName = UdpHelper.GetUserNm(aRecieverId);

            string data = senderName + UdpHelper.mMsgDelim
                        + aSenderId + UdpHelper.mMsgDelim
                        + recieverName + UdpHelper.mMsgDelim
                        + aRecieverId + UdpHelper.mMsgDelim
                        + aTitle + UdpHelper.mMsgDelim
                        + aData ;

            if (ipTable != null && ipTable.Rows.Count > 0)
            {
                foreach (DataRow ip in ipTable.Rows)
                {
                    UdpHelper.SendMsg(UdpMsgType.SMG, "", "", "ADMM", "", "MSGSEND", ip["ip_addr"].ToString(), UdpHelper.mDefaultPort, data);
                                     
                }
            }
        }

        public static void SendMsgToSystem(string aSender, string aSystemId, string aCommand, string aData)
        {
            string cmd = " SELECT DISTINCT A.IP_ADDR"
                       + "   FROM ADM3400 A "
                       + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                       + "    AND A.SYS_ID = '" + aSystemId + "' "
                       + "    AND TRUNC(A.ENTR_TIME) = TRUNC(SYSDATE)";

            DataTable ipTable = Service.ExecuteDataTable(cmd);

            string senderName = UdpHelper.GetUserNm(aSender);

            if (ipTable != null && ipTable.Rows.Count > 0)
            {
                foreach (DataRow ip in ipTable.Rows)
                {
                    UdpHelper.SendMsg(UdpMsgType.SMG, aSender, senderName, aSystemId, "", aCommand, ip["ip_addr"].ToString(), UdpHelper.mDefaultPort, aData);

                }
            }
        }

        public static void SendMsg      ( UdpMsgType aMsgType, string aSenderId, string aSenderName
                                 , string aSystemID   , string aScreenID, string aCommand
                                 , string aIP         , int aPort       , string aData)
        {
            try
            {
                string sendData = aMsgType.ToString()
                                + aIP.PadLeft(15, ' ')
                                + aSenderId.PadLeft(12, ' ')
                                + aSenderName.PadLeft(20, ' ')
                                + aSystemID.PadLeft(4, ' ')
                                + aScreenID.PadLeft(20, ' ')
                                + aCommand.PadLeft(10, ' ')
                                + aData;

                Byte[] sendByte = Service.JpEncoding.GetBytes(sendData);

                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                IPAddress broadcast = IPAddress.Parse(aIP.Trim());

                IPEndPoint ep = new IPEndPoint(broadcast, aPort);

                s.SendTo(sendByte, ep);

                s.Close();
            }
            catch
            {
            }
        }

        private static string GetUserNm ( string aUserId)
        {
            string cmd = " SELECT FN_ADM_LOAD_USER_NAME('" + aUserId + "' ) FROM SYS.DUAL";

            object name = Service.ExecuteScalar(cmd);

            if (name.ToString() != "")
            {
                return name.ToString();
            }

            return "";
        }

        #region // <<2013.12.23>> LKH : admm 화면이 아닌 곳에서 메세지 보내는 처리
        public static void SendMsgToID2(string aRecieverId, string aTitle, string aData)
        {
            SendMsgToID2(UserInfo.UserID.ToString(), "U", aRecieverId, aTitle, aData);
        }
        public static void SendMsgToID2(string aRecieverGubun, string aRecieverId, string aTitle, string aData)
        {
            SendMsgToID2(UserInfo.UserID.ToString(), aRecieverGubun, aRecieverId, aTitle, aData);
        }
        public static void SendMsgToID2(string aSenderId, string aRecieverGubun, string aRecieverId, string aTitle, string aData)
        {
            try
            {
                /*string spName = "PR_ADM_MESSAGE_CALL";
                //
                Hashtable inputList = new Hashtable();
                inputList.Add("I_USER_ID", aSenderId);
                inputList.Add("I_USER_TRM", "");
                inputList.Add("I_SENDER_ID", aSenderId);
                inputList.Add("I_MSG_TITLE", aTitle);
                inputList.Add("I_MSG_CONTENTS", aData);
                inputList.Add("I_SEND_ALL_CNFM_YN", "N");
                inputList.Add("I_RECVER_GUBUN", aRecieverGubun);
                inputList.Add("I_RECVER_ID", aRecieverId);
                //                
                Hashtable outputList = new Hashtable();
                //
                String errFlag = "X";
                String sendSeq = "";
                //
                Service.BeginTransaction();
                //
                if (!(Service.ExecuteProcedure(spName, inputList, outputList)))
                {
                    Service.RollbackTransaction();
                    throw new Exception(Service.ErrFullMsg);
                }
                //성공
                errFlag = outputList["O_ERR_FLAG"].ToString();
                sendSeq = outputList["T_SEND_SEQ"].ToString();

                Service.CommitTransaction();*/

                // Execute Procedure PR_ADM_MESSAGE_CALL
                String errFlag = "X";
                String sendSeq = "";
                AdmMessageCallArgs admMessageCallArgs = new AdmMessageCallArgs();
                admMessageCallArgs.SenderId = aSenderId;
                admMessageCallArgs.RecieverGubun = aRecieverGubun;
                admMessageCallArgs.RecieverId = aRecieverId;
                admMessageCallArgs.Title = aTitle;
                admMessageCallArgs.Data = aData;
                AdmMessageCallResult admMessageCallResult =
                    CloudService.Instance.Submit<AdmMessageCallResult, AdmMessageCallArgs>(admMessageCallArgs);
                if (admMessageCallResult != null)
                {
                    errFlag = admMessageCallResult.ErrFlag;
                    sendSeq = admMessageCallResult.SendSeq;
                }
                // End Execute Procedure

                if ("X".Equals(errFlag)) return;

                // Send Msg To ID
                UdpHelperSendMsgToID2Args helperSendMsgToId2Args = new UdpHelperSendMsgToID2Args();
                helperSendMsgToId2Args.SenderId = UserInfo.UserID;
                helperSendMsgToId2Args.SendSeq = sendSeq;
                UdpHelperSendMsgToID2Result helperSendMsgToId2Result =
                    CloudService.Instance.Submit<UdpHelperSendMsgToID2Result, UdpHelperSendMsgToID2Args>(
                        helperSendMsgToId2Args);
                if (helperSendMsgToId2Result != null)
                {
                    List<UdpHelperSendInfo> lstSendInfo = helperSendMsgToId2Result.SendInfo;
                    if (lstSendInfo != null && lstSendInfo.Count > 0)
                    {
                        foreach(UdpHelperSendInfo helperSendInfo in lstSendInfo)
                        {
                            Logs.WriteLog(String.Format("SendMsgToID[{0}][{1}][{2}][{3}]", helperSendInfo.SenderId, helperSendInfo.RecverId, helperSendInfo.MsgTitle, helperSendInfo.MsgContents));

                            string senderName = UdpHelper.GetUserNm(helperSendInfo.SenderId);
                            string recieverName = UdpHelper.GetUserNm(helperSendInfo.RecverId);

                            string data = senderName + UdpHelper.mMsgDelim
                                        + helperSendInfo.SenderId + UdpHelper.mMsgDelim
                                        + recieverName + UdpHelper.mMsgDelim
                                        + helperSendInfo.RecverId + UdpHelper.mMsgDelim
                                        + helperSendInfo.MsgTitle + UdpHelper.mMsgDelim
                                        + helperSendInfo.MsgContents;
                            UdpHelper.SendMsg(UdpMsgType.SMG, "", "", "ADMM", "", "MSGSEND", helperSendInfo.IpAddr, UdpHelper.mDefaultPort, data);
                        }
                    }
                }


                // TODO comment use connect cloud
                /*DataTable temp = null;
                BindVarCollection bindVar = new BindVarCollection(); ;
                bindVar.Clear();
                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar.Add("f_sender_id", UserInfo.UserID.ToString());
                bindVar.Add("f_send_seq", sendSeq);

                // 
                String cmd = @"SELECT A.SENDER_ID
                                    , A.MSG_TITLE
                                    , A.MSG_CONTENTS
                                    , B.RECVER_ID
                                 FROM ADM0710          B
                                    , adm0700          A
                                WHERE A.HOSP_CODE      = :f_hosp_code
                                  AND A.SEND_DT        = TRUNC(SYSDATE)
                                  AND A.SENDER_ID      = :f_sender_id
                                  AND A.SEND_SEQ       = :f_send_seq
                                  --
                                  AND B.HOSP_CODE      = A.HOSP_CODE
                                  AND B.SEND_DT        = A.SEND_DT
                                  AND B.SENDER_ID      = A.SENDER_ID
                                  AND B.SEND_SEQ       = A.SEND_SEQ
                              ";
                //
                temp = Service.ExecuteDataTable(cmd, bindVar);

                if (temp != null && temp.Rows.Count > 0)
                {
                    foreach (DataRow tRow in temp.Rows)
                    {
                        Logs.WriteLog(String.Format("SendMsgToID[{0}][{1}][{2}][{3}]", tRow["SENDER_ID"].ToString(), tRow["RECVER_ID"].ToString(), tRow["MSG_TITLE"].ToString(), tRow["MSG_CONTENTS"].ToString()));
                        //
                        IHIS.Framework.UdpHelper.SendMsgToID(tRow["SENDER_ID"].ToString(), tRow["RECVER_ID"].ToString(), tRow["MSG_TITLE"].ToString(), tRow["MSG_CONTENTS"].ToString());
                    }
                }*/
            }
            catch
            {
                throw new Exception();
            }
         }
        #endregion // <<2013.12.23>> LKH : admm 화면이 아닌 곳에서 메세지 보내는 처리

    }
}
