using System;
using System.Data;
using System.Data.Common;
using System.Net;
//
using System.Globalization;

namespace IHIS.Framework
{
    #region Enumerations
    public enum LangMode
    {
        /// <summary>
        /// 韓国語モード
        /// </summary>
        Ko,
        /// <summary>
        /// 日本語モード
        /// </summary>
        Jr,
        /// <summary>
        /// 英語モード
        /// </summary>
        En,
        /// <summary>
        /// ベトナム語モード
        /// </summary>
        Vi,
    }
    #endregion

    public class NetInfo
    {
        private static LangMode language;

        static NetInfo()
        {
            language = SetLangMode();
        }

        // <<2017.07.26>> DLL_CROSS START : DLL 의 교차참조 해결을 위함
        //                Forms.EnvironInfo 의 ClientIP 를 분리함
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
        // <<2017.07.26>> DLL_CROSS END

        public static LangMode Language
        {
            get { return language; }
            set { language = value; }
        }

        #region SetLangMode (언어Mode Set)
        public static LangMode SetLangMode()
        {
            switch (CultureInfo.CurrentUICulture.Name)
            {
                case "ja-JP":
                    language = LangMode.Jr;
                    break;
                case "en":
                    language = LangMode.En;
                    break;
                case "vi-VN":
                    language = LangMode.Vi;
                    break;
                default:
                    language = LangMode.Jr;
                    break;
            }
            //string mode = GetConfigString("LANG", "MODE", "Jr");
            ////언어모드 설정
            //NetInfo.Language = (mode == "Ko" ? LangMode.Ko : (mode == "Jr" ? LangMode.Jr : LangMode.En));
            return language;
        }
        #endregion SetLangMode (언어Mode Set)

    }
}
