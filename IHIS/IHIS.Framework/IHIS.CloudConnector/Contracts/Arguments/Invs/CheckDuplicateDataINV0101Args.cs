using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class CheckDuplicateDataINV0101Args : IContractArgs
    {
        private String _codeType;
        private String _code;
        private String _isMaster;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String IsMaster
        {
            get { return this._isMaster; }
            set { this._isMaster = value; }
        }

        public CheckDuplicateDataINV0101Args() { }

        public CheckDuplicateDataINV0101Args(String codeType, String code, String isMaster)
        {
            this._codeType = codeType;
            this._code = code;
            this._isMaster = isMaster;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CheckDuplicateDataINV0101Request();
        }
    }
}