using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0801U00GrdOCS0802Args : IContractArgs
    {
    protected bool Equals(OCS0801U00GrdOCS0802Args other)
    {
        return string.Equals(_patStatus, other._patStatus);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0801U00GrdOCS0802Args) obj);
    }

    public override int GetHashCode()
    {
        return (_patStatus != null ? _patStatus.GetHashCode() : 0);
    }

    private String _patStatus;

        public String PatStatus
        {
            get { return this._patStatus; }
            set { this._patStatus = value; }
        }

        public OCS0801U00GrdOCS0802Args() { }

        public OCS0801U00GrdOCS0802Args(String patStatus)
        {
            this._patStatus = patStatus;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0801U00GrdOCS0802Request();
        }
    }
}