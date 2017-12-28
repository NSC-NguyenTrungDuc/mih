using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit.Layout.Export;
using EmrDocker;
using EmrDocker.Meta;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.OCSO
{
    using System.Diagnostics;
    using System.IO;

    using DevExpress.XtraBars;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraRichEdit;
    using DevExpress.XtraRichEdit.API.Native;
    using DevExpress.XtraRichEdit.API.Native.Implementation;
    using global::EmrDocker.Glossary;
    using global::EmrDocker.Types;
    using IHIS.OCSO.Meta;

    using Newtonsoft.Json;
    using IHIS.Framework;
    using IHIS.CloudConnector.Contracts.Models.OcsEmr;
    using MedicalInterface;

    public partial class EmrViewer : UserControl
    {
        private Dictionary<string, string> displayedTags = new Dictionary<string, string>();

        private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();

        private List<CustomMarkSchema> currentEmrMeta = new List<CustomMarkSchema>();

        private string currentEmrWordMl;
        private List<Tuple<int, UserData>> currentCustomMarks = new List<Tuple<int, UserData>>();

        public Dictionary<string, UserData> MetaDictionary
        {
            get { return metaDictionary; }
        }

        private Dictionary<string, int> recordPosition = new Dictionary<string, int>();
        public IMainScreen _mainScreen;
        private string _naewonDate = string.Empty;
        public string NaewonDate
        {
            get { return _naewonDate; }
            set { _naewonDate = value; }
        }
        private string _naewonKey = string.Empty;
        public string NaewonKey
        {
            get { return _naewonKey; }
            set { _naewonKey = value; }
        }
        public RichEditControl RecordContent
        {
            get { return this.richEditControl; }
        }

        public EmrViewer()
        {
            InitializeComponent();

            BindCombo();

            InitOtherControls();

            this.richEditControl.Options.TableOptions.GridLines = RichEditTableGridLinesVisibility.Hidden;

            this.richEditControl.Options.HorizontalScrollbar.Visibility = RichEditScrollbarVisibility.Visible;
        }

        /// <summary>
        /// Init value for combo Order types, Display
        /// </summary>
        private void InitOtherControls()
        {
            RepositoryItemComboBox cboOrder = (RepositoryItemComboBox)cbOrderType.Edit;
            cboOrder.Items.Add(""); // default all order types
            OCS2015U06OrderTypeComboArgs args = new OCS2015U06OrderTypeComboArgs();
            OCS2015U06OrderTypeComboResult result =
                CloudService.Instance.Submit<OCS2015U06OrderTypeComboResult, OCS2015U06OrderTypeComboArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS2015U06OrderTypeComboInfo item in result.OrderTypes)
                {
                    if (!item.CodeName.Trim().Equals(""))
                    {
                        cboOrder.Items.Add(item.CodeName);
                    }
                }
            }


            DataProvider.Instance.TagDisplayModeSetup(cbDisplay);
        }


        public EmrViewer(IMainScreen main_screen)
            : this()
        {
            this._mainScreen = main_screen;
        }
        private void BindCombo()
        {
            BindMenu(barTag1, barSubTag1);
        }

        private void BindMenu(BarEditItem barTag, BarEditItem barSubTag)
        {
            RepositoryItemComboBox cboTag = (RepositoryItemComboBox)barTag.Edit;
            RepositoryItemComboBox cboSubTag = (RepositoryItemComboBox)barSubTag.Edit;
            cboSubTag.Items.Clear();
            cboTag.Items.Clear();
            cboTag.Items.Add("");
            DataProvider.Instance.ReloadLatestTags();
            foreach (string tag in DataProvider.Instance.Tags.Keys)
            {
                cboTag.Items.Add(tag);
            }
            barTag.EditValueChanged += new EventHandler(barTag_EditValueChanged);
            barSubTag.EditValueChanged += new EventHandler(barSubTag_EditValueChanged);
        }

        void barSubTag_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();
            this.PutToDisplayedTags(barTag, tag);
            ShowHideTag();
            EnableCbDisplay();
        }

        private void EnableCbDisplay()
        {
            cbDisplay.Enabled = (barTag1.EditValue == null || string.IsNullOrEmpty(barTag1.EditValue.ToString()))
                                && (cbOrderType.EditValue == null
                                    || string.IsNullOrEmpty(cbOrderType.EditValue.ToString()));
        }

        private void PutToDisplayedTags(BarEditItem barTag, string tag)
        {
            if (tag != null && tag.Trim().Length > 0)
            {
                if (!this.displayedTags.ContainsKey(barTag.Name))
                {
                    this.displayedTags.Add(barTag.Name, tag.Trim());
                }
                else
                {
                    this.displayedTags[barTag.Name] = tag.Trim();
                }
            }
            else
            {
                displayedTags.Remove(barTag.Name);
            }
        }

        void barTag_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();
            this.PutToDisplayedTags(barTag, tag);
            bool putSubTag = DataProvider.Instance.Tags.ContainsKey(tag);

            string barSubTagName = barTag.Name.Replace("barTag", "barSubTag");
            foreach (BarItemLink item in tagBar.ItemLinks)
            {
                if (item.Item.Name.Equals(barSubTagName))
                {
                    ((BarEditItem)item.Item).EditValue = "";
                    RepositoryItemComboBox cboSubTag = (RepositoryItemComboBox)((BarEditItemLink)item).Edit;
                    cboSubTag.Items.Clear();
                    if (putSubTag)
                    {
                        foreach (string subTag in DataProvider.Instance.Tags[tag])
                        {
                            cboSubTag.Items.Add(String.Format("{0}-{1}", tag, subTag));
                            //cboSubTag.Items.Add(String.Format("{0}", subTag));
                        }
                    }
                }
            }

            ShowHideTag();
            EnableCbDisplay();
        }

        private void ShowHideTag()
        {
            List<string> supportedTags = new List<string>();
            supportedTags.AddRange(displayedTags.Values);
            List<string> allTags = DataProvider.Instance.AllTags;

            foreach (ParagraphStyle style in richEditControl.Document.ParagraphStyles)
            {
                if (allTags.Contains(style.Name))
                {
                    style.Hidden = supportedTags.Count > 0 && !supportedTags.Contains(style.Name);
                }
                else
                {
                    style.Hidden = supportedTags.Count > 0;
                }
            }

            /*if ((barTag1.EditValue != null && !string.IsNullOrEmpty(barTag1.EditValue.ToString()))
                || (barSubTag1.EditValue != null && !string.IsNullOrEmpty(barSubTag1.EditValue.ToString())))
            {
                ShowTableLine(false);
            }
            else
            {
                ShowTableLine(true);
            }*/

            ShowHideByOrderType(cbOrderType.EditValue == null ? string.Empty : cbOrderType.EditValue.ToString());
        }

        public void ShowTableLine(bool show)
        {
            TableBorderLineStyle lineStyle = show ? TableBorderLineStyle.Single : TableBorderLineStyle.None;
            foreach (Table table in richEditControl.Document.Tables)
            {
                table.Borders.Bottom.LineStyle = lineStyle;
                table.Borders.InsideHorizontalBorder.LineStyle = lineStyle;
                table.Borders.InsideVerticalBorder.LineStyle = lineStyle;
                table.Borders.Top.LineStyle = lineStyle;
                table.Borders.Right.LineStyle = lineStyle;
                table.Borders.Left.LineStyle = lineStyle;
            }
        }

        public Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private int _lastRecordOffset = 0;

        public TemplateBind GetLastEmrTagData()
        {
            TemplateBind content = new TemplateBind();
            foreach (Paragraph paragraph in richEditControl.Document.Paragraphs)
            {
                if (paragraph.Range.Start.ToInt() >= _lastRecordOffset)
                {
                    if (paragraph.Style.Name.Equals("S"))
                    {
                        content.S.Add(richEditControl.Document.GetWordMLText(paragraph.Range));
                    }
                    else if (paragraph.Style.Name.Equals("O"))
                    {
                        content.O.Add(richEditControl.Document.GetWordMLText(paragraph.Range));
                    }
                    else if (paragraph.Style.Name.Equals("A"))
                    {
                        content.A.Add(richEditControl.Document.GetWordMLText(paragraph.Range));
                    }
                    else if (paragraph.Style.Name.Equals("P"))
                    {
                        content.P.Add(richEditControl.Document.GetWordMLText(paragraph.Range));
                    }
                    else if (paragraph.Style.Name.Equals("MI"))
                    {
                        content.MI.Add(richEditControl.Document.GetWordMLText(paragraph.Range));
                    }
                    else if (paragraph.Style.Name.Equals("MA"))
                    {
                        content.MA.Add(richEditControl.Document.GetWordMLText(paragraph.Range));
                    }
                    else if (paragraph.Style.Name.Equals("MS"))
                    {
                        content.MS.Add(richEditControl.Document.GetWordMLText(paragraph.Range));
                    }
                }
            }
            return content;
        }

        public void LoadMeta(List<CustomMarkSchema> emrMeta, string emrXml, string recordId)
        {
            this._recordId = recordId;
            LoadMeta(emrMeta, emrXml, this._naewonDate, recordId);
        }

        public List<CommentMeta> LoadMeta(List<CustomMarkSchema> emrMeta, string emrXml, string naewonDate, string recordId)
        {
            this._recordId = recordId;
            this.currentEmrMeta = emrMeta;            
            List<CommentMeta> comments = new List<CommentMeta>();
            //richEditControl.LoadDocument(GenerateStreamFromString(emrXml), DocumentFormat.WordML);
            int positionOffset = 0;
            if (richEditControl.Document.Range.End.ToInt() > 0)
            {
                //richEditControl.Document.AppendParagraph();
                //always -2 because of it has alreadly append " " for both Viewer & Editor
                positionOffset = richEditControl.Document.Range.End.ToInt() - 2;
            }
            _lastRecordOffset = positionOffset;
            string examDate = naewonDate.Replace("/", "-");
            if (!recordPosition.ContainsKey(examDate)) recordPosition.Add(examDate, _lastRecordOffset);
            byte[] byteArray = Encoding.UTF8.GetBytes(emrXml);
            MemoryStream stream = new MemoryStream(byteArray);
            richEditControl.Document.BeginUpdate();
            richEditControl.Document.AppendDocumentContent(stream, DocumentFormat.WordML);

            foreach (CustomMarkSchema schema in emrMeta)
            {
                DocumentPosition pos = richEditControl.Document.CreatePosition(positionOffset + schema.Position >= 0 ? positionOffset + schema.Position : 0); 
                CommentMeta meta = schema.UserData as CommentMeta;
                if (meta != null && schema.Position < richEditControl.Document.Range.End.ToInt())
                {
                    richEditControl.Document.CreateCustomMark(pos, meta);
                    if(meta.IsStart) comments.Add(meta); //We only need add comment for start customMark only
                }

                ParagraphMarker marker = schema.UserData as ParagraphMarker;
                if (marker != null && schema.Position < richEditControl.Document.Range.End.ToInt())
                {
                    richEditControl.Document.CreateCustomMark(pos, marker);
                }

                EmrMarkerMeta examDateStartMark = schema.UserData as EmrMarkerMeta;
                if (examDateStartMark != null && schema.Position <= richEditControl.Document.Range.End.ToInt())
                {
                    if (pos.ToInt() >= richEditControl.Document.Range.Start.ToInt() && pos.ToInt() < richEditControl.Document.Range.End.ToInt())
                    {
                        richEditControl.Document.CreateCustomMark(pos, examDateStartMark); 
                    }
                    else if (pos.ToInt() == richEditControl.Document.Range.End.ToInt())
                    {
                        richEditControl.Document.CreateCustomMark(richEditControl.Document.CreatePosition(pos.ToInt() - 1), examDateStartMark); 
                    }
                }
            }            


            if (emrMeta != null)
            {
                for (int i = emrMeta.Count - 1; i >= 0; i--)
                {
                    CustomMarkSchema schema = emrMeta[i];
                    if(schema.Position > richEditControl.Document.Range.End.ToInt()) continue;                    
                    DocumentPosition pos = richEditControl.Document.CreatePosition(positionOffset + schema.Position >= 0 ? positionOffset + schema.Position : 0);   // custom mark position always be greater or equal zero                 
                    if (schema.UserData.Type == CustomMarkType.Image)
                    {
                        ImageMeta meta = schema.UserData as ImageMeta;
                        meta.EmrcFilePath = Utilities.ConvertToLocalPath(meta.EmrcFilePath, UserInfo.HospCode, Bunho);
                        meta.FilePath = Utilities.ConvertToLocalPath(meta.FilePath, UserInfo.HospCode, Bunho);
                        if (!File.Exists(meta.FilePath)) Utilities.DownloadFile(meta.FilePath, UserInfo.HospCode, Bunho);
                        if (meta.EmrcFilePath != null && !File.Exists(meta.EmrcFilePath)) Utilities.DownloadFile(meta.EmrcFilePath, UserInfo.HospCode, Bunho);
                        if (File.Exists(meta.FilePath))
                        {
                            FileDocumentImageSource dImg = new FileDocumentImageSource(meta.FilePath);
                            DocumentImage img = richEditControl.Document.InsertImage(pos,dImg);
                            img.ScaleX = meta.ScaleX;
                            img.ScaleY = meta.ScaleY;                           
                            if (!metaDictionary.ContainsKey(meta.Checksum)) metaDictionary.Add(meta.Checksum, meta);
                            if (_alreadyExistFilesList.ContainsKey(Path.GetFileName(meta.FilePath).ToLower()))
                            {
                                _alreadyExistFilesList.Add(Path.GetFileName(meta.FilePath).ToLower(), Path.GetFileName(meta.FilePath).ToLower());
                            }
                        }
                    }
                    else if (schema.UserData.Type == CustomMarkType.Pdf)
                    {
                        PdfMeta meta = schema.UserData as PdfMeta;
                        meta.FilePath = Utilities.ConvertToLocalPath(meta.FilePath, UserInfo.HospCode, Bunho);
                        meta.Thumbnail.FilePath = Utilities.ConvertToLocalPath(meta.Thumbnail.FilePath, UserInfo.HospCode, Bunho);
                        if (!File.Exists(meta.FilePath))
                        {
                            Utilities.DownloadFile(meta.FilePath, UserInfo.HospCode, Bunho);
                            if (_alreadyExistFilesList.ContainsKey(Path.GetFileName(meta.FilePath).ToLower()))
                            {
                                _alreadyExistFilesList.Add(Path.GetFileName(meta.FilePath).ToLower(),
                                    Path.GetFileName(meta.FilePath).ToLower());
                            }
                        }
                        if (!File.Exists(meta.Thumbnail.FilePath))
                        {
                            Utilities.DownloadFile(meta.Thumbnail.FilePath, UserInfo.HospCode, Bunho);
                            if (_alreadyExistFilesList.ContainsKey(Path.GetFileName(meta.FilePath).ToLower()))
                            {
                                _alreadyExistFilesList.Add(Path.GetFileName(meta.Thumbnail.FilePath).ToLower(),
                                    Path.GetFileName(meta.Thumbnail.FilePath).ToLower());
                            }
                        }
                        if (File.Exists(meta.Thumbnail.FilePath))
                        {
                            DocumentImage img = richEditControl.Document.InsertImage(
                                pos,
                                new FileDocumentImageSource(meta.Thumbnail.FilePath));
                            img.ScaleX = meta.Thumbnail.ScaleX;
                            img.ScaleY = meta.Thumbnail.ScaleY;
                            if (!metaDictionary.ContainsKey(meta.Thumbnail.Checksum)) metaDictionary.Add(meta.Thumbnail.Checksum, meta);
                            if (_alreadyExistFilesList.ContainsKey(Path.GetFileName(meta.FilePath).ToLower()))
                            {
                                _alreadyExistFilesList.Add(Path.GetFileName(meta.Thumbnail.FilePath).ToLower(),
                                    Path.GetFileName(meta.Thumbnail.FilePath).ToLower());
                            }
                        }
                    }
                }
            }
            richEditControl.Document.EndUpdate();
            this.currentEmrWordMl = richEditControl.Document.WordMLText;
            this.currentCustomMarks.Clear();
            foreach (CustomMark mark in richEditControl.Document.CustomMarks)
            {
                currentCustomMarks.Add(new Tuple<int, UserData>(mark.Position.ToInt(), mark.UserData as UserData));
            }
            OCS2015U06Businesses.DisplayTagBeforeParagraph(this.richEditControl,
                    this.richEditControl.Document.GetParagraphs(this.richEditControl.Document.Range),
                    StringEnum.GetStringValue(TagOption.Both));
            return comments;
        }

        Dictionary<string, string> _alreadyExistFilesList = new Dictionary<string, string>();

        public Dictionary<string, string> AlreadyExistFilesList
        {
            get { return _alreadyExistFilesList; }
            set
            {
                _alreadyExistFilesList = value;
                if (_alreadyExistFilesList == null)
                {
                    _alreadyExistFilesList = new Dictionary<string, string>();
                }
            }
        }

        private void richEditControl_DoubleClick(object sender, EventArgs e)
        {
            DocumentImageCollection imgCollection = richEditControl.Document.GetImages(richEditControl.Document.Selection);
            if (imgCollection != null && imgCollection.Count > 0)
            {
                string imageHash = Utilities.CalculateImageChecksum(imgCollection[0].Image);
                if (metaDictionary.ContainsKey(imageHash))
                {
                    if (metaDictionary[imageHash] is PdfMeta)
                    {
                        PdfMeta meta = metaDictionary[imageHash] as PdfMeta;
                        Process.Start(meta.FilePath);
                    }
                }                
            }
        }

        public void Reset()
        {
            richEditControl.CreateNewDocument();
            _lastRecordOffset = 0;
            recordPosition.Clear();
            //this.gridControl1.DataSource = null;
            metaDictionary.Clear();
            _alreadyExistFilesList.Clear();
        }

        /// <summary>
        /// Scroll EMR viewer to specific record by exam date or pkout1001
        /// </summary>
        /// <param name="examDate">Exam date in format "yyyy/MM/dd"</param>
        /// <param name="naewonKey">Pkout1001</param>
        public void GotoRecord(string examDate, string naewonKey)
        {
            if (string.IsNullOrEmpty(naewonKey))
            {
                foreach (CustomMark mark in richEditControl.Document.CustomMarks)
                {
                    EmrEndMarkerMeta startMark = mark.UserData as EmrEndMarkerMeta;
                    if (startMark != null)
                    {
                        DateTime dt1 = DateTime.ParseExact(examDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        DateTime dt2 = DateTime.ParseExact(startMark.ExaminationDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        if (dt1 == dt2)
                        {
                            DocumentPosition pos = richEditControl.Document.CreatePosition(mark.Position.ToInt());
                            richEditControl.Document.CaretPosition = pos;
                            richEditControl.ScrollToCaret();
                        }
                    }
                }
            }
            else
            {
                foreach (CustomMark mark in richEditControl.Document.CustomMarks)
                {
                    EmrEndMarkerMeta startMark = mark.UserData as EmrEndMarkerMeta;
                    if (startMark != null)
                    {
                        string pkout1001 = startMark.ReservationCode.Substring(0, startMark.ReservationCode.IndexOf('.') > -1 ? startMark.ReservationCode.IndexOf('.') : startMark.ReservationCode.Length);
                        string _naewonKey = naewonKey.Substring(0, naewonKey.IndexOf('.') > -1 ? naewonKey.IndexOf('.') : naewonKey.Length);
                        if (pkout1001 == _naewonKey)
                        {
                            DocumentPosition pos = richEditControl.Document.CreatePosition(mark.Position.ToInt());
                            richEditControl.Document.CaretPosition = pos;
                            richEditControl.ScrollToCaret();
                        }
                    }
                }
            }
        }

        public RichEditControl RichEditCtControl
        {
            get { return richEditControl; }
        }

        public string Pkout1001
        {
            get { return pkout1001; }
            set { pkout1001 = value; }
        }

        public string Bunho
        {
            get { return _bunho; }
            set { _bunho = value; }
        }
        public string Record_id
        {
            get { return _recordId; }
            set { _recordId = value; }
        }

        public List<CommentMeta> GetComments()
        {
            List<CommentMeta> comments = new List<CommentMeta>();
            foreach (CustomMark mark in richEditControl.Document.CustomMarks)
            {
                if (mark.UserData.GetType().ToString().Equals("CommentMeta"))
                {
                    CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
                    if (meta != null) comments.Add(meta); 
                }
            }

            return comments;
        }

        //public GridControl CommentGrid
        //{
        //    get { return gridControl1; }
        //}

        private void quickPrintItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// Print button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Invoke the Print Preview dialog for the workbook.
            using (PrintingSystem printingSystem = new PrintingSystem())
            {
                using (PrintableComponentLink link = new PrintableComponentLink(printingSystem))
                {
                    link.Component = richEditControl;
                    link.CreateDocument();
                    link.ShowPreviewDialog();
                }
            }
        }

        /// <summary>
        /// Add bookmark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// Show log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnShowLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(Bunho)) return;

            //frOCS2015U40 frU40 = new frOCS2015U40(this, pkout1001);
            //frU40.FormBorderStyle = FormBorderStyle.FixedDialog;
            //frU40.MaximizeBox = false;
            //frU40.MinimizeBox = false;
            //frU40.StartPosition = FormStartPosition.CenterScreen;
            //frU40.ShowDialog();
        }

        /// <summary>
        /// Edit record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (!string.IsNullOrEmpty(this.Bunho))
            //{
            //    OCS2015U00EmrRecordLockArgs lockArgs = new OCS2015U00EmrRecordLockArgs();
            //    lockArgs.RecordId = _recordId;
            //    lockArgs.UpdId = UserInfo.UserID;
            //    lockArgs.ScreenId = "OCS2015U06";
            //    UpdateResult lockRes = CloudService.Instance.Submit<UpdateResult, OCS2015U00EmrRecordLockArgs>(lockArgs);
            //    if (lockRes.ExecutionStatus == ExecutionStatus.Success && lockRes.Result)
            //    {
            //        OCS2015U44 historicEditor = new OCS2015U44(this, _recordId, currentEmrMeta, string.IsNullOrEmpty(currentEmrWordMl) ? richEditControl.Document.WordMLText : currentEmrWordMl, this.Bunho, currentCustomMarks, _mainScreen);
            //        historicEditor.FormBorderStyle = FormBorderStyle.FixedDialog;
            //        historicEditor.MaximizeBox = false;
            //        historicEditor.MinimizeBox = false;
            //        historicEditor.StartPosition = FormStartPosition.CenterScreen;
            //        historicEditor.UpdateEmrViewer += historicEditor_UpdateEmrViewer;
            //        historicEditor.ShowDialog();
            //    }
            //    else
            //    {
            //        XMessageBox.Show(Resources.LockAlert);
            //    }
            //}
        }

        private string pkout1001 = "";
        private string _bunho = "";
        private string _recordId = string.Empty;


        public List<CustomMarkSchema> Save(out string emrXml, List<CustomMarkSchema> editorSchema, string editorEmrXml)
        {
            richEditControl.Document.BeginUpdate();
            List<CustomMarkSchema> emrMeta = new List<CustomMarkSchema>();
            emrMeta.AddRange(currentEmrMeta);
            DoButtonBusiness.RemoveAllPermissions(richEditControl);

            DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.Range);
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                DocumentImage image = collection[i];
                richEditControl.Document.Delete(image.Range);
            }

            foreach (CustomMarkSchema customMarkSchema in editorSchema)
            {
                customMarkSchema.Position += richEditControl.Document.Range.End.ToInt();
            }
            emrMeta.AddRange(editorSchema);

            if (!string.IsNullOrEmpty(editorEmrXml))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(editorEmrXml);
                MemoryStream docStream = new MemoryStream(byteArray);
                richEditControl.Document.AppendDocumentContent(docStream, DocumentFormat.WordML);
            }

            emrXml = richEditControl.WordMLText;

            richEditControl.Document.EndUpdate();
            return emrMeta;
        }

        public void RemoveComment(long bookmarkId)
        {
            for (int i = 0; i < richEditControl.Document.CustomMarks.Count; i++)
            {
                CustomMark mark = richEditControl.Document.CustomMarks[i];
                CommentMeta meta = mark.UserData as CommentMeta;
                if (meta != null && meta.Id == bookmarkId)
                {
                    //Need to remove two customMarks (start & end)
                    richEditControl.Document.DeleteCustomMark(mark);                    
                }
            }

            for (int i = 0; i < currentEmrMeta.Count; i++)
            {
                CustomMarkSchema schema = currentEmrMeta[i];
                CommentMeta meta = schema.UserData as CommentMeta;
                if (meta != null && meta.Id == bookmarkId)
                {
                    currentEmrMeta.Remove(schema);
                }
            }
        }

        public void UpdateComment(long bookmarkId, string bookmarkText)
        {
            for (int i = 0; i < richEditControl.Document.CustomMarks.Count; i++)
            {
                CustomMark mark = richEditControl.Document.CustomMarks[i];
                CommentMeta meta = mark.UserData as CommentMeta;
                if (meta != null && meta.Id == bookmarkId && meta.IsStart)
                {
                    int deletedMarkPos = mark.Position.ToInt();
                    richEditControl.Document.DeleteCustomMark(mark);
                    if (!string.IsNullOrEmpty(bookmarkText))
                    {
                        meta.Comment = bookmarkText;
                        richEditControl.Document.CreateCustomMark(richEditControl.Document.CreatePosition(deletedMarkPos), meta);
                        return;
                    }
                }                
            }
            foreach (CustomMarkSchema schema in currentEmrMeta)
            {
                CommentMeta meta = schema.UserData as CommentMeta;
                if (meta != null && meta.Id == bookmarkId)
                {
                    meta.Comment = bookmarkText;
                }
            }
        }

        private void richEditControl_MouseMove(object sender, MouseEventArgs e)
        {            
            IHIS.OCSO.Utilities.DisplayBookmark(e, this.richEditControl, Form.MousePosition);
        }

        private CustomMarkVisualInfoCollection _customMarkVisualInfoCollection;

        private void richEditControl_CustomMarkDraw(object sender, RichEditCustomMarkDrawEventArgs e)
        {
            _customMarkVisualInfoCollection = e.VisualInfoCollection;
        }

        public void DeleteOrUpdateComment(CommentMeta commentMeta, bool remove)
        {
            if (remove)
            {
                RemoveComment(commentMeta.Id);
            }
            else
            {
                UpdateComment(commentMeta.Id, commentMeta.Comment);
            }
        }

        public void GotoBookmark(long bookmarkId)
        {
            for (int i = 0; i < currentEmrMeta.Count; i++)
            {
                CustomMarkSchema schema = currentEmrMeta[i];
                try
                {
                    CommentMeta meta = schema.UserData as CommentMeta;
                    if (meta != null && meta.Id == bookmarkId && meta.IsStart)
                    {
                        richEditControl.Document.CaretPosition = richEditControl.Document.CreatePosition(schema.Position);
                        richEditControl.ScrollToCaret();
                    }
                }
                catch (Exception) { }
                
            }
        }

        public void RemoveRecordData(string naewonDate, string naewonKey)
        {
            int start = -1, end = -1;

            for (int i = 0; i < richEditControl.Document.CustomMarks.Count; i++)
            {
                CustomMark mark = richEditControl.Document.CustomMarks[i];
                EmrEndMarkerMeta meta = mark.UserData as EmrEndMarkerMeta;
                if (meta != null)
                {
                    if (meta.ExaminationDate.Equals(naewonDate) && meta.ReservationCode.Equals(naewonKey)
                        && mark.Position.ToInt() > start)
                    {
                        start = mark.Position.ToInt();
                    }
                    else if (mark.Position.ToInt() > end)
                    {
                        end = mark.Position.ToInt();
                    }
                }
            }
            if (start >= end)
            { //We only remove do table if it's the last save
                RemoveDoTable(start, richEditControl.Document.Range.End.ToInt());
            }
        }       

        /// <summary>
        /// Reset combo boxes to first value, unhide all text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RepositoryItemComboBox cboTags = (RepositoryItemComboBox)barTag1.Edit;
            if (cboTags.Items.Count > 0)
            {
                barTag1.EditValue = cboTags.Items[0]; 
            }
            RepositoryItemComboBox cboSubTags = (RepositoryItemComboBox)barSubTag1.Edit;
            if (cboSubTags.Items.Count > 0)
            {
                barSubTag1.EditValue = cboSubTags.Items[0]; 
            }
            RepositoryItemComboBox cboOrderType = (RepositoryItemComboBox)cbOrderType.Edit;
            if (cboOrderType.Items.Count > 0)
            {
                cbOrderType.EditValue = cboOrderType.Items[0]; 
            }
            RepositoryItemComboBox cboDisplay = (RepositoryItemComboBox)cbDisplay.Edit;
            if (cboDisplay.Items.Count > 0)
            {
                cbDisplay.EditValue = cboDisplay.Items[0]; 
            }

            foreach (Paragraph paragraph in this.richEditControl.Document.Paragraphs)
            {
                paragraph.Style.Hidden = false;
            }
            foreach (Table table in this.richEditControl.Document.Tables)
            {
                table.Style.Hidden = false;
            }
        }

        private void cbDisplay_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();
            if (!tag.Trim().Equals(""))
            {
                OCS2015U06Businesses.DisplayTagBeforeParagraph(this.richEditControl,
                    this.richEditControl.Document.GetParagraphs(this.richEditControl.Document.Range),
                    tag);
            }
        }

        private void cbOrderType_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();
            ShowHideByOrderType(tag);
            EnableCbDisplay();
        }

        public void ShowHideByOrderType(string tag)
        {
            ShowTableLine(string.IsNullOrEmpty(tag));
            if (!string.IsNullOrEmpty(tag))
            {
                int leftSquareBracket = tag.IndexOf('[') > -1 ? tag.IndexOf('[') : 0;
                int rightSquareBracket = tag.IndexOf(']') > (leftSquareBracket + 1) ? tag.IndexOf(']') : 0;
                DoButtonBusiness.FilterOrderByGubun(
                    richEditControl,
                    tag.Substring(
                        leftSquareBracket + 1,
                        (rightSquareBracket - leftSquareBracket - 1) >= (leftSquareBracket + 1)
                            ? (rightSquareBracket - leftSquareBracket - 1)
                            : (leftSquareBracket + 1)));
            }
            else
            {
                TableCollection tables = richEditControl.Document.Tables;
                DocumentImageCollection images = richEditControl.Document.GetImages(richEditControl.Document.Range);
                foreach (Table table in tables)
                {
                    if (DoButtonBusiness.CheckDoTable(table, images))
                    {
                        DocumentRange range = table.Range;
                        CharacterProperties cp = richEditControl.Document.BeginUpdateCharacters(range);
                        cp.Hidden = false;
                        richEditControl.Document.EndUpdateCharacters(cp);
                    }
                }
            }
        }

        private void richEditControl_Click(object sender, EventArgs e)
        {
            DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.Selection);
            if (collection.Count > 0 && DoButtonBusiness.CheckIfNonDolImage(collection[0]))
            {
                richEditControl.Document.Selection =
                    richEditControl.Document.CreateRange(richEditControl.Document.Selection.Start.ToInt() > 1 ? richEditControl.Document.Selection.Start.ToInt() - 1 : 0 , 0);
                string reason;
                try
                {
                    richEditControl.Cursor = Cursors.WaitCursor;
                    DoButtonBusiness.CloneOrder(collection[0], this, out reason);
                }
                finally
                {
                    richEditControl.Cursor = Cursors.Hand;
                }                
            }
        }

        private void RemoveDoTable(int start, int end)
        {
            if (start > -1 && end > start)
            {
                richEditControl.Document.BeginUpdate();
                DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.CreateRange(start, end - start));
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < currentEmrMeta.Count; j++)
                    {
                        CustomMarkSchema schema = currentEmrMeta[j];
                        ImageMeta meta = schema.UserData as ImageMeta;
                        if (meta != null && start <= schema.Position && schema.Position <= end && DoButtonBusiness.CheckIfNonDolImage(meta))
                        {
                            currentEmrMeta.Remove(schema);
                            j--;
                        }
                    }
                    
                }
                for (int i = 0; i < richEditControl.Document.Tables.Count; i++)
                {
                    Table table = richEditControl.Document.Tables[i];
                    if (start <= table.Range.Start.ToInt() && table.Range.End.ToInt() <= end && DoButtonBusiness.CheckDoTable(table, collection))
                    {
                        richEditControl.Document.Tables.Remove(table);
                    }
                }
                richEditControl.Document.EndUpdate();
            }
        }

        public void ResetToDefault()
        {
            foreach (Paragraph paragraph in richEditControl.Document.Paragraphs)
            {
                paragraph.Style.Hidden = false;
            }
            OCS2015U06Businesses.DisplayTagBeforeParagraph(richEditControl, richEditControl.Document.Paragraphs, StringEnum.GetStringValue(TagOption.Both));
            //ShowTableLine(true);
            barTag1.EditValue = barSubTag1.EditValue = cbOrderType.EditValue = "";
            cbDisplay.EditValue = StringEnum.GetStringValue(TagOption.Both);
            //ShowHideByOrderType(string.Empty);
        }
    }
}