using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00OrderCancelGrdOrderArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00OrderCancelGrdOrderArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00OrderCancelGrdOrderArgs) obj);
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

        public CPL2010U00OrderCancelGrdOrderArgs() { }

        public CPL2010U00OrderCancelGrdOrderArgs(String bunho, String orderDate)
        {
            this._bunho = bunho;
            this._orderDate = orderDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00OrderCancelGrdOrderRequest();
        }
    }
}