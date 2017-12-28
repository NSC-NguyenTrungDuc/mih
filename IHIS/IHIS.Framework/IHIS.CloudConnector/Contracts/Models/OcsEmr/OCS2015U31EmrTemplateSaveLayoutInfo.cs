using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U31EmrTemplateSaveLayoutInfo
    {
        private String _templateId;
        private String _templateTypeId;
        private String _templateName;
        private String _templateContent;
        private String _description;
        private String _permissionType;
        private String _hospCode;
        private String _rowState;
        private String _sysId;

        public String TemplateId
        {
            get { return this._templateId; }
            set { this._templateId = value; }
        }

        public String TemplateTypeId
        {
            get { return this._templateTypeId; }
            set { this._templateTypeId = value; }
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

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
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

        public OCS2015U31EmrTemplateSaveLayoutInfo() { }

        public OCS2015U31EmrTemplateSaveLayoutInfo(String templateId, String templateTypeId, String templateName, String templateContent, String description, String permissionType, String hospCode, String rowState, String sysId)
        {
            this._templateId = templateId;
            this._templateTypeId = templateTypeId;
            this._templateName = templateName;
            this._templateContent = templateContent;
            this._description = description;
            this._permissionType = permissionType;
            this._hospCode = hospCode;
            this._rowState = rowState;
            this._sysId = sysId;
        }

    }
}