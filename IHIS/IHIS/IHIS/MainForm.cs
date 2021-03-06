using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Reflection;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.DataAccess.Entities;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts;
using Ionic.Zip;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using IHIS.CloudConnector.Socket;
using IHIS.CloudConnector.Contracts.Results;
using System.Security.Principal;
using IHIS.CloudConnector.DataAccess;
using DrugCheckingInfo = IHIS.CloudConnector.Contracts.Models.System.DrugCheckingInfo;
using DrugDosageInfo = IHIS.CloudConnector.Contracts.Models.System.DrugDosageInfo;
using DrugGenericNameInfo = IHIS.CloudConnector.Contracts.Models.System.DrugGenericNameInfo;
using DrugInteractionInfo = IHIS.CloudConnector.Contracts.Models.System.DrugInteractionInfo;
using DrugKinkiDiseaseInfo = IHIS.CloudConnector.Contracts.Models.System.DrugKinkiDiseaseInfo;
using DrugKinkiMessageInfo = IHIS.CloudConnector.Contracts.Models.System.DrugKinkiMessageInfo;
using MainFormGetMainMenuItemInfo = IHIS.CloudConnector.Contracts.Models.System.MainFormGetMainMenuItemInfo;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Messaging;
using System.Configuration;

namespace IHIS
{
    /// <summary>
    /// MainForm에 대한 요약 설명입니다.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        #region static Fields
        //Window Msg Const
        const int MSG_IHIS_INSTANCE_FOCUS = (int)(Msgs.WM_USER + 101);
        const int MSG_SYSTEM_INSTANCE_FOCUS = (int)(Msgs.WM_USER + 102);
        const int MSG_SYSTEM_WINDOW_HANDLE_SEND = (int)(Msgs.WM_USER + 103);
        const int MSG_MESSAGE_SYSTEM_CLOSE = (int)(Msgs.WM_USER + 105);
        const int MSG_SYSTEM_USER_LOGIN = (int)(Msgs.WM_USER + 106); //시스템사용자 LOGIN MSG
        const int MSG_SYSTEM_USER_LOGOUT = (int)(Msgs.WM_USER + 107); //시스템사용자 LOGOUT 메세지
        const int MSG_SYSTEM_USER_CHANGED = (int)(Msgs.WM_USER + 108); //시스템 사용자 변경 메세지
        //XMSG(메세지송수신 시스템)
        const int MSG_XMSG_DISPLAY = (int)(Msgs.WM_USER + 111);
        //메세지시스템 관련
        const int MSG_FIND_MSG_SYSTEM = (int)(Msgs.WM_USER + 120);
        //메세지 시스템 관련
        const string MSG_SYS_KEY = "SOFTWARE\\IHIS\\MSGSYS";
        const string XMSG_SYSTEM_ID = "ADMM";

        static IntPtr ifcHandle = IntPtr.Zero;
        static string currentSystemID = "";
        static string currentSystemName = "";
        static string currentGroupID = "";
        static string currentGroupName = "";
        static string imagePath = Application.StartupPath + @"\Images\";
        static string currentUserID = "";   //전달된 현재 사용자 ID
        //메세지 시스템 관련 변수　
        static string msgGroupID = "";
        static string msgGroupName = "";
        static string msgSystemID = "";
        static string msgSystemName = "";
        static string BARCODE_FONT_FILE = "3OF9_NEW.TTF";
        static string fullName = Application.StartupPath + "\\BarCodeFont\\" + BARCODE_FONT_FILE;
        #endregion

        #region Fields
        private DataTable sysInfoTable = new DataTable("SystemList");
        private DataTable msgSystemTable = new DataTable("SystemList");
        //private MainMenuResult sysInfoList = new MainMenuResult();
        //private MainMenuResult msgSystemList = new MainMenuResult();
        private ArrayList displayGroupList = new ArrayList();
        private bool autoSystemOpen = false;
        private UdpServer udpServer = null;
        // Thread
        private Thread udpThread = null;
        //Msg PopUp창
        private MsgPopupForm msgPopupForm = null;
        //TabPage관련
        private int selectedIndex = 0;  //첫번째
        private Image firstImage = null;  //첫번째 TABPage 이미지
        private Image secondImage = null; //두번째 TabPage 이미지
        private Rectangle firstRegion = new Rectangle(10, 15, 290, 30); //첫번째 TabPage 영역
        private Rectangle secondRegion = new Rectangle(305, 15, 290, 30); //두번째 TabPage 영역
        //Form Move 관련
        private bool isInMoving = false;
        private int mouseDownX = 0;
        private int mouseDownY = 0;
        //Admin사용자 관련
        private string adminUserYn = "N";
        #endregion

        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.ListView lvList;
        private IHIS.XPButton btnSend;
        private IHIS.XPButton btnSystemClose;
        private IHIS.XPButton btnRun;
        private IHIS.XPButton btnMinimize;
        private IHIS.XPButton btnLogout;
        private System.Windows.Forms.ListView lvOpenList;
        private System.Windows.Forms.ListView lvMyList;
        private IHIS.XPButton btnDelMySystem;
        private IHIS.XPButton btnRegMySystem;
        private IHIS.XPButton btnAdmLogin;
        private IHIS.XPButton btnRegMsg;
        private System.Windows.Forms.ListView lvMsgList;
        private IHIS.XPButton btnUnRegMsg;
        private System.Windows.Forms.Label lbMsg;
        private IHIS.XPButton btnShowMsg;
        private System.Windows.Forms.ImageList imageListSystem;
        private System.Windows.Forms.ImageList imageListGroup;
        private System.ComponentModel.IContainer components;
        private Label ServerTypeName;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pbxNotifyON;
        private XPButton btnNewMasterData;
        private PictureBox pbxNotifyOFF;
        //private int offset = 5000;
        private System.Windows.Forms.Timer timer1;

        //public MainForm()
        //{
        //    try
        //    {
        //        Thread.CurrentThread.CurrentCulture = XLocalizable.CultureInfo;
        //        Thread.CurrentThread.CurrentUICulture = XLocalizable.CultureInfo;

        //        //
        //        // Windows Form 디자이너 지원에 필요합니다.
        //        //
        //        InitializeComponent();

        //        //
        //        // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
        //        //
        //        //args로 SystemID 넘어오면 업무 자동선택처리, 없으면 선택창에서 선택하게 처리
        //        //if (args.Length == 1)
        //        //{
        //        //    currentSystemID = args[0];
        //        //    this.autoSystemOpen = true;
        //        //}

        //        //배경이미지 설정
        //        SetBackgroundImage();

        //        if (this.firstImage != null)
        //        {
        //            //Size 설정 (MaxSize도 고정)
        //            this.ClientSize = firstImage.Size;
        //            this.MaximumSize = firstImage.Size;

        //            this.Region = new Region(CalculateGraphicsPath((Bitmap)firstImage));
        //        }


        //        //메세지창 생성
        //        this.msgPopupForm = new MsgPopupForm();

        //        //일본,한글 모드에 따른 버튼 Text Set
        //        SetControlTextByLangMode();
        //    }
        //    catch (Exception xe)
        //    {
        //        MessageBox.Show("MainForm 생성자 Error=" + xe.Message);
        //        MessageBox.Show(xe.StackTrace);
        //    }
        //}

        public MainForm(string[] args)
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = XLocalizable.CultureInfo;
                Thread.CurrentThread.CurrentUICulture = XLocalizable.CultureInfo;

                //
                // Windows Form 디자이너 지원에 필요합니다.
                //
                InitializeComponent();
                //
                // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
                //

                // MED-14286
                if (NetInfo.Language != LangMode.Jr)
                {
                    this.Font = new Font("Arial", 8.75f);
                }

                //args로 SystemID 넘어오면 업무 자동선택처리, 없으면 선택창에서 선택하게 처리
                if (args.Length == 1)
                {
                    currentSystemID = args[0];
                    this.autoSystemOpen = true;
                }

                //배경이미지 설정
                SetBackgroundImage();

                if (this.firstImage != null)
                {
                    // https://sofiamedix.atlassian.net/browse/MED-13394
                    ////Size 설정 (MaxSize도 고정)
                    //this.ClientSize = firstImage.Size;
                    //this.MaximumSize = firstImage.Size;

                    //this.Region = new Region(CalculateGraphicsPath((Bitmap)firstImage));
                }

                //메세지창 생성
                this.msgPopupForm = new MsgPopupForm();

                //일본,한글 모드에 따른 버튼 Text Set
                SetControlTextByLangMode();

                //this.SyncCache();
                try
                {
                    Thread thread = new Thread(new ThreadStart(SyncCache));
                    thread.Start();
                }
                catch (Exception ex)
                {
                    Logs.WriteLog(ex.Message);
                    Logs.WriteLog(ex.StackTrace);
                }
                finally { }
            }
            catch (Exception xe)
            {
                MessageBox.Show("MainForm 생성자 Error=" + xe.Message);
                MessageBox.Show(xe.StackTrace);
            }
        }

        #region sync Cache
        public void SyncCache()
        {
            //SyncDrugKinkiMessage();
            //SyncDrugKinkiDisease();
            //SyncDrugInteraction();
            //SyncDrugGenericName();
            //SyncDrugDosage();
            //SyncDrugCheckingDao();

            // https://sofiamedix.atlassian.net/browse/MED-8027
            try
            {
                // Current kinki revision (stored in memory cache)
                string currentRevision = CacheService.Instance.Get<string>(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_CHECKING);

                // Download new kinki master if a new revision was updated.
                if (UserInfo.CheckKinki && (string.IsNullOrEmpty(currentRevision) || !UserInfo.VersionDrugChecking.Equals(currentRevision)))
                {
                    // Download kinki.zip from file server
                    string downloadUri = ConfigurationManager.AppSettings["KinkiDownloadURL"];
                    string savePath = Environment.CurrentDirectory + "\\SQLiteDB\\kinki.zip";

                    // Missing download URI?
                    if (string.IsNullOrEmpty(downloadUri)) return;

                    // Delete existing file (if any)
                    if (File.Exists(savePath))
                    {
                        File.Delete(savePath);
                    }

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadCompleted);
                        //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                        client.DownloadFileAsync(new Uri(downloadUri), savePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                // Remove cache revision when download failed
                if (e.Error != null)
                {
                    CacheService.Instance.Remove(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_CHECKING);
                }

                // Path to Unzip
                string extractPath = Environment.CurrentDirectory + "\\SQLiteDB\\";

                // Unzip
                using (ZipFile zip = ZipFile.Read(Environment.CurrentDirectory + "\\SQLiteDB\\kinki.zip"))
                {
                    if (File.Exists(Environment.CurrentDirectory + "\\SQLiteDB\\main.db.tmp"))
                    {
                        File.Delete(Environment.CurrentDirectory + "\\SQLiteDB\\main.db.tmp");
                    }

                    zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                }

                // Rename to kcck.db
                if (File.Exists(Environment.CurrentDirectory + "\\SQLiteDB\\main.db"))
                {
                    File.Copy(Environment.CurrentDirectory + "\\SQLiteDB\\main.db", Environment.CurrentDirectory + "\\SQLiteDB\\kcck.db", true);
                    File.Delete(Environment.CurrentDirectory + "\\SQLiteDB\\main.db");
                }

                // Update revision
                CacheService.Instance.Remove(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_CHECKING);
                CacheService.Instance.Set(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_CHECKING, UserInfo.VersionDrugChecking, TimeSpan.MaxValue);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        public void SyncDrugKinkiMessage()
        {
            string oldVersion = CacheService.Instance.Get<string>(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_KINKI_MESSAGE);
            if (UserInfo.CheckKinki && (String.IsNullOrEmpty(oldVersion) || !UserInfo.VersionDrugKinkiMessage.Equals(oldVersion)))
            {
                IDrugKinkiMessageDao itemDao = DataAccess.Cache.DrugKinkiMessageDao;
                itemDao.Truncate(true);

                SyncKinkiCacheArgs args = new SyncKinkiCacheArgs();
                args.KinkiType = KinkiType.KINKI_MSG;
                SyncKinkiCacheResult result = CloudService.Instance.Submit<SyncKinkiCacheResult, SyncKinkiCacheArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success && result.Data.Count > 0)
                {
                    string fileName = "DRUG_KINKI_MESSAGE.csv";
                    SaveData(fileName, result.Data[0]);
                    List<DrugKinkiMessage> lst = new List<DrugKinkiMessage>();

                    string path = Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName;

                    DataTable data = GetDataTabletFromCsvFile(path, false);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        DrugKinkiMessage drug = new DrugKinkiMessage();
                        drug.DrugId = data.Rows[i][0].ToString();
                        drug.BranchNumber = data.Rows[i][1].ToString();
                        drug.WarningLevel = data.Rows[i][2].ToString();
                        drug.KinkiId = data.Rows[i][3].ToString();
                        drug.Message = data.Rows[i][4].ToString();
                        drug.Category = data.Rows[i][5].ToString();
                        lst.Add(drug);
                    }


                    //string[] lines = File.ReadAllLines(path);
                    //for (int i = 0; i < lines.GetLength(0); i++)
                    //{
                    //    string[] fields = lines[i].Split(new char[] { ',' });

                    //    DrugKinkiMessage drug = new DrugKinkiMessage();
                    //    drug.DrugId = fields[0];
                    //    drug.BranchNumber = fields[1];
                    //    drug.WarningLevel = fields[2];
                    //    drug.KinkiId = fields[3];
                    //    drug.Message = fields[4];
                    //    drug.Category = fields[5];
                    //    lst.Add(drug);
                    //}
                    DeleteFile(path);
                    itemDao.Insert(lst, true);
                    itemDao.Truncate();
                    itemDao.CopyData();
                    itemDao.Truncate(true);
                    //Update cache version
                    CacheService.Instance.Remove(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_KINKI_MESSAGE);
                    CacheService.Instance.Set(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_KINKI_MESSAGE, UserInfo.VersionDrugKinkiMessage, TimeSpan.MaxValue);
                }
            }
        }

        public void SyncDrugKinkiDisease()
        {
            string oldVersion = CacheService.Instance.Get<string>(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_KINKI_DISEASE);
            if (UserInfo.CheckKinki && (String.IsNullOrEmpty(oldVersion) || !UserInfo.VersionDrugKinkiDisease.Equals(oldVersion)))
            {
                IDrugKinkiDiseaseDao itemDao = DataAccess.Cache.DrugKinkiDiseaseDao;
                itemDao.Truncate(true);
                SyncKinkiCacheArgs args = new SyncKinkiCacheArgs();
                args.KinkiType = KinkiType.KINKI_DIEASE;
                SyncKinkiCacheResult result = CloudService.Instance.Submit<SyncKinkiCacheResult, SyncKinkiCacheArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success && result.Data.Count > 0)
                {
                    string fileName = "DRUG_KINKI_DISEASE.csv";
                    SaveData(fileName, result.Data[0]);
                    List<DrugKinkiDisease> lst = new List<DrugKinkiDisease>();

                    string path = Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName;
                    DataTable data = GetDataTabletFromCsvFile(path, false);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        DrugKinkiDisease drug = new DrugKinkiDisease();
                        drug.KinkiId = data.Rows[i][0].ToString();
                        drug.DiseaseName = data.Rows[i][1].ToString();
                        drug.IndexTerm = data.Rows[i][2].ToString();
                        drug.StandardDiseaseName = data.Rows[i][3].ToString();
                        drug.DiseaseCode = data.Rows[i][4].ToString();
                        drug.Icd10 = data.Rows[i][5].ToString();
                        drug.DicisionFlag = data.Rows[i][6].ToString();
                        drug.Comment = data.Rows[i][7].ToString();
                        lst.Add(drug);
                    }
                    DeleteFile(path);
                    itemDao.Insert(lst, true);
                    itemDao.Truncate();
                    itemDao.CopyData();
                    itemDao.Truncate(true);
                    //Update cache version
                    CacheService.Instance.Remove(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_KINKI_DISEASE);
                    CacheService.Instance.Set(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_KINKI_DISEASE, UserInfo.VersionDrugKinkiDisease, TimeSpan.MaxValue);
                }
            }
        }

        public void SyncDrugInteraction()
        {
            string oldVersion = CacheService.Instance.Get<string>(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_INTERACTION);
            if (UserInfo.CheckDosage && (String.IsNullOrEmpty(oldVersion) || !UserInfo.VersionDrugInteraction.Equals(oldVersion)))
            {
                IDrugInteractionDao itemDao = DataAccess.Cache.DrugInteractionDao;
                itemDao.Truncate(true);
                SyncKinkiCacheArgs args = new SyncKinkiCacheArgs();
                args.KinkiType = KinkiType.INTERATION;
                SyncKinkiCacheResult result = CloudService.Instance.Submit<SyncKinkiCacheResult, SyncKinkiCacheArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success && result.Data.Count > 0)
                {
                    string fileName = "DRUG_INTERACTION.csv";
                    SaveData(fileName, result.Data[0]);
                    List<DrugInteraction> lst = new List<DrugInteraction>();

                    string path = Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName;

                    DataTable data = GetDataTabletFromCsvFile(path, false);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        DrugInteraction drug = new DrugInteraction();
                        drug.DrugId = data.Rows[i][0].ToString();
                        drug.BranchNumber = data.Rows[i][1].ToString();
                        drug.Yj9Code = data.Rows[i][2].ToString();
                        drug.DescribedClassification = data.Rows[i][3].ToString();
                        drug.A5 = data.Rows[i][4].ToString();
                        drug.A6 = data.Rows[i][5].ToString();
                        drug.A7 = data.Rows[i][6].ToString();
                        drug.A8 = data.Rows[i][7].ToString();
                        drug.A9 = data.Rows[i][8].ToString();
                        drug.OrderNote = data.Rows[i][9].ToString();
                        drug.A11 = data.Rows[i][10].ToString();
                        drug.Comment = data.Rows[i][11].ToString();

                        lst.Add(drug);
                    }
                    DeleteFile(path);
                    itemDao.Insert(lst, true);
                    itemDao.Truncate();
                    itemDao.CopyData();
                    itemDao.Truncate(true);
                    //Update cache version
                    CacheService.Instance.Remove(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_INTERACTION);
                    CacheService.Instance.Set(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_INTERACTION, UserInfo.VersionDrugInteraction, TimeSpan.MaxValue);

                }
            }
        }

        public void SyncDrugGenericName()
        {
            string oldVersion = CacheService.Instance.Get<string>(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_GENERIC_NAME);
            if (UserInfo.CheckInteraction && (String.IsNullOrEmpty(oldVersion) || !UserInfo.VersionDrugGenericName.Equals(oldVersion)))
            {
                IDrugGenericNameDao itemDao = DataAccess.Cache.DrugGenericNameDao;
                itemDao.Truncate(true);
                SyncKinkiCacheArgs args = new SyncKinkiCacheArgs();
                args.KinkiType = KinkiType.GENERIC_NAME;
                SyncKinkiCacheResult result = CloudService.Instance.Submit<SyncKinkiCacheResult, SyncKinkiCacheArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success && result.Data.Count > 0)
                {
                    string fileName = "DRUG_GENERIC_NAME.csv";
                    SaveData(fileName, result.Data[0]);

                    string path = Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName;
                    List<DrugGenericName> lst = new List<DrugGenericName>();
                    DataTable data = GetDataTabletFromCsvFile(path, false);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        DrugGenericName drug = new DrugGenericName();
                        drug.DrugId = data.Rows[i][0].ToString();
                        drug.BranchNumber = data.Rows[i][1].ToString();
                        drug.Yj9Code = data.Rows[i][2].ToString();
                        drug.DescribedClassification = data.Rows[i][3].ToString();
                        drug.OrderNote = data.Rows[i][4].ToString();
                        drug.A6 = data.Rows[i][5].ToString();
                        drug.Yj9CodeEffect = data.Rows[i][6].ToString();
                        drug.A8 = data.Rows[i][7].ToString();
                        drug.Comment1 = data.Rows[i][8].ToString();
                        drug.Comment2 = data.Rows[i][9].ToString();

                        lst.Add(drug);
                    }
                    DeleteFile(path);
                    itemDao.Insert(lst, true);
                    itemDao.Truncate();
                    itemDao.CopyData();
                    itemDao.Truncate(true);
                    //Update cache version
                    CacheService.Instance.Remove(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_GENERIC_NAME);
                    CacheService.Instance.Set(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_GENERIC_NAME, UserInfo.VersionDrugGenericName, TimeSpan.MaxValue);

                }
            }
        }

        public void SyncDrugDosage()
        {
            string oldVersion = CacheService.Instance.Get<string>(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_DOSAGE);
            if (UserInfo.CheckDosage && (String.IsNullOrEmpty(oldVersion) || !UserInfo.VersionDrugDosage.Equals(oldVersion)))
            {
                SyncKinkiCacheArgs args = new SyncKinkiCacheArgs();
                args.KinkiType = KinkiType.DOSAGE;
                SyncKinkiCacheResult result = CloudService.Instance.Submit<SyncKinkiCacheResult, SyncKinkiCacheArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success && result.Data.Count > 0)
                {
                    string fileName1 = "DRUG_DOSAGE.csv";
                    string fileName2 = "DRUG_DOSAGE_NORMAL.csv";
                    string fileName3 = "DRUG_DOSAGE_STANDARD.csv";
                    string fileName4 = "DRUG_DOSAGE_ADDITION.csv";

                    SaveData(fileName1, result.Data[0]);
                    bool check = false;
                    check = SaveDrugDosage(Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName1);
                    if (check)
                        check = SaveDrugDosageNormal(Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName2);
                    if (check)
                        check = SaveDrugDosageStandard(Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName3);
                    if (check)
                        check = SaveDrugDosageAddtion(Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName4);
                    if (check)
                    {
                        //Update cache version
                        CacheService.Instance.Remove(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_DOSAGE);
                        CacheService.Instance.Set(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_DOSAGE, UserInfo.VersionDrugDosage, TimeSpan.MaxValue);
                    }
                }
            }
        }

        public void SyncDrugCheckingDao()
        {
            string oldVersion = CacheService.Instance.Get<string>(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_CHECKING);
            if ((UserInfo.CheckDosage || UserInfo.CheckKinki || UserInfo.CheckInteraction) && (String.IsNullOrEmpty(oldVersion) || !UserInfo.VersionDrugChecking.Equals(oldVersion)))
            {
                IDrugCheckingDao itemDao = DataAccess.Cache.DrugCheckingDao;
                itemDao.Truncate(true);
                SyncKinkiCacheArgs args = new SyncKinkiCacheArgs();
                args.KinkiType = KinkiType.DRUG_CHECKING;
                SyncKinkiCacheResult result = CloudService.Instance.Submit<SyncKinkiCacheResult, SyncKinkiCacheArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success && result.Data.Count > 0)
                {
                    string fileName = "DRUG_CHECKING.csv";
                    SaveData(fileName, result.Data[0]);

                    List<DrugChecking> lst = new List<DrugChecking>();
                    string path = Environment.CurrentDirectory + "\\SQLiteDB\\" + fileName;
                    DataTable data = GetDataTabletFromCsvFile(path, false);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        DrugChecking drug = new DrugChecking();
                        drug.DrugId = data.Rows[i][0].ToString();
                        drug.BranchNumber = data.Rows[i][1].ToString();
                        drug.A3 = data.Rows[i][2].ToString();
                        drug.A4 = data.Rows[i][3].ToString();
                        drug.A5 = data.Rows[i][4].ToString();
                        drug.A6 = data.Rows[i][5].ToString();
                        drug.A7 = data.Rows[i][6].ToString();
                        drug.A8 = data.Rows[i][7].ToString();
                        drug.A9 = data.Rows[i][8].ToString();
                        drug.YjCode = data.Rows[i][9].ToString();
                        drug.A11 = data.Rows[i][10].ToString();
                        drug.A12 = data.Rows[i][11].ToString();
                        drug.A13 = data.Rows[i][12].ToString();
                        drug.A14 = data.Rows[i][13].ToString();
                        drug.A15 = data.Rows[i][14].ToString();
                        drug.A16 = data.Rows[i][15].ToString();
                        drug.A17 = data.Rows[i][16].ToString();
                        drug.A18 = data.Rows[i][17].ToString();
                        drug.A19 = data.Rows[i][18].ToString();
                        drug.A20 = data.Rows[i][19].ToString();
                        drug.A21 = data.Rows[i][20].ToString();
                        drug.A22 = data.Rows[i][21].ToString();
                        drug.A23 = data.Rows[i][22].ToString();
                        drug.A24 = data.Rows[i][23].ToString();
                        drug.A25 = data.Rows[i][24].ToString();
                        drug.A26 = data.Rows[i][25].ToString();
                        drug.A27 = data.Rows[i][26].ToString();
                        drug.A28 = data.Rows[i][27].ToString();

                        lst.Add(drug);
                    }
                    DeleteFile(path);
                    itemDao.Insert(lst, true);
                    itemDao.Truncate();
                    itemDao.CopyData();
                    itemDao.Truncate(true);
                    //Update cache version
                    CacheService.Instance.Remove(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_CHECKING);
                    CacheService.Instance.Set(Constants.CacheKinki.CACHE_KINKI_REVISION_DRUG_CHECKING, UserInfo.VersionDrugChecking, TimeSpan.MaxValue);
                }

            }
        }

        public bool SaveDrugDosage(string path)
        {
            try
            {
                IDrugDosageDao itemDao = DataAccess.Cache.DrugDosageDao;
                itemDao.Truncate(true);

                List<DrugDosage> lst = new List<DrugDosage>();
                DataTable data = GetDataTabletFromCsvFile(path, false);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DrugDosage drug = new DrugDosage();
                    drug.DrugId = data.Rows[i][0].ToString();
                    drug.BranchNumber = data.Rows[i][1].ToString();
                    drug.DosageBranchNumber = data.Rows[i][2].ToString();
                    drug.A4 = data.Rows[i][3].ToString();
                    drug.A5 = data.Rows[i][4].ToString();
                    drug.Adaptation = data.Rows[i][5].ToString();
                    drug.AdaptationRelated = data.Rows[i][6].ToString();
                    drug.A8 = data.Rows[i][7].ToString();
                    drug.AgeClassification = data.Rows[i][8].ToString();
                    drug.Appropriate = data.Rows[i][9].ToString();
                    drug.AppropriateCondition = data.Rows[i][10].ToString();
                    drug.A12 = data.Rows[i][11].ToString();
                    drug.A13 = data.Rows[i][12].ToString();
                    drug.OneDose = data.Rows[i][13].ToString();

                    lst.Add(drug);
                }

                DeleteFile(path);
                itemDao.Insert(lst, true);
                itemDao.Truncate();
                itemDao.CopyData();
                itemDao.Truncate(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool SaveDrugDosageStandard(string path)
        {
            try
            {
                IDrugDosageStandardDao itemDao = DataAccess.Cache.DrugDosageStandardDao;
                itemDao.Truncate(true);

                List<DrugDosageStandard> lst = new List<DrugDosageStandard>();
                DataTable data = GetDataTabletFromCsvFile(path, false);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DrugDosageStandard drug = new DrugDosageStandard();
                    drug.DrugId = data.Rows[i][0].ToString();
                    drug.BranchNumber = data.Rows[i][1].ToString();
                    drug.DosageBranchNumber = data.Rows[i][2].ToString();
                    drug.A44 = data.Rows[i][3].ToString();
                    drug.A45 = data.Rows[i][4].ToString();
                    drug.A46 = data.Rows[i][5].ToString();
                    drug.A47 = data.Rows[i][6].ToString();
                    drug.A48 = data.Rows[i][7].ToString();
                    drug.A49 = data.Rows[i][8].ToString();
                    drug.A50 = data.Rows[i][9].ToString();
                    drug.A51 = data.Rows[i][10].ToString();
                    drug.A52 = data.Rows[i][11].ToString();
                    drug.A53 = data.Rows[i][12].ToString();
                    drug.A54 = data.Rows[i][13].ToString();
                    drug.A55 = data.Rows[i][14].ToString();
                    drug.A56 = data.Rows[i][15].ToString();
                    drug.A57 = data.Rows[i][16].ToString();
                    drug.A58 = data.Rows[i][17].ToString();
                    drug.A59 = data.Rows[i][18].ToString();
                    drug.A60 = data.Rows[i][19].ToString();
                    drug.A61 = data.Rows[i][20].ToString();
                    drug.A62 = data.Rows[i][21].ToString();
                    drug.A63 = data.Rows[i][22].ToString();
                    drug.A64 = data.Rows[i][23].ToString();
                    drug.A65 = data.Rows[i][24].ToString();
                    drug.A66 = data.Rows[i][25].ToString();
                    drug.A67 = data.Rows[i][26].ToString();
                    drug.A68 = data.Rows[i][27].ToString();
                    drug.A69 = data.Rows[i][28].ToString();
                    drug.A70 = data.Rows[i][29].ToString();
                    drug.A71 = data.Rows[i][30].ToString();
                    drug.A72 = data.Rows[i][31].ToString();

                    lst.Add(drug);
                }
                DeleteFile(path);
                itemDao.Insert(lst, true);
                itemDao.Truncate();
                itemDao.CopyData();
                itemDao.Truncate(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveDrugDosageNormal(string path)
        {
            try
            {
                IDrugDosageNormalDao itemDao = DataAccess.Cache.DrugDosageNormalDao;
                itemDao.Truncate(true);
                List<DrugDosageNormal> lst = new List<DrugDosageNormal>();
                DataTable data = GetDataTabletFromCsvFile(path, false);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DrugDosageNormal drug = new DrugDosageNormal();
                    drug.DrugId = data.Rows[i][0].ToString();
                    drug.BranchNumber = data.Rows[i][1].ToString();
                    drug.DosageBranchNumber = data.Rows[i][2].ToString();
                    drug.DailyDose = data.Rows[i][3].ToString();
                    drug.DailyDoseContent = data.Rows[i][4].ToString();
                    drug.DoseForm = data.Rows[i][5].ToString();
                    drug.DailyDoseForm = data.Rows[i][6].ToString();
                    drug.DosageFormUnit = data.Rows[i][7].ToString();
                    drug.DailyNumberDoses = data.Rows[i][8].ToString();
                    drug.A21 = data.Rows[i][9].ToString();
                    drug.A22 = data.Rows[i][10].ToString();
                    drug.A23 = data.Rows[i][11].ToString();
                    drug.A24 = data.Rows[i][12].ToString();
                    drug.A25 = data.Rows[i][13].ToString();
                    drug.A26 = data.Rows[i][14].ToString();
                    drug.A27 = data.Rows[i][15].ToString();
                    drug.A28 = data.Rows[i][16].ToString();
                    drug.A29 = data.Rows[i][17].ToString();
                    drug.A30 = data.Rows[i][18].ToString();
                    drug.A31 = data.Rows[i][19].ToString();
                    drug.A32 = data.Rows[i][20].ToString();
                    drug.A33 = data.Rows[i][21].ToString();
                    drug.A34 = data.Rows[i][22].ToString();
                    drug.A35 = data.Rows[i][23].ToString();
                    drug.A36 = data.Rows[i][24].ToString();
                    drug.A37 = data.Rows[i][25].ToString();
                    drug.A38 = data.Rows[i][26].ToString();
                    drug.A39 = data.Rows[i][27].ToString();
                    drug.A40 = data.Rows[i][28].ToString();
                    drug.A41 = data.Rows[i][29].ToString();
                    drug.A42 = data.Rows[i][30].ToString();
                    drug.A43 = data.Rows[i][31].ToString();

                    lst.Add(drug);
                }
                DeleteFile(path);
                itemDao.Insert(lst, true);
                itemDao.Truncate();
                itemDao.CopyData();
                itemDao.Truncate(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveDrugDosageAddtion(string path)
        {
            try
            {
                IDrugDosageAddtionDao itemDao = DataAccess.Cache.DrugDosageAddtionDao;
                itemDao.Truncate(true);
                List<DrugDosageAddtion> lst = new List<DrugDosageAddtion>();
                DataTable data = GetDataTabletFromCsvFile(path, false);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DrugDosageAddtion drug = new DrugDosageAddtion();
                    drug.DrugId = data.Rows[i][0].ToString();
                    drug.BranchNumber = data.Rows[i][1].ToString();
                    drug.DosageBranchNumber = data.Rows[i][2].ToString();
                    drug.A73 = data.Rows[i][3].ToString();
                    drug.A74 = data.Rows[i][4].ToString();
                    drug.A75 = data.Rows[i][5].ToString();
                    drug.A76 = data.Rows[i][6].ToString();
                    drug.A77 = data.Rows[i][7].ToString();
                    drug.A78 = data.Rows[i][8].ToString();
                    drug.A79 = data.Rows[i][9].ToString();
                    drug.A80 = data.Rows[i][10].ToString();
                    drug.A81 = data.Rows[i][11].ToString();
                    drug.A82 = data.Rows[i][12].ToString();
                    drug.A83 = data.Rows[i][13].ToString();
                    drug.A84 = data.Rows[i][14].ToString();
                    drug.A85 = data.Rows[i][15].ToString();
                    drug.A86 = data.Rows[i][16].ToString();
                    drug.A87 = data.Rows[i][17].ToString();
                    drug.A88 = data.Rows[i][18].ToString();
                    drug.A89 = data.Rows[i][19].ToString();
                    drug.A90 = data.Rows[i][20].ToString();
                    drug.A91 = data.Rows[i][21].ToString();
                    drug.A92 = data.Rows[i][22].ToString();
                    drug.A93 = data.Rows[i][23].ToString();
                    drug.A94 = data.Rows[i][24].ToString();
                    drug.A95 = data.Rows[i][25].ToString();
                    drug.A96 = data.Rows[i][26].ToString();
                    drug.A97 = data.Rows[i][27].ToString();
                    drug.A98 = data.Rows[i][28].ToString();
                    drug.A99 = data.Rows[i][29].ToString();
                    drug.A100 = data.Rows[i][30].ToString();
                    drug.A101 = data.Rows[i][31].ToString();


                    lst.Add(drug);
                }
                DeleteFile(path);
                itemDao.Insert(lst, true);
                itemDao.Truncate();
                itemDao.CopyData();
                itemDao.Truncate(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExtractFile(string filePath, string pathExtract)
        {
            ZipFile zf = null;
            zf = new ZipFile(filePath);
            zf.ExtractAll(pathExtract, ExtractExistingFileAction.OverwriteSilently);
            zf.Dispose();

            DeleteFile(filePath);
            return true;
        }

        private DataTable GetDataTabletFromCsvFile(string filePath, bool firtRowIsHeader)
        {
            DataTable csvData = new DataTable();

            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(filePath))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn();
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    if (!firtRowIsHeader)
                    {
                        for (int i = 0; i < colFields.Length; i++)
                        {
                            if (colFields[i] == "")
                            {
                                colFields[i] = null;
                            }
                        }
                        csvData.Rows.Add(colFields);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog("Read CSV error" + ex.ToString());
            }
            return csvData;
        }

        protected void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        protected bool SaveData(string fileName, byte[] data)
        {
            string pathExtract = Environment.CurrentDirectory + "\\SQLiteDB\\";
            string pathZip = Environment.CurrentDirectory + "\\SQLiteDB\\" + Path.GetFileNameWithoutExtension(fileName) +
                             ".zip";
            try
            {
                if (File.Exists(pathZip))
                {
                    File.Delete(pathZip);
                }
                FileStream myfile = File.Create(pathZip);
                myfile.Close();
                // Create a new stream to write to the file
                BinaryWriter writer = new BinaryWriter(File.OpenWrite(pathZip));
                // Writer raw data                
                writer.Write(data);
                writer.Flush();
                writer.Close();

                //Unzip
                ExtractFile(pathZip, pathExtract);
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        private void SetBackgroundImage()
        {
            //2006.02.06 IHIS/Images/에 있는 MainForm.gif, MainForm1.gif에서 Image 가져와서 설정하기로 변경처리(LangMode 판단하지 않음)
            if (this.DesignMode) return;

            try
            {
                string pathName = Application.StartupPath + "\\Images\\";
                //string fileName = pathName + "MainForm.gif";
                string fileName = pathName + "form_background.png";
                Color tColor = Color.Magenta;
                //FirstImage Set
                if (File.Exists(fileName))
                {
                    this.firstImage = Image.FromFile(fileName);
                    tColor = ((Bitmap)firstImage).GetPixel(1, 1);
                    ((Bitmap)firstImage).MakeTransparent(tColor);
                }
                //Second Image Set
                //fileName = pathName + "MainForm1.gif";
                fileName = pathName + "form_background.png";
                if (File.Exists(fileName))
                {
                    this.secondImage = Image.FromFile(fileName);
                    tColor = ((Bitmap)secondImage).GetPixel(1, 1);
                    ((Bitmap)secondImage).MakeTransparent(tColor);
                }
                this.BackgroundImage = firstImage;

                //Icon 설정
                fileName = pathName + "IHIS.ico";
                if (File.Exists(fileName))
                {
                    this.Icon = new Icon(fileName);
                }

                // if Real or Develop
                String ServerType = Service.GetConfigString("SERVER", "IP", "127.0.0.1");
                //XMessageBox.Show(ServerType);

                //if (ServerType.Equals("192.168.11.11"))
                //    this.ServerTypeName.Visible = false;
                //else
                //    this.ServerTypeName.Text = XMsg.GetField("F022");

                // updated by AnhNV
                this.ServerTypeName.Text = "v " + Service.GetConfigString("FIX", "VERSION", "");
            }
            finally {  }
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Udp Server 종료
                if (udpThread != null)
                {
                    udpServer.Connected = false;
                    udpThread.Abort();
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region UdpServer 수신 Event
        // UdpServer가 호출하는 EventHandler는 UdpThread에서 실행되므로,
        // Main thread에서 실제로 처리되도록 Async 호출한다.
        private void UdpDataReceivedInvoker(IPEndPoint remoteEP, byte[] receivedData)
        {
            this.BeginInvoke(new UdpDataReceivedHandler(UdpDataReceived), new object[] { remoteEP, receivedData });
        }
        // Main thread의 수신처리기
        private void UdpDataReceived(IPEndPoint remoteEP, byte[] receivedData)
        {
            //Header Length를 채우지 못한 Msg는 받지 않음
            if (receivedData.Length < 84)
            {
                Logs.WriteLog("Main", "MainForm::UdpDataReceived에러 receivedData.Length < 84, Length=" + receivedData.Length.ToString());
                return;
            }

            UdpMessage udpMsg = UdpMessage.FromReceivedMessage(receivedData);
            switch (udpMsg.MsgType)
            {
                case UdpMsgType.IMG:
                    //Msg Popup창에 Msg Show
                    if (this.msgPopupForm == null)
                        this.msgPopupForm = new MsgPopupForm();
                    this.msgPopupForm.ShowMessage(remoteEP, udpMsg);
                    break;
                case UdpMsgType.SMG:

                    //시스템ID.exe가 있으면 해당 System으로 WM_COPYDATA Send
                    //SystemMessage OR SystemHandlingMessage
                    if (SystemHandleManager.Contains(udpMsg.SystemID))
                    {
                        IntPtr handle = SystemHandleManager.GetHandle(udpMsg.SystemID);
                        //해당 시스템으로 Msg Send
                        SendMsgToSystemHandle(handle, udpMsg);
                    }
                    else
                        Logs.WriteLog("Main", "MainForm::UdpDataReceived 에러 sysID=" + udpMsg.SystemID + ", SystemHandle Not Found");
                    break;
                case UdpMsgType.SCM:
                    //화면은 시스템에 종속적이지 않으므로(다른 시스템에서 타시스템화면 Open가능)
                    //기동중인 모든 시스템에 Msg 전송
                    foreach (SystemHandle sh in SystemHandleManager.HandleList)
                    {
                        //2005.06.18 메세지시스템은 제외하고 SEND

                        //해당 시스템으로 Msg Send
                        SendMsgToSystemHandle(sh.Handle, udpMsg);
                    }
                    break;
            }
        }
        private void SendMsgToSystemHandle(IntPtr winHandle, UdpMessage udpMsg)
        {
            if (winHandle == IntPtr.Zero)
            {
                Logs.WriteLog("Main", "MainForm::SendMsgToSystemHandle에러 sysID=" + udpMsg.SystemID + ", WinHandle is IntPtr.Zero");
                return;
            }

            //UdpMessage를 String화 하여 Send
            string sendData = udpMsg.ToString();
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            //UNICODE 기준 (TEXT.Lengh + 1(Null)) * 2
            cds.cbData = (sendData.Length + 1) * 2;
            //Auto (Win2000이상은 UNICODE, Win98 :Ansi로 Marshaling)
            cds.lpData = Marshal.StringToHGlobalAuto(sendData);
            //의미없음 (int형의 데이타를 전송시에 dwData에 설정하여 보냄)
            cds.dwData = 0;
            // cds Data Size Memory Alloc (int형(4byte) * 3)
            IntPtr lParam = Marshal.AllocHGlobal(12);

            // cds를 IntPtr로 Convert
            Marshal.StructureToPtr(cds, lParam, false);

            //CopyData Send
            User32.SendMessage(winHandle, (int)Msgs.WM_COPYDATA, IntPtr.Zero, lParam);

            //Memory Free
            Marshal.FreeCoTaskMem(cds.lpData);
            Marshal.FreeHGlobal(lParam);
        }
        #endregion

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tvList = new System.Windows.Forms.TreeView();
            this.imageListGroup = new System.Windows.Forms.ImageList(this.components);
            this.imageListSystem = new System.Windows.Forms.ImageList(this.components);
            this.lvList = new System.Windows.Forms.ListView();
            this.btnRun = new IHIS.XPButton();
            this.btnMinimize = new IHIS.XPButton();
            this.btnSend = new IHIS.XPButton();
            this.btnSystemClose = new IHIS.XPButton();
            this.btnLogout = new IHIS.XPButton();
            this.lvOpenList = new System.Windows.Forms.ListView();
            this.lvMyList = new System.Windows.Forms.ListView();
            this.btnDelMySystem = new IHIS.XPButton();
            this.btnRegMySystem = new IHIS.XPButton();
            this.btnAdmLogin = new IHIS.XPButton();
            this.btnRegMsg = new IHIS.XPButton();
            this.lvMsgList = new System.Windows.Forms.ListView();
            this.btnUnRegMsg = new IHIS.XPButton();
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnShowMsg = new IHIS.XPButton();
            this.ServerTypeName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbxNotifyON = new System.Windows.Forms.PictureBox();
            this.btnNewMasterData = new IHIS.XPButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbxNotifyOFF = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotifyON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotifyOFF)).BeginInit();
            this.SuspendLayout();
            // 
            // tvList
            // 
            this.tvList.AccessibleDescription = null;
            this.tvList.AccessibleName = null;
            resources.ApplyResources(this.tvList, "tvList");
            this.tvList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.tvList.BackgroundImage = null;
            this.tvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvList.Font = null;
            this.tvList.ForeColor = System.Drawing.Color.DimGray;
            this.tvList.FullRowSelect = true;
            this.tvList.HideSelection = false;
            this.tvList.ImageList = this.imageListGroup;
            this.tvList.ItemHeight = 35;
            this.tvList.Name = "tvList";
            this.tvList.ShowLines = false;
            this.tvList.ShowRootLines = false;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // imageListGroup
            // 
            this.imageListGroup.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageListGroup, "imageListGroup");
            this.imageListGroup.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListSystem
            // 
            this.imageListSystem.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageListSystem, "imageListSystem");
            this.imageListSystem.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvList
            // 
            this.lvList.AccessibleDescription = null;
            this.lvList.AccessibleName = null;
            resources.ApplyResources(this.lvList, "lvList");
            this.lvList.BackColor = System.Drawing.Color.White;
            this.lvList.BackgroundImage = null;
            this.lvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvList.Font = null;
            this.lvList.ForeColor = System.Drawing.Color.DimGray;
            this.lvList.LargeImageList = this.imageListSystem;
            this.lvList.MultiSelect = false;
            this.lvList.Name = "lvList";
            this.lvList.StateImageList = this.imageListSystem;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.DoubleClick += new System.EventHandler(this.lvList_DoubleClick);
            this.lvList.Click += new System.EventHandler(this.lvList_Click);
            // 
            // btnRun
            // 
            this.btnRun.AccessibleDescription = null;
            this.btnRun.AccessibleName = null;
            resources.ApplyResources(this.btnRun, "btnRun");
            this.btnRun.BackgroundImage = null;
            this.btnRun.Font = null;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.Name = "btnRun";
            this.btnRun.Scheme = IHIS.Schemes.Silver;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.AccessibleDescription = null;
            this.btnMinimize.AccessibleName = null;
            resources.ApplyResources(this.btnMinimize, "btnMinimize");
            this.btnMinimize.BackgroundImage = null;
            this.btnMinimize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMinimize.Font = null;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Scheme = IHIS.Schemes.Green;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnSend
            // 
            this.btnSend.AccessibleDescription = null;
            this.btnSend.AccessibleName = null;
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.BackgroundImage = null;
            this.btnSend.Font = null;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Name = "btnSend";
            this.btnSend.Scheme = IHIS.Schemes.Silver;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSystemClose
            // 
            this.btnSystemClose.AccessibleDescription = null;
            this.btnSystemClose.AccessibleName = null;
            resources.ApplyResources(this.btnSystemClose, "btnSystemClose");
            this.btnSystemClose.BackgroundImage = null;
            this.btnSystemClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSystemClose.Font = null;
            this.btnSystemClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSystemClose.Image")));
            this.btnSystemClose.Name = "btnSystemClose";
            this.btnSystemClose.Scheme = IHIS.Schemes.Silver;
            this.btnSystemClose.Click += new System.EventHandler(this.btnSystemClose_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleDescription = null;
            this.btnLogout.AccessibleName = null;
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.BackgroundImage = null;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.Font = null;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Scheme = IHIS.Schemes.Silver;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lvOpenList
            // 
            this.lvOpenList.AccessibleDescription = null;
            this.lvOpenList.AccessibleName = null;
            resources.ApplyResources(this.lvOpenList, "lvOpenList");
            this.lvOpenList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.lvOpenList.BackgroundImage = null;
            this.lvOpenList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOpenList.Font = null;
            this.lvOpenList.ForeColor = System.Drawing.Color.DimGray;
            this.lvOpenList.LargeImageList = this.imageListSystem;
            this.lvOpenList.MultiSelect = false;
            this.lvOpenList.Name = "lvOpenList";
            this.lvOpenList.UseCompatibleStateImageBehavior = false;
            this.lvOpenList.DoubleClick += new System.EventHandler(this.lvOpenList_DoubleClick);
            this.lvOpenList.Click += new System.EventHandler(this.lvOpenList_Click);
            // 
            // lvMyList
            // 
            this.lvMyList.AccessibleDescription = null;
            this.lvMyList.AccessibleName = null;
            resources.ApplyResources(this.lvMyList, "lvMyList");
            this.lvMyList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.lvMyList.BackgroundImage = null;
            this.lvMyList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMyList.Font = null;
            this.lvMyList.ForeColor = System.Drawing.Color.DimGray;
            this.lvMyList.LargeImageList = this.imageListSystem;
            this.lvMyList.MultiSelect = false;
            this.lvMyList.Name = "lvMyList";
            this.lvMyList.UseCompatibleStateImageBehavior = false;
            this.lvMyList.DoubleClick += new System.EventHandler(this.lvMyList_DoubleClick);
            this.lvMyList.Click += new System.EventHandler(this.lvMyList_Click);
            // 
            // btnDelMySystem
            // 
            this.btnDelMySystem.AccessibleDescription = null;
            this.btnDelMySystem.AccessibleName = null;
            resources.ApplyResources(this.btnDelMySystem, "btnDelMySystem");
            this.btnDelMySystem.BackgroundImage = null;
            this.btnDelMySystem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelMySystem.Font = null;
            this.btnDelMySystem.Image = ((System.Drawing.Image)(resources.GetObject("btnDelMySystem.Image")));
            this.btnDelMySystem.Name = "btnDelMySystem";
            this.btnDelMySystem.Scheme = IHIS.Schemes.Green;
            this.btnDelMySystem.Click += new System.EventHandler(this.btnDelMySystem_Click);
            // 
            // btnRegMySystem
            // 
            this.btnRegMySystem.AccessibleDescription = null;
            this.btnRegMySystem.AccessibleName = null;
            resources.ApplyResources(this.btnRegMySystem, "btnRegMySystem");
            this.btnRegMySystem.BackgroundImage = null;
            this.btnRegMySystem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRegMySystem.Font = null;
            this.btnRegMySystem.Image = ((System.Drawing.Image)(resources.GetObject("btnRegMySystem.Image")));
            this.btnRegMySystem.Name = "btnRegMySystem";
            this.btnRegMySystem.Scheme = IHIS.Schemes.Silver;
            this.btnRegMySystem.Click += new System.EventHandler(this.btnRegMySystem_Click);
            // 
            // btnAdmLogin
            // 
            this.btnAdmLogin.AccessibleDescription = null;
            this.btnAdmLogin.AccessibleName = null;
            resources.ApplyResources(this.btnAdmLogin, "btnAdmLogin");
            this.btnAdmLogin.BackgroundImage = null;
            this.btnAdmLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdmLogin.Font = null;
            this.btnAdmLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmLogin.Image")));
            this.btnAdmLogin.Name = "btnAdmLogin";
            this.btnAdmLogin.Scheme = IHIS.Schemes.Silver;
            this.btnAdmLogin.Click += new System.EventHandler(this.btnAdmLogin_Click);
            // 
            // btnRegMsg
            // 
            this.btnRegMsg.AccessibleDescription = null;
            this.btnRegMsg.AccessibleName = null;
            resources.ApplyResources(this.btnRegMsg, "btnRegMsg");
            this.btnRegMsg.BackgroundImage = null;
            this.btnRegMsg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRegMsg.Font = null;
            this.btnRegMsg.Image = ((System.Drawing.Image)(resources.GetObject("btnRegMsg.Image")));
            this.btnRegMsg.Name = "btnRegMsg";
            this.btnRegMsg.Scheme = IHIS.Schemes.Silver;
            this.btnRegMsg.Click += new System.EventHandler(this.btnRegMsg_Click);
            // 
            // lvMsgList
            // 
            this.lvMsgList.AccessibleDescription = null;
            this.lvMsgList.AccessibleName = null;
            resources.ApplyResources(this.lvMsgList, "lvMsgList");
            this.lvMsgList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.lvMsgList.BackgroundImage = null;
            this.lvMsgList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMsgList.Font = null;
            this.lvMsgList.ForeColor = System.Drawing.Color.DimGray;
            this.lvMsgList.LargeImageList = this.imageListSystem;
            this.lvMsgList.MultiSelect = false;
            this.lvMsgList.Name = "lvMsgList";
            this.lvMsgList.UseCompatibleStateImageBehavior = false;
            this.lvMsgList.Click += new System.EventHandler(this.lvMsgList_Click);
            // 
            // btnUnRegMsg
            // 
            this.btnUnRegMsg.AccessibleDescription = null;
            this.btnUnRegMsg.AccessibleName = null;
            resources.ApplyResources(this.btnUnRegMsg, "btnUnRegMsg");
            this.btnUnRegMsg.BackgroundImage = null;
            this.btnUnRegMsg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUnRegMsg.Font = null;
            this.btnUnRegMsg.Image = ((System.Drawing.Image)(resources.GetObject("btnUnRegMsg.Image")));
            this.btnUnRegMsg.Name = "btnUnRegMsg";
            this.btnUnRegMsg.Scheme = IHIS.Schemes.Green;
            this.btnUnRegMsg.Click += new System.EventHandler(this.btnUnRegMsg_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.AccessibleDescription = null;
            this.lbMsg.AccessibleName = null;
            resources.ApplyResources(this.lbMsg, "lbMsg");
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbMsg.ForeColor = System.Drawing.Color.IndianRed;
            this.lbMsg.Name = "lbMsg";
            // 
            // btnShowMsg
            // 
            this.btnShowMsg.AccessibleDescription = null;
            this.btnShowMsg.AccessibleName = null;
            resources.ApplyResources(this.btnShowMsg, "btnShowMsg");
            this.btnShowMsg.BackgroundImage = null;
            this.btnShowMsg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnShowMsg.Font = null;
            this.btnShowMsg.Image = ((System.Drawing.Image)(resources.GetObject("btnShowMsg.Image")));
            this.btnShowMsg.Name = "btnShowMsg";
            this.btnShowMsg.Scheme = IHIS.Schemes.OliveGreen;
            this.btnShowMsg.Click += new System.EventHandler(this.btnShowMsg_Click);
            // 
            // ServerTypeName
            // 
            this.ServerTypeName.AccessibleDescription = null;
            this.ServerTypeName.AccessibleName = null;
            resources.ApplyResources(this.ServerTypeName, "ServerTypeName");
            this.ServerTypeName.BackColor = System.Drawing.Color.Transparent;
            this.ServerTypeName.Font = null;
            this.ServerTypeName.Name = "ServerTypeName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = global::IHIS.Properties.Resources.icon_close;
            this.pictureBox1.Font = null;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.AccessibleDescription = null;
            this.pictureBox2.AccessibleName = null;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = null;
            this.pictureBox2.Font = null;
            this.pictureBox2.Image = global::IHIS.Properties.Resources.icon_kc;
            this.pictureBox2.ImageLocation = null;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pbxNotifyON
            // 
            this.pbxNotifyON.AccessibleDescription = null;
            this.pbxNotifyON.AccessibleName = null;
            resources.ApplyResources(this.pbxNotifyON, "pbxNotifyON");
            this.pbxNotifyON.BackgroundImage = null;
            this.pbxNotifyON.Font = null;
            this.pbxNotifyON.ImageLocation = null;
            this.pbxNotifyON.Name = "pbxNotifyON";
            this.pbxNotifyON.TabStop = false;
            // 
            // btnNewMasterData
            // 
            this.btnNewMasterData.AccessibleDescription = null;
            this.btnNewMasterData.AccessibleName = null;
            resources.ApplyResources(this.btnNewMasterData, "btnNewMasterData");
            this.btnNewMasterData.BackgroundImage = null;
            this.btnNewMasterData.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewMasterData.Font = null;
            this.btnNewMasterData.Image = ((System.Drawing.Image)(resources.GetObject("btnNewMasterData.Image")));
            this.btnNewMasterData.Name = "btnNewMasterData";
            this.btnNewMasterData.Click += new System.EventHandler(this.btnNewMasterData_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbxNotifyOFF
            // 
            this.pbxNotifyOFF.AccessibleDescription = null;
            this.pbxNotifyOFF.AccessibleName = null;
            resources.ApplyResources(this.pbxNotifyOFF, "pbxNotifyOFF");
            this.pbxNotifyOFF.BackgroundImage = null;
            this.pbxNotifyOFF.Font = null;
            this.pbxNotifyOFF.ImageLocation = null;
            this.pbxNotifyOFF.Name = "pbxNotifyOFF";
            this.pbxNotifyOFF.TabStop = false;
            // 
            // MainForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnMinimize;
            this.ControlBox = false;
            this.Controls.Add(this.pbxNotifyOFF);
            this.Controls.Add(this.pbxNotifyON);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ServerTypeName);
            this.Controls.Add(this.btnDelMySystem);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnShowMsg);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.btnUnRegMsg);
            this.Controls.Add(this.lvMsgList);
            this.Controls.Add(this.btnRegMsg);
            this.Controls.Add(this.btnAdmLogin);
            this.Controls.Add(this.btnRegMySystem);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSystemClose);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.tvList);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lvOpenList);
            this.Controls.Add(this.lvList);
            this.Controls.Add(this.lvMyList);
            this.Controls.Add(this.btnNewMasterData);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotifyON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotifyOFF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region OnLoad, OnMouseDown
        private void SetAdminYn()
        {
            //Registry에 저장된 ADMIN여부, NoCheck, LoginTime을 가지고, adminYn 값 설정
            //1.ADMIN이 없거나 N이면 N
            //2.ADMIN이 Y일때 NoCheck가 N이면 N
            //3.ADMIN이 Y AND NoCheck가 Y일때 LoginTime이 같은날이 아니면 N
            /*RegistryKey rKey = Registry.LocalMachine;

            RegistryKey rKey1 = rKey.OpenSubKey("SOFTWARE\\IHIS\\USER");
            if (rKey1 == null)
            {
                rKey1 = rKey.CreateSubKey("SOFTWARE\\IHIS\\USER");
                return;
            }
            if (rKey1.GetValue("ADMIN", "N").ToString() == "Y")
                if (rKey1.GetValue("NoCheck", "N").ToString() == "Y")
                    if (rKey1.GetValue("LoginTime", "20000101").ToString() == DateTime.Today.ToString("yyyyMMdd"))
                        this.adminUserYn = "Y";

            rKey1.Close();*/

            if (CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN, "N").ToString() == "Y")
                if (CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_NO_CHECK, "N").ToString() == "Y")
                    if (CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_LOGIN_TIME, "20000101").ToString() == DateTime.Today.ToString("yyyyMMdd"))
                        this.adminUserYn = "Y";
        }
        protected override void OnLoad(EventArgs e)
        {
            bool connOk = CloudService.Instance.Connect();
            if (connOk)
            {
                try
                {
                    base.OnLoad(e);

                    //ifcHandle 보관
                    ifcHandle = this.Handle;

                    // 0.서버시간과 PC시간 동기화 여부 확인(5분이상 차이 발생시)
                    // 1.Registry를 읽어 Admin인지 여부 SET
                    // 2.시스템 구성 
                    // 3.메세지시스템 리스트 구성
                    // 4.Resource File에서 Image GET, ImageList Gen
                    // 5.TreeView 구성
                    // 6.IHIS공지 메세지ID 등록
                    // 7.마이시스템리스트 구성
                    //<개발중> 개발중에서는 Server가 이전날짜이므로 경고창이 계속 떠서 일단 Comment 처리함.
                    //SynchronizeSystemTime();
                    SetAdminYn();
                    CreateSystemInfoTable(false);
                    CreateMsgSystemTable(false);
                    GenImageList();
                    SetTreeViewItems();
                    RegisterIHISMsgID();
                    LoadMySystemFromXml();
                    //Window XP Service Pack2 방화벽 사용시 15021 UDP Port 방화벽 해제
                    // RegisterFirewallException();

                    //UdpServer Start
                    StartUdpServer();

                    // 자동선택이면 선택창 Minimize상태로하여 업무시스템 선택 Process 기동
                    // 없으면 선택창 Normal상태로 기동
                    if (this.autoSystemOpen)
                    {
                        this.WindowState = FormWindowState.Minimized;
                        CreateSystem();
                    }
                    else
                    {
                        //MySystemList가 있으면 DefaultPage를 MySystemList로 설정
                        if (this.lvMyList.Items.Count > 0)
                            this.OnSelectedTabPageChanged(1);
                    }

                    //<개발중> 완성후 반영 등록된 메세지 시스템 기동
                    // <<2013.11.28>> LKH
                    //StartMsgSystem();

                    ////<TEST> Procudure call
                    //string spName = "PR_ADM_CHECK_LOGIN";
                    //Hashtable inputList = new Hashtable();
                    //Hashtable outputList = new Hashtable();
                    ////<MYSQL>
                    //inputList.Add("I_SYS_ID", "AAA");
                    //inputList.Add("I_USER_ID", "BBB");
                    //inputList.Add("I_USER_SCRT", "CCC");
                    //inputList.Add("I_SCRT_CHECK_YN", "Y");
                    //inputList.Add("I_IP_ADDR", "AAA");
                    //if (Service.ExecuteProcedure(spName, inputList, outputList)) //성공
                    //{
                    //    MessageBox.Show(outputList.Count.ToString());
                    //}

                    //2015.09.29 added by Cloud Version
                    DownloadMissingFont();

                    // https://sofiamedix.atlassian.net/browse/MED-7316

                    if (UserInfo.UserGroup == "ADMIN")
                    {
                        NotifyNewMstData();
                        AutoCheckMstData();
                    }
                    else
                    {
                        btnNewMasterData.Visible = false;
                        pbxNotifyON.Visible = false;
                        pbxNotifyOFF.Visible = false;
                    }

                }
                catch (Exception xe)
                {
                    MessageBox.Show("IHIS.MainForm::OnLoad Error=" + xe.Message);
                }
            }
            else
            {
                MessageBox.Show("IHIS.MainForm::OnLoad Error = Cannot connect to server");
            }
        }

        private void AutoCheckMstData()
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Stop();

            CheckNewMstDataArgs args = new CheckNewMstDataArgs();
            CheckNewMstDataResult result = CloudService.Instance.Submit<CheckNewMstDataResult, CheckNewMstDataArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                UserInfo.NewMstDataLst.Clear();
                result.ListData.ForEach(delegate(IHIS.CloudConnector.Contracts.Models.System.NewMstDataListInfo item)
                        {
                            UserInfo.NewMstDataLst.Add(item.ScreenName);
                        });
            }

            // https://sofiamedix.atlassian.net/browse/MED-13394
            //if (UserInfo.NewMstDataLst.Count > 0)
            //{
            //    // New master data was updated
            //    pbxNotifyON.Location = new Point(548, 367);
            //    pbxNotifyON.Visible = true;
            //    pbxNotifyOFF.Visible = false;
            //}
            //else
            //{
            //    // No master data was updated
            //    pbxNotifyOFF.Location = new Point(548, 367);
            //    pbxNotifyOFF.Visible = true;
            //    pbxNotifyON.Visible = false;
            //}
            this.NotifyNewMstData();

            timer1.Start();
        }

        #region Download Font
        private void DownloadMissingFont()
        {
            try
            {
                ////only Administrator can have previlege to install new font
                //if (!IsAdministrator())
                //{
                //    return;
                //}              
                int result = AddFontResource(fullName);
                //int result = RemoveFontResource(fullName);
                int error = Marshal.GetLastWin32Error();
                //if (error != 0)
                //{
                //    XMessageBox.Show(new Win32Exception(error).Message);
                //} 
            }
            catch //(Exception ex)
            {
                //XMessageBox.Show(ex.Message);
                return;
            }
        }

        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                         string lpFileName);

        [DllImport("gdi32.dll", EntryPoint = "RemoveFontResourceW", SetLastError = true)]
        public static extern int RemoveFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                            string lpFileName);

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        #endregion

        #region WinXP SP2 FireWall 예외 허용처리
        private void RegisterFirewallException()
        {
            //WinXP ServicePack 2 방화벽 사용시 방화벽 예외는
            //Registry의 HLM\SYSTEMS\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile\GolballyOpenPorts\List에
            //UDP:15021는 OPEN처리함
            //IFC는 15021 PORT 사용하고 IHIS 16021 PORT 사용
            try
            {
                string keyName = @"SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile\GloballyOpenPorts\List";
                string valueName = "16021:UDP";
                string data = "16021:UDP:*:Enabled:IHIS UDP PORT";
                RegistryKey rKey = Registry.LocalMachine;
                RegistryKey rKey1 = rKey.OpenSubKey(keyName, true);
                if (rKey1 == null) return;

                //16021:UDP 예외가 등록되어 있지 않으면
                string preValue = rKey1.GetValue(valueName, "N").ToString();
                if (preValue == "N") //등록되어 있지 않으면 등록
                {
                    rKey1.SetValue(valueName, data);
                }
                else if (preValue != data) //데이타가 달라도 다시 등록, Disabled상태로 설정시에
                {
                    rKey1.SetValue(valueName, data);
                }
                rKey1.Close();

                //방화벽 예외허용으로 설정
                keyName = @"SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile";
                valueName = "DoNotAllowExceptions";
                rKey1 = rKey.OpenSubKey(keyName, true);
                if (rKey1 == null) return;
                preValue = rKey1.GetValue(valueName, 1).ToString();  //0.예외허용, 1.예외허용안함
                if (preValue != "0")
                {
                    rKey1.SetValue(valueName, 0);
                }
                rKey1.Close();
            }
            catch (Exception xe)
            {
                Logs.WriteLog("Main", "방화벽 예외설정 에러=" + xe.Message);
            }
        }
        #endregion

        #region StartUdpServer (UdpServer Start)
        private void StartUdpServer()
        {
            //IFC는 15021, IHIS는 16021
            udpServer = new UdpServer(16021);
            udpServer.UdpDataReceived += new UdpDataReceivedHandler(this.UdpDataReceivedInvoker);
            udpThread = new Thread(new ThreadStart(udpServer.Listening));
            udpThread.Name = "UDP Server";
            udpThread.Start();
        }
        #endregion

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //LeftDown시에 TabPage영역이면 해당 TabPage Select
            int index = -1;
            if (e.Button == MouseButtons.Left)
            {
                //첫번째 TabPage영역에 속하는지 확인
                if (firstRegion.Contains(e.X, e.Y))
                    index = 0;
                else if (secondRegion.Contains(e.X, e.Y))
                    index = 1;
                if ((index >= 0) && (selectedIndex != index))
                    OnSelectedTabPageChanged(index);

                //Down Point Set
                this.isInMoving = true;
                this.mouseDownX = e.X;
                this.mouseDownY = e.Y;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left) //Flag Clear
                this.isInMoving = false;

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            //Moving상태이고 Down한 위치에서 3pt이상 이동하면 Move
            if (this.isInMoving && (Math.Abs(e.X - mouseDownX) > 3 || Math.Abs(e.Y - mouseDownY) > 3))
            {
                Point tPt = Point.Empty;
                tPt.X = this.Location.X + (e.X - this.mouseDownX);
                tPt.Y = this.Location.Y + (e.Y - this.mouseDownY);
                this.Location = tPt;
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {

            //Alt F4를 눌러 Window를 닫는 것을 방지(처리하지 않으면 Alt F4일때 Window 닫힘)
            if ((keyData & Keys.Alt) == Keys.Alt)
            {
                Keys keyCode = (Keys)(((int)keyData << 16) >> 16);		// Modifier Clear
                if (keyCode == Keys.F4)
                    return true;  //Alt F4로 Window 닫지 못하게 함
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region SetTreeViewItems, SetListViewItems
        //ImagePath의 ico File에서 가져오기
        private Image GetIcon(string name)
        {
            try
            {
                //Image를 IHIS\Images\에 관리할때
                string fileName = imagePath + name + ".ico";

                if (File.Exists(fileName))
                {
                    Icon icon = new Icon(fileName);
                    Bitmap myBitmap = icon.ToBitmap();
                    // Make the default transparent color transparent for myBitmap.
                    myBitmap.MakeTransparent();
                    return myBitmap;
                }
                else  //File이 없으면 Default Icon (IHIS.ico으로 설정)
                {
                    fileName = imagePath + "IHIS.ico";
                    if (File.Exists(fileName))
                    {
                        Icon icon = new Icon(fileName);
                        Bitmap myBitmap = icon.ToBitmap();
                        // Make the default transparent color transparent for myBitmap.
                        myBitmap.MakeTransparent();
                        return myBitmap;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetIcon Error=" + e.Message);
            }

            return null;
        }
        //ImageList 동적 생성
        private void GenImageList()
        {
            int gIndex = 0, sIndex = 0;
            int cIdx = 0;
            string displayGroupID = null;
            Image cIcon = null;
            Image sIcon = null;
            //ImageList Clear
            imageListGroup.Images.Clear();
            imageListSystem.Images.Clear();

            //foreach (MainMenuItemInfo menuItem in sysInfoList.MenuItem)
            //{
            //    displayGroupID = menuItem.DisplayGroupId;
            //    // 포함전이면 Image Set, index 보관 (Images.Contains는 .NET에서 지원하지 않음
            //    // 따라서, 기 보관한 displayGroupList에 있으면 Add후 category삭제
            //    //if (!imageList.Images.Contains((Image) cIcon))

            //    if (displayGroupList.Contains(displayGroupID))
            //    {
            //        cIcon = GetIcon(displayGroupID);
            //        if (cIcon != null)
            //        {
            //            imageListGroup.Images.Add(cIcon);
            //            cIdx = gIndex;
            //            menuItem.GroupImageIndex = gIndex;
            //            gIndex++;
            //            //displayGroupList에서 삭제
            //            displayGroupList.Remove(displayGroupID);
            //        }
            //    }
            //    else // 포함후이면 Group Index 저장
            //        menuItem.GroupImageIndex = cIdx;

            //    //System Icon Add
            //    sIcon = GetIcon(menuItem.SystemId);
            //    if (sIcon != null)
            //    {
            //        imageListSystem.Images.Add(sIcon);
            //        menuItem.SystemImageIndex = sIndex;
            //        sIndex++;
            //    }
            //}

            ////메세지시스템 Icon 설정
            //string sysID = "";
            //foreach (MainMenuItemInfo menuItem in msgSystemList.MenuItem)
            //{
            //    //XMSG는 Icon필요없음
            //    sysID = menuItem.SystemId;
            //    if (sysID != XMSG_SYSTEM_ID)
            //    {
            //        sIcon = GetIcon(sysID);
            //        if (sIcon != null)
            //        {
            //            imageListSystem.Images.Add(sIcon);
            //            menuItem.SystemImageIndex = sIndex;
            //            sIndex++;
            //        }
            //    }
            //}

            // 2015.08.17 AnhNV ADDED START
            foreach (DataRow dtRow in sysInfoTable.Rows)
            {
                displayGroupID = dtRow["DisplayGroupID"].ToString();
                // 포함전이면 Image Set, index 보관 (Images.Contains는 .NET에서 지원하지 않음
                // 따라서, 기 보관한 displayGroupList에 있으면 Add후 category삭제
                //if (!imageList.Images.Contains((Image) cIcon))

                if (displayGroupList.Contains(displayGroupID))
                {
                    cIcon = GetIcon(displayGroupID);
                    if (cIcon != null)
                    {
                        imageListGroup.Images.Add(cIcon, Color.Transparent);
                        cIdx = gIndex;
                        dtRow["GroupImageIndex"] = gIndex;
                        gIndex++;
                        //displayGroupList에서 삭제
                        displayGroupList.Remove(displayGroupID);
                    }
                }
                else // 포함후이면 Group Index 저장
                    dtRow["GroupImageIndex"] = cIdx;

                //System Icon Add

                sIcon = GetIcon(dtRow["SystemID"].ToString());
                if (sIcon != null)
                {
                    imageListSystem.Images.Add(sIcon, Color.Transparent);
                    dtRow["SystemImageIndex"] = sIndex;
                    sIndex++;
                }
            }

            //메세지시스템 Icon 설정
            string sysID = "";

            foreach (DataRow dtRow in msgSystemTable.Rows)
            {
                //XMSG는 Icon필요없음

                sysID = dtRow["SystemID"].ToString();
                if (sysID != XMSG_SYSTEM_ID)
                {
                    sIcon = GetIcon(sysID);
                    if (sIcon != null)
                    {
                        imageListSystem.Images.Add(sIcon, Color.Transparent);
                        dtRow["SystemImageIndex"] = sIndex;
                        sIndex++;
                    }
                }
            }
            // 2015.08.17 AnhNV ADDED END
        }

        //기 존재하는 category여부 판단
        private bool GroupExistsInTreeView(string displayGroupID)
        {
            foreach (TreeNode node in tvList.Nodes)
                if (node.Tag.ToString() == displayGroupID)
                    return true;
            return false;
        }
        private Hashtable groupImageIndexList = new Hashtable();
        //TreeView Gen
        private void SetTreeViewItems()
        {
            string displayGroupID = "";
            string displayGroupName = "";
            int cImageIdx = 0;
            TreeNode cNode = null;
            //TreeView Clear
            tvList.Nodes.Clear();

            //2.TreeView SET
            //foreach (MainMenuItemInfo menuItem in sysInfoList.MenuItem)
            //{
            //    displayGroupID = menuItem.DisplayGroupId;
            //    displayGroupName = menuItem.DisplayGroupName;
            //    cImageIdx = menuItem.GroupImageIndex;

            //    if (!GroupExistsInTreeView(displayGroupID))
            //    {
            //        cNode = new TreeNode(displayGroupName, cImageIdx, cImageIdx);
            //        cNode.Tag = displayGroupID;  //Tag에 Display GroupID 저장
            //        tvList.Nodes.Add(cNode);
            //        //Hashtable의 해당 group의 ImageIndex 저장
            //        if (!groupImageIndexList.Contains(displayGroupID))
            //            groupImageIndexList.Add(displayGroupID, cImageIdx);
            //    }
            //}

            foreach (DataRow dtRow in sysInfoTable.Rows)
            {

                displayGroupID = dtRow["DisplayGroupID"].ToString();
                displayGroupName = dtRow["DisplayGroupName"].ToString();
                cImageIdx = Int32.Parse(dtRow["GroupImageIndex"].ToString());

                if (!GroupExistsInTreeView(displayGroupID))
                {
                    cNode = new TreeNode(displayGroupName, cImageIdx, cImageIdx);
                    cNode.Tag = displayGroupID;  //Tag에 Display GroupID 저장
                    tvList.Nodes.Add(cNode);
                    //Hashtable의 해당 group의 ImageIndex 저장
                    if (!groupImageIndexList.Contains(displayGroupID))
                        groupImageIndexList.Add(displayGroupID, cImageIdx);
                }
            }
        }

        private void SetListViewItems(string displayGroupID)
        {
            string groupID = "";  //실제 GroupID
            string groupName = "";  //실제 GroupName
            string systemID = "";
            string systemName = "";
            string description = "";
            int sImageIdx = 0;
            ListViewItem item = null;

            // 기존 List Clear
            lvList.Clear();

            //해당 category인 업무 System만 SET
            //foreach (MainMenuItemInfo menuItem in sysInfoList.MenuItem)
            //{
            //    if (menuItem.DisplayGroupId == displayGroupID)
            //    {
            //        groupID = menuItem.GroupId;
            //        groupName = menuItem.GroupName;
            //        systemID = menuItem.SystemId;
            //        systemName = menuItem.SystemName;
            //        description = menuItem.Description;
            //        sImageIdx = menuItem.SystemImageIndex;

            //        //SubItem은 systemName, systemID, groupID, groupName, desc순으로 설정
            //        item = new ListViewItem(new string[] { systemName, systemID, groupID, groupName, description }, sImageIdx);
            //        lvList.Items.Add(item);
            //    }
            //}

            foreach (DataRow dtRow in sysInfoTable.Rows)
            {
                if (dtRow["DisplayGroupID"].ToString() == displayGroupID)
                {

                    groupID = dtRow["GroupID"].ToString();
                    groupName = dtRow["GroupName"].ToString();

                    systemID = dtRow["SystemID"].ToString();
                    systemName = dtRow["SystemName"].ToString();
                    description = dtRow["Description"].ToString();
                    sImageIdx = Int32.Parse(dtRow["SystemImageIndex"].ToString());

                    //SubItem은 systemName, systemID, groupID, groupName, desc순으로 설정
                    item = new ListViewItem(new string[] { systemName, systemID, groupID, groupName, description }, sImageIdx);
                    lvList.Items.Add(item);
                }
            }
        }
        //Description 설정
        private void SetDescription(string desc)
        {
            //설명은 보이지 않게 함(20041125 변경)
            //this.lblDesc.Text = desc;
        }
        // 업무시스템정보 Table 생성
        private void CreateSystemInfoTable(bool reCreate)
        {
            //MainMenuArgs mainMenu = new MainMenuArgs("N", this.adminUserYn);
            //sysInfoList = CloudService.Instance.Submit<MainMenuResult, MainMenuArgs>(mainMenu);
            //if (sysInfoList.MenuItem.Count < 1)
            //{
            //    string msg = XMsg.GetMsg("M012"); // 업무시스템 정보 조회 실패
            //    //XMessageBox.Show(msg, "IHIS");
            //    XMessageBox.Show(msg, "KCCK");
            //    return;
            //}

            ////그룹리스트 생성
            ////GroupList Set
            //foreach (MainMenuItemInfo menuItem in sysInfoList.MenuItem)
            //{
            //    if (!displayGroupList.Contains(menuItem.DisplayGroupId))
            //        displayGroupList.Add(menuItem.DisplayGroupId);
            //}

            //재생성이 아니면 컬럼 정의
            if (!reCreate)
            {
                sysInfoTable.Columns.Add("GroupID", typeof(string));
                sysInfoTable.Columns.Add("GroupName", typeof(string));
                sysInfoTable.Columns.Add("SystemID", typeof(string));
                sysInfoTable.Columns.Add("SystemName", typeof(string));
                sysInfoTable.Columns.Add("DisplayGroupID", typeof(string));
                sysInfoTable.Columns.Add("DisplayGroupName", typeof(string));
                sysInfoTable.Columns.Add("Description", typeof(string));
                sysInfoTable.Columns.Add("GroupImageIndex", typeof(int));
                //DefaultValue 0 Set
                sysInfoTable.Columns["GroupImageIndex"].DefaultValue = 0;
                sysInfoTable.Columns.Add("SystemImageIndex", typeof(int));
                //DefaultValue 0 Set
                sysInfoTable.Columns["SystemImageIndex"].DefaultValue = 0;
            }

            //Data Clear
            sysInfoTable.Clear();

            #region Deleted by Cloud
            //// <ORACLE>
            //string cmdText
            //    = "SELECT A.GRP_ID, A.GRP_NM, B.SYS_ID, B.SYS_NM, A.DISP_GRP_ID, C.GRP_NM, B.SYS_DESC"
            //    + "  FROM ADM0100 A, ADM0200 B, ADM0100 C"
            //    + " WHERE A.GRP_ID = B.GRP_ID"
            //    + "   AND A.DISP_GRP_ID = C.GRP_ID"
            //    + "   AND NVL(B.MSG_SYS_YN,'N') = 'N'"
            //    + "   AND NVL(B.ADM_SYS_YN,'Y') LIKE DECODE('" + this.adminUserYn + "','Y','%','N')"
            //    + " ORDER BY A.GRP_SEQ, B.SYS_SEQ";
            //DataTable table = Service.ExecuteDataTable(cmdText);
            #endregion

            // 2015.07.01 AnhNV updated START
            MainFormGetSysInfoArgs args = new MainFormGetSysInfoArgs();
            args.HospCode = UserInfo.HospCode;
            args.UserId = UserInfo.UserID;
            args.GroupId = UserInfo.UserGroup;
            MainFormGetSysInfoResult res = CloudService.Instance.Submit<MainFormGetSysInfoResult, MainFormGetSysInfoArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.SysInfoItem.Count < 1)
                {
                    string msg = XMsg.GetMsg("M012"); // 업무시스템 정보 조회 실패
                    XMessageBox.Show(msg, "IHIS");

                    return;
                }

                DataRow dataRow = null;
                foreach (MainFormGetMainMenuItemInfo item in res.SysInfoItem)
                {
                    dataRow = sysInfoTable.NewRow();
                    dataRow[0] = item.GrpId;
                    dataRow[1] = item.GrpNm;
                    dataRow[2] = item.SysId;
                    dataRow[3] = item.SysNm;
                    dataRow[4] = item.DispGrpId;
                    dataRow[5] = item.DispGrpNm;
                    dataRow[6] = item.SysDesc;
                    sysInfoTable.Rows.Add(dataRow);
                }

                sysInfoTable.AcceptChanges();
            }
            // 2015.07.01 AnhNV updated END

            //그룹리스트 생성
            //GroupList Set

            foreach (DataRow dtRow in sysInfoTable.Rows)
            {
                if (!displayGroupList.Contains(dtRow["DisplayGroupID"].ToString()))

                    displayGroupList.Add(dtRow["DisplayGroupID"].ToString());
            }
        }
        //메세지 시스템 리스트 테이블 생성
        private void CreateMsgSystemTable(bool reCreate)
        {
            //MainMenuArgs mainMenu = new MainMenuArgs("Y", this.adminUserYn);
            //msgSystemList = CloudService.Instance.Submit<MainMenuResult, MainMenuArgs>(mainMenu);

            //if (msgSystemList.MenuItem.Count < 1)
            //{
            //    string msg = XMsg.GetMsg("M013"); // 메세지시스템 정보 조회 실패
            //    //XMessageBox.Show(msg, "IHIS");
            //    XMessageBox.Show(msg, "KCCK");
            //    return;
            //}

            ////메세지시스템이 있으면 메세지시스템 등록 버튼 활성화
            //if (this.msgSystemList.MenuItem.Count > 0)
            //    this.btnRegMsg.Enabled = true;

            //재생성이 아니면 컬럼 정의
            if (!reCreate)
            {
                msgSystemTable.Columns.Add("GroupID", typeof(string));
                msgSystemTable.Columns.Add("GroupName", typeof(string));
                msgSystemTable.Columns.Add("SystemID", typeof(string));
                msgSystemTable.Columns.Add("SystemName", typeof(string));
                msgSystemTable.Columns.Add("DisplayGroupID", typeof(string));
                msgSystemTable.Columns.Add("DisplayGroupName", typeof(string));
                msgSystemTable.Columns.Add("Description", typeof(string));
                msgSystemTable.Columns.Add("SystemImageIndex", typeof(int));
                //DefaultValue 0 Set
                msgSystemTable.Columns["SystemImageIndex"].DefaultValue = 0;
            }
            //Data Clear
            msgSystemTable.Clear();


            #region Deleted by Cloud
            //            // <ORACLE>
            //            string cmdText = @"SELECT A.GRP_ID, A.GRP_NM, B.SYS_ID, B.SYS_NM, A.DISP_GRP_ID, C.GRP_NM, B.SYS_DESC
            //				                 FROM ADM0100 A, ADM0200 B, ADM0100 C
            //				                WHERE A.GRP_ID = B.GRP_ID
            //             				      AND A.DISP_GRP_ID = C.GRP_ID
            //			            	      AND NVL(B.MSG_SYS_YN,'N') = 'Y'
            //            				      AND NVL(B.ADM_SYS_YN,'Y') LIKE DECODE('" + this.adminUserYn + @"','Y','%','N')
            //				                ORDER BY A.GRP_SEQ, B.SYS_SEQ
            //                              ";

            //            DataTable table = Service.ExecuteDataTable(cmdText);
            #endregion

            // updated by Cloud
            MainFormGetMsgSystemArgs args = new MainFormGetMsgSystemArgs();
            args.HospCode = UserInfo.HospCode;
            args.UserId = UserInfo.UserID;
            args.GroupId = UserInfo.UserGroup;
            MainFormGetMsgSystemResult res = CloudService.Instance.Submit<MainFormGetMsgSystemResult, MainFormGetMsgSystemArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                //if (res.SysInfoItem.Count < 1)
                //{
                //    string msg = XMsg.GetMsg("M013"); // 메세지시스템 정보 조회 실패
                //    XMessageBox.Show(msg, "IHIS");

                //    return;
                //}

                DataRow dataRow = null;
                foreach (MainFormGetMainMenuItemInfo item in res.SysInfoItem)
                {
                    dataRow = msgSystemTable.NewRow();
                    dataRow[0] = item.GrpId;
                    dataRow[1] = item.GrpNm;
                    dataRow[2] = item.SysId;
                    dataRow[3] = item.SysNm;
                    dataRow[4] = item.DispGrpId;
                    dataRow[5] = item.DispGrpNm;
                    dataRow[6] = item.SysDesc;
                    msgSystemTable.Rows.Add(dataRow);
                }
                msgSystemTable.AcceptChanges();
            }

            //if (table.Rows.Count < 1)
            //{
            //    string msg = XMsg.GetMsg("M013"); // 메세지시스템 정보 조회 실패
            //    XMessageBox.Show(msg, "IHIS");
            //    return;
            //}

            //DataRow dataRow = null;
            //foreach (DataRow dtRow in table.Rows)
            //{
            //    dataRow = msgSystemTable.NewRow();
            //    dataRow[0] = dtRow[0];
            //    dataRow[1] = dtRow[1];
            //    dataRow[2] = dtRow[2];
            //    dataRow[3] = dtRow[3];
            //    dataRow[4] = dtRow[4];
            //    dataRow[5] = dtRow[5];
            //    dataRow[6] = dtRow[6];
            //    msgSystemTable.Rows.Add(dataRow);
            //}
            //msgSystemTable.AcceptChanges();

            //메세지시스템이 있으면 메세지시스템 등록 버튼 활성화

            if (this.msgSystemTable.Rows.Count > 0)
                this.btnRegMsg.Enabled = true;
        }
        #endregion

        #region RegisterIHISMsgID, UnRegisterAllMsgID
        private void RegisterIHISMsgID()
        {
            /* <MYSQL>
			try
			{
				string cmdText
					= "BEGIN "
					+ " INSERT INTO ADM0600 (MSG_ID, IP_ADDR, MSG_TYPE, SYS_ID, PGM_ID, MSG_REG_ARG, REGI_TIME)"
					+ " VALUES(:f_msg_id, :f_ip_addr, :f_msg_type, :f_sys_id, :f_pgm_id, :f_msg_reg_arg, SYSDATE);"
					+ " EXCEPTION WHEN DUP_VAL_ON_INDEX THEN"
					+ " UPDATE ADM0600"
					+ "    SET SYS_ID      = :f_sys_id"
					+ "       ,PGM_ID      = :f_pgm_id"
					+ "       ,MSG_REG_ARG = :f_msg_reg_arg"
					+ "       ,REGI_TIME  = SYSDATE"
					+ "  WHERE MSG_ID  = :f_msg_id"
					+ "    AND IP_ADDR = :f_ip_addr;"
					+ "END";
				//Bind 변수 SET MsgID + IP + MsgType(IMG) + SystemID("") + ScreenID("") + MsgRegArg("")
				BindVarCollection bindVars = new BindVarCollection();
				bindVars.Add("f_msg_id", "IHIS_ALLIM");
				bindVars.Add("f_ip_addr", Service.ClientIP);
				bindVars.Add("f_msg_type", "IMG");
				bindVars.Add("f_sys_id", "");
				bindVars.Add("f_pgm_id", "");
				bindVars.Add("f_msg_reg_arg", "");
				//SQL 실행
				Service.ExecuteNonQuery(cmdText, bindVars);

			}
			catch{}
             */

        }
        //해당 IP로 등록된 모든 MSG_ID 등록해제(ADM0600에서 삭제)
        private void UnRegisterAllMsgID()
        {
            /* <MYSQL>
			try
			{
				string cmdText= "DELETE ADM0600 WHERE IP_ADDR   = '" + Service.ClientIP + "'";
				Service.ExecuteNonQuery(cmdText);
			}
			catch{}
			*/

        }
        #endregion

        #region Event Handlers
        private void tvList_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //Reset
            currentSystemID = "";
            currentSystemName = "";
            currentUserID = "";

            //Group선택시 ListView SET
            SetListViewItems(e.Node.Tag.ToString());
            //바로가기,Run 버튼 Disable
            ChangeButtonState(false);

            tvList.ExpandAll();
            tvList.SelectedImageIndex = 1;
        }

        private void lvList_Click(object sender, System.EventArgs e)
        {
            //Reset
            currentSystemID = "";
            currentSystemName = "";
            currentUserID = "";

            if (lvList.SelectedItems.Count > 0)
            {
                //lvOpenList, lvMyList에서 선택된 Item Clear
                this.lvOpenList.SelectedItems.Clear();
                this.lvMyList.SelectedItems.Clear();

                //SubItems순서는 systemName, systemID, groupID, groupName, desc 순으로 설정됨
                //선택된 SystemName ,SystemID,그룹ID SET
                currentSystemName = lvList.SelectedItems[0].SubItems[0].Text;
                currentSystemID = lvList.SelectedItems[0].SubItems[1].Text;
                currentGroupID = lvList.SelectedItems[0].SubItems[2].Text;
                currentGroupName = lvList.SelectedItems[0].SubItems[3].Text;
                //Description SET
                SetDescription(lvList.SelectedItems[0].SubItems[4].Text);

                //바로가기,Run 버튼 Enable
                ChangeButtonState(true);
                //메세지시스템삭제 버튼 Disable
                this.btnUnRegMsg.Enabled = false;
            }
        }
        private void lvList_DoubleClick(object sender, System.EventArgs e)
        {
            if (currentSystemID != "")
                if (CreateSystem())
                    MdiMinimize();
        }
        private void lvOpenList_Click(object sender, System.EventArgs e)
        {
            //Reset
            currentSystemID = "";
            currentSystemName = "";
            currentUserID = "";

            if (lvOpenList.SelectedItems.Count > 0)
            {
                //lvList, lvMyList에서 선택된 Item Clear
                this.lvList.SelectedItems.Clear();
                this.lvMyList.SelectedItems.Clear();

                //SubItems순서는 systemName, systemID, groupID, desc 순으로 설정됨
                //선택된 SystemName ,SystemID,그룹ID SET
                currentSystemName = lvOpenList.SelectedItems[0].SubItems[0].Text;
                currentSystemID = lvOpenList.SelectedItems[0].SubItems[1].Text;
                currentGroupID = lvOpenList.SelectedItems[0].SubItems[2].Text;
                currentGroupName = lvOpenList.SelectedItems[0].SubItems[3].Text;
                //Description SET
                SetDescription(lvOpenList.SelectedItems[0].SubItems[4].Text);

                //바로가기,Run 버튼 Enable
                ChangeButtonState(true);
                //마이메뉴삭제 버튼 Disable
                this.btnDelMySystem.Enabled = false;
                //메세지시스템삭제 버튼 Disable
                this.btnUnRegMsg.Enabled = false;
            }
        }
        private void lvOpenList_DoubleClick(object sender, System.EventArgs e)
        {
            if (currentSystemID != "")
                if (CreateSystem())
                    MdiMinimize();
        }
        private void lvMyList_Click(object sender, System.EventArgs e)
        {
            //Reset
            currentSystemID = "";
            currentSystemName = "";
            currentUserID = "";

            if (lvMyList.SelectedItems.Count > 0)
            {
                //lvOpenList, lvList에서 선택된 Item Clear
                this.lvOpenList.SelectedItems.Clear();
                this.lvList.SelectedItems.Clear();

                //SubItems순서는 systemName, systemID, groupID, desc 순으로 설정됨
                //선택된 SystemName ,SystemID,그룹ID SET
                currentSystemName = lvMyList.SelectedItems[0].SubItems[0].Text;
                currentSystemID = lvMyList.SelectedItems[0].SubItems[1].Text;
                currentGroupID = lvMyList.SelectedItems[0].SubItems[2].Text;
                currentGroupName = lvMyList.SelectedItems[0].SubItems[3].Text;
                //Description SET
                SetDescription(lvMyList.SelectedItems[0].SubItems[4].Text);

                //바로가기,Run 버튼 Enable
                ChangeButtonState(true);

                //마이메뉴 등록버튼 Disable
                this.btnRegMySystem.Enabled = false;
                //메세지시스템삭제 버튼 Disable
                this.btnUnRegMsg.Enabled = false;
            }
        }

        private void lvMyList_DoubleClick(object sender, System.EventArgs e)
        {
            //지정된 시스템 Open
            if (currentSystemID != "")
                if (CreateSystem())
                    MdiMinimize();
        }

        private void btnRun_Click(object sender, System.EventArgs e)
        {
            // 업무시스템이 선택되었을때만 Return
            if (CreateSystem())
                MdiMinimize();
        }
        private void btnMinimize_Click(object sender, System.EventArgs e)
        {
            MdiMinimize();
        }
        private void btnSend_Click(object sender, System.EventArgs e)
        {
            string msg = "";
            try
            {
                if (currentSystemID == "")
                {
                    msg = XMsg.GetMsg("M014"); // 업무 시스템을 선택하십시오.
                    //XMessageBox.Show(msg, "IHIS");
                    XMessageBox.Show(msg, "KCCK");
                    return;
                }
                //바로가기 Icon SET (arg : 업무시스템 ID)
                string args = "\"" + currentSystemID + "\"";
                string iconFileName = imagePath + currentSystemID + ".ico";
                // 해당 업무시스템의 Icon이 없으면 공통 Icon(IHIS.ico)으로 SET
                if (!File.Exists(iconFileName))
                    iconFileName = imagePath + "IHISL.ico";
                string desc = currentSystemName + XMsg.GetMsg("M015"); //currentSystemName + "시스템입니다
                ShellLink.Update(Environment.SpecialFolder.DesktopDirectory, Application.ExecutablePath, currentSystemName, args, desc, iconFileName, true);
            }
            catch (Exception xe)
            {
                msg = XMsg.GetMsg("M016") + "\nError[" + xe.Message + "]";  // 바탕화면에 바로가기를 만들 수 없습니다.\n" + "에러[" + xe.Message + "]"
                //XMessageBox.Show(msg, "IHIS");
                XMessageBox.Show(msg, "KCCK");
            }
        }
        private void btnSystemClose_Click(object sender, System.EventArgs e)
        {
            //업무시스템,메세지시스템이 Run되고 있는 상황에서는 종료다시확인후 확인시 업무시스템 종료후 IHIS 종료
            //Run중인 업무시스템이 있으면 종료여부 재확인
            //2005.04.14 메세지 시스템은 확인하지 않음
            //if ((this.lvOpenList.Items.Count > 0) || (this.lvMsgList.Items.Count > 0))
            if (this.lvOpenList.Items.Count > 0)
            {
                WarningForm dlg = new WarningForm();
                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    dlg.Dispose();
                    return;
                }
                dlg.Dispose();
            }

            //IHIS종료시에 해당 IP로 등록된 모든 MsgID 삭제처리
            UnRegisterAllMsgID();

            try
            {
                //Udp Server 종료
                if (udpThread != null)
                {
                    udpServer.Connected = false;
                    udpThread.Abort();
                }
            }
            catch (Exception xe)
            {
                Logs.WriteLog("Main", "UdpServer Stop Error=" + xe.Message);
            }

            //현재실행중인 메세지시스템에 WM_CLOSE Msg Send (WM_CLOSE에 의해 TrayIcon이 정상적으로 사라질 수 있도록함)
            string systemID = "";
            ArrayList handleList = new ArrayList();

            #region START-FORM
            //foreach (MainMenuItemInfo menuItem in msgSystemList.MenuItem)
            //{
            //    systemID = menuItem.SystemId;
            //    if (SystemHandleManager.Contains(systemID))
            //    {
            //        handleList.Add(SystemHandleManager.GetHandle(systemID));
            //    }
            //}

            foreach (DataRow dtRow in this.msgSystemTable.Rows)
            {
                systemID = dtRow["SystemID"].ToString();
                if (SystemHandleManager.Contains(systemID))
                {
                    handleList.Add(SystemHandleManager.GetHandle(systemID));
                }
            }
            #endregion

            // <<2013.12.23>> LKH START : WM_CLOSE 을 오픈된 시스템에 전달하기 위해
            foreach (ListViewItem lvItem in this.lvOpenList.Items)
            {
                systemID = lvItem.SubItems[1].Text;
                handleList.Add(SystemHandleManager.GetHandle(systemID));
            }

            // <<2013.12.23>> LKH END : WM_CLOSE 을 오픈된 시스템에 전달하기 위해
            foreach (IntPtr handle in handleList)
            {
                if (handle != IntPtr.Zero)
                    User32.SendMessage(handle, (int)Msgs.WM_CLOSE, 0, 0);
                else
                    Logs.WriteLog("Main", "시스템 종료, handle is Zero");
            }

            // DB Session 종료
            Service.DisConnect();

            //IHIS종료 (Application.Exit를 하면 다른 Sub Thread에서 돌고있는 업무시스템이 종료되지
            RemoveBarFont();

            // https://sofiamedix.atlassian.net/browse/MED-10662
            try
            {
                VPNHelpers.ExtAccountDisconnect(CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY, "").ToString());
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }

            //않으므로 Process를 Kill한다.
            Process.GetCurrentProcess().Kill();
        }
        private void btnRegen_Click(object sender, System.EventArgs e)
        {
            //시스템리스트 생성, 메세지시스템 리스트 구성, ImageList 구성, TreeView 구성,마이시스템,메세지시스템 구성
            CreateSystemInfoTable(true);
            CreateMsgSystemTable(true);
            GenImageList();
            SetTreeViewItems();
            lvList.Items.Clear();
            LoadMySystemFromXml();
            //메세지시스템 리스트 Clear후에 다시 Item Set(기 Open중인 메세지 시스템에 Image 다시 설정
            ArrayList msgSysList = new ArrayList();
            foreach (ListViewItem item in this.lvMsgList.Items)
                msgSysList.Add(item.SubItems[1].Text); //시스템ID 저장
            //Clear
            this.lvMsgList.Items.Clear();
            foreach (string sysID in msgSysList)
                this.AddOpenMsgSystemList(sysID);
        }

        private void btnRegMySystem_Click(object sender, System.EventArgs e)
        {
            try
            {
                string msg = "";
                string title = XMsg.GetMsg("M017"); // 자주쓰는 시스템 등록
                //시스템리스트,실행중인시스템리스트에서 선택된 시스템을 마이 시스템으로 등록
                if (this.lvList.SelectedItems.Count > 0)
                {
                    ListViewItem item = this.lvList.SelectedItems[0];
                    //이미 등록된 item인지 여부 Check (SystemID, GroupID 비교)
                    foreach (ListViewItem vItem in this.lvMyList.Items)
                    {
                        if ((vItem.SubItems[1].Text == item.SubItems[1].Text) && (vItem.SubItems[2].Text == item.SubItems[2].Text))
                        {
                            msg = "[" + vItem.Text + "]" + XMsg.GetMsg("M018"); //"[" + vItem.Text + "](은)는 이미 등록되었습니다."
                            XMessageBox.Show(msg, title);
                            return;
                        }
                    }
                    //SubItem은 systemName, systemID, groupID, groupName, desc순으로 설정
                    this.lvMyList.Items.Add(new ListViewItem(new string[] { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text }, item.ImageIndex));

                    //마이시스템 관리 Xml에 해당 시스템 Write
                    this.RegisterMySystemToXml(item.SubItems[1].Text, item.Text, item.SubItems[2].Text);
                }
                else if (this.lvOpenList.SelectedItems.Count > 0)
                {
                    ListViewItem item = this.lvOpenList.SelectedItems[0];
                    //이미 등록된 item인지 여부 Check (SystemID, GroupID 비교)
                    foreach (ListViewItem vItem in this.lvMyList.Items)
                    {
                        if ((vItem.SubItems[1].Text == item.SubItems[1].Text) && (vItem.SubItems[2].Text == item.SubItems[2].Text))
                        {
                            msg = XMsg.GetMsg("M019"); // 이미 등록된 업무시스템입니다."
                            XMessageBox.Show(msg, title);
                            return;
                        }
                    }

                    //SubItem은 systemName, systemID, groupID, groupName, desc순으로 설정
                    this.lvMyList.Items.Add(new ListViewItem(new string[] { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text }, item.ImageIndex));
                    //마이시스템 관리 Xml에 해당 시스템 Write
                    this.RegisterMySystemToXml(item.SubItems[1].Text, item.Text, item.SubItems[2].Text);
                }
            }
            catch (Exception xe)
            {
                Debug.WriteLine("마이시스템등록에러=" + xe.Message);
            }
        }

        private void btnDelMySystem_Click(object sender, System.EventArgs e)
        {
            string msg = "";
            string title = XMsg.GetMsg("M020"); // 자주쓰는 시스템 삭제
            //마이시스템선택여부 확인
            if (this.lvMyList.SelectedItems.Count < 1)
            {
                msg = XMsg.GetMsg("M014"); // 업무시스템을 선택하십시오.
                XMessageBox.Show(msg, title);
                return;
            }
            ListViewItem item = this.lvMyList.SelectedItems[0];
            //삭제확인 Confirm
            msg = "[" + item.Text + "]" + XMsg.GetMsg("M021"); // (을)를 자주쓰는 시스템에서 삭제하시겠습니까?"
            if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                //리스트 삭제
                this.lvMyList.Items.Remove(item);

                //마이시스템 관리 Xml에서 해당시스템 삭제
                this.UnRegisterMySystemToXml(item.SubItems[1].Text);
            }
        }
        private void btnAdmLogin_Click(object sender, System.EventArgs e)
        {
            ////AdminLogin창을 띄워 확인시 시스템 재구성
            //AdminLoginForm dlg = new AdminLoginForm();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    //Admin User
            //    this.adminUserYn = "Y";
            //    //시스템 재생성
            //    this.btnRegen_Click(this.btnRegen, EventArgs.Empty);
            //}

            // updated by Cloud
            if(UserInfo.ChangePwdFlg == "N")
            {
                XMessageBox.Show(Resources.MSG009);
            }
            else
            {
                ChangePswdForm dlg = new ChangePswdForm(UserInfo.UserID);
                dlg.ShowDialog();
                dlg.Dispose();
            }
        }
        #endregion

        #region 상태변경 관련 Private Methods
        private void MdiMinimize()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ChangeButtonState(bool enabled)
        {
            //바로가기, Run 버튼 활성상태 변경
            this.btnSend.Enabled = enabled;
            this.btnRun.Enabled = enabled;
            this.btnDelMySystem.Enabled = enabled;
            this.btnRegMySystem.Enabled = enabled;
        }
        #endregion

        #region WndProc Override
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == MSG_IHIS_INSTANCE_FOCUS)
            {
                //현재 업무시스템 Reset
                currentSystemID = "";
                currentSystemName = "";
                currentUserID = "";

                tvList.SelectedNode = null;
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                if (!this.Focused)
                    this.Focus();
                this.Activate();
                ChangeButtonState(false);
            }
            else if (msg.Msg == MSG_SYSTEM_WINDOW_HANDLE_SEND)
            {
                //WParam에 SystemID, LParam에 WindowHandle
                //WParam을 String으로 변환
                string sysID = Marshal.PtrToStringAnsi(msg.WParam);
                SystemHandleManager.AddHandleList(new SystemHandle(sysID, msg.LParam));
            }
            else if (msg.Msg == (int)Msgs.WM_COPYDATA)
            {
                //LParam에 전달된 데이타를 COPYDATASTRUCT로 변환
                COPYDATASTRUCT st = (COPYDATASTRUCT)Marshal.PtrToStructure(msg.LParam, typeof(COPYDATASTRUCT));
                //Win2000이상 UniCode, Win98 : Ansi (현재시스템 설정)
                currentSystemID = Marshal.PtrToStringAuto(st.lpData);  //업무시스템 ID

                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;
                //if (CreateSystem())
                //	MdiMinimize();
                //선택한 업무시스템 Create
                this.WindowState = FormWindowState.Minimized;
                CreateSystem();
            }
            else if (msg.Msg == MSG_SYSTEM_USER_LOGIN)  //시스템사용자 LOGIN MSG
            {
                // <<2013.12.08>> LKH
                //<개발중> 개발중 XMSG를 띄우지 않으므로 Comment 처리함.

                //XMSG 시스템에 MSG_XMSG_USER_LOGIN MSG Send
                if (SystemHandleManager.Contains(XMSG_SYSTEM_ID))
                {
                    IntPtr handle = SystemHandleManager.GetHandle(XMSG_SYSTEM_ID);
                    if (handle != IntPtr.Zero)
                        User32.SendMessage(handle, MSG_SYSTEM_USER_LOGIN, msg.WParam, msg.LParam);
                    else
                        Logs.WriteLog("Main", "IHIS::WndProc MSG_SYSTEM_USER_LOGIN XMSG Handler = IntPtr.Zero");
                }
                else
                    Logs.WriteLog("Main", "IHIS::WndProc MSG_SYSTEM_USER_LOGIN SystemHandleManager Not Contains XMSG Handle");

            }
            else if (msg.Msg == MSG_SYSTEM_USER_LOGOUT) //시스템 사용자 LOGOUT MSG
            {
                // <<2013.12.08>> LKH
                //<개발중> 개발중 XMSG를 띄우지 않으므로 Comment 처리함.

                //XMSG 시스템에 MSG_XMSG_USER_LOGOUT MSG Send
                if (SystemHandleManager.Contains(XMSG_SYSTEM_ID))
                {
                    IntPtr handle = SystemHandleManager.GetHandle(XMSG_SYSTEM_ID);
                    if (handle != IntPtr.Zero)
                        User32.SendMessage(handle, MSG_SYSTEM_USER_LOGOUT, msg.WParam, msg.LParam);
                    else
                        Logs.WriteLog("Main", "IHIS::WndProc MSG_SYSTEM_USER_LOGOUT XMSG Handler = IntPtr.Zero");
                }
                else
                    Logs.WriteLog("Main", "IHIS::WndProc MSG_SYSTEM_USER_LOGOUT SystemHandleManager Not Contains XMSG Handle");

            }
            else if (msg.Msg == MSG_SYSTEM_USER_CHANGED)  //시스템 사용자 변경시 MSG
            {
                // <<2013.12.08>> LKH
                //<개발중> 개발중 XMSG를 띄우지 않으므로 Comment 처리함.

                //XMSG 시스템에 MSG_SYSTEM_USER_CHANGED MSG Send (wParam에 시스템ID + 변경후사용자ID가 넘어옴)
                if (SystemHandleManager.Contains(XMSG_SYSTEM_ID))
                {
                    IntPtr handle = SystemHandleManager.GetHandle(XMSG_SYSTEM_ID);
                    if (handle != IntPtr.Zero)
                        User32.SendMessage(handle, MSG_SYSTEM_USER_CHANGED, msg.WParam, msg.LParam);
                    else
                        Logs.WriteLog("Main", "IHIS::WndProc MSG_SYSTEM_USER_CHANGED XMSG Handler = IntPtr.Zero");
                }
                else
                    Logs.WriteLog("Main", "IHIS::WndProc MSG_SYSTEM_USER_CHANGED SystemHandleManager Not Contains XMSG Handle");

            }
            else if (msg.Msg == MSG_XMSG_DISPLAY) //메세지시스템 DISPLAY MSG
            {
                // <<2013.12.08>> LKH
                //<개발중> 개발중 XMSG를 띄우지 않으므로 Comment 처리함.

                try
                {
                    //wParam에 전달된 XMSG에 전달할 사용자 ID 가져오기
                    //XMSG 시스템에 MSG_XMSG_DISPLAY MSG Send
                    if (SystemHandleManager.Contains(XMSG_SYSTEM_ID))
                    {
                        IntPtr handle = SystemHandleManager.GetHandle(XMSG_SYSTEM_ID);
                        if (handle != IntPtr.Zero)
                            User32.SendMessage(handle, MSG_XMSG_DISPLAY, msg.WParam, msg.LParam);
                        else
                            Logs.WriteLog("Main", "IHIS::WndProc MSG_XMSG_DISPLAY XMSG Handler = IntPtr.Zero");
                    }
                    else
                        Logs.WriteLog("Main", "IHIS::WndProc MSG_XMSG_DISPLAY SystemHandleManager Not Contains XMSG Handle");
                }
                catch (Exception xe)
                {
                    Logs.WriteLog("Main", "MainForm::WndProc MSG_XMSG_DISPLAY 에러=" + xe.Message);
                }

            }
            else if (msg.Msg == MSG_FIND_MSG_SYSTEM)
            {
                //WParam에 SystemID 
                //WParam을 String으로 변환
                string systemID = Marshal.PtrToStringAnsi(msg.WParam);
                //SystemHandleManager가 systemID를 가지고 있고, Handle이 있으면 1(true), 그외는 (0) false
                if (SystemHandleManager.Contains(systemID) && (SystemHandleManager.GetHandle(systemID) != IntPtr.Zero))
                {
                    msg.Result = new IntPtr(1);
                }
                else
                {
                    msg.Result = new IntPtr(0);
                }
            }
            else
                base.WndProc(ref msg);
        }
        #endregion

        #region AppDomain 관련 static Method
        private bool CreateSystem()
        {
            string msg = "";
            string title = XMsg.GetMsg("M022"); // 업무시스템 시작
            if (currentSystemID == "")
            {
                msg = XMsg.GetMsg("M014"); //업무 시스템이 선택되지 않았습니다."
                XMessageBox.Show(msg, title);
                return false;
            }
            bool isFoundSystem = false;
            //foreach (MainMenuItemInfo menuItem in sysInfoList.MenuItem)
            //{
            //    if (menuItem.SystemId.Trim() == currentSystemID)
            //    {
            //        //IHIS 시스템에서 시스템명을 변경한 경우 기존에 단축ICon의 시스템명이 옛날 시스템명인 경우에 
            //        //대비하여 시스템명 다시 설정(그룹ID, 그룹명도 설정)
            //        currentGroupID = menuItem.GroupId;
            //        currentGroupName = menuItem.GroupName;
            //        currentSystemName = menuItem.SystemName;
            //        isFoundSystem = true;
            //        break;
            //    }
            //}

            foreach (DataRow dtRow in this.sysInfoTable.Rows)
            {
                if (dtRow["SystemID"].ToString().Trim() == currentSystemID)
                {
                    //IHIS 시스템에서 시스템명을 변경한 경우 기존에 단축ICon의 시스템명이 옛날 시스템명인 경우에 
                    //대비하여 시스템명 다시 설정(그룹ID, 그룹명도 설정)

                    currentGroupID = dtRow["GroupID"].ToString();
                    currentGroupName = dtRow["GroupName"].ToString();
                    currentSystemName = dtRow["SystemName"].ToString();
                    isFoundSystem = true;
                    break;
                }
            }

            //현재 등록된 시스템과 다르면 Return
            if (!isFoundSystem)
            {
                msg = XMsg.GetMsg("M023") + "[" + currentSystemID + "]"; // 업무 시스템이 존재하지 않습니다.[" + currentSystemID + "]"
                XMessageBox.Show(msg, title);
                return false;
            }

            if (IsSystemActive())
            {
                try
                {
                    // 해당 업무시스템의 MainWindow로 Focus
                    if (SystemHandleManager.Contains(currentSystemID))
                    {
                        IntPtr handle = SystemHandleManager.GetHandle(currentSystemID);
                        if (handle != IntPtr.Zero)
                            User32.PostMessage(handle, MSG_SYSTEM_INSTANCE_FOCUS, 0, 0); //해당 업무 시스템 MDI Active
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {

                //시작창 Show (3 sec 후 닫기)
                StartingForm dlg = new StartingForm(3);
                dlg.Show();

                // 해당 업무시스템의 Library DownLoad
                // DownLoad에러나 Download성공후에 Copy가 안되면 
                VersionResult result = DownloadFiles();
                //다운로드에러 OR Download후에 FileCopy에러이면 경고후 종료
                if ((result == VersionResult.DownError) || (result == VersionResult.CopyError))
                {
                    // 파일 Copy실패시 어떻게 처리할 것인가 결정필요함(일단 실행불가)
                    msg = XMsg.GetMsg("M008") + "\n"  //파일을 다운로드하는데 실패하였습니다.
                        + XMsg.GetMsg("M009") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
                        + XMsg.GetMsg("M010");      //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
                    //MessageBox를 Show하면 MessageBox든 XMessageBox든 첫번째 MsgBox는 금방 사라져 버림
                    //원인을 찾아야 하며 처리방안으로 TickTockForm(잠시떴다가 0.5sec후에 사라짐)을 먼저 Show함
                    TickTock();
                    XMessageBox.Show(msg, title);

                    return false;
                }
                else if (result == VersionResult.DeleteFail) //Down\bin의 Dummy파일 삭제실패시
                {
                    // 파일 Copy실패시 어떻게 처리할 것인가 결정필요함(일단 실행불가)
                    msg = XMsg.GetMsg("M011") + "\n"  //다운로드 디렉토리에 있는 파일을 삭제하지 못했습니다.
                        + XMsg.GetMsg("M009") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
                        + XMsg.GetMsg("M010");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
                    TickTock();
                    XMessageBox.Show(msg, title);
                    return false;
                }

                try
                {
                    // 상태를 가지는 Thread를 객체를 생성하여 New Thread로 기동
                    // 한 메세지시스템이 기동중일때 다른 메세지 시스템이 들어오면 msgSystemID 가 바뀌므로
                    // Thread객체에 시스템ID정보를 전달하여 처리함
                    // 단일 Thread일 경우 한 업무시스템에서 lock 발생시 다른 시스템을 사용하지 
                    // 못하므로 Multi Thread로 기동처리함
                    //ThreadWithState tws = new ThreadWithState(this, false, currentGroupID, currentGroupName, currentSystemID, currentSystemName, currentUserID);
                    ThreadWithState tws = new ThreadWithState(
                        this,
                        false,
                        currentGroupID,
                        currentGroupName,
                        currentSystemID,
                        currentSystemName,
                        /*currentUserID,*/
                        UserInfo.UserID,
                        UserInfo.UserPswd,
                        UserInfo.HospCode,
                        UserInfo.UserGroup,
                        WebSocketClient.SessionId,
                        UserInfo.DoctorDrugCheck.ToString(),
                        UserInfo.CheckDosage.ToString(),
                        UserInfo.CheckInteraction.ToString(),
                        UserInfo.CheckKinki.ToString(),
                        ((int)NetInfo.Language).ToString(),
                        UserInfo.OrcaIp,
                        UserInfo.OrcaUser,
                        UserInfo.OrcaPassword,
                        UserInfo.OrcaPort,
                        UserInfo.OrcaHospCode,
                        UserInfo.OrcaPortRcvClaim,
                        UserInfo.MisaIp,
                        UserInfo.MisaUser,
                        UserInfo.MisaPwd,
                        UserInfo.MisaDbInsurName,
                        UserInfo.MisaInstanceName,
                        UserInfo.MisaDbNonInsurName,
                        UserInfo.ChangePwdFlg,
                        UserInfo.FirstLoginFlg,
                        UserInfo.LastPwdChange,
                        UserInfo.PwdHistory,
                        UserInfo.CurrentTime,
                        UserInfo.VpnYn.ToString(),
                        UserInfo.InvUsage.ToString(),
                        UserInfo.UsePHR.ToString(),
                        UserInfo.TimeZone,
                        UserInfo.UserName,
                        UserInfo.CplSpecimenAuto,
                        UserInfo.CplDevBlood,
                        UserInfo.CplDevUrine,
                        UserInfo.CplDevBio,
                        UserInfo.CplServer,
                        UserInfo.CplPort,
                        UserInfo.CplDatabase,
                        UserInfo.CplUserId,
                        UserInfo.CplPassword
                    );
                    Thread newThread = new Thread(new ThreadStart(tws.OpenSystem));
                    //끌어서 놓기 같은 요소를 초기화하는 Windows Forms의 경우 단일 스레드 아파트를 만들어서 입력
                    newThread.SetApartmentState(ApartmentState.STA);
                    newThread.Name = currentSystemID;
                    newThread.Start();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("CreateSystem, Error=" + e.Message);
                    Logs.WriteLog("Main", "MainForm::CreateSystem currentSystemID=" + currentSystemID + ",에러=" + e.Message);
                    Logs.WriteLog("Main", "MainForm::CreateSystem StackTrace=" + e.StackTrace);
                }
            }
            return true;
        }

        static VersionResult DownloadFiles()
        {
            if (!Service.IsAssemblyDownLoad)
                return VersionResult.Success;

            //업무시스템의 Dir Name = currentSystemID
            VersionManager ver = new VersionManager(currentGroupID, currentSystemID, currentSystemID);
            return ver.DownloadFiles();
        }
        private bool IsSystemActive()
        {

            //Process.GetCurrentProcess()를 하면 특정한 Case(오랫동안 쓰지 않다가 쓰는 경우)에는 시간이 많이 걸린다.
            //따라서, ProcessModule로 Check하지 않고, lvOpenList의 Items를 검색하여 시스템존재여부를 Check한다.
            foreach (ListViewItem item in lvOpenList.Items)
            {
                //SystemID는 SubItems[1]에 저장
                if (item.SubItems[1].Text == currentSystemID)
                    return true;
            }
            return false;
        }
        #endregion

        #region 오픈시스템 ListView에 추가,삭제 Methods
        internal void AddOpenSystemList(string systemID)
        {
            string description = "", systemName = "", groupID = "", groupName = "";
            int sImageIdx = 0;
            bool isFind = false;
            ListViewItem item = null;

            //foreach (MainMenuItemInfo menuItem in sysInfoList.MenuItem)
            //{
            //    if (menuItem.SystemId == systemID)
            //    {
            //        groupID = menuItem.GroupId;
            //        groupName = menuItem.GroupName;
            //        systemName = menuItem.SystemName;
            //        description = menuItem.Description;
            //        sImageIdx = menuItem.SystemImageIndex;
            //        isFind = true;
            //        break;
            //    }
            //}

            foreach (DataRow dtRow in sysInfoTable.Rows)
            {
                if (dtRow["SystemID"].ToString() == systemID)
                {
                    groupID = dtRow["GroupID"].ToString();
                    groupName = dtRow["GroupName"].ToString();
                    systemName = dtRow["SystemName"].ToString();
                    description = dtRow["Description"].ToString();
                    sImageIdx = Int32.Parse(dtRow["SystemImageIndex"].ToString());
                    isFind = true;
                    break;
                }
            }

            if (isFind)
            {
                //SubItem은 systemName, systemID, groupID, groupName, desc순으로 설정
                item = new ListViewItem(new string[] { systemName, systemID, groupID, groupName, description }, sImageIdx);
                lvOpenList.Items.Add(item);
            }
        }
        internal void RemoveOpenSystemList(string systemID)
        {
            ListViewItem removeItem = null;
            foreach (ListViewItem item in lvOpenList.Items)
            {
                //SystemID는 SubItems[1]에 저장
                if (item.SubItems[1].Text == systemID)
                {
                    removeItem = item;
                    break;
                }
            }
            if (removeItem != null)
            {
                lvOpenList.Items.Remove(removeItem);
            }
        }
        #endregion

        #region 오픈메세지시스템 ListView에 추가,삭제 Methods
        internal void AddOpenMsgSystemList(string systemID)
        {
            //시스템ID가 XMSG는 리스트View에 등록하지 않음(공통 MSG이므로 ListView에 관리하지 않음)
            if (systemID == XMSG_SYSTEM_ID) return;

            string description = "", systemName = "", groupID = "", groupName = "";
            int sImageIdx = 0;
            bool isFind = false;
            ListViewItem item = null;
            //foreach (MainMenuItemInfo menuItem in msgSystemList.MenuItem)
            //{
            //    if (menuItem.SystemId == systemID)
            //    {
            //        groupID = menuItem.GroupId;
            //        groupName = menuItem.GroupName;
            //        systemName = menuItem.SystemName;
            //        description = menuItem.Description;
            //        sImageIdx = menuItem.SystemImageIndex;
            //        isFind = true;
            //        break;
            //    }
            //}

            foreach (DataRow dtRow in this.msgSystemTable.Rows)
            {
                if (dtRow["SystemID"].ToString() == systemID)
                {
                    groupID = dtRow["GroupID"].ToString();
                    groupName = dtRow["GroupName"].ToString();
                    systemName = dtRow["SystemName"].ToString();
                    description = dtRow["Description"].ToString();
                    sImageIdx = Int32.Parse(dtRow["SystemImageIndex"].ToString());
                    isFind = true;
                    break;
                }
            }

            if (isFind)
            {
                //SubItem은 systemName, systemID, groupID, groupName, desc순으로 설정
                item = new ListViewItem(new string[] { systemName, systemID, groupID, groupName, description }, sImageIdx);
                this.lvMsgList.Items.Add(item);
            }
        }
        internal void RemoveOpenMsgSystemList(string systemID)
        {
            //시스템ID가 XMSG는 리스트View에 관리하지 않음(공통 MSG이므로 ListView에 관리하지 않음)
            if (systemID == XMSG_SYSTEM_ID) return;

            ListViewItem removeItem = null;
            foreach (ListViewItem item in lvMsgList.Items)
            {
                //SystemID는 SubItems[1]에 저장
                if (item.SubItems[1].Text == systemID)
                {
                    removeItem = item;
                    break;
                }
            }
            if (removeItem != null)
            {
                lvMsgList.Items.Remove(removeItem);
            }
        }
        #endregion

        #region 자주쓰는 시스템 등록,삭제, Load하기
        private XmlDocument mySystemXmlDoc = null;
        private XmlElement mySystemsXmlElement = null; //MySystem Xml의 systems element
        const string XML_FILE_NAME = "MyFavoriteSystem.xml";
        private void LoadMySystemFromXml()
        {
            try
            {
                //기존 List Clear
                this.lvMyList.Items.Clear();

                //파일명 = MyFavoriteSystem.xml
                string fileName = Application.StartupPath + "\\" + XML_FILE_NAME;
                Encoding kscEncoding = Encoding.UTF8;
                string systemID = "", systemName = "", groupID = "", groupName = "", description = "";
                int systemImageIndex = 0;
                bool isFind = false;
                if (File.Exists(fileName))
                {
                    TextReader textReader = new StreamReader(fileName, kscEncoding);
                    XmlReader xmlReader = new XmlTextReader(textReader);
                    this.mySystemXmlDoc = new XmlDocument();
                    mySystemXmlDoc.Load(xmlReader);
                    mySystemsXmlElement = mySystemXmlDoc.DocumentElement;
                    foreach (XmlNode node in mySystemsXmlElement.ChildNodes)
                    {
                        isFind = false;
                        systemID = node.Attributes["id"].Value;
                        //						systemName  = node.Attributes["name"].Value;
                        groupID = node.Attributes["groupid"].Value;
                        //조회한 정보와 동일한 Group, System인지여부 Check
                        //해당 시스템ID의 Description과 이미지Index Get
                        //foreach (MainMenuItemInfo menuItem in sysInfoList.MenuItem)
                        //{
                        //    //동일한 그룹ID, 시스템ID이면 ListView에 Add
                        //    if ((menuItem.SystemId == systemID) && (menuItem.GroupId == groupID))
                        //    {
                        //        systemName = menuItem.SystemName;
                        //        groupName = menuItem.GroupName;
                        //        description = menuItem.Description;
                        //        systemImageIndex = menuItem.SystemImageIndex;
                        //        isFind = true;
                        //        break;
                        //    }
                        //}

                        foreach (DataRow dtRow in sysInfoTable.Rows)
                        {
                            //동일한 그룹ID, 시스템ID이면 ListView에 Add

                            if ((dtRow["SystemID"].ToString() == systemID) && (dtRow["GroupID"].ToString() == groupID))
                            {
                                systemName = dtRow["SystemName"].ToString();
                                groupName = dtRow["GroupName"].ToString();
                                description = dtRow["Description"].ToString();
                                systemImageIndex = Int32.Parse(dtRow["SystemImageIndex"].ToString());
                                isFind = true;
                                break;
                            }
                        }

                        if (isFind)
                        {
                            //SubItem은 systemName, systemID, groupID, groupName, desc순으로 설정
                            ListViewItem item = new ListViewItem(new string[] { systemName, systemID, groupID, groupName, description }, systemImageIndex);
                            this.lvMyList.Items.Add(item);
                        }

                    }
                    xmlReader.Close();
                    textReader.Close();
                }
                else  //없으면 파일 생성
                {
                    TextWriter textWriter = new StreamWriter(fileName, false, kscEncoding);
                    mySystemXmlDoc = new XmlDocument();
                    //systems node Add
                    mySystemsXmlElement = mySystemXmlDoc.CreateElement("systems");
                    mySystemXmlDoc.AppendChild(mySystemsXmlElement);
                    //File Write
                    mySystemXmlDoc.Save(textWriter);
                    textWriter.Close();
                }
            }
            catch { }
        }
        private void RegisterMySystemToXml(string systemID, string systemName, string groupID)
        {
            try
            {
                //systems Node에 새로운 시스템 Add
                XmlElement element = mySystemXmlDoc.CreateElement("system");
                //id, name, groupID Set
                element.SetAttribute("id", systemID);
                element.SetAttribute("name", systemName);
                element.SetAttribute("groupid", groupID);
                mySystemsXmlElement.AppendChild(element);

                //파일명 = MyFavoriteSystem.xml
                string fileName = Application.StartupPath + "\\" + XML_FILE_NAME;
                Encoding kscEncoding = Encoding.UTF8;
                TextWriter textWriter = new StreamWriter(fileName, false, kscEncoding);
                //FileWrite
                mySystemXmlDoc.Save(textWriter);
                textWriter.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("RegisterMySystemToXml Error=" + e.Message);
            }
        }
        private void UnRegisterMySystemToXml(string systemID)
        {
            try
            {
                bool isFind = false;
                XmlNode delNode = null;
                //mySystemsXmlElement에서 해당 systemID를 가지는 XmlElement Get
                foreach (XmlNode node in this.mySystemsXmlElement.ChildNodes)
                {
                    if (node.Attributes["id"].Value == systemID)
                    {
                        isFind = true;
                        delNode = node;
                        break;
                    }
                }
                if (isFind)
                {
                    //해당 Node 삭제
                    mySystemsXmlElement.RemoveChild(delNode);

                    //Xml File에 Write 파일명 = MyFavoriteSystem.xml
                    string fileName = Application.StartupPath + "\\" + XML_FILE_NAME;
                    Encoding kscEncoding = Encoding.UTF8;
                    TextWriter textWriter = new StreamWriter(fileName, false, kscEncoding);
                    //FileWrite
                    mySystemXmlDoc.Save(textWriter);
                    textWriter.Close();

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("UnRegisterMySystemToXml Error=" + e.Message);
            }
        }
        #endregion

        #region OnSelectedTabPageChanged (TAB이 바뀌었을때 처리)
        private void OnSelectedTabPageChanged(int index)
        {
            this.selectedIndex = index;
            //0이면 IHIS TabPage, 1이면 자주쓰는 시스템 TabPage
            if (index == 0)
            {
                this.BackgroundImage = firstImage;
                this.tvList.Visible = true;
                this.lvList.Visible = true;
                this.btnRegMySystem.Visible = true;
                this.lvMyList.Visible = false;
                this.btnDelMySystem.Visible = false;
            }
            else
            {
                // 2015.09.29 fixed bug https://nextop-asia.atlassian.net/browse/MED-4434
                //this.BackgroundImage = secondImage;
                //this.tvList.Visible = false;
                //this.lvList.Visible = false;
                //this.btnRegMySystem.Visible = false;
                //this.lvMyList.Visible = true;
                //this.btnDelMySystem.Visible = true;
            }

            //버튼 비활성화
            this.ChangeButtonState(false);
            this.lvOpenList.SelectedItems.Clear();
        }
        #endregion

        #region CalculateGraphicsPath
        private static GraphicsPath CalculateGraphicsPath(Bitmap bitmap)
        {

            GraphicsPath graphicsPath = new GraphicsPath();

            // TransParent Color
            Color tColor = bitmap.GetPixel(1, 1);
            //Color tColor = Color.FromArgb(255,0,0);

            // 0 ~ 40까지는 TransParent 계산, 41 ~ 459까지는 Rect 적용(TransParent없음)
            // 460 ~height까지 TransParent 계산

            int colOpaquePixel = 0;
            Rectangle rect = Rectangle.Empty;

            // Go through all rows (Y axis)
            for (int row = 0; row < 40; row++)
            {
                // Reset value
                colOpaquePixel = 0;

                // Go through all columns (X axis)
                for (int col = 0; col < bitmap.Width; col++)
                {
                    if (bitmap.GetPixel(col, row) != tColor)
                    {
                        colOpaquePixel = col;
                        int colNext = col;
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == tColor)
                                break;
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));
                        rect = new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1);
                        col = colNext;
                    }
                }
            }
            graphicsPath.AddRectangle(new Rectangle(0, 40, bitmap.Width, 420));
            for (int row = 460; row < bitmap.Height; row++)
            {
                // Reset value
                colOpaquePixel = 0;

                // Go through all columns (X axis)
                for (int col = 0; col < bitmap.Width; col++)
                {
                    if (bitmap.GetPixel(col, row) != tColor)
                    {
                        colOpaquePixel = col;
                        int colNext = col;
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == tColor)
                                break;
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));
                        rect = new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1);
                        col = colNext;
                    }
                }
            }

            // Return calculated graphics path
            return graphicsPath;
        }
        #endregion

        #region 메세지 시스템 관련 Method
        private bool IsMsgSystemActive()
        {
            //Process.GetCurrentProcess()를 하면 특정한 Case(오랫동안 쓰지 않다가 쓰는 경우)에는 시간이 많이 걸린다.
            //따라서, ProcessModule로 Check하지 않고, lvMsgList의 Items를 검색하여 시스템존재여부를 Check한다.
            foreach (ListViewItem item in lvMsgList.Items)
            {
                //SystemID는 SubItems[1]에 저장
                if (item.SubItems[1].Text == msgSystemID)
                    return true;
            }
            return false;

            //			string name = msgSystemID + ".exe";
            //			name = name.ToLower();
            //			// 현재 Process에서 구동중인 Module 검색
            //			foreach (ProcessModule pm in Process.GetCurrentProcess().Modules)
            //			{
            //				// exe 중 systemId.exe와 같은 것이 있으면 true, 아니면 false
            //				if (pm.ModuleName.ToLower() == name.ToLower())
            //					return true;
            //			}
            //			return false;
        }
        private bool CreateMsgSystem()
        {
            string msg = "";
            string title = XMsg.GetMsg("M024"); // 메세지시스템 시작
            //	
            if (msgSystemID == "")
            {
                msg = XMsg.GetMsg("M025"); // 메세지 시스템이 선택되지 않았습니다."
                XMessageBox.Show(msg, title);
                return false;
            }

            if (IsMsgSystemActive())
            {
                msg = XMsg.GetMsg("M026"); // 메세지 시스템이 이미 실행중입니다."
                XMessageBox.Show(msg, title);
                return true;
            }
            else
            {
                //시작창 Show (3 sec 후 닫기)
                StartingForm dlg = new StartingForm(3);
                dlg.Show();

                // 해당 업무시스템의 Library DownLoad
                VersionResult result = DownloadMsgSystemFiles();
                if ((result == VersionResult.DownError) || (result == VersionResult.CopyError))
                {
                    // 파일 Copy실패시 어떻게 처리할 것인가 결정필요함(일단 실행불가)
                    msg = XMsg.GetMsg("M008") + "\n"  //파일을 다운로드하는데 실패하였습니다.
                        + XMsg.GetMsg("M009") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
                        + XMsg.GetMsg("M010");      //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
                    XMessageBox.Show(msg, title);
                    return false;
                }
                else if (result == VersionResult.DeleteFail) //Down\bin의 Dummy파일 삭제실패시
                {
                    // 파일 Copy실패시 어떻게 처리할 것인가 결정필요함(일단 실행불가)
                    msg = XMsg.GetMsg("M011") + "\n"  //다운로드 디렉토리에 있는 파일을 삭제하지 못했습니다.
                        + XMsg.GetMsg("M009") + "\n"  //프로그램 종료후에 다시 한번 실행해 주십시오.
                        + XMsg.GetMsg("M010");        //계속 다운로드가 실패하면 전산실로 문의하시기 바랍니다.
                    XMessageBox.Show(msg, title);
                    return false;
                }
                try
                {
                    // 상태를 가지는 Thread를 객체를 생성하여 New Thread로 기동
                    // 한 메세지시스템이 기동중일때 다른 메세지 시스템이 들어오면 msgSystemID 가 바뀌므로
                    // Thread객체에 시스템ID정보를 전달하여 처리함
                    // 단일 Thread일 경우 한 업무시스템에서 lock 발생시 다른 시스템을 사용하지 
                    // 못하므로 Multi Thread로 기동처리함
                    ThreadWithState tws = new ThreadWithState(
                        this,
                        true,
                        msgGroupID,
                        msgGroupName,
                        msgSystemID,
                        msgSystemName,
                        /*currentUserID*/
                        UserInfo.UserID,
                        UserInfo.UserPswd,
                        UserInfo.HospCode,
                        UserInfo.UserGroup,
                        WebSocketClient.SessionId,
                        UserInfo.DoctorDrugCheck.ToString(),
                        UserInfo.CheckDosage.ToString(),
                        UserInfo.CheckInteraction.ToString(),
                        UserInfo.CheckKinki.ToString(),
                        ((int)NetInfo.Language).ToString(),
                        UserInfo.OrcaIp,
                        UserInfo.OrcaUser,
                        UserInfo.OrcaPassword,
                        UserInfo.OrcaPort,
                        UserInfo.OrcaHospCode,
                        UserInfo.OrcaPortRcvClaim,
                        UserInfo.MisaIp,
                        UserInfo.MisaUser,
                        UserInfo.MisaPwd,
                        UserInfo.MisaDbInsurName,
                        UserInfo.MisaInstanceName,
                        UserInfo.MisaDbNonInsurName,
                        UserInfo.ChangePwdFlg,
                        UserInfo.FirstLoginFlg,
                        UserInfo.LastPwdChange,
                        UserInfo.PwdHistory,
                        UserInfo.CurrentTime,
                        UserInfo.VpnYn.ToString(),
                        UserInfo.InvUsage.ToString(),
                        UserInfo.UsePHR.ToString(),
                        UserInfo.TimeZone,
                        UserInfo.UserName,
                        UserInfo.CplSpecimenAuto,
                        UserInfo.CplDevBlood,
                        UserInfo.CplDevUrine,
                        UserInfo.CplDevBio,
                        UserInfo.CplServer,
                        UserInfo.CplPort,
                        UserInfo.CplDatabase,
                        UserInfo.CplUserId,
                        UserInfo.CplPassword
                    );
                    Thread newThread = new Thread(new ThreadStart(tws.OpenSystem));
                    //끌어서 놓기 같은 요소를 초기화하는 Windows Forms의 경우 단일 스레드 아파트를 만들어서 입력
                    newThread.SetApartmentState(ApartmentState.STA);
                    newThread.Name = msgSystemID;
                    newThread.Start();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("CreateMsgSystem, Error=" + e.Message);
                    Logs.WriteLog("Main", "MainForm::CreateMsgSystem msgSystemID=" + msgSystemID + ",에러=" + e.Message);
                    Logs.WriteLog("Main", "MainForm::CreateMsgSystem StackTrace=" + e.StackTrace);
                }
            }
            return true;
        }
        static VersionResult DownloadMsgSystemFiles()
        {
            if (!Service.IsAssemblyDownLoad)
                return VersionResult.Success;

            //업무시스템의 Dir Name = systemID.systemName
            VersionManager ver = new VersionManager(msgGroupID, msgSystemID, msgSystemID);
            return ver.DownloadFiles();
        }
        private void StartMsgSystem()
        {
            //XMSG 시스템은 Registry에서 관리하지 않고 등록하기(전체 공통 메세지 시스템)
            msgGroupID = "ADM";
            msgGroupName = "Admin";
            msgSystemID = XMSG_SYSTEM_ID;
            msgSystemName = XMSG_SYSTEM_ID;
            CreateMsgSystem();

            //최초 IHIS 기동시 Registry에 등록된 메세지 시스템 기동
            /*RegistryKey rkey = Registry.LocalMachine;
            RegistryKey rkey1 = rkey.OpenSubKey(MSG_SYS_KEY);
            if (rkey1 == null) return;
            string[] msgSystemIDs = rkey1.GetSubKeyNames();*/

            if (!CacheService.Instance.IsSet(Constants.CacheKeyCbo.CACHE_COMMON_MSGSYS)) return;
            List<string> msgSystemIDs = (List<string>)CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_MSGSYS, null);

            bool isFound = false;
            foreach (string systemID in msgSystemIDs)
            {
                //XMSG가 잘못등록된 경우는 제외
                if (systemID != XMSG_SYSTEM_ID)
                {
                    isFound = false;
                    //Registry에 등록된 시스템ID에 해당하는 ID가 msgSystemTable에 있으면 실행
                    //foreach (MainMenuItemInfo menuItem in msgSystemList.MenuItem)
                    //{
                    //    if (menuItem.SystemId == systemID)
                    //    {
                    //        isFound = true;
                    //        //메세지시스템 관련 변수 설정
                    //        msgGroupID = menuItem.GroupId;
                    //        msgGroupName = menuItem.GroupName;
                    //        msgSystemID = systemID;
                    //        msgSystemName = menuItem.SystemName;
                    //        break;
                    //    }
                    //}

                    foreach (DataRow dtRow in this.msgSystemTable.Rows)
                    {
                        if (dtRow["SystemID"].ToString() == systemID)
                        {
                            isFound = true;
                            //메세지시스템 관련 변수 설정

                            msgGroupID = dtRow["GroupID"].ToString();
                            msgGroupName = dtRow["GroupName"].ToString();
                            msgSystemID = systemID;
                            msgSystemName = dtRow["SystemName"].ToString();
                            break;
                        }
                    }

                    if (isFound)
                        CreateMsgSystem();
                }
            }
        }
        private void lvMsgList_Click(object sender, System.EventArgs e)
        {
            if (this.lvMsgList.SelectedItems.Count > 0)
                this.btnUnRegMsg.Enabled = true;
        }
        private void btnRegMsg_Click(object sender, System.EventArgs e)
        {
            //현재실행중인 메세지시스템 LIST 생성
            ArrayList runSysList = new ArrayList();
            foreach (ListViewItem lvItem in this.lvMsgList.Items)
                runSysList.Add(lvItem.SubItems[1].Text);

            MsgSystemForm dlg = new MsgSystemForm(this.btnRegMsg, this.msgSystemTable, runSysList);
            if ((dlg.ShowDialog() == DialogResult.OK) && (dlg.SelectedRow != null))
            {
                msgGroupID = dlg.SelectedRow["GroupID"].ToString();
                msgGroupName = dlg.SelectedRow["GroupName"].ToString();
                msgSystemID = dlg.SelectedRow["SystemID"].ToString();
                msgSystemName = dlg.SelectedRow["SystemName"].ToString();

                //Registy의 LocalMachine/SOFTWARE/IHIS/MsgSystem에 해당시스템ID를 Key로 SubKey로 생성
                /*RegistryKey rkey = Registry.LocalMachine;
                RegistryKey rkey1 = rkey.OpenSubKey(MSG_SYS_KEY, true);
                if (rkey1 == null)
                    rkey1 = rkey.CreateSubKey(MSG_SYS_KEY);
                RegistryKey rkey2 = rkey1.OpenSubKey(msgSystemID);
                if (rkey2 == null)
                    rkey2 = rkey1.CreateSubKey(msgSystemID);

                rkey1.Close();
                rkey2.Close();*/

                List<string> msgSystemIDs = new List<string>();
                if (CacheService.Instance.IsSet(Constants.CacheKeyCbo.CACHE_COMMON_MSGSYS))
                {
                    msgSystemIDs = (List<string>)CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_MSGSYS, null);
                }
                msgSystemIDs.Add(msgSystemID);
                CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_COMMON_MSGSYS, msgSystemIDs, TimeSpan.MaxValue);

                //메세지시스템 생성
                CreateMsgSystem();
            }
            dlg.Dispose();
        }
        private void btnUnRegMsg_Click(object sender, System.EventArgs e)
        {
            string msg = "";
            string title = XMsg.GetMsg("M027"); // 삭제 확인
            //다시한번 확인후 확인시에 Registry에서 해당시스템의 값을 N로 설정하고,
            //해당 메세지시스템의 Handle로 시스템 종료 MSG SEND
            if (this.lvMsgList.SelectedItems.Count < 1)
            {
                msg = XMsg.GetMsg("M028"); // 삭제할 메세지시스템을 선택하십시오"
                XMessageBox.Show(msg, title);
                return;
            }
            string sysName = this.lvMsgList.SelectedItems[0].Text;
            string systemID = this.lvMsgList.SelectedItems[0].SubItems[1].Text;
            msg = "[" + sysName + "]" + XMsg.GetMsg("M029"); // (을)를 메세지시스템에서 삭제하시겠습니까?"
            if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SystemHandleManager.Contains(systemID))
                {
                    IntPtr handle = SystemHandleManager.GetHandle(systemID);
                    if (handle != IntPtr.Zero)
                    {
                        //Registy의 LocalMachine/SOFTWARE/IHIS/MsgSystem에 해당시스템ID를 Key로 N Set
                        /*RegistryKey rkey = Registry.LocalMachine;
                        RegistryKey rkey1 = rkey.OpenSubKey(MSG_SYS_KEY, true);
                        if (rkey1 == null)
                            rkey1 = rkey.CreateSubKey(MSG_SYS_KEY);
                        //시스템ID로 된 SubKey 삭제
                        rkey1.DeleteSubKey(systemID, false);
                        rkey1.Close();*/

                        RegistryKey rkey = Registry.LocalMachine;
                        RegistryKey rkey1 = rkey.OpenSubKey(MSG_SYS_KEY, true);
                        if (rkey1 == null)
                            rkey1 = rkey.CreateSubKey(MSG_SYS_KEY);
                        //시스템ID로 된 SubKey 삭제
                        rkey1.DeleteSubKey(systemID, false);
                        rkey1.Close();

                        if (CacheService.Instance.IsSet(Constants.CacheKeyCbo.CACHE_COMMON_MSGSYS))
                        {
                            List<string> msgSystemIDs = (List<string>)CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_MSGSYS, null);
                            msgSystemIDs.Remove(systemID);
                            CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_COMMON_MSGSYS, msgSystemIDs, TimeSpan.MaxValue);
                        }

                        //PostCall로 Send
                        //한번 Active창이 뜬 후에는 MSG가 전달되지 않는다.
                        //(이유는메세지시스템창을 TrayIcon에서 ShowInTaskBar속성을 true, false로 변경하면
                        //Window의 Handle이 바뀌어 msg를 전달하지 못함. 따라서, 메세지시스템은
                        //ShowInTaskBar = false로 고정해야 한다.
                        User32.PostMessage(handle, (int)Msgs.WM_CLOSE, 0, 0);
                        //User32.PostMessage(handle, MSG_MESSAGE_SYSTEM_CLOSE, 0, 0);
                    }
                    else
                        Logs.WriteLog("Main", "메세지시스템삭제 Handle==IntPtr.Zero systemID=" + systemID);

                }
                else
                    Logs.WriteLog("Main", "메세지시스템삭제 SystemHandleManager Not Contains systemID=" + systemID);
            }
        }
        #endregion

        #region 메세지시스템 보기
        private void btnShowMsg_Click(object sender, System.EventArgs e)
        {
            //XMSG 시스템에 MSG_XMSG_DISPLAY MSG Send
            if (SystemHandleManager.Contains(XMSG_SYSTEM_ID))
            {
                IntPtr handle = SystemHandleManager.GetHandle(XMSG_SYSTEM_ID);
                if (handle != IntPtr.Zero)
                    User32.SendMessage(handle, MSG_XMSG_DISPLAY, IntPtr.Zero, IntPtr.Zero);
            }
        }
        #endregion

        #region PC시간 동기화
        const long TIME_INTERVAL = 3000000000; //Ticks기준 5분(5분*60초*1천만)
        private void SynchronizeSystemTime()
        {
            try
            {

                //서버시간을 가져와서 PC시간과 5분이상 차이가 동기화여부 확인후 동기화, 
                //1.하루동안 경고창 Check하지 않을 경우 다시 경고창 띄우지 않음
                //하루동안 Check 여부에 관계없이 모두 Check(업무상 관리가 힘듬)
                //				bool isCheckTime = true;
                //				RegistryKey rKey = Registry.LocalMachine;
                //				RegistryKey rKey1 = rKey.OpenSubKey("SOFTWARE\\IHIS\\USER");
                //				if (rKey1 == null)
                //					rKey1 = rKey.CreateSubKey("SOFTWARE\\IHIS\\USER");
                //
                //				//TimeWarning하지 않고, 동기화 시간이 동일하면 시간 Check하지 않음
                //				if (rKey1.GetValue("TIMEWARNING","Y").ToString() == "N")
                //					if (rKey1.GetValue("SYNCDATE", "20000101").ToString() == DateTime.Today.ToString("yyyyMMdd"))
                //						isCheckTime = false;
                //				rKey1.Close();
                //
                //				//서버시간 Check하지 않음
                //				if (!isCheckTime) return;

                DateTime serverTime = GetSysDateTime();

                //시간차이가 5분이상 발생시 동기화 경고창 띄움
                if (Math.Abs(serverTime.Ticks - DateTime.Now.Ticks) < TIME_INTERVAL) return;

                SetTimeForm dlg = new SetTimeForm(serverTime);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    //시간 동기화
                    SYSTEMTIME ST = new SYSTEMTIME();
                    //표준시간적용 (우리나라 표준시는 그리니치 표준시간보다 9시간 빠름)
                    serverTime = serverTime.AddHours(-9);
                    ST.Year = (ushort)serverTime.Year;
                    ST.Month = (ushort)serverTime.Month;
                    ST.Day = (ushort)serverTime.Day;
                    ST.Hour = (ushort)serverTime.Hour;
                    ST.Minute = (ushort)serverTime.Minute;
                    ST.Second = (ushort)serverTime.Second;
                    //SystemTime Set
                    Kernel32.SetSystemTime(ST);
                }
                dlg.Dispose();
            }
            catch { }
        }
        private DateTime GetSysDateTime()
        {
            try
            {
                //2006.07.11 DB종류에 따라 SQL문 변경
                string cmdText = "SELECT TO_CHAR(SYSDATE,'YYYY/MM/DD HH24:MI:SS') FROM DUAL";
                if (Service.CurrentDBKind == DataBaseKind.SqlServer)
                    cmdText = "SELECT   CONVERT(CHAR(10), GETDATE(), 111) + ' ' + CONVERT(CHAR(10), GETDATE(), 108) ";  //For SqlServer

                object data = Service.ExecuteScalar(cmdText);
                if (data != null)
                    return DateTime.Parse(data.ToString());
                else
                    return DateTime.Now;
            }
            catch
            {
                return DateTime.Now;
            }
        }
        #endregion

        #region SetControlTextByLangMode (일본어, 한글 모드에 따른 Text 설정)
        //일본어, 한글 모드에 따른 Text 설정
        private void SetControlTextByLangMode()
        {
            this.btnAdmLogin.Text = XMsg.GetField("F004"); // ADMIN 로그인" : "ADMIN ログイン");
            this.btnDelMySystem.Text = XMsg.GetField("F005"); // 자주쓰는 시스템삭제" : "常用システム削除");
            this.btnMinimize.Text = XMsg.GetField("F006"); // 최소화" : "最小化");
            this.btnLogout.Text = XMsg.GetField("F007"); // 업무시스템 재구성" : "業務システム再構成");
            this.btnRegMsg.Text = XMsg.GetField("F008"); // 메세지시스템 등록" : "メッセージシステム登録");
            this.btnRegMySystem.Text = XMsg.GetField("F009"); // 자주쓰는 시스템등록" : "常用システム登録");
            this.btnRun.Text = XMsg.GetField("F010"); // 실 행" : "実 行");
            this.btnSend.Text = XMsg.GetField("F011"); // 바탕화면에 바로가기 만들기" : "デスクトップにショートカット作成");
            this.btnShowMsg.Text = XMsg.GetField("F012"); // 메세지 보기" : "メッセージ一覧");
            this.btnSystemClose.Text = XMsg.GetField("F013"); // 시스템 종료" : "システム終了");
            this.btnUnRegMsg.Text = XMsg.GetField("F014"); // 메세지시스템 삭제" : "メッセージシステム削除");
            this.btnNewMasterData.Text = XMsg.GetField("F024");

            // MED-14286
            if (NetInfo.Language != LangMode.Jr)
            {
                this.btnSystemClose.Font = new Font("Arial", 8.25f);
                this.btnLogout.Font = new Font("Arial", 8.25f);
                this.btnAdmLogin.Font = new Font("Arial", 8.25f);
                this.btnShowMsg.Font = new Font("Arial", 8.25f);
                this.btnMinimize.Font = new Font("Arial", 8.25f);
                this.btnNewMasterData.Font = new Font("Arial", 8.25f);
            }
        }
        #endregion

        #region TickTock
        private void TickTock()
        {
            TickTockForm dlg = new TickTockForm();
            dlg.ShowDialog();  //ShowDialog후에 0.1sec후에 timer에 의해 Close됨
            dlg.Dispose();
        }
        #endregion

        #region Logout function

        // https://sofiamedix.atlassian.net/browse/MED-6712
        public bool restart = false;

        /// <summary>
        /// Shuts down the application and starts a new instance immediately
        /// To implements this task MED-3855
        /// Date: 2015.09.19
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                // UserInfo stored in cache
                Logs.StartWriteLog();
                Logs.WriteLog("[DATA BEFORE LOGOUT]...");
                VPNHelpers.ExtAccountDisconnect(CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY, "").ToString());

                //MED-10097
                //Logs.WriteLog("[USER_ID]:" + CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_USER_ID, ""));
                //Logs.WriteLog("[CACHE_COMMON_ADMIN_YN.VALUE]:" + CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN, ""));

                //// Start a new instance
                //Process.Start(Application.ExecutablePath);
                //// Kill current process and exit the running IHIS app
                //Process.GetCurrentProcess().Kill();
                RemoveBarFont();

                Logs.WriteLog("[APPLICATION EXECUTABLEPATH]: " + Application.ExecutablePath);
                Logs.EndWriteLog();

                // https://sofiamedix.atlassian.net/browse/MED-6712
                this.restart = true;
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnSystemClose.PerformClick();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveBarFont();
        }
        private void RemoveBarFont()
        {
            try
            {
                int result = -1;
                result = RemoveFontResource(fullName);
            }
            catch (Exception ex)
            {
                Logs.WriteLog("MainForm " + ex);
            }
        }

        private void btnNewMstData_Click(object sender, EventArgs e)
        {
            //btnNewMstData.Tex
        }

        #region Checking for new master data updated

        /// <summary>
        /// 2016.02.03 AnhNV Added
        /// https://sofiamedix.atlassian.net/browse/MED-7316
        /// </summary>
        private void NotifyNewMstData()
        {
            if (UserInfo.NewMstDataLst.Count > 0)
            {
                // New master data was updated
                // 
                // pbxNotifyON.Location = new Point(548, 367);
                pbxNotifyON.Location = new Point(548, pbxNotifyON.Location.Y);
                pbxNotifyON.Visible = true;
                pbxNotifyOFF.Visible = false;
            }
            else
            {
                // No master data was updated
                // https://sofiamedix.atlassian.net/browse/MED-13394
                // pbxNotifyOFF.Location = new Point(548, 367);
                pbxNotifyOFF.Location = new Point(548, pbxNotifyOFF.Location.Y);
                pbxNotifyOFF.Visible = true;
                pbxNotifyON.Visible = false;
            }
        }

        private void btnNewMasterData_Click(object sender, EventArgs e)
        {
            // No master data was updated
            if (UserInfo.NewMstDataLst.Count == 0) return;

            Logs.StartWriteLog();
            Logs.WriteLog("[CHECKING FOR NEW MASTER DATA...]");

            StringBuilder sb = new StringBuilder();
            string mstType = "";

            foreach (string s in UserInfo.NewMstDataLst)
            {
                switch (s)
                {
                    case "OCS0103U00":
                    case "BAS0310U00":
                    //case "OCS0103U00":
                    //case "OCS0103U00":
                    //case "OCS0103U00":
                    case "OCS0108U00":
                        mstType = XMsg.GetMsg("M043"); // 医薬品マスターデータ
                        break;
                    case "CPL0101U00":
                        mstType = XMsg.GetMsg("M044"); // 検体検査マスターデータ
                        break;
                    default:
                        break;
                }

                if (!string.IsNullOrEmpty(mstType))
                {
                    // KCCKシステムの｛0｝が更新されました。マスターデータの更新を実行するために｛1｝の画面へ行って下さい。
                    sb.AppendLine(string.Format(XMsg.GetMsg("M041"), mstType, s));
                    mstType = "";

                    Logs.WriteLog("[NEW MASTER DATA WAS UPDATED TO]: " + s);
                }
            }

            // Has new master data?
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                // 確認
                XMessageBox.Show(sb.ToString(), XMsg.GetMsg("M042"));
            }

            Logs.EndWriteLog();
        }

        #endregion
    }

    #region ThreadWithState
    internal class ThreadWithState
    {
        #region Fields & Properties

        private string groupID = "";
        private string groupName = "";
        private string systemID = "";
        private string systemName = "";
        private string userID = "";
        private MainForm mainForm = null;
        private bool isMsgSystem = false;
        private string password = "";
        private string hospCode = "";
        private string userGroup = "";
        private string sessionId = "";
        private string doctorDrugCheck = "";
        private string checkDosage = "";
        private string checkKinki = "";
        private string checkinteraction = "";
        private string orcaIp = "";
        private string orcaUser = "";
        private string orcaPassword = "";
        //2015.24.12 added by Cloud
        private string orcaPort = "";
        private string orcaHospCode = "";
        private string orcaPortRcvClaim = "";
        // 2016.04.07 Added by Cloud
        private string usePHR = "";
        //MisaInfo
        private string misaIp = "";
        private string misaUser = "";
        private string misaPwd = "";
        private string misaDbInsurName = "";
        private string misaInstanceName = "";
        private string misaDbNonInsurName = "";
        private string changePwdFlg = "";
        private string firstLoginFlg = "";
        private string lastPwdChange = "";
        private string pwdHistory = "";
        private string currentTime = "";
        private string language = "";
        // MED-10181
        private string vpnYn = "";
        // MED-6861
        private string invUsage = "";
        private string timeZone = "";
        // https://sofiamedix.atlassian.net/browse/MED-9831
        private string userName = "";
        // https://sofiamedix.atlassian.net/browse/MED-15740
        private string cplSpecimenAuto = "";
        private string cplDevBlood = "";
        private string cplDevUrine = "";
        private string cplDevBio = "";
        private string cplServer = "";
        private string cplPort = "";
        private string cplDatabase = "";
        private string cplUserId = "";
        private string cplPassword = "";

        public string GroupId
        {
            get { return groupID; }
            set { groupID = value; }
        }
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        public string SystemId
        {
            get { return systemID; }
            set { systemID = value; }
        }
        public string SystemName
        {
            get { return systemName; }
            set { systemName = value; }
        }
        public string UserId
        {
            get { return userID; }
            set { userID = value; }
        }
        public MainForm MainForm
        {
            get { return mainForm; }
            set { mainForm = value; }
        }
        public bool IsMsgSystem
        {
            get { return isMsgSystem; }
            set { isMsgSystem = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string HospCode
        {
            get { return hospCode; }
            set { hospCode = value; }
        }
        public string UserGroup
        {
            get { return userGroup; }
            set { userGroup = value; }
        }
        public string SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        public string DoctorDrugCheck
        {
            get { return doctorDrugCheck; }
            set { doctorDrugCheck = value; }
        }
        public string CheckDosage
        {
            get { return checkDosage; }
            set { checkDosage = value; }
        }
        public string CheckKinki
        {
            get { return checkKinki; }
            set { checkKinki = value; }
        }
        public string CheckInteraction
        {
            get { return checkinteraction; }
            set { checkinteraction = value; }
        }
        public string OrcaIp
        {
            get { return orcaIp; }
            set { orcaIp = value; }
        }
        public string OrcaUser
        {
            get { return orcaUser; }
            set { orcaUser = value; }
        }
        public string OrcaPassword
        {
            get { return orcaPassword; }
            set { orcaPassword = value; }
        }
        public string OrcaPort
        {
            get { return orcaPort; }
            set { orcaPort = value; }
        }
        public string OrcaHospCode
        {
            get { return orcaHospCode; }
            set { orcaHospCode = value; }
        }
        public string OrcaPortRcvClaim
        {
            get { return orcaPortRcvClaim; }
            set { orcaPortRcvClaim = value; }
        }
        public string UsePHR
        {
            get { return usePHR; }
            set { usePHR = value; }
        }
        public string MisaIp
        {
            get { return misaIp; }
            set { misaIp = value; }
        }
        public string MisaUser
        {
            get { return misaUser; }
            set { misaUser = value; }
        }
        public string MisaPwd
        {
            get { return misaPwd; }
            set { misaPwd = value; }
        }
        public string MisaDbInsurName
        {
            get { return misaDbInsurName; }
            set { misaDbInsurName = value; }
        }
        public string MisaInstanceName
        {
            get { return misaInstanceName; }
            set { misaInstanceName = value; }
        }
        public string MisaDbNonInsurName
        {
            get { return misaDbNonInsurName; }
            set { misaDbNonInsurName = value; }
        }
        public string ChangePwdFlg
        {
            get { return changePwdFlg; }
            set { changePwdFlg = value; }
        }
        public string FirstLoginFlg
        {
            get { return firstLoginFlg; }
            set { firstLoginFlg = value; }
        }
        public string LastPwdChange
        {
            get { return lastPwdChange; }
            set { lastPwdChange = value; }
        }
        public string PwdHistory
        {
            get { return pwdHistory; }
            set { pwdHistory = value; }
        }
        public string CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; }
        }
        public string VpnYn
        {
            get { return vpnYn; }
            set { vpnYn = value; }
        }
        public string InvUsage
        {
            get { return invUsage; }
            set { invUsage = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string CplSpecimenAuto
        {
            get { return cplSpecimenAuto; }
            set { cplSpecimenAuto = value; }
        }
        public string CplDevBlood
        {
            get { return cplDevBlood; }
            set { cplDevBlood = value; }
        }
        public string CplDevUrine
        {
            get { return cplDevUrine; }
            set { cplDevUrine = value; }
        }
        public string CplDevBio
        {
            get { return cplDevBio; }
            set { cplDevBio = value; }
        }
        public string CplServer
        {
            get { return cplServer; }
            set { cplServer = value; }
        }
        public string CplPort
        {
            get { return cplPort; }
            set { cplPort = value; }
        }
        public string CplDatabase
        {
            get { return cplDatabase; }
            set { cplDatabase = value; }
        }
        public string CplUserId
        {
            get { return cplUserId; }
            set { cplUserId = value; }
        }
        public string CplPassword
        {
            get { return cplPassword; }
            set { cplPassword = value; }
        }

        #endregion

        public ThreadWithState
        (
            MainForm mainForm,
            bool isMsgSystem,
            string groupID,
            string groupName,
            string systemID,
            string systemName,
            string userID,
            string password,
            string hospCode,
            string userGroup,
            string sessionId,
            string doctorDrugCheck,
            string checkDosage,
            string checkKinki,
            string checkinteraction,
            string language,
            string orcaIp,
            string orcaUser,
            string orcaPassword,
            string orcaPort,
            string orcaHospCode,
            string orcaPortRcvClaim,
            string misaIp,
            string misaUser,
            string misaPwd,
            string misaDbInsurName,
            string misaInstanceName,
            string misaDbNonInsurName,
            string changePwdFlg,
            string firstLoginFlg,
            string lastPwdChange,
            string pwdHistory,
            string currentTime,
            string vpnYn,
            string invUsage,
            string usePHR,
            string timeZone,
            string userName,
            string cplSpecimenAuto,
            string cplDevBlood,
            string cplDevUrine,
            string cplDevBio,
            string cplServer,
            string cplPort,
            string cplDatabase,
            string cplUserId,
            string cplPassword
        )
        {
            this.mainForm = mainForm;
            this.isMsgSystem = isMsgSystem;
            this.groupID = groupID;
            this.groupName = groupName;
            this.systemID = systemID;
            this.systemName = systemName;
            this.userID = userID;
            this.password = password;
            this.hospCode = hospCode;
            this.userGroup = userGroup;
            this.sessionId = sessionId;
            this.doctorDrugCheck = doctorDrugCheck;
            this.checkDosage = checkDosage;
            this.checkKinki = checkKinki;
            this.checkinteraction = checkinteraction;
            this.language = language;
            this.orcaIp = orcaIp;
            this.orcaUser = orcaUser;
            this.orcaPassword = orcaPassword;
            this.orcaPort = orcaPort;
            this.orcaHospCode = orcaHospCode;
            this.orcaPortRcvClaim = orcaPortRcvClaim;
            this.misaIp = misaIp;
            this.misaUser = misaUser;
            this.misaPwd = misaPwd;
            this.misaDbInsurName = misaDbInsurName;
            this.misaInstanceName = misaInstanceName;
            this.misaDbNonInsurName = misaDbNonInsurName;
            this.changePwdFlg = changePwdFlg;
            this.firstLoginFlg = firstLoginFlg;
            this.lastPwdChange = lastPwdChange;
            this.pwdHistory = pwdHistory;
            this.currentTime = currentTime;
            this.vpnYn = vpnYn;
            this.invUsage = invUsage;
            this.usePHR = usePHR;
            this.timeZone = timeZone;
            this.userName = userName;
            this.cplSpecimenAuto = cplSpecimenAuto;
            this.cplDevBlood = cplDevBlood;
            this.cplDevUrine = cplDevUrine;
            this.cplDevBio = cplDevBio;
            this.cplServer = cplServer;
            this.cplPort = cplPort;
            this.cplDatabase = cplDatabase;
            this.cplUserId = cplUserId;
            this.cplPassword = cplPassword;
        }

        public void OpenSystem()
        {
            /*AppDomain domain = AppDomain.CreateDomain(systemID);*/
            // Change for Click Once
            PermissionSet permSet = new PermissionSet(PermissionState.Unrestricted);
            AppDomainSetup ads = new AppDomainSetup();
            ads.ApplicationBase = Application.StartupPath;
            AppDomain domain = AppDomain.CreateDomain(systemID, AppDomain.CurrentDomain.Evidence, ads, permSet, null);
            try
            {
                //Arguments : GroupID + GroupName + SystemID + SystemName + UserID
                //string[] args = { groupID, groupName, systemID, systemName, userID };
                string[] args =
                    {
                        groupID,            // 1
                        groupName,          // 2
                        systemID,           // 3
                        systemName,         // 4
                        userID,             // 5
                        password,           // 6
                        hospCode,           // 7
                        userGroup,          // 8
                        sessionId,          // 9
                        doctorDrugCheck,    // 10
                        checkDosage,        // 11
                        checkKinki,         // 12
                        checkinteraction,   // 13
                        language,           // 14
                        orcaIp,             // 15
                        orcaUser,           // 16
                        orcaPassword,       // 17
                        orcaPort          , // 18
                        orcaHospCode      , // 19
                        orcaPortRcvClaim  , // 20
                        misaIp            , // 21
                        misaUser          , // 22
                        misaPwd           , // 23
                        misaDbInsurName   , // 24
                        misaInstanceName  , // 25
                        misaDbNonInsurName, // 26
                        changePwdFlg      , // 27
                        firstLoginFlg     , // 28
                        lastPwdChange     , // 29
                        pwdHistory        , // 30
                        currentTime       , // 31
                        // MED-10181
                        vpnYn,              // 32
                        // MED-6861
                        invUsage          , // 33
                        usePHR,             // 34
                        timeZone,           // 35
                        userName,           // 36
                        // https://sofiamedix.atlassian.net/browse/MED-15740
                        cplSpecimenAuto,    // 37
                        cplDevBlood,        // 38
                        cplDevUrine,        // 39
                        cplDevBio,          // 40
                        cplServer,          // 41
                        cplPort,            // 42
                        cplDatabase,        // 43
                        cplUserId,          // 44
                        cplPassword,        // 45
                    };
                string basePath = Application.StartupPath;
                //해당 업무 exe는 IHIS\업무시스템ID\업무시스템ID.exe로 관리된다.
                string asmName = basePath + "\\" + systemID + "\\" + systemID + ".exe";

                //사용중인 메세지시스템 LISTVIEW에 Add
                if (this.isMsgSystem)
                    mainForm.AddOpenMsgSystemList(systemID);
                else //사용중인 시스템 ListView에 Add
                    mainForm.AddOpenSystemList(systemID);
                try
                {
                    domain.ExecuteAssembly(asmName, null, args);
                }
                catch (Exception xe)
                {
                    Logs.WriteLog("Main", "ThreadWithState::OpenSystem ExecuteAssembly sysID=" + systemID + ",sysName=" + systemName + ",Error=" + xe.Message);
                    Logs.WriteLog("Main", "ThreadWithState::OpenSystem ExecuteAssembly StackTrace=" + xe.StackTrace);

                    //종료시 SystemHandle의 List Remove
                    SystemHandleManager.RemoveHandleList(domain.FriendlyName);

                    if (this.isMsgSystem) //사용중인 메세지시스템 LISTVIEW에서 제거
                        mainForm.RemoveOpenMsgSystemList(domain.FriendlyName);
                    else
                        mainForm.RemoveOpenSystemList(domain.FriendlyName);
                    return;
                }

                //종료시 SystemHandle의 List Remove
                SystemHandleManager.RemoveHandleList(domain.FriendlyName);

                if (this.isMsgSystem) //사용중인 메세지시스템 LISTVIEW에서 제거
                    mainForm.RemoveOpenMsgSystemList(domain.FriendlyName);
                else
                    mainForm.RemoveOpenSystemList(domain.FriendlyName);

                //Argument전달시 Application.Run을 함으로 업무시스템 종료까지는 Return 없음
                //업무시스템 종료시 아래와 같이 해당 Domain Upload
                AppDomain.Unload(domain);
            }
            catch (Exception e)
            {
                //XMessageBox.Show("OpenSystem, Domain.FriendlyName=" + domain.FriendlyName.ToString());
                Logs.WriteLog("Main", "ThreadWithState::OpenSystem sysID=" + systemID + ",sysName=" + systemName + ",Error=" + e.Message);
                Logs.WriteLog("Main", "ThreadWithState::OpenSystem StackTrace=" + e.StackTrace);
                Debug.WriteLine("OpenSystem, Exception=" + e.Message);
            }
        }
    }
    #endregion

    #region TickTockForm (잠깐 보였다 사라지는 Form)
    /// <summary>
    /// TickTockForm에 대한 요약 설명입니다.
    /// </summary>
    internal class TickTockForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        public TickTockForm()
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTemp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTemp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormTemp";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

        }
        #endregion

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
    #endregion
}
