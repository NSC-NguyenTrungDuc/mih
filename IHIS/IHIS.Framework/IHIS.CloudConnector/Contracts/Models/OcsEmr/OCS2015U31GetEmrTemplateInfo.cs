using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U31GetEmrTemplateInfo
    {
        private String _templateId;
        private String _templateCode;
        private String _templateName;
        private String _description;
        private String _typeId;
        private String _sysId;
        private String _defaultFlg;
        private String _templateTypeId;
        private String _rowState;
        private String _useYn;

        public String TemplateId
        {
            get { return this._templateId; }
            set { this._templateId = value; }
        }

        public String TemplateCode
        {
            get { return this._templateCode; }
            set { this._templateCode = value; }
        }

        public String TemplateName
        {
            get { return this._templateName; }
            set { this._templateName = value; }
        }

        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public String TypeId
        {
            get { return this._typeId; }
            set { this._typeId = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String DefaultFlg
        {
            get { return this._defaultFlg; }
            set { this._defaultFlg = value; }
        }

        public String TemplateTypeId
        {
            get { return this._templateTypeId; }
            set { this._templateTypeId = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public String UseYn
        {
            get { return this._useYn; }
            set { this._useYn = value; }
        }

        public OCS2015U31GetEmrTemplateInfo() { }

        public OCS2015U31GetEmrTemplateInfo(String templateId, String templateCode, String templateName, String description, String typeId, String sysId, String defaultFlg, String templateTypeId, String rowState, String useYn)
        {
            this._templateId = templateId;
            this._templateCode = templateCode;
            this._templateName = templateName;
            this._description = description;
            this._typeId = typeId;
            this._sysId = sysId;
            this._defaultFlg = defaultFlg;
            this._templateTypeId = templateTypeId;
            this._rowState = rowState;
            this._useYn = useYn;
        }

    }
}