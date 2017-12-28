using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00GrdPaListArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00GrdPaListArgs other)
        {
            return _rbxJubsuChecked.Equals(other._rbxJubsuChecked) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00GrdPaListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _rbxJubsuChecked.GetHashCode();
                hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private Boolean _rbxJubsuChecked;
        private String _fromDate;
        private String _toDate;
        private String _bunho;

        public Boolean RbxJubsuChecked
        {
            get { return this._rbxJubsuChecked; }
            set { this._rbxJubsuChecked = value; }
        }

        public String FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public CPL2010U00GrdPaListArgs() { }

        public CPL2010U00GrdPaListArgs(Boolean rbxJubsuChecked, String fromDate, String toDate, String bunho)
        {
            this._rbxJubsuChecked = rbxJubsuChecked;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00GrdPaListRequest();
        }
    }
}