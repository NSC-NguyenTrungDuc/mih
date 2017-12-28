using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Endo
{
    [Serializable]
    public class END1001U02GrdComment3Args : IContractArgs
    {
        protected bool Equals(END1001U02GrdComment3Args other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((END1001U02GrdComment3Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _bunho;
        private String _orderDate;

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

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public END1001U02GrdComment3Args() { }

        public END1001U02GrdComment3Args(String hospCode, String bunho, String orderDate)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._orderDate = orderDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.END1001U02GrdComment3Request();
        }
    }
}