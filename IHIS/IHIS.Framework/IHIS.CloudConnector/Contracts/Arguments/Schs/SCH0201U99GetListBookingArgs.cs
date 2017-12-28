using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH0201U99GetListBookingArgs : IContractArgs
    {
    protected bool Equals(SCH0201U99GetListBookingArgs other)
    {
        return string.Equals(_hospCodeLink, other._hospCodeLink) && string.Equals(_bunhoLink, other._bunhoLink) && string.Equals(_reserDate, other._reserDate) && string.Equals(_reserTime, other._reserTime) && string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201U99GetListBookingArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunhoLink != null ? _bunhoLink.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserTime != null ? _reserTime.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hospCodeLink;
        private String _bunhoLink;
        private String _reserDate;
        private String _reserTime;
        private String _hangmogCode;

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String ReserTime
        {
            get { return this._reserTime; }
            set { this._reserTime = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public SCH0201U99GetListBookingArgs() { }

        public SCH0201U99GetListBookingArgs(String hospCodeLink, String bunhoLink, String reserDate, String reserTime, String hangmogCode)
        {
            this._hospCodeLink = hospCodeLink;
            this._bunhoLink = bunhoLink;
            this._reserDate = reserDate;
            this._reserTime = reserTime;
            this._hangmogCode = hangmogCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH0201U99GetListBookingRequest();
        }
    }
}