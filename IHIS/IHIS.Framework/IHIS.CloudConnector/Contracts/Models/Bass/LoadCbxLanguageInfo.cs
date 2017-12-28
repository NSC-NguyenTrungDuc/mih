using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    public class LoadCbxLanguageInfo
    {
        private String _propertyId;
        private String _propertyCode;
        private String _propertyName;
        private String _propertyValue;
        private String _propertyType;
        private String _moduleType;
        private String _defaultFlg;
        private String _sortNo;
        private String _description;
        private String _locale;
        private String _sysId;
        private String _updId;
        private String _created;
        private String _updated;
        private String _activeFlg;

        public String PropertyId
        {
            get { return this._propertyId; }
            set { this._propertyId = value; }
        }

        public String PropertyCode
        {
            get { return this._propertyCode; }
            set { this._propertyCode = value; }
        }

        public String PropertyName
        {
            get { return this._propertyName; }
            set { this._propertyName = value; }
        }

        public String PropertyValue
        {
            get { return this._propertyValue; }
            set { this._propertyValue = value; }
        }

        public String PropertyType
        {
            get { return this._propertyType; }
            set { this._propertyType = value; }
        }

        public String ModuleType
        {
            get { return this._moduleType; }
            set { this._moduleType = value; }
        }

        public String DefaultFlg
        {
            get { return this._defaultFlg; }
            set { this._defaultFlg = value; }
        }

        public String SortNo
        {
            get { return this._sortNo; }
            set { this._sortNo = value; }
        }

        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public String Locale
        {
            get { return this._locale; }
            set { this._locale = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String Created
        {
            get { return this._created; }
            set { this._created = value; }
        }

        public String Updated
        {
            get { return this._updated; }
            set { this._updated = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public LoadCbxLanguageInfo() { }

        public LoadCbxLanguageInfo(String propertyId, String propertyCode, String propertyName, String propertyValue, String propertyType, String moduleType, String defaultFlg, String sortNo, String description, String locale, String sysId, String updId, String created, String updated, String activeFlg)
        {
            this._propertyId = propertyId;
            this._propertyCode = propertyCode;
            this._propertyName = propertyName;
            this._propertyValue = propertyValue;
            this._propertyType = propertyType;
            this._moduleType = moduleType;
            this._defaultFlg = defaultFlg;
            this._sortNo = sortNo;
            this._description = description;
            this._locale = locale;
            this._sysId = sysId;
            this._updId = updId;
            this._created = created;
            this._updated = updated;
            this._activeFlg = activeFlg;
        }

    }
}