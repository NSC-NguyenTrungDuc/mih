using System;

namespace EmrDocker.Models
{
    public class VnTagPrintInfo
    {
        private String _tagCode;
        private String _tagName;
        private String _tagContent;
        private bool _isParentTag;

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

        public bool IsParentTag
        {
            get { return _isParentTag; }
            set { _isParentTag = value; }
        }

        public VnTagPrintInfo()
        {
        }

        public VnTagPrintInfo(string tagCode, string tagName, string tagContent, bool isParentTag)
        {
            _tagCode = tagCode;
            _tagName = tagName;
            _tagContent = tagContent;
            _isParentTag = isParentTag;
        }
    }
}