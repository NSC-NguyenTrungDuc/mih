using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0118U00GrdOCS0118Args : IContractArgs
    {
    protected bool Equals(OCS0118U00GrdOCS0118Args other)
    {
        return string.Equals(_hangmogNameInx, other._hangmogNameInx);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0118U00GrdOCS0118Args) obj);
    }

    public override int GetHashCode()
    {
        return (_hangmogNameInx != null ? _hangmogNameInx.GetHashCode() : 0);
    }

    private String _hangmogNameInx;

        public String HangmogNameInx
        {
            get { return this._hangmogNameInx; }
            set { this._hangmogNameInx = value; }
        }

        public OCS0118U00GrdOCS0118Args() { }

        public OCS0118U00GrdOCS0118Args(String hangmogNameInx)
        {
            this._hangmogNameInx = hangmogNameInx;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0118U00GrdOCS0118Request();
        }
    }
}