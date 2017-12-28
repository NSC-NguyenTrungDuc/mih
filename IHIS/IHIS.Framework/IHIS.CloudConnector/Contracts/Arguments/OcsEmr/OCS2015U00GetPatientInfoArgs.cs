using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U00GetPatientInfoArgs : IContractArgs
    {
    protected bool Equals(OCS2015U00GetPatientInfoArgs other)
    {
        return string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U00GetPatientInfoArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_bunho != null ? _bunho.GetHashCode() : 0);
    }

    private String _bunho;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public OCS2015U00GetPatientInfoArgs() { }

        public OCS2015U00GetPatientInfoArgs(String bunho)
        {
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetPatientInfoRequest();
        }
    }
}