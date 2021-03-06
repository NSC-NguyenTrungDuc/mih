using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;


namespace IHIS.Framework
{
    public class Logs
    {
        static Dictionary<String, String> strLogMsg = new Dictionary<String, String>();

        //// MED-14286
        ///// <summary>
        ///// Arial, 8.75f
        ///// </summary>
        //public static readonly Font COMMON_FONT = new Font("Arial", 8.75f);

        #region [ErrWriteLog]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMsg"></param>
        public static void ErrWriteLog(string aLogMsg)
        {
            WriteLog(null, null, ".err", aLogMsg);
            //WriteLog(null, null, ".log", String.Format("[ERROR]{0}", aLogMsg));
        }

        public static void ErrWriteLog(string aFileTag, string aLogMsg)
        {
            WriteLog(null, aFileTag, ".err", aLogMsg);
            //WriteLog(null, aFileTag, ".log", String.Format("[ERROR]{0}", aLogMsg));
        }
        public static void ErrWriteLog(string aPathName, string aFileTag, string aLogMsg)
        {
            WriteLog(aPathName, aFileTag, ".err", aLogMsg);
            //WriteLog(aPathName, aFileTag, ".log", String.Format("[ERROR]{0}", aLogMsg));
        }
        #endregion

        #region [StartWriteLog] public
        /// <summary>
        /// 2016.01.27 AnhNV added
        /// </summary>
        public static void StartWriteLog()
        {
            WriteLog(null, null, ".log", "==============================================================================");
        }
        #endregion

        #region [EndWriteLog] public
        /// <summary>
        /// 2016.01.27 AnhNV added
        /// </summary>
        public static void EndWriteLog()
        {
            WriteLog(null, null, ".log", "==============================================================================");
        }
        #endregion

        #region [WriteLog] public
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMsg"></param>
        public static void WriteLog(string aLogMsg)
        {
            WriteLog(null, null, ".log", aLogMsg);
        }
        /*
        public static void WriteLog(string logMsg)
        {
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
        }
        */

        public static void WriteLog(string aFileTag, string aLogMsg)
        {
            WriteLog(null, aFileTag, ".log", aLogMsg);
        }
        public static void WriteLog(string aPathName, string aFileTag, string aLogMsg)
        {
            WriteLog(aPathName, aFileTag, ".log", aLogMsg);
        }
        #endregion [WriteLog] public

        #region [WriteLog] private -> public
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPath"></param>
        /// <param name="aLogFileTag"></param>
        /// <param name="aFileExt"></param>
        /// <param name="aLogMsg"></param>
        //private static void WriteLog(string aPath, string aFileTag, string aFileExt, string aLogMsg)
        public static void WriteLog(string aPath, string aFileTag, string aFileExt, string aLogMsg)
        {
            Object lockObject = new Object();
            String logIndex = "";

            try
            {
                string today = DateTime.Now.ToString("yyyyMMdd");
                //string today = DateTime.Now.ToString("yyyyMMdd-HH");

                string pathName = "";
                string fileName = "";

                if (aPath == null)
                {
                    //pathName = AppDomain.CurrentDomain.BaseDirectory;
                    pathName = Application.StartupPath + "\\" + "debug";
                }
                else
                {
                    pathName = aPath;
                }

                if (aFileTag == null)
                {
                    fileName = pathName + "\\" + today + "-" + "IHIS" + aFileExt;
                    //fileName = pathName + "\\" + today + "-" + "KCCK" + aFileExt;
                }
                else
                {
                    fileName = pathName + "\\" + today + "-" + aFileTag + aFileExt;
                }

                if (!Directory.Exists(pathName))
                {
                    Directory.CreateDirectory(pathName);
                }

                // This text is added only once to the file.
                lock (lockObject)
                {
                    if (aFileTag == null || aFileTag.Length == 0) aFileTag = "NULL";
                    logIndex = aFileTag + aFileExt;

                    if (strLogMsg.ContainsKey(logIndex))
                    {
                        if (strLogMsg[logIndex].Length == 0)
                        {
                            strLogMsg[logIndex] = String.Format("[{0}]: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), aLogMsg);
                        }
                        else
                        {
                            strLogMsg[logIndex] = String.Format("{0}\n[{1}]: {2}", strLogMsg[logIndex], DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss:fff"), aLogMsg);
                        }
                    }
                    else
                    {
                        strLogMsg.Add(logIndex, String.Format("[{0}]: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), aLogMsg));
                    }

                    String str = strLogMsg[logIndex];
                    // Write the string to a file.
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true);

                    if (!File.Exists(fileName))
                    {
                        // Create a file to write to.
                        //using (StreamWriter sw = File.CreateText(fileName))
                        using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.GetEncoding("shift_jis")))
                        {
                            try
                            {
                                sw.WriteLine(str);
                                strLogMsg[logIndex] = "";
                                //sw.Close();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(string.Format("StackTrace: {0} \n Message {1}", ex.StackTrace, ex.Message));
                            }
                            finally
                            {
                                sw.Flush();
                                sw.Close();
                                sw.Dispose();
                            }
                        }
                    }
                    else
                    {
                        //FileInfo fInfo = new FileInfo(fileName);

                        // This text is always added, making the file longer over time
                        // if it is not deleted.
                        //using (StreamWriter sw = File.AppendText(fileName))
                        using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.GetEncoding("shift_jis")))
                        {
                            try
                            {
                                sw.WriteLine(str);
                                //sw.WriteLine(String.Format("[{0}]{1}", fInfo.Length, str));
                                strLogMsg[logIndex] = "";
                                //sw.Close();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(string.Format("StackTrace: {0} \n Message {1}", ex.StackTrace, ex.Message));
                            }
                            finally
                            {
                                sw.Flush();
                                sw.Close();
                                sw.Dispose();
                            }
                        }

                    }
                }
            }
            catch (Exception xe)
            {
                string errStr = String.Format("[{0}]:{1}\n[errorMessage={2}]\n[StackTrace={3}]", DateTime.Now.ToString("yyyy-MM-dd=HH:mm:ss:fff"), aLogMsg, xe.Message, xe.StackTrace);

                strLogMsg[logIndex] = String.Format("\n{0}\n[{1}]\n", strLogMsg[logIndex], errStr);
                //WriteLog(aPath, aFileTag, String.Format("{0}err", aFileExt), errStr);
            }
        }
        #endregion [WriteLog] private
    }
}
