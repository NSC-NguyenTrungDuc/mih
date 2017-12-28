using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class DOC4003U00GetHospArgs : IContractArgs
    {
    protected bool Equals(DOC4003U00GetHospArgs other)
    {
        return string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DOC4003U00GetHospArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_hospCode != null ? _hospCode.GetHashCode() : 0);
    }

    private String _hospCode;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public DOC4003U00GetHospArgs() { }

        public DOC4003U00GetHospArgs(String hospCode)
        {
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DOC4003U00GetHospRequest();
        }
    }
}