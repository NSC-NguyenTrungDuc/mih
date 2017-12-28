namespace IHIS.OCSO.Meta
{
    public class PdfMeta : UserData
    {
        private string filePath;

        private ImageMeta thumbnail;

        public PdfMeta()
            : base(CustomMarkType.Pdf, null)
        {
        }

        public PdfMeta(string checksum, string filePath, ImageMeta thumbnail) : base(CustomMarkType.Pdf, checksum)
        {
            this.filePath = filePath;
            this.thumbnail = thumbnail;
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        public ImageMeta Thumbnail
        {
            get
            {
                return thumbnail;
            }
            set
            {
                this.thumbnail = value;
            }
        }
    }
}