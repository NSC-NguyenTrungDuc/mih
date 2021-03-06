#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using IHIS.ADMA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.ADMA
{
    /// <summary>
    /// ADM401U에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class ADM401U : IHIS.Framework.XScreen
    {
        #region Fields
        private string serverIP = "222.106.127.66";
        const string USER_ID = "ihisdown";
        const string USER_PSWD = "ihisdown";
        const string MSG_TITLE = "파일 전송";
        private TreeNode curNode;
        private XFTPWorker ftpWorker = null;
        private DirectoryInfo dirInfo;
        private ArrayList sendFileList = new ArrayList();
        private string currGrpID = "";
        private string currSysID = "";
        private string serverPath = "";
        private ListViewColumnSorter columnSorter = new ListViewColumnSorter();
        #endregion

        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XGridCell xGridCell3;
        private IHIS.Framework.XGridCell xGridCell4;
        private IHIS.Framework.XGroupBox gbxType;
        private IHIS.Framework.XRadioButton rbBGL;
        private IHIS.Framework.XRadioButton rbBSL;
        private IHIS.Framework.XRadioButton rbBSA;
        private IHIS.Framework.XMstGrid grdGrp;
        private IHIS.Framework.XGrid grdSys;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDisplayBox dbxGrp;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDisplayBox dbxSys;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private System.Windows.Forms.TreeView tvwDir;
        private System.Windows.Forms.ListView lvwFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private IHIS.Framework.XButton btnConnect;
        private IHIS.Framework.XButton btnUpload;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private IHIS.Framework.XGridCell xGridCell1;
        private IHIS.Framework.XGridCell xGridCell2;
        private IHIS.Framework.XRadioButton xRadioButton1;
        private IHIS.Framework.XRadioButton xRadioButton2;
        private System.ComponentModel.IContainer components = null;

        public ADM401U()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //lvwFile의 ListViewItemSorter  Set
            this.lvwFile.ListViewItemSorter = this.columnSorter;

            this.grdSys.ParamList = CreateGrdSysParamList();
            this.grdSys.ExecuteQuery = LoadGrdSys;
            this.grdGrp.ExecuteQuery = LoadGrdGrp;
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

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM401U));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.btnUpload = new IHIS.Framework.XButton();
            this.btnConnect = new IHIS.Framework.XButton();
            this.dbxSys = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxGrp = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.gbxType = new IHIS.Framework.XGroupBox();
            this.xRadioButton2 = new IHIS.Framework.XRadioButton();
            this.xRadioButton1 = new IHIS.Framework.XRadioButton();
            this.rbBSA = new IHIS.Framework.XRadioButton();
            this.rbBSL = new IHIS.Framework.XRadioButton();
            this.rbBGL = new IHIS.Framework.XRadioButton();
            this.grdSys = new IHIS.Framework.XGrid();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.grdGrp = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.lvwFile = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tvwDir = new System.Windows.Forms.TreeView();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop.SuspendLayout();
            this.gbxType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrp)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.btnUpload);
            this.pnlTop.Controls.Add(this.btnConnect);
            this.pnlTop.Controls.Add(this.dbxSys);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.dbxGrp);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.gbxType);
            this.pnlTop.Controls.Add(this.grdSys);
            this.pnlTop.Controls.Add(this.grdGrp);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // btnUpload
            // 
            this.btnUpload.AccessibleDescription = null;
            this.btnUpload.AccessibleName = null;
            resources.ApplyResources(this.btnUpload, "btnUpload");
            this.btnUpload.BackgroundImage = null;
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleDescription = null;
            this.btnConnect.AccessibleName = null;
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.BackgroundImage = null;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // dbxSys
            // 
            this.dbxSys.AccessibleDescription = null;
            this.dbxSys.AccessibleName = null;
            resources.ApplyResources(this.dbxSys, "dbxSys");
            this.dbxSys.Image = null;
            this.dbxSys.Name = "dbxSys";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dbxGrp
            // 
            this.dbxGrp.AccessibleDescription = null;
            this.dbxGrp.AccessibleName = null;
            resources.ApplyResources(this.dbxGrp, "dbxGrp");
            this.dbxGrp.Image = null;
            this.dbxGrp.Name = "dbxGrp";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // gbxType
            // 
            this.gbxType.AccessibleDescription = null;
            this.gbxType.AccessibleName = null;
            resources.ApplyResources(this.gbxType, "gbxType");
            this.gbxType.BackgroundImage = null;
            this.gbxType.Controls.Add(this.xRadioButton2);
            this.gbxType.Controls.Add(this.xRadioButton1);
            this.gbxType.Controls.Add(this.rbBSA);
            this.gbxType.Controls.Add(this.rbBSL);
            this.gbxType.Controls.Add(this.rbBGL);
            this.gbxType.Name = "gbxType";
            this.gbxType.TabStop = false;
            // 
            // xRadioButton2
            // 
            this.xRadioButton2.AccessibleDescription = null;
            this.xRadioButton2.AccessibleName = null;
            resources.ApplyResources(this.xRadioButton2, "xRadioButton2");
            this.xRadioButton2.BackgroundImage = null;
            this.xRadioButton2.CheckedValue = "FWL";
            this.xRadioButton2.Name = "xRadioButton2";
            this.xRadioButton2.UseVisualStyleBackColor = false;
            // 
            // xRadioButton1
            // 
            this.xRadioButton1.AccessibleDescription = null;
            this.xRadioButton1.AccessibleName = null;
            resources.ApplyResources(this.xRadioButton1, "xRadioButton1");
            this.xRadioButton1.BackgroundImage = null;
            this.xRadioButton1.CheckedValue = "BSM";
            this.xRadioButton1.Name = "xRadioButton1";
            this.xRadioButton1.UseVisualStyleBackColor = false;
            // 
            // rbBSA
            // 
            this.rbBSA.AccessibleDescription = null;
            this.rbBSA.AccessibleName = null;
            resources.ApplyResources(this.rbBSA, "rbBSA");
            this.rbBSA.BackgroundImage = null;
            this.rbBSA.Checked = true;
            this.rbBSA.CheckedValue = "BSA";
            this.rbBSA.Name = "rbBSA";
            this.rbBSA.TabStop = true;
            this.rbBSA.UseVisualStyleBackColor = false;
            // 
            // rbBSL
            // 
            this.rbBSL.AccessibleDescription = null;
            this.rbBSL.AccessibleName = null;
            resources.ApplyResources(this.rbBSL, "rbBSL");
            this.rbBSL.BackgroundImage = null;
            this.rbBSL.CheckedValue = "BSL";
            this.rbBSL.Name = "rbBSL";
            this.rbBSL.UseVisualStyleBackColor = false;
            // 
            // rbBGL
            // 
            this.rbBGL.AccessibleDescription = null;
            this.rbBGL.AccessibleName = null;
            resources.ApplyResources(this.rbBGL, "rbBGL");
            this.rbBGL.BackgroundImage = null;
            this.rbBGL.CheckedValue = "BGL";
            this.rbBGL.Name = "rbBGL";
            this.rbBGL.UseVisualStyleBackColor = false;
            // 
            // grdSys
            // 
            resources.ApplyResources(this.grdSys, "grdSys");
            this.grdSys.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell1,
            this.xGridCell2});
            this.grdSys.ColPerLine = 4;
            this.grdSys.Cols = 4;
            this.grdSys.ExecuteQuery = null;
            this.grdSys.FixedRows = 1;
            this.grdSys.HeaderHeights.Add(21);
            this.grdSys.MasterLayout = this.grdGrp;
            this.grdSys.Name = "grdSys";
            this.grdSys.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSys.ParamList")));
            this.grdSys.QuerySQL = "SELECT SYS_ID, SYS_NM, NVL(ADM_SYS_YN,\'N\'), NVL(MSG_SYS_YN,\'N\')\r\n  FROM ADM0200\r\n" +
                " WHERE GRP_ID = :f_grp_id\r\n ORDER BY SYS_ID";
            this.grdSys.Rows = 2;
            this.grdSys.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSys_QueryStarting);
            this.grdSys.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdSys_RowFocusChanged);
            // 
            // xGridCell3
            // 
            this.xGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xGridCell3.CellName = "sysID";
            this.xGridCell3.CellWidth = 81;
            this.xGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            this.xGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell4
            // 
            this.xGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xGridCell4.CellName = "sysNm";
            this.xGridCell4.CellWidth = 151;
            this.xGridCell4.Col = 1;
            this.xGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xGridCell1
            // 
            this.xGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xGridCell1.CellName = "adminYn";
            this.xGridCell1.CellWidth = 40;
            this.xGridCell1.Col = 2;
            this.xGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xGridCell2.CellName = "msgSysYn";
            this.xGridCell2.CellWidth = 40;
            this.xGridCell2.Col = 3;
            this.xGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdGrp
            // 
            resources.ApplyResources(this.grdGrp, "grdGrp");
            this.grdGrp.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdGrp.ColPerLine = 2;
            this.grdGrp.Cols = 2;
            this.grdGrp.ExecuteQuery = null;
            this.grdGrp.FixedRows = 1;
            this.grdGrp.HeaderHeights.Add(21);
            this.grdGrp.Name = "grdGrp";
            this.grdGrp.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGrp.ParamList")));
            this.grdGrp.QuerySQL = "SELECT GRP_ID, GRP_NM\r\n  FROM ADM0100\r\n ORDER BY 1";
            this.grdGrp.ReadOnly = true;
            this.grdGrp.Rows = 2;
            this.grdGrp.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdGrp_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "grpID";
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "grpNm";
            this.xEditGridCell2.CellWidth = 124;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.lvwFile);
            this.pnlFill.Controls.Add(this.tvwDir);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // lvwFile
            // 
            this.lvwFile.AccessibleDescription = null;
            this.lvwFile.AccessibleName = null;
            resources.ApplyResources(this.lvwFile, "lvwFile");
            this.lvwFile.BackgroundImage = null;
            this.lvwFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.lvwFile.Font = null;
            this.lvwFile.FullRowSelect = true;
            this.lvwFile.LargeImageList = this.ImageList;
            this.lvwFile.Name = "lvwFile";
            this.lvwFile.SmallImageList = this.ImageList;
            this.lvwFile.UseCompatibleStateImageBehavior = false;
            this.lvwFile.View = System.Windows.Forms.View.Details;
            this.lvwFile.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwFile_ColumnClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // tvwDir
            // 
            this.tvwDir.AccessibleDescription = null;
            this.tvwDir.AccessibleName = null;
            resources.ApplyResources(this.tvwDir, "tvwDir");
            this.tvwDir.BackgroundImage = null;
            this.tvwDir.Font = null;
            this.tvwDir.ImageList = this.ImageList;
            this.tvwDir.Name = "tvwDir";
            this.tvwDir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwDir_BeforeExpand);
            this.tvwDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDir_AfterSelect);
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // ADM401U
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "ADM401U";
            this.pnlTop.ResumeLayout(false);
            this.gbxType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrp)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //그룹리스트 조회
            this.grdGrp.QueryLayout(true);

            //ClientDir Set
            //Client Dir 구조 생성
            string[] drives = Directory.GetLogicalDrives();
            DirectoryNode cRoot;
            //A Driver는 제외
            foreach (string drive in drives)
            {
                if (drive != @"A:\")
                {
                    cRoot = new DirectoryNode(drive);
                    tvwDir.Nodes.Add(cRoot);
                    AddDirectories(cRoot);
                }
            }

            //다운로드 서버 IP SET
            this.serverIP = EnvironInfo.GetDownloadServerIP();
        }
        #endregion

        #region Private Method
        private void AddDirectories(TreeNode node)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(GetPathFromNode(node));
                DirectoryInfo[] e = dir.GetDirectories();

                for (int i = 0; i < e.Length; i++)
                {
                    string name = e[i].Name;
                    if (!name.Equals(".") && !name.Equals(".."))
                    {
                        node.Nodes.Add(new DirectoryNode(name, 0, 1));
                    }
                }
            }
            catch { }
        }
        private void PopulateClient()
        {
            lvwFile.Items.Clear();
            dirInfo = new DirectoryInfo(dirInfo.FullName);
            ListViewItem lvItem = null;
            //파일만 lvFile에 관리
            foreach (FileSystemInfo fsi in dirInfo.GetFileSystemInfos())
            {
                if (fsi is FileInfo)
                {
                    FileInfo f = (FileInfo)fsi;
                    lvItem = new ListViewItem(new string[]{f.Name
														   ,Math.Ceiling((double)(f.Length / 1024)).ToString()+ "KB"
														   ,f.Extension
														   ,f.LastWriteTime.ToString()
														   //,f.LastAccessTime.ToString()
														   //,f.CreationTime.ToString()
														  }, 2);
                    //Tag에 File인지 Dir인지 보관
                    lvItem.Tag = true;
                    lvwFile.Items.Add(lvItem);
                }
            }
        }
        private string GetPathFromNode(TreeNode node)
        {
            if (node.Parent == null)
            {
                return node.Text;
            }
            return Path.Combine(GetPathFromNode(node.Parent), node.Text);
        }
        private void SetCurrentDir(string currDir)
        {
            Directory.SetCurrentDirectory(currDir);
        }
        private void AddSubDirectories(DirectoryNode node)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                AddDirectories(node.Nodes[i]);
            }
            node.SubDirectoriesAdded = true;
        }
        private Version GetFileVersion(string fileName)
        {
            // Version 확인
            FileVersionInfo fileVersionInfo;
            try
            {
                fileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
            }
            catch
            {
                return null;
            }
            Version fileVersion = new Version(fileVersionInfo.FileMajorPart, fileVersionInfo.FileMinorPart, fileVersionInfo.FileBuildPart, fileVersionInfo.FilePrivatePart);

            //Version정보가 없는 파일도 FileVersionInfo를 가져옴 0.0.0.0 따라서 ,0.0.0.0과 비교
            if (fileVersion.ToString() == "0.0.0.0")
                return null;

            return fileVersion;
        }
        private bool UpdateAsmVersion(SendFileItem item)
        {
            /* 1.ADM0400에 해당 어셈블리명의 데이타 존재여부 확인
             * 2.기 등록된 내역이 있으면 어셈블리Type, BGL은 그룹 Check, BSL,BSM은 시스템 Check
             *   (기등록된 내역과 정보를 다르게 지정했는지 여부 확인)
             * 3.버전이 있는 어셈블리는 해당 버전을, 없으면 기존버전 + 1로 UPDATE
             *   기 등록된 내역이 있으면 UPDATE, 없으면 INSERT
             */
            string asmType = gbxType.GetDataValue(); //선택된 어셈블리 TYPE
            bool isExistData = true; //기존 데이타 존재여부
            /*string cmdText
            = "SELECT ASM_TYPE, NVL(GRP_ID,'X'), NVL(SYS_ID,'X') FROM ADM0400 WHERE ASM_NAME = :f_asm_name";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_asm_name", item.FileName);
            DataTable table = Service.ExecuteDataTable(cmdText, bindVars);
            if ((table == null) || (table.Rows.Count < 1))
            {
                isExistData = false;
            }*/
            ADM401UAsmArgs asmArgs = new ADM401UAsmArgs();
            asmArgs.AsmName = item.FileName;
            ADM401UAsmResult asmResult = CloudService.Instance.Submit<ADM401UAsmResult, ADM401UAsmArgs>(asmArgs);

            //기존 데이타 존재
            if (asmResult.ExecutionStatus == ExecutionStatus.Success && asmResult.AsmItemInfo != null &&
                asmResult.AsmItemInfo.Count > 0)
            {
                string origAsmType = asmResult.AsmItemInfo[0].AsmType;
                string origGrpID = asmResult.AsmItemInfo[0].GrpId;
                string origSysID = asmResult.AsmItemInfo[0].SysId;
                //ASM_TYPE, GRP_ID, SYS_ID 일치여부 확인
                if (asmType != origAsmType)
                {
                    XMessageBox.Show(
                        Resources.MSG_001_1 + item.FileName + Resources.MSG_001_2 + origAsmType + Resources.MSG_001_3 +
                        asmType + Resources.MSG_001_4, MSG_TITLE);
                    return false;
                }
                //그룹 Lib는 그립 일치여부 확인
                if ((asmType == "BGL") && (origGrpID != this.currGrpID))
                {
                    XMessageBox.Show(
                        Resources.MSG_002_1 + item.FileName + Resources.MSG_002_2 + origGrpID + Resources.MSG_002_3 +
                        this.currGrpID + Resources.MSG_002_4, MSG_TITLE);
                    return false;
                }
                else if (((asmType == "BSL") || (asmType == "BSM") || (asmType == "BSA")) &&
                         (origSysID != this.currSysID))
                {
                    XMessageBox.Show(
                        Resources.MSG_003_1 + item.FileName + Resources.MSG_003_2 + origSysID + Resources.MSG_003_3 +
                        this.currSysID + Resources.MSG_003_4, MSG_TITLE);
                    return false;
                }
            }
            else
            {
                isExistData = false;
            }

            //BindVar SET
            /*bindVars.Clear();
            bindVars.Add("f_asm_name", item.FileName);
            bindVars.Add("f_asm_type", asmType);
            bindVars.Add("f_grp_id", (asmType == "FWL" ? "" : this.currGrpID));
            bindVars.Add("f_sys_id", (asmType == "FWL" ? "" : this.currSysID));
            bindVars.Add("f_asm_ver", item.FileVersion);
            bindVars.Add("f_asm_path", this.serverPath);
            bindVars.Add("f_user_id", UserInfo.UserID);*/
            //SQL문 작성

            UpdateResult result;
            if (isExistData) //UPDATE
            {
                ADM401UUpdateArgs updateArgs = new ADM401UUpdateArgs();
                updateArgs.HasVersion = item.HasVersion;
                updateArgs.AsmVer = item.FileVersion;
                updateArgs.AsmName = item.FileName;
                result = CloudService.Instance.Submit<UpdateResult, ADM401UUpdateArgs>(updateArgs);
                /*if (item.HasVersion) //Version이 있으면 -> 해당 Version SET
                {
                    cmdText
                        = "UPDATE ADM0400"
                        + "   SET ASM_VER = :f_asm_ver"
                        + "      ,ASM_ESS_VER = :f_asm_ver"
                        + " WHERE ASM_NAME = :f_asm_name";

                }
                else //Version이 없으면 -> 기존 Version + 1
                {
                    cmdText
                        = "UPDATE ADM0400"
                        + "   SET ASM_VER = TO_NUMBER(ASM_VER) + 1"
                        + "      ,ASM_ESS_VER = TO_NUMBER(ASM_VER) + 1"
                        + " WHERE ASM_NAME = :f_asm_name";
                }*/
            }
            else //INSERT
            {
                ADM401UInsertArgs insertArgs = new ADM401UInsertArgs();
                insertArgs.HasVersion = item.HasVersion;
                insertArgs.AsmName = item.FileName;
                insertArgs.AsmType = asmType;
                insertArgs.GrpId = (asmType == "FWL" ? "" : this.currGrpID);
                insertArgs.SysId = (asmType == "FWL" ? "" : this.currSysID);
                insertArgs.AsmVer = item.FileVersion;
                insertArgs.AsmPath = this.serverPath;
                insertArgs.UserId = UserInfo.UserID;
                result = CloudService.Instance.Submit<UpdateResult, ADM401UInsertArgs>(insertArgs);
                /*if (item.HasVersion) //Version이 있으면 -> 해당 Version SET
                {
                    cmdText
                        = "INSERT INTO ADM0400"
                        + " (ASM_NAME, ASM_TYPE, GRP_ID, SYS_ID, ASM_VER, ASM_ESS_VER, ASM_PATH, CR_MEMB, CR_TIME)"
                        + " VALUES"
                        + " (:f_asm_name, :f_asm_type, :f_grp_id, :f_sys_id, :f_asm_ver, :f_asm_ver, :f_asm_path, :f_user_id, SYSDATE)";
                }
                else //Version이 없으면 -> Version = 1
                {
                    cmdText
                        = "INSERT INTO ADM0400"
                        + " (ASM_NAME, ASM_TYPE, GRP_ID, SYS_ID, ASM_VER, ASM_ESS_VER, ASM_PATH, CR_MEMB, CR_TIME)"
                        + " VALUES"
                        + " (:f_asm_name, :f_asm_type, :f_grp_id, :f_sys_id, '1', '1', :f_asm_path, :f_user_id, SYSDATE)";
                }*/
            }

            if (result.ExecutionStatus != ExecutionStatus.Success)
            {
                XMessageBox.Show(Resources.MSG_004_1 + item.FileName + Resources.MSG_004_2 + Service.ErrMsg + Resources.MSG_004_3, MSG_TITLE);
                return false;
            }
            return true;
        }
        #endregion

        #region Event
        private void grdGrp_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //현재그룹 설정, 그룹에 속하는 시스템 조회
            if (e.CurrentRow >= 0)
            {
                this.currGrpID = grdGrp.GetItemValue(e.CurrentRow, "grpID").ToString();
                this.dbxGrp.SetDataValue(currGrpID + " " + grdGrp.GetItemValue(e.CurrentRow, "grpNm").ToString());
            }
        }

        private void grdSys_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //현재시스템 ID 설정
            if (e.CurrentRow >= 0)
            {
                this.currSysID = grdSys.GetItemValue(e.CurrentRow, "sysID").ToString();
                this.dbxSys.SetDataValue(currSysID + " " + grdSys.GetItemValue(e.CurrentRow, "sysNm").ToString());
            }
        }
        #endregion

        private void tvwDir_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                dirInfo = new DirectoryInfo(e.Node.FullPath);
                SetCurrentDir(dirInfo.FullName);
                curNode = e.Node;
                PopulateClient();
            }
            catch (Exception xe)
            {
                Debug.WriteLine("tvwDir_AfterSelect Error=" + xe.Message);
            }
        }

        private void tvwDir_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            DirectoryNode nodeExpanding = (DirectoryNode)e.Node;
            if (!nodeExpanding.SubDirectoriesAdded)
                AddSubDirectories(nodeExpanding);
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            if (this.ftpWorker == null)
            {
                this.ftpWorker = new XFTPWorker(USER_ID, USER_PSWD, this.serverIP);
            }
            else if (!this.ftpWorker.Connected)
            {
                this.ftpWorker = new XFTPWorker(USER_ID, USER_PSWD, this.serverIP);
            }
            if (this.ftpWorker.Connected)
                this.btnUpload.Enabled = true;
            else
                this.btnUpload.Enabled = false;
        }
        private void btnUpload_Click(object sender, System.EventArgs e)
        {
            /* Upload 전 확인사항
             * 1.FTP 연결여부
             * 2.파일 선택여부 확인
             * 3.FWL외에는 현재 그룹, 업무시스템 선택여부 확인
             * 4.FWL은 IHIS.로 시작하는 dll과 ocx, exe, 등을 올릴 수 있음
             * 5.BGL는 업무그룹 선택, 그룹ID.LIb.Name.dll 형식이어야 함.(jrf 파일 명칭은 추후 고려)
             * 6.BSL는 업무시스템선택, 시스템ID.Lib.Name.dll 형식이어야 함((jrf 파일 명칭은 추후 고려)
             * 7.BSA는 프로그램ID.dll형식이어야 함. (Upload성공시 프로그램 Table에 어셈블리명 Set
             * 8.Upload성공시 어셈블리 Table에 Version Update(한 건식 처리하는 것이 타당함)
             * 8.jrf 파일, 그외 버전이 없는 파일을 어떻게 관리할 것인지는 추후 확정하여 반영
             * 9.업무시스템에서만 쓰는 OCX의 경우 FWL로 할 것인지, BGL,BSL로 할 것인지는 차후 확정필요
             */

            //기존 전송 파일 리스트 Clear
            this.sendFileList.Clear();
            this.serverPath = "";

            string asmType = this.gbxType.GetDataValue();
            if (!ftpWorker.Connected)
            {
                XMessageBox.Show(Resources.MSG_005, MSG_TITLE);
                return;
            }
            if (this.lvwFile.SelectedItems.Count < 1)
            {
                XMessageBox.Show(Resources.MSG_006, MSG_TITLE);
                return;
            }
            if ((asmType == "BGL") && (this.currGrpID == ""))
            {
                XMessageBox.Show(Resources.MSG_007, MSG_TITLE);
                return;
            }
            else if ((asmType == "BSL") && (this.currSysID == ""))
            {
                XMessageBox.Show(Resources.MSG_008, MSG_TITLE);
                return;
            }
            else if ((asmType == "BSA") && (this.currSysID == ""))
            {
                XMessageBox.Show(Resources.MSG_008, MSG_TITLE);
                return;
            }
            //버전이 없는 파일은 전송 불가
            Version version = null;
            string fileName = "";
            string keyName = "";
            string rootServerDir = ftpWorker.GetCurrentDir();
            string fullPath = Directory.GetCurrentDirectory() + "\\";
            foreach (ListViewItem lvItem in this.lvwFile.SelectedItems)
            {
                fileName = lvItem.Text;
                switch (asmType)
                {
                    case "BGL":
                        keyName = this.currGrpID + ".Lib.";
                        if (fileName.ToLower().IndexOf(keyName.ToLower()) < 0)
                        {
                            XMessageBox.Show(Resources.MSG_009_1 + keyName + Resources.MSG_009_2, MSG_TITLE);
                            return;
                        }
                        break;
                    case "BSL":
                        keyName = this.currSysID + ".Lib.";
                        if (fileName.ToLower().IndexOf(keyName.ToLower()) < 0)
                        {
                            XMessageBox.Show(Resources.MSG_009_1 + keyName + Resources.MSG_009_2, MSG_TITLE);
                            return;
                        }
                        break;
                    case "BSM":
                        keyName = this.currSysID + ".exe";
                        if (fileName.ToLower().IndexOf(keyName.ToLower()) < 0)
                        {
                            XMessageBox.Show(Resources.MSG_009_1 + keyName + Resources.MSG_009_3, MSG_TITLE);
                            return;
                        }
                        break;
                    case "BSA":
                        keyName = this.currSysID;
                        if (fileName.ToLower().IndexOf(keyName.ToLower()) < 0)
                        {
                            XMessageBox.Show(Resources.MSG_009_1 + keyName + Resources.MSG_009_2, MSG_TITLE);
                            return;
                        }
                        break;
                }
                version = null;
                version = GetFileVersion(fullPath + fileName);
                //Version이 없는 파일은 jrf만 가능함(현재기준, 앞으로 추가처리함)
                //2005.09.14 pbd File 도 포함
                //2007.01.04 FWL일 경우는 환경파일등 버전이 없는 파일도 Upload 가능
                if (version == null)
                {
                    if (asmType != "FWL")
                    {
                        if ((fileName.IndexOf(".jrf") < 0) && (fileName.IndexOf(".pbd") < 0))
                        {
                            XMessageBox.Show(Resources.MSG_010_1 + fileName + Resources.MSG_010_2, MSG_TITLE);
                            return;
                        }
                    }
                    //전송파일리스트에 SendFileItem을 생성하여 Add(Version은 없음,  Server에서 +1)
                    this.sendFileList.Add(new SendFileItem(fileName, false, "1"));
                }
                else
                {
                    //전송파일리스트에 SendFileItem을 생성하여 Add
                    this.sendFileList.Add(new SendFileItem(fileName, true, version.ToString()));
                }
            }

            //FWL은 bin으로 이동, BGL은 그룹으로 이동, BSL은 그룹/시스템으로 이동
            //BSA는 그룹/시스템/BSA로 이동
            if (asmType == "FWL")
            {
                serverPath = "BIN";
                if (!ftpWorker.ChangeDir(serverPath))
                {
                    ftpWorker.MakeDir(this.currGrpID);
                    ftpWorker.ChangeDir(this.currGrpID);
                }
            }
            else if (asmType == "BGL")
            {
                serverPath = this.currGrpID;
                if (!ftpWorker.ChangeDir(serverPath))
                {
                    //서버에 그룹 DIR 만들기
                    if (!ftpWorker.ChangeDir(this.currGrpID))
                    {
                        ftpWorker.MakeDir(this.currGrpID);
                        ftpWorker.ChangeDir(this.currGrpID);
                    }
                }
            }
            else if ((asmType == "BSL") || (asmType == "BSM"))
            {
                serverPath = this.currGrpID + "/" + this.currSysID;
                if (!ftpWorker.ChangeDir(serverPath))
                {
                    //서버에 그룹 DIR 만들기
                    if (!ftpWorker.ChangeDir(this.currGrpID))
                    {
                        ftpWorker.MakeDir(this.currGrpID);
                        ftpWorker.ChangeDir(this.currGrpID);
                    }

                    // 서버에 시스템 dir만들기
                    if (!ftpWorker.ChangeDir(this.currSysID))
                    {
                        ftpWorker.MakeDir(this.currSysID);
                        ftpWorker.ChangeDir(this.currSysID);
                    }
                }
            }
            else if (asmType == "BSA") //그룹ID/시스템ID
            {
                serverPath = this.currGrpID + "/" + this.currSysID + "/BSA";
                //serverPath = this.currGrpID + "/" + this.currSysID;
                if (!ftpWorker.ChangeDir(serverPath))
                {
                    //서버에 그룹 DIR 만들기
                    if (!ftpWorker.ChangeDir(this.currGrpID))
                    {
                        ftpWorker.MakeDir(this.currGrpID);
                        ftpWorker.ChangeDir(this.currGrpID);
                    }
                    
                    // 서버에 시스템 dir만들기
                    if (!ftpWorker.ChangeDir(this.currSysID))
                    {
                        ftpWorker.MakeDir(this.currSysID);
                        ftpWorker.ChangeDir(this.currSysID);
                    }

                    // BSA Dir 만들기
                    if (!ftpWorker.ChangeDir("BSA"))
                    {
                        ftpWorker.MakeDir("BSA");
                        ftpWorker.ChangeDir("BSA");
                    }
                }
            }

            string msg = Resources.MSG_011;
            if (XMessageBox.Show(msg, MSG_TITLE, MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                //Root 로 이동
                ftpWorker.ChangeDir(rootServerDir);
                return;
            }

            bool isError = false;
            //선택된 리스트 파일전송
            //1건씩 전송후 DB에 바로 Update, DB Update 실패시 에러메세지를 보내고 return
            foreach (SendFileItem sItem in this.sendFileList)
            {
                //성공시
                if (ftpWorker.SendFileToServer(sItem.FileName, sItem.FileName))
                {
                    //저장실패시 Break;
                    if (!UpdateAsmVersion(sItem))
                    {
                        isError = true;
                        break;
                    }
                }
                else  //전송실패시 Break;
                {
                    isError = true;
                    XMessageBox.Show(Resources.MSG_012_1 + this.serverIP + Resources.MSG_012_2 + sItem.FileName + Resources.MSG_012_3, MSG_TITLE);
                    break;
                }
            }
            //전송완료후 ROOT 로 이동
            ftpWorker.ChangeDir(rootServerDir);

            if (!isError)
                XMessageBox.Show(Resources.MSG_013, MSG_TITLE);
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            if (e.Func == FunctionType.Update)
            {
                //this.dsvSave1.Call();
                e.IsBaseCall = false;
            }
        }

        #region 컬럼 Click시에 Sort
        private void lvwFile_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //열머리글 Click시에 Sort 적용 (이름,종류, 변경일만 Sort 적용)
            if ((e.Column == 0) || (e.Column == 2) || (e.Column == 3))
            {
                if (e.Column == columnSorter.SortColumnIndex)  //같은 Header Click
                {
                    if (columnSorter.OrderOfSort == SortOrder.Ascending) //ASC -> DESC
                        columnSorter.OrderOfSort = SortOrder.Descending;
                    else
                        columnSorter.OrderOfSort = SortOrder.Ascending;
                }
                else
                {
                    columnSorter.SortColumnIndex = e.Column;
                    columnSorter.OrderOfSort = SortOrder.Ascending;
                }
                //Sort
                this.lvwFile.Sort();
            }
        }
        #endregion

        private void grdSys_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //f_grp_id BIND 변수 SET (현재 Group ID로 SET)
            grdSys.SetBindVarValue("f_grp_id", this.currGrpID);
        }

        #region cloud services
        private List<string> CreateGrdSysParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_grp_id");
            return paramList;
        }

        private List<object[]> LoadGrdSys(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM401UGrdSysArgs args = new ADM401UGrdSysArgs();
            args.GrpId = bc["f_grp_id"] != null ? bc["f_grp_id"].VarValue : "";
            ADM401UGrdSysResult result = CloudService.Instance.Submit<ADM401UGrdSysResult, ADM401UGrdSysArgs>(args);
            if (result != null)
            {
                foreach (ADM401UGrdSysItemInfo item in result.GrdSysItemInfo)
                {
                    object[] objects = 
				{ 
					item.SysId, 
					item.SysNm, 
					item.AdmSysYn, 
					item.MsgSysYn
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadGrdGrp(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM401UGrdGrpArgs args = new ADM401UGrdGrpArgs();
            ComboResult result = CloudService.Instance.Submit<ComboResult, ADM401UGrdGrpArgs>(args);
            if (result != null)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion
    }

    #region DirectoryNode
    internal class DirectoryNode : System.Windows.Forms.TreeNode
    {

        public bool SubDirectoriesAdded;

        public DirectoryNode(String text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex)
        {
        }

        public DirectoryNode(String text)
            : this(text, -1, -1)
        {
        }
    }
    #endregion

    #region SendFileItem
    internal class SendFileItem
    {
        private string fileName = "";
        private bool hasVersion = true;
        private string fileVersion = "";
        public string FileName
        {
            get { return fileName; }
        }
        public bool HasVersion
        {
            get { return hasVersion; }
        }
        public string FileVersion
        {
            get { return fileVersion; }
        }
        public SendFileItem(string fileName, bool hasVersion, string fileVersion)
        {
            this.fileName = fileName;
            this.hasVersion = hasVersion;
            this.fileVersion = fileVersion;
        }
    }
    #endregion

    #region ListViewColumnSorter
    internal class ListViewColumnSorter : IComparer
    {
        private int sortColumnIndex = -1;
        private SortOrder orderOfSort = SortOrder.None;
        public int SortColumnIndex
        {
            get { return sortColumnIndex; }
            set { sortColumnIndex = value; }
        }
        public SortOrder OrderOfSort
        {
            get { return orderOfSort; }
            set { orderOfSort = value; }
        }
        public ListViewColumnSorter()
        {
        }

        public int Compare(object x, object y)
        {
            if (orderOfSort == SortOrder.None) return 0;

            ListViewItem listviewX, listviewY;
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            int result = 0;
            string compX = listviewX.SubItems[sortColumnIndex].Text;
            string compY = listviewY.SubItems[sortColumnIndex].Text;
            result = compX.CompareTo(compY);
            if (orderOfSort == SortOrder.Descending)
                result = -result;
            return result;

        }
    }
    #endregion
}

