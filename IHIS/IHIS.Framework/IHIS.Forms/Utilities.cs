using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;

namespace IHIS.Framework
{
    public class Utilities
    {
        public enum TransferType {
            PatientImage,
            ProtocolImage
        }

        private static readonly MD5 md5 = MD5.Create();

        public static string CalculateFileChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                byte[] checksum = md5.ComputeHash(stream);
                return BitConverter.ToString(checksum);
            }
        }

        //public static string CalculateImageChecksum(RichEditImage image)
        //{
        //    byte[] checksum = md5.ComputeHash(image.GetImageBytesSafe(RichEditImageFormat.Jpeg));
        //    return BitConverter.ToString(checksum);
        //}

        public static string CalculateImageChecksum(Stream image)
        {
            byte[] checksum = md5.ComputeHash(image);
            return BitConverter.ToString(checksum);
        }

        /// <summary>
        /// Generate file name as format BUNHO_filename_yyyymmddHHMMSS
        /// </summary>
        /// <param name="bunho"></param>
        /// <param name="filename"></param>
        /// <param name="fileExtension">Extension of the file</param>
        /// <returns></returns>
        public static string NextSequence(string bunho, string filename, string fileExtension)
        {
            //return String.Format("{0}-{1}-{2}-{3}", hospitalCode, Guid.NewGuid(), Process.GetCurrentProcess().Id, DateTime.Now.Millisecond);
            return String.Format("{0}_{1}_{2}.{3}", bunho, filename, DateTime.Now.ToString("yyyyMMddHHmmss"), fileExtension);
        }

        //public static void Load(String fileName, RichEditControl richEditControl, string bunho)
        //{
        //    string path = GetRelativePath(fileName, true, bunho);
        //    if (!String.IsNullOrEmpty(path))
        //        richEditControl.LoadDocument(path, DocumentFormat.Rtf);
        //}

        //public static void LoadContent(String content, DocumentFormat format, RichEditControl richEditControl)
        //{
        //    if (!String.IsNullOrEmpty(content))
        //    {
        //        using (MemoryStream memory = new MemoryStream(Encoding.UTF8.GetBytes(content)))
        //        {
        //            //memory.Seek(0, SeekOrigin.Begin);
        //            memory.Position = 0;
        //            //richEditControl.LoadDocument(memory, format);
        //            //richEditControl.Document.Text = content;
        //            richEditControl.Document.BeginUpdate();
        //            richEditControl.Document.InsertText(richEditControl.Document.Range.End, content);
        //            richEditControl.Document.EndUpdate();
        //            memory.Close();
        //        }
        //    }

        //}


        public static string GetAbsoluteDataPath(string name, string bunho)
        {
            return GetRelativePath(name, false, bunho);
        }

        public static string GetFileName(string filePath)
        {
            int index = filePath.LastIndexOf("/") == -1 ? filePath.LastIndexOf("\\") : filePath.LastIndexOf("/");
            string fileName = filePath.Trim().Substring(index == -1 ? 0 : index + 1);
            return fileName;
        }

        /// <summary>
        /// Get file path due to format Data\HOSP_CODE
        /// </summary>
        /// <param name="name"></param>
        /// <param name="checkExists"></param>
        /// <returns></returns>
        public static string GetRelativePath(string name, bool checkExists, string bunho)
        {
            name = "REHAImages\\REHA\\" + name;
            string path = Application.StartupPath;
            string s = "\\";
            if (!Directory.Exists(path + "\\REHAImages\\REHA\\"))
            {
                Directory.CreateDirectory(path + "\\REHAImages\\REHA\\");
            }
            if (checkExists)
            {
                for (int i = 0; i <= 10; i++)
                {
                    if (File.Exists(path + s + name)) return (path + s + name);
                    else s += "..\\";
                }
                return "";
            }
            else
            {
                return (path + s + name);
            }
        }

        /// <summary>
        /// Retrieves an asset from the web given its url.
        /// </summary>
        /// <param name="assetUrl">The url of the asset to be retrieved.</param>
        /// <returns>Asset data, as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="assetUrl"/> is null.</exception>
        public static void DownloadAssetDataFromUrl(Uri assetUrl, string filePath, string hosp_code, string bunho)
        {
            if (assetUrl == null)
            {
                throw new ArgumentNullException("assetUrl");
            }
            WebRequest request = HttpWebRequest.Create(assetUrl);
            request.Headers.Add("filename", Path.GetFileName(filePath));
            request.Headers.Add("token", "1234");
            request.Headers.Add("HOSP_CODE", hosp_code);
            request.Headers.Add("PATIENT_CODE", bunho);
            WebResponse response = request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                using (FileStream fileStream = File.OpenWrite(filePath))
                {
                    CopyStream(responseStream, fileStream);
                }
            }
        }

        /// <summary>
        /// Retrieves an asset from the web given its url.
        /// </summary>
        /// <param name="assetUrl">The url of the asset to be retrieved.</param>
        /// <returns>Asset data, as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="assetUrl"/> is null.</exception>
        private static void DownloadAssetDataFromUrl(Uri assetUrl, string filePath, string hosp_code, string code, string transferType)
        {
            if (assetUrl == null)
            {
                throw new ArgumentNullException("assetUrl");
            }
            WebRequest request = HttpWebRequest.Create(assetUrl);
            request.Headers.Add("filename", Path.GetFileName(filePath));
            request.Headers.Add("token", "1234");
            request.Headers.Add("HOSP_CODE", hosp_code);
            request.Headers.Add("PATIENT_CODE", code);
            request.Headers.Add("TRANSFER_TYPE", transferType);
            WebResponse response = request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                using (FileStream fileStream = File.OpenWrite(filePath))
                {
                    CopyStream(responseStream, fileStream);
                }
            }
        }

        /// <summary>
        /// Upload file method
        /// </summary>
        /// <param name="address"></param>
        /// <param name="filePath"></param>
        /// <param name="token"></param>
        /// <param name="hosp_code">EnvironInfo.HospCode</param>
        /// <param name="bunho">Patient code who is currently in session</param>
        public static void UploadFile(Uri address, string filePath, string token, string hosp_code, string bunho)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address");
            }

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("token", token);
                client.Headers.Add("filename", GetFileName(filePath));
                client.Headers.Add("HOSP_CODE", hosp_code);
                client.Headers.Add("PATIENT_CODE", bunho);
                Logs.WriteLog("[BEGIN UPLOAD] - " + filePath + ", token: " + token);
                client.UploadData(address, File.ReadAllBytes(filePath));
                Logs.WriteLog("[END UPLOAD] - " + filePath + ", token: " + token);
            }
        }

        /// <summary>
        /// @Overload: Upload file method
        /// </summary>
        /// <param name="address"></param>
        /// <param name="filePath"></param>
        /// <param name="token"></param>
        /// <param name="hosp_code">EnvironInfo.HospCode</param>
        /// <param name="bunho">Patient code who is currently in session</param>
        public static void UploadFile(Uri address, string filePath, string token, string hosp_code, string code, string transferType)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address");
            }

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("token", token);
                client.Headers.Add("filename", GetFileName(filePath));
                client.Headers.Add("HOSP_CODE", hosp_code);
                client.Headers.Add("PATIENT_CODE", code);
                client.Headers.Add("TRANSFER_TYPE", transferType);
                Logs.WriteLog("[BEGIN UPLOAD] - " + filePath + ", token: " + token);
                client.UploadData(address, File.ReadAllBytes(filePath));
                Logs.WriteLog("[END UPLOAD] - " + filePath + ", token: " + token);
            }
        }

        /// <summary>
        /// Retrieves an asset from the web given its url.
        /// </summary>
        /// <param name="assetUrl">The url of the asset to be retrieved.</param>
        /// <returns>Asset data, as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="assetUrl"/> is null.</exception>
        public static byte[] GetAssetDataFromUrl(Uri assetUrl)
        {
            if (assetUrl == null)
            {
                throw new ArgumentNullException("assetUrl");
            }
            WebRequest request = HttpWebRequest.Create(assetUrl);
            WebResponse response = request.GetResponse();

            MemoryStream memStream = new MemoryStream();
            using (Stream responseStream = response.GetResponseStream())
            {
                CopyStream(responseStream, memStream);
            }
            return memStream.ToArray();
        }

        /// <summary>
        /// Retrieves an asset from the web given its url.
        /// </summary>
        /// <param name="assetUrl">The url of the asset to be retrieved.</param>
        /// <returns>Asset data, as an array of bytes.</returns>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="assetUrl"/> is null.</exception>
        public static byte[] GetAssetDataFromUrl(string assetUrl)
        {
            if (string.IsNullOrEmpty(assetUrl))
            {
                throw new ArgumentNullException("assetUrl");
            }
            return GetAssetDataFromUrl(new Uri(assetUrl));
        }

        /// <summary>
        /// Deflates data compressed in gzip format.
        /// </summary>
        /// <param name="gzipData">Data to be deflated.</param>
        /// <returns>Deflated data.</returns>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="gzipData"/> is null.</exception>
        public static byte[] DeflateGZipData(byte[] gzipData)
        {
            if (gzipData == null)
            {
                throw new ArgumentNullException("gzipData");
            }
            MemoryStream memStream = new MemoryStream();
            using (GZipStream gzipStream = new GZipStream(new MemoryStream(gzipData),
                CompressionMode.Decompress))
            {
                CopyStream(gzipStream, memStream);
            }
            return memStream.ToArray();
        }

        /// <summary>
        /// Copies a stream from source to destination and returns the first n
        /// bytes as preview.
        /// </summary>
        /// <param name="sourceStream">Source stream.</param>
        /// <param name="targetStream">Destination stream.</param>
        /// <param name="maxPreviewBytes">The maximum number of preview bytes to
        /// return.</param>
        /// <returns>An array of bytes, whose max size is maxPreviewBytes.</returns>
        /// <exception cref="ArgumentException">Thrown if source stream is not
        /// readable, or if the target stream is not writable.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="sourceStream"/> or
        /// <paramref name="targetStream"/> is null.</exception>
        public static byte[] CopyStreamWithPreview(Stream sourceStream, Stream targetStream,
            int maxPreviewBytes)
        {
            if (sourceStream == null)
            {
                throw new ArgumentNullException("sourceStream");
            }

            if (targetStream == null)
            {
                throw new ArgumentNullException("targetStream");
            }

            if (!sourceStream.CanRead)
            {
                throw new ArgumentException("SourceStreamIsNotReadable");
            }

            if (!targetStream.CanWrite)
            {
                throw new ArgumentException("TargetStreamIsNotWritable");
            }

            int bufferSize = 2 << 20;
            byte[] buffer = new byte[bufferSize];
            List<Byte> byteArray = new List<byte>();

            int bytesRead = 0;
            while ((bytesRead = sourceStream.Read(buffer, 0, bufferSize)) != 0)
            {
                int index = 0;
                while (byteArray.Count < maxPreviewBytes && index < bytesRead)
                {
                    byteArray.Add(buffer[index]);
                    index++;
                }
                targetStream.Write(buffer, 0, bytesRead);
            }
            return byteArray.ToArray();
        }

        /// <summary>
        /// Copies a stream from source to destination.
        /// </summary>
        /// <param name="sourceStream">Source stream.</param>
        /// <param name="targetStream">Destination stream.</param>
        /// <exception cref="ArgumentException">Thrown if source stream is not
        /// readable, or if the target stream is not writable.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="sourceStream"/> or
        /// <paramref name="targetStream"/> is null.</exception>
        public static void CopyStream(Stream sourceStream, Stream targetStream)
        {
            CopyStreamWithPreview(sourceStream, targetStream, 0);
        }

        /// <summary>
        /// Gets the stream contents as string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>Contents of the stream, as a string.</returns>
        public static string GetStreamContentsAsString(Stream stream)
        {
            string contents = "";
            using (StreamReader reader = new StreamReader(stream))
            {
                contents = reader.ReadToEnd();
            }
            return contents;
        }

        public static DataTable ConvertListObjToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                object[] values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static string ConvertToLocalPath(string filePath)
        {
            string path = Application.StartupPath;
            if (!Directory.Exists(path + "\\REHAImages\\REHA\\"))
            {
                Directory.CreateDirectory(path + "\\REHAImages\\REHA\\");
            }

            string localPath = filePath == null ? null : Application.StartupPath + "\\REHAImages\\REHA\\" + Utilities.GetFileName(filePath);
            return localPath;
        }

        public static void DownloadFile(string filePath, string hosp_code, string bunho)
        {
            try
            {
                string fileName = Utilities.GetFileName(filePath);

                // MED-10181
                //string mediaHost = ConfigurationManager.AppSettings["MediaBaseUri"];// "http://media.nextop.asia/k01/";
                string mediaHost = Utility.GetConfig("MediaBaseUri", UserInfo.VpnYn);

                Uri assetUrl = new Uri(mediaHost);
                Utilities.DownloadAssetDataFromUrl(assetUrl, filePath, hosp_code, bunho);
            }
            catch (Exception)
            {

            }
        }

        public static void DownloadFile(string filePath, string hosp_code, string code, string transferType)
        {
            try
            {
                string fileName = Utilities.GetFileName(filePath);

                // MED-10181
                //string mediaHost = ConfigurationManager.AppSettings["MediaBaseUri"];// "http://media.nextop.asia/k01/";
                string mediaHost = Utility.GetConfig("MediaBaseUri", UserInfo.VpnYn);

                Uri assetUrl = new Uri(mediaHost);
                Utilities.DownloadAssetDataFromUrl(assetUrl, filePath, hosp_code, code, transferType);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-8027
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="hospCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static byte[] DownloadFileByte(string filePath, string hospCode, string code)
        {
            byte[] data = new byte[] { };

            try
            {
                string fileName = Utilities.GetFileName(filePath);
                string mediaHost = Utility.GetConfig("MediaBaseUri", UserInfo.VpnYn);

                Uri assetUrl = new Uri(mediaHost);
                WebRequest request = HttpWebRequest.Create(assetUrl);
                request.Headers.Add("filename", Path.GetFileName(filePath));
                request.Headers.Add("token", "1234");
                request.Headers.Add("HOSP_CODE", hospCode);
                request.Headers.Add("PATIENT_CODE", code);
                WebResponse response = request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    data = ReadByteStream(responseStream);
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }

            return data;
        }

        public static byte[] ReadByteStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        public static string GetFileConfig(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            //catch (Exception ex)
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get date format corresponding to localization
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public static string GetDateByLangMode(string birth, LangMode langMode)
        {
            string dateStr = "";

            try
            {
                DateTime day = DateTime.Parse(birth);

                switch (langMode)
                {
                    case LangMode.Ko:
                        dateStr = day.Year.ToString() + "년 " + day.Month.ToString() + "월 " + day.Day.ToString() + "일생";
                        break;
                    case LangMode.Jr:
                        string period = "";
                        int year = 0;
                        JapanYearHelper.ConvertToJapanYear(day, out period, out year);
                        dateStr = period + " " + year.ToString() + "年 " + day.Month.ToString() + "月 " + day.Day.ToString() + "日生";
                        break;
                    case LangMode.Vi:
                        dateStr = "Ngày " + day.Day.ToString() + " Tháng " + day.Month.ToString() + " Năm " + day.Year.ToString();
                        break;
                    default:
                        dateStr = birth;
                        break;
                }
            }
            catch
            {
                return birth;
            }

            return dateStr;
        }

        /**
         * Convert DataTable to CSV string, then use File.WriteAllText to save 
         * */
        public static string ToCSV(DataTable table)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
            }

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(EscapeCSVStr(row[i].ToString()));
                    result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Turn a string into a CSV cell output
        /// </summary>
        /// <param name="str">String to output</param>
        /// <returns>The CSV cell formatted string</returns>
        private static string EscapeCSVStr(string str)
        {
            bool mustQuote = (str.Contains(",") || str.Contains("\"") || str.Contains("\r") || str.Contains("\n"));
            if (mustQuote)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\"");
                foreach (char nextChar in str)
                {
                    sb.Append(nextChar);
                    if (nextChar == '"')
                        sb.Append("\"");
                }
                sb.Append("\"");
                return sb.ToString();
            }

            return str;
        }

        /// <summary>
        /// Check if the file is using
        /// </summary>
        /// <param name="file"></param>
        /// <returns>TRUE: File is using, otherwise FALSE</returns>
        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        #region Check Inventory     

        public static bool CheckInventory(DataTable table)
        {
            try
            {
                if (table.Rows.Count > 0)
                {
                    List<OBCheckInventoryParamInfo> inputList = new List<OBCheckInventoryParamInfo>();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-13945
                        if (table.Rows[i].RowState == DataRowState.Unchanged) continue;

                        OBCheckInventoryParamInfo info = new OBCheckInventoryParamInfo();
                        info.HangmogCode = table.Columns.Contains("hangmog_code") ? table.Rows[i]["hangmog_code"].ToString() : "";
                        info.HangmogName = table.Columns.Contains("hangmog_name") ? table.Rows[i]["hangmog_name"].ToString() : "";
                        info.Suryang = table.Columns.Contains("suryang") ? table.Rows[i]["suryang"].ToString() : "1";
                        info.Dv = table.Columns.Contains("dv") ? table.Rows[i]["dv"].ToString() : "1";
                        info.Nalsu = table.Columns.Contains("nalsu") ? table.Rows[i]["nalsu"].ToString() : "1";
                        info.Pkocs1003 = table.Columns.Contains("pkocskey") ? table.Rows[i]["pkocskey"].ToString() : "";
                        // https://sofiamedix.atlassian.net/browse/MED-13722
                        info.DvTime = table.Columns.Contains("dv_time") ? table.Rows[i]["dv_time"].ToString() : "*";

                        inputList.Add(info);
                    }
                    return CheckInventory(inputList);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog("Check inventory failed: " + ex.Message);
                Logs.WriteLog("Check inventory failed (stacktrace): " + ex.StackTrace);
                return true;
            }
        }

        public static bool CheckInventory(List<OBCheckInventoryParamInfo> inputList)
        {
            try
            {
                if (inputList.Count > 0 && UserInfo.InvUsage == true)
                {
                    OBCheckInventoryArgs args = new OBCheckInventoryArgs(inputList);
                    OBCheckInventoryResult result =
                        CloudService.Instance.Submit<OBCheckInventoryResult, OBCheckInventoryArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (result.OutputList.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            //MED-12209
                            if (XScreen.CurrentScreen.ScreenID != "OCS2015U00")
                            {
                                sb.AppendLine(XMsg.GetMsg("M007"));
                            }
                            else
                            {
                                sb.AppendLine(XMsg.GetMsg("M004"));
                            }
                            foreach (OBCheckInventoryInfo info in result.OutputList)
                            {
                                sb.AppendLine(String.Format(XMsg.GetMsg("M005"), info.HangmogName,
                                    info.Quantity));
                            }
                            DialogResult dialogResult = XMessageBox.Show(sb.ToString(), XMsg.GetMsg("M006"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                return true;
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog("Check inventory failed: " + ex.Message);
                Logs.WriteLog("Check inventory failed (stacktrace): " + ex.StackTrace);
                return true;
            }
        }

      

        //Check inventory for orders
        /// <summary>
        /// MED-14641   
        public static bool CheckWonyoiOrderYN(DataTable table)
        {
            string WonyoOrderYN = "";
            string inputTab = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                WonyoOrderYN = table.Columns.Contains("wonyoi_order_yn") ? table.Rows[i]["wonyoi_order_yn"].ToString() : "";
                inputTab = table.Columns.Contains("input_tab") ? table.Rows[i]["input_tab"].ToString() : "";
                if (WonyoOrderYN != "Y" && inputTab == "01")
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckInventory(DataTable table, bool isUseDataTable)
        {
            try
            {
                if (table.Rows.Count > 0)
                {
                    List<OBCheckInventoryParamInfo> inputList = new List<OBCheckInventoryParamInfo>();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-13945
                        if (table.Rows[i].RowState == DataRowState.Unchanged) continue;

                        OBCheckInventoryParamInfo info = new OBCheckInventoryParamInfo();
                        info.HangmogCode = table.Columns.Contains("hangmog_code") ? table.Rows[i]["hangmog_code"].ToString() : "";
                        info.HangmogName = table.Columns.Contains("hangmog_name") ? table.Rows[i]["hangmog_name"].ToString() : "";
                        info.Suryang = table.Columns.Contains("suryang") ? table.Rows[i]["suryang"].ToString() : "1";
                        info.Dv = table.Columns.Contains("dv") ? table.Rows[i]["dv"].ToString() : "1";
                        info.Nalsu = table.Columns.Contains("nalsu") ? table.Rows[i]["nalsu"].ToString() : "1";
                        info.Pkocs1003 = table.Columns.Contains("pkocskey") ? table.Rows[i]["pkocskey"].ToString() : "";
                        // https://sofiamedix.atlassian.net/browse/MED-13722
                        info.DvTime = table.Columns.Contains("dv_time") ? table.Rows[i]["dv_time"].ToString() : "*";

                        inputList.Add(info);
                    }
                    return CheckInventory(inputList, table);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog("Check inventory failed: " + ex.Message);
                Logs.WriteLog("Check inventory failed (stacktrace): " + ex.StackTrace);
                return true;
            }
        }

        public static bool CheckInventory(List<OBCheckInventoryParamInfo> inputList, DataTable dtInput)
        {
            try
            {
                if (inputList.Count > 0 && UserInfo.InvUsage == true && CheckWonyoiOrderYN(dtInput))
                {
                    OBCheckInventoryArgs args = new OBCheckInventoryArgs(inputList);
                    OBCheckInventoryResult result =
                        CloudService.Instance.Submit<OBCheckInventoryResult, OBCheckInventoryArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (result.OutputList.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            //MED-12209
                            if (XScreen.CurrentScreen.ScreenID != "OCS2015U00")
                            {
                                sb.AppendLine(XMsg.GetMsg("M007"));
                            }
                            else
                            {
                                sb.AppendLine(XMsg.GetMsg("M004"));
                            }
                            foreach (OBCheckInventoryInfo info in result.OutputList)
                            {
                                sb.AppendLine(String.Format(XMsg.GetMsg("M005"), info.HangmogName,
                                    info.Quantity));
                            }
                            DialogResult dialogResult = XMessageBox.Show(sb.ToString(), XMsg.GetMsg("M006"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                return true;
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog("Check inventory failed: " + ex.Message);
                Logs.WriteLog("Check inventory failed (stacktrace): " + ex.StackTrace);
                return true;
            }
        }
        /// </summary>
        /// <param name="table"></param>
        /// <param name="isUseDataTable"></param>
        /// <returns></returns>
       
        #endregion

        #region JapanYearHelper
        /// <summary>
        /// JapanYearHelper(서기와 일본연호 변환)에 대한 요약 설명입니다.
        /// </summary>
        private class JapanYearHelper
        {
            private class YearItem
            {
                public string Name = "";
                public DateTime StartDate;
                public DateTime EndDate;
                public int MaxYear = 0;  //최대년수
                public YearItem(string name, DateTime startDate, DateTime endDate, int maxYear)
                {
                    this.Name = name;
                    this.StartDate = startDate;
                    this.EndDate = endDate;
                    this.MaxYear = maxYear;
                }
            }
            private static ArrayList periodList = new ArrayList();
            private static Hashtable yearItemList = new Hashtable();  //Key를 연호로 Value를 YearItem을 관리함.
            private static DateTime START_DATE = DateTime.Parse("1868/09/08");
            private static DateTime END_DATE = DateTime.Parse("9999/12/31");
            static JapanYearHelper()
            {
                //연호 List Set (천황바뀌면 계속 추가)
                YearItem item = new YearItem("明治", START_DATE, DateTime.Parse("1912/07/29"), 45);
                periodList.Add(item);  //명치는 45년(めいじ : M)
                yearItemList.Add("明治", item);
                item = new YearItem("大正", DateTime.Parse("1912/07/30"), DateTime.Parse("1926/12/24"), 15);
                periodList.Add(item);  //대정은 15년(たいしょう: T)
                yearItemList.Add("大正", item);
                item = new YearItem("昭和", DateTime.Parse("1926/12/25"), DateTime.Parse("1989/01/07"), 64);
                periodList.Add(item);  //소화는 64년(しょうわ : S)
                yearItemList.Add("昭和", item);
                item = new YearItem("平成", DateTime.Parse("1989/01/08"), END_DATE, 8010);
                periodList.Add(item);  //평성은 99년(へいせい : H)    
                yearItemList.Add("平成", item);
            }

            /// <summary>
            /// 서기 년도를 분석하여 연호와 년수를 계산
            /// </summary>
            /// <param name="year"></param>
            /// <param name="period"></param>
            /// <param name="convertedYear"></param>
            public static void ConvertToJapanYear(DateTime date, out string period, out int convertedYear)
            {
                period = "UnKnown";
                convertedYear = date.Year;

                if ((date < START_DATE) || (date > END_DATE)) return; //연호없음
                YearItem validItem = null;
                foreach (YearItem item in periodList)
                {
                    if ((date >= item.StartDate) && (date <= item.EndDate))
                    {
                        validItem = item;
                        break;
                    }
                }
                period = validItem.Name;
                convertedYear = date.Year - validItem.StartDate.Year + 1;  //시작년을 1년으로 함
            }
        }
        #endregion

        #region ValidateName
        /// <summary>
        /// prompt user to input space between first name and last name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValidateName(string name)
        {
            //if name includes 1byte space
            if (name.Contains(" "))
            {
                string[] s = name.Split(' ');
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    //count letter except for string.empty and 2bytes space
                    if (s[i] != "" && s[i] != "　")
                        count++;
                }
                if (count > 1)
                    return true;
                else
                    return false;
            }
            // if name just include 2bytes space
            else if (name.Contains("　"))
            {
                string[] s = name.Split('　');
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    //count letter except for string.empty
                    if (s[i] != "")
                        count++;
                }
                if (count > 1)
                    return true;
                else
                    return false;
            }
            return false;
        } 
        #endregion

        #region MessageOrca
        public static string MessageOrca(string input)
        {
            string output = "";
            if (String.IsNullOrEmpty(input)) return output;
            Hashtable msgOrca = new Hashtable();
            msgOrca.Add("1","ORCA患者番号が未設定です");
            msgOrca.Add("2","ORCA診療科が未設定です");
            msgOrca.Add("3","ORCAドクターが未設定です");
            msgOrca.Add("10","ORCA患者番号に該当する患者が存在しません");
            msgOrca.Add("11","ORCA受付日が暦日ではありません");
            msgOrca.Add("12","ORCA受付時間設定誤り");
            msgOrca.Add("13","ORCA診療科が存在しません");
            msgOrca.Add("14","ORCAドクターが存在しません");
            msgOrca.Add("15","ORCA診療内容情報が存在しません");
            msgOrca.Add("16","ORCA診療科・保険組合せで受付登録済みです。二重登録疑い");
            msgOrca.Add("17","ORCA削除対象の受付レコードが存在しません");
            msgOrca.Add("19","ORCA受付ID設定誤り");
            msgOrca.Add("20","ORCA受付IDの受付患者番号と患者番号が一致しません");
            msgOrca.Add("21","ORCA保険の一致する患者保険情報がありません");
            msgOrca.Add("22","ORCA公費の一致する患者公費情報がありません");
            msgOrca.Add("23","ORCA保険情報と一致する保険組合せがありません");
            msgOrca.Add("50","ORCA受付登録件数が上限以上となります。登録できません");
            msgOrca.Add("51","ORCA受付更新エラー");
            msgOrca.Add("52","ORCA受付登録エラー");
            msgOrca.Add("53","ORCA予約更新エラー");
            msgOrca.Add("54","ORCA受付削除エラー");
            msgOrca.Add("90","ORCA他端末使用中");
            msgOrca.Add("91","ORCA処理区分未設定");
            msgOrca.Add("97","ORCA送信内容に誤りがあります");
            msgOrca.Add("98","ORCA送信内容の読込ができませんでした");
            msgOrca.Add("89","ORCA職員情報が取得できません\n医療機関情報が取得できません\n システム日付が取得できません\n患者番号構成情報が取得できません\n	グループ医療機関が不整合です。処理を終了して下さい\nシステム項目が設定できません");
            msgOrca.Add("99","ORCAユーザID未登録");
            msgOrca.Add("K1","受付日を自動設定しました");
            msgOrca.Add("K2","受付時間を自動設定しました");
            msgOrca.Add("K3","診療内容情報を自動設定しました");
            if (msgOrca.ContainsKey(input))
            {
                output = msgOrca[input].ToString();
            }
            return output;
        }

        public static string MessageOrcaBooking(string input)
        {
            string output = "";
            if (String.IsNullOrEmpty(input)) return output;
            Hashtable msgOrca = new Hashtable();
            msgOrca.Add("01", "ORCA 患者番号・予約氏名・予約カナ氏名のいずれかを設定して下さい");
            msgOrca.Add("02", "ORCA 予約日が未設定です");
            msgOrca.Add("03", "ORCA 予約時間が未設定です");
            msgOrca.Add("04", "ORCA 診療科が未設定です");
            msgOrca.Add("05", "ORCA ドクターが未設定です");
            msgOrca.Add("10", "ORCA 患者番号に該当する患者が存在しません");
            msgOrca.Add("11", "ORCA 予約日が暦日ではありません");
            msgOrca.Add("12", "ORCA 予約時間設定誤り");
            msgOrca.Add("13", "ORCA 診療科が存在しません");
            msgOrca.Add("14", "ORCA ドクターが存在しません");
            msgOrca.Add("15", "ORCA 診療内容情報が存在しません");
            msgOrca.Add("16", "ORCA 予約内容が存在しません");
            msgOrca.Add("17", "ORCA 予約メモに登録できない文字があります");
            msgOrca.Add("18", "ORCA 予約氏名に登録できない文字があります");
            msgOrca.Add("19", "ORCA 予約カナ氏名に登録できない文字があります");
            msgOrca.Add("20", "ORCA 診療内容・ドクター・予約時間帯で予約登録済みです");
            msgOrca.Add("25", "ORCA 削除対象の予約レコードが存在しません");
            msgOrca.Add("26", "ORCA 予約ID設定誤り");
            msgOrca.Add("27", "ORCA 予約IDの予約情報と患者情報が一致しません");
            msgOrca.Add("50", "ORCA 予約IDが９９まで登録済みです。これ以上予約できません");
            msgOrca.Add("51", "ORCA 予約登録エラー");
            msgOrca.Add("52", "ORCA 予約メモ登録エラー");
            msgOrca.Add("53", "ORCA 予約更新エラー");
            msgOrca.Add("54", "ORCA 予約削除エラー");
            msgOrca.Add("89", "ORCA 職員情報が取得できません\n医療機関情報が取得できません\nシステム日付が取得できません\n患者番号構成情報が取得できません\nグループ医療機関が不整合です。処理を終了して下さい\nシステム項目が設定できません");
            msgOrca.Add("90", "ORCA 他端末使用中");
            msgOrca.Add("91", "ORCA 処理区分未設定");
            msgOrca.Add("97", "ORCA 送信内容に誤りがあります");
            msgOrca.Add("98", "ORCA 送信内容の読込ができませんでした");
            msgOrca.Add("99", "ORCA ユーザID未登録");
            msgOrca.Add("K1", "ORCA 受付日を自動設定しました");
            msgOrca.Add("K2", "ORCA 受付時間を自動設定しました");
            msgOrca.Add("K3", "ORCA 診療内容情報を自動設定しました");
            if (msgOrca.ContainsKey(input))
            {
                output = msgOrca[input].ToString();
            }
            return output;
        }

        #endregion
    }
}
