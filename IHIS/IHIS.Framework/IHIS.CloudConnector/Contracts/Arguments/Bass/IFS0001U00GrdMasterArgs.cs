using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0001U00GrdMasterArgs : IContractArgs
    {
        protected bool Equals(IFS0001U00GrdMasterArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_acctType, other._acctType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0001U00GrdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_acctType != null ? _acctType.GetHashCode() : 0);
            }
        }

        private String _codeType;
        private String _acctType;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String AcctType
        {
            get { return this._acctType; }
            set { this._acctType = value; }
        }

        public IFS0001U00GrdMasterArgs() { }

        public IFS0001U00GrdMasterArgs(String codeType, String acctType)
        {
            this._codeType = codeType;
            this._acctType = acctType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0001U00GrdMasterRequest();
        }
    }
}