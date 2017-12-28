using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT7001Q01LayRadioHistoryArgs : IContractArgs
    {
    protected bool Equals(XRT7001Q01LayRadioHistoryArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_partCode, other._partCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT7001Q01LayRadioHistoryArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_partCode != null ? _partCode.GetHashCode() : 0);
        }
    }

    private String _bunho;
        private String _partCode;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String PartCode
        {
            get { return this._partCode; }
            set { this._partCode = value; }
        }

        public XRT7001Q01LayRadioHistoryArgs() { }

        public XRT7001Q01LayRadioHistoryArgs(String bunho, String partCode)
        {
            this._bunho = bunho;
            this._partCode = partCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT7001Q01LayRadioHistoryRequest();
        }
    }
}