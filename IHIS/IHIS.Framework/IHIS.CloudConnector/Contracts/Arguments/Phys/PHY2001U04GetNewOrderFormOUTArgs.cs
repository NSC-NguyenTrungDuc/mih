using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04GetNewOrderFormOUTArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04GetNewOrderFormOUTArgs other)
    {
        return string.Equals(_orderDate, other._orderDate) && string.Equals(_timeHour, other._timeHour) && string.Equals(_timeMin, other._timeMin) && string.Equals(_timeSec, other._timeSec);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04GetNewOrderFormOUTArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_timeHour != null ? _timeHour.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_timeMin != null ? _timeMin.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_timeSec != null ? _timeSec.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _orderDate;
        private String _timeHour;
        private String _timeMin;
        private String _timeSec;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String TimeHour
        {
            get { return this._timeHour; }
            set { this._timeHour = value; }
        }

        public String TimeMin
        {
            get { return this._timeMin; }
            set { this._timeMin = value; }
        }

        public String TimeSec
        {
            get { return this._timeSec; }
            set { this._timeSec = value; }
        }

        public PHY2001U04GetNewOrderFormOUTArgs() { }

        public PHY2001U04GetNewOrderFormOUTArgs(String orderDate, String timeHour, String timeMin, String timeSec)
        {
            this._orderDate = orderDate;
            this._timeHour = timeHour;
            this._timeMin = timeMin;
            this._timeSec = timeSec;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04GetNewOrderFormOUTRequest();
        }
    }
}