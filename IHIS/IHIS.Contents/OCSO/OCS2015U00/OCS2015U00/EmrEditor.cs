namespace IHIS.OCSO
{
    using System;
    using System.Collections.Generic;
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

    using IHIS.OCSO.Meta;

    using Newtonsoft.Json;

    public partial class EmrEditor : UserControl {

        public int CurrentTagStart = 0;
        public string intellisenseBuffer = "";
        public bool PassInputToTextbox = true;

        public EmrEditor()
        {
            InitializeComponent();

            foreach (string tag in DataProvider.Instance.Tags.Keys)
            {
                ParagraphStyle tagStyle = richEditControl.Document.ParagraphStyles.CreateNew();
                tagStyle.Name = tag;
                richEditControl.Document.ParagraphStyles.Add(tagStyle);
                foreach (string subTag in DataProvider.Instance.Tags[tag])
                {
                    ParagraphStyle subTagStyle = richEditControl.Document.ParagraphStyles.CreateNew();
                    subTagStyle.Name = String.Format("{0}-{1}", tag, subTag);                    
                    richEditControl.Document.ParagraphStyles.Add(subTagStyle);
                }
            }

            repositoryEmrTemplate.Items.Add("MailMergeSimple.rtf");
            repositoryEmrTemplate.Items.Add("CustomTemplate.rtf");            

            OfficeSkins.Register();
            BonusSkins.Register();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2010 Silver");
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
                    else
                    {
                        ImageMeta meta = metaDictionary[imageHash] as ImageMeta;
                        if (meta != null)
                        {
                            if (meta.EmrcFilePath != null)
                            {
                                DataProvider.ImageEditorInstance.Edit(
                                    meta.EmrcFilePath,
                                    delegate(byte[] data, string path)
                                    {
                                        richEditControl.Document.Delete(imgCollection[0].Range);
                                    });
                            }
                            else
                            {
                                EditImage(imgCollection[0]);
                            }
                        }
                    }
                }
                else
                {
                    EditImage(imgCollection[0]);                    
                }                              
            }
        }

        private void EditImage(DocumentImage image)
        {
            using (MemoryStream memory = new MemoryStream(image.Image.GetImageBytesSafe(RichEditImageFormat.Jpeg)))
            {
                DataProvider.ImageEditorInstance.Edit(
                    memory.ToArray(),
                    delegate(byte[] data)
                        {
                            richEditControl.Document.Delete(image.Range);
                            richEditControl.Document.InsertImage(
                                richEditControl.Document.CaretPosition,
                                new StreamDocumentImageSource(new MemoryStream(data)));
                        });
            }
        }

        private void lbTags_KeyUp(object sender, KeyEventArgs e)
        {
            Object ObjToSelect = new Object();
            if (e.KeyCode != Keys.OemPeriod)
            {
                if (e.KeyCode != Keys.Back)
                {
                    bool startswith = false;
                    intellisenseBuffer += e.KeyCode;
                    foreach (object obj in lbTags.Items)
                    {
                        string str = obj.ToString();
                        if (str != "")
                        {
                            startswith = str.StartsWith(intellisenseBuffer, true, null);
                            if (startswith == true)
                            {
                                ObjToSelect = obj;
                                break;
                            }
                        }
                    }
                    if (startswith == false)
                    {
                        intellisenseBuffer = "";
                        lbTags.Hide();
                    }
                    lbTags.SelectedItem = ObjToSelect;
                }   
            }                
            if (e.KeyCode == Keys.Back)
            {
                richEditControl.Document.Delete(richEditControl.Document.CreateRange(richEditControl.Document.CaretPosition.ToInt() - 1,1));
            }
            if (e.KeyCode == Keys.Return)
            {
                richEditControl.Document.Replace(richEditControl.Document.CreateRange(CurrentTagStart + 1, richEditControl.Document.CaretPosition.ToInt() - CurrentTagStart), lbTags.SelectedItem.ToString());                
            }
        }

        private void lbTags_KeyPress(object sender, KeyPressEventArgs e)
        {
            richEditControl.Document.InsertText(richEditControl.Document.CaretPosition, e.KeyChar.ToString());
        }

        private void richEditControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.D3 && (e.Modifiers == Keys.Shift))
            if (e.KeyCode == Keys.OemPeriod && e.Shift == false)
            {
                CurrentTagStart = richEditControl.Document.CaretPosition.ToInt() + 1;
                Rectangle rectangle = richEditControl.GetBoundsFromPosition(richEditControl.Document.CaretPosition);
                Rectangle r2 = Units.DocumentsToPixels(rectangle, richEditControl.DpiX, richEditControl.DpiY);                
                Point p = new Point(r2.X, r2.Y + 50);
                p.Y += (int)richEditControl.Font.GetHeight() * 2;
                lbTags.Location = p;
                lbTags.Show();
                ActiveControl = lbTags;                
            }            
        }

        private void richEditControl_KeyDown(object sender, KeyEventArgs e)
        {
            /*string styleName = changeStyleItem1.EditValue.ToString();
            richEditControl.Document.ParagraphStyles[styleName].BackColor = SystemColors.ControlDark;*/
            /*Document doc = richEditControl.Document;
            DocumentRange range = doc.Selection;
            ParagraphProperties pp = doc.BeginUpdateParagraphs(range);
            pp.Style.BackColor = SystemColors.ControlDark;
            doc.EndUpdateParagraphs(pp);*/

            //TODO: Missing undo functionality for pdf file.
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < richEditControl.Document.CustomMarks.Count; i++)
                {
                    if (richEditControl.Document.CustomMarks[i].Position.ToInt() == richEditControl.Document.CaretPosition.ToInt())
                    {
                        richEditControl.Document.DeleteCustomMark(richEditControl.Document.CustomMarks[i]);
                    }
                }     
            }

        }

        private ParagraphStyle activeStyle = null;

        private void richEditControl_SelectionChanged(object sender, EventArgs e)
        {
            Document doc = richEditControl.Document;
            DocumentRange range = doc.Selection;
            ParagraphProperties pp = doc.BeginUpdateParagraphs(range);
            if (activeStyle != null)
            {
                activeStyle.BackColor = Color.Transparent;
            }

            if (range.Length == 0 && !pp.Style.Name.Equals("Normal"))
            {
                pp.Style.BackColor = SystemColors.ControlDark;
                activeStyle = pp.Style;
            }
            else
            {
                activeStyle = null;
            }
            doc.EndUpdateParagraphs(pp);
        }

        private void changeStyleItem1_EditValueChanged(object sender, EventArgs e)
        {
            ChangeStyleItem item = (ChangeStyleItem)sender;
            Document doc = richEditControl.Document;
            DocumentRange range = doc.Selection;
            CharacterProperties pp = doc.BeginUpdateCharacters(range);
            if (pp != null && item.EditValue.Equals("Normal"))
            {
                pp.BackColor = Color.Transparent;
            }
            doc.EndUpdateCharacters(pp);
        }

        private void cboTemplate_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem item = (BarEditItem)sender;
            if (item.EditValue != null && item.EditValue.ToString().Trim().Length > 0)
            {
                EmrTemplateMerge.Merge(richEditControl, EmrTemplateMerge.GenerateEmployeeList(), item.EditValue.ToString().Trim());   
            }            
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

        private void insertPdfItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DocumentPosition pos = richEditControl.Document.Selection.Start;
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf Files|*.pdf";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;            

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string originalFilePath = dialog.FileName;
                string pdfLink = Utilities.GetRelativePath(Utilities.NextSequence("K01") + ".pdf");
                File.Copy(originalFilePath, pdfLink);

                string pdfHash = Utilities.CalculateFileChecksum(pdfLink);
                string thumbnailFilePath;

                FileDocumentImageSource image = GetPdfThumbnail(pdfLink, out thumbnailFilePath);                
                string thumbnailHash = Utilities.CalculateImageChecksum(image.Stream);
                if(!metaDictionary.ContainsKey(thumbnailHash))
                    metaDictionary.Add(thumbnailHash, new PdfMeta(pdfHash, pdfLink, new ImageMeta(thumbnailHash, thumbnailFilePath, 0.25f, 0.25f)));

                richEditControl.Document.BeginUpdate();
                DocumentImage docImage = richEditControl.Document.InsertImage(pos, new FileDocumentImageSource(thumbnailFilePath));
                docImage.ScaleX = 0.25f;
                docImage.ScaleY = 0.25f;
                richEditControl.Document.EndUpdate();
            }
        }

        private FileDocumentImageSource GetPdfThumbnail(string pdfFilePath, out string thumbnailFilePath)
        {
            thumbnailFilePath = Utilities.GetRelativePath(Utilities.NextSequence("K01") + ".jpeg");
            GhostscriptWrapper.GeneratePageThumb(pdfFilePath, thumbnailFilePath, 1, 24, 24);            
            return new FileDocumentImageSource(thumbnailFilePath);
        }

        private void insertCommentItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DocumentRange range = richEditControl.Document.Selection;            
            
            frmComment frm = new frmComment(0, range.Start.ToInt(), range.Length, String.Empty, true);
            frm.CommentUpdated += new frmComment.CommentUpdateHandler(frm_CommentUpdated);
            frm.ShowDialog(this);
        }

        void frm_CommentUpdated(object sender, CommentEventArgs e)
        {            
            if(!e.IsNew && !e.Cancel && e.Comment.Trim().Length == 0)
            {
                //Remove empty comment
                for (int i = 0; i < richEditControl.Document.CustomMarks.Count; i++)
                {
                    CustomMark mark = richEditControl.Document.CustomMarks[i];
                    if (mark.Position.ToInt() == e.Position)
                    {
                        //make sure it is correct updating one.
                        CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
                        if (meta != null && meta.Id == e.CommentId)
                        {
                            richEditControl.Document.DeleteCustomMark(mark);
                            break;
                        }
                    }
                }
            }

            //Create new customMark for both insert & update
            if (e.Comment.Trim().Length > 0)
            {
                CommentMeta meta = new CommentMeta(e.Length, "dainguyen", e.Comment.Trim());
                DocumentPosition pos = richEditControl.Document.CreatePosition(e.Position);
                richEditControl.Document.CreateCustomMark(pos, JsonConvert.SerializeObject(meta));
            }
            BindGridComment();
        }

        private void BindGridComment()
        {
            List<CommentMeta> comments = new List<CommentMeta>();
            foreach (CustomMark mark in richEditControl.Document.CustomMarks)
            {
                CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
                if (meta != null) comments.Add(meta);
            }
            gridControl1.DataSource = comments;
        }

        private List<CustomMarkSchema> customMarks = new List<CustomMarkSchema>();

        private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();

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
            richEditControl.Document.BeginUpdate();
            List<CustomMarkSchema> emrMeta = new List<CustomMarkSchema>();
            DocumentImageCollection collection = richEditControl.Document.GetImages(richEditControl.Document.Range);
            for(int i = collection.Count - 1; i >= 0; i--)
            {
                DocumentImage image = collection[i];
                string hash = Utilities.CalculateImageChecksum(image.Image);
                if (!metaDictionary.ContainsKey(hash))
                {
                    //this is a new image --> save the image to folder                    
                    string filePath = Utilities.GetRelativePath(Utilities.NextSequence("K01") + "." + image.Image.RawFormat);
                    SaveStreamToFile(filePath, image.Image.GetImageBytesSafe(image.Image.RawFormat));
                    ImageMeta meta = new ImageMeta(hash, filePath, image.ScaleX, image.ScaleY);
                    CustomMarkSchema schema = new CustomMarkSchema(image.Range.Start.ToInt(), meta);
                    emrMeta.Add(schema);
                    Upload(filePath);
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
            
            //comment
            foreach (CustomMark customMark in richEditControl.Document.CustomMarks)
            {
                UserData userData = JsonConvert.DeserializeObject<CommentMeta>(customMark.UserData.ToString());
                CustomMarkSchema schema = new CustomMarkSchema(customMark.Position.ToInt(), userData);
                emrMeta.Add(schema);
            }
            emrXml = richEditControl.WordMLText;       
            
            richEditControl.Document.EndUpdate();
            return emrMeta;
        }

        public void Upload(string filePath)
        {
            //TODO need override this test code
            /*string destPath = "D:\\dev\\media.nextop.asia\\k01\\";
            string fileName = Utilities.GetFileName(filePath);
            File.Move(filePath, destPath + fileName);*/

            /*Uri address = new Uri("http://10.1.20.149:8010/upload");
            Utilities.UploadFile(address, filePath, "1234");*/
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
                    DXMenuItem subItem = new DXMenuItem(string.Format("{0} - {1}", tag, subTag), ContextMenu_TagSelected);
                    subItem.Tag = string.Format("{0}-{1}", tag, subTag);
                    node.Items.Add(subItem);
                }                
            }
            e.Menu.Items.Insert(5, root);
            e.Menu.Items.Insert(6, node);
        }

        private void ContextMenu_TagSelected(object sender, EventArgs eventArgs)
        {
            richEditControl.Document.BeginUpdate();
            DXMenuItem item = (DXMenuItem)sender;

            foreach (Paragraph paragraph in richEditControl.Document.GetParagraphs(richEditControl.Document.Selection))
            {
                paragraph.Style = richEditControl.Document.ParagraphStyles[item.Tag.ToString()];
            }

            richEditControl.Document.EndUpdate();
        }
    }
}