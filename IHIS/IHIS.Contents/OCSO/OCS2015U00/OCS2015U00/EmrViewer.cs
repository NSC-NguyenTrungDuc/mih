using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    using System.Diagnostics;
    using System.IO;

    using DevExpress.XtraBars;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraRichEdit;
    using DevExpress.XtraRichEdit.API.Native;
    using DevExpress.XtraRichEdit.API.Native.Implementation;
    using DevExpress.XtraRichEdit.Commands;

    using IHIS.CloudConnector.Caching;
    using IHIS.OCSO.Meta;

    using Newtonsoft.Json;

    public partial class EmrViewer : UserControl
    {
        private Dictionary<string, string> displayedTags = new Dictionary<string, string>();

        private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();

        public EmrViewer()
        {
            InitializeComponent();            

            BindMenu(barTag1, barSubTag1);
            BindMenu(barTag2, barSubTag2);
            BindMenu(barTag3, barSubTag3);
            BindMenu(barTag4, barSubTag4);
            BindMenu(barTag5, barSubTag5);
            BindMenu(barTag6, barSubTag6);
        }

        private void BindMenu(BarEditItem barTag, BarEditItem barSubTag)
        {
            RepositoryItemComboBox cboTag = (RepositoryItemComboBox)barTag.Edit;
            RepositoryItemComboBox cboSubTag = (RepositoryItemComboBox)barSubTag.Edit;
            cboSubTag.Items.Clear();
            cboTag.Items.Clear();
            cboTag.Items.Add("");
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
            foreach (BarItemLink item in subTagBar.ItemLinks)
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
                        }   
                    }                    
                }
            }
            
            ShowHideTag();
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

        public void LoadMeta(List<CustomMarkSchema> emrMeta, string emrXml)
        {
            //richEditControl.LoadDocument(GenerateStreamFromString(emrXml), DocumentFormat.WordML);
            int positionOffset = 0;
            if (richEditControl.Document.Range.End.ToInt() > 0)
            {
                richEditControl.Document.AppendParagraph();
                positionOffset = richEditControl.Document.Range.End.ToInt() - 1;
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(emrXml);
            MemoryStream stream = new MemoryStream(byteArray);
            richEditControl.Document.AppendDocumentContent(stream, DocumentFormat.WordML);
            richEditControl.Document.BeginUpdate();   
            if (emrMeta != null)
            {
                List<CommentMeta> comments = new List<CommentMeta>();
                for(int i = emrMeta.Count - 1; i >= 0; i--)
                {
                    CustomMarkSchema schema = emrMeta[i];
                    DocumentPosition pos = richEditControl.Document.CreatePosition(positionOffset + schema.Position);
                    if (schema.UserData.Type == CustomMarkType.Comment)
                    {
                        CommentMeta meta = schema.UserData as CommentMeta;
                        comments.Add(meta);
                        richEditControl.Document.CreateCustomMark(
                            pos,
                            JsonConvert.SerializeObject(meta));
                    }
                    else if (schema.UserData.Type == CustomMarkType.Image)
                    {
                        ImageMeta meta = schema.UserData as ImageMeta;
                        if (!File.Exists(meta.FilePath)) DownloadFile(meta.FilePath);
                        if (meta.EmrcFilePath != null && !File.Exists(meta.EmrcFilePath)) DownloadFile(meta.EmrcFilePath);
                        DocumentImage img = richEditControl.Document.InsertImage(pos, new FileDocumentImageSource(meta.FilePath));
                        img.ScaleX = meta.ScaleX;
                        img.ScaleY = meta.ScaleY;
                        if(!metaDictionary.ContainsKey(meta.Checksum))
                            metaDictionary.Add(meta.Checksum, meta);
                    }
                    else if (schema.UserData.Type == CustomMarkType.Pdf)
                    {
                        PdfMeta meta = schema.UserData as PdfMeta;
                        if (!File.Exists(meta.FilePath)) DownloadFile(meta.FilePath);
                        if (!File.Exists(meta.Thumbnail.FilePath)) DownloadFile(meta.Thumbnail.FilePath);
                        DocumentImage img = richEditControl.Document.InsertImage(pos, new FileDocumentImageSource(meta.Thumbnail.FilePath));
                        img.ScaleX = meta.Thumbnail.ScaleX;
                        img.ScaleY = meta.Thumbnail.ScaleY;
                        if(!metaDictionary.ContainsKey(meta.Thumbnail.Checksum))
                            metaDictionary.Add(meta.Thumbnail.Checksum, meta);
                    }
                }
            }
            richEditControl.Document.EndUpdate();
        }

        private void DownloadFile(string filePath)
        {
            string fileName = Utilities.GetFileName(filePath);
            string mediaHost = "http://media.nextop.asia/k01/";
            Uri assetUrl = new Uri(mediaHost + fileName);
            Utilities.DownloadAssetDataFromUrl(assetUrl, filePath);
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
    }
}