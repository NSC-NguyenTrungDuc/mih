using EmrDocker.Models;
using IHIS.OCSO.Properties;

namespace IHIS.OCSO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Windows.Forms;

    using IHIS.CloudConnector;
    using IHIS.CloudConnector.Contracts.Arguments.Nuro;
    using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
    using IHIS.CloudConnector.Contracts.Arguments.System;
    using IHIS.CloudConnector.Contracts.Models.Nuro;
    using IHIS.CloudConnector.Contracts.Models.System;
    using IHIS.CloudConnector.Contracts.Results;
    using IHIS.CloudConnector.Contracts.Results.Nuro;
    using IHIS.CloudConnector.Contracts.Results.System;
    using IHIS.Framework;
    using IHIS.OCSO.Meta;

    using Newtonsoft.Json;
    using IHIS.CloudConnector.Contracts.Results.OcsEmr;

    public partial class OCS2015U04C : UserControl
    {
        public OCS2015U04C()
        {
            InitializeComponent();
        }

        //public OCS2015U04(OCS2015U00 mainScreen) : this()
        //{
        //    _mainScreen = mainScreen;
        //}

        private OCS2016U02 _mainScreen;

        public OCS2016U02 MainScreen
        {
            set { _mainScreen = value; }
        }

        public ContextMenuStrip ContextMenuStrip
        {
            get { return contextMenuStrip1; }
        }

        public TreeView TvBunho
        {
            get { return tvBunho; }
        }

        private bool _isEnableRightClick;

        public bool IsEnableRightClick
        {
            get { return _isEnableRightClick; }
            set { _isEnableRightClick = value; }
        }

        private DataTable dt;
        private Dictionary<string, List<CustomMarkSchema>> _emrMetaList;
        private List<CommentInfo> _lstCommentInfos = new List<CommentInfo>();
        private string _recordId;
        private const string GWA = "GWA";
        private const string GWA_NAME = "GWA_NAME";
        private const string NAEWON_DATE = "NAEWON_DATE";

        public delegate void BookmarkEventCHandler(object sender, BookmarkEventCArgs e);
        public event BookmarkEventCHandler BookmarkEvent;

        /// <summary>
        /// HungNV added
        /// bind data to bookmark treeview
        /// </summary>
        /// <param name="bunho"></param>
        /// <param name="listBookmark"></param>
        /// <param name="gwa"></param>
        /// <param name="ctlEmrDocker"></param>
        /// <param name="emrMetaList"></param>
        public void DisplayBookmarkHistory(string recordId, string bunho, List<CommentInfo> listBookmark, string gwa, EmrDocketS ctlEmrDocker, string hospCodeRefer)
        {
            tvBunho.Nodes.Clear();
            TreeNode patient = new TreeNode();
            //tvBunho.Nodes.Add(patient);

            if (CloudService.Instance.Connect() && listBookmark.Count > 0)
            {
                _lstCommentInfos = listBookmark;
                _recordId = recordId;
                EMRDisplayBookmarkHistoryArgs args = new EMRDisplayBookmarkHistoryArgs();
                args.Bunho = bunho;
                if (!string.IsNullOrEmpty(hospCodeRefer)) args.HospCode = hospCodeRefer;
                EMRDisplayBookmarkHistoryResult res = CloudService.Instance.Submit<EMRDisplayBookmarkHistoryResult, EMRDisplayBookmarkHistoryArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.PatientListItem.Count > 0)
                    {
                        patient.Nodes.Clear();
                        PatientInfo patientInfo = res.PatientListItem[0];
                        patient.Text = patientInfo.PatientName1;
                        patient.Tag = bunho;

                        if (res.HistoryListItem.Count > 0)
                        {
                            dt = new DataTable();
                            dt.Columns.Add(GWA, typeof(string));
                            dt.Columns.Add(GWA_NAME, typeof(string));
                            dt.Columns.Add(NAEWON_DATE, typeof(string));
                            foreach (NuroPatientReceptionHistoryListItemInfo item in res.HistoryListItem)
                            {
                                DataRow dr = dt.NewRow();
                                dr[GWA] = item.DepartmentCode;
                                dr[GWA_NAME] = item.DepartmentName;
                                dr[NAEWON_DATE] = item.ExamDate;
                                dt.Rows.Add(dr);
                            }

                            _listBookmark = listBookmark;
                            _gwa = gwa;
                            _patient = patient;
                            GenerateBookmarkTree(listBookmark, gwa, patient, true);
                        }
                    }
                }
                // 2015.08.06 AnhNV Added END

                #region deleted
                //GetPatientByCodeArgs patientArgs = new GetPatientByCodeArgs();
                //patientArgs.PatientCode = bunho;
                //GetPatientByCodeResult patientResult = CloudService.Instance.Submit<GetPatientByCodeResult, GetPatientByCodeArgs>(patientArgs);
                //if (patientResult.ExecutionStatus == ExecutionStatus.Success
                //    && patientResult.LstPatientInfos.Count > 0)
                //{
                //    patient.Nodes.Clear();
                //    PatientInfo patientInfo = patientResult.LstPatientInfos[0];
                //    patient.Text = patientInfo.PatientName1;
                //    patient.Tag = bunho;

                //    NuroPatientReceptionHistoryListArgs receptHisArg = new NuroPatientReceptionHistoryListArgs();
                //    receptHisArg.PatientCode = bunho;
                //    NuroPatientReceptionHistoryListResult receptHisResult = CloudService.Instance.Submit<NuroPatientReceptionHistoryListResult, NuroPatientReceptionHistoryListArgs>(receptHisArg);

                //    if (receptHisResult.ExecutionStatus == ExecutionStatus.Success
                //        && receptHisResult.PatientReceptionHistoryListItem.Count > 0)
                //    {
                //        //DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                //        //DataTable dt = new DataTable();
                //        dt = new DataTable();
                //        dt.Columns.Add("GWA", typeof(string));
                //        dt.Columns.Add("GWA_NAME", typeof(string));
                //        dt.Columns.Add("NAEWON_DATE", typeof(string));
                //        foreach (NuroPatientReceptionHistoryListItemInfo item in receptHisResult.PatientReceptionHistoryListItem)
                //        {
                //            DataRow dr = dt.NewRow();
                //            dr["GWA"] = item.DepartmentCode;
                //            dr["GWA_NAME"] = item.DepartmentName;
                //            dr["NAEWON_DATE"] = item.ExamDate;
                //            dt.Rows.Add(dr);
                //        }

                //        _listBookmark = listBookmark;
                //        _gwa = gwa;
                //        _patient = patient;
                //        GenerateBookmarkTree(listBookmark, gwa, patient, true);
                //    }
                //}
                #endregion
            }
        }


        private string _gwa = "";
        List<CommentInfo> _listBookmark = null;
        TreeNode _patient = null;

        private void GenerateBookmarkTree(List<CommentInfo> listBookmark, string gwa, TreeNode patient, bool isNew)
        {
            if (isNew)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Departments
                    DataView dv = new DataView(dt);
                    DataTable dtDept = dv.ToTable(true, GWA, GWA_NAME);
                    DataRow[] drRange = dtDept.Select("GWA ='" + gwa + "'");
                    DataRow drSelectedPatientDept = drRange.Length > 0 ? drRange[0] : null;
                    if (drSelectedPatientDept != null)
                    {
                        DataRow newRow = dtDept.NewRow();
                        newRow.ItemArray = drSelectedPatientDept.ItemArray; // clone datarow
                        dtDept.Rows.Remove(drSelectedPatientDept);
                        dtDept.Rows.InsertAt(newRow, 0); // set current department to first position

                        foreach (DataRow dr in dtDept.Rows)
                        {
                            TreeNode dept = new TreeNode();
                            dept.Text = dr[GWA_NAME].ToString();
                            dept.Name = dr[GWA].ToString();
                            patient.Nodes.Add(dept);
                        }
                    }

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.TypeNameHandling = TypeNameHandling.Objects;

                    Dictionary<string, CommentInfo> existedBookmarks = new Dictionary<string, CommentInfo>();
                    foreach (TreeNode dept1 in patient.Nodes)
                    {
                        contextMenuStrip1.Enabled = IsEnableRightClick ? true : false;

                        foreach (CommentInfo bookmark in listBookmark)
                        {
                            if (UserInfo.UserGubun == UserType.Doctor) // is doctor
                            {
                                //Bookmark of doctor only view data
                                //implement new feature with new logic: Doctors have the right view bookmark
                                /*if (bookmark.UserId == UserInfo.UserID || !bookmark.IsOfDoctor)*/
                                    Getbookmark(existedBookmarks, bookmark, dept1);
                            }
                            else // is nurse
                            {
                                if (bookmark.UserId == UserInfo.UserID)
                                    Getbookmark(existedBookmarks, bookmark, dept1);
                            }
                        }
                    }

                    // Remove departments those havent comments
                    List<TreeNode> rmvDeptList = new List<TreeNode>();
                    foreach (TreeNode treeNode in patient.Nodes)
                    {
                        if (treeNode.Nodes.Count == 0)
                        {
                            rmvDeptList.Add(treeNode);
                        }
                        else
                        {
                            tvBunho.Nodes.Add(treeNode);
                        }
                    }
                    foreach (TreeNode treeNode in rmvDeptList)
                    {
                        treeNode.Remove();
                    }

                    tvBunho.Update();
                    tvBunho.Refresh();
                    tvBunho.ExpandAll();
                }
            }
            else
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (isAsc)
                    {
                        foreach (TreeNode dept in patient.Nodes)
                        {
                            List<TreeNode> lst = new List<TreeNode>();
                            foreach (TreeNode date in dept.Nodes)
                            {
                                lst.Add(date);
                            }
                            lst.Sort(delegate(TreeNode node1, TreeNode node2)
                            {
                                DateTime dt1 = DateTime.Parse(node1.Text);
                                DateTime dt2 = DateTime.Parse(node2.Text);
                                if (dt1 > dt2)
                                {
                                    return 1;
                                }
                                else if (dt1 < dt2)
                                {
                                    return -1;
                                }
                                else
                                {
                                    return 0;
                                }
                            });
                            dept.Nodes.Clear();
                            dept.Nodes.AddRange(lst.ToArray());
                        }

                    }
                    else
                    {
                        foreach (TreeNode dept in patient.Nodes)
                        {
                            List<TreeNode> lst = new List<TreeNode>();
                            foreach (TreeNode date in dept.Nodes)
                            {
                                lst.Add(date);
                            }
                            lst.Sort(delegate(TreeNode node1, TreeNode node2)
                            {
                                DateTime dt1 = DateTime.Parse(node1.Text);
                                DateTime dt2 = DateTime.Parse(node2.Text);
                                if (dt1 > dt2)
                                {
                                    return -1;
                                }
                                else if (dt1 < dt2)
                                {
                                    return 1;
                                }
                                else
                                {
                                    return 0;
                                }
                            });
                            dept.Nodes.Clear();
                            dept.Nodes.AddRange(lst.ToArray());
                        }
                    }

                    tvBunho.Update();
                    tvBunho.Refresh();
                    tvBunho.ExpandAll();

                }
            }
        }

        private void Getbookmark(Dictionary<string, CommentInfo> existedBookmarks, CommentInfo bookmark, TreeNode dept1)
        {
            if (!existedBookmarks.ContainsKey(bookmark.CommentId))
            {
                if (bookmark.Gwa == dept1.Name && !string.IsNullOrEmpty(bookmark.Title)) // Department
                {
                    TreeNode cmt = new TreeNode();
                    cmt.Text = bookmark.Title;
                    cmt.Tag = bookmark;
                    cmt.Name = bookmark.TagId;
                    existedBookmarks.Add(bookmark.CommentId, bookmark);
                    if (dept1.Nodes.Find(bookmark.NaewonDate, true).Length == 1)
                    {
                        dept1.Nodes.Find(bookmark.NaewonDate, true)[0].Nodes.Add(cmt);
                    }
                    else if (dept1.Nodes.Find(bookmark.NaewonDate, true).Length == 0)
                    {
                        TreeNode dateNode = new TreeNode();
                        dateNode.Name = bookmark.NaewonDate;
                        dateNode.Text = bookmark.NaewonDate;
                        dept1.Nodes.Add(dateNode);
                        dateNode.Nodes.Add(cmt);
                    }
                }
            }
        }

        private TreeNode _patientNode;
        private TreeNodeCollection _departmentList;
        private TreeNodeCollection _dateList;
        
        public void Reset()
        {
            _listBookmark = null;
            tvBunho.Nodes.Clear();
            tvBunho.Refresh();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!IsEnableRightClick) return;
            if (tvBunho.SelectedNode.Level == 2)
            {
                CommentInfo cmtMeta = this.tvBunho.SelectedNode.Tag as CommentInfo;
                if (cmtMeta != null && cmtMeta.UserId == UserInfo.UserID)
                {
                    switch (e.ClickedItem.Tag.ToString())
                    {
                        case "mnuDelBookmark":
                            DeleteBookmark(cmtMeta, this.tvBunho.SelectedNode);
                            break;
                        case "mnuEditBookmark":
                            EditBookMark(cmtMeta, this.tvBunho.SelectedNode);
                            break;
                    }
                }
                else if (cmtMeta != null && cmtMeta.UserId != UserInfo.UserID)
                {
                    XMessageBox.Show(_resources.GetString(Resources.OCS2015U04C_MSG_WRONG_USER_EDITING));
                }
            }
        }

        private KeyValuePair<CommentInfo, TreeNode> editingNode = new KeyValuePair<CommentInfo, TreeNode>(null, null);

        private void EditBookMark(CommentInfo comment, TreeNode node)
        {
            if (comment != null)
            {
                //todo: Implement Edit bookMark this!
                editingNode = new KeyValuePair<CommentInfo, TreeNode>(comment, node);
                frmComment frm = new frmComment(comment.TagId, comment.Title, comment.Comment, false);
                frm.CommentUpdated += frm_CommentUpdated;
                frm.ShowDialog();
            }
        }

        void frm_CommentUpdated(object sender, CommentEventArgs e)
        {
            if (editingNode.Key != null && editingNode.Value != null)
            {
                if (e.Comment.Trim().Length > 0
                    && e.Comment.Trim().Length <= 128)
                {
                    ((CommentInfo)editingNode.Value.Tag).Comment = e.Comment;
                    ((CommentInfo)editingNode.Value.Tag).Title = e.Title;
                    editingNode.Value.Text = e.Title;
                    editingNode.Key.Title = e.Title;
                    editingNode.Key.Comment = e.Comment;
                    UpdateBookMark(editingNode.Key, editingNode.Value, false);
                    tvBunho.Refresh();
                }
                else
                {
                    XMessageBox.Show(_resources.GetString(Resources.OCS2015U04C_MSG_COMMENT_LENGTH_INVALID));
                }
            }
        }

        private void DeleteBookmark(CommentInfo cmt, TreeNode node)
        {
            UpdateBookMark(cmt, node, true);
        }

        private bool SubmitChangedBookMark(string recordId, List<CommentInfo> metaData, TreeNode node, bool removeOnSuccess)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            setting.TypeNameHandling = TypeNameHandling.Objects;
            string meta = JsonConvert.SerializeObject(metaData, setting);

            if (CloudService.Instance.Connect())
            {
                OCS2015U06EmrRecordUpdateMetaArgs args = new OCS2015U06EmrRecordUpdateMetaArgs();
                args.FRecordId = recordId;
                args.FMeta = meta;
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS2015U06EmrRecordUpdateMetaArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (result.Result)
                    {
                        if (removeOnSuccess) tvBunho.Nodes.Remove(node);
                        if (BookmarkEvent != null)
                        {
                            BookmarkEvent(this, new BookmarkEventCArgs(node.Tag as CommentInfo, removeOnSuccess));
                        }
                        tvBunho.Refresh();
                        return true;
                    }
                    XMessageBox.Show(_resources.GetString(Resources.OCS2015U04C_MSG_SAVE_FAILED));
                }
            }
            return false;
        }

        /// <summary>
        /// Update bookmark on the Comment treeview
        /// </summary>
        /// <param name="cmt"></param>
        /// <param name="node">Tree node which is being edited</param>
        /// <param name="remove"></param>
        private void UpdateBookMark(CommentInfo cmt, TreeNode node, bool remove)
        {
            CommentInfo comment = node.Tag as CommentInfo;
            if (comment != null && comment.UserId == UserInfo.UserID)
            {
                if (_lstCommentInfos != null && _lstCommentInfos.Count > 0)
                {
                    //foreach (CommentInfo pair in _lstCommentInfos)
                    //{
                    List<CommentInfo> comments = GetCommentById(cmt, _lstCommentInfos);
                    if (comments.Count > 0)
                    {
                        if (remove)
                        {
                            foreach (CommentInfo schema in comments)
                                _lstCommentInfos.Remove(schema);
                        }
                        bool success = SubmitChangedBookMark(_recordId, _lstCommentInfos, node, remove);
                        if (!success && remove) _lstCommentInfos.AddRange(comments);
                    }
                    //}
                }
            }
            else if (comment != null && comment.UserId != UserInfo.UserID)
            {
                XMessageBox.Show(_resources.GetString(Resources.OCS2015U04C_MSG_WRONG_USER_EDITING));
            }
        }

        private List<CommentInfo> GetCommentById(CommentInfo cmt, List<CommentInfo> allItems)
        {
            //HungNV updated
            List<CommentInfo> comments = new List<CommentInfo>();
            foreach (CommentInfo cmInfo in allItems)
            {
                if (cmInfo != null && cmInfo.CommentId == cmt.CommentId)
                {
                    cmInfo.Comment = cmt.Comment;
                    comments.Add(cmInfo);
                }
            }
            return comments;
        }

        ComponentResourceManager _resources = new ComponentResourceManager(typeof(OCS2015U04C));

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (e_Button == MouseButtons.Right)
            {
                if (tvBunho.SelectedNode == null
                    || tvBunho.SelectedNode.Level != 2)  // if not bookmark node, cancel context menu
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private MouseButtons e_Button = MouseButtons.Left;

        private void tvBunho_MouseDown(object sender, MouseEventArgs e)
        {
            tvBunho.SelectedNode = tvBunho.GetNodeAt(e.X, e.Y);
            e_Button = e.Button;
        }
        
        private bool isAsc = true;

        #region button Sort
        //Rem func of button Sort
        private void button1_Click(object sender, EventArgs e)
        {
            if (isAsc)
            {
                if (dt != null && _gwa != "" && _listBookmark != null && _listBookmark.Count > 0 && _patient != null)
                {
                    dt.DefaultView.Sort = "NAEWON_DATE" + " " + "ASC";
                    dt = dt.DefaultView.ToTable();
                    isAsc = !isAsc;
                }
            }
            else
            {
                if (dt != null && _gwa != "" && _listBookmark != null && _listBookmark.Count > 0 && _patient != null)
                {
                    dt.DefaultView.Sort = "NAEWON_DATE" + " " + "DESC";
                    dt = dt.DefaultView.ToTable();
                    isAsc = !isAsc;
                }
            }
            GenerateBookmarkTree(_listBookmark, _gwa, _patient, false);
        }
        #endregion
        
    }

    public class BookmarkEventCArgs : EventArgs
    {
        private readonly CommentInfo _commentInfo;

        private readonly bool _remove;

        public BookmarkEventCArgs(CommentInfo commentInfoParam, bool removeParam)
        {
            _commentInfo = commentInfoParam;
            _remove = removeParam;
        }

        public CommentInfo CommentInfo
        {
            get
            {
                return _commentInfo;
            }
        }

        public bool Remove
        {
            get
            {
                return _remove;
            }
        }
    }
}
