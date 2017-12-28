using System.Globalization;
using System.Text;
using DevExpress.XtraRichEdit;
using EmrDocker;
using EmrDocker.AdditionalBusiness;
using EmrDocker.Meta;
using IHIS.CloudConnector;
using IHIS.Framework;
using EmrDocker.Models;
namespace IHIS.OCSO
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
    using DevExpress.XtraRichEdit.UI;
    using GhostscriptSharp;

    using IHIS.OCSO.Meta;

    using Newtonsoft.Json;
    using DevExpress.XtraRichEdit.Commands;

    using global::EmrDocker.Glossary;
    using IHIS.CloudConnector.Utility;

    public partial class EmrEditor : UserControl
    {

        public int CurrentTagStart = 0;
        public string intellisenseBuffer = "";
        public bool PassInputToTextbox = true;
        private string _userName = "";
        private bool _isVisibleFormat = true;
        private string initialImgPath;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public bool IsVisibleFormat
        {
            get { return _isVisibleFormat; }
            set
            {
                _isVisibleFormat = value;
                if (_isVisibleFormat)
                {
                    //this.fontBar1.Visible = true;
                    this.stylesBar1.Visible = true;
                }
                else
                {
                    //this.fontBar1.Visible = false;
                    this.stylesBar1.Visible = false;
                }
            }
        }

        public EmrEditor(IMainScreen main_screen)
            : this()
        {
            this._mainScreen = main_screen;
        }

        public EmrEditor()
        {
            InitializeComponent();
            ReloadLatesTags();
            BindStyles();
            OfficeSkins.Register();
            BonusSkins.Register();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2010 Silver");
            GetContentTemplates();
            this.richEditControl.Options.TableOptions.GridLines = RichEditTableGridLinesVisibility.Hidden;
            DataProvider.Instance.TagDisplayModeSetup(barTagOptions);
        }

        /// <summary>
        /// Reload data for template combobox, tag combobox
        /// </summary>
        public void ReloadControls()
        {
            ReloadTemplateCbx();
            //BindStyles();
        }

        public void InsertImg(string imgPath, bool hideTemplate)
        {
            this.initialImgPath = imgPath;
            richEditControl.BeginUpdate();
            if (File.Exists(imgPath))
            {                
                string defaultTemplate = this.GetCbxTemContent("0");
                ApplyTemplate(defaultTemplate, false);
                Paragraph paragraph = richEditControl.Document.AppendParagraph();
                if (".pdf".Equals(Path.GetExtension(imgPath), StringComparison.CurrentCultureIgnoreCase))
                {
                    InsertPdfFile(
                        imgPath,
                        richEditControl.Document.CreatePosition(richEditControl.Document.Range.End.ToInt()), false);
                }
                else
                {
                    Image img = Image.FromFile(imgPath);
                    DocumentImage docImage = richEditControl.Document.InsertImage(richEditControl.Document.CreatePosition(richEditControl.Document.Range.End.ToInt()), img);

                    docImage.Size = Utilities.GetImageSizeF(docImage, richEditControl);
                }
                SetParagraphToNormal(paragraph);
                richEditControl.Document.CaretPosition = richEditControl.Document.CreatePosition(0);
                richEditControl.ScrollToCaret();
            }
            richEditControl.EndUpdate();
            this.cbxTemplates.Visible = !hideTemplate;
            splitContainerControl1.SplitterPosition = 27;
        }
        public void ReloadLatesTags()
        {
            DataProvider.Instance.ReloadLatestTags();
        }
        private void BindStyles()
        {
            //DataProvider.Instance.ReloadLatestTags();
            // reset existed paragraph style
            foreach (ParagraphStyle style in richEditControl.Document.ParagraphStyles)
            {
                if (!style.Name.Equals("Normal") && !style.Name.Equals("Hyperlink") && !DataProvider.Instance.AllTags.Contains(style.Name) && !style.IsDeleted) // delete all except default style
                {
                    richEditControl.Document.ParagraphStyles.Delete(style);
                }
            }

            foreach (string tag in DataProvider.Instance.Tags.Keys)
            {
                if (!tag.Equals("Normal") && !tag.Equals("Hyperlink") && (richEditControl.Document.ParagraphStyles[tag] == null || richEditControl.Document.ParagraphStyles[tag].IsDeleted))
                {
                    ParagraphStyle tagStyle = richEditControl.Document.ParagraphStyles.CreateNew();
                    tagStyle.Name = tag;
                    richEditControl.Document.ParagraphStyles.Add(tagStyle);

                    foreach (string subTag in DataProvider.Instance.Tags[tag])
                    {
                        if (!subTag.Equals("Normal") && !subTag.Equals("Hyperlink"))
                        {
                            ParagraphStyle subTagStyle = richEditControl.Document.ParagraphStyles.CreateNew();
                            subTagStyle.Name = String.Format("{0}-{1}", tag, subTag);
                            richEditControl.Document.ParagraphStyles.Add(subTagStyle);
                        }
                    }
                }
            }
        }

        private Dictionary<string, string> _TemplateMap = new Dictionary<string, string>();
        private string GetCbxTemContent(string temId)
        {
            try
            {
                if (_TemplateMap.ContainsKey(temId))
                    return _TemplateMap[temId];
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private bool _isSetTemDefault = false;
        public bool IsSetTemDefault
        {
            get { return _isSetTemDefault; }
            set { _isSetTemDefault = value; }
        }
        public RichEditControl RichEditCtControl
        {
            get { return richEditControl; }
        }
        private void SetTemplateDefault()
        {
            if (_isSetTemDefault && _TemplateMap.ContainsKey("0") || _viewer == null)
                this.cbxTemplates.SelectedIndex = 0;
        }

        private void GetContentTemplates()
        {
            repositoryEmrTemplate.Items.Clear();
            _TemplateMap.Clear();
            OCS2015U09Businesses.QueryTemplateList();
            List<TemplateMeta> templateList = OCS2015U09Businesses.GetTemplateList();
            this.cbxTemplates.Items.Clear();
            foreach (TemplateMeta meta in templateList)
            {
                this.cbxTemplates.Items.Add(meta);
                _TemplateMap.Add(meta.EmrTemplateId, meta.TemplateContent);
            }
            this.cbxTemplates.DisplayMember = "TemplateName";
            this.cbxTemplates.ValueMember = "EmrTemplateId";
            this.cbxTemplates.SelectedIndexChanged -= cbxTemplates_SelectedIndexChanged;
            this.cbxTemplates.SelectedIndexChanged += cbxTemplates_SelectedIndexChanged;

            if (_viewer != null)
                SetTemplateDefault();
        }

        private void ReloadTemplateCbx()
        {
            GetContentTemplates();
        }
        void cbxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            TemplateMeta tem = this.cbxTemplates.SelectedItem as TemplateMeta;
            string temContent = this.GetCbxTemContent(tem.EmrTemplateId);
            ApplyTemplate(temContent, true);
        }

        private List<TemplateTagItem> _backupTagList = new List<TemplateTagItem>();
        private List<TemplateTagItem> _historyTagContentLst = new List<TemplateTagItem>();
        private Dictionary<string, string> _tagInfo = new Dictionary<string, string>();

        public void GetPrevTagContent()
        {
            if (_viewer == null) return;
            _historyTagContentLst.Clear();
            RichEditControl riEClt = _viewer.RichEditCtControl;
            foreach (Paragraph paragraph in riEClt.Document.Paragraphs)
            {
                string tagName = paragraph.Style.Name;
                if (!tagName.Equals("Normal", StringComparison.CurrentCultureIgnoreCase))
                {
                    int start = GetParagraphMarklerPosition(riEClt, paragraph);
                    string content = start >= paragraph.Range.End.ToInt() ? string.Empty : riEClt.Document.GetWordMLText(riEClt.Document.CreateRange(start, paragraph.Range.End.ToInt() - start));
                    _historyTagContentLst.Add(new TemplateTagItem(tagName, content, content.Length == 0));
                }
            }
        }

        private int GetParagraphMarklerPosition(RichEditControl riEClt, Paragraph paragraph)
        {
            foreach (CustomMark mark in riEClt.Document.CustomMarks)
            {
                ParagraphMarker marker = mark.UserData as ParagraphMarker;
                if (marker != null && paragraph.Range.Contains(mark.Position))
                {
                    return mark.Position.ToInt() + 1;
                }
            }
            return paragraph.Range.Start.ToInt();
        }

        public void GetCurrentTagContent(string tagContent)
        {
            string[] tagContentArr = tagContent.Split(new char[] { ',' });
            string currentRoot = null;
            List<string> conversionTags = new List<string>();
            Dictionary<String, List<String>> allTag = DataProvider.Instance.Tags;

            foreach (string tg in tagContentArr)
            {
                if (allTag.ContainsKey(tg.Trim()))
                {
                    currentRoot = tg.Trim();
                    conversionTags.Add(tg.Trim());
                }
                else if (currentRoot != null && allTag[currentRoot].Contains(tg.Trim()))
                {
                    conversionTags.Add(currentRoot == null ? tg.Trim() : string.Format("{0}-{1}", currentRoot, tg.Trim()));
                }
            }

            this.GetPrevTagContent();
            _backupTagList.Clear();

            TemplateTagItem mTagItem;
            //Get all tag content in Editor
            List<TemplateTagItem> mTagContentEditingLst = new List<TemplateTagItem>();
            RichEditControl riEditor = this.richEditControl;
            foreach (Paragraph paragraph in riEditor.Document.Paragraphs)
            {
                string tagName = paragraph.Style.Name;
                if (!tagName.Equals("Normal", StringComparison.CurrentCultureIgnoreCase))
                {
                    int start = GetParagraphMarklerPosition(riEditor, paragraph);
                    string content = start >= paragraph.Range.End.ToInt() ? string.Empty : riEditor.Document.GetWordMLText(riEditor.Document.CreateRange(start, paragraph.Range.End.ToInt() - start));
                    mTagContentEditingLst.Add(new TemplateTagItem(tagName, content, content.Length == 0));
                }
            }

            if (tagContentArr.Length > 0)
            {
                if (string.IsNullOrEmpty(tagContent))
                {
                    _backupTagList.Clear();
                    return;
                }
                for (int i = 0; i < conversionTags.Count; i++)
                {
                    //Get tag content in Editor
                    mTagItem = GetTagEditingByTagCode(mTagContentEditingLst, conversionTags[i]);
                    if (mTagItem == null)
                    {
                        //get tag content in history
                        mTagItem = GetTagContentByTagCode(conversionTags[i].Trim());
                        if (mTagItem == null)
                        {
                            mTagItem = new TemplateTagItem(conversionTags[i].Trim(), "", true);
                        }
                    }
                    _backupTagList.Add(mTagItem);
                }
            }
        }

        /// <summary>
        /// Get tag item in tag List by tag name
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public TemplateTagItem GetTagContentByTagCode(string tagCode)
        {
            if (_historyTagContentLst.Count <= 0) return null;
            TemplateTagItem templateTagItem = null;
            foreach (TemplateTagItem item in _historyTagContentLst)
            {
                if (tagCode.Trim() == item.TagCode)
                {
                    templateTagItem = new TemplateTagItem(tagCode, item.TagContent, false);
                }
            }
            return templateTagItem;
        }
        /// <summary>
        /// Get Tag'content in Edittor by tagcode
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="tagCode"></param>
        /// <returns></returns>
        public TemplateTagItem GetTagEditingByTagCode(List<TemplateTagItem> lst, string tagCode)
        {
            if (lst.Count <= 0) return null;
            foreach (TemplateTagItem item in lst)
            {
                if (tagCode.Trim() == item.TagCode)
                {
                    return item;
                }
            }
            return null;
        }

        public void ApplyTemplate(string tagContent, bool reset)
        {
            this.GetCurrentTagContent(tagContent);
            if(reset) Reset(true);
            this.RichEditControl.BeginUpdate();
            int start;
            int length;
            DocumentRange range;
            foreach (TemplateTagItem item in _backupTagList)
            {
                if (item == null) continue;
                start = richEditControl.Document.CaretPosition.ToInt();
                OCS2015U06Businesses.SwitchParagraphStyle(richEditControl, richEditControl.Document.GetParagraphs(richEditControl.Document.Selection), item.TagCode, barTagOptions.EditValue.ToString());
                this.richEditControl.Document.AppendDocumentContent(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(item.TagContent)), item.IsPlainText ? DocumentFormat.PlainText : DocumentFormat.WordML);
                length = richEditControl.Document.CaretPosition.ToInt() - start;
                range = richEditControl.Document.CreateRange(start, length + 1);
                foreach (Paragraph paragraph in richEditControl.Document.GetParagraphs(range))
                {
                    paragraph.Style = richEditControl.Document.ParagraphStyles[item.TagCode];
                }
                this.richEditControl.Document.AppendParagraph();
            }
            this.RichEditControl.EndUpdate();
            _backupTagList.Clear();
        }

        private void richEditControl_DoubleClick(object sender, EventArgs e)
        {
            DocumentRange rang = richEditControl.Document.CreateRange(clickPosition == -1 ? 0 : clickPosition, 1);
            DocumentImageCollection imgCollection = richEditControl.Document.GetImages(rang);
            if (imgCollection != null && imgCollection.Count > 0)
            {
                string imageHash = Utilities.CalculateImageChecksum(imgCollection[0].Image);
                if (metaDictionary.ContainsKey(imageHash) && metaDictionary[imageHash] is PdfMeta)
                {
                    PdfMeta meta = metaDictionary[imageHash] as PdfMeta;
                    Process.Start(meta.FilePath);
                }
                else
                {
                    if (!DoButtonBusiness.CheckIfNonDolImage(imgCollection[0]))
                    {
                        EditImage(imgCollection[0]);
                    }
                }
            }
        }

        private void EditImage(DocumentImage image)
        {
            /*// Get original image which is being edited
            string editingImageHash = "";
            if (hashFileNameDict.ContainsKey(Utilities.CalculateImageChecksum(image.Image)))
            {
                editingImageHash = Utilities.CalculateImageChecksum(image.Image);
            }
            string editedImageHash = "";

            //string filePath = Utilities.GetAbsoluteDataPath(Path.GetFileName(image.Uri) + "temp" + "." + image.Image.RawFormat, Bunho);
            string filePath = Utilities.GetAbsoluteDataPath(Path.GetFileName(hashFileNameDict.ContainsKey(editingImageHash) ? hashFileNameDict[editingImageHash] : string.IsNullOrEmpty(this.initialImgPath) ? image.Uri : this.initialImgPath) + "temp" + "." + image.Image.RawFormat, Bunho);
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);
            SaveStreamToFile(filePath, image.Image.GetImageBytesSafe(image.Image.RawFormat));
            editingImage = true;
            DataProvider.ImageEditorInstance.Edit(
                filePath, image.ScaleX, image.ScaleY,
                delegate(byte[] data, float scaleX, float scaleY)
                {
                    richEditControl.Document.BeginUpdate();
                    richEditControl.Document.Delete(image.Range);
                    DocumentImage docImage = richEditControl.Document.InsertImage(
                        richEditControl.Document.CreatePosition(clickPosition == -1 ? 0 : clickPosition),
                        new StreamDocumentImageSource(new MemoryStream(data)));
                    docImage.ScaleX = scaleX;
                    docImage.ScaleY = scaleY;
                    richEditControl.Document.EndUpdate();
                    editingImage = false;
                    editedImageHash = Utilities.CalculateImageChecksum(docImage.Image); // get edited image hash
                }, this);

            // Update new file hash after editing
            string orgFilePath = "";
            if (hashFileNameDict.ContainsKey(editingImageHash))
            {
                orgFilePath = hashFileNameDict[editingImageHash];
                hashFileNameDict.Remove(editingImageHash);
            }
            if (!hashFileNameDict.ContainsKey(editedImageHash))
            {
                hashFileNameDict.Add(editedImageHash, orgFilePath);
            }*/
        }

        private void richEditControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.D3 && (e.Modifiers == Keys.Shift))
            /*if (e.KeyCode == Keys.OemPeriod && e.Shift == false)
            {
                CurrentTagStart = richEditControl.Document.CaretPosition.ToInt() + 1;
                Rectangle rectangle = richEditControl.GetBoundsFromPosition(richEditControl.Document.CaretPosition);
                Rectangle r2 = Units.DocumentsToPixels(rectangle, richEditControl.DpiX, richEditControl.DpiY);
                Point p = new Point(r2.X, r2.Y + 50);
                p.Y += (int)richEditControl.Font.GetHeight() * 2;
                lbTags.Location = p;
                lbTags.Show();
                ActiveControl = lbTags;
            }*/
        }

        private void richEditControl_KeyDown(object sender, KeyEventArgs e)
        {

            //TODO: Missing undo functionality for pdf file.
            /*if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < richEditControl.Document.CustomMarks.Count; i++)
                {
                    if (richEditControl.Document.CustomMarks[i].Position.ToInt() == richEditControl.Document.CaretPosition.ToInt())
                    {
                        richEditControl.Document.DeleteCustomMark(richEditControl.Document.CustomMarks[i]);
                    }
                }
            }*/

        }

        private ParagraphStyle activeStyle = null;
        /// <summary>
        /// Use this member to record style name to displace member activeStyle
        /// </summary>
        private string activeStyle_name = "";

        private void richEditControl_SelectionChanged(object sender, EventArgs e)
        {
            /*Document doc = richEditControl.Document;
            DocumentRange range = doc.Selection;
            if (range.Length >= 0 && range.Start.ToInt() >= 0 && range.End.ToInt() <= doc.Range.End.ToInt())
            {
                doc.BeginUpdate();

                ParagraphProperties pp = doc.BeginUpdateParagraphs(range);
                if (activeStyle_name != null)
                {
                    foreach (Paragraph paragraph in doc.Paragraphs)
                    {
                        if (paragraph.Style.Name.Equals(activeStyle_name))
                        {
                            paragraph.Style.BackColor = Color.Transparent;
                        }
                    }
                }

                if (range.Length >= 0 && pp != null && pp.Style != null && !pp.Style.Name.Equals("Normal"))
                {
                    pp.Style.BackColor = Color.DarkGray;
                    activeStyle_name = pp.Style.Name;
                }
                else
                {
                    activeStyle_name = null;
                }

                doc.EndUpdateParagraphs(pp);
                doc.EndUpdate();
            }*/
        }

        private void changeStyleItem1_EditValueChanged(object sender, EventArgs e)
        {
            ChangeStyleItem item = (ChangeStyleItem)sender;
            Document doc = richEditControl.Document;
            DocumentRange range = doc.Selection;
            ParagraphCollection collection = richEditControl.Document.GetParagraphs(doc.Selection);
            OCS2015U06Businesses.SwitchParagraphStyle(richEditControl, collection, item.EditValue.ToString(), barTagOptions.EditValue.ToString());
            if (range.Length > 0 && range.Start.ToInt() >= 0 && range.End.ToInt() <= doc.Range.End.ToInt())
            {
                CharacterProperties pp = doc.BeginUpdateCharacters(range);
                if (pp != null && pp.Style.BackColor != null && item.EditValue.Equals("Normal"))
                {
                    pp.Style.BackColor = Color.Transparent;
                }
                doc.EndUpdateCharacters(pp);
            }
        }

        private Dictionary<string, string> templateDictionary = new Dictionary<string, string>();

        private string prevSelectedItem = "";

        private void cboTemplate_EditValueChanged(object sender, EventArgs e)
        {
            if (prevSelectedItem.Trim() == "")
            {
                BarEditItem item = (BarEditItem)sender;
                if (item.EditValue != null && item.EditValue.ToString().Trim().Length > 0)
                {
                    string s = item.EditValue.ToString();
                    List<TemplateMeta> _templateList = OCS2015U09Businesses.GetTemplateList();

                    try
                    {
                        TemplateMeta template = _templateList.Find(delegate(TemplateMeta meta)
                        {
                            return meta.EmrTemplateId == s ? true : false;
                        });
                        foreach (KeyValuePair<string, string> keyValuePair in template.TagList)
                        {
                            this.RichEditControl.Document.AppendText(keyValuePair.Value);
                            this.RichEditControl.Document.AppendParagraph();
                        }
                        //Insert values for oldTemplate and pre-fill for new template
                        OCS2015U09Businesses.SuggestValueForNewTemplate(null, template, this.Bunho, this.richEditControl);
                    }
                    catch (NullReferenceException ex) // when user types in absent template code, do nothing
                    {

                        //this.richEditControl.Document.Text = "";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    prevSelectedItem = item.EditValue.ToString().Trim() != "" ? item.EditValue.ToString().Trim() : "";
                }
            }
            else if (prevSelectedItem.Trim() != "")
            {
                BarEditItem item = (BarEditItem)sender;
                if (item.EditValue != null && item.EditValue.ToString().Trim().Length > 0)
                {
                    string s = item.EditValue.ToString();
                    List<TemplateMeta> _templateList = OCS2015U09Businesses.GetTemplateList();

                    try
                    {
                        TemplateMeta oldTemplate = _templateList.Find(delegate(TemplateMeta meta)
                        {
                            return meta.EmrTemplateId == prevSelectedItem ? true : false;
                        });
                        // clear old tags
                        richEditControl.Document.BeginUpdate();
                        //string docText = richEditControl.Document.Text;
                        foreach (KeyValuePair<string, string> pair in oldTemplate.TagList)
                        {
                            //docText = docText.Replace(pair.Value, "");
                            if (pair.Value != "")
                            {
                                ISearchResult searchResult = richEditControl.Document.StartSearch(pair.Value,
                                                        SearchOptions.CaseSensitive, SearchDirection.Forward, richEditControl.Document.Range);
                                while (searchResult.FindNext())
                                {
                                    searchResult.Replace(String.Empty);
                                }
                            }
                        }
                        //richEditControl.Document.Text = docText;
                        richEditControl.Document.EndUpdate();

                        TemplateMeta template = _templateList.Find(delegate(TemplateMeta meta)
                        {
                            return meta.EmrTemplateId == s ? true : false;
                        });

                        richEditControl.Document.BeginUpdate();
                        foreach (KeyValuePair<string, string> pair in template.TagList)
                        {
                            //docText = docText + pair.Value + "\r\n";
                            if (pair.Value != "")
                            {
                                ISearchResult searchResult = richEditControl.Document.StartSearch(pair.Value,
                                                        SearchOptions.CaseSensitive, SearchDirection.Forward, richEditControl.Document.Range);
                                while (searchResult.FindNext())
                                {
                                    searchResult.Replace(pair.Value);
                                }
                            }
                        }
                        //richEditControl.Document.Text = docText;
                        richEditControl.Document.EndUpdate();
                        //Insert values for oldTemplate and pre-fill for new template
                        OCS2015U09Businesses.SuggestValueForNewTemplate(oldTemplate, template, this.Bunho, this.richEditControl);

                        foreach (KeyValuePair<string, string> keyValuePair in template.TagList)
                        {
                            this.RichEditControl.Document.AppendText(keyValuePair.Value);
                            this.RichEditControl.Document.AppendParagraph();
                        }
                    }
                    catch (NullReferenceException ex)
                    {

                        //this.richEditControl.Document.Text = "";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    prevSelectedItem = item.EditValue.ToString().Trim() != "" ? item.EditValue.ToString().Trim() : "";
                }
            }


        }

        private string _bunho = "";

        public string Bunho
        {
            get { return _mainScreen == null ? _bunho : _mainScreen.MSelectedPatientInfo.Parameter.Bunho; }
            set { _bunho = value; }
        }

        private void richEditControl_DocumentLoaded(object sender, EventArgs e)
        {
            foreach (CustomMarkSchema schema in customMarks)
            {
                richEditControl.Document.CreateCustomMark(
                    richEditControl.Document.CreatePosition(schema.Position),
                    schema.UserData);
            }
            richEditControl.Document.Fields.Update();
            BindGridComment();
        }

        List<string> _newlyAddedImages = new List<string>();

        public List<string> NewlyAddedImages
        {
            get { return _newlyAddedImages; }
            set
            {
                _newlyAddedImages = value;
                if (_newlyAddedImages == null)
                {
                    _newlyAddedImages = new List<string>();
                }
            }
        }

        private void insertImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            DocumentPosition pos = richEditControl.Document.Selection == null ? richEditControl.Document.CreatePosition(0) : richEditControl.Document.Selection.Start;            

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CLIP";

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))            
            {
                richEditControl.Document.BeginUpdate();
                DocumentImage docImage = richEditControl.Document.InsertImage(pos, new FileDocumentImageSource(dialog.FileName));

                docImage.Size = Utilities.GetImageSizeF(docImage, richEditControl);

                docImage.Uri = dialog.FileName;
                richEditControl.Document.EndUpdate();

                string imageHash = Utilities.CalculateImageChecksum(docImage.Image);

                if (!hashFileNameDict.ContainsKey(imageHash))
                {
                    hashFileNameDict.Add(imageHash, dialog.FileName);
                }
                EditImage(docImage);
            }
        }

        private void insertPdfItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DocumentPosition pos = richEditControl.Document.Selection == null ? richEditControl.Document.CreatePosition(0): richEditControl.Document.Selection.Start;            

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf Files|*.pdf";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(dialog.FileName);
                if (ext.ToLower() == ".pdf")
                {
                    InsertPdfFile(dialog.FileName, pos, true);
                }
            }
        }

        private void InsertPdfFile(string originalFilePath, DocumentPosition pos, bool beginEndBlock)
        {
            string max_size = string.Empty;
            if (!Utilities.CheckPdfUploadFile(originalFilePath, out max_size))
            {
                XMessageBox.Show(string.Format(Resources.EMR_PDF_MAX_SIZE, max_size), Resources.WARN);
                return;
            }
               
            string pdfLink =
                Utilities.GetAbsoluteDataPath(Utilities.NextSequence(Bunho, Path.GetFileName(originalFilePath), "pdf"), Bunho);
            File.Copy(originalFilePath, pdfLink);
            _newlyAddedImages.Add(pdfLink);

            string pdfHash = Utilities.CalculateFileChecksum(pdfLink);
            string thumbnailFilePath;

            FileDocumentImageSource image = GetPdfThumbnail(pdfLink, out thumbnailFilePath);
            //FileDocumentImageSource image = GetPdfThumbnail(originalFilePath, out thumbnailFilePath);
            _newlyAddedImages.Add(pdfLink);
            _newlyAddedImages.Add(thumbnailFilePath);
            string thumbnailHash = Utilities.CalculateImageChecksum(image.Stream);
            if (!metaDictionary.ContainsKey(thumbnailHash))
            {
                metaDictionary.Add(
                    thumbnailHash,
                    new PdfMeta(pdfHash, pdfLink, new ImageMeta(thumbnailHash, thumbnailFilePath, 0.25f, 0.25f)));
            }

            if (beginEndBlock) richEditControl.Document.BeginUpdate();
            DocumentImage docImage = richEditControl.Document.InsertImage(pos, new FileDocumentImageSource(thumbnailFilePath));
            docImage.ScaleX = 0.25f;
            docImage.ScaleY = 0.25f;
            docImage.Uri = thumbnailFilePath;
            if (beginEndBlock) richEditControl.Document.EndUpdate();
        }

        private FileDocumentImageSource GetPdfThumbnail(string pdfFilePath, out string thumbnailFilePath)
        {
            thumbnailFilePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(Bunho, Path.GetFileNameWithoutExtension(pdfFilePath), "jpeg"), Bunho);
            try
            {
                GhostscriptWrapper.GeneratePageThumb(pdfFilePath, thumbnailFilePath, 1, 24, 24);
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
            return new FileDocumentImageSource(thumbnailFilePath);
        }

        private void insertCommentItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddComment();
        }

        private void AddComment()
        {
            /*DocumentRange range = richEditControl.Document.Selection;
            if (range.Length == 0)
            {
                XMessageBox.Show(Resources.EMPTY_COMMENT_SELECTION_WARN, Resources.WARN);
                return;
            }
            frmComment frm = new frmComment(DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture), range.Start.ToInt(), String.Empty, true, string.Empty);
            frm.CommentUpdated += new frmComment.CommentUpdateHandler(frm_CommentUpdated);
            frm.ShowDialog(this);*/
        }

        void frm_CommentUpdated(object sender, CommentEventArgs e)
        {          
            //Create new customMark for comment
            if (e.Comment.Trim().Length > 0)
            {
                /*DocumentRange selection = this.richEditControl.Document.Selection;
                string gwa = string.IsNullOrEmpty(UserInfo.Gwa) && _mainScreen != null ? _mainScreen.MSelectedPatientInfo.Parameter.Gwa : UserInfo.Gwa;
                string gwaName = string.IsNullOrEmpty(UserInfo.GwaName) ? "" : UserInfo.GwaName;
                CommentMeta meta = new CommentMeta(e.Length, UserInfo.UserID, e.Comment.Trim(), e.TagId, true, UserInfo.UserID, gwa, gwaName, _mainScreen == null ? string.Empty : _mainScreen.MSelectedPatientInfo.Parameter.NaewonDate, e.Title);
                CommentMeta meta2 = new CommentMeta(e.Length, UserInfo.UserID, e.Comment.Trim(), e.TagId, false, UserInfo.UserID, gwa, gwaName, _mainScreen == null ? string.Empty : _mainScreen.MSelectedPatientInfo.Parameter.NaewonDate, e.Title);
                DocumentPosition pos = richEditControl.Document.CreatePosition(selection.Start.ToInt());
                //richEditControl.Document.CreateCustomMark(pos, JsonConvert.SerializeObject(meta));
                richEditControl.Document.CreateCustomMark(pos, meta);
                DocumentPosition pos2 = richEditControl.Document.CreatePosition(selection.End.ToInt() == this.richEditControl.Document.Range.End.ToInt() ? (selection.End.ToInt() - 1) : selection.End.ToInt());
                //richEditControl.Document.CreateCustomMark(pos2, JsonConvert.SerializeObject(meta2));
                richEditControl.Document.CreateCustomMark(pos2, meta2);*/
            }
        }

        private void BindGridComment()
        {
            List<CommentMeta> comments = new List<CommentMeta>();
            foreach (CustomMark mark in richEditControl.Document.CustomMarks)
            {
                CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
                if (meta != null) comments.Add(meta);
            }

        }

        //public GridControl CommentGrid
        //{ get { return gridControl1; } }

        private List<CustomMarkSchema> customMarks = new List<CustomMarkSchema>();

        private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();

        public Dictionary<string, UserData> MetaDictionary
        {
            get { return metaDictionary; }
        }

        private void SaveStreamToFile(string fileFullPath, byte[] data)
        {
            if (data.Length == 0) return;
            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = File.Create(fileFullPath, data.Length))
            {
                // Use FileStream object to write to the specified file
                fileStream.Write(data, 0, data.Length);
            }
        }

        public List<CustomMarkSchema> Save(out string emrXml)
        {
            return Save(out emrXml, true, _mainScreen.MSelectedPatientInfo.Parameter.NaewonDate, _mainScreen.MSelectedPatientInfo.Parameter.NaewonKey, this.Bunho);
        }

        private EmrViewer _viewer;// = new EmrViewer();

        /// <summary>
        /// this property used for get offset for file positions after appending to Viewer.
        /// </summary>
        public EmrViewer Viewer
        {
            set { _viewer = value; }
            get { return _viewer; }
        }

        public Dictionary<string, string> HashFileNameDict
        {
            get { return hashFileNameDict; }
            set { hashFileNameDict = value; }
        }

        /// <summary>
        /// Upload new files to server
        /// </summary>
        /// <returns>List of CustomMarkSchema which stores position of images and pdf thumbnail</returns>
        public List<CustomMarkSchema> UploadFiles()
        {
            int offset = this._viewer.RichEditCtControl.Document.Range.End.ToInt();

            List<CustomMarkSchema> result = new List<CustomMarkSchema>();
            DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.Range);
            //int offset = 0;
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                DocumentImage image = collection[i];
                string hash = Utilities.CalculateImageChecksum(image.Image);
                if (!metaDictionary.ContainsKey(hash))
                {
                    string filePath =
                        Utilities.GetAbsoluteDataPath(Utilities.NextSequence(Bunho, "", image.Image.RawFormat.ToString()), Bunho);
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (!fileInfo.Exists)
                        Directory.CreateDirectory(fileInfo.Directory.FullName);
                    SaveStreamToFile(filePath, image.Image.GetImageBytesSafe(image.Image.RawFormat));
                    ImageMeta meta = new ImageMeta(hash, filePath, image.ScaleX, image.ScaleY);
                    //CustomMarkSchema schema = new CustomMarkSchema(image.Range.Start.ToInt(), meta);
                    CustomMarkSchema schema = new CustomMarkSchema(offset + image.Range.Start.ToInt(), meta);
                    result.Add(schema);
                    Upload(filePath);
                }
                else
                {
                    //pdf or old image
                    UserData userData = metaDictionary[hash];
                    if (userData is PdfMeta)
                    {
                        PdfMeta meta = userData as PdfMeta;
                        meta.Thumbnail.ScaleX = image.ScaleX;
                        meta.Thumbnail.ScaleY = image.ScaleY;
                        Upload(meta.FilePath);
                        Upload(meta.Thumbnail.FilePath);
                    }
                    //CustomMarkSchema schema = new CustomMarkSchema(image.Range.Start.ToInt(), userData);
                    CustomMarkSchema schema = new CustomMarkSchema(offset + image.Range.Start.ToInt(), userData);
                    result.Add(schema);
                }
                //richEditControl.Document.Delete(image.Range);
            }
            return result;
        }

        public IMainScreen _mainScreen;
        private DocumentRange InsertExaminationReservationInformation(string naewonDate, string naewonKey)
        {
            string examReservation = UserInfo.HospCode + "\n" +
                                        UserInfo.GwaName + " - " +
                                        UserInfo.UserName + " - " +
                                        naewonDate + "\n"; //_mainScreen.MSelectedPatientInfo.Parameter.NaewonDate
                                        //naewonKey + "\n"; //_mainScreen.MSelectedPatientInfo.Parameter.NaewonKey
            return this.richEditControl.Document.InsertText(this.richEditControl.Document.Range.Start, examReservation);
        }
        public List<CustomMarkSchema> Save(out string emrXml, bool excudeImage, string naewonDate, string naewonKey, string _bunho)
        {
            this.Bunho = string.IsNullOrEmpty(this.Bunho) ? _bunho : this.Bunho;
            richEditControl.Document.BeginUpdate();
            List<CustomMarkSchema> emrMeta = new List<CustomMarkSchema>();

            DoButtonBusiness.RemoveAllPermissions(richEditControl);

            if (excudeImage)
            {
                OCS2015U06Businesses.RemoveEmptyTags(richEditControl, barTagOptions.EditValue == null ? StringEnum.GetStringValue(TagOption.Both) : barTagOptions.EditValue.ToString());
                this.richEditControl.Document.AppendParagraph(); // New line when saving to DB                
                DocumentRange range = InsertExaminationReservationInformation(_mainScreen == null ? naewonDate : _mainScreen.MSelectedPatientInfo.Parameter.NaewonDate, _mainScreen == null ? naewonKey : _mainScreen.MSelectedPatientInfo.Parameter.NaewonKey);

                //set the range to normal
                SetParagraphStyleNormal(range);

                int endHeaderPosition = range.End.ToInt();
                DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.Range);
                int offset = 0;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    DocumentImage image = collection[i];
                    string hash = Utilities.CalculateImageChecksum(image.Image);
                    if (!metaDictionary.ContainsKey(hash))
                    {
                        if (!DoButtonBusiness.CheckIfNonDolImage(image))
                        {
                            //this is a new image --> save the image to folder      
                            string filePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(Bunho, hashFileNameDict.ContainsKey(hash) ? Path.GetFileName(hashFileNameDict[hash]) : image.Uri, image.Image.RawFormat.ToString()), Bunho);
                            FileInfo fileInfo = new FileInfo(filePath);
                            if (!fileInfo.Exists)
                                Directory.CreateDirectory(fileInfo.Directory.FullName);
                            SaveStreamToFile(filePath, image.Image.GetImageBytesSafe(image.Image.RawFormat));
                            ImageMeta meta = new ImageMeta(hash, filePath, image.ScaleX, image.ScaleY);
                            CustomMarkSchema schema = new CustomMarkSchema(image.Range.Start.ToInt(), meta);
                            emrMeta.Add(schema);
                            Upload(filePath);
                        }
                        else
                        {
                            string filePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(Bunho, "DO", image.Image.RawFormat.ToString()), Bunho);
                            FileInfo fileInfo = new FileInfo(filePath);
                            if (!fileInfo.Exists)
                                Directory.CreateDirectory(fileInfo.Directory.FullName);
                            SaveStreamToFile(filePath, image.Image.GetImageBytesSafe(image.Image.RawFormat));
                            ImageMeta meta = new ImageMeta(hash, filePath, image.ScaleX, image.ScaleY);
                            CustomMarkSchema schema = new CustomMarkSchema(image.Range.Start.ToInt(), meta);
                            emrMeta.Add(schema);
                            Upload(filePath);
                        }
                    }
                    else
                    {
                        //pdf or old image
                        UserData userData = metaDictionary[hash];
                        if (userData is ImageMeta)
                        {
                            ImageMeta meta = userData as ImageMeta;
                            meta.ScaleX = image.ScaleX;
                            meta.ScaleY = image.ScaleY;

                            Upload(meta.FilePath);
                        }
                        else if (userData is PdfMeta)
                        {
                            PdfMeta meta = userData as PdfMeta;
                            meta.Thumbnail.ScaleX = image.ScaleX;
                            meta.Thumbnail.ScaleY = image.ScaleY;
                            Upload(meta.FilePath);
                            Upload(meta.Thumbnail.FilePath);
                        }
                        CustomMarkSchema schema = new CustomMarkSchema(image.Range.Start.ToInt(), userData);
                        emrMeta.Add(schema);
                    }
                    richEditControl.Document.Delete(image.Range);
                }
                // Create new CustomMarkSchema to mark start position of examination record, need check if LoadMeta() load it out properly
                #region EMR marker metadata     
                naewonDate = string.IsNullOrEmpty(naewonDate)
                                 ? _mainScreen.MSelectedPatientInfo.Parameter.NaewonDate
                                 : naewonDate;
                naewonKey = string.IsNullOrEmpty(naewonKey)
                                ? _mainScreen.MSelectedPatientInfo.Parameter.NaewonKey
                                : naewonKey;
                emrMeta.Add(Utilities.AddEmrMarkerContent(naewonDate, naewonKey, new EmrStartMarkerMeta(""), richEditControl.Document.Range.Start.ToInt()));
                emrMeta.Add(Utilities.AddEmrMarkerContent(naewonDate, naewonKey, new EmrEndMarkerMeta(""), endHeaderPosition));
                #endregion
            }
            else
            {
                foreach (KeyValuePair<string, UserData> pair in metaDictionary)
                {
                    if (pair.Value is PdfMeta)
                    {
                        CustomMarkSchema schema = new CustomMarkSchema(0, pair.Value);
                        emrMeta.Add(schema);
                    }
                }
            }

            //comment or ParagraphMarker
            foreach (CustomMark customMark in richEditControl.Document.CustomMarks)
            {
                CustomMarkSchema schema = new CustomMarkSchema(customMark.Position.ToInt(), customMark.UserData as UserData);
                emrMeta.Add(schema);
            }
            emrXml = richEditControl.WordMLText;

            richEditControl.Document.EndUpdate();
            return emrMeta;
        }

        public void SetParagraphStyleNormal(DocumentRange range)
        {
            try
            {
                ParagraphCollection paragraphs = richEditControl.Document.GetParagraphs(range);
                foreach (Paragraph prg in paragraphs)
                {
                    prg.Style = richEditControl.Document.ParagraphStyles["Normal"];
                }

            }
            catch (Exception) { /*do nothing here */}
        }

        public void Upload(string filePath)
        {
            //TODO need override this test code

            // MED-10181
            //string uploadAddress = ConfigurationManager.AppSettings["UploadBaseUri"]; //http://10.1.20.149:8010/upload
            string uploadAddress = Utility.GetConfig("UploadBaseUri", UserInfo.VpnYn);

            string uploadToken = ConfigurationManager.AppSettings["UploadToken"]; //"1234"
            Uri address = new Uri(uploadAddress);
            Utilities.UploadFile(address, filePath, uploadToken, UserInfo.HospCode, Bunho);
        }

        private void richEditControl_PopupMenuShowing(object sender, DevExpress.XtraRichEdit.PopupMenuShowingEventArgs e)
        {
            DXSubMenuItem root = new DXSubMenuItem("Choose Root Tag");
            root.BeginGroup = true;
            DXSubMenuItem node = new DXSubMenuItem("Choose Node Tag");
            foreach (string tag in DataProvider.Instance.Tags.Keys)
            {
                DXMenuItem rootItem = new DXMenuItem(tag, ContextMenu_TagSelected);
                rootItem.Tag = tag;
                root.Items.Add(rootItem);

                foreach (string subTag in DataProvider.Instance.Tags[tag])
                {
                    DXMenuItem subItem = new DXMenuItem(string.Format("{0}-{1}", tag, subTag), ContextMenu_TagSelected);
                    subItem.Tag = string.Format("{0}-{1}", tag, subTag);
                    node.Items.Add(subItem);
                }
            }
            e.Menu.RemoveMenuItem(RichEditCommandId.IncreaseIndent);
            e.Menu.RemoveMenuItem(RichEditCommandId.DecreaseIndent);
            e.Menu.RemoveMenuItem(RichEditCommandId.ShowFontForm);
            e.Menu.RemoveMenuItem(RichEditCommandId.ShowParagraphForm);
            e.Menu.RemoveMenuItem(RichEditCommandId.ShowNumberingListForm);
            e.Menu.RemoveMenuItem(RichEditCommandId.CreateBookmark);

            e.Menu.Items.Insert(5, root);
            e.Menu.Items.Insert(6, node);

            //DXSubMenuItem removeTag = new DXSubMenuItem("Remove Tag", new EventHandler(RemoveTagContextMenuClicked));
            DXMenuItem removeTag = new DXMenuItem("Remove Tag");
            removeTag.Click += RemoveTagOnClick;
            e.Menu.Items.Insert(7, removeTag);

            DXMenuItem bookmark = new DXMenuItem("Bookmark", menu_addComment, imageList1.Images[2]);
            bookmark.BeginGroup = true;
            e.Menu.Items.Insert(8, bookmark);
        }

        private void menu_addComment(object sender, EventArgs e)
        {
            AddComment();
        }

        /// <summary>
        /// Handle new Remove Tag context menu item clicked event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void RemoveTagOnClick(object sender, EventArgs eventArgs)
        {
            DocumentPosition pos1 = richEditControl.Document.CaretPosition;
            Paragraph paragraph = richEditControl.Document.GetParagraph(pos1);
            SetParagraphToNormal(paragraph);
        }

        private void SetParagraphToNormal(Paragraph paragraph)
        {            
            if (paragraph != null && paragraph.Style != null)
            {
                paragraph.Style = richEditControl.Document.ParagraphStyles["Normal"];
            }
            ParagraphCollection collection = richEditControl.Document.GetParagraphs(richEditControl.Document.Selection);
            OCS2015U06Businesses.SwitchParagraphStyle(richEditControl, collection, "Normal", barTagOptions.EditValue.ToString());
        }

        private void ContextMenu_TagSelected(object sender, EventArgs eventArgs)
        {
            richEditControl.Document.BeginUpdate();
            DXMenuItem item = (DXMenuItem)sender;
            ParagraphCollection collection = richEditControl.Document.GetParagraphs(richEditControl.Document.Selection);
            OCS2015U06Businesses.SwitchParagraphStyle(richEditControl, collection, item.Tag.ToString(), barTagOptions.EditValue.ToString());
            foreach (Paragraph paragraph in collection)
            {
                paragraph.Style = GetActiveParagraphStyle(item.Tag.ToString());
            }

            richEditControl.Document.EndUpdate();
        }

        private ParagraphStyle GetActiveParagraphStyle(string name)
        {
            foreach (ParagraphStyle style in richEditControl.Document.ParagraphStyles)
            {
                if (!style.IsDeleted && style.Name.Equals(name))
                {
                    return style;
                }
            }
            return null;
        }

        public void Reset(bool isApplyTem)
        {
            richEditControl.CreateNewDocument();
            richEditControl.Document.AppendText(" ");
            BindGridComment();
            if (isApplyTem) BindStyles();
            metaDictionary.Clear();
            hashFileNameDict.Clear();
            _newlyAddedImages.Clear();
        }

        public void LoadRecordFromCache(string emrXml, List<CustomMarkSchema> emrMeta)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(emrXml);
            MemoryStream stream = new MemoryStream(byteArray);
            richEditControl.CreateNewDocument();
            //richEditControl.Document.AppendText(" ");
            BindStyles();
            richEditControl.Document.AppendDocumentContent(stream, DocumentFormat.WordML);
            richEditControl.Document.BeginUpdate();
            if (emrMeta != null)
            {
                for (int i = emrMeta.Count - 1; i >= 0; i--)
                {
                    CustomMarkSchema schema = emrMeta[i];
                    DocumentPosition pos = richEditControl.Document.CreatePosition(schema.Position);
                    if (schema.UserData.Type == CustomMarkType.Comment || schema.UserData.Type == CustomMarkType.ParagraphMarker)
                    {
                        UserData meta = schema.UserData;
                        //richEditControl.Document.CreateCustomMark(pos, JsonConvert.SerializeObject(meta));
                        richEditControl.Document.CreateCustomMark(pos, meta);
                    }
                    else if (schema.UserData.Type == CustomMarkType.Pdf)
                    {
                        PdfMeta meta = schema.UserData as PdfMeta;
                        if (!metaDictionary.ContainsKey(meta.Thumbnail.Checksum))
                            metaDictionary.Add(meta.Thumbnail.Checksum, meta);
                    }
                }
            }
            richEditControl.Document.EndUpdate();

            OCS2015U06Businesses.DisplayTagBeforeParagraph(this.richEditControl,
                    this.richEditControl.Document.GetParagraphs(this.richEditControl.Document.Range),
                    string.IsNullOrEmpty(barTagOptions.EditValue as string) ? StringEnum.GetStringValue(TagOption.Both) : barTagOptions.EditValue.ToString());
            //GetComments();
        }

        private void fontSizeIncreaseItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// Set title text for the form
        /// </summary>
        /// <param name="titleText"></param>
        public void SetFormTitle(string titleText)
        {
            this.Text = titleText;
        }

        private void richEditControl_MouseMove(object sender, MouseEventArgs e)
        {
            IHIS.OCSO.Utilities.DisplayBookmark(e, this.richEditControl, Form.MousePosition);
        }

        private void richEditControl_CustomMarkDraw(object sender, RichEditCustomMarkDrawEventArgs e)
        {
        }

        private int clickPosition = -1;

        private bool editingImage = false;

        private void richEditControl_Click(object sender, EventArgs e)
        {
            if (!editingImage)
                clickPosition = richEditControl.Document.Selection.Start.ToInt();
        }

        /// <summary>
        /// Dictionary to store original file name of inserted files
        /// </summary>
        private Dictionary<string, string> hashFileNameDict = new Dictionary<string, string>();

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            object item = ((BarEditItem)sender).EditValue;
            OCS2015U06Businesses.DisplayTagBeforeParagraph(
                richEditControl,
                richEditControl.Document.Paragraphs,
                item == null ? StringEnum.GetStringValue(TagOption.Both) : item.ToString());
        }
    }
}