using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraRichEdit.API.Native;
using EmrDocker.Meta;
using IHIS.Framework;
using IHIS.OCSO.Meta;
using MedicalInterface.Mml23;

namespace IHIS.OCSO
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Security.Cryptography;
    using System.Windows.Forms;

    using DevExpress.XtraRichEdit;
    using DevExpress.XtraRichEdit.Utils;
    using global::EmrDocker;
    using global::EmrDocker.Types;
    using DevExpress.XtraRichEdit.API.Native.Implementation;
    using GhostscriptSharp;
    using IHIS.CloudConnector.Utility;

    public class Utilities
    {
        private static readonly List<string> fileUploaded = new List<string>();
        private static readonly MD5 md5 = MD5.Create();
        private static readonly List<string> fileMoved = new List<string>();

        public static string CalculateFileChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                byte[] checksum = md5.ComputeHash(stream);
                return BitConverter.ToString(checksum);
            }
        }

        public static string CalculateImageChecksum(RichEditImage image)
        {
            byte[] checksum = md5.ComputeHash(image.GetImageBytesSafe(RichEditImageFormat.Jpeg));
            return BitConverter.ToString(checksum);
        }

        public static bool CompareImageChecksum(string filePath1, string filePath2)
        {
            using (FileStream stream1 = File.OpenRead(filePath1))
            {
                using (FileStream stream2 = File.OpenRead(filePath2))
                {
                    return StreamsContentsAreEqual(stream1, stream2);
                }
            }

        }

        private static bool StreamsContentsAreEqual(Stream stream1, Stream stream2)
        {
            const int bufferSize = 2048 * 2;
            byte[] buffer1 = new byte[bufferSize];
            byte[] buffer2 = new byte[bufferSize];

            while (true)
            {
                int count1 = stream1.Read(buffer1, 0, bufferSize);
                int count2 = stream2.Read(buffer2, 0, bufferSize);

                if (count1 != count2)
                {
                    return false;
                }

                if (count1 == 0)
                {
                    return true;
                }

                int iterations = (int)Math.Ceiling((double)count1 / sizeof(Int64));
                for (int i = 0; i < iterations; i++)
                {
                    if (BitConverter.ToInt64(buffer1, i * sizeof(Int64)) != BitConverter.ToInt64(buffer2, i * sizeof(Int64)))
                    {
                        return false;
                    }
                }
            }
        }

        public static string CalculateImageChecksum(Stream image)
        {
            byte[] checksum = md5.ComputeHash(image);
            return BitConverter.ToString(checksum);
        }


        /// <summary>
        /// Generate file name as format BUNHO_filename_yyyymmddHHMMSS
        /// </summary>
        /// <param name="bunho"></param>
        /// <param name="filename">Unused parameter</param>
        /// <param name="fileExtension">Extension of the file</param>
        /// <returns></returns>
        public static string NextSequence(string bunho, string filename, string fileExtension)
        {
            string path = GetBunhoDataPath(bunho);
            int maxFileNameLength = 248 - path.Length - String.Format("{0}__{1}.{2}", bunho, DateTime.Now.ToString("yyyyMMddHHmmssffffff"), fileExtension.Replace(".", "")).Length;
            //return String.Format("{0}-{1}-{2}-{3}", hospitalCode, Guid.NewGuid(), Process.GetCurrentProcess().Id, DateTime.Now.Millisecond);
            string modifiedName = string.IsNullOrEmpty(filename) ? string.Empty : Path.GetFileNameWithoutExtension(filename);
            modifiedName = modifiedName.Length <= maxFileNameLength ? modifiedName : modifiedName.Substring(0, maxFileNameLength);

            modifiedName = string.Empty; //TODO Fix filename to empty to avoid upload error
            string tmpFilename = String.Format("{0}_{1}_{2}.{3}", bunho, modifiedName, DateTime.Now.ToString("yyyyMMddHHmmssffffff"), fileExtension.Replace(".", ""));
            //CacheService.Instance.Get(tmpFilename);
            return tmpFilename;
        }

        public static void Load(String fileName, RichEditControl richEditControl, string bunho)
        {
            string path = GetRelativePath(fileName, true, bunho);
            if (!String.IsNullOrEmpty(path))
                richEditControl.LoadDocument(path, DocumentFormat.Rtf);
        }

        public static void LoadContent(String content, DocumentFormat format, RichEditControl richEditControl)
        {
            if (!String.IsNullOrEmpty(content))
            {
                using (MemoryStream memory = new MemoryStream(Encoding.UTF8.GetBytes(content)))
                {
                    //memory.Seek(0, SeekOrigin.Begin);
                    memory.Position = 0;
                    //richEditControl.LoadDocument(memory, format);
                    //richEditControl.Document.Text = content;
                    richEditControl.Document.BeginUpdate();
                    richEditControl.Document.InsertText(richEditControl.Document.Range.End, content);
                    richEditControl.Document.EndUpdate();
                    memory.Close();
                }
            }

        }


        public static string GetAbsoluteDataPath(string name, string bunho)
        {
            return GetRelativePath(name, false, bunho);
        }

        public static string GetFileName(string filePath)
        {
            int index = filePath.LastIndexOf("/") == -1 ? filePath.LastIndexOf("\\") : filePath.LastIndexOf("/");
            string fileName = filePath.Substring(index == -1 ? 0 : index + 1);
            return fileName;
        }

        public static string GetBunhoDataPath(string bunho)
        {
            string relativePath = "Data\\" + UserInfo.HospCode + "\\" + bunho + "\\";
            string path = Application.StartupPath;
            string s = "\\";
            if (!Directory.Exists(path + s + relativePath))
            {
                Directory.CreateDirectory(path + s + relativePath);
            }
            return path + s + relativePath;
        }

        /// <summary>
        /// Get file path due to format Data\HOSP_CODE
        /// </summary>
        /// <param name="name"></param>
        /// <param name="checkExists"></param>
        /// <returns></returns>
        public static string GetRelativePath(string name, bool checkExists, string bunho)
        {
            name = "Data\\" + UserInfo.HospCode + "\\" + bunho + "\\" + name;
            string path = Application.StartupPath;
            string s = "\\";
            if (!Directory.Exists(path + "\\Data\\" + UserInfo.HospCode + "\\" + bunho + "\\"))
            {
                Directory.CreateDirectory(path + "\\Data\\" + UserInfo.HospCode + "\\" + bunho + "\\");
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
            try
            {
                if (assetUrl == null)
                {
                    throw new ArgumentNullException("assetUrl");
                }
                WebRequest request = HttpWebRequest.Create(assetUrl);
                request.Headers.Add("filename", GetFileName(filePath));
                request.Headers.Add("token", "1234");
                request.Headers.Add("HOSP_CODE", hosp_code);
                request.Headers.Add("PATIENT_CODE", bunho);
                Service.WriteLog("[BEGIN DOWNLOAD] - " + filePath);
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fileStream = File.OpenWrite(filePath))
                    {
                        CopyStream(responseStream, fileStream);
                    }
                }
                Service.WriteLog("[END DOWNLOAD] - " + filePath);
            }
            catch (Exception ex)
            {
                Service.WriteLog("DONWLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Upload file method
        /// </summary>
        /// <param name="address"></param>
        /// <param name="filePath"></param>
        /// <param name="token"></param>
        /// <param name="hosp_code">UserInfo.HospCode</param>
        /// <param name="bunho">Patient code who is currently in session</param>
        public static void UploadFile(Uri address, string filePath, string token, string hosp_code, string bunho)
        {
            try
            {
                lock (fileUploaded)
                {
                    if (fileUploaded.Contains(filePath))
                    {
                        return;
                    }
                    else
                    {
                        fileUploaded.Add(filePath);                        
                    }
                }
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
                    Service.WriteLog("[BEGIN UPLOAD] - " + filePath + ", token: " + token);
                    //client.UploadFile(address, filePath);
                    client.UploadData(address, File.ReadAllBytes(filePath));
                    Service.WriteLog("[END UPLOAD] - " + filePath + ", token: " + token);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("UPLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        public static void UploadTempFile(Uri address, string filePath, string token, string hosp_code, string bunho)
        {
            try
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
                    client.Headers.Add("TEMP", "Y");
                    Service.WriteLog("[BEGIN UPLOAD] - " + filePath + ", token: " + token);
                    //client.UploadFile(address, filePath);
                    client.UploadData(address, File.ReadAllBytes(filePath));
                    Service.WriteLog("[END UPLOAD] - " + filePath + ", token: " + token);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("UPLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// move file method
        /// </summary>
        /// <param name="address"></param>
        /// <param name="filePath"></param>
        /// <param name="token"></param>
        /// <param name="hosp_code">UserInfo.HospCode</param>
        /// <param name="bunho">Patient code who is currently in session</param>
        public static void MoveTempFile(Uri address, string filePath, string token, string hosp_code, string bunho)
        {
            try
            {
                lock (fileMoved)
                {
                    if (fileMoved.Contains(filePath))
                    {
                        return;
                    }
                    else
                    {
                        fileMoved.Add(filePath);
                    }
                }
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
                    client.Headers.Add("TEMP", "N");
                    Service.WriteLog("[BEGIN MOVING] - " + filePath + ", token: " + token);
                    //client.UploadFile(address, filePath);
                    //client.UploadData(address, File.ReadAllBytes(filePath));
                    client.UploadString(address, "");
                    Service.WriteLog("[END MOVING] - " + filePath + ", token: " + token);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("MOVE ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
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

        public static string ConvertToLocalPath(string filePath, string hosp_code, string bunho)
        {
            string path = Application.StartupPath;
            if (!Directory.Exists(path + "\\Data\\" + hosp_code + "\\" + bunho))
            {
                Directory.CreateDirectory(path + "\\Data\\" + hosp_code + "\\" + bunho);
            }

            string localPath = string.IsNullOrEmpty(filePath) ? null : Application.StartupPath + "\\Data\\" + hosp_code + "\\" + bunho + "\\" + Utilities.GetFileName(filePath);
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

                /*if (filePath.EndsWith(".pdf"))
                {
                    //download file Image of Pfd
                    string thumbnailFilePath = filePath.Replace(".pdf", ".jpeg");
                    if (File.Exists(thumbnailFilePath))
                    {
                        Utilities.DownloadAssetDataFromUrl(assetUrl, thumbnailFilePath, hosp_code, bunho);
                    }
                }*/
            }
            catch (Exception)
            {

            }
        }

        public static long showBookmarkTime = 0;

        /// <summary>
        /// Show bookmark as tooltip at specific position
        /// </summary>
        /// <param name="ctl">RichEditControl</param>
        /// <param name="pos">DocumentPosition</param>
        /// <param name="mousePosition">Position where tooltip shows</param>
        public static void ShowBookmarkByPosition(RichEditControl ctl, DocumentPosition pos, Point mousePosition)
        {
            foreach (CustomMark mark in ctl.Document.CustomMarks)
            {
                if (mark.Position == pos)
                {
                    CommentMeta cmt = null;

                    cmt = mark.UserData as CommentMeta;
                    if (cmt != null)
                    {
                        ShowToolTip(cmt.Comment, mousePosition);
                    }
                }
            }
        }

        public static CustomMarkSchema AddEmrMarkerContent(string naewonDate, string naewonKey, EmrMarkerMeta marker, int position)
        {
            ApplyMarkerContent(naewonDate, naewonKey, marker);
            CustomMarkSchema schema = new CustomMarkSchema(position, marker);
            return schema;
        }

        public static EmrMarkerMeta ApplyMarkerContent(string naewonDate, string naewonKey, EmrMarkerMeta marker)
        {
            marker.DepartmentName = UserInfo.GwaName;
            marker.DoctorName = UserInfo.UserName;
            marker.ExaminationDate = naewonDate;
            marker.HospitalName = UserInfo.HospCode;
            marker.ReservationCode = naewonKey;
            return marker;
        }

        /// <summary>
        /// Display bookmark on richedit control
        /// </summary>
        /// <param name="e"></param>
        /// <param name="richEditControl"></param>
        /// <param name="MousePosition"></param>
        public static void DisplayBookmark(MouseEventArgs e, RichEditControl richEditControl, Point MousePosition)
        {
            if ((DateTime.Now - new DateTime(IHIS.OCSO.Utilities.showBookmarkTime)).Seconds < 3) return;

            Point docPoint = Units.PixelsToDocuments(e.Location, richEditControl.DpiX, richEditControl.DpiY);
            DocumentPosition pos = richEditControl.GetPositionFromPoint(docPoint);

            if (pos == null)
                return;

            //Process Show bookmark
            Dictionary<long, Triple<string, long, long>> comments = new Dictionary<long, Triple<string, long, long>>();
            foreach (CustomMark mark in richEditControl.Document.CustomMarks)
            {
                CommentMeta meta = mark.UserData as CommentMeta;
                if (meta != null && meta.UserId.Equals(UserInfo.UserID))
                {
                    if (!comments.ContainsKey(meta.Id))
                    {
                        comments.Add(meta.Id, new Triple<string, long, long>(meta.Comment, mark.Position.ToInt(), mark.Position.ToInt()));
                    }
                    else
                    {
                        if (meta.IsStart) comments[meta.Id].V2 = mark.Position.ToInt();
                        else comments[meta.Id].V3 = mark.Position.ToInt();
                    }
                }
            }

            foreach (Triple<string, long, long> triple in comments.Values)
            {
                if (triple.V2 <= pos.ToInt() && pos.ToInt() <= triple.V3)
                {
                    ShowToolTip(triple.V1, MousePosition);
                }
            }

            //Process image hover
            int start = pos.ToInt() > 1 ? pos.ToInt() - 1 : pos.ToInt();
            DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.CreateRange(start, 3));
            if (collection.Count > 0 && DoButtonBusiness.CheckIfNonDolImage(collection[0]))
            {
                richEditControl.Cursor = Cursors.Hand;
            }
            else
            {
                richEditControl.Cursor = Cursors.IBeam;
            }
        }

        /// <summary>
        /// Show hint
        /// </summary>
        /// <param name="word">Hint content</param>
        public static void ShowToolTip(string word, Point MousePosition)
        {
            showBookmarkTime = DateTime.Now.Ticks;
            ToolTipControlInfo info = new ToolTipControlInfo(showBookmarkTime, word); // pass showBookmarkTime due to ToolTipControlInfo appears only once if same object passed in
            info.ToolTipPosition = MousePosition;
            toolTipController1.ShowHint(info);
        }

        private static ToolTipController toolTipController1 = new DevExpress.Utils.ToolTipController();

        public static void BindStyles(RichEditControl richEditControl)
        {
            foreach (string tag in DataProvider.Instance.Tags.Keys)
            {
                ParagraphStyle tagStyle = richEditControl.Document.ParagraphStyles.CreateNew();
                tagStyle.Name = tag;
                richEditControl.Document.ParagraphStyles.Add(tagStyle);

                foreach (string subTag in DataProvider.Instance.Tags[tag])
                {
                    ParagraphStyle subTagStyle = richEditControl.Document.ParagraphStyles.CreateNew();
                    subTagStyle.Name = String.Format("{0}-{1}", tag, subTag);
                    richEditControl.Document.ParagraphStyles.Add(subTagStyle);
                }
            }
        }

        public static SizeF GetImageSizeF(DocumentImage img, RichEditControl richEditContrl)
        {
            float pageWidth = richEditContrl.Document.Sections[0].Page.Width - richEditContrl.Document.Sections[0].Margins.Left - richEditContrl.Document.Sections[0].Margins.Right;
            float pageHeight = richEditContrl.Document.Sections[0].Page.Height - richEditContrl.Document.Sections[0].Margins.Top - richEditContrl.Document.Sections[0].Margins.Bottom;

            float imgHeight = img.Size.Height;
            float imgWidth = img.Size.Width;
            if (imgWidth > pageWidth || imgHeight > pageHeight)
            {
                float ratio = Math.Min(imgWidth / pageWidth, imgHeight / pageHeight);
                ratio = ratio > 1 ? 1 / (Math.Max(imgWidth / pageWidth, imgHeight / pageHeight)) : ratio;
                return new SizeF(imgWidth * ratio, imgHeight * ratio);
            }
            return img.Size;
        }

        public static bool CheckPdfUploadFile(string fileName, out string max_size)
        {
            max_size = DataProvider.Instance.Pdf_max_size;
            try
            {
                if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName) || string.IsNullOrEmpty(DataProvider.Instance.Pdf_max_size)) return false;
                Double confSize = Double.Parse(DataProvider.Instance.Pdf_max_size);
                FileInfo fileInfo = new FileInfo(fileName);
                return (double)fileInfo.Length / (1024 * 1024) > confSize ? false : true;
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
                return false;
            }
        }
        public static FileDocumentImageSource GetPdfThumbnail(string pdfFilePath, out string thumbnailFilePath)
        {
            //thumbnailFilePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(bunho, Path.GetFileName(pdfFilePath), "jpeg"), bunho);
            thumbnailFilePath = pdfFilePath.Replace(".pdf", ".jpeg");
            GhostscriptWrapper.GeneratePageThumb(pdfFilePath, thumbnailFilePath, 1, 24, 24);
            return new FileDocumentImageSource(thumbnailFilePath);
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
    }
}   