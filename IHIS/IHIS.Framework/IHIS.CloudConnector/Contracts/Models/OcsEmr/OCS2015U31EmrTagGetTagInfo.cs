using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U31EmrTagGetTagInfo
    {
        private String _tagId;
        private String _tagCode;
        private String _tagName;
        private String _tagDisplayText;

        public String TagId
        {
            get { return this._tagId; }
            set { this._tagId = value; }
        }

        public String TagCode
        {
            get { return this._tagCode; }
            set { this._tagCode = value; }
        }

        public String TagName
        {
            get { return this._tagName; }
            set { this._tagName = value; }
        }

        public String TagDisplayText
        {
            get { return this._tagDisplayText; }
            set { this._tagDisplayText = value; }
        }

        public OCS2015U31EmrTagGetTagInfo() { }

        public OCS2015U31EmrTagGetTagInfo(String tagId, String tagCode, String tagName, String tagDisplayText)
        {
            this._tagId = tagId;
            this._tagCode = tagCode;
            this._tagName = tagName;
            this._tagDisplayText = tagDisplayText;
        }

    }
}