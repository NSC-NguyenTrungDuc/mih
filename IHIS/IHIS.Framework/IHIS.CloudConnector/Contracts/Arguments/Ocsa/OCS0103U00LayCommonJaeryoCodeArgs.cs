using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00LayCommonJaeryoCodeArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00LayCommonJaeryoCodeArgs other)
    {
        return string.Equals(_jaeryoCode, other._jaeryoCode) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00LayCommonJaeryoCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_jaeryoCode != null ? _jaeryoCode.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _jaeryoCode;
        private String _hospCode;

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00LayCommonJaeryoCodeArgs() { }

        public OCS0103U00LayCommonJaeryoCodeArgs(String jaeryoCode, String hospCode)
        {
            this._jaeryoCode = jaeryoCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00LayCommonJaeryoCodeRequest();
        }
    }
}