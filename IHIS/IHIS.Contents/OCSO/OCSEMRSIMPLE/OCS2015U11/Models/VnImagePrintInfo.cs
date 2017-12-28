using System;

namespace EmrDocker.Models
{
    public class VnImagePrintInfo
    {
        private String _tagCode; 
        private String _tagName;
        private String _imageLink;

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

        public string ImageLink
        {
            get { return _imageLink; }
            set { _imageLink = value; }
        }

        public VnImagePrintInfo()
        {
        }

        public VnImagePrintInfo(string tagCode, string tagName, string imageLink)
        {
            _tagCode = tagCode;
            _tagName = tagName;
            _imageLink = imageLink;
        }
    }
}