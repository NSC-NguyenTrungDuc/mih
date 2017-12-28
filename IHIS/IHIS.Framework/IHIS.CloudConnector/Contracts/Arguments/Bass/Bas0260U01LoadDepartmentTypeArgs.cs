using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    public class Bas0260U01LoadDepartmentTypeArgs : IContractArgs
    {
        private String _hospCode;
        private String _codeType;
        private String _language;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        public Bas0260U01LoadDepartmentTypeArgs() { }

        public Bas0260U01LoadDepartmentTypeArgs(String hospCode, String codeType, String language)
        {
            this._hospCode = hospCode;
            this._codeType = codeType;
            this._language = language;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Bas0260U01LoadDepartmentTypeRequest();
        }
    }
}