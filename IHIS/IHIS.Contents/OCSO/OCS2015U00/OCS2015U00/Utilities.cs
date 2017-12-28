namespace IHIS.OCSO
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Security.Cryptography;
    using System.Windows.Forms;

    using DevExpress.XtraRichEdit;
    using DevExpress.XtraRichEdit.Utils;

    public class Utilities
    {
        private static readonly MD5 md5 = MD5.Create();        

        public static string CalculateFileChecksum(string file)
        {
           using (FileStream stream = File.OpenRead (file))
           {
             byte [] checksum = md5.ComputeHash (stream);
             return  BitConverter.ToString ( checksum );
           }
        }

        public static string CalculateImageChecksum(RichEditImage image)
        {
            byte[] checksum = md5.ComputeHash(image.GetImageBytesSafe(RichEditImageFormat.Jpeg));
            return BitConverter.ToString(checksum);
        }

        public static string CalculateImageChecksum(Stream image)
        {
            byte[] checksum = md5.ComputeHash(image);
            return BitConverter.ToString(checksum);
        }

        public static string NextSequence(string hospitalCode)
        {
            return String.Format("{0}-{1}-{2}-{3}", hospitalCode, Guid.NewGuid(), Process.GetCurrentProcess().Id, DateTime.Now.Millisecond);
        }        

        public static void Load(String fileName, RichEditControl richEditControl)
        {
            string path = GetRelativePath(fileName, true);
            if (!String.IsNullOrEmpty(path))
                richEditControl.LoadDocument(path, DocumentFormat.Rtf);
        }

        public static string GetRelativePath(string name)
        {
            return GetRelativePath(name, false);
        }

        public static string GetFileName(string filePath)
        {
            int index = filePath.LastIndexOf("/") == -1 ? filePath.LastIndexOf("\\") : filePath.LastIndexOf("/");
            string fileName = filePath.Trim().Substring(index == -1 ? 0 : index + 1);
            return fileName;
        }

        public static string GetRelativePath(string name, bool checkExists)
        {
            name = "Data\\" + name;
            string path = Application.StartupPath;
            string s = "\\";
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
        public static void DownloadAssetDataFromUrl(Uri assetUrl, string filePath)
        {
            if (assetUrl == null)
            {
                throw new ArgumentNullException("assetUrl");
            }
            WebRequest request = HttpWebRequest.Create(assetUrl);
            WebResponse response = request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                using (FileStream fileStream = File.OpenWrite(filePath))
                {
                    CopyStream(responseStream, fileStream);
                }                
            }
        }

        public static void UploadFile(Uri address, string filePath, string token)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address");
            }

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("token", token);                
                client.UploadFile(address, filePath);                
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
    }
}