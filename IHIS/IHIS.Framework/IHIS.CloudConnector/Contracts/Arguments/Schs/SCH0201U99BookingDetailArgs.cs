using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH0201U99BookingDetailArgs : IContractArgs
    {
    protected bool Equals(SCH0201U99BookingDetailArgs other)
    {
        return string.Equals(_jundalTable, other._jundalTable) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_reservation, other._reservation) && string.Equals(_reserDate, other._reserDate) && Equals(_emrLinkItem, other._emrLinkItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201U99BookingDetailArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reservation != null ? _reservation.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_emrLinkItem != null ? _emrLinkItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _jundalTable;
        private String _jundalPart;
        private String _reservation;
        private String _reserDate;
        private List<SCH0201U99EMRLinkInfo> _emrLinkItem = new List<SCH0201U99EMRLinkInfo>();

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String Reservation
        {
            get { return this._reservation; }
            set { this._reservation = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public List<SCH0201U99EMRLinkInfo> EmrLinkItem
        {
            get { return this._emrLinkItem; }
            set { this._emrLinkItem = value; }
        }

        public SCH0201U99BookingDetailArgs() { }

        public SCH0201U99BookingDetailArgs(String jundalTable, String jundalPart, String reservation, String reserDate, List<SCH0201U99EMRLinkInfo> emrLinkItem)
        {
            this._jundalTable = jundalTable;
            this._jundalPart = jundalPart;
            this._reservation = reservation;
            this._reserDate = reserDate;
            this._emrLinkItem = emrLinkItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH0201U99BookingDetailRequest();
        }
    }
}