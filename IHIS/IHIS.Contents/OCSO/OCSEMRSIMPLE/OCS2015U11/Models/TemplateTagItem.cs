namespace EmrDocker.Models
{
    public class TemplateTagItem
    {
        private string _tagCode;
        private string _tagName;
        private string _tagContent;
        private bool isPlainText;

        public string TagCode
        { 
            get { return _tagCode; }
            set { _tagCode = value; } 
        }
        public string TagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        public string TagContent
        {
            get { return _tagContent; }
            set { _tagContent = value; }
        }

        public bool IsPlainText
        {
            get
            {
                return isPlainText;
            }
            set
            {
                isPlainText = value;
            }
        }

        public TemplateTagItem(bool isPlainText)
        {
            this.isPlainText = isPlainText;
        }

        public TemplateTagItem(string tagCode, string tagContent, bool isPlainText)
        {
            this._tagCode = tagCode;
            this._tagContent = tagContent;
            this.isPlainText = isPlainText;
        }

        public TemplateTagItem(string tagCode, string tagName, string tagContent, bool isPlainText)
        {
            this._tagCode = tagCode;
            this._tagName = tagName;
            this._tagContent = tagContent;
            this.isPlainText = isPlainText;
        }
    }
}
