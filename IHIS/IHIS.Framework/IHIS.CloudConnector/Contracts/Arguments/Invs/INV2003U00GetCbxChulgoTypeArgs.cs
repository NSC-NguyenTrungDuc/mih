using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV2003U00GetCbxChulgoTypeArgs : IContractArgs
    {
        private String _hospCode;
        private String _codeType;

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

        public INV2003U00GetCbxChulgoTypeArgs() { }

        public INV2003U00GetCbxChulgoTypeArgs(String hospCode, String codeType)
        {
            this._hospCode = hospCode;
            this._codeType = codeType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV2003U00GetCbxChulgoTypeRequest();
        }
    }
}