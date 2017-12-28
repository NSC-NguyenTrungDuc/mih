using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00GrdComment3Args : IContractArgs
    {
    protected bool Equals(XRT1002U00GrdComment3Args other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00GrdComment3Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
        }
    }

    private String _bunho;
        private String _orderDate;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public XRT1002U00GrdComment3Args() { }

        public XRT1002U00GrdComment3Args(String bunho, String orderDate)
        {
            this._bunho = bunho;
            this._orderDate = orderDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00GrdComment3Request();
        }
    }
}