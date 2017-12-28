using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U30EmrTagSaveLayoutInfo
    {
        private String _tagId;
        private String _tagName;
        private String _tagCode;
        private String _tagDisplayText;
        private String _description;
        private String _tagLevel;
        private String _tagParent;
        private String _filterFlg;
        private String _rowState;
        private String _sysId;

        public String TagId
        {
            get { return this._tagId; }
            set { this._tagId = value; }
        }

        public String TagName
        {
            get { return this._tagName; }
            set { this._tagName = value; }
        }

        public String TagCode
        {
            get { return this._tagCode; }
            set { this._tagCode = value; }
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

        public String TagLevel
        {
            get { return this._tagLevel; }
            set { this._tagLevel = value; }
        }

        public String TagParent
        {
            get { return this._tagParent; }
            set { this._tagParent = value; }
        }

        public String FilterFlg
        {
            get { return this._filterFlg; }
            set { this._filterFlg = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public OCS2015U30EmrTagSaveLayoutInfo() { }

        public OCS2015U30EmrTagSaveLayoutInfo(String tagId, String tagName, String tagCode, String tagDisplayText, String description, String tagLevel, String tagParent, String filterFlg, String rowState, String sysId)
        {
            this._tagId = tagId;
            this._tagName = tagName;
            this._tagCode = tagCode;
            this._tagDisplayText = tagDisplayText;
            this._description = description;
            this._tagLevel = tagLevel;
            this._tagParent = tagParent;
            this._filterFlg = filterFlg;
            this._rowState = rowState;
            this._sysId = sysId;
        }

    }
}