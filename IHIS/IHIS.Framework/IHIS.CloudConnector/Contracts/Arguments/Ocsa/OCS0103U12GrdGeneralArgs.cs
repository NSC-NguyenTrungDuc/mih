using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U12GrdGeneralArgs : IContractArgs
    {
    protected bool Equals(OCS0103U12GrdGeneralArgs other)
    {
        return string.Equals(_filter, other._filter) && string.Equals(_yakKijunCode, other._yakKijunCode) && string.Equals(_orderDate, other._orderDate) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12GrdGeneralArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_filter != null ? _filter.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_yakKijunCode != null ? _yakKijunCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _filter;
        private String _yakKijunCode;
        private String _orderDate;
        private String _hangmogCode;
        private String _pageNumber;
        private String _offset;

        public String Filter
        {
            get { return this._filter; }
            set { this._filter = value; }
        }

        public String YakKijunCode
        {
            get { return this._yakKijunCode; }
            set { this._yakKijunCode = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public OCS0103U12GrdGeneralArgs() { }

        public OCS0103U12GrdGeneralArgs(String filter, String yakKijunCode, String orderDate, String hangmogCode, String pageNumber, String offset)
        {
            this._filter = filter;
            this._yakKijunCode = yakKijunCode;
            this._orderDate = orderDate;
            this._hangmogCode = hangmogCode;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U12GrdGeneralRequest();
        }
    }
}