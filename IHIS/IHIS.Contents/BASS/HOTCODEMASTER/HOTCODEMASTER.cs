using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.BASS.Properties;
using System.Threading;

namespace IHIS.BASS
{
    public partial class HOTCODEMASTER : IHIS.Framework.XScreen
    {
        #region Fields & Properties

        private DataTable _grdDataSource;

        #endregion

        #region Constructor
        /// <summary>
        /// HOTCODEMASTER
        /// </summary>
        public HOTCODEMASTER()
        {
            InitializeComponent();

            // Connect to Cloud
            InitCloud();
        }
        #endregion

        #region Events

        private void HOTCODEMASTER_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdList.ExecuteQuery = GetGrdList;
            grdList.QueryLayout(false);
        }

        /// <summary>
        /// Load data into grid and save to temp table (ADM_HOTCODE)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
                else
                {
                    return;
                }
            }

            CsvHelper csvHelper = new CsvHelper(fileName);
            csvHelper.XProgressBar = this.xProgressBar;

            // File Validation
            if (csvHelper.Validate() == false)
            {
                XMessageBox.Show(Resources.FILE_INVALID_COL_NUM_MSG, Resources.ERR_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load data to grid
            this._grdDataSource = csvHelper.CsvDataSource;
            grdList.ExecuteQuery = LoadDefaultGrdList;
            grdList.QueryLayout(true);

            // データを保存しますか？
            if (XMessageBox.Show(Resources.CONFIRM_SAVE_MSG, Resources.SAVE_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Save data to ADM_HOTCODE temp table
                if (csvHelper.Save() == true)
                {
                    // Succeeded
                    XMessageBox.Show(Resources.SAVE_SUCCESS_MSG, Resources.SAVE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Failed
                    XMessageBox.Show(Resources.SAVE_FAIL_MSG, Resources.SAVE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// Save to OCS0103 table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor preCursor = Cursor.Current;

            try
            {
                // Confirm before save
                if (XMessageBox.Show(Resources.CONFIRM_PROCESS_MSG, Resources.SAVE_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                HOTCODEMASTERSaveOCS0103Args args = new HOTCODEMASTERSaveOCS0103Args();
                args.HospCode = UserInfo.HospCode;
                args.UserId = UserInfo.UserID;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, HOTCODEMASTERSaveOCS0103Args>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
                {
                    // Succeeded
                    XMessageBox.Show(Resources.SAVE_SUCCESS_MSG, Resources.SAVE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Failed
                    XMessageBox.Show(Resources.SAVE_FAIL_MSG, Resources.SAVE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Cursor.Current = preCursor;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdList.SetBindVarValue("f_hangmog_name", hangmogNameTextBox.Text);
            grdList.SetBindVarValue("f_hot_code", hotCodeTextBox.Text);
        }

        #endregion

        #region Methods


        #endregion

        #region CloudConnector

        private void InitCloud()
        {
            grdList.ParamList = new List<string>(new string[] { "f_hangmog_name", "f_hot_code", "f_page_number" });
        }

        private IList<object[]> GetGrdList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            HOTCODEMASTERGetGrdListArgs args = new HOTCODEMASTERGetGrdListArgs();
            args.HangmogName = bvc["f_hangmog_name"].VarValue;
            args.HotCode = bvc["f_hot_code"].VarValue;
            args.Offset = "200";
            args.PageNumber = bvc["f_page_number"].VarValue;
            HOTCODEMASTERGetGrdListResult res = CloudService.Instance.Submit<HOTCODEMASTERGetGrdListResult, HOTCODEMASTERGetGrdListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdListItem.ForEach(delegate(HOTCODEMASTERGetGrdListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.HotCode,
                        item.HotCode7,
                        item.CinCode,
                        item.DispenseCode,
                        item.LogisticCode,
                        item.JanCode,
                        item.YakKijunCode,
                        item.YjCode,
                        item.SgCode,
                        item.SgCode1,
                        item.HangmogName,
                        item.HangmogName1,
                        item.HangmogName2,
                        item.StandardUnit,
                        item.PkgStatus,
                        item.PkgNumUnit,
                        item.OrdDanui,
                        item.PkgTotal,
                        item.PkgTotalUnit,
                        item.Clsif,
                        item.ManufComp,
                        item.SalesComp,
                        item.ClsifUpd,
                        item.SgYmd,
                    });
                });
            }

            return lObj;
        }

        private IList<object[]> LoadDefaultGrdList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            xProgressBar.Visible = true;
            xProgressBar.Refresh();
            xProgressBar.Minimum = 1;
            xProgressBar.Maximum = this._grdDataSource.Rows.Count;

            for (int i = 0; i < this._grdDataSource.Rows.Count; i++)
            {
                xProgressBar.Value = i + 1;
                xProgressBar.Refresh();
                //int percent = (int)(((double)xProgressBar.Value / (double)xProgressBar.Maximum) * 100);
                xProgressBar.Text = string.Format("Checking {0}/{1} Row(s)", i + 1, this._grdDataSource.Rows.Count);

                DataRow row = this._grdDataSource.Rows[i];
                lObj.Add(new object[]
                {
                    row[0],
                    row[1],
                    row[2],
                    row[3],
                    row[4],
                    row[5],
                    row[6],
                    row[7],
                    row[8],
                    row[9],
                    row[10],
                    row[11],
                    row[12],
                    row[13],
                    row[14],
                    row[15],
                    row[16],
                    row[17],
                    row[18],
                    row[19],
                    row[20],
                    row[21],
                    row[22],
                    row[23],
                });
            }

            //xProgressBar.CreateGraphics().DrawString(string.Format("Checked {0}/{1} Row(s)", this._grdDataSource.Rows.Count, this._grdDataSource.Rows.Count),
            //        new Font("Arial", (float)8.25, FontStyle.Regular),
            //        Brushes.Black,
            //        new PointF(xProgressBar.Width / 2, xProgressBar.Height / 2 - 7));
            xProgressBar.Text = string.Format("{0} row(s) checked", this._grdDataSource.Rows.Count);

            return lObj;
        }

        #endregion

        #region CsvHelper
        /// <summary>
        /// Provides some methods to work with csv file as well
        /// </summary>
        internal class CsvHelper
        {
            private string _filePath = "";
            private DataTable _csvDataSource = new DataTable();
            private XProgressBar _xProgressBar = null;

            /// <summary>
            /// Number of records for each save request
            /// </summary>
            private const int MAX_PROCESS_UPD_ROWS = 989;

            /// <summary>
            /// Number of valid columns in csv file
            /// </summary>
            private const int VALID_COL_NUM = 24;

            /// <summary>
            /// Retrieves the contents of csv file, it's read-only
            /// </summary>
            public DataTable CsvDataSource
            {
                get
                {
                    //if (_csvDataSource.Rows.Count > 0) _csvDataSource.Rows.RemoveAt(0);
                    return _csvDataSource;
                }
            }

            /// <summary>
            /// Indicates the update process, set null if no required
            /// </summary>
            public XProgressBar XProgressBar
            {
                get { return _xProgressBar; }
                set { _xProgressBar = value; }
            }

            public CsvHelper(string filePath)
            {
                this._filePath = filePath;
                LoadDataTableFromCsv();
            }

            /// <summary>
            /// Get datasource from csv content file
            /// </summary>
            /// <param name="path">Path to csv file</param>
            /// <param name="isSetHdr">Table with/without header</param>
            /// <returns></returns>
            private void LoadDataTableFromCsv()
            {
                string fileName = Path.GetFileName(this._filePath);
                string sql = @"SELECT * FROM [" + fileName + "]";

                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\;" + 
                                                                        "Extended Properties=\"text;HDR=YES;FMT=Delimited\""))
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    //this._csvDataSource.Locale = CultureInfo.CurrentCulture;
                    adapter.Fill(this._csvDataSource);
                }
            }

            /// <summary>
            /// Excepts 24 columns in csv file only
            /// </summary>
            /// <returns></returns>
            public bool Validate()
            {
                if (this._csvDataSource.Rows.Count > 0 && this._csvDataSource.Columns.Count != VALID_COL_NUM)
                {
                    //XMessageBox.Show(Resources.FILE_INVALID_COL_NUM_MSG, Resources.ERR_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Save contents of csv to a temp table, via CloudConnector engine
            /// </summary>
            /// <returns></returns>
            public bool Save()
            {
                // Truncates ADM_HOTCODE at first time request
                string truncateYn = "Y";
                int rowCnt = 1;
                Random rnd = new Random();
                int randNum = rnd.Next(1, 10);
                int rejectRow = 0;
                List<HOTCODEMASTERGetGrdListInfo> lstData = new List<HOTCODEMASTERGetGrdListInfo>();

                if (_xProgressBar != null)
                {
                    _xProgressBar.Visible = true;
                    _xProgressBar.Refresh();
                    _xProgressBar.Minimum = 1;
                    _xProgressBar.Maximum = _csvDataSource.Rows.Count;
                }

                foreach (DataRow dr in this._csvDataSource.Rows)
                {
                    if (_xProgressBar != null)
                    {
                        Thread.Sleep(5);
                        this._xProgressBar.Value = rowCnt + 1;
                        this._xProgressBar.Refresh();
                        this._xProgressBar.Text = string.Format("Importing {0}/{1} Row(s)", rowCnt + 1, this._csvDataSource.Rows.Count);
                    }

                    // Skip 区分(columns 20) = 歯
                    if (Convert.ToString(dr[19]) == "歯")
                    {
                        rejectRow++;
                        rowCnt++;
                        continue;
                    }

                    // Import rows to save
                    HOTCODEMASTERGetGrdListInfo item = new HOTCODEMASTERGetGrdListInfo();
                    item.HotCode           = dr[0].ToString();// 基準番号（ＨＯＴコード）
                    item.HotCode7          = dr[1].ToString();// 処方用番号（ＨＯＴ７）
                    item.CinCode           = dr[2].ToString();// 会社識別用番号
                    item.DispenseCode      = dr[3].ToString();// 調剤用番号
                    item.LogisticCode      = dr[4].ToString();// 物流用番号
                    item.JanCode           = dr[5].ToString();// ＪＡＮコード
                    item.YakKijunCode      = dr[6].ToString();// 薬価基準収載医薬品コード
                    item.YjCode            = dr[7].ToString();// 個別医薬品コード
                    item.SgCode            = dr[8].ToString();// レセプト電算処理システムコード（１）
                    item.SgCode1           = dr[9].ToString();// レセプト電算処理システムコード（２）
                    item.HangmogName       = dr[10].ToString();// 告示名称
                    item.HangmogName1      = dr[11].ToString();// 販売名
                    item.HangmogName2      = dr[12].ToString();// レセプト電算処理システム医薬品名
                    item.StandardUnit      = dr[13].ToString();// 規格単位
                    item.PkgStatus         = dr[14].ToString();// 包装形態
                    item.PkgNumUnit        = dr[15].ToString();// 包装単位数
                    item.OrdDanui          = dr[16].ToString();// 包装単位単位
                    item.PkgTotal          = dr[17].ToString();// 包装総量数
                    item.PkgTotalUnit      = dr[18].ToString();// 包装総量単位
                    item.Clsif             = dr[19].ToString();// 区分
                    item.ManufComp         = dr[20].ToString();// 製造会社歯
                    item.SalesComp         = dr[21].ToString();// 販売会社
                    item.ClsifUpd          = dr[22].ToString();// 更新区分
                    item.SgYmd             = dr[23].ToString();// 更新年月日
                    lstData.Add(item);

                    // Next process row
                    rowCnt++;

                    //if (lstData.Count == MAX_PROCESS_UPD_ROWS + randNum || rowCnt + 1 == _csvDataSource.Rows.Count)
                    if (lstData.Count == MAX_PROCESS_UPD_ROWS + randNum || rowCnt == _csvDataSource.Rows.Count + 1)
                    {
                        HOTCODEMASTERSaveLayoutArgs args = new HOTCODEMASTERSaveLayoutArgs();
                        args.HospCode = UserInfo.HospCode;
                        args.UserId = UserInfo.UserID;
                        args.TruncateYn = truncateYn;
                        args.LayoutItem = lstData;
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, HOTCODEMASTERSaveLayoutArgs>(args);

                        // Save failed!
                        if (res.ExecutionStatus != ExecutionStatus.Success || res.Result != true)
                        {
                            return false;
                        }

                        lstData = new List<HOTCODEMASTERGetGrdListInfo>();
                        // No truncate anymore
                        truncateYn = "N";
                    }
                }

                // Succeeded
                //this._xProgressBar.Text = string.Format("{0} row(s) imported", this._csvDataSource.Rows.Count);
                int actualResult = this._csvDataSource.Rows.Count - rejectRow;
                this._xProgressBar.Text = string.Format("{0} row(s) imported", actualResult.ToString());

                return true;
            }
        }
        #endregion
    }
}
