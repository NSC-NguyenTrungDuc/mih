using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0201U00ToolTipArgs : IContractArgs
    {
    protected bool Equals(XRT0201U00ToolTipArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00ToolTipArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
        }
    }

    private String _hospCode;
        private String _bunho;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public XRT0201U00ToolTipArgs() { }

        public XRT0201U00ToolTipArgs(String hospCode, String bunho)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0201U00ToolTipRequest();
        }
    }
}