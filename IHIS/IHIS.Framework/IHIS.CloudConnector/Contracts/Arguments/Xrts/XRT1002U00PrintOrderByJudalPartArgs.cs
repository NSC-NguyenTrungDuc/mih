using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00PrintOrderByJudalPartArgs : IContractArgs
    {
    protected bool Equals(XRT1002U00PrintOrderByJudalPartArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_hangmogCodes, other._hangmogCodes);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00PrintOrderByJudalPartArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_hangmogCodes != null ? _hangmogCodes.GetHashCode() : 0);
        }
    }

    private String _bunho;
        private String _hangmogCodes;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HangmogCodes
        {
            get { return this._hangmogCodes; }
            set { this._hangmogCodes = value; }
        }

        public XRT1002U00PrintOrderByJudalPartArgs() { }

        public XRT1002U00PrintOrderByJudalPartArgs(String bunho, String hangmogCodes)
        {
            this._bunho = bunho;
            this._hangmogCodes = hangmogCodes;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00PrintOrderByJudalPartRequest();
        }
    }
}