using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0122U00GrdMcodeArgs : IContractArgs
    {
    protected bool Equals(XRT0122U00GrdMcodeArgs other)
    {
        return string.Equals(_buwiBunryu, other._buwiBunryu);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0122U00GrdMcodeArgs) obj);
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

        public XRT0122U00GrdMcodeArgs() { }

        public XRT0122U00GrdMcodeArgs(String buwiBunryu)
        {
            this._buwiBunryu = buwiBunryu;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0122U00GrdMcodeRequest();
        }
    }
}