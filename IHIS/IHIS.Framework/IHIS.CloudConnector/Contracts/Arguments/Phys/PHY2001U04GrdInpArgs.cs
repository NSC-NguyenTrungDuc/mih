using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04GrdInpArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04GrdInpArgs other)
    {
        return string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04GrdInpArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_orderDate != null ? _orderDate.GetHashCode() : 0);
    }

    private String _orderDate;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public PHY2001U04GrdInpArgs() { }

        public PHY2001U04GrdInpArgs(String orderDate)
        {
            this._orderDate = orderDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04GrdInpRequest();
        }
    }
}