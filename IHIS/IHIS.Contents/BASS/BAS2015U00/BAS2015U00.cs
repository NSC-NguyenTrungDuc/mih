using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using System.IO.Compression;
using System.IO;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using Ionic.Zip;
using KinkiType = IHIS.CloudConnector.Messaging.KinkiType;

namespace IHIS.BASS
{

    public partial class BAS2015U00 : XScreen
    {
        #region Proporties
        private string _filePath = string.Empty;
        private string _zipFilePath = string.Empty;
        private bool _isSendDataDone = false;
        private readonly int _COUNT = 200000;
        private string _previous;
        Dictionary<string, int> ImportTypeValueDic = new Dictionary<string, int>();
        Dictionary<string, string> FileNameKinkiDic = new Dictionary<string, string>();
        #endregion

        #region Init
        public BAS2015U00()
        {
            InitializeComponent();
            InitData();
        }

        private void BAS2015U00_Load(object sender, EventArgs e)
        {
            btnList.SetEnabled(FunctionType.Update, false);
            btnList.SetEnabled(FunctionType.Process, false);

            progressBar.Visible = true;
            progressBar.Refresh();
            progressBar.Minimum = 0;
            progressBar.Maximum = _COUNT;
            progressBar.Value = 0;
            progressBar.Step = 1;
        }

        private void InitData()
        {
            ImportTypeValueDic.Add("DRUG_KINKI_MESSAGE", 6);
            ImportTypeValueDic.Add("DRUG_KINKI_DISEASE", 8);
            ImportTypeValueDic.Add("DRUG_DOSAGE", 101);
            ImportTypeValueDic.Add("DRUG_CHECKING", 28);
            ImportTypeValueDic.Add("DRUG_INTERACTION", 12);
            ImportTypeValueDic.Add("DRUG_GENERIC_NAME", 10);

            FileNameKinkiDic.Add("DRUG_KINKI_MESSAGE", "Sample_kinki_honnbunn.csv");
            FileNameKinkiDic.Add("DRUG_KINKI_DISEASE", "Sample_kinki_byoumei.csv");
            FileNameKinkiDic.Add("DRUG_DOSAGE", "Sample_youhou.csv");
            FileNameKinkiDic.Add("DRUG_CHECKING", "info_part.csv");
            FileNameKinkiDic.Add("DRUG_INTERACTION", "Sample_Drug_Interaction.csv");
            FileNameKinkiDic.Add("DRUG_GENERIC_NAME", "Sample_Generic_Name.csv");
        }
        #endregion

        #region Functions
        internal string CompressCSVFile(string path)
        {
            if (!File.Exists(path))
            {
                _zipFilePath = string.Empty;
                return _zipFilePath;
            }
            _zipFilePath = path + ".zip";
            ZipFile zip = new ZipFile();
            List<string> pathLst = new List<string>();
            pathLst.Add(path);
            zip.AlternateEncodingUsage = ZipOption.Always;
            zip.AlternateEncoding = Encoding.UTF8;

            zip.AddFiles(pathLst, false, "");
            zip.Save(_zipFilePath);
            return _zipFilePath;
        }

        public void UncompressFile(string zipPath, string fileId)
        {
            if (!File.Exists(zipPath))
                return;
            
            string targetPath = zipPath;
            bool isSuccess = false;
            using (ZipFile zip = ZipFile.Read(zipPath))
            {
                zip.ExtractAll(Path.GetDirectoryName(targetPath), Ionic.Zip.ExtractExistingFileAction.DoNotOverwrite);
            }

            try
            {
                FileInfo f = new FileInfo(Path.GetDirectoryName(targetPath) + @"\" + GetFileName(fileId));
                string fileName = targetPath.Replace(".zip", ".csv");
                if (File.Exists(fileName))
                    File.Delete(fileName);
                f.MoveTo(fileName);
                isSuccess = true;
               
            }
            catch (IOException ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }

            finally
            {
                if (InputValidating(_filePath))
                    btnList.SetEnabled(FunctionType.Update, true);
                else
                    btnList.SetEnabled(FunctionType.Update, false);
                btnList.SetEnabled(FunctionType.Process, true);
                UpdateProgressBar(false);
                if (isSuccess)
                {
                    xMSG.Text = Resources.MSG_EXP_SUCCESS;
                    xMSG.ForeColor = new XColor(Color.Green);
                }
                else
                {
                    xMSG.Text = Resources.MSG_EXP_FAILED;
                    xMSG.ForeColor = new XColor(Color.Red);
                }
            }
        }

        private void ImportMasterData()
        {
            DialogResult ret = XMessageBox.Show(Resources.MSG_CONFIRM, Resources.CAPTION_CONFIRM,
                                                  MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Cancel || !InputValidating(_filePath))
                return;
            SendData(_filePath);
        }

        private void SendData(string path)
        {
            _isSendDataDone = false;
            xMSG.Text = string.Empty;
            btnList.SetEnabled(FunctionType.Update, false);
            btnList.SetEnabled(FunctionType.Process, false);

            string fileId = string.Empty;
            string zipFilePath = CompressCSVFile(_filePath);
            if (string.IsNullOrEmpty(zipFilePath) || !File.Exists(zipFilePath))
            {
                return;
            }
            byte[] data = File.ReadAllBytes(zipFilePath);

            BAS2015U00MasterDataArgs args = new BAS2015U00MasterDataArgs();
            args.KinkiType = GetImportType(out fileId);
            args.Data = data;
            args.ActionType = IHIS.CloudConnector.Messaging.ActionType.IMPORT;
            args.UserId = UserInfo.UserID;
            if (string.IsNullOrEmpty(fileId))
                return;
            switch (args.KinkiType)
            {
                case KinkiType.KINKI_MSG:
                    _previous = "DRUG_KINKI_MESSAGE";
                    break;
                case KinkiType.KINKI_DIEASE:
                    _previous = "DRUG_KINKI_DISEASE";
                    break;
                case KinkiType.DOSAGE:
                    _previous = "DRUG_DOSAGE";
                    break;
                case KinkiType.DRUG_CHECKING:
                    _previous = "DRUG_CHECKING";
                    break;
                case KinkiType.INTERATION:
                    _previous = "DRUG_INTERACTION";
                    break;
                case KinkiType.GENERIC_NAME:
                    _previous = "DRUG_GENERIC_NAME";
                    break;
                default:
                    break;
            }
            UpdateProgressBar(true);
            BAS2015U00MasterDataResult res = CloudService.Instance.Submit<BAS2015U00MasterDataResult, BAS2015U00MasterDataArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
            {
                xMSG.Text = Resources.MSG_SUCCESS;
                xMSG.ForeColor = new XColor(Color.Green);
            }
            else
            {
                xMSG.Text = Resources.MSG_ERR;
                xMSG.ForeColor = new XColor(Color.Red);
            }
            _isSendDataDone = true;
            //Todo
            if (_isSendDataDone)
                UpdateProgressBar(false);
            btnList.SetEnabled(FunctionType.Update, true);
            btnList.SetEnabled(FunctionType.Process, true);
        }

        private void ExportMasterData()
        {
            string filePath = string.Empty;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = saveFileDialog.FileName;
                else
                    filePath = string.Empty;
            }
            if (string.IsNullOrEmpty(filePath))
                return;
            byte[] Data = GetCSVFileFromServer();
            if (Data == null)
            {
                xMSG.Text = Resources.MSG_ERR;
                xMSG.ForeColor = new XColor(Color.Red);
                return;
            }
            string fileId = string.Empty;
            GetImportType(out fileId);
            SaveToFile(filePath, Data, fileId);
        }

        private byte[] GetCSVFileFromServer()
        {
            xMSG.Text = string.Empty;
            btnList.SetEnabled(FunctionType.Update, false);
            btnList.SetEnabled(FunctionType.Process, false);
            UpdateProgressBar(true);
            string fileId = string.Empty;
            BAS2015U00MasterDataArgs args = new BAS2015U00MasterDataArgs();
            args.KinkiType = GetImportType(out fileId);
            args.Data = null;
            args.ActionType = IHIS.CloudConnector.Messaging.ActionType.EXPORT;
            args.UserId = UserInfo.UserID;
            BAS2015U00MasterDataResult res = CloudService.Instance.Submit<BAS2015U00MasterDataResult, BAS2015U00MasterDataArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
            {
                return ConvertToByteArr(res.Data);
            }
            else
            {
                xMSG.Text = Resources.MSG_ERR;
                xMSG.ForeColor = new XColor(Color.Red);
            }
            return null;
        }

        /// <summary>
        /// Save zip file to lacal and unzip file with new file name
        /// </summary>
        /// <param name="targetFile"></param>
        /// <param name="data"></param>
        /// <param name="fileId"></param>
        private void SaveToFile(string targetFile, byte[] data, string fileId)
        {
            if (string.IsNullOrEmpty(targetFile) || data.Length <= 0)
                return;
            FileInfo f = new FileInfo(targetFile);
            string zipFilePath = string.Empty;
            switch (f.Extension.ToLower())
            {
                case ".csv":
                    zipFilePath = targetFile.Replace(".csv", ".zip");
                    break;
                case "":
                    zipFilePath = targetFile + ".zip";
                    break;
                case ".zip":
                    zipFilePath = targetFile;
                    break;
                default:
                    zipFilePath = targetFile.Replace(f.Extension.ToLower(), ".zip");
                    break;
            }

            using (FileStream _FileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                _FileStream.Write(data, 0, data.Length);
            }
            UncompressFile(zipFilePath, fileId);
        }
        #endregion

        #region Event Handler
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            try
            {
                switch (e.Func)
                {
                    case FunctionType.Update:
                        ImportMasterData();
                        break;
                    case FunctionType.Process:
                        ExportMasterData();
                        break;
                    case FunctionType.Close:
                        break;
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            _filePath = string.Empty;
            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog.FileName;
            }

            txtFileDirectory.Text = filePath;
            _filePath = filePath.Trim();
            InputValidating(_filePath);
        }

        private void rdb_Click(object sender, EventArgs e)
        {
            btnList.SetEnabled(FunctionType.Process, true);
            RadioButton rad = (RadioButton) sender;
            if (rad.Tag.ToString() != _previous && _previous != null)
            {
                txtFileDirectory.Clear();
                xMSG.Clear();
                _previous = null;
                _filePath = String.Empty;
                progressBar.Value = 0;
            }
            if (string.IsNullOrEmpty(_filePath))
                return;
            InputValidating(_filePath);
        }
        #endregion

        #region Common
        private bool InputValidating(string filePath)
        {
            string fileID = string.Empty;
            GetImportType(out fileID);
            progressBar.Value = 0;
            xMSG.Text = string.Empty;
            if (!File.Exists(filePath) || string.IsNullOrEmpty(fileID))
            {
                btnList.SetEnabled(FunctionType.Update, false);
                xMSG.ForeColor = new XColor(Color.Red);
                return false;
            }

            if (ImportTypeValueDic.ContainsKey(fileID))
            {
                if (ImportTypeValueDic[fileID] != GetCSVColomnNumber(filePath))
                {
                    xMSG.Text = string.Format(Resources.MSG_FILE_VALIDATE, ImportTypeValueDic[fileID]);
                    btnList.SetEnabled(FunctionType.Update, false);
                    xMSG.ForeColor = new XColor(Color.Red);
                    return false;
                }
            }

            btnList.SetEnabled(FunctionType.Update, true);
            return true;
        }

        private KinkiType GetImportType(out string fileId)
        {
            string mFileId = string.Empty;
            KinkiType ret = new KinkiType();
            foreach (Control r in xPanel1.Controls)
            {
                if (r is RadioButton && ((RadioButton)r).Checked)
                {
                    mFileId = r.Tag.ToString();
                    switch (r.Tag.ToString())
                    {
                        case "DRUG_KINKI_MESSAGE":
                            ret = KinkiType.KINKI_MSG;
                            break;
                        case "DRUG_KINKI_DISEASE":
                            ret = KinkiType.KINKI_DIEASE;
                            break;
                        case "DRUG_DOSAGE":
                            ret = KinkiType.DOSAGE;
                            break;
                        case "DRUG_CHECKING":
                            ret = KinkiType.DRUG_CHECKING;
                            break;
                        case "DRUG_INTERACTION":
                            ret = KinkiType.INTERATION;
                            break;
                        case "DRUG_GENERIC_NAME":
                            ret = KinkiType.GENERIC_NAME;
                            break;
                        default:
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(mFileId))
                    break;
            }
            fileId = mFileId;
            return ret;
        }

        private string GetFileName(string fileID)
        {
            if (FileNameKinkiDic.ContainsKey(fileID))
            {
                return FileNameKinkiDic[fileID];
            }
            return string.Empty;
        }

        private int GetCSVColomnNumber(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines[0].Split(new char[] { ',' }).Length;
            }
            return -1;
        }

        private byte[] ConvertToByteArr(List<byte[]> buffers)
        {
            int totalLength = 0;
            foreach (byte[] item in buffers)
                totalLength = totalLength + item.Length;

            byte[] fullBuffer = new byte[totalLength];

            int insertPosition = 0;
            foreach (byte[] buffer in buffers)
            {
                buffer.CopyTo(fullBuffer, insertPosition);
                insertPosition += buffer.Length;
            }
            return fullBuffer;
        }

        private void UpdateProgressBar(bool isStart)
        {
            if (isStart)
                for (int i = 20000; i < 50000; i++)
                {
                    this.progressBar.Value = i;
                }
            else
                for (int i = 170000; i < _COUNT; i++)
                {
                    this.progressBar.Value = i;
                }
        }
        #endregion
    }
}
