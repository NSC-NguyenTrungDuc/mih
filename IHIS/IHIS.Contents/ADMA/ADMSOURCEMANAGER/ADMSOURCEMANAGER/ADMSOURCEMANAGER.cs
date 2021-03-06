using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using System.IO;
using System.Data.OracleClient;

namespace IHIS.ADMA
{
    public class ADMSOURCEMANAGER : IHIS.Framework.XScreen
    {
        public ADMSOURCEMANAGER()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dispose 구현
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMSOURCEMANAGER));
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdADM0301 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.tvwProgramTree = new IHIS.Framework.XTreeView();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xTextBox1 = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxSysNm = new IHIS.Framework.XDisplayBox();
            this.fbxSysID = new IHIS.Framework.XFindBox();
            this.fwkSysid = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layProgramList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdADM0301)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layProgramList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "보기.gif");
            this.ImageList.Images.SetKeyName(1, "글올리기(화살표).gif");
            this.ImageList.Images.SetKeyName(2, "글올리기(화살표)_1.gif");
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdADM0301);
            this.xPanel3.Controls.Add(this.tvwProgramTree);
            this.xPanel3.Controls.Add(this.xPanel2);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(4, 4);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(691, 546);
            this.xPanel3.TabIndex = 1;
            // 
            // grdADM0301
            // 
            this.grdADM0301.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell8,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell3});
            this.grdADM0301.ColPerLine = 3;
            this.grdADM0301.Cols = 4;
            this.grdADM0301.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdADM0301.FixedCols = 1;
            this.grdADM0301.FixedRows = 1;
            this.grdADM0301.HeaderHeights.Add(28);
            this.grdADM0301.Location = new System.Drawing.Point(258, 33);
            this.grdADM0301.Name = "grdADM0301";
            this.grdADM0301.RowHeaderVisible = true;
            this.grdADM0301.Rows = 2;
            this.grdADM0301.Size = new System.Drawing.Size(433, 513);
            this.grdADM0301.TabIndex = 1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "sys_id";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "sys_id";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "pgm_id";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell2.HeaderText = "プログラムＩＤ";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "seq";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "seq";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "status";
            this.xEditGridCell4.CellWidth = 131;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell4.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell4.HeaderText = "状態";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "Check In";
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "Check Out";
            this.xComboItem2.ValueItem = "2";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "last_upd_date";
            this.xEditGridCell5.CellWidth = 106;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell5.HeaderText = "最終更新日付";
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "last_upd_user";
            this.xEditGridCell6.CellWidth = 149;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell6.HeaderText = "最終更新者";
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "file_name";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "file_name";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // tvwProgramTree
            // 
            this.tvwProgramTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwProgramTree.HideSelection = false;
            this.tvwProgramTree.ImageIndex = 0;
            this.tvwProgramTree.ImageList = this.ImageList;
            this.tvwProgramTree.Location = new System.Drawing.Point(0, 33);
            this.tvwProgramTree.Name = "tvwProgramTree";
            this.tvwProgramTree.SelectedImageIndex = 0;
            this.tvwProgramTree.Size = new System.Drawing.Size(258, 513);
            this.tvwProgramTree.TabIndex = 2;
            this.tvwProgramTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwProgramTree_AfterSelect);
            // 
            // xPanel2
            // 
            this.xPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel2.BackgroundImage")));
            this.xPanel2.Controls.Add(this.xTextBox1);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.dbxSysNm);
            this.xPanel2.Controls.Add(this.fbxSysID);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(691, 33);
            this.xPanel2.TabIndex = 0;
            // 
            // xTextBox1
            // 
            this.xTextBox1.Location = new System.Drawing.Point(428, 7);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.Size = new System.Drawing.Size(240, 20);
            this.xTextBox1.TabIndex = 7;
            // 
            // xLabel2
            // 
            this.xLabel2.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(342, 7);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(85, 20);
            this.xLabel2.TabIndex = 6;
            this.xLabel2.Text = "プログラム検索";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxSysNm
            // 
            this.dbxSysNm.Location = new System.Drawing.Point(189, 7);
            this.dbxSysNm.Name = "dbxSysNm";
            this.dbxSysNm.Size = new System.Drawing.Size(116, 20);
            this.dbxSysNm.TabIndex = 5;
            // 
            // fbxSysID
            // 
            this.fbxSysID.AutoTabDataSelected = true;
            this.fbxSysID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxSysID.FindWorker = this.fwkSysid;
            this.fbxSysID.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fbxSysID.Location = new System.Drawing.Point(80, 7);
            this.fbxSysID.MaxLength = 4;
            this.fbxSysID.Name = "fbxSysID";
            this.fbxSysID.Size = new System.Drawing.Size(108, 20);
            this.fbxSysID.TabIndex = 0;
            this.fbxSysID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxSysID.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSysID_DataValidating);
            // 
            // fwkSysid
            // 
            this.fwkSysid.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkSysid.InputSQL = "SELECT A.SYS_ID\r\n     , A.SYS_NM\r\n  FROM ADM0200 A";
            this.fwkSysid.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "sys_id";
            this.findColumnInfo1.ColWidth = 94;
            this.findColumnInfo1.HeaderText = "システムID";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sys_nm";
            this.findColumnInfo2.ColWidth = 203;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "システム名称";
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(6, 7);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(72, 20);
            this.xLabel1.TabIndex = 3;
            this.xLabel1.Text = "システム";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "Down", 2, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "Up", 1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.ImageList = this.ImageList;
            this.btnList.Location = new System.Drawing.Point(271, 553);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(406, 34);
            this.btnList.TabIndex = 2;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layProgramList
            // 
            this.layProgramList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10});
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "sys_id";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "pgm_id";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "pgm_nm";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "pgm_tp";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "end_yn";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "zip";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "zip";
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ADMSOURCEMANAGER
            // 
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xPanel3);
            this.Name = "ADMSOURCEMANAGER";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(699, 590);
            this.Load += new System.EventHandler(this.ADMSOURCEMANAGER_Load);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdADM0301)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layProgramList)).EndInit();
            this.ResumeLayout(false);

        }

        private XPanel xPanel3;
        private XPanel xPanel2;
        private XDisplayBox dbxSysNm;
        private XFindBox fbxSysID;
        private XLabel xLabel1;
        private XEditGrid grdADM0301;
        private XTextBox xTextBox1;
        private XLabel xLabel2;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell4;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XTreeView tvwProgramTree;
        private XButtonList btnList;
        private MultiLayout layProgramList;
        private XFindWorker fwkSysid;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private System.ComponentModel.IContainer components;
        private XEditGridCell xEditGridCell8;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private XEditGridCell xEditGridCell3;
        
        #region Screen 변수

        string mMsg = "";
        string mCap = "";
        private const string USERID = "ihissource";
        private const string USERPWD = "ihissource";

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #region Screen Load

        private void ADMSOURCEMANAGER_Load(object sender, EventArgs e)
        {
            if (Service.Connect() == false)
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        #endregion

        #region XFindBox

        private void fbxSysID_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                this.dbxSysNm.SetDataValue("");
                this.SetMsg("");

                return;
            }

            string cmd = " SELECT A.SYS_NM " +
                         "   FROM ADM0200 A " +
                         "  WHERE A.SYS_ID = '" + e.DataValue + "'";

            object name = Service.ExecuteScalar(cmd);

            //XMessageBox.Show(Service.ErrFullMsg);

            if (name == null )
            {
                mMsg = "システムIDを確認して下さい。";
                mCap = "確認";

                XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK);

                this.SetMsg (mMsg, MsgType.Error);

                this.dbxSysNm.SetDataValue("");

                return;
            }

            this.dbxSysNm.SetDataValue(name.ToString());
            this.MakeProgramTree(e.DataValue);
        }

        #endregion

        #region Data Query 관련

        private bool QueryProgramList(string aSysid)
        {
            this.layProgramList.QuerySQL = " SELECT A.SYS_ID " +
                                           "      , A.PGM_ID " +
                                           "      , A.PGM_NM " +
                                           "      , A.PGM_TP " +
                                           "      , A.END_YN " +
                                           "   FROM ADM0300 A " +
                                           "  WHERE A.SYS_ID = '" + aSysid + "'" +    
                                           "    AND A.PGM_TP = 'P' " +   // 프로그램만 
                                           "  ORDER BY 1, 2 ";

            if (this.layProgramList.QueryLayout(true) == false)
            {
                return false;
            }

            return true;
        }

        private bool QueryADM0301(string aSysid, string aPgmid)
        {
            this.grdADM0301.QuerySQL = " SELECT A.SYS_ID        " +
                                       "      , A.PGM_ID        " +
                                       "      , A.SEQ           " +
                                       "      , A.STATUS        " +
                                       "      , A.LAST_UPD_DATE " +
                                       "      , A.LAST_UPD_USER " +
                                       "      , A.FILENAME      " +
                                       "   FROM ADM0301 A " +
                                       "  WHERE A.SYS_ID = '" + aSysid + "'" +
                                       "    AND A.PGM_ID = '" + aPgmid + "'" +
                                       "  ORDER BY A.SEQ DESC";

            if (this.grdADM0301.QueryLayout(true) == false)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Check 관련

        private bool IsDownloadable(string aSysid, string aPgmid)
        {
            string cmd = " SELECT 'Y' " +
                         "   FROM DUAL " +
                         "  WHERE EXISTS ( SELECT 'X' " +
                         "                   FROM ADM0301 Z " +
                         "                  WHERE Z.SYS_ID = '" + aSysid + "'" +
                         "                    AND Z.PGM_ID = '" + aPgmid + "'" +
                         "                    AND Z.STATUS = '1' ) "; // 다운로드된 상태의 데이터가 있다면 다운로드 불가

            object checkYN = Service.ExecuteScalar(cmd);

            if (checkYN == null)
            {
                return true;
            }
            else if (checkYN.ToString() == "Y")
            {
                this.mMsg = "既にダウンロードして修正中Sourceです。";
                this.mCap = "ダウンロード確認";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private bool IsUploadable(string aSysid, string aPgmid)
        {
            // 마지막 시퀀스의 데이터가 다운로드이고 
            // 다운로드한 유저가 본인인 경우만 업로드 가능
            /////////////////////////////////////////////////////////////
            string cmd = " SELECT A.LAST_UPD_USER " +
                         "      , FN_ADM_USER_NM(A.LAST_UPD_USER)  AS USER_NAME " +
                         "   FROM ADM0301 A " +
                         "  WHERE A.SYS_ID = '" + aSysid + "'" +
                         "    AND A.PGM_ID = '" + aPgmid + "'" +
                         "    AND A.SEQ    = ( SELECT MAX(Z.SEQ) " +
                         "                       FROM ADM0301 Z " +
                         "                      WHERE Z.SYS_ID = A.SYS_ID   " +
                         "                        AND Z.PGM_ID = A.PGM_ID ) " +
                         "    AND A.STATUS = '1' ";
            System.Data.OracleClient.OracleDataReader dataReader = (OracleDataReader) Service.ExecuteReader(cmd);

            string lastUser = "";
            string lastUserName = "";

            if (dataReader == null)
            {
                return true;
            }
            else
            {
                while (dataReader.Read())
                {
                    lastUser = dataReader.GetString(0);
                    lastUserName = dataReader.GetString(1);
                }

                if (lastUser == "")
                    return true;

                if (lastUser != UserInfo.UserID)
                {
                    this.mMsg = "現在 " + lastUserName + " がダウンロードしてまだアップロードしてなしです。";
                    this.mCap = "アップロード失敗";

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }

        #endregion

        #region FTP UP, Down 관련

        #region 다운로드 관련

        private bool DownloadSource(string aSysid, string aPgmid)
        {
            string ip = EnvironInfo.GetDownloadServerIP();
            string cmd = " SELECT A.FILENAME " +
                         "   FROM ADM0301 A " +
                         "  WHERE A.SYS_ID = '" + aSysid + "'" +
                         "    AND A.PGM_ID = '" + aPgmid + "'" +
                         "    AND A.SEQ = ( SELECT MAX(Z.SEQ) " +
                         "                    FROM ADM0301 Z " +
                         "                   WHERE Z.SYS_ID = A.SYS_ID " +
                         "                     AND Z.PGM_ID = A.PGM_ID )";

            object filename ;

            filename = Service.ExecuteScalar(cmd);

            if (filename == null)
            {
                this.mMsg = "ダウンロードするファイルが存在しません。";
                this.mCap = "ダウンロード失敗";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IHIS.Framework.XFTPWorker ftpWorker = new IHIS.Framework.XFTPWorker(USERID, USERPWD, ip);


            // 디렉토리 변경
            // 시스템 디렉토리
            if (ftpWorker.ChangeDir(aSysid) == false)
            {
                ftpWorker.MakeDir(aSysid);
                ftpWorker.ChangeDir(aSysid);
            }

            // 프로그램 디렉토리
            if (ftpWorker.ChangeDir(aPgmid) == false)
            {
                ftpWorker.MakeDir(aSysid);
                ftpWorker.ChangeDir(aSysid);
            }

            if (ftpWorker.ExistFile(filename.ToString()) == false)
            {
                this.mMsg = "ダウンロードするファイルが存在しません。";
                this.mCap = "ダウンロード失敗";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ftpWorker.Close();
                return false;
            }

            // 다운로드 패스지정
            this.saveFileDialog.DefaultExt = "zip";
            this.saveFileDialog.FileName = filename.ToString();
            DialogResult result = this.saveFileDialog.ShowDialog();

            string downloadpath = "";

            for (int i = 0; i < this.saveFileDialog.FileName.Split('\\').Length - 1; i++)
            {
                downloadpath += this.saveFileDialog.FileName.Split('\\')[i] + @"\";
            }

            // 클라이언트 디렉토리 지정
            // 클라이언트 디렉토리 확인
            if (Directory.Exists(downloadpath) == false)
            {
                this.mMsg = "保存する場所が有効ではありません。";
                this.mCap = "ダウンロード失敗";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ftpWorker.Close();
                return false;
            }

            // 현재의 클라이언트 디렉토리 변경한다.
            if (downloadpath != Directory.GetCurrentDirectory())
            {
                Directory.SetCurrentDirectory(downloadpath);
            }

            // 다운로드 개시
            if (ftpWorker.SendFileToClient(filename.ToString(), filename.ToString()) == false)
            {
                this.mMsg = "ダウンロードに失敗しました。";
                this.mCap = "ダウンロード失敗";

                MessageBox.Show(this.mCap, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ftpWorker.Close();
                return false;
            }

            cmd = " UPDATE ADM0301 " +
                  "    SET STATUS = '1' " + // 다운로드 했음.
                  "      , LAST_UPD_DATE = SYSDATE " +
                  "      , LAST_UPD_USER = '" + UserInfo.UserID + "' " +
                  "  WHERE SYS_ID = '" + aSysid + "' " +
                  "    AND PGM_ID = '" + aPgmid + "' " +
                  "    AND SEQ    = " + this.grdADM0301.GetItemString(0, "seq");

            if (Service.ExecuteNonQuery(cmd) == false)
            {
                this.mMsg = "Data Update Fail";
                this.mCap = "Update";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ftpWorker.Close();
            return true;
        }

        #endregion

        #region 업로드 관련

        private bool UploadSource(string aSysid, string aPgmid)
        {
            string cmd = "";
            string ip = EnvironInfo.GetDownloadServerIP();

            // 업로드 할 자료선택
            ///////////////////////////////////////////////////////////////
            string clientfilename = "";
            string clientpath = "";

            DialogResult result = this.openFileDialog.ShowDialog();

            if (result != DialogResult.OK)
                return false;

            if (openFileDialog.FileName == "")
            {
                this.mMsg = "ファイルを選択して下さい。";
                this.mCap = "確認";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            string ext = this.openFileDialog.FileName.Split('.')[this.openFileDialog.FileName.Split('.').Length - 1];

            if (ext != "zip")
            {
                this.mMsg = "ZIP 形式ファイルのみ転送ができます。";
                this.mCap = "確認";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            clientfilename = this.openFileDialog.FileName;

            for (int i = 0; i < this.openFileDialog.FileName.Split('\\').Length; i++)
            {
                if (i < this.openFileDialog.FileName.Split('\\').Length - 1)
                    clientpath += this.openFileDialog.FileName.Split('\\')[i] + @"\";
                else
                    clientfilename = this.openFileDialog.FileName.Split('\\')[i];
            }

            // 시퀀스 쿼리
            ///////////////////////////////////////////////////////////////
            string nextSeq = "";

            cmd = " SELECT MAX(A.SEQ) LAST_NUM" +
                  "   FROM ADM0301 A " +
                  "  WHERE A.SYS_ID = '" + aSysid + "' " +
                  "    AND A.PGM_ID = '" + aPgmid + "' ";

            object maxnum = Service.ExecuteScalar(cmd);

            if (maxnum == null)
            {
                nextSeq = "1";
            }
            else
            {
                if (TypeCheck.IsInt(nextSeq))
                    nextSeq = (((int)maxnum) + 1).ToString();
                else
                    nextSeq = "1";
            }

            // 디렉토리 변경
            ///////////////////////////////////////////////////////////////
            
            
            // 현재의 클라이언트 디렉토리 변경한다.
            if (clientpath != Directory.GetCurrentDirectory())
            {
                Directory.SetCurrentDirectory(clientpath);
            }

            XFTPWorker ftpWorker = new XFTPWorker(USERID, USERPWD, ip);

            // 시스템
            if (ftpWorker.ChangeDir(aSysid) == false)
            {
                ftpWorker.MakeDir(aSysid);
                ftpWorker.ChangeDir(aSysid);
            }
            // 프로그램
            if (ftpWorker.ChangeDir(aPgmid) == false)
            {
                ftpWorker.MakeDir(aPgmid);
                ftpWorker.ChangeDir(aPgmid);
            }


            // 업로드 시작
            ///////////////////////////////////////////////////////////////
            string serverFilename = aPgmid + "_" + nextSeq + ".zip";

            if (ftpWorker.SendFileToServer(clientfilename, serverFilename) == false)
            {
                this.mMsg = "File Upload Fail...";
                this.mCap = "Upload";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                ftpWorker.Close();
                return false;
            }

            // 데이터 업데이트
            ///////////////////////////////////////////////////////////////

            cmd = " INSERT INTO ADM0301 ( SYS_ID, PGM_ID, STATUS, LAST_UPD_DATE, LAST_UPD_USER, FILENAME, SEQ ) " +
                  " VALUES ( '" + aSysid + "', '" + aPgmid + "', '2', SYSDATE, '" + UserInfo.UserID + "', '" + serverFilename + "', " + nextSeq + ") ";

           // MessageBox.Show(cmd);

            if (Service.ExecuteNonQuery(cmd) == false)
            {
                this.mMsg = "Data Update Fail...";
                this.mMsg += "\r\n " + Service.ErrFullMsg;
                this.mCap = "Update";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                ftpWorker.Close();

                return false;
            }

            ftpWorker.Close();
            return true;
        }

        #endregion

        #endregion

        #region Tree 관련

        private void MakeProgramTree(string aSysid)
        {
            this.tvwProgramTree.Nodes.Clear();

            this.QueryProgramList(aSysid);

            TreeNode node;
            Hashtable nodeInfo;

            foreach (DataRow dr in this.layProgramList.LayoutTable.Rows)
            {
                node = new TreeNode(dr["pgm_nm"].ToString(), 0, 0);

                nodeInfo = new Hashtable();
                nodeInfo.Add("sys_id", dr["sys_id"].ToString());
                nodeInfo.Add("pgm_id", dr["pgm_id"].ToString());
                nodeInfo.Add("pgm_nm", dr["pgm_nm"].ToString());
                nodeInfo.Add("pgm_tp", dr["pgm_tp"].ToString());
                nodeInfo.Add("end_yn", dr["end_yn"].ToString());

                node.Tag = nodeInfo;



                this.tvwProgramTree.Nodes.Add(node);
            }
        }

        #endregion

        #region XButtonList

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            Hashtable nodeInfo;
            switch (e.Func)
            {
                case FunctionType.Insert : // Down

                    e.IsBaseCall = false;

                    if (this.tvwProgramTree.SelectedNode == null)
                        return;

                    nodeInfo = this.tvwProgramTree.SelectedNode.Tag as Hashtable;

                    if (this.IsDownloadable(nodeInfo["sys_id"].ToString(), nodeInfo["pgm_id"].ToString()) == false)
                        return;

                    this.mMsg = nodeInfo["pgm_nm"].ToString() + " をダウンロードしますか？";
                    this.mCap = "ダウンロード確認";

                    if (MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    if (this.DownloadSource(nodeInfo["sys_id"].ToString(), nodeInfo["pgm_id"].ToString()) == true)
                        this.btnList.PerformClick(FunctionType.Query);

                    break;

                case FunctionType.Delete : // Up

                    e.IsBaseCall = false;

                    if (this.tvwProgramTree.SelectedNode == null)
                        return;

                    nodeInfo = this.tvwProgramTree.SelectedNode.Tag as Hashtable;
                    // 업로드 조건 판단
                    if (this.IsUploadable(nodeInfo["sys_id"].ToString(), nodeInfo["pgm_id"].ToString()) == false)
                        return;

                    if (this.UploadSource(nodeInfo["sys_id"].ToString(), nodeInfo["pgm_id"].ToString()) == true)
                        this.btnList.PerformClick(FunctionType.Query);

                    break;
                case FunctionType.Query :

                    e.IsBaseCall = false;

                    if (this.tvwProgramTree.SelectedNode != null)
                    {
                        nodeInfo = this.tvwProgramTree.SelectedNode.Tag as Hashtable;

                        this.QueryADM0301(nodeInfo["sys_id"].ToString(), nodeInfo["pgm_id"].ToString());
                    }

                    break;
                case FunctionType.Reset:

                    this.tvwProgramTree.Nodes.Clear();

                    break;
            }
        }

        #endregion

        private void tvwProgramTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }

            this.btnList.PerformClick(FunctionType.Query);            
        }
    }
}