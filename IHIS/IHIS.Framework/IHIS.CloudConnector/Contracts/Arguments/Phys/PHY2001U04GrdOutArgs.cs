using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04GrdOutArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04GrdOutArgs other)
    {
        return string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04GrdOutArgs) obj);
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

        public PHY2001U04GrdOutArgs() { }

        public PHY2001U04GrdOutArgs(String orderDate)
        {
            this._orderDate = orderDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04GrdOutRequest();
        }
    }
}