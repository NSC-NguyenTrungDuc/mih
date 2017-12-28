using System.Text;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Word;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.Framework;

namespace NUR2015U01
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using DevExpress.UserSkins;
    using DevExpress.Utils.Menu;
    using DevExpress.XtraBars;
    using DevExpress.XtraRichEdit.API.Native;
    using DevExpress.XtraRichEdit.API.Native.Implementation;
    using DevExpress.XtraRichEdit.Commands.Internal;
    using DevExpress.XtraRichEdit.UI;
    using DevExpress.XtraRichEdit.Utils;

    using GhostscriptSharp;


    using Newtonsoft.Json;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Grid.ViewInfo;
    using IHIS.CloudConnector.Contracts.Results;
    using IHIS.CloudConnector.Contracts.Results.System;
    using IHIS.CloudConnector.Caching;
    public partial class OCS2015U44 : Form
    {
        public RichEditControl Editor
        {
            get { return this.richEditControl; }
        }

        //private EmrViewer _emrViewer;
        //private string _userName = "";
        //private Dictionary<string, int> recordPosition = new Dictionary<string, int>();
        //public string UserName
        //{
        //    get { return _userName; }
        //    set { _userName = value; }
        //}
        //private string _record_id = string.Empty;
        //private string bunho = "";
        //public string Bunho
        //{
        //    get { return bunho; }
        //    set { bunho = value; }
        //}
        //private int _lastRecordOffset = 0;
        //public OCS2015U44()
        //{
        //    InitializeComponent();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="viewer">Reference to EmrViewer</param>
        ///// <param name="pEmrRecordId">ID of modifying EMR record</param>
        //public OCS2015U44(EmrViewer viewer, OCS2015U06EmrRecordInfo emrRecord)
        //    : this()
        //{
        //    _emrViewer = viewer;
        //    this.bunho = _emrViewer.Bunho;
        //    ResetBeforeUse();
        //    LoadEmrRecord(emrRecord);
        //    BindStyles();
        //}


        //public OCS2015U44(OCS2015U06EmrRecordInfo emrRecord)
        //    : this()
        //{
        //    ResetBeforeUse();
        //    LoadEmrRecord(emrRecord);
        //    BindStyles();
        //}

        //private void BindStyles()
        //{
        //    foreach (string tag in DataProvider.Instance.Tags.Keys)
        //    {
        //        ParagraphStyle tagStyle = richEditControl.Document.ParagraphStyles.CreateNew();
        //        tagStyle.Name = tag;
        //        richEditControl.Document.ParagraphStyles.Add(tagStyle);
        //        foreach (string subTag in DataProvider.Instance.Tags[tag])
        //        {
        //            ParagraphStyle subTagStyle = richEditControl.Document.ParagraphStyles.CreateNew();
        //            subTagStyle.Name = String.Format("{0}-{1}", tag, subTag);
        //            richEditControl.Document.ParagraphStyles.Add(subTagStyle);
        //        }
        //    }
        //}

        //private void ResetBeforeUse()
        //{
        //    //this.Editor.CreateNewDocument();
        //    metaDictionary.Clear();
        //}

        //private List<CommentMeta> anRecordComments;

        //private void LoadEmrRecord(OCS2015U06EmrRecordInfo emrRecord)
        //{
        //    JsonSerializerSettings settings = new JsonSerializerSettings();
        //    settings.TypeNameHandling = TypeNameHandling.Objects;
        //    List<CustomMarkSchema> emrMeta = emrRecord.Metadata == null || emrRecord.Metadata.Trim().Length == 0
        //                                         ? new List<CustomMarkSchema>()
        //                                         : Newtonsoft.Json.JsonConvert
        //                                               .DeserializeObject<List<CustomMarkSchema>>(
        //                                                   emrRecord.Metadata,
        //                                                   settings);
        //    List<OCS2015U04EmrRecordLoadBookmarkContentInfo> bookmarkLst = new List<OCS2015U04EmrRecordLoadBookmarkContentInfo>();
        //    Dictionary<string, List<CustomMarkSchema>> emrMetaList = new Dictionary<string, List<CustomMarkSchema>>();
        //    //anRecordComments = LoadMeta(emrMeta, emrRecord.Content, emrRecord.NaewonDate);
        //    anRecordComments = LoadMeta(emrMeta, emrRecord.Content, emrRecord.NaewonDate, emrRecord.RecordId, out bookmarkLst);
        //    emrMetaList.Add(emrRecord.RecordId, emrMeta);

        //    List<Dictionary<string, List<CommentMeta>>> _anRecordComments = new List<Dictionary<string, List<CommentMeta>>>();
        //    Dictionary<string, List<CommentMeta>> _d = new Dictionary<string, List<CommentMeta>>();
        //    _d.Add(emrRecord.RecordId, anRecordComments);
        //    _anRecordComments.Add(_d);
        //    emrRecordId = emrRecord.RecordId;
        //    metadata = emrRecord.Metadata;
        //    //gridControl1.DataSource = bookmarkLst;
        //    this.BindGridComment();
        //}
        //private List<CommentMeta> commentsList;
        //public List<CommentMeta> LoadMeta(List<CustomMarkSchema> emrMeta, string emrXml, string naewonDate, string record_id, out List<OCS2015U04EmrRecordLoadBookmarkContentInfo> bookmarkLst)
        //{
        //    this._record_id = record_id;
        //    OCS2015U04EmrRecordLoadBookmarkContentArgs args = new OCS2015U04EmrRecordLoadBookmarkContentArgs();
        //    args.EmrRecordId = record_id;
        //    OCS2015U04EmrRecordLoadBookmarkContentResult result = CloudService.Instance.Submit<OCS2015U04EmrRecordLoadBookmarkContentResult, OCS2015U04EmrRecordLoadBookmarkContentArgs>(args);

        //    List<CommentMeta> comments = new List<CommentMeta>();
        //    bookmarkLst = new List<OCS2015U04EmrRecordLoadBookmarkContentInfo>();
        //    int positionOffset = 0;
        //    if (richEditControl.Document.Range.End.ToInt() > 0)
        //    {
        //        richEditControl.Document.AppendParagraph();
        //        positionOffset = richEditControl.Document.Range.End.ToInt() - 1;
        //    }
        //    _lastRecordOffset = positionOffset;
        //    string examDate = naewonDate.Replace("/", "-");
        //    if (!recordPosition.ContainsKey(examDate)) recordPosition.Add(examDate, _lastRecordOffset);
        //    byte[] byteArray = Encoding.UTF8.GetBytes(emrXml);
        //    MemoryStream stream = new MemoryStream(byteArray);
        //    richEditControl.Document.BeginUpdate();
        //    richEditControl.Document.AppendDocumentContent(stream, DocumentFormat.WordML);
        //    //HungNV added
        //    if (result.ExecutionStatus == ExecutionStatus.Success)
        //    {
        //        if (result.EmrBookmarkContentList.Count > 0)
        //        {
        //            CommentMeta cmm;
        //            foreach (OCS2015U04EmrRecordLoadBookmarkContentInfo item in result.EmrBookmarkContentList)
        //            {
        //                //Todo
        //                cmm = new CommentMeta(item.BookmarkText.Length, item.UserNm, item.BookmarkText);
        //                richEditControl.Document.CreateCustomMark(richEditControl.Document.CreatePosition(0), JsonConvert.SerializeObject(cmm));
        //                comments.Add(cmm);
        //            }
        //            bookmarkLst = result.EmrBookmarkContentList;
        //        }
        //    }


        //    if (emrMeta != null)
        //    {
        //        for (int i = emrMeta.Count - 1; i >= 0; i--)
        //        {
        //            CustomMarkSchema schema = emrMeta[i];
        //            DocumentPosition pos = richEditControl.Document.CreatePosition(positionOffset + schema.Position);
        //            if (schema.UserData.Type == CustomMarkType.Image)
        //            {
        //                ImageMeta meta = schema.UserData as ImageMeta;
        //                meta.EmrcFilePath = Utilities.ConvertToLocalPath(meta.EmrcFilePath, EnvironInfo.HospCode, this.bunho);
        //                meta.FilePath = Utilities.ConvertToLocalPath(meta.FilePath, EnvironInfo.HospCode, this.bunho);

        //                if (!File.Exists(meta.FilePath)) Utilities.DownloadFile(meta.FilePath, EnvironInfo.HospCode, bunho);
        //                if (meta.EmrcFilePath != null && !File.Exists(meta.EmrcFilePath)) Utilities.DownloadFile(meta.EmrcFilePath, EnvironInfo.HospCode, bunho);
        //                if (File.Exists(meta.FilePath))
        //                {
        //                    FileDocumentImageSource dImg = new FileDocumentImageSource(meta.FilePath);
        //                    DocumentImage img = richEditControl.Document.InsertImage(
        //                        pos,
        //                                                                dImg);
        //                    img.ScaleX = meta.ScaleX;
        //                    img.ScaleY = meta.ScaleY;
        //                    if (!metaDictionary.ContainsKey(meta.Checksum)) metaDictionary.Add(meta.Checksum, meta);
        //                }
        //            }
        //            else if (schema.UserData.Type == CustomMarkType.Pdf)
        //            {
        //                PdfMeta meta = schema.UserData as PdfMeta;
        //                meta.FilePath = Utilities.ConvertToLocalPath(meta.FilePath, EnvironInfo.HospCode, this.bunho);
        //                meta.Thumbnail.FilePath = Utilities.ConvertToLocalPath(meta.Thumbnail.FilePath, EnvironInfo.HospCode, this.bunho);
        //                if (!File.Exists(meta.FilePath)) Utilities.DownloadFile(meta.FilePath, EnvironInfo.HospCode, bunho);
        //                if (!File.Exists(meta.Thumbnail.FilePath)) Utilities.DownloadFile(meta.Thumbnail.FilePath, EnvironInfo.HospCode, bunho);
        //                {
        //                    DocumentImage img = richEditControl.Document.InsertImage(
        //                        pos,
        //                        new FileDocumentImageSource(meta.Thumbnail.FilePath));
        //                    img.ScaleX = meta.Thumbnail.ScaleX;
        //                    img.ScaleY = meta.Thumbnail.ScaleY;
        //                    if (!metaDictionary.ContainsKey(meta.Thumbnail.Checksum)) metaDictionary.Add(meta.Thumbnail.Checksum, meta);
        //                }
        //            }
        //        }
        //    }
        //    richEditControl.Document.EndUpdate();
        //    return comments;
        //}
        //private string emrRecordId = "";
        //private string metadata = "";
        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{

        //}
        //public List<CustomMarkSchema> Save(out string emrXml, bool excudeImage)
        //{
        //    richEditControl.Document.BeginUpdate();
        //    List<CustomMarkSchema> emrMeta = new List<CustomMarkSchema>();

        //    //DoButtonBusiness.RemoveAllPermissions(richEditControl);

        //    if (excudeImage)
        //    {
        //        DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.Range);
        //        int offset = 0;
        //        for (int i = collection.Count - 1; i >= 0; i--)
        //        {
        //            DocumentImage image = collection[i];
        //            string hash = Utilities.CalculateImageChecksum(image.Image);
        //            if (!metaDictionary.ContainsKey(hash))
        //            {
        //                //this is a new image --> save the image to folder                    
        //                //string filePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence("K01") + "." + image.Image.RawFormat);
        //                string filePath = Utilities.GetAbsoluteDataPath(Path.GetFileName(image.Uri), bunho);
        //                FileInfo fileInfo = new FileInfo(filePath);
        //                if (!fileInfo.Exists)
        //                    Directory.CreateDirectory(fileInfo.Directory.FullName);
        //                SaveStreamToFile(filePath, image.Image.GetImageBytesSafe(image.Image.RawFormat));
        //                ImageMeta meta = new ImageMeta(hash, filePath, image.ScaleX, image.ScaleY);
        //                CustomMarkSchema schema = new CustomMarkSchema(image.Range.Start.ToInt(), meta);
        //                emrMeta.Add(schema);
        //                Upload(filePath);
        //            }
        //            else
        //            {
        //                //pdf or old image
        //                UserData userData = metaDictionary[hash];
        //                if (userData is ImageMeta)
        //                {
        //                    ImageMeta meta = userData as ImageMeta;
        //                    meta.ScaleX = image.ScaleX;
        //                    meta.ScaleY = image.ScaleY;

        //                    Upload(meta.FilePath);
        //                }
        //                else if (userData is PdfMeta)
        //                {
        //                    PdfMeta meta = userData as PdfMeta;
        //                    meta.Thumbnail.ScaleX = image.ScaleX;
        //                    meta.Thumbnail.ScaleY = image.ScaleY;
        //                    Upload(meta.FilePath);
        //                    Upload(meta.Thumbnail.FilePath);
        //                }
        //                CustomMarkSchema schema = new CustomMarkSchema(image.Range.Start.ToInt(), userData);
        //                emrMeta.Add(schema);
        //            }
        //            richEditControl.Document.Delete(image.Range);
        //        }
        //    }
        //    else
        //    {
        //        foreach (KeyValuePair<string, UserData> pair in metaDictionary)
        //        {
        //            if (pair.Value is PdfMeta)
        //            {
        //                CustomMarkSchema schema = new CustomMarkSchema(0, pair.Value);
        //                emrMeta.Add(schema);
        //            }
        //        }
        //    }

        //    //comment
        //    foreach (CustomMark customMark in richEditControl.Document.CustomMarks)
        //    {
        //        UserData userData = JsonConvert.DeserializeObject<CommentMeta>(customMark.UserData.ToString());
        //        CustomMarkSchema schema = new CustomMarkSchema(customMark.Position.ToInt(), userData);
        //        emrMeta.Add(schema);
        //    }
        //    emrXml = richEditControl.WordMLText;

        //    richEditControl.Document.EndUpdate();
        //    return emrMeta;
        //}
        //private void Upload(string filePath)
        //{
        //    string uploadAddress = ConfigurationManager.AppSettings["UploadBaseUri"]; //http://10.1.20.149:8010/upload
        //    string uploadToken = ConfigurationManager.AppSettings["UploadToken"]; //"1234"
        //    Uri address = new Uri(uploadAddress);
        //    Utilities.UploadFile(address, filePath, uploadToken, EnvironInfo.HospCode, bunho);
        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //   _emrViewer._mainScreen.CancelSaving(emrRecordId, UserInfo.UserID);
        //    this.Dispose(true);
        //}
        //private void insertCommentItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //DocumentRange range = richEditControl.Document.Selection;
        //    //frmComment frm = new frmComment(0, range.Start.ToInt(), range.Length, String.Empty, true);
        //    //frm.CommentUpdated += new frmComment.CommentUpdateHandler(frm_CommentUpdated);
        //    //frm.ShowDialog(this);
        //}
        //void frm_CommentUpdated(object sender, CommentEventArgs e)
        //{
        //    if (!e.IsNew && !e.Cancel && e.Comment.Trim().Length == 0)
        //    {
        //        //Remove empty comment
        //        for (int i = 0; i < richEditControl.Document.CustomMarks.Count; i++)
        //        {
        //            CustomMark mark = richEditControl.Document.CustomMarks[i];
        //            if (mark.Position.ToInt() == e.Position)
        //            {
        //                //make sure it is correct updating one.
        //                CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
        //                if (meta != null && meta.Id == e.CommentId)
        //                {
        //                    richEditControl.Document.DeleteCustomMark(mark);
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    //Create new customMark for both insert & update
        //    if (e.Comment.Trim().Length > 0)
        //    {
        //        CommentMeta meta = new CommentMeta(e.Length, UserInfo.UserName, e.Comment.Trim(), true);
        //        DocumentPosition pos = richEditControl.Document.CreatePosition(e.Position);
        //        richEditControl.Document.CreateCustomMark(pos, JsonConvert.SerializeObject(meta));
        //    }
        //    BindGridComment();
        //}
        //private void BindGridComment()
        //{
        //    List<CommentMeta> comments = new List<CommentMeta>();
        //    foreach (CustomMark mark in richEditControl.Document.CustomMarks)
        //    {
        //        CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
        //        if (meta != null) comments.Add(meta);
        //    }
        //    gridControl1.DataSource = comments;
        //}
        //private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();
        //private List<MediaData> mediaLst = new List<MediaData>();
        //private void insertPdfItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    DocumentPosition pos = richEditControl.Document.Selection.Start;
        //    OpenFileDialog dialog = new OpenFileDialog();
        //    dialog.Filter = "Jpeg images|*.jpg;*.jpeg;*.Jpeg;*.JPEG|Pdf Files|*.pdf";
        //    dialog.FilterIndex = 1;
        //    dialog.RestoreDirectory = true;

        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string fileName = Utilities.GetFileName(dialog.FileName);
        //        string originalFilePath = dialog.FileName;
        //        string ext = Path.GetExtension(dialog.FileName);

        //        if (ext.ToLower() == ".pdf")
        //        {

        //            string pdfLink = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(bunho, Path.GetFileName(originalFilePath), "pdf"), bunho);
        //            File.Copy(originalFilePath, pdfLink);

        //            string pdfHash = Utilities.CalculateFileChecksum(pdfLink);
        //            string thumbnailFilePath;

        //            FileDocumentImageSource image = GetPdfThumbnail(pdfLink, out thumbnailFilePath);
        //            string thumbnailHash = Utilities.CalculateImageChecksum(image.Stream);
        //            string testHash = Utilities.CalculateImageChecksum(File.OpenRead(thumbnailFilePath));
        //            if (!metaDictionary.ContainsKey(thumbnailHash))
        //                metaDictionary.Add(thumbnailHash, new PdfMeta(pdfHash, pdfLink, new ImageMeta(thumbnailHash, thumbnailFilePath, 0.25f, 0.25f)));
        //            //push pdf info to media list
        //            mediaLst.Add(new MediaData(Utilities.GetFileName(pdfLink), pdfLink, Path.GetExtension(pdfLink), string.Empty, originalFilePath, Utilities.CalculateFileChecksum(pdfLink), true));
        //            mediaLst.Add(new MediaData(Utilities.GetFileName(thumbnailFilePath), thumbnailFilePath, Path.GetExtension(thumbnailFilePath), string.Empty, thumbnailFilePath, thumbnailHash, true));

        //            richEditControl.Document.BeginUpdate();
        //            DocumentImage docImage = richEditControl.Document.InsertImage(pos, new FileDocumentImageSource(thumbnailFilePath));
        //            docImage.ScaleX = 0.25f;
        //            docImage.ScaleY = 0.25f;
        //            docImage.Uri = thumbnailFilePath;
        //            richEditControl.Document.EndUpdate();
        //        }
        //        else if (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg")
        //        {
        //            richEditControl.Document.BeginUpdate();
        //            string filePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(bunho, Path.GetFileName(originalFilePath), Path.GetExtension(originalFilePath)), bunho);
        //            DocumentImage docImage = richEditControl.Document.InsertImage(pos, new FileDocumentImageSource(originalFilePath));
        //            //push new media to media list
        //            mediaLst.Add(new MediaData(fileName, filePath, ext, string.Empty, originalFilePath, Utilities.CalculateImageChecksum(File.OpenRead(originalFilePath)), true));
        //            docImage.Uri = dialog.FileName;
        //            richEditControl.Document.EndUpdate();
        //        }
        //    }
        //}
        //private FileDocumentImageSource GetPdfThumbnail(string pdfFilePath, out string thumbnailFilePath)
        //{
        //    //thumbnailFilePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence("K01") + ".jpeg");
        //    thumbnailFilePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(bunho, Path.GetFileName(pdfFilePath), "jpeg"), bunho);
        //    GhostscriptWrapper.GeneratePageThumb(pdfFilePath, thumbnailFilePath, 1, 24, 24);
        //    return new FileDocumentImageSource(thumbnailFilePath);
        //}
        //private void SaveStreamToFile(string fileFullPath, byte[] data)
        //{
        //    if (data.Length == 0) return;
        //    // Create a FileStream object to write a stream to a file
        //    using (FileStream fileStream = File.Create(fileFullPath, data.Length))
        //    {
        //        // Use FileStream object to write to the specified file
        //        fileStream.Write(data, 0, data.Length);
        //    }
        //}
        //private void richEditControl_DoubleClick(object sender, EventArgs e)
        //{

        //    DocumentImageCollection imgCollection = richEditControl.Document.GetImages(richEditControl.Document.Selection);
        //    if (imgCollection != null && imgCollection.Count > 0)
        //    {
        //        string imageHash = Utilities.CalculateImageChecksum(imgCollection[0].Image);
        //        if (metaDictionary.ContainsKey(imageHash))
        //        {
        //            if (metaDictionary[imageHash] is PdfMeta)
        //            {
        //                PdfMeta meta = metaDictionary[imageHash] as PdfMeta;
        //                Process.Start(meta.FilePath);
        //            }
        //            else
        //            {
        //                ImageMeta meta = metaDictionary[imageHash] as ImageMeta;
        //                if (meta != null)
        //                {
        //                    if (!DoButtonBusiness.CheckIfNonDolImage(meta))
        //                    {
        //                        EditImage(imgCollection[0]);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (!DoButtonBusiness.CheckIfNonDolImage(imgCollection[0]))
        //            {
        //                EditImage(imgCollection[0]);
        //            }
        //        }
        //    }
        //}
        //private void EditImage(DocumentImage image)
        //{

        //    string filePath = Utilities.GetAbsoluteDataPath(Path.GetFileName(image.Uri) + "temp" + "." + image.Image.RawFormat, bunho);
        //    FileInfo fileInfo = new FileInfo(filePath);
        //    if (!fileInfo.Exists)
        //        Directory.CreateDirectory(fileInfo.Directory.FullName);
        //    SaveStreamToFile(filePath, image.Image.GetImageBytesSafe(image.Image.RawFormat));

        //    DataProvider.ImageEditorInstance.Edit(
        //        filePath, image.ScaleX, image.ScaleY,
        //        delegate(byte[] data, float scaleX, float scaleY)
        //        {
        //            richEditControl.Document.BeginUpdate();
        //            richEditControl.Document.Delete(image.Range);
        //            DocumentImage docImage = richEditControl.Document.InsertImage(
        //                richEditControl.Document.CaretPosition,
        //                new StreamDocumentImageSource(new MemoryStream(data)));
        //            docImage.ScaleX = scaleX;
        //            docImage.ScaleY = scaleY;
        //            richEditControl.Document.EndUpdate();
        //            mediaLst.Add(new MediaData(Utilities.GetFileName(filePath), filePath, Path.GetExtension(filePath), string.Empty, filePath, Utilities.CalculateImageChecksum(File.OpenRead(filePath)), false));
        //        }, this);
        //}
        //private void gridView1_DoubleClick(object sender, EventArgs e)
        //{
        //    //GridView view = (GridView)sender;
        //    //Point pt = view.GridControl.PointToClient(Control.MousePosition);
        //    //DoRowDoubleClick(view, pt);
        //}

        //private CommentMeta editingComment;
        //private void DoRowDoubleClick(GridView view, Point pt)
        //{

        //    GridHitInfo info = view.CalcHitInfo(pt);
        //    //CommentRowCell cell = info.HitTest

        //    if (info.InRow || info.InRowCell)
        //    {
        //        CommentMeta cmt = view.GetRow(info.RowHandle) as CommentMeta;
        //        // Check if user who has created bookmark can only modify his bookmark
        //        if (cmt != null
        //            && cmt.Author.Trim().Equals(UserInfo.UserName.Trim()))
        //        {
        //            editingComment = cmt;
        //            frmComment frm = new frmComment(0, 0, cmt.Length, cmt.Comment, false);
        //            frm.CommentUpdated -= frm_CommentUpdated;
        //            frm.CommentUpdated += frm_CommentUpdated;
        //            frm.ShowDialog();
        //        }

        //    }

        //}
        //private void gridView1_KeyDown(object sender, KeyEventArgs e)
        //{

        //}
        //private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Delete && gridView1.State == GridState.Normal)
        //    {
        //        int i = gridView1.FocusedRowHandle;
        //        CommentMeta curRow = gridView1.GetRow(i) as CommentMeta;
        //        List<CustomMark> delList = new List<CustomMark>();
        //        if (curRow.Author == UserInfo.UserName)
        //        {
        //            //lstMeta.RemoveAt(i);
        //            List<CommentMeta> comments = new List<CommentMeta>();
        //            foreach (CustomMark mark in richEditControl.Document.CustomMarks)
        //            {
        //                CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
        //                if (meta != null
        //                    && meta.Author == curRow.Author
        //                    && meta.Comment == curRow.Comment
        //                    && meta.Id == curRow.Id
        //                    && meta.Length == curRow.Length)
        //                {
        //                    //richEditControl.Document.DeleteCustomMark(mark);
        //                    delList.Add(mark);
        //                }
        //                else
        //                {
        //                    comments.Add(meta);
        //                }
        //            }
        //            foreach (CustomMark customMark in delList)
        //            {
        //                richEditControl.Document.DeleteCustomMark(customMark);
        //            }
        //            gridControl1.DataSource = comments;
        //        }

        //    }
        //}
        //private string prevSelectedItem = "";
        //private void cboTemplate_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (prevSelectedItem.Trim() == "")
        //    {
        //        BarEditItem item = (BarEditItem)sender;
        //        if (item.EditValue != null && item.EditValue.ToString().Trim().Length > 0)
        //        {
        //            string s = item.EditValue.ToString();
        //            List<TemplateMeta> _templateList = OCS2015U09Businesses.GetTemplateList();

        //            try
        //            {
        //                TemplateMeta template = _templateList.Find(delegate(TemplateMeta meta)
        //                {
        //                    return meta.EmrTemplateId == s ? true : false;
        //                });
        //                foreach (KeyValuePair<string, string> keyValuePair in template.TagList)
        //                {
        //                    this.richEditControl.Document.AppendText(keyValuePair.Value);
        //                    this.richEditControl.Document.AppendParagraph();
        //                }
        //                //Insert values for oldTemplate and pre-fill for new template
        //                OCS2015U09Businesses.SuggestValueForNewTemplate(null, template, this.bunho, this.richEditControl);
        //            }
        //            catch (NullReferenceException ex) // when user types in absent template code, do nothing
        //            {

        //                //this.richEditControl.Document.Text = "";
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }

        //            prevSelectedItem = item.EditValue.ToString().Trim() != "" ? item.EditValue.ToString().Trim() : "";
        //        }
        //    }
        //    else if (prevSelectedItem.Trim() != "")
        //    {
        //        BarEditItem item = (BarEditItem)sender;
        //        if (item.EditValue != null && item.EditValue.ToString().Trim().Length > 0)
        //        {
        //            string s = item.EditValue.ToString();
        //            List<TemplateMeta> _templateList = OCS2015U09Businesses.GetTemplateList();

        //            try
        //            {
        //                TemplateMeta oldTemplate = _templateList.Find(delegate(TemplateMeta meta)
        //                {
        //                    return meta.EmrTemplateId == prevSelectedItem ? true : false;
        //                });
        //                // clear old tags
        //                richEditControl.Document.BeginUpdate();
        //                foreach (KeyValuePair<string, string> pair in oldTemplate.TagList)
        //                {
        //                    if (pair.Value != "")
        //                    {
        //                        ISearchResult searchResult = richEditControl.Document.StartSearch(pair.Value,
        //                                                SearchOptions.CaseSensitive, SearchDirection.Forward, richEditControl.Document.Range);
        //                        while (searchResult.FindNext())
        //                        {
        //                            searchResult.Replace(String.Empty);
        //                        }
        //                    }
        //                }
        //                richEditControl.Document.EndUpdate();

        //                TemplateMeta template = _templateList.Find(delegate(TemplateMeta meta)
        //                {
        //                    return meta.EmrTemplateId == s ? true : false;
        //                });

        //                richEditControl.Document.BeginUpdate();
        //                foreach (KeyValuePair<string, string> pair in template.TagList)
        //                {
        //                    if (pair.Value != "")
        //                    {
        //                        ISearchResult searchResult = richEditControl.Document.StartSearch(pair.Value,
        //                                                SearchOptions.CaseSensitive, SearchDirection.Forward, richEditControl.Document.Range);
        //                        while (searchResult.FindNext())
        //                        {
        //                            searchResult.Replace(pair.Value);
        //                        }
        //                    }
        //                }
        //                richEditControl.Document.EndUpdate();
        //                OCS2015U09Businesses.SuggestValueForNewTemplate(oldTemplate, template, this.bunho, this.richEditControl);

        //                foreach (KeyValuePair<string, string> keyValuePair in template.TagList)
        //                {
        //                    this.richEditControl.Document.AppendText(keyValuePair.Value);
        //                    this.richEditControl.Document.AppendParagraph();
        //                }
        //            }
        //            catch (NullReferenceException ex)
        //            {

        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }

        //            prevSelectedItem = item.EditValue.ToString().Trim() != "" ? item.EditValue.ToString().Trim() : "";
        //        }
        //    }


        //}
        //private string _naewonDate = string.Empty;
        //public string NaewonDate
        //{
        //    get { return _naewonDate; }
        //    set { _naewonDate = value; }
        //}
        //private string _naewonKey = string.Empty;
        //public string NaewonKey
        //{
        //    get { return _naewonKey; }
        //    set { _naewonKey = value; }
        //}
        //private const string CACHE_EMR_RECORD_SCHEMA_PATTERN_U44 = "CACHE_EMR_RECORD_SCHEMA_U44_{0}_{1}_{2}";
        //private void btnUpdateEmrRecord_Click(object sender, EventArgs e)
        //{
        //    OCS2015U42 frmOCS2015U42 = new OCS2015U42(this);
        //    //Show OCS2015U42 popup to add comment
        //    System.Windows.Forms.DialogResult dialogResult = frmOCS2015U42.ShowDialog();
        //    string emailFlg = frmOCS2015U42.EmailCheckBox.Checked ? "1" : "0";

        //    if (dialogResult == DialogResult.Cancel)
        //    {
        //        frmOCS2015U42.Close();
        //        CancelSaving(this._record_id, UserInfo.UserID);
        //        mediaLst.Clear();
        //        return;
        //    }
        //    if (this.richEditControl.Document.Paragraphs.Count > 0)
        //    {
        //        byte[] byteArray = Encoding.UTF8.GetBytes(richEditControl.WordMLText);
        //        List<Image> images = DoButtonBusiness.GenerateDoButtonListFromOrders(DoButtonBusiness.OrderData, _emrViewer.NaewonDate, _emrViewer.NaewonKey, _emrViewer.RecordContent);
        //        string emrXml;
        //        List<CustomMarkSchema> schema = this.Save(out emrXml);

        //        JsonSerializerSettings setting = new JsonSerializerSettings();
        //        setting.TypeNameHandling = TypeNameHandling.Objects;
        //        string meta = JsonConvert.SerializeObject(schema, setting);

        //        if (CloudService.Instance.Connect())
        //        {
        //            string recordLog = frmOCS2015U42.TxtRecordLog.Text.Trim();
        //            OCS2015U44EmrHistoricRecordUpdateArgs args = new OCS2015U44EmrHistoricRecordUpdateArgs();
        //            args.Content = emrXml;
        //            args.Metadata = meta;
        //            args.RecordId = this._record_id;
        //            args.RecordLog = recordLog.Length > 128 ? recordLog.Trim().Substring(0, 128) : recordLog.Trim(); // limit 128 characters
        //            args.UpdId = UserInfo.UserID;
        //            args.EmailFlg = emailFlg;
        //            UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS2015U44EmrHistoricRecordUpdateArgs>(args);
        //            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
        //            {
        //                if (UpdateEmrViewer != null)
        //                    UpdateEmrViewer(this);//Reload data of the Emr viewer
        //                XMessageBox.Show(Resources.CMO_M005, string.Empty, MessageBoxIcon.Information);
        //                //frmOCS2015U42.Close();
        //                this.Close();
        //            }
        //            else
        //            {
        //                XMessageBox.Show(Resources.CMO_M006, string.Empty, MessageBoxIcon.Asterisk);
        //            }
        //        }
        //    }
        //    mediaLst.Clear();
        //}

        //public static void CancelSaving(string emrRecordId, string updId)
        //{
        //    //TODO: unlock record, need proto here
        //    if (CloudService.Instance.Connect())
        //    {
        //        OCS2015U00EmrRecordUnlockArgs args = new OCS2015U00EmrRecordUnlockArgs();
        //        args.RecordId = emrRecordId;
        //        args.UpdId = updId;
        //        args.ScreenId = "OCS2015U06";
        //        UpdateResult res =
        //            CloudService.Instance.Submit<UpdateResult, OCS2015U00EmrRecordUnlockArgs>(args);
        //        if (res.ExecutionStatus == ExecutionStatus.Success)
        //        {
        //            if (res.Result)
        //            {
        //            }
        //            else
        //            {
        //            }
        //        }
        //    }

        //    //Case 1: Valid current user = UPD_ID, timeout in-range
        //    //Case 2: Valid current user = UPD_ID, timeout out-range

        //    //Case 3,4 occur when another user successfully grab lock because of current user has timed out
        //    //Case 3: Invalid current user != UPD_ID, timeout in-range
        //    //Case 4: Invalid current user != UPD_ID, timeout out-range
        //}

        //private void ClearEmrCache(string doctor, string naewon_key, string naewonDate)
        //{
        //    string schemaKey = string.Format(CACHE_EMR_RECORD_SCHEMA_PATTERN_U44, doctor, naewon_key, naewonDate);
        //    string dataKey = string.Format(CACHE_EMR_RECORD_SCHEMA_PATTERN_U44, doctor, naewon_key, naewonDate);
        //    CacheService.Instance.Remove(schemaKey);
        //    CacheService.Instance.Remove(dataKey);
        //}
        //public List<CustomMarkSchema> Save(out string emrXml)
        //{
        //    return SaveData(out emrXml, true);
        //}
        //public List<CustomMarkSchema> SaveData(out string emrXml, bool excudeImage)
        //{
        //    richEditControl.Document.BeginUpdate();
        //    List<CustomMarkSchema> emrMeta = new List<CustomMarkSchema>();
        //    DoButtonBusiness.RemoveAllPermissions(richEditControl);

        //    if (excudeImage)
        //    {
        //        DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.Range);
        //        int offset = 0;
        //        DocumentImage image;
        //        string filePath = string.Empty;
        //        FileInfo fileInfo;
        //        PdfMeta metaPdf;
        //        ImageMeta metaImg;
        //        CustomMarkSchema schema;
        //        UserData userData;
        //        for (int i = collection.Count - 1; i >= 0; i--)
        //        {
        //            image = collection[i];
        //            string hash = Utilities.CalculateImageChecksum(image.Image);
        //            if (!metaDictionary.ContainsKey(hash))//Upload nomarl images file (not the thumbnail of pdf file)
        //            {
        //                //this is a new image --> save the image to local folder      
        //                filePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(bunho, Path.GetFileName(image.Uri), image.Image.RawFormat.ToString()), bunho);
        //                fileInfo = new FileInfo(filePath);
        //                if (!fileInfo.Exists)
        //                    Directory.CreateDirectory(fileInfo.Directory.FullName);
        //                SaveStreamToFile(filePath, image.Image.GetImageBytesSafe(image.Image.RawFormat));
        //                metaImg = new ImageMeta(hash, filePath, image.ScaleX, image.ScaleY);
        //                schema = new CustomMarkSchema(image.Range.Start.ToInt(), metaImg);
        //                emrMeta.Add(schema);
        //                //if exist in mediaLst => new file=> upload file to server
        //                if (this.IsNewMediaData(Utilities.CalculateFileChecksum(filePath)))
        //                    Upload(filePath);
        //            }
        //            else// Upload pdf and thumbnail images file
        //            {
        //                userData = metaDictionary[hash];
        //                if (userData is PdfMeta)
        //                {
        //                    metaPdf = userData as PdfMeta;
        //                    metaPdf.Thumbnail.ScaleX = image.ScaleX;
        //                    metaPdf.Thumbnail.ScaleY = image.ScaleY;
        //                    //Upload pdf file to server
        //                    if (this.IsNewMediaData(Utilities.CalculateFileChecksum(metaPdf.FilePath)))
        //                        Upload(metaPdf.FilePath);
        //                    //Upload thumbnail of the pdf file to server
        //                    if (this.IsNewMediaData(Utilities.CalculateFileChecksum(metaPdf.Thumbnail.FilePath)))
        //                        Upload(metaPdf.Thumbnail.FilePath);
        //                }
        //                schema = new CustomMarkSchema(image.Range.Start.ToInt(), userData);
        //                emrMeta.Add(schema);
        //            }
        //            richEditControl.Document.Delete(image.Range);
        //        }
        //    }
        //    else
        //    {
        //        foreach (KeyValuePair<string, UserData> pair in metaDictionary)
        //        {
        //            if (pair.Value is PdfMeta)
        //            {
        //                CustomMarkSchema schema2 = new CustomMarkSchema(0, pair.Value);
        //                emrMeta.Add(schema2);
        //            }
        //        }
        //    }

        //    emrXml = richEditControl.WordMLText;
        //    richEditControl.Document.EndUpdate();
        //    return emrMeta;
        //}

        ///// <summary>
        ///// Check new file or files were updated
        ///// </summary>
        ///// <param name="hashCode"></param>
        ///// <returns></returns>
        //public bool IsNewMediaData(string hashCode)
        //{
        //    foreach (MediaData item in mediaLst)
        //    {
        //        if (item.CheckSum == hashCode)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public delegate void ReloadEmrViewerHandler(object sender);
        //public event ReloadEmrViewerHandler UpdateEmrViewer;

        //private KeyValuePair<CommentMeta, TreeNode> editingNode = new KeyValuePair<CommentMeta, TreeNode>(null, null);
        //private void EditBookMark(CommentMeta comment, TreeNode node)
        //{
        //    if (comment != null)
        //    {
        //        editingNode = new KeyValuePair<CommentMeta, TreeNode>(comment, node);
        //        frmComment frm = new frmComment(0, 0, comment.Length, comment.Comment, false);
        //        frm.CommentUpdated += UpdateComment;
        //        frm.ShowDialog();
        //    }
        //}

        //void UpdateComment(object sender, CommentEventArgs e)
        //{
        //    if (editingNode.Key != null && editingNode.Value != null)
        //    {
        //        if (e.Comment.Trim().Length > 0
        //            && e.Comment.Trim().Length <= 128)
        //        {
        //            editingNode.Key.Comment = e.Comment;
        //            editingNode.Value.Text = e.Comment;
        //            UpdateBookMark(editingNode.Key, editingNode.Value, false);
        //            tvBunho.Refresh();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Comment content length must be greater than 0 and lower 128");
        //        }
        //    }
        //}
    }

    public class MediaData
    {
        private string _fileName;
        private string _filePath;
        private string _originalFilePath;
        private string _fileExtension;
        private string _fileType;
        private bool _isInsert;
        private string _checkSum;
        public string FileName
        {
            get { return this._fileName; }
            set { this._fileName = value; }
        }
        public string FilePath
        {
            get { return this._filePath; }
            set { this._filePath = value; }
        }
        public string FileExtension
        {
            get { return this._fileExtension; }
            set { this._fileExtension = value; }
        }
        public string FileType
        {
            get { return this._fileType; }
            set { this._fileType = value; }
        }

        public string OriginalFilePath
        {
            get { return this._originalFilePath; }
            set { this._originalFilePath = value; }
        }
        public bool IsInsert
        {
            get { return this._isInsert; }
            set { this._isInsert = value; }
        }

        public string CheckSum
        {
            get { return this._checkSum; }
            set { this._checkSum = value; }
        }

        public MediaData(string fileName, string filePath, string fileExtension, string fileType, string originalFilePath, string checkSum, bool isInsert)
        {
            this.FileName = fileName;
            this.FilePath = filePath;
            this.FileExtension = fileExtension;
            this.FileType = fileType;
            this.IsInsert = isInsert;
            this.OriginalFilePath = originalFilePath;
            this.CheckSum = checkSum;
        }
    }
}
