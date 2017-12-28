using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH0201U10LayReserInfoQueryEndArgs : IContractArgs
    {
    protected bool Equals(SCH0201U10LayReserInfoQueryEndArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_reserDate, other._reserDate) && string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201U10LayReserInfoQueryEndArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
        private String _reserDate;
        private String _gwa;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public SCH0201U10LayReserInfoQueryEndArgs() { }

        public SCH0201U10LayReserInfoQueryEndArgs(String bunho, String reserDate, String gwa)
        {
            this._bunho = bunho;
            this._reserDate = reserDate;
            this._gwa = gwa;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH0201U10LayReserInfoQueryEndRequest();
        }
    }
}