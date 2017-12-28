using System;

namespace EmrDocker.Models
{
    public class TagPrintInfo
    {
        private String _tagCode;
        private String _tagName; 
        private String _tagContent;
        private bool _isImage;
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

        public string TagContent
        {
            get { return _tagContent; }
            set { _tagContent = value; }
        }

        public bool IsImage
        {
            get { return _isImage; }
            set { _isImage = value; }
        }

        public string ImageLink
        {
            get { return _imageLink; }
            set { _imageLink = value; }
        }

        public TagPrintInfo()
        {
        }

        public TagPrintInfo(string tagCode, string tagName, string tagContent, bool isImage, string imageLink)
        {
            _tagCode = tagCode;
            _tagName = tagName;
            _tagContent = tagContent;
            _isImage = isImage;
            _imageLink = imageLink;
        }
    }
}