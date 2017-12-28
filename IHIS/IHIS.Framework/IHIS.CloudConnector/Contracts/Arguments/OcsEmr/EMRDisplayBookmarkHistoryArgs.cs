using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class EMRDisplayBookmarkHistoryArgs : IContractArgs
    {
    protected bool Equals(EMRDisplayBookmarkHistoryArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((EMRDisplayBookmarkHistoryArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _bunho;
        private String _hospCode;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public EMRDisplayBookmarkHistoryArgs() { }

        public EMRDisplayBookmarkHistoryArgs(String bunho, String hospCode)
        {
            this._bunho = bunho;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.EMRDisplayBookmarkHistoryRequest();
        }
    }
}