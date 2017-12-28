using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U31EmrTemplateTypeInfo
    {
        private String _templateTypeId;
        private String _typeCode;
        private String _typeName;
        private String _description;

        public String TemplateTypeId
        {
            get { return this._templateTypeId; }
            set { this._templateTypeId = value; }
        }

        public String TypeCode
        {
            get { return this._typeCode; }
            set { this._typeCode = value; }
        }

        public String TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public OCS2015U31EmrTemplateTypeInfo() { }

        public OCS2015U31EmrTemplateTypeInfo(String templateTypeId, String typeCode, String typeName, String description)
        {
            this._templateTypeId = templateTypeId;
            this._typeCode = typeCode;
            this._typeName = typeName;
            this._description = description;
        }

    }
}