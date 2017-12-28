using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U31GetTemplateTagsInfo
    {
        private String _tagId;
        private String _tagCode;
        private String _tagName;
        private String _type;
        private String _defaultContent;
        private String _tagParent;
        private String _tagChild;
        private String _tagLevel;
        private String _templateId;
        private String _rowState;

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

        public String TagParent
        {
            get { return this._tagParent; }
            set { this._tagParent = value; }
        }

        public String TagChild
        {
            get { return this._tagChild; }
            set { this._tagChild = value; }
        }

        public String TagLevel
        {
            get { return this._tagLevel; }
            set { this._tagLevel = value; }
        }

        public String TemplateId
        {
            get { return this._templateId; }
            set { this._templateId = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS2015U31GetTemplateTagsInfo() { }

        public OCS2015U31GetTemplateTagsInfo(String tagId, String tagCode, String tagName, String type, String defaultContent, String tagParent, String tagChild, String tagLevel, String templateId, String rowState)
        {
            this._tagId = tagId;
            this._tagCode = tagCode;
            this._tagName = tagName;
            this._type = type;
            this._defaultContent = defaultContent;
            this._tagParent = tagParent;
            this._tagChild = tagChild;
            this._tagLevel = tagLevel;
            this._templateId = templateId;
            this._rowState = rowState;
        }

    }
}