using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U31GetEmrTemplateArgs : IContractArgs
    {
        private String _userId;
        private String _departCode;
        private String _doctorCode;
        private String _type;
        private String _commonYn;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String DepartCode
        {
            get { return this._departCode; }
            set { this._departCode = value; }
        }

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String CommonYn
        {
            get { return this._commonYn; }
            set { this._commonYn = value; }
        }

        public OCS2015U31GetEmrTemplateArgs() { }

        public OCS2015U31GetEmrTemplateArgs(String userId, String departCode, String doctorCode, String type, String commonYn)
        {
            this._userId = userId;
            this._departCode = departCode;
            this._doctorCode = doctorCode;
            this._type = type;
            this._commonYn = commonYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31GetEmrTemplateRequest();
        }
    }
}