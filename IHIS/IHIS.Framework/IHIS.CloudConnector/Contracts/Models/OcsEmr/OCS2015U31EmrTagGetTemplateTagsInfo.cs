using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U31EmrTagGetTemplateTagsInfo
    {
        private String _tagId;
        private String _tagCode;
        private String _tagName;
        private String _type;
        private String _defaultContent;
        private String _tagDisplayText;
        private String _description;
        private String _filterFlg;
        private String _tagParent;
        private String _sysId;

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

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String DefaultContent
        {
            get { return this._defaultContent; }
            set { this._defaultContent = value; }
        }

        public String TagDisplayText
        {
            get { return this._tagDisplayText; }
            set { this._tagDisplayText = value; }
        }

        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public String FilterFlg
        {
            get { return this._filterFlg; }
            set { this._filterFlg = value; }
        }

        public String TagParent
        {
            get { return this._tagParent; }
            set { this._tagParent = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public OCS2015U31EmrTagGetTemplateTagsInfo() { }

        public OCS2015U31EmrTagGetTemplateTagsInfo(String tagId, String tagCode, String tagName, String type, String defaultContent, String tagDisplayText, String description, String filterFlg, String tagParent, String sysId)
        {
            this._tagId = tagId;
            this._tagCode = tagCode;
            this._tagName = tagName;
            this._type = type;
            this._defaultContent = defaultContent;
            this._tagDisplayText = tagDisplayText;
            this._description = description;
            this._filterFlg = filterFlg;
            this._tagParent = tagParent;
            this._sysId = sysId;
        }

    }
}