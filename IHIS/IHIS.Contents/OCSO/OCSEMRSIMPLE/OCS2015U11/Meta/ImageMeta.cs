namespace IHIS.OCSO.Meta
{
    public class ImageMeta : UserData
    {        
        private string filePath;

        private float scaleX;

        private float scaleY;

        private string emrcFilePath;

        public ImageMeta()
            : base(CustomMarkType.Image, null)
        {
        }

        public ImageMeta(string checksum, string filePath, float scaleX, float scaleY) : base(CustomMarkType.Image, checksum)
        {            
            this.filePath = filePath;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
        }

        public ImageMeta(string checksum, string filePath, float scaleX, float scaleY, string emrcFilePath)
            : base(CustomMarkType.Image, checksum)
        {
            this.filePath = filePath;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
            this.emrcFilePath = emrcFilePath;
        }

        public string EmrcFilePath
        {
            get
            {
                return emrcFilePath;
            }
            set
            {
                emrcFilePath = value;
            }
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

        public float ScaleX
        {
            get
            {
                return scaleX;
            }
            set
            {
                this.scaleX = value;
            }
        }

        public float ScaleY
        {
            get
            {
                return scaleY;
            }
            set
            {
                this.scaleY = value;
            }
        }
    }
}