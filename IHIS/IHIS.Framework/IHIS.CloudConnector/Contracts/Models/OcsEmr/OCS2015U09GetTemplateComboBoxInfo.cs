using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U09GetTemplateComboBoxInfo
    {
        private String _emrTemplateId;
        private String _emrTemplateTypeId;
        private String _templateName;
        private String _templateContent;
        private String _description;
        private String _permissionType;
        private String _sysId;
        private String _updId;
        private String _defaultYn;
        private List<OCS2015U31EmrTagGetTemplateTagsInfo> _tags = new List<OCS2015U31EmrTagGetTemplateTagsInfo>();
        private String _templateCode;

        public String EmrTemplateId
        {
            get { return this._emrTemplateId; }
            set { this._emrTemplateId = value; }
        }

        public String EmrTemplateTypeId
        {
            get { return this._emrTemplateTypeId; }
            set { this._emrTemplateTypeId = value; }
        }

        public String TemplateName
        {
            get { return this._templateName; }
            set { this._templateName = value; }
        }

        public String TemplateContent
        {
            get { return this._templateContent; }
            set { this._templateContent = value; }
        }

        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public String PermissionType
        {
            get { return this._permissionType; }
            set { this._permissionType = value; }
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

        public String DefaultYn
        {
            get { return this._defaultYn; }
            set { this._defaultYn = value; }
        }

        public List<OCS2015U31EmrTagGetTemplateTagsInfo> Tags
        {
            get { return this._tags; }
            set { this._tags = value; }
        }

        public String TemplateCode
        {
            get { return this._templateCode; }
            set { this._templateCode = value; }
        }

        public OCS2015U09GetTemplateComboBoxInfo() { }

        public OCS2015U09GetTemplateComboBoxInfo(String emrTemplateId, String emrTemplateTypeId, String templateName, String templateContent, String description, String permissionType, String sysId, String updId, String defaultYn, List<OCS2015U31EmrTagGetTemplateTagsInfo> tags, String templateCode)
        {
            this._emrTemplateId = emrTemplateId;
            this._emrTemplateTypeId = emrTemplateTypeId;
            this._templateName = templateName;
            this._templateContent = templateContent;
            this._description = description;
            this._permissionType = permissionType;
            this._sysId = sysId;
            this._updId = updId;
            this._defaultYn = defaultYn;
            this._tags = tags;
            this._templateCode = templateCode;
        }

    }
}