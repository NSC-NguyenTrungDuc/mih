using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U31SaveLayoutArgs : IContractArgs
    {
        private List<OCS2015U31GetEmrTemplateInfo> _listTemplate = new List<OCS2015U31GetEmrTemplateInfo>();
        private List<OCS2015U31GetTemplateTagsInfo> _listTemplateTag = new List<OCS2015U31GetTemplateTagsInfo>();
        private String _userId;
        private String _type;
        private String _deptCode;
        private String _doctorCode;
        private String _cloneYn;

        public List<OCS2015U31GetEmrTemplateInfo> ListTemplate
        {
            get { return this._listTemplate; }
            set { this._listTemplate = value; }
        }

        public List<OCS2015U31GetTemplateTagsInfo> ListTemplateTag
        {
            get { return this._listTemplateTag; }
            set { this._listTemplateTag = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String DeptCode
        {
            get { return this._deptCode; }
            set { this._deptCode = value; }
        }

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String CloneYn
        {
            get { return this._cloneYn; }
            set { this._cloneYn = value; }
        }

        public OCS2015U31SaveLayoutArgs() { }

        public OCS2015U31SaveLayoutArgs(List<OCS2015U31GetEmrTemplateInfo> listTemplate, List<OCS2015U31GetTemplateTagsInfo> listTemplateTag, String userId, String type, String deptCode, String doctorCode, String cloneYn)
        {
            this._listTemplate = listTemplate;
            this._listTemplateTag = listTemplateTag;
            this._userId = userId;
            this._type = type;
            this._deptCode = deptCode;
            this._doctorCode = doctorCode;
            this._cloneYn = cloneYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31SaveLayoutRequest();
        }
    }
}