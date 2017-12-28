using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ionic.Zip;

namespace IHIS.NURO
{
    public class DataFile
    {
        public static bool SaveToCsvFile(string fileName, byte[] data)
        {
            if (string.IsNullOrEmpty(fileName) || data.Length <= 0) return false;

            FileInfo f = new FileInfo(fileName);
            string zipFilePath = fileName;
            switch (f.Extension.ToLower())
            {
                case ".csv":
                    zipFilePath = fileName.Replace(".csv", ".zip");
                    break;
                case "":
                    zipFilePath = fileName + ".zip";
                    break;
                case ".zip":
                    zipFilePath = fileName;
                    break;
                default:
                    zipFilePath = fileName.Replace(f.Extension.ToLower(), ".zip");
                    break;
            }

            SaveFile(zipFilePath, data);
            ExtractFile(zipFilePath);
            DeleteFile(zipFilePath);
            return true;
        }

        public static void SaveFile(string targetFile, byte[] data)
        {
            if (string.IsNullOrEmpty(targetFile) || data.Length <= 0) return;
            FileInfo f = new FileInfo(targetFile);

            // Delete file if exitsted
            DeleteFile(targetFile);

            using (FileStream _FileStream = new FileStream(targetFile, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                _FileStream.Write(data, 0, data.Length);
            }

            DataFile.ExtractFile(targetFile);
        }

        public static void ExtractFile(string fileName)
        {
            if (!File.Exists(fileName)) return;

            FileInfo f = new FileInfo(fileName);
            if (f.Extension == ".zip")
            {
                using (ZipFile zip = ZipFile.Read(fileName))
                {
                    zip.ExtractAll(Path.GetDirectoryName(fileName), Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public static void DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
            }
            catch { 
                
            }
        }

        private static void DeleteRelateFile(string fileName)
        {
            FileInfo f = new FileInfo(fileName);

            string forlder = f.DirectoryName;
            string shortFileName = f.Name.Replace(f.Extension, string.Empty);

            string[] listFile = Directory.GetFiles(forlder, shortFileName+".*");
        
        }
    }
}
