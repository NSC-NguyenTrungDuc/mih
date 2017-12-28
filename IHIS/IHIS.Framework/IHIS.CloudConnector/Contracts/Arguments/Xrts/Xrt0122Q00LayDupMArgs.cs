using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class Xrt0122Q00LayDupMArgs : IContractArgs
    {
    protected bool Equals(Xrt0122Q00LayDupMArgs other)
    {
        return string.Equals(_buwiBunryu, other._buwiBunryu);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Xrt0122Q00LayDupMArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_buwiBunryu != null ? _buwiBunryu.GetHashCode() : 0);
    }

    private String _buwiBunryu;

        public String BuwiBunryu
        {
            get { return this._buwiBunryu; }
            set { this._buwiBunryu = value; }
        }

        public Xrt0122Q00LayDupMArgs() { }

        public Xrt0122Q00LayDupMArgs(String buwiBunryu)
        {
            this._buwiBunryu = buwiBunryu;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Xrt0122Q00LayDupMRequest();
        }
    }
}