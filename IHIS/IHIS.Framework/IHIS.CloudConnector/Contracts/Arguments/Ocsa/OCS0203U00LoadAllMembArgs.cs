using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0203U00LoadAllMembArgs : IContractArgs
    {
    protected bool Equals(OCS0203U00LoadAllMembArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0203U00LoadAllMembArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
        }
    }

    private String _hospCode;
        private String _gwa;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public OCS0203U00LoadAllMembArgs() { }

        public OCS0203U00LoadAllMembArgs(String hospCode, String gwa)
        {
            this._hospCode = hospCode;
            this._gwa = gwa;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0203U00LoadAllMembRequest();
        }
    }
}