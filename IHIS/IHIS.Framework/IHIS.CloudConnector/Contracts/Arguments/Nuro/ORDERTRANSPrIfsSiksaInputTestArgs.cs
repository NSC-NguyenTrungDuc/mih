using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSPrIfsSiksaInputTestArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSPrIfsSiksaInputTestArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_fromDate, other._fromDate) && string.Equals(_fromSik, other._fromSik) && string.Equals(_toDate, other._toDate) && string.Equals(_toSik, other._toSik);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSPrIfsSiksaInputTestArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromSik != null ? _fromSik.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toSik != null ? _toSik.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _bunho;
        private String _fromDate;
        private String _fromSik;
        private String _toDate;
        private String _toSik;

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

        public String FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }

        public String FromSik
        {
            get { return this._fromSik; }
            set { this._fromSik = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public String ToSik
        {
            get { return this._toSik; }
            set { this._toSik = value; }
        }

        public ORDERTRANSPrIfsSiksaInputTestArgs() { }

        public ORDERTRANSPrIfsSiksaInputTestArgs(String hospCode, String bunho, String fromDate, String fromSik, String toDate, String toSik)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._fromDate = fromDate;
            this._fromSik = fromSik;
            this._toDate = toDate;
            this._toSik = toSik;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSPrIfsSiksaInputTestRequest();
        }
    }
}