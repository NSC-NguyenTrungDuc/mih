using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0223U00GrdOCS0223Args : IContractArgs
    {
    protected bool Equals(OCS0223U00GrdOCS0223Args other)
    {
        return string.Equals(_jundalPart, other._jundalPart) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0223U00GrdOCS0223Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_jundalPart != null ? _jundalPart.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _jundalPart;
        private String _hospCode;

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0223U00GrdOCS0223Args() { }

        public OCS0223U00GrdOCS0223Args(String jundalPart, String hospCode)
        {
            this._jundalPart = jundalPart;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0223U00GrdOCS0223Request();
        }
    }
}