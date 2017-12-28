using System;
using System.Collections.Generic;
using System.Text;

namespace OCS2015U30.Models
{
    class TagData
    {
        private string _tagId;
        private string _tagCode;
        private string _tagName;
        public string TagId
        {
            set { _tagId = value; }
            get { return _tagId; }
        }
        public string TagCode
        {
            set { _tagCode = value; }
            get { return _tagCode; }
        }
        public string TagName
        {
            set { _tagName = value; }
            get { return _tagName; }
        }
        public TagData() { }
        public TagData(string tagId, string tagCode, string tagName)
        {
            this.TagId = tagId;
            this.TagCode = tagCode;
            this.TagName = tagName;
        }
    }
}
