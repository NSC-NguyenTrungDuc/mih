using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00GrdPaStatusArgs : IContractArgs
    {
    protected bool Equals(XRT1002U00GrdPaStatusArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00GrdPaStatusArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
        }
    }

    private String _bunho;
        private String _hangmogCode;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public XRT1002U00GrdPaStatusArgs() { }

        public XRT1002U00GrdPaStatusArgs(String bunho, String hangmogCode)
        {
            this._bunho = bunho;
            this._hangmogCode = hangmogCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00GrdPaStatusRequest();
        }
    }
}